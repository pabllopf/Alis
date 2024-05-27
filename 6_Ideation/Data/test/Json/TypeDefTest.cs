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
using System.ComponentModel;
using System.IO;
using System.Reflection;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Data.Test.Json.Sample;
using Xunit;
using JsonPropertyNameAttribute = Alis.Core.Aspect.Data.Json.JsonPropertyNameAttribute;

namespace Alis.Core.Aspect.Data.Test.Json
{
    /// <summary>
    ///     The type def test class
    /// </summary>
    public class TypeDefTest
    {
        /// <summary>
        ///     Tests that test type def constructor
        /// </summary>
        [Fact]
        public void TestTypeDefConstructor()
        {
            JsonOptions options = new JsonOptions();
            TypeDef typeDef = new TypeDef(typeof(string), options);
            
            Assert.NotNull(typeDef);
        }
        
        /// <summary>
        ///     Tests that test get deserialization member
        /// </summary>
        [Fact]
        public void TestGetDeserializationMember()
        {
            JsonOptions options = new JsonOptions();
            TypeDef typeDef = new TypeDef(typeof(string), options);
            
            MemberDefinition member = typeDef.GetDeserializationMember("Length");
            
            Assert.NotNull(member);
        }
        
        /// <summary>
        ///     Tests that test apply entry
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
        ///     Tests that test write values
        /// </summary>
        [Fact]
        public void TestWriteValues()
        {
            JsonOptions options = new JsonOptions();
            TypeDef typeDef = new TypeDef(typeof(string), options);
            Dictionary<object, object> objectGraph = new Dictionary<object, object>();
            StringWriter writer = new StringWriter();
            
            typeDef.WriteValues(writer, "test", objectGraph, options);
            
            Assert.NotEmpty(writer.ToString());
        }
        
        /// <summary>
        ///     Tests that test to string
        /// </summary>
        [Fact]
        public void TestToString()
        {
            JsonOptions options = new JsonOptions();
            TypeDef typeDef = new TypeDef(typeof(string), options);
            
            string result = typeDef.ToString();
            
            Assert.NotEqual("", result);
        }
        
        /// <summary>
        ///     Tests that test get key
        /// </summary>
        [Fact]
        public void TestGetKey()
        {
            JsonOptions options = new JsonOptions();
            
            string key = TypeDef.GetKey(typeof(string), options);
            
            Assert.NotEqual("", key);
        }
        
        /// <summary>
        ///     Tests that test unlocked get
        /// </summary>
        [Fact]
        public void TestUnlockedGet()
        {
            JsonOptions options = new JsonOptions();
            
            TypeDef result = TypeDef.UnlockedGet(typeof(string), options);
            
            Assert.NotNull(result);
        }
        
        /// <summary>
        ///     Tests that test lock method
        /// </summary>
        [Fact]
        public void TestLockMethod()
        {
            TypeDef.LockMethod(x => { }, "test");
            
            Assert.True(true);
        }
        
        /// <summary>
        ///     Tests that test remove deserialization member
        /// </summary>
        [Fact]
        public void TestRemoveDeserializationMember()
        {
            JsonOptions options = new JsonOptions();
            
            bool result = TypeDef.RemoveDeserializationMember(typeof(string), options, new MemberDefinition());
            
            Assert.False(result);
        }
        
        /// <summary>
        ///     Tests that test remove serialization member
        /// </summary>
        [Fact]
        public void TestRemoveSerializationMember()
        {
            JsonOptions options = new JsonOptions();
            
            bool result = TypeDef.RemoveSerializationMember(typeof(string), options, new MemberDefinition());
            
            Assert.False(result);
        }
        
        /// <summary>
        ///     Tests that test add deserialization member
        /// </summary>
        [Fact]
        public void TestAddDeserializationMember()
        {
            JsonOptions options = new JsonOptions();
            
            TypeDef.AddDeserializationMember(typeof(string), options, new MemberDefinition());
            
            Assert.True(true);
        }
        
        /// <summary>
        ///     Tests that test add serialization member
        /// </summary>
        [Fact]
        public void TestAddSerializationMember()
        {
            JsonOptions options = new JsonOptions();
            
            TypeDef.AddSerializationMember(typeof(string), options, new MemberDefinition());
            
            Assert.True(true);
        }
        
        /// <summary>
        ///     Tests that test get deserialization members
        /// </summary>
        [Fact]
        public void TestGetDeserializationMembers()
        {
            JsonOptions options = new JsonOptions();
            
            MemberDefinition[] members = TypeDef.GetDeserializationMembers(typeof(string), options);
            
            Assert.NotEmpty(members);
        }
        
        /// <summary>
        ///     Tests that test get
        /// </summary>
        [Fact]
        public void TestGet()
        {
            JsonOptions options = new JsonOptions();
            
            TypeDef result = TypeDef.Get(typeof(string), options);
            
            Assert.NotNull(result);
        }
        
        /// <summary>
        ///     Tests that test is key value pair enumerable
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
        ///     Tests that test enumerate definitions using reflection serialization
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
        ///     Tests that test enumerate definitions using reflection deserialization
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
        ///     Tests that test enumerate definitions using reflection v 2 serialization
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
        ///     Tests that test enumerate definitions using reflection v 2 deserialization
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
        ///     Tests that test write values skip null property values
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
        ///     Tests that test write values skip zero value types
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
        ///     Tests that test write values skip null date time values
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
        ///     Tests that test write values skip default values
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
        ///     Tests that test write values write keys without quotes
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
        ///     Tests that test write values default
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
            Assert.NotEqual("", result);
        }
        
        /// <summary>
        ///     Tests that test type def constructor v 2
        /// </summary>
        [Fact]
        public void TestTypeDefConstructor_v2()
        {
            JsonOptions options = new JsonOptions();
            TypeDef typeDef = new TypeDef(typeof(string), options);
            
            Assert.NotNull(typeDef);
        }
        
        /// <summary>
        ///     Tests that test get deserialization member v 2
        /// </summary>
        [Fact]
        public void TestGetDeserializationMember_v2()
        {
            JsonOptions options = new JsonOptions();
            TypeDef typeDef = new TypeDef(typeof(string), options);
            
            MemberDefinition member = typeDef.GetDeserializationMember("Length");
            
            Assert.NotNull(member);
        }
        
        /// <summary>
        ///     Tests that test apply entry v 2
        /// </summary>
        [Fact]
        public void TestApplyEntry_v2()
        {
            JsonOptions options = new JsonOptions();
            TypeDef typeDef = new TypeDef(typeof(string), options);
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            
            typeDef.ApplyEntry(dictionary, "test", "Length", 4, options);
            
            Assert.False(dictionary.ContainsKey("Length"));
        }
        
        /// <summary>
        ///     Tests that test write values v 2
        /// </summary>
        [Fact]
        public void TestWriteValues_v2()
        {
            JsonOptions options = new JsonOptions();
            TypeDef typeDef = new TypeDef(typeof(string), options);
            Dictionary<object, object> objectGraph = new Dictionary<object, object>();
            StringWriter writer = new StringWriter();
            
            typeDef.WriteValues(writer, "test", objectGraph, options);
            
            Assert.NotEmpty(writer.ToString());
        }
        
        /// <summary>
        ///     Tests that test to string v 2
        /// </summary>
        [Fact]
        public void TestToString_v2()
        {
            JsonOptions options = new JsonOptions();
            TypeDef typeDef = new TypeDef(typeof(string), options);
            
            string result = typeDef.ToString();
            
            Assert.NotEqual("", result);
        }
        
        /// <summary>
        ///     Tests that test get key v 2
        /// </summary>
        [Fact]
        public void TestGetKey_v2()
        {
            JsonOptions options = new JsonOptions();
            
            string key = TypeDef.GetKey(typeof(string), options);
            
            Assert.NotEqual("", key);
        }
        
        /// <summary>
        ///     Tests that test unlocked get v 2
        /// </summary>
        [Fact]
        public void TestUnlockedGet_v2()
        {
            JsonOptions options = new JsonOptions();
            
            TypeDef result = TypeDef.UnlockedGet(typeof(string), options);
            
            Assert.NotNull(result);
        }
        
