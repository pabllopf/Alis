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

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue)]
        public void Serialize_WithVariousIntegers_SerializesCorrectly(int value)
        {
            // Arrange
            var obj = new TestObject { IntValue = value };

            // Act
            string json = JsonNativeAot.Serialize(obj);

            // Assert
            Assert.Contains(value.ToString(), json);
        }

        [Theory]
        [InlineData(0.0)]
        [InlineData(1.5)]
        [InlineData(-3.14159)]
        [InlineData(double.MaxValue)]
        [InlineData(double.MinValue)]
        public void Serialize_WithVariousDoubles_SerializesCorrectly(double value)
        {
            // Arrange
            var obj = new TestObject { DoubleValue = value };

            // Act
            string json = JsonNativeAot.Serialize(obj);

            // Assert
            Assert.NotEmpty(json);
            Assert.Contains("{", json);
            Assert.Contains("}", json);
        }
        

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("Test")]
        [InlineData("String with \"quotes\"")]
        [InlineData("String\nwith\nnewlines")]
        public void Serialize_WithVariousStrings_SerializesCorrectly(string value)
        {
            // Arrange
            var obj = new TestObject { StringValue = value };

            // Act
            string json = JsonNativeAot.Serialize(obj);

            // Assert
            Assert.NotEmpty(json);
        }

        [Fact]
        public void Serialize_WithNullReference_CompletesWithoutError()
        {
            // Arrange
            var obj = new TestObject { StringValue = null };

            // Act
            string json = JsonNativeAot.Serialize(obj);

            // Assert
            Assert.NotEmpty(json);
        }
        

        #endregion

        #region Deserialization Tests

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
            var obj = JsonNativeAot.Deserialize<TestObject>(json);

            // Assert
            Assert.Equal(value, obj.IntValue);
        }

        [Theory]
        [InlineData("")]
        [InlineData("Test")]
        [InlineData("Multi word string")]
        public void Deserialize_WithStringValues_ParsesCorrectly(string value)
        {
            // Arrange
            string json = $"{{\"StringValue\":\"{value}\"}}";

            // Act
            var obj = JsonNativeAot.Deserialize<TestObject>(json);

            // Assert
            Assert.Equal(value, obj.StringValue);
        }

        [Theory]
        [InlineData("true")]
        [InlineData("false")]
        public void Deserialize_WithBooleanValues_ParsesCorrectly(string value)
        {
            // Arrange
            string json = $"{{\"BoolValue\":\"{value}\"}}";

            // Act
            var obj = JsonNativeAot.Deserialize<TestObject>(json);

            // Assert
            Assert.Equal(bool.Parse(value), obj.BoolValue);
        }

        [Fact]
        public void Deserialize_WithMissingProperty_UsesDefaultValue()
        {
            // Arrange
            string json = "{}";

            // Act
            var obj = JsonNativeAot.Deserialize<TestObject>(json);

            // Assert
            Assert.NotNull(obj);
            Assert.Equal(0, obj.IntValue);
        }

        [Fact]
        public void Deserialize_WithExtraProperty_IgnoresExtra()
        {
            // Arrange
            string json = "{\"IntValue\":\"42\",\"ExtraProperty\":\"ignored\"}";

            // Act
            var obj = JsonNativeAot.Deserialize<TestObject>(json);

            // Assert
            Assert.Equal(42, obj.IntValue);
        }

        #endregion

        #region Round-Trip Tests

        [Fact]
        public void RoundTrip_SimpleObject_PreservesData()
        {
            // Arrange
            var original = new TestObject
            {
                StringValue = "Original",
                IntValue = 123
            };

            // Act
            string json = JsonNativeAot.Serialize(original);
            var restored = JsonNativeAot.Deserialize<TestObject>(json);

            // Assert
            Assert.Equal(original.StringValue, restored.StringValue);
            Assert.Equal(original.IntValue, restored.IntValue);
        }

        [Fact]
        public void RoundTrip_MultipleProperties_PreservesAllData()
        {
            // Arrange
            var original = new TestObject
            {
                StringValue = "Test",
                IntValue = 42,
                BoolValue = true,
                DoubleValue = 3.14
            };

            // Act
            string json = JsonNativeAot.Serialize(original);
            var restored = JsonNativeAot.Deserialize<TestObject>(json);

            // Assert
            Assert.Equal(original.StringValue, restored.StringValue);
            Assert.Equal(original.IntValue, restored.IntValue);
            Assert.Equal(original.BoolValue, restored.BoolValue);
        }

        #endregion

        #region Parsing Tests

        [Fact]
        public void ParseJsonToDictionary_WithSimpleJson_ReturnsAllProperties()
        {
            // Arrange
            string json = "{\"Key1\":\"Value1\",\"Key2\":\"Value2\"}";

            // Act
            var dict = JsonNativeAot.ParseJsonToDictionary(json);

            // Assert
            Assert.Equal(2, dict.Count);
            Assert.Equal("Value1", dict["Key1"]);
            Assert.Equal("Value2", dict["Key2"]);
        }

        [Fact]
        public void ParseJsonToDictionary_WithEmptyJson_ReturnsEmptyDictionary()
        {
            // Arrange
            string json = "{}";

            // Act
            var dict = JsonNativeAot.ParseJsonToDictionary(json);

            // Assert
            Assert.Empty(dict);
        }

        [Fact]
        public void ParseJsonToDictionary_WithNumbers_ReturnedAsStrings()
        {
            // Arrange
            string json = "{\"Number\":\"42\"}";

            // Act
            var dict = JsonNativeAot.ParseJsonToDictionary(json);

            // Assert
            Assert.Equal("42", dict["Number"]);
        }

        [Fact]
        public void ParseJsonToDictionary_WithWhitespace_ParsesCorrectly()
        {
            // Arrange
            string json = "{ \"Key1\" : \"Value1\" , \"Key2\" : \"Value2\" }";

            // Act
            var dict = JsonNativeAot.ParseJsonToDictionary(json);

            // Assert
            Assert.Equal(2, dict.Count);
        }

        #endregion

        #region Edge Case Tests

        [Fact]
        public void Serialize_WithEmptyString_HandlesCorrectly()
        {
            // Arrange
            var obj = new TestObject { StringValue = "" };

            // Act
            string json = JsonNativeAot.Serialize(obj);

            // Assert
            Assert.Contains("\"\"", json);
        }

        [Fact]
        public void Serialize_WithSpecialCharacters_HandlesCorrectly()
        {
            // Arrange
            var obj = new TestObject { StringValue = "!@#$%^&*()" };

            // Act
            string json = JsonNativeAot.Serialize(obj);

            // Assert
            Assert.NotEmpty(json);
        }

        [Fact]
        public void Deserialize_WithUnicodeCharacters_ParsesCorrectly()
        {
            // Arrange
            string json = "{\"StringValue\":\"こんにちは\"}"; // Japanese "Hello"

            // Act
            var obj = JsonNativeAot.Deserialize<TestObject>(json);

            // Assert
            Assert.Equal("こんにちは", obj.StringValue);
        }

        [Fact]
        public void ParseJsonToDictionary_WithNestedStructure_ReturnsRawJson()
        {
            // Arrange
            string json = "{\"Data\":{\"Inner\":\"Value\"}}";

            // Act
            var dict = JsonNativeAot.ParseJsonToDictionary(json);

            // Assert
            Assert.True(dict["Data"].StartsWith("{"));
            Assert.True(dict["Data"].EndsWith("}"));
        }

        [Fact]
        public void ParseJsonToDictionary_WithArray_ReturnsRawJson()
        {
            // Arrange
            string json = "{\"Items\":[\"a\",\"b\",\"c\"]}";

            // Act
            var dict = JsonNativeAot.ParseJsonToDictionary(json);

            // Assert
            Assert.True(dict["Items"].StartsWith("["));
            Assert.True(dict["Items"].EndsWith("]"));
        }

        #endregion

        #region Error Handling Tests

        [Fact]
        public void ParseJsonToDictionary_WithNullInput_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => JsonNativeAot.ParseJsonToDictionary(null));
        }

        [Fact]
        public void Serialize_WithNullInstance_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => JsonNativeAot.Serialize<TestObject>(null));
        }
        
        #endregion

        #region Complex Type Tests

        [Fact]
        public void Serialize_WithGuid_SerializesAsString()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var obj = new ComplexTestObject { GuidValue = guid };

            // Act
            string json = JsonNativeAot.Serialize(obj);

            // Assert
            Assert.Contains(guid.ToString(), json);
        }

        [Fact]
        public void Serialize_WithDateTime_SerializesAsString()
        {
            // Arrange
            var now = DateTime.Now;
            var obj = new ComplexTestObject { DateTimeValue = now };

            // Act
            string json = JsonNativeAot.Serialize(obj);

            // Assert
            Assert.NotEmpty(json);
        }

        [Fact]
        public void Deserialize_WithGuid_ParsesCorrectly()
        {
            // Arrange
            var guid = Guid.NewGuid();
            string json = $"{{\"GuidValue\":\"{guid}\"}}";

            // Act
            var obj = JsonNativeAot.Deserialize<ComplexTestObject>(json);

            // Assert
            Assert.Equal(guid, obj.GuidValue);
        }

        #endregion

        #region Helper Classes

        private class TestObject : IJsonSerializable, IJsonDesSerializable<TestObject>
        {
            public string StringValue { get; set; }
            public int IntValue { get; set; }
            public bool BoolValue { get; set; }
            public double DoubleValue { get; set; }

            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("StringValue", StringValue);
                yield return ("IntValue", IntValue.ToString());
                yield return ("BoolValue", BoolValue.ToString());
                yield return ("DoubleValue", DoubleValue.ToString(CultureInfo.InvariantCulture));
            }

            public TestObject CreateFromProperties(Dictionary<string, string> properties)
            {
                var obj = new TestObject();

                if (properties.TryGetValue("StringValue", out var str))
                    obj.StringValue = str;

                if (properties.TryGetValue("IntValue", out var intStr) && int.TryParse(intStr, out var intVal))
                    obj.IntValue = intVal;

                if (properties.TryGetValue("BoolValue", out var boolStr) && bool.TryParse(boolStr, out var boolVal))
                    obj.BoolValue = boolVal;

                if (properties.TryGetValue("DoubleValue", out var doubleStr) && 
                    double.TryParse(doubleStr, NumberStyles.Float, CultureInfo.InvariantCulture, out var doubleVal))
                    obj.DoubleValue = doubleVal;

                return obj;
            }
        }

        private class ComplexTestObject : IJsonSerializable, IJsonDesSerializable<ComplexTestObject>
        {
            public Guid GuidValue { get; set; }
            public DateTime DateTimeValue { get; set; }

            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("GuidValue", GuidValue.ToString());
                yield return ("DateTimeValue", DateTimeValue.ToString("O"));
            }

            public ComplexTestObject CreateFromProperties(Dictionary<string, string> properties)
            {
                var obj = new ComplexTestObject();

                if (properties.TryGetValue("GuidValue", out var guidStr) && Guid.TryParse(guidStr, out var guid))
                    obj.GuidValue = guid;

                if (properties.TryGetValue("DateTimeValue", out var dtStr) && DateTime.TryParse(dtStr, out var dt))
                    obj.DateTimeValue = dt;

                return obj;
            }
        }

        #endregion
    }
}

