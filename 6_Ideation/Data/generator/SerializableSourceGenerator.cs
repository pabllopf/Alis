

using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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

            foreach (TypeDeclarationSyntax typeDeclaration in receiver.CandidateTypes)
            {
                SemanticModel model = context.Compilation.GetSemanticModel(typeDeclaration.SyntaxTree);
                ISymbol symbol = model.GetDeclaredSymbol(typeDeclaration);

                if (symbol is not INamedTypeSymbol typeSymbol)
                    continue;

                // Generar código de serialización/deserialización
                string source = GenerateSerializationCode(typeSymbol);
                context.AddSource($"{typeSymbol.Name}_Serialization.g.cs", source);
            }
        }

        private string GenerateSerializationCode(INamedTypeSymbol typeSymbol)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using Alis.Core.Aspect.Data.Json;");
            sb.AppendLine($"namespace {typeSymbol.ContainingNamespace}");
           
            sb.AppendLine("{");
            sb.AppendLine($"    public partial {(typeSymbol.TypeKind == TypeKind.Struct ? "struct" : "class")} {typeSymbol.Name} : IJsonSerializable, IJsonDesSerializable<{typeSymbol.Name}>");
            sb.AppendLine("    {");
           
            // Implementación de GetSerializableProperties
            sb.AppendLine("        IEnumerable<(string PropertyName, string Value)> IJsonSerializable.GetSerializableProperties()");
            sb.AppendLine("        {");
            foreach (ISymbol member in typeSymbol.GetMembers())
            {
                if (member is IPropertySymbol property)
                {
                    sb.AppendLine($"            yield return (nameof({property.Name}), {property.Name}.ToString());");
                }
            }
            
            // En GenerateSerializationCode, dentro del foreach de propiedades:
            if (typeSymbol.BaseType?.ToDisplayString() == "System.Exception")
            {
                sb.AppendLine($"            yield return (nameof(Message), Message);");
                sb.AppendLine($"            yield return (nameof(StackTrace), StackTrace);");
                sb.AppendLine($"            yield return (nameof(Source), Source);");
                sb.AppendLine($"            yield return (nameof(HResult), HResult.ToString());");
                sb.AppendLine($"            yield return (nameof(HelpLink), HelpLink);");
                sb.AppendLine($"            yield return (nameof(InnerException), InnerException?.Message);");
            }
            
            sb.AppendLine("        }");
        
            // Implementación de CreateFromProperties
            sb.AppendLine($"        {typeSymbol.Name} IJsonDesSerializable<{typeSymbol.Name}>.CreateFromProperties(Dictionary<string, string> properties)");
            sb.AppendLine("        {");
            sb.AppendLine($"            return new {typeSymbol.Name}");
            sb.AppendLine("            {");
            foreach (ISymbol member in typeSymbol.GetMembers())
            {
               if (member is IPropertySymbol property)
                {
                    ITypeSymbol type = property.Type;
                    string name = property.Name;
                    string typeName = type.ToDisplayString();
                
                    switch (type.SpecialType)
                    {
                       case Microsoft.CodeAnalysis.SpecialType.System_Boolean:
                           sb.AppendLine($"                {name} = properties.TryGetValue(nameof({name}), out var v_{name}) && bool.TryParse(v_{name}, out var b_{name}) ? b_{name} : false,");
                           break;
                       case Microsoft.CodeAnalysis.SpecialType.System_Char:
                           sb.AppendLine($"                {name} = properties.TryGetValue(nameof({name}), out var v_{name}) && char.TryParse(v_{name}, out var c_{name}) ? c_{name} : '\\0',");
                           break;
                       case Microsoft.CodeAnalysis.SpecialType.System_Byte:
                           sb.AppendLine($"                {name} = properties.TryGetValue(nameof({name}), out var v_{name}) && byte.TryParse(v_{name}, out var b_{name}) ? b_{name} : (byte)0,");
                           break;
                       case Microsoft.CodeAnalysis.SpecialType.System_SByte:
                           sb.AppendLine($"                {name} = properties.TryGetValue(nameof({name}), out var v_{name}) && sbyte.TryParse(v_{name}, out var sb_{name}) ? sb_{name} : (sbyte)0,");
                           break;
                       case Microsoft.CodeAnalysis.SpecialType.System_Int16:
                           sb.AppendLine($"                {name} = properties.TryGetValue(nameof({name}), out var v_{name}) && short.TryParse(v_{name}, out var s_{name}) ? s_{name} : (short)0,");
                           break;
                       case Microsoft.CodeAnalysis.SpecialType.System_UInt16:
                           sb.AppendLine($"                {name} = properties.TryGetValue(nameof({name}), out var v_{name}) && ushort.TryParse(v_{name}, out var us_{name}) ? us_{name} : (ushort)0,");
                           break;
                       case Microsoft.CodeAnalysis.SpecialType.System_Int32:
                           sb.AppendLine($"                {name} = properties.TryGetValue(nameof({name}), out var v_{name}) && int.TryParse(v_{name}, out var i_{name}) ? i_{name} : 0,");
                           break;
                       case Microsoft.CodeAnalysis.SpecialType.System_UInt32:
                           sb.AppendLine($"                {name} = properties.TryGetValue(nameof({name}), out var v_{name}) && uint.TryParse(v_{name}, out var ui_{name}) ? ui_{name} : 0u,");
                           break;
                       case Microsoft.CodeAnalysis.SpecialType.System_Int64:
                           sb.AppendLine($"                {name} = properties.TryGetValue(nameof({name}), out var v_{name}) && long.TryParse(v_{name}, out var l_{name}) ? l_{name} : 0L,");
                           break;
                       case Microsoft.CodeAnalysis.SpecialType.System_UInt64:
                           sb.AppendLine($"                {name} = properties.TryGetValue(nameof({name}), out var v_{name}) && ulong.TryParse(v_{name}, out var ul_{name}) ? ul_{name} : 0UL,");
                           break;
                       case Microsoft.CodeAnalysis.SpecialType.System_Single:
                           sb.AppendLine($"                {name} = properties.TryGetValue(nameof({name}), out var v_{name}) && float.TryParse(v_{name}, out var f_{name}) ? f_{name} : 0f,");
                           break;
                       case Microsoft.CodeAnalysis.SpecialType.System_Double:
                           sb.AppendLine($"                {name} = properties.TryGetValue(nameof({name}), out var v_{name}) && double.TryParse(v_{name}, out var d_{name}) ? d_{name} : 0d,");
                           break;
                       case Microsoft.CodeAnalysis.SpecialType.System_Decimal:
                           sb.AppendLine($"                {name} = properties.TryGetValue(nameof({name}), out var v_{name}) && decimal.TryParse(v_{name}, out var dec_{name}) ? dec_{name} : 0m,");
                           break;
                       case Microsoft.CodeAnalysis.SpecialType.System_String:
                           sb.AppendLine($"                {name} = properties.TryGetValue(nameof({name}), out var v_{name}) ? v_{name} : null,");
                           break;
                       default:
                       {
                           if (typeName == "System.DateTime")
                           {
                               sb.AppendLine($"                {name} = properties.TryGetValue(nameof({name}), out var v_{name}) && DateTime.TryParse(v_{name}, out var dt_{name}) ? dt_{name} : default,");
                           }
                           else if (typeName == "System.Guid")
                           {
                               sb.AppendLine($"                {name} = properties.TryGetValue(nameof({name}), out var v_{name}) && Guid.TryParse(v_{name}, out var g_{name}) ? g_{name} : Guid.Empty,");
                           }
                           else
                           {
                               sb.AppendLine($"                {name} = properties.TryGetValue(nameof({name}), out var v_{name}) ? v_{name} : null, // tipo no soportado, usar conversión personalizada");
                           }
                           break;
                       }
                    }
                }
            }
            
            
            
            sb.AppendLine("            };");
            sb.AppendLine("        }");
        
            // ToJson usando JsonNativeAot
            sb.AppendLine("        public string ToJson() => JsonNativeAot.Serialize(this);");
        
            // FromJson usando JsonNativeAot
            sb.AppendLine($"        public static {typeSymbol.Name} FromJson(string json) => JsonNativeAot.Deserialize<{typeSymbol.Name}>(json);");
        
            sb.AppendLine("    }");
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}