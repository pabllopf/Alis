

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
            ParallelSafeAttribute attribute = new ParallelSafeAttribute();

            Assert.NotNull(attribute);
            Assert.Equal(128, attribute.MinBatchSize);
        }

        /// <summary>
        ///     Tests that attribute can be instantiated with custom batch size
        /// </summary>
        [Fact]
        public void Attribute_CanBeInstantiatedWithCustomBatchSize()
        {
            ParallelSafeAttribute attribute = new ParallelSafeAttribute(256);

            Assert.NotNull(attribute);
            Assert.Equal(256, attribute.MinBatchSize);
        }

        /// <summary>
        ///     Tests that attribute can be applied to struct
        /// </summary>
        [Fact]
        public void Attribute_CanBeAppliedToStruct()
        {
            bool hasAttribute = Attribute.IsDefined(typeof(TestComponentWithDefaultBatchSize), typeof(ParallelSafeAttribute));

            Assert.True(hasAttribute);
        }

        /// <summary>
        ///     Tests that attribute can be applied to class
        /// </summary>
        [Fact]
        public void Attribute_CanBeAppliedToClass()
        {
            bool hasAttribute = Attribute.IsDefined(typeof(TestClassWithAttribute), typeof(ParallelSafeAttribute));

            Assert.True(hasAttribute);
        }

        /// <summary>
        ///     Tests that attribute stores default min batch size
        /// </summary>
        [Fact]
        public void Attribute_StoresDefaultMinBatchSize()
        {
            Type type = typeof(TestComponentWithDefaultBatchSize);

            ParallelSafeAttribute attribute = (ParallelSafeAttribute) Attribute.GetCustomAttribute(type, typeof(ParallelSafeAttribute));

            Assert.NotNull(attribute);
            Assert.Equal(128, attribute.MinBatchSize);
        }

        /// <summary>
        ///     Tests that attribute stores custom min batch size
        /// </summary>
        [Fact]
        public void Attribute_StoresCustomMinBatchSize()
        {
            Type type = typeof(TestComponentWithCustomBatchSize);

            ParallelSafeAttribute attribute = (ParallelSafeAttribute) Attribute.GetCustomAttribute(type, typeof(ParallelSafeAttribute));

            Assert.NotNull(attribute);
            Assert.Equal(256, attribute.MinBatchSize);
        }

        /// <summary>
        ///     Tests that component without attribute returns null
        /// </summary>
        [Fact]
        public void Component_WithoutAttribute_ReturnsNull()
        {
            Type type = typeof(TestComponentWithoutAttribute);

            ParallelSafeAttribute attribute = (ParallelSafeAttribute) Attribute.GetCustomAttribute(type, typeof(ParallelSafeAttribute));

            Assert.Null(attribute);
        }

        /// <summary>
        ///     Tests that attribute usage allows struct and class
        /// </summary>
        [Fact]
        public void AttributeUsage_AllowsStructAndClass()
        {
            Type attributeType = typeof(ParallelSafeAttribute);

            AttributeUsageAttribute usage = (AttributeUsageAttribute) Attribute.GetCustomAttribute(attributeType, typeof(AttributeUsageAttribute));

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
            Type attributeType = typeof(ParallelSafeAttribute);

            AttributeUsageAttribute usage = (AttributeUsageAttribute) Attribute.GetCustomAttribute(attributeType, typeof(AttributeUsageAttribute));

            Assert.NotNull(usage);
            Assert.True(usage.Inherited);
        }

        /// <summary>
        ///     Tests that attribute does not allow multiple
        /// </summary>
        [Fact]
        public void Attribute_DoesNotAllowMultiple()
        {
            Type attributeType = typeof(ParallelSafeAttribute);

            AttributeUsageAttribute usage = (AttributeUsageAttribute) Attribute.GetCustomAttribute(attributeType, typeof(AttributeUsageAttribute));

            Assert.NotNull(usage);
            Assert.False(usage.AllowMultiple);
        }

        /// <summary>
        ///     Tests that min batch size property is read only
        /// </summary>
        [Fact]
        public void MinBatchSize_IsReadOnly()
        {
            ParallelSafeAttribute attribute = new ParallelSafeAttribute(512);

            int batchSize = attribute.MinBatchSize;

            Assert.Equal(512, batchSize);

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
            ParallelSafeAttribute attribute = new ParallelSafeAttribute(0);

            Assert.Equal(0, attribute.MinBatchSize);
        }

        /// <summary>
        ///     Tests that attribute can store negative batch size
        /// </summary>
        [Fact]
        public void Attribute_CanStoreNegativeBatchSize()
        {
            ParallelSafeAttribute attribute = new ParallelSafeAttribute(-1);

            Assert.Equal(-1, attribute.MinBatchSize);
        }

        /// <summary>
        ///     Tests that attribute can store maximum integer batch size
        /// </summary>
        [Fact]
        public void Attribute_CanStoreMaxIntegerBatchSize()
        {
            ParallelSafeAttribute attribute = new ParallelSafeAttribute(int.MaxValue);

            Assert.Equal(int.MaxValue, attribute.MinBatchSize);
        }

        /// <summary>
        ///     Tests that is defined works correctly
        /// </summary>
        [Fact]
        public void IsDefined_WorksCorrectly()
        {
            bool withAttribute = Attribute.IsDefined(typeof(TestComponentWithDefaultBatchSize), typeof(ParallelSafeAttribute));
            bool withoutAttribute = Attribute.IsDefined(typeof(TestComponentWithoutAttribute), typeof(ParallelSafeAttribute));

            Assert.True(withAttribute);
            Assert.False(withoutAttribute);
        }

        /// <summary>
        ///     Tests that get custom attributes returns correct attribute
        /// </summary>
        [Fact]
        public void GetCustomAttributes_ReturnsCorrectAttribute()
        {
            Type type = typeof(TestClassWithAttribute);

            object[] attributes = type.GetCustomAttributes(typeof(ParallelSafeAttribute), false);

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
            Type type1 = typeof(TestComponentWithDefaultBatchSize);
            Type type2 = typeof(TestComponentWithCustomBatchSize);
            Type type3 = typeof(TestClassWithAttribute);

            ParallelSafeAttribute attr1 = (ParallelSafeAttribute) Attribute.GetCustomAttribute(type1, typeof(ParallelSafeAttribute));
            ParallelSafeAttribute attr2 = (ParallelSafeAttribute) Attribute.GetCustomAttribute(type2, typeof(ParallelSafeAttribute));
            ParallelSafeAttribute attr3 = (ParallelSafeAttribute) Attribute.GetCustomAttribute(type3, typeof(ParallelSafeAttribute));

            Assert.Equal(128, attr1.MinBatchSize);
            Assert.Equal(256, attr2.MinBatchSize);
            Assert.Equal(64, attr3.MinBatchSize);
        }
    }
}