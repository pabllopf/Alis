// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QueryEnumeratorTest.cs
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

using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    ///     Tests for <see cref="QueryEnumerator{T}" /> and its multi-arity variants.
    /// </summary>
    public class QueryEnumeratorTest
    {
        /// <summary>
        ///     Tests that enumerating a query with one component iterates all matching entities.
        /// </summary>
        [Fact]
        public void QueryEnumerator_Arity1_IteratesMatchingEntities()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 2});
            scene.Create(new Velocity {X = 3, Y = 4});
            scene.Create(new Position {X = 5, Y = 6}, new Velocity {X = 7, Y = 8});

            Query query = scene.Query<With<Position>>();

            int count = 0;
            using QueryEnumerator<Position> enumerator = query.Enumerate<Position>().GetEnumerator();
            while (enumerator.MoveNext())
            {
                Ref<Position> current = enumerator.Current.Item1;
                if (count == 0) Assert.Equal(1, current.Value.X);
                if (count == 1) Assert.Equal(5, current.Value.X);
                count++;
            }

            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that enumerating an empty query returns false on first MoveNext.
        /// </summary>
        [Fact]
        public void QueryEnumerator_EmptyQuery_ReturnsFalse()
        {
            using Scene scene = new Scene();
            Query query = scene.Query<With<Position>>();

            using QueryEnumerator<Position> enumerator = query.Enumerate<Position>().GetEnumerator();
            Assert.False(enumerator.MoveNext());
        }

        /// <summary>
        ///     Tests that Dispose restores structural change allowance.
        /// </summary>
        [Fact]
        public void QueryEnumerator_Dispose_RestoresStructuralChanges()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 2});
            Query query = scene.Query<With<Position>>();

            Assert.True(scene.AllowStructualChanges);

            QueryEnumerator<Position> enumerator = query.Enumerate<Position>().GetEnumerator();
            Assert.False(scene.AllowStructualChanges);
            enumerator.Dispose();

            Assert.True(scene.AllowStructualChanges);
        }

        /// <summary>
        ///     Tests that enumerator arity 2 returns correct paired component values.
        /// </summary>
        [Fact]
        public void QueryEnumerator_Arity2_ReturnsCorrectComponentValues()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4});

            Query query = scene.Query<With<Position>, With<Velocity>>();

            using QueryEnumerator<Position, Velocity> enumerator = query.Enumerate<Position, Velocity>().GetEnumerator();

            Assert.True(enumerator.MoveNext());
            RefTuple<Position, Velocity> current = enumerator.Current;
            Assert.Equal(1, current.Item1.Value.X);
            Assert.Equal(3, current.Item2.Value.X);
        }

        /// <summary>
        ///     Tests that enumerator arity 3 returns correct component values.
        /// </summary>
        [Fact]
        public void QueryEnumerator_Arity3_ReturnsCorrectComponentValues()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5});

            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();

            using QueryEnumerator<Position, Velocity, Health> enumerator = query.Enumerate<Position, Velocity, Health>().GetEnumerator();

            Assert.True(enumerator.MoveNext());
            RefTuple<Position, Velocity, Health> current = enumerator.Current;
            Assert.Equal(1, current.Item1.Value.X);
            Assert.Equal(3, current.Item2.Value.X);
            Assert.Equal(5, current.Item3.Value.Value);
        }

        /// <summary>
        ///     Tests that enumerator arity 4 returns correct component values.
        /// </summary>
        [Fact]
        public void QueryEnumerator_Arity4_ReturnsCorrectComponentValues()
        {
            using Scene scene = new Scene();
            scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {X = 3, Y = 4},
                new Health {Value = 5},
                new Transform {X = 6, Y = 7, Rotation = 8});

            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>>();

            using QueryEnumerator<Position, Velocity, Health, Transform> enumerator = query.Enumerate<Position, Velocity, Health, Transform>().GetEnumerator();

            Assert.True(enumerator.MoveNext());
            RefTuple<Position, Velocity, Health, Transform> current = enumerator.Current;
            Assert.Equal(1, current.Item1.Value.X);
            Assert.Equal(3, current.Item2.Value.X);
            Assert.Equal(5, current.Item3.Value.Value);
            Assert.Equal(8, current.Item4.Value.Rotation);
        }

        /// <summary>
        ///     Tests that enumerator arity 5 returns correct component values.
        /// </summary>
        [Fact]
        public void QueryEnumerator_Arity5_ReturnsCorrectComponentValues()
        {
            using Scene scene = new Scene();
            scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {X = 3, Y = 4},
                new Health {Value = 5},
                new Transform {X = 6, Y = 7, Rotation = 8},
                new TestComponent {Value = 9, Name = "n"});

            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>>();

            using QueryEnumerator<Position, Velocity, Health, Transform, TestComponent> enumerator = query.Enumerate<Position, Velocity, Health, Transform, TestComponent>().GetEnumerator();

            Assert.True(enumerator.MoveNext());
            RefTuple<Position, Velocity, Health, Transform, TestComponent> current = enumerator.Current;
            Assert.Equal(1, current.Item1.Value.X);
            Assert.Equal(3, current.Item2.Value.X);
            Assert.Equal(5, current.Item3.Value.Value);
            Assert.Equal(8, current.Item4.Value.Rotation);
            Assert.Equal(9, current.Item5.Value.Value);
        }

        /// <summary>
        ///     Tests that enumerator arity 8 returns correct component values and restores structural state on dispose.
        /// </summary>
        [Fact]
        public void QueryEnumerator_Arity8_ReturnsCorrectValues_AndDisposeRestoresStructuralChanges()
        {
            using Scene scene = new Scene();
            scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {X = 3, Y = 4},
                new Health {Value = 5},
                new Transform {X = 6, Y = 7, Rotation = 8},
                new TestComponent {Value = 9, Name = "n"},
                new AnotherComponent {Data = 10, Y = 11, Name = "a"},
                new Damage {Value = 12},
                new Armor {Value = 13});

            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, With<Damage>, With<Armor>>();

            Assert.True(scene.AllowStructualChanges);

            QueryEnumerator<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor> enumerator;
            using (enumerator = query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>().GetEnumerator())
            {
                Assert.False(scene.AllowStructualChanges);

                Assert.True(enumerator.MoveNext());
                RefTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor> current = enumerator.Current;
                Assert.Equal(1, current.Item1.Value.X);
                Assert.Equal(3, current.Item2.Value.X);
                Assert.Equal(5, current.Item3.Value.Value);
                Assert.Equal(8, current.Item4.Value.Rotation);
                Assert.Equal(9, current.Item5.Value.Value);
                Assert.Equal(10, current.Item6.Value.Data);
                Assert.Equal(12, current.Item7.Value.Value);
                Assert.Equal(13, current.Item8.Value.Value);

                Assert.False(enumerator.MoveNext());
                Assert.False(scene.AllowStructualChanges);
            }

            Assert.True(scene.AllowStructualChanges);
        }
    }
}
