// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Matrix3X2.cs
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

using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Aspect.Math.Matrix
{
    /// <summary>
    ///     Represents a 3x2 matrix (3 rows, 2 columns) stored in row-major order.
    ///     Commonly used for 2D affine transformations combining rotation, scaling, and translation.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Matrix3X2
    {
        /// <summary>
        ///     The precomputed hash code for this matrix instance.
        /// </summary>
        private readonly int hashCode;

        /// <summary>Creates a 3x2 matrix from the specified components.</summary>
        /// <param name="m11">The value to assign to the first element in the first row.</param>
        /// <param name="m12">The value to assign to the second element in the first row.</param>
        /// <param name="m21">The value to assign to the first element in the second row.</param>
        /// <param name="m22">The value to assign to the second element in the second row.</param>
        /// <param name="m31">The value to assign to the first element in the third row.</param>
        /// <param name="m32">The value to assign to the second element in the third row.</param>
        public Matrix3X2(float m11, float m12,
            float m21, float m22,
            float m31, float m32)
        {
            M11 = m11;
            M12 = m12;

            M21 = m21;
            M22 = m22;

            M31 = m31;
            M32 = m32;

            HashCode hash = new HashCode();
            hash.Add(m11);
            hash.Add(m12);
            hash.Add(m21);
            hash.Add(m22);
            hash.Add(m31);
            hash.Add(m32);
            hashCode = hash.ToHashCode();
        }

        /// <summary>The first element of the first row.</summary>
        public float M11 { get; set; }

        /// <summary>The second element of the first row.</summary>
        public float M12 { get; set; }

        /// <summary>The first element of the second row.</summary>
        public float M21 { get; set; }

        /// <summary>The second element of the second row.</summary>
        public float M22 { get; set; }

        /// <summary>The first element of the third row.</summary>
        public float M31 { get; set; }

        /// <summary>The second element of the third row.</summary>
        public float M32 { get; set; }

        /// <summary>Gets the multiplicative identity matrix (no translation, rotation, or scaling).</summary>
        /// <value>The multiplicative identity matrix.</value>
        private static Matrix3X2 Identity { get; } = new Matrix3X2(
            1f, 0f,
            0f, 1f,
            0f, 0f
        );

        /// <summary>Gets or sets the translation component of this matrix.</summary>
        /// <value>A <see cref="Vector2F" /> representing the X and Y translation values.</value>
        public Vector2F Translation
        {
            get => new Vector2F(M31, M32);
            set
            {
                M31 = value.X;
                M32 = value.Y;
            }
        }

        /// <summary>
        ///     Returns the precomputed hash code for this matrix.
        /// </summary>
        /// <returns>The hash code of this matrix.</returns>
        [ExcludeFromCodeCoverage]
        public override int GetHashCode() => hashCode;

        /// <summary>
        ///     Determines whether this matrix is equal to another <see cref="Matrix3X2" /> instance.
        /// </summary>
        /// <param name="other">The other matrix to compare.</param>
        /// <returns><c>true</c> if all corresponding elements are equal; otherwise, <c>false</c>.</returns>
        [ExcludeFromCodeCoverage]
        private bool Equals(Matrix3X2 other) => M11.Equals(other.M11) && M12.Equals(other.M12) && M21.Equals(other.M21) && M22.Equals(other.M22) && M31.Equals(other.M31) && M32.Equals(other.M32);

        /// <summary>
        ///     Determines whether this matrix is equal to the specified object.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns><c>true</c> if the object is a <see cref="Matrix3X2" /> with equal elements; otherwise, <c>false</c>.</returns>
        [ExcludeFromCodeCoverage]
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (Equals(this, obj))
            {
                return true;
            }

            return (obj.GetType() == GetType()) && Equals((Matrix3X2) obj);
        }

        /// <summary>Adds each element in one matrix with its corresponding element in a second matrix.</summary>
        /// <param name="value1">The first matrix.</param>
        /// <param name="value2">The second matrix.</param>
        /// <returns>The matrix that contains the summed values.</returns>
        public static Matrix3X2 operator +(Matrix3X2 value1, Matrix3X2 value2)
        {
            Matrix3X2 m = Identity;

            m.M11 = value1.M11 + value2.M11;
            m.M12 = value1.M12 + value2.M12;

            m.M21 = value1.M21 + value2.M21;
            m.M22 = value1.M22 + value2.M22;

            m.M31 = value1.M31 + value2.M31;
            m.M32 = value1.M32 + value2.M32;

            return m;
        }

        /// <summary>Returns a value that indicates whether the specified matrices are equal within a tolerance of 0.1.</summary>
        /// <param name="value1">The first matrix to compare.</param>
        /// <param name="value2">The second matrix to compare.</param>
        /// <returns><c>true</c> if the matrices are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Matrix3X2 value1, Matrix3X2 value2) => (System.Math.Abs(value1.M11 - value2.M11) < 0.1f)
                                                                              && (System.Math.Abs(value1.M22 - value2.M22) < 0.1f)
                                                                              && (System.Math.Abs(value1.M12 - value2.M12) < 0.1f)
                                                                              && (System.Math.Abs(value1.M21 - value2.M21) < 0.1f)
                                                                              && (System.Math.Abs(value1.M31 - value2.M31) < 0.1f)
                                                                              && (System.Math.Abs(value1.M32 - value2.M32) < 0.1f);

        /// <summary>Returns a value that indicates whether the specified matrices are not equal.</summary>
        /// <param name="value1">The first matrix to compare.</param>
        /// <param name="value2">The second matrix to compare.</param>
        /// <returns><c>true</c> if the matrices are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Matrix3X2 value1, Matrix3X2 value2) => !(value1 == value2);

        /// <summary>Multiplies two matrices together to compute the product.</summary>
        /// <param name="value1">The first matrix.</param>
        /// <param name="value2">The second matrix.</param>
        /// <returns>The product matrix.</returns>
        public static Matrix3X2 operator *(Matrix3X2 value1, Matrix3X2 value2)
        {
            Matrix3X2 m = Identity;

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

        /// <summary>Multiplies a matrix by a scalar value.</summary>
        /// <param name="value1">The matrix to scale.</param>
        /// <param name="value2">The scaling value.</param>
        /// <returns>The scaled matrix.</returns>
        public static Matrix3X2 operator *(Matrix3X2 value1, float value2)
        {
            Matrix3X2 m = Identity;

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
        /// <returns>The matrix containing the difference.</returns>
        public static Matrix3X2 operator -(Matrix3X2 value1, Matrix3X2 value2)
        {
            Matrix3X2 m = Identity;

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
        public static Matrix3X2 operator -(Matrix3X2 value)
        {
            Matrix3X2 m = Identity;

            m.M11 = -value.M11;
            m.M12 = -value.M12;

            m.M21 = -value.M21;
            m.M22 = -value.M22;

            m.M31 = -value.M31;
            m.M32 = -value.M32;

            return m;
        }

        /// <summary>Adds two matrices together and returns the result.</summary>
        /// <param name="value1">The first matrix.</param>
        /// <param name="value2">The second matrix.</param>
        /// <returns>The summed matrix.</returns>
        public static Matrix3X2 Add(Matrix3X2 value1, Matrix3X2 value2) => value1 + value2;


        /// <summary>Creates a scaling matrix from the specified vector scale.</summary>
        /// <param name="scales">The scale factors for X and Y axes.</param>
        /// <returns>The scaling matrix.</returns>
        [ExcludeFromCodeCoverage]
        public static Matrix3X2 CreateScale(Vector2F scales)
        {
            Matrix3X2 result = Identity;

            result.M11 = scales.X;
            result.M22 = scales.Y;

            return result;
        }

        /// <summary>Creates a scaling matrix from the specified X and Y components.</summary>
        /// <param name="xScale">The value to scale by on the X axis.</param>
        /// <param name="yScale">The value to scale by on the Y axis.</param>
        /// <returns>The scaling matrix.</returns>
        [ExcludeFromCodeCoverage]
        public static Matrix3X2 CreateScale(float xScale, float yScale)
        {
            Matrix3X2 result = Identity;

            result.M11 = xScale;
            result.M22 = yScale;

            return result;
        }


        /// <summary>
        ///     Computes the determinant of this matrix.
        /// </summary>
        /// <returns>The determinant of the 2x2 submatrix (rows 1-2, columns 1-2).</returns>
        public float GetDeterminant() =>
            M11 * M22 - M21 * M12;


        /// <summary>
        ///     Returns a string representation of this matrix.
        /// </summary>
        /// <returns>A string in the format "{{M11:... M12:...} {M21:... M22:...} {M31:... M32:...}}".</returns>
        public override string ToString() =>
            $"{{ {{M11:{M11} M12:{M12}}} {{M21:{M21} M22:{M22}}} {{M31:{M31} M32:{M32}}} }}";
    }
}
