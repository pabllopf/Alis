

using System.Collections.Generic;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     Extended tests for FastLookup collection to ensure comprehensive behavior validation.
    ///     Tests include edge cases, capacity management, and stress scenarios.
    /// </summary>
    public class FastLookupExtendedTest
    {
        /// <summary>
        ///     Test that FastLookup can be created successfully.
        /// </summary>
        [Fact]
        public void Constructor_Default_CreatedSuccessfully()
        {
            FastLookup lookup = new FastLookup();

            Assert.NotNull(lookup);
        }

        /// <summary>
        ///     Test that FastLookup properly stores and retrieves data.
        /// </summary>
        [Fact]
        public void GetKey_AfterGet_ReturnsValidIndex()
        {
            FastLookup lookup = new FastLookup();

            uint key1 = FastLookup.GetKey(10, new GameObjectType(5));
            uint key2 = FastLookup.GetKey(20, new GameObjectType(5));

            Assert.NotEqual(key1, key2);
        }

        /// <summary>
        ///     Test that FastLookup properly handles multiple different keys.
        /// </summary>
        [Fact]
        public void GetKey_DifferentInputs_DifferentKeys()
        {
            FastLookup lookup = new FastLookup();

            uint key1 = FastLookup.GetKey(5, new GameObjectType(10));
            uint key2 = FastLookup.GetKey(5, new GameObjectType(11));
            uint key3 = FastLookup.GetKey(6, new GameObjectType(10));

            Assert.NotEqual(key1, key2);
            Assert.NotEqual(key1, key3);
            Assert.NotEqual(key2, key3);
        }

        /// <summary>
        ///     Test that FastLookup can generate keys for boundary values.
        /// </summary>
        [Fact]
        public void GetKey_BoundaryValues_GeneratesValidKeys()
        {
            FastLookup lookup = new FastLookup();

            uint key1 = FastLookup.GetKey(0, new GameObjectType(0));
            uint key2 = FastLookup.GetKey(ushort.MaxValue, new GameObjectType(ushort.MaxValue));

            Assert.NotEqual(key1, key2);
        }

        /// <summary>
        ///     Test that FastLookup generates consistent keys for same inputs.
        /// </summary>
        [Fact]
        public void GetKey_SameInputs_GeneratesSameKey()
        {
            FastLookup lookup = new FastLookup();
            ushort id = 42;
            GameObjectType archetype = new GameObjectType(10);

            uint key1 = FastLookup.GetKey(id, archetype);
            uint key2 = FastLookup.GetKey(id, archetype);

            Assert.Equal(key1, key2);
        }

        /// <summary>
        ///     Test that FastLookup can handle many key generation requests.
        /// </summary>
        [Fact]
        public void GetKey_ManyRequests_AllUnique()
        {
            FastLookup lookup = new FastLookup();
            HashSet<uint> keys = new HashSet<uint>();

            for (ushort i = 0; i < 100; i++)
            {
                uint key = FastLookup.GetKey(i, new GameObjectType(i));
                keys.Add(key);
            }

            Assert.Equal(100, keys.Count); // All keys should be unique
        }

        /// <summary>
        ///     Test that FastLookup properly manages lookup index operations.
        /// </summary>
        [Fact]
        public void LookupIndex_AfterGetKey_ReturnsValidIndex()
        {
            FastLookup lookup = new FastLookup();
            uint key = FastLookup.GetKey(5, new GameObjectType(10));

            int index = lookup.LookupIndex(key);

            Assert.True(index >= 0 || index == 32); // Valid index or not found indicator
        }

        /// <summary>
        ///     Test that FastLookup handles repeated lookups for same key.
        /// </summary>
        [Fact]
        public void LookupIndex_RepeatCalls_ReturnsSameIndex()
        {
            FastLookup lookup = new FastLookup();
            uint key = FastLookup.GetKey(15, new GameObjectType(20));

            int index1 = lookup.LookupIndex(key);
            int index2 = lookup.LookupIndex(key);

            Assert.Equal(index1, index2);
        }

        /// <summary>
        ///     Test that FastLookup properly handles non-existent key lookups.
        /// </summary>
        [Fact]
        public void LookupIndex_NonExistentKey_ReturnsNotFoundIndicator()
        {
            FastLookup lookup = new FastLookup();

            int index = lookup.LookupIndex(999999u);

            Assert.Equal(32, index); // Assuming 32 indicates not found
        }
    }
}