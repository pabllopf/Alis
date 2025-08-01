

using System.Text;
using Microsoft.CodeAnalysis;

namespace Alis.Core.Aspect.Data.Generator
{
    [Generator]
    public class SerializableSourceGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
            // Registrar el análisis de sintaxis
            context.RegisterForSyntaxNotifications(() => new SerializableSyntaxReceiver());
        }

        public void Execute(GeneratorExecutionContext context)
        {
            if (context.SyntaxReceiver is not SerializableSyntaxReceiver receiver)
                return;

            foreach (var typeDeclaration in receiver.CandidateTypes)
            {
                var model = context.Compilation.GetSemanticModel(typeDeclaration.SyntaxTree);
                var symbol = model.GetDeclaredSymbol(typeDeclaration);

                if (symbol is not INamedTypeSymbol typeSymbol)
                    continue;

                // Generar código de serialización/deserialización
                var source = GenerateSerializationCode(typeSymbol);
                context.AddSource($"{typeSymbol.Name}_Serialization.g.cs", source);
            }
        }

        private string GenerateSerializationCode(INamedTypeSymbol typeSymbol)
        {
            var sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using Alis.Core.Aspect.Data.Json;");
            sb.AppendLine($"namespace {typeSymbol.ContainingNamespace}");
            sb.AppendLine("{");
            sb.AppendLine($"    public partial struct {typeSymbol.Name} : IJsonSerializable, IJsonDesSerializable<{typeSymbol.Name}>");
            sb.AppendLine("    {");
        
            // Implementación de GetSerializableProperties
            sb.AppendLine("        IEnumerable<(string PropertyName, string Value)> IJsonSerializable.GetSerializableProperties()");
            sb.AppendLine("        {");
            foreach (var member in typeSymbol.GetMembers())
            {
                if (member is IPropertySymbol property)
                {
                    sb.AppendLine($"            yield return (nameof({property.Name}), {property.Name}?.ToString());");
                }
            }
            sb.AppendLine("        }");
        
            // Implementación de CreateFromProperties
            sb.AppendLine($"        {typeSymbol.Name} IJsonDesSerializable<{typeSymbol.Name}>.CreateFromProperties(Dictionary<string, string> properties)");
            sb.AppendLine("        {");
            sb.AppendLine($"            return new {typeSymbol.Name}");
            sb.AppendLine("            {");
            foreach (var member in typeSymbol.GetMembers())
            {
                if (member is IPropertySymbol property)
                {
                    var defaultValue = property.Type.SpecialType == Microsoft.CodeAnalysis.SpecialType.System_Boolean ? "false" : "null";
                    if (property.Type.SpecialType == Microsoft.CodeAnalysis.SpecialType.System_Boolean)
                    {
                        sb.AppendLine($"                {property.Name} = properties.TryGetValue(nameof({property.Name}), out var v_{property.Name}) && bool.TryParse(v_{property.Name}, out var b_{property.Name}) && b_{property.Name},");
                    }
                    else
                    {
                        sb.AppendLine($"                {property.Name} = properties.TryGetValue(nameof({property.Name}), out var v_{property.Name}) ? v_{property.Name} : {defaultValue},");
                    }
                }
            }
            sb.AppendLine("            };");
            sb.AppendLine("        }");
        
            // ToJson usando JsonNativeAot
            sb.AppendLine("        public string ToJson()");
            sb.AppendLine("        {");
            sb.AppendLine($"            return JsonNativeAot.Serialize(this);");
            sb.AppendLine("        }");
        
            // FromJson usando JsonNativeAot
            sb.AppendLine($"        public static {typeSymbol.Name} FromJson(string json)");
            sb.AppendLine("        {");
            sb.AppendLine($"            return JsonNativeAot.Deserialize<{typeSymbol.Name}>(json);");
            sb.AppendLine("        }");
        
            sb.AppendLine("    }");
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}