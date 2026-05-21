

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Tests structural and contract properties of QueryEnumerable structs.
    /// </summary>
    public class QueryEnumerableStructureTest
    {
        /// <summary>
        ///     Tests that query enumerable arity 1 get enumerator returns expected type
        /// </summary>
        [Fact]
        public void QueryEnumerable_Arity1_GetEnumerator_ReturnsExpectedType()
        {
            AssertGetEnumeratorReturnType<QueryEnumerable<Position>>(typeof(GameObjectQueryEnumerator<Position>));
        }

        /// <summary>
        ///     Tests that query enumerable arity 2 get enumerator returns expected type
        /// </summary>
        [Fact]
        public void QueryEnumerable_Arity2_GetEnumerator_ReturnsExpectedType()
        {
            AssertGetEnumeratorReturnType<QueryEnumerable<Position, Velocity>>(typeof(GameObjectQueryEnumerator<Position, Velocity>));
        }

        /// <summary>
        ///     Tests that query enumerable arity 3 get enumerator returns expected type
        /// </summary>
        [Fact]
        public void QueryEnumerable_Arity3_GetEnumerator_ReturnsExpectedType()
        {
            AssertGetEnumeratorReturnType<QueryEnumerable<Position, Velocity, Health>>(typeof(GameObjectQueryEnumerator<Position, Velocity, Health>));
        }

        /// <summary>
        ///     Tests that query enumerable arity 4 get enumerator returns expected type
        /// </summary>
        [Fact]
        public void QueryEnumerable_Arity4_GetEnumerator_ReturnsExpectedType()
        {
            AssertGetEnumeratorReturnType<QueryEnumerable<Position, Velocity, Health, Transform>>(typeof(GameObjectQueryEnumerator<Position, Velocity, Health, Transform>));
        }

        /// <summary>
        ///     Tests that query enumerable arity 5 get enumerator returns expected type
        /// </summary>
        [Fact]
        public void QueryEnumerable_Arity5_GetEnumerator_ReturnsExpectedType()
        {
            AssertGetEnumeratorReturnType<QueryEnumerable<Position, Velocity, Health, Transform, TestComponent>>(typeof(GameObjectQueryEnumerator<Position, Velocity, Health, Transform, TestComponent>));
        }

        /// <summary>
        ///     Tests that query enumerable arity 6 get enumerator returns expected type
        /// </summary>
        [Fact]
        public void QueryEnumerable_Arity6_GetEnumerator_ReturnsExpectedType()
        {
            AssertGetEnumeratorReturnType<QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>>(typeof(GameObjectQueryEnumerator<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>));
        }

        /// <summary>
        ///     Tests that query enumerable arity 7 get enumerator returns expected type
        /// </summary>
        [Fact]
        public void QueryEnumerable_Arity7_GetEnumerator_ReturnsExpectedType()
        {
            AssertGetEnumeratorReturnType<QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage>>(typeof(GameObjectQueryEnumerator<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage>));
        }

        /// <summary>
        ///     Tests that query enumerable arity 8 get enumerator returns expected type
        /// </summary>
        [Fact]
        public void QueryEnumerable_Arity8_GetEnumerator_ReturnsExpectedType()
        {
            AssertGetEnumeratorReturnType<QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>>(typeof(GameObjectQueryEnumerator<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>));
        }

        /// <summary>
        ///     Tests that query enumerable arity 1 direct instance works in foreach
        /// </summary>
        [Fact]
        public void QueryEnumerable_Arity1_DirectInstance_WorksInForeach()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 2});
            scene.Create(new Position {X = 3, Y = 4});
            Query query = scene.Query<With<Position>>();
            QueryEnumerable<Position> enumerable = new QueryEnumerable<Position>(query);

            int count = 0;
            foreach (GameObjectRefTuple<Position> _ in enumerable)
            {
                count++;
            }

            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that query enumerable arity 2 direct instance works in foreach
        /// </summary>
        [Fact]
        public void QueryEnumerable_Arity2_DirectInstance_WorksInForeach()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4});
            Query query = scene.Query<With<Position>, With<Velocity>>();
            QueryEnumerable<Position, Velocity> enumerable = new QueryEnumerable<Position, Velocity>(query);

            int count = 0;
            foreach (GameObjectRefTuple<Position, Velocity> _ in enumerable)
            {
                count++;
            }

            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that query enumerable arity 8 direct instance works in foreach
        /// </summary>
        [Fact]
        public void QueryEnumerable_Arity8_DirectInstance_WorksInForeach()
        {
            using Scene scene = new Scene();
            scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {X = 3, Y = 4},
                new Health {Value = 5},
                new Transform {X = 6, Y = 7, Rotation = 8},
                new TestComponent {Value = 9, Name = "n"},
                new AnotherComponent {Data = 10, Y = 11},
                new Damage {Value = 12},
                new Armor {Value = 13}
            );
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, With<Damage>, With<Armor>>();
            QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor> enumerable =
                new QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>(query);

            int count = 0;
            foreach (GameObjectRefTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor> _ in enumerable)
            {
                count++;
            }

            Assert.Equal(1, count);
        }
        

        /// <summary>
        ///     Asserts the get enumerator return type using the specified expected type
        /// </summary>
        /// <typeparam name="TEnumerable">The enumerable</typeparam>
        /// <param name="expectedType">The expected type</param>
        private static void AssertGetEnumeratorReturnType<TEnumerable>(Type expectedType)
        {
            MethodInfo? method = typeof(TEnumerable).GetMethod("GetEnumerator", BindingFlags.Public | BindingFlags.Instance);
            Assert.NotNull(method);
            Assert.Equal(expectedType, method!.ReturnType);
            Assert.Empty(method.GetParameters());
        }
    }
}