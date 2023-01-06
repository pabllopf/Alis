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
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Alis.Core.Aspect.Math.Matrix
{
    /// <summary>
    ///     The matrix
    /// </summary>
    public partial struct Matrix4X4F : IEquatable<Matrix4X4F>
    {
        /// <summary>
        ///     The billboard epsilon
        /// </summary>
        private const float BillboardEpsilon = 1e-4f;

        /// <summary>
        ///     The pi
        /// </summary>
        private const float BillboardMinAngle = 1.0f - 0.1f * (MathF.PI / 180.0f); // 0.1 degrees

        /// <summary>
        ///     The decompose epsilon
        /// </summary>
        private const float DecomposeEpsilon = 0.0001f;
        
        /// <summary>The first element of the first row.</summary>
        public float M11;

        /// <summary>The second element of the first row.</summary>
        public float M12;

        /// <summary>The third element of the first row.</summary>
        public float M13;

        /// <summary>The fourth element of the first row.</summary>
        public float M14;

        /// <summary>The first element of the second row.</summary>
        public float M21;

        /// <summary>The second element of the second row.</summary>
        public float M22;

        /// <summary>The third element of the second row.</summary>
        public float M23;

        /// <summary>The fourth element of the second row.</summary>
        public float M24;

        /// <summary>The first element of the third row.</summary>
        public float M31;

        /// <summary>The second element of the third row.</summary>
        public float M32;

        /// <summary>The third element of the third row.</summary>
        public float M33;

        /// <summary>The fourth element of the third row.</summary>
        public float M34;

        /// <summary>The first element of the fourth row.</summary>
        public float M41;

        /// <summary>The second element of the fourth row.</summary>
        public float M42;

        /// <summary>The third element of the fourth row.</summary>
        public float M43;

        /// <summary>The fourth element of the fourth row.</summary>
        public float M44;

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
        }

        /// <summary>Creates a <see cref="Matrix4X4F" /> object from a specified <see cref="System.Numerics.Matrix3x2" /> object.</summary>
        /// <param name="value">A 3x2 matrix.</param>
        /// <remarks>
        ///     This constructor creates a 4x4 matrix whose <see cref="Matrix4X4F.M13" />, <see cref="Matrix4X4F.M14" />,
        ///     <see cref="Matrix4X4F.M23" />, <see cref="Matrix4X4F.M24" />, <see cref="Matrix4X4F.M31" />,
        ///     <see cref="Matrix4X4F.M32" />, <see cref="Matrix4X4F.M34" />, and <see cref="Matrix4X4F.M43" /> components are
        ///     zero, and whose <see cref="Matrix4X4F.M33" /> and <see cref="Matrix4X4F.M44" /> components are one.
        /// </remarks>
        public Matrix4X4F(Matrix3x2 value)
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
        public readonly bool IsIdentity => (M11 == 1f) && (M22 == 1f) && (M33 == 1f) && (M44 == 1f) && // Check diagonal element first for early out.
                                           (M12 == 0f) && (M13 == 0f) && (M14 == 0f) &&
                                           (M21 == 0f) && (M23 == 0f) && (M24 == 0f) &&
                                           (M31 == 0f) && (M32 == 0f) && (M34 == 0f) &&
                                           (M41 == 0f) && (M42 == 0f) && (M43 == 0f);

        /// <summary>Gets or sets the translation component of this matrix.</summary>
        /// <value>The translation component of the current instance.</value>
        public Vector3 Translation
        {
            readonly get => new Vector3(M41, M42, M43);

            set
            {
                M41 = value.X;
                M42 = value.Y;
                M43 = value.Z;
            }
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
            Matrix4X4F m;

            m.M11 = value1.M11 + value2.M11;
            m.M12 = value1.M12 + value2.M12;
            m.M13 = value1.M13 + value2.M13;
            m.M14 = value1.M14 + value2.M14;
            m.M21 = value1.M21 + value2.M21;
            m.M22 = value1.M22 + value2.M22;
            m.M23 = value1.M23 + value2.M23;
            m.M24 = value1.M24 + value2.M24;
            m.M31 = value1.M31 + value2.M31;
            m.M32 = value1.M32 + value2.M32;
            m.M33 = value1.M33 + value2.M33;
            m.M34 = value1.M34 + value2.M34;
            m.M41 = value1.M41 + value2.M41;
            m.M42 = value1.M42 + value2.M42;
            m.M43 = value1.M43 + value2.M43;
            m.M44 = value1.M44 + value2.M44;

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

        /// <summary>Multiplies two matrices together to compute the product.</summary>
        /// <param name="value1">The first matrix.</param>
        /// <param name="value2">The second matrix.</param>
        /// <returns>The product matrix.</returns>
        public static Matrix4X4F operator *(Matrix4X4F value1, Matrix4X4F value2)
        {
            Matrix4X4F m;

            // First row
            m.M11 = value1.M11 * value2.M11 + value1.M12 * value2.M21 + value1.M13 * value2.M31 + value1.M14 * value2.M41;
            m.M12 = value1.M11 * value2.M12 + value1.M12 * value2.M22 + value1.M13 * value2.M32 + value1.M14 * value2.M42;
            m.M13 = value1.M11 * value2.M13 + value1.M12 * value2.M23 + value1.M13 * value2.M33 + value1.M14 * value2.M43;
            m.M14 = value1.M11 * value2.M14 + value1.M12 * value2.M24 + value1.M13 * value2.M34 + value1.M14 * value2.M44;

            // Second row
            m.M21 = value1.M21 * value2.M11 + value1.M22 * value2.M21 + value1.M23 * value2.M31 + value1.M24 * value2.M41;
            m.M22 = value1.M21 * value2.M12 + value1.M22 * value2.M22 + value1.M23 * value2.M32 + value1.M24 * value2.M42;
            m.M23 = value1.M21 * value2.M13 + value1.M22 * value2.M23 + value1.M23 * value2.M33 + value1.M24 * value2.M43;
            m.M24 = value1.M21 * value2.M14 + value1.M22 * value2.M24 + value1.M23 * value2.M34 + value1.M24 * value2.M44;

            // Third row
            m.M31 = value1.M31 * value2.M11 + value1.M32 * value2.M21 + value1.M33 * value2.M31 + value1.M34 * value2.M41;
            m.M32 = value1.M31 * value2.M12 + value1.M32 * value2.M22 + value1.M33 * value2.M32 + value1.M34 * value2.M42;
            m.M33 = value1.M31 * value2.M13 + value1.M32 * value2.M23 + value1.M33 * value2.M33 + value1.M34 * value2.M43;
            m.M34 = value1.M31 * value2.M14 + value1.M32 * value2.M24 + value1.M33 * value2.M34 + value1.M34 * value2.M44;

            // Fourth row
            m.M41 = value1.M41 * value2.M11 + value1.M42 * value2.M21 + value1.M43 * value2.M31 + value1.M44 * value2.M41;
            m.M42 = value1.M41 * value2.M12 + value1.M42 * value2.M22 + value1.M43 * value2.M32 + value1.M44 * value2.M42;
            m.M43 = value1.M41 * value2.M13 + value1.M42 * value2.M23 + value1.M43 * value2.M33 + value1.M44 * value2.M43;
            m.M44 = value1.M41 * value2.M14 + value1.M42 * value2.M24 + value1.M43 * value2.M34 + value1.M44 * value2.M44;

            return m;
        }

        /// <summary>Multiplies a matrix by a float to compute the product.</summary>
        /// <param name="value1">The matrix to scale.</param>
        /// <param name="value2">The scaling value to use.</param>
        /// <returns>The scaled matrix.</returns>
        public static Matrix4X4F operator *(Matrix4X4F value1, float value2)
        {
            Matrix4X4F m;

            m.M11 = value1.M11 * value2;
            m.M12 = value1.M12 * value2;
            m.M13 = value1.M13 * value2;
            m.M14 = value1.M14 * value2;
            m.M21 = value1.M21 * value2;
            m.M22 = value1.M22 * value2;
            m.M23 = value1.M23 * value2;
            m.M24 = value1.M24 * value2;
            m.M31 = value1.M31 * value2;
            m.M32 = value1.M32 * value2;
            m.M33 = value1.M33 * value2;
            m.M34 = value1.M34 * value2;
            m.M41 = value1.M41 * value2;
            m.M42 = value1.M42 * value2;
            m.M43 = value1.M43 * value2;
            m.M44 = value1.M44 * value2;
            return m;
        }

        /// <summary>Subtracts each element in a second matrix from its corresponding element in a first matrix.</summary>
        /// <param name="value1">The first matrix.</param>
        /// <param name="value2">The second matrix.</param>
        /// <returns>
        ///     The matrix containing the values that result from subtracting each element in <paramref name="value2" /> from
        ///     its corresponding element in <paramref name="value1" />.
        /// </returns>
        /// <remarks>
        ///     The <see cref="Matrix4X4F.op_Subtraction" /> method defines the operation of the subtraction operator for
        ///     <see cref="Matrix4X4F" /> objects.
        /// </remarks>
        public static Matrix4X4F operator -(Matrix4X4F value1, Matrix4X4F value2)
        {
            Matrix4X4F m;

            m.M11 = value1.M11 - value2.M11;
            m.M12 = value1.M12 - value2.M12;
            m.M13 = value1.M13 - value2.M13;
            m.M14 = value1.M14 - value2.M14;
            m.M21 = value1.M21 - value2.M21;
            m.M22 = value1.M22 - value2.M22;
            m.M23 = value1.M23 - value2.M23;
            m.M24 = value1.M24 - value2.M24;
            m.M31 = value1.M31 - value2.M31;
            m.M32 = value1.M32 - value2.M32;
            m.M33 = value1.M33 - value2.M33;
            m.M34 = value1.M34 - value2.M34;
            m.M41 = value1.M41 - value2.M41;
            m.M42 = value1.M42 - value2.M42;
            m.M43 = value1.M43 - value2.M43;
            m.M44 = value1.M44 - value2.M44;

            return m;
        }

        /// <summary>Negates the specified matrix by multiplying all its values by -1.</summary>
        /// <param name="value">The matrix to negate.</param>
        /// <returns>The negated matrix.</returns>
        public static Matrix4X4F operator -(Matrix4X4F value)
        {
            Matrix4X4F m;

            m.M11 = -value.M11;
            m.M12 = -value.M12;
            m.M13 = -value.M13;
            m.M14 = -value.M14;
            m.M21 = -value.M21;
            m.M22 = -value.M22;
            m.M23 = -value.M23;
            m.M24 = -value.M24;
            m.M31 = -value.M31;
            m.M32 = -value.M32;
            m.M33 = -value.M33;
            m.M34 = -value.M34;
            m.M41 = -value.M41;
            m.M42 = -value.M42;
            m.M43 = -value.M43;
            m.M44 = -value.M44;

            return m;
        }

        /// <summary>Adds each element in one matrix with its corresponding element in a second matrix.</summary>
        /// <param name="value1">The first matrix.</param>
        /// <param name="value2">The second matrix.</param>
        /// <returns>The matrix that contains the summed values of <paramref name="value1" /> and <paramref name="value2" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4X4F Add(Matrix4X4F value1, Matrix4X4F value2) => value1 + value2;

        /// <summary>Creates a spherical billboard that rotates around a specified object position.</summary>
        /// <param name="objectPosition">The position of the object that the billboard will rotate around.</param>
        /// <param name="cameraPosition">The position of the camera.</param>
        /// <param name="cameraUpVector">The up vector of the camera.</param>
        /// <param name="cameraForwardVector">The forward vector of the camera.</param>
        /// <returns>The created billboard.</returns>
        public static Matrix4X4F CreateBillboard(Vector3 objectPosition, Vector3 cameraPosition, Vector3 cameraUpVector, Vector3 cameraForwardVector)
        {
            Vector3 zaxis = objectPosition - cameraPosition;
            float norm = zaxis.LengthSquared();

            if (norm < BillboardEpsilon)
            {
                zaxis = -cameraForwardVector;
            }
            else
            {
                zaxis = Vector3.Multiply(zaxis, 1.0f / MathF.Sqrt(norm));
            }

            Vector3 xaxis = Vector3.Normalize(Vector3.Cross(cameraUpVector, zaxis));
            Vector3 yaxis = Vector3.Cross(zaxis, xaxis);

            Matrix4X4F result;

            result.M11 = xaxis.X;
            result.M12 = xaxis.Y;
            result.M13 = xaxis.Z;
            result.M14 = 0.0f;

            result.M21 = yaxis.X;
            result.M22 = yaxis.Y;
            result.M23 = yaxis.Z;
            result.M24 = 0.0f;

            result.M31 = zaxis.X;
            result.M32 = zaxis.Y;
            result.M33 = zaxis.Z;
            result.M34 = 0.0f;

            result.M41 = objectPosition.X;
            result.M42 = objectPosition.Y;
            result.M43 = objectPosition.Z;
            result.M44 = 1.0f;

            return result;
        }

        /// <summary>Creates a cylindrical billboard that rotates around a specified axis.</summary>
        /// <param name="objectPosition">The position of the object that the billboard will rotate around.</param>
        /// <param name="cameraPosition">The position of the camera.</param>
        /// <param name="rotateAxis">The axis to rotate the billboard around.</param>
        /// <param name="cameraForwardVector">The forward vector of the camera.</param>
        /// <param name="objectForwardVector">The forward vector of the object.</param>
        /// <returns>The billboard matrix.</returns>
        public static Matrix4X4F CreateConstrainedBillboard(Vector3 objectPosition, Vector3 cameraPosition, Vector3 rotateAxis, Vector3 cameraForwardVector, Vector3 objectForwardVector)
        {
            // Treat the case when object and camera positions are too close.
            Vector3 faceDir = objectPosition - cameraPosition;
            float norm = faceDir.LengthSquared();

            if (norm < BillboardEpsilon)
            {
                faceDir = -cameraForwardVector;
            }
            else
            {
                faceDir = Vector3.Multiply(faceDir, 1.0f / MathF.Sqrt(norm));
            }

            Vector3 yaxis = rotateAxis;
            Vector3 xaxis;
            Vector3 zaxis;

            // Treat the case when angle between faceDir and rotateAxis is too close to 0.
            float dot = Vector3.Dot(rotateAxis, faceDir);

            if (MathF.Abs(dot) > BillboardMinAngle)
            {
                zaxis = objectForwardVector;

                // Make sure passed values are useful for compute.
                dot = Vector3.Dot(rotateAxis, zaxis);

                if (MathF.Abs(dot) > BillboardMinAngle)
                {
                    zaxis = MathF.Abs(rotateAxis.Z) > BillboardMinAngle ? new Vector3(1, 0, 0) : new Vector3(0, 0, -1);
                }

                xaxis = Vector3.Normalize(Vector3.Cross(rotateAxis, zaxis));
                zaxis = Vector3.Normalize(Vector3.Cross(xaxis, rotateAxis));
            }
            else
            {
                xaxis = Vector3.Normalize(Vector3.Cross(rotateAxis, faceDir));
                zaxis = Vector3.Normalize(Vector3.Cross(xaxis, yaxis));
            }

            Matrix4X4F result;

            result.M11 = xaxis.X;
            result.M12 = xaxis.Y;
            result.M13 = xaxis.Z;
            result.M14 = 0.0f;

            result.M21 = yaxis.X;
            result.M22 = yaxis.Y;
            result.M23 = yaxis.Z;
            result.M24 = 0.0f;

            result.M31 = zaxis.X;
            result.M32 = zaxis.Y;
            result.M33 = zaxis.Z;
            result.M34 = 0.0f;

            result.M41 = objectPosition.X;
            result.M42 = objectPosition.Y;
            result.M43 = objectPosition.Z;
            result.M44 = 1.0f;

            return result;
        }

        /// <summary>Creates a matrix that rotates around an arbitrary vector.</summary>
        /// <param name="axis">The axis to rotate around.</param>
        /// <param name="angle">The angle to rotate around <paramref name="axis" />, in radians.</param>
        /// <returns>The rotation matrix.</returns>
        public static Matrix4X4F CreateFromAxisAngle(Vector3 axis, float angle)
        {
            // a: angle
            // x, y, z: unit vector for axis.
            //
            // Rotation matrix M can compute by using below equation.
            //
            //        T               T
            //  M = uu + (cos a)( I-uu ) + (sin a)S
            //
            // Where:
            //
            //  u = ( x, y, z )
            //
            //      [  0 -z  y ]
            //  S = [  z  0 -x ]
            //      [ -y  x  0 ]
            //
            //      [ 1 0 0 ]
            //  I = [ 0 1 0 ]
            //      [ 0 0 1 ]
            //
            //
            //     [  xx+cosa*(1-xx)   yx-cosa*yx-sina*z zx-cosa*xz+sina*y ]
            // M = [ xy-cosa*yx+sina*z    yy+cosa(1-yy)  yz-cosa*yz-sina*x ]
            //     [ zx-cosa*zx-sina*y zy-cosa*zy+sina*x   zz+cosa*(1-zz)  ]
            //
            float x = axis.X, y = axis.Y, z = axis.Z;
            float sa = MathF.Sin(angle), ca = MathF.Cos(angle);
            float xx = x * x, yy = y * y, zz = z * z;
            float xy = x * y, xz = x * z, yz = y * z;

            Matrix4X4F result = Identity;

            result.M11 = xx + ca * (1.0f - xx);
            result.M12 = xy - ca * xy + sa * z;
            result.M13 = xz - ca * xz - sa * y;

            result.M21 = xy - ca * xy - sa * z;
            result.M22 = yy + ca * (1.0f - yy);
            result.M23 = yz - ca * yz + sa * x;

            result.M31 = xz - ca * xz + sa * y;
            result.M32 = yz - ca * yz - sa * x;
            result.M33 = zz + ca * (1.0f - zz);

            return result;
        }

        /// <summary>Creates a rotation matrix from the specified Quaternion rotation value.</summary>
        /// <param name="quaternion">The source Quaternion.</param>
        /// <returns>The rotation matrix.</returns>
        public static Matrix4X4F CreateFromQuaternion(Quaternion quaternion)
        {
            Matrix4X4F result = Identity;

            float xx = quaternion.X * quaternion.X;
            float yy = quaternion.Y * quaternion.Y;
            float zz = quaternion.Z * quaternion.Z;

            float xy = quaternion.X * quaternion.Y;
            float wz = quaternion.Z * quaternion.W;
            float xz = quaternion.Z * quaternion.X;
            float wy = quaternion.Y * quaternion.W;
            float yz = quaternion.Y * quaternion.Z;
            float wx = quaternion.X * quaternion.W;

            result.M11 = 1.0f - 2.0f * (yy + zz);
            result.M12 = 2.0f * (xy + wz);
            result.M13 = 2.0f * (xz - wy);

            result.M21 = 2.0f * (xy - wz);
            result.M22 = 1.0f - 2.0f * (zz + xx);
            result.M23 = 2.0f * (yz + wx);

            result.M31 = 2.0f * (xz + wy);
            result.M32 = 2.0f * (yz - wx);
            result.M33 = 1.0f - 2.0f * (yy + xx);

            return result;
        }

        /// <summary>Creates a rotation matrix from the specified yaw, pitch, and roll.</summary>
        /// <param name="yaw">The angle of rotation, in radians, around the Y axis.</param>
        /// <param name="pitch">The angle of rotation, in radians, around the X axis.</param>
        /// <param name="roll">The angle of rotation, in radians, around the Z axis.</param>
        /// <returns>The rotation matrix.</returns>
        public static Matrix4X4F CreateFromYawPitchRoll(float yaw, float pitch, float roll)
        {
            Quaternion q = Quaternion.CreateFromYawPitchRoll(yaw, pitch, roll);
            return CreateFromQuaternion(q);
        }

        /// <summary>Creates a view matrix.</summary>
        /// <param name="cameraPosition">The position of the camera.</param>
        /// <param name="cameraTarget">The target towards which the camera is pointing.</param>
        /// <param name="cameraUpVector">The direction that is "up" from the camera's point of view.</param>
        /// <returns>The view matrix.</returns>
        public static Matrix4X4F CreateLookAt(Vector3 cameraPosition, Vector3 cameraTarget, Vector3 cameraUpVector)
        {
            Vector3 zaxis = Vector3.Normalize(cameraPosition - cameraTarget);
            Vector3 xaxis = Vector3.Normalize(Vector3.Cross(cameraUpVector, zaxis));
            Vector3 yaxis = Vector3.Cross(zaxis, xaxis);

            Matrix4X4F result = Identity;

            result.M11 = xaxis.X;
            result.M12 = yaxis.X;
            result.M13 = zaxis.X;

            result.M21 = xaxis.Y;
            result.M22 = yaxis.Y;
            result.M23 = zaxis.Y;

            result.M31 = xaxis.Z;
            result.M32 = yaxis.Z;
            result.M33 = zaxis.Z;

            result.M41 = -Vector3.Dot(xaxis, cameraPosition);
            result.M42 = -Vector3.Dot(yaxis, cameraPosition);
            result.M43 = -Vector3.Dot(zaxis, cameraPosition);

            return result;
        }

        /// <summary>Creates an orthographic perspective matrix from the given view volume dimensions.</summary>
        /// <param name="width">The width of the view volume.</param>
        /// <param name="height">The height of the view volume.</param>
        /// <param name="zNearPlane">The minimum Z-value of the view volume.</param>
        /// <param name="zFarPlane">The maximum Z-value of the view volume.</param>
        /// <returns>The orthographic projection matrix.</returns>
        public static Matrix4X4F CreateOrthographic(float width, float height, float zNearPlane, float zFarPlane)
        {
            Matrix4X4F result = Identity;

            result.M11 = 2.0f / width;
            result.M22 = 2.0f / height;
            result.M33 = 1.0f / (zNearPlane - zFarPlane);
            result.M43 = zNearPlane / (zNearPlane - zFarPlane);

            return result;
        }

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

        /// <summary>Creates a perspective projection matrix from the given view volume dimensions.</summary>
        /// <param name="width">The width of the view volume at the near view plane.</param>
        /// <param name="height">The height of the view volume at the near view plane.</param>
        /// <param name="nearPlaneDistance">The distance to the near view plane.</param>
        /// <param name="farPlaneDistance">The distance to the far view plane.</param>
        /// <returns>The perspective projection matrix.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        ///     <paramref name="nearPlaneDistance" /> is less than or equal to zero.
        ///     -or-
        ///     <paramref name="farPlaneDistance" /> is less than or equal to zero.
        ///     -or-
        ///     <paramref name="nearPlaneDistance" /> is greater than or equal to <paramref name="farPlaneDistance" />.
        /// </exception>
        public static Matrix4X4F CreatePerspective(float width, float height, float nearPlaneDistance, float farPlaneDistance)
        {
            if (nearPlaneDistance <= 0.0f)
            {
                throw new ArgumentOutOfRangeException(nameof(nearPlaneDistance));
            }

            if (farPlaneDistance <= 0.0f)
            {
                throw new ArgumentOutOfRangeException(nameof(farPlaneDistance));
            }

            if (nearPlaneDistance >= farPlaneDistance)
            {
                throw new ArgumentOutOfRangeException(nameof(nearPlaneDistance));
            }

            Matrix4X4F result;

            result.M11 = 2.0f * nearPlaneDistance / width;
            result.M12 = result.M13 = result.M14 = 0.0f;

            result.M22 = 2.0f * nearPlaneDistance / height;
            result.M21 = result.M23 = result.M24 = 0.0f;

            float negFarRange = float.IsPositiveInfinity(farPlaneDistance) ? -1.0f : farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
            result.M33 = negFarRange;
            result.M31 = result.M32 = 0.0f;
            result.M34 = -1.0f;

            result.M41 = result.M42 = result.M44 = 0.0f;
            result.M43 = nearPlaneDistance * negFarRange;

            return result;
        }

        /// <summary>
        ///     Creates a perspective projection matrix based on a field of view, aspect ratio, and near and far view plane
        ///     distances.
        /// </summary>
        /// <param name="fieldOfView">The field of view in the y direction, in radians.</param>
        /// <param name="aspectRatio">The aspect ratio, defined as view space width divided by height.</param>
        /// <param name="nearPlaneDistance">The distance to the near view plane.</param>
        /// <param name="farPlaneDistance">The distance to the far view plane.</param>
        /// <returns>The perspective projection matrix.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        ///     <paramref name="fieldOfView" /> is less than or equal to zero.
        ///     -or-
        ///     <paramref name="fieldOfView" /> is greater than or equal to <see cref="System.Math.PI" />.
        ///     <paramref name="nearPlaneDistance" /> is less than or equal to zero.
        ///     -or-
        ///     <paramref name="farPlaneDistance" /> is less than or equal to zero.
        ///     -or-
        ///     <paramref name="nearPlaneDistance" /> is greater than or equal to <paramref name="farPlaneDistance" />.
        /// </exception>
        public static Matrix4X4F CreatePerspectiveFieldOfView(float fieldOfView, float aspectRatio, float nearPlaneDistance, float farPlaneDistance)
        {
            if (fieldOfView <= 0.0f || fieldOfView >= MathF.PI)
            {
                throw new ArgumentOutOfRangeException(nameof(fieldOfView));
            }

            if (nearPlaneDistance <= 0.0f)
            {
                throw new ArgumentOutOfRangeException(nameof(nearPlaneDistance));
            }

            if (farPlaneDistance <= 0.0f)
            {
                throw new ArgumentOutOfRangeException(nameof(farPlaneDistance));
            }

            if (nearPlaneDistance >= farPlaneDistance)
            {
                throw new ArgumentOutOfRangeException(nameof(nearPlaneDistance));
            }

            float yScale = 1.0f / MathF.Tan(fieldOfView * 0.5f);
            float xScale = yScale / aspectRatio;

            Matrix4X4F result;

            result.M11 = xScale;
            result.M12 = result.M13 = result.M14 = 0.0f;

            result.M22 = yScale;
            result.M21 = result.M23 = result.M24 = 0.0f;

            result.M31 = result.M32 = 0.0f;
            float negFarRange = float.IsPositiveInfinity(farPlaneDistance) ? -1.0f : farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
            result.M33 = negFarRange;
            result.M34 = -1.0f;

            result.M41 = result.M42 = result.M44 = 0.0f;
            result.M43 = nearPlaneDistance * negFarRange;

            return result;
        }

        /// <summary>Creates a customized perspective projection matrix.</summary>
        /// <param name="left">The minimum x-value of the view volume at the near view plane.</param>
        /// <param name="right">The maximum x-value of the view volume at the near view plane.</param>
        /// <param name="bottom">The minimum y-value of the view volume at the near view plane.</param>
        /// <param name="top">The maximum y-value of the view volume at the near view plane.</param>
        /// <param name="nearPlaneDistance">The distance to the near view plane.</param>
        /// <param name="farPlaneDistance">The distance to the far view plane.</param>
        /// <returns>The perspective projection matrix.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        ///     <paramref name="nearPlaneDistance" /> is less than or equal to zero.
        ///     -or-
        ///     <paramref name="farPlaneDistance" /> is less than or equal to zero.
        ///     -or-
        ///     <paramref name="nearPlaneDistance" /> is greater than or equal to <paramref name="farPlaneDistance" />.
        /// </exception>
        public static Matrix4X4F CreatePerspectiveOffCenter(float left, float right, float bottom, float top, float nearPlaneDistance, float farPlaneDistance)
        {
            if (nearPlaneDistance <= 0.0f)
            {
                throw new ArgumentOutOfRangeException(nameof(nearPlaneDistance));
            }

            if (farPlaneDistance <= 0.0f)
            {
                throw new ArgumentOutOfRangeException(nameof(farPlaneDistance));
            }

            if (nearPlaneDistance >= farPlaneDistance)
            {
                throw new ArgumentOutOfRangeException(nameof(nearPlaneDistance));
            }

            Matrix4X4F result;

            result.M11 = 2.0f * nearPlaneDistance / (right - left);
            result.M12 = result.M13 = result.M14 = 0.0f;

            result.M22 = 2.0f * nearPlaneDistance / (top - bottom);
            result.M21 = result.M23 = result.M24 = 0.0f;

            result.M31 = (left + right) / (right - left);
            result.M32 = (top + bottom) / (top - bottom);
            float negFarRange = float.IsPositiveInfinity(farPlaneDistance) ? -1.0f : farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
            result.M33 = negFarRange;
            result.M34 = -1.0f;

            result.M43 = nearPlaneDistance * negFarRange;
            result.M41 = result.M42 = result.M44 = 0.0f;

            return result;
        }

        /// <summary>Creates a matrix that reflects the coordinate system about a specified plane.</summary>
        /// <param name="value">The plane about which to create a reflection.</param>
        /// <returns>A new matrix expressing the reflection.</returns>
        public static Matrix4X4F CreateReflection(Plane value)
        {
            value = Plane.Normalize(value);

            float a = value.Normal.X;
            float b = value.Normal.Y;
            float c = value.Normal.Z;

            float fa = -2.0f * a;
            float fb = -2.0f * b;
            float fc = -2.0f * c;

            Matrix4X4F result = Identity;

            result.M11 = fa * a + 1.0f;
            result.M12 = fb * a;
            result.M13 = fc * a;

            result.M21 = fa * b;
            result.M22 = fb * b + 1.0f;
            result.M23 = fc * b;

            result.M31 = fa * c;
            result.M32 = fb * c;
            result.M33 = fc * c + 1.0f;

            result.M41 = fa * value.D;
            result.M42 = fb * value.D;
            result.M43 = fc * value.D;

            return result;
        }

        /// <summary>Creates a matrix for rotating points around the X axis.</summary>
        /// <param name="radians">The amount, in radians, by which to rotate around the X axis.</param>
        /// <returns>The rotation matrix.</returns>
        public static Matrix4X4F CreateRotationX(float radians)
        {
            Matrix4X4F result = Identity;

            float c = MathF.Cos(radians);
            float s = MathF.Sin(radians);

            // [  1  0  0  0 ]
            // [  0  c  s  0 ]
            // [  0 -s  c  0 ]
            // [  0  0  0  1 ]

            result.M22 = c;
            result.M23 = s;
            result.M32 = -s;
            result.M33 = c;

            return result;
        }

        /// <summary>Creates a matrix for rotating points around the X axis from a center point.</summary>
        /// <param name="radians">The amount, in radians, by which to rotate around the X axis.</param>
        /// <param name="centerPoint">The center point.</param>
        /// <returns>The rotation matrix.</returns>
        public static Matrix4X4F CreateRotationX(float radians, Vector3 centerPoint)
        {
            Matrix4X4F result = Identity;

            float c = MathF.Cos(radians);
            float s = MathF.Sin(radians);

            float y = centerPoint.Y * (1 - c) + centerPoint.Z * s;
            float z = centerPoint.Z * (1 - c) - centerPoint.Y * s;

            // [  1  0  0  0 ]
            // [  0  c  s  0 ]
            // [  0 -s  c  0 ]
            // [  0  y  z  1 ]

            result.M22 = c;
            result.M23 = s;
            result.M32 = -s;
            result.M33 = c;
            result.M42 = y;
            result.M43 = z;

            return result;
        }

        /// <summary>Creates a matrix for rotating points around the Y axis.</summary>
        /// <param name="radians">The amount, in radians, by which to rotate around the Y-axis.</param>
        /// <returns>The rotation matrix.</returns>
        public static Matrix4X4F CreateRotationY(float radians)
        {
            Matrix4X4F result = Identity;

            float c = MathF.Cos(radians);
            float s = MathF.Sin(radians);

            // [  c  0 -s  0 ]
            // [  0  1  0  0 ]
            // [  s  0  c  0 ]
            // [  0  0  0  1 ]
            result.M11 = c;
            result.M13 = -s;
            result.M31 = s;
            result.M33 = c;

            return result;
        }

        /// <summary>The amount, in radians, by which to rotate around the Y axis from a center point.</summary>
        /// <param name="radians">The amount, in radians, by which to rotate around the Y-axis.</param>
        /// <param name="centerPoint">The center point.</param>
        /// <returns>The rotation matrix.</returns>
        public static Matrix4X4F CreateRotationY(float radians, Vector3 centerPoint)
        {
            Matrix4X4F result = Identity;

            float c = MathF.Cos(radians);
            float s = MathF.Sin(radians);

            float x = centerPoint.X * (1 - c) - centerPoint.Z * s;
            float z = centerPoint.Z * (1 - c) + centerPoint.X * s;

            // [  c  0 -s  0 ]
            // [  0  1  0  0 ]
            // [  s  0  c  0 ]
            // [  x  0  z  1 ]
            result.M11 = c;
            result.M13 = -s;
            result.M31 = s;
            result.M33 = c;
            result.M41 = x;
            result.M43 = z;

            return result;
        }

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
            result.M11 = c;
            result.M12 = s;
            result.M21 = -s;
            result.M22 = c;

            return result;
        }

        /// <summary>Creates a matrix for rotating points around the Z axis from a center point.</summary>
        /// <param name="radians">The amount, in radians, by which to rotate around the Z-axis.</param>
        /// <param name="centerPoint">The center point.</param>
        /// <returns>The rotation matrix.</returns>
        public static Matrix4X4F CreateRotationZ(float radians, Vector3 centerPoint)
        {
            Matrix4X4F result = Identity;

            float c = MathF.Cos(radians);
            float s = MathF.Sin(radians);

            float x = centerPoint.X * (1 - c) + centerPoint.Y * s;
            float y = centerPoint.Y * (1 - c) - centerPoint.X * s;

            // [  c  s  0  0 ]
            // [ -s  c  0  0 ]
            // [  0  0  1  0 ]
            // [  x  y  0  1 ]
            result.M11 = c;
            result.M12 = s;
            result.M21 = -s;
            result.M22 = c;
            result.M41 = x;
            result.M42 = y;

            return result;
        }

        /// <summary>Creates a scaling matrix from the specified X, Y, and Z components.</summary>
        /// <param name="xScale">The value to scale by on the X axis.</param>
        /// <param name="yScale">The value to scale by on the Y axis.</param>
        /// <param name="zScale">The value to scale by on the Z axis.</param>
        /// <returns>The scaling matrix.</returns>
        public static Matrix4X4F CreateScale(float xScale, float yScale, float zScale)
        {
            Matrix4X4F result = Identity;
            result.M11 = xScale;
            result.M22 = yScale;
            result.M33 = zScale;
            return result;
        }

        /// <summary>Creates a scaling matrix that is offset by a given center point.</summary>
        /// <param name="xScale">The value to scale by on the X axis.</param>
        /// <param name="yScale">The value to scale by on the Y axis.</param>
        /// <param name="zScale">The value to scale by on the Z axis.</param>
        /// <param name="centerPoint">The center point.</param>
        /// <returns>The scaling matrix.</returns>
        public static Matrix4X4F CreateScale(float xScale, float yScale, float zScale, Vector3 centerPoint)
        {
            Matrix4X4F result = Identity;

            float tx = centerPoint.X * (1 - xScale);
            float ty = centerPoint.Y * (1 - yScale);
            float tz = centerPoint.Z * (1 - zScale);

            result.M11 = xScale;
            result.M22 = yScale;
            result.M33 = zScale;
            result.M41 = tx;
            result.M42 = ty;
            result.M43 = tz;
            return result;
        }

        /// <summary>Creates a scaling matrix from the specified vector scale.</summary>
        /// <param name="scales">The scale to use.</param>
        /// <returns>The scaling matrix.</returns>
        public static Matrix4X4F CreateScale(Vector3 scales)
        {
            Matrix4X4F result = Identity;
            result.M11 = scales.X;
            result.M22 = scales.Y;
            result.M33 = scales.Z;
            return result;
        }

        /// <summary>Creates a scaling matrix with a center point.</summary>
        /// <param name="scales">The vector that contains the amount to scale on each axis.</param>
        /// <param name="centerPoint">The center point.</param>
        /// <returns>The scaling matrix.</returns>
        public static Matrix4X4F CreateScale(Vector3 scales, Vector3 centerPoint)
        {
            Matrix4X4F result = Identity;

            float tx = centerPoint.X * (1 - scales.X);
            float ty = centerPoint.Y * (1 - scales.Y);
            float tz = centerPoint.Z * (1 - scales.Z);

            result.M11 = scales.X;
            result.M22 = scales.Y;
            result.M33 = scales.Z;
            result.M41 = tx;
            result.M42 = ty;
            result.M43 = tz;
            return result;
        }

        /// <summary>Creates a uniform scaling matrix that scale equally on each axis.</summary>
        /// <param name="scale">The uniform scaling factor.</param>
        /// <returns>The scaling matrix.</returns>
        public static Matrix4X4F CreateScale(float scale)
        {
            Matrix4X4F result = Identity;

            result.M11 = scale;
            result.M22 = scale;
            result.M33 = scale;

            return result;
        }

        /// <summary>Creates a uniform scaling matrix that scales equally on each axis with a center point.</summary>
        /// <param name="scale">The uniform scaling factor.</param>
        /// <param name="centerPoint">The center point.</param>
        /// <returns>The scaling matrix.</returns>
        public static Matrix4X4F CreateScale(float scale, Vector3 centerPoint)
        {
            Matrix4X4F result = Identity;

            float tx = centerPoint.X * (1 - scale);
            float ty = centerPoint.Y * (1 - scale);
            float tz = centerPoint.Z * (1 - scale);

            result.M11 = scale;
            result.M22 = scale;
            result.M33 = scale;

            result.M41 = tx;
            result.M42 = ty;
            result.M43 = tz;

            return result;
        }

        /// <summary>
        ///     Creates a matrix that flattens geometry into a specified plane as if casting a shadow from a specified light
        ///     source.
        /// </summary>
        /// <param name="lightDirection">The direction from which the light that will cast the shadow is coming.</param>
        /// <param name="plane">The plane onto which the new matrix should flatten geometry so as to cast a shadow.</param>
        /// <returns>A new matrix that can be used to flatten geometry onto the specified plane from the specified direction.</returns>
        public static Matrix4X4F CreateShadow(Vector3 lightDirection, Plane plane)
        {
            Plane p = Plane.Normalize(plane);

            float dot = p.Normal.X * lightDirection.X + p.Normal.Y * lightDirection.Y + p.Normal.Z * lightDirection.Z;
            float a = -p.Normal.X;
            float b = -p.Normal.Y;
            float c = -p.Normal.Z;
            float d = -p.D;

            Matrix4X4F result = Identity;

            result.M11 = a * lightDirection.X + dot;
            result.M21 = b * lightDirection.X;
            result.M31 = c * lightDirection.X;
            result.M41 = d * lightDirection.X;

            result.M12 = a * lightDirection.Y;
            result.M22 = b * lightDirection.Y + dot;
            result.M32 = c * lightDirection.Y;
            result.M42 = d * lightDirection.Y;

            result.M13 = a * lightDirection.Z;
            result.M23 = b * lightDirection.Z;
            result.M33 = c * lightDirection.Z + dot;
            result.M43 = d * lightDirection.Z;

            result.M44 = dot;

            return result;
        }

        /// <summary>Creates a translation matrix from the specified 3-dimensional vector.</summary>
        /// <param name="position">The amount to translate in each axis.</param>
        /// <returns>The translation matrix.</returns>
        public static Matrix4X4F CreateTranslation(Vector3 position)
        {
            Matrix4X4F result = Identity;
            result.M41 = position.X;
            result.M42 = position.Y;
            result.M43 = position.Z;
            return result;
        }

        /// <summary>Creates a translation matrix from the specified X, Y, and Z components.</summary>
        /// <param name="xPosition">The amount to translate on the X axis.</param>
        /// <param name="yPosition">The amount to translate on the Y axis.</param>
        /// <param name="zPosition">The amount to translate on the Z axis.</param>
        /// <returns>The translation matrix.</returns>
        public static Matrix4X4F CreateTranslation(float xPosition, float yPosition, float zPosition)
        {
            Matrix4X4F result = Identity;
            result.M41 = xPosition;
            result.M42 = yPosition;
            result.M43 = zPosition;
            return result;
        }

        /// <summary>Creates a world matrix with the specified parameters.</summary>
        /// <param name="position">The position of the object.</param>
        /// <param name="forward">The forward direction of the object.</param>
        /// <param name="up">The upward direction of the object. Its value is usually <c>[0, 1, 0]</c>.</param>
        /// <returns>The world matrix.</returns>
        /// <remarks><paramref name="position" /> is used in translation operations.</remarks>
        public static Matrix4X4F CreateWorld(Vector3 position, Vector3 forward, Vector3 up)
        {
            Vector3 zaxis = Vector3.Normalize(-forward);
            Vector3 xaxis = Vector3.Normalize(Vector3.Cross(up, zaxis));
            Vector3 yaxis = Vector3.Cross(zaxis, xaxis);

            Matrix4X4F result = Identity;

            result.M11 = xaxis.X;
            result.M12 = xaxis.Y;
            result.M13 = xaxis.Z;

            result.M21 = yaxis.X;
            result.M22 = yaxis.Y;
            result.M23 = yaxis.Z;

            result.M31 = zaxis.X;
            result.M32 = zaxis.Y;
            result.M33 = zaxis.Z;

            result.M41 = position.X;
            result.M42 = position.Y;
            result.M43 = position.Z;

            return result;
        }

        /// <summary>Multiplies two matrices together to compute the product.</summary>
        /// <param name="value1">The first matrix.</param>
        /// <param name="value2">The second matrix.</param>
        /// <returns>The product matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4X4F Multiply(Matrix4X4F value1, Matrix4X4F value2) => value1 * value2;

        /// <summary>Multiplies a matrix by a float to compute the product.</summary>
        /// <param name="value1">The matrix to scale.</param>
        /// <param name="value2">The scaling value to use.</param>
        /// <returns>The scaled matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4X4F Multiply(Matrix4X4F value1, float value2) => value1 * value2;

        /// <summary>Negates the specified matrix by multiplying all its values by -1.</summary>
        /// <param name="value">The matrix to negate.</param>
        /// <returns>The negated matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4X4F Negate(Matrix4X4F value) => -value;

        /// <summary>Subtracts each element in a second matrix from its corresponding element in a first matrix.</summary>
        /// <param name="value1">The first matrix.</param>
        /// <param name="value2">The second matrix.</param>
        /// <returns>
        ///     The matrix containing the values that result from subtracting each element in <paramref name="value2" /> from
        ///     its corresponding element in <paramref name="value1" />.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix4X4F Subtract(Matrix4X4F value1, Matrix4X4F value2) => value1 - value2;

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

            Matrix4X4F result;

            // First row
            result.M11 = value.M11 * q11 + value.M12 * q21 + value.M13 * q31;
            result.M12 = value.M11 * q12 + value.M12 * q22 + value.M13 * q32;
            result.M13 = value.M11 * q13 + value.M12 * q23 + value.M13 * q33;
            result.M14 = value.M14;

            // Second row
            result.M21 = value.M21 * q11 + value.M22 * q21 + value.M23 * q31;
            result.M22 = value.M21 * q12 + value.M22 * q22 + value.M23 * q32;
            result.M23 = value.M21 * q13 + value.M22 * q23 + value.M23 * q33;
            result.M24 = value.M24;

            // Third row
            result.M31 = value.M31 * q11 + value.M32 * q21 + value.M33 * q31;
            result.M32 = value.M31 * q12 + value.M32 * q22 + value.M33 * q32;
            result.M33 = value.M31 * q13 + value.M32 * q23 + value.M33 * q33;
            result.M34 = value.M34;

            // Fourth row
            result.M41 = value.M41 * q11 + value.M42 * q21 + value.M43 * q31;
            result.M42 = value.M41 * q12 + value.M42 * q22 + value.M43 * q32;
            result.M43 = value.M41 * q13 + value.M42 * q23 + value.M43 * q33;
            result.M44 = value.M44;

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
        public readonly override bool Equals([NotNullWhen(true)] object obj) => obj is Matrix4X4F other && Equals(other);

        /// <summary>Returns a value that indicates whether this instance and another 4x4 matrix are equal.</summary>
        /// <param name="other">The other matrix.</param>
        /// <returns><see langword="true" /> if the two matrices are equal; otherwise, <see langword="false" />.</returns>
        public readonly bool Equals(Matrix4X4F other) => this == other;

        /// <summary>Calculates the determinant of the current 4x4 matrix.</summary>
        /// <returns>The determinant.</returns>
        public readonly float GetDeterminant()
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

            float kp_lo = k * p - l * o;
            float jp_ln = j * p - l * n;
            float jo_kn = j * o - k * n;
            float ip_lm = i * p - l * m;
            float io_km = i * o - k * m;
            float in_jm = i * n - j * m;

            return a * (f * kp_lo - g * jp_ln + h * jo_kn) -
                   b * (e * kp_lo - g * ip_lm + h * io_km) +
                   c * (e * jp_ln - f * ip_lm + h * in_jm) -
                   d * (e * jo_kn - f * io_km + g * in_jm);
        }

        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>The hash code.</returns>
        public readonly override int GetHashCode()
        {
            HashCode hash = default(HashCode);

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

            return hash.ToHashCode();
        }

        /// <summary>Returns a string that represents this matrix.</summary>
        /// <returns>The string representation of this matrix.</returns>
        /// <remarks>
        ///     The numeric values in the returned string are formatted by using the conventions of the current culture. For
        ///     example, for the en-US culture, the returned string might appear as
        ///     <c>
        ///         { {M11:1.1 M12:1.2 M13:1.3 M14:1.4} {M21:2.1 M22:2.2 M23:2.3 M24:2.4} {M31:3.1 M32:3.2 M33:3.3 M34:3.4} {M41:4.1
        ///         M42:4.2 M43:4.3 M44:4.4} }
        ///     </c>
        ///     .
        /// </remarks>
        public readonly override string ToString() =>
            $"{{ {{M11:{M11} M12:{M12} M13:{M13} M14:{M14}}} {{M21:{M21} M22:{M22} M23:{M23} M24:{M24}}} {{M31:{M31} M32:{M32} M33:{M33} M34:{M34}}} {{M41:{M41} M42:{M42} M43:{M43} M44:{M44}}} }}";
    }
}