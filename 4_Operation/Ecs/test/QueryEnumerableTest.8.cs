// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QueryEnumerable.2.cs
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
                new Position { X = 10, Y = 20 },
                new Velocity { VX = 5, VY = 10 },
                new Health { Value = 150 },
                new Transform { X = 1, Y = 2, Rotation = 45 },
                new TestComponent { Value = 999, Name = "Test" },
                new AnotherComponent { X = 100, Y = 200 },
                new Damage { Amount = 25 },
                new Armor { Defense = 50 }
            );
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, With<Damage>, With<Armor>>();
                new QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>(query);

            // Act & Assert
            foreach (var (pos, vel, health, trans, test, another, damage, armor) in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>())
            {
              
                Assert.Equal(10, pos.Value.X);
                Assert.Equal(5, vel.Value.VX);
                Assert.Equal(150, health.Value.Value);
                Assert.Equal(45, trans.Value.Rotation);
                Assert.Equal(999, test.Value.Value);
                Assert.Equal(100, another.Value.X);
                Assert.Equal(25, damage.Value.Amount);
                Assert.Equal(50, armor.Value.Defense);
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
                new Position { X = 1, Y = 1 },
                new Velocity { VX = 1, VY = 1 },
                new Health { Value = 100 },
                new Transform { X = 0, Y = 0, Rotation = 0 },
                new TestComponent { Value = 1, Name = "Test" },
                new AnotherComponent { X = 5, Y = 10 },
                new Damage { Amount = 10 },
                new Armor { Defense = 20 }
            );
            scene.Create(
                new Position { X = 2, Y = 2 },
                new Velocity { VX = 2, VY = 2 },
                new Health { Value = 50 },
                new Transform { X = 1, Y = 1, Rotation = 0 },
                new TestComponent { Value = 2, Name = "Test2" },
                new AnotherComponent { X = 10, Y = 20 },
                new Damage { Amount = 15 }
            ); // Missing Armor
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, With<Damage>, With<Armor>>();
                new QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>(query);

            // Act
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>())
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
                new Position { X = 0, Y = 0 },
                new Velocity { VX = 0, VY = 0 },
                new Health { Value = 0 },
                new Transform { X = 0, Y = 0, Rotation = 0 },
                new TestComponent { Value = 0, Name = "" },
                new AnotherComponent { X = 0, Y = 0 },
                new Damage { Amount = 0 },
                new Armor { Defense = 0 }
            );
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, With<Damage>, With<Armor>>();
                new QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>(query);

            // Act
            foreach (var (pos, vel, health, trans, test, another, damage, armor) in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>())
            {
                var p = pos.Value;
                p.X = 100;
                pos.Value = p;

                var h = health.Value;
                h.Value = 500;
                health.Value = h;

                var d = damage.Value;
                d.Amount = 75;
                damage.Value = d;

                var a = armor.Value;
                a.Defense = 100;
                armor.Value = a;
            }

            // Assert
            Assert.Equal(100, entity.Get<Position>().X);
            Assert.Equal(500, entity.Get<Health>().Value);
            Assert.Equal(75, entity.Get<Damage>().Amount);
            Assert.Equal(100, entity.Get<Armor>().Defense);
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
            foreach (var _ in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>())
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
                new Position { X = 1, Y = 1 },
                new Velocity { VX = 1, VY = 1 },
                new Health { Value = 100 },
                new Transform { X = 0, Y = 0, Rotation = 0 },
                new TestComponent { Value = 1, Name = "Complex" },
                new AnotherComponent { X = 5, Y = 10 },
                new Damage { Amount = 10 },
                new Armor { Defense = 20 }
            );
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, With<Damage>, With<Armor>>();
                new QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>(query);

            // Act
            bool found = false;
            foreach (var _ in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>())
            {
                found = true;
            }

            // Assert
            Assert.True(found, "Entity with 8 components should be found");
        }
    }
}

