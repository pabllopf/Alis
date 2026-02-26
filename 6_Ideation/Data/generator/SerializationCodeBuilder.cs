// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: SerializationCodeBuilder.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web: https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program. If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;

namespace Alis.Core.Aspect.Data.Generator
{
    /// <summary>
    ///     Builder class for generating serialization and deserialization code.
    /// </summary>
    internal class SerializationCodeBuilder
    {
        /// <summary>
        /// The string builder
        /// </summary>
        private readonly StringBuilder _stringBuilder;
        /// <summary>
        /// The type symbol
        /// </summary>
        private readonly INamedTypeSymbol _typeSymbol;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SerializationCodeBuilder" /> class.
        /// </summary>
        /// <param name="typeSymbol">The type symbol to generate code for.</param>
        public SerializationCodeBuilder(INamedTypeSymbol typeSymbol)
        {
            _stringBuilder = new StringBuilder();
            _typeSymbol = typeSymbol;
        }

        /// <summary>
        ///     Builds the complete serialization code.
        /// </summary>
        /// <returns>The generated source code as a string.</returns>
        internal string Build()
        {
            AddFileHeader();
            AddNamespaceBegin();
            AddClassDeclaration();
            AddGetSerializablePropertiesMethod();
            AddCreateFromPropertiesMethod();
            AddExtensionMethods();
            AddHelperMethods();
            AddClassEnd();
            AddNamespaceEnd();
            AddFileFooter();

            return _stringBuilder.ToString();
        }

        /// <summary>
        ///     Adds the file header with pragma directives.
        /// </summary>
        private void AddFileHeader()
        {
            _stringBuilder.AppendLine("#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member");
            _stringBuilder.AppendLine("#pragma warning disable CS8603 // Possible null reference return");
            _stringBuilder.AppendLine("#pragma warning disable CS8604 // Possible null reference argument");
            _stringBuilder.AppendLine("#pragma warning disable CS8618 // Non-nullable field is uninitialized");
            _stringBuilder.AppendLine("using System;");
            _stringBuilder.AppendLine("using System.Linq;");
            _stringBuilder.AppendLine("using System.Collections.Generic;");
            _stringBuilder.AppendLine("using Alis.Core.Aspect.Data.Json;");
            _stringBuilder.AppendLine("");
        }

        /// <summary>
        ///     Adds the namespace declaration.
        /// </summary>
        private void AddNamespaceBegin()
        {
            _stringBuilder.AppendLine($"namespace {_typeSymbol.ContainingNamespace}");
            _stringBuilder.AppendLine("{");
        }

        /// <summary>
        ///     Adds the class declaration with the necessary interfaces.
        /// </summary>
        private void AddClassDeclaration()
        {
            string typeKeyword = _typeSymbol.TypeKind == TypeKind.Struct ? "struct" : "class";
            _stringBuilder.AppendLine($"    /// <summary>");
            _stringBuilder.AppendLine($"    ///     Partial implementation of {_typeSymbol.Name} providing JSON serialization support.");
            _stringBuilder.AppendLine($"    /// </summary>");
            _stringBuilder.AppendLine($"    public partial {typeKeyword} {_typeSymbol.Name} : IJsonSerializable, IJsonDesSerializable<{_typeSymbol.Name}>");
            _stringBuilder.AppendLine("    {");
        }

