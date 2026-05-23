using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace XmlDocProcessor
{
    /// <summary>
    ///     Roslyn-based tool that adds XML documentation comments to public/protected/internal
    ///     C# symbols that are missing them. Uses TrackNodes for safe multi-replacement.
    ///     Performs zero structural changes.
    /// </summary>
    internal class Program
    {
        private static readonly string RepoRoot = Path.GetFullPath(
            Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", ".."));

        private static readonly string CacheFilePath = Path.Combine(
            RepoRoot, ".opencode", "cache", "csdoc_processed_files.json");

        private static int _filesProcessed;
        private static int _filesSkipped;
        private static int _filesWithChanges;
        private static int _totalDocsAdded;
        private static readonly ConcurrentDictionary<string, CacheEntry> Cache = new();

        public static void Main(string[] args)
        {
            Console.WriteLine("=== XmlDocProcessor ===");
            Console.WriteLine($"Repo root: {RepoRoot}");
            Console.WriteLine();

            LoadCache();
            List<string> csFiles = FindCsFiles();
            Console.WriteLine($"Found {csFiles.Count} .cs files total");
            Console.WriteLine($"Already processed: {Cache.Count}");
            Console.WriteLine();

            int count = 0;
            foreach (string filePath in csFiles)
            {
                if (Cache.ContainsKey(filePath))
                {
                    _filesSkipped++;
                    continue;
                }

                ProcessFile(filePath);
                count++;

                if (count % 1000 == 0)
                {
                    Console.WriteLine($"\n=== Checkpoint: {count} files processed ===");
                    SaveCache();
                }
            }

            SaveCache();

            Console.WriteLine();
            Console.WriteLine("=== Final Report ===");
            Console.WriteLine($"Files processed: {_filesProcessed}");
            Console.WriteLine($"Files skipped (cached): {_filesSkipped}");
            Console.WriteLine($"Files with changes: {_filesWithChanges}");
            Console.WriteLine($"XML docs added: {_totalDocsAdded}");
            Console.WriteLine($"Total files in repo: {csFiles.Count}");
        }

        private static List<string> FindCsFiles()
        {
            var files = new List<string>();
            var excludeDirs = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "bin", "obj", ".git", ".vs", "node_modules", ".idea" };
            var dirs = new Queue<string>();
            dirs.Enqueue(RepoRoot);

            while (dirs.Count > 0)
            {
                string dir = dirs.Dequeue();
                try
                {
                    foreach (string subDir in Directory.GetDirectories(dir))
                    {
                        string name = Path.GetFileName(subDir);
                        if (!excludeDirs.Contains(name) && !name.StartsWith("."))
                            dirs.Enqueue(subDir);
                    }

                    foreach (string file in Directory.GetFiles(dir, "*.cs"))
                    {
                        string rp = Path.GetRelativePath(RepoRoot, file);
                        if (rp.Contains("bin") || rp.Contains("obj")) continue;
                        files.Add(file);
                    }
                }
                catch { }
            }
            return files;
        }

        private static void LoadCache()
        {
            try
            {
                if (File.Exists(CacheFilePath))
                {
                    string json = File.ReadAllText(CacheFilePath);
                    var dict = JsonSerializer.Deserialize<Dictionary<string, CacheEntry>>(json);
                    if (dict != null)
                        foreach (var kvp in dict) Cache[kvp.Key] = kvp.Value;
                }
            }
            catch { }
        }

        private static void SaveCache()
        {
            try
            {
                string dir = Path.GetDirectoryName(CacheFilePath);
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                var dict = new Dictionary<string, CacheEntry>(Cache);
                File.WriteAllText(CacheFilePath, JsonSerializer.Serialize(dict, new JsonSerializerOptions { WriteIndented = true }));
            }
            catch { }
        }

        private static void ProcessFile(string filePath)
        {
            string relativePath = Path.GetRelativePath(RepoRoot, filePath);
            string originalText;
            try { originalText = File.ReadAllText(filePath); }
            catch (Exception ex) { Console.WriteLine($"  ERROR reading {relativePath}: {ex.Message}"); return; }

            string newLine = DetectNewLine(originalText);
            var parseOptions = new CSharpParseOptions(LanguageVersion.Latest);
            SyntaxTree tree = CSharpSyntaxTree.ParseText(originalText, parseOptions);
            CompilationUnitSyntax root = (CompilationUnitSyntax)tree.GetRoot();

            // Gather all public/protected/internal member declarations missing XML docs
            var membersToDoc = new List<MemberDeclarationSyntax>();
            GatherMembersMissingDocs(root, membersToDoc);

            if (membersToDoc.Count == 0)
            {
                Cache[filePath] = new CacheEntry { Status = "no-changes", Timestamp = DateTime.UtcNow.ToString("O") };
                _filesSkipped++;
                SaveCache();
                return;
            }

            // Track all nodes that will be replaced
            root = root.TrackNodes(membersToDoc);

            int docsAdded = 0;
            // Apply docs from innermost to outermost to avoid position issues
            // But since we use TrackNodes, order doesn't matter for correctness
            foreach (MemberDeclarationSyntax originalNode in membersToDoc)
            {
                MemberDeclarationSyntax currentNode = root.GetCurrentNode(originalNode);
                if (currentNode == null) continue;

                string docXml = GenerateDoc(currentNode);
                if (docXml == null) continue;

                string indent = ExtractIndent(currentNode);
                string normalizedDoc = docXml.Replace("\r\n", "\n").Replace("\n", newLine);
                string indentedDoc = IndentXmlDoc(normalizedDoc, indent);
                var docTrivia = SyntaxFactory.ParseLeadingTrivia(indentedDoc);
                var existingTrivia = currentNode.GetLeadingTrivia();
                var newTrivia = existingTrivia.InsertRange(0, docTrivia);
                var newNode = currentNode.WithLeadingTrivia(newTrivia);
                root = root.ReplaceNode(currentNode, newNode);
                docsAdded++;
            }

            if (docsAdded == 0)
            {
                Cache[filePath] = new CacheEntry { Status = "no-changes", Timestamp = DateTime.UtcNow.ToString("O") };
                _filesSkipped++;
                SaveCache();
                return;
            }

            string modifiedText = root.ToFullString();

            // Validate
            SyntaxTree modTree = CSharpSyntaxTree.ParseText(modifiedText, parseOptions);
            if (modTree.GetDiagnostics().Any(d => d.Severity == DiagnosticSeverity.Error))
            {
                Console.WriteLine($"  SKIP {relativePath}: would introduce syntax error");
                _filesSkipped++;
                return;
            }

            // Write atomically
            try
            {
                string tmp = filePath + ".tmp";
                File.WriteAllText(tmp, modifiedText);
                File.Delete(filePath);
                File.Move(tmp, filePath);

                _filesProcessed++;
                _filesWithChanges++;
                _totalDocsAdded += docsAdded;
                Cache[filePath] = new CacheEntry { Status = "documented", Timestamp = DateTime.UtcNow.ToString("O"), DocsAdded = docsAdded };
                Console.WriteLine($"  OK   {relativePath}  (+{docsAdded} docs)");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"  ERROR writing {relativePath}: {ex.Message}");
                _filesSkipped++;
            }

            SaveCache();
        }

        private static void GatherMembersMissingDocs(SyntaxNode node, List<MemberDeclarationSyntax> result)
        {
            foreach (var child in node.ChildNodes())
            {
                if (child is MemberDeclarationSyntax member)
                {
                    if (!ShouldSkip(member) && !HasXmlDoc(member))
                    {
                        result.Add(member);
                    }
                    // Always recurse into member declarations to find nested types
                    GatherMembersMissingDocs(member, result);
                }
                else if (child is NamespaceDeclarationSyntax ns)
                {
                    GatherMembersMissingDocs(ns, result);
                }
                else if (child is FileScopedNamespaceDeclarationSyntax fns)
                {
                    GatherMembersMissingDocs(fns, result);
                }
                else if (child is CompilationUnitSyntax cu)
                {
                    GatherMembersMissingDocs(cu, result);
                }
                // Don't recurse into other node types (statements, expressions, etc.)
            }
        }

        private static string DetectNewLine(string text)
        {
            int idx = text.IndexOf("\r\n", StringComparison.Ordinal);
            if (idx >= 0) return "\r\n";
            idx = text.IndexOf('\n');
            if (idx >= 0) return "\n";
            return Environment.NewLine;
        }

        private static string ExtractIndent(MemberDeclarationSyntax node)
        {
            foreach (var t in node.GetLeadingTrivia())
                if (t.IsKind(SyntaxKind.WhitespaceTrivia))
                    return t.ToFullString();
            return "        ";
        }

        private static string IndentXmlDoc(string doc, string indent)
        {
            if (string.IsNullOrEmpty(indent)) return doc;
            string nl = doc.Contains("\r\n") ? "\r\n" : "\n";
            var lines = doc.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length; i++)
                if (lines[i].Length > 0)
                    lines[i] = indent + lines[i];
            return string.Join(nl, lines);
        }

        private static bool ShouldSkip(MemberDeclarationSyntax member)
        {
            if (member.Modifiers.Any(m => m.IsKind(SyntaxKind.PrivateKeyword))) return true;

            if (member is ClassDeclarationSyntax or StructDeclarationSyntax or
                InterfaceDeclarationSyntax or EnumDeclarationSyntax or RecordDeclarationSyntax)
            {
                if (!member.Modifiers.Any(m => m.IsKind(SyntaxKind.PublicKeyword) ||
                                               m.IsKind(SyntaxKind.InternalKeyword) ||
                                               m.IsKind(SyntaxKind.ProtectedKeyword)))
                    return true;
            }

            if (member is MethodDeclarationSyntax or PropertyDeclarationSyntax or
                FieldDeclarationSyntax or EventDeclarationSyntax)
            {
                if (!member.Modifiers.Any(m => m.IsKind(SyntaxKind.PublicKeyword) ||
                                               m.IsKind(SyntaxKind.InternalKeyword) ||
                                               m.IsKind(SyntaxKind.ProtectedKeyword)))
                    return true;
            }

            if (member.Modifiers.Any(m => m.IsKind(SyntaxKind.OverrideKeyword))) return true;

            if (member is MethodDeclarationSyntax m && m.ExplicitInterfaceSpecifier != null) return true;
            if (member is PropertyDeclarationSyntax p && p.ExplicitInterfaceSpecifier != null) return true;
            if (member is EventDeclarationSyntax e && e.ExplicitInterfaceSpecifier != null) return true;

            if (member.Parent is InterfaceDeclarationSyntax) return true;

            foreach (var al in member.AttributeLists)
                foreach (var a in al.Attributes)
                {
                    string n = a.Name.ToString();
                    if (n.Contains("GeneratedCode") || n.Contains("ExcludeFromCodeCoverage"))
                        return true;
                }

            return false;
        }

        private static bool HasXmlDoc(MemberDeclarationSyntax member)
        {
            return member.GetLeadingTrivia().Any(t =>
                t.IsKind(SyntaxKind.SingleLineDocumentationCommentTrivia) ||
                t.IsKind(SyntaxKind.MultiLineDocumentationCommentTrivia));
        }

        private static string GenerateDoc(MemberDeclarationSyntax member)
        {
            return member switch
            {
                ClassDeclarationSyntax c => SimpleDoc($"The {ToWords(c.Identifier.Text)} class"),
                StructDeclarationSyntax s => SimpleDoc($"The {ToWords(s.Identifier.Text)} struct"),
                InterfaceDeclarationSyntax i => SimpleDoc($"The {ToWords(i.Identifier.Text)} interface"),
                EnumDeclarationSyntax e => SimpleDoc($"The {ToWords(e.Identifier.Text)} enum"),
                RecordDeclarationSyntax r => SimpleDoc($"The {ToWords(r.Identifier.Text)} record"),
                MethodDeclarationSyntax m => GenerateMethodDoc(m),
                PropertyDeclarationSyntax p => GeneratePropertyDoc(p),
                FieldDeclarationSyntax f => GenerateFieldDoc(f),
                EventDeclarationSyntax ev => SimpleDoc($"The {ToWords(ev.Identifier.Text)} event"),
                DelegateDeclarationSyntax d => SimpleDoc($"The {ToWords(d.Identifier.Text)} delegate"),
                ConstructorDeclarationSyntax ctor => GenerateConstructorDoc(ctor),
                DestructorDeclarationSyntax => SimpleDoc("Finalizes an instance of the class."),
                OperatorDeclarationSyntax op => SimpleDoc($"The {op.OperatorToken.Text} operator"),
                ConversionOperatorDeclarationSyntax conv =>
                    SimpleDoc($"{(conv.ImplicitOrExplicitKeyword.IsKind(SyntaxKind.ImplicitKeyword) ? "Implicitly" : "Explicitly")} converts to {conv.Type}"),
                _ => null
            };
        }

        private static string GenerateMethodDoc(MethodDeclarationSyntax m)
        {
            string name = m.Identifier.Text;
            string summary = DeriveMethodSummary(name);

            var sb = new StringBuilder();
            sb.AppendLine("/// <summary>");
            sb.AppendLine($"///     {summary.Sanitize()}.");
            sb.AppendLine("/// </summary>");

            foreach (var param in m.ParameterList.Parameters)
            {
                string pn = ToWords(param.Identifier.Text);
                sb.AppendLine($"/// <param name=\"{param.Identifier.Text}\">The {(pn.Length > 0 ? pn : param.Identifier.Text)}.</param>");
            }

            if (!(m.ReturnType is PredefinedTypeSyntax pts && pts.Keyword.IsKind(SyntaxKind.VoidKeyword)))
            {
                string rn = SplitPascalCase(name);
                sb.AppendLine("/// <returns>");
                sb.AppendLine($"///     The {(rn.Length > 0 ? rn : name)} result.");
                sb.AppendLine("/// </returns>");
            }

            return sb.ToString();
        }

        private static string DeriveMethodSummary(string name)
        {
            if (name.StartsWith("Get") && name.Length > 3 && char.IsUpper(name[3]))
                return $"Gets the {ToWords(name[3..])}";
            if (name.StartsWith("Set") && name.Length > 3 && char.IsUpper(name[3]))
                return $"Sets the {ToWords(name[3..])}";
            if (name.StartsWith("Is") && name.Length > 2 && char.IsUpper(name[2]))
                return $"Determines whether the specified {ToWords(name[2..])}";
            if (name.StartsWith("Has") && name.Length > 3 && char.IsUpper(name[3]))
                return $"Determines whether the object has the specified {ToWords(name[3..])}";
            string split = SplitPascalCase(name);
            return split.Length > 0 ? split : name;
        }

        private static string GeneratePropertyDoc(PropertyDeclarationSyntax p)
        {
            string name = p.Identifier.Text;
            bool hasSetter = p.AccessorList?.Accessors.Any(a =>
                a.IsKind(SyntaxKind.SetAccessorDeclaration) ||
                a.IsKind(SyntaxKind.InitAccessorDeclaration)) ?? false;

            string summary;
            if (name.StartsWith("Is") && name.Length > 2 && char.IsUpper(name[2]))
                summary = hasSetter
                    ? $"Gets or sets a value indicating whether {ToWords(name[2..])}"
                    : $"Gets a value indicating whether {ToWords(name[2..])}";
            else if (name.StartsWith("Has") && name.Length > 3 && char.IsUpper(name[3]))
                summary = hasSetter
                    ? $"Gets or sets a value indicating whether the object has {ToWords(name[3..])}"
                    : $"Gets a value indicating whether the object has {ToWords(name[3..])}";
            else
                summary = hasSetter
                    ? $"Gets or sets the {ToWords(name)}"
                    : $"Gets the {ToWords(name)}";

            return SimpleDoc(summary);
        }

        private static string GenerateFieldDoc(FieldDeclarationSyntax f)
        {
            if (f.Declaration.Variables.Count == 0) return null;
            string name = f.Declaration.Variables[0].Identifier.Text;
            string trimmed = name.TrimStart('_');
            string display = ToWords(trimmed.Length > 0 ? trimmed : name);
            string prefix = f.Modifiers.Any(m => m.IsKind(SyntaxKind.ConstKeyword)) ? "The constant " : "The ";
            return SimpleDoc($"{prefix}{display}");
        }

        private static string GenerateConstructorDoc(ConstructorDeclarationSyntax ctor)
        {
            string typeName = ctor.Identifier.Text;
            var sb = new StringBuilder();
            sb.AppendLine("/// <summary>");
            sb.AppendLine($"///     Initializes a new instance of the <see cref=\"{EscapeXml(typeName)}\" /> class.");
            sb.AppendLine("/// </summary>");
            foreach (var param in ctor.ParameterList.Parameters)
            {
                string pn = ToWords(param.Identifier.Text);
                sb.AppendLine($"/// <param name=\"{param.Identifier.Text}\">The {(pn.Length > 0 ? pn : param.Identifier.Text)}.</param>");
            }
            return sb.ToString();
        }

        private static string SimpleDoc(string summary)
        {
            var sb = new StringBuilder();
            sb.AppendLine("/// <summary>");
            sb.AppendLine($"///     {summary.Sanitize()}.");
            sb.AppendLine("/// </summary>");
            return sb.ToString();
        }

        private static string EscapeXml(string s) => s.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;");

        private static string ToWords(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            string r = SplitPascalCase(input);
            if (string.IsNullOrEmpty(r)) return input;
            return char.ToLowerInvariant(r[0]) + r[1..];
        }

        private static string SplitPascalCase(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            if (input.Length == 1) return input;
            var sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (i > 0 && char.IsUpper(input[i]))
                {
                    bool nextUpper = i + 1 < input.Length && char.IsUpper(input[i + 1]);
                    bool prevUpper = char.IsUpper(input[i - 1]);
                    bool endOfAcro = nextUpper && (i + 2 >= input.Length || !char.IsUpper(input[i + 2]));

                    if (endOfAcro)
                        sb.Append(' ');
                    else if (!prevUpper && !nextUpper)
                    { sb.Append(' '); sb.Append(char.ToLowerInvariant(input[i])); continue; }
                    else if (!prevUpper)
                    { sb.Append(' '); sb.Append(char.ToLowerInvariant(input[i])); continue; }
                }
                sb.Append(input[i]);
            }
            return sb.ToString().Trim();
        }

        /// <summary>
        ///     Represents a cache entry for tracking processed file documentation status.
        /// </summary>
        private class CacheEntry
        {
            /// <summary>
            ///     Gets or sets the processing status of the file.
            /// </summary>
            public string Status { get; set; }

            /// <summary>
            ///     Gets or sets the timestamp of when the file was last processed.
            /// </summary>
            public string Timestamp { get; set; }

            /// <summary>
            ///     Gets or sets the number of XML documentation comments added to the file.
            /// </summary>
            public int DocsAdded { get; set; }
        }
    }

    /// <summary>
    ///     Provides extension methods for string manipulation used by the XML documentation processor.
    /// </summary>
    internal static class StringExtensions
    {
        /// <summary>Sanitizes string for XML doc content (removes problematic characters).</summary>
        public static string Sanitize(this string s)
        {
            return s?.Replace("\r", "").Replace("\n", " ").Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;") ?? "";
        }
    }
}
