// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IncludeDisabledExtendedTest.cs
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
    ///     The include disabled extended test class
    /// </summary>
    /// <remarks>
    ///     Extended tests for the IncludeDisabled query rule, validating that
    ///     disabled entities are included in queries when specified.
    /// </remarks>
    public class IncludeDisabledExtendedTest
    {
        /// <summary>
        ///     Tests that include disabled includes disabled entities
        /// </summary>
        /// <remarks>
        ///     Validates that entities with the Disable tag are included in queries with IncludeDisabled.
        /// </remarks>
        [Fact]
        public void IncludeDisabled_IncludesDisabledEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject enabledEntity = scene.Create(new Position { X = 1, Y = 2 });
            GameObject disabledEntity = scene.Create(new Position { X = 3, Y = 4 });
            
            disabledEntity.Tag<Disable>();

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
        ///     Tests that standard query excludes disabled entities
        /// </summary>
        /// <remarks>
        ///     Validates that queries without IncludeDisabled exclude disabled entities.
        /// </remarks>
        [Fact]
        public void IncludeDisabled_StandardQueryExcludesDisabled()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject enabledEntity = scene.Create(new Position { X = 1, Y = 2 });
            GameObject disabledEntity = scene.Create(new Position { X = 3, Y = 4 });
            
            disabledEntity.Tag<Disable>();

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
        ///     Tests that include disabled with tagged filter works
        /// </summary>
        /// <remarks>
        ///     Validates that IncludeDisabled works with other query filters.
        /// </remarks>
        [Fact]
        public void IncludeDisabled_WorksWithOtherFilters()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 2 });
            GameObject entity2 = scene.Create(new Position { X = 3, Y = 4 });
            
            entity1.Tag<IncludeDisabledPlayerTag>();
            entity2.Tag<IncludeDisabledPlayerTag>();
            entity2.Tag<Disable>();

            // Act
            Query query = scene.Query<With<Position>, Tagged<IncludeDisabledPlayerTag>, IncludeDisabled>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that include disabled works with multiple components
        /// </summary>
        /// <remarks>
        ///     Validates that IncludeDisabled works with multi-component queries.
        /// </remarks>
        [Fact]
        public void IncludeDisabled_WorksWithMultipleComponents()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(
                new Position { X = 1, Y = 2 },
                new Velocity { VX = 3, VY = 4 }
            );
            GameObject entity2 = scene.Create(
                new Position { X = 5, Y = 6 },
                new Velocity { VX = 7, VY = 8 }
            );
            
            entity2.Tag<Disable>();

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, IncludeDisabled>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity>())
            {
                count++;
            }

            // Assert
            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that disabling entity changes standard query results
        /// </summary>
        /// <remarks>
        ///     Validates that adding the Disable tag removes entities from standard queries.
        /// </remarks>
        [Fact]
        public void IncludeDisabled_DisablingChangesStandardQueryResults()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 1, Y = 2 });

            // Act
            Query standardQuery = scene.Query<With<Position>>();
            int countBefore = 0;
            foreach (var _ in standardQuery.Enumerate<Position>())
            {
                countBefore++;
            }

            entity.Tag<Disable>();

            int countAfter = 0;
            foreach (var _ in standardQuery.Enumerate<Position>())
            {
                countAfter++;
            }

            // Assert
            Assert.Equal(1, countBefore);
            Assert.Equal(1, countAfter);
        }

        /// <summary>
        ///     Tests that disabling entity doesn't change include disabled results
        /// </summary>
        /// <remarks>
        ///     Validates that IncludeDisabled always includes disabled entities.
        /// </remarks>
        [Fact]
        public void IncludeDisabled_StaysIncludedAfterDisabling()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 1, Y = 2 });

            // Act
            Query includeDisabledQuery = scene.Query<With<Position>, IncludeDisabled>();
            int countBefore = 0;
            foreach (var _ in includeDisabledQuery.Enumerate<Position>())
            {
                countBefore++;
            }

            entity.Tag<Disable>();

            int countAfter = 0;
            foreach (var _ in includeDisabledQuery.Enumerate<Position>())
            {
                countAfter++;
            }

            // Assert
            Assert.Equal(1, countBefore);
            Assert.Equal(1, countAfter);
        }

        /// <summary>
        ///     Tests that include disabled works with many disabled entities
        /// </summary>
        /// <remarks>
        ///     Validates that IncludeDisabled scales with many disabled entities.
        /// </remarks>
        [Fact]
        public void IncludeDisabled_ScalesWithManyDisabledEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            for (int i = 0; i < 100; i++)
            {
                GameObject entity = scene.Create(new Position { X = i, Y = i * 2 });
                if (i % 2 == 0)
                {
                    entity.Tag<Disable>();
                }
            }

            // Act
            Query includeDisabledQuery = scene.Query<With<Position>, IncludeDisabled>();
            int countIncludeDisabled = 0;
            foreach (var _ in includeDisabledQuery.Enumerate<Position>())
            {
                countIncludeDisabled++;
            }

            Query standardQuery = scene.Query<With<Position>>();
            int countStandard = 0;
            foreach (var _ in standardQuery.Enumerate<Position>())
            {
                countStandard++;
            }

            // Assert
            Assert.Equal(100, countIncludeDisabled);
            Assert.Equal(100, countStandard);
        }

        /// <summary>
        ///     Tests that include disabled works with not filter
        /// </summary>
        /// <remarks>
        ///     Validates that IncludeDisabled works with Not query filter.
        /// </remarks>
        [Fact]
        public void IncludeDisabled_WorksWithNotFilter()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 2 });
            GameObject entity2 = scene.Create(
                new Position { X = 3, Y = 4 },
                new Velocity { VX = 5, VY = 6 }
            );
            
            entity2.Tag<Disable>();

            // Act
            Query query = scene.Query<With<Position>, Not<Velocity>, IncludeDisabled>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that all disabled entities are included
        /// </summary>
        /// <remarks>
        ///     Validates that IncludeDisabled includes all disabled entities regardless of other properties.
        /// </remarks>
        [Fact]
        public void IncludeDisabled_IncludesAllDisabledEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            for (int i = 0; i < 10; i++)
            {
                GameObject entity = scene.Create(new Position { X = i, Y = i });
                entity.Tag<Disable>();
            }

            // Act
            Query query = scene.Query<With<Position>, IncludeDisabled>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(10, count);
        }

        /// <summary>
        ///     Tests that include disabled works in mixed scenario
        /// </summary>
        /// <remarks>
        ///     Validates that IncludeDisabled works correctly in complex scenarios.
        /// </remarks>
        [Fact]
        public void IncludeDisabled_WorksInMixedScenario()
        {
            // Arrange
            using Scene scene = new Scene();
            
            // Create enabled entities
            scene.Create(new Position { X = 1, Y = 1 });
            scene.Create(new Position { X = 2, Y = 2 });
            
            // Create disabled entities
            GameObject disabled1 = scene.Create(new Position { X = 3, Y = 3 });
            disabled1.Tag<Disable>();
            
            GameObject disabled2 = scene.Create(new Position { X = 4, Y = 4 });
            disabled2.Tag<Disable>();
            
            // Create entity without Position
            scene.Create(new Velocity { VX = 5, VY = 5 });

            // Act
            Query standardQuery = scene.Query<With<Position>>();
            int standardCount = 0;
            foreach (var _ in standardQuery.Enumerate<Position>())
            {
                standardCount++;
            }

            Query includeDisabledQuery = scene.Query<With<Position>, IncludeDisabled>();
            int includedCount = 0;
            foreach (var _ in includeDisabledQuery.Enumerate<Position>())
            {
                includedCount++;
            }

            // Assert
            Assert.Equal(4, standardCount);
            Assert.Equal(4, includedCount);
        }
    }
}

