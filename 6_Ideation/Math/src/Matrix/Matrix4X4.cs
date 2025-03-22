// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Matrix4X4.cs
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
using Alis.Core.Aspect.Math.Util;
using Alis.Core.Aspect.Math.Vector;
using HashCode = Alis.Core.Aspect.Math.Util.HashCode;


namespace Alis.Core.Aspect.Math.Matrix
{
    /// <summary>
    ///     The matrix
    /// </summary>
    public struct Matrix4X4 : IEquatable<Matrix4X4>
    {
        /// <summary>
        ///     The hash code
        /// </summary>
        private readonly int hashCode;

        /// <summary>The first element of the first row.</summary>
        public float M11 { get; set; }

        /// <summary>The second element of the first row.</summary>
        public float M12 { get; set; }

        /// <summary>The third element of the first row.</summary>
        public float M13 { get; set; }

        /// <summary>The fourth element of the first row.</summary>
        public float M14 { get; set; }

        /// <summary>The first element of the second row.</summary>
        public float M21 { get; set; }

        /// <summary>The second element of the second row.</summary>
        public float M22 { get; set; }

        /// <summary>The third element of the second row.</summary>
        public float M23 { get; set; }

        /// <summary>The fourth element of the second row.</summary>
        public float M24 { get; set; }

        /// <summary>The first element of the third row.</summary>
        public float M31 { get; set; }

        /// <summary>The second element of the third row.</summary>
        public float M32 { get; set; }

        /// <summary>The third element of the third row.</summary>
        public float M33 { get; set; }

        /// <summary>The fourth element of the third row.</summary>
        public float M34 { get; set; }

        /// <summary>The first element of the fourth row.</summary>
        public float M41 { get; set; }

        /// <summary>The second element of the fourth row.</summary>
        public float M42 { get; set; }

        /// <summary>The third element of the fourth row.</summary>
        public float M43 { get; set; }

        /// <summary>The fourth element of the fourth row.</summary>
        public float M44 { get; set; }

        /// <summary>Creates a 4x4 matrix from the specified components.</summary>
        /// <param name="m11">The value to assign to the first element in the first row.</param>
        /// <param name="m12">The value to assign to the second element in the first row.</param>
        /// <param name="m13">The value to assign to the third element in the first row.</param>
        /// <param name="m14">The value to assign to the fourth element in the first row.</param>
        /// <param name="m21">The value to assign to the first element in the second row.</param>
        /// <param name="m22">The value to assign to the second element in the second row.</param>
        /// <param name="m23">The value to assign to the third element in the second row.</param>
        /// <param name="m24">The value to assign to the third element in the second row.</param>
        /// <param name="m31">The value to assign to the first element in the third row.</param>
        /// <param name="m32">The value to assign to the second element in the third row.</param>
        /// <param name="m33">The value to assign to the third element in the third row.</param>
        /// <param name="m34">The value to assign to the fourth element in the third row.</param>
        /// <param name="m41">The value to assign to the first element in the fourth row.</param>
        /// <param name="m42">The value to assign to the second element in the fourth row.</param>
        /// <param name="m43">The value to assign to the third eleme<>nt in the fourth row<>.</param>
        /// <param name="m44">The value <><><><><><><><><><><><><><><><>to assign to the fourth element in the fourth row.</param>
        public Matrix4X4(float m11, float m12, float m13, float m14,
            float m21, float m22, float m23, float m24,
            float m31, float m32, float m33, float m34,
            float m41, float m42, float m43, float m44)
        {
            M11 = m11;
            M12 = m12;
            M13 = m13;
            M14 = m14;

            M21 = m21;
            M22 = m22;
            M23 = m23;
            M24 = m24;

            M31 = m31;
            M32 = m32;
            M33 = m33;
            M34 = m34;

            M41 = m41;
            M42 = m42;
            M43 = m43;
            M44 = m44;

            HashCode hash = new HashCode();

            hash.Add(M11);
            hash.Add(M12);
            hash.Add(M13);
            hash.Add(M14);
            hash.Add(M21);
            hash.Add(M22);
            hash.Add(M23);
            hash.Add(M24);
            hash.Add(M31);
            hash.Add(M32);
            hash.Add(M33);
            hash.Add(M34);
            hash.Add(M41);
            hash.Add(M42);
            hash.Add(M43);
            hash.Add(M44);

            hashCode = hash.ToHashCode();
        }

