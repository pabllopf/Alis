using Xunit;
using Alis.Extension.Graphic.Sfml.Render;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// Unit tests for the CircleShape class.
    /// </summary>
    public class CircleShapeTest
    {
        /// <summary>
        /// Tests default constructor and property assignment.
        /// </summary>
        [Fact]
        public void DefaultConstructor_Works()
        {
            var shape = new CircleShape();
            Assert.NotNull(shape);
        }

        /// <summary>
        /// Tests constructor with radius and point count.
        /// </summary>
        [Fact]
        public void Constructor_WithRadiusAndPointCount_Works()
        {
            var shape = new CircleShape(5.0f, 20);
            Assert.Equal(5.0f, shape.Radius);
            Assert.Equal(20u, shape.GetPointCount());
        }

        /// <summary>
        /// Tests copy constructor.
        /// </summary>
        [Fact]
        public void CopyConstructor_Works()
        {
            var original = new CircleShape(3.0f, 10);
            var copy = new CircleShape(original);
            Assert.Equal(original.Radius, copy.Radius);
            Assert.Equal(original.GetPointCount(), copy.GetPointCount());
        }
    }
}

