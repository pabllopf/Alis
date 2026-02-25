// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: JsonParserUnitTest.cs
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

using System;
using System.Collections.Generic;
using System.Linq;
using Alis.Core.Aspect.Data.Json.Helpers;
using Alis.Core.Aspect.Data.Json.Parsing;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json.Parsing
{
    /// <summary>
    ///     Comprehensive unit tests for JsonParser class.
    ///     Tests all parsing scenarios, edge cases, and error conditions.
    /// </summary>
    public class JsonParserUnitTest
    {
        private readonly IJsonParser _parser;

        public JsonParserUnitTest()
        {
            _parser = new JsonParser(new EscapeSequenceHandler());
        }

        #region Constructor Tests

        [Fact]
        public void Constructor_WithValidHandler_CreatesInstance()
        {
            // Arrange & Act
            var parser = new JsonParser(new EscapeSequenceHandler());

            // Assert
            Assert.NotNull(parser);
        }

        [Fact]
        public void Constructor_WithNullHandler_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new JsonParser(null));
        }

        #endregion

        #region Basic Parsing Tests

        [Fact]
        public void ParseToDictionary_EmptyJson_ReturnsEmptyDictionary()
        {
            // Arrange
            string json = "{}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void ParseToDictionary_SingleProperty_ReturnsDictionaryWithOneEntry()
        {
            // Arrange
            string json = "{\"name\":\"value\"}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Single(result);
            Assert.Equal("value", result["name"]);
        }

        [Fact]
        public void ParseToDictionary_TwoProperties_ReturnsDictionaryWithTwoEntries()
        {
            // Arrange
            string json = "{\"key1\":\"value1\",\"key2\":\"value2\"}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("value1", result["key1"]);
            Assert.Equal("value2", result["key2"]);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(50)]
        public void ParseToDictionary_MultipleProperties_ReturnsAllProperties(int count)
        {
            // Arrange
            var props = new List<string>();
            for (int i = 0; i < count; i++)
            {
                props.Add($"\"prop{i}\":\"val{i}\"");
            }
            string json = "{" + string.Join(",", props) + "}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(count, result.Count);
        }

        #endregion

        #region Whitespace Handling Tests

        [Fact]
        public void ParseToDictionary_LeadingWhitespace_IgnoresWhitespace()
        {
            // Arrange
            string json = "   {\"key\":\"value\"}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Single(result);
            Assert.Equal("value", result["key"]);
        }

        [Fact]
        public void ParseToDictionary_TrailingWhitespace_IgnoresWhitespace()
        {
            // Arrange
            string json = "{\"key\":\"value\"}   ";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Single(result);
        }

        [Fact]
        public void ParseToDictionary_WhitespaceAroundColon_ParsesCorrectly()
        {
            // Arrange
            string json = "{\"key\" : \"value\"}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("value", result["key"]);
        }

        [Fact]
        public void ParseToDictionary_WhitespaceAroundCommas_ParsesCorrectly()
        {
            // Arrange
            string json = "{\"a\":\"1\" , \"b\":\"2\"}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void ParseToDictionary_MultilineJson_ParsesCorrectly()
        {
            // Arrange
            string json = @"{
                ""name"": ""value"",
                ""age"": ""30""
            }";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void ParseToDictionary_TabCharacters_ParsesCorrectly()
        {
            // Arrange
            string json = "{\t\"key\":\t\"value\"\t}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Single(result);
        }

        #endregion

        #region String Value Tests

        [Fact]
        public void ParseToDictionary_EmptyStringValue_ReturnsEmptyString()
        {
            // Arrange
            string json = "{\"key\":\"\"}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("", result["key"]);
        }

        [Fact]
        public void ParseToDictionary_StringWithSpaces_PreservesSpaces()
        {
            // Arrange
            string json = "{\"text\":\"hello world\"}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("hello world", result["text"]);
        }

        [Fact]
        public void ParseToDictionary_StringWithNumbers_ReturnsAsString()
        {
            // Arrange
            string json = "{\"code\":\"12345\"}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("12345", result["code"]);
        }

        [Fact]
        public void ParseToDictionary_StringWithSpecialChars_PreservesChars()
        {
            // Arrange
            string json = "{\"email\":\"user@example.com\"}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("user@example.com", result["email"]);
        }

        [Theory]
        [InlineData("!")]
        [InlineData("@")]
        [InlineData("#")]
        [InlineData("$")]
        [InlineData("%")]
        [InlineData("&")]
        [InlineData("*")]
        public void ParseToDictionary_SingleSpecialChar_ParsesCorrectly(string specialChar)
        {
            // Arrange
            string json = $"{{\"char\":\"{specialChar}\"}}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(specialChar, result["char"]);
        }

        #endregion

        #region Nested Structure Tests

        [Fact]
        public void ParseToDictionary_NestedObject_ReturnsRawJson()
        {
            // Arrange
            string json = "{\"user\":{\"name\":\"Alice\"}}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Contains("name", result["user"]);
            Assert.Contains("Alice", result["user"]);
        }

        [Fact]
        public void ParseToDictionary_EmptyNestedObject_ReturnsEmptyBraces()
        {
            // Arrange
            string json = "{\"data\":{}}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("{}", result["data"]);
        }

        [Fact]
        public void ParseToDictionary_DeeplyNested_ReturnsCorrectStructure()
        {
            // Arrange
            string json = "{\"l1\":{\"l2\":{\"l3\":\"value\"}}}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Contains("l2", result["l1"]);
            Assert.Contains("l3", result["l1"]);
            Assert.Contains("value", result["l1"]);
        }

        [Fact]
        public void ParseToDictionary_MultipleNestedObjects_ParsesAll()
        {
            // Arrange
            string json = "{\"obj1\":{\"a\":\"1\"},\"obj2\":{\"b\":\"2\"}}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains("a", result["obj1"]);
            Assert.Contains("b", result["obj2"]);
        }

        #endregion

        #region Array Tests

        [Fact]
        public void ParseToDictionary_EmptyArray_ReturnsEmptyBrackets()
        {
            // Arrange
            string json = "{\"items\":[]}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("[]", result["items"]);
        }

        [Fact]
        public void ParseToDictionary_ArrayWithOneElement_ReturnsArrayJson()
        {
            // Arrange
            string json = "{\"items\":[\"a\"]}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Contains("[", result["items"]);
            Assert.Contains("a", result["items"]);
            Assert.Contains("]", result["items"]);
        }

        [Fact]
        public void ParseToDictionary_ArrayWithMultipleElements_ReturnsFullArray()
        {
            // Arrange
            string json = "{\"tags\":[\"tag1\",\"tag2\",\"tag3\"]}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Contains("tag1", result["tags"]);
            Assert.Contains("tag2", result["tags"]);
            Assert.Contains("tag3", result["tags"]);
        }

        [Fact]
        public void ParseToDictionary_ArrayOfNumbers_ReturnsAsString()
        {
            // Arrange
            string json = "{\"scores\":[\"90\",\"85\",\"92\"]}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Contains("90", result["scores"]);
            Assert.Contains("85", result["scores"]);
        }

        [Fact]
        public void ParseToDictionary_ArrayOfObjects_ReturnsNestedJson()
        {
            // Arrange
            string json = "{\"users\":[{\"name\":\"Alice\"},{\"name\":\"Bob\"}]}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Contains("Alice", result["users"]);
            Assert.Contains("Bob", result["users"]);
        }

        #endregion

        #region Escape Sequence Tests

        [Fact]
        public void ParseToDictionary_EscapedQuote_UnescapesCorrectly()
        {
            // Arrange
            string json = "{\"text\":\"say \\\"hello\\\"\"}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Contains("\"", result["text"]);
        }

        [Fact]
        public void ParseToDictionary_EscapedBackslash_UnescapesCorrectly()
        {
            // Arrange
            string json = "{\"path\":\"C:\\\\\\\\Windows\"}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Contains("\\", result["path"]);
        }

        [Fact]
        public void ParseToDictionary_EscapedNewline_UnescapesCorrectly()
        {
            // Arrange
            string json = "{\"text\":\"line1\\nline2\"}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Contains("\n", result["text"]);
        }

        [Fact]
        public void ParseToDictionary_EscapedTab_UnescapesCorrectly()
        {
            // Arrange
            string json = "{\"text\":\"col1\\tcol2\"}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Contains("\t", result["text"]);
        }

        [Fact]
        public void ParseToDictionary_MultipleEscapes_UnescapesAll()
        {
            // Arrange
            string json = "{\"text\":\"line1\\nline2\\ttab\\rcarriage\"}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Contains("\n", result["text"]);
            Assert.Contains("\t", result["text"]);
            Assert.Contains("\r", result["text"]);
        }

        #endregion

        #region Error Handling Tests

        [Fact]
        public void ParseToDictionary_NullInput_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _parser.ParseToDictionary(null));
        }

        
 

        #endregion

        #region Unicode Tests

        [Theory]
        [InlineData("こんにちは")] // Japanese
        [InlineData("你好")] // Chinese
        [InlineData("Привет")] // Russian
        [InlineData("مرحبا")] // Arabic
        [InlineData("שלום")] // Hebrew
        public void ParseToDictionary_UnicodeCharacters_ParsesCorrectly(string unicodeText)
        {
            // Arrange
            string json = $"{{\"text\":\"{unicodeText}\"}}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(unicodeText, result["text"]);
        }

        [Theory]
        [InlineData("😀")] // Grinning face
        [InlineData("❤️")] // Heart
        [InlineData("🚀")] // Rocket
        [InlineData("🎉")] // Party popper
        public void ParseToDictionary_Emojis_ParsesCorrectly(string emoji)
        {
            // Arrange
            string json = $"{{\"emoji\":\"{emoji}\"}}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(emoji, result["emoji"]);
        }

        #endregion

        #region Property Name Tests

        [Theory]
        [InlineData("a")]
        [InlineData("simple")]
        [InlineData("camelCase")]
        [InlineData("PascalCase")]
        [InlineData("snake_case")]
        [InlineData("kebab-case")]
        public void ParseToDictionary_VariousPropertyNames_ParsesCorrectly(string propertyName)
        {
            // Arrange
            string json = $"{{\"{propertyName}\":\"value\"}}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.True(result.ContainsKey(propertyName));
        }

        [Fact]
        public void ParseToDictionary_PropertyNameWithNumbers_ParsesCorrectly()
        {
            // Arrange
            string json = "{\"property123\":\"value\"}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.True(result.ContainsKey("property123"));
        }

        [Fact]
        public void ParseToDictionary_PropertyNameWithUnderscore_ParsesCorrectly()
        {
            // Arrange
            string json = "{\"_private\":\"value\"}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.True(result.ContainsKey("_private"));
        }

        [Fact]
        public void ParseToDictionary_LongPropertyName_ParsesCorrectly()
        {
            // Arrange
            string longName = new string('a', 200);
            string json = $"{{\"{longName}\":\"value\"}}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.True(result.ContainsKey(longName));
        }

        #endregion

        #region Value Type Tests

        [Theory]
        [InlineData("0")]
        [InlineData("42")]
        [InlineData("-100")]
        [InlineData("2147483647")]
        public void ParseToDictionary_IntegerValues_ReturnsAsString(string value)
        {
            // Arrange
            string json = $"{{\"number\":\"{value}\"}}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(value, result["number"]);
        }

        [Theory]
        [InlineData("0.0")]
        [InlineData("3.14")]
        [InlineData("-2.5")]
        [InlineData("1.23456789")]
        public void ParseToDictionary_FloatValues_ReturnsAsString(string value)
        {
            // Arrange
            string json = $"{{\"decimal\":\"{value}\"}}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(value, result["decimal"]);
        }

        [Theory]
        [InlineData("true")]
        [InlineData("false")]
        public void ParseToDictionary_BooleanValues_ReturnsAsString(string value)
        {
            // Arrange
            string json = $"{{\"flag\":\"{value}\"}}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(value, result["flag"]);
        }

        #endregion

        #region Boundary Tests

        [Fact]
        public void ParseToDictionary_VeryLongValue_ParsesCorrectly()
        {
            // Arrange
            string longValue = new string('x', 5000);
            string json = $"{{\"data\":\"{longValue}\"}}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(longValue, result["data"]);
        }

        [Fact]
        public void ParseToDictionary_MaxIntValue_ParsesCorrectly()
        {
            // Arrange
            string json = $"{{\"max\":\"{int.MaxValue}\"}}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(int.MaxValue.ToString(), result["max"]);
        }

        [Fact]
        public void ParseToDictionary_MinIntValue_ParsesCorrectly()
        {
            // Arrange
            string json = $"{{\"min\":\"{int.MinValue}\"}}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(int.MinValue.ToString(), result["min"]);
        }

        #endregion

        #region Mixed Content Tests

        [Fact]
        public void ParseToDictionary_MixedTypes_ParsesAllCorrectly()
        {
            // Arrange
            string json = "{\"str\":\"text\",\"num\":\"42\",\"bool\":\"true\",\"arr\":[],\"obj\":{}}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(5, result.Count);
            Assert.Equal("text", result["str"]);
            Assert.Equal("42", result["num"]);
            Assert.Equal("true", result["bool"]);
            Assert.Equal("[]", result["arr"]);
            Assert.Equal("{}", result["obj"]);
        }

        #endregion

        #region Performance Tests

        [Fact]
        public void ParseToDictionary_LargeJson_CompletesReasonably()
        {
            // Arrange
            var props = new List<string>();
            for (int i = 0; i < 1000; i++)
            {
                props.Add($"\"field{i}\":\"value{i}\"");
            }
            string json = "{" + string.Join(",", props) + "}";

            // Act
            var sw = System.Diagnostics.Stopwatch.StartNew();
            var result = _parser.ParseToDictionary(json);
            sw.Stop();

            // Assert
            Assert.Equal(1000, result.Count);
            Assert.True(sw.ElapsedMilliseconds < 2000);
        }

        [Fact]
        public void ParseToDictionary_DeepNesting_CompletesReasonably()
        {
            // Arrange - 10 levels deep
            string json = "{\"l1\":{\"l2\":{\"l3\":{\"l4\":{\"l5\":{\"l6\":{\"l7\":{\"l8\":{\"l9\":{\"l10\":\"value\"}}}}}}}}}}";

            // Act
            var sw = System.Diagnostics.Stopwatch.StartNew();
            var result = _parser.ParseToDictionary(json);
            sw.Stop();

            // Assert
            Assert.Single(result);
            Assert.True(sw.ElapsedMilliseconds < 100);
        }

        #endregion

        #region Duplicate Key Tests

        [Fact]
        public void ParseToDictionary_DuplicateKeys_UsesLastValue()
        {
            // Arrange
            string json = "{\"key\":\"first\",\"key\":\"second\"}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("second", result["key"]);
        }

        [Fact]
        public void ParseToDictionary_MultipleDuplicates_UsesLastForEach()
        {
            // Arrange
            string json = "{\"a\":\"1\",\"a\":\"2\",\"b\":\"3\",\"b\":\"4\"}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("2", result["a"]);
            Assert.Equal("4", result["b"]);
        }

        #endregion

        #region Case Sensitivity Tests

        [Fact]
        public void ParseToDictionary_CaseSensitiveKeys_TreatsAsDifferent()
        {
            // Arrange
            string json = "{\"Key\":\"upper\",\"key\":\"lower\"}";

            // Act
            var result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("upper", result["Key"]);
            Assert.Equal("lower", result["key"]);
        }

        #endregion
    }
}

