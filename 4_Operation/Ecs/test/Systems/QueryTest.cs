// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QueryTest.cs
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

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    ///     The query test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="Query"/> class which represents a set of entities
    ///     from a scene that can be efficiently queried and iterated.
    /// </remarks>
    public class QueryTest
    {
        /// <summary>
        ///     Tests that query can be created from scene
        /// </summary>
        /// <remarks>
        ///     Verifies that a Query can be created from a Scene.
        /// </remarks>
        [Fact]
        public void Query_CanBeCreatedFromScene()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            Query query = scene.Query<With<Position>>();

            // Assert
            Assert.NotNull(query);
        }

        /// <summary>
        ///     Tests that query can enumerate entities with single component
        /// </summary>
        /// <remarks>
        ///     Tests that Query can enumerate entities that have a specific component.
        /// </remarks>
        [Fact]
        public void Query_CanEnumerateEntitiesWithSingleComponent()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 });
            scene.Create(new Position { X = 3, Y = 4 });

            // Act
            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (var position in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that query can enumerate entities with multiple components
        /// </summary>
        /// <remarks>
        ///     Tests that Query can enumerate entities that have multiple components.
        /// </remarks>
        [Fact]
        public void Query_CanEnumerateEntitiesWithMultipleComponents()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 }, new Velocity { VX = 0.5f, VY = 0.5f });
            scene.Create(new Position { X = 3, Y = 4 }, new Velocity { VX = 1.0f, VY = 1.0f });
            scene.Create(new Position { X = 5, Y = 6 }); // This entity should not match

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>>();
            int count = 0;
            foreach (var (position, velocity) in query.Enumerate<Position, Velocity>())
            {
                count++;
            }

            // Assert
            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that query enumerate with entities returns game object
        /// </summary>
        /// <remarks>
        ///     Validates that EnumerateWithEntities returns both components and GameObjects.
        /// </remarks>
        [Fact]
        public void Query_EnumerateWithEntities_ReturnsGameObject()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 10, Y = 20 });

            // Act
            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (var (entity, position) in query.EnumerateWithEntities<Position>())
            {
                Assert.False(entity.IsNull);
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that query does not enumerate entities without required component
        /// </summary>
        /// <remarks>
        ///     Tests that Query only enumerates entities that have all required components.
        /// </remarks>
        [Fact]
        public void Query_DoesNotEnumerateEntitiesWithoutRequiredComponent()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 });
            scene.Create(new Velocity { VX = 1, VY = 1 });

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity>())
            {
                count++;
            }

            // Assert
            Assert.Equal(0, count);
        }
        

        /// <summary>
        ///     Tests that query excludes disabled entities by default
        /// </summary>
        /// <remarks>
        ///     Validates that Query excludes entities with the Disable tag by default.
        /// </remarks>
        [Fact]
        public void Query_ExcludesDisabledEntitiesByDefault()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 });
            GameObject disabledEntity = scene.Create(new Position { X = 3, Y = 4 });
            disabledEntity.Tag<Disable>();

            // Act
            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that query with include disabled includes disabled entities
        /// </summary>
        /// <remarks>
        ///     Tests that Query includes disabled entities when IncludeDisabled is specified.
        /// </remarks>
        [Fact]
        public void Query_WithIncludeDisabled_IncludesDisabledEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 });
            GameObject disabledEntity = scene.Create(new Position { X = 3, Y = 4 });
            disabledEntity.Tag<Disable>();

            // Act
            Query query = scene.Query<With<Position>, With<IncludeDisabled>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(0, count);
        }

        /// <summary>
        ///     Tests that query handles empty result set
        /// </summary>
        /// <remarks>
        ///     Tests that Query properly handles cases where no entities match.
        /// </remarks>
        [Fact]
        public void Query_HandlesEmptyResultSet()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 });

            // Act
            Query query = scene.Query<With<Velocity>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Velocity>())
            {
                count++;
            }

            // Assert
            Assert.Equal(0, count);
        }

        /// <summary>
        ///     Tests that query can enumerate with three components
        /// </summary>
        /// <remarks>
        ///     Tests that Query works with three component types.
        /// </remarks>
        [Fact]
        public void Query_CanEnumerateWithThreeComponents()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(
                new Position { X = 1, Y = 2 }, 
                new Velocity { VX = 0.5f, VY = 0.5f },
                new Health { Value = 100 }
            );

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();
            int count = 0;
            foreach (var (positionRef, velocityRef, healthRef) in query.Enumerate<Position, Velocity, Health>())
            {
                Assert.True(healthRef.Value.Value > 0);
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that query enumerate chunks returns chunk data
        /// </summary>
        /// <remarks>
        ///     Tests that EnumerateChunks method provides access to chunked component data.
        /// </remarks>
        [Fact]
        public void Query_EnumerateChunks_ReturnsChunkData()
        {
            // Arrange
            using Scene scene = new Scene();
            for (int i = 0; i < 5; i++)
            {
                scene.Create(new Position { X = i, Y = i * 2 });
            }

            // Act
            Query query = scene.Query<With<Position>>();
            int chunkCount = 0;
            foreach (var chunk in query.EnumerateChunks<Position>())
            {
                chunkCount++;
                Assert.True(chunk.Span.Length > 0);
            }

            // Assert
            Assert.True(chunkCount > 0);
        }

        /// <summary>
        ///     Tests that query enumerate only returns entities
        /// </summary>
        /// <remarks>
        ///     Tests that EnumerateWithEntities with no type parameters returns only entities.
        /// </remarks>
        [Fact]
        public void Query_EnumerateOnly_ReturnsEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 });
            scene.Create(new Position { X = 3, Y = 4 });

            // Act
            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (var entity in query.EnumerateWithEntities())
            {
                Assert.False(entity.IsNull);
                count++;
            }

            // Assert
            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that query handles dynamically added entities
        /// </summary>
        /// <remarks>
        ///     Tests that Query properly handles entities added during iteration (in a new iteration).
        /// </remarks>
        [Fact]
        public void Query_HandlesDynamicallyAddedEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 });

            // Act
            Query query = scene.Query<With<Position>>();
            int firstCount = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                firstCount++;
            }

            scene.Create(new Position { X = 3, Y = 4 });
            int secondCount = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                secondCount++;
            }

            // Assert
            Assert.Equal(1, firstCount);
            Assert.Equal(2, secondCount);
        }
    }
}

