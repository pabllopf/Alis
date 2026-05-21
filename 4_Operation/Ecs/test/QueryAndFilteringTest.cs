

using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The query and filtering test class
    /// </summary>
    /// <remarks>
    ///     Comprehensive tests for the query and filtering system which allows
    ///     iterating over entities with specific component combinations using the
    ///     Query<With<T>> pattern.
    /// </remarks>
    public class QueryAndFilteringTest
    {
        /// <summary>
        ///     Tests querying entities with single component
        /// </summary>
        /// <remarks>
        ///     Validates that Query returns only entities with the specified
        ///     component type using With<T> filter.
        /// </remarks>
        [Fact]
        public void Query_ReturnsSingleComponentEntities()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 0, Y = 0});
            scene.Create(new Position {X = 1, Y = 1});
            scene.Create(new Health {Value = 100});

            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach ((GameObject entity, Ref<Position> pos) in query.EnumerateWithEntities<Position>())
            {
                count++;
            }

            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests querying with two component requirement
        /// </summary>
        /// <remarks>
        ///     Tests that Query with two component types returns only entities
        ///     that have both components.
        /// </remarks>
        [Fact]
        public void Query_RequiresTwoComponents()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 0, Y = 0}, new Velocity {X = 1, Y = 1});
            scene.Create(new Position {X = 1, Y = 1});
            scene.Create(new Velocity {X = 2, Y = 2});

            Query query = scene.Query<With<Position>, With<Velocity>>();
            int count = 0;
            foreach (GameObjectRefTuple<Position, Velocity> _ in query.EnumerateWithEntities<Position, Velocity>())
            {
                count++;
            }

            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests query enumeration consistency
        /// </summary>
        /// <remarks>
        ///     Validates that multiple iterations yield same results.
        /// </remarks>
        [Fact]
        public void Query_IsConsistentAcrossMultipleIterations()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 0, Y = 0});
            scene.Create(new Position {X = 1, Y = 1});

            Query query = scene.Query<With<Position>>();
            int count1 = 0;
            foreach (Ecs.Systems.GameObjectRefTuple<Position> _ in query.EnumerateWithEntities<Position>())
            {
                count1++;
            }

            int count2 = 0;
            foreach (Ecs.Systems.GameObjectRefTuple<Position> _ in query.EnumerateWithEntities<Position>())
            {
                count2++;
            }

            Assert.Equal(count1, count2);
            Assert.Equal(2, count1);
        }

        /// <summary>
        ///     Tests empty query returns no entities
        /// </summary>
        /// <remarks>
        ///     Validates that Query returns no entities when no entity
        ///     matches the specified component criteria.
        /// </remarks>
        [Fact]
        public void Query_ReturnsNoEntitiesWhenNoneMatch()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 0, Y = 0});
            scene.Create(new Position {X = 1, Y = 1});

            Query query = scene.Query<With<Health>>();
            int count = 0;
            foreach (Ecs.Systems.GameObjectRefTuple<Health> _ in query.EnumerateWithEntities<Health>())
            {
                count++;
            }

            Assert.Equal(0, count);
        }

        /// <summary>
        ///     Tests query provides access to components during iteration
        /// </summary>
        /// <remarks>
        ///     Validates that component data can be accessed during iteration.
        /// </remarks>
        [Fact]
        public void Query_AllowsComponentAccessDuringIteration()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 10, Y = 20});
            scene.Create(new Position {X = 30, Y = 40});

            Query query = scene.Query<With<Position>>();
            float totalX = 0;
            foreach ((GameObject entity, Ref<Position> pos) in query.EnumerateWithEntities<Position>())
            {
                totalX += pos.Value.X;
            }

            Assert.Equal(40, totalX);
        }

        /// <summary>
        ///     Tests querying after removing component
        /// </summary>
        /// <remarks>
        ///     Tests that entities with removed components are excluded
        ///     from subsequent queries.
        /// </remarks>
        [Fact]
        public void Query_ExcludesEntitiesWithRemovedComponents()
        {
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position {X = 0, Y = 0}, new Health {Value = 100});
            GameObject entity2 = scene.Create(new Position {X = 1, Y = 1}, new Health {Value = 100});

            entity1.Remove<Health>();

            Query query = scene.Query<With<Position>, With<Health>>();
            int count = 0;
            foreach (GameObjectRefTuple<Position, Health> _ in query.EnumerateWithEntities<Position, Health>())
            {
                count++;
            }

            Assert.Equal(1, count);
        }
    }
}