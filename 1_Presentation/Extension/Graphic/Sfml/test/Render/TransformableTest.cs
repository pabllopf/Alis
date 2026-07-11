// license header
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Render;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The transformable test class
    /// </summary>
    public class TransformableTest
    {
        /// <summary>
        /// Tests that default constructor sets defaults
        /// </summary>
        [Fact]
        public void DefaultConstructor_SetsDefaults()
        {
            var t = new Transformable();
            Assert.Equal(0f, t.Position.X);
            Assert.Equal(0f, t.Position.Y);
            Assert.Equal(0f, t.Rotation);
            Assert.Equal(1f, t.Scale.X);
            Assert.Equal(1f, t.Scale.Y);
            Assert.Equal(0f, t.Origin.X);
            Assert.Equal(0f, t.Origin.Y);
        }

        /// <summary>
        /// Tests that position setter updates value
        /// </summary>
        [Fact]
        public void Position_Setter_UpdatesValue()
        {
            var t = new Transformable();
            t.Position = new Vector2F(10, 20);
            Assert.Equal(10f, t.Position.X);
            Assert.Equal(20f, t.Position.Y);
        }

        /// <summary>
        /// Tests that position setter invalidates transform
        /// </summary>
        [Fact]
        public void Position_Setter_InvalidatesTransform()
        {
            var t = new Transformable();
            t.Position = new Vector2F(10, 20);
            var transform = t.Transform;
            Assert.NotNull(transform);
        }

        /// <summary>
        /// Tests that rotation setter updates value
        /// </summary>
        [Fact]
        public void Rotation_Setter_UpdatesValue()
        {
            var t = new Transformable();
            t.Rotation = 45f;
            Assert.Equal(45f, t.Rotation);
        }

        /// <summary>
        /// Tests that rotation setter invalidates transform
        /// </summary>
        [Fact]
        public void Rotation_Setter_InvalidatesTransform()
        {
            var t = new Transformable();
            t.Rotation = 90f;
            var transform = t.Transform;
            Assert.NotNull(transform);
        }

        /// <summary>
        /// Tests that scale setter updates value
        /// </summary>
        [Fact]
        public void Scale_Setter_UpdatesValue()
        {
            var t = new Transformable();
            t.Scale = new Vector2F(2, 3);
            Assert.Equal(2f, t.Scale.X);
            Assert.Equal(3f, t.Scale.Y);
        }

        /// <summary>
        /// Tests that scale setter invalidates transform
        /// </summary>
        [Fact]
        public void Scale_Setter_InvalidatesTransform()
        {
            var t = new Transformable();
            t.Scale = new Vector2F(2, 2);
            var transform = t.Transform;
            Assert.NotNull(transform);
        }

        /// <summary>
        /// Tests that origin setter updates value
        /// </summary>
        [Fact]
        public void Origin_Setter_UpdatesValue()
        {
            var t = new Transformable();
            t.Origin = new Vector2F(5, 10);
            Assert.Equal(5f, t.Origin.X);
            Assert.Equal(10f, t.Origin.Y);
        }
        
        /// <summary>
        /// Tests that transform changes after origin change
        /// </summary>
        [Fact]
        public void Transform_Changes_AfterOriginChange()
        {
            var t = new Transformable();
            var transform1 = t.Transform;
            t.Origin = new Vector2F(50, 50);
            var transform2 = t.Transform;
            Assert.NotEqual(transform1, transform2);
        }

        /// <summary>
        /// Tests that inverse transform returns non null
        /// </summary>
        [Fact]
        public void InverseTransform_ReturnsNonNull()
        {
            var t = new Transformable();
            var inverse = t.InverseTransform;
            Assert.NotNull(inverse);
        }

        /// <summary>
        /// Tests that inverse transform caches result
        /// </summary>
        [Fact]
        public void InverseTransform_CachesResult()
        {
            var t = new Transformable();
            var inv1 = t.InverseTransform;
            var inv2 = t.InverseTransform;
            Assert.Equal(inv1, inv2);
        }

        /// <summary>
        /// Tests that inverse transform invalidated by position change
        /// </summary>
        [Fact]
        public void InverseTransform_Invalidated_ByPositionChange()
        {
            var t = new Transformable();
            var inv1 = t.InverseTransform;
            t.Position = new Vector2F(100, 200);
            var inv2 = t.InverseTransform;
            Assert.NotEqual(inv1, inv2);
        }

        /// <summary>
        /// Tests that inverse transform invalidated by rotation change
        /// </summary>
        [Fact]
        public void InverseTransform_Invalidated_ByRotationChange()
        {
            var t = new Transformable();
            var inv1 = t.InverseTransform;
            t.Rotation = 90f;
            var inv2 = t.InverseTransform;
            Assert.NotEqual(inv1, inv2);
        }

        /// <summary>
        /// Tests that inverse transform invalidated by scale change
        /// </summary>
        [Fact]
        public void InverseTransform_Invalidated_ByScaleChange()
        {
            var t = new Transformable();
            var inv1 = t.InverseTransform;
            t.Scale = new Vector2F(0.5f, 0.5f);
            var inv2 = t.InverseTransform;
            Assert.NotEqual(inv1, inv2);
        }

        /// <summary>
        /// Tests that inverse transform invalidated by origin change
        /// </summary>
        [Fact]
        public void InverseTransform_Invalidated_ByOriginChange()
        {
            var t = new Transformable();
            var inv1 = t.InverseTransform;
            t.Origin = new Vector2F(25, 25);
            var inv2 = t.InverseTransform;
            Assert.NotEqual(inv1, inv2);
        }

        /// <summary>
        /// Tests that transform with position translates correctly
        /// </summary>
        [Fact]
        public void Transform_WithPosition_TranslatesCorrectly()
        {
            var t = new Transformable();
            t.Position = new Vector2F(100, 200);
            var transform = t.Transform;
            var point = transform.TransformPoint(new Vector2F(0, 0));
            Assert.Equal(100f, point.X);
            Assert.Equal(200f, point.Y);
        }

        /// <summary>
        /// Tests that transform with scale scales correctly
        /// </summary>
        [Fact]
        public void Transform_WithScale_ScalesCorrectly()
        {
            var t = new Transformable();
            t.Scale = new Vector2F(2, 3);
            t.Position = new Vector2F(0, 0);
            var transform = t.Transform;
            var point = transform.TransformPoint(new Vector2F(10, 10));
            Assert.Equal(20f, point.X);
            Assert.Equal(30f, point.Y);
        }

        /// <summary>
        /// Tests that copy constructor copies properties
        /// </summary>
        [Fact]
        public void CopyConstructor_CopiesProperties()
        {
            var original = new Transformable();
            original.Position = new Vector2F(1, 2);
            original.Rotation = 45f;
            original.Scale = new Vector2F(3, 4);
            original.Origin = new Vector2F(5, 6);

            var copy = new Transformable(original);
            Assert.Equal(original.Position, copy.Position);
            Assert.Equal(original.Rotation, copy.Rotation);
            Assert.Equal(original.Scale, copy.Scale);
            Assert.Equal(original.Origin, copy.Origin);
        }

        /// <summary>
        /// Tests that destroy does not throw
        /// </summary>
        [Fact]
        public void Destroy_DoesNotThrow()
        {
            var t = new Transformable();
            t.Destroy(true);
            t.Destroy(false);
        }
    }
}
