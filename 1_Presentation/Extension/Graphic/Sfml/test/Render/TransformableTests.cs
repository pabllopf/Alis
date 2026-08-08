// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TransformableTests.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The transformable tests class
    /// </summary>
    public class TransformableTests
    {
        /// <summary>
        /// Transforms the caches result
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Transform_CachesResult()
        {
            Transformable t = new Transformable();
            Transform first = t.Transform;
            Transform second = t.Transform;
            Assert.Equal(first, second);
        }

        /// <summary>
        /// Transforms the invalidated by position change
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Transform_Invalidated_ByPositionChange()
        {
            Transformable t = new Transformable();
            Transform before = t.Transform;
            t.Position = new Vector2F(50, 50);
            Transform after = t.Transform;
            Assert.NotEqual(before, after);
        }

        /// <summary>
        /// Transforms the invalidated by rotation change
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Transform_Invalidated_ByRotationChange()
        {
            Transformable t = new Transformable();
            Transform before = t.Transform;
            t.Rotation = 90f;
            Transform after = t.Transform;
            Assert.NotEqual(before, after);
        }

        /// <summary>
        /// Transforms the invalidated by scale change
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Transform_Invalidated_ByScaleChange()
        {
            Transformable t = new Transformable();
            Transform before = t.Transform;
            t.Scale = new Vector2F(2, 2);
            Transform after = t.Transform;
            Assert.NotEqual(before, after);
        }

        /// <summary>
        /// Transforms the invalidated by origin change
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Transform_Invalidated_ByOriginChange()
        {
            Transformable t = new Transformable();
            Transform before = t.Transform;
            t.Origin = new Vector2F(10, 10);
            Transform after = t.Transform;
            Assert.NotEqual(before, after);
        }

        /// <summary>
        /// Transforms the with rotation rotates correctly
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Transform_WithRotation_RotatesCorrectly()
        {
            Transformable t = new Transformable();
            t.Rotation = 90f;
            Transform transform = t.Transform;
            Vector2F point = transform.TransformPoint(new Vector2F(10, 0));
            Assert.Equal(0f, point.X, 4);
            Assert.Equal(10f, point.Y, 4);
        }

        /// <summary>
        /// Transforms the with origin offsets transformation
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Transform_WithOrigin_OffsetsTransformation()
        {
            Transformable t = new Transformable();
            t.Origin = new Vector2F(50, 50);
            t.Position = new Vector2F(100, 100);
            Transform transform = t.Transform;
            Vector2F point = transform.TransformPoint(new Vector2F(0, 0));
            Assert.Equal(50f, point.X, 5);
            Assert.Equal(50f, point.Y, 5);
        }

        /// <summary>
        /// Transforms the with position rotation scale origin combines correctly
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Transform_WithPositionRotationScaleOrigin_CombinesCorrectly()
        {
            Transformable t = new Transformable();
            t.Position = new Vector2F(100, 200);
            t.Rotation = 45f;
            t.Scale = new Vector2F(2, 2);
            t.Origin = new Vector2F(10, 10);
            Transform transform = t.Transform;
            Vector2F point = transform.TransformPoint(new Vector2F(0, 0));
            Assert.True(point.X != 0 || point.Y != 0);
        }

        /// <summary>
        /// Transforms the negative rotation rotates clockwise
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Transform_NegativeRotation_RotatesClockwise()
        {
            Transformable t = new Transformable();
            t.Rotation = -90f;
            Transform transform = t.Transform;
            Vector2F point = transform.TransformPoint(new Vector2F(10, 0));
            Assert.Equal(0f, point.X, 4);
            Assert.Equal(-10f, point.Y, 4);
        }

        /// <summary>
        /// Transforms the negative scale flips direction
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Transform_NegativeScale_FlipsDirection()
        {
            Transformable t = new Transformable();
            t.Scale = new Vector2F(-1, 1);
            Transform transform = t.Transform;
            Vector2F point = transform.TransformPoint(new Vector2F(10, 0));
            Assert.Equal(-10f, point.X, 5);
            Assert.Equal(0f, point.Y, 5);
        }

        /// <summary>
        /// Transforms the identity with no changes
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Transform_Identity_WithNoChanges()
        {
            Transformable t = new Transformable();
            Transform transform = t.Transform;
            Vector2F point = transform.TransformPoint(new Vector2F(5, 10));
            Assert.Equal(5f, point.X, 5);
            Assert.Equal(10f, point.Y, 5);
        }

        /// <summary>
        /// Positions the setter invalidates inverse transform
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Position_Setter_InvalidatesInverseTransform()
        {
            Transformable t = new Transformable();
            Transform inv1 = t.InverseTransform;
            t.Position = new Vector2F(100, 200);
            Transform inv2 = t.InverseTransform;
            Assert.NotEqual(inv1, inv2);
        }

        /// <summary>
        /// Rotations the setter invalidates inverse transform
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Rotation_Setter_InvalidatesInverseTransform()
        {
            Transformable t = new Transformable();
            Transform inv1 = t.InverseTransform;
            t.Rotation = 45f;
            Transform inv2 = t.InverseTransform;
            Assert.NotEqual(inv1, inv2);
        }

        /// <summary>
        /// Scales the setter invalidates inverse transform
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Scale_Setter_InvalidatesInverseTransform()
        {
            Transformable t = new Transformable();
            Transform inv1 = t.InverseTransform;
            t.Scale = new Vector2F(2, 2);
            Transform inv2 = t.InverseTransform;
            Assert.NotEqual(inv1, inv2);
        }

        /// <summary>
        /// Origins the setter invalidates inverse transform
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Origin_Setter_InvalidatesInverseTransform()
        {
            Transformable t = new Transformable();
            Transform inv1 = t.InverseTransform;
            t.Origin = new Vector2F(10, 10);
            Transform inv2 = t.InverseTransform;
            Assert.NotEqual(inv1, inv2);
        }

        /// <summary>
        /// Inverses the transform is actually inverse
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void InverseTransform_IsActuallyInverse()
        {
            Transformable t = new Transformable();
            t.Position = new Vector2F(100, 50);
            t.Rotation = 30f;
            t.Scale = new Vector2F(1.5f, 1.5f);
            Transform transform = t.Transform;
            Transform inverse = t.InverseTransform;
            Vector2F original = new Vector2F(20, 10);
            Vector2F transformed = transform.TransformPoint(original);
            Vector2F restored = inverse.TransformPoint(transformed);
            Assert.Equal(original.X, restored.X, 4);
            Assert.Equal(original.Y, restored.Y, 4);
        }

        /// <summary>
        /// Transforms the zero scale produces zero transform
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Transform_ZeroScale_ProducesZeroTransform()
        {
            Transformable t = new Transformable();
            t.Scale = new Vector2F(0, 0);
            Transform transform = t.Transform;
            Vector2F point = transform.TransformPoint(new Vector2F(100, 200));
            Assert.Equal(0f, point.X, 5);
            Assert.Equal(0f, point.Y, 5);
        }

        /// <summary>
        /// Transforms the multiple property changes caches after access
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Transform_MultiplePropertyChanges_CachesAfterAccess()
        {
            Transformable t = new Transformable();
            Transform first = t.Transform;
            t.Position = new Vector2F(1, 2);
            Transform second = t.Transform;
            Transform third = t.Transform;
            Assert.Equal(second, third);
        }

        /// <summary>
        /// Inverses the transform caches after initial access
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void InverseTransform_CachesAfterInitialAccess()
        {
            Transformable t = new Transformable();
            Transform inv1 = t.InverseTransform;
            Transform inv2 = t.InverseTransform;
            Assert.Equal(inv1, inv2);
        }

        /// <summary>
        /// Transformables the dispose sets c pointer to zero
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Transformable_Dispose_SetsCPointerToZero()
        {
            Transformable t = new Transformable();
            t.Dispose();
            Assert.Equal(IntPtr.Zero, t.CPointer);
        }

        /// <summary>
        /// Transformables the dispose multiple calls do not throw
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Transformable_Dispose_MultipleCalls_DoNotThrow()
        {
            Transformable t = new Transformable();
            t.Dispose();
            t.Dispose();
        }

        /// <summary>
        /// Positions the set multiple times reflects latest
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Position_SetMultipleTimes_ReflectsLatest()
        {
            Transformable t = new Transformable();
            t.Position = new Vector2F(10, 20);
            t.Position = new Vector2F(30, 40);
            Assert.Equal(30f, t.Position.X, 5);
            Assert.Equal(40f, t.Position.Y, 5);
        }

        /// <summary>
        /// Rotations the set multiple times reflects latest
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Rotation_SetMultipleTimes_ReflectsLatest()
        {
            Transformable t = new Transformable();
            t.Rotation = 45f;
            t.Rotation = 90f;
            Assert.Equal(90f, t.Rotation, 5);
        }

        /// <summary>
        /// Scales the set multiple times reflects latest
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Scale_SetMultipleTimes_ReflectsLatest()
        {
            Transformable t = new Transformable();
            t.Scale = new Vector2F(1, 1);
            t.Scale = new Vector2F(3, 4);
            Assert.Equal(3f, t.Scale.X, 5);
            Assert.Equal(4f, t.Scale.Y, 5);
        }

        /// <summary>
        /// Origins the set multiple times reflects latest
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Origin_SetMultipleTimes_ReflectsLatest()
        {
            Transformable t = new Transformable();
            t.Origin = new Vector2F(5, 5);
            t.Origin = new Vector2F(15, 25);
            Assert.Equal(15f, t.Origin.X, 5);
            Assert.Equal(25f, t.Origin.Y, 5);
        }

        /// <summary>
        /// Positions the default is zero
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Position_Default_IsZero()
        {
            Transformable t = new Transformable();
            Assert.Equal(0f, t.Position.X, 5);
            Assert.Equal(0f, t.Position.Y, 5);
        }

        /// <summary>
        /// Rotations the default is zero
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Rotation_Default_IsZero()
        {
            Transformable t = new Transformable();
            Assert.Equal(0f, t.Rotation, 5);
        }

        /// <summary>
        /// Scales the default is one
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Scale_Default_IsOne()
        {
            Transformable t = new Transformable();
            Assert.Equal(1f, t.Scale.X, 5);
            Assert.Equal(1f, t.Scale.Y, 5);
        }

        /// <summary>
        /// Origins the default is zero
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Origin_Default_IsZero()
        {
            Transformable t = new Transformable();
            Assert.Equal(0f, t.Origin.X, 5);
            Assert.Equal(0f, t.Origin.Y, 5);
        }

        /// <summary>
        /// Copies the constructor copies all properties
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void CopyConstructor_CopiesAllProperties()
        {
            Transformable original = new Transformable();
            original.Position = new Vector2F(10, 20);
            original.Rotation = 45f;
            original.Scale = new Vector2F(2, 3);
            original.Origin = new Vector2F(5, 6);
            Transformable copy = new Transformable(original);
            Assert.Equal(original.Position.X, copy.Position.X);
            Assert.Equal(original.Position.Y, copy.Position.Y);
            Assert.Equal(original.Rotation, copy.Rotation);
            Assert.Equal(original.Scale.X, copy.Scale.X);
            Assert.Equal(original.Scale.Y, copy.Scale.Y);
            Assert.Equal(original.Origin.X, copy.Origin.X);
            Assert.Equal(original.Origin.Y, copy.Origin.Y);
        }

        /// <summary>
        /// Copies the constructor independent copy
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void CopyConstructor_IndependentCopy()
        {
            Transformable original = new Transformable();
            original.Position = new Vector2F(10, 20);
            Transformable copy = new Transformable(original);
            copy.Position = new Vector2F(100, 200);
            Assert.Equal(10f, original.Position.X, 5);
            Assert.Equal(20f, original.Position.Y, 5);
        }

        /// <summary>
        /// Destroys the sets c pointer to zero
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Destroy_SetsCPointerToZero()
        {
            Transformable t = new Transformable();
            t.Destroy(true);
            Assert.Equal(IntPtr.Zero, t.CPointer);
        }

        /// <summary>
        /// Destroys the can be called multiple times
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Destroy_CanBeCalledMultipleTimes()
        {
            Transformable t = new Transformable();
            t.Destroy(true);
            t.Destroy(false);
            t.Destroy(true);
        }

        /// <summary>
        /// Tests that protected int ptr constructor sets c pointer
        /// </summary>
        [RequireCSfmlSystemFact]
        public void ProtectedIntPtrConstructor_SetsCPointer()
        {
            IntPtr expected = new IntPtr(42);
            TestTransformable t = new TestTransformable(expected);
            Assert.Equal(expected, t.CPointer);
        }

        /// <summary>
        /// The test transformable class
        /// </summary>
        /// <seealso cref="Transformable"/>
        private class TestTransformable : Transformable
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="TestTransformable"/> class
            /// </summary>
            /// <param name="cPointer">The pointer</param>
            public TestTransformable(IntPtr cPointer) : base(cPointer)
            {
            }
        }
    }
}
