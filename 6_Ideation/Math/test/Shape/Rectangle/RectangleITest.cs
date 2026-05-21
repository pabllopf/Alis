

using System.Runtime.Serialization;
using Alis.Core.Aspect.Math.Shapes.Rectangle;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Shape.Rectangle
{
    /// <summary>
    ///     The rectangle test class
    /// </summary>
    public class RectangleITest
    {
        /// <summary>
        ///     Tests that test rectangle i constructor
        /// </summary>
        [Fact]
        public void TestRectangleI_Constructor()
        {
            int x = 1;
            int y = 2;
            int w = 3;
            int h = 4;

            RectangleI rectangle = new RectangleI(x, y, w, h);

            Assert.Equal(x, rectangle.X);
            Assert.Equal(y, rectangle.Y);
            Assert.Equal(w, rectangle.W);
            Assert.Equal(h, rectangle.H);
        }

        /// <summary>
        ///     Tests that GetObjectData writes all fields
        /// </summary>
        [Fact]
        public void GetObjectData_WritesAllFields()
        {
            RectangleI rectangle = new RectangleI(1, 2, 3, 4);
            SerializationInfo info = new SerializationInfo(typeof(RectangleI), new FormatterConverter());

            rectangle.GetObjectData(info, default(StreamingContext));

            Assert.Equal(1, info.GetInt32("x"));
            Assert.Equal(2, info.GetInt32("y"));
            Assert.Equal(3, info.GetInt32("w"));
            Assert.Equal(4, info.GetInt32("h"));
        }
    }
}