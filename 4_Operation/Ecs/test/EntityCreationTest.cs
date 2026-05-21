

using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Tests for entity creation with various component combinations
    /// </summary>
    /// <remarks>
    ///     Validates that entities can be created with zero or more components,
    ///     and that component data is properly initialized.
    /// </remarks>
    public class EntityCreationTest
    {
        /// <summary>
        ///     Tests creating entity without components
        /// </summary>
        [Fact]
        public void Scene_CanCreateEmptyEntity()
        {
            using Scene scene = new Scene();

            GameObject entity = scene.Create();

            Assert.NotNull(entity);
            Assert.True(entity.IsAlive);
            Assert.False(entity.IsNull);
        }

        /// <summary>
        ///     Tests creating entity with single component
        /// </summary>
        [Fact]
        public void Scene_CanCreateEntityWithSingleComponent()
        {
            using Scene scene = new Scene();
            Position position = new Position {X = 10, Y = 20};

            GameObject entity = scene.Create(position);

            Assert.True(entity.IsAlive);
            Assert.True(entity.Has<Position>());
            ref Position retrievedPos = ref entity.Get<Position>();
            Assert.Equal(10, retrievedPos.X);
            Assert.Equal(20, retrievedPos.Y);
        }

        /// <summary>
        ///     Tests creating entity with two components
        /// </summary>
        [Fact]
        public void Scene_CanCreateEntityWithTwoComponents()
        {
            using Scene scene = new Scene();
            Position position = new Position {X = 5, Y = 15};
            Health health = new Health {Value = 100};

            GameObject entity = scene.Create(position, health);

            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Health>());
            Assert.Equal(5, entity.Get<Position>().X);
            Assert.Equal(100, entity.Get<Health>().Value);
        }

        /// <summary>
        ///     Tests creating multiple entities with same components
        /// </summary>
        [Fact]
        public void Scene_CanCreateMultipleEntitiesWithSameComponents()
        {
            using Scene scene = new Scene();

            GameObject entity1 = scene.Create(new Position {X = 1, Y = 2});
            GameObject entity2 = scene.Create(new Position {X = 3, Y = 4});
            GameObject entity3 = scene.Create(new Position {X = 5, Y = 6});

            Assert.True(entity1.IsAlive);
            Assert.True(entity2.IsAlive);
            Assert.True(entity3.IsAlive);
            Assert.Equal(1, entity1.Get<Position>().X);
            Assert.Equal(3, entity2.Get<Position>().X);
            Assert.Equal(5, entity3.Get<Position>().X);
        }

        /// <summary>
        ///     Tests entity IDs are unique
        /// </summary>
        [Fact]
        public void Scene_EntityIdsAreUnique()
        {
            using Scene scene = new Scene();

            GameObject entity1 = scene.Create();
            GameObject entity2 = scene.Create();
            GameObject entity3 = scene.Create();

            Assert.NotEqual(entity1.EntityID, entity2.EntityID);
            Assert.NotEqual(entity2.EntityID, entity3.EntityID);
            Assert.NotEqual(entity1.EntityID, entity3.EntityID);
        }

        /// <summary>
        ///     Tests that each scene has unique ID
        /// </summary>
        [Fact]
        public void Scene_EachSceneHasUniqueId()
        {
            using Scene scene1 = new Scene();
            using Scene scene2 = new Scene();

            Assert.NotEqual(scene1.Id, scene2.Id);
        }

        /// <summary>
        ///     Tests creating entity with three components
        /// </summary>
        [Fact]
        public void Scene_CanCreateEntityWithThreeComponents()
        {
            using Scene scene = new Scene();

            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Health {Value = 50},
                new Velocity {X = 3, Y = 4});

            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Velocity>());
        }

        /// <summary>
        ///     Tests that created entity belongs to correct scene
        /// </summary>
        [Fact]
        public void Scene_CreatedEntityBelongsToCorrectScene()
        {
            using Scene scene1 = new Scene();
            using Scene scene2 = new Scene();

            GameObject entity1 = scene1.Create(new Position());
            GameObject entity2 = scene2.Create(new Position());

            Assert.Same(scene1, entity1.Scene);
            Assert.Same(scene2, entity2.Scene);
            Assert.NotSame(entity1.Scene, entity2.Scene);
        }
    }
}