        /// <summary>
        ///     Adds the GetSerializableProperties method implementation.
        /// </summary>
        private void AddGetSerializablePropertiesMethod()
        {
            _stringBuilder.AppendLine("        /// <summary>");
            _stringBuilder.AppendLine("        ///     Gets the serializable properties of this instance.");
            _stringBuilder.AppendLine("        /// </summary>");
            _stringBuilder.AppendLine("        /// <returns>An enumerable of tuples containing property names and their serialized values.</returns>");
            _stringBuilder.AppendLine("        IEnumerable<(string PropertyName, string Value)> IJsonSerializable.GetSerializableProperties()");
            _stringBuilder.AppendLine("        {");

            foreach (ISymbol member in _typeSymbol.GetMembers())
            {
                if (member is not IPropertySymbol property || property.DeclaredAccessibility != Accessibility.Public || property.IsIndexer)
                {
                    continue;
                }

                // Skip ignored properties
                if (property.GetAttributes().Any(a => a.AttributeClass?.Name.Contains("JsonNativeIgnore") ?? false))
                {
                    continue;
                }

                string jsonName = GetJsonPropertyName(property);
                string propertyName = property.Name;
                ITypeSymbol type = property.Type;

                AddSerializationCode(_stringBuilder, propertyName, jsonName, type);
            }

            _stringBuilder.AppendLine("            yield break;");
            _stringBuilder.AppendLine("        }");
            _stringBuilder.AppendLine("");
        }

        /// <summary>
        ///     Adds the CreateFromProperties method implementation.
        /// </summary>
        private void AddCreateFromPropertiesMethod()
        {
            _stringBuilder.AppendLine("        /// <summary>");
            _stringBuilder.AppendLine("        ///     Creates an instance from a dictionary of properties.");
            _stringBuilder.AppendLine("        /// </summary>");
            _stringBuilder.AppendLine("        /// <param name=\"properties\">The property dictionary.</param>");
            _stringBuilder.AppendLine("        /// <returns>A new instance with properties set from the dictionary.</returns>");
            _stringBuilder.AppendLine($"        {_typeSymbol.Name} IJsonDesSerializable<{_typeSymbol.Name}>.CreateFromProperties(Dictionary<string, string> properties)");
            _stringBuilder.AppendLine("        {");
            _stringBuilder.AppendLine($"            return new {_typeSymbol.Name}");
            _stringBuilder.AppendLine("            {");

            foreach (ISymbol member in _typeSymbol.GetMembers())
            {
                if (member is not IPropertySymbol property || property.DeclaredAccessibility != Accessibility.Public || 
                    property.IsIndexer || property.SetMethod == null)
                {
                    continue;
                }

                // Skip ignored properties
                if (property.GetAttributes().Any(a => a.AttributeClass?.Name.Contains("JsonNativeIgnore") ?? false))
                {
                    continue;
                }

                string jsonName = GetJsonPropertyName(property);
                string name = property.Name;
                ITypeSymbol type = property.Type;

                AddDeserializationCode(_stringBuilder, name, jsonName, type);
            }

            _stringBuilder.AppendLine("            };");
            _stringBuilder.AppendLine("        }");
            _stringBuilder.AppendLine("");
        }

        /// <summary>
        ///     Adds the extension methods for JSON conversion.
        /// </summary>
        private void AddExtensionMethods()
        {
            _stringBuilder.AppendLine("        /// <summary>");
            _stringBuilder.AppendLine("        ///     Converts this instance to its JSON string representation.");
            _stringBuilder.AppendLine("        /// </summary>");
            _stringBuilder.AppendLine("        /// <returns>The JSON string representation of this instance.</returns>");
            _stringBuilder.AppendLine("        public string ToJson() => JsonNativeAot.Serialize(this);");
            _stringBuilder.AppendLine("");
            _stringBuilder.AppendLine("        /// <summary>");
            _stringBuilder.AppendLine($"        ///     Creates an instance of {_typeSymbol.Name} from a JSON string.");
            _stringBuilder.AppendLine("        /// </summary>");
            _stringBuilder.AppendLine("        /// <param name=\"json\">The JSON string to deserialize.</param>");
            _stringBuilder.AppendLine($"        /// <returns>A new instance of {_typeSymbol.Name} deserialized from the JSON string.</returns>");
            _stringBuilder.AppendLine($"        public static {_typeSymbol.Name} FromJson(string json) => JsonNativeAot.Deserialize<{_typeSymbol.Name}>(json);");
            _stringBuilder.AppendLine("");
        }

        /// <summary>
        ///     Adds the helper methods for serialization and deserialization.
        /// </summary>
        private void AddHelperMethods()
        {
            _stringBuilder.Append(HelperMethodsGenerator.GenerateHelperMethods());
        }

