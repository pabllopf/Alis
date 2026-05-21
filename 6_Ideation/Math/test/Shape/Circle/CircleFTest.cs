

using Alis.Core.Aspect.Math.Shapes.Circle;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Shape.Circle
{
    /// <summary>
    ///     The circle test class
    /// </summary>
    public class CircleFTest
    {
        /// <summary>
        ///     Tests that constructor initializes properties correctly
        /// </summary>
        [Fact]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            CircleF circle = new CircleF {X = 1.0f, Y = 2.0f, R = 3.0f};

            Assert.Equal(1.0f, circle.X);
            Assert.Equal(2.0f, circle.Y);
            Assert.Equal(3.0f, circle.R);
        }

        /// <summary>
        ///     Tests that properties set values correctly
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="r">The </param>
        [Theory, InlineData(0f, 0f, 0f), InlineData(-1f, -1f, 1f), InlineData(float.MaxValue, float.MaxValue, float.MaxValue)]
        public void Properties_SetValuesCorrectly(float x, float y, float r)
        {
            CircleF circle = new CircleF {X = x, Y = y, R = r};

            Assert.Equal(x, circle.X);
            Assert.Equal(y, circle.Y);
            Assert.Equal(r, circle.R);
        }
    }
}