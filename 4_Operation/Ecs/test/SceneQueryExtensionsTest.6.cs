// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneQueryExtensionsTest.2.cs
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
    ///     The scene query extensions test class
    /// </summary>
    /// <remarks>
    ///     Tests for SceneQueryExtensions.6.cs - Query methods with 6 rule providers.
    /// </remarks>
    public partial class SceneQueryExtensionsTest
    {
        /// <summary>
        ///     Tests that query with six rule providers returns valid query
        /// </summary>
        /// <remarks>
        ///     Verifies that Query with 6 IRuleProvider types creates a valid Query instance.
        /// </remarks>
        [Fact]
        public void Query_WithSixRuleProviders_ReturnsValidQuery()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();

            // Assert
            Assert.NotNull(query);
        }

        /// <summary>
        ///     Tests that six rule provider query filters correctly
        /// </summary>
        /// <remarks>
        ///     Validates that only entities with all six components are returned.
        /// </remarks>
        [Fact]
        public void SixRuleProviderQuery_FiltersCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(
                new Position { X = 1, Y = 1 },
                new Velocity { VX = 1, VY = 1 },
                new Health { Value = 100 },
                new Transform { X = 0, Y = 0, Rotation = 0 },
                new TestComponent { Value = 42, Name = "Test" },
                new AnotherComponent { X = 5, Y = 10 }
            );
            scene.Create(
                new Position { X = 2, Y = 2 },
                new Velocity { VX = 2, VY = 2 },
                new Health { Value = 50 },
                new Transform { X = 1, Y = 1, Rotation = 0 },
                new TestComponent { Value = 1, Name = "Test2" }
            ); // Missing AnotherComponent

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that six rule provider query enumerates all components
        /// </summary>
        /// <remarks>
        ///     Validates that enumeration provides access to all six component types.
        /// </remarks>
        [Fact]
        public void SixRuleProviderQuery_EnumeratesAllComponents()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(
                new Position { X = 10, Y = 20 },
                new Velocity { VX = 5, VY = 10 },
                new Health { Value = 150 },
                new Transform { X = 1, Y = 2, Rotation = 45 },
                new TestComponent { Value = 999, Name = "TestEntity" },
                new AnotherComponent { X = 100, Y = 200 }
            );

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();
            bool found = false;
            foreach (var (pos, vel, health, trans, test, another) in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>())
            {
                Assert.Equal(10, pos.Value.X);
                Assert.Equal(5, vel.Value.VX);
                Assert.Equal(150, health.Value.Value);
                Assert.Equal(45, trans.Value.Rotation);
                Assert.Equal(999, test.Value.Value);
                Assert.Equal(100, another.Value.X);
                Assert.Equal(200, another.Value.Y);
                found = true;
            }

            // Assert
            Assert.True(found);
        }

        /// <summary>
        ///     Tests that six rule provider query caches correctly
        /// </summary>
        /// <remarks>
        ///     Validates that identical six-rule-provider queries return the same cached instance.
        /// </remarks>
        [Fact]
        public void SixRuleProviderQuery_CachesCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            Query query1 = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();
            Query query2 = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();

            // Assert
            Assert.Same(query1, query2);
        }

        /// <summary>
        ///     Tests that six rule provider query with tagged works
        /// </summary>
        /// <remarks>
        ///     Validates that mixing 5 With filters and 1 Tagged filter works.
        /// </remarks>
        [Fact]
        public void SixRuleProviderQuery_WithTagged_Works()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(
                new Position { X = 1, Y = 1 },
                new Velocity { VX = 1, VY = 1 },
                new Health { Value = 100 },
                new Transform { X = 0, Y = 0, Rotation = 0 },
                new TestComponent { Value = 1, Name = "Test" }
            );
            entity1.Tag<PlayerTag>();

            scene.Create(
                new Position { X = 2, Y = 2 },
                new Velocity { VX = 2, VY = 2 },
                new Health { Value = 50 },
                new Transform { X = 1, Y = 1, Rotation = 0 },
                new TestComponent { Value = 2, Name = "Test2" }
            ); // No PlayerTag

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, Tagged<PlayerTag>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity, Health, Transform, TestComponent>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that six rule provider query with not filter works
        /// </summary>
        /// <remarks>
        ///     Validates that Not filter properly excludes entities.
        /// </remarks>
        [Fact]
        public void SixRuleProviderQuery_WithNotFilter_Works()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(
                new Position { X = 1, Y = 1 },
                new Velocity { VX = 1, VY = 1 },
                new Health { Value = 100 },
                new Transform { X = 0, Y = 0, Rotation = 0 },
                new TestComponent { Value = 1, Name = "Test" }
            ); // No AnotherComponent - should match

            scene.Create(
                new Position { X = 2, Y = 2 },
                new Velocity { VX = 2, VY = 2 },
                new Health { Value = 50 },
                new Transform { X = 1, Y = 1, Rotation = 0 },
                new TestComponent { Value = 2, Name = "Test2" },
                new AnotherComponent { X = 1, Y = 1 }
            ); // Has AnotherComponent - should NOT match

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, Not<AnotherComponent>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity, Health, Transform, TestComponent>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that six rule provider query works with multiple entities
        /// </summary>
        /// <remarks>
        ///     Validates that queries correctly handle multiple matching entities.
        /// </remarks>
        [Fact]
        public void SixRuleProviderQuery_WorksWithMultipleEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            for (int i = 0; i < 3; i++)
            {
                scene.Create(
                    new Position { X = i, Y = i },
                    new Velocity { VX = i, VY = i },
                    new Health { Value = i * 10 },
                    new Transform { X = i, Y = i, Rotation = i },
                    new TestComponent { Value = i, Name = $"Test{i}" },
                    new AnotherComponent { X = i * 2, Y = i * 3 }
                );
            }

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>())
            {
                count++;
            }

            // Assert
            Assert.Equal(3, count);
        }

        /// <summary>
        ///     Tests that six rule provider query with complex filter combination works
        /// </summary>
        /// <remarks>
        ///     Validates complex combinations of With, Tagged, and Not filters.
        /// </remarks>
        [Fact]
        public void SixRuleProviderQuery_WithComplexFilterCombination_Works()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(
                new Position { X = 1, Y = 1 },
                new Velocity { VX = 1, VY = 1 },
                new Health { Value = 100 },
                new TestComponent { Value = 1, Name = "Test" }
            );
            entity1.Tag<PlayerTag>();

            GameObject entity2 = scene.Create(
                new Position { X = 2, Y = 2 },
                new Velocity { VX = 2, VY = 2 },
                new Health { Value = 50 },
                new TestComponent { Value = 2, Name = "Test2" },
                new Transform { X = 0, Y = 0, Rotation = 0 }
            );
            entity2.Tag<PlayerTag>();

            // Act - With 4 components + Tagged + Not Transform
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<TestComponent>, Tagged<PlayerTag>, Not<Transform>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity, Health, TestComponent>())
            {
                count++;
            }

            // Assert - Only entity1 matches
            Assert.Equal(1, count);
        }
    }
}