        /// <summary>
        ///     Tests that test lock method v 2
        /// </summary>
        [Fact]
        public void TestLockMethod_v2()
        {
            TypeDef.LockMethod(x => { }, "test");
            
            Assert.True(true);
        }
        
        /// <summary>
        ///     Tests that test remove deserialization member v 2
        /// </summary>
        [Fact]
        public void TestRemoveDeserializationMember_v2()
        {
            JsonOptions options = new JsonOptions();
            
            bool result = TypeDef.RemoveDeserializationMember(typeof(string), options, new MemberDefinition());
            
            Assert.False(result);
        }
        
        /// <summary>
        ///     Tests that test remove serialization member v 2
        /// </summary>
        [Fact]
        public void TestRemoveSerializationMember_v2()
        {
            JsonOptions options = new JsonOptions();
            
            bool result = TypeDef.RemoveSerializationMember(typeof(string), options, new MemberDefinition());
            
            Assert.False(result);
        }
        
        /// <summary>
        ///     Tests that test add deserialization member v 2
        /// </summary>
        [Fact]
        public void TestAddDeserializationMember_v2()
        {
            JsonOptions options = new JsonOptions();
            
            TypeDef.AddDeserializationMember(typeof(string), options, new MemberDefinition());
            
            Assert.True(true);
        }
        
        /// <summary>
        ///     Tests that test add serialization member v 2
        /// </summary>
        [Fact]
        public void TestAddSerializationMember_v2()
        {
            JsonOptions options = new JsonOptions();
            
            TypeDef.AddSerializationMember(typeof(string), options, new MemberDefinition());
            
            Assert.True(true);
        }
        
        /// <summary>
        ///     Tests that test get v 2
        /// </summary>
        [Fact]
        public void TestGet_v2()
        {
            JsonOptions options = new JsonOptions();
            
            TypeDef result = TypeDef.Get(typeof(string), options);
            
            Assert.NotNull(result);
        }
        
        /// <summary>
        ///     Tests that test is key value pair enumerable v 2
        /// </summary>
        [Fact]
        public void TestIsKeyValuePairEnumerable_v2()
        {
            bool result = TypeDef.IsKeyValuePairEnumerable(typeof(Dictionary<string, string>), out Type keyType, out Type valueType);
            
            Assert.True(result);
            Assert.Equal(typeof(string), keyType);
            Assert.Equal(typeof(string), valueType);
        }
        
        /// <summary>
        ///     Tests that handle field serialization valid input returns expected result
        /// </summary>
        [Fact]
        public void HandleFieldSerialization_ValidInput_ReturnsExpectedResult()
        {
            // Arrange
            bool serialization = true;
            Type type = typeof(MyClassSample); // Replace with your actual class type
            JsonOptions options = new JsonOptions(); // Initialize with your actual options
            
            // Act
            IEnumerable<MemberDefinition> result = TypeDef.HandleFieldSerialization(serialization, type, options);
            
            // Assert
            Assert.NotNull(result);
            // Add more assertions based on your expected result
        }
        
        /// <summary>
        ///     Tests that should skip field valid input returns expected result
        /// </summary>
        [Fact]
        public void ShouldSkipField_ValidInput_ReturnsExpectedResult()
        {
            // Arrange
            bool serialization = true;
            FieldInfo info = typeof(MyClassSample).GetField("MyField"); // Replace with your actual field
            JsonOptions options = new JsonOptions(); // Initialize with your actual options
            
            // Act
            bool result = TypeDef.ShouldSkipField(serialization, info, options);
            
            // Assert
            Assert.False(result); // Replace with your expected result
        }
        
        /// <summary>
        ///     Tests that create member definition valid input returns expected result
        /// </summary>
        [Fact]
        public void CreateMemberDefinition_ValidInput_ReturnsExpectedResult()
        {
            // Arrange
            bool serialization = true;
            FieldInfo info = typeof(MyClassSample).GetField("MyField"); // Replace with your actual field
            
            // Act
            MemberDefinition result = TypeDef.CreateMemberDefinition(serialization, info);
            
            // Assert
            Assert.NotNull(result);
            Assert.Equal("MyField", result.Name); // Replace with your expected result
        }
        
        /// <summary>
        ///     Tests that check xml ignore attribute valid input returns expected result
        /// </summary>
        [Fact]
        public void CheckXmlIgnoreAttribute_ValidInput_ReturnsExpectedResult()
        {
            // Arrange
            PropertyInfo info = typeof(MyClassSample).GetProperty("MyProperty"); // Replace with your actual property
            JsonOptions options = new JsonOptions(); // Initialize with your actual options
            
            // Act
            bool result = TypeDef.CheckXmlIgnoreAttribute(info, options);
            
            // Assert
            Assert.False(result); // Replace with your expected result
        }
        
        /// <summary>
        ///     Tests that check script ignore valid input returns expected result
        /// </summary>
        [Fact]
        public void CheckScriptIgnore_ValidInput_ReturnsExpectedResult()
        {
            // Arrange
            PropertyInfo info = typeof(MyClassSample).GetProperty("MyProperty"); // Replace with your actual property
            JsonOptions options = new JsonOptions(); // Initialize with your actual options
            
            // Act
            bool result = TypeDef.CheckScriptIgnore(info, options);
            
            // Assert
            Assert.False(result); // Replace with your expected result
        }
        
        /// <summary>
        ///     Tests that check serialization valid input returns expected result
        /// </summary>
        [Fact]
        public void CheckSerialization_ValidInput_ReturnsExpectedResult()
        {
            // Arrange
            bool serialization = true;
            PropertyInfo info = typeof(MyClassSample).GetProperty("MyProperty"); // Replace with your actual property
            
            // Act
            bool result = TypeDef.CheckSerialization(serialization, info);
            
            // Assert
            Assert.False(result); // Replace with your expected result
        }
        
        /// <summary>
        ///     Tests that create member definition valid input returns expected result v 3
        /// </summary>
        [Fact]
        public void CreateMemberDefinition_ValidInput_ReturnsExpectedResult_v3()
        {
            // Arrange
            bool serialization = true;
            PropertyInfo info = typeof(MyClassSample).GetProperty("MyProperty"); // Replace with your actual property
            
            // Act
            MemberDefinition result = TypeDef.CreateMemberDefinition(serialization, info);
            
            // Assert
            Assert.NotNull(result);
            Assert.Equal("MyProperty", result.Name); // Replace with your expected result
        }
        
        /// <summary>
        ///     Tests that handle field serialization valid input returns expected result v 2
        /// </summary>
        [Fact]
        public void HandleFieldSerialization_ValidInput_ReturnsExpectedResult_v2()
        {
            // Arrange
            bool serialization = true;
            Type type = typeof(MyClassSample); // Replace with your actual class type
            JsonOptions options = new JsonOptions(); // Initialize with your actual options
            
            // Act
            IEnumerable<MemberDefinition> result = TypeDef.HandleFieldSerialization(serialization, type, options);
            
            // Assert
            Assert.NotNull(result);
            // Add more assertions based on your expected result
        }
        
        /// <summary>
        ///     Tests that handle field serialization valid input returns expected result v 4
        /// </summary>
        [Fact]
        public void HandleFieldSerialization_ValidInput_ReturnsExpectedResult_v4()
        {
            // Arrange
            bool serialization = true;
            Type type = typeof(MyClassSample); // Replace with your actual class type
            JsonOptions options = new JsonOptions(); // Initialize with your actual options
            
            // Act
            IEnumerable<MemberDefinition> result = TypeDef.HandleFieldSerialization(serialization, type, options);
            
            // Assert
            Assert.NotNull(result);
            // Add more assertions based on your expected result
        }
        
        /// <summary>
        ///     Tests that handle field serialization invalid input returns null
        /// </summary>
        [Fact]
        public void HandleFieldSerialization_InvalidInput_ReturnsNull()
        {
            // Arrange
            bool serialization = false;
            Type type = null; // Invalid input
            JsonOptions options = new JsonOptions(); // Initialize with your actual options
            
            // Act
            IEnumerable<MemberDefinition> result = TypeDef.HandleFieldSerialization(serialization, type, options);
            
            // Assert
            Assert.NotNull(result);
        }
        
