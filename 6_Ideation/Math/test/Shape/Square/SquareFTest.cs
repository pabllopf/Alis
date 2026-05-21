

using Alis.Core.Aspect.Math.Shapes.Square;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Shape.Square
{
    /// <summary>
    ///     The square test class
    /// </summary>
    public class SquareFTest
    {
        /// <summary>
        ///     Tests that constructor initializes properties correctly
        /// </summary>
        [Fact]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            SquareF square = new SquareF {X = 1.0f, Y = 2.0f, W = 3.0f};

            Assert.Equal(1.0f, square.X);
            Assert.Equal(2.0f, square.Y);
            Assert.Equal(3.0f, square.W);
        }

        /// <summary>
        ///     Tests that properties set values correctly
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="w">The </param>
        [Theory, InlineData(0f, 0f, 0f), InlineData(-1f, -1f, -1f), InlineData(float.MaxValue, float.MaxValue, float.MaxValue)]
        public void Properties_SetValuesCorrectly(float x, float y, float w)
        {
            SquareF square = new SquareF {X = x, Y = y, W = w};

            Assert.Equal(x, square.X);
            Assert.Equal(y, square.Y);
            Assert.Equal(w, square.W);
        }
    }
}