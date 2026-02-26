// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: JsonNativePropertyNameAttributeTest.cs
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
using System.Reflection;
using Alis.Core.Aspect.Data.Json;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json
{
    /// <summary>
    ///     Test suite for the JsonNativePropertyNameAttribute class
    /// </summary>
    public class JsonNativePropertyNameAttributeTest
    {
        /// <summary>
        ///     Tests that the attribute can be created with a simple name
        /// </summary>
        [Fact]
        public void Constructor_WithSimpleName_CreatesAttributeSuccessfully()
        {
            // Arrange
            const string name = "customPropertyName";

            // Act
            JsonNativePropertyNameAttribute attribute = new JsonNativePropertyNameAttribute(name);

            // Assert
            Assert.NotNull(attribute);
            Assert.Equal(name, attribute.Name);
        }

        /// <summary>
        ///     Tests that the attribute can be created with an empty string
        /// </summary>
        [Fact]
        public void Constructor_WithEmptyString_CreatesAttributeSuccessfully()
        {
            // Arrange
            const string name = "";

            // Act
            JsonNativePropertyNameAttribute attribute = new JsonNativePropertyNameAttribute(name);

            // Assert
            Assert.NotNull(attribute);
            Assert.Equal(name, attribute.Name);
        }

        /// <summary>
        ///     Tests that the attribute can be created with special characters
        /// </summary>
        [Fact]
        public void Constructor_WithSpecialCharacters_CreatesAttributeSuccessfully()
        {
            // Arrange
            const string name = "custom-property_name.with.special@chars";

            // Act
            JsonNativePropertyNameAttribute attribute = new JsonNativePropertyNameAttribute(name);

            // Assert
            Assert.NotNull(attribute);
            Assert.Equal(name, attribute.Name);
        }

        /// <summary>
        ///     Tests that the attribute can be created with spaces
        /// </summary>
        [Fact]
        public void Constructor_WithSpaces_CreatesAttributeSuccessfully()
        {
            // Arrange
            const string name = "property name with spaces";

            // Act
            JsonNativePropertyNameAttribute attribute = new JsonNativePropertyNameAttribute(name);

            // Assert
            Assert.NotNull(attribute);
            Assert.Equal(name, attribute.Name);
        }

        /// <summary>
        ///     Tests that the attribute can be created with null name
        /// </summary>
        [Fact]
        public void Constructor_WithNullName_CreatesAttributeSuccessfully()
        {
            // Act
            JsonNativePropertyNameAttribute attribute = new JsonNativePropertyNameAttribute(null);

            // Assert
            Assert.NotNull(attribute);
            Assert.Null(attribute.Name);
        }

        /// <summary>
        ///     Tests that the attribute Name property is read-only
        /// </summary>
        [Fact]
        public void Name_Property_IsReadOnly()
        {
            // Act & Assert
            PropertyInfo propertyInfo = typeof(JsonNativePropertyNameAttribute).GetProperty("Name", 
                BindingFlags.Public | BindingFlags.Instance);
            
            Assert.NotNull(propertyInfo);
            Assert.NotNull(propertyInfo.GetGetMethod());
            Assert.Null(propertyInfo.GetSetMethod());
        }

        /// <summary>
        ///     Tests that the attribute can be applied to a property
        /// </summary>
        [Fact]
        public void Attribute_CanBeAppliedToProperty()
        {
            // Arrange & Act
            PropertyInfo propertyInfo = typeof(TestClassWithAttribute).GetProperty(nameof(TestClassWithAttribute.CustomNameProperty));

            // Assert
            Assert.NotNull(propertyInfo);
            JsonNativePropertyNameAttribute attribute = propertyInfo.GetCustomAttribute<JsonNativePropertyNameAttribute>();
            Assert.NotNull(attribute);
            Assert.Equal("customJsonName", attribute.Name);
        }

        /// <summary>
        ///     Tests that the attribute is sealed and cannot be inherited
        /// </summary>
        [Fact]
        public void Attribute_IsSealed()
        {
            // Act
            Type attributeType = typeof(JsonNativePropertyNameAttribute);

            // Assert
            Assert.True(attributeType.IsSealed);
        }

        /// <summary>
        ///     Tests that the attribute targets only properties
        /// </summary>
        [Fact]
        public void Attribute_TargetsPropertiesOnly()
        {
            // Arrange
            Type attributeType = typeof(JsonNativePropertyNameAttribute);
            AttributeUsageAttribute attributeUsageAttr = attributeType.GetCustomAttribute<AttributeUsageAttribute>();

            // Assert
            Assert.NotNull(attributeUsageAttr);
            Assert.Equal(AttributeTargets.Property, attributeUsageAttr.ValidOn);
        }

        /// <summary>
        ///     Tests that the attribute can store and retrieve long names
        /// </summary>
        [Fact]
        public void Constructor_WithLongName_StoresAndRetrievesCorrectly()
        {
            // Arrange
            const string longName = "thisIsAVeryLongPropertyNameThatMightBeUsedInJsonSerializationWithManyCharactersAndNumbers123456789";

            // Act
            JsonNativePropertyNameAttribute attribute = new JsonNativePropertyNameAttribute(longName);

            // Assert
            Assert.Equal(longName, attribute.Name);
        }

        /// <summary>
        ///     Tests that the attribute can store names with unicode characters
        /// </summary>
        [Fact]
        public void Constructor_WithUnicodeCharacters_StoresAndRetrievesCorrectly()
        {
            // Arrange
            const string unicodeName = "属性名字مجموعةنام";

            // Act
            JsonNativePropertyNameAttribute attribute = new JsonNativePropertyNameAttribute(unicodeName);

            // Assert
            Assert.Equal(unicodeName, attribute.Name);
        }

        /// <summary>
        ///     Tests that multiple attributes can be applied to different properties
        /// </summary>
        [Fact]
        public void Attribute_CanBeAppliedToMultipleProperties()
        {
            // Arrange & Act
            Type classType = typeof(TestClassWithMultipleAttributes);
            PropertyInfo property1 = classType.GetProperty(nameof(TestClassWithMultipleAttributes.Property1));
            PropertyInfo property2 = classType.GetProperty(nameof(TestClassWithMultipleAttributes.Property2));
            PropertyInfo property3 = classType.GetProperty(nameof(TestClassWithMultipleAttributes.Property3));

            // Assert
            Assert.NotNull(property1);
            Assert.NotNull(property2);
            Assert.NotNull(property3);

            JsonNativePropertyNameAttribute attr1 = property1.GetCustomAttribute<JsonNativePropertyNameAttribute>();
            JsonNativePropertyNameAttribute attr2 = property2.GetCustomAttribute<JsonNativePropertyNameAttribute>();
            JsonNativePropertyNameAttribute attr3 = property3.GetCustomAttribute<JsonNativePropertyNameAttribute>();

            Assert.NotNull(attr1);
            Assert.NotNull(attr2);
            Assert.NotNull(attr3);

            Assert.Equal("firstName", attr1.Name);
            Assert.Equal("lastName", attr2.Name);
            Assert.Equal("emailAddress", attr3.Name);
        }

        /// <summary>
        ///     Tests that the attribute inherits from System.Attribute
        /// </summary>
        [Fact]
        public void Attribute_InheritsFromSystemAttribute()
        {
            // Act
            Type attributeType = typeof(JsonNativePropertyNameAttribute);

            // Assert
            Assert.True(attributeType.IsSubclassOf(typeof(Attribute)));
        }

        /// <summary>
        ///     Tests that two attributes with the same name are equal in value
        /// </summary>
        [Fact]
        public void Constructor_WithSameName_BothInstancesHaveSameValue()
        {
            // Arrange
            const string name = "sameName";
            JsonNativePropertyNameAttribute attribute1 = new JsonNativePropertyNameAttribute(name);
            JsonNativePropertyNameAttribute attribute2 = new JsonNativePropertyNameAttribute(name);

            // Act & Assert
            Assert.Equal(attribute1.Name, attribute2.Name);
        }

        /// <summary>
        ///     Tests that the attribute Name property preserves case sensitivity
        /// </summary>
        [Fact]
        public void Name_PreservesCaseSensitivity()
        {
            // Arrange
            const string lowerCaseName = "propertyname";
            const string upperCaseName = "PropertyName";
            const string mixedCaseName = "propertyName";

            // Act
            JsonNativePropertyNameAttribute attr1 = new JsonNativePropertyNameAttribute(lowerCaseName);
            JsonNativePropertyNameAttribute attr2 = new JsonNativePropertyNameAttribute(upperCaseName);
            JsonNativePropertyNameAttribute attr3 = new JsonNativePropertyNameAttribute(mixedCaseName);

            // Assert
            Assert.Equal(lowerCaseName, attr1.Name);
            Assert.Equal(upperCaseName, attr2.Name);
            Assert.Equal(mixedCaseName, attr3.Name);
            Assert.NotEqual(attr1.Name, attr2.Name);
            Assert.NotEqual(attr2.Name, attr3.Name);
        }

        /// <summary>
        ///     Test class with attribute applied
        /// </summary>
        private class TestClassWithAttribute
        {
            /// <summary>
            /// Gets or sets the value of the custom name property
            /// </summary>
            [JsonNativePropertyName("customJsonName")]
            public string CustomNameProperty { get; set; }
        }

        /// <summary>
        ///     Test class with multiple attributes
        /// </summary>
        private class TestClassWithMultipleAttributes
        {
            /// <summary>
            /// Gets or sets the value of the property 1
            /// </summary>
            [JsonNativePropertyName("firstName")]
            public string Property1 { get; set; }

            /// <summary>
            /// Gets or sets the value of the property 2
            /// </summary>
            [JsonNativePropertyName("lastName")]
            public string Property2 { get; set; }

            /// <summary>
            /// Gets or sets the value of the property 3
            /// </summary>
            [JsonNativePropertyName("emailAddress")]
            public string Property3 { get; set; }
        }
    }
}


