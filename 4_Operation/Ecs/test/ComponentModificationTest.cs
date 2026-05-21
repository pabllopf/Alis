

using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Tests for adding and removing components on existing entities
    /// </summary>
    /// <remarks>
    ///     Validates that components can be dynamically added to or removed from
    ///     entities, and that queries correctly reflect these changes.
    /// </remarks>
    public class ComponentModificationTest
    {
        /// <summary>
        ///     Tests adding component to entity
        /// </summary>
        [Fact]
        public void GameObject_CanAddComponent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            Assert.False(entity.Has<Position>());

            entity.Add(new Position {X = 10, Y = 20});

            Assert.True(entity.Has<Position>());
            Assert.Equal(10, entity.Get<Position>().X);
        }

        /// <summary>
        ///     Tests removing component from entity
        /// </summary>
        [Fact]
        public void GameObject_CanRemoveComponent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 10}, new Health {Value = 100});
            Assert.True(entity.Has<Position>());

            entity.Remove<Position>();

            Assert.False(entity.Has<Position>());
            Assert.True(entity.Has<Health>());
        }

        /// <summary>
        ///     Tests adding and removing component updates queries
        /// </summary>
        [Fact]
        public void Query_ReflectsComponentAddition()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            Query query = scene.Query<With<Position>>();

            entity.Add(new Position {X = 5});

            int count = 0;
            foreach (Ecs.Systems.GameObjectRefTuple<Position> _ in query.EnumerateWithEntities<Position>())
            {
                count++;
            }

            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests removing component updates queries
        /// </summary>
        [Fact]
        public void Query_ReflectsComponentRemoval()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 5});
            Query query = scene.Query<With<Position>>();

            entity.Remove<Position>();

            int count = 0;
            foreach (Ecs.Systems.GameObjectRefTuple<Position> _ in query.EnumerateWithEntities<Position>())
            {
                count++;
            }

            Assert.Equal(0, count);
        }

        /// <summary>
        ///     Tests adding multiple components sequentially
        /// </summary>
        [Fact]
        public void GameObject_CanAddMultipleComponentsSequentially()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.Add(new Position {X = 1});
            entity.Add(new Health {Value = 100});
            entity.Add(new Velocity {X = 2});

            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Velocity>());
        }

        /// <summary>
        ///     Tests removing multiple components
        /// </summary>
        [Fact]
        public void GameObject_CanRemoveMultipleComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1},
                new Health {Value = 100},
                new Velocity {X = 2});

            entity.Remove<Position>();
            entity.Remove<Velocity>();

            Assert.False(entity.Has<Position>());
            Assert.True(entity.Has<Health>());
            Assert.False(entity.Has<Velocity>());
        }

        /// <summary>
        ///     Tests component data preserved when other components added
        /// </summary>
        [Fact]
        public void GameObject_ComponentDataPreservedWhenAddingOtherComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 10, Y = 20});

            entity.Add(new Health {Value = 100});

            ref Position pos = ref entity.Get<Position>();
            Assert.Equal(10, pos.X);
            Assert.Equal(20, pos.Y);
            Assert.Equal(100, entity.Get<Health>().Value);
        }


        /// <summary>
        ///     Tests adding component to multiple entities
        /// </summary>
        [Fact]
        public void Scene_CanAddComponentToMultipleEntities()
        {
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create();
            GameObject entity2 = scene.Create();

            entity1.Add(new Position {X = 1});
            entity2.Add(new Position {X = 2});

            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (Ecs.Systems.GameObjectRefTuple<Position> _ in query.EnumerateWithEntities<Position>())
            {
                count++;
            }

            Assert.Equal(2, count);
        }
    }
}