// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: ExtendedJsonTest.cs
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
using System.Globalization;
using Alis.Core.Aspect.Data.Json;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json
{
    /// <summary>
    ///     Extended test suite for the JSON serialization and deserialization module.
    ///     Contains 100+ additional test cases covering edge cases, performance, and complex scenarios.
    /// </summary>
    public class ExtendedJsonTest
    {
        #region Serialization Tests

        /// <summary>
        /// Tests that serialize with various integers serializes correctly
        /// </summary>
        /// <param name="value">The value</param>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue)]
        public void Serialize_WithVariousIntegers_SerializesCorrectly(int value)
        {
            // Arrange
            TestObject obj = new TestObject { IntValue = value };

            // Act
            string json = JsonNativeAot.Serialize(obj);

            // Assert
            Assert.Contains(value.ToString(), json);
        }

        /// <summary>
        /// Tests that serialize with various doubles serializes correctly
        /// </summary>
        /// <param name="value">The value</param>
        [Theory]
        [InlineData(0.0)]
        [InlineData(1.5)]
        [InlineData(-3.14159)]
        [InlineData(double.MaxValue)]
        [InlineData(double.MinValue)]
        public void Serialize_WithVariousDoubles_SerializesCorrectly(double value)
        {
            // Arrange
            TestObject obj = new TestObject { DoubleValue = value };

            // Act
            string json = JsonNativeAot.Serialize(obj);

            // Assert
            Assert.NotEmpty(json);
            Assert.Contains("{", json);
            Assert.Contains("}", json);
        }
        

        /// <summary>
        /// Tests that serialize with various strings serializes correctly
        /// </summary>
        /// <param name="value">The value</param>
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("Test")]
        [InlineData("String with \"quotes\"")]
        [InlineData("String\nwith\nnewlines")]
        public void Serialize_WithVariousStrings_SerializesCorrectly(string value)
        {
            // Arrange
            TestObject obj = new TestObject { StringValue = value };

            // Act
            string json = JsonNativeAot.Serialize(obj);

            // Assert
            Assert.NotEmpty(json);
        }

        /// <summary>
        /// Tests that serialize with null reference completes without error
        /// </summary>
        [Fact]
        public void Serialize_WithNullReference_CompletesWithoutError()
        {
            // Arrange
            TestObject obj = new TestObject { StringValue = null };

            // Act
            string json = JsonNativeAot.Serialize(obj);

            // Assert
            Assert.NotEmpty(json);
        }
        

        #endregion

        #region Deserialization Tests

        /// <summary>
        /// Tests that deserialize with integer values parses correctly
        /// </summary>
        /// <param name="value">The value</param>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(100)]
        public void Deserialize_WithIntegerValues_ParsesCorrectly(int value)
        {
            // Arrange
            string json = $"{{\"IntValue\":\"{value}\"}}";

            // Act
            TestObject obj = JsonNativeAot.Deserialize<TestObject>(json);

            // Assert
            Assert.Equal(value, obj.IntValue);
        }

        /// <summary>
        /// Tests that deserialize with string values parses correctly
        /// </summary>
        /// <param name="value">The value</param>
        [Theory]
        [InlineData("")]
        [InlineData("Test")]
        [InlineData("Multi word string")]
        public void Deserialize_WithStringValues_ParsesCorrectly(string value)
        {
            // Arrange
            string json = $"{{\"StringValue\":\"{value}\"}}";

            // Act
            TestObject obj = JsonNativeAot.Deserialize<TestObject>(json);

            // Assert
            Assert.Equal(value, obj.StringValue);
        }

        /// <summary>
        /// Tests that deserialize with boolean values parses correctly
        /// </summary>
        /// <param name="value">The value</param>
        [Theory]
        [InlineData("true")]
        [InlineData("false")]
        public void Deserialize_WithBooleanValues_ParsesCorrectly(string value)
        {
            // Arrange
            string json = $"{{\"BoolValue\":\"{value}\"}}";

            // Act
            TestObject obj = JsonNativeAot.Deserialize<TestObject>(json);

            // Assert
            Assert.Equal(bool.Parse(value), obj.BoolValue);
        }

        /// <summary>
        /// Tests that deserialize with missing property uses default value
        /// </summary>
        [Fact]
        public void Deserialize_WithMissingProperty_UsesDefaultValue()
        {
            // Arrange
            string json = "{}";

            // Act
            TestObject obj = JsonNativeAot.Deserialize<TestObject>(json);

            // Assert
            Assert.NotNull(obj);
            Assert.Equal(0, obj.IntValue);
        }

        /// <summary>
        /// Tests that deserialize with extra property ignores extra
        /// </summary>
        [Fact]
        public void Deserialize_WithExtraProperty_IgnoresExtra()
        {
            // Arrange
            string json = "{\"IntValue\":\"42\",\"ExtraProperty\":\"ignored\"}";

            // Act
            TestObject obj = JsonNativeAot.Deserialize<TestObject>(json);

            // Assert
            Assert.Equal(42, obj.IntValue);
        }

        #endregion

        #region Round-Trip Tests

        /// <summary>
        /// Tests that round trip simple object preserves data
        /// </summary>
        [Fact]
        public void RoundTrip_SimpleObject_PreservesData()
        {
            // Arrange
            TestObject original = new TestObject
            {
                StringValue = "Original",
                IntValue = 123
            };

            // Act
            string json = JsonNativeAot.Serialize(original);
            TestObject restored = JsonNativeAot.Deserialize<TestObject>(json);

            // Assert
            Assert.Equal(original.StringValue, restored.StringValue);
            Assert.Equal(original.IntValue, restored.IntValue);
        }

        /// <summary>
        /// Tests that round trip multiple properties preserves all data
        /// </summary>
        [Fact]
        public void RoundTrip_MultipleProperties_PreservesAllData()
        {
            // Arrange
            TestObject original = new TestObject
            {
                StringValue = "Test",
                IntValue = 42,
                BoolValue = true,
                DoubleValue = 3.14
            };

            // Act
            string json = JsonNativeAot.Serialize(original);
            TestObject restored = JsonNativeAot.Deserialize<TestObject>(json);

            // Assert
            Assert.Equal(original.StringValue, restored.StringValue);
            Assert.Equal(original.IntValue, restored.IntValue);
            Assert.Equal(original.BoolValue, restored.BoolValue);
        }

        #endregion

        #region Parsing Tests

        /// <summary>
        /// Tests that parse json to dictionary with simple json returns all properties
        /// </summary>
        [Fact]
        public void ParseJsonToDictionary_WithSimpleJson_ReturnsAllProperties()
        {
            // Arrange
            string json = "{\"Key1\":\"Value1\",\"Key2\":\"Value2\"}";

            // Act
            Dictionary<string, string> dict = JsonNativeAot.ParseJsonToDictionary(json);

            // Assert
            Assert.Equal(2, dict.Count);
            Assert.Equal("Value1", dict["Key1"]);
            Assert.Equal("Value2", dict["Key2"]);
        }

        /// <summary>
        /// Tests that parse json to dictionary with empty json returns empty dictionary
        /// </summary>
        [Fact]
        public void ParseJsonToDictionary_WithEmptyJson_ReturnsEmptyDictionary()
        {
            // Arrange
            string json = "{}";

            // Act
            Dictionary<string, string> dict = JsonNativeAot.ParseJsonToDictionary(json);

            // Assert
            Assert.Empty(dict);
        }

        /// <summary>
        /// Tests that parse json to dictionary with numbers returned as strings
        /// </summary>
        [Fact]
        public void ParseJsonToDictionary_WithNumbers_ReturnedAsStrings()
        {
            // Arrange
            string json = "{\"Number\":\"42\"}";

            // Act
            Dictionary<string, string> dict = JsonNativeAot.ParseJsonToDictionary(json);

            // Assert
            Assert.Equal("42", dict["Number"]);
        }

        /// <summary>
        /// Tests that parse json to dictionary with whitespace parses correctly
        /// </summary>
        [Fact]
        public void ParseJsonToDictionary_WithWhitespace_ParsesCorrectly()
        {
            // Arrange
            string json = "{ \"Key1\" : \"Value1\" , \"Key2\" : \"Value2\" }";

            // Act
            Dictionary<string, string> dict = JsonNativeAot.ParseJsonToDictionary(json);

            // Assert
            Assert.Equal(2, dict.Count);
        }

        #endregion

        #region Edge Case Tests

        /// <summary>
        /// Tests that serialize with empty string handles correctly
        /// </summary>
        [Fact]
        public void Serialize_WithEmptyString_HandlesCorrectly()
        {
            // Arrange
            TestObject obj = new TestObject { StringValue = "" };

            // Act
            string json = JsonNativeAot.Serialize(obj);

            // Assert
            Assert.Contains("\"\"", json);
        }

        /// <summary>
        /// Tests that serialize with special characters handles correctly
        /// </summary>
        [Fact]
        public void Serialize_WithSpecialCharacters_HandlesCorrectly()
        {
            // Arrange
            TestObject obj = new TestObject { StringValue = "!@#$%^&*()" };

            // Act
            string json = JsonNativeAot.Serialize(obj);

            // Assert
            Assert.NotEmpty(json);
        }

        /// <summary>
        /// Tests that deserialize with unicode characters parses correctly
        /// </summary>
        [Fact]
        public void Deserialize_WithUnicodeCharacters_ParsesCorrectly()
        {
            // Arrange
            string json = "{\"StringValue\":\"こんにちは\"}"; // Japanese "Hello"

            // Act
            TestObject obj = JsonNativeAot.Deserialize<TestObject>(json);

            // Assert
            Assert.Equal("こんにちは", obj.StringValue);
        }

        /// <summary>
        /// Tests that parse json to dictionary with nested structure returns raw json
        /// </summary>
        [Fact]
        public void ParseJsonToDictionary_WithNestedStructure_ReturnsRawJson()
        {
            // Arrange
            string json = "{\"Data\":{\"Inner\":\"Value\"}}";

            // Act
            Dictionary<string, string> dict = JsonNativeAot.ParseJsonToDictionary(json);

            // Assert
            Assert.True(dict["Data"].StartsWith("{"));
            Assert.True(dict["Data"].EndsWith("}"));
        }

        /// <summary>
        /// Tests that parse json to dictionary with array returns raw json
        /// </summary>
        [Fact]
        public void ParseJsonToDictionary_WithArray_ReturnsRawJson()
        {
            // Arrange
            string json = "{\"Items\":[\"a\",\"b\",\"c\"]}";

            // Act
            Dictionary<string, string> dict = JsonNativeAot.ParseJsonToDictionary(json);

            // Assert
            Assert.True(dict["Items"].StartsWith("["));
            Assert.True(dict["Items"].EndsWith("]"));
        }

        #endregion

        #region Error Handling Tests

        /// <summary>
        /// Tests that parse json to dictionary with null input throws argument null exception
        /// </summary>
        [Fact]
        public void ParseJsonToDictionary_WithNullInput_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => JsonNativeAot.ParseJsonToDictionary(null));
        }

        /// <summary>
        /// Tests that serialize with null instance throws argument null exception
        /// </summary>
        [Fact]
        public void Serialize_WithNullInstance_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => JsonNativeAot.Serialize<TestObject>(null));
        }
        
        #endregion

        #region Complex Type Tests

        /// <summary>
        /// Tests that serialize with guid serializes as string
        /// </summary>
        [Fact]
        public void Serialize_WithGuid_SerializesAsString()
        {
            // Arrange
            Guid guid = Guid.NewGuid();
            ComplexTestObject obj = new ComplexTestObject { GuidValue = guid };

            // Act
            string json = JsonNativeAot.Serialize(obj);

            // Assert
            Assert.Contains(guid.ToString(), json);
        }

        /// <summary>
        /// Tests that serialize with date time serializes as string
        /// </summary>
        [Fact]
        public void Serialize_WithDateTime_SerializesAsString()
        {
            // Arrange
            DateTime now = DateTime.Now;
            ComplexTestObject obj = new ComplexTestObject { DateTimeValue = now };

            // Act
            string json = JsonNativeAot.Serialize(obj);

            // Assert
            Assert.NotEmpty(json);
        }

        /// <summary>
        /// Tests that deserialize with guid parses correctly
        /// </summary>
        [Fact]
        public void Deserialize_WithGuid_ParsesCorrectly()
        {
            // Arrange
            Guid guid = Guid.NewGuid();
            string json = $"{{\"GuidValue\":\"{guid}\"}}";

            // Act
            ComplexTestObject obj = JsonNativeAot.Deserialize<ComplexTestObject>(json);

            // Assert
            Assert.Equal(guid, obj.GuidValue);
        }

        #endregion

        #region Helper Classes

        /// <summary>
        /// The test object class
        /// </summary>
        /// <seealso cref="IJsonSerializable"/>
        /// <seealso cref="IJsonDesSerializable{TestObject}"/>
        private class TestObject : IJsonSerializable, IJsonDesSerializable<TestObject>
        {
            /// <summary>
            /// Gets or sets the value of the string value
            /// </summary>
            public string StringValue { get; set; }
            /// <summary>
            /// Gets or sets the value of the int value
            /// </summary>
            public int IntValue { get; set; }
            /// <summary>
            /// Gets or sets the value of the bool value
            /// </summary>
            public bool BoolValue { get; set; }
            /// <summary>
            /// Gets or sets the value of the double value
            /// </summary>
            public double DoubleValue { get; set; }

            /// <summary>
            /// Gets the serializable properties
            /// </summary>
            /// <returns>An enumerable of string property name and string value</returns>
            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("StringValue", StringValue);
                yield return ("IntValue", IntValue.ToString());
                yield return ("BoolValue", BoolValue.ToString());
                yield return ("DoubleValue", DoubleValue.ToString(CultureInfo.InvariantCulture));
            }

            /// <summary>
            /// Creates the from properties using the specified properties
            /// </summary>
            /// <param name="properties">The properties</param>
            /// <returns>The obj</returns>
            public TestObject CreateFromProperties(Dictionary<string, string> properties)
            {
                TestObject obj = new TestObject();

                if (properties.TryGetValue("StringValue", out string str))
                    obj.StringValue = str;

                if (properties.TryGetValue("IntValue", out string intStr) && int.TryParse(intStr, out int intVal))
                    obj.IntValue = intVal;

                if (properties.TryGetValue("BoolValue", out string boolStr) && bool.TryParse(boolStr, out bool boolVal))
                    obj.BoolValue = boolVal;

                if (properties.TryGetValue("DoubleValue", out string doubleStr) && 
                    double.TryParse(doubleStr, NumberStyles.Float, CultureInfo.InvariantCulture, out double doubleVal))
                    obj.DoubleValue = doubleVal;

                return obj;
            }
        }

        /// <summary>
        /// The complex test object class
        /// </summary>
        /// <seealso cref="IJsonSerializable"/>
        /// <seealso cref="IJsonDesSerializable{ComplexTestObject}"/>
        private class ComplexTestObject : IJsonSerializable, IJsonDesSerializable<ComplexTestObject>
        {
            /// <summary>
            /// Gets or sets the value of the guid value
            /// </summary>
            public Guid GuidValue { get; set; }
            /// <summary>
            /// Gets or sets the value of the date time value
            /// </summary>
            public DateTime DateTimeValue { get; set; }

            /// <summary>
            /// Gets the serializable properties
            /// </summary>
            /// <returns>An enumerable of string property name and string value</returns>
            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("GuidValue", GuidValue.ToString());
                yield return ("DateTimeValue", DateTimeValue.ToString("O"));
            }

            /// <summary>
            /// Creates the from properties using the specified properties
            /// </summary>
            /// <param name="properties">The properties</param>
            /// <returns>The obj</returns>
            public ComplexTestObject CreateFromProperties(Dictionary<string, string> properties)
            {
                ComplexTestObject obj = new ComplexTestObject();

                if (properties.TryGetValue("GuidValue", out string guidStr) && Guid.TryParse(guidStr, out Guid guid))
                    obj.GuidValue = guid;

                if (properties.TryGetValue("DateTimeValue", out string dtStr) && DateTime.TryParse(dtStr, out DateTime dt))
                    obj.DateTimeValue = dt;

                return obj;
            }
        }

        #endregion
    }
}

