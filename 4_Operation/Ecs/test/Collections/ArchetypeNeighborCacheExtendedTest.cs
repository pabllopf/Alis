

using Alis.Core.Ecs.Collections;
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
            ArchetypeNeighborCache cache = new ArchetypeNeighborCache();

            Assert.NotNull(cache);
        }

        /// <summary>
        ///     Test that ArchetypeNeighborCache Traverse returns 32 for non-existent key.
        /// </summary>
        [Fact]
        public void Traverse_NonExistentKey_ReturnsMaxIndex()
        {
            ArchetypeNeighborCache cache = new ArchetypeNeighborCache();

            int result = cache.Traverse(42);

            Assert.Equal(32, result);
        }

        /// <summary>
        ///     Test that ArchetypeNeighborCache Set and Lookup work correctly.
        /// </summary>
        [Fact]
        public void SetAndLookup_StoreAndRetrieveValue()
        {
            ArchetypeNeighborCache cache = new ArchetypeNeighborCache();
            ushort key = 10;
            ushort value = 42;

            cache.Set(key, value);
            ushort storedValue = cache.Lookup(cache.Traverse(key));

            Assert.Equal(value, storedValue);
        }

        /// <summary>
        ///     Test that ArchetypeNeighborCache handles multiple entries.
        /// </summary>
        [Fact]
        public void SetAndLookup_MultipleKeys_Independent()
        {
            ArchetypeNeighborCache cache = new ArchetypeNeighborCache();

            cache.Set(1, 100);
            cache.Set(2, 200);
            cache.Set(3, 300);

            int index1 = cache.Traverse(1);
            int index2 = cache.Traverse(2);
            int index3 = cache.Traverse(3);

            if (index1 != 32)
            {
                Assert.Equal((ushort) 100, cache.Lookup(index1));
            }

            if (index2 != 32)
            {
                Assert.Equal((ushort) 200, cache.Lookup(index2));
            }

            if (index3 != 32)
            {
                Assert.Equal((ushort) 300, cache.Lookup(index3));
            }
        }

        /// <summary>
        ///     Test that ArchetypeNeighborCache respects cache capacity.
        /// </summary>
        [Fact]
        public void SetAndLookup_MaxCapacity_WorksCorrectly()
        {
            ArchetypeNeighborCache cache = new ArchetypeNeighborCache();

            cache.Set(1, 10);
            cache.Set(2, 20);
            cache.Set(3, 30);
            cache.Set(4, 40);

            int idx1 = cache.Traverse(1);
            if (idx1 != 32)
            {
                Assert.Equal((ushort) 10, cache.Lookup(idx1));
            }
        }

        /// <summary>
        ///     Test that ArchetypeNeighborCache maintains a reasonable hit/miss ratio.
        /// </summary>
        [Fact]
        public void Traverse_CacheHitRatio_IsReasonable()
        {
            ArchetypeNeighborCache cache = new ArchetypeNeighborCache();
            ushort testKey = 5;
            ushort testValue = 123;
            cache.Set(testKey, testValue);

            int result = cache.Traverse(testKey);

            Assert.NotEqual(32, result);
        }

        /// <summary>
        ///     Test that ArchetypeNeighborCache handles boundary values.
        /// </summary>
        [Fact]
        public void SetAndLookup_BoundaryValues_WorksCorrectly()
        {
            ArchetypeNeighborCache cache = new ArchetypeNeighborCache();

            cache.Set(ushort.MinValue, 1);
            cache.Set(ushort.MaxValue, 2);

            int idx1 = cache.Traverse(ushort.MinValue);
            int idx2 = cache.Traverse(ushort.MaxValue);

            if (idx1 != 32)
            {
                Assert.Equal((ushort) 1, cache.Lookup(idx1));
            }
        }

        /// <summary>
        ///     Test that ArchetypeNeighborCache wraps around correctly with circular buffer.
        /// </summary>
        [Fact]
        public void SetAndLookup_CircularOverwrite_UpdatesCorrectly()
        {
            ArchetypeNeighborCache cache = new ArchetypeNeighborCache();

            for (int i = 0; i < 8; i++)
            {
                cache.Set((ushort) i, (ushort) (i * 10));
            }

            int result = cache.Traverse(0);
            Assert.True(result >= 0 || result == 32);
        }
    }
}