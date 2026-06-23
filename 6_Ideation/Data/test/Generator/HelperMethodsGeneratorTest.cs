// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:HelperMethodsGeneratorTest.cs
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

using Alis.Core.Aspect.Data.Generator;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Generator
{
    /// <summary>
    ///     Unit tests for the <see cref="HelperMethodsGenerator" /> class.
    /// </summary>
    public class HelperMethodsGeneratorTest
    {
        /// <summary>
        ///     Tests that GenerateHelperMethods returns a non-empty string.
        /// </summary>
        [Fact]
        public void GenerateHelperMethods_ReturnsNonEmptyString()
        {
            string result = HelperMethodsGenerator.GenerateHelperMethods();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        /// <summary>
        ///     Tests that GenerateHelperMethods contains the SerializeArray method.
        /// </summary>
        [Fact]
        public void GenerateHelperMethods_ContainsSerializeArrayMethod()
        {
            string result = HelperMethodsGenerator.GenerateHelperMethods();

            Assert.Contains("SerializeArray", result);
            Assert.Contains("System.Array array", result);
            Assert.Contains("IJsonSerializable serializable", result);
            Assert.Contains("if (array == null) return null;", result);
        }

        /// <summary>
        ///     Tests that GenerateHelperMethods contains the Serialize2DArray method.
        /// </summary>
        [Fact]
        public void GenerateHelperMethods_ContainsSerialize2DArrayMethod()
        {
            string result = HelperMethodsGenerator.GenerateHelperMethods();

            Assert.Contains("Serialize2DArray<T>", result);
            Assert.Contains("T[,] array", result);
            Assert.Contains("GetLength(0)", result);
            Assert.Contains("GetLength(1)", result);
        }

        /// <summary>
        ///     Tests that GenerateHelperMethods contains the SerializeCollection method.
        /// </summary>
        [Fact]
        public void GenerateHelperMethods_ContainsSerializeCollectionMethod()
        {
            string result = HelperMethodsGenerator.GenerateHelperMethods();

            Assert.Contains("SerializeCollection", result);
            Assert.Contains("System.Collections.IEnumerable collection", result);
        }

        /// <summary>
        ///     Tests that GenerateHelperMethods contains the SerializeDictionary method.
        /// </summary>
        [Fact]
        public void GenerateHelperMethods_ContainsSerializeDictionaryMethod()
        {
            string result = HelperMethodsGenerator.GenerateHelperMethods();

            Assert.Contains("SerializeDictionary", result);
            Assert.Contains("System.Collections.IDictionary dictionary", result);
            Assert.Contains("DictionaryEntry entry", result);
        }

        /// <summary>
        ///     Tests that GenerateHelperMethods contains the DeserializeArray method.
        /// </summary>
        [Fact]
        public void GenerateHelperMethods_ContainsDeserializeArrayMethod()
        {
            string result = HelperMethodsGenerator.GenerateHelperMethods();

            Assert.Contains("DeserializeArray<T>", result);
            Assert.Contains("string json", result);
            Assert.Contains("new T[0]", result);
            Assert.Contains("Trim('[', ']')", result);
        }

        /// <summary>
        ///     Tests that DeserializeArray method handles all supported primitive types.
        /// </summary>
        [Fact]
        public void GenerateHelperMethods_DeserializeArray_HandlesAllPrimitiveTypes()
        {
            string result = HelperMethodsGenerator.GenerateHelperMethods();

            Assert.Contains("typeof(T) == typeof(string)", result);
            Assert.Contains("typeof(T).IsEnum", result);
            Assert.Contains("typeof(T) == typeof(int)", result);
            Assert.Contains("typeof(T) == typeof(double)", result);
            Assert.Contains("typeof(T) == typeof(bool)", result);
            Assert.Contains("typeof(T) == typeof(float)", result);
            Assert.Contains("typeof(T) == typeof(long)", result);
            Assert.Contains("typeof(T) == typeof(decimal)", result);
        }

        /// <summary>
        ///     Tests that GenerateHelperMethods contains the Deserialize2DArray method.
        /// </summary>
        [Fact]
        public void GenerateHelperMethods_ContainsDeserialize2DArrayMethod()
        {
            string result = HelperMethodsGenerator.GenerateHelperMethods();

            Assert.Contains("Deserialize2DArray<T>", result);
            Assert.Contains("new T[0, 0]", result);
            Assert.Contains("\"],[\"", result);
        }

        /// <summary>
        ///     Tests that GenerateHelperMethods contains the DeserializeList method.
        /// </summary>
        [Fact]
        public void GenerateHelperMethods_ContainsDeserializeListMethod()
        {
            string result = HelperMethodsGenerator.GenerateHelperMethods();

            Assert.Contains("DeserializeList<T>", result);
            Assert.Contains("new System.Collections.Generic.List<T>", result);
            Assert.Contains("DeserializeArray<T>(json)", result);
        }

        /// <summary>
        ///     Tests that GenerateHelperMethods contains the DeserializeDictionary method.
        /// </summary>
        [Fact]
        public void GenerateHelperMethods_ContainsDeserializeDictionaryMethod()
        {
            string result = HelperMethodsGenerator.GenerateHelperMethods();

            Assert.Contains("DeserializeDictionary<TKey, TValue>", result);
            Assert.Contains("new System.Collections.Generic.Dictionary<TKey, TValue>()", result);
            Assert.Contains("Trim('{', '}')", result);
        }

        /// <summary>
        ///     Tests that generated helper methods include XML documentation comments.
        /// </summary>
        [Fact]
        public void GenerateHelperMethods_ContainsXmlDocumentation()
        {
            string result = HelperMethodsGenerator.GenerateHelperMethods();

            Assert.Contains("/// <summary>", result);
            Assert.Contains("/// </summary>", result);
            Assert.Contains("/// <param", result);
            Assert.Contains("/// <returns>", result);
        }

        /// <summary>
        ///     Tests that generated helper methods include [ExcludeFromCodeCoverage] attribute.
        /// </summary>
        [Fact]
        public void GenerateHelperMethods_ContainsExcludeFromCodeCoverageAttribute()
        {
            string result = HelperMethodsGenerator.GenerateHelperMethods();

            int count = result.Split(new[] { "[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]" }, System.StringSplitOptions.None).Length - 1;
            Assert.Equal(8, count);
        }

        /// <summary>
        ///     Tests that generated helper methods contain string.Join for array serialization.
        /// </summary>
        [Fact]
        public void GenerateHelperMethods_ContainsStringJoinForArrays()
        {
            string result = HelperMethodsGenerator.GenerateHelperMethods();

            Assert.Contains("[\" + string.Join(\",\", items) + \"]", result);
        }

        /// <summary>
        ///     Tests that generated helper methods contain string.Join for dictionary serialization.
        /// </summary>
        [Fact]
        public void GenerateHelperMethods_ContainsStringJoinForDictionaries()
        {
            string result = HelperMethodsGenerator.GenerateHelperMethods();

            Assert.Contains("\"{\" + string.Join(\",\", items) + \"}\"", result);
        }

        /// <summary>
        ///     Tests that generated helper methods handle null strings correctly.
        /// </summary>
        [Fact]
        public void GenerateHelperMethods_HandlesNullStrings()
        {
            string result = HelperMethodsGenerator.GenerateHelperMethods();

            Assert.Contains("\"\\\"{str}\\\"\"", result);
        }

        /// <summary>
        ///     Tests that generated helper methods handle null values with ToString fallback.
        /// </summary>
        [Fact]
        public void GenerateHelperMethods_HandlesNullValuesWithToStringFallback()
        {
            string result = HelperMethodsGenerator.GenerateHelperMethods();

            Assert.Contains("item?.ToString() ?? \"null\"", result);
        }

        /// <summary>
        ///     Tests that DeserializeArray handles empty and null JSON.
        /// </summary>
        [Fact]
        public void GenerateHelperMethods_DeserializeArray_HandlesEmptyAndNullJson()
        {
            string result = HelperMethodsGenerator.GenerateHelperMethods();

            Assert.Contains("string.IsNullOrEmpty(json)", result);
            Assert.Contains("json == \"[]\"", result);
        }

        /// <summary>
        ///     Tests that generated helper methods contain proper method signatures with private static access.
        /// </summary>
        [Fact]
        public void GenerateHelperMethods_ContainsPrivateStaticMethodSignatures()
        {
            string result = HelperMethodsGenerator.GenerateHelperMethods();

            Assert.Contains("private static string SerializeArray", result);
            Assert.Contains("private static string Serialize2DArray<T>", result);
            Assert.Contains("private static string SerializeCollection", result);
            Assert.Contains("private static string SerializeDictionary", result);
            Assert.Contains("private static T[] DeserializeArray<T>", result);
            Assert.Contains("private static T[,] Deserialize2DArray<T>", result);
            Assert.Contains("private static System.Collections.Generic.List<T> DeserializeList<T>", result);
            Assert.Contains("private static System.Collections.Generic.Dictionary<TKey, TValue> DeserializeDictionary<TKey, TValue>", result);
        }

        /// <summary>
        ///     Tests that generated helper methods contain proper namespace-qualified types.
        /// </summary>
        [Fact]
        public void GenerateHelperMethods_ContainsNamespaceQualifiedTypes()
        {
            string result = HelperMethodsGenerator.GenerateHelperMethods();

            Assert.Contains("System.Array", result);
            Assert.Contains("System.Collections.Generic.List<string>", result);
            Assert.Contains("System.Collections.IEnumerable", result);
            Assert.Contains("System.Collections.IDictionary", result);
            Assert.Contains("System.Collections.DictionaryEntry", result);
        }

        /// <summary>
        ///     Tests that DeserializeDictionary handles key-value parsing with colon separator.
        /// </summary>
        [Fact]
        public void GenerateHelperMethods_DeserializeDictionary_HandlesKeyValueParsing()
        {
            string result = HelperMethodsGenerator.GenerateHelperMethods();

            Assert.Contains("pair.Split(':')", result);
            Assert.Contains("keyValue[0].Trim().Trim('\\\"')", result);
            Assert.Contains("keyValue[1].Trim().Trim('\\\"')", result);
        }

        /// <summary>
        ///     Tests that Deserialize2DArray splits rows using bracket delimiter.
        /// </summary>
        [Fact]
        public void GenerateHelperMethods_Deserialize2DArray_SplitsRowsCorrectly()
        {
            string result = HelperMethodsGenerator.GenerateHelperMethods();

            Assert.Contains("json.Split(new[] { \"],[\" }, System.StringSplitOptions.None)", result);
            Assert.Contains("Trim('[', ']')", result);
        }

        /// <summary>
        ///     Tests that generated output contains all 8 helper methods total.
        /// </summary>
        [Fact]
        public void GenerateHelperMethods_ContainsAllEightMethods()
        {
            string result = HelperMethodsGenerator.GenerateHelperMethods();

            int methodCount = result.Split(new[] { "private static" }, System.StringSplitOptions.None).Length - 1;
            Assert.Equal(8, methodCount);
        }

        /// <summary>
        ///     Tests that the output contains JsonNativeAot.Serialize calls for serializable objects.
        /// </summary>
        [Fact]
        public void GenerateHelperMethods_ContainsJsonNativeAotSerializeCalls()
        {
            string result = HelperMethodsGenerator.GenerateHelperMethods();

            int count = result.Split(new[] { "JsonNativeAot.Serialize" }, System.StringSplitOptions.None).Length - 1;
            Assert.True(count >= 4, $"Expected at least 4 JsonNativeAot.Serialize calls, got {count}");
        }

        /// <summary>
        ///     Tests that the output contains proper foreach loops for iteration.
        /// </summary>
        [Fact]
        public void GenerateHelperMethods_ContainsForeachLoops()
        {
            string result = HelperMethodsGenerator.GenerateHelperMethods();

            int foreachCount = result.Split(new[] { "foreach" }, System.StringSplitOptions.None).Length - 1;
            Assert.True(foreachCount >= 4, $"Expected at least 4 foreach loops, got {foreachCount}");
        }
    }
}