        /// <summary>
        ///     Closes the class declaration.
        /// </summary>
        private void AddClassEnd()
        {
            _stringBuilder.AppendLine("    }");
        }

        /// <summary>
        ///     Closes the namespace.
        /// </summary>
        private void AddNamespaceEnd()
        {
            _stringBuilder.AppendLine("}");
        }

        /// <summary>
        ///     Adds the file footer with pragma restore directives.
        /// </summary>
        private void AddFileFooter()
        {
            _stringBuilder.AppendLine("#pragma warning restore CS8618");
            _stringBuilder.AppendLine("#pragma warning restore CS8604");
            _stringBuilder.AppendLine("#pragma warning restore CS8603");
            _stringBuilder.AppendLine("#pragma warning restore CS1591");
        }

        /// <summary>
        ///     Gets the JSON property name from the property symbol.
        /// </summary>
        /// <param name="property">The property symbol.</param>
        /// <returns>The JSON property name.</returns>
        private static string GetJsonPropertyName(IPropertySymbol property)
        {
            AttributeData propNameAttr = property.GetAttributes()
                .FirstOrDefault(a => a.AttributeClass?.Name == "JsonNativePropertyNameAttribute");

            if (propNameAttr?.ConstructorArguments.FirstOrDefault().Value is string jsonName)
            {
                return jsonName;
            }

            return property.Name;
        }

        /// <summary>
        ///     Adds serialization code for a property.
        /// </summary>
        /// <param name="sb">The string builder.</param>
        /// <param name="propertyName">The property name.</param>
        /// <param name="jsonName">The JSON property name.</param>
        /// <param name="type">The property type.</param>
        private static void AddSerializationCode(StringBuilder sb, string propertyName, string jsonName, ITypeSymbol type)
        {
            if (type is IArrayTypeSymbol arrayType)
            {
                if (arrayType.Rank == 1)
                {
                    sb.AppendLine($"            yield return (\"{jsonName}\", SerializeArray({propertyName}));");
                }
                else if (arrayType.Rank == 2)
                {
                    sb.AppendLine($"            yield return (\"{jsonName}\", Serialize2DArray({propertyName}));");
                }
            }
            else if (TypeConversionHelper.IsListOrCollection(type))
            {
                sb.AppendLine($"            yield return (\"{jsonName}\", SerializeCollection({propertyName}));");
            }
            else if (TypeConversionHelper.IsDictionary(type))
            {
                sb.AppendLine($"            yield return (\"{jsonName}\", SerializeDictionary({propertyName}));");
            }
            else if (type.TypeKind == TypeKind.Enum)
            {
                sb.AppendLine($"            yield return (\"{jsonName}\", {propertyName}.ToString());");
            }
            else if (TypeConversionHelper.IsComplexType(type))
            {
                sb.AppendLine($"            yield return (\"{jsonName}\", {propertyName} != null && {propertyName} is IJsonSerializable s ? JsonNativeAot.Serialize(s) : null);");
            }
            else
            {
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

        /// <summary>
        ///     Adds deserialization code for a property.
        /// </summary>
        /// <param name="sb">The string builder.</param>
        /// <param name="name">The property name.</param>
        /// <param name="jsonName">The JSON property name.</param>
        /// <param name="type">The property type.</param>
        private static void AddDeserializationCode(StringBuilder sb, string name, string jsonName, ITypeSymbol type)
        {
            string typeName = type.ToDisplayString();

            if (type.TypeKind == TypeKind.Enum)
            {
                sb.AppendLine($"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) && Enum.TryParse<{typeName}>(v_{name}, out var e_{name}) ? e_{name} : default,");
            }
            else if (type is IArrayTypeSymbol arrayType)
            {
                if (arrayType.Rank == 1)
                {
                    string elemType = arrayType.ElementType.ToDisplayString();
                    sb.AppendLine($"                {name} = DeserializeArray<{elemType}>(properties.TryGetValue(\"{jsonName}\", out var v_{name}) ? v_{name} : null),");
                }
                else if (arrayType.Rank == 2)
                {
                    string elemType = arrayType.ElementType.ToDisplayString();
                    sb.AppendLine($"                {name} = Deserialize2DArray<{elemType}>(properties.TryGetValue(\"{jsonName}\", out var v_{name}) ? v_{name} : null),");
                }
            }
            else if (TypeConversionHelper.IsListOrCollection(type) && type is INamedTypeSymbol namedType && namedType.TypeArguments.Length == 1)
            {
                string itemType = namedType.TypeArguments[0].ToDisplayString();
                sb.AppendLine($"                {name} = DeserializeList<{itemType}>(properties.TryGetValue(\"{jsonName}\", out var v_{name}) ? v_{name} : null),");
            }
            else if (TypeConversionHelper.IsDictionary(type) && type is INamedTypeSymbol dictType && dictType.TypeArguments.Length == 2)
            {
                string keyType = dictType.TypeArguments[0].ToDisplayString();
                string valueType = dictType.TypeArguments[1].ToDisplayString();
                sb.AppendLine($"                {name} = DeserializeDictionary<{keyType}, {valueType}>(properties.TryGetValue(\"{jsonName}\", out var v_{name}) ? v_{name} : null),");
            }
            else
            {
                AddDeserializationCodeForSpecialTypes(sb, name, jsonName, type, typeName);
            }
        }

        /// <summary>
        ///     Adds deserialization code for special types.
        /// </summary>
        /// <param name="sb">The string builder.</param>
        /// <param name="name">The property name.</param>
        /// <param name="jsonName">The JSON property name.</param>
        /// <param name="type">The property type.</param>
        /// <param name="typeName">The display name of the type.</param>
        private static void AddDeserializationCodeForSpecialTypes(StringBuilder sb, string name, string jsonName, ITypeSymbol type, string typeName)
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
                    AddDeserializationCodeForExtendedTypes(sb, name, jsonName, typeName);
                    break;
            }
        }

