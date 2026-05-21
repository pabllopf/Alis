

using Alis.Core.Aspect.Math.Shapes.Line;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Shape.Line
{
    /// <summary>
    ///     The line test class
    /// </summary>
    public class LineITest
    {
        /// <summary>
        ///     Tests that constructor initializes properties correctly
        /// </summary>
        [Fact]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            LineI line = new LineI {X1 = 1, Y1 = 2, X2 = 3, Y2 = 4};

            Assert.Equal(1, line.X1);
            Assert.Equal(2, line.Y1);
            Assert.Equal(3, line.X2);
            Assert.Equal(4, line.Y2);
        }

        /// <summary>
        ///     Tests that properties set values correctly
        /// </summary>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        [Theory, InlineData(0, 0, 0, 0), InlineData(-1, -2, -3, -4), InlineData(int.MaxValue, int.MaxValue, int.MinValue, int.MinValue)]
        public void Properties_SetValuesCorrectly(int x1, int y1, int x2, int y2)
        {
            LineI line = new LineI {X1 = x1, Y1 = y1, X2 = x2, Y2 = y2};

            Assert.Equal(x1, line.X1);
            Assert.Equal(y1, line.Y1);
            Assert.Equal(x2, line.X2);
            Assert.Equal(y2, line.Y2);
        }
    }
}