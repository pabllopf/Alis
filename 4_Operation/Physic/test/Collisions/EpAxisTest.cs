

using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The ep axis test class
    /// </summary>
    public class EpAxisTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with default values
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithDefaultValues()
        {
            EpAxis axis = new EpAxis();

            Assert.Equal(0, axis.Index);
            Assert.Equal(0.0f, axis.Separation);
            Assert.Equal(EpAxisType.Unknown, axis.Type);
        }

        /// <summary>
        ///     Tests that index should set and get correctly
        /// </summary>
        [Fact]
        public void Index_ShouldSetAndGetCorrectly()
        {
            EpAxis axis = new EpAxis
            {
                Index = 5
            };

            Assert.Equal(5, axis.Index);
        }

        /// <summary>
        ///     Tests that separation should set and get correctly
        /// </summary>
        [Fact]
        public void Separation_ShouldSetAndGetCorrectly()
        {
            EpAxis axis = new EpAxis
            {
                Separation = 3.5f
            };

            Assert.Equal(3.5f, axis.Separation);
        }

        /// <summary>
        ///     Tests that type should set and get correctly
        /// </summary>
        [Fact]
        public void Type_ShouldSetAndGetCorrectly()
        {
            EpAxis axis = new EpAxis
            {
                Type = EpAxisType.EdgeA
            };

            Assert.Equal(EpAxisType.EdgeA, axis.Type);
        }

        /// <summary>
        ///     Tests that all properties should set correctly
        /// </summary>
        [Fact]
        public void AllProperties_ShouldSetCorrectly()
        {
            EpAxis axis = new EpAxis
            {
                Index = 10,
                Separation = 2.5f,
                Type = EpAxisType.EdgeB
            };

            Assert.Equal(10, axis.Index);
            Assert.Equal(2.5f, axis.Separation);
            Assert.Equal(EpAxisType.EdgeB, axis.Type);
        }

        /// <summary>
        ///     Tests that separation with negative value should work
        /// </summary>
        [Fact]
        public void Separation_WithNegativeValue_ShouldWork()
        {
            EpAxis axis = new EpAxis
            {
                Separation = -1.5f
            };

            Assert.Equal(-1.5f, axis.Separation);
        }

        /// <summary>
        ///     Tests that index with negative value should work
        /// </summary>
        [Fact]
        public void Index_WithNegativeValue_ShouldWork()
        {
            EpAxis axis = new EpAxis
            {
                Index = -1
            };

            Assert.Equal(-1, axis.Index);
        }
    }
}