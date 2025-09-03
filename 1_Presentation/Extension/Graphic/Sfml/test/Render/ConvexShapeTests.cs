using Xunit;
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The convex shape tests class
    /// </summary>
    public class ConvexShapeTests
    {
        /// <summary>
        /// Tests that constructor sets point count
        /// </summary>
        [Fact]
        public void Constructor_SetsPointCount()
        {
            ConvexShape shape = new ConvexShape(3);
            Assert.Equal((uint)3, shape.GetPointCount());
        }

        /// <summary>
        /// Tests that set point count changes point count
        /// </summary>
        [Fact]
        public void SetPointCount_ChangesPointCount()
        {
            ConvexShape shape = new ConvexShape(2);
            shape.SetPointCount(5);
            Assert.Equal((uint)5, shape.GetPointCount());
        }

        /// <summary>
        /// Tests that set and get point works
        /// </summary>
        [Fact]
        public void SetAndGetPoint_Works()
        {
            ConvexShape shape = new ConvexShape(2);
            Vector2F p = new Vector2F(1, 2);
            shape.SetPoint(0, p);
            Assert.Equal(p, shape.GetPoint(0));
        }

        /// <summary>
        /// Tests that copy constructor copies points
        /// </summary>
        [Fact]
        public void CopyConstructor_CopiesPoints()
        {
            ConvexShape shape1 = new ConvexShape(2);
            shape1.SetPoint(0, new Vector2F(1, 2));
            shape1.SetPoint(1, new Vector2F(3, 4));
            ConvexShape shape2 = new ConvexShape(shape1);
            Assert.Equal(shape1.GetPointCount(), shape2.GetPointCount());
            Assert.Equal(shape1.GetPoint(0), shape2.GetPoint(0));
            Assert.Equal(shape1.GetPoint(1), shape2.GetPoint(1));
        }
    }
}

