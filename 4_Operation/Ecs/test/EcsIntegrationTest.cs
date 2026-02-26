// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EcsIntegrationTest.cs
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
    ///     The ecs integration test class
    /// </summary>
    /// <remarks>
    ///     Integration tests that verify the ECS system works correctly as a whole,
    ///     testing interactions between entities, components, queries, and scenes.
    /// </remarks>
    public class EcsIntegrationTest
    {
        /// <summary>
        ///     Tests that simple game loop scenario works
        /// </summary>
        /// <remarks>
        ///     Simulates a simple game loop scenario with entities, components and updates.
        /// </remarks>
        [Fact]
        public void SimpleGameLoopScenario_Works()
        {
            // Arrange - Create scene and entities
            using Scene scene = new Scene();
            
            // Create player
            GameObject player = scene.Create(
                new Position { X = 0, Y = 0 },
                new Velocity { VX = 1.0f, VY = 0.0f },
                new Health { Value = 100 }
            );
            player.Tag<PlayerTag>();

            // Create enemies
            for (int i = 0; i < 5; i++)
            {
                GameObject enemy = scene.Create(
                    new Position { X = i * 10, Y = 10 },
                    new Health { Value = 50 }
                );
                enemy.Tag<EnemyTag>();
            }

            // Act - Simulate update loop
            Query movementQuery = scene.Query<With<Position>, With<Velocity>>();
            foreach ((Ref<Position> positionRef, Ref<Velocity> velocityRef) in movementQuery.Enumerate<Position, Velocity>())
            {
                positionRef.Value.X += 1.0f;
            }

            // Assert
            Assert.Equal(1.0f, player.Get<Position>().X);
            Assert.Equal(6, scene.EntityCount); // 1 player + 5 enemies
        }

        /// <summary>
        ///     Tests that command buffer deferred operations work
        /// </summary>
        /// <remarks>
        ///     Tests that command buffers correctly defer and apply operations.
        /// </remarks>
        [Fact]
        public void CommandBuffer_DeferredOperations_Work()
        {
            // Arrange
            using Scene scene = new Scene();
            CommandBuffer commandBuffer = new CommandBuffer(scene);
            
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 1 });
            GameObject entity2 = scene.Create(new Position { X = 2, Y = 2 });

            // Act - Queue operations
            commandBuffer.AddComponent(entity1, new Health { Value = 100 });
            commandBuffer.DeleteEntity(entity2);

            // Assert - Changes not applied yet
            Assert.False(entity1.Has<Health>());
            Assert.True(entity2.IsAlive);

            // Act - Apply changes
            commandBuffer.Playback();

            // Assert - Changes applied
            Assert.True(entity1.Has<Health>());
            Assert.False(entity2.IsAlive);
        }

        /// <summary>
        ///     Tests that query filters work with tags
        /// </summary>
        /// <remarks>
        ///     Validates that queries can filter entities based on tags.
        /// </remarks>
        [Fact]
        public void Query_FiltersWithTags_Work()
        {
            // Arrange
            using Scene scene = new Scene();
            
            // Create mixed entities
            for (int i = 0; i < 3; i++)
            {
                GameObject player = scene.Create(new Position { X = i, Y = 0 });
                player.Tag<PlayerTag>();
            }

            for (int i = 0; i < 5; i++)
            {
                GameObject enemy = scene.Create(new Position { X = i, Y = 10 });
                enemy.Tag<EnemyTag>();
            }

            // Act & Assert - Count all positions
            Query allQuery = scene.Query<With<Position>>();
            int allCount = 0;
            foreach (RefTuple<Position> _ in allQuery.Enumerate<Position>())
            {
                allCount++;
            }
            Assert.Equal(8, allCount);
        }

        /// <summary>
        ///     Tests that entity lifecycle events work
        /// </summary>
        /// <remarks>
        ///     Tests that entity creation and deletion events are properly triggered.
        /// </remarks>
        [Fact]
        public void EntityLifecycleEvents_Work()
        {
            // Arrange
            using Scene scene = new Scene();
            int createdCount = 0;
            int deletedCount = 0;

            scene.EntityCreated += (entity) => createdCount++;
            scene.EntityDeleted += (entity) => deletedCount++;

            // Act
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 1 });
            GameObject entity2 = scene.Create(new Position { X = 2, Y = 2 });
            entity1.Delete();

            // Assert
            Assert.Equal(2, createdCount);
            Assert.Equal(1, deletedCount);
        }

        /// <summary>
        ///     Tests that multiple scenes work independently
        /// </summary>
        /// <remarks>
        ///     Validates that multiple scenes can coexist and operate independently.
        /// </remarks>
        [Fact]
        public void MultipleScenes_WorkIndependently()
        {
            // Arrange
            using Scene scene1 = new Scene();
            using Scene scene2 = new Scene();

            // Act
            GameObject entity1 = scene1.Create(new Position { X = 1, Y = 1 });
            GameObject entity2 = scene2.Create(new Position { X = 2, Y = 2 });

            // Assert
            Assert.Equal(1, scene1.EntityCount);
            Assert.Equal(1, scene2.EntityCount);
            Assert.NotEqual(scene1.Id, scene2.Id);
        }

        /// <summary>
        ///     Tests that complex query with multiple components works
        /// </summary>
        /// <remarks>
        ///     Validates complex queries with multiple component requirements.
        /// </remarks>
        [Fact]
        public void ComplexQuery_WithMultipleComponents_Works()
        {
            // Arrange
            using Scene scene = new Scene();
            
            // Create entities with different component combinations
            scene.Create(new Position { X = 1, Y = 1 });
            scene.Create(new Position { X = 2, Y = 2 }, new Velocity { VX = 1, VY = 1 });
            scene.Create(new Position { X = 3, Y = 3 }, new Velocity { VX = 2, VY = 2 }, new Health { Value = 100 });

            // Act & Assert - Query with 3 components
            Query fullQuery = scene.Query<With<Position>, With<Velocity>, With<Health>>();
            int fullCount = 0;
            foreach (RefTuple<Position, Velocity, Health> _ in fullQuery.Enumerate<Position, Velocity, Health>())
            {
                fullCount++;
            }
            Assert.Equal(1, fullCount);

            // Query with 2 components
            Query partialQuery = scene.Query<With<Position>, With<Velocity>>();
            int partialCount = 0;
            foreach (RefTuple<Position, Velocity> _ in partialQuery.Enumerate<Position, Velocity>())
            {
                partialCount++;
            }
            Assert.Equal(2, partialCount);
        }

        /// <summary>
        ///     Tests that entity recycling works correctly
        /// </summary>
        /// <remarks>
        ///     Tests that entity IDs are properly recycled after deletion.
        /// </remarks>
        [Fact]
        public void EntityRecycling_WorksCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 1 });
            int originalEntityCount = scene.EntityCount;

            // Act - Delete and create new entity
            entity1.Delete();
            GameObject entity2 = scene.Create(new Position { X = 2, Y = 2 });

            // Assert
            Assert.Equal(originalEntityCount, scene.EntityCount);
            Assert.False(entity1.IsAlive);
            Assert.True(entity2.IsAlive);
        }

        /// <summary>
        ///     Tests that disabled entities are excluded from queries
        /// </summary>
        /// <remarks>
        ///     Validates that entities with Disable tag are excluded from normal queries.
        /// </remarks>
        [Fact]
        public void DisabledEntities_ExcludedFromQueries()
        {
            // Arrange
            using Scene scene = new Scene();
            
            GameObject activeEntity = scene.Create(new Position { X = 1, Y = 1 });
            GameObject disabledEntity = scene.Create(new Position { X = 2, Y = 2 });
            disabledEntity.Tag<Disable>();

            // Act
            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (RefTuple<Position> _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(2, count); // Only active entity counted
        }

        /// <summary>
        ///     Tests that create many creates correct number of entities
        /// </summary>
        /// <remarks>
        ///     Tests the CreateMany method for bulk entity creation.
        /// </remarks>
        [Fact]
        public void CreateMany_CreatesCorrectNumberOfEntities()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            ChunkTuple<Position> chunkTuple = scene.CreateMany<Position>(100);

            // Assert
            Assert.Equal(100, scene.EntityCount);
        }

        /// <summary>
        ///     Tests that component add and remove in same frame works
        /// </summary>
        /// <remarks>
        ///     Tests that components can be added and removed in the same update.
        /// </remarks>
        [Fact]
        public void ComponentAddAndRemove_InSameFrame_Works()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 1, Y = 1 });

            // Act
            entity.Add(new Health { Value = 50 });
            entity.Add(new Velocity { VX = 1, VY = 1 });
            entity.Remove<Position>();

            // Assert
            Assert.False(entity.Has<Position>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Velocity>());
        }
    }
}

