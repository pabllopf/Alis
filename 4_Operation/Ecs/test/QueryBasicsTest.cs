// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QueryBasicsTest.cs
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
    ///     Tests for basic query functionality
    /// </summary>
    /// <remarks>
    ///     Validates that queries work correctly for filtering entities
    ///     by component composition and enumerating results.
    /// </remarks>
    public class QueryBasicsTest
    {
        /// <summary>
        ///     Tests query with single component filter
        /// </summary>
        [Fact]
        public void Query_FiltersBySingleComponent()
        {
            // Arrange
            using var scene = new Scene();
            scene.Create(new Position { X = 1 });
            scene.Create(new Position { X = 2 });
            scene.Create(new Health { Value = 100 });

            // Act
            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (var (entity, pos) in query.EnumerateWithEntities<Position>())
            {
                count++;
                Assert.True(entity.IsAlive);
            }

            // Assert
            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests query with two component filters
        /// </summary>
        [Fact]
        public void Query_FiltersByTwoComponents()
        {
            // Arrange
            using var scene = new Scene();
            scene.Create(new Position { X = 1 });
            scene.Create(new Position { X = 2 }, new Health { Value = 100 });
            scene.Create(new Health { Value = 50 });

            // Act
            Query query = scene.Query<With<Position>, With<Health>>();
            int count = 0;
            foreach (var (entity, pos, health) in query.EnumerateWithEntities<Position, Health>())
            {
                count++;
                Assert.True(entity.IsAlive);
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests query on empty result set
        /// </summary>
        [Fact]
        public void Query_ReturnsEmptyWhenNoMatches()
        {
            // Arrange
            using var scene = new Scene();
            scene.Create(new Position { X = 1 });
            scene.Create(new Health { Value = 100 });

            // Act
            Query query = scene.Query<With<Velocity>>();
            int count = 0;
            foreach (var _ in query.EnumerateWithEntities<Velocity>())
            {
                count++;
            }

            // Assert
            Assert.Equal(0, count);
        }

        /// <summary>
        ///     Tests query enumeration consistency
        /// </summary>
        [Fact]
        public void Query_IsConsistentAcrossIterations()
        {
            // Arrange
            using var scene = new Scene();
            scene.Create(new Position { X = 1 });
            scene.Create(new Position { X = 2 });

            // Act
            Query query = scene.Query<With<Position>>();
            int count1 = 0, count2 = 0, count3 = 0;

            foreach (var _ in query.EnumerateWithEntities<Position>())
                count1++;
            foreach (var _ in query.EnumerateWithEntities<Position>())
                count2++;
            foreach (var _ in query.EnumerateWithEntities<Position>())
                count3++;

            // Assert
            Assert.Equal(2, count1);
            Assert.Equal(2, count2);
            Assert.Equal(2, count3);
        }

        /// <summary>
        ///     Tests accessing component data through query enumeration
        /// </summary>
        [Fact]
        public void Query_CanAccessComponentDataInEnumeration()
        {
            // Arrange
            using var scene = new Scene();
            scene.Create(new Position { X = 10, Y = 20 });
            scene.Create(new Position { X = 30, Y = 40 });

            // Act
            Query query = scene.Query<With<Position>>();
            int totalX = 0;
            foreach (var (entity, pos) in query.EnumerateWithEntities<Position>())
            {
                totalX += (int)pos.Value.X;
            }

            // Assert
            Assert.Equal(40, totalX);
        }

        /// <summary>
        ///     Tests query with three component filters
        /// </summary>
        [Fact]
        public void Query_FiltersByThreeComponents()
        {
            // Arrange
            using var scene = new Scene();
            scene.Create(new Position { X = 1 });
            scene.Create(new Position { X = 2 }, new Health { Value = 100 });
            scene.Create(new Position { X = 3 }, new Health { Value = 100 }, new Velocity { VX = 1 });
            scene.Create(new Health { Value = 50 }, new Velocity { VX = 2 });

            // Act
            Query query = scene.Query<With<Position>, With<Health>, With<Velocity>>();
            int count = 0;
            foreach (var (_, _, _, _) in query.EnumerateWithEntities<Position, Health, Velocity>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests query can be reused multiple times
        /// </summary>
        [Fact]
        public void Query_CanBeReused()
        {
            // Arrange
            using var scene = new Scene();
            scene.Create(new Position { X = 1 });
            scene.Create(new Position { X = 2 });

            // Act
            Query query = scene.Query<With<Position>>();
            
            int firstUseCount = 0;
            foreach (var _ in query.EnumerateWithEntities<Position>())
                firstUseCount++;

            int secondUseCount = 0;
            foreach (var _ in query.EnumerateWithEntities<Position>())
                secondUseCount++;

            // Assert
            Assert.Equal(2, firstUseCount);
            Assert.Equal(2, secondUseCount);
        }
    }
}

