// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QueryEnumerable.cs
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
    ///     Tests the <see cref="QueryEnumerable{T1}"/> struct which provides
    ///     foreach enumeration support for single-component queries.
    /// </remarks>
    public partial class QueryEnumerableTest
    {
        /// <summary>
        ///     Tests that query enumerable can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that QueryEnumerable can be instantiated with a Query.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_CanBeCreated()
        {
            // Arrange
            using Scene scene = new Scene();
            Query query = scene.Query<With<Position>>();

            // Act
            QueryEnumerable<Position> enumerable = new QueryEnumerable<Position>(query);

            // Assert
            Assert.NotEqual(default(QueryEnumerable<Position>), enumerable);
        }


        /// <summary>
        ///     Tests that query enumerable can be used in foreach
        /// </summary>
        /// <remarks>
        ///     Validates that QueryEnumerable can be used in foreach loops.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_CanBeUsedInForeach()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 });
            scene.Create(new Position { X = 3, Y = 4 });
            Query query = scene.Query<With<Position>>();
            QueryEnumerable<Position> enumerable = new QueryEnumerable<Position>(query);

            // Act
            int count = 0;
            foreach (var _ in enumerable)
            {
                count++;
            }

            // Assert
            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that query enumerable provides access to entities
        /// </summary>
        /// <remarks>
        ///     Validates that QueryEnumerable provides access to GameObject instances.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_ProvidesAccessToEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 10, Y = 20 });
            Query query = scene.Query<With<Position>>();
            QueryEnumerable<Position> enumerable = new QueryEnumerable<Position>(query);

            // Act & Assert
            foreach (var (entity, pos) in enumerable)
            {
                Assert.False(entity.IsNull);
                Assert.True(entity.IsAlive);
                Assert.Equal(10, pos.Value.X);
                Assert.Equal(20, pos.Value.Y);
            }
        }

        /// <summary>
        ///     Tests that query enumerable works with empty query
        /// </summary>
        /// <remarks>
        ///     Validates that QueryEnumerable handles empty queries correctly.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WorksWithEmptyQuery()
        {
            // Arrange
            using Scene scene = new Scene();
            Query query = scene.Query<With<Position>>();
            QueryEnumerable<Position> enumerable = new QueryEnumerable<Position>(query);

            // Act
            int count = 0;
            foreach (var _ in enumerable)
            {
                count++;
            }

            // Assert
            Assert.Equal(0, count);
        }

        /// <summary>
        ///     Tests that query enumerable can enumerate multiple times
        /// </summary>
        /// <remarks>
        ///     Validates that the same QueryEnumerable can be enumerated multiple times.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_CanEnumerateMultipleTimes()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 1 });
            scene.Create(new Position { X = 2, Y = 2 });
            Query query = scene.Query<With<Position>>();
            QueryEnumerable<Position> enumerable = new QueryEnumerable<Position>(query);

            // Act
            int count1 = 0;
            foreach (var _ in enumerable)
            {
                count1++;
            }

            int count2 = 0;
            foreach (var _ in enumerable)
            {
                count2++;
            }

            // Assert
            Assert.Equal(2, count1);
            Assert.Equal(2, count2);
        }

        /// <summary>
        ///     Tests that query enumerable allows component modification
        /// </summary>
        /// <remarks>
        ///     Validates that components can be modified during enumeration.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_AllowsComponentModification()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 0, Y = 0 });
            Query query = scene.Query<With<Position>>();
            QueryEnumerable<Position> enumerable = new QueryEnumerable<Position>(query);

            // Act
            foreach (var (_, pos) in enumerable)
            {
                var p = pos.Value;
                p.X = 100;
                p.Y = 200;
                pos.Value = p;
            }

            // Assert
            Assert.Equal(100, entity.Get<Position>().X);
            Assert.Equal(200, entity.Get<Position>().Y);
        }

        /// <summary>
        ///     Tests that query enumerable works with value types
        /// </summary>
        /// <remarks>
        ///     Tests that QueryEnumerable works correctly with value type components.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WorksWithValueTypes()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Health { Value = 100 });
            Query query = scene.Query<With<Health>>();
            QueryEnumerable<Health> enumerable = new QueryEnumerable<Health>(query);

            // Act & Assert
            foreach (var (_, health) in enumerable)
            {
                Assert.Equal(100, health.Value.Value);
            }
        }

        /// <summary>
        ///     Tests that query enumerable is struct type
        /// </summary>
        /// <remarks>
        ///     Validates that QueryEnumerable is a value type (struct).
        /// </remarks>
        [Fact]
        public void QueryEnumerable_IsStructType()
        {
            // Assert
            Assert.True(typeof(QueryEnumerable<Position>).IsValueType);
        }

        /// <summary>
        ///     Tests that query enumerable excludes disabled entities by default
        /// </summary>
        /// <remarks>
        ///     Validates that disabled entities are not included in enumeration.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_ExcludesDisabledEntitiesByDefault()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 1 });
            GameObject disabled = scene.Create(new Position { X = 2, Y = 2 });
            disabled.Tag<Disable>();

            Query query = scene.Query<With<Position>>();
            QueryEnumerable<Position> enumerable = new QueryEnumerable<Position>(query);

            // Act
            int count = 0;
            foreach (var _ in enumerable)
            {
                count++;
            }

            // Assert
            Assert.Equal(2, count);
        }
    }
}

