// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentAccessTest.cs
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

using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Tests for accessing and modifying components on entities
    /// </summary>
    /// <remarks>
    ///     Validates that Get<T>() and Has<T>() methods work correctly,
    ///     and that component data can be accessed and modified through references.
    /// </remarks>
    public class ComponentAccessTest
    {
        /// <summary>
        ///     Tests checking if entity has component
        /// </summary>
        [Fact]
        public void GameObject_CanCheckIfHasComponent()
        {
            // Arrange
            using var scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 10 });

            // Act & Assert
            Assert.True(entity.Has<Position>());
            Assert.False(entity.Has<Health>());
        }

        /// <summary>
        ///     Tests getting component reference
        /// </summary>
        [Fact]
        public void GameObject_CanGetComponentReference()
        {
            // Arrange
            using var scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 10, Y = 20 });

            // Act
            ref Position pos = ref entity.Get<Position>();

            // Assert
            Assert.Equal(10, pos.X);
            Assert.Equal(20, pos.Y);
        }

        /// <summary>
        ///     Tests modifying component through reference
        /// </summary>
        [Fact]
        public void GameObject_CanModifyComponentThroughReference()
        {
            // Arrange
            using var scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 10, Y = 20 });

            // Act
            ref Position pos = ref entity.Get<Position>();
            pos.X = 50;
            pos.Y = 60;

            // Assert
            ref Position retrievedPos = ref entity.Get<Position>();
            Assert.Equal(50, retrievedPos.X);
            Assert.Equal(60, retrievedPos.Y);
        }

        /// <summary>
        ///     Tests TryHas on live entity
        /// </summary>
        [Fact]
        public void GameObject_TryHasWorksOnLiveEntity()
        {
            // Arrange
            using var scene = new Scene();
            GameObject entity = scene.Create(new Health { Value = 100 });

            // Act
            bool hasHealth = entity.TryHas<Health>();
            bool hasPosition = entity.TryHas<Position>();

            // Assert
            Assert.True(hasHealth);
            Assert.False(hasPosition);
        }

        /// <summary>
        ///     Tests accessing multiple components on same entity
        /// </summary>
        [Fact]
        public void GameObject_CanAccessMultipleComponents()
        {
            // Arrange
            using var scene = new Scene();
            GameObject entity = scene.Create(
                new Position { X = 1, Y = 2 },
                new Health { Value = 100 },
                new Velocity { VX = 3, VY = 4 });

            // Act & Assert
            ref Position pos = ref entity.Get<Position>();
            Assert.Equal(1, pos.X);

            ref Health health = ref entity.Get<Health>();
            Assert.Equal(100, health.Value);

            ref Velocity vel = ref entity.Get<Velocity>();
            Assert.Equal(3, vel.VX);
        }

        /// <summary>
        ///     Tests component data persists across multiple accesses
        /// </summary>
        [Fact]
        public void GameObject_ComponentDataPersistsAcrossAccesses()
        {
            // Arrange
            using var scene = new Scene();
            GameObject entity = scene.Create(new Health { Value = 100 });

            // Act
            ref Health health = ref entity.Get<Health>();
            health.Value = 50;

            // Assert
            ref Health secondAccess = ref entity.Get<Health>();
            Assert.Equal(50, secondAccess.Value);
        }

        /// <summary>
        ///     Tests getting same component multiple times
        /// </summary>
        [Fact]
        public void GameObject_CanGetComponentMultipleTimes()
        {
            // Arrange
            using var scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 10, Y = 20 });

            // Act
            ref Position pos1 = ref entity.Get<Position>();
            ref Position pos2 = ref entity.Get<Position>();
            ref Position pos3 = ref entity.Get<Position>();

            // Assert
            Assert.Equal(10, pos1.X);
            Assert.Equal(10, pos2.X);
            Assert.Equal(10, pos3.X);
        }
    }
}

