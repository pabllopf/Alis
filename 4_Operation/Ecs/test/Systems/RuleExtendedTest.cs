// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RuleExtendedTest.cs
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

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    ///     The rule extended test class
    /// </summary>
    /// <remarks>
    ///     Extended tests for Query rules, validating component filtering,
    ///     tag matching, and complex query combinations.
    /// </remarks>
    public class RuleExtendedTest
    {
        /// <summary>
        ///     Tests that with rule filters correctly
        /// </summary>
        /// <remarks>
        ///     Validates that With rule only includes entities with specified component.
        /// </remarks>
        [Fact]
        public void Rule_WithRuleFiltersCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 });
            scene.Create(new Velocity { VX = 3, VY = 4 }); // No Position

            // Act
            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that not rule excludes correctly
        /// </summary>
        /// <remarks>
        ///     Validates that Not rule excludes entities with specified component.
        /// </remarks>
        [Fact]
        public void Rule_NotRuleExcludesCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 });
            scene.Create(new Position { X = 3, Y = 4 }, new Velocity { VX = 5, VY = 6 });

            // Act
            Query query = scene.Query<With<Position>, Not<Velocity>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that tagged rule filters by tag
        /// </summary>
        /// <remarks>
        ///     Validates that Tagged rule only includes entities with specified tag.
        /// </remarks>
        [Fact]
        public void Rule_TaggedRuleFiltersCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 2 });
            GameObject entity2 = scene.Create(new Position { X = 3, Y = 4 });
            
            entity1.Tag<RuleTestPlayerTag>();

            // Act
            Query query = scene.Query<With<Position>, Tagged<RuleTestPlayerTag>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that untagged rule filters by absence of tag
        /// </summary>
        /// <remarks>
        ///     Validates that Untagged rule excludes entities with specified tag.
        /// </remarks>
        [Fact]
        public void Rule_UntaggedRuleFiltersCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 2 });
            GameObject entity2 = scene.Create(new Position { X = 3, Y = 4 });
            
            entity1.Tag<RuleTestPlayerTag>();

            // Act
            Query query = scene.Query<With<Position>, Untagged<RuleTestPlayerTag>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that multiple with rules work together
        /// </summary>
        /// <remarks>
        ///     Validates that multiple With rules combine with AND logic.
        /// </remarks>
        [Fact]
        public void Rule_MultipleWithRulesWork()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 });
            scene.Create(new Position { X = 3, Y = 4 }, new Velocity { VX = 5, VY = 6 });
            scene.Create(new Velocity { VX = 7, VY = 8 });

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
        ///     Tests that with and not rules combine correctly
        /// </summary>
        /// <remarks>
        ///     Validates that With and Not rules combine with AND logic.
        /// </remarks>
        [Fact]
        public void Rule_WithAndNotCombineCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 });
            scene.Create(new Position { X = 3, Y = 4 }, new Velocity { VX = 5, VY = 6 });
            scene.Create(new Position { X = 7, Y = 8 }, new Health { Value = 100 });

            // Act
            Query query = scene.Query<With<Position>, Not<Velocity>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that rules work with enabled/disabled filtering
        /// </summary>
        /// <remarks>
        ///     Validates that rules respect Disable tag by default.
        /// </remarks>
        [Fact]
        public void Rule_RespectsDisableTag()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 2 });
            GameObject entity2 = scene.Create(new Position { X = 3, Y = 4 });
            
            entity2.Tag<Disable>();

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
        ///     Tests that include disabled rule works
        /// </summary>
        /// <remarks>
        ///     Validates that IncludeDisabled overrides default Disable filtering.
        /// </remarks>
        [Fact]
        public void Rule_IncludeDisabledOverridesDefault()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 2 });
            GameObject entity2 = scene.Create(new Position { X = 3, Y = 4 });
            
            entity2.Tag<Disable>();

            // Act
            Query query = scene.Query<With<Position>, IncludeDisabled>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that complex rule combination works
        /// </summary>
        /// <remarks>
        ///     Validates that complex combinations of rules work correctly.
        /// </remarks>
        [Fact]
        public void Rule_ComplexCombinationWorks()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(
                new Position { X = 1, Y = 2 },
                new Velocity { VX = 3, VY = 4 }
            );
            GameObject entity2 = scene.Create(
                new Position { X = 5, Y = 6 },
                new Health { Value = 100 }
            );
            GameObject entity3 = scene.Create(
                new Position { X = 7, Y = 8 },
                new Velocity { VX = 9, VY = 10 },
                new Health { Value = 150 }
            );
            
            entity1.Tag<RuleTestPlayerTag>();
            entity3.Tag<RuleTestEnemyTag>();

            // Act
            Query query = scene.Query<With<Position>, Not<Health>, Tagged<RuleTestPlayerTag>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that rules affect query results consistently
        /// </summary>
        /// <remarks>
        ///     Validates that rules provide consistent filtering across multiple queries.
        /// </remarks>
        [Fact]
        public void Rule_AffectsQueryResultsConsistently()
        {
            // Arrange
            using Scene scene = new Scene();
            for (int i = 0; i < 10; i++)
            {
                GameObject entity = scene.Create(new Position { X = i, Y = i });
                if (i % 2 == 0)
                {
                    entity.Tag<RuleTestPlayerTag>();
                }
            }

            // Act
            Query query = scene.Query<With<Position>, Tagged<RuleTestPlayerTag>>();
            int count1 = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count1++;
            }

            int count2 = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count2++;
            }

            // Assert
            Assert.Equal(5, count1);
            Assert.Equal(5, count2);
        }

        /// <summary>
        ///     Tests that rules handle dynamic entity changes
        /// </summary>
        /// <remarks>
        ///     Validates that rules adapt when entities are modified.
        /// </remarks>
        [Fact]
        public void Rule_HandlesDynamicEntityChanges()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 1, Y = 2 });

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>>();
            int countBefore = 0;
            foreach (var _ in query.Enumerate<Position, Velocity>())
            {
                countBefore++;
            }

            entity.Add(new Velocity { VX = 3, VY = 4 });

            int countAfter = 0;
            foreach (var _ in query.Enumerate<Position, Velocity>())
            {
                countAfter++;
            }

            // Assert
            Assert.Equal(0, countBefore);
            Assert.Equal(1, countAfter);
        }

        /// <summary>
        ///     Tests that rules work with empty results
        /// </summary>
        /// <remarks>
        ///     Validates that rules handle empty query results gracefully.
        /// </remarks>
        [Fact]
        public void Rule_WorksWithEmptyResults()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Velocity { VX = 1, VY = 2 }); // No Position

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
    }
}

