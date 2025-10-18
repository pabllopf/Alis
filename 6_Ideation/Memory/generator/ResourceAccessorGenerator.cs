using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Linq; 
using System;
using System.IO;
using System.IO.Compression; 
using System.Security.Cryptography; // New: required for SHA256
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Alis.Core.Aspect.Memory.Generator
{
    /// <summary>
    /// The resource accessor generator class
    /// </summary>
    /// <seealso cref="IIncrementalGenerator"/>
    [Generator]
    public class ResourceAccessorGenerator : IIncrementalGenerator
    {
        /// <summary>
        /// The resource file name
        /// </summary>
        private const string ResourceFileName = "assets.pak";
        /// <summary>
        /// The registry namespace
        /// </summary>
        private const string RegistryNamespace = "Alis.Core.Aspect.Memory.AssetRegistry";

        /// <summary>
        /// Initializes the context
        /// </summary>
        /// <param name="context">The context</param>
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            // Message: generator initialization
            context.RegisterPostInitializationOutput(ctx => {
                // No se puede usar ctx.ReportDiagnostic en .NETStandard2.0, solo en .NET8.0 y Roslyn >=4.x
                // Si no está disponible, omitir el diagnóstico aquí
            });

            IncrementalValuesProvider<AdditionalText> additional = context.AdditionalTextsProvider;
            IncrementalValueProvider<ImmutableArray<AdditionalText>> pakProvider = additional
                .Where(at => Path.GetFileName(at.Path).Equals(ResourceFileName, StringComparison.OrdinalIgnoreCase))
                .Collect();
            IncrementalValueProvider<ImmutableArray<AdditionalText>> assetFilesProvider = additional
                .Where(at => IsUnderAssets(at.Path))
                .Collect();
            IncrementalValueProvider<((ImmutableArray<AdditionalText> Left, ImmutableArray<AdditionalText> Right) Left, Compilation Right)> combined = pakProvider.Combine(assetFilesProvider).Combine(context.CompilationProvider);

            context.RegisterSourceOutput(combined, (spc, triple) =>
            {
                (ImmutableArray<AdditionalText> Left, ImmutableArray<AdditionalText> Right) pair = triple.Left;
                Compilation compilation = triple.Right;

                if (compilation == null)
                {
                    // Mensaje de advertencia solo si está disponible el método
                    #if NET8_0_OR_GREATER
                    var desc = new DiagnosticDescriptor("ALIS0001", "Compilación nula", "No se pudo obtener la compilación del proyecto", "AOT Resources", DiagnosticSeverity.Warning, true);
                    spc.ReportDiagnostic(Diagnostic.Create(desc, Location.None));
                    #endif
                    return;
                }

                var kind = compilation.Options.OutputKind;
                if (kind != OutputKind.ConsoleApplication && kind != OutputKind.WindowsApplication)
                {
                    #if NET8_0_OR_GREATER
                    var desc = new DiagnosticDescriptor("ALIS0003", "Proyecto no ejecutable", "El generador solo se ejecuta en proyectos ejecutables. Tipo detectado: {0}", "AOT Resources", DiagnosticSeverity.Info, true);
                    spc.ReportDiagnostic(Diagnostic.Create(desc, Location.None, kind.ToString()));
                    #endif
                    return;
                }
                #if NET8_0_OR_GREATER
                var descStart = new DiagnosticDescriptor("ALIS0004", "Generación iniciada", "Iniciando generación de assets.pak para proyecto ejecutable", "AOT Resources", DiagnosticSeverity.Info, true);
                spc.ReportDiagnostic(Diagnostic.Create(descStart, Location.None));
                #endif

                ImmutableArray<AdditionalText> pakFiles = pair.Left;
                ImmutableArray<AdditionalText> assets = pair.Right;

                try
                {
                    byte[] originalBytes = null;
                    string originalHash = string.Empty;
                    string assemblyName = compilation.AssemblyName ?? "DefaultAssembly";

                    if (!pakFiles.IsDefaultOrEmpty && pakFiles.Length > 0)
                    {
                        SourceText pakText = pakFiles[0].GetText();
                        if (pakText != null)
                        {
                            string txt = pakText.ToString();
                            originalBytes = Encoding.UTF8.GetBytes(txt);
                            #if NET8_0_OR_GREATER
                            var descPak = new DiagnosticDescriptor("ALIS0005", "Archivo assets.pak detectado", "Se usará el archivo assets.pak proporcionado", "AOT Resources", DiagnosticSeverity.Info, true);
                            spc.ReportDiagnostic(Diagnostic.Create(descPak, Location.None));
                            #endif
                        }
                    }

                    if (originalBytes == null)
                    {
                        List<(string Path, string Text)> entries = assets
                            .Select(a => (Path: a.Path.Replace('\\','/'), Text: a.GetText()?.ToString() ?? string.Empty))
                            .OrderBy(e => e.Path, StringComparer.OrdinalIgnoreCase)
                            .ToList();
                        originalBytes = CreatePakFromAssetTexts(entries);
                        #if NET8_0_OR_GREATER
                        var descGen = new DiagnosticDescriptor("ALIS0006", "Generando assets.pak", $"Generando assets.pak a partir de {entries.Count} archivos de assets", "AOT Resources", DiagnosticSeverity.Info, true);
                        spc.ReportDiagnostic(Diagnostic.Create(descGen, Location.None));
                        #endif
                    }

                    if (originalBytes != null)
                    {
                        originalHash = CalculateSha256Hash(originalBytes);
                        #if NET8_0_OR_GREATER
                        var descHash = new DiagnosticDescriptor("ALIS0007", "Hash calculado", $"Hash SHA256 de assets.pak: {originalHash}", "AOT Resources", DiagnosticSeverity.Info, true);
                        spc.ReportDiagnostic(Diagnostic.Create(descHash, Location.None));
                        #endif
                    }

                    byte[] compressed = CompressGZip(originalBytes ?? Array.Empty<byte>());
                    #if NET8_0_OR_GREATER
                    var descZip = new DiagnosticDescriptor("ALIS0008", "Compresión finalizada", $"Assets.pak comprimido. Tamaño final: {compressed.Length} bytes", "AOT Resources", DiagnosticSeverity.Info, true);
                    spc.ReportDiagnostic(Diagnostic.Create(descZip, Location.None));
                    #endif

                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < compressed.Length; i++)
                    {
                        sb.Append(compressed[i]);
                        if (i < compressed.Length - 1)
                            sb.Append(',');
                    }

                    string generated = GenerateRegistrationLoader(assemblyName, sb.ToString(), originalHash);
                    spc.AddSource("AssemblyLoader.g.cs", SourceText.From(generated, Encoding.UTF8));
                    #if NET8_0_OR_GREATER
                    var descOk = new DiagnosticDescriptor("ALIS0009", "Generación exitosa", "Archivo AssemblyLoader.g.cs generado correctamente", "AOT Resources", DiagnosticSeverity.Info, true);
                    spc.ReportDiagnostic(Diagnostic.Create(descOk, Location.None));
                    #endif
                }
                catch (Exception ex)
                {
                    #if NET8_0_OR_GREATER
                    DiagnosticDescriptor desc = new DiagnosticDescriptor("ALIS0002", "Generator failure", $"Resource generator failed: {ex.Message}", "AOT Resources", DiagnosticSeverity.Error, true);
                    spc.ReportDiagnostic(Diagnostic.Create(desc, Location.None));
                    #endif
                    
                    throw new InvalidOperationException("ResourceAccessorGenerator failed", ex);
                }
            });
        }

        // Helper: determina si una ruta pertenece a una carpeta "Assets"
        /// <summary>
        /// Ises the under assets using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>The bool</returns>
        private static bool IsUnderAssets(string path)
        {
            if (string.IsNullOrEmpty(path)) return false;
            string p = path.Replace('\\', '/');
            return p.IndexOf("/Assets/", StringComparison.OrdinalIgnoreCase) >= 0 || p.EndsWith("/Assets", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Creates the pak from asset texts using the specified entries
        /// </summary>
        /// <param name="entries">The entries</param>
        /// <returns>The byte array</returns>
        private static byte[] CreatePakFromAssetTexts(IEnumerable<(string Path, string Text)> entries)
        {
            using MemoryStream ms = new MemoryStream();
            using (ZipArchive archive = new ZipArchive(ms, ZipArchiveMode.Create, true))
            {
                bool any = false;
                foreach ((string Path, string Text) e in entries)
                {
                    any = true;
                    string relative = e.Path.Replace('\\', '/');
                    ZipArchiveEntry entry = archive.CreateEntry(relative, CompressionLevel.Optimal);
                    using Stream es = entry.Open();
                    byte[] content = Encoding.UTF8.GetBytes(e.Text ?? string.Empty);
                    es.Write(content, 0, content.Length);
                }

                if (!any)
                {
                    ZipArchiveEntry entry = archive.CreateEntry("placeholder.txt", CompressionLevel.Optimal);
                    using Stream es = entry.Open();
                    byte[] content = Encoding.UTF8.GetBytes($"# Auto-generated placeholder for {ResourceFileName}\n");
                    es.Write(content, 0, content.Length);
                }
            }

            ms.Seek(0, SeekOrigin.Begin);
            return ms.ToArray();
        }

        /// <summary>
        /// Compresses the g zip using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The byte array</returns>
        private static byte[] CompressGZip(byte[] data)
        {
            using MemoryStream output = new MemoryStream();
            using (GZipStream compressor = new GZipStream(output, CompressionLevel.Optimal, true))
            {
                compressor.Write(data ?? Array.Empty<byte>(), 0, data?.Length ?? 0);
            }
            return output.ToArray();
        }

        /// <summary>
        /// Calculates the sha 256 hash using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The string</returns>
        private static string CalculateSha256Hash(byte[] data)
        {
            using SHA256 sha = SHA256.Create();
            byte[] h = sha.ComputeHash(data ?? Array.Empty<byte>());
            return BitConverter.ToString(h).Replace("-", "").ToLowerInvariant();
        }

        /// <summary>
        /// Generates the registration loader using the specified assembly name
        /// </summary>
        /// <param name="assemblyName">The assembly name</param>
        /// <param name="compressedByteDataAsCSharp">The compressed byte data as sharp</param>
        /// <param name="originalHash">The original hash</param>
        /// <returns>The string</returns>
        private string GenerateRegistrationLoader(string assemblyName, string compressedByteDataAsCSharp, string originalHash)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("// <auto-generated/>");
            sb.AppendLine("using System;");
            sb.AppendLine("using System.IO;");
            sb.AppendLine("using System.Runtime.CompilerServices;");
            sb.AppendLine("using System.IO.Compression;");
            sb.AppendLine();
            sb.AppendLine("namespace Alis.Core.Aspect.Memory.Generator");
            sb.AppendLine("{");
            sb.AppendLine("    internal static class ResourceAnchor");
            sb.AppendLine("    {");
            sb.Append("        private const string OriginalHash = \"");
            sb.Append(originalHash ?? string.Empty);
            sb.AppendLine("\";");
            sb.AppendLine();
            sb.AppendLine("        private static readonly byte[] AssetData = new byte[] {");
            if (!string.IsNullOrEmpty(compressedByteDataAsCSharp))
            {
                sb.Append("            ");
                sb.Append(compressedByteDataAsCSharp);
                sb.AppendLine();
            }
            sb.AppendLine("        }; ");
            sb.AppendLine();
            sb.AppendLine("        public static Stream LoadAsset()");
            sb.AppendLine("        {");
            sb.AppendLine("            if (AssetData.Length == 0) throw new InvalidOperationException(\"The resource '" + ResourceFileName + "' was not found or is empty during AOT compilation.\");");
            sb.AppendLine("            var compressedStream = new MemoryStream(AssetData, writable: false);");
            sb.AppendLine("            using var decompressor = new GZipStream(compressedStream, CompressionMode.Decompress);");
            sb.AppendLine("            var decompressedStream = new MemoryStream();");
            sb.AppendLine("            decompressor.CopyTo(decompressedStream);");
            sb.AppendLine("            decompressedStream.Seek(0, SeekOrigin.Begin);");
            sb.AppendLine("            return decompressedStream;");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine();
            sb.AppendLine("    public static class AssemblyLoader");
            sb.AppendLine("    {");
            sb.AppendLine("        [ModuleInitializer]");
            sb.AppendLine("        public static void EnsureLoaded()");
            sb.AppendLine("        {");
            sb.AppendLine("            Func<Stream> assetLoader = ResourceAnchor.LoadAsset;");
            sb.Append("            ");
            sb.Append(RegistryNamespace);
            sb.AppendLine(".RegisterAssembly(\"" + assemblyName + "\", assetLoader);");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}
