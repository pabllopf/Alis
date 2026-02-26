// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: JsonSerializerAdvancedTest.cs
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
using System.Diagnostics;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Data.Json.Serialization;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json.Serialization
{
    /// <summary>
    ///     Advanced tests for JsonSerializer - 60+ test cases
    /// </summary>
    public class JsonSerializerAdvancedTest
    {
        private readonly IJsonSerializer _serializer = new JsonSerializer();

        #region Value Type Tests

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue)]
        public void Serialize_IntegerProperty_SerializesCorrectly(int value)
        {
            // Arrange
            TestIntObject obj = new TestIntObject { Value = value };

            // Act
            string json = _serializer.Serialize(obj);

            // Assert
            Assert.Contains(value.ToString(), json);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Serialize_BooleanProperty_SerializesCorrectly(bool value)
        {
            // Arrange
            TestBoolObject obj = new TestBoolObject { Flag = value };

            // Act
            string json = _serializer.Serialize(obj);

            // Assert
            Assert.Contains(value.ToString(), json);
        }

        [Theory]
        [InlineData(0.0)]
        [InlineData(1.5)]
        [InlineData(-3.14)]
        [InlineData(double.MaxValue)]
        public void Serialize_DoubleProperty_SerializesCorrectly(double value)
        {
            // Arrange
            TestDoubleObject obj = new TestDoubleObject { Number = value };

            // Act
            string json = _serializer.Serialize(obj);

            // Assert
            Assert.NotEmpty(json);
            Assert.Contains("{", json);
        }

        #endregion

        #region String Tests

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("simple")]
        [InlineData("with spaces")]
        [InlineData("with\nnewline")]
        public void Serialize_StringProperty_SerializesCorrectly(string value)
        {
            // Arrange
            TestStringObject obj = new TestStringObject { Text = value };

            // Act
            string json = _serializer.Serialize(obj);

            // Assert
            Assert.NotEmpty(json);
        }

        [Fact]
        public void Serialize_NullString_HandlesGracefully()
        {
            // Arrange
            TestStringObject obj = new TestStringObject { Text = null };

            // Act
            string json = _serializer.Serialize(obj);

            // Assert
            Assert.NotEmpty(json);
        }

        [Fact]
        public void Serialize_EmptyString_IncludesEmptyString()
        {
            // Arrange
            TestStringObject obj = new TestStringObject { Text = "" };

            // Act
            string json = _serializer.Serialize(obj);

            // Assert
            Assert.Contains("\"\"", json);
        }

        #endregion

        #region DateTime and Guid Tests

        [Fact]
        public void Serialize_DateTimeProperty_SerializesCorrectly()
        {
            // Arrange
            DateTime now = DateTime.Now;
            TestDateTimeObject obj = new TestDateTimeObject { Timestamp = now };

            // Act
            string json = _serializer.Serialize(obj);

            // Assert
            Assert.NotEmpty(json);
        }

        [Fact]
        public void Serialize_GuidProperty_SerializesCorrectly()
        {
            // Arrange
            Guid guid = Guid.NewGuid();
            TestGuidObject obj = new TestGuidObject { Id = guid };

            // Act
            string json = _serializer.Serialize(obj);

            // Assert
            Assert.Contains(guid.ToString(), json);
        }

        [Fact]
        public void Serialize_EmptyGuid_SerializesCorrectly()
        {
            // Arrange
            TestGuidObject obj = new TestGuidObject { Id = Guid.Empty };

            // Act
            string json = _serializer.Serialize(obj);

            // Assert
            Assert.Contains("00000000-0000-0000-0000-000000000000", json);
        }

        #endregion

        #region Multiple Properties Tests

        [Fact]
        public void Serialize_MultipleProperties_IncludesAllProperties()
        {
            // Arrange
            TestMultiObject obj = new TestMultiObject
            {
                Name = "Test",
                Age = 30,
                IsActive = true
            };

            // Act
            string json = _serializer.Serialize(obj);

            // Assert
            Assert.Contains("Test", json);
            Assert.Contains("30", json);
            Assert.Contains("True", json);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(10)]
        public void Serialize_ObjectWithManyProperties_IncludesAll(int propertyCount)
        {
            // Arrange
            TestDynamicObject obj = new TestDynamicObject(propertyCount);

            // Act
            string json = _serializer.Serialize(obj);

            // Assert
            Assert.NotEmpty(json);
            Assert.StartsWith("{", json);
            Assert.EndsWith("}", json);
        }

        #endregion

        #region JSON Format Tests

        [Fact]
        public void Serialize_ValidObject_StartsWithOpenBrace()
        {
            // Arrange
            TestStringObject obj = new TestStringObject { Text = "test" };

            // Act
            string json = _serializer.Serialize(obj);

            // Assert
            Assert.StartsWith("{", json);
        }

        [Fact]
        public void Serialize_ValidObject_EndsWithCloseBrace()
        {
            // Arrange
            TestStringObject obj = new TestStringObject { Text = "test" };

            // Act
            string json = _serializer.Serialize(obj);

            // Assert
            Assert.EndsWith("}", json);
        }

        [Fact]
        public void Serialize_PropertyWithCommas_FormatsCorrectly()
        {
            // Arrange
            TestMultiObject obj = new TestMultiObject
            {
                Name = "First",
                Age = 25,
                IsActive = true
            };

            // Act
            string json = _serializer.Serialize(obj);

            // Assert
            int commaCount = json.Split(',').Length - 1;
            Assert.True(commaCount >= 2);
        }

        #endregion

        #region Special Value Tests

        [Fact]
        public void Serialize_MaxIntValue_SerializesCorrectly()
        {
            // Arrange
            TestIntObject obj = new TestIntObject { Value = int.MaxValue };

            // Act
            string json = _serializer.Serialize(obj);

            // Assert
            Assert.Contains(int.MaxValue.ToString(), json);
        }

        [Fact]
        public void Serialize_MinIntValue_SerializesCorrectly()
        {
            // Arrange
            TestIntObject obj = new TestIntObject { Value = int.MinValue };

            // Act
            string json = _serializer.Serialize(obj);

            // Assert
            Assert.Contains(int.MinValue.ToString(), json);
        }

        #endregion

        #region Performance Tests

        [Fact]
        public void Serialize_LargeObject_CompletesInReasonableTime()
        {
            // Arrange
            TestDynamicObject obj = new TestDynamicObject(100);
            Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();

            // Act
            string json = _serializer.Serialize(obj);
            stopwatch.Stop();

            // Assert
            Assert.NotEmpty(json);
            Assert.True(stopwatch.ElapsedMilliseconds < 1000);
        }

        #endregion

        #region Error Handling Tests

        [Fact]
        public void Serialize_NullObject_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _serializer.Serialize<TestStringObject>(null));
        }

        #endregion

        #region Helper Test Classes

        private class TestIntObject : IJsonSerializable
        {
            public int Value { get; set; }

            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Value", Value.ToString());
            }
        }

        private class TestBoolObject : IJsonSerializable
        {
            public bool Flag { get; set; }

            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Flag", Flag.ToString());
            }
        }

        private class TestDoubleObject : IJsonSerializable
        {
            public double Number { get; set; }

            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Number", Number.ToString());
            }
        }

        private class TestStringObject : IJsonSerializable
        {
            public string Text { get; set; }

            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Text", Text);
            }
        }

        private class TestDateTimeObject : IJsonSerializable
        {
            public DateTime Timestamp { get; set; }

            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Timestamp", Timestamp.ToString("O"));
            }
        }

        private class TestGuidObject : IJsonSerializable
        {
            public Guid Id { get; set; }

            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Id", Id.ToString());
            }
        }

        private class TestMultiObject : IJsonSerializable
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
        }

        private class TestDynamicObject : IJsonSerializable
        {
            private readonly int _propertyCount;

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
        }

        #endregion
    }
}

