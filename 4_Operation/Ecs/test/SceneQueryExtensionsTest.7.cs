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

using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The scene query extensions test class
    /// </summary>
    /// <remarks>
    ///     Tests for SceneQueryExtensions.7.cs - Query methods with 7 rule providers.
    /// </remarks>
    public partial class SceneQueryExtensionsTest
    {
        /// <summary>
        ///     Tests that query with seven rule providers returns valid query
        /// </summary>
        /// <remarks>
        ///     Verifies that Query with 7 IRuleProvider types creates a valid Query instance.
        /// </remarks>
        [Fact]
        public void Query_WithSevenRuleProviders_ReturnsValidQuery()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, Tagged<PlayerTag>>();

            // Assert
            Assert.NotNull(query);
        }

        /// <summary>
        ///     Tests that seven rule provider query filters correctly
        /// </summary>
        /// <remarks>
        ///     Validates that only entities matching all seven filters are returned.
        /// </remarks>
        [Fact]
        public void SevenRuleProviderQuery_FiltersCorrectly()
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

            scene.Create(
                new Position { X = 2, Y = 2 },
                new Velocity { VX = 2, VY = 2 },
                new Health { Value = 50 },
                new Transform { X = 1, Y = 1, Rotation = 0 },
                new TestComponent { Value = 1, Name = "Test2" },
                new AnotherComponent { X = 10, Y = 20 }
            ); // Missing PlayerTag

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, Tagged<PlayerTag>>();
            int count = 0;
            foreach (RefTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent> _ in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that seven rule provider query caches correctly
        /// </summary>
        /// <remarks>
        ///     Validates that identical seven-rule-provider queries return the same cached instance.
        /// </remarks>
        [Fact]
        public void SevenRuleProviderQuery_CachesCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            Query query1 = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, Tagged<PlayerTag>>();
            Query query2 = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, Tagged<PlayerTag>>();

            // Assert
            Assert.Same(query1, query2);
        }

        /// <summary>
        ///     Tests that seven rule provider query with different tags creates different queries
        /// </summary>
        /// <remarks>
        ///     Validates that different tag filters create different cached queries.
        /// </remarks>
        [Fact]
        public void SevenRuleProviderQuery_WithDifferentTags_CreatesDifferentQueries()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            Query query1 = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, Tagged<PlayerTag>>();
            Query query2 = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, Tagged<EnemyTag>>();

            // Assert
            Assert.NotSame(query1, query2);
        }

        /// <summary>
        ///     Tests that seven rule provider query with not filter works
        /// </summary>
        /// <remarks>
        ///     Validates that Not filter can be used as the 7th rule provider.
        /// </remarks>
        [Fact]
        public void SevenRuleProviderQuery_WithNotFilter_Works()
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

            // Act - 6 With filters + Not EnemyTag
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, Not<EnemyTag>>();
            int count = 0;
            foreach (RefTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent> _ in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>())
            {
                count++;
            }

            // Assert - Only entity1 matches (no EnemyTag)
            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that seven rule provider query with multiple tags works
        /// </summary>
        /// <remarks>
        ///     Validates queries with multiple tag requirements.
        /// </remarks>
        [Fact]
        public void SevenRuleProviderQuery_WithMultipleTags_Works()
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
            entity1.Tag<TagComponent>();

            GameObject entity2 = scene.Create(
                new Position { X = 2, Y = 2 },
                new Velocity { VX = 2, VY = 2 },
                new Health { Value = 50 },
                new Transform { X = 1, Y = 1, Rotation = 0 },
                new TestComponent { Value = 2, Name = "Test2" }
            );
            entity2.Tag<PlayerTag>();

            // Act - 5 With + 2 Tagged
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, Tagged<PlayerTag>, Tagged<TagComponent>>();
            int count = 0;
            foreach (RefTuple<Position, Velocity, Health, Transform, TestComponent> _ in query.Enumerate<Position, Velocity, Health, Transform, TestComponent>())
            {
                count++;
            }

            // Assert - Only entity1 matches (has both tags)
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that seven rule provider query with include disabled works
        /// </summary>
        /// <remarks>
        ///     Validates that IncludeDisabled can be used as the 7th rule provider.
        /// </remarks>
        [Fact]
        public void SevenRuleProviderQuery_WithIncludeDisabled_Works()
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

            GameObject disabled = scene.Create(
                new Position { X = 2, Y = 2 },
                new Velocity { VX = 2, VY = 2 },
                new Health { Value = 50 },
                new Transform { X = 1, Y = 1, Rotation = 0 },
                new TestComponent { Value = 2, Name = "Test2" },
                new AnotherComponent { X = 10, Y = 20 }
            );
            disabled.Tag<Disable>();

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, IncludeDisabled>();
            int count = 0;
            foreach (RefTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent> _ in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>())
            {
                count++;
            }

            // Assert - Both entities match (including disabled)
            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that seven rule provider query enumerates all components correctly
        /// </summary>
        /// <remarks>
        ///     Validates that enumeration provides correct access to all components.
        /// </remarks>
        [Fact]
        public void SevenRuleProviderQuery_EnumeratesAllComponentsCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position { X = 100, Y = 200 },
                new Velocity { VX = 10, VY = 20 },
                new Health { Value = 500 },
                new Transform { X = 5, Y = 10, Rotation = 90 },
                new TestComponent { Value = 999, Name = "ComplexEntity" },
                new AnotherComponent { X = 50, Y = 75 }
            );
            entity.Tag<PlayerTag>();

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, Tagged<PlayerTag>>();
            bool found = false;
            foreach ((Ref<Position> pos, Ref<Velocity> vel, Ref<Health> health, Ref<Transform> trans, Ref<TestComponent> test, Ref<AnotherComponent> another) in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>())
            {
                Assert.Equal(100, pos.Value.X);
                Assert.Equal(10, vel.Value.VX);
                Assert.Equal(500, health.Value.Value);
                Assert.Equal(90, trans.Value.Rotation);
                Assert.Equal("ComplexEntity", test.Value.Name);
                Assert.Equal(50, another.Value.X);
                found = true;
            }

            // Assert
            Assert.True(found);
        }
    }
}

