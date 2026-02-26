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
    ///     Tests for SceneQueryExtensions.4.cs - Query methods with 4 rule providers.
    /// </remarks>
    public partial class SceneQueryExtensionsTest
    {
        /// <summary>
        ///     Tests that query with four rule providers returns valid query
        /// </summary>
        /// <remarks>
        ///     Verifies that Query with 4 IRuleProvider types creates a valid Query instance.
        /// </remarks>
        [Fact]
        public void Query_WithFourRuleProviders_ReturnsValidQuery()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>>();

            // Assert
            Assert.NotNull(query);
        }

        /// <summary>
        ///     Tests that four rule provider query filters correctly
        /// </summary>
        /// <remarks>
        ///     Validates that only entities with all four components are returned.
        /// </remarks>
        [Fact]
        public void FourRuleProviderQuery_FiltersCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(
                new Position { X = 1, Y = 1 },
                new Velocity { VX = 1, VY = 1 },
                new Health { Value = 100 },
                new Transform { X = 0, Y = 0, Rotation = 0 }
            );
            scene.Create(new Position { X = 2, Y = 2 }, new Velocity { VX = 2, VY = 2 }, new Health { Value = 50 }); // Missing Transform

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity, Health, Transform>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that four rule provider query enumerates all components
        /// </summary>
        /// <remarks>
        ///     Validates that enumeration provides access to all four component types.
        /// </remarks>
        [Fact]
        public void FourRuleProviderQuery_EnumeratesAllComponents()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(
                new Position { X = 10, Y = 20 },
                new Velocity { VX = 5, VY = 10 },
                new Health { Value = 150 },
                new Transform { X = 1, Y = 2, Rotation = 45 }
            );

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>>();
            bool found = false;
            foreach (var (pos, vel, health, trans) in query.Enumerate<Position, Velocity, Health, Transform>())
            {
                Assert.Equal(10, pos.Value.X);
                Assert.Equal(20, pos.Value.Y);
                Assert.Equal(5, vel.Value.VX);
                Assert.Equal(10, vel.Value.VY);
                Assert.Equal(150, health.Value.Value);
                Assert.Equal(1, trans.Value.X);
                Assert.Equal(2, trans.Value.Y);
                Assert.Equal(45, trans.Value.Rotation);
                found = true;
            }

            // Assert
            Assert.True(found);
        }

        /// <summary>
        ///     Tests that four rule provider query caches correctly
        /// </summary>
        /// <remarks>
        ///     Validates that identical four-rule-provider queries return the same cached instance.
        /// </remarks>
        [Fact]
        public void FourRuleProviderQuery_CachesCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            Query query1 = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>>();
            Query query2 = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>>();

            // Assert
            Assert.Same(query1, query2);
        }

        /// <summary>
        ///     Tests that four rule provider query with mixed filters works
        /// </summary>
        /// <remarks>
        ///     Validates that mixing With and Tagged filters works correctly.
        /// </remarks>
        [Fact]
        public void FourRuleProviderQuery_WithMixedFilters_Works()
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
                new Health { Value = 50 }
            );

            // Act - Query with 3 With + 1 Tagged
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, Tagged<PlayerTag>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity, Health>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that four rule provider query with not filter works
        /// </summary>
        /// <remarks>
        ///     Validates that mixing With and Not filters works correctly.
        /// </remarks>
        [Fact]
        public void FourRuleProviderQuery_WithNotFilter_Works()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 1 }, new Velocity { VX = 1, VY = 1 }, new Health { Value = 100 });
            scene.Create(
                new Position { X = 2, Y = 2 },
                new Velocity { VX = 2, VY = 2 },
                new Health { Value = 50 },
                new Transform { X = 0, Y = 0, Rotation = 0 }
            );

            // Act - Query with 3 With + 1 Not
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, Not<Transform>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity, Health>())
            {
                count++;
            }

            // Assert - Only first entity (without Transform) should match
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that four rule provider query works with multiple entities
        /// </summary>
        /// <remarks>
        ///     Validates that queries work correctly with multiple matching entities.
        /// </remarks>
        [Fact]
        public void FourRuleProviderQuery_WorksWithMultipleEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            for (int i = 0; i < 3; i++)
            {
                scene.Create(
                    new Position { X = i, Y = i },
                    new Velocity { VX = i, VY = i },
                    new Health { Value = i * 10 },
                    new Transform { X = i, Y = i, Rotation = i * 45 }
                );
            }

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity, Health, Transform>())
            {
                count++;
            }

            // Assert
            Assert.Equal(3, count);
        }

        /// <summary>
        ///     Tests that four rule provider query can modify components
        /// </summary>
        /// <remarks>
        ///     Validates that all four components can be modified during enumeration.
        /// </remarks>
        [Fact]
        public void FourRuleProviderQuery_CanModifyComponents()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position { X = 0, Y = 0 },
                new Velocity { VX = 0, VY = 0 },
                new Health { Value = 0 },
                new Transform { X = 0, Y = 0, Rotation = 0 }
            );

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>>();
            foreach (var (pos, vel, health, trans) in query.Enumerate<Position, Velocity, Health, Transform>())
            {
                var p = pos.Value;
                p.X = 100;
                pos.Value = p;

                var v = vel.Value;
                v.VX = 10;
                vel.Value = v;

                var h = health.Value;
                h.Value = 200;
                health.Value = h;

                var t = trans.Value;
                t.Rotation = 90;
                trans.Value = t;
            }

            // Assert
            Assert.Equal(100, entity.Get<Position>().X);
            Assert.Equal(10, entity.Get<Velocity>().VX);
            Assert.Equal(200, entity.Get<Health>().Value);
            Assert.Equal(90, entity.Get<Transform>().Rotation);
        }

        /// <summary>
        ///     Tests that four rule provider query with include disabled works
        /// </summary>
        /// <remarks>
        ///     Validates that IncludeDisabled filter includes disabled entities.
        /// </remarks>
        [Fact]
        public void FourRuleProviderQuery_WithIncludeDisabled_Works()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 1 }, new Velocity { VX = 1, VY = 1 }, new Health { Value = 100 });
            GameObject disabled = scene.Create(
                new Position { X = 2, Y = 2 },
                new Velocity { VX = 2, VY = 2 },
                new Health { Value = 50 }
            );
            disabled.Tag<Disable>();

            // Act - Query with 3 With + IncludeDisabled
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, IncludeDisabled>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity, Health>())
            {
                count++;
            }

            // Assert
            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that four rule provider query different combinations create different queries
        /// </summary>
        /// <remarks>
        ///     Validates that different filter combinations are cached separately.
        /// </remarks>
        [Fact]
        public void FourRuleProviderQuery_DifferentCombinations_CreateDifferentQueries()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            Query query1 = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>>();
            Query query2 = scene.Query<With<Position>, With<Velocity>, With<Health>, Tagged<PlayerTag>>();
            Query query3 = scene.Query<With<Position>, With<Velocity>, With<Health>, Not<Transform>>();

            // Assert
            Assert.NotSame(query1, query2);
            Assert.NotSame(query1, query3);
            Assert.NotSame(query2, query3);
        }
    }
}

