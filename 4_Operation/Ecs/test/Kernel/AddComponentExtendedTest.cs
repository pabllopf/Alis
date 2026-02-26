// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AddComponentExtendedTest.cs
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
using Alis.Core.Ecs.Exceptions;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     The add component extended test class
    /// </summary>
    /// <remarks>
    ///     Extended tests for the AddComponent functionality, covering additional
    ///     edge cases and integration scenarios.
    /// </remarks>
    public class AddComponentExtendedTest
    {
        /// <summary>
        ///     Tests that adding same component twice throws exception
        /// </summary>
        /// <remarks>
        ///     Validates that adding a component that already exists throws ComponentAlreadyExistsException.
        /// </remarks>
        [Fact]
        public void AddComponent_AddingSameComponentTwiceThrowsException()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 1, Y = 2 });

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                entity.Add(new Position { X = 3, Y = 4 });
            });
        }

        /// <summary>
        ///     Tests that adding component to dead entity throws
        /// </summary>
        /// <remarks>
        ///     Validates that adding a component to a dead entity throws an exception.
        /// </remarks>
        [Fact]
        public void AddComponent_AddingComponentToDeadEntityThrows()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            entity.Delete();

            // Act & Assert
            Assert.Throws<System.InvalidOperationException>(() =>
            {
                entity.Add(new Position { X = 1, Y = 2 });
            });
        }

        /// <summary>
        ///     Tests that adding multiple different components works
        /// </summary>
        /// <remarks>
        ///     Validates that multiple different components can be added to the same entity.
        /// </remarks>
        [Fact]
        public void AddComponent_AddingMultipleDifferentComponentsWorks()
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
        ///     Tests that added component data is accessible immediately
        /// </summary>
        /// <remarks>
        ///     Validates that the added component can be accessed right after addition.
        /// </remarks>
        [Fact]
        public void AddComponent_AddedComponentDataIsAccessibleImmediately()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            Position testPos = new Position { X = 42, Y = 84 };

            // Act
            entity.Add(testPos);

            // Assert
            Assert.True(entity.TryGet<Position>(out var pos));
            Assert.Equal(42, pos.Value.X);
            Assert.Equal(84, pos.Value.Y);
        }

        /// <summary>
        ///     Tests that adding component affects queries
        /// </summary>
        /// <remarks>
        ///     Validates that entities with newly added components are included in queries.
        /// </remarks>
        [Fact]
        public void AddComponent_AddingComponentAffectsQueries()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            int countBefore = 0;
            Query query = scene.Query<With<Position>>();
            foreach (var _ in query.Enumerate<Position>())
            {
                countBefore++;
            }

            // Act
            entity.Add(new Position { X = 1, Y = 2 });

            // Assert
            int countAfter = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                countAfter++;
            }

            Assert.Equal(0, countBefore);
            Assert.Equal(1, countAfter);
        }

        /// <summary>
        ///     Tests that adding component to entity with existing components works
        /// </summary>
        /// <remarks>
        ///     Validates that components can be added to entities that already have components.
        /// </remarks>
        [Fact]
        public void AddComponent_AddingComponentToEntityWithExistingComponentsWorks()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 1, Y = 2 });

            // Act
            entity.Add(new Velocity { VX = 3, VY = 4 });

            // Assert
            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.TryGet<Position>(out var pos));
            Assert.Equal(1, pos.Value.X);
        }

        /// <summary>
        ///     Tests that adding component preserves existing component data
        /// </summary>
        /// <remarks>
        ///     Validates that adding a new component doesn't modify existing ones.
        /// </remarks>
        [Fact]
        public void AddComponent_PreservesExistingComponentData()
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
        ///     Tests that adding component works with many entities
        /// </summary>
        /// <remarks>
        ///     Validates that adding components to entities scales well.
        /// </remarks>
        [Fact]
        public void AddComponent_WorksWithManyEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject[] entities = new GameObject[100];
            for (int i = 0; i < 100; i++)
            {
                entities[i] = scene.Create();
            }

            // Act
            for (int i = 0; i < 50; i++)
            {
                entities[i].Add(new Position { X = i, Y = i * 2 });
            }

            // Assert
            for (int i = 0; i < 50; i++)
            {
                Assert.True(entities[i].Has<Position>());
            }
            for (int i = 50; i < 100; i++)
            {
                Assert.False(entities[i].Has<Position>());
            }
        }

        /// <summary>
        ///     Tests that adding default component works
        /// </summary>
        /// <remarks>
        ///     Validates that components with default values can be added.
        /// </remarks>
        [Fact]
        public void AddComponent_AddingDefaultComponentWorks()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            // Act
            entity.Add(new Position());

            // Assert
            Assert.True(entity.Has<Position>());
            Assert.True(entity.TryGet<Position>(out var pos));
            Assert.Equal(0, pos.Value.X);
            Assert.Equal(0, pos.Value.Y);
        }

        /// <summary>
        ///     Tests that adding component after removal works
        /// </summary>
        /// <remarks>
        ///     Validates that a component can be re-added after removal.
        /// </remarks>
        [Fact]
        public void AddComponent_ReAddingComponentAfterRemovalWorks()
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
            Assert.Equal(20, pos.Value.Y);
        }

        /// <summary>
        ///     Tests that adding component sequence works
        /// </summary>
        /// <remarks>
        ///     Validates that a specific sequence of component additions works.
        /// </remarks>
        [Fact]
        public void AddComponent_SequenceOfAdditionsWorks()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            // Act
            entity.Add(new Position { X = 1, Y = 2 });
            entity.Add(new Velocity { VX = 3, VY = 4 });
            entity.Add(new Health { Value = 100 });
            entity.Add(new Transform { X = 5, Y = 6, Rotation = 45 });

            // Assert
            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Transform>());
        }

        /// <summary>
        ///     Tests that adding component is thread-safe within scene
        /// </summary>
        /// <remarks>
        ///     Validates that components can be added safely within the same scene context.
        /// </remarks>
        [Fact]
        public void AddComponent_CanBeUsedInMixedScenario()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 2 });
            GameObject entity2 = scene.Create(new Velocity { VX = 3, VY = 4 });
            GameObject entity3 = scene.Create();

            // Act
            entity1.Add(new Velocity { VX = 5, VY = 6 });
            entity2.Add(new Position { X = 7, Y = 8 });
            entity3.Add(new Position { X = 9, Y = 10 });
            entity3.Add(new Velocity { VX = 11, VY = 12 });

            // Assert
            Assert.True(entity1.Has<Position>());
            Assert.True(entity1.Has<Velocity>());
            Assert.True(entity2.Has<Position>());
            Assert.True(entity2.Has<Velocity>());
            Assert.True(entity3.Has<Position>());
            Assert.True(entity3.Has<Velocity>());
        }
    }
}

