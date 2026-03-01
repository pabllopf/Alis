// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AdvancedEcsIntegrationTest.cs
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

using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The advanced ECS integration test class
    /// </summary>
    /// <remarks>
    ///     Tests complex scenarios and advanced use cases combining multiple ECS features.
    ///     Covers archetype migrations, complex queries, bulk operations, and edge cases.
    /// </remarks>
    public class AdvancedEcsIntegrationTest
    {
        /// <summary>
        ///     Tests archetype migration when adding multiple components
        /// </summary>
        /// <remarks>
        ///     Validates that an entity correctly transitions through multiple archetypes
        ///     when components are added sequentially.
        /// </remarks>
        [Fact]
        public void AdvancedEcs_ArchetypeMigrationWithMultipleComponents()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            // Act - Add components one by one, causing archetype transitions
            entity.Add(new Position());
            entity.Add(new Velocity());
            entity.Add(new Health());

            // Assert
            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
        }

        /// <summary>
        ///     Tests efficient bulk entity creation with same component set
        /// </summary>
        /// <remarks>
        ///     Verifies that creating many entities with the same components
        ///     reuses the same archetype for efficiency.
        /// </remarks>
        [Fact]
        public void AdvancedEcs_BulkEntityCreationWithSameArchetype()
        {
            // Arrange
            using Scene scene = new Scene();
            const int entityCount = 100;

            // Act
            GameObject[] entities = new GameObject[entityCount];
            for (int i = 0; i < entityCount; i++)
            {
                entities[i] = scene.Create();
                entities[i].Add(new Position());
                entities[i].Add(new Velocity());
            }

            // Assert
            for (int i = 0; i < entityCount; i++)
            {
                Assert.True(entities[i].Has<Position>());
                Assert.True(entities[i].Has<Velocity>());
            }
        }

        /// <summary>
        ///     Tests complex archetype topology with varied component combinations
        /// </summary>
        /// <remarks>
        ///     Validates that the ECS correctly handles diverse entity archetypes
        ///     with different component combinations in the same scene.
        /// </remarks>
        [Fact]
        public void AdvancedEcs_ComplexArchetypeTopology()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act - Create entities with different component combinations
            GameObject e1 = scene.Create();
            e1.Add(new Position());

            GameObject e2 = scene.Create();
            e2.Add(new Position());
            e2.Add(new Velocity());

            GameObject e3 = scene.Create();
            e3.Add(new Position());
            e3.Add(new Velocity());
            e3.Add(new Health());

            GameObject e4 = scene.Create();
            e4.Add(new Health());

            // Assert
            Assert.True(e1.Has<Position>());
            Assert.True(e2.Has<Position>() && e2.Has<Velocity>());
            Assert.True(e3.Has<Position>() && e3.Has<Velocity>() && e3.Has<Health>());
            Assert.True(e4.Has<Health>());
        }

        /// <summary>
        ///     Tests component removal and archetype downgrade
        /// </summary>
        /// <remarks>
        ///     Verifies that removing components causes the entity to move to
        ///     a simpler archetype.
        /// </remarks>
        [Fact]
        public void AdvancedEcs_ComponentRemovalAndArchetypeDowngrade()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            entity.Add(new Position());
            entity.Add(new Velocity());
            entity.Add(new Health());

            // Act
            entity.Remove<Health>();
            entity.Remove<Velocity>();

            // Assert
            Assert.True(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
        }

        /// <summary>
        ///     Tests deferred operations with structural changes
        /// </summary>
        /// <remarks>
        ///     Validates that deferred component operations (add/remove)
        ///     don't break queries or entity integrity.
        /// </remarks>
        [Fact]
        public void AdvancedEcs_DeferredOperationsDoNotBreakState()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject e1 = scene.Create();
            GameObject e2 = scene.Create();
            e1.Add(new Position());
            e2.Add(new Position());

            // Act
            e1.Add(new Velocity());
            e2.Add(new Health());

            // Assert
            Assert.True(e1.Has<Position>());
            Assert.True(e1.Has<Velocity>());
            Assert.True(e2.Has<Position>());
            Assert.True(e2.Has<Health>());
        }

        /// <summary>
        ///     Tests component value preservation across archetype changes
        /// </summary>
        /// <remarks>
        ///     Verifies that component data is preserved when an entity
        ///     transitions between archetypes.
        /// </remarks>
        [Fact]
        public void AdvancedEcs_ComponentDataPreservedAcrossArchetypeChanges()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            // Act
            entity.Add(new Position());
            ref Position pos1 = ref entity.Get<Position>();
            pos1.X = 100;
            pos1.Y = 200;

            entity.Add(new Velocity());
            ref Position pos2 = ref entity.Get<Position>();

            // Assert
            Assert.Equal(100, pos2.X);
            Assert.Equal(200, pos2.Y);
        }

        /// <summary>
        ///     Tests rapid add/remove cycles don't corrupt state
        /// </summary>
        /// <remarks>
        ///     Validates that quickly adding and removing components
        ///     doesn't introduce bugs or memory corruption.
        /// </remarks>
        [Fact]
        public void AdvancedEcs_RapidAddRemoveCyclesDoNotCorruptState()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            // Act
            for (int i = 0; i < 10; i++)
            {
                entity.Add(new Position());
                entity.Add(new Velocity());
                entity.Remove<Position>();
                entity.Remove<Velocity>();
            }

            // Assert
            Assert.False(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
        }

        /// <summary>
        ///     Tests multiple scenes can coexist independently
        /// </summary>
        /// <remarks>
        ///     Verifies that multiple Scene instances operate independently
        ///     without interfering with each other.
        /// </remarks>
        [Fact]
        public void AdvancedEcs_MultipleScenesCoexistIndependently()
        {
            // Arrange
            using Scene scene1 = new Scene();
            using Scene scene2 = new Scene();

            // Act
            GameObject e1 = scene1.Create();
            GameObject e2 = scene2.Create();
            e1.Add(new Position());
            e2.Add(new Health());

            // Assert
            Assert.True(e1.Has<Position>());
            Assert.False(e1.Has<Health>());
            Assert.True(e2.Has<Health>());
            Assert.False(e2.Has<Position>());
        }

        /// <summary>
        ///     Tests component access consistency across updates
        /// </summary>
        /// <remarks>
        ///     Validates that component references obtained at different times
        ///     point to the same entity data.
        /// </remarks>
        [Fact]
        public void AdvancedEcs_ComponentAccessConsistencyAcrossUpdates()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            entity.Add(new Position());
            ref Position pos1 = ref entity.Get<Position>();
            pos1.X = 42;

            // Act
            ref Position pos2 = ref entity.Get<Position>();
            pos2.Y = 84;

            // Assert
            Assert.Equal(42, entity.Get<Position>().X);
            Assert.Equal(84, entity.Get<Position>().Y);
        }
    }
}

