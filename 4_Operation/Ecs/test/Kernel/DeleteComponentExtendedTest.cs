// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DeleteComponentExtendedTest.cs
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

using Alis.Core.Ecs.Exceptions;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     The delete component extended test class
    /// </summary>
    /// <remarks>
    ///     Extended tests for the DeleteComponent functionality, covering edge cases
    ///     and integration scenarios for component removal.
    /// </remarks>
    public class DeleteComponentExtendedTest
    {
        /// <summary>
        ///     Tests that removing non-existent component throws exception
        /// </summary>
        /// <remarks>
        ///     Validates that removing a component that doesn't exist throws ComponentNotFoundException.
        /// </remarks>
        [Fact]
        public void DeleteComponent_RemovingNonExistentComponentThrowsException()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            // Act & Assert
            Assert.Throws<ComponentNotFoundException>(() =>
            {
                entity.Remove<Position>();
            });
        }

        /// <summary>
        ///     Tests that removing component from dead entity throws
        /// </summary>
        /// <remarks>
        ///     Validates that removing a component from a dead entity throws an exception.
        /// </remarks>
        [Fact]
        public void DeleteComponent_RemovingComponentFromDeadEntityThrows()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 1, Y = 2 });
            entity.Delete();

            // Act & Assert
            Assert.Throws<System.InvalidOperationException>(() =>
            {
                entity.Remove<Position>();
            });
        }

        /// <summary>
        ///     Tests that removing single component works
        /// </summary>
        /// <remarks>
        ///     Validates that a component can be removed from an entity.
        /// </remarks>
        [Fact]
        public void DeleteComponent_RemovingSingleComponentWorks()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 1, Y = 2 });

            // Act
            entity.Remove<Position>();

            // Assert
            Assert.False(entity.Has<Position>());
            Assert.True(entity.IsAlive);
        }

        /// <summary>
        ///     Tests that removing component preserves other components
        /// </summary>
        /// <remarks>
        ///     Validates that removing a component doesn't affect other components.
        /// </remarks>
        [Fact]
        public void DeleteComponent_PreservesOtherComponents()
        {
            // Arrange
            using Scene scene = new Scene();
            Position originalPos = new Position { X = 42, Y = 84 };
            GameObject entity = scene.Create(
                originalPos,
                new Velocity { VX = 5, VY = 10 }
            );

            // Act
            entity.Remove<Velocity>();

            // Assert
            Assert.True(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.True(entity.TryGet<Position>(out var pos));
            Assert.Equal(42, pos.Value.X);
        }

        /// <summary>
        ///     Tests that removing multiple components works
        /// </summary>
        /// <remarks>
        ///     Validates that multiple components can be removed sequentially.
        /// </remarks>
        [Fact]
        public void DeleteComponent_RemovingMultipleComponentsWorks()
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
        ///     Tests that removing all components works
        /// </summary>
        /// <remarks>
        ///     Validates that all components can be removed, leaving an empty entity.
        /// </remarks>
        [Fact]
        public void DeleteComponent_RemovingAllComponentsWorks()
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
            Assert.False(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.True(entity.IsAlive);
        }

        /// <summary>
        ///     Tests that removing component affects queries
        /// </summary>
        /// <remarks>
        ///     Validates that entities with removed components are excluded from queries.
        /// </remarks>
        [Fact]
        public void DeleteComponent_RemovingComponentAffectsQueries()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 1, Y = 2 });

            // Act
            Query query = scene.Query<With<Position>>();
            int countBefore = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                countBefore++;
            }

            entity.Remove<Position>();

            int countAfter = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                countAfter++;
            }

            // Assert
            Assert.Equal(1, countBefore);
            Assert.Equal(0, countAfter);
        }

        /// <summary>
        ///     Tests that removing component works with many entities
        /// </summary>
        /// <remarks>
        ///     Validates that component removal scales well with many entities.
        /// </remarks>
        [Fact]
        public void DeleteComponent_WorksWithManyEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject[] entities = new GameObject[100];
            for (int i = 0; i < 100; i++)
            {
                entities[i] = scene.Create(new Position { X = i, Y = i * 2 });
            }

            // Act
            for (int i = 0; i < 50; i++)
            {
                entities[i].Remove<Position>();
            }

            // Assert
            for (int i = 0; i < 50; i++)
            {
                Assert.False(entities[i].Has<Position>());
            }
            for (int i = 50; i < 100; i++)
            {
                Assert.True(entities[i].Has<Position>());
            }
        }

        /// <summary>
        ///     Tests that removed component cannot be accessed
        /// </summary>
        /// <remarks>
        ///     Validates that accessing a removed component throws an exception.
        /// </remarks>
        [Fact]
        public void DeleteComponent_RemovedComponentCannotBeAccessed()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 1, Y = 2 });

            // Act
            entity.Remove<Position>();

            // Assert
            Assert.False(entity.TryGet<Position>(out _));
        }

        /// <summary>
        ///     Tests that removing and re-adding component works
        /// </summary>
        /// <remarks>
        ///     Validates that a component can be re-added after removal.
        /// </remarks>
        [Fact]
        public void DeleteComponent_ReAddingComponentAfterRemovalWorks()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 1, Y = 2 });

            // Act
            entity.Remove<Position>();
            entity.Add(new Position { X = 10, Y = 20 });

            // Assert
            Assert.True(entity.Has<Position>());
            Assert.True(entity.TryGet<Position>(out var pos));
            Assert.Equal(10, pos.Value.X);
        }

        /// <summary>
        ///     Tests that removing component sequence works
        /// </summary>
        /// <remarks>
        ///     Validates that a specific sequence of component removals works.
        /// </remarks>
        [Fact]
        public void DeleteComponent_SequenceOfRemovalsWorks()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position { X = 1, Y = 2 },
                new Velocity { VX = 3, VY = 4 },
                new Health { Value = 100 },
                new Transform { X = 5, Y = 6, Rotation = 45 }
            );

            // Act
            entity.Remove<Position>();
            entity.Remove<Transform>();
            entity.Remove<Velocity>();
            entity.Remove<Health>();

            // Assert
            Assert.False(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
            Assert.False(entity.Has<Transform>());
        }

        /// <summary>
        ///     Tests that other entities are unaffected by removal
        /// </summary>
        /// <remarks>
        ///     Validates that removing a component from one entity doesn't affect others.
        /// </remarks>
        [Fact]
        public void DeleteComponent_OtherEntitiesAreUnaffected()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 2 });
            GameObject entity2 = scene.Create(new Position { X = 3, Y = 4 });

            // Act
            entity1.Remove<Position>();

            // Assert
            Assert.False(entity1.Has<Position>());
            Assert.True(entity2.Has<Position>());
            Assert.True(entity2.TryGet<Position>(out var pos));
            Assert.Equal(3, pos.Value.X);
        }

        /// <summary>
        ///     Tests that removing component in mixed scenario works
        /// </summary>
        /// <remarks>
        ///     Validates that component removal works in complex scenarios.
        /// </remarks>
        [Fact]
        public void DeleteComponent_WorksInMixedScenario()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 2 }, new Velocity { VX = 3, VY = 4 });
            GameObject entity2 = scene.Create(new Position { X = 5, Y = 6 });
            GameObject entity3 = scene.Create(new Velocity { VX = 7, VY = 8 });

            // Act
            entity1.Remove<Position>();
            entity2.Remove<Position>();
            entity3.Remove<Velocity>();

            // Assert
            Assert.False(entity1.Has<Position>());
            Assert.True(entity1.Has<Velocity>());
            Assert.False(entity2.Has<Position>());
            Assert.False(entity3.Has<Velocity>());
        }

        /// <summary>
        ///     Tests that removing component is idempotent within transactions
        /// </summary>
        /// <remarks>
        ///     Validates that component removal handles edge cases properly.
        /// </remarks>
        [Fact]
        public void DeleteComponent_RemovedComponentIsGone()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position { X = 1, Y = 2 },
                new Velocity { VX = 3, VY = 4 }
            );

            // Act
            entity.Remove<Position>();

            // Assert - Trying to remove it again should throw
            Assert.Throws<ComponentNotFoundException>(() =>
            {
                entity.Remove<Position>();
            });
        }
    }
}

