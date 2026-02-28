// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentModificationTest.cs
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

using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Tests for adding and removing components on existing entities
    /// </summary>
    /// <remarks>
    ///     Validates that components can be dynamically added to or removed from
    ///     entities, and that queries correctly reflect these changes.
    /// </remarks>
    public class ComponentModificationTest
    {
        /// <summary>
        ///     Tests adding component to entity
        /// </summary>
        [Fact]
        public void GameObject_CanAddComponent()
        {
            // Arrange
            using var scene = new Scene();
            GameObject entity = scene.Create();
            Assert.False(entity.Has<Position>());

            // Act
            entity.Add(new Position { X = 10, Y = 20 });

            // Assert
            Assert.True(entity.Has<Position>());
            Assert.Equal(10, entity.Get<Position>().X);
        }

        /// <summary>
        ///     Tests removing component from entity
        /// </summary>
        [Fact]
        public void GameObject_CanRemoveComponent()
        {
            // Arrange
            using var scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 10 }, new Health { Value = 100 });
            Assert.True(entity.Has<Position>());

            // Act
            entity.Remove<Position>();

            // Assert
            Assert.False(entity.Has<Position>());
            Assert.True(entity.Has<Health>());
        }

        /// <summary>
        ///     Tests adding and removing component updates queries
        /// </summary>
        [Fact]
        public void Query_ReflectsComponentAddition()
        {
            // Arrange
            using var scene = new Scene();
            GameObject entity = scene.Create();
            Query query = scene.Query<With<Position>>();

            // Act - Add component
            entity.Add(new Position { X = 5 });

            // Assert
            int count = 0;
            foreach (var _ in query.EnumerateWithEntities<Position>())
                count++;

            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests removing component updates queries
        /// </summary>
        [Fact]
        public void Query_ReflectsComponentRemoval()
        {
            // Arrange
            using var scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 5 });
            Query query = scene.Query<With<Position>>();

            // Act - Remove component
            entity.Remove<Position>();

            // Assert
            int count = 0;
            foreach (var _ in query.EnumerateWithEntities<Position>())
                count++;

            Assert.Equal(0, count);
        }

        /// <summary>
        ///     Tests adding multiple components sequentially
        /// </summary>
        [Fact]
        public void GameObject_CanAddMultipleComponentsSequentially()
        {
            // Arrange
            using var scene = new Scene();
            GameObject entity = scene.Create();

            // Act
            entity.Add(new Position { X = 1 });
            entity.Add(new Health { Value = 100 });
            entity.Add(new Velocity { VX = 2 });

            // Assert
            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Velocity>());
        }

        /// <summary>
        ///     Tests removing multiple components
        /// </summary>
        [Fact]
        public void GameObject_CanRemoveMultipleComponents()
        {
            // Arrange
            using var scene = new Scene();
            GameObject entity = scene.Create(
                new Position { X = 1 },
                new Health { Value = 100 },
                new Velocity { VX = 2 });

            // Act
            entity.Remove<Position>();
            entity.Remove<Velocity>();

            // Assert
            Assert.False(entity.Has<Position>());
            Assert.True(entity.Has<Health>());
            Assert.False(entity.Has<Velocity>());
        }

        /// <summary>
        ///     Tests component data preserved when other components added
        /// </summary>
        [Fact]
        public void GameObject_ComponentDataPreservedWhenAddingOtherComponents()
        {
            // Arrange
            using var scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 10, Y = 20 });

            // Act
            entity.Add(new Health { Value = 100 });

            // Assert
            ref Position pos = ref entity.Get<Position>();
            Assert.Equal(10, pos.X);
            Assert.Equal(20, pos.Y);
            Assert.Equal(100, entity.Get<Health>().Value);
        }
        

        /// <summary>
        ///     Tests adding component to multiple entities
        /// </summary>
        [Fact]
        public void Scene_CanAddComponentToMultipleEntities()
        {
            // Arrange
            using var scene = new Scene();
            GameObject entity1 = scene.Create();
            GameObject entity2 = scene.Create();

            // Act
            entity1.Add(new Position { X = 1 });
            entity2.Add(new Position { X = 2 });

            // Assert
            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (var _ in query.EnumerateWithEntities<Position>())
                count++;

            Assert.Equal(2, count);
        }
    }
}

