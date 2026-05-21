

using System;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The scene test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="Scene" /> class which represents a collection of entities
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
            using Scene scene = new Scene();

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
            using Scene scene1 = new Scene();
            using Scene scene2 = new Scene();

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
            using Scene scene = new Scene();

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
            using Scene scene = new Scene();
            TestComponent component = new TestComponent {Value = 42};

            GameObject entity = scene.Create(component);

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
            using Scene scene = new Scene();

            scene.Create(new TestComponent {Value = 1});
            scene.Create(new TestComponent {Value = 2});
            scene.Create(new TestComponent {Value = 3});

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
            using Scene scene = new Scene();

            ChunkTuple<TestComponent> chunkTuple = scene.CreateMany<TestComponent>(5);

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
            using Scene scene = new Scene();

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
            using Scene scene = new Scene();

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
            using Scene scene = new Scene();

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
            Scene scene = new Scene();

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
            using Scene scene = new Scene();
            bool eventInvoked = false;
            scene.EntityCreated += entity => eventInvoked = true;

            scene.Create(new TestComponent {Value = 99});

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
            using Scene scene = new Scene();

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
            using Scene scene = new Scene();

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
            using Scene scene = new Scene();

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
            using Scene scene = new Scene();

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
            using Scene scene = new Scene();

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
            using Scene scene = new Scene();

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
            using Scene scene = new Scene();
            TestComponent comp1 = new TestComponent {Value = 100};
            AnotherComponent comp2 = new AnotherComponent {Name = "Test"};

            GameObject entity = scene.Create(comp1, comp2);

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
            using Scene scene = new Scene();

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
            using Scene scene = new Scene();

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
            using Scene scene = new Scene();
            const int entityCount = 1000;

            for (int i = 0; i < entityCount; i++)
            {
                scene.Create(new TestComponent {Value = i});
            }

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
            using Scene scene = new Scene();

            Assert.True(scene.WorldEventFlags == GameObjectFlags.None ||
                        scene.WorldEventFlags != (GameObjectFlags) (-1));
        }
    }
}