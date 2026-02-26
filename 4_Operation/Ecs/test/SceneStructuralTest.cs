// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneStructuralTest.cs
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
    ///     The scene structural test class
    /// </summary>
    /// <remarks>
    ///     Tests the structural changes functionality in Scene, including archetype
    ///     transitions when components are added or removed from entities.
    /// </remarks>
    public class SceneStructuralTest
    {
        /// <summary>
        ///     Tests that entity archetype changes when component is added
        /// </summary>
        /// <remarks>
        ///     Validates that adding a component causes the entity to transition to a new archetype.
        /// </remarks>
        [Fact]
        public void SceneStructural_EntityArchetypeChangesWhenComponentAdded()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            // Act
            entity.Add(new Position { X = 1, Y = 2 });

            // Assert
            Assert.True(entity.IsAlive);
            Assert.True(entity.Has<Position>());
        }

        /// <summary>
        ///     Tests that entity archetype changes when component is removed
        /// </summary>
        /// <remarks>
        ///     Validates that removing a component causes the entity to transition to a new archetype.
        /// </remarks>
        [Fact]
        public void SceneStructural_EntityArchetypeChangesWhenComponentRemoved()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 1, Y = 2 });

            // Act
            entity.Remove<Position>();

            // Assert
            Assert.True(entity.IsAlive);
            Assert.False(entity.Has<Position>());
        }

        /// <summary>
        ///     Tests that entity data is preserved during archetype transition
        /// </summary>
        /// <remarks>
        ///     Validates that component data is preserved when changing archetypes.
        /// </remarks>
        [Fact]
        public void SceneStructural_EntityDataIsPreservedDuringTransition()
        {
            // Arrange
            using Scene scene = new Scene();
            Position originalPos = new Position { X = 42, Y = 84 };
            GameObject entity = scene.Create(originalPos);

            // Act
            entity.Add(new Velocity { VX = 10, VY = 20 });

            // Assert
            Assert.True(entity.TryGet<Position>(out var pos));
            Assert.Equal(42, pos.Value.X);
            Assert.Equal(84, pos.Value.Y);
        }

        /// <summary>
        ///     Tests that multiple components can be added sequentially
        /// </summary>
        /// <remarks>
        ///     Validates that multiple archetype transitions work correctly.
        /// </remarks>
        [Fact]
        public void SceneStructural_MultipleComponentsCanBeAddedSequentially()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            // Act
            entity.Add(new Position { X = 1, Y = 2 });
            entity.Add(new Velocity { VX = 3, VY = 4 });
            entity.Add(new Health { Value = 100 });

            // Assert
            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
        }

        /// <summary>
        ///     Tests that multiple components can be removed sequentially
        /// </summary>
        /// <remarks>
        ///     Validates that multiple removal operations work correctly.
        /// </remarks>
        [Fact]
        public void SceneStructural_MultipleComponentsCanBeRemovedSequentially()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position { X = 1, Y = 2 },
                new Velocity { VX = 3, VY = 4 },
                new Health { Value = 100 }
            );

            // Act
            entity.Remove<Position>();
            entity.Remove<Velocity>();

            // Assert
            Assert.False(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
        }

        /// <summary>
        ///     Tests that entity identity is preserved during archetype transition
        /// </summary>
        /// <remarks>
        ///     Validates that the GameObject reference remains valid after structural changes.
        /// </remarks>
        [Fact]
        public void SceneStructural_EntityIdentityIsPreservedDuringTransition()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 1, Y = 2 });
            GameObject originalRef = entity;

            // Act
            entity.Add(new Velocity { VX = 3, VY = 4 });

            // Assert
            Assert.Equal(originalRef, entity);
            Assert.True(entity.IsAlive);
        }

        /// <summary>
        ///     Tests that removing all components returns to default archetype
        /// </summary>
        /// <remarks>
        ///     Validates that removing all components transitions to the empty archetype.
        /// </remarks>
        [Fact]
        public void SceneStructural_RemovingAllComponentsReturnsToDefaultArchetype()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position { X = 1, Y = 2 },
                new Velocity { VX = 3, VY = 4 }
            );

            // Act
            entity.Remove<Position>();
            entity.Remove<Velocity>();

            // Assert
            Assert.True(entity.IsAlive);
            Assert.False(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
        }

        /// <summary>
        ///     Tests that archetype transitions preserve other entities
        /// </summary>
        /// <remarks>
        ///     Validates that structural changes don't affect other entities.
        /// </remarks>
        [Fact]
        public void SceneStructural_ArchetypeTransitionsPreserveOtherEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 2 });
            GameObject entity2 = scene.Create(new Position { X = 3, Y = 4 });

            // Act
            entity1.Add(new Velocity { VX = 5, VY = 6 });

            // Assert
            Assert.True(entity2.IsAlive);
            Assert.True(entity2.Has<Position>());
            Assert.False(entity2.Has<Velocity>());
        }

        /// <summary>
        ///     Tests that archetype transitions work with many entities
        /// </summary>
        /// <remarks>
        ///     Validates that structural changes work correctly with many entities.
        /// </remarks>
        [Fact]
        public void SceneStructural_ArchetypeTransitionsWorkWithManyEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject[] entities = new GameObject[100];
            for (int i = 0; i < 100; i++)
            {
                entities[i] = scene.Create(new Position { X = i, Y = i * 2 });
            }

            // Act
            entities[50].Add(new Velocity { VX = 10, VY = 20 });

            // Assert
            Assert.True(entities[50].Has<Velocity>());
            for (int i = 0; i < 100; i++)
            {
                if (i == 50)
                {
                    Assert.True(entities[i].Has<Velocity>());
                }
                else
                {
                    Assert.False(entities[i].Has<Velocity>());
                }
            }
        }

        /// <summary>
        ///     Tests that structural changes work after scene update
        /// </summary>
        /// <remarks>
        ///     Validates that structural changes can be applied after updates.
        /// </remarks>
        [Fact]
        public void SceneStructural_StructuralChangesWorkAfterSceneUpdate()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 1, Y = 2 });

            // Act
            scene.Update();
            entity.Add(new Velocity { VX = 3, VY = 4 });

            // Assert
            Assert.True(entity.IsAlive);
            Assert.True(entity.Has<Velocity>());
        }

        /// <summary>
        ///     Tests that replacing a component works correctly
        /// </summary>
        /// <remarks>
        ///     Validates that removing and adding a component sequentially works.
        /// </remarks>
        [Fact]
        public void SceneStructural_ReplacingComponentWorks()
        {
            // Arrange
            using Scene scene = new Scene();
            Position originalPos = new Position { X = 1, Y = 2 };
            GameObject entity = scene.Create(originalPos);

            // Act
            entity.Remove<Position>();
            Position newPos = new Position { X = 10, Y = 20 };
            entity.Add(newPos);

            // Assert
            Assert.True(entity.Has<Position>());
            Assert.True(entity.TryGet<Position>(out var pos));
            Assert.Equal(10, pos.Value.X);
            Assert.Equal(20, pos.Value.Y);
        }

        /// <summary>
        ///     Tests that archetype transitions work with mixed component types
        /// </summary>
        /// <remarks>
        ///     Validates that transitions handle various component combinations.
        /// </remarks>
        [Fact]
        public void SceneStructural_ArchetypeTransitionsWorkWithMixedComponentTypes()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 1, Y = 2 });

            // Act
            entity.Add(new Velocity { VX = 3, VY = 4 });
            entity.Add(new Health { Value = 100 });
            entity.Remove<Velocity>();
            entity.Add(new Transform { X = 5, Y = 6, Rotation = 45 });

            // Assert
            Assert.True(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Transform>());
        }

        /// <summary>
        ///     Tests that deferred structural changes work correctly
        /// </summary>
        /// <remarks>
        ///     Validates that structural changes can be deferred and applied later.
        /// </remarks>
        [Fact]
        public void SceneStructural_DeferredStructuralChangesAreApplied()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 1, Y = 2 });

            // Act
            entity.Add(new Velocity { VX = 3, VY = 4 });
            scene.Update();

            // Assert
            Assert.True(entity.IsAlive);
            Assert.True(entity.Has<Velocity>());
        }

        /// <summary>
        ///     Tests that entity count is updated correctly after structural changes
        /// </summary>
        /// <remarks>
        ///     Validates that archetype entity counts are maintained correctly.
        /// </remarks>
        [Fact]
        public void SceneStructural_EntityCountIsUpdatedAfterStructuralChanges()
        {
            // Arrange
            using Scene scene = new Scene();
            int initialCount = scene.EntityCount;
            GameObject entity1 = scene.Create();
            GameObject entity2 = scene.Create();

            // Act
            entity1.Add(new Position { X = 1, Y = 2 });
            entity2.Add(new Position { X = 3, Y = 4 });

            // Assert
            Assert.Equal(initialCount + 2, scene.EntityCount);
        }
    }
}

