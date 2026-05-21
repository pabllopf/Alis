

using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The simplex cache test class
    /// </summary>
    public class SimplexCacheTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with default values
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithDefaultValues()
        {
            SimplexCache cache = new SimplexCache();

            Assert.Equal(0, cache.Count);
            Assert.Equal(0.0f, cache.Metric);
        }

        /// <summary>
        ///     Tests that count should set and get correctly
        /// </summary>
        [Fact]
        public void Count_ShouldSetAndGetCorrectly()
        {
            SimplexCache cache = new SimplexCache
            {
                Count = 3
            };

            Assert.Equal(3, cache.Count);
        }

        /// <summary>
        ///     Tests that metric should set and get correctly
        /// </summary>
        [Fact]
        public void Metric_ShouldSetAndGetCorrectly()
        {
            SimplexCache cache = new SimplexCache
            {
                Metric = 1.5f
            };

            Assert.Equal(1.5f, cache.Metric);
        }

        /// <summary>
        ///     Tests that all properties should set correctly
        /// </summary>
        [Fact]
        public void AllProperties_ShouldSetCorrectly()
        {
            SimplexCache cache = new SimplexCache
            {
                Count = 2,
                Metric = 2.5f
            };

            Assert.Equal(2, cache.Count);
            Assert.Equal(2.5f, cache.Metric);
        }

        /// <summary>
        ///     Tests that count with zero should work
        /// </summary>
        [Fact]
        public void Count_WithZero_ShouldWork()
        {
            SimplexCache cache = new SimplexCache
            {
                Count = 0
            };

            Assert.Equal(0, cache.Count);
        }

        /// <summary>
        ///     Tests that count with max ushort value should work
        /// </summary>
        [Fact]
        public void Count_WithMaxUshortValue_ShouldWork()
        {
            SimplexCache cache = new SimplexCache
            {
                Count = ushort.MaxValue
            };

            Assert.Equal(ushort.MaxValue, cache.Count);
        }

        /// <summary>
        ///     Tests that metric with negative value should work
        /// </summary>
        [Fact]
        public void Metric_WithNegativeValue_ShouldWork()
        {
            SimplexCache cache = new SimplexCache
            {
                Metric = -1.0f
            };

            Assert.Equal(-1.0f, cache.Metric);
        }
    }
}