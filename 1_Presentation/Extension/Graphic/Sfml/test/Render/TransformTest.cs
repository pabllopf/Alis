using Xunit;
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// Unit tests for the Transform struct.
    /// </summary>
    public class TransformTest
    {
        /// <summary>
        /// Tests the constructor and field assignment.
        /// </summary>
        [Fact]
        public void Constructor_AssignsFields()
        {
            Transform t = new Transform(1,2,3,4,5,6,7,8,9);
            Assert.Equal(1, t.m00);
            Assert.Equal(2, t.m01);
            Assert.Equal(3, t.m02);
            Assert.Equal(4, t.m10);
            Assert.Equal(5, t.m11);
            Assert.Equal(6, t.m12);
            Assert.Equal(7, t.m20);
            Assert.Equal(8, t.m21);
            Assert.Equal(9, t.m22);
        }

        /// <summary>
        /// Tests GetInverse returns a Transform.
        /// </summary>
        [Fact]
        public void GetInverse_ReturnsTransform()
        {
            Transform t = new Transform(1,0,0,0,1,0,0,0,1);
            Transform inv = t.GetInverse();
            Assert.IsType<Transform>(inv);
        }

        /// <summary>
        /// Tests TransformPoint with coordinates and Vector2F.
        /// </summary>
        [Fact]
        public void TransformPoint_Works()
        {
            Transform t = new Transform(1,0,0,0,1,0,0,0,1);
            Vector2F v = t.TransformPoint(2,3);
            Assert.Equal(2, v.X);
            Assert.Equal(3, v.Y);
        }
    }
}

