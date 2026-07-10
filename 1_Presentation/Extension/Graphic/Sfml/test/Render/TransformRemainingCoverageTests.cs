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
        [Fact]
        public void TransformPoint_WithXY_ReturnsTransformedPoint()
        {
            Transform t = Transform.Identity;
            Vector2F result = t.TransformPoint(10f, 20f);

            Assert.Equal(10f, result.X);
            Assert.Equal(20f, result.Y);
        }

        /// <summary>
        ///     Tests that Translate with Vector2F offset modifies the transform.
        /// </summary>
        [Fact]
        public void Translate_WithVector2F_ModifiesTransform()
        {
            Transform t = Transform.Identity;
            Vector2F offset = new Vector2F(15f, 25f);
            t.Translate(offset);

            Assert.Equal(15f, t.m02);
            Assert.Equal(25f, t.m12);
        }

        /// <summary>
        ///     Tests that Rotate with angle and Vector2F center modifies the transform.
        /// </summary>
        [Fact]
        public void Rotate_WithAngleAndVector2FCenter_ModifiesTransform()
        {
            Transform t = Transform.Identity;
            Vector2F center = new Vector2F(100f, 200f);
            t.Rotate(0f, center);

            Assert.Equal(1f, t.m00);
            Assert.Equal(1f, t.m11);
            Assert.Equal(1f, t.m22);
        }

        /// <summary>
        ///     Tests that Scale with Vector2F factors modifies the transform.
        /// </summary>
        [Fact]
        public void Scale_WithVector2F_ModifiesTransform()
        {
            Transform t = Transform.Identity;
            Vector2F factors = new Vector2F(3f, 4f);
            t.Scale(factors);

            Assert.Equal(3f, t.m00);
            Assert.Equal(4f, t.m11);
        }

        /// <summary>
        ///     Tests that Scale with Vector2F factors and center modifies the transform.
        /// </summary>
        [Fact]
        public void Scale_WithVector2FAndCenter_ModifiesTransform()
        {
            Transform t = Transform.Identity;
            Vector2F factors = new Vector2F(2f, 3f);
            Vector2F center = new Vector2F(50f, 100f);
            t.Scale(factors, center);

            Assert.Equal(2f, t.m00);
            Assert.Equal(3f, t.m11);
        }

        /// <summary>
        ///     Tests that Equals with object of type Transform returns correct value.
        /// </summary>
        [Fact]
        public void Equals_ObjectIsTransform_ReturnsTrue()
        {
            Transform t1 = new Transform(1, 2, 3, 4, 5, 6, 7, 8, 9);
            object t2 = new Transform(1, 2, 3, 4, 5, 6, 7, 8, 9);

            Assert.True(t1.Equals(t2));
        }

        /// <summary>
        ///     Tests that Equals with object of type Transform returns false for different values.
        /// </summary>
        [Fact]
        public void Equals_ObjectIsDifferentTransform_ReturnsFalse()
        {
            Transform t1 = new Transform(1, 0, 0, 0, 1, 0, 0, 0, 1);
            object t2 = new Transform(2, 0, 0, 0, 2, 0, 0, 0, 2);

            Assert.False(t1.Equals(t2));
        }

        /// <summary>
        ///     Tests that operator * combines two transforms.
        /// </summary>
        [Fact]
        public void Operator_MultiplyTransformTransform_CombinesTransforms()
        {
            Transform t1 = Transform.Identity;
            Transform t2 = new Transform(1, 0, 10, 0, 1, 20, 0, 0, 1);
            Transform result = t1 * t2;

            Assert.Equal(10f, result.m02);
            Assert.Equal(20f, result.m12);
        }

        /// <summary>
        ///     Tests that operator * transforms a point.
        /// </summary>
        [Fact]
        public void Operator_MultiplyTransformVector2F_TransformsPoint()
        {
            Transform t = Transform.Identity;
            Vector2F point = new Vector2F(7f, 14f);
            Vector2F result = t * point;

            Assert.Equal(7f, result.X);
            Assert.Equal(14f, result.Y);
        }

        /// <summary>
        ///     Tests that operator * transforms a point with a translated transform.
        /// </summary>
        [Fact]
        public void Operator_MultiplyTransformVector2F_WithTranslation_TransformsPoint()
        {
            Transform t = new Transform(1, 0, 5, 0, 1, 10, 0, 0, 1);
            Vector2F point = new Vector2F(1f, 2f);
            Vector2F result = t * point;

            Assert.Equal(6f, result.X);
            Assert.Equal(12f, result.Y);
        }
    }
}
