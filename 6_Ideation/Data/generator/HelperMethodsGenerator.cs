// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: HelperMethodsGenerator.cs
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

using System.Text;

namespace Alis.Core.Aspect.Data.Generator
{
    /// <summary>
    ///     Generator class for helper methods used in serialization and deserialization.
    /// </summary>
    internal static class HelperMethodsGenerator
    {
        /// <summary>
        ///     Generates all helper methods for serialization and deserialization.
        /// </summary>
        /// <returns>The generated helper methods source code as a string.</returns>
        internal static string GenerateHelperMethods()
        {
            StringBuilder sb = new StringBuilder();

            AppendSerializeArrayMethod(sb);
            sb.AppendLine("");
            AppendSerialize2DArrayMethod(sb);
            sb.AppendLine("");
            AppendSerializeCollectionMethod(sb);
            sb.AppendLine("");
            AppendSerializeDictionaryMethod(sb);
            sb.AppendLine("");
            AppendDeserializeArrayMethod(sb);
            sb.AppendLine("");
            AppendDeserialize2DArrayMethod(sb);
            sb.AppendLine("");
            AppendDeserializeListMethod(sb);
            sb.AppendLine("");
            AppendDeserializeDictionaryMethod(sb);

            return sb.ToString();
        }

        /// <summary>
        ///     Appends the SerializeArray method to the string builder.
        /// </summary>
        /// <param name="sb">The string builder.</param>
        private static void AppendSerializeArrayMethod(StringBuilder sb)
        {
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        ///     Serializes a one-dimensional array to a JSON array string.");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"array\">The array to serialize.</param>");
            sb.AppendLine("        /// <returns>The JSON array string representation, or null if the array is null.</returns>");
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
        }

        /// <summary>
        ///     Appends the Serialize2DArray method to the string builder.
        /// </summary>
        /// <param name="sb">The string builder.</param>
        private static void AppendSerialize2DArrayMethod(StringBuilder sb)
        {
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        ///     Serializes a two-dimensional array to a JSON nested array string.");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <typeparam name=\"T\">The element type of the array.</typeparam>");
            sb.AppendLine("        /// <param name=\"array\">The two-dimensional array to serialize.</param>");
            sb.AppendLine("        /// <returns>The JSON nested array string representation, or null if the array is null.</returns>");
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
        }

        /// <summary>
        ///     Appends the SerializeCollection method to the string builder.
        /// </summary>
        /// <param name="sb">The string builder.</param>
        private static void AppendSerializeCollectionMethod(StringBuilder sb)
        {
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        ///     Serializes an enumerable collection to a JSON array string.");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"collection\">The collection to serialize.</param>");
            sb.AppendLine("        /// <returns>The JSON array string representation, or null if the collection is null.</returns>");
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
        }

        /// <summary>
        ///     Appends the SerializeDictionary method to the string builder.
        /// </summary>
        /// <param name="sb">The string builder.</param>
        private static void AppendSerializeDictionaryMethod(StringBuilder sb)
        {
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        ///     Serializes a dictionary to a JSON object string.");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"dictionary\">The dictionary to serialize.</param>");
            sb.AppendLine("        /// <returns>The JSON object string representation, or null if the dictionary is null.</returns>");
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
        }

        /// <summary>
        ///     Appends the DeserializeArray method to the string builder.
        /// </summary>
        /// <param name="sb">The string builder.</param>
        private static void AppendDeserializeArrayMethod(StringBuilder sb)
        {
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        ///     Deserializes a JSON array string to a typed array.");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <typeparam name=\"T\">The element type of the array.</typeparam>");
            sb.AppendLine("        /// <param name=\"json\">The JSON array string to deserialize.</param>");
            sb.AppendLine("        /// <returns>The deserialized array, or an empty array if the JSON is null or empty.</returns>");
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
            sb.AppendLine("                    items.Add((T)System.Enum.Parse(typeof(T), trimmed));");
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
        }

        /// <summary>
        ///     Appends the Deserialize2DArray method to the string builder.
        /// </summary>
        /// <param name="sb">The string builder.</param>
        private static void AppendDeserialize2DArrayMethod(StringBuilder sb)
        {
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        ///     Deserializes a JSON nested array string to a two-dimensional typed array.");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <typeparam name=\"T\">The element type of the array.</typeparam>");
            sb.AppendLine("        /// <param name=\"json\">The JSON nested array string to deserialize.</param>");
            sb.AppendLine("        /// <returns>The deserialized two-dimensional array, or an empty array if the JSON is null or empty.</returns>");
            sb.AppendLine("        private static T[,] Deserialize2DArray<T>(string json)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (string.IsNullOrEmpty(json) || json == \"[]\") return new T[0, 0];");
            sb.AppendLine("            json = json.Trim('[', ']');");
            sb.AppendLine("            if (string.IsNullOrWhiteSpace(json)) return new T[0, 0];");
            sb.AppendLine("            var rowsData = json.Split(new[] { \"],[\" }, System.StringSplitOptions.None);");
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
            sb.AppendLine("                        result[i, j] = (T)System.Enum.Parse(typeof(T), trimmed);");
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
        }

        /// <summary>
        ///     Appends the DeserializeList method to the string builder.
        /// </summary>
        /// <param name="sb">The string builder.</param>
        private static void AppendDeserializeListMethod(StringBuilder sb)
        {
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        ///     Deserializes a JSON array string to a generic list.");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <typeparam name=\"T\">The element type of the list.</typeparam>");
            sb.AppendLine("        /// <param name=\"json\">The JSON array string to deserialize.</param>");
            sb.AppendLine("        /// <returns>The deserialized list, or an empty list if the JSON is null or empty.</returns>");
            sb.AppendLine("        private static System.Collections.Generic.List<T> DeserializeList<T>(string json)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (string.IsNullOrEmpty(json) || json == \"[]\") return new System.Collections.Generic.List<T>();");
            sb.AppendLine("            var array = DeserializeArray<T>(json);");
            sb.AppendLine("            return new System.Collections.Generic.List<T>(array);");
            sb.AppendLine("        }");
        }

        /// <summary>
        ///     Appends the DeserializeDictionary method to the string builder.
        /// </summary>
        /// <param name="sb">The string builder.</param>
        private static void AppendDeserializeDictionaryMethod(StringBuilder sb)
        {
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        ///     Deserializes a JSON object string to a generic dictionary.");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <typeparam name=\"TKey\">The key type of the dictionary.</typeparam>");
            sb.AppendLine("        /// <typeparam name=\"TValue\">The value type of the dictionary.</typeparam>");
            sb.AppendLine("        /// <param name=\"json\">The JSON object string to deserialize.</param>");
            sb.AppendLine("        /// <returns>The deserialized dictionary, or an empty dictionary if the JSON is null or empty.</returns>");
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
        }
    }
}

