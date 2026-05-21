

using Alis.Core.Physic.Common;
using Xunit;

namespace Alis.Core.Physic.Test.Common
{
    /// <summary>
    ///     The polygon error test class
    /// </summary>
    public class PolygonErrorTest
    {
        /// <summary>
        ///     Tests that no error should have value zero
        /// </summary>
        [Fact]
        public void NoError_ShouldHaveValueZero()
        {
            Assert.Equal(0, (int) PolygonError.NoError);
        }

        /// <summary>
        ///     Tests that invalid amount of vertices should have value one
        /// </summary>
        [Fact]
        public void InvalidAmountOfVertices_ShouldHaveValueOne()
        {
            Assert.Equal(1, (int) PolygonError.InvalidAmountOfVertices);
        }

        /// <summary>
        ///     Tests that not simple should have value two
        /// </summary>
        [Fact]
        public void NotSimple_ShouldHaveValueTwo()
        {
            Assert.Equal(2, (int) PolygonError.NotSimple);
        }

        /// <summary>
        ///     Tests that not counter clock wise should have value three
        /// </summary>
        [Fact]
        public void NotCounterClockWise_ShouldHaveValueThree()
        {
            Assert.Equal(3, (int) PolygonError.NotCounterClockWise);
        }

        /// <summary>
        ///     Tests that not convex should have value four
        /// </summary>
        [Fact]
        public void NotConvex_ShouldHaveValueFour()
        {
            Assert.Equal(4, (int) PolygonError.NotConvex);
        }

        /// <summary>
        ///     Tests that area too small should have value five
        /// </summary>
        [Fact]
        public void AreaTooSmall_ShouldHaveValueFive()
        {
            Assert.Equal(5, (int) PolygonError.AreaTooSmall);
        }

        /// <summary>
        ///     Tests that side too small should have value six
        /// </summary>
        [Fact]
        public void SideTooSmall_ShouldHaveValueSix()
        {
            Assert.Equal(6, (int) PolygonError.SideTooSmall);
        }

        /// <summary>
        ///     Tests that all values should be unique
        /// </summary>
        [Fact]
        public void AllValues_ShouldBeUnique()
        {
            PolygonError[] values = new[]
            {
                PolygonError.NoError,
                PolygonError.InvalidAmountOfVertices,
                PolygonError.NotSimple,
                PolygonError.NotCounterClockWise,
                PolygonError.NotConvex,
                PolygonError.AreaTooSmall,
                PolygonError.SideTooSmall
            };

            for (int i = 0; i < values.Length; i++)
            {
                for (int j = i + 1; j < values.Length; j++)
                {
                    Assert.NotEqual(values[i], values[j]);
                }
            }
        }

        /// <summary>
        ///     Tests that values should be sequential
        /// </summary>
        [Fact]
        public void Values_ShouldBeSequential()
        {
            Assert.Equal(0, (int) PolygonError.NoError);
            Assert.Equal(1, (int) PolygonError.InvalidAmountOfVertices);
            Assert.Equal(2, (int) PolygonError.NotSimple);
            Assert.Equal(3, (int) PolygonError.NotCounterClockWise);
            Assert.Equal(4, (int) PolygonError.NotConvex);
            Assert.Equal(5, (int) PolygonError.AreaTooSmall);
            Assert.Equal(6, (int) PolygonError.SideTooSmall);
        }
    }
}