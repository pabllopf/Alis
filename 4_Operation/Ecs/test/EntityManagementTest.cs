

using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The entity management test class
    /// </summary>
    /// <remarks>
    ///     Tests for entity lifecycle management including creation, deletion,
    ///     and state tracking of entities in scenes.
    /// </remarks>
    public class EntityManagementTest
    {
        /// <summary>
        ///     Tests that entities can be created with components
        /// </summary>
        /// <remarks>
        ///     Validates that entities can be created with initial components.
        /// </remarks>
        [Fact]
        public void Entity_CanBeCreatedWithComponent()
        {
            using Scene scene = new Scene();

            GameObject entity = scene.Create(new Position {X = 5, Y = 10});

            Assert.False(entity.IsNull);
            Assert.True(entity.IsAlive);
            Assert.True(entity.Has<Position>());
        }

        /// <summary>
        ///     Tests that entities can be deleted
        /// </summary>
        /// <remarks>
        ///     Tests that entities can be deleted and become no longer alive.
        /// </remarks>
        [Fact]
        public void Entity_CanBeDeleted()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 0, Y = 0});

            entity.Delete();

            Assert.False(entity.IsAlive);
        }

        /// <summary>
        ///     Tests that entity count reflects entities in scene
        /// </summary>
        /// <remarks>
        ///     Validates that the scene entity count is accurate.
        /// </remarks>
        [Fact]
        public void Scene_EntityCountIsAccurate()
        {
            using Scene scene = new Scene();

            int initialCount = scene.EntityCount;
            scene.Create(new Position {X = 0, Y = 0});
            int afterCreate = scene.EntityCount;

            GameObject entity = scene.Create(new Position {X = 1, Y = 1});
            int afterSecond = scene.EntityCount;

            entity.Delete();
            int afterDelete = scene.EntityCount;

            Assert.Equal(0, initialCount);
            Assert.Equal(1, afterCreate);
            Assert.Equal(2, afterSecond);
            Assert.Equal(1, afterDelete);
        }

        /// <summary>
        ///     Tests that null entity is null
        /// </summary>
        /// <remarks>
        ///     Validates that the default entity is null.
        /// </remarks>
        [Fact]
        public void Entity_DefaultIsNull()
        {
            GameObject entity = default(GameObject);

            Assert.True(entity.IsNull);
            Assert.False(entity.IsAlive);
        }

        /// <summary>
        ///     Tests that entity IDs are unique
        /// </summary>
        /// <remarks>
        ///     Validates that each entity receives a unique ID.
        /// </remarks>
        [Fact]
        public void Entity_IdsAreUnique()
        {
            using Scene scene = new Scene();

            GameObject entity1 = scene.Create(new Position {X = 0, Y = 0});
            GameObject entity2 = scene.Create(new Position {X = 1, Y = 1});

            Assert.NotEqual(entity1.EntityID, entity2.EntityID);
        }

        /// <summary>
        ///     Tests that multiple entities with same components work
        /// </summary>
        /// <remarks>
        ///     Validates that multiple entities with identical components
        ///     are handled correctly.
        /// </remarks>
        [Fact]
        public void Scene_CanHaveMultipleEntitiesWithSameComponents()
        {
            using Scene scene = new Scene();

            GameObject entity1 = scene.Create(new Position {X = 0, Y = 0});
            GameObject entity2 = scene.Create(new Position {X = 1, Y = 1});
            GameObject entity3 = scene.Create(new Position {X = 2, Y = 2});

            Assert.Equal(3, scene.EntityCount);
            Assert.True(entity1.Has<Position>());
            Assert.True(entity2.Has<Position>());
            Assert.True(entity3.Has<Position>());
        }

        /// <summary>
        ///     Tests that bulk entity creation works
        /// </summary>
        /// <remarks>
        ///     Tests that many entities can be created efficiently.
        /// </remarks>
        [Fact]
        public void Scene_CanCreateManyEntities()
        {
            using Scene scene = new Scene();
            const int count = 100;

            for (int i = 0; i < count; i++)
            {
                scene.Create(new Position {X = i, Y = i});
            }

            Assert.Equal(count, scene.EntityCount);
        }
    }
}