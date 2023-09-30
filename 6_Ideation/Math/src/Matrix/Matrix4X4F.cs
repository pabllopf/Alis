// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Matrix4X4F.cs
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
using System.Runtime.CompilerServices;
using Alis.Core.Aspect.Math.Util;
using Alis.Core.Aspect.Math.Vector;
using HashCode = Alis.Core.Aspect.Math.Util.HashCode;

namespace Alis.Core.Aspect.Math.Matrix
{
    /// <summary>
    ///     The matrix
    /// </summary>
    public struct Matrix4X4F : IEquatable<Matrix4X4F>
    {
        /// <summary>
        ///     The hash
        /// </summary>
        private readonly HashCode hash;

        /// <summary>
        ///     The hash code
        /// </summary>
        private readonly int hashCode;


        /// <summary>
        ///     The billboard epsilon
        /// </summary>
        private const float BillboardEpsilon = 1e-4f;

        /// <summary>
        ///     The pi
        /// </summary>
        private const float BillboardMinAngle = 1.0f - 0.1f * (MathF.Pi / 180.0f); // 0.1 degrees

        /// <summary>
        ///     The decompose epsilon
        /// </summary>
        private const float DecomposeEpsilon = 0.0001f;

        /// <summary>The first element of the first row.</summary>
        public float M11;

        /// <summary>The second element of the first row.</summary>
        public readonly float M12;

        /// <summary>The third element of the first row.</summary>
        public readonly float M13;

        /// <summary>The fourth element of the first row.</summary>
        public readonly float M14;

        /// <summary>The first element of the second row.</summary>
        public readonly float M21;

        /// <summary>The second element of the second row.</summary>
        public float M22;

        /// <summary>The third element of the second row.</summary>
        public readonly float M23;

        /// <summary>The fourth element of the second row.</summary>
        public readonly float M24;

        /// <summary>The first element of the third row.</summary>
        public readonly float M31;

        /// <summary>The second element of the third row.</summary>
        public readonly float M32;

        /// <summary>The third element of the third row.</summary>
        public float M33;

        /// <summary>The fourth element of the third row.</summary>
        public readonly float M34;

        /// <summary>The first element of the fourth row.</summary>
        public float M41;

        /// <summary>The second element of the fourth row.</summary>
        public float M42;

        /// <summary>The third element of the fourth row.</summary>
        public float M43;

