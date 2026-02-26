// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentLifecycleTest.cs
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
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The component lifecycle test class
    /// </summary>
    /// <remarks>
    ///     Tests component lifecycle operations including addition, removal,
    ///     access, and modification of components on entities.
    /// </remarks>
    public class ComponentLifecycleTest
    {
        /// <summary>
        ///     Tests that components can be added to entities
        /// </summary>
        /// <remarks>
        ///     Validates that components can be added after entity creation.
        /// </remarks>
        [Fact]
        public void Component_CanBeAddedAfterCreation()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 0, Y = 0 });

            // Act
            entity.Add(new Health { Value = 100 });

            // Assert
            Assert.True(entity.Has<Health>());
            Assert.Equal(100, entity.Get<Health>().Value);
        }

        /// <summary>
        ///     Tests that components can be removed from entities
        /// </summary>
        /// <remarks>
        ///     Tests that components can be removed and will not be accessible.
        /// </remarks>
        [Fact]
        public void Component_CanBeRemoved()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 0, Y = 0 }, new Health { Value = 100 });

            // Act
            entity.Remove<Health>();

            // Assert
            Assert.False(entity.Has<Health>());
            Assert.True(entity.Has<Position>());
        }

        /// <summary>
        ///     Tests that component data can be accessed
        /// </summary>
        /// <remarks>
        ///     Validates that component data can be retrieved from entities.
        /// </remarks>
        [Fact]
        public void Component_DataCanBeAccessed()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 10, Y = 20 });

            // Act
            var pos = entity.Get<Position>();

            // Assert
            Assert.Equal(10, pos.X);
            Assert.Equal(20, pos.Y);
        }

        /// <summary>
        ///     Tests that TryGet works correctly
        /// </summary>
        /// <remarks>
        ///     Tests that TryGet returns true for present components
        ///     and false for absent ones.
        /// </remarks>
        [Fact]
        public void Component_TryGetWorks()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 5, Y = 10 });

            // Act
            bool hasPos = entity.TryGet(out Ref<Position> posRef);
            bool hasHealth = entity.TryGet(out Ref<Health> healthRef);

            // Assert
            Assert.True(hasPos);
            Assert.Equal(5, posRef.Value.X);
            Assert.False(hasHealth);
        }

        /// <summary>
        ///     Tests that multiple component types can coexist
        /// </summary>
        /// <remarks>
        ///     Validates that entities can have multiple components simultaneously.
        /// </remarks>
        [Fact]
        public void Component_MultipleComponentsCanCoexist()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position { X = 1, Y = 2 },
                new Health { Value = 75 },
                new Velocity { VX = 1.5f, VY = 2.5f }
            );

            // Assert
            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Velocity>());
        }

        /// <summary>
        ///     Tests that dead entities cannot access components
        /// </summary>
        /// <remarks>
        ///     Validates that accessing components on deleted entities throws.
        /// </remarks>
        [Fact]
        public void Component_DeadEntityThrowsOnAccess()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 0, Y = 0 });

            // Act
            entity.Delete();

            // Assert
            Assert.ThrowsAny<System.InvalidOperationException>(() => entity.Get<Position>());
        }
    }
}

