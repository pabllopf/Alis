// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentRegistrationTest.cs
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

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Tests for component registration and ID management
    /// </summary>
    /// <remarks>
    ///     Validates that components are properly registered and assigned unique IDs.
    ///     Tests the Component<T>.Id property and Component.GetComponentId() method.
    /// </remarks>
    public class ComponentRegistrationTest
    {
        /// <summary>
        ///     Tests that each component type gets unique ID
        /// </summary>
        [Fact]
        public void Component_EachTypeGetsUniqueId()
        {
            // Arrange & Act
            ComponentId positionId = Component<Position>.Id;
            ComponentId healthId = Component<Health>.Id;
            ComponentId velocityId = Component<Velocity>.Id;

            // Assert
            Assert.NotEqual(positionId, healthId);
            Assert.NotEqual(healthId, velocityId);
            Assert.NotEqual(positionId, velocityId);
        }

        /// <summary>
        ///     Tests that component IDs are consistent across multiple accesses
        /// </summary>
        [Fact]
        public void Component_IdIsConsistentAcrossAccesses()
        {
            // Arrange & Act
            ComponentId id1 = Component<Position>.Id;
            ComponentId id2 = Component<Position>.Id;
            ComponentId id3 = Component<Position>.Id;

            // Assert
            Assert.Equal(id1, id2);
            Assert.Equal(id2, id3);
        }

        /// <summary>
        ///     Tests getting component ID by type
        /// </summary>
        [Fact]
        public void Component_GetComponentIdByType()
        {
            // Arrange & Act
            var positionType = typeof(Position);
            ComponentId genericId = Component<Position>.Id;
            ComponentId typeId = Component.GetComponentId(positionType);

            // Assert
            Assert.Equal(genericId, typeId);
        }

        /// <summary>
        ///     Tests that component IDs are non-zero
        /// </summary>
        [Fact]
        public void Component_IdsAreNonZero()
        {
            // Arrange & Act
            ComponentId posId = Component<Position>.Id;
            ComponentId healthId = Component<Health>.Id;

            // Assert
            Assert.NotEqual(default, posId);
            Assert.NotEqual(default, healthId);
        }
    }
}

