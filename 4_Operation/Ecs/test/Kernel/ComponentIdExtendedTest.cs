// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentIdExtendedTest.cs
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

using Alis.Core.Ecs.Kernel;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     The component id extended test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="ComponentId"/> struct which represents
    ///     a lightweight identifier for component types in the ECS system.
    ///     This is an extended test suite with more comprehensive coverage.
    /// </remarks>
    public class ComponentIdExtendedTest
    {
        /// <summary>
        ///     Tests that component id can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that ComponentId can be instantiated with a raw index.
        /// </remarks>
        [Fact]
        public void ComponentId_CanBeCreated()
        {
            // Act
            ComponentId componentId = new ComponentId(0);

            // Assert
            Assert.NotNull(componentId);
        }

        /// <summary>
        ///     Tests that component id raw index is preserved
        /// </summary>
        /// <remarks>
        ///     Validates that the RawIndex field is correctly stored.
        /// </remarks>
        [Fact]
        public void ComponentId_RawIndexIsPreserved()
        {
            // Act
            ComponentId componentId = new ComponentId(42);

            // Assert
            Assert.Equal((ushort)42, componentId.RawIndex);
        }

        /// <summary>
        ///     Tests that component id with zero index
        /// </summary>
        /// <remarks>
        ///     Tests creation with zero index.
        /// </remarks>
        [Fact]
        public void ComponentId_WithZeroIndex()
        {
            // Act
            ComponentId componentId = new ComponentId(0);

            // Assert
            Assert.Equal((ushort)0, componentId.RawIndex);
        }

        /// <summary>
        ///     Tests that component id with max index
        /// </summary>
        /// <remarks>
        ///     Tests creation with maximum ushort index.
        /// </remarks>
        [Fact]
        public void ComponentId_WithMaxIndex()
        {
            // Act
            ComponentId componentId = new ComponentId(ushort.MaxValue);

            // Assert
            Assert.Equal(ushort.MaxValue, componentId.RawIndex);
        }

        /// <summary>
        ///     Tests that component id equals with same index
        /// </summary>
        /// <remarks>
        ///     Tests equality comparison with same index.
        /// </remarks>
        [Fact]
        public void ComponentId_EqualsWithSameIndex()
        {
            // Arrange
            ComponentId componentId1 = new ComponentId(5);
            ComponentId componentId2 = new ComponentId(5);

            // Assert
            Assert.True(componentId1.Equals(componentId2));
            Assert.Equal(componentId1, componentId2);
        }

        /// <summary>
        ///     Tests that component id not equals with different index
        /// </summary>
        /// <remarks>
        ///     Tests inequality comparison with different indices.
        /// </remarks>
        [Fact]
        public void ComponentId_NotEqualsWithDifferentIndex()
        {
            // Arrange
            ComponentId componentId1 = new ComponentId(1);
            ComponentId componentId2 = new ComponentId(2);

            // Assert
            Assert.False(componentId1.Equals(componentId2));
            Assert.NotEqual(componentId1, componentId2);
        }

        /// <summary>
        ///     Tests that component id hash code equals with same index
        /// </summary>
        /// <remarks>
        ///     Validates that hash codes are equal for same indices.
        /// </remarks>
        [Fact]
        public void ComponentId_HashCodeEqualsWithSameIndex()
        {
            // Arrange
            ComponentId componentId1 = new ComponentId(10);
            ComponentId componentId2 = new ComponentId(10);

            // Assert
            Assert.Equal(componentId1.GetHashCode(), componentId2.GetHashCode());
        }

        /// <summary>
        ///     Tests that component id equality operator
        /// </summary>
        /// <remarks>
        ///     Tests the == operator for ComponentId.
        /// </remarks>
        [Fact]
        public void ComponentId_EqualityOperator()
        {
            // Arrange
            ComponentId componentId1 = new ComponentId(7);
            ComponentId componentId2 = new ComponentId(7);
            ComponentId componentId3 = new ComponentId(8);

            // Assert
            Assert.True(componentId1 == componentId2);
            Assert.False(componentId1 == componentId3);
        }

        /// <summary>
        ///     Tests that component id inequality operator
        /// </summary>
        /// <remarks>
        ///     Tests the != operator for ComponentId.
        /// </remarks>
        [Fact]
        public void ComponentId_InequalityOperator()
        {
            // Arrange
            ComponentId componentId1 = new ComponentId(7);
            ComponentId componentId2 = new ComponentId(7);
            ComponentId componentId3 = new ComponentId(8);

            // Assert
            Assert.False(componentId1 != componentId2);
            Assert.True(componentId1 != componentId3);
        }

        /// <summary>
        ///     Tests that component id equals object method
        /// </summary>
        /// <remarks>
        ///     Tests the Equals(object) method.
        /// </remarks>
        [Fact]
        public void ComponentId_EqualsObjectMethod()
        {
            // Arrange
            ComponentId componentId1 = new ComponentId(5);
            ComponentId componentId2 = new ComponentId(5);
            ComponentId componentId3 = new ComponentId(6);

            // Assert
            Assert.True(componentId1.Equals((object)componentId2));
            Assert.False(componentId1.Equals((object)componentId3));
            Assert.False(componentId1.Equals(null));
            Assert.False(componentId1.Equals("string"));
        }
    }
}

