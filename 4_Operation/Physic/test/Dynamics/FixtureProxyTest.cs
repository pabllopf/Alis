

using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The fixture proxy test class
    /// </summary>
    public class FixtureProxyTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with default values
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithDefaultValues()
        {
            FixtureProxy proxy = new FixtureProxy();

            Assert.Equal(0, proxy.ChildIndex);
            Assert.Equal(0, proxy.ProxyId);
            Assert.Null(proxy.Fixture);
        }

        /// <summary>
        ///     Tests that aabb should set and get correctly
        /// </summary>
        [Fact]
        public void Aabb_ShouldSetAndGetCorrectly()
        {
            FixtureProxy proxy = new FixtureProxy();
            Aabb aabb = new Aabb();

            proxy.Aabb = aabb;

            Assert.Equal(aabb, proxy.Aabb);
        }

        /// <summary>
        ///     Tests that child index should set and get correctly
        /// </summary>
        [Fact]
        public void ChildIndex_ShouldSetAndGetCorrectly()
        {
            FixtureProxy proxy = new FixtureProxy
            {
                ChildIndex = 5
            };

            Assert.Equal(5, proxy.ChildIndex);
        }

        /// <summary>
        ///     Tests that proxy id should set and get correctly
        /// </summary>
        [Fact]
        public void ProxyId_ShouldSetAndGetCorrectly()
        {
            FixtureProxy proxy = new FixtureProxy
            {
                ProxyId = 100
            };

            Assert.Equal(100, proxy.ProxyId);
        }

        /// <summary>
        ///     Tests that all properties should set correctly
        /// </summary>
        [Fact]
        public void AllProperties_ShouldSetCorrectly()
        {
            FixtureProxy proxy = new FixtureProxy
            {
                Aabb = new Aabb(),
                ChildIndex = 3,
                ProxyId = 50
            };

            Assert.NotNull(proxy.Aabb);
            Assert.Equal(3, proxy.ChildIndex);
            Assert.Equal(50, proxy.ProxyId);
        }

        /// <summary>
        ///     Tests that proxy id with negative value should work
        /// </summary>
        [Fact]
        public void ProxyId_WithNegativeValue_ShouldWork()
        {
            FixtureProxy proxy = new FixtureProxy
            {
                ProxyId = -1
            };

            Assert.Equal(-1, proxy.ProxyId);
        }

        /// <summary>
        ///     Tests that child index with negative value should work
        /// </summary>
        [Fact]
        public void ChildIndex_WithNegativeValue_ShouldWork()
        {
            FixtureProxy proxy = new FixtureProxy
            {
                ChildIndex = -1
            };

            Assert.Equal(-1, proxy.ChildIndex);
        }
    }
}