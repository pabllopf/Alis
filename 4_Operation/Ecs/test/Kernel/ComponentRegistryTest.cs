// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentRegistryTest.cs
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
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     Tests for <see cref="Component" /> static registry and <see cref="Component{T}" /> static generic
    /// </summary>
    public class ComponentRegistryTest
    {
        /// <summary>
        ///     Tests that component id is unique per type
        /// </summary>
        [Fact]
        public void ShouldReturnUniqueIdPerType()
        {
            ComponentId positionId = Component<Position>.Id;
            ComponentId velocityId = Component<Velocity>.Id;

            Assert.NotEqual(positionId, velocityId);
        }

        /// <summary>
        ///     Tests that component id is stable across accesses
        /// </summary>
        [Fact]
        public void ShouldReturnStableIdAcrossAccesses()
        {
            ComponentId first = Component<Position>.Id;
            ComponentId second = Component<Position>.Id;

            Assert.Equal(first, second);
        }

        /// <summary>
        ///     Tests that component id has valid raw index
        /// </summary>
        [Fact]
        public void ShouldReturnNonNegativeRawIndex()
        {
            ComponentId id = Component<Health>.Id;

            Assert.True(id.RawIndex >= 0);
        }

        /// <summary>
        ///     Tests that store component handle has correct component id
        /// </summary>
        [Fact]
        public void ShouldReturnHandleWithCorrectComponentId()
        {
            Position position = new Position { X = 5, Y = 15 };

            ComponentHandle handle = Component<Position>.StoreComponent(in position);

            Assert.Equal(Component<Position>.Id, handle.ComponentId);
        }

        /// <summary>
        ///     Tests that get component id returns valid id for type
        /// </summary>
        [Fact]
        public void ShouldReturnValidIdWhenGetComponentIdCalled()
        {
            ComponentId id = Component.GetComponentId(typeof(Position));

            Assert.True(id.RawIndex >= 0);
        }

        /// <summary>
        ///     Tests that get component id is consistent with generic version
        /// </summary>
        [Fact]
        public void ShouldReturnConsistentIdWithGenericVersion()
        {
            ComponentId genericId = Component<Health>.Id;
            ComponentId nonGenericId = Component.GetComponentId(typeof(Health));

            Assert.Equal(genericId, nonGenericId);
        }

        /// <summary>
        ///     Tests that register component does not throw
        /// </summary>
        [Fact]
        public void ShouldNotThrowWhenRegisterComponentCalled()
        {
            Exception exception = Record.Exception(() => Component.RegisterComponent<ComplexType>());

            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that register component is idempotent
        /// </summary>
        [Fact]
        public void ShouldBeIdempotentWhenRegisterComponentCalledTwice()
        {
            Exception exception = Record.Exception(() =>
            {
                Component.RegisterComponent<ComplexType>();
                Component.RegisterComponent<ComplexType>();
            });

            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that register component makes get component id succeed
        /// </summary>
        [Fact]
        public void ShouldMakeGetComponentIdSucceedAfterRegistration()
        {
            Component.RegisterComponent<ComplexType>();

            ComponentId id = Component.GetComponentId(typeof(ComplexType));

            Assert.True(id.RawIndex >= 0);
        }

        /// <summary>
        ///     Tests that different types get different ids
        /// </summary>
        [Fact]
        public void ShouldAssignDifferentIdsToDifferentTypes()
        {
            ComponentId positionId = Component.GetComponentId(typeof(Position));
            ComponentId healthId = Component.GetComponentId(typeof(Health));

            Assert.NotEqual(positionId, healthId);
        }
    }
}
