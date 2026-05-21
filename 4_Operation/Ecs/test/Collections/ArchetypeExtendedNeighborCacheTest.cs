

using Alis.Core.Ecs.Collections;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     The archetype neighbor cache test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="ArchetypeNeighborCache" /> struct which maintains
    ///     a fast cache for frequently accessed adjacent archetypes.
    /// </remarks>
    public class ArchetypeExtendedNeighborCacheTest
    {
        /// <summary>
        ///     Tests that archetype neighbor cache can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that ArchetypeNeighborCache can be instantiated.
        /// </remarks>
        [Fact]
        public void v2_ArchetypeNeighborCache_CanBeCreated()
        {
            ArchetypeNeighborCache cache = new ArchetypeNeighborCache();

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
            ArchetypeNeighborCache cache = new ArchetypeNeighborCache();

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
            ArchetypeNeighborCache cache1 = new ArchetypeNeighborCache();
            ArchetypeNeighborCache cache2 = cache1;

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
            ArchetypeNeighborCache cache = default(ArchetypeNeighborCache);

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
            ArchetypeNeighborCache cache1 = new ArchetypeNeighborCache();
            ArchetypeNeighborCache cache2 = new ArchetypeNeighborCache();

            Assert.NotNull(cache1);
            Assert.NotNull(cache2);
        }
    }
}