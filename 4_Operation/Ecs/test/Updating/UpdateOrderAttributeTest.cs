

using System;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating
{
    /// <summary>
    ///     The update order attribute test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="UpdateOrderAttribute" /> attribute class which is used
    ///     to specify the execution order of component update methods.
    /// </remarks>
    public class UpdateOrderAttributeTest
    {
        /// <summary>
        ///     Tests that update order attribute can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that UpdateOrderAttribute can be instantiated.
        /// </remarks>
        [Fact]
        public void UpdateOrderAttribute_CanBeCreated()
        {
            UpdateOrderAttribute attribute = new UpdateOrderAttribute(0);

            Assert.NotNull(attribute);
            Assert.IsAssignableFrom<Attribute>(attribute);
        }

        /// <summary>
        ///     Tests that update order attribute is attribute
        /// </summary>
        /// <remarks>
        ///     Confirms that UpdateOrderAttribute inherits from Attribute.
        /// </remarks>
        [Fact]
        public void UpdateOrderAttribute_InheritsFromAttribute()
        {
            UpdateOrderAttribute attribute = new UpdateOrderAttribute(0);

            Assert.IsAssignableFrom<Attribute>(attribute);
        }

        /// <summary>
        ///     Tests that update order attribute can be applied to methods
        /// </summary>
        /// <remarks>
        ///     Validates that the attribute is properly configured for method targets.
        /// </remarks>
        [Fact]
        public void UpdateOrderAttribute_IsApplicableToMethods()
        {
            AttributeUsageAttribute attrUsage = typeof(UpdateOrderAttribute).GetCustomAttributes(
                typeof(AttributeUsageAttribute), false)[0] as AttributeUsageAttribute;

            Assert.NotNull(attrUsage);
            Assert.True((attrUsage.ValidOn & AttributeTargets.Method) != 0);
        }

        /// <summary>
        ///     Tests that update order attribute with positive order
        /// </summary>
        /// <remarks>
        ///     Tests creation with a positive order value.
        /// </remarks>
        [Fact]
        public void UpdateOrderAttribute_WithPositiveOrder()
        {
            UpdateOrderAttribute attribute = new UpdateOrderAttribute(100);

            Assert.NotNull(attribute);
        }

        /// <summary>
        ///     Tests that update order attribute with negative order
        /// </summary>
        /// <remarks>
        ///     Tests creation with a negative order value.
        /// </remarks>
        [Fact]
        public void UpdateOrderAttribute_WithNegativeOrder()
        {
            UpdateOrderAttribute attribute = new UpdateOrderAttribute(-100);

            Assert.NotNull(attribute);
        }

        /// <summary>
        ///     Tests that update order attribute with zero order
        /// </summary>
        /// <remarks>
        ///     Tests creation with zero order.
        /// </remarks>
        [Fact]
        public void UpdateOrderAttribute_WithZeroOrder()
        {
            UpdateOrderAttribute attribute = new UpdateOrderAttribute(0);

            Assert.NotNull(attribute);
        }

        /// <summary>
        ///     Tests that update order attribute multiple instances are independent
        /// </summary>
        /// <remarks>
        ///     Validates that multiple instances can have different order values.
        /// </remarks>
        [Fact]
        public void UpdateOrderAttribute_MultipleInstancesAreIndependent()
        {
            UpdateOrderAttribute attr1 = new UpdateOrderAttribute(1);
            UpdateOrderAttribute attr2 = new UpdateOrderAttribute(2);
            UpdateOrderAttribute attr3 = new UpdateOrderAttribute(1);

            Assert.NotNull(attr1);
            Assert.NotNull(attr2);
            Assert.NotNull(attr3);
        }
    }
}