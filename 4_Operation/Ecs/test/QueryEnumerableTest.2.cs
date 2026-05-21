

using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The query enumerable test class
    /// </summary>
    /// <remarks>
    ///     Tests for QueryEnumerable with 2 component types.
    /// </remarks>
    public partial class QueryEnumerableTest
    {
        /// <summary>
        ///     Tests that query enumerable with two components can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that QueryEnumerable with 2 components can be instantiated.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithTwoComponents_CanBeCreated()
        {
            using Scene scene = new Scene();
            Query query = scene.Query<With<Position>, With<Velocity>>();

            QueryEnumerator<Position, Velocity>.QueryEnumerable enumerable = query.Enumerate<Position, Velocity>();

            Assert.NotEqual(default(QueryEnumerator<Position, Velocity>.QueryEnumerable), enumerable);
        }

        /// <summary>
        ///     Tests that query enumerable with two components can be used in foreach
        /// </summary>
        /// <remarks>
        ///     Validates that QueryEnumerable with 2 components works in foreach loops.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithTwoComponents_CanBeUsedInForeach()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 0.5f, Y = 1.0f});
            scene.Create(new Position {X = 3, Y = 4}, new Velocity {X = 1.5f, Y = 2.0f});
            Query query = scene.Query<With<Position>, With<Velocity>>();

            int count = 0;
            foreach (RefTuple<Position, Velocity> _ in query.Enumerate<Position, Velocity>())
            {
                count++;
            }

            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that query enumerable with two components provides access to both
        /// </summary>
        /// <remarks>
        ///     Validates that both component types are accessible during enumeration.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithTwoComponents_ProvidesAccessToBoth()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 10, Y = 20}, new Velocity {X = 5, Y = 10});
            Query query = scene.Query<With<Position>, With<Velocity>>();

            foreach ((Ref<Position> pos, Ref<Velocity> vel) in query.Enumerate<Position, Velocity>())
            {
                Assert.Equal(10, pos.Value.X);
                Assert.Equal(20, pos.Value.Y);
                Assert.Equal(5, vel.Value.X);
                Assert.Equal(10, vel.Value.Y);
            }
        }

        /// <summary>
        ///     Tests that query enumerable with two components filters correctly
        /// </summary>
        /// <remarks>
        ///     Validates that only entities with both components are enumerated.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithTwoComponents_FiltersCorrectly()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 1}, new Velocity {X = 1, Y = 1});
            scene.Create(new Position {X = 2, Y = 2}); // Missing Velocity
            Query query = scene.Query<With<Position>, With<Velocity>>();

            int count = 0;
            foreach (RefTuple<Position, Velocity> _ in query.Enumerate<Position, Velocity>())
            {
                count++;
            }

            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that query enumerable with two components allows modification
        /// </summary>
        /// <remarks>
        ///     Validates that both components can be modified during enumeration.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithTwoComponents_AllowsModification()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 0, Y = 0}, new Velocity {X = 0, Y = 0});
            Query query = scene.Query<With<Position>, With<Velocity>>();

            foreach ((Ref<Position> pos, Ref<Velocity> vel) in query.Enumerate<Position, Velocity>())
            {
                Position p = pos.Value;
                p.X = 100;
                pos.Value = p;

                Velocity v = vel.Value;
                v.X = 50;
                vel.Value = v;
            }

            Assert.Equal(100, entity.Get<Position>().X);
            Assert.Equal(50, entity.Get<Velocity>().X);
        }

        /// <summary>
        ///     Tests that query enumerable with two components works with multiple entities
        /// </summary>
        /// <remarks>
        ///     Validates enumeration with multiple matching entities.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithTwoComponents_WorksWithMultipleEntities()
        {
            using Scene scene = new Scene();
            for (int i = 0; i < 5; i++)
            {
                scene.Create(new Position {X = i, Y = i * 2}, new Velocity {X = i * 0.5f, Y = i * 0.3f});
            }

            Query query = scene.Query<With<Position>, With<Velocity>>();

            int count = 0;
            foreach (RefTuple<Position, Velocity> _ in query.Enumerate<Position, Velocity>())
            {
                count++;
            }

            Assert.Equal(5, count);
        }

        /// <summary>
        ///     Tests that query enumerable with two components works with empty query
        /// </summary>
        /// <remarks>
        ///     Validates handling of empty queries with 2 components.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithTwoComponents_WorksWithEmptyQuery()
        {
            using Scene scene = new Scene();
            Query query = scene.Query<With<Position>, With<Velocity>>();

            int count = 0;
            foreach (RefTuple<Position, Velocity> _ in query.Enumerate<Position, Velocity>())
            {
                count++;
            }

            Assert.Equal(0, count);
        }

        /// <summary>
        ///     Tests that query enumerable with two components provides entity access
        /// </summary>
        /// <remarks>
        ///     Validates that EnumerateWithEntities works with 2 components.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithTwoComponents_ProvidesEntityAccess()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 5, Y = 10}, new Velocity {X = 2, Y = 3});
            Query query = scene.Query<With<Position>, With<Velocity>>();

            foreach ((GameObject entity, Ref<Position> pos, Ref<Velocity> vel) in query.EnumerateWithEntities<Position, Velocity>())
            {
                Assert.False(entity.IsNull);
                Assert.True(entity.IsAlive);
                Assert.Equal(5, pos.Value.X);
                Assert.Equal(2, vel.Value.X);
            }
        }
    }
}