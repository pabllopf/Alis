// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TransformTest.cs
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

using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     Unit tests for the Transform struct.
    /// </summary>
    public class TransformTest
    {
        /// <summary>
        ///     Tests the constructor and field assignment.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_AssignsFields()
        {
            Transform t = new Transform(1, 2, 3, 4, 5, 6, 7, 8, 9);
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
        ///     Tests that Identity returns identity matrix.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Identity_ReturnsIdentityMatrix()
        {
            Transform t = Transform.Identity;

            Assert.Equal(1, t.m00);
            Assert.Equal(0, t.m01);
            Assert.Equal(0, t.m02);
            Assert.Equal(0, t.m10);
            Assert.Equal(1, t.m11);
            Assert.Equal(0, t.m12);
            Assert.Equal(0, t.m20);
            Assert.Equal(0, t.m21);
            Assert.Equal(1, t.m22);
        }

        /// <summary>
        ///     Tests that GetHashCode returns consistent value.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetHashCode_ReturnsConsistentValue()
        {
            Transform t1 = new Transform(1, 2, 3, 4, 5, 6, 7, 8, 9);
            Transform t2 = new Transform(1, 2, 3, 4, 5, 6, 7, 8, 9);

            Assert.Equal(t1.GetHashCode(), t2.GetHashCode());
        }

        /// <summary>
        ///     Tests that GetHashCode differs for different transforms.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetHashCode_DiffersForDifferentTransforms()
        {
            Transform t1 = new Transform(1, 0, 0, 0, 1, 0, 0, 0, 1);
            Transform t2 = new Transform(2, 0, 0, 0, 2, 0, 0, 0, 2);

            Assert.NotEqual(t1.GetHashCode(), t2.GetHashCode());
        }

        /// <summary>
        ///     Tests that ToString returns formatted matrix.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void ToString_ReturnsFormattedMatrix()
        {
            Transform t = new Transform(1, 2, 3, 4, 5, 6, 7, 8, 9);
            string str = t.ToString();

            Assert.Contains("1", str);
            Assert.Contains("5", str);
            Assert.Contains("9", str);
        }

        /// <summary>
        ///     Tests that Equals with null returns false.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Equals_WithNull_ReturnsFalse()
        {
            Transform t = new Transform(1, 0, 0, 0, 1, 0, 0, 0, 1);

            Assert.False(t.Equals(null));
        }

        /// <summary>
        ///     Tests that Equals with non-Transform returns false.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Equals_WithNonTransform_ReturnsFalse()
        {
            Transform t = new Transform(1, 0, 0, 0, 1, 0, 0, 0, 1);

            Assert.False(t.Equals("not a transform"));
        }


    }
}