        /// <summary>Gets the multiplicative identity matrix.</summary>
        /// <value>Gets the multiplicative identity matrix.</value>
        public static Matrix4X4 Identity => new Matrix4X4
        (
            1f, 0f, 0f, 0f,
            0f, 1f, 0f, 0f,
            0f, 0f, 1f, 0f,
            0f, 0f, 0f, 1f
        );

        /// <summary>
        ///     The index out of range exception
        /// </summary>
        public float this[int row, int column]
        {
            get
            {
                return (row, column) switch
                {
                    (0, 0) => M11,
                    (0, 1) => M12,
                    (0, 2) => M13,
                    (0, 3) => M14,
                    (1, 0) => M21,
                    (1, 1) => M22,
                    (1, 2) => M23,
                    (1, 3) => M24,
                    (2, 0) => M31,
                    (2, 1) => M32,
                    (2, 2) => M33,
                    (2, 3) => M34,
                    (3, 0) => M41,
                    (3, 1) => M42,
                    (3, 2) => M43,
                    (3, 3) => M44,
                    _ => throw new CustomIndexOutOfRangeException("Invalid matrix index!")
                };
            }
            set
            {
                switch (row, column)
                {
                    case (0, 0): M11 = value; break;
                    case (0, 1): M12 = value; break;
                    case (0, 2): M13 = value; break;
                    case (0, 3): M14 = value; break;
                    case (1, 0): M21 = value; break;
                    case (1, 1): M22 = value; break;
                    case (1, 2): M23 = value; break;
                    case (1, 3): M24 = value; break;
                    case (2, 0): M31 = value; break;
                    case (2, 1): M32 = value; break;
                    case (2, 2): M33 = value; break;
                    case (2, 3): M34 = value; break;
                    case (3, 0): M41 = value; break;
                    case (3, 1): M42 = value; break;
                    case (3, 2): M43 = value; break;
                    case (3, 3): M44 = value; break;
                    default: throw new CustomIndexOutOfRangeException("Invalid matrix index!");
                }
            }
        }

        /// <summary>Creates a customized orthographic projection matrix.</summary>
        /// <param name="left">The minimum X-value of the view volume.</param>
        /// <param name="right">The maximum X-value of the view volume.</param>
        /// <param name="bottom">The minimum Y-value of the view volume.</param>
        /// <param name="top">The maximum Y-value of the view volume.</param>
        /// <param name="zNearPlane">The minimum Z-value of the view volume.</param>
        /// <param name="zFarPlane">The maximum Z-value of the view volume.</param>
        /// <returns>The orthographic projection matrix.</returns>
        public static Matrix4X4 CreateOrthographicOffCenter(float left, float right, float bottom, float top, float zNearPlane, float zFarPlane)
        {
            Matrix4X4 result = Identity;

            result.M11 = 2.0f / (right - left);

            result.M22 = 2.0f / (top - bottom);

            result.M33 = 1.0f / (zNearPlane - zFarPlane);

            result.M41 = (left + right) / (left - right);
            result.M42 = (top + bottom) / (bottom - top);
            result.M43 = zNearPlane / (zNearPlane - zFarPlane);

            return result;
        }


