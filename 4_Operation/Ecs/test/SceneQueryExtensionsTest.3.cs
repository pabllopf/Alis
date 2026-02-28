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

using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The scene query extensions test class
    /// </summary>
    /// <remarks>
    ///     Tests for SceneQueryExtensions.3.cs - Query methods with 3 component types.
    /// </remarks>
    public partial class SceneQueryExtensionsTest
    {
        /// <summary>
        ///     Tests that query with three components returns valid query
        /// </summary>
        /// <remarks>
        ///     Verifies that Query with 3 components creates a valid Query instance.
        /// </remarks>
        [Fact]
        public void Query_WithThreeComponents_ReturnsValidQuery()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();

            // Assert
            Assert.NotNull(query);
        }

        /// <summary>
        ///     Tests that three component query filters correctly
        /// </summary>
        /// <remarks>
        ///     Validates that only entities with all three components are returned.
        /// </remarks>
        [Fact]
        public void ThreeComponentQuery_FiltersCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 1 }, new Velocity { VX = 1, VY = 1 }, new Health { Value = 100 });
            scene.Create(new Position { X = 2, Y = 2 }, new Velocity { VX = 2, VY = 2 }); // Missing Health
            scene.Create(new Position { X = 3, Y = 3 }); // Missing Velocity and Health

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();
            int count = 0;
            foreach (RefTuple<Position, Velocity, Health> _ in query.Enumerate<Position, Velocity, Health>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that three component query enumerates all components
        /// </summary>
        /// <remarks>
        ///     Validates that enumeration provides access to all three component types.
        /// </remarks>
        [Fact]
        public void ThreeComponentQuery_EnumeratesAllComponents()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(
                new Position { X = 10, Y = 20 },
                new Velocity { VX = 5, VY = 10 },
                new Health { Value = 150 }
            );

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();
            bool found = false;
            foreach ((Ref<Position> pos, Ref<Velocity> vel, Ref<Health> health) in query.Enumerate<Position, Velocity, Health>())
            {
                Assert.Equal(10, pos.Value.X);
                Assert.Equal(20, pos.Value.Y);
                Assert.Equal(5, vel.Value.VX);
                Assert.Equal(10, vel.Value.VY);
                Assert.Equal(150, health.Value.Value);
                found = true;
            }

            // Assert
            Assert.True(found);
        }

        /// <summary>
        ///     Tests that three component query caches correctly
        /// </summary>
        /// <remarks>
        ///     Validates that identical three-component queries return the same cached instance.
        /// </remarks>
        [Fact]
        public void ThreeComponentQuery_CachesCorrectly()
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
        ///     Tests that three component query with different types is different
        /// </summary>
        /// <remarks>
        ///     Validates that different component combinations create different queries.
        /// </remarks>
        [Fact]
        public void ThreeComponentQuery_WithDifferentTypes_IsDifferent()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            Query query1 = scene.Query<With<Position>, With<Velocity>, With<Health>>();
            Query query2 = scene.Query<With<Position>, With<Velocity>, With<Transform>>();

            // Assert
            Assert.NotSame(query1, query2);
        }

        /// <summary>
        ///     Tests that three component query works with multiple entities
        /// </summary>
        /// <remarks>
        ///     Validates that queries work correctly with multiple matching entities.
        /// </remarks>
        [Fact]
        public void ThreeComponentQuery_WorksWithMultipleEntities()
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
            int count = 0;
            foreach (RefTuple<Position, Velocity, Health> _ in query.Enumerate<Position, Velocity, Health>())
            {
                count++;
            }

            // Assert
            Assert.Equal(5, count);
        }

        /// <summary>
        ///     Tests that three component query enumerate with entities works
        /// </summary>
        /// <remarks>
        ///     Validates that EnumerateWithEntities provides GameObject and all components.
        /// </remarks>
        [Fact]
        public void ThreeComponentQuery_EnumerateWithEntities_Works()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(
                new Position { X = 1, Y = 1 },
                new Velocity { VX = 1, VY = 1 },
                new Health { Value = 100 }
            );

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();
            int count = 0;
            foreach ((GameObject entity, Ref<Position> pos, Ref<Velocity> vel, Ref<Health> health) in query.EnumerateWithEntities<Position, Velocity, Health>())
            {
                Assert.False(entity.IsNull);
                Assert.True(entity.IsAlive);
                Assert.Equal(100, health.Value.Value);
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that three component query can modify all components
        /// </summary>
        /// <remarks>
        ///     Validates that all three components can be modified during enumeration.
        /// </remarks>
        [Fact]
        public void ThreeComponentQuery_CanModifyAllComponents()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position { X = 0, Y = 0 },
                new Velocity { VX = 0, VY = 0 },
                new Health { Value = 0 }
            );

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();
            foreach ((Ref<Position> pos, Ref<Velocity> vel, Ref<Health> health) in query.Enumerate<Position, Velocity, Health>())
            {
                Position p = pos.Value;
                p.X = 50;
                p.Y = 75;
                pos.Value = p;

                Velocity v = vel.Value;
                v.VX = 5;
                v.VY = 7.5f;
                vel.Value = v;

                Health h = health.Value;
                h.Value = 200;
                health.Value = h;
            }

            // Assert
            Assert.Equal(50, entity.Get<Position>().X);
            Assert.Equal(75, entity.Get<Position>().Y);
            Assert.Equal(5, entity.Get<Velocity>().VX);
            Assert.Equal(7.5f, entity.Get<Velocity>().VY);
            Assert.Equal(200, entity.Get<Health>().Value);
        }

        /// <summary>
        ///     Tests that three component query includes entities with extra components
        /// </summary>
        /// <remarks>
        ///     Validates that entities with additional components are still matched.
        /// </remarks>
        [Fact]
        public void ThreeComponentQuery_IncludesEntitiesWithExtraComponents()
        {
            // Arrange
            using Scene scene = new Scene();
            scene.Create(
                new Position { X = 1, Y = 1 },
                new Velocity { VX = 1, VY = 1 },
                new Health { Value = 100 },
                new Transform { X = 0, Y = 0, Rotation = 0 }
            );

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();
            int count = 0;
            foreach (RefTuple<Position, Velocity, Health> _ in query.Enumerate<Position, Velocity, Health>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that three component query excludes disabled entities
        /// </summary>
        /// <remarks>
        ///     Validates that entities with Disable tag are excluded.
        /// </remarks>
        [Fact]
        public void ThreeComponentQuery_ExcludesDisabledEntities()
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

            // Act
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();
            int count = 0;
            foreach (RefTuple<Position, Velocity, Health> _ in query.Enumerate<Position, Velocity, Health>())
            {
                count++;
            }

            // Assert
            Assert.Equal(2, count);
        }
    }
}