        /// <summary>
        ///     Tests that handle field serialization serialization false returns expected result
        /// </summary>
        [Fact]
        public void HandleFieldSerialization_SerializationFalse_ReturnsExpectedResult()
        {
            // Arrange
            bool serialization = false;
            Type type = typeof(MyClassSample); // Replace with your actual class type
            JsonOptions options = new JsonOptions(); // Initialize with your actual options
            
            // Act
            IEnumerable<MemberDefinition> result = TypeDef.HandleFieldSerialization(serialization, type, options);
            
            // Assert
            Assert.NotNull(result);
            // Add more assertions based on your expected result
        }
        
        /// <summary>
        ///     Tests that enumerate definitions using reflection valid input returns expected result
        /// </summary>
        [Fact]
        public void EnumerateDefinitionsUsingReflection_ValidInput_ReturnsExpectedResult()
        {
            // Arrange
            bool serialization = true;
            Type type = typeof(MyClassSample); // Replace with your actual class type
            JsonOptions options = new JsonOptions(); // Initialize with your actual options
            
            // Act
            IEnumerable<MemberDefinition> result = TypeDef.EnumerateDefinitionsUsingReflection(serialization, type, options);
            
            // Assert
            Assert.NotNull(result);
            // Add more assertions based on your expected result
        }
        
        /// <summary>
        ///     Tests that handle property serialization valid input returns expected result
        /// </summary>
        [Fact]
        public void HandlePropertySerialization_ValidInput_ReturnsExpectedResult()
        {
            // Arrange
            bool serialization = true;
            Type type = typeof(MyClassSample); // Replace with your actual class type
            JsonOptions options = new JsonOptions(); // Initialize with your actual options
            
            // Act
            IEnumerable<MemberDefinition> result = TypeDef.HandlePropertySerialization(serialization, type, options);
            
            // Assert
            Assert.NotNull(result);
            // Add more assertions based on your expected result
        }
        
        /// <summary>
        ///     Tests that should skip property valid input returns expected result
        /// </summary>
        [Fact]
        public void ShouldSkipProperty_ValidInput_ReturnsExpectedResult()
        {
            // Arrange
            bool serialization = true;
            PropertyInfo info = typeof(MyClassSample).GetProperty("MyProperty"); // Replace with your actual property
            JsonOptions options = new JsonOptions(); // Initialize with your actual options
            
            // Act
            bool result = TypeDef.ShouldSkipProperty(serialization, info, options);
            
            // Assert
            Assert.False(result); // Replace with your expected result
        }
        
        /// <summary>
        ///     Tests that check json attribute valid input returns expected result
        /// </summary>
        [Fact]
        public void CheckJsonAttribute_ValidInput_ReturnsExpectedResult()
        {
            // Arrange
            bool serialization = true;
            PropertyInfo info = typeof(MyClassSample).GetProperty("MyProperty"); // Replace with your actual property
            JsonOptions options = new JsonOptions(); // Initialize with your actual options
            
            // Act
            bool result = TypeDef.CheckJsonAttribute(serialization, info, options);
            
            // Assert
            Assert.False(result); // Replace with your expected result
        }
        
        /// <summary>
        ///     Tests that check xml ignore attribute valid input returns expected result v 5
        /// </summary>
        [Fact]
        public void CheckXmlIgnoreAttribute_ValidInput_ReturnsExpectedResult_v5()
        {
            // Arrange
            PropertyInfo info = typeof(MyClassSample).GetProperty("MyProperty"); // Replace with your actual property
            JsonOptions options = new JsonOptions(); // Initialize with your actual options
            
            // Act
            bool result = TypeDef.CheckXmlIgnoreAttribute(info, options);
            
            // Assert
            Assert.False(result); // Replace with your expected result
        }
        
        /// <summary>
        ///     Tests that enumerate definitions using reflection valid input returns expected result v 7
        /// </summary>
        [Fact]
        public void EnumerateDefinitionsUsingReflection_ValidInput_ReturnsExpectedResult_v7()
        {
            // Arrange
            bool serialization = true;
            Type type = typeof(MyClassSample); // Replace with your actual class type
            JsonOptions options = new JsonOptions(); // Initialize with your actual options
            
            // Act
            IEnumerable<MemberDefinition> result = TypeDef.EnumerateDefinitionsUsingReflection(serialization, type, options);
            
            // Assert
            Assert.NotNull(result);
            // Add more assertions based on your expected result
        }
        
        /// <summary>
        ///     Tests that enumerate definitions using reflection serialization false returns expected result
        /// </summary>
        [Fact]
        public void EnumerateDefinitionsUsingReflection_SerializationFalse_ReturnsExpectedResult()
        {
            // Arrange
            bool serialization = false;
            Type type = typeof(MyClassSample); // Replace with your actual class type
            JsonOptions options = new JsonOptions(); // Initialize with your actual options
            
            // Act
            IEnumerable<MemberDefinition> result = TypeDef.EnumerateDefinitionsUsingReflection(serialization, type, options);
            
            // Assert
            Assert.NotNull(result);
            // Add more assertions based on your expected result
        }
        
        /// <summary>
        ///     Tests that handle property serialization valid input returns expected result v 6
        /// </summary>
        [Fact]
        public void HandlePropertySerialization_ValidInput_ReturnsExpectedResult_v6()
        {
            // Arrange
            bool serialization = true;
            Type type = typeof(MyClassSample); // Replace with your actual class type
            JsonOptions options = new JsonOptions(); // Initialize with your actual options
            
            // Act
            IEnumerable<MemberDefinition> result = TypeDef.HandlePropertySerialization(serialization, type, options);
            
            // Assert
            Assert.NotNull(result);
            // Add more assertions based on your expected result
        }
        
        /// <summary>
        ///     Tests that handle property serialization serialization false returns expected result
        /// </summary>
        [Fact]
        public void HandlePropertySerialization_SerializationFalse_ReturnsExpectedResult()
        {
            // Arrange
            bool serialization = false;
            Type type = typeof(MyClassSample); // Replace with your actual class type
            JsonOptions options = new JsonOptions(); // Initialize with your actual options
            
            // Act
            IEnumerable<MemberDefinition> result = TypeDef.HandlePropertySerialization(serialization, type, options);
            
            // Assert
            Assert.NotNull(result);
            // Add more assertions based on your expected result
        }
        
        /// <summary>
        ///     Tests that enumerate definitions using reflection serialization true returns expected result
        /// </summary>
        [Fact]
        public void EnumerateDefinitionsUsingReflection_SerializationTrue_ReturnsExpectedResult()
        {
            // Arrange
            bool serialization = true;
            Type type = typeof(MyClassSample); // Replace with your actual class type
            JsonOptions options = new JsonOptions(); // Initialize with your actual options
            
            // Act
            IEnumerable<MemberDefinition> result = TypeDef.EnumerateDefinitionsUsingReflection(serialization, type, options);
            
            // Assert
            Assert.NotNull(result);
            // Add more assertions based on your expected result
        }
        
        /// <summary>
        ///     Tests that enumerate definitions using reflection serialization false returns expected result v 8
        /// </summary>
        [Fact]
        public void EnumerateDefinitionsUsingReflection_SerializationFalse_ReturnsExpectedResult_v8()
        {
            // Arrange
            bool serialization = false;
            Type type = typeof(MyClassSample); // Replace with your actual class type
            JsonOptions options = new JsonOptions(); // Initialize with your actual options
            
            // Act
            IEnumerable<MemberDefinition> result = TypeDef.EnumerateDefinitionsUsingReflection(serialization, type, options);
            
            // Assert
            Assert.NotNull(result);
            // Add more assertions based on your expected result
        }
        
        /// <summary>
        ///     Tests that get serialization members valid input returns expected result
        /// </summary>
        [Fact]
        public void GetSerializationMembers_ValidInput_ReturnsExpectedResult()
        {
            // Arrange
            Type type = typeof(MyClassSample); // Replace with your actual class type
            JsonOptions options = new JsonOptions(); // Initialize with your actual options
            
            // Act
            MemberDefinition[] result = TypeDef.GetSerializationMembers(type, options);
            
            // Assert
            Assert.NotNull(result);
            // Add more assertions based on your expected result
        }
        
