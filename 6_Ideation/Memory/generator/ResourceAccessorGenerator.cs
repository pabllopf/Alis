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
    /// <summary>
    /// The resource accessor generator class
    /// </summary>
    /// <seealso cref="ISourceGenerator"/>
    [Generator]
    public class ResourceAccessorGenerator : ISourceGenerator
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
        public void Initialize(GeneratorInitializationContext context)
        {
            // No specific initialization required
        }

        /// <summary>
        /// Executes the context
        /// </summary>
        /// <param name="context">The context</param>
        public void Execute(GeneratorExecutionContext context)
        {
            // ----------------------------------------------------------------------
            // 1. Generation condition (exclude pure DLLs)
            // ----------------------------------------------------------------------
            if (context.Compilation.Options.OutputKind == OutputKind.DynamicallyLinkedLibrary)
            {
                return;
            }
            
            AdditionalText assetFile = context.AdditionalFiles
                .FirstOrDefault(f => Path.GetFileName(f.Path).Equals(ResourceFileName, StringComparison.OrdinalIgnoreCase));

            string compressedByteDataAsCSharp = "";
            string assemblyName = context.Compilation.AssemblyName ?? "DefaultAssembly";
            string originalHash = string.Empty; // Hash of the original file
            byte[] originalFileBytes = null;

            // Helper: obtener projectDir razonablemente
            string projectDir = null;
            try
            {
                if (context.AnalyzerConfigOptions.GlobalOptions.TryGetValue("build_property.ProjectDir", out string projDirValue) && !string.IsNullOrEmpty(projDirValue))
                {
                    projectDir = projDirValue;
                }
                else if (context.AdditionalFiles.Any())
                {
                    projectDir = Path.GetDirectoryName(context.AdditionalFiles.First().Path) ?? Environment.CurrentDirectory;
                }
            }
            catch
            {
                // ignore
            }

            if (string.IsNullOrEmpty(projectDir))
            {
                projectDir = Environment.CurrentDirectory;
            }

            if (assetFile != null)
            {
                try
                {
                    if (File.Exists(assetFile.Path) && new FileInfo(assetFile.Path).Length > 0)
                    {
                        // Read the original binary (I/O required for embedding)
                        originalFileBytes = File.ReadAllBytes(assetFile.Path);
                    }
                    else
                    {
                        // El archivo declarado existe pero está vacío: generar a partir de la carpeta Assets
                        originalFileBytes = CreatePakFromAssets(projectDir);

                        DiagnosticDescriptor infoDescriptor = new DiagnosticDescriptor(
                            "ALIS0004", "Assets packaged",
                            $"The declared '{ResourceFileName}' was empty; a package was created from '{Path.Combine(projectDir, "Assets")}'.",
                            "AOT Resources", DiagnosticSeverity.Info, true);
                        context.ReportDiagnostic(Diagnostic.Create(infoDescriptor, Location.None));

                        // Intentamos escribir el paquete en el mismo path para compatibilidad si es posible
                        try
                        {
                            File.WriteAllBytes(assetFile.Path, originalFileBytes);
                        }
                        catch
                        {
                            // ignore write failures to declared AdditionalFile
                        }
                    }

                    // ----------------------------------------------------------------------
                    // TRACEABILITY OPTIMIZATION: Calculate SHA256 hash of original file.
                    // ----------------------------------------------------------------------
                    if (originalFileBytes != null)
                    {
                        originalHash = CalculateSha256Hash(originalFileBytes);

                        // ----------------------------------------------------------------------
                        // SPEED & SIZE OPTIMIZATION: Compress the data with GZip.
                        // ----------------------------------------------------------------------
                        byte[] compressedBytes = CompressGZip(originalFileBytes);

                        // ----------------------------------------------------------------------
                        // SPEED OPTIMIZATION: Use StringBuilder.
                        // SIZE OPTIMIZATION: Use decimal format and REMOVE space after comma.
                        // ----------------------------------------------------------------------
                        StringBuilder builder = new StringBuilder();
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
                    else
                    {
                        // If still null, leave as empty and diagnostics will mention it later.
                        compressedByteDataAsCSharp = "";
                    }
                }
                catch (Exception ex)
                {
                    // Report diagnostic if I/O fails
                    Diagnostic diagnostic = Diagnostic.Create(
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
                string generatedPath = Path.Combine(Path.Combine(projectDir, "obj"), ResourceFileName);

                try
                {
                    // Crear el paquete a partir de Assets (si existe) o un placeholder si no hay archivos.
                    originalFileBytes = CreatePakFromAssets(projectDir);

                    // Escribir el archivo generado en obj/ para que MSBuild/IDE lo vea si es necesario
                    Directory.CreateDirectory(Path.GetDirectoryName(generatedPath) ?? projectDir);
                    File.WriteAllBytes(generatedPath, originalFileBytes);

                    // Report an informational diagnostic indicating the file was generated
                    DiagnosticDescriptor infoDescriptor = new DiagnosticDescriptor(
                        "ALIS0003", "Resource generated",
                        $"The file '{ResourceFileName}' was not declared and has been generated at: {generatedPath}",
                        "AOT Resources", DiagnosticSeverity.Info, true);
                    context.ReportDiagnostic(Diagnostic.Create(infoDescriptor, Location.None));

                    // Now process the newly created file bytes
                    originalHash = CalculateSha256Hash(originalFileBytes);
                    byte[] compressedBytes = CompressGZip(originalFileBytes);

                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < compressedBytes.Length; i++)
                    {
                        builder.Append(compressedBytes[i]);
                        if (i < compressedBytes.Length - 1)
                        {
                            builder.Append(',');
                        }
                    }
                    compressedByteDataAsCSharp = builder.ToString();
                }
                catch (Exception ex)
                {
                    Diagnostic diagnostic = Diagnostic.Create(
                        new DiagnosticDescriptor("ALIS0002", "I/O Error in Generator",
                            $"Failed to generate/read/compress '{generatedPath}': {ex.Message}",
                            "AOT Resources", DiagnosticSeverity.Error, true),
                        Location.None);
                    context.ReportDiagnostic(diagnostic);
                    return;
                }
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
            using MemoryStream output = new MemoryStream();
            // CompressionLevel.Optimal optimizes compression speed at the cost of slightly lower compression ratio.
            using (GZipStream compressor = new GZipStream(output, CompressionLevel.Optimal, true))
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
            using SHA256 sha256 = SHA256.Create();
            byte[] hashBytes = sha256.ComputeHash(data);
            // Convert to lowercase hexadecimal string without dashes.
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
        }

        /// <summary>
        /// Creates a deterministic ZIP package from the project's Assets folder.
        /// If no assets are found, returns a small placeholder package.
        /// </summary>
        private static byte[] CreatePakFromAssets(string projectDir)
        {
            string assetsDir = Path.Combine(projectDir, "Assets");

            // Collect files deterministically
            List<string> files = new List<string>();
            if (Directory.Exists(assetsDir))
            {
                files = Directory.GetFiles(assetsDir, "*", SearchOption.AllDirectories)
                                 .OrderBy(p => p, StringComparer.OrdinalIgnoreCase)
                                 .ToList();
            }

            using MemoryStream ms = new MemoryStream();
            using (ZipArchive archive = new ZipArchive(ms, ZipArchiveMode.Create, true))
            {
                if (files.Count == 0)
                {
                    // No files: create a placeholder entry so the pak isn't empty.
                    ZipArchiveEntry entry = archive.CreateEntry("placeholder.txt", CompressionLevel.Optimal);
                    using Stream entryStream = entry.Open();
                    byte[] content = Encoding.UTF8.GetBytes($"# Auto-generated placeholder for {ResourceFileName}\nGenerated on {DateTime.UtcNow:O}\n");
                    entryStream.Write(content, 0, content.Length);
                }
                else
                {
                    foreach (string file in files)
                    {
                        // Compute a relative path inside the archive
                        string relative = GetRelativePath(projectDir, file).Replace('\\', '/');
                        ZipArchiveEntry entry = archive.CreateEntry(relative, CompressionLevel.Optimal);
                        using Stream entryStream = entry.Open();
                        using FileStream fs = File.OpenRead(file);
                        fs.CopyTo(entryStream);
                    }
                }
            }

            ms.Seek(0, SeekOrigin.Begin);
            return ms.ToArray();
        }

        /// <summary>
        /// Generates the registration loader using the specified assembly name
        /// </summary>
        /// <param name="assemblyName">The assembly name</param>
        /// <param name="compressedByteDataAsCSharp">The compressed byte data as sharp</param>
        /// <param name="originalHash">The original hash</param>
        /// <returns>The code</returns>
        private string GenerateRegistrationLoader(string assemblyName, string compressedByteDataAsCSharp, string originalHash)
        {
            // Build the generated code using StringBuilder to reduce large temporary strings and copies.
            var sb = new StringBuilder();

            sb.AppendLine("// <auto-generated/>");
            sb.AppendLine("using System;");
            sb.AppendLine("using System.IO;");
            sb.AppendLine("using System.Runtime.CompilerServices;");
            sb.AppendLine("using System.IO.Compression;");
            sb.AppendLine();
            sb.AppendLine("namespace Alis.Core.Aspect.Memory.Generator");
            sb.AppendLine("{");

            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// AOT-safe anchor class that contains the static binary resource (compressed).\n    /// </summary>");
            sb.AppendLine("    internal static class ResourceAnchor");
            sb.AppendLine("    {");
            sb.Append("        private const string OriginalHash = \"");
            sb.Append(originalHash ?? string.Empty);
            sb.AppendLine("\";");

            sb.AppendLine();
            sb.AppendLine("        // COMPRESSED byte array (decimal format, no spaces).");
            sb.AppendLine("        private static readonly byte[] AssetData = new byte[] {");

            // If there's compressed data, append it directly (already generated as decimal comma-separated list)
            if (!string.IsNullOrEmpty(compressedByteDataAsCSharp))
            {
                // Append the compressed data in one call to minimize StringBuilder reallocations.
                sb.Append("            ");
                sb.Append(compressedByteDataAsCSharp);
                sb.AppendLine();
            }

            sb.AppendLine("        };\n");

            sb.AppendLine("        public static Stream LoadAsset()");
            sb.AppendLine("        {");
            sb.AppendLine("            if (AssetData.Length == 0)");
            sb.AppendLine("            {");
            sb.AppendLine("                throw new InvalidOperationException(\"The resource '" + ResourceFileName + "' was not found or is empty during AOT compilation.\");");
            sb.AppendLine("            }");
            sb.AppendLine();
            sb.AppendLine("            // -------------------------------------------------------------------");
            sb.AppendLine("            // Runtime decompression logic (AOT-safe)");
            sb.AppendLine("            // -------------------------------------------------------------------");
            sb.AppendLine();
            sb.AppendLine("            // Create a read-only MemoryStream from the static array.");
            sb.AppendLine("            var compressedStream = new MemoryStream(AssetData, writable: false);");
            sb.AppendLine();
            sb.AppendLine("            // Create the decompression stream (GZipStream constructor handles positioning).");
            sb.AppendLine("            using var decompressor = new GZipStream(compressedStream, CompressionMode.Decompress);");
            sb.AppendLine();
            sb.AppendLine("            // Create the destination stream and copy the contents.");
            sb.AppendLine("            var decompressedStream = new MemoryStream();");
            sb.AppendLine("            decompressor.CopyTo(decompressedStream);");
            sb.AppendLine();
            sb.AppendLine("            // Rewind and return the decompressed stream.");
            sb.AppendLine("            decompressedStream.Seek(0, SeekOrigin.Begin);");
            sb.AppendLine();
            sb.AppendLine("            // Return the MemoryStream. Caller is responsible for disposing it.");
            sb.AppendLine("            return decompressedStream;");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine();
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// Static initializer to register this assembly with the central loader.");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    public static class AssemblyLoader");
            sb.AppendLine("    {");
            sb.AppendLine("        [ModuleInitializer]");
            sb.AppendLine("        public static void EnsureLoaded()");
            sb.AppendLine("        {");
            sb.AppendLine("            Func<Stream> assetLoader = ResourceAnchor.LoadAsset;");

            // RegisterAssembly call with assemblyName and registry namespace
            sb.Append("            ");
            sb.Append(RegistryNamespace);
            sb.Append(".RegisterAssembly(\"");
            sb.Append(assemblyName ?? string.Empty);
            sb.AppendLine("\", assetLoader);");

            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }

        /// <summary>
        /// Cross-target helper to compute relative paths on platforms that don't have Path.GetRelativePath (e.g. .NET Standard 2.0).
        /// Returns a relative path from <paramref name="relativeTo"/> to <paramref name="path"/>.
        /// </summary>
        private static string GetRelativePath(string relativeTo, string path)
        {
            if (string.IsNullOrEmpty(relativeTo))
            {
                throw new ArgumentNullException(nameof(relativeTo));
            }

            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            // Normalize to full paths to handle .. and . segments
            string absoluteFrom = Path.GetFullPath(relativeTo);
            string absoluteTo = Path.GetFullPath(path);

            // If roots are different (different drives on Windows), return absolute path
            if (!string.Equals(Path.GetPathRoot(absoluteFrom), Path.GetPathRoot(absoluteTo), StringComparison.OrdinalIgnoreCase))
            {
                return absoluteTo;
            }

            // Use URI trick for relative path calculation
            // Ensure directory sentinel for folders
            if (!absoluteFrom.EndsWith(Path.DirectorySeparatorChar.ToString()) && !absoluteFrom.EndsWith(Path.AltDirectorySeparatorChar.ToString()))
            {
                absoluteFrom = absoluteFrom + Path.DirectorySeparatorChar;
            }

            Uri fromUri = new Uri(absoluteFrom);
            Uri toUri = new Uri(absoluteTo);
            Uri relativeUri = fromUri.MakeRelativeUri(toUri);
            string relativePath = Uri.UnescapeDataString(relativeUri.ToString());

            // Convert URI separators to platform separators
            return relativePath.Replace('/', Path.DirectorySeparatorChar);
        }
    }
}
