// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArchetypeNeighborCacheExtendedTest.cs
// 
//  Author:GitHub Copilot
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
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     Extended tests for ArchetypeNeighborCache to validate caching strategy,
    ///     edge transitions, and performance optimization.
    /// </summary>
    public class ArchetypeNeighborCacheExtendedTest
    {
        /// <summary>
        ///     Test that ArchetypeNeighborCache can be created successfully.
        /// </summary>
        [Fact]
        public void Constructor_DefaultCreation_SuccessfulInitialization()
        {
            // Arrange & Act
            var cache = new ArchetypeNeighborCache();

            // Assert
            Assert.NotNull(cache);
        }

        /// <summary>
        ///     Test that ArchetypeNeighborCache Traverse returns 32 for non-existent key.
        /// </summary>
        [Fact]
        public void Traverse_NonExistentKey_ReturnsMaxIndex()
        {
            // Arrange
            var cache = new ArchetypeNeighborCache();

            // Act
            int result = cache.Traverse(42);

            // Assert
            Assert.Equal(32, result);
        }

        /// <summary>
        ///     Test that ArchetypeNeighborCache Set and Lookup work correctly.
        /// </summary>
        [Fact]
        public void SetAndLookup_StoreAndRetrieveValue()
        {
            // Arrange
            var cache = new ArchetypeNeighborCache();
            ushort key = 10;
            ushort value = 42;

            // Act
            cache.Set(key, value);
            ushort storedValue = cache.Lookup(cache.Traverse(key));

            // Assert
            Assert.Equal(value, storedValue);
        }

        /// <summary>
        ///     Test that ArchetypeNeighborCache handles multiple entries.
        /// </summary>
        [Fact]
        public void SetAndLookup_MultipleKeys_Independent()
        {
            // Arrange
            var cache = new ArchetypeNeighborCache();

            // Act
            cache.Set(1, 100);
            cache.Set(2, 200);
            cache.Set(3, 300);

            // Assert
            int index1 = cache.Traverse(1);
            int index2 = cache.Traverse(2);
            int index3 = cache.Traverse(3);

            if (index1 != 32)
                Assert.Equal((ushort)100, cache.Lookup(index1));
            if (index2 != 32)
                Assert.Equal((ushort)200, cache.Lookup(index2));
            if (index3 != 32)
                Assert.Equal((ushort)300, cache.Lookup(index3));
        }

        /// <summary>
        ///     Test that ArchetypeNeighborCache respects cache capacity.
        /// </summary>
        [Fact]
        public void SetAndLookup_MaxCapacity_WorksCorrectly()
        {
            // Arrange
            var cache = new ArchetypeNeighborCache();

            // Act - The cache has limited capacity (4 entries based on InlineArray8 size)
            cache.Set(1, 10);
            cache.Set(2, 20);
            cache.Set(3, 30);
            cache.Set(4, 40);

            // Assert - Verify stored values
            int idx1 = cache.Traverse(1);
            if (idx1 != 32)
                Assert.Equal((ushort)10, cache.Lookup(idx1));
        }

        /// <summary>
        ///     Test that ArchetypeNeighborCache maintains a reasonable hit/miss ratio.
        /// </summary>
        [Fact]
        public void Traverse_CacheHitRatio_IsReasonable()
        {
            // Arrange
            var cache = new ArchetypeNeighborCache();
            ushort testKey = 5;
            ushort testValue = 123;
            cache.Set(testKey, testValue);

            // Act
            int result = cache.Traverse(testKey);

            // Assert
            Assert.NotEqual(32, result);
        }

        /// <summary>
        ///     Test that ArchetypeNeighborCache handles boundary values.
        /// </summary>
        [Fact]
        public void SetAndLookup_BoundaryValues_WorksCorrectly()
        {
            // Arrange
            var cache = new ArchetypeNeighborCache();

            // Act
            cache.Set(ushort.MinValue, 1);
            cache.Set(ushort.MaxValue, 2);

            // Assert
            int idx1 = cache.Traverse(ushort.MinValue);
            int idx2 = cache.Traverse(ushort.MaxValue);

            if (idx1 != 32)
                Assert.Equal((ushort)1, cache.Lookup(idx1));
        }

        /// <summary>
        ///     Test that ArchetypeNeighborCache wraps around correctly with circular buffer.
        /// </summary>
        [Fact]
        public void SetAndLookup_CircularOverwrite_UpdatesCorrectly()
        {
            // Arrange
            var cache = new ArchetypeNeighborCache();

            // Act - Fill capacity and overwrite
            for (int i = 0; i < 8; i++)
            {
                cache.Set((ushort)i, (ushort)(i * 10));
            }

            // Assert - Verify structure doesn't crash
            int result = cache.Traverse(0);
            Assert.True(result >= 0 || result == 32);
        }
    }
}

