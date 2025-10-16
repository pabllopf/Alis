using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis.CSharp;
using System.Linq; 
using System;
using System.IO;
using System.IO.Compression; 
using System.Security.Cryptography; // Nuevo: Necesario para SHA256

namespace Alis.Core.Aspect.Memory.Generator
{
    [Generator]
    public class ResourceAccessorGenerator : ISourceGenerator
    {
        private const string ResourceFileName = "assets.pak";
        private const string RegistryNamespace = "Alis.Core.Aspect.Memory.AssetRegistry";

        public void Initialize(GeneratorInitializationContext context)
        {
            // No se requiere inicialización específica
        }

        public void Execute(GeneratorExecutionContext context)
        {
            // ----------------------------------------------------------------------
            // 1. Condición de Generación (Excluir DLLs puras)
            // ----------------------------------------------------------------------
            if (context.Compilation.Options.OutputKind == OutputKind.DynamicallyLinkedLibrary)
            {
                return;
            }
            
            var assetFile = context.AdditionalFiles
                .FirstOrDefault(f => Path.GetFileName(f.Path).Equals(ResourceFileName, StringComparison.OrdinalIgnoreCase));

            string compressedByteDataAsCSharp = "";
            string assemblyName = context.Compilation.AssemblyName ?? "DefaultAssembly";
            string originalHash = string.Empty; // Hash del archivo original
            
            if (assetFile != null)
            {
                try
                {
                    // Leer el binario original (I/O requerida para incrustación)
                    byte[] originalFileBytes = File.ReadAllBytes(assetFile.Path);

                    // ----------------------------------------------------------------------
                    // OPTIMIZACIÓN DE TRAZABILIDAD: Calcular el Hash del archivo original.
                    // ----------------------------------------------------------------------
                    originalHash = CalculateSha256Hash(originalFileBytes);

                    // ----------------------------------------------------------------------
                    // OPTIMIZACIÓN DE VELOCIDAD Y TAMAÑO: Comprimir los datos con GZip.
                    // ----------------------------------------------------------------------
                    byte[] compressedBytes = CompressGZip(originalFileBytes);

                    // ----------------------------------------------------------------------
                    // OPTIMIZACIÓN DE VELOCIDAD: Usar StringBuilder.
                    // OPTIMIZACIÓN DE TAMAÑO: Usar formato decimal y ELIMINAR ESPACIO tras la coma.
                    // ----------------------------------------------------------------------
                    var builder = new StringBuilder();
                    for (int i = 0; i < compressedBytes.Length; i++)
                    {
                        // Añadir el byte en formato decimal (1-3 caracteres)
                        builder.Append(compressedBytes[i]); 

                        if (i < compressedBytes.Length - 1)
                        {
                            // Añadir SOLO la coma, sin espacio. (Ahorra 1 char por byte)
                            builder.Append(',');
                        }
                    }
                    compressedByteDataAsCSharp = builder.ToString();
                }
                catch (Exception ex)
                {
                    // Reportar error si falla la I/O
                    var diagnostic = Diagnostic.Create(
                        new DiagnosticDescriptor("ALIS0002", "Error de I/O en Generador", 
                            $"Fallo al leer/comprimir el binario del AdditionalFile '{assetFile.Path}': {ex.Message}",
                            "Recursos AOT", DiagnosticSeverity.Error, true),
                        Location.None);
                    context.ReportDiagnostic(diagnostic);
                    return;
                }
            }
            else
            {
                // Reportar advertencia si el archivo no se encontró.
                 var diagnostic = Diagnostic.Create(
                        new DiagnosticDescriptor("ALIS0001", "Recurso no declarado", 
                            $"El archivo '{ResourceFileName}' no fue encontrado en AdditionalFiles.",
                            "Recursos AOT", DiagnosticSeverity.Warning, true),
                        Location.None);
                context.ReportDiagnostic(diagnostic);
            }

            // ----------------------------------------------------------------------
            // 3. Generación del Código (Ahora con datos comprimidos y hash)
            // ----------------------------------------------------------------------
            string sourceCode = GenerateRegistrationLoader(assemblyName, compressedByteDataAsCSharp, originalHash);

            context.AddSource("AssemblyLoader.g.cs", SourceText.From(sourceCode, Encoding.UTF8));
        }

