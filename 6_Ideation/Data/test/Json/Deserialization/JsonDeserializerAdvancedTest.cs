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
        /// <summary>
        /// The deserializer
        /// </summary>
        private readonly IJsonDeserializer _deserializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonDeserializerAdvancedTest"/> class
        /// </summary>
        public JsonDeserializerAdvancedTest()
        {
            EscapeSequenceHandler escapeHandler = new EscapeSequenceHandler();
            JsonParser parser = new JsonParser(escapeHandler);
            _deserializer = new JsonDeserializer(parser);
        }

        #region Integer Deserialization Tests

        /// <summary>
        /// Tests that deserialize integer value parses correctly
        /// </summary>
        /// <param name="jsonValue">The json value</param>
        /// <param name="expected">The expected</param>
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
            TestIntObject obj = _deserializer.Deserialize<TestIntObject>(json);

            // Assert
            Assert.Equal(expected, obj.Value);
        }

        /// <summary>
        /// Tests that deserialize integer as string converts correctly
        /// </summary>
        [Fact]
        public void Deserialize_IntegerAsString_ConvertsCorrectly()
        {
            // Arrange
            string json = "{\"Value\":\"42\"}";

            // Act
            TestIntObject obj = _deserializer.Deserialize<TestIntObject>(json);

            // Assert
            Assert.Equal(42, obj.Value);
        }

        #endregion

        #region Boolean Deserialization Tests

        /// <summary>
        /// Tests that deserialize boolean value parses correctly
        /// </summary>
        /// <param name="jsonValue">The json value</param>
        /// <param name="expected">The expected</param>
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
            TestBoolObject obj = _deserializer.Deserialize<TestBoolObject>(json);

            // Assert
            Assert.Equal(expected, obj.Flag);
        }

        #endregion

        #region Double Deserialization Tests

        /// <summary>
        /// Tests that deserialize double value parses correctly
        /// </summary>
        /// <param name="jsonValue">The json value</param>
        /// <param name="expected">The expected</param>
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
            TestDoubleObject obj = _deserializer.Deserialize<TestDoubleObject>(json);

            // Assert
            Assert.Equal(expected, obj.Number, 0.001);
        }

        #endregion

        #region String Deserialization Tests

        /// <summary>
        /// Tests that deserialize string value parses correctly
        /// </summary>
        /// <param name="value">The value</param>
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
            TestStringObject obj = _deserializer.Deserialize<TestStringObject>(json);

            // Assert
            Assert.Equal(value, obj.Text);
        }

        /// <summary>
        /// Tests that deserialize unicode string parses correctly
        /// </summary>
        [Fact]
        public void Deserialize_UnicodeString_ParsesCorrectly()
        {
            // Arrange
            string json = "{\"Text\":\"こんにちは\"}";

            // Act
            TestStringObject obj = _deserializer.Deserialize<TestStringObject>(json);

            // Assert
            Assert.Equal("こんにちは", obj.Text);
        }

        #endregion

        #region DateTime and Guid Deserialization Tests

        /// <summary>
        /// Tests that deserialize date time value parses correctly
        /// </summary>
        [Fact]
        public void Deserialize_DateTimeValue_ParsesCorrectly()
        {
            // Arrange
            DateTime expected = new DateTime(2023, 6, 15, 10, 30, 0);
            string json = $"{{\"Timestamp\":\"{expected:O}\"}}";

            // Act
            TestDateTimeObject obj = _deserializer.Deserialize<TestDateTimeObject>(json);

            // Assert
            Assert.Equal(expected.Year, obj.Timestamp.Year);
            Assert.Equal(expected.Month, obj.Timestamp.Month);
            Assert.Equal(expected.Day, obj.Timestamp.Day);
        }

        /// <summary>
        /// Tests that deserialize guid value parses correctly
        /// </summary>
        [Fact]
        public void Deserialize_GuidValue_ParsesCorrectly()
        {
            // Arrange
            Guid expected = Guid.NewGuid();
            string json = $"{{\"Id\":\"{expected}\"}}";

            // Act
            TestGuidObject obj = _deserializer.Deserialize<TestGuidObject>(json);

            // Assert
            Assert.Equal(expected, obj.Id);
        }

        #endregion

        #region Missing Property Tests

        /// <summary>
        /// Tests that deserialize missing int property uses default value
        /// </summary>
        [Fact]
        public void Deserialize_MissingIntProperty_UsesDefaultValue()
        {
            // Arrange
            string json = "{}";

            // Act
            TestIntObject obj = _deserializer.Deserialize<TestIntObject>(json);

            // Assert
            Assert.Equal(0, obj.Value);
        }

        /// <summary>
        /// Tests that deserialize missing string property uses null
        /// </summary>
        [Fact]
        public void Deserialize_MissingStringProperty_UsesNull()
        {
            // Arrange
            string json = "{}";

            // Act
            TestStringObject obj = _deserializer.Deserialize<TestStringObject>(json);

            // Assert
            Assert.Null(obj.Text);
        }

        /// <summary>
        /// Tests that deserialize missing bool property uses default value
        /// </summary>
        [Fact]
        public void Deserialize_MissingBoolProperty_UsesDefaultValue()
        {
            // Arrange
            string json = "{}";

            // Act
            TestBoolObject obj = _deserializer.Deserialize<TestBoolObject>(json);

            // Assert
            Assert.False(obj.Flag);
        }

        #endregion

        #region Invalid Value Tests

        /// <summary>
        /// Tests that deserialize invalid integer value uses default value
        /// </summary>
        [Fact]
        public void Deserialize_InvalidIntegerValue_UsesDefaultValue()
        {
            // Arrange
            string json = "{\"Value\":\"not_a_number\"}";

            // Act
            TestIntObject obj = _deserializer.Deserialize<TestIntObject>(json);

            // Assert
            Assert.Equal(0, obj.Value);
        }

        /// <summary>
        /// Tests that deserialize invalid boolean value uses default value
        /// </summary>
        [Fact]
        public void Deserialize_InvalidBooleanValue_UsesDefaultValue()
        {
            // Arrange
            string json = "{\"Flag\":\"not_a_bool\"}";

            // Act
            TestBoolObject obj = _deserializer.Deserialize<TestBoolObject>(json);

            // Assert
            Assert.False(obj.Flag);
        }

        /// <summary>
        /// Tests that deserialize invalid guid value uses empty guid
        /// </summary>
        [Fact]
        public void Deserialize_InvalidGuidValue_UsesEmptyGuid()
        {
            // Arrange
            string json = "{\"Id\":\"not_a_guid\"}";

            // Act
            TestGuidObject obj = _deserializer.Deserialize<TestGuidObject>(json);

            // Assert
            Assert.Equal(Guid.Empty, obj.Id);
        }

        #endregion

        #region Extra Properties Tests

        /// <summary>
        /// Tests that deserialize with extra properties ignores extra
        /// </summary>
        [Fact]
        public void Deserialize_WithExtraProperties_IgnoresExtra()
        {
            // Arrange
            string json = "{\"Value\":\"42\",\"ExtraProp\":\"ignored\"}";

            // Act
            TestIntObject obj = _deserializer.Deserialize<TestIntObject>(json);

            // Assert
            Assert.Equal(42, obj.Value);
        }

        /// <summary>
        /// Tests that deserialize with many extra properties ignores all
        /// </summary>
        [Fact]
        public void Deserialize_WithManyExtraProperties_IgnoresAll()
        {
            // Arrange
            string json = "{\"Value\":\"42\",\"Extra1\":\"a\",\"Extra2\":\"b\",\"Extra3\":\"c\"}";

            // Act
            TestIntObject obj = _deserializer.Deserialize<TestIntObject>(json);

            // Assert
            Assert.Equal(42, obj.Value);
        }

        #endregion

        #region Helper Test Classes

        /// <summary>
        /// The test int object class
        /// </summary>
        /// <seealso cref="IJsonSerializable"/>
        /// <seealso cref="IJsonDesSerializable{TestIntObject}"/>
        private class TestIntObject : IJsonSerializable, IJsonDesSerializable<TestIntObject>
        {
            /// <summary>
            /// Gets or sets the value of the value
            /// </summary>
            public int Value { get; set; }

            /// <summary>
            /// Gets the serializable properties
            /// </summary>
            /// <returns>An enumerable of string property name and string value</returns>
            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Value", Value.ToString());
            }

            /// <summary>
            /// Creates the from properties using the specified properties
            /// </summary>
            /// <param name="properties">The properties</param>
            /// <returns>The obj</returns>
            public TestIntObject CreateFromProperties(Dictionary<string, string> properties)
            {
                TestIntObject obj = new TestIntObject();
                if (properties.TryGetValue("Value", out string value) && int.TryParse(value, out int intValue))
                    obj.Value = intValue;
                return obj;
            }
        }

        /// <summary>
        /// The test bool object class
        /// </summary>
        /// <seealso cref="IJsonSerializable"/>
        /// <seealso cref="IJsonDesSerializable{TestBoolObject}"/>
        private class TestBoolObject : IJsonSerializable, IJsonDesSerializable<TestBoolObject>
        {
            /// <summary>
            /// Gets or sets the value of the flag
            /// </summary>
            public bool Flag { get; set; }

            /// <summary>
            /// Gets the serializable properties
            /// </summary>
            /// <returns>An enumerable of string property name and string value</returns>
            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Flag", Flag.ToString());
            }

            /// <summary>
            /// Creates the from properties using the specified properties
            /// </summary>
            /// <param name="properties">The properties</param>
            /// <returns>The obj</returns>
            public TestBoolObject CreateFromProperties(Dictionary<string, string> properties)
            {
                TestBoolObject obj = new TestBoolObject();
                if (properties.TryGetValue("Flag", out string value) && bool.TryParse(value, out bool boolValue))
                    obj.Flag = boolValue;
                return obj;
            }
        }

        /// <summary>
        /// The test double object class
        /// </summary>
        /// <seealso cref="IJsonSerializable"/>
        /// <seealso cref="IJsonDesSerializable{TestDoubleObject}"/>
        private class TestDoubleObject : IJsonSerializable, IJsonDesSerializable<TestDoubleObject>
        {
            /// <summary>
            /// Gets or sets the value of the number
            /// </summary>
            public double Number { get; set; }

            /// <summary>
            /// Gets the serializable properties
            /// </summary>
            /// <returns>An enumerable of string property name and string value</returns>
            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Number", Number.ToString(CultureInfo.InvariantCulture));
            }

            /// <summary>
            /// Creates the from properties using the specified properties
            /// </summary>
            /// <param name="properties">The properties</param>
            /// <returns>The obj</returns>
            public TestDoubleObject CreateFromProperties(Dictionary<string, string> properties)
            {
                TestDoubleObject obj = new TestDoubleObject();
                if (properties.TryGetValue("Number", out string value) && 
                    double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out double doubleValue))
                    obj.Number = doubleValue;
                return obj;
            }
        }

        /// <summary>
        /// The test string object class
        /// </summary>
        /// <seealso cref="IJsonSerializable"/>
        /// <seealso cref="IJsonDesSerializable{TestStringObject}"/>
        private class TestStringObject : IJsonSerializable, IJsonDesSerializable<TestStringObject>
        {
            /// <summary>
            /// Gets or sets the value of the text
            /// </summary>
            public string Text { get; set; }

            /// <summary>
            /// Gets the serializable properties
            /// </summary>
            /// <returns>An enumerable of string property name and string value</returns>
            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Text", Text);
            }

            /// <summary>
            /// Creates the from properties using the specified properties
            /// </summary>
            /// <param name="properties">The properties</param>
            /// <returns>The obj</returns>
            public TestStringObject CreateFromProperties(Dictionary<string, string> properties)
            {
                TestStringObject obj = new TestStringObject();
                if (properties.TryGetValue("Text", out string value))
                    obj.Text = value;
                return obj;
            }
        }

        /// <summary>
        /// The test date time object class
        /// </summary>
        /// <seealso cref="IJsonSerializable"/>
        /// <seealso cref="IJsonDesSerializable{TestDateTimeObject}"/>
        private class TestDateTimeObject : IJsonSerializable, IJsonDesSerializable<TestDateTimeObject>
        {
            /// <summary>
            /// Gets or sets the value of the timestamp
            /// </summary>
            public DateTime Timestamp { get; set; }

            /// <summary>
            /// Gets the serializable properties
            /// </summary>
            /// <returns>An enumerable of string property name and string value</returns>
            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Timestamp", Timestamp.ToString("O"));
            }

            /// <summary>
            /// Creates the from properties using the specified properties
            /// </summary>
            /// <param name="properties">The properties</param>
            /// <returns>The obj</returns>
            public TestDateTimeObject CreateFromProperties(Dictionary<string, string> properties)
            {
                TestDateTimeObject obj = new TestDateTimeObject();
                if (properties.TryGetValue("Timestamp", out string value) && DateTime.TryParse(value, out DateTime dateValue))
                    obj.Timestamp = dateValue;
                return obj;
            }
        }

        /// <summary>
        /// The test guid object class
        /// </summary>
        /// <seealso cref="IJsonSerializable"/>
        /// <seealso cref="IJsonDesSerializable{TestGuidObject}"/>
        private class TestGuidObject : IJsonSerializable, IJsonDesSerializable<TestGuidObject>
        {
            /// <summary>
            /// Gets or sets the value of the id
            /// </summary>
            public Guid Id { get; set; }

            /// <summary>
            /// Gets the serializable properties
            /// </summary>
            /// <returns>An enumerable of string property name and string value</returns>
            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Id", Id.ToString());
            }

            /// <summary>
            /// Creates the from properties using the specified properties
            /// </summary>
            /// <param name="properties">The properties</param>
            /// <returns>The obj</returns>
            public TestGuidObject CreateFromProperties(Dictionary<string, string> properties)
            {
                TestGuidObject obj = new TestGuidObject();
                if (properties.TryGetValue("Id", out string value) && Guid.TryParse(value, out Guid guidValue))
                    obj.Id = guidValue;
                return obj;
            }
        }

        /// <summary>
        /// The test multi object class
        /// </summary>
        /// <seealso cref="IJsonSerializable"/>
        /// <seealso cref="IJsonDesSerializable{TestMultiObject}"/>
        private class TestMultiObject : IJsonSerializable, IJsonDesSerializable<TestMultiObject>
        {
            /// <summary>
            /// Gets or sets the value of the name
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// Gets or sets the value of the age
            /// </summary>
            public int Age { get; set; }
            /// <summary>
            /// Gets or sets the value of the is active
            /// </summary>
            public bool IsActive { get; set; }

            /// <summary>
            /// Gets the serializable properties
            /// </summary>
            /// <returns>An enumerable of string property name and string value</returns>
            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Name", Name);
                yield return ("Age", Age.ToString());
                yield return ("IsActive", IsActive.ToString());
            }

            /// <summary>
            /// Creates the from properties using the specified properties
            /// </summary>
            /// <param name="properties">The properties</param>
            /// <returns>The obj</returns>
            public TestMultiObject CreateFromProperties(Dictionary<string, string> properties)
            {
                TestMultiObject obj = new TestMultiObject();
                if (properties.TryGetValue("Name", out string name))
                    obj.Name = name;
                if (properties.TryGetValue("Age", out string age) && int.TryParse(age, out int ageValue))
                    obj.Age = ageValue;
                if (properties.TryGetValue("IsActive", out string active) && bool.TryParse(active, out bool activeValue))
                    obj.IsActive = activeValue;
                return obj;
            }
        }

        /// <summary>
        /// The test dynamic object class
        /// </summary>
        /// <seealso cref="IJsonSerializable"/>
        /// <seealso cref="IJsonDesSerializable{TestDynamicObject}"/>
        private class TestDynamicObject : IJsonSerializable, IJsonDesSerializable<TestDynamicObject>
        {
            /// <summary>
            /// The property count
            /// </summary>
            private readonly int _propertyCount;

            /// <summary>
            /// Initializes a new instance of the <see cref="TestDynamicObject"/> class
            /// </summary>
            public TestDynamicObject() : this(0) { }

            /// <summary>
            /// Initializes a new instance of the <see cref="TestDynamicObject"/> class
            /// </summary>
            /// <param name="propertyCount">The property count</param>
            public TestDynamicObject(int propertyCount)
            {
                _propertyCount = propertyCount;
            }

            /// <summary>
            /// Gets the serializable properties
            /// </summary>
            /// <returns>An enumerable of string property name and string value</returns>
            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                for (int i = 0; i < _propertyCount; i++)
                {
                    yield return ($"Property{i}", $"Value{i}");
                }
            }

            /// <summary>
            /// Creates the from properties using the specified properties
            /// </summary>
            /// <param name="properties">The properties</param>
            /// <returns>The test dynamic object</returns>
            public TestDynamicObject CreateFromProperties(Dictionary<string, string> properties)
            {
                return new TestDynamicObject(properties.Count);
            }
        }

        #endregion
    }
}

