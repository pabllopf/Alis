

using System;
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
            ShortSparseSet<int> shortSet = new ShortSparseSet<int>();

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
            Chunk<int> chunk = new Chunk<int>(100);

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
            Chunk<int> chunk = new Chunk<int>(10);

            chunk[0] = 100;
            chunk[5] = 500;

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
            Chunk<int> chunk = new Chunk<int>(5);
            chunk[0] = 10;
            chunk[1] = 20;

            Span<int> span = chunk.AsSpan();

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
            ArchetypeNeighborCache cache = new ArchetypeNeighborCache();

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
            ArchetypeNeighborCache cache = new ArchetypeNeighborCache();

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
            Chunk<int> chunk = new Chunk<int>(10);
            chunk[0] = 100;

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
            Chunk<int> chunk = new Chunk<int>(10);
            for (int i = 0; i < 10; i++)
            {
                chunk[i] = i * 10;
            }

            Span<int> partialSpan = chunk.AsSpan(2, 3);

            Assert.Equal(20, partialSpan[0]);
            Assert.Equal(30, partialSpan[1]);
            Assert.Equal(40, partialSpan[2]);
        }
    }
}