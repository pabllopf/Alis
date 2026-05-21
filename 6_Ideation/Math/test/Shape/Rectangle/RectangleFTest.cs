

using Alis.Core.Aspect.Math.Shapes.Rectangle;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Shape.Rectangle
{
    /// <summary>
    ///     The rectangle test class
    /// </summary>
    public class RectangleFTest
    {
        /// <summary>
        ///     Tests the rectangle f constructor
        /// </summary>
        [Fact]
        public void TestRectangleF_Constructor()
        {
            float x = 1.0f;
            float y = 2.0f;
            float w = 3.0f;
            float h = 4.0f;

            RectangleF rectangle = new RectangleF(x, y, w, h);

            Assert.Equal(x, rectangle.X);
            Assert.Equal(y, rectangle.Y);
            Assert.Equal(w, rectangle.W);
            Assert.Equal(h, rectangle.H);
        }

        /// <summary>
        ///     Tests that test rectangle f constructor v 2
        /// </summary>
        [Fact]
        public void TestRectangleF_Constructor_V2()
        {
            float x = 1.0f;
            float y = 2.0f;
            float w = 3.0f;
            float h = 4.0f;

            RectangleF rectangle = new RectangleF(x, y, w, h);

            Assert.Equal(x, rectangle.X);
            Assert.Equal(y, rectangle.Y);
            Assert.Equal(w, rectangle.W);
            Assert.Equal(h, rectangle.H);
        }

        /// <summary>
        ///     Tests the Contains method of the rectangle
        /// </summary>
        [Fact]
        public void Contains_ReturnsTrueOnBoundaryAndFalseOutside()
        {
            RectangleF rectangle = new RectangleF(10f, 20f, 5f, 5f);

            Assert.True(rectangle.Contains(new Vector2F(10f, 20f)));
            Assert.True(rectangle.Contains(new Vector2F(15f, 25f)));
            Assert.False(rectangle.Contains(new Vector2F(15.1f, 25f)));
            Assert.False(rectangle.Contains(new Vector2F(9.9f, 20f)));
        }
    }
}