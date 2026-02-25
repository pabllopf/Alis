// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: JsonParserTest.cs
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
using Alis.Core.Aspect.Data.Json.Exceptions;
using Alis.Core.Aspect.Data.Json.Helpers;
using Alis.Core.Aspect.Data.Json.Parsing;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json.Parsing
{
    /// <summary>
    /// The json parser test class
    /// </summary>
    public class JsonParserTest
    {
        /// <summary>
        /// The parser
        /// </summary>
        private readonly JsonParser _parser;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonParserTest"/> class
        /// </summary>
        public JsonParserTest()
        {
            var escapeHandler = new EscapeSequenceHandler();
            _parser = new JsonParser(escapeHandler);
        }

        /// <summary>
        /// Tests that parse to dictionary with empty json returns empty dictionary
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithEmptyJson_ReturnsEmptyDictionary()
        {
            var result = _parser.ParseToDictionary("{}");
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that parse to dictionary with simple property returns dictionary
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithSimpleProperty_ReturnsDictionary()
        {
            string json = "{\"name\":\"John\"}";
            var result = _parser.ParseToDictionary(json);
            
            Assert.Single(result);
            Assert.Equal("John", result["name"]);
        }

        /// <summary>
        /// Tests that parse to dictionary with multiple properties returns dictionary
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithMultipleProperties_ReturnsDictionary()
        {
            string json = "{\"name\":\"John\",\"age\":\"30\"}";
            var result = _parser.ParseToDictionary(json);
            
            Assert.Equal(2, result.Count);
            Assert.Equal("John", result["name"]);
            Assert.Equal("30", result["age"]);
        }

        /// <summary>
        /// Tests that parse to dictionary with nested object returns raw json
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithNestedObject_ReturnsRawJson()
        {
            string json = "{\"data\":{\"inner\":\"value\"}}";
            var result = _parser.ParseToDictionary(json);
            
            Assert.Single(result);
            Assert.StartsWith("{", result["data"]);
            Assert.EndsWith("}", result["data"]);
        }

        /// <summary>
        /// Tests that parse to dictionary with array returns raw json
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithArray_ReturnsRawJson()
        {
            string json = "{\"items\":[\"a\",\"b\",\"c\"]}";
            var result = _parser.ParseToDictionary(json);
            
            Assert.Single(result);
            Assert.StartsWith("[", result["items"]);
            Assert.EndsWith("]", result["items"]);
        }

        /// <summary>
        /// Tests that parse to dictionary with number returned as string
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithNumber_ReturnedAsString()
        {
            string json = "{\"count\":42}";
            var result = _parser.ParseToDictionary(json);
            
            Assert.Equal("42", result["count"]);
        }

        /// <summary>
        /// Tests that parse to dictionary with boolean returned as string
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithBoolean_ReturnedAsString()
        {
            string json = "{\"active\":true}";
            var result = _parser.ParseToDictionary(json);
            
            Assert.Equal("true", result["active"]);
        }

        /// <summary>
        /// Tests that parse to dictionary with null returned as string
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithNull_ReturnedAsString()
        {
            string json = "{\"value\":null}";
            var result = _parser.ParseToDictionary(json);
            
            Assert.Equal("null", result["value"]);
        }

        /// <summary>
        /// Tests that parse to dictionary with whitespace parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithWhitespace_ParsesCorrectly()
        {
            string json = "{ \"name\" : \"John\" , \"age\" : \"30\" }";
            var result = _parser.ParseToDictionary(json);
            
            Assert.Equal(2, result.Count);
            Assert.Equal("John", result["name"]);
            Assert.Equal("30", result["age"]);
        }

        /// <summary>
        /// Tests that parse to dictionary with escaped quotes unescapes correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithEscapedQuotes_UnescapesCorrectly()
        {
            string json = "{\"message\":\"Say \\\"Hello\\\"\"}";
            var result = _parser.ParseToDictionary(json);
            
            Assert.Equal("Say \"Hello\"", result["message"]);
        }

        /// <summary>
        /// Tests that parse to dictionary with null json throws argument null exception
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithNullJson_ThrowsArgumentNullException()
        {
            Assert.Throws<System.ArgumentNullException>(() => _parser.ParseToDictionary(null));
        }

        /// <summary>
        /// Tests that parse to dictionary with empty string returns empty dictionary
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithEmptyString_ReturnsEmptyDictionary()
        {
            var result = _parser.ParseToDictionary("");
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that parse to dictionary with whitespace only returns empty dictionary
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithWhitespaceOnly_ReturnsEmptyDictionary()
        {
            var result = _parser.ParseToDictionary("   ");
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that parse to dictionary with missing colon throws json parsing exception
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithMissingColon_ThrowsJsonParsingException()
        {
            string json = "{\"name\"\"John\"}";
            Assert.Throws<JsonParsingException>(() => _parser.ParseToDictionary(json));
        }

        /// <summary>
        /// Tests that parse to dictionary with unterminated string throws json parsing exception
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithUnterminatedString_ThrowsJsonParsingException()
        {
            string json = "{\"name\":\"John}";
            Assert.Throws<JsonParsingException>(() => _parser.ParseToDictionary(json));
        }

        /// <summary>
        /// Tests that parse to dictionary with escaped newline unescapes correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithEscapedNewline_UnescapesCorrectly()
        {
            string json = "{\"text\":\"line1\\nline2\"}";
            var result = _parser.ParseToDictionary(json);
            
            Assert.Equal("line1\nline2", result["text"]);
        }

        /// <summary>
        /// Tests that parse to dictionary with complex json parses successfully
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithComplexJson_ParsesSuccessfully()
        {
            string json = "{\"user\":{\"name\":\"John\",\"age\":30},\"active\":true}";
            var result = _parser.ParseToDictionary(json);
            
            Assert.Equal(2, result.Count);
            Assert.Equal("true", result["active"]);
            Assert.Contains("{", result["user"]);
        }

        /// <summary>
        /// Tests that parse to dictionary with consecutive commas skips empty values
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithConsecutiveCommas_SkipsEmptyValues()
        {
            string json = "{\"a\":\"1\",\"b\":\"2\"}";
            var result = _parser.ParseToDictionary(json);
            
            Assert.Equal(2, result.Count);
        }
    }
}

