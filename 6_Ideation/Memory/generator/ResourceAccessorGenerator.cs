using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Linq; 
using System;
using System.IO;
using System.IO.Compression; 
using System.Security.Cryptography; // New: required for SHA256
using System.Collections.Generic;

namespace Alis.Core.Aspect.Memory.Generator
{
    [Generator]
    public class ResourceAccessorGenerator : IIncrementalGenerator
    {
        private const string ResourceFileName = "assets.pak";
        private const string RegistryNamespace = "Alis.Core.Aspect.Memory.AssetRegistry";

        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            // Provider for all additional files
            var additional = context.AdditionalTextsProvider;

            // Provider for a declared assets.pak AdditionalFile (if any)
            var pakProvider = additional
                .Where(at => Path.GetFileName(at.Path).Equals(ResourceFileName, StringComparison.OrdinalIgnoreCase))
                .Collect();

            // Provider for all files that look like they belong to an Assets folder
            var assetFilesProvider = additional
                .Where(at => IsUnderAssets(at.Path))
                .Collect();

            // Combine both providers and the compilation so we can compute a state and only regenerate when something changes
            var combined = pakProvider.Combine(assetFilesProvider).Combine(context.CompilationProvider);

            context.RegisterSourceOutput(combined, (spc, triple) =>
            {
                // triple.Left is the pair (pakFiles, assets), triple.Right is the Compilation
                var pair = triple.Left;
                var compilation = triple.Right;

                var pakFiles = pair.Left; // ImmutableArray<AdditionalText>
                var assets = pair.Right;  // ImmutableArray<AdditionalText>

                try
                {
                    byte[] originalBytes = null;
                    string originalHash = string.Empty;

                    // Determine assembly name from compilation
                    string assemblyName = compilation?.AssemblyName ?? "DefaultAssembly";

                    // Prefer declared assets.pak content if present
                    if (!pakFiles.IsDefaultOrEmpty && pakFiles.Length > 0)
                    {
                        var pakText = pakFiles[0].GetText();
                        if (pakText != null)
                        {
                            var txt = pakText.ToString();
                            originalBytes = Encoding.UTF8.GetBytes(txt);
                        }
                    }

                    // If not present, build a deterministic pak from the AdditionalFiles under Assets
                    if (originalBytes == null)
                    {
                        var entries = assets
                            .Select(a => (Path: a.Path.Replace('\\','/'), Text: a.GetText()?.ToString() ?? string.Empty))
                            .OrderBy(e => e.Path, StringComparer.OrdinalIgnoreCase)
                            .ToList();

                        originalBytes = CreatePakFromAssetTexts(entries);
                    }

                    if (originalBytes != null)
                    {
                        originalHash = CalculateSha256Hash(originalBytes);
                    }

                    var compressed = CompressGZip(originalBytes ?? Array.Empty<byte>());

                    // Convert compressed bytes to comma-separated decimal list
                    var sb = new StringBuilder();
                    for (int i = 0; i < compressed.Length; i++)
                    {
                        sb.Append(compressed[i]);
                        if (i < compressed.Length - 1)
                            sb.Append(',');
                    }

                    string generated = GenerateRegistrationLoader(assemblyName, sb.ToString(), originalHash);
                    spc.AddSource("AssemblyLoader.g.cs", SourceText.From(generated, Encoding.UTF8));
                }
                catch (Exception ex)
                {
                    var desc = new DiagnosticDescriptor("ALIS0002", "Generator failure", $"Resource generator failed: {ex.Message}", "AOT Resources", DiagnosticSeverity.Error, true);
                    spc.ReportDiagnostic(Diagnostic.Create(desc, Location.None));
                }
            });
        }

        // Helper: determina si una ruta pertenece a una carpeta "Assets"
        private static bool IsUnderAssets(string path)
        {
            if (string.IsNullOrEmpty(path)) return false;
            var p = path.Replace('\\', '/');
            return p.IndexOf("/Assets/", StringComparison.OrdinalIgnoreCase) >= 0 || p.EndsWith("/Assets", StringComparison.OrdinalIgnoreCase);
        }

        private static byte[] CreatePakFromAssetTexts(IEnumerable<(string Path, string Text)> entries)
        {
            using var ms = new MemoryStream();
            using (var archive = new ZipArchive(ms, ZipArchiveMode.Create, true))
            {
                bool any = false;
                foreach (var e in entries)
                {
                    any = true;
                    string relative = e.Path.Replace('\\', '/');
                    var entry = archive.CreateEntry(relative, CompressionLevel.Optimal);
                    using var es = entry.Open();
                    byte[] content = Encoding.UTF8.GetBytes(e.Text ?? string.Empty);
                    es.Write(content, 0, content.Length);
                }

                if (!any)
                {
                    var entry = archive.CreateEntry("placeholder.txt", CompressionLevel.Optimal);
                    using var es = entry.Open();
                    var content = Encoding.UTF8.GetBytes($"# Auto-generated placeholder for {ResourceFileName}\n");
                    es.Write(content, 0, content.Length);
                }
            }

            ms.Seek(0, SeekOrigin.Begin);
            return ms.ToArray();
        }

        private static byte[] CompressGZip(byte[] data)
        {
            using var output = new MemoryStream();
            using (var compressor = new GZipStream(output, CompressionLevel.Optimal, true))
            {
                compressor.Write(data ?? Array.Empty<byte>(), 0, data?.Length ?? 0);
            }
            return output.ToArray();
        }

        private static string CalculateSha256Hash(byte[] data)
        {
            using var sha = SHA256.Create();
            var h = sha.ComputeHash(data ?? Array.Empty<byte>());
            return BitConverter.ToString(h).Replace("-", "").ToLowerInvariant();
        }

        private string GenerateRegistrationLoader(string assemblyName, string compressedByteDataAsCSharp, string originalHash)
        {
            var sb = new StringBuilder();

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
