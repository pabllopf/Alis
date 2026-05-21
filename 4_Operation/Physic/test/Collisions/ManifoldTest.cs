

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The manifold test class
    /// </summary>
    public class ManifoldTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with default values
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithDefaultValues()
        {
            Manifold manifold = new Manifold();

            Assert.Equal(Vector2F.Zero, manifold.LocalNormal);
            Assert.Equal(Vector2F.Zero, manifold.LocalPoint);
            Assert.Equal(0, manifold.PointCount);
            Assert.Equal(ManifoldType.Circles, manifold.Type);
        }

        /// <summary>
        ///     Tests that local normal should set and get correctly
        /// </summary>
        [Fact]
        public void LocalNormal_ShouldSetAndGetCorrectly()
        {
            Manifold manifold = new Manifold
            {
                LocalNormal = new Vector2F(1.0f, 0.0f)
            };

            Assert.Equal(new Vector2F(1.0f, 0.0f), manifold.LocalNormal);
        }

        /// <summary>
        ///     Tests that local point should set and get correctly
        /// </summary>
        [Fact]
        public void LocalPoint_ShouldSetAndGetCorrectly()
        {
            Manifold manifold = new Manifold
            {
                LocalPoint = new Vector2F(2.0f, 3.0f)
            };

            Assert.Equal(new Vector2F(2.0f, 3.0f), manifold.LocalPoint);
        }

        /// <summary>
        ///     Tests that point count should set and get correctly
        /// </summary>
        [Fact]
        public void PointCount_ShouldSetAndGetCorrectly()
        {
            Manifold manifold = new Manifold
            {
                PointCount = 2
            };

            Assert.Equal(2, manifold.PointCount);
        }

        /// <summary>
        ///     Tests that type should set and get correctly
        /// </summary>
        [Fact]
        public void Type_ShouldSetAndGetCorrectly()
        {
            Manifold manifold = new Manifold
            {
                Type = ManifoldType.FaceA
            };

            Assert.Equal(ManifoldType.FaceA, manifold.Type);
        }

        /// <summary>
        ///     Tests that all properties should set correctly
        /// </summary>
        [Fact]
        public void AllProperties_ShouldSetCorrectly()
        {
            Manifold manifold = new Manifold
            {
                LocalNormal = new Vector2F(1.0f, 0.0f),
                LocalPoint = new Vector2F(2.0f, 3.0f),
                PointCount = 2,
                Type = ManifoldType.FaceB
            };

            Assert.Equal(new Vector2F(1.0f, 0.0f), manifold.LocalNormal);
            Assert.Equal(new Vector2F(2.0f, 3.0f), manifold.LocalPoint);
            Assert.Equal(2, manifold.PointCount);
            Assert.Equal(ManifoldType.FaceB, manifold.Type);
        }

        /// <summary>
        ///     Tests that point count with max value should work
        /// </summary>
        [Fact]
        public void PointCount_WithMaxValue_ShouldWork()
        {
            Manifold manifold = new Manifold
            {
                PointCount = SettingEnv.MaxManifoldPoints
            };

            Assert.Equal(SettingEnv.MaxManifoldPoints, manifold.PointCount);
        }
    }
}