// license header
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Render;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    public class TransformableTest
    {
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

        [Fact]
        public void Position_Setter_UpdatesValue()
        {
            var t = new Transformable();
            t.Position = new Vector2F(10, 20);
            Assert.Equal(10f, t.Position.X);
            Assert.Equal(20f, t.Position.Y);
        }

        [Fact]
        public void Position_Setter_InvalidatesTransform()
        {
            var t = new Transformable();
            t.Position = new Vector2F(10, 20);
            var transform = t.Transform;
            Assert.NotNull(transform);
        }

        [Fact]
        public void Rotation_Setter_UpdatesValue()
        {
            var t = new Transformable();
            t.Rotation = 45f;
            Assert.Equal(45f, t.Rotation);
        }

        [Fact]
        public void Rotation_Setter_InvalidatesTransform()
        {
            var t = new Transformable();
            t.Rotation = 90f;
            var transform = t.Transform;
            Assert.NotNull(transform);
        }

        [Fact]
        public void Scale_Setter_UpdatesValue()
        {
            var t = new Transformable();
            t.Scale = new Vector2F(2, 3);
            Assert.Equal(2f, t.Scale.X);
            Assert.Equal(3f, t.Scale.Y);
        }

        [Fact]
        public void Scale_Setter_InvalidatesTransform()
        {
            var t = new Transformable();
            t.Scale = new Vector2F(2, 2);
            var transform = t.Transform;
            Assert.NotNull(transform);
        }

        [Fact]
        public void Origin_Setter_UpdatesValue()
        {
            var t = new Transformable();
            t.Origin = new Vector2F(5, 10);
            Assert.Equal(5f, t.Origin.X);
            Assert.Equal(10f, t.Origin.Y);
        }

        [Fact]
        public void Transform_ReturnsSameInstance_WhenNotDirty()
        {
            var t = new Transformable();
            var transform1 = t.Transform;
            var transform2 = t.Transform;
            Assert.Equal(transform1, transform2);
        }

        [Fact]
        public void Transform_Changes_AfterPositionChange()
        {
            var t = new Transformable();
            var transform1 = t.Transform;
            t.Position = new Vector2F(100, 200);
            var transform2 = t.Transform;
            Assert.NotEqual(transform1, transform2);
        }

        [Fact]
        public void Transform_Changes_AfterRotationChange()
        {
            var t = new Transformable();
            var transform1 = t.Transform;
            t.Rotation = 45f;
            var transform2 = t.Transform;
            Assert.NotEqual(transform1, transform2);
        }

        [Fact]
        public void Transform_Changes_AfterScaleChange()
        {
            var t = new Transformable();
            var transform1 = t.Transform;
            t.Scale = new Vector2F(2, 2);
            var transform2 = t.Transform;
            Assert.NotEqual(transform1, transform2);
        }

        [Fact]
        public void Transform_Changes_AfterOriginChange()
        {
            var t = new Transformable();
            var transform1 = t.Transform;
            t.Origin = new Vector2F(50, 50);
            var transform2 = t.Transform;
            Assert.NotEqual(transform1, transform2);
        }

        [Fact]
        public void InverseTransform_ReturnsNonNull()
        {
            var t = new Transformable();
            var inverse = t.InverseTransform;
            Assert.NotNull(inverse);
        }

        [Fact]
        public void InverseTransform_CachesResult()
        {
            var t = new Transformable();
            var inv1 = t.InverseTransform;
            var inv2 = t.InverseTransform;
            Assert.Equal(inv1, inv2);
        }

        [Fact]
        public void InverseTransform_Invalidated_ByPositionChange()
        {
            var t = new Transformable();
            var inv1 = t.InverseTransform;
            t.Position = new Vector2F(100, 200);
            var inv2 = t.InverseTransform;
            Assert.NotEqual(inv1, inv2);
        }

        [Fact]
        public void InverseTransform_Invalidated_ByRotationChange()
        {
            var t = new Transformable();
            var inv1 = t.InverseTransform;
            t.Rotation = 90f;
            var inv2 = t.InverseTransform;
            Assert.NotEqual(inv1, inv2);
        }

        [Fact]
        public void InverseTransform_Invalidated_ByScaleChange()
        {
            var t = new Transformable();
            var inv1 = t.InverseTransform;
            t.Scale = new Vector2F(0.5f, 0.5f);
            var inv2 = t.InverseTransform;
            Assert.NotEqual(inv1, inv2);
        }

        [Fact]
        public void InverseTransform_Invalidated_ByOriginChange()
        {
            var t = new Transformable();
            var inv1 = t.InverseTransform;
            t.Origin = new Vector2F(25, 25);
            var inv2 = t.InverseTransform;
            Assert.NotEqual(inv1, inv2);
        }

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

        [Fact]
        public void Destroy_DoesNotThrow()
        {
            var t = new Transformable();
            t.Destroy(true);
            t.Destroy(false);
        }
    }
}
