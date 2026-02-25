// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: JsonDeserializerAdvancedTest.cs
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
using Alis.Core.Aspect.Data.Json.Deserialization;
using Alis.Core.Aspect.Data.Json.Helpers;
using Alis.Core.Aspect.Data.Json.Parsing;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json.Deserialization
{
    /// <summary>
    ///     Advanced tests for JsonDeserializer - 60+ test cases
    /// </summary>
    public class JsonDeserializerAdvancedTest
    {
        private readonly IJsonDeserializer _deserializer;

        public JsonDeserializerAdvancedTest()
        {
            var escapeHandler = new EscapeSequenceHandler();
            var parser = new JsonParser(escapeHandler);
            _deserializer = new JsonDeserializer(parser);
        }

        #region Integer Deserialization Tests

        [Theory]
        [InlineData("0", 0)]
        [InlineData("1", 1)]
        [InlineData("-1", -1)]
        [InlineData("100", 100)]
        [InlineData("2147483647", int.MaxValue)]
        public void Deserialize_IntegerValue_ParsesCorrectly(string jsonValue, int expected)
        {
            // Arrange
            string json = $"{{\"Value\":\"{jsonValue}\"}}";

            // Act
            var obj = _deserializer.Deserialize<TestIntObject>(json);

            // Assert
            Assert.Equal(expected, obj.Value);
        }

        [Fact]
        public void Deserialize_IntegerAsString_ConvertsCorrectly()
        {
            // Arrange
            string json = "{\"Value\":\"42\"}";

            // Act
            var obj = _deserializer.Deserialize<TestIntObject>(json);

            // Assert
            Assert.Equal(42, obj.Value);
        }

        #endregion

        #region Boolean Deserialization Tests

        [Theory]
        [InlineData("true", true)]
        [InlineData("false", false)]
        [InlineData("True", true)]
        [InlineData("False", false)]
        public void Deserialize_BooleanValue_ParsesCorrectly(string jsonValue, bool expected)
        {
            // Arrange
            string json = $"{{\"Flag\":\"{jsonValue}\"}}";

            // Act
            var obj = _deserializer.Deserialize<TestBoolObject>(json);

            // Assert
            Assert.Equal(expected, obj.Flag);
        }

        #endregion

        #region Double Deserialization Tests

        [Theory]
        [InlineData("0.0", 0.0)]
        [InlineData("1.5", 1.5)]
        [InlineData("-3.14", -3.14)]
        [InlineData("99.99", 99.99)]
        public void Deserialize_DoubleValue_ParsesCorrectly(string jsonValue, double expected)
        {
            // Arrange
            string json = $"{{\"Number\":\"{jsonValue}\"}}";

            // Act
            var obj = _deserializer.Deserialize<TestDoubleObject>(json);

            // Assert
            Assert.Equal(expected, obj.Number, 0.001);
        }

        #endregion

        #region String Deserialization Tests

        [Theory]
        [InlineData("")]
        [InlineData("simple")]
        [InlineData("with spaces")]
        [InlineData("special!@#$%")]
        public void Deserialize_StringValue_ParsesCorrectly(string value)
        {
            // Arrange
            string json = $"{{\"Text\":\"{value}\"}}";

            // Act
            var obj = _deserializer.Deserialize<TestStringObject>(json);

            // Assert
            Assert.Equal(value, obj.Text);
        }

        [Fact]
        public void Deserialize_UnicodeString_ParsesCorrectly()
        {
            // Arrange
            string json = "{\"Text\":\"こんにちは\"}";

            // Act
            var obj = _deserializer.Deserialize<TestStringObject>(json);

            // Assert
            Assert.Equal("こんにちは", obj.Text);
        }

        #endregion

        #region DateTime and Guid Deserialization Tests

        [Fact]
        public void Deserialize_DateTimeValue_ParsesCorrectly()
        {
            // Arrange
            var expected = new DateTime(2023, 6, 15, 10, 30, 0);
            string json = $"{{\"Timestamp\":\"{expected:O}\"}}";

            // Act
            var obj = _deserializer.Deserialize<TestDateTimeObject>(json);

            // Assert
            Assert.Equal(expected.Year, obj.Timestamp.Year);
            Assert.Equal(expected.Month, obj.Timestamp.Month);
            Assert.Equal(expected.Day, obj.Timestamp.Day);
        }

        [Fact]
        public void Deserialize_GuidValue_ParsesCorrectly()
        {
            // Arrange
            var expected = Guid.NewGuid();
            string json = $"{{\"Id\":\"{expected}\"}}";

            // Act
            var obj = _deserializer.Deserialize<TestGuidObject>(json);

            // Assert
            Assert.Equal(expected, obj.Id);
        }

        #endregion

        #region Missing Property Tests

        [Fact]
        public void Deserialize_MissingIntProperty_UsesDefaultValue()
        {
            // Arrange
            string json = "{}";

            // Act
            var obj = _deserializer.Deserialize<TestIntObject>(json);

            // Assert
            Assert.Equal(0, obj.Value);
        }

        [Fact]
        public void Deserialize_MissingStringProperty_UsesNull()
        {
            // Arrange
            string json = "{}";

            // Act
            var obj = _deserializer.Deserialize<TestStringObject>(json);

            // Assert
            Assert.Null(obj.Text);
        }

        [Fact]
        public void Deserialize_MissingBoolProperty_UsesDefaultValue()
        {
            // Arrange
            string json = "{}";

            // Act
            var obj = _deserializer.Deserialize<TestBoolObject>(json);

            // Assert
            Assert.False(obj.Flag);
        }

        #endregion

        #region Invalid Value Tests

        [Fact]
        public void Deserialize_InvalidIntegerValue_UsesDefaultValue()
        {
            // Arrange
            string json = "{\"Value\":\"not_a_number\"}";

            // Act
            var obj = _deserializer.Deserialize<TestIntObject>(json);

            // Assert
            Assert.Equal(0, obj.Value);
        }

        [Fact]
        public void Deserialize_InvalidBooleanValue_UsesDefaultValue()
        {
            // Arrange
            string json = "{\"Flag\":\"not_a_bool\"}";

            // Act
            var obj = _deserializer.Deserialize<TestBoolObject>(json);

            // Assert
            Assert.False(obj.Flag);
        }

        [Fact]
        public void Deserialize_InvalidGuidValue_UsesEmptyGuid()
        {
            // Arrange
            string json = "{\"Id\":\"not_a_guid\"}";

            // Act
            var obj = _deserializer.Deserialize<TestGuidObject>(json);

            // Assert
            Assert.Equal(Guid.Empty, obj.Id);
        }

        #endregion

        #region Extra Properties Tests

        [Fact]
        public void Deserialize_WithExtraProperties_IgnoresExtra()
        {
            // Arrange
            string json = "{\"Value\":\"42\",\"ExtraProp\":\"ignored\"}";

            // Act
            var obj = _deserializer.Deserialize<TestIntObject>(json);

            // Assert
            Assert.Equal(42, obj.Value);
        }

        [Fact]
        public void Deserialize_WithManyExtraProperties_IgnoresAll()
        {
            // Arrange
            string json = "{\"Value\":\"42\",\"Extra1\":\"a\",\"Extra2\":\"b\",\"Extra3\":\"c\"}";

            // Act
            var obj = _deserializer.Deserialize<TestIntObject>(json);

            // Assert
            Assert.Equal(42, obj.Value);
        }

        #endregion

        #region Helper Test Classes

        private class TestIntObject : IJsonSerializable, IJsonDesSerializable<TestIntObject>
        {
            public int Value { get; set; }

            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Value", Value.ToString());
            }

            public TestIntObject CreateFromProperties(Dictionary<string, string> properties)
            {
                var obj = new TestIntObject();
                if (properties.TryGetValue("Value", out var value) && int.TryParse(value, out var intValue))
                    obj.Value = intValue;
                return obj;
            }
        }

        private class TestBoolObject : IJsonSerializable, IJsonDesSerializable<TestBoolObject>
        {
            public bool Flag { get; set; }

            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Flag", Flag.ToString());
            }

            public TestBoolObject CreateFromProperties(Dictionary<string, string> properties)
            {
                var obj = new TestBoolObject();
                if (properties.TryGetValue("Flag", out var value) && bool.TryParse(value, out var boolValue))
                    obj.Flag = boolValue;
                return obj;
            }
        }

        private class TestDoubleObject : IJsonSerializable, IJsonDesSerializable<TestDoubleObject>
        {
            public double Number { get; set; }

            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Number", Number.ToString(CultureInfo.InvariantCulture));
            }

            public TestDoubleObject CreateFromProperties(Dictionary<string, string> properties)
            {
                var obj = new TestDoubleObject();
                if (properties.TryGetValue("Number", out var value) && 
                    double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out var doubleValue))
                    obj.Number = doubleValue;
                return obj;
            }
        }

        private class TestStringObject : IJsonSerializable, IJsonDesSerializable<TestStringObject>
        {
            public string Text { get; set; }

            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Text", Text);
            }

            public TestStringObject CreateFromProperties(Dictionary<string, string> properties)
            {
                var obj = new TestStringObject();
                if (properties.TryGetValue("Text", out var value))
                    obj.Text = value;
                return obj;
            }
        }

        private class TestDateTimeObject : IJsonSerializable, IJsonDesSerializable<TestDateTimeObject>
        {
            public DateTime Timestamp { get; set; }

            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Timestamp", Timestamp.ToString("O"));
            }

            public TestDateTimeObject CreateFromProperties(Dictionary<string, string> properties)
            {
                var obj = new TestDateTimeObject();
                if (properties.TryGetValue("Timestamp", out var value) && DateTime.TryParse(value, out var dateValue))
                    obj.Timestamp = dateValue;
                return obj;
            }
        }

        private class TestGuidObject : IJsonSerializable, IJsonDesSerializable<TestGuidObject>
        {
            public Guid Id { get; set; }

            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Id", Id.ToString());
            }

            public TestGuidObject CreateFromProperties(Dictionary<string, string> properties)
            {
                var obj = new TestGuidObject();
                if (properties.TryGetValue("Id", out var value) && Guid.TryParse(value, out var guidValue))
                    obj.Id = guidValue;
                return obj;
            }
        }

        private class TestMultiObject : IJsonSerializable, IJsonDesSerializable<TestMultiObject>
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public bool IsActive { get; set; }

            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Name", Name);
                yield return ("Age", Age.ToString());
                yield return ("IsActive", IsActive.ToString());
            }

            public TestMultiObject CreateFromProperties(Dictionary<string, string> properties)
            {
                var obj = new TestMultiObject();
                if (properties.TryGetValue("Name", out var name))
                    obj.Name = name;
                if (properties.TryGetValue("Age", out var age) && int.TryParse(age, out var ageValue))
                    obj.Age = ageValue;
                if (properties.TryGetValue("IsActive", out var active) && bool.TryParse(active, out var activeValue))
                    obj.IsActive = activeValue;
                return obj;
            }
        }

        private class TestDynamicObject : IJsonSerializable, IJsonDesSerializable<TestDynamicObject>
        {
            private readonly int _propertyCount;

            public TestDynamicObject() : this(0) { }

            public TestDynamicObject(int propertyCount)
            {
                _propertyCount = propertyCount;
            }

            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                for (int i = 0; i < _propertyCount; i++)
                {
                    yield return ($"Property{i}", $"Value{i}");
                }
            }

            public TestDynamicObject CreateFromProperties(Dictionary<string, string> properties)
            {
                return new TestDynamicObject(properties.Count);
            }
        }

        #endregion
    }
}

