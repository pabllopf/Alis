using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis.CSharp;
using System.Linq; 
using System;
using System.IO;
using System.IO.Compression; 
using System.Security.Cryptography; // New: required for SHA256

namespace Alis.Core.Aspect.Memory.Generator
{
    [Generator]
    public class ResourceAccessorGenerator : ISourceGenerator
    {
        private const string ResourceFileName = "assets.pak";
        private const string RegistryNamespace = "Alis.Core.Aspect.Memory.AssetRegistry";

        public void Initialize(GeneratorInitializationContext context)
        {
            // No specific initialization required
        }

        public void Execute(GeneratorExecutionContext context)
        {
            // ----------------------------------------------------------------------
            // 1. Generation condition (exclude pure DLLs)
            // ----------------------------------------------------------------------
            if (context.Compilation.Options.OutputKind == OutputKind.DynamicallyLinkedLibrary)
            {
                return;
            }
            
            var assetFile = context.AdditionalFiles
                .FirstOrDefault(f => Path.GetFileName(f.Path).Equals(ResourceFileName, StringComparison.OrdinalIgnoreCase));

            string compressedByteDataAsCSharp = "";
            string assemblyName = context.Compilation.AssemblyName ?? "DefaultAssembly";
            string originalHash = string.Empty; // Hash of the original file
            
            if (assetFile != null)
            {
                try
                {
                    // Read the original binary (I/O required for embedding)
                    byte[] originalFileBytes = File.ReadAllBytes(assetFile.Path);

                    // ----------------------------------------------------------------------
                    // TRACEABILITY OPTIMIZATION: Calculate SHA256 hash of original file.
                    // ----------------------------------------------------------------------
                    originalHash = CalculateSha256Hash(originalFileBytes);

                    // ----------------------------------------------------------------------
                    // SPEED & SIZE OPTIMIZATION: Compress the data with GZip.
                    // ----------------------------------------------------------------------
                    byte[] compressedBytes = CompressGZip(originalFileBytes);

                    // ----------------------------------------------------------------------
                    // SPEED OPTIMIZATION: Use StringBuilder.
                    // SIZE OPTIMIZATION: Use decimal format and REMOVE space after comma.
                    // ----------------------------------------------------------------------
                    var builder = new StringBuilder();
                    for (int i = 0; i < compressedBytes.Length; i++)
                    {
                        // Append the byte in decimal format (1-3 characters)
                        builder.Append(compressedBytes[i]); 

                        if (i < compressedBytes.Length - 1)
                        {
                            // Append ONLY the comma, without space. (Saves 1 char per byte)
                            builder.Append(',');
                        }
                    }
                    compressedByteDataAsCSharp = builder.ToString();
                }
                catch (Exception ex)
                {
                    // Report diagnostic if I/O fails
                    var diagnostic = Diagnostic.Create(
                        new DiagnosticDescriptor("ALIS0002", "I/O Error in Generator", 
                            $"Failed to read/compress the binary AdditionalFile '{assetFile.Path}': {ex.Message}",
                            "AOT Resources", DiagnosticSeverity.Error, true),
                        Location.None);
                    context.ReportDiagnostic(diagnostic);
                    return;
                }
            }
            else
            {
                // Report a warning if the file was not found.
                 var diagnostic = Diagnostic.Create(
                        new DiagnosticDescriptor("ALIS0001", "Resource not declared", 
                            $"The file '{ResourceFileName}' was not found in AdditionalFiles.",
                            "AOT Resources", DiagnosticSeverity.Warning, true),
                        Location.None);
                context.ReportDiagnostic(diagnostic);
            }

            // ----------------------------------------------------------------------
            // 3. Code generation (now with compressed data and hash)
            // ----------------------------------------------------------------------
            string sourceCode = GenerateRegistrationLoader(assemblyName, compressedByteDataAsCSharp, originalHash);

            context.AddSource("AssemblyLoader.g.cs", SourceText.From(sourceCode, Encoding.UTF8));
        }

        /// <summary>
        /// Compress data using GZip.
        /// </summary>
        private static byte[] CompressGZip(byte[] data)
        {
            using var output = new MemoryStream();
            // CompressionLevel.Fastest optimizes compression speed at the cost of slightly lower compression ratio.
            using (var compressor = new GZipStream(output, CompressionLevel.Fastest, true))
            {
                compressor.Write(data, 0, data.Length);
            }
            return output.ToArray();
        }
        
        /// <summary>
        /// Calculate SHA256 hash of binary data.
        /// </summary>
        private static string CalculateSha256Hash(byte[] data)
        {
            using var sha256 = SHA256.Create();
            byte[] hashBytes = sha256.ComputeHash(data);
            // Convert to lowercase hexadecimal string without dashes.
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
        }

        private string GenerateRegistrationLoader(string assemblyName, string compressedByteDataAsCSharp, string originalHash)
        {
            // If the file could not be read, use an empty array.
            if (string.IsNullOrEmpty(compressedByteDataAsCSharp))
            {
                // Use an empty array without comment for a cleaner generation
                compressedByteDataAsCSharp = "";
            }

            // Use $"" for interpolation: clear and efficient.
            string code = $@"// <auto-generated/>
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.IO.Compression;

namespace Alis.Core.Aspect.Memory.Generator
{{
    /// <summary>
    /// AOT-safe anchor class that contains the static binary resource (compressed).
    /// </summary>
    internal static class ResourceAnchor
    {{
        /// <summary>
        /// SHA256 hash of the original '{ResourceFileName}' file (uncompressed).
        /// Used for traceability.
        /// </summary>
        private const string OriginalHash = ""{originalHash}"";

        // COMPRESSED byte array (decimal format, no spaces).
        private static readonly byte[] AssetData = new byte[] {{
            {compressedByteDataAsCSharp}
        }};

        public static Stream LoadAsset()
        {{
            if (AssetData.Length == 0)
            {{
                throw new InvalidOperationException(""The resource '{ResourceFileName}' was not found or is empty during AOT compilation."");
            }}

            // -------------------------------------------------------------------
            // Runtime decompression logic (AOT-safe)
            // -------------------------------------------------------------------

            // Create a read-only MemoryStream from the static array.
            var compressedStream = new MemoryStream(AssetData, writable: false);

            // Create the decompression stream (GZipStream constructor handles positioning).
            using var decompressor = new GZipStream(compressedStream, CompressionMode.Decompress);

            // Create the destination stream and copy the contents.
            var decompressedStream = new MemoryStream();
            decompressor.CopyTo(decompressedStream);

            // Rewind and return the decompressed stream.
            decompressedStream.Seek(0, SeekOrigin.Begin);

            // Return the MemoryStream. Caller is responsible for disposing it.
            return decompressedStream;
        }}
    }}

    /// <summary>
    /// Static initializer to register this assembly with the central loader.
    /// </summary>
    public static class AssemblyLoader
    {{
        [ModuleInitializer]
        public static void EnsureLoaded()
        {{
            Func<Stream> assetLoader = ResourceAnchor.LoadAsset;

            // Register the delegate loader.
            {RegistryNamespace}.RegisterAssembly(""{assemblyName}"", assetLoader);
        }}
    }}
}}
";
            return code;
        }
    }
}
