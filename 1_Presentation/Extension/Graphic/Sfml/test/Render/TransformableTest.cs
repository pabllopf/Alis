// license header
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
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
        [RequireCSfmlWindowsFact]
        public void DefaultConstructor_SetsDefaults()
        {
            Transformable t = new Transformable();
            Assert.Equal(0f, t.Position.X, 5);
            Assert.Equal(0f, t.Position.Y, 5);
            Assert.Equal(0f, t.Rotation, 5);
            Assert.Equal(1f, t.Scale.X, 5);
            Assert.Equal(1f, t.Scale.Y, 5);
            Assert.Equal(0f, t.Origin.X, 5);
            Assert.Equal(0f, t.Origin.Y, 5);
        }

        
        /// <summary>
        /// Tests that position setter updates value
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Position_Setter_UpdatesValue()
        {
            Transformable t = new Transformable();
            t.Position = new Vector2F(10, 20);
            Assert.Equal(10f, t.Position.X, 5);
            Assert.Equal(20f, t.Position.Y, 5);
        }

        /// <summary>
        /// Tests that position setter invalidates transform
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Position_Setter_InvalidatesTransform()
        {
            Transformable t = new Transformable();
            t.Position = new Vector2F(10, 20);
            Transform transform = t.Transform;
            Assert.NotNull(transform);
        }

        /// <summary>
        /// Tests that rotation setter updates value
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Rotation_Setter_UpdatesValue()
        {
            Transformable t = new Transformable();
            t.Rotation = 45f;
            Assert.Equal(45f, t.Rotation, 5);
        }

        /// <summary>
        /// Tests that rotation setter invalidates transform
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Rotation_Setter_InvalidatesTransform()
        {
            Transformable t = new Transformable();
            t.Rotation = 90f;
            Transform transform = t.Transform;
            Assert.NotNull(transform);
        }

        /// <summary>
        /// Tests that scale setter updates value
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Scale_Setter_UpdatesValue()
        {
            Transformable t = new Transformable();
            t.Scale = new Vector2F(2, 3);
            Assert.Equal(2f, t.Scale.X, 5);
            Assert.Equal(3f, t.Scale.Y, 5);
        }

        /// <summary>
        /// Tests that scale setter invalidates transform
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Scale_Setter_InvalidatesTransform()
        {
            Transformable t = new Transformable();
            t.Scale = new Vector2F(2, 2);
            Transform transform = t.Transform;
            Assert.NotNull(transform);
        }

        /// <summary>
        /// Tests that origin setter updates value
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Origin_Setter_UpdatesValue()
        {
            Transformable t = new Transformable();
            t.Origin = new Vector2F(5, 10);
            Assert.Equal(5f, t.Origin.X, 5);
            Assert.Equal(10f, t.Origin.Y, 5);
        }
        
        /// <summary>
        /// Tests that transform changes after origin change
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Transform_Changes_AfterOriginChange()
        {
            Transformable t = new Transformable();
            Transform transform1 = t.Transform;
            t.Origin = new Vector2F(50, 50);
            Transform transform2 = t.Transform;
            Assert.NotEqual(transform1, transform2);
        }

        /// <summary>
        /// Tests that inverse transform returns non null
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void InverseTransform_ReturnsNonNull()
        {
            Transformable t = new Transformable();
            Transform inverse = t.InverseTransform;
            Assert.NotNull(inverse);
        }

        /// <summary>
        /// Tests that inverse transform caches result
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void InverseTransform_CachesResult()
        {
            Transformable t = new Transformable();
            Transform inv1 = t.InverseTransform;
            Transform inv2 = t.InverseTransform;
            Assert.Equal(inv1, inv2);
        }

        /// <summary>
        /// Tests that inverse transform invalidated by position change
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void InverseTransform_Invalidated_ByPositionChange()
        {
            Transformable t = new Transformable();
            Transform inv1 = t.InverseTransform;
            t.Position = new Vector2F(100, 200);
            Transform inv2 = t.InverseTransform;
            Assert.NotEqual(inv1, inv2);
        }

        /// <summary>
        /// Tests that inverse transform invalidated by rotation change
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void InverseTransform_Invalidated_ByRotationChange()
        {
            Transformable t = new Transformable();
            Transform inv1 = t.InverseTransform;
            t.Rotation = 90f;
            Transform inv2 = t.InverseTransform;
            Assert.NotEqual(inv1, inv2);
        }

        /// <summary>
        /// Tests that inverse transform invalidated by scale change
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void InverseTransform_Invalidated_ByScaleChange()
        {
            Transformable t = new Transformable();
            Transform inv1 = t.InverseTransform;
            t.Scale = new Vector2F(0.5f, 0.5f);
            Transform inv2 = t.InverseTransform;
            Assert.NotEqual(inv1, inv2);
        }

        /// <summary>
        /// Tests that inverse transform invalidated by origin change
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void InverseTransform_Invalidated_ByOriginChange()
        {
            Transformable t = new Transformable();
            Transform inv1 = t.InverseTransform;
            t.Origin = new Vector2F(25, 25);
            Transform inv2 = t.InverseTransform;
            Assert.NotEqual(inv1, inv2);
        }

        /// <summary>
        /// Tests that transform with position translates correctly
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Transform_WithPosition_TranslatesCorrectly()
        {
            Transformable t = new Transformable();
            t.Position = new Vector2F(100, 200);
            Transform transform = t.Transform;
            Vector2F point = transform.TransformPoint(new Vector2F(0, 0));
            Assert.Equal(100f, point.X, 5);
            Assert.Equal(200f, point.Y, 5);
        }

        /// <summary>
        /// Tests that transform with scale scales correctly
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Transform_WithScale_ScalesCorrectly()
        {
            Transformable t = new Transformable();
            t.Scale = new Vector2F(2, 3);
            t.Position = new Vector2F(0, 0);
            Transform transform = t.Transform;
            Vector2F point = transform.TransformPoint(new Vector2F(10, 10));
            Assert.Equal(20f, point.X, 5);
            Assert.Equal(30f, point.Y, 5);
        }

        /// <summary>
        /// Tests that copy constructor copies properties
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void CopyConstructor_CopiesProperties()
        {
            Transformable original = new Transformable();
            original.Position = new Vector2F(1, 2);
            original.Rotation = 45f;
            original.Scale = new Vector2F(3, 4);
            original.Origin = new Vector2F(5, 6);

            Transformable copy = new Transformable(original);
            Assert.Equal(original.Position, copy.Position);
            Assert.Equal(original.Rotation, copy.Rotation);
            Assert.Equal(original.Scale, copy.Scale);
            Assert.Equal(original.Origin, copy.Origin);
        }

        /// <summary>
        /// Tests that destroy does not throw
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Destroy_DoesNotThrow()
        {
            Transformable t = new Transformable();
            t.Destroy(true);
            t.Destroy(false);
        }
    }
}