        /// <summary>Adds each element in one matrix with its corresponding element in a second matrix.</summary>
        /// <param name="value1">The first matrix.</param>
        /// <param name="value2">The second matrix.</param>
        /// <returns>The matrix that contains the summed values.</returns>
        /// <remarks>
        ///     The <see cref="Matrix4X4.op_Addition" /> method defines the operation of the addition operator for
        ///     <see cref="Matrix4X4" /> objects.
        /// </remarks>
        public static Matrix4X4 operator +(Matrix4X4 value1, Matrix4X4 value2)
        {
            Matrix4X4 m = new Matrix4X4(
                value1.M11 + value2.M11,
                value1.M12 + value2.M12,
                value1.M13 + value2.M13,
                value1.M14 + value2.M14,
                value1.M21 + value2.M21,
                value1.M22 + value2.M22,
                value1.M23 + value2.M23,
                value1.M24 + value2.M24,
                value1.M31 + value2.M31,
                value1.M32 + value2.M32,
                value1.M33 + value2.M33,
                value1.M34 + value2.M34,
                value1.M41 + value2.M41,
                value1.M42 + value2.M42,
                value1.M43 + value2.M43,
                value1.M44 + value2.M44
            );
            return m;
        }

        /// <summary>Returns a value that indicates whether the specified matrices are equal.</summary>
        /// <param name="value1">The first matrix to compare.</param>
        /// <param name="value2">The second matrix to care</param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="value1" /> and <paramref name="value2" /> are equal; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        /// <remarks>Two matrices are equal if all their corresponding elements are equal.</remarks>
        public static bool operator ==(Matrix4X4 value1, Matrix4X4 value2) => (System.Math.Abs(value1.M11 - value2.M11) < 0.1F) && (System.Math.Abs(value1.M22 - value2.M22) < 0.1F) && (System.Math.Abs(value1.M33 - value2.M33) < 0.1F) && (System.Math.Abs(value1.M44 - value2.M44) < 0.1F) && // Check diagonal element first for early out.
                                                                              (System.Math.Abs(value1.M12 - value2.M12) < 0.1F) && (System.Math.Abs(value1.M13 - value2.M13) < 0.1F) && (System.Math.Abs(value1.M14 - value2.M14) < 0.1F) && (System.Math.Abs(value1.M21 - value2.M21) < 0.1F) &&
                                                                              (System.Math.Abs(value1.M23 - value2.M23) < 0.1F) && (System.Math.Abs(value1.M24 - value2.M24) < 0.1F) && (System.Math.Abs(value1.M31 - value2.M31) < 0.1F) && (System.Math.Abs(value1.M32 - value2.M32) < 0.1F) &&
                                                                              (System.Math.Abs(value1.M34 - value2.M34) < 0.1F) && (System.Math.Abs(value1.M41 - value2.M41) < 0.1F) && (System.Math.Abs(value1.M42 - value2.M42) < 0.1F) && (System.Math.Abs(value1.M43 - value2.M43) < 0.1F);

        /// <summary>Returns a value that indicates whether the specified matrices are not equal.</summary>
        /// <param name="value1">The first matrix to compare.</param>
        /// <param name="value2">The second matrix to compare.</param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="value1" /> and <paramref name="value2" /> are not equal; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        public static bool operator !=(Matrix4X4 value1, Matrix4X4 value2) => !(System.Math.Abs(value1.M11 - value2.M11) > 0.1F) && !(System.Math.Abs(value1.M12 - value2.M12) > 0.1F) && !(System.Math.Abs(value1.M13 - value2.M13) > 0.1F) && !(System.Math.Abs(value1.M14 - value2.M14) > 0.1F) &&
                                                                              !(System.Math.Abs(value1.M21 - value2.M21) > 0.1F) && !(System.Math.Abs(value1.M22 - value2.M22) > 0.1F) && !(System.Math.Abs(value1.M23 - value2.M23) > 0.1F) && !(System.Math.Abs(value1.M24 - value2.M24) > 0.1F) &&
                                                                              !(System.Math.Abs(value1.M31 - value2.M31) > 0.1F) && !(System.Math.Abs(value1.M32 - value2.M32) > 0.1F) && !(System.Math.Abs(value1.M33 - value2.M33) > 0.1F) && !(System.Math.Abs(value1.M34 - value2.M34) > 0.1F) &&
                                                                              !(System.Math.Abs(value1.M41 - value2.M41) > 0.1F) && !(System.Math.Abs(value1.M42 - value2.M42) > 0.1F) && !(System.Math.Abs(value1.M43 - value2.M43) > 0.1F) && !(System.Math.Abs(value1.M44 - value2.M44) > 0.1F);


