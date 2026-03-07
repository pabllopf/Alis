// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ParallelSafeAttributeTest.cs
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
using System.Reflection;
using Alis.Extension.Thread.Attributes;
using Xunit;

namespace Alis.Extension.Thread.Test.Attributes
{
    /// <summary>
    ///     The test component with default batch size
    /// </summary>
    [ParallelSafe]
    internal struct TestComponentWithDefaultBatchSize
    {
        /// <summary>
        ///     The value
        /// </summary>
        public int Value;
    }

    /// <summary>
    ///     The test component with custom batch size
    /// </summary>
    [ParallelSafe(256)]
    internal struct TestComponentWithCustomBatchSize
    {
        /// <summary>
        ///     The value
        /// </summary>
        public int Value;
    }

    /// <summary>
    ///     The test class with attribute class
    /// </summary>
    [ParallelSafe(64)]
    internal class TestClassWithAttribute
    {
        /// <summary>
        ///     Gets or sets the value of the value
        /// </summary>
        public int Value { get; set; }
    }

    /// <summary>
    ///     The test component without attribute
    /// </summary>
    internal struct TestComponentWithoutAttribute
    {
        /// <summary>
        ///     The value
        /// </summary>
        public int Value;
    }

    /// <summary>
    ///     The parallel safe attribute test class
    /// </summary>
    public class ParallelSafeAttributeTest
    {
        /// <summary>
        ///     Tests that attribute can be instantiated with default constructor
        /// </summary>
        [Fact]
        public void Attribute_CanBeInstantiatedWithDefaultConstructor()
        {
            // Act
            ParallelSafeAttribute attribute = new ParallelSafeAttribute();

            // Assert
            Assert.NotNull(attribute);
            Assert.Equal(128, attribute.MinBatchSize);
        }

        /// <summary>
        ///     Tests that attribute can be instantiated with custom batch size
        /// </summary>
        [Fact]
        public void Attribute_CanBeInstantiatedWithCustomBatchSize()
        {
            // Act
            ParallelSafeAttribute attribute = new ParallelSafeAttribute(256);

            // Assert
            Assert.NotNull(attribute);
            Assert.Equal(256, attribute.MinBatchSize);
        }

        /// <summary>
        ///     Tests that attribute can be applied to struct
        /// </summary>
        [Fact]
        public void Attribute_CanBeAppliedToStruct()
        {
            // Act
            bool hasAttribute = Attribute.IsDefined(typeof(TestComponentWithDefaultBatchSize), typeof(ParallelSafeAttribute));

            // Assert
            Assert.True(hasAttribute);
        }

        /// <summary>
        ///     Tests that attribute can be applied to class
        /// </summary>
        [Fact]
        public void Attribute_CanBeAppliedToClass()
        {
            // Act
            bool hasAttribute = Attribute.IsDefined(typeof(TestClassWithAttribute), typeof(ParallelSafeAttribute));

            // Assert
            Assert.True(hasAttribute);
        }

        /// <summary>
        ///     Tests that attribute stores default min batch size
        /// </summary>
        [Fact]
        public void Attribute_StoresDefaultMinBatchSize()
        {
            // Arrange
            Type type = typeof(TestComponentWithDefaultBatchSize);

            // Act
            ParallelSafeAttribute attribute = (ParallelSafeAttribute) Attribute.GetCustomAttribute(type, typeof(ParallelSafeAttribute));

            // Assert
            Assert.NotNull(attribute);
            Assert.Equal(128, attribute.MinBatchSize);
        }

        /// <summary>
        ///     Tests that attribute stores custom min batch size
        /// </summary>
        [Fact]
        public void Attribute_StoresCustomMinBatchSize()
        {
            // Arrange
            Type type = typeof(TestComponentWithCustomBatchSize);

            // Act
            ParallelSafeAttribute attribute = (ParallelSafeAttribute) Attribute.GetCustomAttribute(type, typeof(ParallelSafeAttribute));

            // Assert
            Assert.NotNull(attribute);
            Assert.Equal(256, attribute.MinBatchSize);
        }

        /// <summary>
        ///     Tests that component without attribute returns null
        /// </summary>
        [Fact]
        public void Component_WithoutAttribute_ReturnsNull()
        {
            // Arrange
            Type type = typeof(TestComponentWithoutAttribute);

            // Act
            ParallelSafeAttribute attribute = (ParallelSafeAttribute) Attribute.GetCustomAttribute(type, typeof(ParallelSafeAttribute));

            // Assert
            Assert.Null(attribute);
        }

        /// <summary>
        ///     Tests that attribute usage allows struct and class
        /// </summary>
        [Fact]
        public void AttributeUsage_AllowsStructAndClass()
        {
            // Arrange
            Type attributeType = typeof(ParallelSafeAttribute);

            // Act
            AttributeUsageAttribute usage = (AttributeUsageAttribute) Attribute.GetCustomAttribute(attributeType, typeof(AttributeUsageAttribute));

            // Assert
            Assert.NotNull(usage);
            Assert.True((usage.ValidOn & AttributeTargets.Struct) != 0);
            Assert.True((usage.ValidOn & AttributeTargets.Class) != 0);
        }

