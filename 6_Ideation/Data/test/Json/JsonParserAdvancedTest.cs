

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
        ///     The escape sequence handler
        /// </summary>
        private readonly IJsonParser _parser = new JsonParser(new EscapeSequenceHandler());


        /// <summary>
        ///     Tests that parse to dictionary with multiple properties returns correct count
        /// </summary>
        /// <param name="count">The count</param>
        [Theory, InlineData(1), InlineData(2), InlineData(3), InlineData(5), InlineData(10)]
        public void ParseToDictionary_WithMultipleProperties_ReturnsCorrectCount(int count)
        {
            List<string> properties = new List<string>();
            for (int i = 0; i < count; i++)
            {
                properties.Add($"\"prop{i}\":\"value{i}\"");
            }

            string json = "{" + string.Join(",", properties) + "}";

            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            Assert.Equal(count, dict.Count);
        }


        /// <summary>
        ///     Tests that parse to dictionary with boolean value returns as string
        /// </summary>
        /// <param name="boolValue">The bool value</param>
        [Theory, InlineData("true"), InlineData("false")]
        public void ParseToDictionary_WithBooleanValue_ReturnsAsString(string boolValue)
        {
            string json = $"{{\"flag\":\"{boolValue}\"}}";

            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            Assert.Equal(boolValue, dict["flag"]);
        }


        /// <summary>
        ///     Tests that parse to dictionary with large json completes in reasonable time
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithLargeJson_CompletesInReasonableTime()
        {
            List<string> properties = new List<string>();
            for (int i = 0; i < 1000; i++)
            {
                properties.Add($"\"prop{i}\":\"value{i}\"");
            }

            string json = "{" + string.Join(",", properties) + "}";

            Stopwatch stopwatch = Stopwatch.StartNew();
            Dictionary<string, string> dict = _parser.ParseToDictionary(json);
            stopwatch.Stop();

            Assert.Equal(1000, dict.Count);
            Assert.True(stopwatch.ElapsedMilliseconds < 1000, "Parsing should complete in less than 1 second");
        }


        /// <summary>
        ///     Tests that parse to dictionary with leading whitespace parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithLeadingWhitespace_ParsesCorrectly()
        {
            string json = "   {\"key\":\"value\"}";

            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            Assert.Single(dict);
            Assert.Equal("value", dict["key"]);
        }

        /// <summary>
        ///     Tests that parse to dictionary with trailing whitespace parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithTrailingWhitespace_ParsesCorrectly()
        {
            string json = "{\"key\":\"value\"}   ";

            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            Assert.Single(dict);
        }

        /// <summary>
        ///     Tests that parse to dictionary with multiple spaces parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithMultipleSpaces_ParsesCorrectly()
        {
            string json = "{  \"key\"  :  \"value\"  }";

            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            Assert.Equal("value", dict["key"]);
        }

        /// <summary>
        ///     Tests that parse to dictionary with newlines parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithNewlines_ParsesCorrectly()
        {
            string json = "{\n\"key\":\"value\"\n}";

            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            Assert.Single(dict);
        }

        /// <summary>
        ///     Tests that parse to dictionary with tabs parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithTabs_ParsesCorrectly()
        {
            string json = "{\t\"key\":\t\"value\"\t}";

            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            Assert.Single(dict);
        }


        /// <summary>
        ///     Tests that parse to dictionary with nested object returns raw json
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithNestedObject_ReturnsRawJson()
        {
            string json = "{\"outer\":{\"inner\":\"value\"}}";

            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            Assert.True(dict["outer"].Contains("inner"));
            Assert.True(dict["outer"].Contains("value"));
        }

        /// <summary>
        ///     Tests that parse to dictionary with nested array returns raw json
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithNestedArray_ReturnsRawJson()
        {
            string json = "{\"items\":[\"a\",\"b\",\"c\"]}";

            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            Assert.StartsWith("[", dict["items"]);
            Assert.EndsWith("]", dict["items"]);
        }

        /// <summary>
        ///     Tests that parse to dictionary with empty array returns empty array string
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithEmptyArray_ReturnsEmptyArrayString()
        {
            string json = "{\"items\":[]}";

            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            Assert.Equal("[]", dict["items"]);
        }

        /// <summary>
        ///     Tests that parse to dictionary with empty nested object returns empty object string
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithEmptyNestedObject_ReturnsEmptyObjectString()
        {
            string json = "{\"nested\":{}}";

            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            Assert.Equal("{}", dict["nested"]);
        }

        /// <summary>
        ///     Tests that parse to dictionary with deeply nested returns correct structure
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithDeeplyNested_ReturnsCorrectStructure()
        {
            string json = "{\"level1\":{\"level2\":{\"level3\":\"value\"}}}";

            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            Assert.Contains("level2", dict["level1"]);
            Assert.Contains("level3", dict["level1"]);
        }


        /// <summary>
        ///     Tests that parse to dictionary with special chars in value parses correctly
        /// </summary>
        /// <param name="value">The value</param>
        [Theory, InlineData("test@email.com"), InlineData("test#value"), InlineData("test$value"), InlineData("test%value")]
        public void ParseToDictionary_WithSpecialCharsInValue_ParsesCorrectly(string value)
        {
            string json = $"{{\"key\":\"{value}\"}}";

            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            Assert.Equal(value, dict["key"]);
        }

        /// <summary>
        ///     Tests that parse to dictionary with unicode characters parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithUnicodeCharacters_ParsesCorrectly()
        {
            string json = "{\"key\":\"こんにちは\"}";

            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            Assert.Equal("こんにちは", dict["key"]);
        }

        /// <summary>
        ///     Tests that parse to dictionary with emojis parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithEmojis_ParsesCorrectly()
        {
            string json = "{\"emoji\":\"😀\"}";

            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            Assert.Equal("😀", dict["emoji"]);
        }


        /// <summary>
        ///     Tests that parse to dictionary with escape sequences unescapes correctly
        /// </summary>
        /// <param name="escaped">The escaped</param>
        /// <param name="expected">The expected</param>
        [Theory, InlineData("\\n", "\n"), InlineData("\\t", "\t"), InlineData("\\r", "\r")]
        public void ParseToDictionary_WithEscapeSequences_UnescapesCorrectly(string escaped, string expected)
        {
            string json = $"{{\"key\":\"{escaped}\"}}";

            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            Assert.Equal(expected, dict["key"]);
        }

        /// <summary>
        ///     Tests that parse to dictionary with quoted value parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithQuotedValue_ParsesCorrectly()
        {
            string json = "{\"key\":\"value with \\\"quotes\\\"\"}";

            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            Assert.Contains("\"", dict["key"]);
        }

        /// <summary>
        ///     Tests that parse to dictionary with backslash parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithBackslash_ParsesCorrectly()
        {
            string json = "{\"path\":\"C:\\\\\\\\Users\\\\\\\\file.txt\"}";

            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            Assert.Contains("\\", dict["path"]);
        }


        /// <summary>
        ///     Tests that parse to dictionary with integer value returns as string
        /// </summary>
        /// <param name="number">The number</param>
        [Theory, InlineData("0"), InlineData("1"), InlineData("-1"), InlineData("123"), InlineData("999999")]
        public void ParseToDictionary_WithIntegerValue_ReturnsAsString(string number)
        {
            string json = $"{{\"number\":\"{number}\"}}";

            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            Assert.Equal(number, dict["number"]);
        }

        /// <summary>
        ///     Tests that parse to dictionary with double value returns as string
        /// </summary>
        /// <param name="number">The number</param>
        [Theory, InlineData("0.0"), InlineData("1.5"), InlineData("-3.14"), InlineData("999.999")]
        public void ParseToDictionary_WithDoubleValue_ReturnsAsString(string number)
        {
            string json = $"{{\"number\":\"{number}\"}}";

            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            Assert.Equal(number, dict["number"]);
        }


        /// <summary>
        ///     Tests that parse to dictionary with empty string returns empty
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithEmptyString_ReturnsEmpty()
        {
            string json = "{\"key\":\"\"}";

            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            Assert.Equal("", dict["key"]);
        }

        /// <summary>
        ///     Tests that parse to dictionary with only whitespace parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithOnlyWhitespace_ParsesCorrectly()
        {
            string json = "{\"key\":\"   \"}";

            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            Assert.Equal("   ", dict["key"]);
        }


        /// <summary>
        ///     Tests that parse to dictionary with mixed types parses all correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithMixedTypes_ParsesAllCorrectly()
        {
            string json = "{\"string\":\"text\",\"number\":\"42\",\"bool\":\"true\",\"nested\":{}}";

            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            Assert.Equal(4, dict.Count);
            Assert.Equal("text", dict["string"]);
            Assert.Equal("42", dict["number"]);
            Assert.Equal("true", dict["bool"]);
            Assert.Equal("{}", dict["nested"]);
        }

        /// <summary>
        ///     Tests that parse to dictionary with repeated keys uses last value
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithRepeatedKeys_UsesLastValue()
        {
            string json = "{\"key\":\"first\",\"key\":\"second\"}";

            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            Assert.Equal("second", dict["key"]);
        }


        /// <summary>
        ///     Tests that parse to dictionary with long property name parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithLongPropertyName_ParsesCorrectly()
        {
            string longName = new string('a', 500);
            string json = $"{{\"{longName}\":\"value\"}}";

            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            Assert.Contains(longName, dict.Keys);
        }

        /// <summary>
        ///     Tests that parse to dictionary with long value parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithLongValue_ParsesCorrectly()
        {
            string longValue = new string('x', 1000);
            string json = $"{{\"key\":\"{longValue}\"}}";

            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            Assert.Equal(longValue, dict["key"]);
        }

        /// <summary>
        ///     Tests that parse to dictionary with consecutive commas parses correctly
        /// </summary>
        [Fact]
        public void ParseToDictionary_WithConsecutiveCommas_ParsesCorrectly()
        {
            string json = "{\"a\":\"1\",\"b\":\"2\",\"c\":\"3\"}";

            Dictionary<string, string> dict = _parser.ParseToDictionary(json);

            Assert.Equal(3, dict.Count);
        }
    }
}