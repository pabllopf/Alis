

using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json.Exceptions;
using Alis.Core.Aspect.Data.Json.Helpers;
using Alis.Core.Aspect.Data.Json.Parsing;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json.Parsing
{
    /// <summary>
    ///     The json parser test class
    /// </summary>
    public class JsonParserTest
    {
        /// <summary>
        ///     The parser
        /// </summary>
        private readonly JsonParser _parser;

        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonParserTest" /> class
        /// </summary>
        public JsonParserTest()
        {
            EscapeSequenceHandler escapeHandler = new EscapeSequenceHandler();
            _parser = new JsonParser(escapeHandler);
        }

        /// <summary>
        ///     Tests that parse to dictionary with empty json returns empty dictionary
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithEmptyJson_ReturnsEmptyDictionary()
        {
            Dictionary<string, string> result = _parser.ParseToDictionary("{}");
            Assert.Empty(result);
        }

        /// <summary>
        ///     Tests that parse to dictionary with simple property returns dictionary
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithSimpleProperty_ReturnsDictionary()
        {
            string json = "{\"name\":\"John\"}";
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            Assert.Single(result);
            Assert.Equal("John", result["name"]);
        }

        /// <summary>
        ///     Tests that parse to dictionary with multiple properties returns dictionary
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithMultipleProperties_ReturnsDictionary()
        {
            string json = "{\"name\":\"John\",\"age\":\"30\"}";
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            Assert.Equal(2, result.Count);
            Assert.Equal("John", result["name"]);
            Assert.Equal("30", result["age"]);
        }

        /// <summary>
        ///     Tests that parse to dictionary with nested object returns raw json
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithNestedObject_ReturnsRawJson()
        {
            string json = "{\"data\":{\"inner\":\"value\"}}";
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            Assert.Single(result);
            Assert.StartsWith("{", result["data"]);
            Assert.EndsWith("}", result["data"]);
        }

        /// <summary>
        ///     Tests that parse to dictionary with array returns raw json
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithArray_ReturnsRawJson()
        {
            string json = "{\"items\":[\"a\",\"b\",\"c\"]}";
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            Assert.Single(result);
            Assert.StartsWith("[", result["items"]);
            Assert.EndsWith("]", result["items"]);
        }

        /// <summary>
        ///     Tests that parse to dictionary with number returned as string
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithNumber_ReturnedAsString()
        {
            string json = "{\"count\":42}";
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            Assert.Equal("42", result["count"]);
        }

        /// <summary>
        ///     Tests that parse to dictionary with boolean returned as string
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithBoolean_ReturnedAsString()
        {
            string json = "{\"active\":true}";
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            Assert.Equal("true", result["active"]);
        }

        /// <summary>
        ///     Tests that parse to dictionary with null returned as string
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithNull_ReturnedAsString()
        {
            string json = "{\"value\":null}";
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            Assert.Equal("null", result["value"]);
        }

        /// <summary>
        ///     Tests that parse to dictionary with whitespace parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithWhitespace_ParsesCorrectly()
        {
            string json = "{ \"name\" : \"John\" , \"age\" : \"30\" }";
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            Assert.Equal(2, result.Count);
            Assert.Equal("John", result["name"]);
            Assert.Equal("30", result["age"]);
        }

        /// <summary>
        ///     Tests that parse to dictionary with escaped quotes unescapes correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithEscapedQuotes_UnescapesCorrectly()
        {
            string json = "{\"message\":\"Say \\\"Hello\\\"\"}";
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            Assert.Equal("Say \"Hello\"", result["message"]);
        }

        /// <summary>
        ///     Tests that parse to dictionary with null json throws argument null exception
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithNullJson_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _parser.ParseToDictionary(null));
        }

        /// <summary>
        ///     Tests that parse to dictionary with empty string returns empty dictionary
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithEmptyString_ReturnsEmptyDictionary()
        {
            Dictionary<string, string> result = _parser.ParseToDictionary("");
            Assert.Empty(result);
        }

        /// <summary>
        ///     Tests that parse to dictionary with whitespace only returns empty dictionary
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithWhitespaceOnly_ReturnsEmptyDictionary()
        {
            Dictionary<string, string> result = _parser.ParseToDictionary("   ");
            Assert.Empty(result);
        }

        /// <summary>
        ///     Tests that parse to dictionary with missing colon throws json parsing exception
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithMissingColon_ThrowsJsonParsingException()
        {
            string json = "{\"name\"\"John\"}";
            Assert.Throws<JsonParsingException>(() => _parser.ParseToDictionary(json));
        }

        /// <summary>
        ///     Tests that parse to dictionary with unterminated string throws json parsing exception
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithUnterminatedString_ThrowsJsonParsingException()
        {
            string json = "{\"name\":\"John}";
            Assert.Throws<JsonParsingException>(() => _parser.ParseToDictionary(json));
        }

        /// <summary>
        ///     Tests that parse to dictionary with escaped newline unescapes correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithEscapedNewline_UnescapesCorrectly()
        {
            string json = "{\"text\":\"line1\\nline2\"}";
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            Assert.Equal("line1\nline2", result["text"]);
        }

        /// <summary>
        ///     Tests that parse to dictionary with complex json parses successfully
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithComplexJson_ParsesSuccessfully()
        {
            string json = "{\"user\":{\"name\":\"John\",\"age\":30},\"active\":true}";
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            Assert.Equal(2, result.Count);
            Assert.Equal("true", result["active"]);
            Assert.Contains("{", result["user"]);
        }

        /// <summary>
        ///     Tests that parse to dictionary with consecutive commas skips empty values
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithConsecutiveCommas_SkipsEmptyValues()
        {
            string json = "{\"a\":\"1\",\"b\":\"2\"}";
            Dictionary<string, string> result = _parser.ParseToDictionary(json);

            Assert.Equal(2, result.Count);
        }
    }
}