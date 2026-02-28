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
    ///     Tests for SceneQueryExtensions.8.cs - Query methods with 8 rule providers (maximum complexity).
    /// </remarks>
    public partial class SceneQueryExtensionsTest
    {
        /// <summary>
        ///     Tests that query with eight rule providers returns valid query
        /// </summary>
        /// <remarks>
        ///     Verifies that Query with 8 IRuleProvider types creates a valid Query instance.
        /// </remarks>
        [Fact]
        public void Query_WithEightRuleProviders_ReturnsValidQuery()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, Tagged<PlayerTag>, Tagged<TagComponent>>();

            // Assert
            Assert.NotNull(query);
        }

        /// <summary>
        ///     Tests that eight rule provider query filters correctly
        /// </summary>
        /// <remarks>
        ///     Validates that only entities matching all eight filters are returned.
        /// </remarks>
        [Fact]
        public void EightRuleProviderQuery_FiltersCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(
                new Position { X = 1, Y = 1 },
                new Velocity { VX = 1, VY = 1 },
                new Health { Value = 100 },
                new Transform { X = 0, Y = 0, Rotation = 0 },
                new TestComponent { Value = 42, Name = "Test" },
                new AnotherComponent { X = 5, Y = 10 }
            );
            entity1.Tag<PlayerTag>();
            entity1.Tag<TagComponent>();

            GameObject entity2 = scene.Create(
                new Position { X = 2, Y = 2 },
                new Velocity { VX = 2, VY = 2 },
                new Health { Value = 50 },
                new Transform { X = 1, Y = 1, Rotation = 0 },
                new TestComponent { Value = 1, Name = "Test2" },
                new AnotherComponent { X = 10, Y = 20 }
            );
            entity2.Tag<PlayerTag>(); // Missing TagComponent

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, Tagged<PlayerTag>, Tagged<TagComponent>>();
            int count = 0;
            foreach (RefTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent> _ in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that eight rule provider query caches correctly
        /// </summary>
        /// <remarks>
        ///     Validates that identical eight-rule-provider queries return the same cached instance.
        /// </remarks>
        [Fact]
        public void EightRuleProviderQuery_CachesCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            Query query1 = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, Tagged<PlayerTag>, Tagged<TagComponent>>();
            Query query2 = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, Tagged<PlayerTag>, Tagged<TagComponent>>();

            // Assert
            Assert.Same(query1, query2);
        }

        /// <summary>
        ///     Tests that eight rule provider query with different last filter creates different query
        /// </summary>
        /// <remarks>
        ///     Validates that changing the 8th filter creates a different cached query.
        /// </remarks>
        [Fact]
        public void EightRuleProviderQuery_WithDifferentLastFilter_CreatesDifferentQuery()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            Query query1 = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, Tagged<PlayerTag>, Tagged<TagComponent>>();
            Query query2 = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, Tagged<PlayerTag>, Tagged<EnemyTag>>();

            // Assert
            Assert.NotSame(query1, query2);
        }

        /// <summary>
        ///     Tests that eight rule provider query with not filters works
        /// </summary>
        /// <remarks>
        ///     Validates that Not filters can be used in 8-filter queries.
        /// </remarks>
        [Fact]
        public void EightRuleProviderQuery_WithNotFilters_Works()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(
                new Position { X = 1, Y = 1 },
                new Velocity { VX = 1, VY = 1 },
                new Health { Value = 100 },
                new Transform { X = 0, Y = 0, Rotation = 0 },
                new TestComponent { Value = 1, Name = "Test" },
                new AnotherComponent { X = 5, Y = 10 }
            );
            entity1.Tag<PlayerTag>();

            GameObject entity2 = scene.Create(
                new Position { X = 2, Y = 2 },
                new Velocity { VX = 2, VY = 2 },
                new Health { Value = 50 },
                new Transform { X = 1, Y = 1, Rotation = 0 },
                new TestComponent { Value = 2, Name = "Test2" },
                new AnotherComponent { X = 10, Y = 20 }
            );
            entity2.Tag<PlayerTag>();
            entity2.Tag<TagComponent>();

            // Act - 6 With + Tagged PlayerTag + Not TagComponent
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, Tagged<PlayerTag>, Not<TagComponent>>();
            int count = 0;
            foreach (RefTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent> _ in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>())
            {
                count++;
            }

            // Assert - Only entity1 matches (no TagComponent)
            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that eight rule provider query with untagged filter works
        /// </summary>
        /// <remarks>
        ///     Validates that Untagged filter can be used in 8-filter queries.
        /// </remarks>
        [Fact]
        public void EightRuleProviderQuery_WithUntaggedFilter_Works()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(
                new Position { X = 1, Y = 1 },
                new Velocity { VX = 1, VY = 1 },
                new Health { Value = 100 },
                new Transform { X = 0, Y = 0, Rotation = 0 },
                new TestComponent { Value = 1, Name = "Test" },
                new AnotherComponent { X = 5, Y = 10 }
            );
            entity1.Tag<PlayerTag>();

            GameObject entity2 = scene.Create(
                new Position { X = 2, Y = 2 },
                new Velocity { VX = 2, VY = 2 },
                new Health { Value = 50 },
                new Transform { X = 1, Y = 1, Rotation = 0 },
                new TestComponent { Value = 2, Name = "Test2" },
                new AnotherComponent { X = 10, Y = 20 }
            );
            entity2.Tag<PlayerTag>();
            entity2.Tag<EnemyTag>();

            // Act - 6 With + Tagged PlayerTag + Untagged EnemyTag
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, Tagged<PlayerTag>, Untagged<EnemyTag>>();
            int count = 0;
            foreach (RefTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent> _ in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>())
            {
                count++;
            }

            // Assert - Only entity1 matches (not tagged with EnemyTag)
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that eight rule provider query with all filter types works
        /// </summary>
        /// <remarks>
        ///     Validates that With, Tagged, Not, and Untagged can all be combined.
        /// </remarks>
        [Fact]
        public void EightRuleProviderQuery_WithAllFilterTypes_Works()
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

            GameObject entity3 = scene.Create(
                new Position { X = 3, Y = 3 },
                new Velocity { VX = 3, VY = 3 },
                new Health { Value = 75 },
                new TestComponent { Value = 3, Name = "Test3" }
            );
            entity3.Tag<PlayerTag>();
            entity3.Tag<EnemyTag>();

            // Act - With 4 components + Tagged PlayerTag + Not Transform + Untagged EnemyTag + IncludeDisabled
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<TestComponent>, Tagged<PlayerTag>, Not<Transform>, Untagged<EnemyTag>, IncludeDisabled>();
            int count = 0;
            foreach (RefTuple<Position, Velocity, Health, TestComponent> _ in query.Enumerate<Position, Velocity, Health, TestComponent>())
            {
                count++;
            }

            // Assert - Only entity1 matches all filters
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that eight rule provider query works with empty scene
        /// </summary>
        /// <remarks>
        ///     Validates that complex queries work correctly with empty scenes.
        /// </remarks>
        [Fact]
        public void EightRuleProviderQuery_WorksWithEmptyScene()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, Tagged<PlayerTag>, Tagged<TagComponent>>();
            int count = 0;
            foreach (RefTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent> _ in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>())
            {
                count++;
            }

            // Assert
            Assert.Equal(0, count);
        }
    }
}