        /// <summary>Creates a matrix for rotating points around the Z axis.</summary>
        /// <param name="radians">The amount, in radians, by which to rotate around the Z-axis.</param>
        /// <returns>The rotation matrix.</returns>
        public static Matrix4X4 CreateRotationZ(float radians)
        {
            float c = CustomMathF.Cos(radians);
            float s = CustomMathF.Sin(radians);

            // [  c  s  0  0 ]
            // [ -s  c  0  0 ]
            // [  0  0  1  0 ]
            // [  0  0  0  1 ]
            Matrix4X4 result = new Matrix4X4(
                c, s, 0, 0,
                -s, c, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1);

            return result;
        }

        /// <summary>Returns a value that indicates whether this instance and a specified object are equal.</summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns>
        ///     <see langword="true" /> if the current instance and <paramref name="obj" /> are equal; otherwise,
        ///     <see langword="false" />. If <paramref name="obj" /> is <see langword="null" />, the method returns
        ///     <see langword="false" />.
        /// </returns>
        /// <remarks>
        ///     The current instance and <paramref name="obj" /> are equal if <paramref name="obj" /> is a
        ///     <see cref="Matrix4X4" /> object and the corresponding elements of each matrix are equal.
        /// </remarks>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is Matrix4X4 other && Equals(other);

        public static Matrix4X4 operator *(Matrix4X4 a, Matrix4X4 b)
        {
            // Implement the matrix multiplication logic here
            Matrix4X4 result = new Matrix4X4();
            // Example logic for matrix multiplication
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < 4; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }

            return result;
        }

        /// <summary>Returns a value that indicates whether this instance and another 4x4 matrix are equal.</summary>
        /// <param name="other">The other matrix.</param>
        /// <returns><see langword="true" /> if the two matrices are equal; otherwise, <see langword="false" />.</returns>
        public bool Equals(Matrix4X4 other) => this == other;

        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode() => hashCode;

        /// <summary>Returns a string that represents this matrix.</summary>
        /// <returns>The string representation of this matrix.</returns>
        /// <remarks>
        ///     The numeric values in the returned string are formatted by using the conventions of the current culture. For
        ///     example, for the en-US culture, the returned string might appear as
        ///     <c>
        ///         { {M11:1.1 M12:1.2 M13:1.3 M14:1.4} {M21:2.1 M22:2.2 M23:2.3 M24:2.4} {M31:3.1 M32:3.2 M33:3.3 M34:3.4}
        ///         {M41:4.1
        ///         M42:4.2 M43:4.3 M44:4.4} }
        ///     </c>
        ///     .
        /// </remarks>
        public override string ToString() =>
            $"{{ {{M11:{M11} M12:{M12} M13:{M13} M14:{M14}}} {{M21:{M21} M22:{M22} M23:{M23} M24:{M24}}} {{M31:{M31} M32:{M32} M33:{M33} M34:{M34}}} {{M41:{M41} M42:{M42} M43:{M43} M44:{M44}}} }}";

        /// <summary>
        ///     Creates the rotation x using the specified radians
        /// </summary>
        /// <param name="radians">The radians</param>
        /// <returns>The result</returns>
        public static Matrix4X4 CreateRotationX(float radians)
        {
            float c = CustomMathF.Cos(radians);
            float s = CustomMathF.Sin(radians);

            // [  1  0  0  0 ]
            // [  0  c  s  0 ]
            // [  0 -s  c  0 ]
            // [  0  0  0  1 ]
            Matrix4X4 result = new Matrix4X4(
                1f, 0f, 0f, 0f,
                0f, c, s, 0f,
                0f, -s, c, 0f,
                0f, 0f, 0f, 1f);

            return result;
        }

