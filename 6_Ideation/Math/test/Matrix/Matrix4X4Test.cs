// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Matrix4X4Test.cs
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

using Alis.Core.Aspect.Math.Matrix;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Matrix
{
    /// <summary>
    ///     The matrix test class
    /// </summary>
    public class Matrix4X4Test
    {
        /// <summary>
        ///     Tests that test identity matrix
        /// </summary>
        [Fact]
        public void TestIdentityMatrix()
        {
            Matrix4X4 identity = Matrix4X4.Identity;

            Assert.Equal(1f, identity.M11);
            Assert.Equal(0f, identity.M12);
            Assert.Equal(0f, identity.M13);
            Assert.Equal(0f, identity.M14);

            Assert.Equal(0f, identity.M21);
            Assert.Equal(1f, identity.M22);
            Assert.Equal(0f, identity.M23);
            Assert.Equal(0f, identity.M24);

            Assert.Equal(0f, identity.M31);
            Assert.Equal(0f, identity.M32);
            Assert.Equal(1f, identity.M33);
            Assert.Equal(0f, identity.M34);

            Assert.Equal(0f, identity.M41);
            Assert.Equal(0f, identity.M42);
            Assert.Equal(0f, identity.M43);
            Assert.Equal(1f, identity.M44);
        }

        /// <summary>
        ///     Tests that test matrix addition
        /// </summary>
        [Fact]
        public void TestMatrixAddition()
        {
            Matrix4X4 matrix1 = new Matrix4X4(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            Matrix4X4 matrix2 = new Matrix4X4(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            Matrix4X4 result = matrix1 + matrix2;

            Assert.Equal(2, result.M11);
            Assert.Equal(4, result.M12);
        }

        /// <summary>
        ///     Tests that test get hash code
        /// </summary>
        [Fact]
        public void TestGetHashCode()
        {
            Matrix4X4 matrix1 = new Matrix4X4(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            Matrix4X4 matrix2 = new Matrix4X4(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            Assert.Equal(matrix1.GetHashCode(), matrix2.GetHashCode());
        }

        /// <summary>
        ///     Tests that test to string
        /// </summary>
        [Fact]
        public void TestToString()
        {
            Matrix4X4 matrix = new Matrix4X4(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            string expectedString = "{ {M11:1 M12:2 M13:3 M14:4} {M21:5 M22:6 M23:7 M24:8} {M31:9 M32:10 M33:11 M34:12} {M41:13 M42:14 M43:15 M44:16} }";

            Assert.Equal(expectedString, matrix.ToString());
        }

        /// <summary>
        ///     Tests that test equals
        /// </summary>
        [Fact]
        public void TestEquals()
        {
            Matrix4X4 matrix1 = new Matrix4X4(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            Matrix4X4 matrix2 = new Matrix4X4(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            Matrix4X4 matrix3 = new Matrix4X4(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);

            Assert.True(matrix1.Equals(matrix2));
            Assert.False(matrix1.Equals(matrix3));
        }

        /// <summary>
        ///     Tests that test get hash code v 2
        /// </summary>
        [Fact]
        public void TestGetHashCode_v2()
        {
            Matrix4X4 matrix1 = new Matrix4X4(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            Matrix4X4 matrix2 = new Matrix4X4(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            Matrix4X4 matrix3 = new Matrix4X4(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);

            Assert.Equal(matrix1.GetHashCode(), matrix2.GetHashCode());
            Assert.NotEqual(matrix1.GetHashCode(), matrix3.GetHashCode());
        }

        /// <summary>
        ///     Tests that test create rotation z
        /// </summary>
        [Fact]
        public void TestCreateRotationZ()
        {
            float radians = MathF.Pi / 4; // 45 degrees
            Matrix4X4 matrix = Matrix4X4.CreateRotationZ(radians);

            // Expected values were calculated manually
            Assert.Equal(MathF.Cos(radians), matrix.M11, 5);
            Assert.Equal(MathF.Sin(radians), matrix.M12, 5);
            Assert.Equal(-MathF.Sin(radians), matrix.M21, 5);
            Assert.Equal(MathF.Cos(radians), matrix.M22, 5);

            Assert.Equal(0f, matrix.M13);
            Assert.Equal(0f, matrix.M14);
            Assert.Equal(0f, matrix.M23);
            Assert.Equal(0f, matrix.M24);
            Assert.Equal(0f, matrix.M31);
            Assert.Equal(0f, matrix.M32);
            Assert.Equal(1f, matrix.M33);
            Assert.Equal(0f, matrix.M34);
            Assert.Equal(0f, matrix.M41);
            Assert.Equal(0f, matrix.M42);
            Assert.Equal(0f, matrix.M43);
            Assert.Equal(1f, matrix.M44);
        }

        /// <summary>
        ///     Tests that test create orthographic off center
        /// </summary>
        [Fact]
        public void TestCreateOrthographicOffCenter()
        {
            float left = -1.0f;
            float right = 1.0f;
            float bottom = -1.0f;
            float top = 1.0f;
            float zNearPlane = 0.1f;
            float zFarPlane = 100.0f;

            Matrix4X4 matrix = Matrix4X4.CreateOrthographicOffCenter(left, right, bottom, top, zNearPlane, zFarPlane);

            Assert.Equal(2.0f / (right - left), matrix.M11);
            Assert.Equal(2.0f / (top - bottom), matrix.M22);
            Assert.Equal(1.0f / (zNearPlane - zFarPlane), matrix.M33);
            Assert.Equal((left + right) / (left - right), matrix.M41);
            Assert.Equal((top + bottom) / (bottom - top), matrix.M42);
            Assert.Equal(zNearPlane / (zNearPlane - zFarPlane), matrix.M43);
        }

        /// <summary>
        ///     Tests that test op inequality
        /// </summary>
        [Fact]
        public void TestOpInequality()
        {
            Matrix4X4 matrix1 = new Matrix4X4(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            Matrix4X4 matrix2 = new Matrix4X4(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            Matrix4X4 matrix3 = new Matrix4X4(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);

            Assert.True(matrix1 != matrix2);
            Assert.False(matrix1 != matrix3);
        }

        /// <summary>
        ///     Tests that test equals v 2
        /// </summary>
        [Fact]
        public void TestEquals_v2()
        {
            Matrix4X4 matrix1 = new Matrix4X4(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            Matrix4X4 matrix2 = new Matrix4X4(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            Matrix4X4 matrix3 = new Matrix4X4(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);

            Assert.True(matrix1.Equals(matrix2));
            Assert.False(matrix1.Equals(matrix3));
        }

        /// <summary>
        ///     Tests that test equals v 4
        /// </summary>
        [Fact]
        public void TestEquals_v4()
        {
            Matrix4X4 matrix1 = new Matrix4X4(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            Matrix4X4 matrix2 = new Matrix4X4(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            Matrix4X4 matrix3 = new Matrix4X4(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);

            Assert.True(matrix1.Equals(matrix2));
            Assert.False(matrix1.Equals(matrix3));
        }

        /// <summary>
        ///     Tests that test equals v 5
        /// </summary>
        [Fact]
        public void TestEquals_v5()
        {
            Matrix4X4 matrix1 = new Matrix4X4(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            Matrix4X4 matrix2 = new Matrix4X4(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            Matrix4X4 matrix3 = new Matrix4X4(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);

            Assert.True(matrix1.Equals(matrix2));
            Assert.False(matrix1.Equals(matrix3));
            Assert.False(matrix1.Equals("not a matrix"));
        }
    }
}