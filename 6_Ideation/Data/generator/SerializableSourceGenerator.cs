// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SerializableSourceGenerator.cs
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

using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Alis.Core.Aspect.Data.Generator
{
    /// <summary>
    ///     The serializable source generator class
    /// </summary>
    /// <seealso cref="ISourceGenerator" />
    [Generator]
    public class SerializableSourceGenerator : ISourceGenerator
    {
        /// <summary>
        ///     Initializes the context
        /// </summary>
        /// <param name="context">The context</param>
        public void Initialize(GeneratorInitializationContext context)
        {
            // Registrar el análisis de sintaxis
            context.RegisterForSyntaxNotifications(() => new SerializableSyntaxReceiver());
        }

        /// <summary>
        ///     Executes the context
        /// </summary>
        /// <param name="context">The context</param>
        public void Execute(GeneratorExecutionContext context)
        {
            if (context.SyntaxReceiver is not SerializableSyntaxReceiver receiver)
            {
                return;
            }

            foreach (TypeDeclarationSyntax typeDeclaration in receiver.CandidateTypes)
            {
                SemanticModel model = context.Compilation.GetSemanticModel(typeDeclaration.SyntaxTree);
                ISymbol symbol = model.GetDeclaredSymbol(typeDeclaration);

                if (symbol is not INamedTypeSymbol typeSymbol)
                {
                    continue;
                }

                // Generar código de serialización/deserialización
                string source = GenerateSerializationCode(typeSymbol);
                context.AddSource($"{typeSymbol.Name}_Serialization.g.cs", source);
            }
        }

        /// <summary>
        ///     Generates the serialization code using the specified type symbol
        /// </summary>
        /// <param name="typeSymbol">The type symbol</param>
        /// <returns>The string</returns>
        private string GenerateSerializationCode(INamedTypeSymbol typeSymbol)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("#pragma warning disable CS1591 // Deshabilitar advertencia de comentario XML");
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("");
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
                    if (property.GetAttributes().Any(a => a.AttributeClass?.Name.Contains("JsonNativeIgnore") ?? false))
                    {
                        continue;
                    }

                    AttributeData propNameAttr = property.GetAttributes()
                        .FirstOrDefault(a => a.AttributeClass?.Name == "JsonNativePropertyNameAttribute");
                    string jsonName = propNameAttr != null
                        ? propNameAttr.ConstructorArguments[0].Value?.ToString()
                        : property.Name;

                    ITypeSymbol type = property.Type;
                    if (type is IArrayTypeSymbol arrayType && arrayType.Rank == 1)
                    {
                        // Array simple
                        string elemType = arrayType.ElementType.ToDisplayString();
                        sb.AppendLine($"            yield return (\"{jsonName}\", JoinJsonSerializableArray({property.Name}));");
                    }
                    else if (type is IArrayTypeSymbol arrayType2D && arrayType2D.Rank == 2)
                    {
                        // Array 2D
                        string elemType = arrayType2D.ElementType.ToDisplayString();
                        sb.AppendLine(
                            $"            yield return (\"{jsonName}\", {property.Name} != null ? \"[\" + string.Join(\",\", Enumerable.Range(0, {property.Name}.GetLength(0)).Select(i => \"[\" + string.Join(\",\", Enumerable.Range(0, {property.Name}.GetLength(1)).Select(j => {property.Name}[i,j] is IJsonSerializable js ? JsonNativeAot.Serialize(js) : {property.Name}[i,j].ToString())) + \"]\")) + \"]\" : null);");
                    }
                    else if (type.AllInterfaces.Any(i => i.ToDisplayString().StartsWith("System.Collections.Generic.IEnumerable"))
                             && type is INamedTypeSymbol namedType && namedType.TypeArguments.Length == 1)
                    {
                        // Colección genérica
                        string itemType = namedType.TypeArguments[0].ToDisplayString();
                        sb.AppendLine($"            yield return (\"{jsonName}\", {property.Name} != null ? \"[\" + string.Join(\",\", {property.Name}.Select(x => x is IJsonSerializable js ? JsonNativeAot.Serialize(js) : x.ToString())) + \"]\" : null);");
                    }
                    else if (type.ToDisplayString().StartsWith("System.Collections.Generic.Dictionary"))
                    {
                        // Diccionario genérico
                        sb.AppendLine($"            yield return (\"{jsonName}\", {property.Name} != null ? \"{{\" + string.Join(\",\", {property.Name}.Select(kv => $\"\\\"{{kv.Key}}\\\":{{(kv.Value is IJsonSerializable js ? JsonNativeAot.Serialize(js) : kv.Value.ToString())}}\")) + \"}}\" : null);");
                    }
                    else if (type.GetAttributes().Any(a => a.AttributeClass?.ToDisplayString() == "System.SerializableAttribute"))
                    {
                        // Tipo complejo serializable
                        sb.AppendLine($"            yield return (\"{jsonName}\", {property.Name} != null ? {property.Name}.ToJson() : null);");
                    }
                    else if (type.TypeKind == TypeKind.Enum)
                    {
                        // Enum
                        sb.AppendLine($"            yield return (\"{jsonName}\", {property.Name}.ToString());");
                    }
                    else if (type is INamedTypeSymbol namedTypeSymbol && namedTypeSymbol.TypeArguments.Length > 0)
                    {
                        // Tipo complejo serializable
                        sb.AppendLine($"            yield return (\"{jsonName}\", {property.Name} != null ? \"[\" + string.Join(\",\", {property.Name}.Select(x => x is IJsonSerializable js ? js.ToJson() : x.ToString())) + \"]\" : null);");
                    }
                    else
                    {
                        // Tipo primitivo
                        sb.AppendLine($"            yield return (\"{jsonName}\", {property.Name}.ToString());");
                    }
                }
            }

            // En GenerateSerializationCode, dentro del foreach de propiedades:
            if (typeSymbol.BaseType?.ToDisplayString() == "System.Exception")
            {
                sb.AppendLine("            yield return (nameof(Message), Message);");
                sb.AppendLine("            yield return (nameof(StackTrace), StackTrace);");
                sb.AppendLine("            yield return (nameof(Source), Source);");
                sb.AppendLine("            yield return (nameof(HResult), HResult.ToString());");
                sb.AppendLine("            yield return (nameof(HelpLink), HelpLink);");
                sb.AppendLine("            yield return (nameof(InnerException), InnerException?.Message);");
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
                    // Ignorar propiedades con el atributo JsonNativeIgnore
                    if (property.GetAttributes().Any(a => a.AttributeClass?.Name.Contains("JsonNativeIgnore") ?? false))
                    {
                        continue;
                    }

                    AttributeData propNameAttr = property.GetAttributes()
                        .FirstOrDefault(a => a.AttributeClass?.Name == "JsonNativePropertyNameAttribute");
                    string jsonName = propNameAttr != null
                        ? propNameAttr.ConstructorArguments[0].Value?.ToString()
                        : property.Name;

                    ITypeSymbol type = property.Type;
                    string name = property.Name;
                    string typeName = type.ToDisplayString();

                    if (type.TypeKind == TypeKind.Enum)
                    {
                        sb.AppendLine($"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) && Enum.TryParse<{typeName}>(v_{name}, out var e_{name}) ? e_{name} : default,");
                    }
                    else if (type.AllInterfaces.Any(i => i.ToDisplayString().StartsWith("System.Collections.Generic.IEnumerable"))
                             && type is INamedTypeSymbol namedType && namedType.TypeArguments.Length == 1)
                    {
                        string itemType = namedType.TypeArguments[0].ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
                        sb.AppendLine(
                            $"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) && !string.IsNullOrEmpty(v_{name}) ? System.Text.RegularExpressions.Regex.Matches(v_{name}, \"{{[^{{}}]*}}\", System.Text.RegularExpressions.RegexOptions.Singleline).Cast<System.Text.RegularExpressions.Match>().Select(m => JsonNativeAot.Deserialize<{itemType}>(m.Value)).ToList() : new List<{itemType}>(),");
                    }
                    else if (type is IArrayTypeSymbol arrayType && arrayType.Rank == 1)
                    {
                        // Array simple
                        string elemType = arrayType.ElementType.ToDisplayString();
                        sb.AppendLine($"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) && !string.IsNullOrEmpty(v_{name}) ?");
                        sb.AppendLine($"                    v_{name}.Trim('[',']').Split(',').Select(x =>");
                        sb.AppendLine($"                        typeof({elemType}).IsEnum ? Enum.Parse(typeof({elemType}), x) :");
                        sb.AppendLine($"                        typeof({elemType}) == typeof(string) ? x :");
                        sb.AppendLine($"                        typeof({elemType}) == typeof(int) ? int.Parse(x) :");
                        sb.AppendLine($"                        typeof({elemType}) == typeof(double) ? double.Parse(x) :");
                        sb.AppendLine($"                        typeof({elemType}) == typeof(bool) ? bool.Parse(x) :");
                        sb.AppendLine($"                        Activator.CreateInstance(typeof({elemType}), x)").AppendLine($").Cast<{elemType}>().ToArray() : new {elemType}[0],");
                    }
                    else if (type is IArrayTypeSymbol arrayType2D && arrayType2D.Rank == 2)
                    {
                        // Array 2D
                        string elemType = arrayType2D.ElementType.ToDisplayString();
                        sb.AppendLine($"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) && !string.IsNullOrEmpty(v_{name}) ?");
                        sb.AppendLine($"                    Parse2DArrayInline<{elemType}>(v_{name}) : new {elemType}[0,0],");
                    }
                    else if (type.ToDisplayString().StartsWith("System.Collections.Generic.Dictionary") && type is INamedTypeSymbol dictType && dictType.TypeArguments.Length == 2)
                    {
                        // Diccionario genérico
                        string keyType = dictType.TypeArguments[0].ToDisplayString();
                        string valueType = dictType.TypeArguments[1].ToDisplayString();
                        sb.AppendLine($"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) && !string.IsNullOrEmpty(v_{name}) ?");
                        sb.AppendLine($"                    v_{name}.Trim('{{','}}').Split(',').Select(pair => pair.Split(':')).ToDictionary(");
                        sb.AppendLine($"                        arr => typeof({keyType}).IsEnum ? Enum.Parse(typeof({keyType}), arr[0].Trim('\"')) :");
                        sb.AppendLine($"                                typeof({keyType}) == typeof(string) ? arr[0].Trim('\"') :");
                        sb.AppendLine($"                                typeof({keyType}) == typeof(int) ? int.Parse(arr[0].Trim('\"')) :");
                        sb.AppendLine($"                                Activator.CreateInstance(typeof({keyType}), arr[0].Trim('\"')),");

                        sb.AppendLine($"                        arr => typeof({valueType}).IsEnum ? Enum.Parse(typeof({valueType}), arr[1]) :");
                        sb.AppendLine($"                                typeof({valueType}) == typeof(string) ? arr[1] :");
                        sb.AppendLine($"                                typeof({valueType}) == typeof(int) ? int.Parse(arr[1]) :");
                        sb.AppendLine($"                                typeof({valueType}) == typeof(double) ? double.Parse(arr[1]) :");
                        sb.AppendLine($"                                typeof({valueType}) == typeof(bool) ? bool.Parse(arr[1]) :");
                        sb.AppendLine($"                                Activator.CreateInstance(typeof({valueType}), arr[1])").AppendLine($") : new Dictionary<{keyType},{valueType}>(),");
                    }
                    else
                    {
                        switch (type.SpecialType)
                        {
                            case SpecialType.System_Boolean:
                                sb.AppendLine($"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) && bool.TryParse(v_{name}, out var b_{name}) ? b_{name} : false,");
                                break;
                            case SpecialType.System_Char:
                                sb.AppendLine($"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) && char.TryParse(v_{name}, out var c_{name}) ? c_{name} : '\\0',");
                                break;
                            case SpecialType.System_Byte:
                                sb.AppendLine($"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) && byte.TryParse(v_{name}, out var b_{name}) ? b_{name} : (byte)0,");
                                break;
                            case SpecialType.System_SByte:
                                sb.AppendLine($"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) && sbyte.TryParse(v_{name}, out var sb_{name}) ? sb_{name} : (sbyte)0,");
                                break;
                            case SpecialType.System_Int16:
                                sb.AppendLine($"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) && short.TryParse(v_{name}, out var s_{name}) ? s_{name} : (short)0,");
                                break;
                            case SpecialType.System_UInt16:
                                sb.AppendLine($"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) && ushort.TryParse(v_{name}, out var us_{name}) ? us_{name} : (ushort)0,");
                                break;
                            case SpecialType.System_Int32:
                                sb.AppendLine($"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) && int.TryParse(v_{name}, out var i_{name}) ? i_{name} : 0,");
                                break;
                            case SpecialType.System_UInt32:
                                sb.AppendLine($"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) && uint.TryParse(v_{name}, out var ui_{name}) ? ui_{name} : 0u,");
                                break;
                            case SpecialType.System_Int64:
                                sb.AppendLine($"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) && long.TryParse(v_{name}, out var l_{name}) ? l_{name} : 0L,");
                                break;
                            case SpecialType.System_UInt64:
                                sb.AppendLine($"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) && ulong.TryParse(v_{name}, out var ul_{name}) ? ul_{name} : 0UL,");
                                break;
                            case SpecialType.System_Single:
                                sb.AppendLine($"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) && float.TryParse(v_{name}, out var f_{name}) ? f_{name} : 0f,");
                                break;
                            case SpecialType.System_Double:
                                sb.AppendLine($"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) && double.TryParse(v_{name}, out var d_{name}) ? d_{name} : 0d,");
                                break;
                            case SpecialType.System_Decimal:
                                sb.AppendLine($"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) && decimal.TryParse(v_{name}, out var dec_{name}) ? dec_{name} : 0m,");
                                break;
                            case SpecialType.System_String:


                                sb.AppendLine($"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) ? v_{name} : null,");
                                break;
                            default:
                            {
                                if (typeName == "System.DateTime")
                                {
                                    sb.AppendLine($"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) && DateTime.TryParse(v_{name}, out var dt_{name}) ? dt_{name} : default,");
                                }
                                else if (typeName == "System.Guid")
                                {
                                    sb.AppendLine($"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) && Guid.TryParse(v_{name}, out var g_{name}) ? g_{name} : Guid.Empty,");
                                }
                                else if (typeName == "System.Int32")
                                {
                                    sb.AppendLine($"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) && int.TryParse(v_{name}, out var i_{name}) ? i_{name} : 0,");
                                }
                                else
                                {
                                    sb.AppendLine($@"                {name} = properties.TryGetValue(""{jsonName}"", out var v_{name}) && !string.IsNullOrEmpty(v_{name}) 
                                    ? (v_{name}.TrimStart().StartsWith(""{{"") || v_{name}.TrimStart().StartsWith(""["") 
                                        ? {typeName}.FromJson(v_{name}) 
                                        : {typeName}.FromJson(v_{name}))
                                    : null,");
                                }

                                break;
                            }
                        }
                    }
                }
            }


            sb.AppendLine("            };");
            sb.AppendLine("        }");

            sb.AppendLine(@"
                    private static string JoinJsonSerializableArray(System.Array array)
                    {
                        if (array == null) return null;
                        var sb = new System.Text.StringBuilder();
                        sb.Append(""["");
                        bool first = true;
                        foreach (var x in array)
                        {
                            if (!first) sb.Append("",""); 
                            sb.Append(x is IJsonSerializable js ? JsonNativeAot.Serialize(js) : x.ToString());
                            first = false;
                        }
                        sb.Append(""]"");
                        return sb.ToString();
                    }
            ");

            sb.AppendLine(@"
                   private static T[,] Parse2DArrayInline<T>(string json)
                   {
                       // Elimina corchetes exteriores
                       json = json.Trim('[', ']');
                       if (string.IsNullOrWhiteSpace(json)) return new T[0,0];
                       var rows = json.Split(new[] { ""],["" }, StringSplitOptions.None);
                       int rowCount = rows.Length;
                       int colCount = rows[0].Split(',').Length;
                       var result = new T[rowCount, colCount];
                       for (int i = 0; i < rowCount; i++)
                       {
                           var cleanRow = rows[i].Trim('[', ']');
                           var values = cleanRow.Split(',');
                           for (int j = 0; j < colCount; j++)
                           {
                               string val = values[j];
                               if (typeof(T).IsEnum)
                                   result[i, j] = (T)Enum.Parse(typeof(T), val);
                               else if (typeof(T) == typeof(string))
                                   result[i, j] = (T)(object)val;
                               else if (typeof(T) == typeof(int))
                                   result[i, j] = (T)(object)int.Parse(val);
                               else if (typeof(T) == typeof(double))
                                   result[i, j] = (T)(object)double.Parse(val);
                               else if (typeof(T) == typeof(bool))
                                   result[i, j] = (T)(object)bool.Parse(val);
                                else
                                {
                                    // Intenta usar FromJson si existe
                                    var fromJson = typeof(T).GetMethod(""FromJson"", new[] { typeof(string) });
                                    if (fromJson != null)
                                        result[i, j] = (T)fromJson.Invoke(null, new object[] { val });
                                    else
                                        throw new InvalidOperationException($""No se puede crear una instancia de {typeof(T).Name} con el valor '{val}'. Asegúrate de que tenga un constructor adecuado o un método FromJson."");
                                }
                           }
                       }
                       return result;
                   }
           ");

            // ToJson usando JsonNativeAot
            sb.AppendLine("        public string ToJson() => JsonNativeAot.Serialize(this);");

            // FromJson usando JsonNativeAot
            sb.AppendLine($"        public static {typeSymbol.Name} FromJson(string json) => JsonNativeAot.Deserialize<{typeSymbol.Name}>(json);");

            sb.AppendLine("    }");
            sb.AppendLine("}");

            sb.AppendLine("#pragma warning restore CS1591 // Restaurar advertencia de comentario XML");

            return sb.ToString();
        }
    }
}