        /// <summary>
        ///     Tests that attribute is not inherited
        /// </summary>
        [Fact]
        public void Attribute_IsInherited()
        {
            // Arrange
            Type attributeType = typeof(ParallelSafeAttribute);

            // Act
            AttributeUsageAttribute usage = (AttributeUsageAttribute) Attribute.GetCustomAttribute(attributeType, typeof(AttributeUsageAttribute));

            // Assert
            Assert.NotNull(usage);
            Assert.True(usage.Inherited);
        }

        /// <summary>
        ///     Tests that attribute does not allow multiple
        /// </summary>
        [Fact]
        public void Attribute_DoesNotAllowMultiple()
        {
            // Arrange
            Type attributeType = typeof(ParallelSafeAttribute);

            // Act
            AttributeUsageAttribute usage = (AttributeUsageAttribute) Attribute.GetCustomAttribute(attributeType, typeof(AttributeUsageAttribute));

            // Assert
            Assert.NotNull(usage);
            Assert.False(usage.AllowMultiple);
        }

        /// <summary>
        ///     Tests that min batch size property is read only
        /// </summary>
        [Fact]
        public void MinBatchSize_IsReadOnly()
        {
            // Arrange
            ParallelSafeAttribute attribute = new ParallelSafeAttribute(512);

            // Act
            int batchSize = attribute.MinBatchSize;

            // Assert
            Assert.Equal(512, batchSize);

            // Verify property is read-only by checking if setter exists
            PropertyInfo property = typeof(ParallelSafeAttribute).GetProperty(nameof(ParallelSafeAttribute.MinBatchSize));
            Assert.NotNull(property);
            Assert.Null(property.SetMethod);
        }

        /// <summary>
        ///     Tests that attribute can store zero batch size
        /// </summary>
        [Fact]
        public void Attribute_CanStoreZeroBatchSize()
        {
            // Act
            ParallelSafeAttribute attribute = new ParallelSafeAttribute(0);

            // Assert
            Assert.Equal(0, attribute.MinBatchSize);
        }

        /// <summary>
        ///     Tests that attribute can store negative batch size
        /// </summary>
        [Fact]
        public void Attribute_CanStoreNegativeBatchSize()
        {
            // Act
            ParallelSafeAttribute attribute = new ParallelSafeAttribute(-1);

            // Assert
            Assert.Equal(-1, attribute.MinBatchSize);
        }

        /// <summary>
        ///     Tests that attribute can store maximum integer batch size
        /// </summary>
        [Fact]
        public void Attribute_CanStoreMaxIntegerBatchSize()
        {
            // Act
            ParallelSafeAttribute attribute = new ParallelSafeAttribute(int.MaxValue);

            // Assert
            Assert.Equal(int.MaxValue, attribute.MinBatchSize);
        }

        /// <summary>
        ///     Tests that is defined works correctly
        /// </summary>
        [Fact]
        public void IsDefined_WorksCorrectly()
        {
            // Act
            bool withAttribute = Attribute.IsDefined(typeof(TestComponentWithDefaultBatchSize), typeof(ParallelSafeAttribute));
            bool withoutAttribute = Attribute.IsDefined(typeof(TestComponentWithoutAttribute), typeof(ParallelSafeAttribute));

            // Assert
            Assert.True(withAttribute);
            Assert.False(withoutAttribute);
        }

        /// <summary>
        ///     Tests that get custom attributes returns correct attribute
        /// </summary>
        [Fact]
        public void GetCustomAttributes_ReturnsCorrectAttribute()
        {
            // Arrange
            Type type = typeof(TestClassWithAttribute);

            // Act
            object[] attributes = type.GetCustomAttributes(typeof(ParallelSafeAttribute), false);

            // Assert
            Assert.Single(attributes);
            Assert.IsType<ParallelSafeAttribute>(attributes[0]);
            ParallelSafeAttribute attr = (ParallelSafeAttribute) attributes[0];
            Assert.Equal(64, attr.MinBatchSize);
        }

        /// <summary>
        ///     Tests that multiple types can have different batch sizes
        /// </summary>
        [Fact]
        public void MultipleTypes_CanHaveDifferentBatchSizes()
        {
            // Arrange
            Type type1 = typeof(TestComponentWithDefaultBatchSize);
            Type type2 = typeof(TestComponentWithCustomBatchSize);
            Type type3 = typeof(TestClassWithAttribute);

            // Act
            ParallelSafeAttribute attr1 = (ParallelSafeAttribute) Attribute.GetCustomAttribute(type1, typeof(ParallelSafeAttribute));
            ParallelSafeAttribute attr2 = (ParallelSafeAttribute) Attribute.GetCustomAttribute(type2, typeof(ParallelSafeAttribute));
            ParallelSafeAttribute attr3 = (ParallelSafeAttribute) Attribute.GetCustomAttribute(type3, typeof(ParallelSafeAttribute));

            // Assert
            Assert.Equal(128, attr1.MinBatchSize);
            Assert.Equal(256, attr2.MinBatchSize);
            Assert.Equal(64, attr3.MinBatchSize);
        }
    }
}