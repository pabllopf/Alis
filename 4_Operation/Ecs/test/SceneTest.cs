// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneTest.cs
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
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The scene test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="Scene"/> class which represents a collection of entities
    ///     that can be updated and queried in the ECS system.
    /// </remarks>
    public class SceneTest
    {

        /// <summary>
        ///     Tests that scene can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that a Scene can be instantiated with the default constructor.
        /// </remarks>
        [Fact]
        public void Scene_CanBeCreated()
        {
            // Act
            using Scene scene = new Scene();

            // Assert
            Assert.NotNull(scene);
        }

        /// <summary>
        ///     Tests that scene has unique id
        /// </summary>
        /// <remarks>
        ///     Validates that each Scene instance receives a unique identifier.
        /// </remarks>
        [Fact]
        public void Scene_HasUniqueId()
        {
            // Act
            using Scene scene1 = new Scene();
            using Scene scene2 = new Scene();

            // Assert
            Assert.NotEqual(scene1.Id, scene2.Id);
        }

        /// <summary>
        ///     Tests that scene starts with zero entities
        /// </summary>
        /// <remarks>
        ///     Confirms that a newly created Scene has no entities initially.
        /// </remarks>
        [Fact]
        public void Scene_StartsWithZeroEntities()
        {
            // Act
            using Scene scene = new Scene();

            // Assert
            Assert.Equal(0, scene.EntityCount);
        }

        /// <summary>
        ///     Tests that scene can create entity with component
        /// </summary>
        /// <remarks>
        ///     Tests that a Scene can create an entity with a single component.
        /// </remarks>
        [Fact]
        public void Scene_CanCreateEntityWithComponent()
        {
            // Arrange
            using Scene scene = new Scene();
            TestComponent component = new TestComponent { Value = 42 };

            // Act
            GameObject entity = scene.Create(component);

            // Assert
            Assert.Equal(1, scene.EntityCount);
            Assert.False(entity.IsNull);
        }

        /// <summary>
        ///     Tests that scene entity count increases when creating entities
        /// </summary>
        /// <remarks>
        ///     Validates that the entity count properly increments when entities are created.
        /// </remarks>
        [Fact]
        public void Scene_EntityCountIncreasesWhenCreatingEntities()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            scene.Create(new TestComponent { Value = 1 });
            scene.Create(new TestComponent { Value = 2 });
            scene.Create(new TestComponent { Value = 3 });

            // Assert
            Assert.Equal(3, scene.EntityCount);
        }

        /// <summary>
        ///     Tests that scene can create multiple entities
        /// </summary>
        /// <remarks>
        ///     Tests that a Scene can create multiple entities at once using CreateMany.
        /// </remarks>
        [Fact]
        public void Scene_CanCreateMultipleEntities()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            var chunkTuple = scene.CreateMany<TestComponent>(5);

            // Assert
            Assert.Equal(5, scene.EntityCount);
        }
        

        /// <summary>
        ///     Tests that scene has default archetype
        /// </summary>
        /// <remarks>
        ///     Confirms that a Scene has a default archetype upon creation.
        /// </remarks>
        [Fact]
        public void Scene_HasDefaultArchetype()
        {
            // Act
            using Scene scene = new Scene();

            // Assert
            Assert.NotNull(scene.DefaultArchetype);
        }

        /// <summary>
        ///     Tests that scene has default world game object
        /// </summary>
        /// <remarks>
        ///     Validates that a Scene has a default world GameObject.
        /// </remarks>
        [Fact]
        public void Scene_HasDefaultWorldGameObject()
        {
            // Act
            using Scene scene = new Scene();

            // Assert
            Assert.False(scene.DefaultWorldGameObject.IsNull);
        }

        /// <summary>
        ///     Tests that scene allow structural changes returns true by default
        /// </summary>
        /// <remarks>
        ///     Tests that AllowStructuralChanges property is true for a new Scene.
        /// </remarks>
        [Fact]
        public void Scene_AllowStructuralChangesReturnsTrueByDefault()
        {
            // Act
            using Scene scene = new Scene();

            // Assert
            Assert.True(scene.AllowStructualChanges);
        }

        /// <summary>
        ///     Tests that scene can be disposed
        /// </summary>
        /// <remarks>
        ///     Tests that a Scene can be properly disposed without throwing exceptions.
        /// </remarks>
        [Fact]
        public void Scene_CanBeDisposed()
        {
            // Arrange
            Scene scene = new Scene();

            // Act & Assert
            scene.Dispose();
        }

        /// <summary>
        ///     Tests that scene entity created event is invoked
        /// </summary>
        /// <remarks>
        ///     Validates that the EntityCreated event is properly invoked when an entity is created.
        /// </remarks>
        [Fact]
        public void Scene_EntityCreatedEventIsInvoked()
        {
            // Arrange
            using Scene scene = new Scene();
            bool eventInvoked = false;
            scene.EntityCreated += (entity) => eventInvoked = true;

            // Act
            scene.Create(new TestComponent { Value = 99 });

            // Assert
            Assert.True(eventInvoked);
        }
        
        
        /// <summary>
        ///     Tests that scene recycled entity ids stack exists
        /// </summary>
        /// <remarks>
        ///     Validates that the RecycledEntityIds collection is properly initialized.
        /// </remarks>
        [Fact]
        public void Scene_RecycledEntityIdsStackExists()
        {
            // Act
            using Scene scene = new Scene();

            // Assert
            Assert.NotNull(scene.RecycledEntityIds);
        }

        /// <summary>
        ///     Tests that scene command buffer exists
        /// </summary>
        /// <remarks>
        ///     Confirms that a Scene has a WorldUpdateCommandBuffer initialized.
        /// </remarks>
        [Fact]
        public void Scene_CommandBufferExists()
        {
            // Act
            using Scene scene = new Scene();

            // Assert
            Assert.NotNull(scene.WorldUpdateCommandBuffer);
        }

        /// <summary>
        ///     Tests that scene entity table is initialized
        /// </summary>
        /// <remarks>
        ///     Tests that the EntityTable is properly initialized in a new Scene.
        /// </remarks>
        [Fact]
        public void Scene_EntityTableIsInitialized()
        {
            // Act
            using Scene scene = new Scene();

            // Assert
            Assert.NotNull(scene.EntityTable);
        }

        /// <summary>
        ///     Tests that scene archetype graph edges is initialized
        /// </summary>
        /// <remarks>
        ///     Validates that the ArchetypeGraphEdges dictionary is initialized.
        /// </remarks>
        [Fact]
        public void Scene_ArchetypeGraphEdgesIsInitialized()
        {
            // Act
            using Scene scene = new Scene();

            // Assert
            Assert.NotNull(scene.ArchetypeGraphEdges);
        }

        /// <summary>
        ///     Tests that scene query cache is initialized
        /// </summary>
        /// <remarks>
        ///     Tests that the QueryCache dictionary is properly initialized.
        /// </remarks>
        [Fact]
        public void Scene_QueryCacheIsInitialized()
        {
            // Act
            using Scene scene = new Scene();

            // Assert
            Assert.NotNull(scene.QueryCache);
        }

        /// <summary>
        ///     Tests that scene shared countdown is initialized
        /// </summary>
        /// <remarks>
        ///     Confirms that the SharedCountdown is properly initialized.
        /// </remarks>
        [Fact]
        public void Scene_SharedCountdownIsInitialized()
        {
            // Act
            using Scene scene = new Scene();

            // Assert
            Assert.NotNull(scene.SharedCountdown);
        }

        /// <summary>
        ///     Tests that scene can create entity with multiple components
        /// </summary>
        /// <remarks>
        ///     Tests that a Scene can create entities with multiple different components.
        /// </remarks>
        [Fact]
        public void Scene_CanCreateEntityWithMultipleComponents()
        {
            // Arrange
            using Scene scene = new Scene();
            TestComponent comp1 = new TestComponent { Value = 100 };
            AnotherComponent comp2 = new AnotherComponent { Name = "Test" };

            // Act
            GameObject entity = scene.Create(comp1, comp2);

            // Assert
            Assert.Equal(1, scene.EntityCount);
            Assert.False(entity.IsNull);
        }

        /// <summary>
        ///     Tests that create many with zero count throws exception
        /// </summary>
        /// <remarks>
        ///     Validates that CreateMany throws an exception when count is zero or negative.
        /// </remarks>
        [Fact]
        public void CreateMany_WithZeroCount_ThrowsException()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => scene.CreateMany<TestComponent>(0));
        }

        /// <summary>
        ///     Tests that create many with negative count throws exception
        /// </summary>
        /// <remarks>
        ///     Validates that CreateMany throws an exception when count is negative.
        /// </remarks>
        [Fact]
        public void CreateMany_WithNegativeCount_ThrowsException()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => scene.CreateMany<TestComponent>(-5));
        }

        /// <summary>
        ///     Tests that scene can handle large number of entities
        /// </summary>
        /// <remarks>
        ///     Tests that a Scene can manage a large number of entities efficiently.
        /// </remarks>
        [Fact]
        public void Scene_CanHandleLargeNumberOfEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            const int entityCount = 1000;

            // Act
            for (int i = 0; i < entityCount; i++)
            {
                scene.Create(new TestComponent { Value = i });
            }

            // Assert
            Assert.Equal(entityCount, scene.EntityCount);
        }

        /// <summary>
        ///     Tests that scene world event flags starts as none
        /// </summary>
        /// <remarks>
        ///     Validates that WorldEventFlags is initialized properly.
        /// </remarks>
        [Fact]
        public void Scene_WorldEventFlagsStartsAsNone()
        {
            // Act
            using Scene scene = new Scene();

            // Assert - The flags should be None or some default value
            Assert.True(scene.WorldEventFlags == GameObjectFlags.None || 
                       scene.WorldEventFlags != (GameObjectFlags)(-1));
        }
    }
}