        /// <summary>The fourth element of the fourth row.</summary>
        public readonly float M44;

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
        /// <param name="m43">The value to assign to the third element in the fourth row.</param>
        /// <param name="m44">The value to assign to the fourth element in the fourth row.</param>
        public Matrix4X4F(float m11, float m12, float m13, float m14,
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

            hash = new HashCode();

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

        /// <summary>Creates a <see cref="Matrix4X4F" /> object from a specified <see cref="Matrix3X2F" /> object.</summary>
        /// <param name="value">A 3x2 matrix.</param>
        /// <remarks>
        ///     This constructor creates a 4x4 matrix whose <see cref="Matrix4X4F.M13" />, <see cref="Matrix4X4F.M14" />,
        ///     <see cref="Matrix4X4F.M23" />, <see cref="Matrix4X4F.M24" />, <see cref="Matrix4X4F.M31" />,
        ///     <see cref="Matrix4X4F.M32" />, <see cref="Matrix4X4F.M34" />, and <see cref="Matrix4X4F.M43" /> components are
        ///     zero, and whose <see cref="Matrix4X4F.M33" /> and <see cref="Matrix4X4F.M44" /> components are one.
        /// </remarks>
        public Matrix4X4F(Matrix3X2F value)
        {
            M11 = value.M11;
            M12 = value.M12;
            M13 = 0f;
            M14 = 0f;

            M21 = value.M21;
            M22 = value.M22;
            M23 = 0f;
            M24 = 0f;

            M31 = 0f;
            M32 = 0f;
            M33 = 1f;
            M34 = 0f;

            M41 = value.M31;
            M42 = value.M32;
            M43 = 0f;
            M44 = 1f;

            hash = new HashCode();

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
        public static Matrix4X4F Identity => new Matrix4X4F
        (
            1f, 0f, 0f, 0f,
            0f, 1f, 0f, 0f,
            0f, 0f, 1f, 0f,
            0f, 0f, 0f, 1f
        );

        /// <summary>Indicates whether the current matrix is the identity matrix.</summary>
        /// <value><see langword="true" /> if the current matrix is the identity matrix; otherwise, <see langword="false" />.</value>
        public bool IsIdentity => (M11 == 1f) && (M22 == 1f) && (M33 == 1f) && (M44 == 1f) && // Check diagonal element first for early out.
                                  (M12 == 0f) && (M13 == 0f) && (M14 == 0f) &&
                                  (M21 == 0f) && (M23 == 0f) && (M24 == 0f) &&
                                  (M31 == 0f) && (M32 == 0f) && (M34 == 0f) &&
                                  (M41 == 0f) && (M42 == 0f) && (M43 == 0f);

        /// <summary>Gets or sets the translation component of this matrix.</summary>
        /// <value>The translation component of the current instance.</value>
        public Vector3 Translation => new Vector3(M41, M42, M43);

        /// <summary>Creates a customized orthographic projection matrix.</summary>
        /// <param name="left">The minimum X-value of the view volume.</param>
        /// <param name="right">The maximum X-value of the view volume.</param>
        /// <param name="bottom">The minimum Y-value of the view volume.</param>
        /// <param name="top">The maximum Y-value of the view volume.</param>
        /// <param name="zNearPlane">The minimum Z-value of the view volume.</param>
        /// <param name="zFarPlane">The maximum Z-value of the view volume.</param>
        /// <returns>The orthographic projection matrix.</returns>
        public static Matrix4X4F CreateOrthographicOffCenter(float left, float right, float bottom, float top, float zNearPlane, float zFarPlane)
        {
            Matrix4X4F result = Identity;

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
        ///     The <see cref="Matrix4X4F.op_Addition" /> method defines the operation of the addition operator for
        ///     <see cref="Matrix4X4F" /> objects.
        /// </remarks>
        public static Matrix4X4F operator +(Matrix4X4F value1, Matrix4X4F value2)
        {
            Matrix4X4F m = new Matrix4X4F(
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
        public static bool operator ==(Matrix4X4F value1, Matrix4X4F value2) => (value1.M11 == value2.M11) && (value1.M22 == value2.M22) && (value1.M33 == value2.M33) && (value1.M44 == value2.M44) && // Check diagonal element first for early out.
                                                                                (value1.M12 == value2.M12) && (value1.M13 == value2.M13) && (value1.M14 == value2.M14) && (value1.M21 == value2.M21) &&
                                                                                (value1.M23 == value2.M23) && (value1.M24 == value2.M24) && (value1.M31 == value2.M31) && (value1.M32 == value2.M32) &&
                                                                                (value1.M34 == value2.M34) && (value1.M41 == value2.M41) && (value1.M42 == value2.M42) && (value1.M43 == value2.M43);

        /// <summary>Returns a value that indicates whether the specified matrices are not equal.</summary>
        /// <param name="value1">The first matrix to compare.</param>
        /// <param name="value2">The second matrix to compare.</param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="value1" /> and <paramref name="value2" /> are not equal; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        public static bool operator !=(Matrix4X4F value1, Matrix4X4F value2) => value1.M11 != value2.M11 || value1.M12 != value2.M12 || value1.M13 != value2.M13 || value1.M14 != value2.M14 ||
                                                                                value1.M21 != value2.M21 || value1.M22 != value2.M22 || value1.M23 != value2.M23 || value1.M24 != value2.M24 ||
                                                                                value1.M31 != value2.M31 || value1.M32 != value2.M32 || value1.M33 != value2.M33 || value1.M34 != value2.M34 ||
                                                                                value1.M41 != value2.M41 || value1.M42 != value2.M42 || value1.M43 != value2.M43 || value1.M44 != value2.M44;


        /// <summary>Adds each element in one matrix with its corresponding element in a second matrix.</summary>
        /// <param name="value1">The first matrix.</param>
        /// <param name="value2">The second matrix.</param>
        /// <returns>The matrix that contains the summed values of <paramref name="value1" /> and <paramref name="value2" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4X4F Add(Matrix4X4F value1, Matrix4X4F value2) => value1 + value2;


        /// <summary>Creates a matrix for rotating points around the Z axis.</summary>
        /// <param name="radians">The amount, in radians, by which to rotate around the Z-axis.</param>
        /// <returns>The rotation matrix.</returns>
        public static Matrix4X4F CreateRotationZ(float radians)
        {
            Matrix4X4F result = Identity;

            float c = MathF.Cos(radians);
            float s = MathF.Sin(radians);

            // [  c  s  0  0 ]
            // [ -s  c  0  0 ]
            // [  0  0  1  0 ]
            // [  0  0  0  1 ]

            result = new Matrix4X4F(
                c, s, 0, 0,
                -s, c, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1);

            return result;
        }

        /// <summary>Transforms the specified matrix by applying the specified Quaternion rotation.</summary>
        /// <param name="value">The matrix to transform.</param>
        /// <param name="rotation">The rotation t apply.</param>
        /// <returns>The transformed matrix.</returns>
        public static Matrix4X4F Transform(Matrix4X4F value, Quaternion rotation)
        {
            // Compute rotation matrix.
            float x2 = rotation.X + rotation.X;
            float y2 = rotation.Y + rotation.Y;
            float z2 = rotation.Z + rotation.Z;

            float wx2 = rotation.W * x2;
            float wy2 = rotation.W * y2;
            float wz2 = rotation.W * z2;
            float xx2 = rotation.X * x2;
            float xy2 = rotation.X * y2;
            float xz2 = rotation.X * z2;
            float yy2 = rotation.Y * y2;
            float yz2 = rotation.Y * z2;
            float zz2 = rotation.Z * z2;

            float q11 = 1.0f - yy2 - zz2;
            float q21 = xy2 - wz2;
            float q31 = xz2 + wy2;

            float q12 = xy2 + wz2;
            float q22 = 1.0f - xx2 - zz2;
            float q32 = yz2 - wx2;

            float q13 = xz2 - wy2;
            float q23 = yz2 + wx2;
            float q33 = 1.0f - xx2 - yy2;

            Matrix4X4F result = new Matrix4X4F(
                value.M11 * q11 + value.M12 * q21 + value.M13 * q31,
                value.M11 * q12 + value.M12 * q22 + value.M13 * q32,
                value.M11 * q13 + value.M12 * q23 + value.M13 * q33,
                value.M14,
                value.M21 * q11 + value.M22 * q21 + value.M23 * q31,
                value.M21 * q12 + value.M22 * q22 + value.M23 * q32,
                value.M21 * q13 + value.M22 * q23 + value.M23 * q33,
                value.M24,
                value.M31 * q11 + value.M32 * q21 + value.M33 * q31,
                value.M31 * q12 + value.M32 * q22 + value.M33 * q32,
                value.M31 * q13 + value.M32 * q23 + value.M33 * q33,
                value.M34,
                value.M41 * q11 + value.M42 * q21 + value.M43 * q31,
                value.M41 * q12 + value.M42 * q22 + value.M43 * q32,
                value.M41 * q13 + value.M42 * q23 + value.M43 * q33,
                value.M44
            );

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
        ///     <see cref="Matrix4X4F" /> object and the corresponding elements of each matrix are equal.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is Matrix4X4F other && Equals(other);

        /// <summary>Returns a value that indicates whether this instance and another 4x4 matrix are equal.</summary>
        /// <param name="other">The other matrix.</param>
        /// <returns><see langword="true" /> if the two matrices are equal; otherwise, <see langword="false" />.</returns>
        public bool Equals(Matrix4X4F other) => this == other;

        /// <summary>Calculates the determinant of the current 4x4 matrix.</summary>
        /// <returns>The determinant.</returns>
        public float GetDeterminant()
        {
            // | a b c d |     | f g h |     | e g h |     | e f h |     | e f g |
            // | e f g h | = a | j k l | - b | i k l | + c | i j l | - d | i j k |
            // | i j k l |     | n o p |     | m o p |     | m n p |     | m n o |
            // | m n o p |
            //
            //   | f g h |
            // a | j k l | = a ( f ( kp - lo ) - g ( jp - ln ) + h ( jo - kn ) )
            //   | n o p |
            //
            //   | e g h |
            // b | i k l | = b ( e ( kp - lo ) - g ( ip - lm ) + h ( io - km ) )
            //   | m o p |
            //
            //   | e f h |
            // c | i j l | = c ( e ( jp - ln ) - f ( ip - lm ) + h ( in - jm ) )
            //   | m n p |
            //
            //   | e f g |
            // d | i j k | = d ( e ( jo - kn ) - f ( io - km ) + g ( in - jm ) )
            //   | m n o |
            //
            // Cost of operation
            // 17 adds and 28 muls.
            //
            // add: 6 + 8 + 3 = 17
            // mul: 12 + 16 = 28

            float a = M11, b = M12, c = M13, d = M14;
            float e = M21, f = M22, g = M23, h = M24;
            float i = M31, j = M32, k = M33, l = M34;
            float m = M41, n = M42, o = M43, p = M44;

            float kpLo = k * p - l * o;
            float jpLn = j * p - l * n;
            float joKn = j * o - k * n;
            float ipLm = i * p - l * m;
            float ioKm = i * o - k * m;
            float inJm = i * n - j * m;

            return a * (f * kpLo - g * jpLn + h * joKn) -
                   b * (e * kpLo - g * ipLm + h * ioKm) +
                   c * (e * jpLn - f * ipLm + h * inJm) -
                   d * (e * joKn - f * ioKm + g * inJm);
        }


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
    }
}