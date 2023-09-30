// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Matrix3X2F.cs
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

using System.Runtime.CompilerServices;
using Alis.Core.Aspect.Math.Util;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Aspect.Math.Matrix
{
    /// <summary>
    ///     The matrix 3x class
    /// </summary>
    public class Matrix3X2F
    {
        /// <summary>
        ///     The pi
        /// </summary>
        private const float RotationEpsilon = 0.001f * MathF.Pi / 180f; // 0.1% of a degree

        /// <summary>
        ///     The hash
        /// </summary>
        private readonly HashCode hash;

        /// <summary>
        ///     The hash code
        /// </summary>
        private readonly int hashCode;

        /// <summary>The first element of the first row.</summary>
        public float M11;

        /// <summary>The second element of the first row.</summary>
        public float M12;

        /// <summary>The first element of the second row.</summary>
        public float M21;

        /// <summary>The second element of the second row.</summary>
        public float M22;

        /// <summary>The first element of the third row.</summary>
        public float M31;

        /// <summary>The second element of the third row.</summary>
        public float M32;

        /// <summary>Creates a 3x2 matrix from the specified components.</summary>
        /// <param name="m11">The value to assign to the first element in the first row.</param>
        /// <param name="m12">The value to assign to the second element in the first row.</param>
        /// <param name="m21">The value to assign to the first element in the second row.</param>
        /// <param name="m22">The value to assign to the second element in the second row.</param>
        /// <param name="m31">The value to assign to the first element in the third row.</param>
        /// <param name="m32">The value to assign to the second element in the third row.</param>
        public Matrix3X2F(float m11, float m12,
            float m21, float m22,
            float m31, float m32)
        {
            M11 = m11;
            M12 = m12;

            M21 = m21;
            M22 = m22;

            M31 = m31;
            M32 = m32;

            hash = new HashCode();
            hash.Add(m11);
            hash.Add(m12);
            hash.Add(m21);
            hash.Add(m22);
            hash.Add(m31);
            hash.Add(m32);
            hashCode = hash.ToHashCode();
        }

        /// <summary>Gets the multiplicative identity matrix.</summary>
        /// <value>The multiplicative identify matrix.</value>
        public static Matrix3X2F Identity { get; } = new Matrix3X2F(
            1f, 0f,
            0f, 1f,
            0f, 0f
        );

        /// <summary>Gets a value that indicates whether the current matrix is the identity matrix.</summary>
        /// <value><see langword="true" /> if the current matrix is the identity matrix; otherwise, <see langword="false" />.</value>
        public bool IsIdentity => this == Identity;

        /// <summary>Gets or sets the translation component of this matrix.</summary>
        /// <value>The translation component of the current instance.</value>
        public Vector2 Translation
        {
            get => new Vector2(M31, M32);

            set
            {
                M31 = value.X;
                M32 = value.Y;
            }
        }

        /// <summary>
        ///     Gets the hash code
        /// </summary>
        /// <returns>The int</returns>
        public override int GetHashCode() => hashCode;

        /// <summary>
        ///     Describes whether this instance equals
        /// </summary>
        /// <param name="other">The other</param>
        /// <returns>The bool</returns>
        protected bool Equals(Matrix3X2F other) => M11.Equals(other.M11) && M12.Equals(other.M12) && M21.Equals(other.M21) && M22.Equals(other.M22) && M31.Equals(other.M31) && M32.Equals(other.M32);

        /// <summary>
        ///     Describes whether this instance equals
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <returns>The bool</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((Matrix3X2F) obj);
        }

        /// <summary>Adds each element in one matrix with its corresponding element in a second matrix.</summary>
        /// <param name="value1">The first matrix.</param>
        /// <param name="value2">The second matrix.</param>
        /// <returns>The matrix that contains the summed values.</returns>
        /// <remarks>
        ///     The <see cref="Matrix3X2F.op_Addition" /> method defines the operation of the addition operator for
        ///     <see cref="Matrix3X2F" /> objects.
        /// </remarks>
        public static Matrix3X2F operator +(Matrix3X2F value1, Matrix3X2F value2)
        {
            Matrix3X2F m = Identity;

            m.M11 = value1.M11 + value2.M11;
            m.M12 = value1.M12 + value2.M12;

            m.M21 = value1.M21 + value2.M21;
            m.M22 = value1.M22 + value2.M22;

            m.M31 = value1.M31 + value2.M31;
            m.M32 = value1.M32 + value2.M32;

            return m;
        }

        /// <summary>Returns a value that indicates whether the specified matrices are equal.</summary>
        /// <param name="value1">The first matrix to compare.</param>
        /// <param name="value2">The second matrix to compare.</param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="value1" /> and <paramref name="value2" /> are equal; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        /// <remarks>Two matrices are equal if all their corresponding elements are equal.</remarks>
        public static bool operator ==(Matrix3X2F value1, Matrix3X2F value2) =>
            // Check diagonal element first for early out.
            (value1.M11 == value2.M11)
            && (value1.M22 == value2.M22)
            && (value1.M12 == value2.M12)
            && (value1.M21 == value2.M21)
            && (value1.M31 == value2.M31)
            && (value1.M32 == value2.M32);

        /// <summary>Returns a value that indicates whether the specified matrices are not equal.</summary>
        /// <param name="value1">The first matrix to compare.</param>
        /// <param name="value2">The second matrix to compare.</param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="value1" /> and <paramref name="value2" /> are not equal; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        public static bool operator !=(Matrix3X2F value1, Matrix3X2F value2) => !(value1 == value2);

        /// <summary>Multiplies two matrices together to compute the product.</summary>
        /// <param name="value1">The first matrix.</param>
        /// <param name="value2">The second matrix.</param>
        /// <returns>The product matrix.</returns>
        public static Matrix3X2F operator *(Matrix3X2F value1, Matrix3X2F value2)
        {
            Matrix3X2F m = Identity;

            // First row
            m.M11 = value1.M11 * value2.M11 + value1.M12 * value2.M21;
            m.M12 = value1.M11 * value2.M12 + value1.M12 * value2.M22;

            // Second row
            m.M21 = value1.M21 * value2.M11 + value1.M22 * value2.M21;
            m.M22 = value1.M21 * value2.M12 + value1.M22 * value2.M22;

            // Third row
            m.M31 = value1.M31 * value2.M11 + value1.M32 * value2.M21 + value2.M31;
            m.M32 = value1.M31 * value2.M12 + value1.M32 * value2.M22 + value2.M32;

            return m;
        }

        /// <summary>Multiplies a matrix by a float to compute the product.</summary>
        /// <param name="value1">The matrix to scale.</param>
        /// <param name="value2">The scaling value to use.</param>
        /// <returns>The scaled matrix.</returns>
        public static Matrix3X2F operator *(Matrix3X2F value1, float value2)
        {
            Matrix3X2F m = Identity;

            m.M11 = value1.M11 * value2;
            m.M12 = value1.M12 * value2;

            m.M21 = value1.M21 * value2;
            m.M22 = value1.M22 * value2;

            m.M31 = value1.M31 * value2;
            m.M32 = value1.M32 * value2;

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
        ///     The <see cref="Matrix3X2F.Subtract" /> method defines the operation of the subtraction operator for
        ///     <see cref="Matrix3X2F" /> objects.
        /// </remarks>
        public static Matrix3X2F operator -(Matrix3X2F value1, Matrix3X2F value2)
        {
            Matrix3X2F m = Identity;

            m.M11 = value1.M11 - value2.M11;
            m.M12 = value1.M12 - value2.M12;

            m.M21 = value1.M21 - value2.M21;
            m.M22 = value1.M22 - value2.M22;

            m.M31 = value1.M31 - value2.M31;
            m.M32 = value1.M32 - value2.M32;

            return m;
        }

        /// <summary>Negates the specified matrix by multiplying all its values by -1.</summary>
        /// <param name="value">The matrix to negate.</param>
        /// <returns>The negated matrix.</returns>
        public static Matrix3X2F operator -(Matrix3X2F value)
        {
            Matrix3X2F m = Identity;

            m.M11 = -value.M11;
            m.M12 = -value.M12;

            m.M21 = -value.M21;
            m.M22 = -value.M22;

            m.M31 = -value.M31;
            m.M32 = -value.M32;

            return m;
        }

        /// <summary>Adds each element in one matrix with its corresponding element in a second matrix.</summary>
        /// <param name="value1">The first matrix.</param>
        /// <param name="value2">The second matrix.</param>
        /// <returns>The matrix that contains the summed values of <paramref name="value1" /> and <paramref name="value2" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3X2F Add(Matrix3X2F value1, Matrix3X2F value2) => value1 + value2;


        /// <summary>Creates a scaling matrix from the specified vector scale.</summary>
        /// <param name="scales">The scale to use.</param>
        /// <returns>The scaling matrix.</returns>
        public static Matrix3X2F CreateScale(Vector2 scales)
        {
            Matrix3X2F result = Identity;

            result.M11 = scales.X;
            result.M22 = scales.Y;

            return result;
        }

        /// <summary>Creates a scaling matrix from the specified X and Y components.</summary>
        /// <param name="xScale">The value to scale by on the X axis.</param>
        /// <param name="yScale">The value to scale by on the Y axis.</param>
        /// <returns>The scaling matrix.</returns>
        public static Matrix3X2F CreateScale(float xScale, float yScale)
        {
            Matrix3X2F result = Identity;

            result.M11 = xScale;
            result.M22 = yScale;

            return result;
        }

        /// <summary>Creates a scaling matrix that is offset by a given center point.</summary>
        /// <param name="xScale">The value to scale by on the X axis.</param>
        /// <param name="yScale">The value to scale by on the Y axis.</param>
        /// <param name="centerPoint">The center point.</param>
        /// <returns>The scaling matrix.</returns>
        public static Matrix3X2F CreateScale(float xScale, float yScale, Vector2 centerPoint)
        {
            Matrix3X2F result = Identity;

            float tx = centerPoint.X * (1 - xScale);
            float ty = centerPoint.Y * (1 - yScale);

            result.M11 = xScale;
            result.M22 = yScale;
            result.M31 = tx;
            result.M32 = ty;

            return result;
        }

        /// <summary>Creates a scaling matrix from the specified vector scale with an offset from the specified center point.</summary>
        /// <param name="scales">The scale to use.</param>
        /// <param name="centerPoint">The center offset.</param>
        /// <returns>The scaling matrix.</returns>
        public static Matrix3X2F CreateScale(Vector2 scales, Vector2 centerPoint)
        {
            Matrix3X2F result = Identity;

            float tx = centerPoint.X * (1 - scales.X);
            float ty = centerPoint.Y * (1 - scales.Y);

            result.M11 = scales.X;
            result.M22 = scales.Y;
            result.M31 = tx;
            result.M32 = ty;

            return result;
        }

        /// <summary>Creates a scaling matrix that scales uniformly with the given scale.</summary>
        /// <param name="scale">The uniform scale to use.</param>
        /// <returns>The scaling matrix.</returns>
        public static Matrix3X2F CreateScale(float scale)
        {
            Matrix3X2F result = Identity;

            result.M11 = scale;
            result.M22 = scale;

            return result;
        }

        /// <summary>
        ///     Creates a scaling matrix that scales uniformly with the specified scale with an offset from the specified
        ///     center.
        /// </summary>
        /// <param name="scale">The uniform scale to use.</param>
        /// <param name="centerPoint">The center offset.</param>
        /// <returns>The scaling matrix.</returns>
        public static Matrix3X2F CreateScale(float scale, Vector2 centerPoint)
        {
            Matrix3X2F result = Identity;

            float tx = centerPoint.X * (1 - scale);
            float ty = centerPoint.Y * (1 - scale);

            result.M11 = scale;
            result.M22 = scale;
            result.M31 = tx;
            result.M32 = ty;

            return result;
        }

        /// <summary>Creates a translation matrix from the specified 2-dimensional vector.</summary>
        /// <param name="position">The translation position.</param>
        /// <returns>The translation matrix.</returns>
        public static Matrix3X2F CreateTranslation(Vector2 position)
        {
            Matrix3X2F result = Identity;

            result.M31 = position.X;
            result.M32 = position.Y;

            return result;
        }

        /// <summary>Creates a translation matrix from the specified X and Y components.</summary>
        /// <param name="xPosition">The X position.</param>
        /// <param name="yPosition">The Y position.</param>
        /// <returns>The translation matrix.</returns>
        public static Matrix3X2F CreateTranslation(float xPosition, float yPosition)
        {
            Matrix3X2F result = Identity;

            result.M31 = xPosition;
            result.M32 = yPosition;

            return result;
        }

        /// <summary>Tries to invert the specified matrix. The return value indicates whether the operation succeeded.</summary>
        /// <param name="matrix">The matrix to invert.</param>
        /// <param name="result">When this method returns, contains the inverted matrix if the operation succeeded.</param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="matrix" /> was converted successfully; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        public static bool Invert(Matrix3X2F matrix, out Matrix3X2F result)
        {
            float det = matrix.M11 * matrix.M22 - matrix.M21 * matrix.M12;

            result = Identity;

            if (MathF.Abs(det) < float.Epsilon)
            {
                result = new Matrix3X2F(float.NaN, float.NaN, float.NaN, float.NaN, float.NaN, float.NaN);
                return false;
            }

            float invDet = 1.0f / det;

            result.M11 = matrix.M22 * invDet;
            result.M12 = -matrix.M12 * invDet;

            result.M21 = -matrix.M21 * invDet;
            result.M22 = matrix.M11 * invDet;

            result.M31 = (matrix.M21 * matrix.M32 - matrix.M31 * matrix.M22) * invDet;
            result.M32 = (matrix.M31 * matrix.M12 - matrix.M11 * matrix.M32) * invDet;

            return true;
        }

        /// <summary>
        ///     Performs a linear interpolation from one matrix to a second matrix based on a value that specifies the
        ///     weighting of the second matrix.
        /// </summary>
        /// <param name="matrix1">The first matrix.</param>
        /// <param name="matrix2">The second matrix.</param>
        /// <param name="amount">The relative weighting of <paramref name="matrix2" />.</param>
        /// <returns>The interpolated matrix.</returns>
        public static Matrix3X2F Lerp(Matrix3X2F matrix1, Matrix3X2F matrix2, float amount)
        {
            Matrix3X2F result = Identity;

            // First row
            result.M11 = matrix1.M11 + (matrix2.M11 - matrix1.M11) * amount;
            result.M12 = matrix1.M12 + (matrix2.M12 - matrix1.M12) * amount;

            // Second row
            result.M21 = matrix1.M21 + (matrix2.M21 - matrix1.M21) * amount;
            result.M22 = matrix1.M22 + (matrix2.M22 - matrix1.M22) * amount;

            // Third row
            result.M31 = matrix1.M31 + (matrix2.M31 - matrix1.M31) * amount;
            result.M32 = matrix1.M32 + (matrix2.M32 - matrix1.M32) * amount;

            return result;
        }

        /// <summary>Multiplies two matrices together to compute the product.</summary>
        /// <param name="value1">The first matrix.</param>
        /// <param name="value2">The second matrix.</param>
        /// <returns>The product matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3X2F Multiply(Matrix3X2F value1, Matrix3X2F value2) => value1 * value2;

        /// <summary>Multiplies a matrix by a float to compute the product.</summary>
        /// <param name="value1">The matrix to scale.</param>
        /// <param name="value2">The scaling value to use.</param>
        /// <returns>The scaled matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3X2F Multiply(Matrix3X2F value1, float value2) => value1 * value2;

        /// <summary>Negates the specified matrix by multiplying all its values by -1.</summary>
        /// <param name="value">The matrix to negate.</param>
        /// <returns>The negated matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3X2F Negate(Matrix3X2F value) => -value;

        /// <summary>Subtracts each element in a second matrix from its corresponding element in a first matrix.</summary>
        /// <param name="value1">The first matrix.</param>
        /// <param name="value2">The second matrix.</param>
        /// <returns>
        ///     The matrix containing the values that result from subtracting each element in <paramref name="value2" /> from
        ///     its corresponding element in <paramref name="value1" />.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix3X2F Subtract(Matrix3X2F value1, Matrix3X2F value2) => value1 - value2;

        /// <summary>Calculates the determinant for this matrix.</summary>
        /// <returns>The determinant.</returns>
        /// <remarks>The determinant is calculated by expanding the matrix with a third column whose values are (0,0,1).</remarks>
        public float GetDeterminant() =>
            // There isn't actually any such thing as a determinant for a non-square matrix,
            // but this 3x2 type is really just an optimization of a 3x3 where we happen to
            // know the rightmost column is always (0, 0, 1). So we expand to 3x3 format:
            //
            //  [ M11, M12, 0 ]
            //  [ M21, M22, 0 ]
            //  [ M31, M32, 1 ]
            //
            // Sum the diagonal products:
            //  (M11 * M22 * 1) + (M12 * 0 * M31) + (0 * M21 * M32)
            //
            // Subtract the opposite diagonal products:
            //  (M31 * M22 * 0) + (M32 * 0 * M11) + (1 * M21 * M12)
            //
            // Collapse out the constants and oh look, this is just a 2x2 determinant!
            M11 * M22 - M21 * M12;


        /// <summary>Returns a string that represents this matrix.</summary>
        /// <returns>The string representation of this matrix.</returns>
        /// <remarks>
        ///     The numeric values in the returned string are formatted by using the conventions of the current culture. For
        ///     example, for the en-US culture, the returned string might appear as
        ///     <c>{ {M11:1.1 M12:1.2} {M21:2.1 M22:2.2} {M31:3.1 M32:3.2} }</c>.
        /// </remarks>
        public override string ToString() =>
            $"{{ {{M11:{M11} M12:{M12}}} {{M21:{M21} M22:{M22}}} {{M31:{M31} M32:{M32}}} }}";
    }
}