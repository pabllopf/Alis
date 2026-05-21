

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
    ///     Tests for QueryEnumerable with 6 component types.
    /// </remarks>
    public partial class QueryEnumerableTest
    {
        /// <summary>
        ///     Tests that query enumerable with six components can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that QueryEnumerable with 6 components can be instantiated.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithSixComponents_CanBeCreated()
        {
            using Scene scene = new Scene();
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();

            QueryEnumerator<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>.QueryEnumerable enumerable = query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>();

            Assert.NotEqual(default(QueryEnumerator<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>.QueryEnumerable), enumerable);
        }

        /// <summary>
        ///     Tests that query enumerable with six components provides access to all
        /// </summary>
        /// <remarks>
        ///     Validates that all six component types are accessible during enumeration.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithSixComponents_ProvidesAccessToAll()
        {
            using Scene scene = new Scene();
            scene.Create(
                new Position {X = 10, Y = 20},
                new Velocity {X = 5, Y = 10},
                new Health {Value = 150},
                new Transform {X = 1, Y = 2, Rotation = 45},
                new TestComponent {Value = 999, Name = "Test"},
                new AnotherComponent {Data = 100, Y = 200}
            );
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();

            foreach ((Ref<Position> pos, Ref<Velocity> vel, Ref<Health> health, Ref<Transform> trans, Ref<TestComponent> test, Ref<AnotherComponent> another) in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>())
            {
                Assert.Equal(10, pos.Value.X);
                Assert.Equal(5, vel.Value.X);
                Assert.Equal(150, health.Value.Value);
                Assert.Equal(45, trans.Value.Rotation);
                Assert.Equal(999, test.Value.Value);
                Assert.Equal("Test", test.Value.Name);
                Assert.Equal(100, another.Value.Data);
                Assert.Equal(200, another.Value.Y);
            }
        }

        /// <summary>
        ///     Tests that query enumerable with six components filters correctly
        /// </summary>
        /// <remarks>
        ///     Validates that only entities with all six components are enumerated.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithSixComponents_FiltersCorrectly()
        {
            using Scene scene = new Scene();
            scene.Create(
                new Position {X = 1, Y = 1},
                new Velocity {X = 1, Y = 1},
                new Health {Value = 100},
                new Transform {X = 0, Y = 0, Rotation = 0},
                new TestComponent {Value = 1, Name = "Test"},
                new AnotherComponent {Data = 5, Y = 10}
            );
            scene.Create(
                new Position {X = 2, Y = 2},
                new Velocity {X = 2, Y = 2},
                new Health {Value = 50},
                new Transform {X = 1, Y = 1, Rotation = 0},
                new TestComponent {Value = 2, Name = "Test2"}
            ); // Missing AnotherComponent
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();

            int count = 0;
            foreach (RefTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent> _ in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>())
            {
                count++;
            }

            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that query enumerable with six components allows modification
        /// </summary>
        /// <remarks>
        ///     Validates that all six components can be modified during enumeration.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithSixComponents_AllowsModification()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 0, Y = 0},
                new Velocity {X = 0, Y = 0},
                new Health {Value = 0},
                new Transform {X = 0, Y = 0, Rotation = 0},
                new TestComponent {Value = 0, Name = ""},
                new AnotherComponent {Data = 0, Y = 0}
            );
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();

            foreach ((Ref<Position> pos, Ref<Velocity> vel, Ref<Health> health, Ref<Transform> trans, Ref<TestComponent> test, Ref<AnotherComponent> another) in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>())
            {
                Position p = pos.Value;
                p.X = 100;
                pos.Value = p;

                Health h = health.Value;
                h.Value = 300;
                health.Value = h;

                Transform t = trans.Value;
                t.Rotation = 180;
                trans.Value = t;

                AnotherComponent a = another.Value;
                a.Data = 50;
                another.Value = a;
            }

            Assert.Equal(100, entity.Get<Position>().X);
            Assert.Equal(300, entity.Get<Health>().Value);
            Assert.Equal(180, entity.Get<Transform>().Rotation);
            Assert.Equal(50, entity.Get<AnotherComponent>().Data);
        }

        /// <summary>
        ///     Tests that query enumerable with six components works with multiple entities
        /// </summary>
        /// <remarks>
        ///     Validates enumeration with multiple matching entities.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithSixComponents_WorksWithMultipleEntities()
        {
            using Scene scene = new Scene();
            for (int i = 0; i < 2; i++)
            {
                scene.Create(
                    new Position {X = i, Y = i * 2},
                    new Velocity {X = i * 0.5f, Y = i * 0.3f},
                    new Health {Value = i * 10},
                    new Transform {X = i, Y = i, Rotation = i * 45},
                    new TestComponent {Value = i, Name = $"Test{i}"},
                    new AnotherComponent {Data = i * 2, Y = i * 3}
                );
            }

            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();

            int count = 0;
            foreach (RefTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent> _ in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>())
            {
                count++;
            }

            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that query enumerable with six components is struct type
        /// </summary>
        /// <remarks>
        ///     Validates that QueryEnumerable with 6 components is a value type.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithSixComponents_IsStructType()
        {
            Assert.True(typeof(QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>).IsValueType);
        }

        /// <summary>
        ///     Tests that query enumerable with six components works with empty query
        /// </summary>
        /// <remarks>
        ///     Validates handling of empty queries with 6 components.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithSixComponents_WorksWithEmptyQuery()
        {
            using Scene scene = new Scene();
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();

            int count = 0;
            foreach (RefTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent> _ in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>())
            {
                count++;
            }

            Assert.Equal(0, count);
        }
    }
}