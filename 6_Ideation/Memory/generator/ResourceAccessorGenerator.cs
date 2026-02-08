// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ResourceAccessorGenerator.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Collections.Immutable;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
// New: required for SHA256

namespace Alis.Core.Aspect.Memory.Generator
{
    /// <summary>
    ///     The resource accessor generator class
    /// </summary>
    /// <seealso cref="IIncrementalGenerator" />
    [Generator]
    public class ResourceAccessorGenerator : IIncrementalGenerator
    {
        /// <summary>
        ///     The resource file name
        /// </summary>
        private const string ResourceFileName = "assets.pack";

        /// <summary>
        ///     The registry namespace
        /// </summary>
        private const string RegistryNamespace = "Alis.Core.Aspect.Memory.AssetRegistry";

        /// <summary>
        ///     Initializes the context
        /// </summary>
        /// <param name="context">The context</param>
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            IncrementalValuesProvider<AdditionalText> additional = context.AdditionalTextsProvider;
            IncrementalValueProvider<ImmutableArray<AdditionalText>> pakProvider = additional
                .Where(at => Path.GetFileName(at.Path).Equals(ResourceFileName, StringComparison.OrdinalIgnoreCase))
                .Collect();

            IncrementalValueProvider<(ImmutableArray<AdditionalText> PakFiles, Compilation Compilation)> combinedProvider = pakProvider.Combine(context.CompilationProvider);

            context.RegisterSourceOutput(combinedProvider, (spc, combined) =>
            {
                ImmutableArray<AdditionalText> pakFiles = combined.PakFiles;
                Compilation compilation = combined.Compilation;

                // Check if the project is a Console or Windows Application
                if (compilation.Options.OutputKind != OutputKind.ConsoleApplication &&
                    compilation.Options.OutputKind != OutputKind.WindowsApplication)
                {
#if NET8_0_OR_GREATER
                    DiagnosticDescriptor descInfo = new DiagnosticDescriptor("ALIS0013", "Proyecto no ejecutable", "El generador no se ejecuta en proyectos de tipo {0}", "AOT Resources", DiagnosticSeverity.Info, true);
                    spc.ReportDiagnostic(Diagnostic.Create(descInfo, Location.None, compilation.Options.OutputKind.ToString()));
#endif
#if NETSTANDARD2_0
                    DiagnosticDescriptor descInfoNetStandard = new DiagnosticDescriptor("ALIS0013", "Proyecto no ejecutable", "El generador no se ejecuta en proyectos de tipo {0}", "AOT Resources", DiagnosticSeverity.Info, true);
                    spc.ReportDiagnostic(Diagnostic.Create(descInfoNetStandard, Location.None, compilation.Options.OutputKind.ToString()));
#endif
                    return;
                }

                if (pakFiles.IsDefaultOrEmpty || pakFiles.Length == 0)
                {
#if NET8_0_OR_GREATER
                    DiagnosticDescriptor descWarning = new DiagnosticDescriptor("ALIS0011", "Archivo no encontrado", "El archivo assets.pack no fue encontrado. Asegúrate de generarlo antes de compilar.", "AOT Resources", DiagnosticSeverity.Warning, true);
                    spc.ReportDiagnostic(Diagnostic.Create(descWarning, Location.None));
#endif
#if NETSTANDARD2_0
                    DiagnosticDescriptor descWarningNetStandard = new DiagnosticDescriptor("ALIS0011", "Archivo no encontrado", "El archivo assets.pack no fue encontrado. Asegúrate de generarlo antes de compilar.", "AOT Resources", DiagnosticSeverity.Warning, true);
                    spc.ReportDiagnostic(Diagnostic.Create(descWarningNetStandard, Location.None));
#endif
                    return;
                }

                // Process the first matching file
                SourceText pakText = pakFiles[0].GetText();
                if (pakText == null)
                {
#if NET8_0_OR_GREATER
                    DiagnosticDescriptor descError = new DiagnosticDescriptor("ALIS0012", "Archivo vacío", "El archivo assets.pack está vacío o no es válido.", "AOT Resources", DiagnosticSeverity.Error, true);
                    spc.ReportDiagnostic(Diagnostic.Create(descError, Location.None));
#endif
#if NETSTANDARD2_0
                    DiagnosticDescriptor descErrorNetStandard = new DiagnosticDescriptor("ALIS0012", "Archivo vacío", "El archivo assets.pack está vacío o no es válido.", "AOT Resources", DiagnosticSeverity.Error, true);
                    spc.ReportDiagnostic(Diagnostic.Create(descErrorNetStandard, Location.None));
#endif
                    return;
                }

                // Continue processing the file as before
                string base64Content = pakText.ToString();
                byte[] originalBytes = Convert.FromBase64String(base64Content);
                string originalHash = CalculateSha256Hash(originalBytes);

#if NET8_0_OR_GREATER
                DiagnosticDescriptor descHash = new DiagnosticDescriptor("ALIS0007", "Hash calculado", $"Hash SHA256 de assets.pack: {originalHash}", "AOT Resources", DiagnosticSeverity.Info, true);
                spc.ReportDiagnostic(Diagnostic.Create(descHash, Location.None));
#endif
#if NETSTANDARD2_0
                DiagnosticDescriptor descHashNetStandard = new DiagnosticDescriptor("ALIS0007", "Hash calculado", $"Hash SHA256 de assets.pack: {originalHash}", "AOT Resources", DiagnosticSeverity.Info, true);
                spc.ReportDiagnostic(Diagnostic.Create(descHashNetStandard, Location.None));
#endif

                byte[] compressed = CompressGZip(originalBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < compressed.Length; i++)
                {
                    sb.Append(compressed[i]);
                    if (i < compressed.Length - 1)
                    {
                        sb.Append(',');
                    }
                }

                string assemblyName = compilation.AssemblyName ?? "DefaultAssembly";
                string generated = GenerateRegistrationLoader(assemblyName, sb.ToString(), originalHash);
                spc.AddSource("AssemblyLoader.g.cs", SourceText.From(generated, Encoding.UTF8));
            });
        }

        /// <summary>
        ///     Compresses the g zip using the specified data
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
        ///     Calculates the sha 256 hash using the specified data
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
        ///     Generates the registration loader using the specified assembly name
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