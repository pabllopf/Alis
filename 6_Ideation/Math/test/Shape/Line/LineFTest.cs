

using Alis.Core.Aspect.Math.Shapes.Line;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Shape.Line
{
    /// <summary>
    ///     The line test class
    /// </summary>
    public class LineFTest
    {
        /// <summary>
        ///     Tests that constructor initializes properties correctly
        /// </summary>
        [Fact]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            LineF line = new LineF {X1 = 1.0f, Y1 = 2.0f, X2 = 3.0f, Y2 = 4.0f};

            Assert.Equal(1.0f, line.X1);
            Assert.Equal(2.0f, line.Y1);
            Assert.Equal(3.0f, line.X2);
            Assert.Equal(4.0f, line.Y2);
        }

        /// <summary>
        ///     Tests that properties set values correctly
        /// </summary>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        [Theory, InlineData(0f, 0f, 0f, 0f), InlineData(-1f, -2f, -3f, -4f), InlineData(float.MaxValue, float.MaxValue, float.MinValue, float.MinValue)]
        public void Properties_SetValuesCorrectly(float x1, float y1, float x2, float y2)
        {
            LineF line = new LineF {X1 = x1, Y1 = y1, X2 = x2, Y2 = y2};

            Assert.Equal(x1, line.X1);
            Assert.Equal(y1, line.Y1);
            Assert.Equal(x2, line.X2);
            Assert.Equal(y2, line.Y2);
        }
    }
}