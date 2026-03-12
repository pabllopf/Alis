// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QueryEnumerableTest.8.cs
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

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The query enumerable test class
    /// </summary>
    /// <remarks>
    ///     Tests for QueryEnumerable with 8 component types (maximum complexity).
    /// </remarks>
    public partial class QueryEnumerableTest
    {
        /// <summary>
        ///     Tests that query enumerable with eight components provides access to all
        /// </summary>
        /// <remarks>
        ///     Validates that all eight component types are accessible during enumeration.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithEightComponents_ProvidesAccessToAll()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(
                new Position {X = 10, Y = 20},
                new Velocity {X = 5, Y = 10},
                new Health {Value = 150},
                new Transform {X = 1, Y = 2, Rotation = 45},
                new TestComponent {Value = 999, Name = "Test"},
                new AnotherComponent {Data = 100, Y = 200},
                new Damage {Value = 25},
                new Armor {Value = 50}
            );
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, With<Damage>, With<Armor>>();
            new QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>(query);

            // Act & Assert
            foreach ((Ref<Position> pos, Ref<Velocity> vel, Ref<Health> health, Ref<Transform> trans, Ref<TestComponent> test, Ref<AnotherComponent> another, Ref<Damage> damage, Ref<Armor> armor) in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>())
            {
                Assert.Equal(10, pos.Value.X);
                Assert.Equal(5, vel.Value.X);
                Assert.Equal(150, health.Value.Value);
                Assert.Equal(45, trans.Value.Rotation);
                Assert.Equal(999, test.Value.Value);
                Assert.Equal(100, another.Value.Data);
                Assert.Equal(25, damage.Value.Value);
                Assert.Equal(50, armor.Value.Value);
            }
        }

        /// <summary>
        ///     Tests that query enumerable with eight components filters correctly
        /// </summary>
        /// <remarks>
        ///     Validates that only entities with all eight components are enumerated.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithEightComponents_FiltersCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(
                new Position {X = 1, Y = 1},
                new Velocity {X = 1, Y = 1},
                new Health {Value = 100},
                new Transform {X = 0, Y = 0, Rotation = 0},
                new TestComponent {Value = 1, Name = "Test"},
                new AnotherComponent {Data = 5, Y = 10},
                new Damage {Value = 10},
                new Armor {Value = 20}
            );
            scene.Create(
                new Position {X = 2, Y = 2},
                new Velocity {X = 2, Y = 2},
                new Health {Value = 50},
                new Transform {X = 1, Y = 1, Rotation = 0},
                new TestComponent {Value = 2, Name = "Test2"},
                new AnotherComponent {Data = 10, Y = 20},
                new Damage {Value = 15}
            ); // Missing Armor
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, With<Damage>, With<Armor>>();
            new QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>(query);

            // Act
            int count = 0;
            foreach (RefTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor> _ in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that query enumerable with eight components allows modification
        /// </summary>
        /// <remarks>
        ///     Validates that all eight components can be modified during enumeration.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithEightComponents_AllowsModification()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 0, Y = 0},
                new Velocity {X = 0, Y = 0},
                new Health {Value = 0},
                new Transform {X = 0, Y = 0, Rotation = 0},
                new TestComponent {Value = 0, Name = ""},
                new AnotherComponent {Data = 0, Y = 0},
                new Damage {Value = 0},
                new Armor {Value = 0}
            );
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, With<Damage>, With<Armor>>();
            new QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>(query);

            // Act
            foreach ((Ref<Position> pos, Ref<Velocity> vel, Ref<Health> health, Ref<Transform> trans, Ref<TestComponent> test, Ref<AnotherComponent> another, Ref<Damage> damage, Ref<Armor> armor) in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>())
            {
                Position p = pos.Value;
                p.X = 100;
                pos.Value = p;

                Health h = health.Value;
                h.Value = 500;
                health.Value = h;

                Damage d = damage.Value;
                d.Value = 75;
                damage.Value = d;

                Armor a = armor.Value;
                a.Value = 100;
                armor.Value = a;
            }

            // Assert
            Assert.Equal(100, entity.Get<Position>().X);
            Assert.Equal(500, entity.Get<Health>().Value);
            Assert.Equal(75, entity.Get<Damage>().Value);
            Assert.Equal(100, entity.Get<Armor>().Value);
        }

        /// <summary>
        ///     Tests that query enumerable with eight components is struct type
        /// </summary>
        /// <remarks>
        ///     Validates that QueryEnumerable with 8 components is a value type.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithEightComponents_IsStructType()
        {
            // Assert
            Assert.True(typeof(QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>).IsValueType);
        }

        /// <summary>
        ///     Tests that query enumerable with eight components works with empty query
        /// </summary>
        /// <remarks>
        ///     Validates handling of empty queries with 8 components.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithEightComponents_WorksWithEmptyQuery()
        {
            // Arrange
            using Scene scene = new Scene();
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, With<Damage>, With<Armor>>();
            new QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>(query);

            // Act
            int count = 0;
            foreach (RefTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor> _ in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>())
            {
                count++;
            }

            // Assert
            Assert.Equal(0, count);
        }

        /// <summary>
        ///     Tests that query enumerable with eight components represents maximum complexity
        /// </summary>
        /// <remarks>
        ///     Validates that 8-component queries represent the maximum supported complexity.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithEightComponents_RepresentsMaximumComplexity()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(
                new Position {X = 1, Y = 1},
                new Velocity {X = 1, Y = 1},
                new Health {Value = 100},
                new Transform {X = 0, Y = 0, Rotation = 0},
                new TestComponent {Value = 1, Name = "Complex"},
                new AnotherComponent {Data = 5, Y = 10},
                new Damage {Value = 10},
                new Armor {Value = 20}
            );
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, With<Damage>, With<Armor>>();
            new QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>(query);

            // Act
            bool found = false;
            foreach (RefTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor> _ in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>())
            {
                found = true;
            }

            // Assert
            Assert.True(found, "Entity with 8 components should be found");
        }
    }
}