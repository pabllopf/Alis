// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneCreateTest.cs
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
    ///     The scene create test class
    /// </summary>
    /// <remarks>
    ///     Tests the entity creation functionality in Scene, validating various ways
    ///     to create entities with different component combinations.
    /// </remarks>
    public class SceneCreateTest
    {
        /// <summary>
        ///     Tests that empty entity can be created
        /// </summary>
        /// <remarks>
        ///     Validates that a Scene can create an entity with no components.
        /// </remarks>
        [Fact]
        public void SceneCreate_EmptyEntityCanBeCreated()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            GameObject entity = scene.Create();

            // Assert
            Assert.NotNull(entity);
            Assert.False(entity.IsNull);
            Assert.True(entity.IsAlive);
        }

        /// <summary>
        ///     Tests that entity with single component can be created
        /// </summary>
        /// <remarks>
        ///     Validates that an entity can be created with one component.
        /// </remarks>
        [Fact]
        public void SceneCreate_EntityWithSingleComponentCanBeCreated()
        {
            // Arrange
            using Scene scene = new Scene();
            Position pos = new Position { X = 10, Y = 20 };

            // Act
            GameObject entity = scene.Create(pos);

            // Assert
            Assert.True(entity.IsAlive);
            Assert.True(entity.Has<Position>());
        }

        /// <summary>
        ///     Tests that entity with two components can be created
        /// </summary>
        /// <remarks>
        ///     Validates that an entity can be created with two components.
        /// </remarks>
        [Fact]
        public void SceneCreate_EntityWithTwoComponentsCanBeCreated()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            GameObject entity = scene.Create(
                new Position { X = 1, Y = 2 },
                new Velocity { VX = 3, VY = 4 }
            );

            // Assert
            Assert.True(entity.IsAlive);
            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
        }

        /// <summary>
        ///     Tests that entity with three components can be created
        /// </summary>
        /// <remarks>
        ///     Validates that an entity can be created with three components.
        /// </remarks>
        [Fact]
        public void SceneCreate_EntityWithThreeComponentsCanBeCreated()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            GameObject entity = scene.Create(
                new Position { X = 1, Y = 2 },
                new Velocity { VX = 3, VY = 4 },
                new Health { Value = 100 }
            );

            // Assert
            Assert.True(entity.IsAlive);
            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
        }

        /// <summary>
        ///     Tests that entity with four components can be created
        /// </summary>
        /// <remarks>
        ///     Validates that an entity can be created with four components.
        /// </remarks>
        [Fact]
        public void SceneCreate_EntityWithFourComponentsCanBeCreated()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            GameObject entity = scene.Create(
                new Position { X = 1, Y = 2 },
                new Velocity { VX = 3, VY = 4 },
                new Health { Value = 100 },
                new Transform { X = 5, Y = 6, Rotation = 45 }
            );

            // Assert
            Assert.True(entity.IsAlive);
            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Transform>());
        }

        /// <summary>
        ///     Tests that entity with five components can be created
        /// </summary>
        /// <remarks>
        ///     Validates that an entity can be created with five components.
        /// </remarks>
        [Fact]
        public void SceneCreate_EntityWithFiveComponentsCanBeCreated()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            GameObject entity = scene.Create(
                new Position { X = 1, Y = 2 },
                new Velocity { VX = 3, VY = 4 },
                new Health { Value = 100 },
                new Transform { X = 5, Y = 6, Rotation = 45 },
                new TestComponent { Value = 999 }
            );

            // Assert
            Assert.True(entity.IsAlive);
            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Transform>());
            Assert.True(entity.Has<TestComponent>());
        }

        /// <summary>
        ///     Tests that multiple entities can be created
        /// </summary>
        /// <remarks>
        ///     Validates that multiple entities can be created in sequence.
        /// </remarks>
        [Fact]
        public void SceneCreate_MultipleEntitiesCanBeCreated()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 2 });
            GameObject entity2 = scene.Create(new Position { X = 3, Y = 4 });
            GameObject entity3 = scene.Create(new Position { X = 5, Y = 6 });

            // Assert
            Assert.True(entity1.IsAlive);
            Assert.True(entity2.IsAlive);
            Assert.True(entity3.IsAlive);
            Assert.NotEqual(entity1, entity2);
            Assert.NotEqual(entity2, entity3);
        }

        /// <summary>
        ///     Tests that created entities have unique identities
        /// </summary>
        /// <remarks>
        ///     Validates that each created entity has a unique ID.
        /// </remarks>
        [Fact]
        public void SceneCreate_CreatedEntitiesHaveUniqueIdentities()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            GameObject entity1 = scene.Create();
            GameObject entity2 = scene.Create();
            GameObject entity3 = scene.Create();

            // Assert
            Assert.NotEqual(entity1, entity2);
            Assert.NotEqual(entity2, entity3);
            Assert.NotEqual(entity1, entity3);
        }

        /// <summary>
        ///     Tests that created entity count increases
        /// </summary>
        /// <remarks>
        ///     Validates that the scene entity count increases with each creation.
        /// </remarks>
        [Fact]
        public void SceneCreate_EntityCountIncreases()
        {
            // Arrange
            using Scene scene = new Scene();
            int initialCount = scene.EntityCount;

            // Act
            scene.Create();

            // Assert
            Assert.Equal(initialCount + 1, scene.EntityCount);
        }

        /// <summary>
        ///     Tests that component data is preserved when created
        /// </summary>
        /// <remarks>
        ///     Validates that component values set during creation are preserved.
        /// </remarks>
        [Fact]
        public void SceneCreate_ComponentDataIsPreservedWhenCreated()
        {
            // Arrange
            using Scene scene = new Scene();
            Position testPos = new Position { X = 42, Y = 84 };

            // Act
            GameObject entity = scene.Create(testPos);

            // Assert
            Assert.True(entity.TryGet<Position>(out var pos));
            Assert.Equal(42, pos.Value.X);
            Assert.Equal(84, pos.Value.Y);
        }

        /// <summary>
        ///     Tests that components created with different data are separate
        /// </summary>
        /// <remarks>
        ///     Validates that each entity maintains its own component data.
        /// </remarks>
        [Fact]
        public void SceneCreate_ComponentDataIsSeparateBetweenEntities()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 1 });
            GameObject entity2 = scene.Create(new Position { X = 2, Y = 2 });

            // Assert
            Assert.True(entity1.TryGet<Position>(out var pos1));
            Assert.True(entity2.TryGet<Position>(out var pos2));
            Assert.Equal(1, pos1.Value.X);
            Assert.Equal(2, pos2.Value.X);
        }

        /// <summary>
        ///     Tests that entity can be created after previous entity deletion
        /// </summary>
        /// <remarks>
        ///     Validates that entities can be created after other entities are destroyed.
        /// </remarks>
        [Fact]
        public void SceneCreate_EntityCanBeCreatedAfterDeletion()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 2 });

            // Act
            entity1.Delete();
            GameObject entity2 = scene.Create(new Position { X = 3, Y = 4 });

            // Assert
            Assert.False(entity1.IsAlive);
            Assert.True(entity2.IsAlive);
        }

        /// <summary>
        ///     Tests that large number of entities can be created
        /// </summary>
        /// <remarks>
        ///     Validates that the scene can handle creation of many entities.
        /// </remarks>
        [Fact]
        public void SceneCreate_LargeNumberOfEntitiesCanBeCreated()
        {
            // Arrange
            using Scene scene = new Scene();
            int entityCount = 1000;

            // Act
            for (int i = 0; i < entityCount; i++)
            {
                scene.Create(new Position { X = i, Y = i * 2 });
            }

            // Assert
            Assert.Equal(entityCount, scene.EntityCount);
        }

        /// <summary>
        ///     Tests that created entities are immediately alive
        /// </summary>
        /// <remarks>
        ///     Validates that newly created entities are ready to use immediately.
        /// </remarks>
        [Fact]
        public void SceneCreate_CreatedEntitiesAreImmediatelyAlive()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            GameObject entity = scene.Create(new Position { X = 1, Y = 2 });

            // Assert
            Assert.True(entity.IsAlive);
            Assert.False(entity.IsNull);
        }

        /// <summary>
        ///     Tests that created entity can be queried immediately
        /// </summary>
        /// <remarks>
        ///     Validates that newly created entities appear in queries immediately.
        /// </remarks>
        [Fact]
        public void SceneCreate_CreatedEntityCanBeQueriedImmediately()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            GameObject entity = scene.Create(new Position { X = 1, Y = 2 });
            Query query = scene.Query<With<Position>>();

            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that created entities with different component sets coexist
        /// </summary>
        /// <remarks>
        ///     Validates that entities with different archetype signatures can coexist.
        /// </remarks>
        [Fact]
        public void SceneCreate_EntitiesWithDifferentComponentSetsCoexist()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 2 });
            GameObject entity2 = scene.Create(new Position { X = 3, Y = 4 }, new Velocity { VX = 5, VY = 6 });
            GameObject entity3 = scene.Create();

            // Assert
            Assert.True(entity1.IsAlive);
            Assert.True(entity2.IsAlive);
            Assert.True(entity3.IsAlive);
            Assert.True(entity1.Has<Position>());
            Assert.False(entity1.Has<Velocity>());
            Assert.True(entity2.Has<Position>());
            Assert.True(entity2.Has<Velocity>());
            Assert.False(entity3.Has<Position>());
        }
    }
}

