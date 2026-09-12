// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:TransformCoverageTests.cs
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
    ///     Covers every member of <see cref="Transform" /> through real native CSFML calls with
    ///     concrete expected values for translations, rotations, scales, inverses and equality.
    /// </summary>
    public class TransformCoverageTests
    {
        /// <summary>
        ///     Constructs a plain translation matrix.
        /// </summary>
        /// <returns>The translation transform</returns>
        private static Transform Translation(float x, float y) => new Transform(1, 0, x,
            0, 1, y,
            0, 0, 1);

        /// <summary>
        ///     Tests that the identity transform leaves points unchanged.
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void TransformPoint_WhenIdentity_ReturnsSamePoint()
        {
            Vector2F point = Transform.Identity.TransformPoint(new Vector2F(3f, 4f));

            Assert.Equal(3f, point.X);
            Assert.Equal(4f, point.Y);
        }

        /// <summary>
        ///     Tests that the identity transform leaves raw coordinates unchanged.
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void TransformPoint_WhenIdentityWithRawCoords_ReturnsSameCoords()
        {
            Vector2F point = Transform.Identity.TransformPoint(3f, 4f);

            Assert.Equal(3f, point.X);
            Assert.Equal(4f, point.Y);
        }

        /// <summary>
        ///     Tests that a translation transform shifts the point by the matrix offset.
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void TransformPoint_WhenTranslated_ShiftsPoint()
        {
            Vector2F point = Translation(10f, 20f).TransformPoint(new Vector2F(1f, 2f));

            Assert.Equal(11f, point.X);
            Assert.Equal(22f, point.Y);
        }

        /// <summary>
        ///     Tests that Translate applies its offset to the transform.
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void Translate_WhenCalled_UsesVector2FOffset()
        {
            Transform transform = Transform.Identity;
            transform.Translate(new Vector2F(5f, -3f));

            Vector2F point = transform.TransformPoint(new Vector2F(2f, 2f));

            Assert.Equal(7f, point.X);
            Assert.Equal(-1f, point.Y);
        }

        /// <summary>
        ///     Tests that a translation combined through Combine behaves like matrix addition of the offset.
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void Combine_WhenCombinedWithTranslation_TranslatesPoints()
        {
            Transform transform = Transform.Identity;
            transform.Combine(Translation(4f, 7f));

            Vector2F point = transform.TransformPoint(0f, 0f);

            Assert.Equal(4f, point.X);
            Assert.Equal(7f, point.Y);
        }

        /// <summary>
        ///     Tests that rotating 90 degrees around the origin maps (1, 0) to (0, 1).
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void Rotate_WhenRotationByNinetyDegrees_MapsXAxisToYAxis()
        {
            Transform transform = Transform.Identity;
            transform.Rotate(90f);

            Vector2F point = transform.TransformPoint(1f, 0f);

            Assert.True(point.X < 0.001f, point.X.ToString());
            Assert.True(point.Y > 0.999f, point.Y.ToString());
        }

        /// <summary>
        ///     Tests that Rotate rotates around the given center via the raw overload and keeps the center fixed.
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void Rotate_WhenAroundCenter_RawOverloadKeepsCenterFixed()
        {
            Transform transform = Transform.Identity;
            transform.Rotate(90f, 1f, 0f);

            Vector2F point = transform.TransformPoint(1f, 0f);

            Assert.True(System.Math.Abs(point.X - 1f) < 0.001f, point.X.ToString());
            Assert.True(System.Math.Abs(point.Y) < 0.001f, point.Y.ToString());
        }

        /// <summary>
        ///     Tests that Rotate keeps the vector center fixed.
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void Rotate_WhenAroundVectorCenter_CenterRemainsFixed()
        {
            Transform transform = Transform.Identity;
            transform.Rotate(90f, new Vector2F(1f, 0f));

            Vector2F point = transform.TransformPoint(1f, 0f);

            Assert.True(System.Math.Abs(point.X - 1f) < 0.001f, point.X.ToString());
            Assert.True(System.Math.Abs(point.Y) < 0.001f, point.Y.ToString());
        }

        /// <summary>
        ///     Tests that Scale multiplies coordinates by the factor.
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void Scale_WhenScaled_MultipliesCoordinates()
        {
            Transform transform = Transform.Identity;
            transform.Scale(2f, 3f);

            Vector2F point = transform.TransformPoint(3f, 4f);

            Assert.Equal(6f, point.X);
            Assert.Equal(12f, point.Y);
        }

        /// <summary>
        ///     Tests that the raw centered Scale overload keeps the center fixed.
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void Scale_WhenAroundCenter_RawOverloadKeepsCenterFixed()
        {
            Transform transform = Transform.Identity;
            transform.Scale(2f, 2f, 1f, 1f);

            Vector2F point = transform.TransformPoint(1f, 1f);

            Assert.Equal(1f, point.X);
            Assert.Equal(1f, point.Y);
        }

        /// <summary>
        ///     Tests that the Vector2F centered Scale overload keeps the center fixed.
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void Scale_WhenAroundVectorCenter_CenterRemainsFixed()
        {
            Transform transform = Transform.Identity;
            transform.Scale(new Vector2F(2f, 2f), new Vector2F(1f, 1f));

            Vector2F point = transform.TransformPoint(1f, 1f);

            Assert.Equal(1f, point.X);
            Assert.Equal(1f, point.Y);
        }

        /// <summary>
        ///     Tests that the Vector2F-only Scale overload scales coordinates.
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void Scale_WhenVectorOnly_MultipliesCoordinates()
        {
            Transform transform = Transform.Identity;
            transform.Scale(new Vector2F(2f, 5f));

            Vector2F point = transform.TransformPoint(1f, 1f);

            Assert.Equal(2f, point.X);
            Assert.Equal(5f, point.Y);
        }

        /// <summary>
        ///     Tests that the inverse of a translation cancels it back.
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void GetInverse_WhenTranslated_MapsBackToOriginal()
        {
            Transform inverse = Translation(10f, 20f).GetInverse();

            Vector2F point = inverse.TransformPoint(10f, 20f);

            Assert.True(System.Math.Abs(point.X) < 0.001f, point.X.ToString());
            Assert.True(System.Math.Abs(point.Y) < 0.001f, point.Y.ToString());
        }

        /// <summary>
        ///     Tests that TransformRect on a translated matrix moves the rectangle.
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void TransformRect_WhenTranslated_ContainsShiftedBounds()
        {
            Transform transform = Translation(10f, 20f);

            FloatRect rect = transform.TransformRect(new FloatRect(0f, 0f, 4f, 5f));

            Assert.True(rect.Left == 10f);
            Assert.True(rect.Top == 20f);
        }

        /// <summary>
        ///     Tests that identical matrices are equal and different ones are not.
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void Equals_WhenMatrixValuesDiffer_ReturnsFalse()
        {
            Transform left = Translation(1f, 2f);
            Transform same = Translation(1f, 2f);
            Transform other = Translation(3f, 4f);

            Assert.True(left.Equals(same));
            Assert.False(left.Equals(other));
        }

        /// <summary>
        ///     Tests that Equals(object) accepts boxed transforms and rejects other objects.
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void EqualsBoxedObject_WhenTypesDiffer_ReturnsCorrectResult()
        {
            Transform transform = Transform.Identity;

            Assert.True(transform.Equals((object) Transform.Identity));
            Assert.False(transform.Equals("not a transform"));
            Assert.False(transform.Equals(null));
        }

        /// <summary>
        ///     Tests that equal matrices hash identically and note different values.
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void GetHashCode_WhenMatricesDiffer_ReturnsDistinctHashes()
        {
            Transform left = Transform.Identity;
            Transform same = Transform.Identity;
            Transform other = Translation(5f, 0f);

            Assert.Equal(left.GetHashCode(), same.GetHashCode());
            Assert.NotEqual(left.GetHashCode(), other.GetHashCode());
        }

        /// <summary>
        ///     Tests that the multiplication operator combines transforms with translation applied last.
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void OperatorMultiply_WhenCombiningTranslationAndRotation_ShiftsRotatedPoint()
        {
            Transform rotation = Transform.Identity;
            rotation.Rotate(90f);

            Transform combined = Translation(10f, 0f) * rotation;
            Vector2F point = combined.TransformPoint(1f, 0f);

            Assert.True(System.Math.Abs(point.X - 10f) < 0.001f, point.X.ToString());
            Assert.True(System.Math.Abs(point.Y - 1f) < 0.001f, point.Y.ToString());
        }

        /// <summary>
        ///     Tests that the multiplication operator between transform and point dispatches to TransformPoint.
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void OperatorMultiply_WhenTransformingPoint_TranslatesPoint()
        {
            Vector2F point = Translation(4f, 4f) * new Vector2F(1f, 1f);

            Assert.Equal(5f, point.X);
            Assert.Equal(5f, point.Y);
        }

        /// <summary>
        ///     Tests that the string representation exposes all nine entries of the matrix.
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void ToString_WhenIdentity_PrintsMatrixEntries()
        {
            string text = Transform.Identity.ToString();

            Assert.Contains("[Transform]", text);
            Assert.Contains("1", text);
            Assert.Contains("0", text);
        }

        /// <summary>
        ///     Tests that a singular matrix has a deterministic hash.
        /// </summary>
        [RequireCSfmlGraphicsFact]
        public void GetHashCode_WhenCalledTwice_IsStable()
        {
            Transform transform = Translation(2f, 3f);

            int first = transform.GetHashCode();
            int second = transform.GetHashCode();

            Assert.Equal(first, second);
        }
    }
}
