using Alis.Core.Aspect.Math.Vector;
using Xunit;
using Alis.Extension.Graphic.Sfml.Render;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// Unit tests for the Vec2 struct.
    /// </summary>
    public class Vec2Test
    {
        /// <summary>
        /// Tests the constructor and field assignment.
        /// </summary>
        [Fact]
        public void Constructor_AssignsFields()
        {
            Vec2 v = new Vec2(1.5f, 2.5f);
            Assert.Equal(1.5f, v.X);
            Assert.Equal(2.5f, v.Y);
        }

        /// <summary>
        /// Tests the implicit cast from Vector2F.
        /// </summary>
        [Fact]
        public void ImplicitCast_FromVector2F_Works()
        {
            Vector2F vec2f = new Alis.Core.Aspect.Math.Vector.Vector2F(3.5f, 4.5f);
            Vec2 v = vec2f;
            Assert.Equal(3.5f, v.X);
            Assert.Equal(4.5f, v.Y);
        }
    }
}

