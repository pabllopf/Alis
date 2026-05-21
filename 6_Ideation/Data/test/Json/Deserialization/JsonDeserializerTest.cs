

using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Data.Json.Deserialization;
using Alis.Core.Aspect.Data.Json.Exceptions;
using Alis.Core.Aspect.Data.Json.Helpers;
using Alis.Core.Aspect.Data.Json.Parsing;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json.Deserialization
{
    /// <summary>
    ///     The json deserializer test class
    /// </summary>
    public class JsonDeserializerTest
    {
        /// <summary>
        ///     The deserializer
        /// </summary>
        private readonly JsonDeserializer _deserializer;

        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonDeserializerTest" /> class
        /// </summary>
        public JsonDeserializerTest()
        {
            EscapeSequenceHandler escapeHandler = new EscapeSequenceHandler();
            JsonParser parser = new JsonParser(escapeHandler);
            _deserializer = new JsonDeserializer(parser);
        }

        /// <summary>
        ///     Tests that deserialize with valid json returns object
        /// </summary>
        [Fact]
        public void Deserialize_WithValidJson_ReturnsObject()
        {
            string json = "{\"Name\":\"John\",\"Age\":\"30\"}";
            SimpleTestObject result = _deserializer.Deserialize<SimpleTestObject>(json);

            Assert.NotNull(result);
            Assert.Equal("John", result.Name);
            Assert.Equal(30, result.Age);
        }

        /// <summary>
        ///     Tests that deserialize with null json throws argument null exception
        /// </summary>
        [Fact]
        public void Deserialize_WithNullJson_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _deserializer.Deserialize<SimpleTestObject>(null));
        }

        /// <summary>
        ///     Tests that deserialize with empty json returns object
        /// </summary>
        [Fact]
        public void Deserialize_WithEmptyJson_ReturnsObject()
        {
            string json = "{}";
            SimpleTestObject result = _deserializer.Deserialize<SimpleTestObject>(json);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that deserialize with empty object returns object
        /// </summary>
        [Fact]
        public void Deserialize_WithEmptyObject_ReturnsObject()
        {
            string json = "{}";
            EmptyObject result = _deserializer.Deserialize<EmptyObject>(json);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that deserialize with missing property handles gracefully
        /// </summary>
        [Fact]
        public void Deserialize_WithMissingProperty_HandlesGracefully()
        {
            string json = "{\"Name\":\"John\"}";
            SimpleTestObject result = _deserializer.Deserialize<SimpleTestObject>(json);

            Assert.NotNull(result);
            Assert.Equal("John", result.Name);
            Assert.Equal(0, result.Age);
        }

        /// <summary>
        ///     Tests that deserialize with extra property ignores extra property
        /// </summary>
        [Fact]
        public void Deserialize_WithExtraProperty_IgnoresExtraProperty()
        {
            string json = "{\"Name\":\"John\",\"Age\":\"30\",\"Email\":\"john@example.com\"}";
            SimpleTestObject result = _deserializer.Deserialize<SimpleTestObject>(json);

            Assert.NotNull(result);
            Assert.Equal("John", result.Name);
            Assert.Equal(30, result.Age);
        }

        /// <summary>
        ///     Tests that deserialize with invalid json throws json deserialization exception
        /// </summary>
        [Fact]
        public void Deserialize_WithInvalidJson_ThrowsJsonDeserializationException()
        {
            string json = "{invalid json}";
            Assert.Throws<JsonDeserializationException>(() => _deserializer.Deserialize<SimpleTestObject>(json));
        }

        /// <summary>
        ///     Tests that deserialize with whitespace parses correctly
        /// </summary>
        [Fact]
        public void Deserialize_WithWhitespace_ParsesCorrectly()
        {
            string json = "{ \"Name\" : \"John\" , \"Age\" : \"30\" }";
            SimpleTestObject result = _deserializer.Deserialize<SimpleTestObject>(json);

            Assert.NotNull(result);
            Assert.Equal("John", result.Name);
            Assert.Equal(30, result.Age);
        }

        /// <summary>
        ///     The simple test object class
        /// </summary>
        /// <seealso cref="IJsonSerializable" />
        /// <seealso cref="IJsonDesSerializable{SimpleTestObject}" />
        private class SimpleTestObject : IJsonSerializable, IJsonDesSerializable<SimpleTestObject>
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
            ///     Creates the from properties using the specified properties
            /// </summary>
            /// <param name="properties">The properties</param>
            /// <returns>The simple test object</returns>
            public SimpleTestObject CreateFromProperties(Dictionary<string, string> properties) => new SimpleTestObject
            {
                Name = properties.TryGetValue("Name", out string name) ? name : null,
                Age = properties.TryGetValue("Age", out string age) && int.TryParse(age, out int ageValue) ? ageValue : 0
            };

            /// <summary>
            ///     Gets the serializable properties
            /// </summary>
            /// <returns>An enumerable of string property name and string value</returns>
            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Name", Name);
                yield return ("Age", Age.ToString());
            }
        }

        /// <summary>
        ///     The empty object class
        /// </summary>
        /// <seealso cref="IJsonSerializable" />
        /// <seealso cref="IJsonDesSerializable{EmptyObject}" />
        private class EmptyObject : IJsonSerializable, IJsonDesSerializable<EmptyObject>
        {
            /// <summary>
            ///     Creates the from properties using the specified properties
            /// </summary>
            /// <param name="properties">The properties</param>
            /// <returns>The empty object</returns>
            public EmptyObject CreateFromProperties(Dictionary<string, string> properties) => new EmptyObject();

            /// <summary>
            ///     Gets the serializable properties
            /// </summary>
            /// <returns>An enumerable of string property name and string value</returns>
            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield break;
            }
        }
    }
}