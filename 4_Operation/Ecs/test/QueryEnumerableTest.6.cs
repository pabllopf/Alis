// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QueryEnumerableTest.6.cs
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
            // Arrange
            using Scene scene = new Scene();
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();

            // Act
            var enumerable = query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>();

            // Assert
            Assert.NotEqual(default, enumerable);
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
            // Arrange
            using Scene scene = new Scene();
            scene.Create(
                new Position { X = 10, Y = 20 },
                new Velocity { VX = 5, VY = 10 },
                new Health { Value = 150 },
                new Transform { X = 1, Y = 2, Rotation = 45 },
                new TestComponent { Value = 999, Name = "Test" },
                new AnotherComponent { X = 100, Y = 200 }
            );
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();

            // Act & Assert
            foreach (var (pos, vel, health, trans, test, another) in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>())
            {
                Assert.Equal(10, pos.Value.X);
                Assert.Equal(5, vel.Value.VX);
                Assert.Equal(150, health.Value.Value);
                Assert.Equal(45, trans.Value.Rotation);
                Assert.Equal(999, test.Value.Value);
                Assert.Equal("Test", test.Value.Name);
                Assert.Equal(100, another.Value.X);
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
            // Arrange
            using Scene scene = new Scene();
            scene.Create(
                new Position { X = 1, Y = 1 },
                new Velocity { VX = 1, VY = 1 },
                new Health { Value = 100 },
                new Transform { X = 0, Y = 0, Rotation = 0 },
                new TestComponent { Value = 1, Name = "Test" },
                new AnotherComponent { X = 5, Y = 10 }
            );
            scene.Create(
                new Position { X = 2, Y = 2 },
                new Velocity { VX = 2, VY = 2 },
                new Health { Value = 50 },
                new Transform { X = 1, Y = 1, Rotation = 0 },
                new TestComponent { Value = 2, Name = "Test2" }
            ); // Missing AnotherComponent
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();

            // Act
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>())
            {
                count++;
            }

            // Assert
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
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position { X = 0, Y = 0 },
                new Velocity { VX = 0, VY = 0 },
                new Health { Value = 0 },
                new Transform { X = 0, Y = 0, Rotation = 0 },
                new TestComponent { Value = 0, Name = "" },
                new AnotherComponent { X = 0, Y = 0 }
            );
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();

            // Act
            foreach (var (pos, vel, health, trans, test, another) in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>())
            {
                var p = pos.Value;
                p.X = 100;
                pos.Value = p;

                var h = health.Value;
                h.Value = 300;
                health.Value = h;

                var t = trans.Value;
                t.Rotation = 180;
                trans.Value = t;

                var a = another.Value;
                a.X = 50;
                another.Value = a;
            }

            // Assert
            Assert.Equal(100, entity.Get<Position>().X);
            Assert.Equal(300, entity.Get<Health>().Value);
            Assert.Equal(180, entity.Get<Transform>().Rotation);
            Assert.Equal(50, entity.Get<AnotherComponent>().X);
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
            // Arrange
            using Scene scene = new Scene();
            for (int i = 0; i < 2; i++)
            {
                scene.Create(
                    new Position { X = i, Y = i * 2 },
                    new Velocity { VX = i * 0.5f, VY = i * 0.3f },
                    new Health { Value = i * 10 },
                    new Transform { X = i, Y = i, Rotation = i * 45 },
                    new TestComponent { Value = i, Name = $"Test{i}" },
                    new AnotherComponent { X = i * 2, Y = i * 3 }
                );
            }
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();

            // Act
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>())
            {
                count++;
            }

            // Assert
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
            // Assert
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
            // Arrange
            using Scene scene = new Scene();
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();

            // Act
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>())
            {
                count++;
            }

            // Assert
            Assert.Equal(0, count);
        }
    }
}

