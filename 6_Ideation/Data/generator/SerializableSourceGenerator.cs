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
            sb.AppendLine("#pragma warning disable CS1591 // Disable XML comment warnings");
            sb.AppendLine("#pragma warning disable CS8603 // Possible null reference return");
            sb.AppendLine("#pragma warning disable CS8604 // Possible null reference argument");
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using Alis.Core.Aspect.Data.Json;");
            sb.AppendLine("");
            sb.AppendLine($"namespace {typeSymbol.ContainingNamespace}");
            sb.AppendLine("{");
            sb.AppendLine($"    public partial {(typeSymbol.TypeKind == TypeKind.Struct ? "struct" : "class")} {typeSymbol.Name} : IJsonSerializable, IJsonDesSerializable<{typeSymbol.Name}>");
            sb.AppendLine("    {");

            // Implementación de GetSerializableProperties
            sb.AppendLine("        IEnumerable<(string PropertyName, string Value)> IJsonSerializable.GetSerializableProperties()");
            sb.AppendLine("        {");
            
            foreach (ISymbol member in typeSymbol.GetMembers())
            {
                if (member is IPropertySymbol property && property.DeclaredAccessibility == Accessibility.Public && !property.IsIndexer)
                {
                    // Skip ignored properties
                    if (property.GetAttributes().Any(a => a.AttributeClass?.Name.Contains("JsonNativeIgnore") ?? false))
                    {
                        continue;
                    }

                    AttributeData propNameAttr = property.GetAttributes()
                        .FirstOrDefault(a => a.AttributeClass?.Name == "JsonNativePropertyNameAttribute");
                    string jsonName = propNameAttr?.ConstructorArguments.FirstOrDefault().Value?.ToString() ?? property.Name;
                    string propertyName = property.Name;
                    ITypeSymbol type = property.Type;
                    string typeName = type.ToDisplayString();

                    // Handle different property types
                    if (type is IArrayTypeSymbol arrayType && arrayType.Rank == 1)
                    {
                        // 1D Array
                        sb.AppendLine($"            yield return (\"{jsonName}\", SerializeArray({propertyName}));");
                    }
                    else if (type is IArrayTypeSymbol arrayType2D && arrayType2D.Rank == 2)
                    {
                        // 2D Array
                        sb.AppendLine($"            yield return (\"{jsonName}\", Serialize2DArray({propertyName}));");
                    }
                    else if (IsListOrCollection(type))
                    {
                        // List or IEnumerable
                        sb.AppendLine($"            yield return (\"{jsonName}\", SerializeCollection({propertyName}));");
                    }
                    else if (typeName.StartsWith("System.Collections.Generic.Dictionary"))
                    {
                        // Dictionary
                        sb.AppendLine($"            yield return (\"{jsonName}\", SerializeDictionary({propertyName}));");
                    }
                    else if (type.TypeKind == TypeKind.Enum)
                    {
                        // Enum
                        sb.AppendLine($"            yield return (\"{jsonName}\", {propertyName}.ToString());");
                    }
                    else if (IsComplexType(type))
                    {
                        // Complex type (IJsonSerializable)
                        sb.AppendLine($"            yield return (\"{jsonName}\", {propertyName} != null && {propertyName} is IJsonSerializable s ? JsonNativeAot.Serialize(s) : null);");
                    }
                    else
                    {
                        // Primitive types - handle value types vs reference types
                        if (type.IsValueType)
                        {
                            sb.AppendLine($"            yield return (\"{jsonName}\", {propertyName}.ToString());");
                        }
                        else
                        {
                            sb.AppendLine($"            yield return (\"{jsonName}\", {propertyName}?.ToString());");
                        }
                    }
                }
            }

            sb.AppendLine("        }");


            // Implementación de CreateFromProperties
            sb.AppendLine($"        {typeSymbol.Name} IJsonDesSerializable<{typeSymbol.Name}>.CreateFromProperties(Dictionary<string, string> properties)");
            sb.AppendLine("        {");
            sb.AppendLine($"            return new {typeSymbol.Name}");
            sb.AppendLine("            {");
            
            foreach (ISymbol member in typeSymbol.GetMembers())
            {
                if (member is IPropertySymbol property && property.DeclaredAccessibility == Accessibility.Public && 
                    !property.IsIndexer && property.SetMethod != null)
                {
                    // Skip ignored properties
                    if (property.GetAttributes().Any(a => a.AttributeClass?.Name.Contains("JsonNativeIgnore") ?? false))
                    {
                        continue;
                    }

                    AttributeData propNameAttr = property.GetAttributes()
                        .FirstOrDefault(a => a.AttributeClass?.Name == "JsonNativePropertyNameAttribute");
                    string jsonName = propNameAttr?.ConstructorArguments.FirstOrDefault().Value?.ToString() ?? property.Name;
                    string name = property.Name;
                    ITypeSymbol type = property.Type;
                    string typeName = type.ToDisplayString();

                    // Generate deserialization code based on type
                    if (type.TypeKind == TypeKind.Enum)
                    {
                        sb.AppendLine($"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) && Enum.TryParse<{typeName}>(v_{name}, out var e_{name}) ? e_{name} : default,");
                    }
                    else if (type is IArrayTypeSymbol arrayType && arrayType.Rank == 1)
                    {
                        string elemType = arrayType.ElementType.ToDisplayString();
                        sb.AppendLine($"                {name} = DeserializeArray<{elemType}>(properties.TryGetValue(\"{jsonName}\", out var v_{name}) ? v_{name} : null),");
                    }
                    else if (type is IArrayTypeSymbol arrayType2D && arrayType2D.Rank == 2)
                    {
                        string elemType = arrayType2D.ElementType.ToDisplayString();
                        sb.AppendLine($"                {name} = Deserialize2DArray<{elemType}>(properties.TryGetValue(\"{jsonName}\", out var v_{name}) ? v_{name} : null),");
                    }
                    else if (IsListOrCollection(type) && type is INamedTypeSymbol namedType && namedType.TypeArguments.Length == 1)
                    {
                        string itemType = namedType.TypeArguments[0].ToDisplayString();
                        sb.AppendLine($"                {name} = DeserializeList<{itemType}>(properties.TryGetValue(\"{jsonName}\", out var v_{name}) ? v_{name} : null),");
                    }
                    else if (typeName.StartsWith("System.Collections.Generic.Dictionary") && type is INamedTypeSymbol dictType && dictType.TypeArguments.Length == 2)
                    {
                        string keyType = dictType.TypeArguments[0].ToDisplayString();
                        string valueType = dictType.TypeArguments[1].ToDisplayString();
                        sb.AppendLine($"                {name} = DeserializeDictionary<{keyType}, {valueType}>(properties.TryGetValue(\"{jsonName}\", out var v_{name}) ? v_{name} : null),");
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
                                else
                                {
                                    // Complex type - try to deserialize
                                    sb.AppendLine($"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) && !string.IsNullOrEmpty(v_{name}) ? JsonNativeAot.Deserialize<{typeName}>(v_{name}) : default,");
                                }
                                break;
                            }
                        }
                    }
                }
            }


            sb.AppendLine("            };");
            sb.AppendLine("        }");
            sb.AppendLine("");

            // Helper methods - line by line to avoid escaping issues
            GenerateHelperMethods(sb);

            // Extension methods
            sb.AppendLine("        public string ToJson() => JsonNativeAot.Serialize(this);");
            sb.AppendLine($"        public static {typeSymbol.Name} FromJson(string json) => JsonNativeAot.Deserialize<{typeSymbol.Name}>(json);");

            sb.AppendLine("    }");
            sb.AppendLine("}");
            sb.AppendLine("#pragma warning restore CS8604");
            sb.AppendLine("#pragma warning restore CS8603");
            sb.AppendLine("#pragma warning restore CS1591");

            return sb.ToString();
        }

        /// <summary>
        ///     Generates helper methods for serialization and deserialization
        /// </summary>
        private void GenerateHelperMethods(StringBuilder sb)
        {
            // SerializeArray
            sb.AppendLine("        private static string SerializeArray(System.Array array)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (array == null) return null;");
            sb.AppendLine("            var items = new System.Collections.Generic.List<string>();");
            sb.AppendLine("            foreach (var item in array)");
            sb.AppendLine("            {");
            sb.AppendLine("                if (item is IJsonSerializable serializable)");
            sb.AppendLine("                    items.Add(JsonNativeAot.Serialize(serializable));");
            sb.AppendLine("                else if (item is string str)");
            sb.AppendLine("                    items.Add($\"\\\"{str}\\\"\");");
            sb.AppendLine("                else");
            sb.AppendLine("                    items.Add(item?.ToString() ?? \"null\");");
            sb.AppendLine("            }");
            sb.AppendLine("            return \"[\" + string.Join(\",\", items) + \"]\";");
            sb.AppendLine("        }");
            sb.AppendLine("");

            // Serialize2DArray
            sb.AppendLine("        private static string Serialize2DArray<T>(T[,] array)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (array == null) return null;");
            sb.AppendLine("            var rowList = new System.Collections.Generic.List<string>();");
            sb.AppendLine("            for (int i = 0; i < array.GetLength(0); i++)");
            sb.AppendLine("            {");
            sb.AppendLine("                var rowItems = new System.Collections.Generic.List<string>();");
            sb.AppendLine("                for (int j = 0; j < array.GetLength(1); j++)");
            sb.AppendLine("                {");
            sb.AppendLine("                    var item = array[i, j];");
            sb.AppendLine("                    if (item is IJsonSerializable serializable)");
            sb.AppendLine("                        rowItems.Add(JsonNativeAot.Serialize(serializable));");
            sb.AppendLine("                    else if (item is string str)");
            sb.AppendLine("                        rowItems.Add($\"\\\"{str}\\\"\");");
            sb.AppendLine("                    else");
            sb.AppendLine("                        rowItems.Add(item?.ToString() ?? \"null\");");
            sb.AppendLine("                }");
            sb.AppendLine("                rowList.Add(\"[\" + string.Join(\",\", rowItems) + \"]\");");
            sb.AppendLine("            }");
            sb.AppendLine("            return \"[\" + string.Join(\",\", rowList) + \"]\";");
            sb.AppendLine("        }");
            sb.AppendLine("");

            // SerializeCollection
            sb.AppendLine("        private static string SerializeCollection(System.Collections.IEnumerable collection)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (collection == null) return null;");
            sb.AppendLine("            var items = new System.Collections.Generic.List<string>();");
            sb.AppendLine("            foreach (var item in collection)");
            sb.AppendLine("            {");
            sb.AppendLine("                if (item is IJsonSerializable serializable)");
            sb.AppendLine("                    items.Add(JsonNativeAot.Serialize(serializable));");
            sb.AppendLine("                else if (item is string str)");
            sb.AppendLine("                    items.Add($\"\\\"{str}\\\"\");");
            sb.AppendLine("                else");
            sb.AppendLine("                    items.Add(item?.ToString() ?? \"null\");");
            sb.AppendLine("            }");
            sb.AppendLine("            return \"[\" + string.Join(\",\", items) + \"]\";");
            sb.AppendLine("        }");
            sb.AppendLine("");

            // SerializeDictionary
            sb.AppendLine("        private static string SerializeDictionary(System.Collections.IDictionary dictionary)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (dictionary == null) return null;");
            sb.AppendLine("            var items = new System.Collections.Generic.List<string>();");
            sb.AppendLine("            foreach (System.Collections.DictionaryEntry entry in dictionary)");
            sb.AppendLine("            {");
            sb.AppendLine("                var key = entry.Key?.ToString() ?? \"null\";");
            sb.AppendLine("                string valueStr;");
            sb.AppendLine("                if (entry.Value is IJsonSerializable serializable)");
            sb.AppendLine("                    valueStr = JsonNativeAot.Serialize(serializable);");
            sb.AppendLine("                else if (entry.Value is string str)");
            sb.AppendLine("                    valueStr = $\"\\\"{str}\\\"\";");
            sb.AppendLine("                else");
            sb.AppendLine("                    valueStr = entry.Value?.ToString() ?? \"null\";");
            sb.AppendLine("                items.Add($\"\\\"{key}\\\":{valueStr}\");");
            sb.AppendLine("            }");
            sb.AppendLine("            return \"{\" + string.Join(\",\", items) + \"}\";");
            sb.AppendLine("        }");
            sb.AppendLine("");

            // DeserializeArray
            sb.AppendLine("        private static T[] DeserializeArray<T>(string json)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (string.IsNullOrEmpty(json) || json == \"[]\") return new T[0];");
            sb.AppendLine("            json = json.Trim('[', ']');");
            sb.AppendLine("            if (string.IsNullOrWhiteSpace(json)) return new T[0];");
            sb.AppendLine("            var items = new System.Collections.Generic.List<T>();");
            sb.AppendLine("            var parts = json.Split(',');");
            sb.AppendLine("            foreach (var part in parts)");
            sb.AppendLine("            {");
            sb.AppendLine("                var trimmed = part.Trim();");
            sb.AppendLine("                if (typeof(T) == typeof(string))");
            sb.AppendLine("                    items.Add((T)(object)trimmed.Trim('\\\"'));");
            sb.AppendLine("                else if (typeof(T).IsEnum)");
            sb.AppendLine("                    items.Add((T)Enum.Parse(typeof(T), trimmed));");
            sb.AppendLine("                else if (typeof(T) == typeof(int))");
            sb.AppendLine("                    items.Add((T)(object)int.Parse(trimmed));");
            sb.AppendLine("                else if (typeof(T) == typeof(double))");
            sb.AppendLine("                    items.Add((T)(object)double.Parse(trimmed));");
            sb.AppendLine("                else if (typeof(T) == typeof(bool))");
            sb.AppendLine("                    items.Add((T)(object)bool.Parse(trimmed));");
            sb.AppendLine("                else if (typeof(T) == typeof(float))");
            sb.AppendLine("                    items.Add((T)(object)float.Parse(trimmed));");
            sb.AppendLine("                else if (typeof(T) == typeof(long))");
            sb.AppendLine("                    items.Add((T)(object)long.Parse(trimmed));");
            sb.AppendLine("                else if (typeof(T) == typeof(decimal))");
            sb.AppendLine("                    items.Add((T)(object)decimal.Parse(trimmed));");
            sb.AppendLine("            }");
            sb.AppendLine("            return items.ToArray();");
            sb.AppendLine("        }");
            sb.AppendLine("");

            // Deserialize2DArray
            sb.AppendLine("        private static T[,] Deserialize2DArray<T>(string json)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (string.IsNullOrEmpty(json) || json == \"[]\") return new T[0, 0];");
            sb.AppendLine("            json = json.Trim('[', ']');");
            sb.AppendLine("            if (string.IsNullOrWhiteSpace(json)) return new T[0, 0];");
            sb.AppendLine("            var rowsData = json.Split(new[] { \"],[\" }, StringSplitOptions.None);");
            sb.AppendLine("            int rowCount = rowsData.Length;");
            sb.AppendLine("            var firstRow = rowsData[0].Trim('[', ']').Split(',');");
            sb.AppendLine("            int colCount = firstRow.Length;");
            sb.AppendLine("            var result = new T[rowCount, colCount];");
            sb.AppendLine("            for (int i = 0; i < rowCount; i++)");
            sb.AppendLine("            {");
            sb.AppendLine("                var cleanRow = rowsData[i].Trim('[', ']');");
            sb.AppendLine("                var values = cleanRow.Split(',');");
            sb.AppendLine("                for (int j = 0; j < colCount && j < values.Length; j++)");
            sb.AppendLine("                {");
            sb.AppendLine("                    var trimmed = values[j].Trim();");
            sb.AppendLine("                    if (typeof(T) == typeof(string))");
            sb.AppendLine("                        result[i, j] = (T)(object)trimmed.Trim('\\\"');");
            sb.AppendLine("                    else if (typeof(T).IsEnum)");
            sb.AppendLine("                        result[i, j] = (T)Enum.Parse(typeof(T), trimmed);");
            sb.AppendLine("                    else if (typeof(T) == typeof(int))");
            sb.AppendLine("                        result[i, j] = (T)(object)int.Parse(trimmed);");
            sb.AppendLine("                    else if (typeof(T) == typeof(double))");
            sb.AppendLine("                        result[i, j] = (T)(object)double.Parse(trimmed);");
            sb.AppendLine("                    else if (typeof(T) == typeof(bool))");
            sb.AppendLine("                        result[i, j] = (T)(object)bool.Parse(trimmed);");
            sb.AppendLine("                    else if (typeof(T) == typeof(float))");
            sb.AppendLine("                        result[i, j] = (T)(object)float.Parse(trimmed);");
            sb.AppendLine("                    else if (typeof(T) == typeof(long))");
            sb.AppendLine("                        result[i, j] = (T)(object)long.Parse(trimmed);");
            sb.AppendLine("                    else if (typeof(T) == typeof(decimal))");
            sb.AppendLine("                        result[i, j] = (T)(object)decimal.Parse(trimmed);");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            return result;");
            sb.AppendLine("        }");
            sb.AppendLine("");

            // DeserializeList
            sb.AppendLine("        private static System.Collections.Generic.List<T> DeserializeList<T>(string json)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (string.IsNullOrEmpty(json) || json == \"[]\") return new System.Collections.Generic.List<T>();");
            sb.AppendLine("            var array = DeserializeArray<T>(json);");
            sb.AppendLine("            return new System.Collections.Generic.List<T>(array);");
            sb.AppendLine("        }");
            sb.AppendLine("");

            // DeserializeDictionary
            sb.AppendLine("        private static System.Collections.Generic.Dictionary<TKey, TValue> DeserializeDictionary<TKey, TValue>(string json)");
            sb.AppendLine("        {");
            sb.AppendLine("            var result = new System.Collections.Generic.Dictionary<TKey, TValue>();");
            sb.AppendLine("            if (string.IsNullOrEmpty(json) || json == \"{}\") return result;");
            sb.AppendLine("            json = json.Trim('{', '}');");
            sb.AppendLine("            if (string.IsNullOrWhiteSpace(json)) return result;");
            sb.AppendLine("            var pairs = json.Split(',');");
            sb.AppendLine("            foreach (var pair in pairs)");
            sb.AppendLine("            {");
            sb.AppendLine("                var keyValue = pair.Split(':');");
            sb.AppendLine("                if (keyValue.Length == 2)");
            sb.AppendLine("                {");
            sb.AppendLine("                    var key = keyValue[0].Trim().Trim('\\\"');");
            sb.AppendLine("                    var value = keyValue[1].Trim().Trim('\\\"');");
            sb.AppendLine("                    TKey parsedKey = default;");
            sb.AppendLine("                    TValue parsedValue = default;");
            sb.AppendLine("                    if (typeof(TKey) == typeof(string))");
            sb.AppendLine("                        parsedKey = (TKey)(object)key;");
            sb.AppendLine("                    else if (typeof(TKey) == typeof(int))");
            sb.AppendLine("                        parsedKey = (TKey)(object)int.Parse(key);");
            sb.AppendLine("                    if (typeof(TValue) == typeof(string))");
            sb.AppendLine("                        parsedValue = (TValue)(object)value;");
            sb.AppendLine("                    else if (typeof(TValue) == typeof(int))");
            sb.AppendLine("                        parsedValue = (TValue)(object)int.Parse(value);");
            sb.AppendLine("                    result[parsedKey] = parsedValue;");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            return result;");
            sb.AppendLine("        }");
            sb.AppendLine("");
        }

        /// <summary>
        ///     Determines if a type is a List or IEnumerable collection
        /// </summary>
        private bool IsListOrCollection(ITypeSymbol type)
        {
            return type.AllInterfaces.Any(i => 
                i.ToDisplayString().StartsWith("System.Collections.Generic.IEnumerable") ||
                i.ToDisplayString().StartsWith("System.Collections.Generic.ICollection") ||
                i.ToDisplayString().StartsWith("System.Collections.Generic.IList"))
                && type is INamedTypeSymbol namedType && namedType.TypeArguments.Length == 1;
        }

        /// <summary>
        ///     Determines if a type is a complex type (not a primitive)
        /// </summary>
        private bool IsComplexType(ITypeSymbol type)
        {
            if (type.SpecialType != SpecialType.None)
                return false;
            if (type.TypeKind == TypeKind.Enum)
                return false;
            if (type.ToDisplayString() == "System.DateTime")
                return false;
            if (type.ToDisplayString() == "System.Guid")
                return false;
            return true;
        }
    }
}