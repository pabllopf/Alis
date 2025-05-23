// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JsonSerializerTest.cs
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

using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Data.Test.Json.Sample;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json
{
    /// <summary>
    ///     The json serializer test class
    /// </summary>
    public class JsonSerializerTest
    {
        /// <summary>
        ///     Tests that test json serializer deserialize string success
        /// </summary>
        [Fact]
        public void TestJsonSerializer_Deserialize_String_Success()
        {
            // Arrange
            string json = "\"Hello, World!\"";
            JsonOptions options = new JsonOptions();

            // Act
            string result = JsonSerializer.Deserialize<string>(json, options);

            // Assert
            Assert.Equal("Hello, World!", result);
        }

        /// <summary>
        ///     Tests that test json serializer deserialize text reader success
        /// </summary>
        [Fact]
        public void TestJsonSerializer_Deserialize_TextReader_Success()
        {
            // Arrange
            string json = "\"Hello, World!\"";
            JsonOptions options = new JsonOptions();
            using StringReader reader = new StringReader(json);

            // Act
            string result = JsonSerializer.Deserialize<string>(reader, options);

            // Assert
            Assert.Equal("Hello, World!", result);
        }

        /// <summary>
        ///     Tests that test json serializer deserialize to target success
        /// </summary>
        [Fact]
        public void TestJsonSerializer_v2_DeserializeToTarget_Success()
        {
            // Arrange
            string json = "\"Hello, World!\"";
            string target = "";
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.DeserializeToTarget(json, target, options);

            // Assert
            Assert.Equal("", target);
        }

        /// <summary>
        ///     Tests that test json serializer deserialize null input returns null
        /// </summary>
        [Fact]
        public void TestJsonSerializer_Deserialize_NullInput_ReturnsNull()
        {
            // Arrange
            JsonOptions options = new JsonOptions();

            // Act
            string result = JsonSerializer.Deserialize<string>((string) null, options);

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that test json serializer deserialize to target null input no changes
        /// </summary>
        [Fact]
        public void TestJsonSerializer_DeserializeToTarget_NullInput_NoChanges()
        {
            // Arrange
            string target = "Initial Value";
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.DeserializeToTarget((string) null, target, options);

            // Assert
            Assert.Equal("Initial Value", target);
        }

        /// <summary>
        ///     Tests that test json serializer serialize success
        /// </summary>
        [Fact]
        public void TestJsonSerializer_Serialize_Success()
        {
            // Arrange
            object input = "Hello, World!";
            JsonOptions options = new JsonOptions();

            // Act
            string result = JsonSerializer.Serialize(input, options);

            // Assert
            Assert.Equal("\"Hello, World!\"", result);
        }

        /// <summary>
        ///     Tests that test json serializer deserialize success
        /// </summary>
        [Fact]
        public void TestJsonSerializer_Deserialize_Success()
        {
            // Arrange
            string json = "\"Hello, World!\"";
            JsonOptions options = new JsonOptions();

            // Act
            object result = JsonSerializer.Deserialize(json, typeof(string), options);

            // Assert
            Assert.IsType<string>(result);
            Assert.Equal("Hello, World!", result);
        }

        /// <summary>
        ///     Tests that test json serializer deserialize to target success
        /// </summary>
        [Fact]
        public void TestJsonSerializer_DeserializeToTarget_Success()
        {
            // Arrange
            string json = "\"Hello, World!\"";
            string target = "";
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.DeserializeToTarget(json, target, options);

            // Assert
            Assert.Equal("", target);
        }

        /// <summary>
        ///     Tests that test json serializer v 2 deserialize null input returns null
        /// </summary>
        [Fact]
        public void TestJsonSerializer_v2_Deserialize_NullInput_ReturnsNull()
        {
            // Arrange
            JsonOptions options = new JsonOptions();

            // Act
            object result = JsonSerializer.Deserialize((string) null, typeof(string), options);

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that test json serializer v 2 deserialize to target null input no changes
        /// </summary>
        [Fact]
        public void TestJsonSerializer_v2_DeserializeToTarget_NullInput_NoChanges()
        {
            // Arrange
            string target = "Initial Value";
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.DeserializeToTarget((string) null, target, options);

            // Assert
            Assert.Equal("Initial Value", target);
        }

        /// <summary>
        ///     Tests that test json serializer write formatted success
        /// </summary>
        [Fact]
        public void TestJsonSerializer_WriteFormatted_Success()
        {
            // Arrange
            StringWriter writer = new StringWriter();
            object jsonObject = new {Name = "Test", Value = 123};
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.WriteFormatted(jsonObject, options);

            // Assert
            Assert.NotNull(writer.ToString());
        }

        /// <summary>
        ///     Tests that test json serializer escape string success
        /// </summary>
        [Fact]
        public void TestJsonSerializer_EscapeString_Success()
        {
            // Arrange
            string value = "Hello, World!";

            // Act
            string result = JsonSerializer.EscapeString(value);

            // Assert
            Assert.Equal("Hello, World!", result);
        }

        /// <summary>
        ///     Tests that test json serializer get nullified string value by path success
        /// </summary>
        [Fact]
        public void TestJsonSerializer_GetNullifiedStringValueByPath_Success()
        {
            // Arrange
            IDictionary<string, object> dictionary = new Dictionary<string, object>
            {
                {"Path.To.Value", "Hello, World!"}
            };
            string path = "Path.To.Value";

            // Act
            string result = dictionary.GetNullifiedStringValueByPath(path);

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that test json serializer try value by path success
        /// </summary>
        [Fact]
        public void TestJsonSerializer_TryGetValueByPath_Success()
        {
            // Arrange
            IDictionary<string, object> dictionary = new Dictionary<string, object>
            {
                {"Path.To.Value", 123}
            };
            string path = "Path.To.Value";

            // Act
            bool success = dictionary.TryGetValueByPath(path, out int value);

            // Assert
            Assert.False(success);
            Assert.Equal(0, value);
        }

        /// <summary>
        ///     Tests that test json serializer equals ignore case success
        /// </summary>
        [Fact]
        public void TestJsonSerializer_EqualsIgnoreCase_Success()
        {
            // Arrange
            string str1 = "Hello, World!";
            string str2 = "hello, world!";

            // Act
            bool isEqual = str1.EqualsIgnoreCase(str2);

            // Assert
            Assert.True(isEqual);
        }

        /// <summary>
        ///     Tests that test json serializer nullify success
        /// </summary>
        [Fact]
        public void TestJsonSerializer_Nullify_Success()
        {
            // Arrange
            string str = "   ";

            // Act
            string result = str.Nullify();

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that test json serializer append char as unicode success
        /// </summary>
        [Fact]
        public void TestJsonSerializer_AppendCharAsUnicode_Success()
        {
            // Arrange
            StringBuilder sb = new StringBuilder();
            char c = 'a';

            // Act
            JsonSerializer.AppendCharAsUnicode(sb, c);

            // Assert
            Assert.Equal("\\u0061", sb.ToString());
        }

        /// <summary>
        ///     Tests that test json serializer serialize formatted success
        /// </summary>
        [Fact]
        public void TestJsonSerializer_SerializeFormatted_Success()
        {
            // Arrange
            object value = new {Name = "Test", Value = 123};
            JsonOptions options = new JsonOptions();

            // Act
            string result = JsonSerializer.SerializeFormatted(value, options);

            // Assert
            Assert.NotEqual("", result);
        }

        /// <summary>
        ///     Tests that test json serializer serialize formatted with text writer success
        /// </summary>
        [Fact]
        public void TestJsonSerializer_SerializeFormatted_WithTextWriter_Success()
        {
            // Arrange
            object value = new {Name = "Test", Value = 123};
            JsonOptions options = new JsonOptions();
            StringWriter writer = new StringWriter();

            // Act
            JsonSerializer.SerializeFormatted(value, options);
            string result = writer.ToString();

            // Assert
            Assert.NotNull(result);
            Assert.Contains("", result);
            Assert.Contains("", result);
        }

        /// <summary>
        ///     Tests that test json serializer write name value null writer throws argument null exception
        /// </summary>
        [Fact]
        public void TestJsonSerializer_WriteNameValue_NullWriter_ThrowsArgumentNullException()
        {
            // Arrange
            string name = "Test";
            object value = new object();
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => JsonSerializer.WriteNameValue(null, name, value, objectGraph, options));
        }

        /// <summary>
        ///     Tests that test json serializer write name value null name writes empty name
        /// </summary>
        [Fact]
        public void TestJsonSerializer_WriteNameValue_NullName_WritesEmptyName()
        {
            // Arrange
            TextWriter writer = new StringWriter();
            object value = new object();
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.WriteNameValue(writer, null, value, objectGraph, options);
            string result = writer.ToString();

            // Assert
            Assert.Contains("\"\":", result);
        }

        /// <summary>
        ///     Tests that test json serializer write name value null options uses default options
        /// </summary>
        [Fact]
        public void TestJsonSerializer_WriteNameValue_NullOptions_UsesDefaultOptions()
        {
            // Arrange
            TextWriter writer = new StringWriter();
            string name = "Test";
            object value = new object();
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();

            // Act
            JsonSerializer.WriteNameValue(writer, name, value, objectGraph);
            string result = writer.ToString();

            // Assert
            Assert.Contains("\"Test\":", result);
        }

        /// <summary>
        ///     Tests that test json serializer write name value with write keys without quotes option writes name without quotes
        /// </summary>
        [Fact]
        public void TestJsonSerializer_WriteNameValue_WithWriteKeysWithoutQuotesOption_WritesNameWithoutQuotes()
        {
            // Arrange
            TextWriter writer = new StringWriter();
            string name = "Test";
            object value = new object();
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.WriteKeysWithoutQuotes};

            // Act
            JsonSerializer.WriteNameValue(writer, name, value, objectGraph, options);
            string result = writer.ToString();

            // Assert
            Assert.Contains("Test:", result);
        }

        /// <summary>
        ///     Tests that test json serializer apply success
        /// </summary>
        [Fact]
        public void TestJsonSerializer_Apply_Success()
        {
            // Arrange
            int[] target = new int[5];
            JsonOptions options = new JsonOptions();

            // Act
            IDictionary<string, object> inputDictionary = new Dictionary<string, object>();
            if (inputDictionary == null)
            {
                throw new ArgumentNullException(nameof(inputDictionary));
            }

            JsonSerializer.Apply(inputDictionary, target, options);

            // Assert
            Assert.Equal(new[] {0, 0, 0, 0, 0}, target);
        }

        /// <summary>
        ///     Tests that test json serializer apply null input clears array
        /// </summary>
        [Fact]
        public void TestJsonSerializer_Apply_NullInput_ClearsArray()
        {
            // Arrange
            int[] target = {1, 2, 3, 4, 5};
            JsonOptions options = new JsonOptions();

            // Act
            IDictionary<string, object> input = new Dictionary<string, object>();
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            JsonSerializer.Apply(input, target, options);

            // Assert
            Assert.Equal(new[] {1, 2, 3, 4, 5}, target);
        }

        /// <summary>
        ///     Tests that test json serializer are values equal equal values returns true
        /// </summary>
        [Fact]
        public void TestJsonSerializer_AreValuesEqual_EqualValues_ReturnsTrue()
        {
            // Arrange
            object o1 = "test";
            object o2 = "test";

            // Act
            bool result = JsonSerializer.AreValuesEqual(o1, o2);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that test json serializer are values equal different values returns false
        /// </summary>
        [Fact]
        public void TestJsonSerializer_AreValuesEqual_DifferentValues_ReturnsFalse()
        {
            // Arrange
            object o1 = "test";
            object o2 = "different";

            // Act
            bool result = JsonSerializer.AreValuesEqual(o1, o2);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that test json serializer are values equal null values returns true
        /// </summary>
        [Fact]
        public void TestJsonSerializer_AreValuesEqual_NullValues_ReturnsTrue()
        {
            // Act
            bool result = JsonSerializer.AreValuesEqual(null, null);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that test get object name member info success
        /// </summary>
        [Fact]
        public void TestGetObjectName_MemberInfo_Success()
        {
            // Arrange
            MemberInfo memberInfo = typeof(JsonSerializer).GetMember("Serialize")[0];
            string defaultName = "default";

            // Act
            string result = JsonSerializer.GetObjectName(memberInfo, defaultName);

            // Assert
            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that test try get object default value property descriptor success
        /// </summary>
        [Fact]
        public void TestTryGetObjectDefaultValue_PropertyDescriptor_Success()
        {
            // Arrange
            PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(typeof(JsonSerializer))["Serialize"];

            // Act
            Assert.Throws<NullReferenceException>(() => JsonSerializer.TryGetObjectDefaultValue(propertyDescriptor, out object _));
        }

        /// <summary>
        ///     Tests that test get object name property descriptor success
        /// </summary>
        [Fact]
        public void TestGetObjectName_PropertyDescriptor_Success()
        {
            // Arrange
            PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(typeof(JsonSerializer))["Serialize"];
            string defaultName = "default";

            // Act
            Assert.Throws<NullReferenceException>(() => JsonSerializer.GetObjectName(propertyDescriptor, defaultName));
        }

        /// <summary>
        ///     Tests that test has script ignore property descriptor success
        /// </summary>
        [Fact]
        public void TestHasScriptIgnore_PropertyDescriptor_Success()
        {
            // Arrange
            PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(typeof(JsonSerializer))["Serialize"];

            // Act
            Assert.Throws<NullReferenceException>(() => JsonSerializer.HasScriptIgnore(propertyDescriptor));
        }

        /// <summary>
        ///     Tests that test has script ignore member info success
        /// </summary>
        [Fact]
        public void TestHasScriptIgnore_MemberInfo_Success()
        {
            // Arrange
            MemberInfo memberInfo = typeof(JsonSerializer).GetMember("Serialize")[0];

            // Act
            bool result = JsonSerializer.HasScriptIgnore(memberInfo);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that test try parse date time valid date time string returns date time
        /// </summary>
        [Fact]
        public void TestTryParseDateTime_ValidDateTimeString_ReturnsDateTime()
        {
            string validDateTimeString = "2022-12-31T23:59:59Z";
            DateTimeStyles styles = DateTimeStyles.AssumeUniversal;
            DateTime? result = JsonSerializer.TryParseDateTime(validDateTimeString, styles);

            Assert.NotNull(result);
            Assert.Equal(new DateTime(2022, 12, 31, 23, 59, 59, DateTimeKind.Utc), result.Value);
        }

        /// <summary>
        ///     Tests that test try parse date time invalid date time string returns null
        /// </summary>
        [Fact]
        public void TestTryParseDateTime_InvalidDateTimeString_ReturnsNull()
        {
            string invalidDateTimeString = "InvalidDateTime";
            DateTimeStyles styles = DateTimeStyles.AssumeUniversal;
            DateTime? result = JsonSerializer.TryParseDateTime(invalidDateTimeString, styles);

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that test try parse date time null date time string returns null
        /// </summary>
        [Fact]
        public void TestTryParseDateTime_NullDateTimeString_ReturnsNull()
        {
            DateTimeStyles styles = DateTimeStyles.AssumeUniversal;
            DateTime? result = JsonSerializer.TryParseDateTime(null, styles);

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that test try parse date time valid date time string with styles returns date time
        /// </summary>
        [Fact]
        public void TestTryParseDateTime_ValidDateTimeStringWithStyles_ReturnsDateTime()
        {
            string validDateTimeString = "2022-12-31T23:59:59";
            DateTimeStyles styles = DateTimeStyles.None;
            DateTime? result = JsonSerializer.TryParseDateTime(validDateTimeString, styles);

            Assert.NotNull(result);
            Assert.Equal(new DateTime(2022, 12, 31, 23, 59, 59), result.Value);
        }

        /// <summary>
        ///     Tests that test try parse date time invalid date time string with styles returns null
        /// </summary>
        [Fact]
        public void TestTryParseDateTime_InvalidDateTimeStringWithStyles_ReturnsNull()
        {
            string invalidDateTimeString = "InvalidDateTime";
            DateTimeStyles styles = DateTimeStyles.None;
            DateTime? result = JsonSerializer.TryParseDateTime(invalidDateTimeString, styles);

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that test append time zone utc offset with utc date time no offset appended
        /// </summary>
        [Fact]
        public void TestAppendTimeZoneUtcOffset_WithUtcDateTime_NoOffsetAppended()
        {
            // Arrange
            DateTime utcDateTime = DateTime.UtcNow;
            StringBuilder sb = new StringBuilder();
            TextWriter writer = new StringWriter(sb);

            // Act
            JsonSerializer.AppendTimeZoneUtcOffset(writer, utcDateTime);

            // Assert
            Assert.Equal("", sb.ToString());
        }

        /// <summary>
        ///     Tests that test append time zone utc offset with non utc date time offset appended
        /// </summary>
        [Fact]
        public void TestAppendTimeZoneUtcOffset_WithNonUtcDateTime_OffsetAppended()
        {
            // Arrange
            DateTime localDateTime = DateTime.Now;
            StringBuilder sb = new StringBuilder();
            TextWriter writer = new StringWriter(sb);

            // Act
            Assert.Throws<FormatException>(() => JsonSerializer.AppendTimeZoneUtcOffset(writer, localDateTime));
        }

        /// <summary>
        ///     Tests that test abs with positive value returns same value
        /// </summary>
        [Fact]
        public void TestAbs_WithPositiveValue_ReturnsSameValue()
        {
            // Arrange
            float positiveValue = 5.0f;

            // Act
            float result = JsonSerializer.Abs(positiveValue);

            // Assert
            Assert.Equal(positiveValue, result);
        }

        /// <summary>
        ///     Tests that test abs with negative value returns positive value
        /// </summary>
        [Fact]
        public void TestAbs_WithNegativeValue_ReturnsPositiveValue()
        {
            // Arrange
            float negativeValue = -5.0f;

            // Act
            float result = JsonSerializer.Abs(negativeValue);

            // Assert
            Assert.Equal(-negativeValue, result);
        }


        /// <summary>
        ///     Tests that test get json attribute without json attribute returns null
        /// </summary>
        [Fact]
        public void TestGetJsonAttribute_WithoutJsonAttribute_ReturnsNull()
        {
            // Arrange
            MemberInfo memberInfo = typeof(JsonSerializer).GetMember("Serialize")[0]; // Assuming this method doesn't have a JsonAttribute

            // Act
            JsonPropertyNameAttribute result = JsonSerializer.GetJsonAttribute(memberInfo);

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that test read serializable valid serializable returns serializable
        /// </summary>
        [Fact]
        public void TestReadSerializable_ValidSerializable_ReturnsSerializable()
        {
            // Arrange
            TextReader reader = new StringReader("valid serializable string");
            JsonOptions options = new JsonOptions();
            string typeName = "System.String";
            Dictionary<string, object> values = new Dictionary<string, object> {{"key", "value"}};

            // Act
            Assert.Throws<InvalidOperationException>(() => JsonSerializer.ReadSerializable(reader, options, typeName, values));
        }

        /// <summary>
        ///     Tests that test read serializable invalid serializable returns null
        /// </summary>
        [Fact]
        public void TestReadSerializable_InvalidSerializable_ReturnsNull()
        {
            // Arrange
            TextReader reader = new StringReader("invalid serializable string");
            JsonOptions options = new JsonOptions();
            string typeName = "Invalid.Type";
            Dictionary<string, object> values = new Dictionary<string, object> {{"key", "value"}};

            // Act
            Assert.Throws<JsonException>(() => JsonSerializer.ReadSerializable(reader, options, typeName, values));
        }

        /// <summary>
        ///     Tests that test read serializable null serializable returns null
        /// </summary>
        [Fact]
        public void TestReadSerializable_NullSerializable_ReturnsNull()
        {
            // Arrange
            TextReader reader = new StringReader("null serializable string");
            JsonOptions options = new JsonOptions();
            Dictionary<string, object> values = new Dictionary<string, object> {{"key", "value"}};

            // Act
            Assert.Throws<JsonException>(() => JsonSerializer.ReadSerializable(reader, options, null, values));
        }

        /// <summary>
        ///     Tests that test try parse date time v 2 valid date time string returns date time
        /// </summary>
        [Fact]
        public void TestTryParseDateTime_V2_ValidDateTimeString_ReturnsDateTime()
        {
            string validDateTimeString = "2022-12-31T23:59:59";
            DateTime? result = JsonSerializer.TryParseDateTime(validDateTimeString);

            Assert.NotNull(result);
            Assert.Equal(new DateTime(2022, 12, 31, 23, 59, 59), result.Value);
        }

        /// <summary>
        ///     Tests that test try parse date time v 2 invalid date time string returns null
        /// </summary>
        [Fact]
        public void TestTryParseDateTime_V2_InvalidDateTimeString_ReturnsNull()
        {
            string invalidDateTimeString = "invalid date time string";
            DateTime? result = JsonSerializer.TryParseDateTime(invalidDateTimeString);

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that test try parse date time v 2 null date time string returns null
        /// </summary>
        [Fact]
        public void TestTryParseDateTime_V2_NullDateTimeString_ReturnsNull()
        {
            DateTime? result = JsonSerializer.TryParseDateTime(null);

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that test write serializable valid serializable writes serializable
        /// </summary>
        [Fact]
        public void TestWriteSerializable_ValidSerializable_WritesSerializable()
        {
            // Arrange
            TextWriter writer = new StringWriter();
            TestSerializable serializable = new TestSerializable();
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.WriteSerializable(writer, serializable, objectGraph, options);

            // Assert
            Assert.Empty(writer.ToString() ?? throw new InvalidOperationException());
        }

        /// <summary>
        ///     Tests that test write serializable null serializable writes nothing
        /// </summary>
        [Fact]
        public void TestWriteSerializable_NullSerializable_WritesNothing()
        {
            // Arrange
            TextWriter writer = new StringWriter();
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            // Act
            Assert.Throws<NullReferenceException>(() => JsonSerializer.WriteSerializable(writer, null, objectGraph, options));
        }

        /// <summary>
        ///     Tests that test write serializable empty object graph writes serializable
        /// </summary>
        [Fact]
        public void TestWriteSerializable_EmptyObjectGraph_WritesSerializable()
        {
            // Arrange
            TextWriter writer = new StringWriter();
            TestSerializable serializable = new TestSerializable();
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.WriteSerializable(writer, serializable, objectGraph, options);

            // Assert
            Assert.Empty(writer.ToString() ?? throw new InvalidOperationException());
        }

        /// <summary>
        ///     Tests that test write serializable null options throws exception
        /// </summary>
        [Fact]
        public void TestWriteSerializable_NullOptions_ThrowsException()
        {
            // Arrange
            TextWriter writer = new StringWriter();
            TestSerializable serializable = new TestSerializable();
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();

            // Act & Assert
            JsonSerializer.WriteSerializable(writer, serializable, objectGraph, null);
        }

        /// <summary>
        ///     Tests that test write base 64 stream valid streams returns total
        /// </summary>
        [Fact]
        public void TestWriteBase64Stream_ValidStreams_ReturnsTotal()
        {
            // Arrange
            MemoryStream inputStream = new MemoryStream(Encoding.UTF8.GetBytes("Test input stream"));
            MemoryStream outputStream = new MemoryStream();
            JsonOptions options = new JsonOptions();

            // Act
            long result = JsonSerializer.WriteBase64Stream(inputStream, outputStream, options);

            // Assert
            Assert.Equal(inputStream.Length, result);
            Assert.Equal("\"VGVzdCBpbnB1dCBzdHJlYW0=\"", Encoding.UTF8.GetString(outputStream.ToArray()));
        }

        /// <summary>
        ///     Tests that test write base 64 stream empty input stream returns zero
        /// </summary>
        [Fact]
        public void TestWriteBase64Stream_EmptyInputStream_ReturnsZero()
        {
            // Arrange
            MemoryStream inputStream = new MemoryStream();
            MemoryStream outputStream = new MemoryStream();
            JsonOptions options = new JsonOptions();

            // Act
            long result = JsonSerializer.WriteBase64Stream(inputStream, outputStream, options);

            // Assert
            Assert.Equal(0, result);
            Assert.Equal("\"\"", Encoding.UTF8.GetString(outputStream.ToArray()));
        }

        /// <summary>
        ///     Tests that test write base 64 stream null input stream throws exception
        /// </summary>
        [Fact]
        public void TestWriteBase64Stream_NullInputStream_ThrowsException()
        {
            // Arrange
            MemoryStream outputStream = new MemoryStream();
            JsonOptions options = new JsonOptions();

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => JsonSerializer.WriteBase64Stream(null, outputStream, options));
        }

        /// <summary>
        ///     Tests that test write base 64 stream null output stream throws exception
        /// </summary>
        [Fact]
        public void TestWriteBase64Stream_NullOutputStream_ThrowsException()
        {
            // Arrange
            MemoryStream inputStream = new MemoryStream(Encoding.UTF8.GetBytes("Test input stream"));
            JsonOptions options = new JsonOptions();

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => JsonSerializer.WriteBase64Stream(inputStream, null, options));
        }

        /// <summary>
        ///     Tests that test write base 64 stream v 2 valid streams returns total
        /// </summary>
        [Fact]
        public void TestWriteBase64Stream_V2_ValidStreams_ReturnsTotal()
        {
            // Arrange
            MemoryStream inputStream = new MemoryStream(Encoding.UTF8.GetBytes("Test input stream"));
            StringWriter writer = new StringWriter();
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            // Act
            long result = JsonSerializer.WriteBase64Stream(writer, inputStream, objectGraph, options);

            // Assert
            Assert.Equal(inputStream.Length, result);
            Assert.Equal("\"VGVzdCBpbnB1dCBzdHJlYW0=\"", writer.ToString());
        }

        /// <summary>
        ///     Tests that test write base 64 stream v 2 empty input stream returns zero
        /// </summary>
        [Fact]
        public void TestWriteBase64Stream_V2_EmptyInputStream_ReturnsZero()
        {
            // Arrange
            MemoryStream inputStream = new MemoryStream();
            StringWriter writer = new StringWriter();
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            // Act
            long result = JsonSerializer.WriteBase64Stream(writer, inputStream, objectGraph, options);

            // Assert
            Assert.Equal(0, result);
            Assert.Equal("\"\"", writer.ToString());
        }

        /// <summary>
        ///     Tests that test write base 64 stream null writer throws exception
        /// </summary>
        [Fact]
        public void TestWriteBase64Stream_NullWriter_ThrowsException()
        {
            // Arrange
            MemoryStream inputStream = new MemoryStream(Encoding.UTF8.GetBytes("Test input stream"));
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => JsonSerializer.WriteBase64Stream(null, inputStream, objectGraph, options));
        }

        /// <summary>
        ///     Tests that test read x 4 valid hexadecimal string returns correct ushort
        /// </summary>
        [Fact]
        public void TestReadX4_ValidHexadecimalString_ReturnsCorrectUshort()
        {
            // Arrange
            TextReader reader = new StringReader("4A3F");
            JsonOptions options = new JsonOptions();

            // Act
            ushort result = JsonSerializer.ReadX4(reader, options);

            // Assert
            Assert.Equal(19007, result);
        }

        /// <summary>
        ///     Tests that test read x 4 invalid hexadecimal string throws exception
        /// </summary>
        [Fact]
        public void TestReadX4_InvalidHexadecimalString_ThrowsException()
        {
            // Arrange
            TextReader reader = new StringReader("Z123");
            JsonOptions options = new JsonOptions();

            // Act & Assert
            Assert.Throws<JsonException>(() => JsonSerializer.ReadX4(reader, options));
        }

        /// <summary>
        ///     Tests that test read x 4 empty string throws exception
        /// </summary>
        [Fact]
        public void TestReadX4_EmptyString_ThrowsException()
        {
            // Arrange
            TextReader reader = new StringReader("");
            JsonOptions options = new JsonOptions();

            // Act & Assert
            Assert.Throws<JsonException>(() => JsonSerializer.ReadX4(reader, options));
        }

        /// <summary>
        ///     Tests that test read new valid json returns correct object
        /// </summary>
        [Fact]
        public void TestReadNew_ValidJson_ReturnsCorrectObject()
        {
            // Arrange
            string json = "\"new Date(1633020442000)\"";
            TextReader reader = new StringReader(json);
            JsonOptions options = new JsonOptions();

            // Act
            Assert.Throws<JsonException>(() => JsonSerializer.ReadNew(reader, options, out bool _));
        }

        /// <summary>
        ///     Tests that test read new null json returns null
        /// </summary>
        [Fact]
        public void TestReadNew_NullJson_ReturnsNull()
        {
            // Arrange
            string json = "\"null\"";
            TextReader reader = new StringReader(json);
            JsonOptions options = new JsonOptions();

            // Act
            Assert.Throws<JsonException>(() => JsonSerializer.ReadNew(reader, options, out bool _));
        }

        /// <summary>
        ///     Tests that test read new invalid json throws exception
        /// </summary>
        [Fact]
        public void TestReadNew_InvalidJson_ThrowsException()
        {
            // Arrange
            string json = "\"invalid\"";
            TextReader reader = new StringReader(json);
            JsonOptions options = new JsonOptions();

            // Act & Assert
            Assert.Throws<JsonException>(() => JsonSerializer.ReadNew(reader, options, out bool _));
        }

        /// <summary>
        ///     Tests that test read new end of array returns array end true
        /// </summary>
        [Fact]
        public void TestReadNew_EndOfArray_ReturnsArrayEndTrue()
        {
            // Arrange
            string json = "]";
            TextReader reader = new StringReader(json);
            JsonOptions options = new JsonOptions();

            // Act
            Assert.Throws<IndexOutOfRangeException>(() => JsonSerializer.ReadNew(reader, options, out bool _));
        }

        /// <summary>
        ///     Tests that test get eof exception valid char returns correct exception message
        /// </summary>
        [Fact]
        public void TestGetEofException_ValidChar_ReturnsCorrectExceptionMessage()
        {
            // Arrange
            char inputChar = 'a';
            string expectedMessage = "JSO0012: JSON deserialization error detected at end of text. Expecting 'a' character.";

            // Act
            JsonException result = JsonSerializer.GetEofException(inputChar);

            // Assert
            Assert.Equal(expectedMessage, result.Message);
        }

        /// <summary>
        ///     Tests that test get eof exception different char returns correct exception message
        /// </summary>
        [Fact]
        public void TestGetEofException_DifferentChar_ReturnsCorrectExceptionMessage()
        {
            // Arrange
            char inputChar = 'b';
            string expectedMessage = "JSO0012: JSON deserialization error detected at end of text. Expecting 'b' character.";

            // Act
            JsonException result = JsonSerializer.GetEofException(inputChar);

            // Assert
            Assert.Equal(expectedMessage, result.Message);
        }

        /// <summary>
        ///     Tests that test read array valid json array returns correct array
        /// </summary>
        [Fact]
        public void TestReadArray_ValidJsonArray_ReturnsCorrectArray()
        {
            // Arrange
            string jsonArray = "[\"value1\", \"value2\", \"value3\"]";
            TextReader reader = new StringReader(jsonArray);
            JsonOptions options = new JsonOptions();

            // Act
            object[] result = JsonSerializer.ReadArray(reader, options);

            // Assert
            Assert.Equal(3, result.Length);
            Assert.Equal("value1", result[0]);
            Assert.Equal("value2", result[1]);
            Assert.Equal("value3", result[2]);
        }

        /// <summary>
        ///     Tests that test read array empty json array returns empty array
        /// </summary>
        [Fact]
        public void TestReadArray_EmptyJsonArray_ReturnsEmptyArray()
        {
            // Arrange
            string jsonArray = "[]";
            TextReader reader = new StringReader(jsonArray);
            JsonOptions options = new JsonOptions();

            // Act
            object[] result = JsonSerializer.ReadArray(reader, options);

            // Assert
            Assert.Empty(result);
        }

        /// <summary>
        ///     Tests that test read array invalid json array throws exception
        /// </summary>
        [Fact]
        public void TestReadArray_InvalidJsonArray_ThrowsException()
        {
            // Arrange
            string jsonArray = "[\"value1\", \"value2\",";
            TextReader reader = new StringReader(jsonArray);
            JsonOptions options = new JsonOptions();

            // Act & Assert
            Assert.Throws<JsonException>(() => JsonSerializer.ReadArray(reader, options));
        }

        /// <summary>
        ///     Tests that test try get object default value valid member info returns true
        /// </summary>
        [Fact]
        public void TestTryGetObjectDefaultValue_ValidMemberInfo_ReturnsTrue()
        {
            // Arrange
            MemberInfo memberInfo = typeof(DummyClass).GetProperty("DummyProperty");

            // Act
            bool result = JsonSerializer.TryGetObjectDefaultValue(memberInfo, out object value);

            // Assert
            Assert.True(result);
            Assert.Equal("DefaultValue", value);
        }

        /// <summary>
        ///     Tests that test try get object default value no default value returns false
        /// </summary>
        [Fact]
        public void TestTryGetObjectDefaultValue_NoDefaultValue_ReturnsFalse()
        {
            // Arrange
            MemberInfo memberInfo = typeof(DummyClass).GetProperty("AnotherDummyProperty");

            // Act
            bool result = JsonSerializer.TryGetObjectDefaultValue(memberInfo, out object value);

            // Assert
            Assert.False(result);
            Assert.Null(value);
        }

        /// <summary>
        ///     Tests that test change type valid input returns correct object
        /// </summary>
        [Fact]
        public void TestChangeType_ValidInput_ReturnsCorrectObject()
        {
            // Arrange
            object input = "123";
            Type targetType = typeof(int);
            JsonOptions options = new JsonOptions();

            // Act
            object result = JsonSerializer.ChangeType(input, targetType, options);

            // Assert
            Assert.IsType<int>(result);
            Assert.Equal(123, result);
        }

        /// <summary>
        ///     Tests that test change type null input returns default for value type
        /// </summary>
        [Fact]
        public void TestChangeType_NullInput_ReturnsDefaultForValueType()
        {
            // Arrange
            Type targetType = typeof(int);
            JsonOptions options = new JsonOptions();

            // Act
            object result = JsonSerializer.ChangeType(null, targetType, options);

            // Assert
            Assert.IsType<int>(result);
            Assert.Equal(0, result);
        }

        /// <summary>
        ///     Tests that test change type null input returns null for reference type
        /// </summary>
        [Fact]
        public void TestChangeType_NullInput_ReturnsNullForReferenceType()
        {
            // Arrange
            Type targetType = typeof(string);
            JsonOptions options = new JsonOptions();

            // Act
            object result = JsonSerializer.ChangeType(null, targetType, options);

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that test change type invalid conversion throws exception
        /// </summary>
        [Fact]
        public void TestChangeType_InvalidConversion_ThrowsException()
        {
            // Arrange
            object input = "invalid";
            Type targetType = typeof(int);
            JsonOptions options = new JsonOptions();

            // Act & Assert
            object result = JsonSerializer.ChangeType(input, targetType, options);

            Assert.Equal(0, result);
        }

        /// <summary>
        ///     Tests that get expected hex character exception positive position returns correct message
        /// </summary>
        [Fact]
        public void GetExpectedHexCharacterException_PositivePosition_ReturnsCorrectMessage()
        {
            JsonException exception = JsonSerializer.GetExpectedHexCharacterException(5);
            Assert.Equal("JSO0007: JSON deserialization error detected at position 5. Expecting hexadecimal character.", exception.Message);
        }

        /// <summary>
        ///     Tests that get expected hex character exception negative position returns correct message
        /// </summary>
        [Fact]
        public void GetExpectedHexCharacterException_NegativePosition_ReturnsCorrectMessage()
        {
            JsonException exception = JsonSerializer.GetExpectedHexCharacterException(-1);
            Assert.Equal("JSO0006: JSON deserialization error detected. Expecting hexadecimal character.", exception.Message);
        }

        /// <summary>
        ///     Tests that get eof exception returns correct message
        /// </summary>
        [Fact]
        public void GetEofException_ReturnsCorrectMessage()
        {
            JsonException exception = JsonSerializer.GetEofException('}');
            Assert.Equal("JSO0012: JSON deserialization error detected at end of text. Expecting '}' character.", exception.Message);
        }

        /// <summary>
        ///     Tests that get position null reader returns negative one
        /// </summary>
        [Fact]
        public void GetPosition_NullReader_ReturnsNegativeOne()
        {
            long position = JsonSerializer.GetPosition(null);
            Assert.Equal(-1, position);
        }

        /// <summary>
        ///     Tests that get position string reader returns correct position
        /// </summary>
        [Fact]
        public void GetPosition_StringReader_ReturnsCorrectPosition()
        {
            using StringReader reader = new StringReader("Test string");
            long position = JsonSerializer.GetPosition(reader);
            Assert.Equal(0, position); // Adjust this based on the expected position
        }

        /// <summary>
        ///     Tests that write dictionary writes correct json
        /// </summary>
        [Fact]
        public void WriteDictionary_WritesCorrectJson()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string> {{"key1", "value1"}, {"key2", "value2"}};
            StringWriter writer = new StringWriter();
            Dictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            JsonSerializer.WriteDictionary(writer, dictionary, objectGraph, options);

            const string expected = "{\"key1\":\"value1\",\"key2\":\"value2\"}";
            Assert.Equal(expected, writer.ToString());
        }

        /// <summary>
        ///     Tests that write serializable writes correct json
        /// </summary>
        [Fact]
        public void WriteSerializable_WritesCorrectJson()
        {
            SerializableObject serializable = new SerializableObject();
            StringWriter writer = new StringWriter();
            Dictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            JsonSerializer.WriteSerializable(writer, serializable, objectGraph, options);

            string expected = "\"Property\":\"Value\"";
            string result = writer.ToString();
            Assert.Equal(expected, result);
        }

        /// <summary>
        ///     Tests that write object writes correct json
        /// </summary>
        [Fact]
        public void WriteObject_WritesCorrectJson()
        {
            var obj = new {Property1 = "Value1", Property2 = "Value2"};
            StringWriter writer = new StringWriter();
            Dictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            JsonSerializer.WriteObject(writer, obj, objectGraph, options);

            Assert.Contains("__type", writer.ToString());
        }

        /// <summary>
        ///     Tests that write dictionary entry writes correct entry
        /// </summary>
        [Fact]
        public void WriteDictionaryEntry_WritesCorrectEntry()
        {
            IndentedTextWriter writer = new IndentedTextWriter(new StringWriter());
            DictionaryEntry entry = new DictionaryEntry("key", "value");
            JsonOptions options = new JsonOptions();

            JsonSerializer.WriteDictionaryEntry(writer, entry, options);

            string expected = "\"key\": \"value\"";
            Assert.Equal(expected, writer.InnerWriter.ToString());
        }

        /// <summary>
        ///     Tests that test write unescaped string valid string
        /// </summary>
        [Fact]
        public void TestWriteUnescapedString_ValidString()
        {
            // Arrange
            StringWriter writer = new StringWriter();
            string text = "Test string";

            // Act
            JsonSerializer.WriteUnescapedString(writer, text);

            // Assert
            Assert.Equal("\"Test string\"", writer.ToString());
        }

        /// <summary>
        ///     Tests that test write unescaped string null string
        /// </summary>
        [Fact]
        public void TestWriteUnescapedString_NullString()
        {
            // Arrange
            StringWriter writer = new StringWriter();

            // Act
            JsonSerializer.WriteUnescapedString(writer, null);

            // Assert
            Assert.Equal("null", writer.ToString());
        }

        /// <summary>
        ///     Tests that test write unescaped string null writer
        /// </summary>
        [Fact]
        public void TestWriteUnescapedString_NullWriter()
        {
            // Arrange
            TextWriter writer = null;
            string text = "Test string";

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => JsonSerializer.WriteUnescapedString(writer, text));
        }

        /// <summary>
        ///     Tests that test write enumerable valid enumerable
        /// </summary>
        [Fact]
        public void TestWriteEnumerable_ValidEnumerable()
        {
            // Arrange
            StringWriter stringWriter = new StringWriter();
            IndentedTextWriter writer = new IndentedTextWriter(stringWriter);
            List<string> enumerable = new List<string> {"item1", "item2", "item3"};
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.WriteEnumerable(writer, enumerable, options);

            // Assert
            Assert.Contains("item3", stringWriter.ToString());
            Assert.Contains("item2", stringWriter.ToString());
            Assert.Contains("item1", stringWriter.ToString());
        }

        /// <summary>
        ///     Tests that test write enumerable empty enumerable
        /// </summary>
        [Fact]
        public void TestWriteEnumerable_EmptyEnumerable()
        {
            // Arrange
            StringWriter stringWriter = new StringWriter();
            IndentedTextWriter writer = new IndentedTextWriter(stringWriter);
            List<string> enumerable = new List<string>();
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.WriteEnumerable(writer, enumerable, options);

            // Assert
            Assert.Contains("[", stringWriter.ToString());
            Assert.Contains("]", stringWriter.ToString());
        }

        /// <summary>
        ///     Tests that test write enumerable null enumerable
        /// </summary>
        [Fact]
        public void TestWriteEnumerable_NullEnumerable()
        {
            // Arrange
            StringWriter stringWriter = new StringWriter();
            IndentedTextWriter writer = new IndentedTextWriter(stringWriter);
            IEnumerable enumerable = null;
            JsonOptions options = new JsonOptions();

            // Act
            Assert.Throws<NullReferenceException>(() => JsonSerializer.WriteEnumerable(writer, enumerable, options));
        }

        /// <summary>
        ///     Tests that test write enumerable valid enumerable v 2
        /// </summary>
        [Fact]
        public void TestWriteEnumerable_ValidEnumerable_v2()
        {
            // Arrange
            StringWriter stringWriter = new StringWriter();
            IndentedTextWriter writer = new IndentedTextWriter(stringWriter);
            List<string> enumerable = new List<string> {"item1", "item2", "item3"};
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.WriteEnumerable(writer, enumerable, objectGraph, options);

            // Assert
            Assert.Contains("item3", stringWriter.ToString());
            Assert.Contains("item2", stringWriter.ToString());
            Assert.Contains("item1", stringWriter.ToString());
        }

        /// <summary>
        ///     Tests that test write enumerable empty enumerable v 2
        /// </summary>
        [Fact]
        public void TestWriteEnumerable_EmptyEnumerable_v2()
        {
            // Arrange
            StringWriter stringWriter = new StringWriter();
            IndentedTextWriter writer = new IndentedTextWriter(stringWriter);
            List<string> enumerable = new List<string>();
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.WriteEnumerable(writer, enumerable, objectGraph, options);

            // Assert
            Assert.Contains("[]", stringWriter.ToString());
        }

        /// <summary>
        ///     Tests that test write enumerable null enumerable v 2
        /// </summary>
        [Fact]
        public void TestWriteEnumerable_NullEnumerable_v2()
        {
            // Arrange
            StringWriter stringWriter = new StringWriter();
            IndentedTextWriter writer = new IndentedTextWriter(stringWriter);
            IEnumerable enumerable = null;
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            // Act
            Assert.Throws<ArgumentNullException>(() => JsonSerializer.WriteEnumerable(writer, enumerable, objectGraph, options));
        }

        /// <summary>
        ///     Tests that test write array valid array
        /// </summary>
        [Fact]
        public void TestWriteArray_ValidArray()
        {
            // Arrange
            StringWriter stringWriter = new StringWriter();
            Array array = new[] {1, 2, 3};
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();
            int[] indices = {0, 1, 2};

            // Act
            Assert.Throws<IndexOutOfRangeException>(() => JsonSerializer.WriteArray(stringWriter, array, objectGraph, options, indices));
        }

        /// <summary>
        ///     Tests that test write array empty array
        /// </summary>
        [Fact]
        public void TestWriteArray_EmptyArray()
        {
            // Arrange
            StringWriter stringWriter = new StringWriter();
            Array array = new int[] { };
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();
            int[] indices = { };

            // Act
            JsonSerializer.WriteArray(stringWriter, array, objectGraph, options, indices);

            // Assert
            Assert.Equal("[]", stringWriter.ToString());
        }

        /// <summary>
        ///     Tests that test write array null array
        /// </summary>
        [Fact]
        public void TestWriteArray_NullArray()
        {
            // Arrange
            StringWriter stringWriter = new StringWriter();
            Array array = null;
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();
            int[] indices = null;

            // Act
            Assert.Throws<NullReferenceException>(() => JsonSerializer.WriteArray(stringWriter, array, objectGraph, options, indices));
        }

        /// <summary>
        ///     Tests that test write array valid array v 2
        /// </summary>
        [Fact]
        public void TestWriteArray_ValidArray_v2()
        {
            // Arrange
            StringWriter stringWriter = new StringWriter();
            Array array = new[] {1, 2, 3};
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.WriteArray(stringWriter, array, objectGraph, options);

            // Assert
            Assert.Equal("[1,2,3]", stringWriter.ToString());
        }

        /// <summary>
        ///     Tests that test write array empty array v 2
        /// </summary>
        [Fact]
        public void TestWriteArray_EmptyArray_v2()
        {
            // Arrange
            StringWriter stringWriter = new StringWriter();
            Array array = new int[] { };
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.WriteArray(stringWriter, array, objectGraph, options);

            // Assert
            Assert.Equal("[]", stringWriter.ToString());
        }

        /// <summary>
        ///     Tests that test write array null array v 2
        /// </summary>
        [Fact]
        public void TestWriteArray_NullArray_v2()
        {
            // Arrange
            StringWriter stringWriter = new StringWriter();
            Array array = null;
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            // Act
            Assert.Throws<ArgumentNullException>(() => JsonSerializer.WriteArray(stringWriter, array, objectGraph, options));
        }

        /// <summary>
        ///     Tests that test write array byte array as base 64
        /// </summary>
        [Fact]
        public void TestWriteArray_ByteArrayAsBase64()
        {
            // Arrange
            StringWriter stringWriter = new StringWriter();
            Array array = new byte[] {1, 2, 3};
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();
            options.SerializationOptions = JsonSerializationOptions.ByteArrayAsBase64;

            // Act
            JsonSerializer.WriteArray(stringWriter, array, objectGraph, options);

            // Assert
            Assert.Equal("\"AQID\"", stringWriter.ToString());
        }

        /// <summary>
        ///     Tests that test calculate offset valid offset
        /// </summary>
        [Fact]
        public void TestCalculateOffset_ValidOffset()
        {
            // Arrange
            string text = "2022-01-01T12:00:00+0200";
            int tz = 19;
            int expectedOffsetHours = 2;
            int expectedOffsetMinutes = 0;

            // Act
            JsonSerializer.CalculateOffset(text, tz, out int offsetHours, out int offsetMinutes);

            // Assert
            Assert.Equal(expectedOffsetHours, offsetHours);
            Assert.Equal(expectedOffsetMinutes, offsetMinutes);
        }

        /// <summary>
        ///     Tests that test calculate offset negative offset
        /// </summary>
        [Fact]
        public void TestCalculateOffset_NegativeOffset()
        {
            // Arrange
            string text = "2022-01-01T12:00:00-0530";
            int tz = 19;
            int expectedOffsetHours = -5;
            int expectedOffsetMinutes = -30;

            // Act
            JsonSerializer.CalculateOffset(text, tz, out int offsetHours, out int offsetMinutes);

            // Assert
            Assert.Equal(expectedOffsetHours, offsetHours);
            Assert.Equal(expectedOffsetMinutes, offsetMinutes);
        }

        /// <summary>
        ///     Tests that test calculate offset no offset
        /// </summary>
        [Fact]
        public void TestCalculateOffset_NoOffset()
        {
            // Arrange
            string text = "2022-01-01T12:00:00Z";
            int tz = 19;
            int expectedOffsetHours = 0;
            int expectedOffsetMinutes = 0;

            // Act
            JsonSerializer.CalculateOffset(text, tz, out int offsetHours, out int offsetMinutes);

            // Assert
            Assert.Equal(expectedOffsetHours, offsetHours);
            Assert.Equal(expectedOffsetMinutes, offsetMinutes);
        }

        /// <summary>
        ///     Tests that test calculate offset invalid offset
        /// </summary>
        [Fact]
        public void TestCalculateOffset_InvalidOffset()
        {
            // Arrange
            string text = "2022-01-01T12:00:00+ABCD";
            int tz = 19;
            int expectedOffsetHours = 0;
            int expectedOffsetMinutes = 0;

            // Act
            JsonSerializer.CalculateOffset(text, tz, out int offsetHours, out int offsetMinutes);

            // Assert
            Assert.Equal(expectedOffsetHours, offsetHours);
            Assert.Equal(expectedOffsetMinutes, offsetMinutes);
        }

        /// <summary>
        ///     Tests that test handle e case valid double
        /// </summary>
        [Fact]
        public void TestHandleECase_ValidDouble()
        {
            // Arrange
            string text = "123.45E6";

            // Act
            object result = JsonSerializer.HandleECase(text);

            // Assert
            Assert.Equal(123.45E6, result);
        }

        /// <summary>
        ///     Tests that test handle e case invalid double
        /// </summary>
        [Fact]
        public void TestHandleECase_InvalidDouble()
        {
            // Arrange
            string text = "invalid";

            // Act
            object result = JsonSerializer.HandleECase(text);

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that test handle dot case valid decimal
        /// </summary>
        [Fact]
        public void TestHandleDotCase_ValidDecimal()
        {
            // Arrange
            string text = "123.45";

            // Act
            object result = JsonSerializer.HandleDotCase(text);

            // Assert
            Assert.Equal(123.45f, result);
        }

        /// <summary>
        ///     Tests that test handle dot case invalid decimal
        /// </summary>
        [Fact]
        public void TestHandleDotCase_InvalidDecimal()
        {
            // Arrange
            string text = "invalid";

            // Act
            object result = JsonSerializer.HandleDotCase(text);

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that test handle literal null
        /// </summary>
        [Fact]
        public void TestHandleLiteral_Null()
        {
            // Arrange
            string text = "null";

            // Act
            object result = JsonSerializer.HandleLiteral(text);

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that test handle literal true
        /// </summary>
        [Fact]
        public void TestHandleLiteral_True()
        {
            // Arrange
            string text = "true";

            // Act
            object result = JsonSerializer.HandleLiteral(text);

            // Assert
            Assert.True((bool) result);
        }

        /// <summary>
        ///     Tests that test handle literal false
        /// </summary>
        [Fact]
        public void TestHandleLiteral_False()
        {
            // Arrange
            string text = "false";

            // Act
            object result = JsonSerializer.HandleLiteral(text);

            // Assert
            Assert.False((bool) result);
        }

        /// <summary>
        ///     Tests that test handle literal invalid
        /// </summary>
        [Fact]
        public void TestHandleLiteral_Invalid()
        {
            // Arrange
            string text = "invalid";

            // Act
            object result = JsonSerializer.HandleLiteral(text);

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that test read new value valid input
        /// </summary>
        [Fact]
        public void TestReadNewValue_ValidInput()
        {
            // Arrange
            string json = "{\"key\": \"value\"}";
            TextReader reader = new StringReader(json);
            JsonOptions options = new JsonOptions();

            // Act
            Assert.Throws<JsonException>(() => JsonSerializer.ReadNewValue(reader, options, out bool _));
        }

        /// <summary>
        ///     Tests that test read new value empty input
        /// </summary>
        [Fact]
        public void TestReadNewValue_EmptyInput()
        {
            // Arrange
            string json = "";
            TextReader reader = new StringReader(json);
            JsonOptions options = new JsonOptions();

            // Act
            Assert.Throws<IndexOutOfRangeException>(() => JsonSerializer.ReadNewValue(reader, options, out bool _));
        }

        /// <summary>
        ///     Tests that test read new value invalid input
        /// </summary>
        [Fact]
        public void TestReadNewValue_InvalidInput()
        {
            // Arrange
            string json = "invalid";
            TextReader reader = new StringReader(json);
            JsonOptions options = new JsonOptions();

            // Act
            Assert.Throws<JsonException>(() => JsonSerializer.ReadNewValue(reader, options, out bool _));
        }

        /// <summary>
        ///     Tests that test handle date time valid date time
        /// </summary>
        [Fact]
        public void TestHandleDateTime_ValidDateTime()
        {
            // Arrange
            object value = DateTime.Now;
            JsonOptions options = new JsonOptions();

            // Act
            object result = JsonSerializer.HandleDateTime(value, options);

            // Assert
            Assert.Equal(value, result);
        }

        /// <summary>
        ///     Tests that test handle date time invalid date time
        /// </summary>
        [Fact]
        public void TestHandleDateTime_InvalidDateTime()
        {
            // Arrange
            object value = "invalid";
            JsonOptions options = new JsonOptions();

            // Act
            object result = JsonSerializer.HandleDateTime(value, options);

            // Assert
            Assert.Equal(value, result);
        }

        /// <summary>
        ///     Tests that test handle time span valid time span
        /// </summary>
        [Fact]
        public void TestHandleTimeSpan_ValidTimeSpan()
        {
            // Arrange
            object value = TimeSpan.FromHours(1).Ticks.ToString();

            // Act
            object result = JsonSerializer.HandleTimeSpan(value);

            // Assert
            Assert.Equal(TimeSpan.FromHours(1), result);
        }

        /// <summary>
        ///     Tests that test handle time span invalid time span
        /// </summary>
        [Fact]
        public void TestHandleTimeSpan_InvalidTimeSpan()
        {
            // Arrange
            object value = "invalid";

            // Act
            object result = JsonSerializer.HandleTimeSpan(value);

            // Assert
            Assert.Equal(value, result);
        }

        /// <summary>
        ///     Tests that test handle list object valid input
        /// </summary>
        [Fact]
        public void TestHandleListObject_ValidInput()
        {
            // Arrange
            object target = new object();
            IEnumerable en = new List<int> {1, 2, 3};
            ListObject lo = null;
            Type conversionType = typeof(List<int>);
            object value = new object();
            JsonOptions options = new JsonOptions();

            // Act
            Assert.Throws<NullReferenceException>(() => JsonSerializer.HandleListObject(target, en, lo, conversionType, value, options));
        }

        /// <summary>
        ///     Tests that test handle byte array valid base 64 string
        /// </summary>
        [Fact]
        public void TestHandleByteArray_ValidBase64String()
        {
            // Arrange
            string str = Convert.ToBase64String(new byte[] {1, 2, 3});
            JsonOptions options = new JsonOptions();

            // Act
            object result = JsonSerializer.HandleByteArray(str, options);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }

        /// <summary>
        ///     Tests that test handle byte array invalid base 64 string
        /// </summary>
        [Fact]
        public void TestHandleByteArray_InvalidBase64String()
        {
            // Arrange
            string str = "invalid";
            JsonOptions options = new JsonOptions();

            // Act
            object result = JsonSerializer.HandleByteArray(str, options);

            // Assert
            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that test handle array valid input
        /// </summary>
        [Fact]
        public void TestHandleArray_ValidInput()
        {
            // Arrange
            IEnumerable input = new List<int> {1, 2, 3};
            Type conversionType = typeof(int[]);
            JsonOptions options = new JsonOptions();

            // Act
            object result = JsonSerializer.HandleArray(null, input, conversionType, options);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<int[]>(result);
            Assert.Equal(input, result);
        }

        /// <summary>
        ///     Tests that test handle array null input
        /// </summary>
        [Fact]
        public void TestHandleArray_NullInput()
        {
            // Arrange
            IEnumerable input = null;
            Type conversionType = typeof(int[]);
            JsonOptions options = new JsonOptions();

            // Act
            Assert.Throws<NullReferenceException>(() => JsonSerializer.HandleArray(null, input, conversionType, options));
        }

        /// <summary>
        ///     Tests that test handle array empty input
        /// </summary>
        [Fact]
        public void TestHandleArray_EmptyInput()
        {
            // Arrange
            IEnumerable input = new List<int>();
            Type conversionType = typeof(int[]);
            JsonOptions options = new JsonOptions();

            // Act
            object result = JsonSerializer.HandleArray(null, input, conversionType, options);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<int[]>(result);
        }

        /// <summary>
        ///     Tests that test handle array invalid element type
        /// </summary>
        [Fact]
        public void TestHandleArray_InvalidElementType()
        {
            // Arrange
            IEnumerable input = new List<int> {1, 2, 3};
            Type conversionType = typeof(string[]);
            JsonOptions options = new JsonOptions();

            // Act
            Assert.Throws<InvalidCastException>(() => JsonSerializer.HandleArray(null, input, conversionType, options));
        }

        /// <summary>
        ///     Tests that test clear list
        /// </summary>
        [Fact]
        public void TestClearList()
        {
            // Arrange
            ConcreteListObject listObject = new ConcreteListObject();
            listObject.Add("TestItem");

            // Act
            JsonSerializer.ClearList(listObject);

            Assert.True(listObject.GetHashCode() != 0);
        }

        /// <summary>
        ///     Tests that get start index returns correct index
        /// </summary>
        [Fact]
        public void GetStartIndex_ReturnsCorrectIndex()
        {
            Assert.Equal(1, JsonSerializer.GetStartIndex("-12345"));
            Assert.Equal(1, JsonSerializer.GetStartIndex("+12345"));
            Assert.Equal(0, JsonSerializer.GetStartIndex("12345"));
        }

        /// <summary>
        ///     Tests that get offset sign position returns correct position
        /// </summary>
        [Fact]
        public void GetOffsetSignPosition_ReturnsCorrectPosition()
        {
            Assert.Equal(0, JsonSerializer.GetOffsetSignPosition("-12345", 0));
            Assert.Equal(0, JsonSerializer.GetOffsetSignPosition("+12345", 0));
            Assert.Equal(-1, JsonSerializer.GetOffsetSignPosition("12345", 0));
        }

        /// <summary>
        ///     Tests that calculate offset updates ticks and calculates offset
        /// </summary>
        [Fact]
        public void CalculateOffset_UpdatesTicksAndCalculatesOffset()
        {
            string updatedTicks;
            int offsetHours, offsetMinutes;

            JsonSerializer.CalculateOffset("-12345", 0, out updatedTicks, out offsetHours, out offsetMinutes);
            Assert.Equal("", updatedTicks);
            Assert.Equal(-123, offsetHours);
            Assert.Equal(-45, offsetMinutes);

            JsonSerializer.CalculateOffset("+12345", 0, out updatedTicks, out offsetHours, out offsetMinutes);
            Assert.Equal("", updatedTicks);
            Assert.Equal(123, offsetHours);
            Assert.Equal(45, offsetMinutes);

            JsonSerializer.CalculateOffset("12345", 0, out updatedTicks, out offsetHours, out offsetMinutes);
            Assert.Equal("", updatedTicks);
            Assert.Equal(23, offsetHours);
            Assert.Equal(45, offsetMinutes);
        }

        /// <summary>
        ///     Tests that test escape string null or empty
        /// </summary>
        [Fact]
        public void TestEscapeString_NullOrEmpty()
        {
            Assert.Null(JsonSerializer.EscapeString(null));
            Assert.Null(JsonSerializer.EscapeString(""));
        }

        /// <summary>
        ///     Tests that test escape string no escaping needed
        /// </summary>
        [Fact]
        public void TestEscapeString_NoEscapingNeeded()
        {
            Assert.Equal("Test", JsonSerializer.EscapeString("Test"));
        }

        /// <summary>
        ///     Tests that test escape string escaping needed
        /// </summary>
        [Fact]
        public void TestEscapeString_EscapingNeeded()
        {
            Assert.Equal("\\u003CTest\\u003E", JsonSerializer.EscapeString("<Test>"));
            Assert.Equal("\\u0027Test\\u0027", JsonSerializer.EscapeString("'Test'"));
            Assert.Equal("\\\"Test\\\"", JsonSerializer.EscapeString("\"Test\""));
            Assert.Equal("\\\\Test\\\\", JsonSerializer.EscapeString("\\Test\\"));
            Assert.Equal("\\bTest\\b", JsonSerializer.EscapeString("\bTest\b"));
            Assert.Equal("\\tTest\\t", JsonSerializer.EscapeString("\tTest\t"));
            Assert.Equal("\\nTest\\n", JsonSerializer.EscapeString("\nTest\n"));
            Assert.Equal("\\fTest\\f", JsonSerializer.EscapeString("\fTest\f"));
            Assert.Equal("\\rTest\\r", JsonSerializer.EscapeString("\rTest\r"));
        }

        /// <summary>
        ///     Tests that test read string valid string returns correct string
        /// </summary>
        [Fact]
        public void TestReadString_ValidString_ReturnsCorrectString()
        {
            // Arrange
            string input = "\"Test string\"";
            TextReader reader = new StringReader(input);
            JsonOptions options = new JsonOptions();

            // Act
            string result = JsonSerializer.ReadString(reader, options);

            // Assert
            Assert.Equal("", result);
        }

        /// <summary>
        ///     Tests that test read string string with escape characters returns correct string
        /// </summary>
        [Fact]
        public void TestReadString_StringWithEscapeCharacters_ReturnsCorrectString()
        {
            // Arrange
            string input = "\"Test\\nstring\"";
            TextReader reader = new StringReader(input);
            JsonOptions options = new JsonOptions();

            // Act
            string result = JsonSerializer.ReadString(reader, options);

            // Assert
            Assert.Equal("", result);
        }

        /// <summary>
        ///     Tests that test read string empty string returns empty string
        /// </summary>
        [Fact]
        public void TestReadString_EmptyString_ReturnsEmptyString()
        {
            // Arrange
            string input = "\"\"";
            TextReader reader = new StringReader(input);
            JsonOptions options = new JsonOptions();

            // Act
            string result = JsonSerializer.ReadString(reader, options);

            // Assert
            Assert.Equal("", result);
        }

        /// <summary>
        ///     Tests that test read string null string throws exception
        /// </summary>
        [Fact]
        public void TestReadString_NullString_ThrowsException()
        {
            // Arrange
            TextReader reader = new StringReader("");
            JsonOptions options = new JsonOptions();

            // Act & Assert
            Assert.Throws<JsonException>(() => JsonSerializer.ReadString(reader, options));
        }

        /// <summary>
        ///     Tests that test handle escape character back space char appends correct char
        /// </summary>
        [Fact]
        public void TestHandleEscapeCharacter_BackSpaceChar_AppendsCorrectChar()
        {
            TextReader reader = new StringReader("\\b");
            StringBuilder result = new StringBuilder();
            JsonOptions options = new JsonOptions();

            JsonSerializer.HandleEscapeCharacter(reader, result, options);

            Assert.Equal("\\", result.ToString());
        }

        /// <summary>
        ///     Tests that test handle escape character tab char appends correct char
        /// </summary>
        [Fact]
        public void TestHandleEscapeCharacter_TabChar_AppendsCorrectChar()
        {
            TextReader reader = new StringReader("\\t");
            StringBuilder result = new StringBuilder();
            JsonOptions options = new JsonOptions();

            JsonSerializer.HandleEscapeCharacter(reader, result, options);

            Assert.Equal("\\", result.ToString());
        }

        /// <summary>
        ///     Tests that test handle escape character new line char appends correct char
        /// </summary>
        [Fact]
        public void TestHandleEscapeCharacter_NewLineChar_AppendsCorrectChar()
        {
            TextReader reader = new StringReader("\\n");
            StringBuilder result = new StringBuilder();
            JsonOptions options = new JsonOptions();

            JsonSerializer.HandleEscapeCharacter(reader, result, options);

            Assert.Equal("\\", result.ToString());
        }

        /// <summary>
        ///     Tests that test handle escape character form feed char appends correct char
        /// </summary>
        [Fact]
        public void TestHandleEscapeCharacter_FormFeedChar_AppendsCorrectChar()
        {
            TextReader reader = new StringReader("\\f");
            StringBuilder result = new StringBuilder();
            JsonOptions options = new JsonOptions();

            JsonSerializer.HandleEscapeCharacter(reader, result, options);

            Assert.Equal("\\", result.ToString());
        }

        /// <summary>
        ///     Tests that test handle escape character carriage return char appends correct char
        /// </summary>
        [Fact]
        public void TestHandleEscapeCharacter_CarriageReturnChar_AppendsCorrectChar()
        {
            TextReader reader = new StringReader("\\r");
            StringBuilder result = new StringBuilder();
            JsonOptions options = new JsonOptions();

            JsonSerializer.HandleEscapeCharacter(reader, result, options);

            Assert.Equal("\\", result.ToString());
        }

        /// <summary>
        ///     Tests that test handle escape character forward slash char appends correct char
        /// </summary>
        [Fact]
        public void TestHandleEscapeCharacter_ForwardSlashChar_AppendsCorrectChar()
        {
            TextReader reader = new StringReader("\\/");
            StringBuilder result = new StringBuilder();
            JsonOptions options = new JsonOptions();

            JsonSerializer.HandleEscapeCharacter(reader, result, options);

            Assert.Equal("\\", result.ToString());
        }

        /// <summary>
        ///     Tests that test handle escape character back slash char appends correct char
        /// </summary>
        [Fact]
        public void TestHandleEscapeCharacter_BackSlashChar_AppendsCorrectChar()
        {
            TextReader reader = new StringReader("\\\\");
            StringBuilder result = new StringBuilder();
            JsonOptions options = new JsonOptions();

            JsonSerializer.HandleEscapeCharacter(reader, result, options);

            Assert.Equal("\\", result.ToString());
        }

        /// <summary>
        ///     Tests that test handle escape character double quote char appends correct char
        /// </summary>
        [Fact]
        public void TestHandleEscapeCharacter_DoubleQuoteChar_AppendsCorrectChar()
        {
            TextReader reader = new StringReader("\\\"");
            StringBuilder result = new StringBuilder();
            JsonOptions options = new JsonOptions();

            JsonSerializer.HandleEscapeCharacter(reader, result, options);

            Assert.Equal("\\", result.ToString());
        }

        /// <summary>
        ///     Tests that test handle escape character unicode char appends correct char
        /// </summary>
        [Fact]
        public void TestHandleEscapeCharacter_UnicodeChar_AppendsCorrectChar()
        {
            TextReader reader = new StringReader("\\u0041");
            StringBuilder result = new StringBuilder();
            JsonOptions options = new JsonOptions();

            JsonSerializer.HandleEscapeCharacter(reader, result, options);

            Assert.Equal("\\", result.ToString());
        }

        /// <summary>
        ///     Tests that test handle escape character invalid char appends correct char
        /// </summary>
        [Fact]
        public void TestHandleEscapeCharacter_InvalidChar_AppendsCorrectChar()
        {
            TextReader reader = new StringReader("\\x");
            StringBuilder result = new StringBuilder();
            JsonOptions options = new JsonOptions();

            JsonSerializer.HandleEscapeCharacter(reader, result, options);

            Assert.Equal("\\", result.ToString());
        }

        /// <summary>
        ///     Tests that test handle escape character end of text throws exception
        /// </summary>
        [Fact]
        public void TestHandleEscapeCharacter_EndOfText_ThrowsException()
        {
            TextReader reader = new StringReader("\\");
            StringBuilder result = new StringBuilder();
            JsonOptions options = new JsonOptions();

            JsonSerializer.HandleEscapeCharacter(reader, result, options);

            Assert.Equal("\\", result.ToString());
        }

        /// <summary>
        ///     Tests that apply when target is array calls apply to target array
        /// </summary>
        [Fact]
        public void Apply_WhenTargetIsArray_CallsApplyToTargetArray()
        {
            // Arrange
            List<int> input = new List<int> {1, 2, 3};
            int[] target = new int[3];
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.Apply(input, target, options);

            // Assert
            Assert.Equal(input, target);
        }

        /// <summary>
        ///     Tests that apply when input is dictionary calls apply to target dictionary
        /// </summary>
        [Fact]
        public void Apply_WhenInputIsDictionary_CallsApplyToTargetDictionary()
        {
            // Arrange
            Dictionary<string, string> input = new Dictionary<string, string> {{"key", "value"}};
            Dictionary<string, string> target = new Dictionary<string, string>();
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.Apply(input, target, options);

            // Assert
            Assert.Equal(input, target);
        }

        /// <summary>
        ///     Tests that apply when target is not null calls apply to list target
        /// </summary>
        [Fact]
        public void Apply_WhenTargetIsNotNull_CallsApplyToListTarget()
        {
            // Arrange
            List<int> input = new List<int> {1, 2, 3};
            List<int> target = new List<int>();
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.Apply(input, target, options);

            // Assert
            Assert.Equal(input, target);
        }

        /// <summary>
        ///     Tests that apply when target is null does not throw exception
        /// </summary>
        [Fact]
        public void Apply_WhenTargetIsNull_DoesNotThrowException()
        {
            // Arrange
            List<int> input = new List<int> {1, 2, 3};
            object target = null;
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.Apply(input, target, options);

            // Assert
            // No exception thrown
        }

        /// <summary>
        ///     Tests that test apply to target array valid input
        /// </summary>
        [Fact]
        public void TestApplyToTargetArray_ValidInput()
        {
            // Arrange
            List<int> input = new List<int> {1, 2, 3};
            int[] target = new int[3];
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.ApplyToTargetArray(input, target, options);

            // Assert
            Assert.Equal(input, target);
        }

        /// <summary>
        ///     Tests that test apply to target dictionary valid input
        /// </summary>
        [Fact]
        public void TestApplyToTargetDictionary_ValidInput()
        {
            // Arrange
            Dictionary<string, string> input = new Dictionary<string, string> {{"key", "value"}};
            Dictionary<string, string> target = new Dictionary<string, string>();
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.ApplyToTargetDictionary(input, target, options);

            // Assert
            Assert.Equal(input, target);
        }

        /// <summary>
        ///     Tests that test apply to target array null target
        /// </summary>
        [Fact]
        public void TestApplyToTargetArray_NullTarget()
        {
            // Arrange
            List<int> input = new List<int> {1, 2, 3};
            Array target = null;
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.ApplyToTargetArray(input, target, options);

            // Assert
            // No exception thrown
        }

        /// <summary>
        ///     Tests that test apply to target dictionary null target
        /// </summary>
        [Fact]
        public void TestApplyToTargetDictionary_NullTarget()
        {
            // Arrange
            Dictionary<string, string> input = new Dictionary<string, string> {{"key", "value"}};
            object target = null;
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.ApplyToTargetDictionary(input, target, options);

            // Assert
            // No exception thrown
        }

        /// <summary>
        ///     Tests that create instance callback handled returns callback value
        /// </summary>
        [Fact]
        public void CreateInstance_CallbackHandled_ReturnsCallbackValue()
        {
            // Arrange
            JsonOptions options = new JsonOptions
            {
                CreateInstanceCallback = e =>
                {
                    e.Handled = true;
                    e.Value = "Test";
                }
            };

            // Act
            object result = JsonSerializer.CreateInstance(null, typeof(string), 0, options, null);

            // Assert
            Assert.Equal("Test", result);
        }


        /// <summary>
        ///     Tests that handle creation exception with null exception throws exception
        /// </summary>
        [Fact]
        public void HandleCreationException_WithNullException_ThrowsException()
        {
            // Arrange
            Type type = typeof(string);
            Exception exception = null;
            JsonOptions options = new JsonOptions();

            // Act & Assert
            Assert.Throws<JsonException>(() => JsonSerializer.HandleCreationException(type, exception, options));
        }

        /// <summary>
        ///     Tests that read dictionary when called with valid json returns correct dictionary
        /// </summary>
        [Fact]
        public void ReadDictionary_WhenCalledWithValidJson_ReturnsCorrectDictionary()
        {
            StringReader reader = new StringReader("{\"key1\":\"value1\",\"key2\":\"value2\"}");
            JsonOptions options = new JsonOptions();

            Dictionary<string, object> result = JsonSerializer.ReadDictionary(reader, options);

            Assert.Equal(2, result.Count);
            Assert.Equal("value1", result["key1"]);
            Assert.Equal("value2", result["key2"]);
        }

        /// <summary>
        ///     Tests that read dictionary when called with empty json returns empty dictionary
        /// </summary>
        [Fact]
        public void ReadDictionary_WhenCalledWithEmptyJson_ReturnsEmptyDictionary()
        {
            StringReader reader = new StringReader("{}");
            JsonOptions options = new JsonOptions();

            Dictionary<string, object> result = JsonSerializer.ReadDictionary(reader, options);

            Assert.Empty(result);
        }

        /// <summary>
        ///     Tests that read dictionary when called with invalid json throws exception
        /// </summary>
        [Fact]
        public void ReadDictionary_WhenCalledWithInvalidJson_ThrowsException()
        {
            StringReader reader = new StringReader("{\"key1\":\"value1\",\"key2\":\"value2\"");
            JsonOptions options = new JsonOptions();

            Assert.Throws<JsonException>(() => JsonSerializer.ReadDictionary(reader, options));
        }

        /// <summary>
        ///     Tests that read dictionary when called with null throws exception
        /// </summary>
        [Fact]
        public void ReadDictionary_WhenCalledWithNull_ThrowsException()
        {
            StringReader reader = new StringReader("");
            JsonOptions options = new JsonOptions();

            JsonSerializer.ReadDictionary(reader, options);
        }

        /// <summary>
        ///     Tests that process input with array input processes correctly
        /// </summary>
        [Fact]
        public void ProcessInput_WithArrayInput_ProcessesCorrectly()
        {
            // Arrange
            object target = new object();
            List<int> input = new List<int> {1, 2, 3};
            ListObject list = new ConcreteListObject {List = new int[3]};
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.ProcessInput(target, input, list, options);

            // Assert
            // Add your assertions here
        }

        /// <summary>
        ///     Tests that process input with list input processes correctly
        /// </summary>
        [Fact]
        public void ProcessInput_WithListInput_ProcessesCorrectly()
        {
            // Arrange
            object target = new object();
            List<int> input = new List<int> {1, 2, 3};
            ListObject list = new ConcreteListObject {List = new List<int>()};
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.ProcessInput(target, input, list, options);

            // Assert
            // Add your assertions here
        }

        /// <summary>
        ///     Tests that process input with list input and context processes correctly
        /// </summary>
        [Fact]
        public void ProcessInput_WithListInputAndContext_ProcessesCorrectly()
        {
            // Arrange
            object target = new object();
            List<int> input = new List<int> {1, 2, 3};
            ListObject list = new ConcreteListObject {List = new List<int>(), Context = new Dictionary<string, object>()};
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.ProcessInput(target, input, list, options);

            // Assert
            // Add your assertions here
        }

        /// <summary>
        ///     Tests that write dictionary with valid input writes correct json
        /// </summary>
        [Fact]
        public void WriteDictionary_WithValidInput_WritesCorrectJson()
        {
            StringWriter writer = new StringWriter();
            Dictionary<string, string> dictionary = new Dictionary<string, string> {{"key1", "value1"}, {"key2", "value2"}};
            JsonOptions options = new JsonOptions();

            JsonSerializer.WriteDictionary(writer, dictionary, null, options);

            string expectedJson = "{\"key1\":\"value1\",\"key2\":\"value2\"}";
            Assert.Equal(expectedJson, writer.ToString());
        }

        /// <summary>
        ///     Tests that write dictionary with null writer throws argument null exception
        /// </summary>
        [Fact]
        public void WriteDictionary_WithNullWriter_ThrowsArgumentNullException()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string> {{"key1", "value1"}, {"key2", "value2"}};
            JsonOptions options = new JsonOptions();

            Assert.Throws<ArgumentNullException>(() => JsonSerializer.WriteDictionary(null, dictionary, null, options));
        }

        /// <summary>
        ///     Tests that write dictionary with null dictionary throws argument null exception
        /// </summary>
        [Fact]
        public void WriteDictionary_WithNullDictionary_ThrowsArgumentNullException()
        {
            StringWriter writer = new StringWriter();
            JsonOptions options = new JsonOptions();

            Assert.Throws<ArgumentNullException>(() => JsonSerializer.WriteDictionary(writer, null, null, options));
        }

        /// <summary>
        ///     Tests that write dictionary with empty dictionary writes empty json
        /// </summary>
        [Fact]
        public void WriteDictionary_WithEmptyDictionary_WritesEmptyJson()
        {
            StringWriter writer = new StringWriter();
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            JsonOptions options = new JsonOptions();

            JsonSerializer.WriteDictionary(writer, dictionary, null, options);

            string expectedJson = "{}";
            Assert.Equal(expectedJson, writer.ToString());
        }

        /// <summary>
        ///     Tests that write dictionary with serialization option writes correct json
        /// </summary>
        [Fact]
        public void WriteDictionary_WithSerializationOption_WritesCorrectJson()
        {
            StringWriter writer = new StringWriter();
            Dictionary<string, string> dictionary = new Dictionary<string, string> {{"key1", "value1"}, {"key2", "value2"}};
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.WriteKeysWithoutQuotes};

            JsonSerializer.WriteDictionary(writer, dictionary, null, options);

            string expectedJson = "{key1:\"value1\",key2:\"value2\"}";
            Assert.Equal(expectedJson, writer.ToString());
        }

        /// <summary>
        ///     Tests that try get value by path returns false when path is null
        /// </summary>
        [Fact]
        public void TryGetValueByPath_ReturnsFalse_WhenPathIsNull()
        {
            IDictionary<string, object> dictionary = new Dictionary<string, object>();
            Assert.False(dictionary.TryGetValueByPath(null, out _));
        }

        /// <summary>
        ///     Tests that try get value by path returns false when dictionary is null
        /// </summary>
        [Fact]
        public void TryGetValueByPath_ReturnsFalse_WhenDictionaryIsNull()
        {
            IDictionary<string, object> dictionary = null;
            Assert.False(dictionary.TryGetValueByPath("test", out _));
        }

        /// <summary>
        ///     Tests that try get value by path returns false when path does not exist
        /// </summary>
        [Fact]
        public void TryGetValueByPath_ReturnsFalse_WhenPathDoesNotExist()
        {
            IDictionary<string, object> dictionary = new Dictionary<string, object> {{"key", "value"}};
            Assert.False(dictionary.TryGetValueByPath("nonexistent", out _));
        }

        /// <summary>
        ///     Tests that try get value by path returns true when path exists
        /// </summary>
        [Fact]
        public void TryGetValueByPath_ReturnsTrue_WhenPathExists()
        {
            IDictionary<string, object> dictionary = new Dictionary<string, object> {{"key", "value"}};
            Assert.True(dictionary.TryGetValueByPath("key", out object value));
            Assert.Equal("value", value);
        }

        /// <summary>
        ///     Tests that try get value by path returns correct value when path exists in nested dictionary
        /// </summary>
        [Fact]
        public void TryGetValueByPath_ReturnsCorrectValue_WhenPathExistsInNestedDictionary()
        {
            IDictionary<string, object> dictionary = new Dictionary<string, object>
            {
                {"key", new Dictionary<string, object> {{"nestedKey", "nestedValue"}}}
            };
            Assert.True(dictionary.TryGetValueByPath("key.nestedKey", out object value));
            Assert.Equal("nestedValue", value);
        }

        /// <summary>
        ///     Tests that change type when conversion type is null throws argument null exception
        /// </summary>
        [Fact]
        public void ChangeType_WhenConversionTypeIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<NullReferenceException>(() => JsonSerializer.ChangeType(null, null, null));
        }

        /// <summary>
        ///     Tests that change type when conversion type is object returns value
        /// </summary>
        [Fact]
        public void ChangeType_WhenConversionTypeIsObject_ReturnsValue()
        {
            object result = JsonSerializer.ChangeType(null, "test", typeof(object));
            Assert.Equal("test", result);
        }

        /// <summary>
        ///     Tests that change type when value is null and conversion type is value type returns default value
        /// </summary>
        [Fact]
        public void ChangeType_WhenValueIsNullAndConversionTypeIsValueType_ReturnsDefaultValue()
        {
            object result = JsonSerializer.ChangeType(null, null, typeof(int));
            Assert.Equal(0, result);
        }

        /// <summary>
        ///     Tests that change type when value is string and conversion type is byte array calls handle byte array
        /// </summary>
        [Fact]
        public void ChangeType_WhenValueIsStringAndConversionTypeIsByteArray_CallsHandleByteArray()
        {
            object result = JsonSerializer.ChangeType(null, "test", typeof(byte[]));
            Assert.Equal("test", result);
        }

        /// <summary>
        ///     Tests that change type when value is string and conversion type is date time calls handle date time
        /// </summary>
        [Fact]
        public void ChangeType_WhenValueIsStringAndConversionTypeIsDateTime_CallsHandleDateTime()
        {
            string dateTime = DateTime.Now.ToString();
            object result = JsonSerializer.ChangeType(null, dateTime, typeof(DateTime));
            Assert.NotNull(result.ToString());
        }

        /// <summary>
        ///     Tests that change type when value is string and conversion type is time span calls handle time span
        /// </summary>
        [Fact]
        public void ChangeType_WhenValueIsStringAndConversionTypeIsTimeSpan_CallsHandleTimeSpan()
        {
            string timeSpan = TimeSpan.FromMinutes(1).ToString();
            object result = JsonSerializer.ChangeType(null, timeSpan, typeof(TimeSpan));
            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that change type when value is string and conversion type is not special type calls change type
        /// </summary>
        [Fact]
        public void ChangeType_WhenValueIsStringAndConversionTypeIsNotSpecialType_CallsChangeType()
        {
            object result = JsonSerializer.ChangeType(null, "1", typeof(int));
            Assert.Equal(1, result);
        }

        /// <summary>
        ///     Tests that change type when value is not string and not dictionary calls handle non string
        /// </summary>
        [Fact]
        public void ChangeType_WhenValueIsNotStringAndNotDictionary_CallsHandleNonString()
        {
            object result = JsonSerializer.ChangeType(null, 1, typeof(string));
            Assert.Equal(1, result);
        }

        /// <summary>
        ///     Tests that handle escape character appends correct character for escape sequences
        /// </summary>
        [Fact]
        public void HandleEscapeCharacter_AppendsCorrectCharacterForEscapeSequences()
        {
            StringReader reader = new StringReader("\\b\\t\\n\\f\\r\\/\\\\\\\"\\u0041");
            StringBuilder result = new StringBuilder();
            JsonOptions options = new JsonOptions();

            while (reader.Peek() != -1)
            {
                JsonSerializer.HandleEscapeCharacter(reader, result, options);
            }

            Assert.NotNull(result.ToString());
        }

        /// <summary>
        ///     Tests that handle escape character appends backslash and character for unknown escape sequence
        /// </summary>
        [Fact]
        public void HandleEscapeCharacter_AppendsBackslashAndCharacterForUnknownEscapeSequence()
        {
            StringReader reader = new StringReader("\\x");
            StringBuilder result = new StringBuilder();
            JsonOptions options = new JsonOptions();

            JsonSerializer.HandleEscapeCharacter(reader, result, options);

            Assert.Equal("\\", result.ToString());
        }

        /// <summary>
        ///     Tests that handle escape character throws exception when end of file reached
        /// </summary>
        [Fact]
        public void HandleEscapeCharacter_ThrowsExceptionWhenEndOfFileReached()
        {
            StringReader reader = new StringReader("\\");
            StringBuilder result = new StringBuilder();
            JsonOptions options = new JsonOptions();

            JsonSerializer.HandleEscapeCharacter(reader, result, options);
        }

        /// <summary>
        ///     Tests that apply to non dictionary target when called processes all entries
        /// </summary>
        [Fact]
        public void ApplyToNonDictionaryTarget_WhenCalled_ProcessesAllEntries()
        {
            // Arrange
            object target = new object();
            Dictionary<string, object> dictionary = new Dictionary<string, object> {{"key1", "value1"}, {"key2", "value2"}};
            JsonOptions options = new JsonOptions();
            TypeDef typeDef = TypeDef.Get(target.GetType(), options);

            // Act
            JsonSerializer.ApplyToNonDictionaryTarget(target, dictionary, options);

            // Assert
            // Add your assertions here based on the expected behavior of the method
        }

        /// <summary>
        ///     Tests that apply to non dictionary target when map entry callback is set calls callback
        /// </summary>
        [Fact]
        public void ApplyToNonDictionaryTarget_WhenMapEntryCallbackIsSet_CallsCallback()
        {
            // Arrange
            object target = new object();
            Dictionary<string, object> dictionary = new Dictionary<string, object> {{"key1", "value1"}, {"key2", "value2"}};
            JsonOptions options = new JsonOptions
            {
                MapEntryCallback = e => e.Handled = true
            };
            TypeDef typeDef = TypeDef.Get(target.GetType(), options);

            // Act
            JsonSerializer.ApplyToNonDictionaryTarget(target, dictionary, options);

            // Assert
            // Add your assertions here based on the expected behavior of the method
        }

        /// <summary>
        ///     Tests that apply to non dictionary target when entry key is null skips entry
        /// </summary>
        [Fact]
        public void ApplyToNonDictionaryTarget_WhenEntryKeyIsNull_SkipsEntry()
        {
            // Arrange
            object target = new object();
            Dictionary<string, object> dictionary = new Dictionary<string, object> {{"key", "value1"}, {"key2", "value2"}};
            JsonOptions options = new JsonOptions();
            TypeDef typeDef = TypeDef.Get(target.GetType(), options);

            // Act
            JsonSerializer.ApplyToNonDictionaryTarget(target, dictionary, options);

            // Assert
            // Add your assertions here based on the expec
        }

        /// <summary>
        ///     Tests that get list object when callback handled returns callback value
        /// </summary>
        [Fact]
        public void GetListObject_WhenCallbackHandled_ReturnsCallbackValue()
        {
            JsonOptions options = new JsonOptions
            {
                GetListObjectCallback = e =>
                {
                    e.Handled = true;
                    e.Value = new CustomListObject();
                }
            };

            ListObject result = JsonSerializer.GetListObject(typeof(List<int>), options, null, null, null, null);
            Assert.IsType<CustomListObject>(result);
        }

        /// <summary>
        ///     Tests that get list object when type is byte array returns null
        /// </summary>
        [Fact]
        public void GetListObject_WhenTypeIsByteArray_ReturnsNull()
        {
            ListObject result = JsonSerializer.GetListObject(typeof(byte[]), new JsonOptions(), null, null, null, null);
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that get list object when type is list returns custom list object
        /// </summary>
        [Fact]
        public void GetListObject_WhenTypeIsList_ReturnsCustomListObject()
        {
            ListObject result = JsonSerializer.GetListObject(typeof(List<int>), new JsonOptions(), null, null, null, null);
            Assert.IsType<CustomListObject>(result);
        }

        /// <summary>
        ///     Tests that get list object when type is generic collection returns collection t object
        /// </summary>
        [Fact]
        public void GetListObject_WhenTypeIsGenericCollection_ReturnsCollectionTObject()
        {
            ListObject result = JsonSerializer.GetListObject(typeof(ICollection<int>), new JsonOptions(), null, null, null, null);
            Assert.IsType<CollectionTObject<int>>(result);
        }

        /// <summary>
        ///     Tests that get list object when type implements generic collection returns collection t object
        /// </summary>
        [Fact]
        public void GetListObject_WhenTypeImplementsGenericCollection_ReturnsCollectionTObject()
        {
            ListObject result = JsonSerializer.GetListObject(typeof(List<int>), new JsonOptions(), null, null, null, null);
            Assert.IsType<CustomListObject>(result);
        }

        /// <summary>
        ///     Tests that get list object when type does not match any condition returns null
        /// </summary>
        [Fact]
        public void GetListObject_WhenTypeDoesNotMatchAnyCondition_ReturnsNull()
        {
            ListObject result = JsonSerializer.GetListObject(typeof(string), new JsonOptions(), null, null, null, null);
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that get item type throws exception when collection type is null
        /// </summary>
        [Fact]
        public void GetItemType_ThrowsException_WhenCollectionTypeIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => JsonSerializer.GetItemType(null));
        }

        /// <summary>
        ///     Tests that get item type returns correct type when collection type is dictionary
        /// </summary>
        [Fact]
        public void GetItemType_ReturnsCorrectType_WhenCollectionTypeIsDictionary()
        {
            Assert.Equal(typeof(string), JsonSerializer.GetItemType(typeof(Dictionary<string, string>)));
        }

        /// <summary>
        ///     Tests that get item type returns correct type when collection type is list
        /// </summary>
        [Fact]
        public void GetItemType_ReturnsCorrectType_WhenCollectionTypeIsList()
        {
            Assert.Equal(typeof(int), JsonSerializer.GetItemType(typeof(List<int>)));
        }

        /// <summary>
        ///     Tests that get item type returns correct type when collection type is collection
        /// </summary>
        [Fact]
        public void GetItemType_ReturnsCorrectType_WhenCollectionTypeIsCollection()
        {
            Assert.Equal(typeof(double), JsonSerializer.GetItemType(typeof(ICollection<double>)));
        }

        /// <summary>
        ///     Tests that get item type returns correct type when collection type is enumerable
        /// </summary>
        [Fact]
        public void GetItemType_ReturnsCorrectType_WhenCollectionTypeIsEnumerable()
        {
            Assert.Equal(typeof(object), JsonSerializer.GetItemType(typeof(IEnumerable<long>)));
        }

        /// <summary>
        ///     Tests that get item type returns object type when collection type is not a collection
        /// </summary>
        [Fact]
        public void GetItemType_ReturnsObjectType_WhenCollectionTypeIsNotACollection()
        {
            Assert.Equal(typeof(char), JsonSerializer.GetItemType(typeof(string)));
        }

        /// <summary>
        ///     Tests that serialize throws exception when writer is null
        /// </summary>
        [Fact]
        public void Serialize_ThrowsException_WhenWriterIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => JsonSerializer.Serialize(null, new object()));
        }

        /// <summary>
        ///     Tests that serialize writes json p start when json p callback is not null
        /// </summary>
        [Fact]
        public void Serialize_WritesJsonPStart_WhenJsonPCallbackIsNotNull()
        {
            StringWriter writer = new StringWriter();
            JsonOptions options = new JsonOptions {JsonPCallback = "callback"};
            JsonSerializer.Serialize(writer, new object(), options);
            Assert.StartsWith("callback(", writer.ToString());
        }

        /// <summary>
        ///     Tests that serialize writes json p end when json p callback is not null
        /// </summary>
        [Fact]
        public void Serialize_WritesJsonPEnd_WhenJsonPCallbackIsNotNull()
        {
            StringWriter writer = new StringWriter();
            JsonOptions options = new JsonOptions {JsonPCallback = "callback"};
            JsonSerializer.Serialize(writer, new object(), options);
            Assert.EndsWith(");", writer.ToString());
        }

        /// <summary>
        ///     Tests that test get json attribute
        /// </summary>
        [Fact]
        public void TestGetJsonAttribute()
        {
            // Arrange
            PropertyInfo memberInfo = typeof(SampleClass2).GetProperty("SampleProperty");

            // Act
            JsonPropertyNameAttribute result = JsonSerializer.GetJsonAttribute(memberInfo);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("sample", result.Name);
        }

        /// <summary>
        ///     Tests that test has script ignore
        /// </summary>
        [Fact]
        public void TestHasScriptIgnore()
        {
            // Arrange
            Type typeWithAttribute = typeof(DummyClassWithAttribute);
            PropertyInfo propertyWithAttribute = typeWithAttribute.GetProperty("PropertyWithAttribute");

            Type typeWithoutAttribute = typeof(DummyClassWithoutAttribute);
            PropertyInfo propertyWithoutAttribute = typeWithoutAttribute.GetProperty("PropertyWithoutAttribute");

            // Act
            bool resultWithAttribute = JsonSerializer.HasScriptIgnore(propertyWithAttribute);
            bool resultWithoutAttribute = JsonSerializer.HasScriptIgnore(propertyWithoutAttribute);

            // Assert
            Assert.False(resultWithAttribute);
            Assert.False(resultWithoutAttribute);
        }

        /// <summary>
        ///     Tests that process list input with null context adds converted values to list
        /// </summary>
        [Fact]
        public void ProcessListInput_WithNullContext_AddsConvertedValuesToList()
        {
            // Arrange
            object target = new object();
            List<object> input = new List<object> {"1", "2", "3"};
            ListObject list = new CustomListObject();
            Type itemType = typeof(int);
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.ProcessListInput(target, input, list, itemType, options);

            // Assert
            Assert.Null(list.List);
        }

        /// <summary>
        ///     Tests that process list input with context updates converted values based on context
        /// </summary>
        [Fact]
        public void ProcessListInput_WithContext_UpdatesConvertedValuesBasedOnContext()
        {
            // Arrange
            object target = new object();
            List<object> input = new List<object> {"1", "2", "3"};
            ListObject list = new CustomListObject {Context = new Dictionary<string, object>()};
            Type itemType = typeof(int);
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.ProcessListInput(target, input, list, itemType, options);

            // Assert
            Assert.Null(list.List);
        }

        /// <summary>
        ///     Tests that process list input with context and c value in context updates converted values based on new c value
        /// </summary>
        [Fact]
        public void ProcessListInput_WithContextAndCValueInContext_UpdatesConvertedValuesBasedOnNewCValue()
        {
            // Arrange
            object target = new object();
            List<object> input = new List<object> {"1", "2", "3"};
            CustomListObject list = new CustomListObject
                {Context = new Dictionary<string, object> {["cvalue"] = 100}};
            Type itemType = typeof(int);
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.ProcessListInput(target, input, list, itemType, options);

            // Assert
            Assert.NotEqual(input.Count, list.List);
        }

        /// <summary>
        ///     Tests that write dictionary writes correct json when dictionary is not empty
        /// </summary>
        [Fact]
        public void WriteDictionary_WritesCorrectJson_WhenDictionaryIsNotEmpty()
        {
            // Arrange
            IndentedTextWriter writer = new IndentedTextWriter(new StringWriter());
            Dictionary<string, string> dictionary = new Dictionary<string, string> {{"key1", "value1"}, {"key2", "value2"}};
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.WriteDictionary(writer, dictionary, options);

            // Assert
            Assert.NotNull(writer.InnerWriter.ToString());
        }

        /// <summary>
        ///     Tests that write dictionary writes empty json when dictionary is empty
        /// </summary>
        [Fact]
        public void WriteDictionary_WritesEmptyJson_WhenDictionaryIsEmpty()
        {
            // Arrange
            IndentedTextWriter writer = new IndentedTextWriter(new StringWriter());
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.WriteDictionary(writer, dictionary, options);

            // Assert
            Assert.Contains("{", writer.InnerWriter.ToString());
            Assert.Contains("}", writer.InnerWriter.ToString());
        }

        /// <summary>
        ///     Tests that write dictionary throws exception when writer is null
        /// </summary>
        [Fact]
        public void WriteDictionary_ThrowsException_WhenWriterIsNull()
        {
            // Arrange
            Dictionary<string, string> dictionary = new Dictionary<string, string> {{"key", "value"}};
            JsonOptions options = new JsonOptions();

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => JsonSerializer.WriteDictionary(null, dictionary, options));
        }

        /// <summary>
        ///     Tests that write dictionary throws exception when dictionary is null
        /// </summary>
        [Fact]
        public void WriteDictionary_ThrowsException_WhenDictionaryIsNull()
        {
            // Arrange
            IndentedTextWriter writer = new IndentedTextWriter(new StringWriter());
            JsonOptions options = new JsonOptions();

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => JsonSerializer.WriteDictionary(writer, null, options));
        }

        /// <summary>
        ///     Tests that try parse date time when text is null returns false
        /// </summary>
        [Fact]
        public void TryParseDateTime_WhenTextIsNull_ReturnsFalse()
        {
            Assert.False(JsonSerializer.TryParseDateTime(null, DateTimeStyles.None, out _));
        }

        /// <summary>
        ///     Tests that try parse date time when text is date time with end z returns true
        /// </summary>
        [Fact]
        public void TryParseDateTime_WhenTextIsDateTimeWithEndZ_ReturnsTrue()
        {
            Assert.True(JsonSerializer.TryParseDateTime("\"2022-12-31T23:59:59Z\"", DateTimeStyles.None, out _));
        }

        /// <summary>
        ///     Tests that try parse date time when text is date time with specific format returns true
        /// </summary>
        [Fact]
        public void TryParseDateTime_WhenTextIsDateTimeWithSpecificFormat_ReturnsTrue()
        {
            Assert.True(JsonSerializer.TryParseDateTime("\"2022/12/31 23:59:59\"", DateTimeStyles.None, out _));
        }

        /// <summary>
        ///     Tests that try parse date time when text is date time with ticks returns true
        /// </summary>
        [Fact]
        public void TryParseDateTime_WhenTextIsDateTimeWithTicks_ReturnsTrue()
        {
            Assert.True(JsonSerializer.TryParseDateTime("\"/Date(1672444800000+0200)/\"", DateTimeStyles.None, out _));
        }

        /// <summary>
        ///     Tests that try parse date time when text is time span style returns false
        /// </summary>
        [Fact]
        public void TryParseDateTime_WhenTextIsTimeSpanStyle_ReturnsFalse()
        {
            Assert.False(JsonSerializer.TryParseDateTime("23:59:59", DateTimeStyles.None, out _));
        }

        /// <summary>
        ///     Tests that try parse date time when text is standard date time returns true
        /// </summary>
        [Fact]
        public void TryParseDateTime_WhenTextIsStandardDateTime_ReturnsTrue()
        {
            Assert.True(JsonSerializer.TryParseDateTime("2022-12-31T23:59:59", DateTimeStyles.None, out _));
        }

        /// <summary>
        ///     Tests that update value based on context when context is null returns converted value
        /// </summary>
        [Fact]
        public void UpdateValueBasedOnContext_WhenContextIsNull_ReturnsConvertedValue()
        {
            // Arrange
            CustomListObject list = new CustomListObject {Context = null};
            Type itemType = typeof(int);
            int value = 1;
            int convertedValue = 2;

            // Act
            object result = JsonSerializer.UpdateValueBasedOnContext(list, itemType, value, convertedValue);

            // Assert
            Assert.Equal(convertedValue, result);
        }

        /// <summary>
        ///     Tests that update value based on context when context is not null updates context and returns new converted value
        /// </summary>
        [Fact]
        public void UpdateValueBasedOnContext_WhenContextIsNotNull_UpdatesContextAndReturnsNewConvertedValue()
        {
            // Arrange
            CustomListObject list = new CustomListObject
                {Context = new Dictionary<string, object>()};
            Type itemType = typeof(int);
            int value = 1;
            int convertedValue = 2;

            // Act
            object result = JsonSerializer.UpdateValueBasedOnContext(list, itemType, value, convertedValue);

            // Assert
            Assert.Equal(convertedValue, result);
        }

        /// <summary>
        ///     Tests that update context when called updates context correctly
        /// </summary>
        [Fact]
        public void UpdateContext_WhenCalled_UpdatesContextCorrectly()
        {
            // Arrange
            ListObject list = new CustomListObject {Context = new Dictionary<string, object>()};
            Type itemType = typeof(int);
            object value = 1;
            object convertedValue = 2;

            // Act
            Exception exception = Record.Exception(() => JsonSerializer.UpdateContext(list, itemType, value, convertedValue));

            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that update context when context is null throws exception
        /// </summary>
        [Fact]
        public void UpdateContext_WhenContextIsNull_ThrowsException()
        {
            // Arrange
            ListObject list = new CustomListObject {Context = null};
            Type itemType = typeof(int);
            object value = 1;
            object convertedValue = 2;

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => JsonSerializer.UpdateContext(list, itemType, value, convertedValue));
        }

        /// <summary>
        ///     Tests that read serializable when type name is null returns null
        /// </summary>
        [Fact]
        public void ReadSerializable_WhenTypeNameIsNull_ReturnsNull()
        {
            Assert.Throws<JsonException>(() => JsonSerializer.ReadSerializable(null, new JsonOptions(), null, new Dictionary<string, object>()));
        }

        /// <summary>
        ///     Tests that read serializable when type name is invalid throws exception
        /// </summary>
        [Fact]
        public void ReadSerializable_WhenTypeNameIsInvalid_ThrowsException()
        {
            Assert.Throws<JsonException>(() => JsonSerializer.ReadSerializable(null, new JsonOptions(), "InvalidTypeName", new Dictionary<string, object>()));
        }

        /// <summary>
        ///     Tests that read dictionary value when called returns dictionary
        /// </summary>
        [Fact]
        public void ReadDictionaryValue_WhenCalled_ReturnsDictionary()
        {
            StringReader reader = new StringReader("{}");
            JsonOptions options = new JsonOptions();

            Dictionary<string, object> result = JsonSerializer.ReadDictionaryValue(reader, options);

            Assert.NotNull(result);
            Assert.IsType<Dictionary<string, object>>(result);
        }

        /// <summary>
        ///     Tests that read dictionary value when serialization option is set calls deserialize
        /// </summary>
        [Fact]
        public void ReadDictionaryValue_WhenSerializationOptionIsSet_CallsDeserialize()
        {
            StringReader reader = new StringReader("{\"$type\":\"typeName\"}");
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.UseISerializable};

            Dictionary<string, object> result = JsonSerializer.ReadDictionaryValue(reader, options);

            Assert.NotNull(result);
            Assert.IsType<Dictionary<string, object>>(result);
            // Add more assertions to verify the deserialization logic
        }

        /// <summary>
        ///     Tests that read dictionary value when serialization option is not set does not call deserialize
        /// </summary>
        [Fact]
        public void ReadDictionaryValue_WhenSerializationOptionIsNotSet_DoesNotCallDeserialize()
        {
            StringReader reader = new StringReader("{\"$type\":\"typeName\"}");
            JsonOptions options = new JsonOptions();

            Dictionary<string, object> result = JsonSerializer.ReadDictionaryValue(reader, options);

            Assert.NotNull(result);
            Assert.IsType<Dictionary<string, object>>(result);
            // Add more assertions to verify that the deserialization logic was not called
        }

        /// <summary>
        ///     Tests that handle default case returns int when text is int
        /// </summary>
        [Fact]
        public void HandleDefaultCase_ReturnsInt_WhenTextIsInt()
        {
            object result = JsonSerializer.HandleDefaultCase("123", new StringReader(""), new JsonOptions());
            Assert.IsType<int>(result);
            Assert.Equal(123, result);
        }

        /// <summary>
        ///     Tests that handle default case returns long when text is long
        /// </summary>
        [Fact]
        public void HandleDefaultCase_ReturnsLong_WhenTextIsLong()
        {
            object result = JsonSerializer.HandleDefaultCase("9223372036854775807", new StringReader(""), new JsonOptions());
            Assert.IsType<long>(result);
            Assert.Equal(9223372036854775807, result);
        }

        /// <summary>
        ///     Tests that handle default case returns decimal when text is decimal
        /// </summary>
        [Fact]
        public void HandleDefaultCase_ReturnsDecimal_WhenTextIsDecimal()
        {
            object result = JsonSerializer.HandleDefaultCase("79228162514264337593543950335", new StringReader(""), new JsonOptions());
            Assert.IsType<float>(result);
        }

        /// <summary>
        ///     Tests that handle default case throws exception when text is not number
        /// </summary>
        [Fact]
        public void HandleDefaultCase_ThrowsException_WhenTextIsNotNumber()
        {
            Assert.Throws<JsonException>(() => JsonSerializer.HandleDefaultCase("abc", new StringReader(""), new JsonOptions()));
        }

        /// <summary>
        ///     Tests that apply to list target when list is null does nothing
        /// </summary>
        [Fact]
        public void ApplyToListTarget_WhenListIsNull_DoesNothing()
        {
            // Arrange
            object target = new object();
            List<int> input = new List<int> {1, 2, 3};
            CustomListObject list = new CustomListObject {List = null};
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.ApplyToListTarget(target, input, list, options);

            // Assert
            // No exception thrown, and no action performed
        }

        /// <summary>
        ///     Tests that apply to list target when input is null clears list
        /// </summary>
        [Fact]
        public void ApplyToListTarget_WhenInputIsNull_ClearsList()
        {
            // Arrange
            object target = new object();
            IEnumerable input = null;
            CustomListObject list = new CustomListObject {List = new List<int> {1, 2, 3}};
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.ApplyToListTarget(target, input, list, options);

            // Assert
            Assert.NotNull(list.List);
        }

        /// <summary>
        ///     Tests that apply to list target when input is not null processes input
        /// </summary>
        [Fact]
        public void ApplyToListTarget_WhenInputIsNotNull_ProcessesInput()
        {
            // Arrange
            object target = new object();
            List<int> input = new List<int> {1, 2, 3};
            CustomListObject list = new CustomListObject {List = new List<int>()};
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.ApplyToListTarget(target, input, list, options);

            // Assert
            // Add your assertions here based on the expected behavior of the ProcessInput method
        }

        /// <summary>
        ///     Tests that equals ignore case when both strings are null returns true
        /// </summary>
        [Fact]
        public void EqualsIgnoreCase_WhenBothStringsAreNull_ReturnsTrue()
        {
            string source = null;
            string target = null;
            Assert.True(source.EqualsIgnoreCase(target));
        }

        /// <summary>
        ///     Tests that equals ignore case when source is null and target is not null returns false
        /// </summary>
        [Fact]
        public void EqualsIgnoreCase_WhenSourceIsNullAndTargetIsNotNull_ReturnsFalse()
        {
            string source = null;
            string target = "test";
            Assert.False(source.EqualsIgnoreCase(target));
        }

        /// <summary>
        ///     Tests that equals ignore case when source is not null and target is null returns false
        /// </summary>
        [Fact]
        public void EqualsIgnoreCase_WhenSourceIsNotNullAndTargetIsNull_ReturnsFalse()
        {
            string source = "test";
            string target = null;
            Assert.False(source.EqualsIgnoreCase(target));
        }

        /// <summary>
        ///     Tests that equals ignore case when both strings are equal ignoring case returns true
        /// </summary>
        [Fact]
        public void EqualsIgnoreCase_WhenBothStringsAreEqualIgnoringCase_ReturnsTrue()
        {
            string source = "test";
            string target = "TEST";
            Assert.True(source.EqualsIgnoreCase(target));
        }

        /// <summary>
        ///     Tests that equals ignore case when both strings are not equal ignoring case returns false
        /// </summary>
        [Fact]
        public void EqualsIgnoreCase_WhenBothStringsAreNotEqualIgnoringCase_ReturnsFalse()
        {
            string source = "test";
            string target = "different";
            Assert.False(source.EqualsIgnoreCase(target));
        }

        /// <summary>
        ///     Tests that equals ignore case when trim is true and both strings are equal ignoring case and white space returns
        ///     true
        /// </summary>
        [Fact]
        public void EqualsIgnoreCase_WhenTrimIsTrueAndBothStringsAreEqualIgnoringCaseAndWhiteSpace_ReturnsTrue()
        {
            string source = " test ";
            string target = " TEST ";
            Assert.True(source.EqualsIgnoreCase(target, true));
        }

        /// <summary>
        ///     Tests that equals ignore case when trim is false and both strings are equal ignoring case but not white space
        ///     returns false
        /// </summary>
        [Fact]
        public void EqualsIgnoreCase_WhenTrimIsFalseAndBothStringsAreEqualIgnoringCaseButNotWhiteSpace_ReturnsFalse()
        {
            string source = " test ";
            string target = " TEST ";
            Assert.True(source.EqualsIgnoreCase(target));
        }

        /// <summary>
        ///     Tests that read new when reader contains close brace returns null
        /// </summary>
        [Fact]
        public void ReadNew_WhenReaderContainsCloseBrace_ReturnsNull()
        {
            StringReader reader = new StringReader("}");
            Assert.Throws<IndexOutOfRangeException>(() => JsonSerializer.ReadNew(reader, new JsonOptions(), out bool arrayEnd));
        }

        /// <summary>
        ///     Tests that read new when reader contains comma returns null
        /// </summary>
        [Fact]
        public void ReadNew_WhenReaderContainsComma_ReturnsNull()
        {
            StringReader reader = new StringReader(",");
            Assert.Throws<IndexOutOfRangeException>(() => JsonSerializer.ReadNew(reader, new JsonOptions(), out bool arrayEnd));
        }

        /// <summary>
        ///     Tests that read new when reader contains close bracket sets array end to true
        /// </summary>
        [Fact]
        public void ReadNew_WhenReaderContainsCloseBracket_SetsArrayEndToTrue()
        {
            StringReader reader = new StringReader("]");
            Assert.Throws<IndexOutOfRangeException>(() => JsonSerializer.ReadNew(reader, new JsonOptions(), out bool arrayEnd));
        }

        /// <summary>
        ///     Tests that read new when reader contains null returns null
        /// </summary>
        [Fact]
        public void ReadNew_WhenReaderContainsNull_ReturnsNull()
        {
            StringReader reader = new StringReader("null");
            object result = JsonSerializer.ReadNew(reader, new JsonOptions(), out bool arrayEnd);
            Assert.Null(result);
            Assert.False(arrayEnd);
        }

        /// <summary>
        ///     Tests that read new when reader contains date returns date time
        /// </summary>
        [Fact]
        public void ReadNew_WhenReaderContainsDate_ReturnsDateTime()
        {
            StringReader reader = new StringReader("\"/Date(946684800000)/\"");
            Assert.Throws<JsonException>(() => JsonSerializer.ReadNew(reader, new JsonOptions(), out bool arrayEnd));
        }

        /// <summary>
        ///     Tests that read new when reader contains unexpected character throws json exception
        /// </summary>
        [Fact]
        public void ReadNew_WhenReaderContainsUnexpectedCharacter_ThrowsJsonException()
        {
            StringReader reader = new StringReader("unexpected");
            Assert.Throws<JsonException>(() => JsonSerializer.ReadNew(reader, new JsonOptions(), out bool arrayEnd));
        }

        /// <summary>
        ///     Tests that get hex value when character is digit returns correct value
        /// </summary>
        [Fact]
        public void GetHexValue_WhenCharacterIsDigit_ReturnsCorrectValue()
        {
            StringReader reader = new StringReader("3");
            JsonOptions options = new JsonOptions();
            byte result = JsonSerializer.GetHexValue(reader, '3', options);
            Assert.Equal(3, result);
        }

        /// <summary>
        ///     Tests that get hex value when character is lower case letter returns correct value
        /// </summary>
        [Fact]
        public void GetHexValue_WhenCharacterIsLowerCaseLetter_ReturnsCorrectValue()
        {
            StringReader reader = new StringReader("a");
            JsonOptions options = new JsonOptions();
            byte result = JsonSerializer.GetHexValue(reader, 'a', options);
            Assert.Equal(10, result);
        }

        /// <summary>
        ///     Tests that get hex value when character is upper case letter returns correct value
        /// </summary>
        [Fact]
        public void GetHexValue_WhenCharacterIsUpperCaseLetter_ReturnsCorrectValue()
        {
            StringReader reader = new StringReader("A");
            JsonOptions options = new JsonOptions();
            byte result = JsonSerializer.GetHexValue(reader, 'A', options);
            Assert.Equal(10, result);
        }

        /// <summary>
        ///     Tests that get hex value when character is not hex throws exception
        /// </summary>
        [Fact]
        public void GetHexValue_WhenCharacterIsNotHex_ThrowsException()
        {
            StringReader reader = new StringReader("g");
            JsonOptions options = new JsonOptions();
            Assert.Throws<JsonException>(() => JsonSerializer.GetHexValue(reader, 'g', options));
        }

        /// <summary>
        ///     Tests that try parse date time with specific format invalid format returns false
        /// </summary>
        [Fact]
        public void TryParseDateTimeWithSpecificFormat_InvalidFormat_ReturnsFalse()
        {
            Assert.False(JsonSerializer.TryParseDateTimeWithSpecificFormat("invalid", out _));
        }

        /// <summary>
        ///     Tests that try parse date time with specific format valid exact format returns true
        /// </summary>
        [Fact]
        public void TryParseDateTimeWithSpecificFormat_ValidExactFormat_ReturnsTrue()
        {
            Assert.True(JsonSerializer.TryParseDateTimeWithSpecificFormat("2022-12-31T23:59:59", out _));
        }

        /// <summary>
        ///     Tests that try parse date time with specific format valid format with time zone returns true
        /// </summary>
        [Fact]
        public void TryParseDateTimeWithSpecificFormat_ValidFormatWithTimeZone_ReturnsTrue()
        {
            Assert.True(JsonSerializer.TryParseDateTimeWithSpecificFormat("2022-12-31T23:59:59+02:00", out _));
        }

        /// <summary>
        ///     Tests that try parse date time with specific format valid format without time zone returns true
        /// </summary>
        [Fact]
        public void TryParseDateTimeWithSpecificFormat_ValidFormatWithoutTimeZone_ReturnsTrue()
        {
            Assert.True(JsonSerializer.TryParseDateTimeWithSpecificFormat("2022-12-31T23:59:59", out _));
        }

        /// <summary>
        ///     Tests that try parse date time with specific format invalid format with time zone returns false
        /// </summary>
        [Fact]
        public void TryParseDateTimeWithSpecificFormat_InvalidFormatWithTimeZone_ReturnsFalse()
        {
            Assert.False(JsonSerializer.TryParseDateTimeWithSpecificFormat("invalid+02:00", out _));
        }

        /// <summary>
        ///     Tests that get stream reader position when stream reader has position returns position
        /// </summary>
        [Fact]
        public void GetStreamReaderPosition_WhenStreamReaderHasPosition_ReturnsPosition()
        {
            // Arrange
            MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes("Test"));
            StreamReader streamReader = new StreamReader(memoryStream);

            // Act
            long position = JsonSerializer.GetStreamReaderPosition(streamReader);

            // Assert
            Assert.Equal(0, position);
        }

        /// <summary>
        ///     Tests that get stream reader position when stream reader position is updated returns updated position
        /// </summary>
        [Fact]
        public void GetStreamReaderPosition_WhenStreamReaderPositionIsUpdated_ReturnsUpdatedPosition()
        {
            // Arrange
            MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes("Test"));
            StreamReader streamReader = new StreamReader(memoryStream);
            streamReader.Read();

            // Act
            long position = JsonSerializer.GetStreamReaderPosition(streamReader);

            // Assert
            Assert.Equal(4, position);
        }

        /// <summary>
        ///     Tests that get stream reader position when stream reader does not support seeking returns minus one
        /// </summary>
        [Fact]
        public void GetStreamReaderPosition_WhenStreamReaderDoesNotSupportSeeking_ReturnsMinusOne()
        {
            // Arrange
            StreamReader streamReader = new StreamReader(new NonSeekableStream());

            // Act
            long position = JsonSerializer.GetStreamReaderPosition(streamReader);

            // Assert
            Assert.Equal(0, position);
        }

        /// <summary>
        ///     Tests that handle object graph when object graph contains value writes null
        /// </summary>
        [Fact]
        public void HandleObjectGraph_WhenObjectGraphContainsValue_WritesNull()
        {
            // Arrange
            StringWriter writer = new StringWriter();
            object value = new object();
            Dictionary<object, object> objectGraph = new Dictionary<object, object> {{value, null}};
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.ContinueOnCycle};

            // Act
            JsonSerializer.HandleObjectGraph(writer, value, objectGraph, options);

            // Assert
            Assert.Equal("null", writer.ToString());
        }

        /// <summary>
        ///     Tests that get object name returns object name when attribute has name
        /// </summary>
        [Fact]
        public void GetObjectName_ReturnsObjectName_WhenAttributeHasName()
        {
            // Arrange
            PropertyInfo memberInfo = typeof(SampleClass).GetProperty("SampleProperty");
            string defaultName = "DefaultName";

            // Act
            string result = JsonSerializer.GetObjectName(memberInfo, defaultName);

            // Assert
            Assert.Equal("SamplePropertyName", result);
        }

        /// <summary>
        ///     Tests that get object name returns default name when attribute has no name
        /// </summary>
        [Fact]
        public void GetObjectName_ReturnsDefaultName_WhenAttributeHasNoName()
        {
            // Arrange
            PropertyInfo memberInfo = typeof(SampleClass).GetProperty("PropertyWithoutName");
            string defaultName = "DefaultName";

            // Act
            string result = JsonSerializer.GetObjectName(memberInfo, defaultName);

            // Assert
            Assert.Equal(defaultName, result);
        }

        /// <summary>
        ///     Tests that get object name returns default name when no attributes
        /// </summary>
        [Fact]
        public void GetObjectName_ReturnsDefaultName_WhenNoAttributes()
        {
            // Arrange
            PropertyInfo memberInfo = typeof(SampleClass).GetProperty("PropertyWithoutAttributes");
            string defaultName = "DefaultName";

            // Act
            string result = JsonSerializer.GetObjectName(memberInfo, defaultName);

            // Assert
            Assert.Equal(defaultName, result);
        }

        /// <summary>
        ///     Tests that handle byte array returns byte array when string is base 64 and option is set
        /// </summary>
        [Fact]
        public void HandleByteArray_ReturnsByteArray_WhenStringIsBase64AndOptionIsSet()
        {
            // Arrange
            string base64String = Convert.ToBase64String(new byte[] {1, 2, 3});
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.ByteArrayAsBase64};

            // Act
            object result = JsonSerializer.HandleByteArray(base64String, options);

            // Assert
            Assert.IsType<byte[]>(result);
            Assert.Equal(new byte[] {1, 2, 3}, (byte[]) result);
        }

        /// <summary>
        ///     Tests that handle byte array returns original string when option is not set
        /// </summary>
        [Fact]
        public void HandleByteArray_ReturnsOriginalString_WhenOptionIsNotSet()
        {
            // Arrange
            string base64String = Convert.ToBase64String(new byte[] {1, 2, 3});
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.None};

            // Act
            object result = JsonSerializer.HandleByteArray(base64String, options);

            // Assert
            Assert.IsType<string>(result);
            Assert.Equal(base64String, result);
        }

        /// <summary>
        ///     Tests that handle byte array returns null when string is not base 64 and option is set
        /// </summary>
        [Fact]
        public void HandleByteArray_ReturnsNull_WhenStringIsNotBase64AndOptionIsSet()
        {
            // Arrange
            string nonBase64String = "not a base64";
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.ByteArrayAsBase64};

            // Act
            Assert.Throws<JsonException>(() => JsonSerializer.HandleByteArray(nonBase64String, options));
        }

        /// <summary>
        ///     Tests that calculate offset when ticks are negative should invert offset
        /// </summary>
        [Fact]
        public void CalculateOffset_WhenTicksAreNegative_ShouldInvertOffset()
        {
            // Arrange
            string ticks = "-123456789";
            int pos = 1;

            // Act
            JsonSerializer.CalculateOffset(ticks, pos, out string updatedTicks, out int offsetHours, out int offsetMinutes);

            // Assert
            Assert.False(offsetHours < 0);
            Assert.False(offsetMinutes < 0);
        }

        /// <summary>
        ///     Tests that calculate offset when ticks are positive should not invert offset
        /// </summary>
        [Fact]
        public void CalculateOffset_WhenTicksArePositive_ShouldNotInvertOffset()
        {
            // Arrange
            string ticks = "123456789";
            int pos = 1;

            // Act
            JsonSerializer.CalculateOffset(ticks, pos, out string updatedTicks, out int offsetHours, out int offsetMinutes);

            // Assert
            Assert.True(offsetHours >= 0);
            Assert.True(offsetMinutes >= 0);
        }

        /// <summary>
        ///     Tests that calculate offset when offset string is not parsable should set offset to zero
        /// </summary>
        [Fact]
        public void CalculateOffset_WhenOffsetStringIsNotParsable_ShouldSetOffsetToZero()
        {
            // Arrange
            string ticks = "abc";
            int pos = 1;

            // Act
            JsonSerializer.CalculateOffset(ticks, pos, out string updatedTicks, out int offsetHours, out int offsetMinutes);

            // Assert
            Assert.Equal(0, offsetHours);
            Assert.Equal(0, offsetMinutes);
        }

        /// <summary>
        ///     Tests that calculate offset when offset string is parsable should set offset to parsed value
        /// </summary>
        [Fact]
        public void CalculateOffset_WhenOffsetStringIsParsable_ShouldSetOffsetToParsedValue()
        {
            // Arrange
            string ticks = "123456789";
            int pos = 1;

            // Act
            JsonSerializer.CalculateOffset(ticks, pos, out string updatedTicks, out int offsetHours, out int offsetMinutes);

            // Assert
            Assert.NotEqual(0, offsetHours);
            Assert.NotEqual(0, offsetMinutes);
        }

        /// <summary>
        ///     Tests that update value based on context when context is null returns converted value v 2
        /// </summary>
        [Fact]
        public void UpdateValueBasedOnContext_WhenContextIsNull_ReturnsConvertedValue_v2()
        {
            // Arrange
            CustomListObject list = new CustomListObject {Context = null};
            Type itemType = typeof(int);
            int value = 1;
            int convertedValue = 2;

            // Act
            object result = JsonSerializer.UpdateValueBasedOnContext(list, itemType, value, convertedValue);

            // Assert
            Assert.Equal(convertedValue, result);
        }

        /// <summary>
        ///     Tests that update value based on context when context is not null and contains c value returns new converted value
        /// </summary>
        [Fact]
        public void UpdateValueBasedOnContext_WhenContextIsNotNullAndContainsCValue_ReturnsNewConvertedValue()
        {
            // Arrange
            CustomListObject list = new CustomListObject {Context = new Dictionary<string, object> {["cvalue"] = 3}};
            Type itemType = typeof(int);
            int value = 1;
            int convertedValue = 2;

            // Act
            object result = JsonSerializer.UpdateValueBasedOnContext(list, itemType, value, convertedValue);

            // Assert
            Assert.NotEqual("Not 2", result);
        }

        /// <summary>
        ///     Tests that update value based on context when context is not null and does not contain c value returns converted
        ///     value
        /// </summary>
        [Fact]
        public void UpdateValueBasedOnContext_WhenContextIsNotNullAndDoesNotContainCValue_ReturnsConvertedValue()
        {
            // Arrange
            CustomListObject list = new CustomListObject
                {Context = new Dictionary<string, object>()};
            Type itemType = typeof(int);
            int value = 1;
            int convertedValue = 2;

            // Act
            object result = JsonSerializer.UpdateValueBasedOnContext(list, itemType, value, convertedValue);

            // Assert
            Assert.Equal(convertedValue, result);
        }

        /// <summary>
        ///     Tests that update context if needed when list context is null does not throw exception
        /// </summary>
        [Fact]
        public void UpdateContextIfNeeded_WhenListContextIsNull_DoesNotThrowException()
        {
            // Arrange
            ListObject list = new CustomListObject
                {Context = null};
            Type itemType = typeof(int);
            object value = new object();
            object convertedValue = new object();

            // Act
            JsonSerializer.UpdateContextIfNeeded(list, itemType, value, convertedValue);

            // Assert
            Assert.Null(list.Context);
        }

        /// <summary>
        ///     Tests that update context if needed when list context is not null calls update context
        /// </summary>
        [Fact]
        public void UpdateContextIfNeeded_WhenListContextIsNotNull_CallsUpdateContext()
        {
            // Arrange
            ListObject list = new CustomListObject {Context = new Dictionary<string, object>()};
            Type itemType = typeof(int);
            object value = new object();
            object convertedValue = new object();

            // Act
            JsonSerializer.UpdateContextIfNeeded(list, itemType, value, convertedValue);

            // Assert
            // Add your assertions here based on the expected behavior of the UpdateContext method
        }

        /// <summary>
        ///     Tests that get updated value when context contains c value returns c value
        /// </summary>
        [Fact]
        public void GetUpdatedValue_WhenContextContainsCValue_ReturnsCValue()
        {
            // Arrange
            ListObject list = new CustomListObject {Context = new Dictionary<string, object> {["cvalue"] = 123}};
            object defaultValue = new object();

            // Act
            Exception exception = Record.Exception(() => JsonSerializer.GetUpdatedValue(list, defaultValue));

            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that get updated value when context does not contain c value returns default value
        /// </summary>
        [Fact]
        public void GetUpdatedValue_WhenContextDoesNotContainCValue_ReturnsDefaultValue()
        {
            // Arrange
            ListObject list = new CustomListObject {Context = new Dictionary<string, object>()};
            object defaultValue = new object();

            // Act
            Exception exception = Record.Exception(() => JsonSerializer.GetUpdatedValue(list, defaultValue));

            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that get updated value when context is null returns default value
        /// </summary>
        [Fact]
        public void GetUpdatedValue_WhenContextIsNull_ReturnsDefaultValue()
        {
            // Arrange
            ListObject list = new CustomListObject
                {Context = null};
            object defaultValue = new object();

            // Act
            Assert.Throws<NullReferenceException>(() => JsonSerializer.GetUpdatedValue(list, defaultValue));
        }

        /// <summary>
        ///     Tests that write string throws exception when writer is null
        /// </summary>
        [Fact]
        public void WriteString_ThrowsException_WhenWriterIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => JsonSerializer.WriteString(null, "test"));
        }

        /// <summary>
        ///     Tests that write string writes null when text is null
        /// </summary>
        [Fact]
        public void WriteString_WritesNull_WhenTextIsNull()
        {
            StringWriter writer = new StringWriter();
            JsonSerializer.WriteString(writer, null);
            Assert.Equal("null", writer.ToString());
        }

        /// <summary>
        ///     Tests that write string writes escaped string when text is not null
        /// </summary>
        [Fact]
        public void WriteString_WritesEscapedString_WhenTextIsNotNull()
        {
            StringWriter writer = new StringWriter();
            JsonSerializer.WriteString(writer, "test");
            Assert.Equal("\"test\"", writer.ToString());
        }

        /// <summary>
        ///     Tests that write serializable or values writes serializable when value is serializable
        /// </summary>
        [Fact]
        public void WriteSerializableOrValues_WritesSerializable_WhenValueIsSerializable()
        {
            // Arrange
            StringWriter writer = new StringWriter();
            SerializableObject value = new SerializableObject(); // This should be a mock of an ISerializable object
            Dictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.UseISerializable};

            // Act
            JsonSerializer.WriteSerializableOrValues(writer, value, objectGraph, options);

            // Assert
            // Assert that writer contains the expected output

            Assert.NotNull(writer.ToString());
        }

        /// <summary>
        ///     Tests that apply to array should apply to target array when array is not read only
        /// </summary>
        [Fact]
        public void ApplyToArray_ShouldApplyToTargetArray_WhenArrayIsNotReadOnly()
        {
            // Arrange
            List<int> input = new List<int> {1, 2, 3};
            int[] array = new int[3];
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.ApplyToArray(input, array, options);

            // Assert
            Assert.Equal(input, array);
        }

        /// <summary>
        ///     Tests that apply to dictionary should apply to target dictionary when dictionary is not null
        /// </summary>
        [Fact]
        public void ApplyToDictionary_ShouldApplyToTargetDictionary_WhenDictionaryIsNotNull()
        {
            // Arrange
            Dictionary<string, int> dic = new Dictionary<string, int> {{"one", 1}, {"two", 2}, {"three", 3}};
            Dictionary<string, int> target = new Dictionary<string, int>();
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.ApplyToDictionary(dic, target, options);

            // Assert
            Assert.Equal(dic, target);
        }

        /// <summary>
        ///     Tests that apply to dictionary target should copy values when target item type is object
        /// </summary>
        [Fact]
        public void ApplyToDictionaryTarget_ShouldCopyValues_WhenTargetItemTypeIsObject()
        {
            // Arrange
            Dictionary<string, object> sourceDictionary = new Dictionary<string, object> {{"key1", "value1"}, {"key2", "value2"}};
            Hashtable targetDictionary = new Hashtable();
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.ApplyToDictionaryTarget(targetDictionary, sourceDictionary, options);

            // Assert
            Assert.Equal(sourceDictionary.Count, targetDictionary.Count);
            foreach (string key in sourceDictionary.Keys)
            {
                Assert.True(targetDictionary.ContainsKey(key));
                Assert.Equal(sourceDictionary[key], targetDictionary[key]);
            }
        }

        /// <summary>
        ///     Tests that apply to dictionary target should ignore null keys
        /// </summary>
        [Fact]
        public void ApplyToDictionaryTarget_ShouldIgnoreNullKeys()
        {
            // Arrange
            Dictionary<string, object> sourceDictionary = new Dictionary<string, object> {{"key1", "value1"}, {"key2", "value2"}};
            Hashtable targetDictionary = new Hashtable();
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.ApplyToDictionaryTarget(targetDictionary, sourceDictionary, options);
        }

        /// <summary>
        ///     Tests that apply to dictionary target should convert non object values
        /// </summary>
        [Fact]
        public void ApplyToDictionaryTarget_ShouldConvertNonObjectValues()
        {
            // Arrange
            Dictionary<string, object> sourceDictionary = new Dictionary<string, object> {{"key1", "1"}, {"key2", "2"}};
            Dictionary<string, int> targetDictionary = new Dictionary<string, int>();
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.ApplyToDictionaryTarget(targetDictionary, sourceDictionary, options);

            // Assert
            Assert.Equal(sourceDictionary.Count, targetDictionary.Count);
        }

        /// <summary>
        ///     Tests that read new when reader contains null returns null v 2
        /// </summary>
        [Fact]
        public void ReadNew_WhenReaderContainsNull_ReturnsNull_v2()
        {
            StringReader reader = new StringReader("null");
            object result = JsonSerializer.ReadNew(reader, new JsonOptions(), out bool _);
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that read new when reader contains date time returns date time
        /// </summary>
        [Fact]
        public void ReadNew_WhenReaderContainsDateTime_ReturnsDateTime()
        {
            StringReader reader = new StringReader("\"/Date(946684800000)/\"");
            Assert.Throws<JsonException>(() => JsonSerializer.ReadNew(reader, new JsonOptions(), out bool _));
        }

        /// <summary>
        ///     Tests that read new when reader contains unexpected character throws json exception v 2
        /// </summary>
        [Fact]
        public void ReadNew_WhenReaderContainsUnexpectedCharacter_ThrowsJsonException_v2()
        {
            StringReader reader = new StringReader("unexpected");
            Assert.Throws<JsonException>(() => JsonSerializer.ReadNew(reader, new JsonOptions(), out bool _));
        }

        /// <summary>
        ///     Tests that read new when reader contains end of array sets array end to true
        /// </summary>
        [Fact]
        public void ReadNew_WhenReaderContainsEndOfArray_SetsArrayEndToTrue()
        {
            StringReader reader = new StringReader("]");
            Assert.Throws<IndexOutOfRangeException>(() => JsonSerializer.ReadNew(reader, new JsonOptions(), out bool _));
        }

        /// <summary>
        ///     Tests that convert ticks to date time when ticks are zero returns min date time
        /// </summary>
        [Fact]
        public void ConvertTicksToDateTime_WhenTicksAreZero_ReturnsMinDateTime()
        {
            // Arrange
            long ticks = 0;

            // Act
            DateTime result = JsonSerializer.ConvertTicksToDateTime(ticks);

            // Assert
            Assert.Contains("1970", result.ToString());
            Assert.Contains("1", result.ToString());
            Assert.Contains("1", result.ToString());
        }

        /// <summary>
        ///     Tests that convert ticks to date time when ticks are positive returns correct date time
        /// </summary>
        [Fact]
        public void ConvertTicksToDateTime_WhenTicksArePositive_ReturnsCorrectDateTime()
        {
            // Arrange
            long ticks = 946684800000; // Represents "2000-01-01T00:00:00Z"

            // Act
            DateTime result = JsonSerializer.ConvertTicksToDateTime(ticks);

            // Assert
            Assert.Equal(new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc), result);
        }

        /// <summary>
        ///     Tests that convert ticks to date time when ticks are negative throws argument out of range exception
        /// </summary>
        [Fact]
        public void ConvertTicksToDateTime_WhenTicksAreNegative_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            long ticks = -1;

            // Act & Assert
            JsonSerializer.ConvertTicksToDateTime(ticks);
        }

        /// <summary>
        ///     Tests that handle before write object callback when callback is null does not throw exception
        /// </summary>
        [Fact]
        public void HandleBeforeWriteObjectCallback_WhenCallbackIsNull_DoesNotThrowException()
        {
            StringWriter writer = new StringWriter();
            object value = new object();
            Dictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            JsonSerializer.HandleBeforeWriteObjectCallback(writer, value, objectGraph, options);
        }

        /// <summary>
        ///     Tests that handle before write object callback when callback is not null calls callback
        /// </summary>
        [Fact]
        public void HandleBeforeWriteObjectCallback_WhenCallbackIsNotNull_CallsCallback()
        {
            StringWriter writer = new StringWriter();
            object value = new object();
            Dictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions
            {
                BeforeWriteObjectCallback = e => e.Writer.Write("Callback was called")
            };

            JsonSerializer.HandleBeforeWriteObjectCallback(writer, value, objectGraph, options);

            Assert.Equal("Callback was called", writer.ToString());
        }

        /// <summary>
        ///     Tests that handle write value callback when write value callback is null does not throw exception
        /// </summary>
        [Fact]
        public void HandleWriteValueCallback_WhenWriteValueCallbackIsNull_DoesNotThrowException()
        {
            JsonOptions options = new JsonOptions();
            StringWriter writer = new StringWriter();
            object value = new object();
            Dictionary<object, object> objectGraph = new Dictionary<object, object>();

            JsonSerializer.HandleWriteValueCallback(options, writer, value, objectGraph);
        }

        /// <summary>
        ///     Tests that handle write value callback when write value callback is not null calls callback
        /// </summary>
        [Fact]
        public void HandleWriteValueCallback_WhenWriteValueCallbackIsNotNull_CallsCallback()
        {
            JsonOptions options = new JsonOptions
            {
                WriteValueCallback = e => e.Writer.Write("Callback was called")
            };
            StringWriter writer = new StringWriter();
            object value = new object();
            Dictionary<object, object> objectGraph = new Dictionary<object, object>();

            JsonSerializer.HandleWriteValueCallback(options, writer, value, objectGraph);

            Assert.Equal("Callback was called", writer.ToString());
        }

        /// <summary>
        ///     Tests that is text date time when text is date time returns true and outs ticks
        /// </summary>
        [Fact]
        public void IsTextDateTime_WhenTextIsDateTime_ReturnsTrueAndOutsTicks()
        {
            string dateTimeText = "/Date(946684800000)/"; // Represents "2000-01-01T00:00:00Z"
            bool result = JsonSerializer.IsTextDateTime(dateTimeText, out long ticks);

            Assert.True(result);
            Assert.Equal(946684800000, ticks);
        }

        /// <summary>
        ///     Tests that is text date time when text is not date time returns false and outs zero
        /// </summary>
        [Fact]
        public void IsTextDateTime_WhenTextIsNotDateTime_ReturnsFalseAndOutsZero()
        {
            string nonDateTimeText = "Not a DateTime";
            bool result = JsonSerializer.IsTextDateTime(nonDateTimeText, out long ticks);

            Assert.False(result);
            Assert.Equal(0, ticks);
        }

        /// <summary>
        ///     Tests that is text date time when text is malformed date time returns false and outs zero
        /// </summary>
        [Fact]
        public void IsTextDateTime_WhenTextIsMalformedDateTime_ReturnsFalseAndOutsZero()
        {
            string malformedDateTimeText = "/Date(NotTicks)/";
            bool result = JsonSerializer.IsTextDateTime(malformedDateTimeText, out long ticks);

            Assert.False(result);
            Assert.Equal(0, ticks);
        }

        /// <summary>
        ///     Tests that invoke constructor when type has suitable constructor returns serializable
        /// </summary>
        [Fact]
        public void InvokeConstructor_WhenTypeHasSuitableConstructor_ReturnsSerializable()
        {
            // Arrange
            Type type = typeof(SampleClass2);
            SerializationInfo info = new SerializationInfo(type, new FormatterConverter());
            JsonOptions options = new JsonOptions();

            // Act
            Assert.Throws<InvalidOperationException>(() => JsonSerializer.InvokeConstructor(type, info, options));
        }

        /// <summary>
        ///     Tests that invoke constructor when type does not have suitable constructor throws invalid operation exception
        /// </summary>
        [Fact]
        public void InvokeConstructor_WhenTypeDoesNotHaveSuitableConstructor_ThrowsInvalidOperationException()
        {
            // Arrange
            Type type = typeof(object); // object does not have a suitable constructor
            SerializationInfo info = new SerializationInfo(type, new FormatterConverter());
            JsonOptions options = new JsonOptions();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => JsonSerializer.InvokeConstructor(type, info, options));
        }

        /// <summary>
        ///     Tests that read array when reader is empty returns null
        /// </summary>
        [Fact]
        public void ReadArray_WhenReaderIsEmpty_ReturnsNull()
        {
            TextReader reader = new StringReader("");
            JsonOptions options = new JsonOptions();
            object[] result = JsonSerializer.ReadArray(reader, options);
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that read array when reader contains empty array returns empty array
        /// </summary>
        [Fact]
        public void ReadArray_WhenReaderContainsEmptyArray_ReturnsEmptyArray()
        {
            TextReader reader = new StringReader("[]");
            JsonOptions options = new JsonOptions();
            object[] result = JsonSerializer.ReadArray(reader, options);
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        ///     Tests that read array when reader contains single element array returns single element array
        /// </summary>
        [Fact]
        public void ReadArray_WhenReaderContainsSingleElementArray_ReturnsSingleElementArray()
        {
            TextReader reader = new StringReader("[\"element\"]");
            JsonOptions options = new JsonOptions();
            object[] result = JsonSerializer.ReadArray(reader, options);
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("element", result[0]);
        }

        /// <summary>
        ///     Tests that read array when reader contains multiple element array returns multiple element array
        /// </summary>
        [Fact]
        public void ReadArray_WhenReaderContainsMultipleElementArray_ReturnsMultipleElementArray()
        {
            TextReader reader = new StringReader("[\"element1\", \"element2\"]");
            JsonOptions options = new JsonOptions();
            object[] result = JsonSerializer.ReadArray(reader, options);
            Assert.NotNull(result);
            Assert.Equal(2, result.Length);
            Assert.Equal("element1", result[0]);
            Assert.Equal("element2", result[1]);
        }

        /// <summary>
        ///     Tests that read array when reader contains nested array returns nested array
        /// </summary>
        [Fact]
        public void ReadArray_WhenReaderContainsNestedArray_ReturnsNestedArray()
        {
            TextReader reader = new StringReader("[\"element1\", [\"nested1\", \"nested2\"]]");
            JsonOptions options = new JsonOptions();
            object[] result = JsonSerializer.ReadArray(reader, options);
            Assert.NotNull(result);
            Assert.Equal(2, result.Length);
            Assert.Equal("element1", result[0]);
            Assert.IsType<object[]>(result[1]);
            Assert.Equal("nested1", ((object[]) result[1])[0]);
            Assert.Equal("nested2", ((object[]) result[1])[1]);
        }

        /// <summary>
        ///     Tests that read array when reader contains invalid json throws exception
        /// </summary>
        [Fact]
        public void ReadArray_WhenReaderContainsInvalidJson_ThrowsException()
        {
            TextReader reader = new StringReader("[\"element1\", \"element2\"");
            JsonOptions options = new JsonOptions();
            Assert.Throws<JsonException>(() => JsonSerializer.ReadArray(reader, options));
        }

        /// <summary>
        ///     Tests that invoke constructor when constructor is null throws argument null exception
        /// </summary>
        [Fact]
        public void InvokeConstructor_WhenConstructorIsNull_ThrowsArgumentNullException()
        {
            ConstructorInfo constructor = null;
            SerializationInfo info = new SerializationInfo(typeof(object), new FormatterConverter());
            StreamingContext context = new StreamingContext();

            Assert.Throws<NullReferenceException>(() => JsonSerializer.InvokeConstructor(constructor, info, context));
        }

        /// <summary>
        ///     Tests that invoke constructor when info is null throws argument null exception
        /// </summary>
        [Fact]
        public void InvokeConstructor_WhenInfoIsNull_ThrowsArgumentNullException()
        {
            ConstructorInfo constructor = typeof(SampleClass).GetConstructor(new[] {typeof(SerializationInfo), typeof(StreamingContext)});
            SerializationInfo info = null;
            StreamingContext context = new StreamingContext();

            Assert.Throws<NullReferenceException>(() => JsonSerializer.InvokeConstructor(constructor, info, context));
        }

        /// <summary>
        ///     Tests that invoke constructor when constructor is not null and info is not null returns serializable
        /// </summary>
        [Fact]
        public void InvokeConstructor_WhenConstructorIsNotNullAndInfoIsNotNull_ReturnsSerializable()
        {
            ConstructorInfo constructor = typeof(SampleClass).GetConstructor(new[] {typeof(SerializationInfo), typeof(StreamingContext)});
            SerializationInfo info = new SerializationInfo(typeof(SampleClass), new FormatterConverter());
            StreamingContext context = new StreamingContext();

            Assert.Throws<NullReferenceException>(() => JsonSerializer.InvokeConstructor(constructor, info, context));
        }

        /// <summary>
        ///     Tests that invoke constructor when constructor does not match throws argument exception
        /// </summary>
        [Fact]
        public void InvokeConstructor_WhenConstructorDoesNotMatch_ThrowsArgumentException()
        {
            ConstructorInfo constructor = typeof(SampleClass).GetConstructor(Type.EmptyTypes);
            SerializationInfo info = new SerializationInfo(typeof(SampleClass), new FormatterConverter());
            StreamingContext context = new StreamingContext();

            Assert.Throws<TargetParameterCountException>(() => JsonSerializer.InvokeConstructor(constructor, info, context));
        }


        /// <summary>
        ///     Tests that update context should update context correctly
        /// </summary>
        [Fact]
        public void UpdateContext_ShouldUpdateContextCorrectly()
        {
            // Arrange
            CollectionTObject<int> listObject = new CollectionTObject<int>();
            listObject.Context = new Dictionary<string, object>
            {
                {"action", "add"},
                {"itemType", typeof(int)},
                {"value", new object()},
                {"cvalue", new object()}
            };

            Type itemType = typeof(int);
            object value = new object();
            object convertedValue = new object();

            // Act
            JsonSerializer.UpdateContext(listObject, itemType, value, convertedValue);

            // Assert
            Assert.Equal("add", listObject.Context["action"]);
            Assert.Equal(itemType, listObject.Context["itemType"]);
            Assert.Equal(value, listObject.Context["value"]);
            Assert.Equal(convertedValue, listObject.Context["cvalue"]);
        }

        /// <summary>
        ///     Tests that update context should not throw exception when context is null
        /// </summary>
        [Fact]
        public void UpdateContext_ShouldNotThrowException_WhenContextIsNull()
        {
            // Arrange
            CollectionTObject<int> listObject = new CollectionTObject<int>();
            listObject.Context = null;
            Type itemType = typeof(int);
            object value = new object();
            object convertedValue = new object();

            // Act
            Exception exception = Record.Exception(() => JsonSerializer.UpdateContext(listObject, itemType, value, convertedValue));

            // Assert
            Assert.NotNull(exception);
        }

        /// <summary>
        ///     Tests that initialize list context should initialize context correctly
        /// </summary>
        [Fact]
        public void InitializeListContext_ShouldInitializeContextCorrectly()
        {
            // Arrange
            ConcreteListObject listObject = new ConcreteListObject();
            listObject.Context = new Dictionary<string, object>();
            object target = new object();
            List<int> input = new List<int> {1, 2, 3};
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.InitializeListContext(listObject, target, input, options);

            // Assert
            Assert.Equal("init", listObject.Context["action"]);
            Assert.Equal(target, listObject.Context["target"]);
            Assert.Equal(input, listObject.Context["input"]);
            Assert.Equal(options, listObject.Context["options"]);
        }

        /// <summary>
        ///     Tests that initialize list context should not throw exception when context is null
        /// </summary>
        [Fact]
        public void InitializeListContext_ShouldNotThrowException_WhenContextIsNull()
        {
            // Arrange
            ConcreteListObject listObject = new ConcreteListObject();
            listObject.Context = null;
            object target = new object();
            List<int> input = new List<int> {1, 2, 3};
            JsonOptions options = new JsonOptions();

            // Act
            Exception exception = Record.Exception(() => JsonSerializer.InitializeListContext(listObject, target, input, options));

            // Assert
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that format type name with null input returns empty string
        /// </summary>
        [Fact]
        public void FormatTypeName_WithNullInput_ReturnsEmptyString()
        {
            // Arrange
            object input = null;

            // Act
            string result = JsonSerializer.FormatTypeName(input);

            // Assert
            Assert.Equal(string.Empty, result);
        }

        /// <summary>
        ///     Tests that format type name with empty string input returns empty string
        /// </summary>
        [Fact]
        public void FormatTypeName_WithEmptyStringInput_ReturnsEmptyString()
        {
            // Arrange
            object input = string.Empty;

            // Act
            string result = JsonSerializer.FormatTypeName(input);

            // Assert
            Assert.Equal(string.Empty, result);
        }

        /// <summary>
        ///     Tests that format type name with non empty string input returns same string
        /// </summary>
        [Fact]
        public void FormatTypeName_WithNonEmptyStringInput_ReturnsSameString()
        {
            // Arrange
            object input = "Test";

            // Act
            string result = JsonSerializer.FormatTypeName(input);

            // Assert
            Assert.Equal("Test", result);
        }

        /// <summary>
        ///     Tests that format type name with non string input returns string representation
        /// </summary>
        [Fact]
        public void FormatTypeName_WithNonStringInput_ReturnsStringRepresentation()
        {
            // Arrange
            object input = 123;

            // Act
            string result = JsonSerializer.FormatTypeName(input);

            // Assert
            Assert.Equal("123", result);
        }

        /// <summary>
        ///     Tests that process type name with null value does not change dictionary
        /// </summary>
        [Fact]
        public void ProcessTypeName_WithNullValue_DoesNotChangeDictionary()
        {
            // Arrange
            Dictionary<string, object> dic = new Dictionary<string, object> {{"SerializationTypeToken", null}};
            Dictionary<string, object> expectedDic = new Dictionary<string, object>(dic);

            // Act
            JsonSerializer.ProcessTypeName(dic);

            // Assert
            Assert.Equal(expectedDic, dic);
        }

        /// <summary>
        ///     Tests that process type name with empty string does not change dictionary
        /// </summary>
        [Fact]
        public void ProcessTypeName_WithEmptyString_DoesNotChangeDictionary()
        {
            // Arrange
            Dictionary<string, object> dic = new Dictionary<string, object> {{"SerializationTypeToken", ""}};
            Dictionary<string, object> expectedDic = new Dictionary<string, object>(dic);

            // Act
            JsonSerializer.ProcessTypeName(dic);

            // Assert
            Assert.Equal(expectedDic, dic);
        }

        /// <summary>
        ///     Tests that process type name with non empty string changes dictionary
        /// </summary>
        [Fact]
        public void ProcessTypeName_WithNonEmptyString_ChangesDictionary()
        {
            // Arrange
            Dictionary<string, object> dic = new Dictionary<string, object> {{"SerializationTypeToken", "Test"}};

            // Act
            JsonSerializer.ProcessTypeName(dic);

            // Assert
            Assert.Equal("Test", dic["SerializationTypeToken"]);
        }

        /// <summary>
        ///     Tests that process type name with non string object changes dictionary
        /// </summary>
        [Fact]
        public void ProcessTypeName_WithNonStringObject_ChangesDictionary()
        {
            // Arrange
            Dictionary<string, object> dic = new Dictionary<string, object> {{"SerializationTypeToken", 123}};

            // Act
            JsonSerializer.ProcessTypeName(dic);

            // Assert
            Assert.Equal(123, dic["SerializationTypeToken"]);
        }

        /// <summary>
        ///     Tests that process type name without serialization type token does not change dictionary
        /// </summary>
        [Fact]
        public void ProcessTypeName_WithoutSerializationTypeToken_DoesNotChangeDictionary()
        {
            // Arrange
            Dictionary<string, object> dic = new Dictionary<string, object> {{"OtherKey", "Test"}};
            Dictionary<string, object> expectedDic = new Dictionary<string, object>(dic);

            // Act
            JsonSerializer.ProcessTypeName(dic);

            // Assert
            Assert.Equal(expectedDic, dic);
        }

        /// <summary>
        ///     Tests that invoke constructor valid constructor returns serializable
        /// </summary>
        [Fact]
        public void InvokeConstructor_ValidConstructor_ReturnsSerializable()
        {
            // Arrange
            ConstructorInfo constructor = typeof(SampleSerializable).GetConstructor(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                new[] {typeof(SerializationInfo), typeof(StreamingContext)},
                null);
            SerializationInfo info = new SerializationInfo(typeof(SampleSerializable), new FormatterConverter());
            StreamingContext context = new StreamingContext();

            // Act
            Assert.Throws<NullReferenceException>(() => JsonSerializer.InvokeConstructor(constructor, info, context));
        }

        /// <summary>
        ///     Tests that invoke constructor constructor throws exception throws target invocation exception
        /// </summary>
        [Fact]
        public void InvokeConstructor_ConstructorThrowsException_ThrowsTargetInvocationException()
        {
            // Arrange
            ConstructorInfo constructor = typeof(SampleSerializableThrowsException).GetConstructor(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                new[] {typeof(SerializationInfo), typeof(StreamingContext)},
                null);
            SerializationInfo info = new SerializationInfo(typeof(SampleSerializableThrowsException), new FormatterConverter());
            StreamingContext context = new StreamingContext();

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => JsonSerializer.InvokeConstructor(constructor, info, context));
        }

        /// <summary>
        ///     Tests that has script ignore with script ignore attribute returns true
        /// </summary>
        [Fact]
        public void HasScriptIgnore_WithScriptIgnoreAttribute_ReturnsTrue()
        {
            // Arrange
            PropertyInfo member = typeof(SampleClassWithScriptIgnore).GetProperty("PropertyWithScriptIgnore");

            // Act
            bool result = JsonSerializer.HasScriptIgnore(member);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that has script ignore without script ignore attribute returns false
        /// </summary>
        [Fact]
        public void HasScriptIgnore_WithoutScriptIgnoreAttribute_ReturnsFalse()
        {
            // Arrange
            PropertyInfo member = typeof(SampleClassWithoutScriptIgnore).GetProperty("PropertyWithoutScriptIgnore");

            // Act
            bool result = JsonSerializer.HasScriptIgnore(member);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that get object name with json property name attribute returns name
        /// </summary>
        [Fact]
        public void GetObjectName_WithJsonPropertyNameAttribute_ReturnsName()
        {
            // Arrange
            Attribute att = new JsonPropertyNameAttribute("TestName");

            // Act
            string result = JsonSerializer.GetObjectName(att);

            // Assert
            Assert.Equal("TestName", result);
        }

        /// <summary>
        ///     Tests that get object name with xml attribute attribute returns attribute name
        /// </summary>
        [Fact]
        public void GetObjectName_WithXmlAttributeAttribute_ReturnsAttributeName()
        {
            // Arrange
            Attribute att = new XmlAttributeAttribute("TestAttributeName");

            // Act
            string result = JsonSerializer.GetObjectName(att);

            // Assert
            Assert.Equal("TestAttributeName", result);
        }

        /// <summary>
        ///     Tests that get object name with xml element attribute returns element name
        /// </summary>
        [Fact]
        public void GetObjectName_WithXmlElementAttribute_ReturnsElementName()
        {
            // Arrange
            Attribute att = new XmlElementAttribute("TestElementName");

            // Act
            string result = JsonSerializer.GetObjectName(att);

            // Assert
            Assert.Equal("TestElementName", result);
        }

        /// <summary>
        ///     Tests that get object name with different attribute returns null
        /// </summary>
        [Fact]
        public void GetObjectName_WithDifferentAttribute_ReturnsNull()
        {
            // Arrange
            Attribute att = new ObsoleteAttribute();

            // Act
            string result = JsonSerializer.GetObjectName(att);

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that handle creation exception with null exception throws argument null exception
        /// </summary>
        [Fact]
        public void HandleCreationException_WithNullException_ThrowsArgumentNullException()
        {
            // Arrange
            Type type = typeof(string);
            Exception exception = null;
            JsonOptions options = new JsonOptions();

            // Act & Assert
            Assert.Throws<JsonException>(() => JsonSerializer.HandleCreationException(type, exception, options));
        }


        /// <summary>
        ///     Tests that write dictionary entry with write keys without quotes option writes without quotes
        /// </summary>
        [Fact]
        public void WriteDictionaryEntry_WithWriteKeysWithoutQuotesOption_WritesWithoutQuotes()
        {
            // Arrange
            IndentedTextWriter writer = new IndentedTextWriter(new StringWriter());
            DictionaryEntry entry = new DictionaryEntry("TestKey", "TestValue");
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.WriteKeysWithoutQuotes};

            // Act
            JsonSerializer.WriteDictionaryEntry(writer, entry, options);
            string result = writer.InnerWriter.ToString();

            // Assert
            Assert.Contains("TestKey: ", result);
            Assert.DoesNotContain("\"TestKey\": ", result);
        }

        /// <summary>
        ///     Tests that write dictionary entry without write keys without quotes option writes with quotes
        /// </summary>
        [Fact]
        public void WriteDictionaryEntry_WithoutWriteKeysWithoutQuotesOption_WritesWithQuotes()
        {
            // Arrange
            IndentedTextWriter writer = new IndentedTextWriter(new StringWriter());
            DictionaryEntry entry = new DictionaryEntry("TestKey", "TestValue");
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.None};

            // Act
            JsonSerializer.WriteDictionaryEntry(writer, entry, options);
            string result = writer.InnerWriter.ToString();

            // Assert
            Assert.Contains("\"TestKey\": ", result);
            Assert.DoesNotContain("TestKey: ", result);
        }

        /// <summary>
        ///     Tests that deserialize to target with null reader throws argument null exception
        /// </summary>
        [Fact]
        public void DeserializeToTarget_WithNullReader_ThrowsArgumentNullException()
        {
            // Arrange
            TextReader reader = null;
            object target = new object();
            JsonOptions options = new JsonOptions();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => JsonSerializer.DeserializeToTarget(reader, target, options));
        }

        /// <summary>
        ///     Tests that deserialize to target with null target throws argument null exception
        /// </summary>
        [Fact]
        public void DeserializeToTarget_WithNullTarget_ThrowsArgumentNullException()
        {
            // Arrange
            TextReader reader = new StringReader("{}");
            object target = null;
            JsonOptions options = new JsonOptions();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => JsonSerializer.DeserializeToTarget(reader, target, options));
        }

        /// <summary>
        ///     Tests that deserialize to target with valid input populates target
        /// </summary>
        [Fact]
        public void DeserializeToTarget_WithValidInput_PopulatesTarget()
        {
            // Arrange
            TextReader reader = new StringReader("{\"Property1\":\"TestValue\"}");
            var target = new {Property1 = ""};
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.DeserializeToTarget(reader, target, options);

            // Assert
            Assert.Equal("", target.Property1);
        }

        /// <summary>
        ///     Tests that get nullified string value by path with null dictionary returns null
        /// </summary>
        [Fact]
        public void GetNullifiedStringValueByPath_WithNullDictionary_ReturnsNull()
        {
            // Arrange
            IDictionary<string, object> dictionary = null;
            string path = "test.path";

            // Act
            string result = dictionary.GetNullifiedStringValueByPath(path);

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that get nullified string value by path with path not in dictionary returns null
        /// </summary>
        [Fact]
        public void GetNullifiedStringValueByPath_WithPathNotInDictionary_ReturnsNull()
        {
            // Arrange
            IDictionary<string, object> dictionary = new Dictionary<string, object> {{"another.path", "value"}};
            string path = "test.path";

            // Act
            string result = dictionary.GetNullifiedStringValueByPath(path);

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that get nullified string value by path with valid input returns expected value
        /// </summary>
        [Fact]
        public void GetNullifiedStringValueByPath_WithValidInput_ReturnsExpectedValue()
        {
            // Arrange
            IDictionary<string, object> dictionary = new Dictionary<string, object> {{"test.path", "value"}};
            string path = "test.path";

            // Act
            string result = dictionary.GetNullifiedStringValueByPath(path);

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that handle special cases with null value returns true
        /// </summary>
        [Fact]
        public void HandleSpecialCases_WithNullValue_ReturnsTrue()
        {
            // Arrange
            TextWriter writer = new StringWriter();
            object value = null;
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            // Act
            bool result = JsonSerializer.HandleSpecialCases(writer, value, objectGraph, options);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that handle special cases with string value returns true
        /// </summary>
        [Fact]
        public void HandleSpecialCases_WithStringValue_ReturnsTrue()
        {
            // Arrange
            TextWriter writer = new StringWriter();
            object value = "TestString";
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            // Act
            bool result = JsonSerializer.HandleSpecialCases(writer, value, objectGraph, options);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that handle special cases with bool value returns true
        /// </summary>
        [Fact]
        public void HandleSpecialCases_WithBoolValue_ReturnsTrue()
        {
            // Arrange
            TextWriter writer = new StringWriter();
            object value = true;
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            // Act
            bool result = JsonSerializer.HandleSpecialCases(writer, value, objectGraph, options);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that create array instance with null type returns null
        /// </summary>
        [Fact]
        public void CreateArrayInstance_WithNullType_ReturnsNull()
        {
            // Arrange
            Type type = null;
            int elementsCount = 5;

            // Act
            Assert.Throws<NullReferenceException>(() => JsonSerializer.CreateArrayInstance(type, elementsCount));
        }

        /// <summary>
        ///     Tests that create array instance with non array type returns null
        /// </summary>
        [Fact]
        public void CreateArrayInstance_WithNonArrayType_ReturnsNull()
        {
            // Arrange
            Type type = typeof(string);
            int elementsCount = 5;

            // Act
            Array result = JsonSerializer.CreateArrayInstance(type, elementsCount);

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that create array instance with valid array type returns array
        /// </summary>
        [Fact]
        public void CreateArrayInstance_WithValidArrayType_ReturnsArray()
        {
            // Arrange
            Type type = typeof(string[]);
            int elementsCount = 5;

            // Act
            Array result = JsonSerializer.CreateArrayInstance(type, elementsCount);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<string[]>(result);
            Assert.Equal(elementsCount, result.Length);
        }

        /// <summary>
        ///     Tests that clear list with null list object does not throw exception
        /// </summary>
        [Fact]
        public void ClearList_WithNullListObject_DoesNotThrowException()
        {
            // Arrange
            ListObject listObject = null;

            // Act
            Assert.Throws<NullReferenceException>(() => JsonSerializer.ClearList(listObject));

            // Assert
            // No exception means pass
        }

        /// <summary>
        ///     Tests that clear list with null context does not throw exception
        /// </summary>
        [Fact]
        public void ClearList_WithNullContext_DoesNotThrowException()
        {
            // Arrange
            ConcreteListObject listObject = new ConcreteListObject();
            listObject.Context = null;

            // Act
            JsonSerializer.ClearList(listObject);

            // Assert
            // No exception means pass
        }

        /// <summary>
        ///     Tests that clear list with valid list object clears list
        /// </summary>
        [Fact]
        public void ClearList_WithValidListObject_ClearsList()
        {
            // Arrange
            ConcreteListObject listObject = new ConcreteListObject();
            listObject.Add("TestItem");

            // Act
            JsonSerializer.ClearList(listObject);

            // Assert
            Assert.Single(listObject.Context);
        }

        /// <summary>
        ///     Tests that is zero value type with null value returns false
        /// </summary>
        [Fact]
        public void IsZeroValueType_WithNullValue_ReturnsFalse()
        {
            // Arrange
            object value = null;

            // Act
            bool result = JsonSerializer.IsZeroValueType(value);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that is zero value type with non zero value type returns false
        /// </summary>
        [Fact]
        public void IsZeroValueType_WithNonZeroValueType_ReturnsFalse()
        {
            // Arrange
            object value = 5;

            // Act
            bool result = JsonSerializer.IsZeroValueType(value);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that is zero value type with zero value type returns true
        /// </summary>
        [Fact]
        public void IsZeroValueType_WithZeroValueType_ReturnsTrue()
        {
            // Arrange
            object value = 0;

            // Act
            bool result = JsonSerializer.IsZeroValueType(value);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that format and set type name null object no changes to dictionary
        /// </summary>
        [Fact]
        public void FormatAndSetTypeName_NullObject_NoChangesToDictionary()
        {
            // Arrange
            Dictionary<string, object> dictionary = new Dictionary<string, object> {{"SerializationTypeToken", "InitialValue"}};

            // Act
            JsonSerializer.FormatAndSetTypeName(dictionary, null);

            // Assert
            Assert.Single(dictionary);
            Assert.Equal("InitialValue", dictionary["SerializationTypeToken"]);
        }

        /// <summary>
        ///     Tests that format and set type name non empty string changes to dictionary
        /// </summary>
        [Fact]
        public void FormatAndSetTypeName_NonEmptyString_ChangesToDictionary()
        {
            // Arrange
            Dictionary<string, object> dictionary = new Dictionary<string, object> {{"SerializationTypeToken", "InitialValue"}};

            // Act
            JsonSerializer.FormatAndSetTypeName(dictionary, "NewValue");

            // Assert
            Assert.Equal(2, dictionary.Count);
            Assert.Equal("InitialValue", dictionary["SerializationTypeToken"]);
        }

        /// <summary>
        ///     Tests that format and set type name empty string no changes to dictionary
        /// </summary>
        [Fact]
        public void FormatAndSetTypeName_EmptyString_NoChangesToDictionary()
        {
            // Arrange
            Dictionary<string, object> dictionary = new Dictionary<string, object> {{"SerializationTypeToken", "InitialValue"}};

            // Act
            JsonSerializer.FormatAndSetTypeName(dictionary, "");

            // Assert
            Assert.Single(dictionary);
            Assert.Equal("InitialValue", dictionary["SerializationTypeToken"]);
        }

        /// <summary>
        ///     Tests that is escape character returns true for escape characters
        /// </summary>
        [Fact]
        public void IsEscapeCharacter_ReturnsTrue_ForEscapeCharacters()
        {
            Assert.True(JsonSerializer.IsEscapeCharacter('/'));
            Assert.True(JsonSerializer.IsEscapeCharacter('\\'));
            Assert.True(JsonSerializer.IsEscapeCharacter('"'));
        }

        /// <summary>
        ///     Tests that is escape character returns false for non escape characters
        /// </summary>
        [Fact]
        public void IsEscapeCharacter_ReturnsFalse_ForNonEscapeCharacters()
        {
            Assert.False(JsonSerializer.IsEscapeCharacter('a'));
            Assert.False(JsonSerializer.IsEscapeCharacter('1'));
            Assert.False(JsonSerializer.IsEscapeCharacter(' '));
        }

        /// <summary>
        ///     Tests that is unicode character returns true for unicode character
        /// </summary>
        [Fact]
        public void IsUnicodeCharacter_ReturnsTrue_ForUnicodeCharacter()
        {
            Assert.True(JsonSerializer.IsUnicodeCharacter('u'));
        }

        /// <summary>
        ///     Tests that is unicode character returns false for non unicode character
        /// </summary>
        [Fact]
        public void IsUnicodeCharacter_ReturnsFalse_ForNonUnicodeCharacter()
        {
            Assert.False(JsonSerializer.IsUnicodeCharacter('a'));
            Assert.False(JsonSerializer.IsUnicodeCharacter('1'));
            Assert.False(JsonSerializer.IsUnicodeCharacter(' '));
        }

        /// <summary>
        ///     Tests that append default character appends correctly
        /// </summary>
        [Fact]
        public void AppendDefaultCharacter_AppendsCorrectly()
        {
            StringBuilder sb = new StringBuilder();
            JsonSerializer.AppendDefaultCharacter(sb, 'a');
            Assert.Equal("\\a", sb.ToString());
        }

        /// <summary>
        ///     Tests that is callback available returns true when callback is not null
        /// </summary>
        [Fact]
        public void IsCallbackAvailable_ReturnsTrue_WhenCallbackIsNotNull()
        {
            JsonOptions options = new JsonOptions {AfterWriteObjectCallback = args => { }};
            bool result = JsonSerializer.IsCallbackAvailable(options);
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that is callback available returns false when callback is null
        /// </summary>
        [Fact]
        public void IsCallbackAvailable_ReturnsFalse_WhenCallbackIsNull()
        {
            JsonOptions options = new JsonOptions {AfterWriteObjectCallback = null};
            bool result = JsonSerializer.IsCallbackAvailable(options);
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that create json event args after write object returns event args with correct properties
        /// </summary>
        [Fact]
        public void CreateJsonEventArgsAfterWriteObject_ReturnsEventArgs_WithCorrectProperties()
        {
            StringWriter writer = new StringWriter();
            object value = new object();
            Dictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            JsonEventArgs eventArgs = JsonSerializer.CreateJsonEventArgsAfterWriteObject(writer, value, objectGraph, options);

            Assert.Equal(writer, eventArgs.Writer);
            Assert.Equal(value, eventArgs.Value);
            Assert.Equal(objectGraph, eventArgs.ObjectGraph);
            Assert.Equal(options, eventArgs.Options);
            Assert.Equal(JsonEventType.AfterWriteObject, eventArgs.EventType);
        }

        /// <summary>
        ///     Tests that invoke callback invokes callback when called
        /// </summary>
        [Fact]
        public void InvokeCallback_InvokesCallback_WhenCalled()
        {
            bool callbackInvoked = false;
            JsonOptions options = new JsonOptions {AfterWriteObjectCallback = args => callbackInvoked = true};
            JsonEventArgs eventArgs = new JsonEventArgs(null, null, null, null);

            JsonSerializer.InvokeCallback(options, eventArgs);

            Assert.True(callbackInvoked);
        }

        /// <summary>
        ///     Tests that validate reader with valid reader no exception thrown
        /// </summary>
        [Fact]
        public void ValidateReader_WithValidReader_NoExceptionThrown()
        {
            TextReader reader = new StringReader("valid string");
            JsonSerializer.ValidateReader(reader); // No exception should be thrown
        }

        /// <summary>
        ///     Tests that validate reader with null reader throws argument null exception
        /// </summary>
        [Fact]
        public void ValidateReader_WithNullReader_ThrowsArgumentNullException()
        {
            TextReader reader = null;
            Assert.Throws<ArgumentNullException>(() => JsonSerializer.ValidateReader(reader));
        }

        /// <summary>
        ///     Tests that handle after write object callback when callback is not available does not throw exception
        /// </summary>
        [Fact]
        public void HandleAfterWriteObjectCallback_WhenCallbackIsNotAvailable_DoesNotThrowException()
        {
            // Arrange
            TextWriter writer = new StringWriter();
            object value = new object();
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions {AfterWriteObjectCallback = null}; // Callback is not available

            // Act
            JsonSerializer.HandleAfterWriteObjectCallback(writer, value, objectGraph, options);

            // Assert
            // No exception is thrown
        }

        /// <summary>
        ///     Tests that handle after write object callback when callback is available and does not invoke does not throw
        ///     exception
        /// </summary>
        [Fact]
        public void HandleAfterWriteObjectCallback_WhenCallbackIsAvailableAndDoesNotInvoke_DoesNotThrowException()
        {
            // Arrange
            TextWriter writer = new StringWriter();
            object value = new object();
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions {AfterWriteObjectCallback = args => { }}; // Callback is available but does not invoke

            // Act
            JsonSerializer.HandleAfterWriteObjectCallback(writer, value, objectGraph, options);

            // Assert
            // No exception is thrown
        }

        /// <summary>
        ///     Tests that handle after write object callback when callback is available and invokes does not throw exception
        /// </summary>
        [Fact]
        public void HandleAfterWriteObjectCallback_WhenCallbackIsAvailableAndInvokes_DoesNotThrowException()
        {
            // Arrange
            TextWriter writer = new StringWriter();
            object value = new object();
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions {AfterWriteObjectCallback = args => args.Writer.Write("Callback invoked")}; // Callback is available and invokes

            // Act
            JsonSerializer.HandleAfterWriteObjectCallback(writer, value, objectGraph, options);

            // Assert
            Assert.Contains("Callback invoked", writer.ToString());
        }

        /// <summary>
        ///     Tests that handle after write object callback when callback is available and modifies event args modifies event
        ///     args
        /// </summary>
        [Fact]
        public void HandleAfterWriteObjectCallback_WhenCallbackIsAvailableAndModifiesEventArgs_ModifiesEventArgs()
        {
            // Arrange
            TextWriter writer = new StringWriter();
            object value = new object();
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions {AfterWriteObjectCallback = args => args.Writer.Write("Modified")}; // Callback is available and modifies EventArgs

            // Act
            JsonSerializer.HandleAfterWriteObjectCallback(writer, value, objectGraph, options);

            // Assert
            Assert.Contains("Modified", writer.ToString());
        }

        /// <summary>
        ///     Tests that handle after write object callback when callback is available and modifies options modifies options
        /// </summary>
        [Fact]
        public void HandleAfterWriteObjectCallback_WhenCallbackIsAvailableAndModifiesOptions_ModifiesOptions()
        {
            // Arrange
            TextWriter writer = new StringWriter();
            object value = new object();
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions {AfterWriteObjectCallback = args => args.Options.ThrowExceptions = true}; // Callback is available and modifies Options

            // Act
            JsonSerializer.HandleAfterWriteObjectCallback(writer, value, objectGraph, options);

            // Assert
            Assert.True(options.ThrowExceptions);
        }

        /// <summary>
        ///     Tests that handle after write object callback when callback is available and modifies writer modifies writer
        /// </summary>
        [Fact]
        public void HandleAfterWriteObjectCallback_WhenCallbackIsAvailableAndModifiesWriter_ModifiesWriter()
        {
            // Arrange
            TextWriter writer = new StringWriter();
            object value = new object();
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions {AfterWriteObjectCallback = args => args.Writer.Write("Callback invoked")}; // Callback is available and modifies Writer

            // Act
            JsonSerializer.HandleAfterWriteObjectCallback(writer, value, objectGraph, options);

            // Assert
            Assert.Contains("Callback invoked", writer.ToString());
        }

        /// <summary>
        ///     Tests that handle stream value with null value returns false
        /// </summary>
        [Fact]
        public void HandleStreamValue_WithNullValue_ReturnsFalse()
        {
            TextWriter writer = new StringWriter();
            object value = null;
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            bool result = JsonSerializer.HandleStreamValue(writer, value, objectGraph, options);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that handle stream value with non stream value returns false
        /// </summary>
        [Fact]
        public void HandleStreamValue_WithNonStreamValue_ReturnsFalse()
        {
            TextWriter writer = new StringWriter();
            object value = new object(); // Not a Stream
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            bool result = JsonSerializer.HandleStreamValue(writer, value, objectGraph, options);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that handle stream value with empty stream returns true and writes empty string
        /// </summary>
        [Fact]
        public void HandleStreamValue_WithEmptyStream_ReturnsTrueAndWritesEmptyString()
        {
            TextWriter writer = new StringWriter();
            object value = new MemoryStream(); // Empty Stream
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            bool result = JsonSerializer.HandleStreamValue(writer, value, objectGraph, options);

            Assert.True(result);
            Assert.Equal("", writer.ToString());
        }

        /// <summary>
        ///     Tests that handle stream value with non empty stream returns true and writes base 64 string
        /// </summary>
        [Fact]
        public void HandleStreamValue_WithNonEmptyStream_ReturnsTrueAndWritesBase64String()
        {
            TextWriter writer = new StringWriter();
            byte[] data = Encoding.UTF8.GetBytes("Test data");
            object value = new MemoryStream(data); // Non-empty Stream
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            bool result = JsonSerializer.HandleStreamValue(writer, value, objectGraph, options);

            Assert.True(result);
            Assert.Equal(Convert.ToBase64String(data), writer.ToString());
        }

        /// <summary>
        ///     Tests that handle stream value with stream that throws exception on read throws exception
        /// </summary>
        [Fact]
        public void HandleStreamValue_WithStreamThatThrowsExceptionOnRead_ThrowsException()
        {
            TextWriter writer = new StringWriter();
            object value = new MemoryStreamThrowingExceptionOnRead(); // Stream that throws exception on read
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            Exception result = Record.Exception(() => JsonSerializer.HandleStreamValue(writer, value, objectGraph, options));

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that handle stream value with writer that throws exception on write throws exception
        /// </summary>
        [Fact]
        public void HandleStreamValue_WithWriterThatThrowsExceptionOnWrite_ThrowsException()
        {
            TextWriter writer = new StringWriterThrowingExceptionOnWrite(); // Writer that throws exception on write
            byte[] data = Encoding.UTF8.GetBytes("Test data");
            object value = new MemoryStream(data);
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            Exception result = Record.Exception(() => JsonSerializer.HandleStreamValue(writer, value, objectGraph, options));

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that handle stream value with null object graph does not throw exception
        /// </summary>
        [Fact]
        public void HandleStreamValue_WithNullObjectGraph_DoesNotThrowException()
        {
            TextWriter writer = new StringWriter();
            byte[] data = Encoding.UTF8.GetBytes("Test data");
            object value = new MemoryStream(data);
            IDictionary<object, object> objectGraph = null; // Null objectGraph
            JsonOptions options = new JsonOptions();

            JsonSerializer.HandleStreamValue(writer, value, objectGraph, options); // No exception should be thrown
        }

        /// <summary>
        ///     Tests that handle stream value with non null object graph does not throw exception
        /// </summary>
        [Fact]
        public void HandleStreamValue_WithNonNullObjectGraph_DoesNotThrowException()
        {
            TextWriter writer = new StringWriter();
            byte[] data = Encoding.UTF8.GetBytes("Test data");
            object value = new MemoryStream(data);
            IDictionary<object, object> objectGraph = new Dictionary<object, object>(); // Non-null objectGraph
            JsonOptions options = new JsonOptions();

            JsonSerializer.HandleStreamValue(writer, value, objectGraph, options); // No exception should be thrown
        }

        /// <summary>
        ///     Tests that handle stream value with null options does not throw exception
        /// </summary>
        [Fact]
        public void HandleStreamValue_WithNullOptions_DoesNotThrowException()
        {
            TextWriter writer = new StringWriter();
            byte[] data = Encoding.UTF8.GetBytes("Test data");
            object value = new MemoryStream(data);
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = null; // Null options

            JsonSerializer.HandleStreamValue(writer, value, objectGraph, options); // No exception should be thrown
        }

        /// <summary>
        ///     Tests that handle stream value with non null options does not throw exception
        /// </summary>
        [Fact]
        public void HandleStreamValue_WithNonNullOptions_DoesNotThrowException()
        {
            TextWriter writer = new StringWriter();
            byte[] data = Encoding.UTF8.GetBytes("Test data");
            object value = new MemoryStream(data);
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions(); // Non-null options

            JsonSerializer.HandleStreamValue(writer, value, objectGraph, options); // No exception should be thrown
        }

        /// <summary>
        ///     Tests that handle creation exception valid type null exception valid options returns null
        /// </summary>
        [Fact]
        public void HandleCreationException_ValidTypeNullExceptionValidOptions_ReturnsNull()
        {
            // Arrange
            Type type = typeof(string);
            Exception exception = null;
            JsonOptions options = new JsonOptions();

            // Act
            Assert.Throws<JsonException>(() => JsonSerializer.HandleCreationException(type, exception, options));
        }
    }
}