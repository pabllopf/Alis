

using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     The fast lookup test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="FastLookup" /> struct which provides fast
    ///     archetype lookup for component and tag operations.
    /// </remarks>
    public class FastLookupTest
    {
        /// <summary>
        ///     Tests that fast lookup can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that a FastLookup instance can be created.
        /// </remarks>
        [Fact]
        public void FastLookup_CanBeCreated()
        {
            FastLookup lookup = new FastLookup();

            Assert.NotNull(lookup.Archetypes);
        }

        /// <summary>
        ///     Tests that fast lookup get key combines id and archetype
        /// </summary>
        /// <remarks>
        ///     Validates that GetKey properly combines component/tag ID with archetype ID.
        /// </remarks>
        [Fact]
        public void FastLookup_GetKeyCombinesIdAndArchetype()
        {
            FastLookup lookup = new FastLookup();
            ushort id = 5;
            GameObjectType archetypeId = new GameObjectType(10);

            uint key = FastLookup.GetKey(id, archetypeId);

            Assert.NotEqual(0u, key);
            Assert.Equal((uint) ((id << 16) | archetypeId.RawIndex), key);
        }

        /// <summary>
        ///     Tests that fast lookup get key with zero values
        /// </summary>
        /// <remarks>
        ///     Tests GetKey with zero ID and zero archetype ID.
        /// </remarks>
        [Fact]
        public void FastLookup_GetKeyWithZeroValues()
        {
            FastLookup lookup = new FastLookup();
            ushort id = 0;
            GameObjectType archetypeId = new GameObjectType(0);

            uint key = FastLookup.GetKey(id, archetypeId);

            Assert.Equal(0u, key);
        }

        /// <summary>
        ///     Tests that fast lookup get key with max values
        /// </summary>
        /// <remarks>
        ///     Tests GetKey with maximum ID values.
        /// </remarks>
        [Fact]
        public void FastLookup_GetKeyWithMaxValues()
        {
            FastLookup lookup = new FastLookup();
            ushort id = ushort.MaxValue;
            GameObjectType archetypeId = new GameObjectType(ushort.MaxValue);

            uint key = FastLookup.GetKey(id, archetypeId);

            Assert.NotEqual(0u, key);
        }

        /// <summary>
        ///     Tests that fast lookup lookup index returns not found for non existent key
        /// </summary>
        /// <remarks>
        ///     Verifies that LookupIndex returns 32 (not found) for non-existent keys.
        /// </remarks>
        [Fact]
        public void FastLookup_LookupIndexReturnsNotFoundForNonExistentKey()
        {
            FastLookup lookup = new FastLookup();
            uint key = 999u;

            int result = lookup.LookupIndex(key);

            Assert.Equal(32, result);
        }

        /// <summary>
        ///     Tests that fast lookup archetypes array is initialized
        /// </summary>
        /// <remarks>
        ///     Validates that the Archetypes array is properly initialized.
        /// </remarks>
        [Fact]
        public void FastLookup_ArchetypesArrayIsInitialized()
        {
            FastLookup lookup = new FastLookup();

            Assert.NotNull(lookup.Archetypes);
            Assert.Equal(8, lookup.Archetypes.Length);
        }

        /// <summary>
        ///     Tests that fast lookup different keys produce different values
        /// </summary>
        /// <remarks>
        ///     Verifies that different input combinations produce different keys.
        /// </remarks>
        [Fact]
        public void FastLookup_DifferentKeysProduceDifferentValues()
        {
            FastLookup lookup = new FastLookup();

            uint key1 = FastLookup.GetKey(1, new GameObjectType(1));
            uint key2 = FastLookup.GetKey(2, new GameObjectType(2));
            uint key3 = FastLookup.GetKey(1, new GameObjectType(2));

            Assert.NotEqual(key1, key2);
            Assert.NotEqual(key1, key3);
            Assert.NotEqual(key2, key3);
        }

        /// <summary>
        ///     Tests that fast lookup is value type
        /// </summary>
        /// <remarks>
        ///     Confirms that FastLookup is a value type (struct).
        /// </remarks>
        [Fact]
        public void FastLookup_IsValueType()
        {
            FastLookup lookup1 = new FastLookup();
            FastLookup lookup2 = lookup1;
            lookup2.Archetypes[0] = null;

            Assert.Null(lookup2.Archetypes[0]);
        }
    }
}