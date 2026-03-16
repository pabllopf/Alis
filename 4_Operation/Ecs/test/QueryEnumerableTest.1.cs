// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QueryEnumerableTest.1.cs
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
    ///     The query enumerable test class
    /// </summary>
    /// <remarks>
    ///     Tests for QueryEnumerable with 1 component type.
    /// </remarks>
    public partial class QueryEnumerableTest
    {
        /// <summary>
        ///     Tests that query enumerable with one component can be created.
        /// </summary>
        [Fact]
        public void QueryEnumerable_WithOneComponent_CanBeCreated()
        {
            // Arrange
            using Scene scene = new Scene();
            Query query = scene.Query<With<Position>>();

            // Act
            QueryEnumerator<Position>.QueryEnumerable enumerable = query.Enumerate<Position>();

            // Assert
            Assert.NotEqual(default(QueryEnumerator<Position>.QueryEnumerable), enumerable);
        }

        /// <summary>
        ///     Tests that query enumerable with one component can be used in foreach.
        /// </summary>
        [Fact]
        public void QueryEnumerable_WithOneComponent_CanBeUsedInForeach()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 2});
            scene.Create(new Position {X = 3, Y = 4});
            Query query = scene.Query<With<Position>>();

            // Act
            int count = 0;
            foreach (RefTuple<Position> _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that query enumerable with one component filters correctly.
        /// </summary>
        [Fact]
        public void QueryEnumerable_WithOneComponent_FiltersCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position {X = 10, Y = 10});
            scene.Create(new Velocity {X = 1, Y = 1});
            Query query = scene.Query<With<Position>>();

            // Act
            int count = 0;
            foreach (RefTuple<Position> _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }


        /// <summary>
        ///     Tests that query enumerable with one component works with empty query.
        /// </summary>
        [Fact]
        public void QueryEnumerable_WithOneComponent_WorksWithEmptyQuery()
        {
            // Arrange
            using Scene scene = new Scene();
            Query query = scene.Query<With<Position>>();

            // Act
            int count = 0;
            foreach (RefTuple<Position> _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(0, count);
        }

        /// <summary>
        ///     Tests that query enumerable with one component provides entity access.
        /// </summary>
        [Fact]
        public void QueryEnumerable_WithOneComponent_ProvidesEntityAccess()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position {X = 5, Y = 7});
            Query query = scene.Query<With<Position>>();

            // Act
            int count = 0;
            foreach ((GameObject entity, Ref<Position> position) in query.EnumerateWithEntities<Position>())
            {
                Assert.True(entity.IsAlive);
                Assert.Equal(5, position.Value.X);
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that query enumerable with one component is struct type.
        /// </summary>
        [Fact]
        public void QueryEnumerable_WithOneComponent_IsStructType()
        {
            // Assert
            Assert.True(typeof(QueryEnumerable<Position>).IsValueType);
        }
    }
}