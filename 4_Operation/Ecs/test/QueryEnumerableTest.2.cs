// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QueryEnumerable.2.cs
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
    ///     Tests for QueryEnumerable with 2 component types.
    /// </remarks>
    public partial class QueryEnumerableTest
    {
        /// <summary>
        ///     Tests that query enumerable with two components can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that QueryEnumerable with 2 components can be instantiated.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithTwoComponents_CanBeCreated()
        {
            // Arrange
            using Scene scene = new Scene();
            Query query = scene.Query<With<Position>, With<Velocity>>();

            // Act
            var enumerable = query.Enumerate<Position, Velocity>();

            // Assert
            Assert.NotEqual(default, enumerable);
        }

        /// <summary>
        ///     Tests that query enumerable with two components can be used in foreach
        /// </summary>
        /// <remarks>
        ///     Validates that QueryEnumerable with 2 components works in foreach loops.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithTwoComponents_CanBeUsedInForeach()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 }, new Velocity { VX = 0.5f, VY = 1.0f });
            scene.Create(new Position { X = 3, Y = 4 }, new Velocity { VX = 1.5f, VY = 2.0f });
            Query query = scene.Query<With<Position>, With<Velocity>>();

            // Act
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity>())
            {
                count++;
            }

            // Assert
            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that query enumerable with two components provides access to both
        /// </summary>
        /// <remarks>
        ///     Validates that both component types are accessible during enumeration.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithTwoComponents_ProvidesAccessToBoth()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 10, Y = 20 }, new Velocity { VX = 5, VY = 10 });
            Query query = scene.Query<With<Position>, With<Velocity>>();

            // Act & Assert
            foreach (var (pos, vel) in query.Enumerate<Position, Velocity>())
            {
                Assert.Equal(10, pos.Value.X);
                Assert.Equal(20, pos.Value.Y);
                Assert.Equal(5, vel.Value.VX);
                Assert.Equal(10, vel.Value.VY);
            }
        }

        /// <summary>
        ///     Tests that query enumerable with two components filters correctly
        /// </summary>
        /// <remarks>
        ///     Validates that only entities with both components are enumerated.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithTwoComponents_FiltersCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 1 }, new Velocity { VX = 1, VY = 1 });
            scene.Create(new Position { X = 2, Y = 2 }); // Missing Velocity
            Query query = scene.Query<With<Position>, With<Velocity>>();

            // Act
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that query enumerable with two components allows modification
        /// </summary>
        /// <remarks>
        ///     Validates that both components can be modified during enumeration.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithTwoComponents_AllowsModification()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 0, Y = 0 }, new Velocity { VX = 0, VY = 0 });
            Query query = scene.Query<With<Position>, With<Velocity>>();

            // Act
            foreach (var (pos, vel) in query.Enumerate<Position, Velocity>())
            {
                var p = pos.Value;
                p.X = 100;
                pos.Value = p;

                var v = vel.Value;
                v.VX = 50;
                vel.Value = v;
            }

            // Assert
            Assert.Equal(100, entity.Get<Position>().X);
            Assert.Equal(50, entity.Get<Velocity>().VX);
        }

        /// <summary>
        ///     Tests that query enumerable with two components works with multiple entities
        /// </summary>
        /// <remarks>
        ///     Validates enumeration with multiple matching entities.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithTwoComponents_WorksWithMultipleEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            for (int i = 0; i < 5; i++)
            {
                scene.Create(new Position { X = i, Y = i * 2 }, new Velocity { VX = i * 0.5f, VY = i * 0.3f });
            }
            Query query = scene.Query<With<Position>, With<Velocity>>();

            // Act
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity>())
            {
                count++;
            }

            // Assert
            Assert.Equal(5, count);
        }

        /// <summary>
        ///     Tests that query enumerable with two components works with empty query
        /// </summary>
        /// <remarks>
        ///     Validates handling of empty queries with 2 components.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithTwoComponents_WorksWithEmptyQuery()
        {
            // Arrange
            using Scene scene = new Scene();
            Query query = scene.Query<With<Position>, With<Velocity>>();

            // Act
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity>())
            {
                count++;
            }

            // Assert
            Assert.Equal(0, count);
        }

        /// <summary>
        ///     Tests that query enumerable with two components provides entity access
        /// </summary>
        /// <remarks>
        ///     Validates that EnumerateWithEntities works with 2 components.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithTwoComponents_ProvidesEntityAccess()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 5, Y = 10 }, new Velocity { VX = 2, VY = 3 });
            Query query = scene.Query<With<Position>, With<Velocity>>();

            // Act & Assert
            foreach (var (entity, pos, vel) in query.EnumerateWithEntities<Position, Velocity>())
            {
                Assert.False(entity.IsNull);
                Assert.True(entity.IsAlive);
                Assert.Equal(5, pos.Value.X);
                Assert.Equal(2, vel.Value.VX);
            }
        }
    }
}

