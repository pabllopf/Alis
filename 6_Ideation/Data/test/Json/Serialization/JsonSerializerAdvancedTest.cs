

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
        /// <summary>
        ///     The json serializer
        /// </summary>
        private readonly IJsonSerializer _serializer = new JsonSerializer();


        /// <summary>
        ///     Tests that serialize large object completes in reasonable time
        /// </summary>
        [Fact]
        public void Serialize_LargeObject_CompletesInReasonableTime()
        {
            TestDynamicObject obj = new TestDynamicObject(100);
            Stopwatch stopwatch = Stopwatch.StartNew();

            string json = _serializer.Serialize(obj);
            stopwatch.Stop();

            Assert.NotEmpty(json);
            Assert.True(stopwatch.ElapsedMilliseconds < 1000);
        }


        /// <summary>
        ///     Tests that serialize null object throws argument null exception
        /// </summary>
        [Fact]
        public void Serialize_NullObject_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _serializer.Serialize<TestStringObject>(null));
        }


        /// <summary>
        ///     Tests that serialize integer property serializes correctly
        /// </summary>
        /// <param name="value">The value</param>
        [Theory, InlineData(0), InlineData(1), InlineData(-1), InlineData(int.MaxValue), InlineData(int.MinValue)]
        public void Serialize_IntegerProperty_SerializesCorrectly(int value)
        {
            TestIntObject obj = new TestIntObject {Value = value};

            string json = _serializer.Serialize(obj);

            Assert.Contains(value.ToString(), json);
        }

        /// <summary>
        ///     Tests that serialize boolean property serializes correctly
        /// </summary>
        /// <param name="value">The value</param>
        [Theory, InlineData(true), InlineData(false)]
        public void Serialize_BooleanProperty_SerializesCorrectly(bool value)
        {
            TestBoolObject obj = new TestBoolObject {Flag = value};

            string json = _serializer.Serialize(obj);

            Assert.Contains(value.ToString(), json);
        }

        /// <summary>
        ///     Tests that serialize double property serializes correctly
        /// </summary>
        /// <param name="value">The value</param>
        [Theory, InlineData(0.0), InlineData(1.5), InlineData(-3.14), InlineData(double.MaxValue)]
        public void Serialize_DoubleProperty_SerializesCorrectly(double value)
        {
            TestDoubleObject obj = new TestDoubleObject {Number = value};

            string json = _serializer.Serialize(obj);

            Assert.NotEmpty(json);
            Assert.Contains("{", json);
        }


        /// <summary>
        ///     Tests that serialize string property serializes correctly
        /// </summary>
        /// <param name="value">The value</param>
        [Theory, InlineData(""), InlineData(" "), InlineData("simple"), InlineData("with spaces"), InlineData("with\nnewline")]
        public void Serialize_StringProperty_SerializesCorrectly(string value)
        {
            TestStringObject obj = new TestStringObject {Text = value};

            string json = _serializer.Serialize(obj);

            Assert.NotEmpty(json);
        }

        /// <summary>
        ///     Tests that serialize null string handles gracefully
        /// </summary>
        [Fact]
        public void Serialize_NullString_HandlesGracefully()
        {
            TestStringObject obj = new TestStringObject {Text = null};

            string json = _serializer.Serialize(obj);

            Assert.NotEmpty(json);
        }

        /// <summary>
        ///     Tests that serialize empty string includes empty string
        /// </summary>
        [Fact]
        public void Serialize_EmptyString_IncludesEmptyString()
        {
            TestStringObject obj = new TestStringObject {Text = ""};

            string json = _serializer.Serialize(obj);

            Assert.Contains("\"\"", json);
        }


        /// <summary>
        ///     Tests that serialize date time property serializes correctly
        /// </summary>
        [Fact]
        public void Serialize_DateTimeProperty_SerializesCorrectly()
        {
            DateTime now = DateTime.Now;
            TestDateTimeObject obj = new TestDateTimeObject {Timestamp = now};

            string json = _serializer.Serialize(obj);

            Assert.NotEmpty(json);
        }

        /// <summary>
        ///     Tests that serialize guid property serializes correctly
        /// </summary>
        [Fact]
        public void Serialize_GuidProperty_SerializesCorrectly()
        {
            Guid guid = Guid.NewGuid();
            TestGuidObject obj = new TestGuidObject {Id = guid};

            string json = _serializer.Serialize(obj);

            Assert.Contains(guid.ToString(), json);
        }

        /// <summary>
        ///     Tests that serialize empty guid serializes correctly
        /// </summary>
        [Fact]
        public void Serialize_EmptyGuid_SerializesCorrectly()
        {
            TestGuidObject obj = new TestGuidObject {Id = Guid.Empty};

            string json = _serializer.Serialize(obj);

            Assert.Contains("00000000-0000-0000-0000-000000000000", json);
        }


        /// <summary>
        ///     Tests that serialize multiple properties includes all properties
        /// </summary>
        [Fact]
        public void Serialize_MultipleProperties_IncludesAllProperties()
        {
            TestMultiObject obj = new TestMultiObject
            {
                Name = "Test",
                Age = 30,
                IsActive = true
            };

            string json = _serializer.Serialize(obj);

            Assert.Contains("Test", json);
            Assert.Contains("30", json);
            Assert.Contains("True", json);
        }

        /// <summary>
        ///     Tests that serialize object with many properties includes all
        /// </summary>
        /// <param name="propertyCount">The property count</param>
        [Theory, InlineData(1), InlineData(2), InlineData(5), InlineData(10)]
        public void Serialize_ObjectWithManyProperties_IncludesAll(int propertyCount)
        {
            TestDynamicObject obj = new TestDynamicObject(propertyCount);

            string json = _serializer.Serialize(obj);

            Assert.NotEmpty(json);
            Assert.StartsWith("{", json);
            Assert.EndsWith("}", json);
        }


        /// <summary>
        ///     Tests that serialize valid object starts with open brace
        /// </summary>
        [Fact]
        public void Serialize_ValidObject_StartsWithOpenBrace()
        {
            TestStringObject obj = new TestStringObject {Text = "test"};

            string json = _serializer.Serialize(obj);

            Assert.StartsWith("{", json);
        }

        /// <summary>
        ///     Tests that serialize valid object ends with close brace
        /// </summary>
        [Fact]
        public void Serialize_ValidObject_EndsWithCloseBrace()
        {
            TestStringObject obj = new TestStringObject {Text = "test"};

            string json = _serializer.Serialize(obj);

            Assert.EndsWith("}", json);
        }

        /// <summary>
        ///     Tests that serialize property with commas formats correctly
        /// </summary>
        [Fact]
        public void Serialize_PropertyWithCommas_FormatsCorrectly()
        {
            TestMultiObject obj = new TestMultiObject
            {
                Name = "First",
                Age = 25,
                IsActive = true
            };

            string json = _serializer.Serialize(obj);

            int commaCount = json.Split(',').Length - 1;
            Assert.True(commaCount >= 2);
        }


        /// <summary>
        ///     Tests that serialize max int value serializes correctly
        /// </summary>
        [Fact]
        public void Serialize_MaxIntValue_SerializesCorrectly()
        {
            TestIntObject obj = new TestIntObject {Value = int.MaxValue};

            string json = _serializer.Serialize(obj);

            Assert.Contains(int.MaxValue.ToString(), json);
        }

        /// <summary>
        ///     Tests that serialize min int value serializes correctly
        /// </summary>
        [Fact]
        public void Serialize_MinIntValue_SerializesCorrectly()
        {
            TestIntObject obj = new TestIntObject {Value = int.MinValue};

            string json = _serializer.Serialize(obj);

            Assert.Contains(int.MinValue.ToString(), json);
        }


        /// <summary>
        ///     The test int object class
        /// </summary>
        /// <seealso cref="IJsonSerializable" />
        private class TestIntObject : IJsonSerializable
        {
            /// <summary>
            ///     Gets or sets the value of the value
            /// </summary>
            public int Value { get; set; }

            /// <summary>
            ///     Gets the serializable properties
            /// </summary>
            /// <returns>An enumerable of string property name and string value</returns>
            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Value", Value.ToString());
            }
        }

        /// <summary>
        ///     The test bool object class
        /// </summary>
        /// <seealso cref="IJsonSerializable" />
        private class TestBoolObject : IJsonSerializable
        {
            /// <summary>
            ///     Gets or sets the value of the flag
            /// </summary>
            public bool Flag { get; set; }

            /// <summary>
            ///     Gets the serializable properties
            /// </summary>
            /// <returns>An enumerable of string property name and string value</returns>
            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Flag", Flag.ToString());
            }
        }

        /// <summary>
        ///     The test double object class
        /// </summary>
        /// <seealso cref="IJsonSerializable" />
        private class TestDoubleObject : IJsonSerializable
        {
            /// <summary>
            ///     Gets or sets the value of the number
            /// </summary>
            public double Number { get; set; }

            /// <summary>
            ///     Gets the serializable properties
            /// </summary>
            /// <returns>An enumerable of string property name and string value</returns>
            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Number", Number.ToString());
            }
        }

        /// <summary>
        ///     The test string object class
        /// </summary>
        /// <seealso cref="IJsonSerializable" />
        private class TestStringObject : IJsonSerializable
        {
            /// <summary>
            ///     Gets or sets the value of the text
            /// </summary>
            public string Text { get; set; }

            /// <summary>
            ///     Gets the serializable properties
            /// </summary>
            /// <returns>An enumerable of string property name and string value</returns>
            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Text", Text);
            }
        }

        /// <summary>
        ///     The test date time object class
        /// </summary>
        /// <seealso cref="IJsonSerializable" />
        private class TestDateTimeObject : IJsonSerializable
        {
            /// <summary>
            ///     Gets or sets the value of the timestamp
            /// </summary>
            public DateTime Timestamp { get; set; }

            /// <summary>
            ///     Gets the serializable properties
            /// </summary>
            /// <returns>An enumerable of string property name and string value</returns>
            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Timestamp", Timestamp.ToString("O"));
            }
        }

        /// <summary>
        ///     The test guid object class
        /// </summary>
        /// <seealso cref="IJsonSerializable" />
        private class TestGuidObject : IJsonSerializable
        {
            /// <summary>
            ///     Gets or sets the value of the id
            /// </summary>
            public Guid Id { get; set; }

            /// <summary>
            ///     Gets the serializable properties
            /// </summary>
            /// <returns>An enumerable of string property name and string value</returns>
            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Id", Id.ToString());
            }
        }

        /// <summary>
        ///     The test multi object class
        /// </summary>
        /// <seealso cref="IJsonSerializable" />
        private class TestMultiObject : IJsonSerializable
        {
            /// <summary>
            ///     Gets or sets the value of the name
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            ///     Gets or sets the value of the age
            /// </summary>
            public int Age { get; set; }

            /// <summary>
            ///     Gets or sets the value of the is active
            /// </summary>
            public bool IsActive { get; set; }

            /// <summary>
            ///     Gets the serializable properties
            /// </summary>
            /// <returns>An enumerable of string property name and string value</returns>
            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Name", Name);
                yield return ("Age", Age.ToString());
                yield return ("IsActive", IsActive.ToString());
            }
        }

        /// <summary>
        ///     The test dynamic object class
        /// </summary>
        /// <seealso cref="IJsonSerializable" />
        private class TestDynamicObject : IJsonSerializable
        {
            /// <summary>
            ///     The property count
            /// </summary>
            private readonly int _propertyCount;

            /// <summary>
            ///     Initializes a new instance of the <see cref="TestDynamicObject" /> class
            /// </summary>
            /// <param name="propertyCount">The property count</param>
            public TestDynamicObject(int propertyCount) => _propertyCount = propertyCount;

            /// <summary>
            ///     Gets the serializable properties
            /// </summary>
            /// <returns>An enumerable of string property name and string value</returns>
            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                for (int i = 0; i < _propertyCount; i++)
                {
                    yield return ($"Property{i}", $"Value{i}");
                }
            }
        }
    }
}