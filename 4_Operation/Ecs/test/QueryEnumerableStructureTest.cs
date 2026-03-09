// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QueryEnumerableStructureTest.cs
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


        [Fact]
        public void QueryEnumerable_Arity1_GetEnumerator_ReturnsExpectedType()
        {
            AssertGetEnumeratorReturnType<QueryEnumerable<Position>>(typeof(GameObjectQueryEnumerator<Position>));
        }

        [Fact]
        public void QueryEnumerable_Arity2_GetEnumerator_ReturnsExpectedType()
        {
            AssertGetEnumeratorReturnType<QueryEnumerable<Position, Velocity>>(typeof(GameObjectQueryEnumerator<Position, Velocity>));
        }

        [Fact]
        public void QueryEnumerable_Arity3_GetEnumerator_ReturnsExpectedType()
        {
            AssertGetEnumeratorReturnType<QueryEnumerable<Position, Velocity, Health>>(typeof(GameObjectQueryEnumerator<Position, Velocity, Health>));
        }

        [Fact]
        public void QueryEnumerable_Arity4_GetEnumerator_ReturnsExpectedType()
        {
            AssertGetEnumeratorReturnType<QueryEnumerable<Position, Velocity, Health, Transform>>(typeof(GameObjectQueryEnumerator<Position, Velocity, Health, Transform>));
        }

        [Fact]
        public void QueryEnumerable_Arity5_GetEnumerator_ReturnsExpectedType()
        {
            AssertGetEnumeratorReturnType<QueryEnumerable<Position, Velocity, Health, Transform, TestComponent>>(typeof(GameObjectQueryEnumerator<Position, Velocity, Health, Transform, TestComponent>));
        }

        [Fact]
        public void QueryEnumerable_Arity6_GetEnumerator_ReturnsExpectedType()
        {
            AssertGetEnumeratorReturnType<QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>>(typeof(GameObjectQueryEnumerator<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>));
        }

        [Fact]
        public void QueryEnumerable_Arity7_GetEnumerator_ReturnsExpectedType()
        {
            AssertGetEnumeratorReturnType<QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage>>(typeof(GameObjectQueryEnumerator<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage>));
        }

        [Fact]
        public void QueryEnumerable_Arity8_GetEnumerator_ReturnsExpectedType()
        {
            AssertGetEnumeratorReturnType<QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>>(typeof(GameObjectQueryEnumerator<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>));
        }

        [Fact]
        public void QueryEnumerable_Arity1_DirectInstance_WorksInForeach()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 2});
            scene.Create(new Position {X = 3, Y = 4});
            Query query = scene.Query<With<Position>>();
            QueryEnumerable<Position> enumerable = new QueryEnumerable<Position>(query);

            int count = 0;
            foreach (var _ in enumerable)
            {
                count++;
            }

            Assert.Equal(2, count);
        }

        [Fact]
        public void QueryEnumerable_Arity2_DirectInstance_WorksInForeach()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 2}, new Velocity {VX = 3, VY = 4});
            Query query = scene.Query<With<Position>, With<Velocity>>();
            QueryEnumerable<Position, Velocity> enumerable = new QueryEnumerable<Position, Velocity>(query);

            int count = 0;
            foreach (var _ in enumerable)
            {
                count++;
            }

            Assert.Equal(1, count);
        }

        [Fact]
        public void QueryEnumerable_Arity8_DirectInstance_WorksInForeach()
        {
            using Scene scene = new Scene();
            scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {VX = 3, VY = 4},
                new Health {Value = 5},
                new Transform {X = 6, Y = 7, Rotation = 8},
                new TestComponent {Value = 9, Name = "n"},
                new AnotherComponent {X = 10, Y = 11},
                new Damage {Amount = 12},
                new Armor {Defense = 13}
            );
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, With<Damage>, With<Armor>>();
            QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor> enumerable =
                new QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>(query);

            int count = 0;
            foreach (var _ in enumerable)
            {
                count++;
            }

            Assert.Equal(1, count);
        }

        private static void AssertQueryEnumerableLayout(Type type)
        {
            Assert.True(type.IsValueType);
            Assert.True(type.IsDefined(typeof(IsReadOnlyAttribute), inherit: false));

            StructLayoutAttribute? attr = type.GetCustomAttribute<StructLayoutAttribute>();
            Assert.Equal(LayoutKind.Sequential, attr!.Value);
            Assert.Equal(1, attr.Pack);
        }

        private static void AssertGetEnumeratorReturnType<TEnumerable>(Type expectedType)
        {
            MethodInfo? method = typeof(TEnumerable).GetMethod("GetEnumerator", BindingFlags.Public | BindingFlags.Instance);
            Assert.NotNull(method);
            Assert.Equal(expectedType, method!.ReturnType);
            Assert.Empty(method.GetParameters());
        }
    }
}
