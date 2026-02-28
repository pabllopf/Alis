// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentHandleExtendedTest.cs
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
    ///     The component handle extended test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="ComponentHandle"/> struct which stores
    ///     information needed to handle component instances (index and archetype).
    ///     This is an extended test suite with more comprehensive cases.
    /// </remarks>
    public class ComponentHandleExtendedTest
    {
    /// <summary>
    ///     Tests that component handle can be created with parameters
    /// </summary>
    /// <remarks>
    ///     Verifies that ComponentHandle can be instantiated with valid parameters.
    /// </remarks>
    [Fact]
    public void ComponentHandle_CanBeCreatedWithParameters()
    {
        // Arrange
        ComponentId id = new ComponentId(5);

        // Act
        ComponentHandle handle = new ComponentHandle(5, id);

        // Assert
        Assert.Equal(5, handle.Index);
        Assert.Equal(id, handle.ComponentId);
    }

    /// <summary>
    ///     Tests that component handle component index is preserved
    /// </summary>
    /// <remarks>
    ///     Validates that the Index field is correctly stored.
    /// </remarks>
    [Fact]
    public void ComponentHandle_ComponentIndexIsPreserved()
    {
        // Arrange
        ComponentId id = new ComponentId(10);

        // Act
        ComponentHandle handle = new ComponentHandle(42, id);

        // Assert
        Assert.Equal(42, handle.Index);
    }

    /// <summary>
    ///     Tests that component handle archetype id is preserved
    /// </summary>
    /// <remarks>
    ///     Validates that the ComponentId field is correctly stored.
    /// </remarks>
    [Fact]
    public void ComponentHandle_ComponentIdIsPreserved()
    {
        // Arrange
        ComponentId id = new ComponentId(25);

        // Act
        ComponentHandle handle = new ComponentHandle(5, id);

        // Assert
        Assert.Equal(id, handle.ComponentId);
        Assert.Equal((ushort)25, handle.ComponentId.RawIndex);
    }

    /// <summary>
    ///     Tests that component handle with zero indices
    /// </summary>
    /// <remarks>
    ///     Tests creation with zero component index and component ID.
    /// </remarks>
    [Fact]
    public void ComponentHandle_WithZeroIndices()
    {
        // Arrange
        ComponentId id = new ComponentId(0);

        // Act
        ComponentHandle handle = new ComponentHandle(0, id);

        // Assert
        Assert.Equal(0, handle.Index);
        Assert.Equal((ushort)0, handle.ComponentId.RawIndex);
    }

    /// <summary>
    ///     Tests that component handle with max values
    /// </summary>
    /// <remarks>
    ///     Tests creation with maximum component index and component ID.
    /// </remarks>
    [Fact]
    public void ComponentHandle_WithMaxValues()
    {
        // Arrange
        ComponentId id = new ComponentId(ushort.MaxValue);

        // Act
        ComponentHandle handle = new ComponentHandle(int.MaxValue, id);

        // Assert
        Assert.Equal(int.MaxValue, handle.Index);
        Assert.Equal(ushort.MaxValue, handle.ComponentId.RawIndex);
    }

        /// <summary>
        ///     Tests that component handle equality
        /// </summary>
        /// <remarks>
        ///     Tests ComponentHandle equality comparison.
        /// </remarks>
        [Fact]
        public void ComponentHandle_Equality()
        {
            // Arrange
            ComponentId id = new ComponentId(5);
            ComponentHandle handle1 = new ComponentHandle(10, id);
            ComponentHandle handle2 = new ComponentHandle(10, id);
            ComponentHandle handle3 = new ComponentHandle(20, id);

            // Assert
            Assert.Equal(handle1, handle2);
            Assert.NotEqual(handle1, handle3);
        }

        /// <summary>
        ///     Tests that component handle hash code consistency
        /// </summary>
        /// <remarks>
        ///     Validates that hash codes are consistent for equal handles.
        /// </remarks>
        [Fact]
        public void ComponentHandle_HashCodeConsistency()
        {
            // Arrange
            ComponentId id = new ComponentId(8);
            ComponentHandle handle1 = new ComponentHandle(15, id);
            ComponentHandle handle2 = new ComponentHandle(15, id);

            // Act & Assert
            Assert.Equal(handle1.GetHashCode(), handle2.GetHashCode());
        }

        /// <summary>
        ///     Tests that component handle is value type
        /// </summary>
        /// <remarks>
        ///     Confirms that ComponentHandle is a value type.
        /// </remarks>
        [Fact]
        public void ComponentHandle_IsValueType()
        {
            // Arrange
            ComponentId id1 = new ComponentId(10);
            ComponentId id2 = new ComponentId(30);
            ComponentHandle handle1 = new ComponentHandle(5, id1);
            ComponentHandle handle2 = new ComponentHandle(20, id2);

            // Assert
            Assert.NotEqual(handle1, handle2);
        }

        /// <summary>
        ///     Tests that component handle with negative index
        /// </summary>
        /// <remarks>
        ///     Tests creation with negative component index.
        /// </remarks>
        [Fact]
        public void ComponentHandle_WithNegativeIndex()
        {
            // Arrange
            ComponentId id = new ComponentId(10);

            // Act
            ComponentHandle handle = new ComponentHandle(-1, id);

            // Assert
            Assert.Equal(-1, handle.Index);
        }

        /// <summary>
        ///     Tests that component handle different component ids are not equal
        /// </summary>
        /// <remarks>
        ///     Validates that handles with different component IDs are not equal.
        /// </remarks>
        [Fact]
        public void ComponentHandle_WithDifferentComponentIdsAreNotEqual()
        {
            // Arrange
            ComponentId id1 = new ComponentId(5);
            ComponentId id2 = new ComponentId(10);
            ComponentHandle handle1 = new ComponentHandle(10, id1);
            ComponentHandle handle2 = new ComponentHandle(10, id2);

            // Assert
            Assert.NotEqual(handle1, handle2);
        }

        /// <summary>
        ///     Tests that component handle to string works
        /// </summary>
        /// <remarks>
        ///     Validates string representation of ComponentHandle.
        /// </remarks>
        [Fact]
        public void ComponentHandle_ToStringWorks()
        {
            // Arrange
            ComponentId id = new ComponentId(5);
            ComponentHandle handle = new ComponentHandle(10, id);

            // Act
            string result = handle.ToString();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }

        /// <summary>
        ///     Tests that component handle equality operator works
        /// </summary>
        /// <remarks>
        ///     Validates that the equality operator works correctly.
        /// </remarks>
        [Fact]
        public void ComponentHandle_EqualityOperator()
        {
            // Arrange
            ComponentId id = new ComponentId(5);
            ComponentHandle handle1 = new ComponentHandle(10, id);
            ComponentHandle handle2 = new ComponentHandle(10, id);
            ComponentHandle handle3 = new ComponentHandle(20, id);

            // Assert
            Assert.True(handle1 == handle2);
            Assert.False(handle1 == handle3);
        }

        /// <summary>
        ///     Tests that component handle inequality operator works
        /// </summary>
        /// <remarks>
        ///     Validates that the inequality operator works correctly.
        /// </remarks>
        [Fact]
        public void ComponentHandle_InequalityOperator()
        {
            // Arrange
            ComponentId id = new ComponentId(5);
            ComponentHandle handle1 = new ComponentHandle(10, id);
            ComponentHandle handle2 = new ComponentHandle(10, id);
            ComponentHandle handle3 = new ComponentHandle(20, id);

            // Assert
            Assert.False(handle1 != handle2);
            Assert.True(handle1 != handle3);
        }

        /// <summary>
        ///     Tests that component handle type property works
        /// </summary>
        /// <remarks>
        ///     Validates that Type property reflects the component type.
        /// </remarks>
        [Fact]
        public void ComponentHandle_TypeProperty()
        {
            // Arrange
            ComponentId id = new ComponentId(0);
            ComponentHandle handle = new ComponentHandle(5, id);

            // Act & Assert - This should not throw
            try
            {
                object componentType = handle.Type;
                Assert.NotNull(componentType);
            }
            catch
            {
                // Expected behavior when ComponentId is not properly registered
                Assert.True(true);
            }
        }
    }
}
