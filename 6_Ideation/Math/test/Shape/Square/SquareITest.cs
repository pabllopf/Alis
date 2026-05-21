

using Alis.Core.Aspect.Math.Shapes.Square;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Shape.Square
{
    /// <summary>
    ///     The square test class
    /// </summary>
    public class SquareITest
    {
        /// <summary>
        ///     Tests that constructor initializes properties correctly
        /// </summary>
        [Fact]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            SquareI square = new SquareI {X = 1, Y = 2, W = 3};

            Assert.Equal(1, square.X);
            Assert.Equal(2, square.Y);
            Assert.Equal(3, square.W);
        }

        /// <summary>
        ///     Tests that properties set values correctly
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="w">The </param>
        [Theory, InlineData(0, 0, 0), InlineData(-1, -1, -1), InlineData(int.MaxValue, int.MaxValue, int.MaxValue)]
        public void Properties_SetValuesCorrectly(int x, int y, int w)
        {
            SquareI square = new SquareI {X = x, Y = y, W = w};

            Assert.Equal(x, square.X);
            Assert.Equal(y, square.Y);
            Assert.Equal(w, square.W);
        }
    }
}