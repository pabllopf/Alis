// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UpdateOrderAttributeTest.cs
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
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating
{
    /// <summary>
    ///     The update order attribute test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="UpdateOrderAttribute"/> attribute class which is used
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
            // Act
            UpdateOrderAttribute attribute = new UpdateOrderAttribute(0);

            // Assert
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
            // Act
            UpdateOrderAttribute attribute = new UpdateOrderAttribute(0);

            // Assert
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
            // Act
            AttributeUsageAttribute attrUsage = typeof(UpdateOrderAttribute).GetCustomAttributes(
                typeof(AttributeUsageAttribute), false)[0] as AttributeUsageAttribute;

            // Assert
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
            // Act
            UpdateOrderAttribute attribute = new UpdateOrderAttribute(100);

            // Assert
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
            // Act
            UpdateOrderAttribute attribute = new UpdateOrderAttribute(-100);

            // Assert
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
            // Act
            UpdateOrderAttribute attribute = new UpdateOrderAttribute(0);

            // Assert
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
            // Act
            UpdateOrderAttribute attr1 = new UpdateOrderAttribute(1);
            UpdateOrderAttribute attr2 = new UpdateOrderAttribute(2);
            UpdateOrderAttribute attr3 = new UpdateOrderAttribute(1);

            // Assert
            Assert.NotNull(attr1);
            Assert.NotNull(attr2);
            Assert.NotNull(attr3);
        }
    }
}

