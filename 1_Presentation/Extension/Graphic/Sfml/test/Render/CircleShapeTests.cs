using Xunit;
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The circle shape tests class
    /// </summary>
    public class CircleShapeTests
    {
        /// <summary>
        /// Tests that default constructor sets radius to zero
        /// </summary>
        [Fact]
        public void DefaultConstructor_SetsRadiusToZero()
        {
            var shape = new CircleShape();
            Assert.Equal(0, shape.Radius);
        }

        /// <summary>
        /// Tests that constructor with radius sets radius
        /// </summary>
        [Fact]
        public void Constructor_WithRadius_SetsRadius()
        {
            var shape = new CircleShape(5.5f);
            Assert.Equal(5.5f, shape.Radius);
        }

        /// <summary>
        /// Tests that constructor with radius and point count sets values
        /// </summary>
        [Fact]
        public void Constructor_WithRadiusAndPointCount_SetsValues()
        {
            var shape = new CircleShape(3.3f, 7);
            Assert.Equal(3.3f, shape.Radius);
            Assert.Equal((uint)7, shape.GetPointCount());
        }

        /// <summary>
        /// Tests that set point count changes point count
        /// </summary>
        [Fact]
        public void SetPointCount_ChangesPointCount()
        {
            var shape = new CircleShape(2.2f, 3);
            shape.SetPointCount(10);
            Assert.Equal((uint)10, shape.GetPointCount());
        }

        /// <summary>
        /// Tests that get point returns expected position
        /// </summary>
        [Fact]
        public void GetPoint_ReturnsExpectedPosition()
        {
            var shape = new CircleShape(10, 4);
            var point = shape.GetPoint(0);
            Assert.True(point.X > 0);
            Assert.True(point.Y >= 0);
        }

        /// <summary>
        /// Tests that copy constructor copies radius and point count
        /// </summary>
        [Fact]
        public void CopyConstructor_CopiesRadiusAndPointCount()
        {
            var shape1 = new CircleShape(7.7f, 8);
            var shape2 = new CircleShape(shape1);
            Assert.Equal(shape1.Radius, shape2.Radius);
            Assert.Equal(shape1.GetPointCount(), shape2.GetPointCount());
        }
    }
}