        /// <summary>
        ///     Multiplies the matrix 1
        /// </summary>
        /// <param name="matrix1">The matrix</param>
        /// <param name="matrix2">The matrix</param>
        /// <returns>The result</returns>
        public static Matrix4X4 Multiply(Matrix4X4 matrix1, Matrix4X4 matrix2) => new Matrix4X4
        {
            M11 = matrix1.M11 * matrix2.M11 + matrix1.M12 * matrix2.M21 + matrix1.M13 * matrix2.M31 + matrix1.M14 * matrix2.M41,
            M12 = matrix1.M11 * matrix2.M12 + matrix1.M12 * matrix2.M22 + matrix1.M13 * matrix2.M32 + matrix1.M14 * matrix2.M42,
            M13 = matrix1.M11 * matrix2.M13 + matrix1.M12 * matrix2.M23 + matrix1.M13 * matrix2.M33 + matrix1.M14 * matrix2.M43,
            M14 = matrix1.M11 * matrix2.M14 + matrix1.M12 * matrix2.M24 + matrix1.M13 * matrix2.M34 + matrix1.M14 * matrix2.M44,
            M21 = matrix1.M21 * matrix2.M11 + matrix1.M22 * matrix2.M21 + matrix1.M23 * matrix2.M31 + matrix1.M24 * matrix2.M41,
            M22 = matrix1.M21 * matrix2.M12 + matrix1.M22 * matrix2.M22 + matrix1.M23 * matrix2.M32 + matrix1.M24 * matrix2.M42,
            M23 = matrix1.M21 * matrix2.M13 + matrix1.M22 * matrix2.M23 + matrix1.M23 * matrix2.M33 + matrix1.M24 * matrix2.M43,
            M24 = matrix1.M21 * matrix2.M14 + matrix1.M22 * matrix2.M24 + matrix1.M23 * matrix2.M34 + matrix1.M24 * matrix2.M44,
            M31 = matrix1.M31 * matrix2.M11 + matrix1.M32 * matrix2.M21 + matrix1.M33 * matrix2.M31 + matrix1.M34 * matrix2.M41,
            M32 = matrix1.M31 * matrix2.M12 + matrix1.M32 * matrix2.M22 + matrix1.M33 * matrix2.M32 + matrix1.M34 * matrix2.M42,
            M33 = matrix1.M31 * matrix2.M13 + matrix1.M32 * matrix2.M23 + matrix1.M33 * matrix2.M33 + matrix1.M34 * matrix2.M43,
            M34 = matrix1.M31 * matrix2.M14 + matrix1.M32 * matrix2.M24 + matrix1.M33 * matrix2.M34 + matrix1.M34 * matrix2.M44,
            M41 = matrix1.M41 * matrix2.M11 + matrix1.M42 * matrix2.M21 + matrix1.M43 * matrix2.M31 + matrix1.M44 * matrix2.M41,
            M42 = matrix1.M41 * matrix2.M12 + matrix1.M42 * matrix2.M22 + matrix1.M43 * matrix2.M32 + matrix1.M44 * matrix2.M42,
            M43 = matrix1.M41 * matrix2.M13 + matrix1.M42 * matrix2.M23 + matrix1.M43 * matrix2.M33 + matrix1.M44 * matrix2.M43,
            M44 = matrix1.M41 * matrix2.M14 + matrix1.M42 * matrix2.M24 + matrix1.M43 * matrix2.M34 + matrix1.M44 * matrix2.M44
        };

        /// <summary>
        ///     Creates the translation using the specified vector 3
        /// </summary>
        /// <param name="vector3">The vector</param>
        /// <returns>The result</returns>
        public static Matrix4X4 CreateTranslation(Vector3F vector3)
        {
            Matrix4X4 result = Identity;

            result.M41 = vector3.X;
            result.M42 = vector3.Y;
            result.M43 = vector3.Z;

            return result;
        }
    }
}