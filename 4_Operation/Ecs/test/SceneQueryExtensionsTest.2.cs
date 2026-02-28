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
    ///     Tests for SceneQueryExtensions.2.cs - Query methods with 2 component types.
    /// </remarks>
    public partial class SceneQueryExtensionsTest
    {
        /// <summary>
        ///     Tests that query with two components returns correct query
        /// </summary>
        /// <remarks>
        ///     Verifies that Query with 2 components creates a valid Query instance.
        /// </remarks>
        [Fact]
        public void Query_WithTwoComponents_ReturnsCorrectQuery()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>>();

            // Assert
            Assert.NotNull(query);
        }

        /// <summary>
        ///     Tests that query with two components filters correctly
        /// </summary>
        /// <remarks>
        ///     Validates that only entities with both components are returned.
        /// </remarks>
        [Fact]
        public void Query_WithTwoComponents_FiltersCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 1 }, new Velocity { VX = 1, VY = 1 });
            scene.Create(new Position { X = 2, Y = 2 }); // Missing Velocity
            scene.Create(new Velocity { VX = 3, VY = 3 }); // Missing Position

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
        ///     Tests that two component query enumerates both components
        /// </summary>
        /// <remarks>
        ///     Validates that enumeration provides access to both component types.
        /// </remarks>
        [Fact]
        public void TwoComponentQuery_EnumeratesBothComponents()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 5, Y = 10 }, new Velocity { VX = 2, VY = 3 });

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>>();
            bool found = false;
            foreach (var (pos, vel) in query.Enumerate<Position, Velocity>())
            {
                Assert.Equal(5, pos.Value.X);
                Assert.Equal(10, pos.Value.Y);
                Assert.Equal(2, vel.Value.VX);
                Assert.Equal(3, vel.Value.VY);
                found = true;
            }

            // Assert
            Assert.True(found);
        }

        /// <summary>
        ///     Tests that two component query caches properly
        /// </summary>
        /// <remarks>
        ///     Validates that the same query instance is returned for identical component combinations.
        /// </remarks>
        [Fact]
        public void TwoComponentQuery_CachesProperly()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            Query query1 = scene.Query<With<Position>, With<Velocity>>();
            Query query2 = scene.Query<With<Position>, With<Velocity>>();

            // Assert
            Assert.Same(query1, query2);
        }

        /// <summary>
        ///     Tests that two component query with different order creates different query
        /// </summary>
        /// <remarks>
        ///     Validates that component order matters for query caching.
        /// </remarks>
        [Fact]
        public void TwoComponentQuery_DifferentOrder_CreatesDifferentQuery()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            Query query1 = scene.Query<With<Position>, With<Velocity>>();
            Query query2 = scene.Query<With<Velocity>, With<Position>>();

            // Assert
            Assert.Equal(query1, query2);
        }

        /// <summary>
        ///     Tests that two component query works with multiple entities
        /// </summary>
        /// <remarks>
        ///     Validates that queries work correctly with multiple matching entities.
        /// </remarks>
        [Fact]
        public void TwoComponentQuery_WorksWithMultipleEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            for (int i = 0; i < 10; i++)
            {
                scene.Create(new Position { X = i, Y = i * 2 }, new Velocity { VX = i * 0.5f, VY = i * 0.3f });
            }

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity>())
            {
                count++;
            }

            // Assert
            Assert.Equal(10, count);
        }

        /// <summary>
        ///     Tests that two component query with health and position works
        /// </summary>
        /// <remarks>
        ///     Tests different component type combinations.
        /// </remarks>
        [Fact]
        public void TwoComponentQuery_WithHealthAndPosition_Works()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 1 }, new Health { Value = 100 });
            scene.Create(new Position { X = 2, Y = 2 }); // No Health

            // Act
            Query query = scene.Query<With<Position>, With<Health>>();
            int count = 0;
            foreach (var (pos, health) in query.Enumerate<Position, Health>())
            {
                Assert.Equal(100, health.Value.Value);
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that two component query enumerate with entities works
        /// </summary>
        /// <remarks>
        ///     Validates that EnumerateWithEntities provides GameObject reference.
        /// </remarks>
        [Fact]
        public void TwoComponentQuery_EnumerateWithEntities_Works()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 1 }, new Velocity { VX = 1, VY = 1 });

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>>();
            int count = 0;
            foreach (var (entity, pos, vel) in query.EnumerateWithEntities<Position, Velocity>())
            {
                Assert.False(entity.IsNull);
                Assert.True(entity.IsAlive);
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that two component query can modify components
        /// </summary>
        /// <remarks>
        ///     Validates that components can be modified during enumeration.
        /// </remarks>
        [Fact]
        public void TwoComponentQuery_CanModifyComponents()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 0, Y = 0 }, new Velocity { VX = 0, VY = 0 });

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>>();
            foreach (var (pos, vel) in query.Enumerate<Position, Velocity>())
            {
                var p = pos.Value;
                p.X = 100;
                p.Y = 200;
                pos.Value = p;

                var v = vel.Value;
                v.VX = 10;
                v.VY = 20;
                vel.Value = v;
            }

            // Assert
            Assert.Equal(100, entity.Get<Position>().X);
            Assert.Equal(200, entity.Get<Position>().Y);
            Assert.Equal(10, entity.Get<Velocity>().VX);
            Assert.Equal(20, entity.Get<Velocity>().VY);
        }

        /// <summary>
        ///     Tests that two component query excludes disabled entities by default
        /// </summary>
        /// <remarks>
        ///     Validates that entities with Disable tag are excluded from normal queries.
        /// </remarks>
        [Fact]
        public void TwoComponentQuery_ExcludesDisabledEntitiesByDefault()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 1 }, new Velocity { VX = 1, VY = 1 });
            GameObject disabled = scene.Create(new Position { X = 2, Y = 2 }, new Velocity { VX = 2, VY = 2 });
            disabled.Tag<Disable>();

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position, Velocity>())
            {
                count++;
            }

            // Assert
            Assert.Equal(2, count);
        }
    }
}

