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
    ///     Tests for SceneQueryExtensions.5.cs - Query methods with 5 rule providers.
    /// </remarks>
    public partial class SceneQueryExtensionsTest
    {
        /// <summary>
        ///     Tests that query with five rule providers returns valid query
        /// </summary>
        /// <remarks>
        ///     Verifies that Query with 5 IRuleProvider types creates a valid Query instance.
        /// </remarks>
        [Fact]
        public void Query_WithFiveRuleProviders_ReturnsValidQuery()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>>();

            // Assert
            Assert.NotNull(query);
        }

        /// <summary>
        ///     Tests that five rule provider query filters correctly
        /// </summary>
        /// <remarks>
        ///     Validates that only entities with all five components are returned.
        /// </remarks>
        [Fact]
        public void FiveRuleProviderQuery_FiltersCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(
                new Position { X = 1, Y = 1 },
                new Velocity { VX = 1, VY = 1 },
                new Health { Value = 100 },
                new Transform { X = 0, Y = 0, Rotation = 0 },
                new TestComponent { Value = 42, Name = "Test" }
            );
            scene.Create(
                new Position { X = 2, Y = 2 },
                new Velocity { VX = 2, VY = 2 },
                new Health { Value = 50 },
                new Transform { X = 1, Y = 1, Rotation = 0 }
            ); // Missing TestComponent

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>>();
            int count = 0;
            foreach (RefTuple<Position, Velocity, Health, Transform, TestComponent> _ in query.Enumerate<Position, Velocity, Health, Transform, TestComponent>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that five rule provider query enumerates all components
        /// </summary>
        /// <remarks>
        ///     Validates that enumeration provides access to all five component types.
        /// </remarks>
        [Fact]
        public void FiveRuleProviderQuery_EnumeratesAllComponents()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(
                new Position { X = 10, Y = 20 },
                new Velocity { VX = 5, VY = 10 },
                new Health { Value = 150 },
                new Transform { X = 1, Y = 2, Rotation = 45 },
                new TestComponent { Value = 999, Name = "TestEntity" }
            );

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>>();
            bool found = false;
            foreach ((Ref<Position> pos, Ref<Velocity> vel, Ref<Health> health, Ref<Transform> trans, Ref<TestComponent> test) in query.Enumerate<Position, Velocity, Health, Transform, TestComponent>())
            {
                Assert.Equal(10, pos.Value.X);
                Assert.Equal(20, pos.Value.Y);
                Assert.Equal(5, vel.Value.VX);
                Assert.Equal(150, health.Value.Value);
                Assert.Equal(45, trans.Value.Rotation);
                Assert.Equal(999, test.Value.Value);
                Assert.Equal("TestEntity", test.Value.Name);
                found = true;
            }

            // Assert
            Assert.True(found);
        }

        /// <summary>
        ///     Tests that five rule provider query caches correctly
        /// </summary>
        /// <remarks>
        ///     Validates that identical five-rule-provider queries return the same cached instance.
        /// </remarks>
        [Fact]
        public void FiveRuleProviderQuery_CachesCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            Query query1 = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>>();
            Query query2 = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>>();

            // Assert
            Assert.Same(query1, query2);
        }

        /// <summary>
        ///     Tests that five rule provider query with tagged filter works
        /// </summary>
        /// <remarks>
        ///     Validates that mixing 4 With filters and 1 Tagged filter works.
        /// </remarks>
        [Fact]
        public void FiveRuleProviderQuery_WithTaggedFilter_Works()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(
                new Position { X = 1, Y = 1 },
                new Velocity { VX = 1, VY = 1 },
                new Health { Value = 100 },
                new Transform { X = 0, Y = 0, Rotation = 0 }
            );
            entity1.Tag<PlayerTag>();

            GameObject entity2 = scene.Create(
                new Position { X = 2, Y = 2 },
                new Velocity { VX = 2, VY = 2 },
                new Health { Value = 50 },
                new Transform { X = 1, Y = 1, Rotation = 0 }
            );

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, Tagged<PlayerTag>>();
            int count = 0;
            foreach (RefTuple<Position, Velocity, Health, Transform> _ in query.Enumerate<Position, Velocity, Health, Transform>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that five rule provider query with not filter excludes components
        /// </summary>
        /// <remarks>
        ///     Validates that mixing With and Not filters excludes entities correctly.
        /// </remarks>
        [Fact]
        public void FiveRuleProviderQuery_WithNotFilter_ExcludesComponents()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(
                new Position { X = 1, Y = 1 },
                new Velocity { VX = 1, VY = 1 },
                new Health { Value = 100 },
                new Transform { X = 0, Y = 0, Rotation = 0 }
            ); // No TestComponent - should match

            scene.Create(
                new Position { X = 2, Y = 2 },
                new Velocity { VX = 2, VY = 2 },
                new Health { Value = 50 },
                new Transform { X = 1, Y = 1, Rotation = 0 },
                new TestComponent { Value = 1, Name = "Test" }
            ); // Has TestComponent - should NOT match

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, Not<TestComponent>>();
            int count = 0;
            foreach (RefTuple<Position, Velocity, Health, Transform> _ in query.Enumerate<Position, Velocity, Health, Transform>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that five rule provider query works with include disabled
        /// </summary>
        /// <remarks>
        ///     Validates that IncludeDisabled includes disabled entities in results.
        /// </remarks>
        [Fact]
        public void FiveRuleProviderQuery_WithIncludeDisabled_Works()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(
                new Position { X = 1, Y = 1 },
                new Velocity { VX = 1, VY = 1 },
                new Health { Value = 100 },
                new Transform { X = 0, Y = 0, Rotation = 0 }
            );

            GameObject disabled = scene.Create(
                new Position { X = 2, Y = 2 },
                new Velocity { VX = 2, VY = 2 },
                new Health { Value = 50 },
                new Transform { X = 1, Y = 1, Rotation = 0 }
            );
            disabled.Tag<Disable>();

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, IncludeDisabled>();
            int count = 0;
            foreach (RefTuple<Position, Velocity, Health, Transform> _ in query.Enumerate<Position, Velocity, Health, Transform>())
            {
                count++;
            }

            // Assert
            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that five rule provider query can combine multiple filter types
        /// </summary>
        /// <remarks>
        ///     Validates that With, Tagged, and Not filters can be combined.
        /// </remarks>
        [Fact]
        public void FiveRuleProviderQuery_CanCombineMultipleFilterTypes()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(
                new Position { X = 1, Y = 1 },
                new Velocity { VX = 1, VY = 1 },
                new Health { Value = 100 }
            );
            entity1.Tag<PlayerTag>();

            GameObject entity2 = scene.Create(
                new Position { X = 2, Y = 2 },
                new Velocity { VX = 2, VY = 2 },
                new Health { Value = 50 },
                new Transform { X = 0, Y = 0, Rotation = 0 }
            );
            entity2.Tag<PlayerTag>();

            // Act - With Position, Velocity, Health + Tagged PlayerTag + Not Transform
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, Tagged<PlayerTag>, Not<Transform>>();
            int count = 0;
            foreach (RefTuple<Position, Velocity, Health> _ in query.Enumerate<Position, Velocity, Health>())
            {
                count++;
            }

            // Assert - Only entity1 matches (has PlayerTag, no Transform)
            Assert.Equal(1, count);
        }
    }
}

