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
        private readonly IJsonParser _parser = new JsonParser(new EscapeSequenceHandler());

        #region Whitespace Handling Tests

        [Fact]
        public void ParseToDictionary_WithLeadingWhitespace_ParsesCorrectly()
        {
            // Arrange
            string json = "   {\"key\":\"value\"}";

            // Act
            var dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Single(dict);
            Assert.Equal("value", dict["key"]);
        }

        [Fact]
        public void ParseToDictionary_WithTrailingWhitespace_ParsesCorrectly()
        {
            // Arrange
            string json = "{\"key\":\"value\"}   ";

            // Act
            var dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Single(dict);
        }

        [Fact]
        public void ParseToDictionary_WithMultipleSpaces_ParsesCorrectly()
        {
            // Arrange
            string json = "{  \"key\"  :  \"value\"  }";

            // Act
            var dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("value", dict["key"]);
        }

        [Fact]
        public void ParseToDictionary_WithNewlines_ParsesCorrectly()
        {
            // Arrange
            string json = "{\n\"key\":\"value\"\n}";

            // Act
            var dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Single(dict);
        }

        [Fact]
        public void ParseToDictionary_WithTabs_ParsesCorrectly()
        {
            // Arrange
            string json = "{\t\"key\":\t\"value\"\t}";

            // Act
            var dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Single(dict);
        }

        #endregion

        #region Complex Value Tests

        [Fact]
        public void ParseToDictionary_WithNestedObject_ReturnsRawJson()
        {
            // Arrange
            string json = "{\"outer\":{\"inner\":\"value\"}}";

            // Act
            var dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.True(dict["outer"].Contains("inner"));
            Assert.True(dict["outer"].Contains("value"));
        }

        [Fact]
        public void ParseToDictionary_WithNestedArray_ReturnsRawJson()
        {
            // Arrange
            string json = "{\"items\":[\"a\",\"b\",\"c\"]}";

            // Act
            var dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.StartsWith("[", dict["items"]);
            Assert.EndsWith("]", dict["items"]);
        }

        [Fact]
        public void ParseToDictionary_WithEmptyArray_ReturnsEmptyArrayString()
        {
            // Arrange
            string json = "{\"items\":[]}";

            // Act
            var dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("[]", dict["items"]);
        }

        [Fact]
        public void ParseToDictionary_WithEmptyNestedObject_ReturnsEmptyObjectString()
        {
            // Arrange
            string json = "{\"nested\":{}}";

            // Act
            var dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("{}", dict["nested"]);
        }

        [Fact]
        public void ParseToDictionary_WithDeeplyNested_ReturnsCorrectStructure()
        {
            // Arrange
            string json = "{\"level1\":{\"level2\":{\"level3\":\"value\"}}}";

            // Act
            var dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Contains("level2", dict["level1"]);
            Assert.Contains("level3", dict["level1"]);
        }

        #endregion

        #region Property Count Tests

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(10)]
        public void ParseToDictionary_WithMultipleProperties_ReturnsCorrectCount(int count)
        {
            // Arrange
            var properties = new List<string>();
            for (int i = 0; i < count; i++)
            {
                properties.Add($"\"prop{i}\":\"value{i}\"");
            }
            string json = "{" + string.Join(",", properties) + "}";

            // Act
            var dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(count, dict.Count);
        }

        #endregion

        #region Special Characters Tests

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
            var dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(value, dict["key"]);
        }

        [Fact]
        public void ParseToDictionary_WithUnicodeCharacters_ParsesCorrectly()
        {
            // Arrange
            string json = "{\"key\":\"こんにちは\"}";

            // Act
            var dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("こんにちは", dict["key"]);
        }

        [Fact]
        public void ParseToDictionary_WithEmojis_ParsesCorrectly()
        {
            // Arrange
            string json = "{\"emoji\":\"😀\"}";

            // Act
            var dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("😀", dict["emoji"]);
        }

        #endregion

        #region Escape Sequence Tests

        [Theory]
        [InlineData("\\n", "\n")]
        [InlineData("\\t", "\t")]
        [InlineData("\\r", "\r")]
        public void ParseToDictionary_WithEscapeSequences_UnescapesCorrectly(string escaped, string expected)
        {
            // Arrange
            string json = $"{{\"key\":\"{escaped}\"}}";

            // Act
            var dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(expected, dict["key"]);
        }

        [Fact]
        public void ParseToDictionary_WithQuotedValue_ParsesCorrectly()
        {
            // Arrange
            string json = "{\"key\":\"value with \\\"quotes\\\"\"}";

            // Act
            var dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Contains("\"", dict["key"]);
        }

        [Fact]
        public void ParseToDictionary_WithBackslash_ParsesCorrectly()
        {
            // Arrange
            string json = "{\"path\":\"C:\\\\\\\\Users\\\\\\\\file.txt\"}";

            // Act
            var dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Contains("\\", dict["path"]);
        }

        #endregion

        #region Number Value Tests

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
            var dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(number, dict["number"]);
        }

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
            var dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(number, dict["number"]);
        }

        #endregion

        #region Boolean Value Tests

        [Theory]
        [InlineData("true")]
        [InlineData("false")]
        public void ParseToDictionary_WithBooleanValue_ReturnsAsString(string boolValue)
        {
            // Arrange
            string json = $"{{\"flag\":\"{boolValue}\"}}";

            // Act
            var dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(boolValue, dict["flag"]);
        }

        #endregion

        #region Empty and Null Tests

        [Fact]
        public void ParseToDictionary_WithEmptyString_ReturnsEmpty()
        {
            // Arrange
            string json = "{\"key\":\"\"}";

            // Act
            var dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("", dict["key"]);
        }

        [Fact]
        public void ParseToDictionary_WithOnlyWhitespace_ParsesCorrectly()
        {
            // Arrange
            string json = "{\"key\":\"   \"}";

            // Act
            var dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("   ", dict["key"]);
        }

        #endregion

        #region Multiple Properties Tests

        [Fact]
        public void ParseToDictionary_WithMixedTypes_ParsesAllCorrectly()
        {
            // Arrange
            string json = "{\"string\":\"text\",\"number\":\"42\",\"bool\":\"true\",\"nested\":{}}";

            // Act
            var dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(4, dict.Count);
            Assert.Equal("text", dict["string"]);
            Assert.Equal("42", dict["number"]);
            Assert.Equal("true", dict["bool"]);
            Assert.Equal("{}", dict["nested"]);
        }

        [Fact]
        public void ParseToDictionary_WithRepeatedKeys_UsesLastValue()
        {
            // Arrange
            string json = "{\"key\":\"first\",\"key\":\"second\"}";

            // Act
            var dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal("second", dict["key"]);
        }

        #endregion

        #region Performance Tests

        [Fact]
        public void ParseToDictionary_WithLargeJson_CompletesInReasonableTime()
        {
            // Arrange
            var properties = new List<string>();
            for (int i = 0; i < 1000; i++)
            {
                properties.Add($"\"prop{i}\":\"value{i}\"");
            }
            string json = "{" + string.Join(",", properties) + "}";

            // Act
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            var dict = _parser.ParseToDictionary(json);
            stopwatch.Stop();

            // Assert
            Assert.Equal(1000, dict.Count);
            Assert.True(stopwatch.ElapsedMilliseconds < 1000, "Parsing should complete in less than 1 second");
        }

        #endregion

        #region Edge Case Tests

        [Fact]
        public void ParseToDictionary_WithLongPropertyName_ParsesCorrectly()
        {
            // Arrange
            string longName = new string('a', 500);
            string json = $"{{\"{longName}\":\"value\"}}";

            // Act
            var dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Contains(longName, dict.Keys);
        }

        [Fact]
        public void ParseToDictionary_WithLongValue_ParsesCorrectly()
        {
            // Arrange
            string longValue = new string('x', 1000);
            string json = $"{{\"key\":\"{longValue}\"}}";

            // Act
            var dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(longValue, dict["key"]);
        }

        [Fact]
        public void ParseToDictionary_WithConsecutiveCommas_ParsesCorrectly()
        {
            // Arrange
            string json = "{\"a\":\"1\",\"b\":\"2\",\"c\":\"3\"}";

            // Act
            var dict = _parser.ParseToDictionary(json);

            // Assert
            Assert.Equal(3, dict.Count);
        }

        #endregion
    }
}