        /// <summary>
        ///     Adds deserialization code for extended types (DateTime, DateTimeOffset, Guid, TimeSpan, Uri, Version).
        /// </summary>
        /// <param name="sb">The string builder.</param>
        /// <param name="name">The property name.</param>
        /// <param name="jsonName">The JSON property name.</param>
        /// <param name="typeName">The display name of the type.</param>
        private static void AddDeserializationCodeForExtendedTypes(StringBuilder sb, string name, string jsonName, string typeName)
        {
            switch (typeName)
            {
                case "System.DateTime":
                    sb.AppendLine($"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) && DateTime.TryParse(v_{name}, out var dt_{name}) ? dt_{name} : default,");
                    break;
                case "System.DateTimeOffset":
                    sb.AppendLine($"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) && DateTimeOffset.TryParse(v_{name}, out var dto_{name}) ? dto_{name} : default,");
                    break;
                case "System.TimeSpan":
                    sb.AppendLine($"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) && TimeSpan.TryParse(v_{name}, out var ts_{name}) ? ts_{name} : default,");
                    break;
                case "System.Guid":
                    sb.AppendLine($"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) && Guid.TryParse(v_{name}, out var g_{name}) ? g_{name} : Guid.Empty,");
                    break;
                case "System.Uri":
                    sb.AppendLine($"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) && Uri.TryCreate(v_{name}, UriKind.RelativeOrAbsolute, out var u_{name}) ? u_{name} : null,");
                    break;
                case "System.Version":
                    sb.AppendLine($"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) ? new Version(v_{name} ?? \"0.0.0.0\") : new Version(\"0.0.0.0\"),");
                    break;
                default:
                    // Complex type - try to deserialize
                    sb.AppendLine($"                {name} = properties.TryGetValue(\"{jsonName}\", out var v_{name}) && !string.IsNullOrEmpty(v_{name}) ? JsonNativeAot.Deserialize<{typeName}>(v_{name}) : default,");
                    break;
            }
        }
    }
}

