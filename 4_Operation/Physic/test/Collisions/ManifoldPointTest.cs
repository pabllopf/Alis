

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The manifold point test class
    /// </summary>
    public class ManifoldPointTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with default values
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithDefaultValues()
        {
            ManifoldPoint point = new ManifoldPoint();

            Assert.Equal(Vector2F.Zero, point.LocalPoint);
            Assert.Equal(0.0f, point.NormalImpulse);
            Assert.Equal(0.0f, point.TangentImpulse);
        }

        /// <summary>
        ///     Tests that local point should set and get correctly
        /// </summary>
        [Fact]
        public void LocalPoint_ShouldSetAndGetCorrectly()
        {
            ManifoldPoint point = new ManifoldPoint
            {
                LocalPoint = new Vector2F(1.0f, 2.0f)
            };

            Assert.Equal(new Vector2F(1.0f, 2.0f), point.LocalPoint);
        }

        /// <summary>
        ///     Tests that normal impulse should set and get correctly
        /// </summary>
        [Fact]
        public void NormalImpulse_ShouldSetAndGetCorrectly()
        {
            ManifoldPoint point = new ManifoldPoint
            {
                NormalImpulse = 5.0f
            };

            Assert.Equal(5.0f, point.NormalImpulse);
        }

        /// <summary>
        ///     Tests that tangent impulse should set and get correctly
        /// </summary>
        [Fact]
        public void TangentImpulse_ShouldSetAndGetCorrectly()
        {
            ManifoldPoint point = new ManifoldPoint
            {
                TangentImpulse = 3.0f
            };

            Assert.Equal(3.0f, point.TangentImpulse);
        }

        /// <summary>
        ///     Tests that id should set and get correctly
        /// </summary>
        [Fact]
        public void Id_ShouldSetAndGetCorrectly()
        {
            ManifoldPoint point = new ManifoldPoint();
            ContactId id = new ContactId();

            point.Id = id;

            Assert.Equal(id, point.Id);
        }

        /// <summary>
        ///     Tests that all properties should set correctly
        /// </summary>
        [Fact]
        public void AllProperties_ShouldSetCorrectly()
        {
            ManifoldPoint point = new ManifoldPoint
            {
                LocalPoint = new Vector2F(1.0f, 2.0f),
                NormalImpulse = 5.0f,
                TangentImpulse = 3.0f,
                Id = new ContactId()
            };

            Assert.Equal(new Vector2F(1.0f, 2.0f), point.LocalPoint);
            Assert.Equal(5.0f, point.NormalImpulse);
            Assert.Equal(3.0f, point.TangentImpulse);
        }

        /// <summary>
        ///     Tests that impulses with negative values should work
        /// </summary>
        [Fact]
        public void Impulses_WithNegativeValues_ShouldWork()
        {
            ManifoldPoint point = new ManifoldPoint
            {
                NormalImpulse = -1.0f,
                TangentImpulse = -2.0f
            };

            Assert.Equal(-1.0f, point.NormalImpulse);
            Assert.Equal(-2.0f, point.TangentImpulse);
        }

        /// <summary>
        ///     Tests that impulses with zero should work
        /// </summary>
        [Fact]
        public void Impulses_WithZero_ShouldWork()
        {
            ManifoldPoint point = new ManifoldPoint
            {
                NormalImpulse = 0.0f,
                TangentImpulse = 0.0f
            };

            Assert.Equal(0.0f, point.NormalImpulse);
            Assert.Equal(0.0f, point.TangentImpulse);
        }
    }
}