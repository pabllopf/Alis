using Alis.Core.Aspect.Math.Shapes;
using Alis.Core.Aspect.Math.Shapes.Circle;
using Alis.Core.Aspect.Math.Shapes.Line;
using Alis.Core.Aspect.Math.Shapes.Point;
using Alis.Core.Aspect.Math.Shapes.Rectangle;
using Alis.Core.Aspect.Math.Shapes.Square;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Shape
{
    /// <summary>
    /// The shape implementation test class
    /// </summary>
    public class IShapeImplementationTest
    {
        /// <summary>
        /// Tests that all shape structs are assignable to i shape
        /// </summary>
        [Fact]
        public void AllShapeStructs_AreAssignableToIShape()
        {
            IShape[] shapes =
            {
                new CircleF(),
                new CircleI(),
                new LineF(),
                new LineI(),
                new PointF(),
                new PointI(),
                new RectangleF(),
                new RectangleI(),
                new SquareF(),
                new SquareI()
            };

            Assert.Equal(10, shapes.Length);
            foreach (IShape shape in shapes)
            {
                Assert.NotNull(shape);
            }
        }
    }
}

