// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Vector2F.cs
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
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Util;

namespace Alis.Core.Aspect.Math.Vector
{
    /// <summary>
    ///     Represents a 2D vector with single-precision floating-point X and Y components.
    ///     Provides standard vector operations such as addition, subtraction, dot product, normalization,
    ///     transformation, distance calculation, and linear interpolation.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2F : IEquatable<Vector2F>, IFormattable, ISerializable
    {
        /// <summary>The X component of the vector.</summary>
        public float X { get; set; }

        /// <summary>The Y component of the vector.</summary>
        public float Y { get; set; }

        /// <summary>Creates a new <see cref="Vector2F" /> object whose two elements have the same value.</summary>
        /// <param name="value">The value to assign to both X and Y components.</param>
        public Vector2F(float value) : this(value, value)
        {
        }

        /// <summary>Creates a vector whose elements have the specified values.</summary>
        /// <param name="x">The value to assign to the <see cref="X" /> component.</param>
        /// <param name="y">The value to assign to the <see cref="Y" /> component.</param>
        public Vector2F(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>Returns a vector whose two elements are equal to zero.</summary>
        /// <value>A vector with both components set to zero: <c>(0, 0)</c>.</value>
        public static Vector2F Zero => default(Vector2F);

        /// <summary>Gets a vector whose two elements are equal to one.</summary>
        /// <value>A vector with both components set to one: <c>(1, 1)</c>.</value>
        public static Vector2F One => new Vector2F(1.0f);

        /// <summary>Gets the unit vector for the X axis.</summary>
        /// <value>The vector <c>(1, 0)</c>.</value>
        public static Vector2F UnitX => new Vector2F(1.0f, 0.0f);

        /// <summary>Gets the unit vector for the Y axis.</summary>
        /// <value>The vector <c>(0, 1)</c>.</value>
        public static Vector2F UnitY => new Vector2F(0.0f, 1.0f);

        /// <summary>Adds two vectors together component-wise.</summary>
        /// <param name="left">The first vector to add.</param>
        /// <param name="right">The second vector to add.</param>
        /// <returns>The summed vector.</returns>
        public static Vector2F operator +(Vector2F left, Vector2F right) => new Vector2F(
            left.X + right.X,
            left.Y + right.Y
        );

        /// <summary>Divides the first vector by the second component-wise.</summary>
        /// <param name="left">The dividend vector.</param>
        /// <param name="right">The divisor vector.</param>
        /// <returns>The component-wise quotient vector.</returns>
        public static Vector2F operator /(Vector2F left, Vector2F right) => new Vector2F(
            left.X / right.X,
            left.Y / right.Y
        );

        /// <summary>Divides the specified vector by a scalar value.</summary>
        /// <param name="value1">The vector.</param>
        /// <param name="value2">The scalar divisor.</param>
        /// <returns>The scaled result.</returns>
        public static Vector2F operator /(Vector2F value1, float value2) => value1 / new Vector2F(value2);

        /// <summary>Returns a value that indicates whether each pair of elements in two specified vectors is equal within a tolerance of 0.01.</summary>
        /// <param name="left">The first vector to compare.</param>
        /// <param name="right">The second vector to compare.</param>
        /// <returns><c>true</c> if equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Vector2F left, Vector2F right) => (System.Math.Abs(left.X - right.X) < 0.01f)
                                                                         && (System.Math.Abs(left.Y - right.Y) < 0.01f);

        /// <summary>Returns a value that indicates whether two specified vectors are not equal.</summary>
        /// <param name="left">The first vector to compare.</param>
        /// <param name="right">The second vector to compare.</param>
        /// <returns><c>true</c> if not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Vector2F left, Vector2F right) => !(left == right);

        /// <summary>Returns a new vector whose values are the component-wise product of two specified vectors.</summary>
        /// <param name="left">The first vector.</param>
        /// <param name="right">The second vector.</param>
        /// <returns>The element-wise product vector.</returns>
        public static Vector2F operator *(Vector2F left, Vector2F right) => new Vector2F(
            left.X * right.X,
            left.Y * right.Y
        );

        /// <summary>Multiplies the specified vector by a scalar value.</summary>
        /// <param name="left">The vector.</param>
        /// <param name="right">The scalar multiplier.</param>
        /// <returns>The scaled vector.</returns>
        public static Vector2F operator *(Vector2F left, float right) => left * new Vector2F(right);

        /// <summary>Multiplies a scalar value by the specified vector.</summary>
        /// <param name="left">The scalar multiplier.</param>
        /// <param name="right">The vector.</param>
        /// <returns>The scaled vector.</returns>
        public static Vector2F operator *(float left, Vector2F right) => right * left;

        /// <summary>Subtracts the second vector from the first component-wise.</summary>
        /// <param name="left">The first vector.</param>
        /// <param name="right">The second vector.</param>
        /// <returns>The difference vector.</returns>
        public static Vector2F operator -(Vector2F left, Vector2F right) => new Vector2F(
            left.X - right.X,
            left.Y - right.Y
        );

        /// <summary>Negates the specified vector.</summary>
        /// <param name="value">The vector to negate.</param>
        /// <returns>The negated vector.</returns>
        public static Vector2F operator -(Vector2F value) => Zero - value;

        /// <summary>Returns a vector whose elements are the absolute values of each of the specified vector's elements.</summary>
        /// <param name="value">The source vector.</param>
        /// <returns>The absolute value vector.</returns>
        public static Vector2F Abs(Vector2F value) => new Vector2F(
            System.Math.Abs(value.X),
            System.Math.Abs(value.Y)
        );

        /// <summary>Adds two vectors together.</summary>
        /// <param name="left">The first vector to add.</param>
        /// <param name="right">The second vector to add.</param>
        /// <returns>The summed vector.</returns>
        public static Vector2F Add(Vector2F left, Vector2F right) => left + right;

        /// <summary>Restricts a vector between a minimum and a maximum value.</summary>
        /// <param name="value1">The vector to restrict.</param>
        /// <param name="min">The minimum value vector.</param>
        /// <param name="max">The maximum value vector.</param>
        /// <returns>The clamped vector within the inclusive range [<paramref name="min" />, <paramref name="max" />].</returns>
        public static Vector2F Clamp(Vector2F value1, Vector2F min, Vector2F max) =>
            Min(Max(value1, min), max);

        /// <summary>Computes the Euclidean distance between two points.</summary>
        /// <param name="value1">The first point.</param>
        /// <param name="value2">The second point.</param>
        /// <returns>The Euclidean distance.</returns>
        public static float Distance(Vector2F value1, Vector2F value2)
        {
            float distanceSquared = DistanceSquared(value1, value2);
            return (float) System.Math.Sqrt(distanceSquared);
        }

        /// <summary>Returns the Euclidean distance squared between two points. This is faster than <see cref="Distance" /> as it avoids a square root.</summary>
        /// <param name="value1">The first point.</param>
        /// <param name="value2">The second point.</param>
        /// <returns>The squared distance.</returns>
        public static float DistanceSquared(Vector2F value1, Vector2F value2)
        {
            Vector2F difference = value1 - value2;
            return Dot(difference, difference);
        }

        /// <summary>Divides the first vector by the second component-wise.</summary>
        /// <param name="left">The dividend vector.</param>
        /// <param name="right">The divisor vector.</param>
        /// <returns>The quotient vector.</returns>
        public static Vector2F Divide(Vector2F left, Vector2F right) => left / right;

        /// <summary>Divides the specified vector by a scalar value.</summary>
        /// <param name="left">The vector.</param>
        /// <param name="divisor">The scalar divisor.</param>
        /// <returns>The scaled vector.</returns>
        public static Vector2F Divide(Vector2F left, float divisor) => left / divisor;

        /// <summary>Returns the dot product of two vectors.</summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>The dot product (scalar).</returns>
        public static float Dot(Vector2F value1, Vector2F value2) => value1.X * value2.X
                                                                     + value1.Y * value2.Y;

        /// <summary>Performs a linear interpolation between two vectors based on the given weighting.</summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <param name="amount">A value between 0 and 1 that indicates the weight of <paramref name="value2" />.</param>
        /// <returns>The interpolated vector.</returns>
        public static Vector2F LerP(Vector2F value1, Vector2F value2, float amount) => value1 * (1.0f - amount) + value2 * amount;

        /// <summary>Returns a vector whose elements are the maximum of each of the pairs of elements in two specified vectors.</summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>The component-wise maximum vector.</returns>
        public static Vector2F Max(Vector2F value1, Vector2F value2) => new Vector2F(
            value1.X > value2.X ? value1.X : value2.X,
            value1.Y > value2.Y ? value1.Y : value2.Y
        );

        /// <summary>Returns a vector whose elements are the minimum of each of the pairs of elements in two specified vectors.</summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>The component-wise minimum vector.</returns>
        public static Vector2F Min(Vector2F value1, Vector2F value2) => new Vector2F(
            value1.X < value2.X ? value1.X : value2.X,
            value1.Y < value2.Y ? value1.Y : value2.Y
        );

        /// <summary>Returns a new vector whose values are the component-wise product of two specified vectors.</summary>
        /// <param name="left">The first vector.</param>
        /// <param name="right">The second vector.</param>
        /// <returns>The element-wise product vector.</returns>
        public static Vector2F Multiply(Vector2F left, Vector2F right) => left * right;

        /// <summary>Multiplies a vector by a scalar value.</summary>
        /// <param name="left">The vector to multiply.</param>
        /// <param name="right">The scalar value.</param>
        /// <returns>The scaled vector.</returns>
        public static Vector2F Multiply(Vector2F left, float right) => left * right;

        /// <summary>Multiplies a scalar value by a specified vector.</summary>
        /// <param name="left">The scalar value.</param>
        /// <param name="right">The vector.</param>
        /// <returns>The scaled vector.</returns>
        public static Vector2F Multiply(float left, Vector2F right) => left * right;

        /// <summary>Negates a specified vector.</summary>
        /// <param name="value">The vector to negate.</param>
        /// <returns>The negated vector.</returns>
        public static Vector2F Negate(Vector2F value) => -value;

        /// <summary>Returns a vector with the same direction as the specified vector, but with a length of one.</summary>
        /// <param name="value">The vector to normalize.</param>
        /// <returns>The normalized unit vector.</returns>
        public static Vector2F Normalize(Vector2F value) => value / value.Length();

        /// <summary>Returns the reflection of a vector off a surface that has the specified normal.</summary>
        /// <param name="vector">The source vector.</param>
        /// <param name="normal">The normal of the surface being reflected off.</param>
        /// <returns>The reflected vector.</returns>
        public static Vector2F Reflect(Vector2F vector, Vector2F normal)
        {
            float dot = Dot(vector, normal);
            return vector - 2 * dot * normal;
        }

        /// <summary>Returns a vector whose elements are the square root of each of a specified vector's elements.</summary>
        /// <param name="value">The source vector.</param>
        /// <returns>The square root vector.</returns>
        public static Vector2F SquareRoot(Vector2F value) => new Vector2F(
            (float) System.Math.Sqrt(value.X),
            (float) System.Math.Sqrt(value.Y)
        );

        /// <summary>Subtracts the second vector from the first.</summary>
        /// <param name="left">The first vector.</param>
        /// <param name="right">The second vector.</param>
        /// <returns>The difference vector.</returns>
        public static Vector2F Subtract(Vector2F left, Vector2F right) => left - right;

        /// <summary>Transforms a vector by a specified 3x2 matrix (affine transformation).</summary>
        /// <param name="position">The vector to transform.</param>
        /// <param name="matrix">The transformation matrix.</param>
        /// <returns>The transformed vector.</returns>
        public static Vector2F Transform(Vector2F position, Matrix3X2 matrix) => new Vector2F(
            position.X * matrix.M11 + position.Y * matrix.M21 + matrix.M31,
            position.X * matrix.M12 + position.Y * matrix.M22 + matrix.M32
        );

        /// <summary>Transforms a vector by a specified 4x4 matrix.</summary>
        /// <param name="position">The vector to transform.</param>
        /// <param name="matrix">The transformation matrix.</param>
        /// <returns>The transformed vector.</returns>
        public static Vector2F Transform(Vector2F position, Matrix4X4 matrix) => new Vector2F(
            position.X * matrix.M11 + position.Y * matrix.M21 + matrix.M41,
            position.X * matrix.M12 + position.Y * matrix.M22 + matrix.M42
        );

        /// <summary>Transforms a vector by the specified quaternion rotation.</summary>
        /// <param name="value">The vector to rotate.</param>
        /// <param name="rotation">The quaternion representing the rotation.</param>
        /// <returns>The rotated vector.</returns>
        public static Vector2F Transform(Vector2F value, Quaternion rotation)
        {
            float x2 = rotation.X + rotation.X;
            float y2 = rotation.Y + rotation.Y;
            float z2 = rotation.Z + rotation.Z;

            float wz2 = rotation.W * z2;
            float xx2 = rotation.X * x2;
            float xy2 = rotation.X * y2;
            float yy2 = rotation.Y * y2;
            float zz2 = rotation.Z * z2;

            return new Vector2F(
                value.X * (1.0f - yy2 - zz2) + value.Y * (xy2 - wz2),
                value.X * (xy2 + wz2) + value.Y * (1.0f - xx2 - zz2)
            );
        }

        /// <summary>Transforms a vector normal by the given 3x2 matrix (ignores translation).</summary>
        /// <param name="normal">The source normal vector.</param>
        /// <param name="matrix">The transformation matrix.</param>
        /// <returns>The transformed normal.</returns>
        public static Vector2F TransformNormal(Vector2F normal, Matrix3X2 matrix) => new Vector2F(
            normal.X * matrix.M11 + normal.Y * matrix.M21,
            normal.X * matrix.M12 + normal.Y * matrix.M22
        );

        /// <summary>Transforms a vector normal by the given 4x4 matrix (ignores translation).</summary>
        /// <param name="normal">The source normal vector.</param>
        /// <param name="matrix">The transformation matrix.</param>
        /// <returns>The transformed normal.</returns>
        public static Vector2F TransformNormal(Vector2F normal, Matrix4X4 matrix) => new Vector2F(
            normal.X * matrix.M11 + normal.Y * matrix.M21,
            normal.X * matrix.M12 + normal.Y * matrix.M22
        );

        /// <summary>Copies the vector elements to a specified array starting at a specified index.</summary>
        /// <param name="array">The destination array.</param>
        /// <param name="index">The index at which to copy the first element.</param>
        /// <exception cref="NullReferenceException">Thrown when <paramref name="array" /> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="index" /> is less than zero or greater than or equal to the array length.</exception>
        /// <exception cref="ArgumentException">Thrown when the array does not have enough space for two elements starting at <paramref name="index" />.</exception>
        public void CopyTo(float[] array, int index = 0)
        {
            if (array is null)
            {
                throw new NullReferenceException();
            }

            if (index < 0 || index >= array.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (array.Length - index < 2)
            {
                throw new ArgumentException("Arg_ElementsInSourceIsGreaterThanDestination");
            }

            array[index] = X;
            array[index + 1] = Y;
        }

        /// <summary>Returns a value that indicates whether this instance and a specified object are equal.</summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns><c>true</c> if equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj) => obj is Vector2F other && Equals(other);

        /// <summary>Returns a value that indicates whether this instance and another vector are equal.</summary>
        /// <param name="other">The other vector.</param>
        /// <returns><c>true</c> if equal; otherwise, <c>false</c>.</returns>
        public bool Equals(Vector2F other) => this == other;

        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>A hash code computed from the X and Y components.</returns>
        public override int GetHashCode() => HashCode.Combine(X, Y);

        /// <summary>
        ///     Populates a <see cref="SerializationInfo" /> with the vector's component data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo" /> to populate.</param>
        /// <param name="context">The streaming context.</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("x", X);
            info.AddValue("y", Y);
        }

        /// <summary>Returns the Euclidean length (magnitude) of the vector.</summary>
        /// <returns>The vector's length.</returns>
        public float Length()
        {
            float lengthSquared = LengthSquared();
            return (float) System.Math.Sqrt(lengthSquared);
        }

        /// <summary>Returns the squared length of the vector. This is faster than <see cref="Length" /> as it avoids a square root.</summary>
        /// <returns>The squared length.</returns>
        public float LengthSquared() => Dot(this, this);

        /// <summary>
        ///     Returns the string representation of the current instance using the specified format and culture.
        /// </summary>
        /// <param name="format">A standard or custom numeric format string.</param>
        /// <param name="formatProvider">A format provider for culture-specific formatting.</param>
        /// <returns>The formatted string.</returns>
        [ExcludeFromCodeCoverage]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            StringBuilder sb = new StringBuilder();
            string separator = NumberFormatInfo.GetInstance(formatProvider).NumberGroupSeparator;
            sb.Append('<');
            sb.Append(X.ToString(format, formatProvider));
            sb.Append(separator);
            sb.Append(' ');
            sb.Append(Y.ToString(format, formatProvider));
            sb.Append('>');
            return sb.ToString();
        }

        /// <summary>
        ///     Normalizes this vector in-place, setting its length to 1 while preserving direction.
        /// </summary>
        public void Normalize()
        {
            float length = (float) System.Math.Sqrt(X * X + Y * Y);
            float invLength = 1.0f / length;
            X *= invLength;
            Y *= invLength;
        }

        /// <summary>
        ///     Computes the dot product of two vectors (output variant).
        /// </summary>
        /// <param name="left">The first vector.</param>
        /// <param name="right">The second vector.</param>
        /// <param name="result">The output dot product.</param>
        public static void Dot(ref Vector2F left, ref Vector2F right, out float result)
        {
            result = left.X * right.X + left.Y * right.Y;
        }

        /// <summary>
        ///     Computes the component-wise minimum of two vectors (output variant).
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <param name="result">The output minimum vector.</param>
        public static void Min(ref Vector2F v1, ref Vector2F v2, out Vector2F result)
        {
            result = new Vector2F(
                v1.X < v2.X ? v1.X : v2.X,
                v1.Y < v2.Y ? v1.Y : v2.Y
            );
        }

        /// <summary>
        ///     Computes the component-wise maximum of two vectors (output variant).
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <param name="result">The output maximum vector.</param>
        public static void Max(ref Vector2F v1, ref Vector2F v2, out Vector2F result)
        {
            result = new Vector2F(v1.X > v2.X ? v1.X : v2.X, v1.Y > v2.Y ? v1.Y : v2.Y);
        }

        /// <summary>
        ///     Computes the Euclidean distance between two points (output variant).
        /// </summary>
        /// <param name="v1">The first point.</param>
        /// <param name="v2">The second point.</param>
        /// <param name="result">The output distance.</param>
        public static void Distance(ref Vector2F v1, ref Vector2F v2, out float result)
        {
            float dx = v1.X - v2.X;
            float dy = v1.Y - v2.Y;
            result = (float) System.Math.Sqrt(dx * dx + dy * dy);
        }

        /// <summary>
        ///     Computes the squared Euclidean distance between two points (output variant).
        /// </summary>
        /// <param name="v1">The first point.</param>
        /// <param name="v2">The second point.</param>
        /// <param name="result">The output squared distance.</param>
        public static void DistanceSquared(ref Vector2F v1, ref Vector2F v2, out float result)
        {
            float dx = v1.X - v2.X;
            float dy = v1.Y - v2.Y;
            result = dx * dx + dy * dy;
        }

        /// <summary>
        ///     Adds two vectors (output variant).
        /// </summary>
        /// <param name="left">The first vector.</param>
        /// <param name="right">The second vector.</param>
        /// <param name="result">The output sum vector.</param>
        public static void Add(ref Vector2F left, ref Vector2F right, out Vector2F result)
        {
            result = new Vector2F(left.X + right.X, left.Y + right.Y);
        }

        /// <summary>
        ///     Subtracts two vectors (output variant).
        /// </summary>
        /// <param name="left">The first vector.</param>
        /// <param name="right">The second vector.</param>
        /// <param name="result">The output difference vector.</param>
        public static void Subtract(ref Vector2F left, ref Vector2F right, out Vector2F result)
        {
            result = new Vector2F(left.X - right.X, left.Y - right.Y);
        }

        /// <summary>
        ///     Multiplies two vectors component-wise (output variant).
        /// </summary>
        /// <param name="left">The first vector.</param>
        /// <param name="right">The second vector.</param>
        /// <param name="result">The output product vector.</param>
        public static void Multiply(ref Vector2F left, ref Vector2F right, out Vector2F result)
        {
            result = new Vector2F(left.X * right.X, left.Y * right.Y);
        }

        /// <summary>
        ///     Multiplies a vector by a scalar (output variant).
        /// </summary>
        /// <param name="left">The vector.</param>
        /// <param name="right">The scalar value.</param>
        /// <param name="result">The output scaled vector.</param>
        public static void Multiply(ref Vector2F left, float right, out Vector2F result)
        {
            result = new Vector2F(left.X * right, left.Y * right);
        }

        /// <summary>
        ///     Divides a vector by a scalar (output variant).
        /// </summary>
        /// <param name="left">The vector.</param>
        /// <param name="right">The scalar divisor.</param>
        /// <param name="result">The output quotient vector.</param>
        public static void Divide(ref Vector2F left, float right, out Vector2F result)
        {
            float invRight = 1 / right;
            result = new Vector2F(left.X * invRight, left.Y * invRight);
        }

        /// <summary>
        ///     Returns a string representation of this vector.
        /// </summary>
        /// <returns>A string in the format "{X: value Y: value}".</returns>
        public override string ToString() => "{X: " + X + " Y: " + Y + "}";

        /// <summary>
        ///     Returns a formatted string representation of this vector using the specified format and culture.
        /// </summary>
        /// <param name="f2">The numeric format string.</param>
        /// <param name="cultureInfo">The culture info for formatting.</param>
        /// <returns>The formatted string.</returns>
        public string ToString(string f2, CultureInfo cultureInfo) => string.Format("{{X: {0} Y: {1}}}", X.ToString(f2, cultureInfo), Y.ToString(f2, cultureInfo));
    }
}