        /// <summary>
        /// Comprime los datos usando GZip.
        /// </summary>
        private static byte[] CompressGZip(byte[] data)
        {
            using var output = new MemoryStream();
            // CompressionLevel.Fastest optimiza la velocidad de compresión, a costa de una tasa de compresión ligeramente menor.
            using (var compressor = new GZipStream(output, CompressionLevel.Fastest, true))
            {
                compressor.Write(data, 0, data.Length);
            }
            return output.ToArray();
        }
        
        /// <summary>
        /// Calcula el hash SHA256 de los datos binarios.
        /// </summary>
        private static string CalculateSha256Hash(byte[] data)
        {
            using var sha256 = SHA256.Create();
            byte[] hashBytes = sha256.ComputeHash(data);
            // Convertir a string hexadecimal en minúsculas sin guiones.
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
        }

        private string GenerateRegistrationLoader(string assemblyName, string compressedByteDataAsCSharp, string originalHash)
        {
            // Si el archivo no se pudo leer, se usa un array vacío.
            if (string.IsNullOrEmpty(compressedByteDataAsCSharp))
            {
                // Usamos un array vacío sin comentario para una generación más limpia
                compressedByteDataAsCSharp = "";
            }
            
            // Usamos $"" para interpolación, que es rápido y legible.
            string code = $@"
// <auto-generated/>
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.IO.Compression; 

namespace Alis.Core.Aspect.Memory.Generator
{{
    /// <summary>
    /// Clase de anclaje AOT-safe que contiene el recurso binario estático (comprimido).
    /// </summary>
    internal static class ResourceAnchor 
    {{ 
        /// <summary>
        /// Hash SHA256 del archivo '{ResourceFileName}' original (sin comprimir).
        /// Utilizado para trazabilidad.
        /// </summary>
        private const string OriginalHash = ""{originalHash}"";
        
        // Array de bytes COMPRIMIDO (formato decimal y sin espacios).
        private static readonly byte[] AssetData = new byte[] {{ 
            {compressedByteDataAsCSharp} 
        }};

        public static Stream LoadAsset()
        {{
            if (AssetData.Length == 0)
            {{
                throw new InvalidOperationException(""El recurso '{ResourceFileName}' no se encontró o está vacío durante la compilación AOT."");
            }}

            // -------------------------------------------------------------------
            // Lógica de Descompresión en tiempo de ejecución (AOT-Safe)
            // -------------------------------------------------------------------
            
            // Creamos un MemoryStream de solo lectura a partir del array estático.
            var compressedStream = new MemoryStream(AssetData, writable: false);
            
            // Creamos el stream de descompresión (el constructor de GZipStream maneja el posicionamiento).
            using var decompressor = new GZipStream(compressedStream, CompressionMode.Decompress);
            
            // Creamos el stream de destino y copiamos el contenido.
            var decompressedStream = new MemoryStream();
            decompressor.CopyTo(decompressedStream);
            
            // Rebobinamos y devolvemos el stream decompressed.
            decompressedStream.Seek(0, SeekOrigin.Begin);
            
            // Devolvemos el MemoryStream. El caller es responsable de disponer de él.
            return decompressedStream;
        }}
    }}

    /// <summary>
    /// Inicializador estático para registrar esta asamblea en el cargador central.
    /// </summary>
    public static class AssemblyLoader
    {{
        [ModuleInitializer] 
        public static void EnsureLoaded()
        {{
            Func<Stream> assetLoader = ResourceAnchor.LoadAsset;
            
            // Registramos el cargador delegado.
            {RegistryNamespace}.RegisterAssembly(""{assemblyName}"", assetLoader);
        }}
    }}
}}
";
            return code;
        }
    }
}
