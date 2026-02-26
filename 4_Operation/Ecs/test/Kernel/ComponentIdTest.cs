// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentIdTest.cs
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
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     The component id test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="ComponentId"/> struct which represents a lightweight
    ///     component type identifier used for fast lookups in the ECS system.
    /// </remarks>
    public class ComponentIdTest
    {
        /// <summary>
        ///     Tests that component id can be retrieved for type
        /// </summary>
        /// <remarks>
        ///     Verifies that Component.Id returns a valid ComponentId.
        /// </remarks>
        [Fact]
        public void ComponentId_CanBeRetrievedForType()
        {
            // Act
            ComponentId id = Component<Position>.Id;

            // Assert
            Assert.NotEqual(default(ComponentId), id);
        }

        /// <summary>
        ///     Tests that component id is consistent across calls
        /// </summary>
        /// <remarks>
        ///     Validates that multiple calls to get the same component ID return the same value.
        /// </remarks>
        [Fact]
        public void ComponentId_IsConsistentAcrossCalls()
        {
            // Act
            ComponentId id1 = Component<Position>.Id;
            ComponentId id2 = Component<Position>.Id;

            // Assert
            Assert.Equal(id1, id2);
        }

        /// <summary>
        ///     Tests that different components have different ids
        /// </summary>
        /// <remarks>
        ///     Validates that different component types get unique IDs.
        /// </remarks>
        [Fact]
        public void DifferentComponents_HaveDifferentIds()
        {
            // Act
            ComponentId posId = Component<Position>.Id;
            ComponentId velId = Component<Velocity>.Id;

            // Assert
            Assert.NotEqual(posId, velId);
        }

        /// <summary>
        ///     Tests that component id equality works correctly
        /// </summary>
        /// <remarks>
        ///     Tests the Equals method of ComponentId.
        /// </remarks>
        [Fact]
        public void ComponentId_EqualityWorksCorrectly()
        {
            // Arrange
            ComponentId id1 = Component<Position>.Id;
            ComponentId id2 = Component<Position>.Id;
            ComponentId id3 = Component<Velocity>.Id;

            // Assert
            Assert.True(id1.Equals(id2));
            Assert.False(id1.Equals(id3));
        }

        /// <summary>
        ///     Tests that component id equality operator works
        /// </summary>
        /// <remarks>
        ///     Tests the == and != operators of ComponentId.
        /// </remarks>
        [Fact]
        public void ComponentId_EqualityOperatorWorks()
        {
            // Arrange
            ComponentId id1 = Component<Position>.Id;
            ComponentId id2 = Component<Position>.Id;
            ComponentId id3 = Component<Velocity>.Id;

            // Assert
            Assert.True(id1 == id2);
            Assert.False(id1 == id3);
            Assert.True(id1 != id3);
            Assert.False(id1 != id2);
        }

        /// <summary>
        ///     Tests that component id get hash code returns consistent values
        /// </summary>
        /// <remarks>
        ///     Validates that GetHashCode returns consistent values for the same ComponentId.
        /// </remarks>
        [Fact]
        public void ComponentId_GetHashCodeReturnsConsistentValues()
        {
            // Arrange
            ComponentId id = Component<Position>.Id;

            // Act
            int hash1 = id.GetHashCode();
            int hash2 = id.GetHashCode();

            // Assert
            Assert.Equal(hash1, hash2);
        }

        /// <summary>
        ///     Tests that component id has type property
        /// </summary>
        /// <remarks>
        ///     Validates that ComponentId.Type returns the correct Type.
        /// </remarks>
        [Fact]
        public void ComponentId_HasTypeProperty()
        {
            // Arrange
            ComponentId id = Component<Position>.Id;

            // Act
            var type = id.Type;

            // Assert
            Assert.NotNull(type);
            Assert.Equal(typeof(Position), type);
        }

        /// <summary>
        ///     Tests that component id can be used in dictionary
        /// </summary>
        /// <remarks>
        ///     Tests that ComponentId can be used as a dictionary key.
        /// </remarks>
        [Fact]
        public void ComponentId_CanBeUsedInDictionary()
        {
            // Arrange
            var dict = new System.Collections.Generic.Dictionary<ComponentId, string>();
            ComponentId posId = Component<Position>.Id;
            ComponentId velId = Component<Velocity>.Id;

            // Act
            dict[posId] = "Position";
            dict[velId] = "Velocity";

            // Assert
            Assert.Equal("Position", dict[posId]);
            Assert.Equal("Velocity", dict[velId]);
            Assert.Equal(2, dict.Count);
        }

        /// <summary>
        ///     Tests that component id equals null returns false
        /// </summary>
        /// <remarks>
        ///     Validates that ComponentId.Equals(null) returns false.
        /// </remarks>
        [Fact]
        public void ComponentId_EqualsNullReturnsFalse()
        {
            // Arrange
            ComponentId id = Component<Position>.Id;

            // Act
            bool result = id.Equals(null);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that component id equals wrong type returns false
        /// </summary>
        /// <remarks>
        ///     Validates that ComponentId.Equals with wrong type returns false.
        /// </remarks>
        [Fact]
        public void ComponentId_EqualsWrongTypeReturnsFalse()
        {
            // Arrange
            ComponentId id = Component<Position>.Id;

            // Act
            bool result = id.Equals("string");

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that component id works with value types
        /// </summary>
        /// <remarks>
        ///     Tests that ComponentId works correctly with value type components.
        /// </remarks>
        [Fact]
        public void ComponentId_WorksWithValueTypes()
        {
            // Act
            ComponentId intId = Component<int>.Id;
            ComponentId doubleId = Component<double>.Id;

            // Assert
            Assert.NotEqual(intId, doubleId);
            Assert.NotEqual(default(ComponentId), intId);
        }

        /// <summary>
        ///     Tests that component id works with reference types
        /// </summary>
        /// <remarks>
        ///     Tests that ComponentId works correctly with reference type components.
        /// </remarks>
        [Fact]
        public void ComponentId_WorksWithReferenceTypes()
        {
            // Act
            ComponentId stringId = Component<string>.Id;

            // Assert
            Assert.NotEqual(default(ComponentId), stringId);
            Assert.Equal(typeof(string), stringId.Type);
        }
    }
}

