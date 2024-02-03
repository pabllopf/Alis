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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using Alis.Core.Aspect.Data.Json;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json
{
    /// <summary>
    /// The json serializer test class
    /// </summary>
    public class JsonSerializerTest
    {
        /// <summary>
        /// Tests that test json serializer deserialize string success
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
        /// Tests that test json serializer deserialize text reader success
        /// </summary>
        [Fact]
        public void TestJsonSerializer_Deserialize_TextReader_Success()
        {
            // Arrange
            string json = "\"Hello, World!\"";
            JsonOptions options = new JsonOptions();
            using var reader = new StringReader(json);

            // Act
            string result = JsonSerializer.Deserialize<string>(reader, options);

            // Assert
            Assert.Equal("Hello, World!", result);
        }

        /// <summary>
        /// Tests that test json serializer deserialize to target success
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
        /// Tests that test json serializer deserialize null input returns null
        /// </summary>
        [Fact]
        public void TestJsonSerializer_Deserialize_NullInput_ReturnsNull()
        {
            // Arrange
            string json = null;
            JsonOptions options = new JsonOptions();

            // Act
            string result = JsonSerializer.Deserialize<string>(json, options);

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        /// Tests that test json serializer deserialize to target null input no changes
        /// </summary>
        [Fact]
        public void TestJsonSerializer_DeserializeToTarget_NullInput_NoChanges()
        {
            // Arrange
            string json = null;
            string target = "Initial Value";
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.DeserializeToTarget(json, target, options);

            // Assert
            Assert.Equal("Initial Value", target);
        }

        /// <summary>
        /// Tests that test json serializer serialize success
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
        /// Tests that test json serializer deserialize success
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
        /// Tests that test json serializer deserialize to target success
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
        /// Tests that test json serializer v 2 deserialize null input returns null
        /// </summary>
        [Fact]
        public void TestJsonSerializer_v2_Deserialize_NullInput_ReturnsNull()
        {
            // Arrange
            string json = null;
            JsonOptions options = new JsonOptions();

            // Act
            object result = JsonSerializer.Deserialize(json, typeof(string), options);

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        /// Tests that test json serializer v 2 deserialize to target null input no changes
        /// </summary>
        [Fact]
        public void TestJsonSerializer_v2_DeserializeToTarget_NullInput_NoChanges()
        {
            // Arrange
            string json = null;
            string target = "Initial Value";
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.DeserializeToTarget(json, target, options);

            // Assert
            Assert.Equal("Initial Value", target);
        }

        /// <summary>
        /// Tests that test json serializer write formatted success
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
        /// Tests that test json serializer escape string success
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
        /// Tests that test json serializer get nullified string value by path success
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
        /// Tests that test json serializer try get value by path success
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
            bool success = dictionary.TryGetValueByPath<int>(path, out int value);

            // Assert
            Assert.False(success);
            Assert.Equal(0, value);
        }

        /// <summary>
        /// Tests that test json serializer equals ignore case success
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
        /// Tests that test json serializer nullify success
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
        /// Tests that test json serializer append char as unicode success
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
        /// Tests that test json serializer serialize formatted success
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
            Assert.Contains("{\n\n}", result);
            Assert.Contains("{\n\n}", result);
        }

        /// <summary>
        /// Tests that test json serializer serialize formatted with text writer success
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
        /// Tests that test json serializer write name value null writer throws argument null exception
        /// </summary>
        [Fact]
        public void TestJsonSerializer_WriteNameValue_NullWriter_ThrowsArgumentNullException()
        {
            // Arrange
            TextWriter writer = null;
            string name = "Test";
            object value = new object();
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => JsonSerializer.WriteNameValue(writer, name, value, objectGraph, options));
        }

        /// <summary>
        /// Tests that test json serializer write name value null name writes empty name
        /// </summary>
        [Fact]
        public void TestJsonSerializer_WriteNameValue_NullName_WritesEmptyName()
        {
            // Arrange
            TextWriter writer = new StringWriter();
            string name = null;
            object value = new object();
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            // Act
            JsonSerializer.WriteNameValue(writer, name, value, objectGraph, options);
            string result = writer.ToString();

            // Assert
            Assert.Contains("\"\":", result);
        }

        /// <summary>
        /// Tests that test json serializer write name value null options uses default options
        /// </summary>
        [Fact]
        public void TestJsonSerializer_WriteNameValue_NullOptions_UsesDefaultOptions()
        {
            // Arrange
            TextWriter writer = new StringWriter();
            string name = "Test";
            object value = new object();
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = null;

            // Act
            JsonSerializer.WriteNameValue(writer, name, value, objectGraph, options);
            string result = writer.ToString();

            // Assert
            Assert.Contains("\"Test\":", result);
        }

        /// <summary>
        /// Tests that test json serializer write name value with write keys without quotes option writes name without quotes
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
        /// Tests that test json serializer apply success
        /// </summary>
        [Fact]
        public void TestJsonSerializer_Apply_Success()
        {
            // Arrange
            int[] target = new int[5];
            IEnumerable input = new List<int> {1, 2, 3, 4, 5};
            JsonOptions options = new JsonOptions();

            // Act
            IDictionary<string, object> inputDictionary = new Dictionary<string, object>();
            JsonSerializer.Apply(inputDictionary, target, options);

            // Assert
            Assert.Equal(new int[] {0, 0, 0, 0, 0}, target);
        }

        /// <summary>
        /// Tests that test json serializer apply null input clears array
        /// </summary>
        [Fact]
        public void TestJsonSerializer_Apply_NullInput_ClearsArray()
        {
            // Arrange
            int[] target = {1, 2, 3, 4, 5};
            JsonOptions options = new JsonOptions();

            // Act
            IDictionary<string, object> input = new Dictionary<string, object>();
            JsonSerializer.Apply(input, target, options);

            // Assert
            Assert.Equal(new int[] {1, 2, 3, 4, 5}, target);
        }

        /// <summary>
        /// Tests that test json serializer are values equal equal values returns true
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
        /// Tests that test json serializer are values equal different values returns false
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
        /// Tests that test json serializer are values equal null values returns true
        /// </summary>
        [Fact]
        public void TestJsonSerializer_AreValuesEqual_NullValues_ReturnsTrue()
        {
            // Arrange
            object o1 = null;
            object o2 = null;

            // Act
            bool result = JsonSerializer.AreValuesEqual(o1, o2);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Tests that test get object name member info success
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
        /// Tests that test try get object default value property descriptor success
        /// </summary>
        [Fact]
        public void TestTryGetObjectDefaultValue_PropertyDescriptor_Success()
        {
            // Arrange
            PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(typeof(JsonSerializer))["Serialize"];

            // Act
            Assert.Throws<NullReferenceException>(() => JsonSerializer.TryGetObjectDefaultValue(propertyDescriptor, out object value));
        }

        /// <summary>
        /// Tests that test get object name property descriptor success
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
        /// Tests that test has script ignore property descriptor success
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
        /// Tests that test has script ignore member info success
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
        /// Tests that test try parse date time valid date time string returns date time
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
        /// Tests that test try parse date time invalid date time string returns null
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
        /// Tests that test try parse date time null date time string returns null
        /// </summary>
        [Fact]
        public void TestTryParseDateTime_NullDateTimeString_ReturnsNull()
        {
            string nullDateTimeString = null;
            DateTimeStyles styles = DateTimeStyles.AssumeUniversal;
            DateTime? result = JsonSerializer.TryParseDateTime(nullDateTimeString, styles);

            Assert.Null(result);
        }

        /// <summary>
        /// Tests that test try parse date time valid date time string with styles returns date time
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
        /// Tests that test try parse date time invalid date time string with styles returns null
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
        /// Tests that test append time zone utc offset with utc date time no offset appended
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
        /// Tests that test append time zone utc offset with non utc date time offset appended
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
        /// Tests that test abs with positive value returns same value
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
        /// Tests that test abs with negative value returns positive value
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
        /// Tests that test get json attribute without json attribute returns null
        /// </summary>
        [Fact]
        public void TestGetJsonAttribute_WithoutJsonAttribute_ReturnsNull()
        {
            // Arrange
            MemberInfo memberInfo = typeof(JsonSerializer).GetMember("Serialize")[0]; // Assuming this method doesn't have a JsonAttribute

            // Act
            JsonAttribute result = JsonSerializer.GetJsonAttribute(memberInfo);

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        /// Tests that test read serializable valid serializable returns serializable
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
            JsonSerializer.ReadSerializable(reader, options, typeName, values);

            // Assert
            Assert.NotNull(reader);
        }

        /// <summary>
        /// Tests that test read serializable invalid serializable returns null
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
        /// Tests that test read serializable null serializable returns null
        /// </summary>
        [Fact]
        public void TestReadSerializable_NullSerializable_ReturnsNull()
        {
            // Arrange
            TextReader reader = new StringReader("null serializable string");
            JsonOptions options = new JsonOptions();
            string typeName = null;
            Dictionary<string, object> values = new Dictionary<string, object> {{"key", "value"}};

            // Act
            Assert.Throws<JsonException>(() => JsonSerializer.ReadSerializable(reader, options, typeName, values));
        }

        /// <summary>
        /// Tests that test try parse date time v 2 valid date time string returns date time
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
        /// Tests that test try parse date time v 2 invalid date time string returns null
        /// </summary>
        [Fact]
        public void TestTryParseDateTime_V2_InvalidDateTimeString_ReturnsNull()
        {
            string invalidDateTimeString = "invalid date time string";
            DateTime? result = JsonSerializer.TryParseDateTime(invalidDateTimeString);

            Assert.Null(result);
        }

        /// <summary>
        /// Tests that test try parse date time v 2 null date time string returns null
        /// </summary>
        [Fact]
        public void TestTryParseDateTime_V2_NullDateTimeString_ReturnsNull()
        {
            string nullDateTimeString = null;
            DateTime? result = JsonSerializer.TryParseDateTime(nullDateTimeString);

            Assert.Null(result);
        }

        /// <summary>
        /// Tests that test write serializable valid serializable writes serializable
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
            Assert.NotEmpty(writer.ToString());
        }

        /// <summary>
        /// Tests that test write serializable null serializable writes nothing
        /// </summary>
        [Fact]
        public void TestWriteSerializable_NullSerializable_WritesNothing()
        {
            // Arrange
            TextWriter writer = new StringWriter();
            ISerializable serializable = null;
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            // Act
            Assert.Throws<NullReferenceException>(() => JsonSerializer.WriteSerializable(writer, serializable, objectGraph, options));
        }

        /// <summary>
        /// Tests that test write serializable empty object graph writes serializable
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
            Assert.NotEmpty(writer.ToString());
        }

        /// <summary>
        /// Tests that test write serializable null options throws exception
        /// </summary>
        [Fact]
        public void TestWriteSerializable_NullOptions_ThrowsException()
        {
            // Arrange
            TextWriter writer = new StringWriter();
            TestSerializable serializable = new TestSerializable();
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = null;

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => JsonSerializer.WriteSerializable(writer, serializable, objectGraph, options));
        }

        /// <summary>
        /// Tests that test write base 64 stream valid streams returns total
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
        /// Tests that test write base 64 stream empty input stream returns zero
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
        /// Tests that test write base 64 stream null input stream throws exception
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
        /// Tests that test write base 64 stream null output stream throws exception
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
        /// Tests that test write base 64 stream v 2 valid streams returns total
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
        /// Tests that test write base 64 stream v 2 empty input stream returns zero
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
        /// Tests that test write base 64 stream v 2 null input stream throws exception
        /// </summary>
        [Fact]
        public void TestWriteBase64Stream_V2_NullInputStream_ThrowsException()
        {
            // Arrange
            StringWriter writer = new StringWriter();
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => JsonSerializer.WriteBase64Stream(writer, null, objectGraph, options));
        }

        /// <summary>
        /// Tests that test write base 64 stream null writer throws exception
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
        /// Tests that test read x 4 valid hexadecimal string returns correct ushort
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
        /// Tests that test read x 4 invalid hexadecimal string throws exception
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
        /// Tests that test read x 4 empty string throws exception
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
        /// Tests that test read new valid json returns correct object
        /// </summary>
        [Fact]
        public void TestReadNew_ValidJson_ReturnsCorrectObject()
        {
            // Arrange
            string json = "\"new Date(1633020442000)\"";
            TextReader reader = new StringReader(json);
            JsonOptions options = new JsonOptions();
            bool arrayEnd;

            // Act
            Assert.Throws<JsonException>(() => JsonSerializer.ReadNew(reader, options, out arrayEnd));
        }

        /// <summary>
        /// Tests that test read new null json returns null
        /// </summary>
        [Fact]
        public void TestReadNew_NullJson_ReturnsNull()
        {
            // Arrange
            string json = "\"null\"";
            TextReader reader = new StringReader(json);
            JsonOptions options = new JsonOptions();
            bool arrayEnd;

            // Act
            Assert.Throws<JsonException>(() => JsonSerializer.ReadNew(reader, options, out arrayEnd));
        }

        /// <summary>
        /// Tests that test read new invalid json throws exception
        /// </summary>
        [Fact]
        public void TestReadNew_InvalidJson_ThrowsException()
        {
            // Arrange
            string json = "\"invalid\"";
            TextReader reader = new StringReader(json);
            JsonOptions options = new JsonOptions();
            bool arrayEnd;

            // Act & Assert
            Assert.Throws<JsonException>(() => JsonSerializer.ReadNew(reader, options, out arrayEnd));
        }

        /// <summary>
        /// Tests that test read new end of array returns array end true
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
        /// Tests that test get eof exception valid char returns correct exception message
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
        /// Tests that test get eof exception different char returns correct exception message
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
        /// Tests that test read array valid json array returns correct array
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
        /// Tests that test read array empty json array returns empty array
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
        /// Tests that test read array invalid json array throws exception
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
        /// Tests that test try get object default value valid member info returns true
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
        /// Tests that test try get object default value no default value returns false
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
        /// Tests that test change type valid input returns correct object
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
        /// Tests that test change type null input returns default for value type
        /// </summary>
        [Fact]
        public void TestChangeType_NullInput_ReturnsDefaultForValueType()
        {
            // Arrange
            object input = null;
            Type targetType = typeof(int);
            JsonOptions options = new JsonOptions();

            // Act
            object result = JsonSerializer.ChangeType(input, targetType, options);

            // Assert
            Assert.IsType<int>(result);
            Assert.Equal(0, result);
        }

        /// <summary>
        /// Tests that test change type null input returns null for reference type
        /// </summary>
        [Fact]
        public void TestChangeType_NullInput_ReturnsNullForReferenceType()
        {
            // Arrange
            object input = null;
            Type targetType = typeof(string);
            JsonOptions options = new JsonOptions();

            // Act
            object result = JsonSerializer.ChangeType(input, targetType, options);

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        /// Tests that test change type invalid conversion throws exception
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
    }
}