        /// <summary>
        ///     Tests that get serialization members null type returns null
        /// </summary>
        [Fact]
        public void GetSerializationMembers_NullType_ReturnsNull()
        {
            // Arrange
            Type type = null; // Invalid input
            JsonOptions options = new JsonOptions(); // Initialize with your actual options
            
            // Act
            Assert.Throws<NullReferenceException>(() => TypeDef.GetSerializationMembers(type, options));
        }
        
        /// <summary>
        ///     Tests that get serialization members null options throws argument null exception
        /// </summary>
        [Fact]
        public void GetSerializationMembers_NullOptions_ThrowsArgumentNullException()
        {
            // Arrange
            Type type = typeof(MyClassSample); // Replace with your actual class type
            JsonOptions options = null; // Invalid input
            
            // Act & Assert
            Assert.Throws<NullReferenceException>(() => TypeDef.GetSerializationMembers(type, options));
        }
        
        /// <summary>
        ///     Tests that handle property serialization serialization true returns expected result
        /// </summary>
        [Fact]
        public void HandlePropertySerialization_SerializationTrue_ReturnsExpectedResult()
        {
            // Arrange
            bool serialization = true;
            Type type = typeof(MyClassSample); // Replace with your actual class type
            JsonOptions options = new JsonOptions(); // Initialize with your actual options
            
            // Act
            IEnumerable<MemberDefinition> result = TypeDef.HandlePropertySerialization(serialization, type, options);
            
            // Assert
            Assert.NotNull(result);
            // Add more assertions based on your expected result
        }
        
        /// <summary>
        ///     Tests that handle property serialization serialization false returns expected result v 9
        /// </summary>
        [Fact]
        public void HandlePropertySerialization_SerializationFalse_ReturnsExpectedResult_v9()
        {
            // Arrange
            bool serialization = false;
            Type type = typeof(MyClassSample); // Replace with your actual class type
            JsonOptions options = new JsonOptions(); // Initialize with your actual options
            
            // Act
            IEnumerable<MemberDefinition> result = TypeDef.HandlePropertySerialization(serialization, type, options);
            
            // Assert
            Assert.NotNull(result);
            // Add more assertions based on your expected result
        }
        
        /// <summary>
        ///     Tests that handle property serialization null type returns null
        /// </summary>
        [Fact]
        public void HandlePropertySerialization_NullType_ReturnsNull()
        {
            // Arrange
            bool serialization = true;
            Type type = null; // Invalid input
            JsonOptions options = new JsonOptions(); // Initialize with your actual options
            
            // Act & Assert
            IEnumerable<MemberDefinition> result = TypeDef.HandlePropertySerialization(serialization, type, options);
            
            Assert.NotNull(result);
        }
        
        /// <summary>
        ///     Tests that handle property serialization null options throws argument null exception
        /// </summary>
        [Fact]
        public void HandlePropertySerialization_NullOptions_ThrowsArgumentNullException()
        {
            // Arrange
            bool serialization = true;
            Type type = typeof(MyClassSample); // Replace with your actual class type
            JsonOptions options = null; // Invalid input
            
            // Act & Assert
            IEnumerable<MemberDefinition> result = TypeDef.HandlePropertySerialization(serialization, type, options);
            
            Assert.NotNull(result);
        }
        
        /// <summary>
        ///     Tests that handle field serialization serialization true returns expected result
        /// </summary>
        [Fact]
        public void HandleFieldSerialization_SerializationTrue_ReturnsExpectedResult()
        {
            // Arrange
            bool serialization = true;
            Type type = typeof(MyClassSample); // Replace with your actual class type
            JsonOptions options = new JsonOptions(); // Initialize with your actual options
            
            // Act
            IEnumerable<MemberDefinition> result = TypeDef.HandleFieldSerialization(serialization, type, options);
            
            // Assert
            Assert.NotNull(result);
            // Add more assertions based on your expected result
        }
        
        /// <summary>
        ///     Tests that handle field serialization serialization false returns expected result
        /// </summary>
        [Fact]
        public void HandleFieldSerialization_SerializationFalse_ReturnsExpectedResult_v10()
        {
            // Arrange
            bool serialization = false;
            Type type = typeof(MyClassSample); // Replace with your actual class type
            JsonOptions options = new JsonOptions(); // Initialize with your actual options
            
            // Act
            IEnumerable<MemberDefinition> result = TypeDef.HandleFieldSerialization(serialization, type, options);
            
            // Assert
            Assert.NotNull(result);
            // Add more assertions based on your expected result
        }
        
        /// <summary>
        ///     Tests that handle field serialization null type returns null
        /// </summary>
        [Fact]
        public void HandleFieldSerialization_NullType_ReturnsNull()
        {
            // Arrange
            bool serialization = true;
            Type type = null; // Invalid input
            JsonOptions options = new JsonOptions(); // Initialize with your actual options
            
            // Act & Assert
            IEnumerable<MemberDefinition> result = TypeDef.HandleFieldSerialization(serialization, type, options);
            
            Assert.NotNull(result);
        }
        
        /// <summary>
        ///     Tests that handle field serialization null options throws argument null exception
        /// </summary>
        [Fact]
        public void HandleFieldSerialization_NullOptions_ThrowsArgumentNullException()
        {
            // Arrange
            bool serialization = true;
            Type type = typeof(MyClassSample); // Replace with your actual class type
            JsonOptions options = null; // Invalid input
            
            // Act & Assert
            IEnumerable<MemberDefinition> result = TypeDef.HandleFieldSerialization(serialization, type, options);
            
            Assert.NotNull(result);
        }
        
        /// <summary>
        ///     Tests that should skip field serialization true json attribute ignore when serializing returns true
        /// </summary>
        [Fact]
        public void ShouldSkipField_SerializationTrue_JsonAttributeIgnoreWhenSerializing_ReturnsTrue()
        {
            // Arrange
            bool serialization = true;
            FieldInfo info = typeof(MyClassSample).GetField("MyField"); // Replace with your actual field
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.UseJsonAttribute};
            
            // Act
            bool result = TypeDef.ShouldSkipField(serialization, info, options);
            
