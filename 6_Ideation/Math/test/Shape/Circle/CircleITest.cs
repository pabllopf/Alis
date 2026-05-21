

using Alis.Core.Aspect.Math.Shapes.Circle;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Shape.Circle
{
    /// <summary>
    ///     The circle test class
    /// </summary>
    public class CircleITest
    {
        /// <summary>
        ///     Tests that constructor initializes properties correctly
        /// </summary>
        [Fact]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            CircleI circle = new CircleI {X = 1, Y = 2, R = 3};

            Assert.Equal(1, circle.X);
            Assert.Equal(2, circle.Y);
            Assert.Equal(3, circle.R);
        }

        /// <summary>
        ///     Tests that properties set values correctly
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="r">The </param>
        [Theory, InlineData(0, 0, 0), InlineData(-1, -1, 1), InlineData(int.MaxValue, int.MaxValue, int.MaxValue)]
        public void Properties_SetValuesCorrectly(int x, int y, int r)
        {
            CircleI circle = new CircleI {X = x, Y = y, R = r};

            Assert.Equal(x, circle.X);
            Assert.Equal(y, circle.Y);
            Assert.Equal(r, circle.R);
        }
    }
}