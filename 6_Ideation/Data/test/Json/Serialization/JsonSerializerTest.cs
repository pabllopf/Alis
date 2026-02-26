// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: JsonSerializerTest.cs
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
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Data.Json.Serialization;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json.Serialization
{
    /// <summary>
    /// The json serializer test class
    /// </summary>
    public class JsonSerializerTest
    {
        /// <summary>
        /// The serializer
        /// </summary>
        private readonly JsonSerializer _serializer;

        /// <summary>
        /// The simple test object class
        /// </summary>
        /// <seealso cref="IJsonSerializable"/>
        private class SimpleTestObject : IJsonSerializable
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
            /// Gets the serializable properties
            /// </summary>
            /// <returns>An enumerable of string property name and string value</returns>
            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Name", Name);
                yield return ("Age", Age.ToString());
            }
        }

        /// <summary>
        /// The object with array class
        /// </summary>
        /// <seealso cref="IJsonSerializable"/>
        private class ObjectWithArray : IJsonSerializable
        {
            /// <summary>
            /// Gets the serializable properties
            /// </summary>
            /// <returns>An enumerable of string property name and string value</returns>
            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("items", "[\"a\",\"b\",\"c\"]");
            }
        }

        /// <summary>
        /// The object with null property class
        /// </summary>
        /// <seealso cref="IJsonSerializable"/>
        private class ObjectWithNullProperty : IJsonSerializable
        {
            /// <summary>
            /// Gets the serializable properties
            /// </summary>
            /// <returns>An enumerable of string property name and string value</returns>
            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Name", "John");
                yield return ("Email", null);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSerializerTest"/> class
        /// </summary>
        public JsonSerializerTest()
        {
            _serializer = new JsonSerializer();
        }

        /// <summary>
        /// Tests that serialize with simple object returns valid json
        /// </summary>
        [Fact]
        public void Serialize_WithSimpleObject_ReturnsValidJson()
        {
            SimpleTestObject obj = new SimpleTestObject { Name = "John", Age = 30 };
            string result = _serializer.Serialize(obj);

            Assert.Contains("\"Name\"", result);
            Assert.Contains("\"John\"", result);
            Assert.Contains("\"Age\"", result);
            Assert.Contains("\"30\"", result);
        }

        /// <summary>
        /// Tests that serialize with null instance throws argument null exception
        /// </summary>
        [Fact]
        public void Serialize_WithNullInstance_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _serializer.Serialize<SimpleTestObject>(null));
        }

        /// <summary>
        /// Tests that serialize with array property does not add quotes
        /// </summary>
        [Fact]
        public void Serialize_WithArrayProperty_DoesNotAddQuotes()
        {
            ObjectWithArray obj = new ObjectWithArray();
            string result = _serializer.Serialize(obj);

            Assert.Contains("\"items\":[\"a\",\"b\",\"c\"]", result);
        }

        /// <summary>
        /// Tests that serialize with null property excludes property
        /// </summary>
        [Fact]
        public void Serialize_WithNullProperty_ExcludesProperty()
        {
            ObjectWithNullProperty obj = new ObjectWithNullProperty();
            string result = _serializer.Serialize(obj);

            Assert.Contains("\"Name\"", result);
            Assert.DoesNotContain("Email", result);
        }

        /// <summary>
        /// Tests that serialize result starts with open brace
        /// </summary>
        [Fact]
        public void Serialize_ResultStartsWithOpenBrace()
        {
            SimpleTestObject obj = new SimpleTestObject { Name = "Test", Age = 25 };
            string result = _serializer.Serialize(obj);

            Assert.StartsWith("{", result);
        }

        /// <summary>
        /// Tests that serialize result ends with close brace
        /// </summary>
        [Fact]
        public void Serialize_ResultEndsWithCloseBrace()
        {
            SimpleTestObject obj = new SimpleTestObject { Name = "Test", Age = 25 };
            string result = _serializer.Serialize(obj);

            Assert.EndsWith("}", result);
        }

        /// <summary>
        /// Tests that serialize with object property does not add quotes
        /// </summary>
        [Fact]
        public void Serialize_WithObjectProperty_DoesNotAddQuotes()
        {
            ObjectWithArray obj = new ObjectWithArray();
            string result = _serializer.Serialize(obj);

            Assert.StartsWith("{", result);
            Assert.Contains("[", result);
        }

        /// <summary>
        /// Tests that serialize with multiple properties separated by commas
        /// </summary>
        [Fact]
        public void Serialize_WithMultipleProperties_SeparatedByCommas()
        {
            SimpleTestObject obj = new SimpleTestObject { Name = "John", Age = 30 };
            string result = _serializer.Serialize(obj);

            int commaCount = result.Split(',').Length - 1;
            Assert.True(commaCount > 0);
        }

        /// <summary>
        /// Tests that serialize with object with no properties returns empty object
        /// </summary>
        [Fact]
        public void Serialize_WithObjectWithNoProperties_ReturnsEmptyObject()
        {
            EmptyObject obj = new EmptyObject();
            string result = _serializer.Serialize(obj);

            Assert.Equal("{}", result);
        }

        /// <summary>
        /// The empty object class
        /// </summary>
        /// <seealso cref="IJsonSerializable"/>
        private class EmptyObject : IJsonSerializable
        {
            /// <summary>
            /// Gets the serializable properties
            /// </summary>
            /// <returns>An enumerable of string property name and string value</returns>
            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield break;
            }
        }
    }
}

