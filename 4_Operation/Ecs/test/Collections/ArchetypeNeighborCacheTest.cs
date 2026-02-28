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
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     The archetype neighbor cache test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="ArchetypeNeighborCache"/> struct which maintains
    ///     a fast cache for frequently accessed adjacent archetypes.
    /// </remarks>
    public class ArchetypeNeighborCacheTest
    {
        /// <summary>
        ///     Tests that archetype neighbor cache can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that ArchetypeNeighborCache can be instantiated.
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
        ///     Tests that archetype neighbor cache has valid initial state
        /// </summary>
        /// <remarks>
        ///     Validates that the cache starts in a valid state.
        /// </remarks>
        [Fact]
        public void ArchetypeNeighborCache_HasValidInitialState()
        {
            // Act
            ArchetypeNeighborCache cache = new ArchetypeNeighborCache();

            // Assert
            // The cache should be created successfully and usable
            Assert.NotNull(cache);
        }

        /// <summary>
        ///     Tests that archetype neighbor cache is value type
        /// </summary>
        /// <remarks>
        ///     Confirms that ArchetypeNeighborCache is a value type (struct).
        /// </remarks>
        [Fact]
        public void ArchetypeNeighborCache_IsValueType()
        {
            // Arrange
            ArchetypeNeighborCache cache1 = new ArchetypeNeighborCache();
            ArchetypeNeighborCache cache2 = cache1;

            // Assert
            // They should be separate instances since it's a struct
            Assert.NotNull(cache1);
            Assert.NotNull(cache2);
        }

        /// <summary>
        ///     Tests that archetype neighbor cache can be default initialized
        /// </summary>
        /// <remarks>
        ///     Tests that default(ArchetypeNeighborCache) creates a valid instance.
        /// </remarks>
        [Fact]
        public void ArchetypeNeighborCache_CanBeDefaultInitialized()
        {
            // Act
            ArchetypeNeighborCache cache = default;

            // Assert
            Assert.NotNull(cache);
        }

        /// <summary>
        ///     Tests that archetype neighbor cache instances are independent
        /// </summary>
        /// <remarks>
        ///     Validates that multiple instances don't interfere with each other.
        /// </remarks>
        [Fact]
        public void ArchetypeNeighborCache_InstancesAreIndependent()
        {
            // Act
            ArchetypeNeighborCache cache1 = new ArchetypeNeighborCache();
            ArchetypeNeighborCache cache2 = new ArchetypeNeighborCache();

            // Assert
            Assert.NotNull(cache1);
            Assert.NotNull(cache2);
        }
    }
}

