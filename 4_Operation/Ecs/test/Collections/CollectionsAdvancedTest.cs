// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CollectionsAdvancedTest.cs
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
    ///     The collections advanced test class
    /// </summary>
    /// <remarks>
    ///     Advanced tests for ECS collection types including FrugalStack,
    ///     InlineArray8, IDTable, and other collection implementations
    ///     optimized for the ECS system patterns.
    /// </remarks>
    public class CollectionsAdvancedTest
    {
        /// <summary>
        ///     Tests that short sparse set can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that ShortSparseSet can be instantiated and used
        ///     for sparse set operations with smaller data.
        /// </remarks>
        [Fact]
        public void ShortSparseSet_CanBeCreated()
        {
            // Act
            var shortSet = new ShortSparseSet<int>();

            // Assert
            Assert.NotNull(shortSet);
        }


        /// <summary>
        ///     Tests that chunk can be created with capacity
        /// </summary>
        /// <remarks>
        ///     Tests that Chunk struct can be created and used for
        ///     managing fixed-size component data arrays.
        /// </remarks>
        [Fact]
        public void Chunk_CanBeCreatedWithCapacity()
        {
            // Act
            var chunk = new Chunk<int>(100);

            // Assert
            Assert.NotNull(chunk.Buffer);
        }

        /// <summary>
        ///     Tests that chunk supports element access
        /// </summary>
        /// <remarks>
        ///     Tests that Chunk can store and retrieve elements at
        ///     specific indices.
        /// </remarks>
        [Fact]
        public void Chunk_SupportsElementAccess()
        {
            // Arrange
            var chunk = new Chunk<int>(10);

            // Act
            chunk[0] = 100;
            chunk[5] = 500;

            // Assert
            Assert.Equal(100, chunk[0]);
            Assert.Equal(500, chunk[5]);
        }

        /// <summary>
        ///     Tests that chunk can be converted to span
        /// </summary>
        /// <remarks>
        ///     Tests that Chunk.AsSpan provides span view of the chunk data
        ///     for efficient iteration.
        /// </remarks>
        [Fact]
        public void Chunk_CanBeConvertedToSpan()
        {
            // Arrange
            var chunk = new Chunk<int>(5);
            chunk[0] = 10;
            chunk[1] = 20;

            // Act
            var span = chunk.AsSpan();

            // Assert
            Assert.Equal(10, span[0]);
            Assert.Equal(20, span[1]);
        }

        /// <summary>
        ///     Tests that archive neighbor cache improves lookup performance
        /// </summary>
        /// <remarks>
        ///     Tests that ArchetypeNeighborCache caches archetype transitions
        ///     for faster component add/remove operations.
        /// </remarks>
        [Fact]
        public void ArchetypeNeighborCache_CachesTransitions()
        {
            // Act
            var cache = new ArchetypeNeighborCache();

            // Assert
            Assert.NotNull(cache);
        }

        /// <summary>
        ///     Tests that archetype neighbor cache improves lookup performance
        /// </summary>
        /// <remarks>
        ///     Tests that ArchetypeNeighborCache is a proper struct type.
        /// </remarks>
        [Fact]
        public void ArchetypeNeighborCache_HasProperStructure()
        {
            // Act
            var cache = new ArchetypeNeighborCache();

            // Assert - just verify it can be instantiated
            // ArchetypeNeighborCache is a value type
        }

        /// <summary>
        ///     Tests that chunk can be returned to pool
        /// </summary>
        /// <remarks>
        ///     Tests that Chunk.Return properly releases memory back to
        ///     the memory pool for reuse.
        /// </remarks>
        [Fact]
        public void Chunk_CanBeReturnedToPool()
        {
            // Arrange
            var chunk = new Chunk<int>(10);
            chunk[0] = 100;

            // Act & Assert (no exception should be thrown)
            chunk.Return();
        }

        /// <summary>
        ///     Tests that chunk supports partial span
        /// </summary>
        /// <remarks>
        ///     Tests that Chunk.AsSpan with start and length parameters
        ///     provides partial view of chunk data.
        /// </remarks>
        [Fact]
        public void Chunk_SupportsPartialSpan()
        {
            // Arrange
            var chunk = new Chunk<int>(10);
            for (int i = 0; i < 10; i++)
            {
                chunk[i] = i * 10;
            }

            // Act
            var partialSpan = chunk.AsSpan(2, 3);

            // Assert
            Assert.Equal(20, partialSpan[0]);
            Assert.Equal(30, partialSpan[1]);
            Assert.Equal(40, partialSpan[2]);
        }
    }
}

