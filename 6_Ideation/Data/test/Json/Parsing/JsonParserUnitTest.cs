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
using System.Diagnostics;
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
        /// <summary>
        /// The parser
        /// </summary>
        private readonly IJsonParser _parser;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonParserUnitTest"/> class
        /// </summary>
        public JsonParserUnitTest()
        {
            _parser = new JsonParser(new EscapeSequenceHandler());
        }

        #region Constructor Tests

        /// <summary>
        /// Tests that constructor with valid handler creates instance
        /// </summary>
        [Fact]
        public void Constructor_WithValidHandler_CreatesInstance()
        {
            // Arrange & Act
            JsonParser parser = new JsonParser(new EscapeSequenceHandler());

            // Assert
            Assert.NotNull(parser);
        }

        /// <summary>
        /// Tests that constructor with null handler throws argument null exception
        /// </summary>
        [Fact]
        public void Constructor_WithNullHandler_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new JsonParser(null));
        }

        #endregion

        #region Basic Parsing Tests

        /// <summary>
        /// Tests that parse to dictionary empty json returns empty dictionary
        /// </summary>
        [Fact]
        public void ParseToDictionary_EmptyJson_ReturnsEmptyDictionary()
        {
            // Arrange
            string json = "{}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that parse to dictionary single property returns dictionary with one entry
        /// </summary>
        [Fact]
        public void ParseToDictionary_SingleProperty_ReturnsDictionaryWithOneEntry()
        {
            // Arrange
            string json = "{\"name\":\"value\"}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Single(result);
            Assert.Equal("value", result["name"]);
        }

        /// <summary>
        /// Tests that parse to dictionary two properties returns dictionary with two entries
        /// </summary>
        [Fact]
        public void ParseToDictionary_TwoProperties_ReturnsDictionaryWithTwoEntries()
        {
            // Arrange
            string json = "{\"key1\":\"value1\",\"key2\":\"value2\"}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("value1", result["key1"]);
            Assert.Equal("value2", result["key2"]);
        }

        /// <summary>
        /// Tests that parse to dictionary multiple properties returns all properties
        /// </summary>
        /// <param name="count">The count</param>
        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(50)]
        public void ParseToDictionary_MultipleProperties_ReturnsAllProperties(int count)
        {
            // Arrange
            List<string> props = new List<string>();
            for (int i = 0; i < count; i++)
            {
                props.Add($"\"prop{i}\":\"val{i}\"");
            }
            string json = "{" + string.Join(",", props) + "}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(count, result.Count);
        }

        #endregion

        #region Whitespace Handling Tests

        /// <summary>
        /// Tests that parse to dictionary leading whitespace ignores whitespace
        /// </summary>
        [Fact]
        public void ParseToDictionary_LeadingWhitespace_IgnoresWhitespace()
        {
            // Arrange
            string json = "   {\"key\":\"value\"}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Single(result);
            Assert.Equal("value", result["key"]);
        }

        /// <summary>
        /// Tests that parse to dictionary trailing whitespace ignores whitespace
        /// </summary>
        [Fact]
        public void ParseToDictionary_TrailingWhitespace_IgnoresWhitespace()
        {
            // Arrange
            string json = "{\"key\":\"value\"}   ";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Single(result);
        }

        /// <summary>
        /// Tests that parse to dictionary whitespace around colon parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WhitespaceAroundColon_ParsesCorrectly()
        {
            // Arrange
            string json = "{\"key\" : \"value\"}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("value", result["key"]);
        }

        /// <summary>
        /// Tests that parse to dictionary whitespace around commas parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WhitespaceAroundCommas_ParsesCorrectly()
        {
            // Arrange
            string json = "{\"a\":\"1\" , \"b\":\"2\"}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(2, result.Count);
        }

        /// <summary>
        /// Tests that parse to dictionary multiline json parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_MultilineJson_ParsesCorrectly()
        {
            // Arrange
            string json = @"{
                ""name"": ""value"",
                ""age"": ""30""
            }";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(2, result.Count);
        }

        /// <summary>
        /// Tests that parse to dictionary tab characters parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_TabCharacters_ParsesCorrectly()
        {
            // Arrange
            string json = "{\t\"key\":\t\"value\"\t}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Single(result);
        }

        #endregion

        #region String Value Tests

        /// <summary>
        /// Tests that parse to dictionary empty string value returns empty string
        /// </summary>
        [Fact]
        public void ParseToDictionary_EmptyStringValue_ReturnsEmptyString()
        {
            // Arrange
            string json = "{\"key\":\"\"}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("", result["key"]);
        }

        /// <summary>
        /// Tests that parse to dictionary string with spaces preserves spaces
        /// </summary>
        [Fact]
        public void ParseToDictionary_StringWithSpaces_PreservesSpaces()
        {
            // Arrange
            string json = "{\"text\":\"hello world\"}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("hello world", result["text"]);
        }

        /// <summary>
        /// Tests that parse to dictionary string with numbers returns as string
        /// </summary>
        [Fact]
        public void ParseToDictionary_StringWithNumbers_ReturnsAsString()
        {
            // Arrange
            string json = "{\"code\":\"12345\"}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("12345", result["code"]);
        }

        /// <summary>
        /// Tests that parse to dictionary string with special chars preserves chars
        /// </summary>
        [Fact]
        public void ParseToDictionary_StringWithSpecialChars_PreservesChars()
        {
            // Arrange
            string json = "{\"email\":\"user@example.com\"}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("user@example.com", result["email"]);
        }

        /// <summary>
        /// Tests that parse to dictionary single special char parses correctly
        /// </summary>
        /// <param name="specialChar">The special char</param>
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
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(specialChar, result["char"]);
        }

        #endregion

        #region Nested Structure Tests

        /// <summary>
        /// Tests that parse to dictionary nested object returns raw json
        /// </summary>
        [Fact]
        public void ParseToDictionary_NestedObject_ReturnsRawJson()
        {
            // Arrange
            string json = "{\"user\":{\"name\":\"Alice\"}}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Contains("name", result["user"]);
            Assert.Contains("Alice", result["user"]);
        }

        /// <summary>
        /// Tests that parse to dictionary empty nested object returns empty braces
        /// </summary>
        [Fact]
        public void ParseToDictionary_EmptyNestedObject_ReturnsEmptyBraces()
        {
            // Arrange
            string json = "{\"data\":{}}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("{}", result["data"]);
        }

        /// <summary>
        /// Tests that parse to dictionary deeply nested returns correct structure
        /// </summary>
        [Fact]
        public void ParseToDictionary_DeeplyNested_ReturnsCorrectStructure()
        {
            // Arrange
            string json = "{\"l1\":{\"l2\":{\"l3\":\"value\"}}}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Contains("l2", result["l1"]);
            Assert.Contains("l3", result["l1"]);
            Assert.Contains("value", result["l1"]);
        }

        /// <summary>
        /// Tests that parse to dictionary multiple nested objects parses all
        /// </summary>
        [Fact]
        public void ParseToDictionary_MultipleNestedObjects_ParsesAll()
        {
            // Arrange
            string json = "{\"obj1\":{\"a\":\"1\"},\"obj2\":{\"b\":\"2\"}}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains("a", result["obj1"]);
            Assert.Contains("b", result["obj2"]);
        }

        #endregion

        #region Array Tests

        /// <summary>
        /// Tests that parse to dictionary empty array returns empty brackets
        /// </summary>
        [Fact]
        public void ParseToDictionary_EmptyArray_ReturnsEmptyBrackets()
        {
            // Arrange
            string json = "{\"items\":[]}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("[]", result["items"]);
        }

        /// <summary>
        /// Tests that parse to dictionary array with one element returns array json
        /// </summary>
        [Fact]
        public void ParseToDictionary_ArrayWithOneElement_ReturnsArrayJson()
        {
            // Arrange
            string json = "{\"items\":[\"a\"]}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Contains("[", result["items"]);
            Assert.Contains("a", result["items"]);
            Assert.Contains("]", result["items"]);
        }

        /// <summary>
        /// Tests that parse to dictionary array with multiple elements returns full array
        /// </summary>
        [Fact]
        public void ParseToDictionary_ArrayWithMultipleElements_ReturnsFullArray()
        {
            // Arrange
            string json = "{\"tags\":[\"tag1\",\"tag2\",\"tag3\"]}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Contains("tag1", result["tags"]);
            Assert.Contains("tag2", result["tags"]);
            Assert.Contains("tag3", result["tags"]);
        }

        /// <summary>
        /// Tests that parse to dictionary array of numbers returns as string
        /// </summary>
        [Fact]
        public void ParseToDictionary_ArrayOfNumbers_ReturnsAsString()
        {
            // Arrange
            string json = "{\"scores\":[\"90\",\"85\",\"92\"]}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Contains("90", result["scores"]);
            Assert.Contains("85", result["scores"]);
        }

        /// <summary>
        /// Tests that parse to dictionary array of objects returns nested json
        /// </summary>
        [Fact]
        public void ParseToDictionary_ArrayOfObjects_ReturnsNestedJson()
        {
            // Arrange
            string json = "{\"users\":[{\"name\":\"Alice\"},{\"name\":\"Bob\"}]}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Contains("Alice", result["users"]);
            Assert.Contains("Bob", result["users"]);
        }

        #endregion

        #region Escape Sequence Tests

        /// <summary>
        /// Tests that parse to dictionary escaped quote unescapes correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_EscapedQuote_UnescapesCorrectly()
        {
            // Arrange
            string json = "{\"text\":\"say \\\"hello\\\"\"}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Contains("\"", result["text"]);
        }

        /// <summary>
        /// Tests that parse to dictionary escaped backslash unescapes correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_EscapedBackslash_UnescapesCorrectly()
        {
            // Arrange
            string json = "{\"path\":\"C:\\\\\\\\Windows\"}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Contains("\\", result["path"]);
        }

        /// <summary>
        /// Tests that parse to dictionary escaped newline unescapes correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_EscapedNewline_UnescapesCorrectly()
        {
            // Arrange
            string json = "{\"text\":\"line1\\nline2\"}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Contains("\n", result["text"]);
        }

        /// <summary>
        /// Tests that parse to dictionary escaped tab unescapes correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_EscapedTab_UnescapesCorrectly()
        {
            // Arrange
            string json = "{\"text\":\"col1\\tcol2\"}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Contains("\t", result["text"]);
        }

        /// <summary>
        /// Tests that parse to dictionary multiple escapes unescapes all
        /// </summary>
        [Fact]
        public void ParseToDictionary_MultipleEscapes_UnescapesAll()
        {
            // Arrange
            string json = "{\"text\":\"line1\\nline2\\ttab\\rcarriage\"}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Contains("\n", result["text"]);
            Assert.Contains("\t", result["text"]);
            Assert.Contains("\r", result["text"]);
        }

        #endregion

        #region Error Handling Tests

        /// <summary>
        /// Tests that parse to dictionary null input throws argument null exception
        /// </summary>
        [Fact]
        public void ParseToDictionary_NullInput_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _parser.ParseToDictionary(null));
        }

        
 

        #endregion

        #region Unicode Tests

        /// <summary>
        /// Tests that parse to dictionary unicode characters parses correctly
        /// </summary>
        /// <param name="unicodeText">The unicode text</param>
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
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(unicodeText, result["text"]);
        }

        /// <summary>
        /// Tests that parse to dictionary emojis parses correctly
        /// </summary>
        /// <param name="emoji">The emoji</param>
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
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(emoji, result["emoji"]);
        }

        #endregion

        #region Property Name Tests

        /// <summary>
        /// Tests that parse to dictionary various property names parses correctly
        /// </summary>
        /// <param name="propertyName">The property name</param>
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
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.True(result.ContainsKey(propertyName));
        }

        /// <summary>
        /// Tests that parse to dictionary property name with numbers parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_PropertyNameWithNumbers_ParsesCorrectly()
        {
            // Arrange
            string json = "{\"property123\":\"value\"}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.True(result.ContainsKey("property123"));
        }

        /// <summary>
        /// Tests that parse to dictionary property name with underscore parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_PropertyNameWithUnderscore_ParsesCorrectly()
        {
            // Arrange
            string json = "{\"_private\":\"value\"}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.True(result.ContainsKey("_private"));
        }

        /// <summary>
        /// Tests that parse to dictionary long property name parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_LongPropertyName_ParsesCorrectly()
        {
            // Arrange
            string longName = new string('a', 200);
            string json = $"{{\"{longName}\":\"value\"}}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.True(result.ContainsKey(longName));
        }

        #endregion

        #region Value Type Tests

        /// <summary>
        /// Tests that parse to dictionary integer values returns as string
        /// </summary>
        /// <param name="value">The value</param>
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
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(value, result["number"]);
        }

        /// <summary>
        /// Tests that parse to dictionary float values returns as string
        /// </summary>
        /// <param name="value">The value</param>
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
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(value, result["decimal"]);
        }

        /// <summary>
        /// Tests that parse to dictionary boolean values returns as string
        /// </summary>
        /// <param name="value">The value</param>
        [Theory]
        [InlineData("true")]
        [InlineData("false")]
        public void ParseToDictionary_BooleanValues_ReturnsAsString(string value)
        {
            // Arrange
            string json = $"{{\"flag\":\"{value}\"}}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(value, result["flag"]);
        }

        #endregion

        #region Boundary Tests

        /// <summary>
        /// Tests that parse to dictionary very long value parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_VeryLongValue_ParsesCorrectly()
        {
            // Arrange
            string longValue = new string('x', 5000);
            string json = $"{{\"data\":\"{longValue}\"}}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(longValue, result["data"]);
        }

        /// <summary>
        /// Tests that parse to dictionary max int value parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_MaxIntValue_ParsesCorrectly()
        {
            // Arrange
            string json = $"{{\"max\":\"{int.MaxValue}\"}}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(int.MaxValue.ToString(), result["max"]);
        }

        /// <summary>
        /// Tests that parse to dictionary min int value parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_MinIntValue_ParsesCorrectly()
        {
            // Arrange
            string json = $"{{\"min\":\"{int.MinValue}\"}}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(int.MinValue.ToString(), result["min"]);
        }

        #endregion

        #region Mixed Content Tests

        /// <summary>
        /// Tests that parse to dictionary mixed types parses all correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_MixedTypes_ParsesAllCorrectly()
        {
            // Arrange
            string json = "{\"str\":\"text\",\"num\":\"42\",\"bool\":\"true\",\"arr\":[],\"obj\":{}}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

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

        /// <summary>
        /// Tests that parse to dictionary large json completes reasonably
        /// </summary>
        [Fact]
        public void ParseToDictionary_LargeJson_CompletesReasonably()
        {
            // Arrange
            List<string> props = new List<string>();
            for (int i = 0; i < 1000; i++)
            {
                props.Add($"\"field{i}\":\"value{i}\"");
            }
            string json = "{" + string.Join(",", props) + "}";

            // Act
            Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            Dictionary<string, string> result = _parser.ParseToDictionary(json);
            sw.Stop();

            // Assert
            Assert.Equal(1000, result.Count);
            Assert.True(sw.ElapsedMilliseconds < 2000);
        }

        /// <summary>
        /// Tests that parse to dictionary deep nesting completes reasonably
        /// </summary>
        [Fact]
        public void ParseToDictionary_DeepNesting_CompletesReasonably()
        {
            // Arrange - 10 levels deep
            string json = "{\"l1\":{\"l2\":{\"l3\":{\"l4\":{\"l5\":{\"l6\":{\"l7\":{\"l8\":{\"l9\":{\"l10\":\"value\"}}}}}}}}}}";

            // Act
            Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            Dictionary<string, string> result = _parser.ParseToDictionary(json);
            sw.Stop();

            // Assert
            Assert.Single(result);
            Assert.True(sw.ElapsedMilliseconds < 100);
        }

        #endregion

        #region Duplicate Key Tests

        /// <summary>
        /// Tests that parse to dictionary duplicate keys uses last value
        /// </summary>
        [Fact]
        public void ParseToDictionary_DuplicateKeys_UsesLastValue()
        {
            // Arrange
            string json = "{\"key\":\"first\",\"key\":\"second\"}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("second", result["key"]);
        }

        /// <summary>
        /// Tests that parse to dictionary multiple duplicates uses last for each
        /// </summary>
        [Fact]
        public void ParseToDictionary_MultipleDuplicates_UsesLastForEach()
        {
            // Arrange
            string json = "{\"a\":\"1\",\"a\":\"2\",\"b\":\"3\",\"b\":\"4\"}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("2", result["a"]);
            Assert.Equal("4", result["b"]);
        }

        #endregion

        #region Case Sensitivity Tests

        /// <summary>
        /// Tests that parse to dictionary case sensitive keys treats as different
        /// </summary>
        [Fact]
        public void ParseToDictionary_CaseSensitiveKeys_TreatsAsDifferent()
        {
            // Arrange
            string json = "{\"Key\":\"upper\",\"key\":\"lower\"}";

            // Act
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("upper", result["Key"]);
            Assert.Equal("lower", result["key"]);
        }

        #endregion
    }
}

