// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TransformRemainingCoverageTests.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     Remaining coverage tests for the Transform struct.
    /// </summary>
    public class TransformRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that TransformPoint with float parameters delegates correctly.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void TransformPoint_WithXY_ReturnsTransformedPoint()
        {
            Transform t = Transform.Identity;
            Vector2F result = t.TransformPoint(10f, 20f);

            Assert.Equal(10f, result.X, 5);
            Assert.Equal(20f, result.Y, 5);
        }

        /// <summary>
        ///     Tests that Translate with Vector2F offset modifies the transform.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Translate_WithVector2F_ModifiesTransform()
        {
            Transform t = Transform.Identity;
            Vector2F offset = new Vector2F(15f, 25f);
            t.Translate(offset);

            Assert.Equal(15f, t.m02, 5);
            Assert.Equal(25f, t.m12, 5);
        }

        /// <summary>
        ///     Tests that Rotate with angle and Vector2F center modifies the transform.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Rotate_WithAngleAndVector2FCenter_ModifiesTransform()
        {
            Transform t = Transform.Identity;
            Vector2F center = new Vector2F(100f, 200f);
            t.Rotate(0f, center);

            Assert.Equal(1f, t.m00, 5);
            Assert.Equal(1f, t.m11, 5);
            Assert.Equal(1f, t.m22, 5);
        }

        /// <summary>
        ///     Tests that Scale with Vector2F RequireCSfmlWindowsFactors modifies the transform.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Scale_WithVector2F_ModifiesTransform()
        {
            Transform t = Transform.Identity;
            Vector2F RequireCSfmlWindowsFactors = new Vector2F(3f, 4f);
            t.Scale(RequireCSfmlWindowsFactors);

            Assert.Equal(3f, t.m00, 5);
            Assert.Equal(4f, t.m11, 5);
        }

        /// <summary>
        ///     Tests that Scale with Vector2F RequireCSfmlWindowsFactors and center modifies the transform.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Scale_WithVector2FAndCenter_ModifiesTransform()
        {
            Transform t = Transform.Identity;
            Vector2F RequireCSfmlWindowsFactors = new Vector2F(2f, 3f);
            Vector2F center = new Vector2F(50f, 100f);
            t.Scale(RequireCSfmlWindowsFactors, center);

            Assert.Equal(2f, t.m00, 5);
            Assert.Equal(3f, t.m11, 5);
        }

        /// <summary>
        ///     Tests that Equals with object of type Transform returns correct value.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Equals_ObjectIsTransform_ReturnsTrue()
        {
            Transform t1 = new Transform(1, 2, 3, 4, 5, 6, 7, 8, 9);
            object t2 = new Transform(1, 2, 3, 4, 5, 6, 7, 8, 9);

            Assert.True(t1.Equals(t2));
        }

        /// <summary>
        ///     Tests that Equals with object of type Transform returns false for different values.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Equals_ObjectIsDifferentTransform_ReturnsFalse()
        {
            Transform t1 = new Transform(1, 0, 0, 0, 1, 0, 0, 0, 1);
            object t2 = new Transform(2, 0, 0, 0, 2, 0, 0, 0, 2);

            Assert.False(t1.Equals(t2));
        }

        /// <summary>
        ///     Tests that operator * combines two transforms.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Operator_MultiplyTransformTransform_CombinesTransforms()
        {
            Transform t1 = Transform.Identity;
            Transform t2 = new Transform(1, 0, 10, 0, 1, 20, 0, 0, 1);
            Transform result = t1 * t2;

            Assert.Equal(10f, result.m02, 5);
            Assert.Equal(20f, result.m12, 5);
        }

        /// <summary>
        ///     Tests that operator * transforms a point.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Operator_MultiplyTransformVector2F_TransformsPoint()
        {
            Transform t = Transform.Identity;
            Vector2F point = new Vector2F(7f, 14f);
            Vector2F result = t * point;

            Assert.Equal(7f, result.X, 5);
            Assert.Equal(14f, result.Y, 5);
        }

        /// <summary>
        ///     Tests that operator * transforms a point with a translated transform.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Operator_MultiplyTransformVector2F_WithTranslation_TransformsPoint()
        {
            Transform t = new Transform(1, 0, 5, 0, 1, 10, 0, 0, 1);
            Vector2F point = new Vector2F(1f, 2f);
            Vector2F result = t * point;

            Assert.Equal(6f, result.X, 5);
            Assert.Equal(12f, result.Y, 5);
        }

        /// <summary>
        ///     Tests that GetInverse returns the inverse transform.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void GetInverse_ReturnsInverseTransform()
        {
            Transform t = new Transform(1, 0, 10, 0, 1, 20, 0, 0, 1);
            Transform inv = t.GetInverse();

            Assert.Equal(1f, inv.m00, 5);
            Assert.Equal(1f, inv.m11, 5);
            Assert.Equal(1f, inv.m22, 5);
        }

        /// <summary>
        ///     Tests that TransformRect transforms a rectangle.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void TransformRect_TransformsRectangle()
        {
            Transform t = Transform.Identity;
            FloatRect rect = new FloatRect(10f, 20f, 30f, 40f);
            FloatRect result = t.TransformRect(rect);

            Assert.Equal(10f, result.Left, 5);
            Assert.Equal(20f, result.Top, 5);
            Assert.Equal(30f, result.Width, 5);
            Assert.Equal(40f, result.Height, 5);
        }

        /// <summary>
        ///     Tests that Rotate with angle only modifies the transform.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Rotate_WithAngleOnly_ModifiesTransform()
        {
            Transform t = Transform.Identity;
            t.Rotate(90f);

            Assert.Equal(0f, t.m00, 4);
            Assert.Equal(-1f, t.m01, 4);
            Assert.Equal(1f, t.m10, 4);
            Assert.Equal(0f, t.m11, 4);
        }

        /// <summary>
        ///     Tests that TransformPoint with Vector2F directly transforms a point.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void TransformPoint_WithVector2F_ReturnsTransformedPoint()
        {
            Transform t = Transform.Identity;
            Vector2F point = new Vector2F(10f, 20f);
            Vector2F result = t.TransformPoint(point);

            Assert.Equal(10f, result.X, 5);
            Assert.Equal(20f, result.Y, 5);
        }

        /// <summary>
        ///     Tests that Translate with floats modifies the transform.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Translate_WithFloats_ModifiesTransform()
        {
            Transform t = Transform.Identity;
            t.Translate(15f, 25f);

            Assert.Equal(15f, t.m02, 5);
            Assert.Equal(25f, t.m12, 5);
        }

        /// <summary>
        ///     Tests that Scale with floats modifies the transform.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Scale_WithFloats_ModifiesTransform()
        {
            Transform t = Transform.Identity;
            t.Scale(3f, 4f);

            Assert.Equal(3f, t.m00, 5);
            Assert.Equal(4f, t.m11, 5);
        }

        /// <summary>
        ///     Tests that Scale with floats and center modifies the transform.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Scale_WithFloatsAndCenter_ModifiesTransform()
        {
            Transform t = Transform.Identity;
            t.Scale(2f, 3f, 50f, 100f);

            Assert.Equal(2f, t.m00, 5);
            Assert.Equal(3f, t.m11, 5);
        }

        /// <summary>
        ///     Tests that Combine directly combines two transforms.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Combine_CombinesTransforms()
        {
            Transform t = Transform.Identity;
            Transform other = new Transform(1, 0, 10, 0, 1, 20, 0, 0, 1);
            t.Combine(other);

            Assert.Equal(10f, t.m02, 5);
            Assert.Equal(20f, t.m12, 5);
        }

        /// <summary>
        ///     Tests that Rotate with angle and center coordinates modifies the transform.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Rotate_WithAngleAndCenterCoords_ModifiesTransform()
        {
            Transform t = Transform.Identity;
            t.Rotate(0f, 100f, 200f);

            Assert.Equal(1f, t.m00, 5);
            Assert.Equal(1f, t.m11, 5);
            Assert.Equal(1f, t.m22, 5);
        }
    }
}
