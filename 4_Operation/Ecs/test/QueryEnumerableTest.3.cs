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
    ///     Tests for QueryEnumerable with 3 component types.
    /// </remarks>
    public partial class QueryEnumerableTest
    {
        /// <summary>
        ///     Tests that query enumerable with three components can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that QueryEnumerable with 3 components can be instantiated.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithThreeComponents_CanBeCreated()
        {
            // Arrange
            using Scene scene = new Scene();
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();

            // Act
            var enumerable = query.Enumerate<Position, Velocity, Health>();

            // Assert
            Assert.NotEqual(default, enumerable);
        }

        /// <summary>
        ///     Tests that query enumerable with three components can be used in foreach
        /// </summary>
        /// <remarks>
        ///     Validates that QueryEnumerable with 3 components works in foreach loops.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithThreeComponents_CanBeUsedInForeach()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(
                new Position { X = 1, Y = 2 },
                new Velocity { VX = 0.5f, VY = 1.0f },
                new Health { Value = 100 }
            );
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();

            // Act
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity, Health>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that query enumerable with three components provides access to all
        /// </summary>
        /// <remarks>
        ///     Validates that all three component types are accessible during enumeration.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithThreeComponents_ProvidesAccessToAll()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(
                new Position { X = 10, Y = 20 },
                new Velocity { VX = 5, VY = 10 },
                new Health { Value = 150 }
            );
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();

            // Act & Assert
            foreach (var (pos, vel, health) in query.Enumerate<Position, Velocity, Health>())
            {
                Assert.Equal(10, pos.Value.X);
                Assert.Equal(20, pos.Value.Y);
                Assert.Equal(5, vel.Value.VX);
                Assert.Equal(10, vel.Value.VY);
                Assert.Equal(150, health.Value.Value);
            }
        }

        /// <summary>
        ///     Tests that query enumerable with three components filters correctly
        /// </summary>
        /// <remarks>
        ///     Validates that only entities with all three components are enumerated.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithThreeComponents_FiltersCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 1 }, new Velocity { VX = 1, VY = 1 }, new Health { Value = 100 });
            scene.Create(new Position { X = 2, Y = 2 }, new Velocity { VX = 2, VY = 2 }); // Missing Health
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();

            // Act
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity, Health>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that query enumerable with three components allows modification
        /// </summary>
        /// <remarks>
        ///     Validates that all three components can be modified during enumeration.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithThreeComponents_AllowsModification()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position { X = 0, Y = 0 },
                new Velocity { VX = 0, VY = 0 },
                new Health { Value = 0 }
            );
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();

            // Act
            foreach (var (pos, vel, health) in query.Enumerate<Position, Velocity, Health>())
            {
                var p = pos.Value;
                p.X = 100;
                pos.Value = p;

                var v = vel.Value;
                v.VX = 50;
                vel.Value = v;

                var h = health.Value;
                h.Value = 200;
                health.Value = h;
            }

            // Assert
            Assert.Equal(100, entity.Get<Position>().X);
            Assert.Equal(50, entity.Get<Velocity>().VX);
            Assert.Equal(200, entity.Get<Health>().Value);
        }

        /// <summary>
        ///     Tests that query enumerable with three components works with multiple entities
        /// </summary>
        /// <remarks>
        ///     Validates enumeration with multiple matching entities.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithThreeComponents_WorksWithMultipleEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            for (int i = 0; i < 3; i++)
            {
                scene.Create(
                    new Position { X = i, Y = i * 2 },
                    new Velocity { VX = i * 0.5f, VY = i * 0.3f },
                    new Health { Value = i * 10 }
                );
            }
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();

            // Act
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity, Health>())
            {
                count++;
            }

            // Assert
            Assert.Equal(3, count);
        }

        /// <summary>
        ///     Tests that query enumerable with three components is struct type
        /// </summary>
        /// <remarks>
        ///     Validates that QueryEnumerable with 3 components is a value type.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithThreeComponents_IsStructType()
        {
            // Assert
            Assert.True(typeof(QueryEnumerable<Position, Velocity, Health>).IsValueType);
        }

        /// <summary>
        ///     Tests that query enumerable with three components excludes disabled entities
        /// </summary>
        /// <remarks>
        ///     Validates that disabled entities are excluded from enumeration.
        /// </remarks>
        [Fact]
        public void QueryEnumerable_WithThreeComponents_ExcludesDisabledEntities()
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

            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();

            // Act
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity, Health>())
            {
                count++;
            }

            // Assert
            Assert.Equal(2, count);
        }
    }
}

