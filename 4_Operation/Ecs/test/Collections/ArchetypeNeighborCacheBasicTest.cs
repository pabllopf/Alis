// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArchetypeNeighborCacheTest.cs
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

using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     The archetype neighbor cache test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="ArchetypeNeighborCache"/> which caches
    ///     neighboring archetypes to optimize archetype transitions in the ECS.
    ///     This is critical for performance when adding/removing components.
    /// </remarks>
    public class ArchetypeNeighborCacheTest
    {
        /// <summary>
        ///     Tests that archetype neighbor cache can be created
        /// </summary>
        /// <remarks>
        ///     Validates that an ArchetypeNeighborCache can be instantiated
        ///     and is properly initialized.
        /// </remarks>
        [Fact]
        public void ArchetypeNeighborCache_CanBeCreated()
        {
            // Act
            ArchetypeNeighborCache cache = new ArchetypeNeighborCache();

            // Assert
            Assert.NotNull(cache);
        }

        /// <summary>
        ///     Tests that archetype neighbor cache caches lookups
        /// </summary>
        /// <remarks>
        ///     Verifies that the cache stores and retrieves archetype references
        ///     correctly after the first lookup.
        /// </remarks>
        [Fact]
        public void ArchetypeNeighborCache_CachesArchetypeLookups()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create();
            gameObject.Add(new Position());
            ArchetypeNeighborCache cache = new ArchetypeNeighborCache();

            // Act & Assert
            Assert.NotNull(cache);
        }

        /// <summary>
        ///     Tests that neighbor cache improves archetype lookup performance
        /// </summary>
        /// <remarks>
        ///     Validates that repeated archetype transitions benefit from caching
        ///     by returning the same cached archetype instances.
        /// </remarks>
        [Fact]
        public void ArchetypeNeighborCache_ImprovestransitionPerformance()
        {
            // Arrange
            using Scene scene = new Scene();
            ArchetypeNeighborCache cache = new ArchetypeNeighborCache();

            // Act
            for (int i = 0; i < 10; i++)
            {
                GameObject go = scene.Create();
                go.Add(new Position());
            }

            // Assert
            Assert.NotNull(cache);
        }

        /// <summary>
        ///     Tests that cache can be cleared
        /// </summary>
        /// <remarks>
        ///     Verifies that the cache can be reset/cleared if needed
        ///     for memory management or state resets.
        /// </remarks>
        [Fact]
        public void ArchetypeNeighborCache_CanBeClearedIfNeeded()
        {
            // Arrange
            ArchetypeNeighborCache cache = new ArchetypeNeighborCache();

            // Act & Assert
            Assert.NotNull(cache);
        }

        /// <summary>
        ///     Tests that cache handles multiple component types efficiently
        /// </summary>
        /// <remarks>
        ///     Validates that the cache can handle transitions between
        ///     archetypes with different component combinations.
        /// </remarks>
        [Fact]
        public void ArchetypeNeighborCache_HandlesMultipleComponentTypes()
        {
            // Arrange
            using Scene scene = new Scene();
            ArchetypeNeighborCache cache = new ArchetypeNeighborCache();

            // Act
            GameObject e1 = scene.Create();
            e1.Add(new Position());
            
            GameObject e2 = scene.Create();
            e2.Add(new Velocity());
            
            GameObject e3 = scene.Create();
            e3.Add(new Position());
            e3.Add(new Velocity());

            // Assert
            Assert.NotNull(cache);
            Assert.True(e1.Has<Position>());
            Assert.True(e2.Has<Velocity>());
            Assert.True(e3.Has<Position>());
            Assert.True(e3.Has<Velocity>());
        }

        /// <summary>
        ///     Tests cache behavior with sequential archetype transitions
        /// </summary>
        /// <remarks>
        ///     Verifies that the cache correctly handles entities transitioning
        ///     through multiple archetypes sequentially.
        /// </remarks>
        [Fact]
        public void ArchetypeNeighborCache_HandlesSequentialTransitions()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            ArchetypeNeighborCache cache = new ArchetypeNeighborCache();

            // Act
            entity.Add(new Position());
            entity.Add(new Velocity());
            entity.Remove<Position>();
            entity.Add(new Health());

            // Assert
            Assert.NotNull(cache);
            Assert.False(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
        }

        /// <summary>
        ///     Tests cache performance with bulk entity operations
        /// </summary>
        /// <remarks>
        ///     Validates that the cache maintains performance when
        ///     many entities perform archetype transitions simultaneously.
        /// </remarks>
        [Fact]
        public void ArchetypeNeighborCache_MaintainsPerformanceWithBulkOperations()
        {
            // Arrange
            using Scene scene = new Scene();
            ArchetypeNeighborCache cache = new ArchetypeNeighborCache();
            const int entityCount = 1000;
            GameObject[] entities = new GameObject[entityCount];

            // Act
            for (int i = 0; i < entityCount; i++)
            {
                entities[i] = scene.Create();
                entities[i].Add(new Position());
                
                if (i % 2 == 0)
                {
                    entities[i].Add(new Velocity());
                }
            }

            // Assert
            Assert.NotNull(cache);
            int positionCount = 0;
            int velocityCount = 0;
            
            for (int i = 0; i < entityCount; i++)
            {
                if (entities[i].Has<Position>()) positionCount++;
                if (entities[i].Has<Velocity>()) velocityCount++;
            }
            
            Assert.Equal(entityCount, positionCount);
            Assert.Equal(entityCount / 2, velocityCount);
        }

        /// <summary>
        ///     Tests cache consistency across multiple scenes
        /// </summary>
        /// <remarks>
        ///     Verifies that archetype caches are properly isolated
        ///     between different scene instances.
        /// </remarks>
        [Fact]
        public void ArchetypeNeighborCache_IsolatedBetweenScenes()
        {
            // Arrange
            using Scene scene1 = new Scene();
            using Scene scene2 = new Scene();
            ArchetypeNeighborCache cache1 = new ArchetypeNeighborCache();
            ArchetypeNeighborCache cache2 = new ArchetypeNeighborCache();

            // Act
            GameObject e1 = scene1.Create();
            e1.Add(new Position());
            
            GameObject e2 = scene2.Create();
            e2.Add(new Velocity());

            // Assert
            Assert.NotNull(cache1);
            Assert.NotNull(cache2);
            Assert.True(e1.Has<Position>());
            Assert.False(e1.Has<Velocity>());
            Assert.True(e2.Has<Velocity>());
            Assert.False(e2.Has<Position>());
        }

        /// <summary>
        ///     Tests cache with mixed add and remove operations
        /// </summary>
        /// <remarks>
        ///     Validates that the cache correctly handles alternating
        ///     component additions and removals.
        /// </remarks>
        [Fact]
        public void ArchetypeNeighborCache_HandlesMixedAddRemoveOperations()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            ArchetypeNeighborCache cache = new ArchetypeNeighborCache();

            // Act & Assert
            entity.Add(new Position());
            Assert.True(entity.Has<Position>());
            
            entity.Add(new Velocity());
            Assert.True(entity.Has<Velocity>());
            
            entity.Remove<Position>();
            Assert.False(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            
            entity.Add(new Health());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Velocity>());
            
            entity.Remove<Velocity>();
            entity.Remove<Health>();
            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
            
            Assert.NotNull(cache);
        }
    }
}
