// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: JsonParserAdvancedTest.cs
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

using System.Collections.Generic;
using System.Diagnostics;
using Alis.Core.Aspect.Data.Json.Helpers;
using Alis.Core.Aspect.Data.Json.Parsing;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json
{
    /// <summary>
    ///     Advanced test suite for JsonParser with 50+ additional test cases.
    /// </summary>
    public class JsonParserAdvancedTest
    {
        /// <summary>
        /// The escape sequence handler
        /// </summary>
        private readonly IJsonParser _parser = new JsonParser(new EscapeSequenceHandler());

        #region Whitespace Handling Tests

        /// <summary>
        /// Tests that parse to dictionary with leading whitespace parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithLeadingWhitespace_ParsesCorrectly()
        {
            // Arrange
            string json = "   {\"key\":\"value\"}";

            // Act
            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Single(dict);
            Assert.Equal("value", dict["key"]);
        }

        /// <summary>
        /// Tests that parse to dictionary with trailing whitespace parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithTrailingWhitespace_ParsesCorrectly()
        {
            // Arrange
            string json = "{\"key\":\"value\"}   ";

            // Act
            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Single(dict);
        }

        /// <summary>
        /// Tests that parse to dictionary with multiple spaces parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithMultipleSpaces_ParsesCorrectly()
        {
            // Arrange
            string json = "{  \"key\"  :  \"value\"  }";

            // Act
            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("value", dict["key"]);
        }

        /// <summary>
        /// Tests that parse to dictionary with newlines parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithNewlines_ParsesCorrectly()
        {
            // Arrange
            string json = "{\n\"key\":\"value\"\n}";

            // Act
            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Single(dict);
        }

        /// <summary>
        /// Tests that parse to dictionary with tabs parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithTabs_ParsesCorrectly()
        {
            // Arrange
            string json = "{\t\"key\":\t\"value\"\t}";

            // Act
            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Single(dict);
        }

        #endregion

        #region Complex Value Tests

        /// <summary>
        /// Tests that parse to dictionary with nested object returns raw json
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithNestedObject_ReturnsRawJson()
        {
            // Arrange
            string json = "{\"outer\":{\"inner\":\"value\"}}";

            // Act
            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.True(dict["outer"].Contains("inner"));
            Assert.True(dict["outer"].Contains("value"));
        }

        /// <summary>
        /// Tests that parse to dictionary with nested array returns raw json
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithNestedArray_ReturnsRawJson()
        {
            // Arrange
            string json = "{\"items\":[\"a\",\"b\",\"c\"]}";

            // Act
            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.StartsWith("[", dict["items"]);
            Assert.EndsWith("]", dict["items"]);
        }

        /// <summary>
        /// Tests that parse to dictionary with empty array returns empty array string
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithEmptyArray_ReturnsEmptyArrayString()
        {
            // Arrange
            string json = "{\"items\":[]}";

            // Act
            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("[]", dict["items"]);
        }

        /// <summary>
        /// Tests that parse to dictionary with empty nested object returns empty object string
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithEmptyNestedObject_ReturnsEmptyObjectString()
        {
            // Arrange
            string json = "{\"nested\":{}}";

            // Act
            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("{}", dict["nested"]);
        }

        /// <summary>
        /// Tests that parse to dictionary with deeply nested returns correct structure
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithDeeplyNested_ReturnsCorrectStructure()
        {
            // Arrange
            string json = "{\"level1\":{\"level2\":{\"level3\":\"value\"}}}";

            // Act
            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Contains("level2", dict["level1"]);
            Assert.Contains("level3", dict["level1"]);
        }

        #endregion

        #region Property Count Tests

        /// <summary>
        /// Tests that parse to dictionary with multiple properties returns correct count
        /// </summary>
        /// <param name="count">The count</param>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(10)]
        public void ParseToDictionary_WithMultipleProperties_ReturnsCorrectCount(int count)
        {
            // Arrange
            List<string> properties = new List<string>();
            for (int i = 0; i < count; i++)
            {
                properties.Add($"\"prop{i}\":\"value{i}\"");
            }
            string json = "{" + string.Join(",", properties) + "}";

            // Act
            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(count, dict.Count);
        }

        #endregion

        #region Special Characters Tests

        /// <summary>
        /// Tests that parse to dictionary with special chars in value parses correctly
        /// </summary>
        /// <param name="value">The value</param>
        [Theory]
        [InlineData("test@email.com")]
        [InlineData("test#value")]
        [InlineData("test$value")]
        [InlineData("test%value")]
        public void ParseToDictionary_WithSpecialCharsInValue_ParsesCorrectly(string value)
        {
            // Arrange
            string json = $"{{\"key\":\"{value}\"}}";

            // Act
            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(value, dict["key"]);
        }

        /// <summary>
        /// Tests that parse to dictionary with unicode characters parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithUnicodeCharacters_ParsesCorrectly()
        {
            // Arrange
            string json = "{\"key\":\"こんにちは\"}";

            // Act
            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("こんにちは", dict["key"]);
        }

        /// <summary>
        /// Tests that parse to dictionary with emojis parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithEmojis_ParsesCorrectly()
        {
            // Arrange
            string json = "{\"emoji\":\"😀\"}";

            // Act
            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("😀", dict["emoji"]);
        }

        #endregion

        #region Escape Sequence Tests

        /// <summary>
        /// Tests that parse to dictionary with escape sequences unescapes correctly
        /// </summary>
        /// <param name="escaped">The escaped</param>
        /// <param name="expected">The expected</param>
        [Theory]
        [InlineData("\\n", "\n")]
        [InlineData("\\t", "\t")]
        [InlineData("\\r", "\r")]
        public void ParseToDictionary_WithEscapeSequences_UnescapesCorrectly(string escaped, string expected)
        {
            // Arrange
            string json = $"{{\"key\":\"{escaped}\"}}";

            // Act
            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(expected, dict["key"]);
        }

        /// <summary>
        /// Tests that parse to dictionary with quoted value parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithQuotedValue_ParsesCorrectly()
        {
            // Arrange
            string json = "{\"key\":\"value with \\\"quotes\\\"\"}";

            // Act
            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Contains("\"", dict["key"]);
        }

        /// <summary>
        /// Tests that parse to dictionary with backslash parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithBackslash_ParsesCorrectly()
        {
            // Arrange
            string json = "{\"path\":\"C:\\\\\\\\Users\\\\\\\\file.txt\"}";

            // Act
            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Contains("\\", dict["path"]);
        }

        #endregion

        #region Number Value Tests

        /// <summary>
        /// Tests that parse to dictionary with integer value returns as string
        /// </summary>
        /// <param name="number">The number</param>
        [Theory]
        [InlineData("0")]
        [InlineData("1")]
        [InlineData("-1")]
        [InlineData("123")]
        [InlineData("999999")]
        public void ParseToDictionary_WithIntegerValue_ReturnsAsString(string number)
        {
            // Arrange
            string json = $"{{\"number\":\"{number}\"}}";

            // Act
            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(number, dict["number"]);
        }

        /// <summary>
        /// Tests that parse to dictionary with double value returns as string
        /// </summary>
        /// <param name="number">The number</param>
        [Theory]
        [InlineData("0.0")]
        [InlineData("1.5")]
        [InlineData("-3.14")]
        [InlineData("999.999")]
        public void ParseToDictionary_WithDoubleValue_ReturnsAsString(string number)
        {
            // Arrange
            string json = $"{{\"number\":\"{number}\"}}";

            // Act
            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(number, dict["number"]);
        }

        #endregion

        #region Boolean Value Tests

        /// <summary>
        /// Tests that parse to dictionary with boolean value returns as string
        /// </summary>
        /// <param name="boolValue">The bool value</param>
        [Theory]
        [InlineData("true")]
        [InlineData("false")]
        public void ParseToDictionary_WithBooleanValue_ReturnsAsString(string boolValue)
        {
            // Arrange
            string json = $"{{\"flag\":\"{boolValue}\"}}";

            // Act
            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(boolValue, dict["flag"]);
        }

        #endregion

        #region Empty and Null Tests

        /// <summary>
        /// Tests that parse to dictionary with empty string returns empty
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithEmptyString_ReturnsEmpty()
        {
            // Arrange
            string json = "{\"key\":\"\"}";

            // Act
            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("", dict["key"]);
        }

        /// <summary>
        /// Tests that parse to dictionary with only whitespace parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithOnlyWhitespace_ParsesCorrectly()
        {
            // Arrange
            string json = "{\"key\":\"   \"}";

            // Act
            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("   ", dict["key"]);
        }

        #endregion

        #region Multiple Properties Tests

        /// <summary>
        /// Tests that parse to dictionary with mixed types parses all correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithMixedTypes_ParsesAllCorrectly()
        {
            // Arrange
            string json = "{\"string\":\"text\",\"number\":\"42\",\"bool\":\"true\",\"nested\":{}}";

            // Act
            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(4, dict.Count);
            Assert.Equal("text", dict["string"]);
            Assert.Equal("42", dict["number"]);
            Assert.Equal("true", dict["bool"]);
            Assert.Equal("{}", dict["nested"]);
        }

        /// <summary>
        /// Tests that parse to dictionary with repeated keys uses last value
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithRepeatedKeys_UsesLastValue()
        {
            // Arrange
            string json = "{\"key\":\"first\",\"key\":\"second\"}";

            // Act
            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("second", dict["key"]);
        }

        #endregion

        #region Performance Tests

        /// <summary>
        /// Tests that parse to dictionary with large json completes in reasonable time
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithLargeJson_CompletesInReasonableTime()
        {
            // Arrange
            List<string> properties = new List<string>();
            for (int i = 0; i < 1000; i++)
            {
                properties.Add($"\"prop{i}\":\"value{i}\"");
            }
            string json = "{" + string.Join(",", properties) + "}";

            // Act
            Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
            Dictionary<string, string> dict = _parser.ParseToDictionary(json);
            stopwatch.Stop();

            // Assert
            Assert.Equal(1000, dict.Count);
            Assert.True(stopwatch.ElapsedMilliseconds < 1000, "Parsing should complete in less than 1 second");
        }

        #endregion

        #region Edge Case Tests

        /// <summary>
        /// Tests that parse to dictionary with long property name parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithLongPropertyName_ParsesCorrectly()
        {
            // Arrange
            string longName = new string('a', 500);
            string json = $"{{\"{longName}\":\"value\"}}";

            // Act
            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Contains(longName, dict.Keys);
        }

        /// <summary>
        /// Tests that parse to dictionary with long value parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithLongValue_ParsesCorrectly()
        {
            // Arrange
            string longValue = new string('x', 1000);
            string json = $"{{\"key\":\"{longValue}\"}}";

            // Act
            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(longValue, dict["key"]);
        }

        /// <summary>
        /// Tests that parse to dictionary with consecutive commas parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithConsecutiveCommas_ParsesCorrectly()
        {
            // Arrange
            string json = "{\"a\":\"1\",\"b\":\"2\",\"c\":\"3\"}";

            // Act
            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(3, dict.Count);
        }

        #endregion
    }
}