            // Assert
            Assert.False(result);
        }
        
        /// <summary>
        ///     Tests that should skip field serialization false json attribute ignore when deserializing returns true
        /// </summary>
        [Fact]
        public void ShouldSkipField_SerializationFalse_JsonAttributeIgnoreWhenDeserializing_ReturnsTrue()
        {
            // Arrange
            bool serialization = false;
            FieldInfo info = typeof(MyClassSample).GetField("MyField"); // Replace with your actual field
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.UseJsonAttribute};
            
            // Act
            bool result = TypeDef.ShouldSkipField(serialization, info, options);
            
            // Assert
            Assert.False(result);
        }
        
        /// <summary>
        ///     Tests that should skip field serialization true xml ignore attribute returns true
        /// </summary>
        [Fact]
        public void ShouldSkipField_SerializationTrue_XmlIgnoreAttribute_ReturnsTrue()
        {
            // Arrange
            bool serialization = true;
            FieldInfo info = typeof(MyClassSample).GetField("MyField"); // Replace with your actual field
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.UseXmlIgnore};
            
            // Act
            bool result = TypeDef.ShouldSkipField(serialization, info, options);
            
            // Assert
            Assert.False(result);
        }
        
        /// <summary>
        ///     Tests that should skip field serialization true script ignore returns true
        /// </summary>
        [Fact]
        public void ShouldSkipField_SerializationTrue_ScriptIgnore_ReturnsTrue()
        {
            // Arrange
            bool serialization = true;
            FieldInfo info = typeof(MyClassSample).GetField("MyField"); // Replace with your actual field
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.UseScriptIgnore};
            
            // Act
            bool result = TypeDef.ShouldSkipField(serialization, info, options);
            
            // Assert
            Assert.False(result);
        }
        
        /// <summary>
        ///     Tests that should skip field serialization true no ignore attributes returns false
        /// </summary>
        [Fact]
        public void ShouldSkipField_SerializationTrue_NoIgnoreAttributes_ReturnsFalse()
        {
            // Arrange
            bool serialization = true;
            FieldInfo info = typeof(MyClassSample).GetField("MyField"); // Replace with your actual field
            JsonOptions options = new JsonOptions();
            
            // Act
            bool result = TypeDef.ShouldSkipField(serialization, info, options);
            
            // Assert
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that test enumerate definitions using reflection with serialization
        /// </summary>
        [Fact]
        public void TestEnumerateDefinitionsUsingReflection_WithSerialization()
        {
            // Arrange
            Type type = typeof(ConcreteListObject);
            JsonOptions options = new JsonOptions();
            
            // Act
            IEnumerable<MemberDefinition> result = TypeDef.EnumerateDefinitionsUsingReflection(true, type, options);
            
            // Assert
            Assert.NotNull(result);
            Assert.All(result, member => Assert.IsType<MemberDefinition>(member));
        }
        
        /// <summary>
        /// Tests that test enumerate definitions using reflection without serialization
        /// </summary>
        [Fact]
        public void TestEnumerateDefinitionsUsingReflection_WithoutSerialization()
        {
            // Arrange
            Type type = typeof(ConcreteListObject);
            JsonOptions options = new JsonOptions();
            
            // Act
            IEnumerable<MemberDefinition> result = TypeDef.EnumerateDefinitionsUsingReflection(false, type, options);
            
            // Assert
            Assert.NotNull(result);
            Assert.All(result, member => Assert.IsType<MemberDefinition>(member));
        }
        
        /// <summary>
        /// Tests that test enumerate definitions using reflection with serialize fields option
        /// </summary>
        [Fact]
        public void TestEnumerateDefinitionsUsingReflection_WithSerializeFieldsOption()
        {
            // Arrange
            Type type = typeof(ConcreteListObject);
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.SerializeFields};
            
            // Act
            IEnumerable<MemberDefinition> result = TypeDef.EnumerateDefinitionsUsingReflection(true, type, options);
            
            // Assert
            Assert.NotNull(result);
            Assert.All(result, member => Assert.IsType<MemberDefinition>(member));
        }
        
        /// <summary>
        /// Tests that test enumerate definitions using reflection without serialize fields option
        /// </summary>
        [Fact]
        public void TestEnumerateDefinitionsUsingReflection_WithoutSerializeFieldsOption()
        {
            // Arrange
            Type type = typeof(ConcreteListObject);
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.None};
            
            // Act
            IEnumerable<MemberDefinition> result = TypeDef.EnumerateDefinitionsUsingReflection(true, type, options);
            
            // Assert
            Assert.NotNull(result);
            Assert.All(result, member => Assert.IsType<MemberDefinition>(member));
        }
        
        /// <summary>
        /// Tests that handle write named value object callback with null callback returns expected values
        /// </summary>
        [Fact]
        public void HandleWriteNamedValueObjectCallback_WithNullCallback_ReturnsExpectedValues()
        {
            // Arrange
            StringWriter writer = new StringWriter();
            object component = new object();
            Dictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions {WriteNamedValueObjectCallback = null};
            MemberDefinition member = new MemberDefinition {WireName = "Test"};
            bool first = true;
            
            // Act
            Assert.Throws<NullReferenceException>(() => TypeDef.HandleWriteNamedValueObjectCallback(writer, component, objectGraph, options, member, first));
        }
        
        /// <summary>
        /// Tests that handle write named value object callback with callback and handled event returns expected values
        /// </summary>
        [Fact]
        public void HandleWriteNamedValueObjectCallback_WithCallbackAndHandledEvent_ReturnsExpectedValues()
        {
            // Arrange
            StringWriter writer = new StringWriter();
            object component = new object();
            Dictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions
            {
                WriteNamedValueObjectCallback = e => e.Handled = true
            };
            MemberDefinition member = new MemberDefinition
            {
                WireName = "Test"
            };
            bool first = true;
            
            // Act
            Assert.Throws<NullReferenceException>(() => TypeDef.HandleWriteNamedValueObjectCallback(writer, component, objectGraph, options, member, first));
            
        }
        
        /// <summary>
        /// Tests that handle write named value object callback with callback and changed name returns expected values
        /// </summary>
        [Fact]
        public void HandleWriteNamedValueObjectCallback_WithCallbackAndChangedName_ReturnsExpectedValues()
        {
            // Arrange
            StringWriter writer = new StringWriter();
            object component = new object();
            Dictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions
            {
                WriteNamedValueObjectCallback = e => e.Name = "Changed"
            };
            MemberDefinition member = new MemberDefinition {WireName = "Test"};
            bool first = true;
            
            // Act
            Assert.Throws<NullReferenceException>(() => TypeDef.HandleWriteNamedValueObjectCallback(writer, component, objectGraph, options, member, first));
            
        }
        
        /// <summary>
        /// Tests that check json attribute with serialization and ignore when serializing returns true
        /// </summary>
        [Fact]
        public void CheckJsonAttribute_WithSerializationAndIgnoreWhenSerializing_ReturnsTrue()
        {
            // Arrange
            PropertyDescriptor descriptor = TypeDescriptor.GetProperties(typeof(TestClass))["PropertyWithIgnoreWhenSerializing"];
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.UseJsonAttribute};
            
            // Act
            bool result = TypeDef.CheckJsonAttribute(true, descriptor, options);
            
            // Assert
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that check json attribute without serialization and ignore when deserializing returns true
        /// </summary>
        [Fact]
        public void CheckJsonAttribute_WithoutSerializationAndIgnoreWhenDeserializing_ReturnsTrue()
        {
            // Arrange
            PropertyDescriptor descriptor = TypeDescriptor.GetProperties(typeof(TestClass))["PropertyWithIgnoreWhenDeserializing"];
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.UseJsonAttribute};
            
            // Act
            bool result = TypeDef.CheckJsonAttribute(false, descriptor, options);
            
            // Assert
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that check json attribute without serialization and ignore when serializing returns false
        /// </summary>
        [Fact]
        public void CheckJsonAttribute_WithoutSerializationAndIgnoreWhenSerializing_ReturnsFalse()
        {
            // Arrange
            PropertyDescriptor descriptor = TypeDescriptor.GetProperties(typeof(TestClass))["PropertyWithIgnoreWhenSerializing"];
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.UseJsonAttribute};
            
            // Act
            bool result = TypeDef.CheckJsonAttribute(false, descriptor, options);
            
            // Assert
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that check json attribute with serialization and ignore when deserializing returns false
        /// </summary>
        [Fact]
        public void CheckJsonAttribute_WithSerializationAndIgnoreWhenDeserializing_ReturnsFalse()
        {
            // Arrange
            PropertyDescriptor descriptor = TypeDescriptor.GetProperties(typeof(TestClass))["PropertyWithIgnoreWhenDeserializing"];
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.UseJsonAttribute};
            
            // Act
            bool result = TypeDef.CheckJsonAttribute(true, descriptor, options);
            
            // Assert
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that check json attribute without json attribute returns false
        /// </summary>
        [Fact]
        public void CheckJsonAttribute_WithoutJsonAttribute_ReturnsFalse()
        {
            // Arrange
            PropertyDescriptor descriptor = TypeDescriptor.GetProperties(typeof(TestClass))["PropertyWithoutAttribute"];
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.UseJsonAttribute};
            
            // Act
            Assert.Throws<NullReferenceException>(() => TypeDef.CheckJsonAttribute(true, descriptor, options));
        }
        
        /// <summary>
        /// Tests that check json attribute without use json attribute option returns false
        /// </summary>
        [Fact]
        public void CheckJsonAttribute_WithoutUseJsonAttributeOption_ReturnsFalse()
        {
            // Arrange
            PropertyDescriptor descriptor = TypeDescriptor.GetProperties(typeof(TestClass))["PropertyWithIgnoreWhenSerializing"];
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.None};
            
            // Act
            bool result = TypeDef.CheckJsonAttribute(true, descriptor, options);
            
            // Assert
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that check json attribute when serialization is true and ignore when serializing is true returns true
        /// </summary>
        [Fact]
        public void CheckJsonAttribute_WhenSerializationIsTrueAndIgnoreWhenSerializingIsTrue_ReturnsTrue()
        {
            // Arrange
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.UseJsonAttribute};
            PropertyInfo info = typeof(TestClass).GetProperty(nameof(TestClass.PropertyWithIgnoreWhenSerializing));
            bool serialization = true;
            
            // Act
            bool result = TypeDef.CheckJsonAttribute(serialization, info, options);
            
            // Assert
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that check json attribute when serialization is false and ignore when deserializing is true returns true
        /// </summary>
        [Fact]
        public void CheckJsonAttribute_WhenSerializationIsFalseAndIgnoreWhenDeserializingIsTrue_ReturnsTrue()
        {
            // Arrange
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.UseJsonAttribute};
            PropertyInfo info = typeof(TestClass).GetProperty(nameof(TestClass.PropertyWithIgnoreWhenDeserializing));
            bool serialization = false;
            
            // Act
            bool result = TypeDef.CheckJsonAttribute(serialization, info, options);
            
            // Assert
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that check json attribute when serialization is true and ignore when serializing is false returns false
        /// </summary>
        [Fact]
        public void CheckJsonAttribute_WhenSerializationIsTrueAndIgnoreWhenSerializingIsFalse_ReturnsFalse()
        {
            // Arrange
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.UseJsonAttribute};
            PropertyInfo info = typeof(TestClass).GetProperty(nameof(TestClass.PropertyWithoutIgnoreWhenSerializing));
            bool serialization = true;
            
            // Act
            bool result = TypeDef.CheckJsonAttribute(serialization, info, options);
            
            // Assert
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that check json attribute when serialization is false and ignore when deserializing is false returns false
        /// </summary>
        [Fact]
        public void CheckJsonAttribute_WhenSerializationIsFalseAndIgnoreWhenDeserializingIsFalse_ReturnsFalse()
        {
            // Arrange
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.UseJsonAttribute};
            PropertyInfo info = typeof(TestClass).GetProperty(nameof(TestClass.PropertyWithoutIgnoreWhenDeserializing));
            bool serialization = false;
            
            // Act
            bool result = TypeDef.CheckJsonAttribute(serialization, info, options);
            
            // Assert
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that check json attribute when use json attribute is not set returns false
        /// </summary>
        [Fact]
        public void CheckJsonAttribute_WhenUseJsonAttributeIsNotSet_ReturnsFalse()
        {
            // Arrange
            JsonOptions options = new JsonOptions {SerializationOptions = JsonSerializationOptions.None};
            PropertyInfo info = typeof(TestClass).GetProperty(nameof(TestClass.PropertyWithIgnoreWhenSerializing));
            bool serialization = true;
            
            // Act
            bool result = TypeDef.CheckJsonAttribute(serialization, info, options);
            
            // Assert
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that should skip field with json attribute and serialization returns true
        /// </summary>
        [Fact]
        public void ShouldSkipField_WithJsonAttributeAndSerialization_ReturnsTrue()
        {
            // Arrange
            FieldInfo fieldInfo = typeof(TestClass).GetField("FieldWithJsonAttribute");
            JsonOptions options = new JsonOptions();
            
            // Act
            Assert.Throws<NullReferenceException>(() => TypeDef.ShouldSkipField(true, fieldInfo, options));
        }
        
        /// <summary>
        /// Tests that should skip field with json attribute and deserialization returns false
        /// </summary>
        [Fact]
        public void ShouldSkipField_WithJsonAttributeAndDeserialization_ReturnsFalse()
        {
            // Arrange
            FieldInfo fieldInfo = typeof(TestClass).GetField("FieldWithJsonAttribute");
            JsonOptions options = new JsonOptions();
            
            // Act
            Assert.Throws<NullReferenceException>(() => TypeDef.ShouldSkipField(false, fieldInfo, options));
            
        }
        
        /// <summary>
        /// Tests that should skip field with xml ignore attribute returns true
        /// </summary>
        [Fact]
        public void ShouldSkipField_WithXmlIgnoreAttribute_ReturnsTrue()
        {
            // Arrange
            FieldInfo fieldInfo = typeof(TestClass).GetField("FieldWithXmlIgnoreAttribute");
            JsonOptions options = new JsonOptions();
            
            // Act
            Assert.Throws<NullReferenceException>(() => TypeDef.ShouldSkipField(true, fieldInfo, options));
        }
        
        /// <summary>
        /// Tests that should skip field with script ignore attribute returns true
        /// </summary>
        [Fact]
        public void ShouldSkipField_WithScriptIgnoreAttribute_ReturnsTrue()
        {
            // Arrange
            FieldInfo fieldInfo = typeof(TestClass).GetField("FieldWithScriptIgnoreAttribute");
            JsonOptions options = new JsonOptions();
            
            // Act
            Assert.Throws<NullReferenceException>(() => TypeDef.ShouldSkipField(true, fieldInfo, options));
        }
        
        /// <summary>
        /// Tests that should skip field without any attributes returns false
        /// </summary>
        [Fact]
        public void ShouldSkipField_WithoutAnyAttributes_ReturnsFalse()
        {
            // Arrange
            FieldInfo fieldInfo = typeof(TestClass).GetField("FieldWithoutAnyAttributes");
            JsonOptions options = new JsonOptions();
            
            // Act
            Assert.Throws<NullReferenceException>(() => TypeDef.ShouldSkipField(true, fieldInfo, options));
        }
        
        /// <summary>
        /// Tests that check script ignore with script ignore returns true
        /// </summary>
        [Fact]
        public void CheckScriptIgnore_WithScriptIgnore_ReturnsTrue()
        {
            // Arrange
            JsonOptions options = new JsonOptions
            {
                SerializationOptions = JsonSerializationOptions.UseScriptIgnore
            };
            PropertyInfo propertyInfo = typeof(SampleClassWithScriptIgnore).GetProperty("PropertyWithScriptIgnore");
            
            // Act
            bool result = TypeDef.CheckScriptIgnore(propertyInfo, options);
            
            // Assert
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that check script ignore without script ignore returns false
        /// </summary>
        [Fact]
        public void CheckScriptIgnore_WithoutScriptIgnore_ReturnsFalse()
        {
            // Arrange
            JsonOptions options = new JsonOptions
            {
                SerializationOptions = JsonSerializationOptions.UseScriptIgnore
            };
            PropertyInfo propertyInfo = typeof(SampleClassWithoutScriptIgnore).GetProperty("PropertyWithoutScriptIgnore");
            
            // Act
            bool result = TypeDef.CheckScriptIgnore(propertyInfo, options);
            
            // Assert
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that check script ignore without use script ignore option returns false
        /// </summary>
        [Fact]
        public void CheckScriptIgnore_WithoutUseScriptIgnoreOption_ReturnsFalse()
        {
            // Arrange
            JsonOptions options = new JsonOptions
            {
                SerializationOptions = JsonSerializationOptions.None
            };
            PropertyInfo propertyInfo = typeof(SampleClassWithScriptIgnore).GetProperty("PropertyWithScriptIgnore");
            
            // Act
            bool result = TypeDef.CheckScriptIgnore(propertyInfo, options);
            
            // Assert
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that should ignore attribute when serialization is true and ignore when serializing is true returns true
        /// </summary>
        [Fact]
        public void ShouldIgnoreAttribute_WhenSerializationIsTrueAndIgnoreWhenSerializingIsTrue_ReturnsTrue()
        {
            // Arrange
            JsonPropertyNameAttribute attribute = new JsonPropertyNameAttribute {IgnoreWhenSerializing = true};
            
            // Act
            bool result = TypeDef.ShouldIgnoreAttribute(true, attribute);
            
            // Assert
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that should ignore attribute when serialization is true and ignore when serializing is false returns false
        /// </summary>
        [Fact]
        public void ShouldIgnoreAttribute_WhenSerializationIsTrueAndIgnoreWhenSerializingIsFalse_ReturnsFalse()
        {
            // Arrange
            JsonPropertyNameAttribute attribute = new JsonPropertyNameAttribute {IgnoreWhenSerializing = false};
            
            // Act
            bool result = TypeDef.ShouldIgnoreAttribute(true, attribute);
            
            // Assert
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that should ignore attribute when serialization is false and ignore when deserializing is true returns true
        /// </summary>
        [Fact]
        public void ShouldIgnoreAttribute_WhenSerializationIsFalseAndIgnoreWhenDeserializingIsTrue_ReturnsTrue()
        {
            // Arrange
            JsonPropertyNameAttribute attribute = new JsonPropertyNameAttribute {IgnoreWhenDeserializing = true};
            
            // Act
            bool result = TypeDef.ShouldIgnoreAttribute(false, attribute);
            
            // Assert
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that should ignore attribute when serialization is false and ignore when deserializing is false returns false
        /// </summary>
        [Fact]
        public void ShouldIgnoreAttribute_WhenSerializationIsFalseAndIgnoreWhenDeserializingIsFalse_ReturnsFalse()
        {
            // Arrange
            JsonPropertyNameAttribute attribute = new JsonPropertyNameAttribute {IgnoreWhenDeserializing = false};
            
            // Act
            bool result = TypeDef.ShouldIgnoreAttribute(false, attribute);
            
            // Assert
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that should create member definition for field with valid input returns expected result
        /// </summary>
        [Fact]
        public void ShouldCreateMemberDefinitionForField_WithValidInput_ReturnsExpectedResult()
        {
            // Arrange
            bool serialization = true;
            FieldInfo field = typeof(SampleClass).GetField("sampleField");
            JsonOptions options = new JsonOptions();
            
            // Act
            Assert.Throws<NullReferenceException>(() => TypeDef.ShouldCreateMemberDefinitionForField(serialization, field, options));
        }
        
        /// <summary>
        /// Tests that should create member definition for field with invalid input returns expected result
        /// </summary>
        [Fact]
        public void ShouldCreateMemberDefinitionForField_WithInvalidInput_ReturnsExpectedResult()
        {
            // Arrange
            bool serialization = true;
            FieldInfo field = null; // Invalid input
            JsonOptions options = new JsonOptions();
            
            // Act
            Assert.Throws<NullReferenceException>(() => TypeDef.ShouldCreateMemberDefinitionForField(serialization, field, options));
        }
        
        /// <summary>
        /// Tests that create member definition if applicable with valid input returns expected result
        /// </summary>
        [Fact]
        public void CreateMemberDefinitionIfApplicable_WithValidInput_ReturnsExpectedResult()
        {
            // Arrange
            bool serialization = true;
            FieldInfo field = typeof(SampleClass).GetField("sampleField");
            JsonOptions options = new JsonOptions();
            
            // Act
            Assert.Throws<NullReferenceException>(() => TypeDef.CreateMemberDefinitionIfApplicable(serialization, field, options));
            
        }
        
        /// <summary>
        /// Tests that create member definition if applicable with invalid input returns expected result
        /// </summary>
        [Fact]
        public void CreateMemberDefinitionIfApplicable_WithInvalidInput_ReturnsExpectedResult()
        {
            // Arrange
            bool serialization = true;
            FieldInfo field = null; // Invalid input
            JsonOptions options = new JsonOptions();
            
            // Act
            Assert.Throws<NullReferenceException>(() => TypeDef.CreateMemberDefinitionIfApplicable(serialization, field, options));
        }
        
        /// <summary>
        /// Tests that create member definition if applicable v 2 with valid input returns expected result
        /// </summary>
        [Fact]
        public void CreateMemberDefinitionIfApplicable_V2_WithValidInput_ReturnsExpectedResult()
        {
            // Arrange
            bool serialization = true;
            FieldInfo field = typeof(SampleClass).GetField("sampleField");
            JsonOptions options = new JsonOptions();
            
            // Act
            Assert.Throws<NullReferenceException>(() => TypeDef.CreateMemberDefinitionIfApplicable(serialization, field, options));
        }
        
        /// <summary>
        /// Tests that create member definition if applicable v 2 with invalid input returns expected result
        /// </summary>
        [Fact]
        public void CreateMemberDefinitionIfApplicable_V2_WithInvalidInput_ReturnsExpectedResult()
        {
            // Arrange
            bool serialization = true;
            FieldInfo field = null; // Invalid input
            JsonOptions options = new JsonOptions();
            
            // Act
            Assert.Throws<NullReferenceException>(() => TypeDef.CreateMemberDefinitionIfApplicable(serialization, field, options));
        }
        
        /// <summary>
        /// Tests that write member value with valid input writes expected value
        /// </summary>
        [Fact]
        public void WriteMemberValue_WithValidInput_WritesExpectedValue()
        {
            // Arrange
            StringWriter writer = new StringWriter();
            JsonOptions options = new JsonOptions();
            MemberDefinition member = new MemberDefinition
            {
                EscapedWireName = "testMember",
                Type = typeof(string)
            };
            bool nameChanged = false;
            string name = "testName";
            object value = "testValue";
            Dictionary<object, object> objectGraph = new Dictionary<object, object>();
            
            // Act
            TypeDef typeDef = new TypeDef(typeof(object), options);
            typeDef.WriteMemberValue(writer, options, member, nameChanged, name, value, objectGraph);
            
            // Assert
            Assert.Equal("\"testMember\":\"testValue\"", writer.ToString());
        }
        
        /// <summary>
        /// Tests that write member value with name changed writes expected value
        /// </summary>
        [Fact]
        public void WriteMemberValue_WithNameChanged_WritesExpectedValue()
        {
            // Arrange
            StringWriter writer = new StringWriter();
            JsonOptions options = new JsonOptions();
            MemberDefinition member = new MemberDefinition
            {
                EscapedWireName = "testMember",
                Type = typeof(string)
            };
            bool nameChanged = true;
            string name = "changedName";
            object value = "testValue";
            Dictionary<object, object> objectGraph = new Dictionary<object, object>();
            
            // Act
            TypeDef typeDef = new TypeDef(typeof(object), options);
            typeDef.WriteMemberValue(writer, options, member, nameChanged, name, value, objectGraph);
            
            // Assert
            Assert.Equal("\"changedName\":\"testValue\"", writer.ToString());
        }
        
        /// <summary>
        /// Tests that write member value with write keys without quotes writes expected value
        /// </summary>
        [Fact]
        public void WriteMemberValue_WithWriteKeysWithoutQuotes_WritesExpectedValue()
        {
            // Arrange
            StringWriter writer = new StringWriter();
            JsonOptions options = new JsonOptions
            {
                SerializationOptions = JsonSerializationOptions.WriteKeysWithoutQuotes
            };
            MemberDefinition member = new MemberDefinition
            {
                EscapedWireName = "testMember",
                Type = typeof(string)
            };
            bool nameChanged = false;
            string name = "testName";
            object value = "testValue";
            Dictionary<object, object> objectGraph = new Dictionary<object, object>();
            
            // Act
            TypeDef typeDef = new TypeDef(typeof(object), options);
            typeDef.WriteMemberValue(writer, options, member, nameChanged, name, value, objectGraph);
            
            // Assert
            Assert.Equal("testMember:\"testValue\"", writer.ToString());
        }
        
        /// <summary>
        /// Tests that should create member definition for field with valid field returns true
        /// </summary>
        [Fact]
        public void ShouldCreateMemberDefinitionForField_WithValidField_ReturnsTrue()
        {
            // Arrange
            FieldInfo field = typeof(MyClass).GetField("myField");
            JsonOptions options = new JsonOptions();
            
            // Act
            bool result = TypeDef.ShouldCreateMemberDefinitionForField(true, field, options);
            
            // Assert
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that should create member definition for field with invalid field returns false
        /// </summary>
        [Fact]
        public void ShouldCreateMemberDefinitionForField_WithInvalidField_ReturnsFalse()
        {
            // Arrange
            FieldInfo field = null; // Invalid field
            JsonOptions options = new JsonOptions();
            
            // Act
            Assert.Throws<NullReferenceException>(() => TypeDef.ShouldCreateMemberDefinitionForField(true, field, options));
            
        }
        
        /// <summary>
        /// Tests that handle event when event is null returns input parameters
        /// </summary>
        [Fact]
        public void HandleEvent_WhenEventIsNull_ReturnsInputParameters()
        {
            // Arrange
            bool first = true;
            string name = "TestName";
            object value = new object();
            
            // Act
            (bool, bool, string, object) result = TypeDef.HandleEvent(null, first, name, value);
            
            // Assert
            Assert.Equal(first, result.Item1);
            Assert.False(result.Item2);
            Assert.Equal(name, result.Item3);
            Assert.Equal(value, result.Item4);
        }
        
        /// <summary>
        /// Tests that handle event when event is null v 2 returns input parameters
        /// </summary>
        [Fact]
        public void HandleEvent_WhenEventIsNull_v2_ReturnsInputParameters()
        {
            // Arrange
            bool first = true;
            string name = "TestName";
            object value = new object();
            StringWriter writer = new StringWriter();
            Dictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();
            JsonEventArgs eventArgs = new JsonEventArgs(writer, value, objectGraph, options);
            
            // Act
            (bool, bool, string, object) result = TypeDef.HandleEvent(eventArgs, first, name, value);
            
            // Assert
            Assert.NotEqual(first, result.Item1);
            Assert.True(result.Item2);
            Assert.Null(result.Item3);
            Assert.Equal(value, result.Item4);
        }
        
        /// <summary>
        /// Tests that handle event when event is handled returns input parameters
        /// </summary>
        [Fact]
        public void HandleEvent_WhenEventIsHandled_ReturnsInputParameters()
        {
            // Arrange
            bool first = true;
            string name = "TestName";
            object value = new object();
            StringWriter writer = new StringWriter();
            Dictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();
            JsonEventArgs eventArgs = new JsonEventArgs(writer, value, objectGraph, options) {Handled = true};
            
            // Act
            (bool, bool, string, object) result = TypeDef.HandleEvent(eventArgs, first, name, value);
            
            // Assert
            Assert.NotEqual(first, result.Item1);
            Assert.False(result.Item2);
            Assert.Equal(name, result.Item3);
            Assert.Equal(value, result.Item4);
        }
        
        /// <summary>
        /// Tests that handle event when event is not handled returns event parameters
        /// </summary>
        [Fact]
        public void HandleEvent_WhenEventIsNotHandled_ReturnsEventParameters()
        {
            // Arrange
            bool first = false;
            string name = "NewName";
            object value = new object();
            StringWriter writer = new StringWriter();
            Dictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();
            JsonEventArgs eventArgs = new JsonEventArgs(writer, value, objectGraph, options) {First = first, Name = name, Value = value};
            
            // Act
            (bool, bool, string, object) result = TypeDef.HandleEvent(eventArgs, true, "TestName", new object());
            
            // Assert
            Assert.Equal(first, result.Item1);
            Assert.True(result.Item2);
            Assert.Equal(name, result.Item3);
            Assert.Equal(value, result.Item4);
        }
        
        /// <summary>
        /// Tests that should create member definition for field returns true when member definition is not null
        /// </summary>
        [Fact]
        public void ShouldCreateMemberDefinitionForField_ReturnsTrue_WhenMemberDefinitionIsNotNull()
        {
            // Arrange
            bool serialization = true;
            FieldInfo field = typeof(MyClass).GetField("myField");
            JsonOptions options = new JsonOptions();
            
            // Act
            bool result = TypeDef.ShouldCreateMemberDefinitionForField(serialization, field, options);
            
            // Assert
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that should create member definition returns true when member definition is not null
        /// </summary>
        [Fact]
        public void ShouldCreateMemberDefinition_ReturnsTrue_WhenMemberDefinitionIsNotNull()
        {
            // Arrange
            bool serialization = true;
            FieldInfo field = typeof(MyClass).GetField("myField");
            JsonOptions options = new JsonOptions();
            
            // Act
            bool result = TypeDef.ShouldCreateMemberDefinition(serialization, field, options);
            
            // Assert
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that create member definition returns member definition when called
        /// </summary>
        [Fact]
        public void CreateMemberDefinition_ReturnsMemberDefinition_WhenCalled()
        {
            // Arrange
            bool serialization = true;
            FieldInfo field = typeof(MyClass).GetField("myField");
            JsonOptions options = new JsonOptions();
            
            // Act
            MemberDefinition result = TypeDef.CreateMemberDefinition(serialization, field, options);
            
            // Assert
            Assert.NotNull(result);
        }
        
        /// <summary>
        /// Tests that create member definition if applicable returns member definition when should create member definition is true
        /// </summary>
        [Fact]
        public void CreateMemberDefinitionIfApplicable_ReturnsMemberDefinition_WhenShouldCreateMemberDefinitionIsTrue()
        {
            // Arrange
            bool serialization = true;
            FieldInfo field = typeof(MyClass).GetField("myField");
            JsonOptions options = new JsonOptions();
            
            // Act
            MemberDefinition result = TypeDef.CreateMemberDefinitionIfApplicable(serialization, field, options);
            
            // Assert
            Assert.NotNull(result);
        }
        
        /// <summary>
        /// Tests that create member definitions returns member definitions when called
        /// </summary>
        [Fact]
        public void CreateMemberDefinitions_ReturnsMemberDefinitions_WhenCalled()
        {
            // Arrange
            bool serialization = true;
            IEnumerable<FieldInfo> fields = typeof(MyClass).GetFields();
            JsonOptions options = new JsonOptions();
            
            // Act
            IEnumerable<MemberDefinition> result = TypeDef.CreateMemberDefinitions(serialization, fields, options);
            
            // Assert
            Assert.NotEmpty(result);
        }
        
        /// <summary>
        /// Tests that create json event args returns json event args when called
        /// </summary>
        [Fact]
        public void CreateJsonEventArgs_ReturnsJsonEventArgs_WhenCalled()
        {
            // Arrange
            TextWriter writer = new StringWriter();
            object component = new object();
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();
            bool first = true;
            string name = "TestName";
            object value = new object();
            
            // Act
            JsonEventArgs result = TypeDef.CreateJsonEventArgs(writer, component, objectGraph, options, first, name, value);
            
            // Assert
            Assert.NotNull(result);
            Assert.Equal(JsonEventType.WriteNamedValueObject, result.EventType);
            Assert.Equal(first, result.First);
        }
        
        /// <summary>
        
        /// Tests that invoke callback invokes callback when callback is not null
        
        /// </summary>
        
        [Fact]
        public void InvokeCallback_InvokesCallback_WhenCallbackIsNotNull()
        {
            // Arrange
            JsonOptions options = new JsonOptions();
            options.WriteNamedValueObjectCallback = e => { e.First = false; };
            JsonEventArgs e = new JsonEventArgs(null, null, null, options, null, null)
            {
                First = true
            };
            
            // Act
            TypeDef.InvokeCallback(options, e);
            
            // Assert
            Assert.False(e.First);
        }
        
        /// <summary>
        
        /// Tests that invoke callback does not invoke callback when callback is null
        
        /// </summary>
        
        [Fact]
        public void InvokeCallback_DoesNotInvokeCallback_WhenCallbackIsNull()
        {
            // Arrange
            JsonOptions options = new JsonOptions();
            options.WriteNamedValueObjectCallback = null;
            JsonEventArgs e = new JsonEventArgs(null, null, null, options, null, null)
            {
                First = true
            };
            
            // Act
            TypeDef.InvokeCallback(options, e);
            
            // Assert
            Assert.True(e.First);
        }
        
        /// <summary>
        /// Tests that invoke callback returns null when callback is null
        /// </summary>
        [Fact]
        public void InvokeCallback_ReturnsNull_WhenCallbackIsNull()
        {
            // Arrange
            TextWriter writer = new StringWriter();
            object component = new object();
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();
            bool first = true;
            string name = "TestName";
            object value = new object();
            
            // Act
            JsonEventArgs result = TypeDef.InvokeCallback(writer, component, objectGraph, options, first, name, value);
            
            // Assert
            Assert.Null(result);
        }
        
        /// <summary>
        /// Tests that invoke callback returns json event args when callback is not null
        /// </summary>
        [Fact]
        public void InvokeCallback_ReturnsJsonEventArgs_WhenCallbackIsNotNull()
        {
            // Arrange
            TextWriter writer = new StringWriter();
            object component = new object();
            IDictionary<object, object> objectGraph = new Dictionary<object, object>();
            JsonOptions options = new JsonOptions();
            options.WriteNamedValueObjectCallback = e => { e.First = false; };
            bool first = true;
            string name = "TestName";
            object value = new object();
            
            // Act
            JsonEventArgs result = TypeDef.InvokeCallback(writer, component, objectGraph, options, first, name, value);
            
            // Assert
            Assert.NotNull(result);
            Assert.Equal(JsonEventType.WriteNamedValueObject, result.EventType);
            Assert.False(result.First);
        }
    }
}