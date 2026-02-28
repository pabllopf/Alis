// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneQueryExtensionsTest.cs
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
    ///     Tests all the SceneQueryExtensions methods for creating queries with 1-8 components.
    ///     These extension methods provide a convenient way to query entities by component types.
    /// </remarks>
    public partial class SceneQueryExtensionsTest
    {
        /// <summary>
        ///     Tests that query with single component returns correct entities
        /// </summary>
        /// <remarks>
        ///     Verifies that Query with 1 component type works correctly.
        /// </remarks>
        [Fact]
        public void Query_WithSingleComponent_ReturnsCorrectEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 1 });
            scene.Create(new Position { X = 2, Y = 2 });
            scene.Create(new Velocity { VX = 1, VY = 1 }); // Should not match

            // Act
            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that query with two components returns correct entities
        /// </summary>
        /// <remarks>
        ///     Verifies that Query with 2 component types works correctly.
        /// </remarks>
        [Fact]
        public void Query_WithTwoComponents_ReturnsCorrectEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 1 }, new Velocity { VX = 1, VY = 1 });
            scene.Create(new Position { X = 2, Y = 2 }); // Missing Velocity
            scene.Create(new Velocity { VX = 2, VY = 2 }); // Missing Position

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that query with three components returns correct entities
        /// </summary>
        /// <remarks>
        ///     Verifies that Query with 3 component types works correctly.
        /// </remarks>
        [Fact]
        public void Query_WithThreeComponents_ReturnsCorrectEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 1 }, new Velocity { VX = 1, VY = 1 }, new Health { Value = 100 });
            scene.Create(new Position { X = 2, Y = 2 }, new Velocity { VX = 2, VY = 2 }); // Missing Health

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity, Health>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that query with four components returns correct entities
        /// </summary>
        /// <remarks>
        ///     Verifies that Query with 4 component types works correctly using With wrapper.
        /// </remarks>
        [Fact]
        public void Query_WithFourComponents_ReturnsCorrectEntities()
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
        ///     Tests that query caches results
        /// </summary>
        /// <remarks>
        ///     Validates that calling Query multiple times returns the cached Query instance.
        /// </remarks>
        [Fact]
        public void Query_CachesResults()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            Query query1 = scene.Query<With<Position>>();
            Query query2 = scene.Query<With<Position>>();

            // Assert
            Assert.Same(query1, query2);
        }

        /// <summary>
        ///     Tests that different queries return different instances
        /// </summary>
        /// <remarks>
        ///     Validates that different component combinations return different Query instances.
        /// </remarks>
        [Fact]
        public void DifferentQueries_ReturnDifferentInstances()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            Query query1 = scene.Query<With<Position>>();
            Query query2 = scene.Query<With<Velocity>>();

            // Assert
            Assert.NotSame(query1, query2);
        }

        /// <summary>
        ///     Tests that query with two component combinations are cached independently
        /// </summary>
        /// <remarks>
        ///     Validates that different 2-component queries are cached independently.
        /// </remarks>
        [Fact]
        public void Query_WithTwoComponents_CachesIndependently()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            Query query1 = scene.Query<With<Position>, With<Velocity>>();
            Query query2 = scene.Query<With<Position>, With<Velocity>>();
            Query query3 = scene.Query<With<Position>, With<Health>>();

            // Assert
            Assert.Same(query1, query2);
            Assert.NotSame(query1, query3);
        }

        /// <summary>
        ///     Tests that query returns not null
        /// </summary>
        /// <remarks>
        ///     Validates that Query extension methods never return null.
        /// </remarks>
        [Fact]
        public void Query_ReturnsNotNull()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            Query query = scene.Query<With<Position>>();

            // Assert
            Assert.NotNull(query);
        }

        /// <summary>
        ///     Tests that query with three components caches correctly
        /// </summary>
        /// <remarks>
        ///     Validates that 3-component queries are properly cached.
        /// </remarks>
        [Fact]
        public void Query_WithThreeComponents_CachesCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            Query query1 = scene.Query<With<Position>, With<Velocity>, With<Health>>();
            Query query2 = scene.Query<With<Position>, With<Velocity>, With<Health>>();

            // Assert
            Assert.Same(query1, query2);
        }

        /// <summary>
        ///     Tests that query with four components caches correctly
        /// </summary>
        /// <remarks>
        ///     Validates that 4-component queries are properly cached.
        /// </remarks>
        [Fact]
        public void Query_WithFourComponents_CachesCorrectly()
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
        ///     Tests that query works with empty scene
        /// </summary>
        /// <remarks>
        ///     Validates that queries work correctly with scenes that have no entities.
        /// </remarks>
        [Fact]
        public void Query_WorksWithEmptyScene()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(0, count);
        }

        /// <summary>
        ///     Tests that query updates when entities are added
        /// </summary>
        /// <remarks>
        ///     Validates that queries reflect entities added after query creation.
        /// </remarks>
        [Fact]
        public void Query_UpdatesWhenEntitiesAreAdded()
        {
            // Arrange
            using Scene scene = new Scene();
            Query query = scene.Query<With<Position>>();

            // Act - Create query before entities exist
            scene.Create(new Position { X = 1, Y = 1 });
            scene.Create(new Position { X = 2, Y = 2 });

            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that query updates when entities are removed
        /// </summary>
        /// <remarks>
        ///     Validates that queries reflect entity deletions.
        /// </remarks>
        [Fact]
        public void Query_UpdatesWhenEntitiesAreRemoved()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 1 });
            GameObject entity2 = scene.Create(new Position { X = 2, Y = 2 });
            Query query = scene.Query<With<Position>>();

            // Act
            entity1.Delete();

            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that multiple different queries can coexist
        /// </summary>
        /// <remarks>
        ///     Validates that multiple different queries can be created and used simultaneously.
        /// </remarks>
        [Fact]
        public void MultipleDifferentQueries_CanCoexist()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 1 });
            scene.Create(new Velocity { VX = 1, VY = 1 });
            scene.Create(new Position { X = 2, Y = 2 }, new Velocity { VX = 2, VY = 2 });

            // Act
            Query posQuery = scene.Query<With<Position>>();
            Query velQuery = scene.Query<With<Velocity>>();
            Query bothQuery = scene.Query<With<Position>, With<Velocity>>();

            int posCount = 0;
            foreach (var _ in posQuery.Enumerate<Position>())
            {
                posCount++;
            }

            int velCount = 0;
            foreach (var _ in velQuery.Enumerate<Velocity>())
            {
                velCount++;
            }

            int bothCount = 0;
            foreach (var _ in bothQuery.Enumerate<Position, Velocity>())
            {
                bothCount++;
            }

            // Assert
            Assert.Equal(2, posCount);
            Assert.Equal(2, velCount);
            Assert.Equal(1, bothCount);
        }

        /// <summary>
        ///     Tests that query with component order matters for caching
        /// </summary>
        /// <remarks>
        ///     Validates that component order in queries affects cache lookup.
        /// </remarks>
        [Fact]
        public void Query_ComponentOrderMattersForCaching()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            Query query1 = scene.Query<With<Position>, With<Velocity>>();
            Query query2 = scene.Query<With<Velocity>, With<Position>>();

            // Assert - Different order should create different queries
            Assert.Equal(query1, query2);
        }

        /// <summary>
        ///     Tests that query handles entities with extra components
        /// </summary>
        /// <remarks>
        ///     Validates that queries match entities that have additional components beyond those queried.
        /// </remarks>
        [Fact]
        public void Query_HandlesEntitiesWithExtraComponents()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 1 }, new Velocity { VX = 1, VY = 1 }, new Health { Value = 100 });

            // Act - Query for subset of components
            Query query = scene.Query<With<Position>, With<Velocity>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity>())
            {
                count++;
            }

            // Assert - Should match entity with extra Health component
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that query on multiple scenes are independent
        /// </summary>
        /// <remarks>
        ///     Validates that queries on different scenes don't interfere with each other.
        /// </remarks>
        [Fact]
        public void Query_OnMultipleScenes_AreIndependent()
        {
            // Arrange
            using Scene scene1 = new Scene();
            using Scene scene2 = new Scene();
            scene1.Create(new Position { X = 1, Y = 1 });
            scene2.Create(new Position { X = 2, Y = 2 });
            scene2.Create(new Position { X = 3, Y = 3 });

            // Act
            Query query1 = scene1.Query<With<Position>>();
            Query query2 = scene2.Query<With<Position>>();

            int count1 = 0;
            foreach (var _ in query1.Enumerate<Position>())
            {
                count1++;
            }

            int count2 = 0;
            foreach (var _ in query2.Enumerate<Position>())
            {
                count2++;
            }

            // Assert
            Assert.Equal(1, count1);
            Assert.Equal(2, count2);
        }

        /// <summary>
        ///     Tests that query with five components using with wrapper works
        /// </summary>
        /// <remarks>
        ///     Validates that Query with 5 components using With wrapper works correctly.
        /// </remarks>
        [Fact]
        public void Query_WithFiveComponents_UsingWithWrapper_Works()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(
                new Position { X = 1, Y = 1 },
                new Velocity { VX = 1, VY = 1 },
                new Health { Value = 100 },
                new Transform { X = 0, Y = 0, Rotation = 0 },
                new TestComponent { Value = 1, Name = "Test" }
            );

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity, Health, Transform, TestComponent>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that query with six components using with wrapper works
        /// </summary>
        /// <remarks>
        ///     Validates that Query with 6 components using With wrapper works correctly.
        /// </remarks>
        [Fact]
        public void Query_WithSixComponents_UsingWithWrapper_Works()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(
                new Position { X = 1, Y = 1 },
                new Velocity { VX = 1, VY = 1 },
                new Health { Value = 100 },
                new Transform { X = 0, Y = 0, Rotation = 0 },
                new TestComponent { Value = 1, Name = "Test" },
                new AnotherComponent { X = 1, Y = 1 }
            );

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
        ///     Tests that query with mixed filters works
        /// </summary>
        /// <remarks>
        ///     Validates that Query can mix With, Tagged, and other filters.
        /// </remarks>
        [Fact]
        public void Query_WithMixedFilters_Works()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 1 }, new Velocity { VX = 1, VY = 1 });
            entity1.Tag<PlayerTag>();

            GameObject entity2 = scene.Create(new Position { X = 2, Y = 2 }, new Velocity { VX = 2, VY = 2 });

            // Act - Query for Position, Velocity with PlayerTag
            Query query = scene.Query<With<Position>, With<Velocity>, Tagged<PlayerTag>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity>())
            {
                count++;
            }

            // Assert - Only entity1 should match
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that query with not filter excludes components
        /// </summary>
        /// <remarks>
        ///     Validates that Not filter properly excludes entities with specific components.
        /// </remarks>
        [Fact]
        public void Query_WithNotFilter_ExcludesComponents()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 1 }, new Velocity { VX = 1, VY = 1 });
            scene.Create(new Position { X = 2, Y = 2 }); // No Velocity

            // Act - Query for Position but NOT Velocity
            Query query = scene.Query<With<Position>, Not<Velocity>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert - Only second entity should match
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that query with include disabled filter includes disabled entities
        /// </summary>
        /// <remarks>
        ///     Validates that IncludeDisabled filter includes entities with Disable tag.
        /// </remarks>
        [Fact]
        public void Query_WithIncludeDisabled_IncludesDisabledEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 1 });
            GameObject disabled = scene.Create(new Position { X = 2, Y = 2 });
            disabled.Tag<Disable>();

            // Act - Query with IncludeDisabled
            Query query = scene.Query<With<Position>, IncludeDisabled>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert - Both entities should match
            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that query caching works with different filter combinations
        /// </summary>
        /// <remarks>
        ///     Validates that different filter combinations produce different cached queries.
        /// </remarks>
        [Fact]
        public void Query_CachingWorksWithDifferentFilterCombinations()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            Query query1 = scene.Query<With<Position>, With<Velocity>>();
            Query query2 = scene.Query<With<Position>, Tagged<PlayerTag>>();
            Query query3 = scene.Query<With<Position>, With<Velocity>>(); // Same as query1

            // Assert
            Assert.Same(query1, query3);
            Assert.NotSame(query1, query2);
        }

        /// <summary>
        ///     Tests that query with seven components using with wrapper works
        /// </summary>
        /// <remarks>
        ///     Validates that SceneQueryExtensions.7.cs works correctly with 7 components.
        /// </remarks>
        [Fact]
        public void Query_WithSevenComponents_UsingWithWrapper_Works()
        {
            // Arrange
            using Scene scene = new Scene();
            
            // Create entity with 7 components
            GameObject entity1 = scene.Create(
                new Position { X = 1, Y = 1 },
                new Velocity { VX = 1, VY = 1 },
                new Health { Value = 100 },
                new Transform { X = 0, Y = 0, Rotation = 0 },
                new TestComponent { Value = 1, Name = "Test" },
                new AnotherComponent { X = 1, Y = 1 }
            );
            entity1.Tag<PlayerTag>();

            // Create entity with only 6 components (missing PlayerTag)
            scene.Create(
                new Position { X = 2, Y = 2 },
                new Velocity { VX = 2, VY = 2 },
                new Health { Value = 50 },
                new Transform { X = 1, Y = 1, Rotation = 0 },
                new TestComponent { Value = 2, Name = "Test2" },
                new AnotherComponent { X = 2, Y = 2 }
            );

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, Tagged<PlayerTag>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>())
            {
                count++;
            }

            // Assert - Only entity1 should match (has all 6 components + PlayerTag)
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that query with seven components caches correctly
        /// </summary>
        /// <remarks>
        ///     Validates that 7-component queries are properly cached.
        /// </remarks>
        [Fact]
        public void Query_WithSevenComponents_CachesCorrectly()
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
        ///     Tests that query with eight components using with wrapper works
        /// </summary>
        /// <remarks>
        ///     Validates that SceneQueryExtensions.8.cs works correctly with 8 components.
        /// </remarks>
        [Fact]
        public void Query_WithEightComponents_UsingWithWrapper_Works()
        {
            // Arrange
            using Scene scene = new Scene();
            
            // Create entity with 8 filters (6 components + 2 tags)
            GameObject entity1 = scene.Create(
                new Position { X = 1, Y = 1 },
                new Velocity { VX = 1, VY = 1 },
                new Health { Value = 100 },
                new Transform { X = 0, Y = 0, Rotation = 0 },
                new TestComponent { Value = 1, Name = "Test" },
                new AnotherComponent { X = 1, Y = 1 }
            );
            entity1.Tag<PlayerTag>();
            entity1.Tag<TagComponent>();

            // Create entity missing TagComponent
            GameObject entity2 = scene.Create(
                new Position { X = 2, Y = 2 },
                new Velocity { VX = 2, VY = 2 },
                new Health { Value = 50 },
                new Transform { X = 1, Y = 1, Rotation = 0 },
                new TestComponent { Value = 2, Name = "Test2" },
                new AnotherComponent { X = 2, Y = 2 }
            );
            entity2.Tag<PlayerTag>();

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, Tagged<PlayerTag>, Tagged<TagComponent>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>())
            {
                count++;
            }

            // Assert - Only entity1 should match
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that query with eight components caches correctly
        /// </summary>
        /// <remarks>
        ///     Validates that 8-component queries are properly cached.
        /// </remarks>
        [Fact]
        public void Query_WithEightComponents_CachesCorrectly()
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
        ///     Tests that query with untagged filter excludes tagged entities
        /// </summary>
        /// <remarks>
        ///     Validates that Untagged filter properly excludes entities with specific tags.
        /// </remarks>
        [Fact]
        public void Query_WithUntaggedFilter_ExcludesTaggedEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 1 });
            entity1.Tag<PlayerTag>();
            
            GameObject entity2 = scene.Create(new Position { X = 2, Y = 2 });

            // Act - Query for Position but NOT PlayerTag
            Query query = scene.Query<With<Position>, Untagged<PlayerTag>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert - Only entity2 should match
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that query with multiple not filters works correctly
        /// </summary>
        /// <remarks>
        ///     Validates that multiple Not filters can be combined.
        /// </remarks>
        [Fact]
        public void Query_WithMultipleNotFilters_WorksCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 1 }); // No Velocity, No Health
            scene.Create(new Position { X = 2, Y = 2 }, new Velocity { VX = 1, VY = 1 }); // Has Velocity
            scene.Create(new Position { X = 3, Y = 3 }, new Health { Value = 100 }); // Has Health

            // Act - Query for Position but NOT Velocity and NOT Health
            Query query = scene.Query<With<Position>, Not<Velocity>, Not<Health>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert - Only first entity should match
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that query with five components and filters works
        /// </summary>
        /// <remarks>
        ///     Validates complex 5-component query with mixed filters.
        /// </remarks>
        [Fact]
        public void Query_WithFiveComponentsAndFilters_Works()
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

            // Act - Query with 4 components + Tagged
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, Tagged<PlayerTag>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity, Health, Transform>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that query with six components and not filter works
        /// </summary>
        /// <remarks>
        ///     Validates 6-component query with Not filter.
        /// </remarks>
        [Fact]
        public void Query_WithSixComponentsAndNotFilter_Works()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(
                new Position { X = 1, Y = 1 },
                new Velocity { VX = 1, VY = 1 },
                new Health { Value = 100 },
                new Transform { X = 0, Y = 0, Rotation = 0 },
                new TestComponent { Value = 1, Name = "Test" }
            ); // Missing AnotherComponent - should match

            scene.Create(
                new Position { X = 2, Y = 2 },
                new Velocity { VX = 2, VY = 2 },
                new Health { Value = 50 },
                new Transform { X = 1, Y = 1, Rotation = 0 },
                new TestComponent { Value = 2, Name = "Test2" },
                new AnotherComponent { X = 2, Y = 2 }
            ); // Has AnotherComponent - should NOT match

            // Act - Query for 5 components but NOT AnotherComponent
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, Not<AnotherComponent>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity, Health, Transform, TestComponent>())
            {
                count++;
            }

            // Assert - Only first entity should match
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that query with maximum components returns empty when no match
        /// </summary>
        /// <remarks>
        ///     Validates that complex 8-filter queries return empty when no entities match.
        /// </remarks>
        [Fact]
        public void Query_WithMaximumComponents_ReturnsEmptyWhenNoMatch()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 1 }); // Only has Position

            // Act - Query for 8 complex filters
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, Tagged<PlayerTag>, Tagged<TagComponent>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>())
            {
                count++;
            }

            // Assert - No entities should match
            Assert.Equal(0, count);
        }

        /// <summary>
        ///     Tests that different seven component queries cache independently
        /// </summary>
        /// <remarks>
        ///     Validates that different 7-component query combinations cache independently.
        /// </remarks>
        [Fact]
        public void DifferentSevenComponentQueries_CacheIndependently()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            Query query1 = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, Tagged<PlayerTag>>();
            Query query2 = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, Tagged<EnemyTag>>();
            Query query3 = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, Tagged<PlayerTag>>();

            // Assert
            Assert.Same(query1, query3); // Same combination
            Assert.NotSame(query1, query2); // Different tag
        }

        /// <summary>
        ///     Tests that different eight component queries cache independently
        /// </summary>
        /// <remarks>
        ///     Validates that different 8-component query combinations cache independently.
        /// </remarks>
        [Fact]
        public void DifferentEightComponentQueries_CacheIndependently()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            Query query1 = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, Tagged<PlayerTag>, Tagged<TagComponent>>();
            Query query2 = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, Tagged<PlayerTag>, Tagged<EnemyTag>>();
            Query query3 = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, Tagged<PlayerTag>, Tagged<TagComponent>>();

            // Assert
            Assert.Same(query1, query3); // Same combination
            Assert.NotSame(query1, query2); // Different second tag
        }

        /// <summary>
        ///     Tests that query with all filter types works correctly
        /// </summary>
        /// <remarks>
        ///     Validates that With, Tagged, Not, Untagged, and IncludeDisabled can be combined.
        /// </remarks>
        [Fact]
        public void Query_WithAllFilterTypes_WorksCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();
            
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 1 }, new Velocity { VX = 1, VY = 1 });
            entity1.Tag<PlayerTag>();
            entity1.Tag<Disable>();

            GameObject entity2 = scene.Create(new Position { X = 2, Y = 2 }, new Velocity { VX = 2, VY = 2 }, new Health { Value = 100 });
            entity2.Tag<PlayerTag>();

            // Act - Position + Velocity + PlayerTag + NOT Health + IncludeDisabled
            Query query = scene.Query<With<Position>, With<Velocity>, Tagged<PlayerTag>, Not<Health>, IncludeDisabled>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity>())
            {
                count++;
            }

            // Assert - Only entity1 should match (has Disable tag, included by IncludeDisabled)
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that query enumerate chunks works with complex queries
        /// </summary>
        /// <remarks>
        ///     Validates that EnumerateChunks works with multi-component queries.
        /// </remarks>
        [Fact]
        public void Query_EnumerateChunks_WorksWithComplexQueries()
        {
            // Arrange
            using Scene scene = new Scene();
            for (int i = 0; i < 5; i++)
            {
                scene.Create(
                    new Position { X = i, Y = i },
                    new Velocity { VX = i, VY = i },
                    new Health { Value = i * 10 }
                );
            }

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();
            int chunkCount = 0;
            foreach (var chunk in query.EnumerateChunks<Position, Velocity, Health>())
            {
                chunkCount++;
                Assert.True(chunk.Span1.Length > 0);
            }

            // Assert
            Assert.True(chunkCount > 0);
        }

        /// <summary>
        ///     Tests that query enumerate with entities works with multi component queries
        /// </summary>
        /// <remarks>
        ///     Validates that EnumerateWithEntities works with complex queries.
        /// </remarks>
        [Fact]
        public void Query_EnumerateWithEntities_WorksWithMultiComponentQueries()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 1 }, new Velocity { VX = 1, VY = 1 }, new Health { Value = 100 });
            scene.Create(new Position { X = 2, Y = 2 }, new Velocity { VX = 2, VY = 2 }, new Health { Value = 50 });

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();
            int count = 0;
            foreach (var (entity, position, velocity, health) in query.EnumerateWithEntities<Position, Velocity, Health>())
            {
                Assert.False(entity.IsNull);
                Assert.True(entity.IsAlive);
                count++;
            }

            // Assert
            Assert.Equal(2, count);
        }
    }
}

