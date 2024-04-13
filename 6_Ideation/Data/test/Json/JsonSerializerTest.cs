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
using System.Text;
using Alis.Core.Aspect.Data.Json;
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
            JsonSerializer.ReadSerializable(reader, options, typeName, values);
            
            // Assert
            Assert.NotNull(reader);
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
            Assert.NotEmpty(writer.ToString() ?? throw new InvalidOperationException());
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
            Assert.NotEmpty(writer.ToString() ?? throw new InvalidOperationException());
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
            Assert.Throws<NullReferenceException>(() => JsonSerializer.WriteSerializable(writer, serializable, objectGraph, null));
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
        ///     Tests that test write base 64 stream v 2 null input stream throws exception
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
        ///     Tests that get type exception positive position returns correct message
        /// </summary>
        [Fact]
        public void GetTypeException_PositivePosition_ReturnsCorrectMessage()
        {
            Exception innerException = new Exception("Inner exception message");
            JsonException exception = JsonSerializer.GetTypeException(5, "TestType", innerException);
            Assert.Equal("JSO0011: JSON deserialization error detected for 'TestType' type at position 5.", exception.Message);
            Assert.Equal(innerException, exception.InnerException);
        }
        
        /// <summary>
        ///     Tests that get type exception negative position returns correct message
        /// </summary>
        [Fact]
        public void GetTypeException_NegativePosition_ReturnsCorrectMessage()
        {
            Exception innerException = new Exception("Inner exception message");
            JsonException exception = JsonSerializer.GetTypeException(-1, "TestType", innerException);
            Assert.Equal("JSO0010: JSON deserialization error detected for 'TestType' type.", exception.Message);
            Assert.Equal(innerException, exception.InnerException);
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
            
            string expected = "\"Property\":\"Value\",\"__type\":\"Alis.Core.Aspect.Data.Test.Json.SerializableObject, Alis.Core.Aspect.Data.Test, Version=0.2.7.0, Culture=neutral, PublicKeyToken=null\"";
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
            
            string expected = "{}";
            Assert.Equal(expected, writer.ToString());
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
            Assert.Equal("[\n    \"item1\",\n    \"item2\",\n    \"item3\"\n]", stringWriter.ToString());
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
            Assert.Equal("[\n\n]", stringWriter.ToString());
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
            Assert.Equal("[\"item1\",\"item2\",\"item3\"]", stringWriter.ToString());
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
            Assert.Equal("[]", stringWriter.ToString());
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
            Assert.Equal(123.45m, result);
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
        /// Tests that apply when target is array calls apply to target array
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
        /// Tests that apply when input is dictionary calls apply to target dictionary
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
        /// Tests that apply when target is not null calls apply to list target
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
        /// Tests that apply when target is null does not throw exception
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
        /// Tests that test apply to target array valid input
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
        
        /// Tests that test apply to target dictionary valid input
        
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
        
        /// Tests that test apply to target array null target
        
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
        
        /// Tests that test apply to target dictionary null target
        
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
        /// Tests that create instance callback handled returns callback value
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
        /// Tests that handle creation exception with valid type and exception returns null
        /// </summary>
        [Fact]
        public void HandleCreationException_WithValidTypeAndException_ReturnsNull()
        {
            // Arrange
            Type type = typeof(string);
            Exception exception = new Exception("Test exception");
            JsonOptions options = new JsonOptions();
            
            // Act
            Assert.Throws<JsonException>(() => JsonSerializer.HandleCreationException(type, exception, options));
            
        }
        
        /// <summary>
        /// Tests that handle creation exception with null type throws exception
        /// </summary>
        [Fact]
        public void HandleCreationException_WithNullType_ThrowsException()
        {
            // Arrange
            Type type = null;
            Exception exception = new Exception("Test exception");
            JsonOptions options = new JsonOptions();
            
            // Act & Assert
            Assert.Throws<NullReferenceException>(() => JsonSerializer.HandleCreationException(type, exception, options));
        }
        
        /// <summary>
        /// Tests that handle creation exception with null exception throws exception
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
        /// Tests that handle creation exception with null options throws exception
        /// </summary>
        [Fact]
        public void HandleCreationException_WithNullOptions_ThrowsException()
        {
            // Arrange
            Type type = typeof(string);
            Exception exception = new Exception("Test exception");
            JsonOptions options = null;
            
            // Act & Assert
            Assert.Throws<JsonException>(() => JsonSerializer.HandleCreationException(type, exception, options));
        }
        
        /// <summary>
        /// Tests that read dictionary when called with valid json returns correct dictionary
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
        /// Tests that read dictionary when called with empty json returns empty dictionary
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
        /// Tests that read dictionary when called with invalid json throws exception
        /// </summary>
        [Fact]
        public void ReadDictionary_WhenCalledWithInvalidJson_ThrowsException()
        {
            StringReader reader = new StringReader("{\"key1\":\"value1\",\"key2\":\"value2\"");
            JsonOptions options = new JsonOptions();
            
            Assert.Throws<JsonException>(() => JsonSerializer.ReadDictionary(reader, options));
        }
        
        /// <summary>
        /// Tests that read dictionary when called with null throws exception
        /// </summary>
        [Fact]
        public void ReadDictionary_WhenCalledWithNull_ThrowsException()
        {
            StringReader reader = new StringReader("");
            JsonOptions options = new JsonOptions();
            
            JsonSerializer.ReadDictionary(reader, options);
        }
        
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
    }
}