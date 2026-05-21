

using System;
using Alis.Core.Ecs.Exceptions;
using Alis.Core.Ecs.Kernel;
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
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            Assert.Throws<ComponentNotFoundException>(() => { entity.Remove<Position>(); });
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
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            entity.Delete();

            Assert.Throws<InvalidOperationException>(() => { entity.Remove<Position>(); });
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
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.Remove<Position>();

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
            using Scene scene = new Scene();
            Position originalPos = new Position {X = 42, Y = 84};
            GameObject entity = scene.Create(
                originalPos,
                new Velocity {X = 5, Y = 10}
            );

            entity.Remove<Velocity>();

            Assert.True(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.True(entity.TryGet(out Ref<Position> pos));
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
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {X = 3, Y = 4},
                new Health {Value = 100}
            );

            entity.Remove<Position>();
            entity.Remove<Velocity>();

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
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {X = 3, Y = 4}
            );

            entity.Remove<Position>();
            entity.Remove<Velocity>();

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
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            Query query = scene.Query<With<Position>>();
            int countBefore = 0;
            foreach (RefTuple<Position> _ in query.Enumerate<Position>())
            {
                countBefore++;
            }

            entity.Remove<Position>();

            int countAfter = 0;
            foreach (RefTuple<Position> _ in query.Enumerate<Position>())
            {
                countAfter++;
            }

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
            using Scene scene = new Scene();
            GameObject[] entities = new GameObject[100];
            for (int i = 0; i < 100; i++)
            {
                entities[i] = scene.Create(new Position {X = i, Y = i * 2});
            }

            for (int i = 0; i < 50; i++)
            {
                entities[i].Remove<Position>();
            }

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
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.Remove<Position>();

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
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.Remove<Position>();
            entity.Add(new Position {X = 10, Y = 20});

            Assert.True(entity.Has<Position>());
            Assert.True(entity.TryGet(out Ref<Position> pos));
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
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {X = 3, Y = 4},
                new Health {Value = 100},
                new Transform {X = 5, Y = 6, Rotation = 45}
            );

            entity.Remove<Position>();
            entity.Remove<Transform>();
            entity.Remove<Velocity>();
            entity.Remove<Health>();

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
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position {X = 1, Y = 2});
            GameObject entity2 = scene.Create(new Position {X = 3, Y = 4});

            entity1.Remove<Position>();

            Assert.False(entity1.Has<Position>());
            Assert.True(entity2.Has<Position>());
            Assert.True(entity2.TryGet(out Ref<Position> pos));
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
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4});
            GameObject entity2 = scene.Create(new Position {X = 5, Y = 6});
            GameObject entity3 = scene.Create(new Velocity {X = 7, Y = 8});

            entity1.Remove<Position>();
            entity2.Remove<Position>();
            entity3.Remove<Velocity>();

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
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {X = 3, Y = 4}
            );

            entity.Remove<Position>();

            Assert.Throws<ComponentNotFoundException>(() => { entity.Remove<Position>(); });
        }
    }
}