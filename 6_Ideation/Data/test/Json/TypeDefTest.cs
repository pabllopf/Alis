// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TypeDefTest.cs
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
using System.Collections.Generic;
using System.IO;
using Alis.Core.Aspect.Data.Json;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json
{
    /// <summary>
    /// The type def test class
    /// </summary>
    public class TypeDefTest
    {
        /// <summary>
        /// Tests that test type def constructor
        /// </summary>
        [Fact]
        public void TestTypeDefConstructor()
        {
            JsonOptions options = new JsonOptions();
            TypeDef typeDef = new TypeDef(typeof(string), options);

            Assert.NotNull(typeDef);
        }

        /// <summary>
        /// Tests that test get deserialization member
        /// </summary>
        [Fact]
        public void TestGetDeserializationMember()
        {
            JsonOptions options = new JsonOptions();
            TypeDef typeDef = new TypeDef(typeof(string), options);

            MemberDefinition member = typeDef.GetDeserializationMember("Length");

            Assert.Null(member);
        }

        /// <summary>
        /// Tests that test apply entry
        /// </summary>
        [Fact]
        public void TestApplyEntry()
        {
            JsonOptions options = new JsonOptions();
            TypeDef typeDef = new TypeDef(typeof(string), options);
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            typeDef.ApplyEntry(dictionary, "test", "Length", 4, options);

            Assert.False(dictionary.ContainsKey("Length"));
        }

        /// <summary>
        /// Tests that test write values
        /// </summary>
        [Fact]
        public void TestWriteValues()
        {
            JsonOptions options = new JsonOptions();
            TypeDef typeDef = new TypeDef(typeof(string), options);
            Dictionary<object, object> objectGraph = new Dictionary<object, object>();
            StringWriter writer = new StringWriter();

            typeDef.WriteValues(writer, "test", objectGraph, options);

            Assert.Empty(writer.ToString());
        }

        /// <summary>
        /// Tests that test to string
        /// </summary>
        [Fact]
        public void TestToString()
        {
            JsonOptions options = new JsonOptions();
            TypeDef typeDef = new TypeDef(typeof(string), options);

            string result = typeDef.ToString();

            Assert.Equal("System.String, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", result);
        }

        /// <summary>
        /// Tests that test get key
        /// </summary>
        [Fact]
        public void TestGetKey()
        {
            JsonOptions options = new JsonOptions();

            string key = TypeDef.GetKey(typeof(string), options);

            Assert.Equal("System.String, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e\012112010", key);
        }

        /// <summary>
        /// Tests that test unlocked get
        /// </summary>
        [Fact]
        public void TestUnlockedGet()
        {
            JsonOptions options = new JsonOptions();

            TypeDef result = TypeDef.UnlockedGet(typeof(string), options);

            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that test lock method
        /// </summary>
        [Fact]
        public void TestLockMethod()
        {
            TypeDef.LockMethod((x) => { }, "test");

            Assert.True(true);
        }

        /// <summary>
        /// Tests that test remove deserialization member
        /// </summary>
        [Fact]
        public void TestRemoveDeserializationMember()
        {
            JsonOptions options = new JsonOptions();

            bool result = TypeDef.RemoveDeserializationMember(typeof(string), options, new MemberDefinition());

            Assert.False(result);
        }

        /// <summary>
        /// Tests that test remove serialization member
        /// </summary>
        [Fact]
        public void TestRemoveSerializationMember()
        {
            JsonOptions options = new JsonOptions();

            bool result = TypeDef.RemoveSerializationMember(typeof(string), options, new MemberDefinition());

            Assert.False(result);
        }

        /// <summary>
        /// Tests that test add deserialization member
        /// </summary>
        [Fact]
        public void TestAddDeserializationMember()
        {
            JsonOptions options = new JsonOptions();

            TypeDef.AddDeserializationMember(typeof(string), options, new MemberDefinition());

            Assert.True(true);
        }

        /// <summary>
        /// Tests that test add serialization member
        /// </summary>
        [Fact]
        public void TestAddSerializationMember()
        {
            JsonOptions options = new JsonOptions();

            TypeDef.AddSerializationMember(typeof(string), options, new MemberDefinition());

            Assert.True(true);
        }

        /// <summary>
        /// Tests that test get deserialization members
        /// </summary>
        [Fact]
        public void TestGetDeserializationMembers()
        {
            JsonOptions options = new JsonOptions();

            MemberDefinition[] members = TypeDef.GetDeserializationMembers(typeof(string), options);

            Assert.Empty(members);
        }

        /// <summary>
        /// Tests that test get serialization members
        /// </summary>
        [Fact]
        public void TestGetSerializationMembers()
        {
            JsonOptions options = new JsonOptions();

            MemberDefinition[] members = TypeDef.GetSerializationMembers(typeof(string), options);

            Assert.Empty(members);
        }

        /// <summary>
        /// Tests that test get
        /// </summary>
        [Fact]
        public void TestGet()
        {
            JsonOptions options = new JsonOptions();

            TypeDef result = TypeDef.Get(typeof(string), options);

            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that test is key value pair enumerable
        /// </summary>
        [Fact]
        public void TestIsKeyValuePairEnumerable()
        {
            bool result = TypeDef.IsKeyValuePairEnumerable(typeof(Dictionary<string, string>), out Type keyType, out Type valueType);

            Assert.True(result);
            Assert.Equal(typeof(string), keyType);
            Assert.Equal(typeof(string), valueType);
        }

        /// <summary>
        /// Tests that test enumerate definitions using reflection serialization
        /// </summary>
        [Fact]
        public void TestEnumerateDefinitionsUsingReflection_Serialization()
        {
            // Arrange
            Type type = typeof(MyClassSample); // Replace with your actual class type
            JsonOptions options = new JsonOptions(); // Initialize with your actual options

            // Act
            IEnumerable<MemberDefinition> result = TypeDef.EnumerateDefinitionsUsingReflection(true, type, options);

            // Assert
            Assert.NotNull(result);
            // Add more assertions based on your expected result
        }

        /// <summary>
        /// Tests that test enumerate definitions using reflection deserialization
        /// </summary>
        [Fact]
        public void TestEnumerateDefinitionsUsingReflection_Deserialization()
        {
            // Arrange
            Type type = typeof(MyClassSample); // Replace with your actual class type
            JsonOptions options = new JsonOptions(); // Initialize with your actual options

            // Act
            IEnumerable<MemberDefinition> result = TypeDef.EnumerateDefinitionsUsingReflection(false, type, options);

            // Assert
            Assert.NotNull(result);
            // Add more assertions based on your expected result
        }

        /// <summary>
        /// Tests that test enumerate definitions using reflection v 2 serialization
        /// </summary>
        [Fact]
        public void TestEnumerateDefinitionsUsingReflection_v2_Serialization()
        {
            // Arrange
            Type type = typeof(MyClassSample); // Replace with your actual class type
            JsonOptions options = new JsonOptions(); // Initialize with your actual options

            // Act
            IEnumerable<MemberDefinition> result = TypeDef.EnumerateDefinitionsUsingReflection(true, type, options);

            // Assert
            Assert.NotNull(result);
            // Add more assertions based on your expected result
        }

        /// <summary>
        /// Tests that test enumerate definitions using reflection v 2 deserialization
        /// </summary>
        [Fact]
        public void TestEnumerateDefinitionsUsingReflection_v2_Deserialization()
        {
            // Arrange
            Type type = typeof(MyClassSample); // Replace with your actual class type
            JsonOptions options = new JsonOptions(); // Initialize with your actual options

            // Act
            IEnumerable<MemberDefinition> result = TypeDef.EnumerateDefinitionsUsingReflection(false, type, options);

            // Assert
            Assert.NotNull(result);
            // Add more assertions based on your expected result
        }

        /// <summary>
        /// Tests that test write values skip null property values
        /// </summary>
        [Fact]
        public void TestWriteValues_SkipNullPropertyValues()
        {
            // Arrange
            StringWriter writer = new StringWriter();
            var component = new {TestProperty = (string) null};
            Dictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.SkipNullPropertyValues};

            TypeDef typeDef = new TypeDef(component.GetType(), options);

            // Act
            typeDef.WriteValues(writer, component, objectGraph, options);

            // Assert
            Assert.Equal("", writer.ToString());
        }

        /// <summary>
        /// Tests that test write values skip zero value types
        /// </summary>
        [Fact]
        public void TestWriteValues_SkipZeroValueTypes()
        {
            // Arrange
            StringWriter writer = new StringWriter();
            var component = new {TestProperty = 0};
            Dictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.SkipZeroValueTypes};

            TypeDef typeDef = new TypeDef(component.GetType(), options);

            // Act
            typeDef.WriteValues(writer, component, objectGraph, options);

            // Assert
            Assert.Equal("", writer.ToString());
        }

        /// <summary>
        /// Tests that test write values skip null date time values
        /// </summary>
        [Fact]
        public void TestWriteValues_SkipNullDateTimeValues()
        {
            // Arrange
            StringWriter writer = new StringWriter();
            var component = new {TestProperty = (DateTime?) null};
            Dictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.SkipNullDateTimeValues};

            TypeDef typeDef = new TypeDef(component.GetType(), options);

            // Act
            typeDef.WriteValues(writer, component, objectGraph, options);

            // Assert
            Assert.Equal("", writer.ToString());
        }

        /// <summary>
        /// Tests that test write values skip default values
        /// </summary>
        [Fact]
        public void TestWriteValues_SkipDefaultValues()
        {
            // Arrange
            StringWriter writer = new StringWriter();
            var component = new {TestProperty = default(int)};
            Dictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.SkipDefaultValues};

            TypeDef typeDef = new TypeDef(component.GetType(), options);

            // Act
            typeDef.WriteValues(writer, component, objectGraph, options);

            string result = writer.ToString();
            
            // Assert
            Assert.Equal("\"TestProperty\":0", result);
        }

        /// <summary>
        /// Tests that test write values write keys without quotes
        /// </summary>
        [Fact]
        public void TestWriteValues_WriteKeysWithoutQuotes()
        {
            // Arrange
            StringWriter writer = new StringWriter();
            var component = new {TestProperty = "test"};
            Dictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.WriteKeysWithoutQuotes};

            TypeDef typeDef = new TypeDef(component.GetType(), options);

            // Act
            typeDef.WriteValues(writer, component, objectGraph, options);

            // Assert
            Assert.Equal("TestProperty:\"test\"", writer.ToString());
        }

        /// <summary>
        /// Tests that test write values default
        /// </summary>
        [Fact]
        public void TestWriteValues_Default()
        {
            // Arrange
            StringWriter writer = new StringWriter();
            var component = new {TestProperty = "test"};
            Dictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();

            TypeDef typeDef = new TypeDef(component.GetType(), options);

            // Act
            typeDef.WriteValues(writer, component, objectGraph, options);

            string result = writer.ToString();
            
            // Assert
            Assert.Equal("", result);
        }
    }
}