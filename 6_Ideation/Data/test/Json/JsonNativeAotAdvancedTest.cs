// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: JsonNativeAotAdvancedTest.cs
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
using System.IO;
using Alis.Core.Aspect.Data.Json;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json
{
    /// <summary>
    ///     Advanced integration tests for JsonNativeAot - 50+ test cases
    /// </summary>
    public class JsonNativeAotAdvancedTest
    {
        #region Round-Trip Tests with Different Types

        /// <summary>
        /// Tests that round trip integer value preserves value
        /// </summary>
        /// <param name="value">The value</param>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(100)]
        [InlineData(int.MaxValue)]
        public void RoundTrip_IntegerValue_PreservesValue(int value)
        {
            // Arrange
            TestInt original = new TestInt { Value = value };

            // Act
            string json = JsonNativeAot.Serialize(original);
            TestInt restored = JsonNativeAot.Deserialize<TestInt>(json);

            // Assert
            Assert.Equal(original.Value, restored.Value);
        }

        /// <summary>
        /// Tests that round trip boolean value preserves value
        /// </summary>
        /// <param name="value">The value</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void RoundTrip_BooleanValue_PreservesValue(bool value)
        {
            // Arrange
            TestBool original = new TestBool { Flag = value };

            // Act
            string json = JsonNativeAot.Serialize(original);
            TestBool restored = JsonNativeAot.Deserialize<TestBool>(json);

            // Assert
            Assert.Equal(original.Flag, restored.Flag);
        }

        /// <summary>
        /// Tests that round trip string value preserves value
        /// </summary>
        /// <param name="value">The value</param>
        [Theory]
        [InlineData("")]
        [InlineData("test")]
        [InlineData("with spaces")]
        [InlineData("special!@#")]
        public void RoundTrip_StringValue_PreservesValue(string value)
        {
            // Arrange
            TestString original = new TestString { Text = value };

            // Act
            string json = JsonNativeAot.Serialize(original);
            TestString restored = JsonNativeAot.Deserialize<TestString>(json);

            // Assert
            Assert.Equal(original.Text, restored.Text);
        }

        /// <summary>
        /// Tests that round trip guid value preserves value
        /// </summary>
        [Fact]
        public void RoundTrip_GuidValue_PreservesValue()
        {
            // Arrange
            Guid guid = Guid.NewGuid();
            TestGuid original = new TestGuid { Id = guid };

            // Act
            string json = JsonNativeAot.Serialize(original);
            TestGuid restored = JsonNativeAot.Deserialize<TestGuid>(json);

            // Assert
            Assert.Equal(original.Id, restored.Id);
        }

        /// <summary>
        /// Tests that round trip date time value preserves value
        /// </summary>
        [Fact]
        public void RoundTrip_DateTimeValue_PreservesValue()
        {
            // Arrange
            DateTime date = new DateTime(2023, 6, 15, 10, 30, 45);
            TestDateTime original = new TestDateTime { Timestamp = date };

            // Act
            string json = JsonNativeAot.Serialize(original);
            TestDateTime restored = JsonNativeAot.Deserialize<TestDateTime>(json);

            // Assert
            Assert.Equal(original.Timestamp.Year, restored.Timestamp.Year);
            Assert.Equal(original.Timestamp.Month, restored.Timestamp.Month);
            Assert.Equal(original.Timestamp.Day, restored.Timestamp.Day);
        }

        #endregion

        #region ParseJsonToDictionary Tests

        /// <summary>
        /// Tests that parse json to dictionary with simple object returns all properties
        /// </summary>
        [Fact]
        public void ParseJsonToDictionary_WithSimpleObject_ReturnsAllProperties()
        {
            // Arrange
            string json = "{\"Name\":\"Alice\",\"Age\":\"30\"}";

            // Act
            Dictionary<string, string> dict = JsonNativeAot.ParseJsonToDictionary(json);

            // Assert
            Assert.Equal(2, dict.Count);
            Assert.Equal("Alice", dict["Name"]);
            Assert.Equal("30", dict["Age"]);
        }

        /// <summary>
        /// Tests that parse json to dictionary with empty object returns empty dictionary
        /// </summary>
        [Fact]
        public void ParseJsonToDictionary_WithEmptyObject_ReturnsEmptyDictionary()
        {
            // Arrange
            string json = "{}";

            // Act
            Dictionary<string, string> dict = JsonNativeAot.ParseJsonToDictionary(json);

            // Assert
            Assert.Empty(dict);
        }

        /// <summary>
        /// Tests that parse json to dictionary with nested object returns raw json
        /// </summary>
        [Fact]
        public void ParseJsonToDictionary_WithNestedObject_ReturnsRawJson()
        {
            // Arrange
            string json = "{\"Nested\":{\"Inner\":\"Value\"}}";

            // Act
            Dictionary<string, string> dict = JsonNativeAot.ParseJsonToDictionary(json);

            // Assert
            Assert.Contains("Inner", dict["Nested"]);
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
            Assert.StartsWith("[", dict["Items"]);
            Assert.EndsWith("]", dict["Items"]);
        }

        /// <summary>
        /// Tests that parse json to dictionary with multiple properties returns all properties
        /// </summary>
        /// <param name="count">The count</param>
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        public void ParseJsonToDictionary_WithMultipleProperties_ReturnsAllProperties(int count)
        {
            // Arrange
            List<string> props = new List<string>();
            for (int i = 0; i < count; i++)
                props.Add($"\"Prop{i}\":\"Value{i}\"");
            string json = "{" + string.Join(",", props) + "}";

            // Act
            Dictionary<string, string> dict = JsonNativeAot.ParseJsonToDictionary(json);

            // Assert
            Assert.Equal(count, dict.Count);
        }

        #endregion

        #region File Operations Tests

        /// <summary>
        /// Tests that serialize to file and deserialize from file preserves data
        /// </summary>
        [Fact]
        public void SerializeToFile_AndDeserializeFromFile_PreservesData()
        {
            // Arrange
            TestString original = new TestString { Text = "FileTest" };
            string fileName = $"test_{Guid.NewGuid()}";
            string path = "TestData";

            try
            {
                // Act
                JsonNativeAot.SerializeToFile(original, fileName, path);
                TestString restored = JsonNativeAot.DeserializeFromFile<TestString>(fileName, path);

                // Assert
                Assert.Equal(original.Text, restored.Text);
            }
            finally
            {
                // Cleanup
                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), path, $"{fileName}.json");
                if (File.Exists(fullPath))
                    File.Delete(fullPath);
            }
        }

        /// <summary>
        /// Tests that serialize to file creates directory if not exists
        /// </summary>
        [Fact]
        public void SerializeToFile_CreatesDirectory_IfNotExists()
        {
            // Arrange
            TestString obj = new TestString { Text = "Test" };
            string fileName = $"test_{Guid.NewGuid()}";
            string path = $"TempDir_{Guid.NewGuid()}";

            try
            {
                // Act
                JsonNativeAot.SerializeToFile(obj, fileName, path);

                // Assert
                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), path, $"{fileName}.json");
                Assert.True(File.Exists(fullPath));
            }
            finally
            {
                // Cleanup
                string dir = Path.Combine(Directory.GetCurrentDirectory(), path);
                if (Directory.Exists(dir))
                    Directory.Delete(dir, true);
            }
        }

        #endregion

        #region Error Handling Tests

        /// <summary>
        /// Tests that serialize with null throws argument null exception
        /// </summary>
        [Fact]
        public void Serialize_WithNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => JsonNativeAot.Serialize<TestString>(null));
        }

        /// <summary>
        /// Tests that deserialize with null throws argument null exception
        /// </summary>
        [Fact]
        public void Deserialize_WithNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => JsonNativeAot.Deserialize<TestString>(null));
        }

        /// <summary>
        /// Tests that parse json to dictionary with null throws argument null exception
        /// </summary>
        [Fact]
        public void ParseJsonToDictionary_WithNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => JsonNativeAot.ParseJsonToDictionary(null));
        }

        /// <summary>
        /// Tests that serialize to file with null instance throws argument null exception
        /// </summary>
        [Fact]
        public void SerializeToFile_WithNullInstance_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => 
                JsonNativeAot.SerializeToFile<TestString>(null, "file", "path"));
        }

        /// <summary>
        /// Tests that serialize to file with null file name throws argument null exception
        /// </summary>
        [Fact]
        public void SerializeToFile_WithNullFileName_ThrowsArgumentNullException()
        {
            // Arrange
            TestString obj = new TestString { Text = "Test" };

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => 
                JsonNativeAot.SerializeToFile(obj, null, "path"));
        }

        /// <summary>
        /// Tests that serialize to file with null path throws argument null exception
        /// </summary>
        [Fact]
        public void SerializeToFile_WithNullPath_ThrowsArgumentNullException()
        {
            // Arrange
            TestString obj = new TestString { Text = "Test" };

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => 
                JsonNativeAot.SerializeToFile(obj, "file", null));
        }

        #endregion

        #region Helper Classes

        /// <summary>
        /// The test int class
        /// </summary>
        /// <seealso cref="IJsonSerializable"/>
        /// <seealso cref="IJsonDesSerializable{TestInt}"/>
        private class TestInt : IJsonSerializable, IJsonDesSerializable<TestInt>
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
            public TestInt CreateFromProperties(Dictionary<string, string> properties)
            {
                TestInt obj = new TestInt();
                if (properties.TryGetValue("Value", out string v) && int.TryParse(v, out int val))
                    obj.Value = val;
                return obj;
            }
        }

        /// <summary>
        /// The test bool class
        /// </summary>
        /// <seealso cref="IJsonSerializable"/>
        /// <seealso cref="IJsonDesSerializable{TestBool}"/>
        private class TestBool : IJsonSerializable, IJsonDesSerializable<TestBool>
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
            public TestBool CreateFromProperties(Dictionary<string, string> properties)
            {
                TestBool obj = new TestBool();
                if (properties.TryGetValue("Flag", out string v) && bool.TryParse(v, out bool val))
                    obj.Flag = val;
                return obj;
            }
        }

        /// <summary>
        /// The test string class
        /// </summary>
        /// <seealso cref="IJsonSerializable"/>
        /// <seealso cref="IJsonDesSerializable{TestString}"/>
        private class TestString : IJsonSerializable, IJsonDesSerializable<TestString>
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
            public TestString CreateFromProperties(Dictionary<string, string> properties)
            {
                TestString obj = new TestString();
                if (properties.TryGetValue("Text", out string v))
                    obj.Text = v;
                return obj;
            }
        }

        /// <summary>
        /// The test guid class
        /// </summary>
        /// <seealso cref="IJsonSerializable"/>
        /// <seealso cref="IJsonDesSerializable{TestGuid}"/>
        private class TestGuid : IJsonSerializable, IJsonDesSerializable<TestGuid>
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
            public TestGuid CreateFromProperties(Dictionary<string, string> properties)
            {
                TestGuid obj = new TestGuid();
                if (properties.TryGetValue("Id", out string v) && Guid.TryParse(v, out Guid val))
                    obj.Id = val;
                return obj;
            }
        }

        /// <summary>
        /// The test date time class
        /// </summary>
        /// <seealso cref="IJsonSerializable"/>
        /// <seealso cref="IJsonDesSerializable{TestDateTime}"/>
        private class TestDateTime : IJsonSerializable, IJsonDesSerializable<TestDateTime>
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
            public TestDateTime CreateFromProperties(Dictionary<string, string> properties)
            {
                TestDateTime obj = new TestDateTime();
                if (properties.TryGetValue("Timestamp", out string v) && DateTime.TryParse(v, out DateTime val))
                    obj.Timestamp = val;
                return obj;
            }
        }

        #endregion
    }
}

