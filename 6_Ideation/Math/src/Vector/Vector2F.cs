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
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Util;

namespace Alis.Core.Aspect.Math.Vector
{
    /// <summary>
    ///     The vector
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2F : IEquatable<Vector2F>, IFormattable, ISerializable
    {
        /// <summary>The X component of the vector.</summary>
        public float X { get; set; }

        /// <summary>The Y component of the vector.</summary>
        public float Y { get; set; }

        /// <summary>Creates a new <see cref="Vector2F" /> object whose two elements have the same value.</summary>
        /// <param name="value">The value to assign to both elements.</param>
        public Vector2F(float value) : this(value, value)
        {
        }

        /// <summary>Creates a vector whose elements have the specified values.</summary>
        /// <param name="x">The value to assign to the <see cref="X" /> field.</param>
        /// <param name="y">The value to assign to the <see cref="Y" /> field.</param>
        public Vector2F(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>Returns a vector whose 2 elements are equal to zero.</summary>
        /// <value>A vector whose two elements are equal to zero (that is, it returns the vector <c>(0,0)</c>.</value>
        public static Vector2F Zero => default(Vector2F);

        /// <summary>Gets a vector whose 2 elements are equal to one.</summary>
        /// <value>A vector whose two elements are equal to one (that is, it returns the vector <c>(1,1)</c>.</value>
        public static Vector2F One => new Vector2F(1.0f);

        /// <summary>Gets the vector (1,0).</summary>
        /// <value>The vector <c>(1,0)</c>.</value>
        public static Vector2F UnitX => new Vector2F(1.0f, 0.0f);

        /// <summary>Gets the vector (0,1).</summary>
        /// <value>The vector <c>(0,1)</c>.</value>
        public static Vector2F UnitY => new Vector2F(0.0f, 1.0f);

        /// <summary>Adds two vectors together.</summary>
        /// <param name="left">The first vector to add.</param>
        /// <param name="right">The second vector to add.</param>
        /// <returns>The summed vector.</returns>
        /// <remarks>The <see cref="op_Addition" /> method defines the addition operation for <see cref="Vector2F" /> objects.</remarks>
        public static Vector2F operator +(Vector2F left, Vector2F right) => new Vector2F(
            left.X + right.X,
            left.Y + right.Y
        );

        /// <summary>Divides the first vector by the second.</summary>
        /// <param name="left">The first vector.</param>
        /// <param name="right">The second vector.</param>
        /// <returns>The vector that results from dividing <paramref name="left" /> by <paramref name="right" />.</returns>
        public static Vector2F operator /(Vector2F left, Vector2F right) => new Vector2F(
            left.X / right.X,
            left.Y / right.Y
        );

        /// <summary>Divides the specified vector by a specified scalar value.</summary>
        /// <param name="value1">The vector.</param>
        /// <param name="value2">The scalar value.</param>
        /// <returns>The result of the division.</returns>
        public static Vector2F operator /(Vector2F value1, float value2) => value1 / new Vector2F(value2);

        /// <summary>Returns a value that indicates whether each pair of elements in two specified vectors is equal.</summary>
        /// <param name="left">The first vector to compare.</param>
        /// <param name="right">The second vector to compare.</param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are equal; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        /// <remarks>
        ///     Two <see cref="Vector2F" /> objects are equal if each value in <paramref name="left" /> is equal to the
        ///     corresponding value in <paramref name="right" />.
        /// </remarks>
        public static bool operator ==(Vector2F left, Vector2F right) => (System.Math.Abs(left.X - right.X) < 0.01f)
                                                                         && (System.Math.Abs(left.Y - right.Y) < 0.01f);

        /// <summary>Returns a value that indicates whether two specified vectors are not equal.</summary>
        /// <param name="left">The first vector to compare.</param>
        /// <param name="right">The second vector to compare.</param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are not equal; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        public static bool operator !=(Vector2F left, Vector2F right) => !(left == right);

        /// <summary>Returns a new vector whose values are the product of each pair of elements in two specified vectors.</summary>
        /// <param name="left">The first vector.</param>
        /// <param name="right">The second vector.</param>
        /// <returns>The element-wise product vector.</returns>
        public static Vector2F operator *(Vector2F left, Vector2F right) => new Vector2F(
            left.X * right.X,
            left.Y * right.Y
        );

        /// <summary>Multiplies the specified vector by the specified scalar value.</summary>
        /// <param name="left">The vector.</param>
        /// <param name="right">The scalar value.</param>
        /// <returns>The scaled vector.</returns>
        public static Vector2F operator *(Vector2F left, float right) => left * new Vector2F(right);

        /// <summary>Multiplies the scalar value by the specified vector.</summary>
        /// <param name="left">The vector.</param>
        /// <param name="right">The scalar value.</param>
        /// <returns>The scaled vector.</returns>
        public static Vector2F operator *(float left, Vector2F right) => right * left;

        /// <summary>Subtracts the second vector from the first.</summary>
        /// <param name="left">The first vector.</param>
        /// <param name="right">The second vector.</param>
        /// <returns>The vector that results from subtracting <paramref name="right" /> from <paramref name="left" />.</returns>
        /// <remarks>
        ///     The <see cref="op_Subtraction" /> method defines the subtraction operation for <see cref="Vector2F" />
        ///     objects.
        /// </remarks>
        public static Vector2F operator -(Vector2F left, Vector2F right) => new Vector2F(
            left.X - right.X,
            left.Y - right.Y
        );

        /// <summary>Negates the specified vector.</summary>
        /// <param name="value">The vector to negate.</param>
        /// <returns>The negated vector.</returns>
        /// <remarks>
        ///     The <see cref="op_UnaryNegation" /> method defines the unary negation operation for <see cref="Vector2F" />
        ///     objects.
        /// </remarks>
        public static Vector2F operator -(Vector2F value) => Zero - value;

        /// <summary>Returns a vector whose elements are the absolute values of each of the specified vector's elements.</summary>
        /// <param name="value">A vector.</param>
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
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The restricted vector.</returns>
        public static Vector2F Clamp(Vector2F value1, Vector2F min, Vector2F max) =>
            // We must follow HLSL behavior in the case user specified min value is bigger than max value.
            Min(Max(value1, min), max);

        /// <summary>Computes the Euclidean distance between the two given points.</summary>
        /// <param name="value1">The first point.</param>
        /// <param name="value2">The second point.</param>
        /// <returns>The distance.</returns>
        public static float Distance(Vector2F value1, Vector2F value2)
        {
            float distanceSquared = DistanceSquared(value1, value2);
            return (float) System.Math.Sqrt(distanceSquared);
        }

        /// <summary>Returns the Euclidean distance squared between two specified points.</summary>
        /// <param name="value1">The first point.</param>
        /// <param name="value2">The second point.</param>
        /// <returns>The distance squared.</returns>
        public static float DistanceSquared(Vector2F value1, Vector2F value2)
        {
            Vector2F difference = value1 - value2;
            return Dot(difference, difference);
        }

        /// <summary>Divides the first vector by the second.</summary>
        /// <param name="left">The first vector.</param>
        /// <param name="right">The second vector.</param>
        /// <returns>The vector resulting from the division.</returns>
        public static Vector2F Divide(Vector2F left, Vector2F right) => left / right;

        /// <summary>Divides the specified vector by a specified scalar value.</summary>
        /// <param name="left">The vector.</param>
        /// <param name="divisor">The scalar value.</param>
        /// <returns>The vector that results from the division.</returns>
        public static Vector2F Divide(Vector2F left, float divisor) => left / divisor;

        /// <summary>Returns the dot product of two vectors.</summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>The dot product.</returns>
        public static float Dot(Vector2F value1, Vector2F value2) => value1.X * value2.X
                                                                     + value1.Y * value2.Y;

        /// <summary>Performs a linear interpolation between two vectors based on the given weighting.</summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <param name="amount">A value between 0 and 1 that indicates the weight of <paramref name="value2" />.</param>
        /// <returns>The interpolated vector.</returns>
        /// <remarks>
        ///     <format type="text/markdown"><![CDATA[
        /// The behavior of this method changed in .NET 5.0. For more information, see [Behavior change for Vector2F.Lerp and Vector4F.Lerp](/dotnet/core/compatibility/3.1-5.0#behavior-change-for-vector2lerp-and-vector4lerp).
        /// ]]></format>
        /// </remarks>
        public static Vector2F LerP(Vector2F value1, Vector2F value2, float amount) => value1 * (1.0f - amount) + value2 * amount;

        /// <summary>Returns a vector whose elements are the maximum of each of the pairs of elements in two specified vectors.</summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>The maximized vector.</returns>
        public static Vector2F Max(Vector2F value1, Vector2F value2) => new Vector2F(
            value1.X > value2.X ? value1.X : value2.X,
            value1.Y > value2.Y ? value1.Y : value2.Y
        );

        /// <summary>Returns a vector whose elements are the minimum of each of the pairs of elements in two specified vectors.</summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>The minimized vector.</returns>
        public static Vector2F Min(Vector2F value1, Vector2F value2) => new Vector2F(
            value1.X < value2.X ? value1.X : value2.X,
            value1.Y < value2.Y ? value1.Y : value2.Y
        );

        /// <summary>Returns a new vector whose values are the product of each pair of elements in two specified vectors.</summary>
        /// <param name="left">The first vector.</param>
        /// <param name="right">The second vector.</param>
        /// <returns>The element-wise product vector.</returns>
        public static Vector2F Multiply(Vector2F left, Vector2F right) => left * right;

        /// <summary>Multiplies a vector by a specified scalar.</summary>
        /// <param name="left">The vector to multiply.</param>
        /// <param name="right">The scalar value.</param>
        /// <returns>The scaled vector.</returns>
        public static Vector2F Multiply(Vector2F left, float right) => left * right;

        /// <summary>Multiplies a scalar value by a specified vector.</summary>
        /// <param name="left">The scaled value.</param>
        /// <param name="right">The vector.</param>
        /// <returns>The scaled vector.</returns>
        public static Vector2F Multiply(float left, Vector2F right) => left * right;

        /// <summary>Negates a specified vector.</summary>
        /// <param name="value">The vector to negate.</param>
        /// <returns>The negated vector.</returns>
        public static Vector2F Negate(Vector2F value) => -value;

        /// <summary>Returns a vector with the same direction as the specified vector, but with a length of one.</summary>
        /// <param name="value">The vector to normalize.</param>
        /// <returns>The normalized vector.</returns>
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
        /// <param name="value">A vector.</param>
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

        /// <summary>Transforms a vector by a specified 3x2 matrix.</summary>
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

        /// <summary>Transforms a vector by the specified Quaternion rotation value.</summary>
        /// <param name="value">The vector to rotate.</param>
        /// <param name="rotation">The rotation to apply.</param>
        /// <returns>The transformed vector.</returns>
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

        /// <summary>Transforms a vector normal by the given 3x2 matrix.</summary>
        /// <param name="normal">The source vector.</param>
        /// <param name="matrix">The matrix.</param>
        /// <returns>The transformed vector.</returns>
        public static Vector2F TransformNormal(Vector2F normal, Matrix3X2 matrix) => new Vector2F(
            normal.X * matrix.M11 + normal.Y * matrix.M21,
            normal.X * matrix.M12 + normal.Y * matrix.M22
        );

        /// <summary>Transforms a vector normal by the given 4x4 matrix.</summary>
        /// <param name="normal">The source vector.</param>
        /// <param name="matrix">The matrix.</param>
        /// <returns>The transformed vector.</returns>
        public static Vector2F TransformNormal(Vector2F normal, Matrix4X4 matrix) => new Vector2F(
            normal.X * matrix.M11 + normal.Y * matrix.M21,
            normal.X * matrix.M12 + normal.Y * matrix.M22
        );

        /// <summary>Copies the elements of the vector to a specified array starting at a specified index position.</summary>
        /// <param name="array">The destination array.</param>
        /// <param name="index">The index at which to copy the first element of the vector.</param>
        /// <remarks>
        ///     <paramref name="array" /> must have a sufficient number of elements to accommodate the two vector elements. In
        ///     other words, elements <paramref name="index" /> and <paramref name="index" /> + 1 must already exist in
        ///     <paramref name="array" />.
        /// </remarks>
        /// <exception cref="System.ArgumentNullException"><paramref name="array" /> is <see langword="null" />.</exception>
        /// <exception cref="System.ArgumentException">The number of elements in the current instance is greater than in the array.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        ///     <paramref name="index" /> is less than zero.
        ///     -or-
        ///     <paramref name="index" /> is greater than or equal to the array length.
        /// </exception>
        /// <exception cref="System.RankException"><paramref name="array" /> is multidimensional.</exception>
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
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns>
        ///     <see langword="true" /> if the current instance and <paramref name="obj" /> are equal; otherwise,
        ///     <see langword="false" />. If <paramref name="obj" /> is <see langword="null" />, the method returns
        ///     <see langword="false" />.
        /// </returns>
        /// <remarks>
        ///     The current instance and <paramref name="obj" /> are equal if <paramref name="obj" /> is a
        ///     <see cref="Vector2F" /> object and their <see cref="X" /> and <see cref="Y" /> elements are equal.
        /// </remarks>
        public override bool Equals(object obj) => obj is Vector2F other && Equals(other);

        /// <summary>Returns a value that indicates whether this instance and another vector are equal.</summary>
        /// <param name="other">The other vector.</param>
        /// <returns><see langword="true" /> if the two vectors are equal; otherwise, <see langword="false" />.</returns>
        /// <remarks>Two vectors are equal if their <see cref="X" /> and <see cref="Y" /> elements are equal.</remarks>
        public bool Equals(Vector2F other) => this == other;

        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode() => HashCode.Combine(X, Y);

        /// <summary>
        ///     Gets the object data using the specified info
        /// </summary>
        /// <param name="info">The info</param>
        /// <param name="context">The context</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("x", X);
            info.AddValue("y", Y);
        }

        /// <summary>Returns the length of the vector.</summary>
        /// <returns>The vector's length.</returns>
        /// <altmember cref="LengthSquared" />
        public float Length()
        {
            float lengthSquared = LengthSquared();
            return (float) System.Math.Sqrt(lengthSquared);
        }

        /// <summary>Returns the length of the vector squared.</summary>
        /// <returns>The vector's length squared.</returns>
        /// <remarks>This operation offers better performance than a call to the <see cref="Length" /> method.</remarks>
        /// <altmember cref="Length" />
        public float LengthSquared() => Dot(this, this);

        /// <summary>
        ///     Returns the string representation of the current instance using the specified format string to format
        ///     individual elements and the specified format provider to define culture-specific formatting.
        /// </summary>
        /// <param name="format">A standard or custom numeric format string that defines the format of individual elements.</param>
        /// <param name="formatProvider">A format provider that supplies culture-specific formatting information.</param>
        /// <returns>The string representation of the current instance.</returns>
        /// <remarks>
        ///     This method returns a string in which each element of the vector is formatted using <paramref name="format" />
        ///     and <paramref name="formatProvider" />. The "&lt;" and "&gt;" characters are used to begin and end the string, and
        ///     the format provider's <see cref="System.Globalization.NumberFormatInfo.NumberGroupSeparator" /> property followed
        ///     by a space is used to separate each element.
        /// </remarks>
        /// <related type="Article" href="/dotnet/standard/base-types/custom-numeric-format-strings">Custom Numeric Format Strings</related>
        /// <related type="Article" href="/dotnet/standard/base-types/standard-numeric-format-strings">
        ///     Standard Numeric Format
        ///     Strings
        /// </related>
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
        ///     Normalizes this instance
        /// </summary>
        public void Normalize()
        {
            float length = (float) System.Math.Sqrt(X * X + Y * Y);
            float invLength = 1.0f / length;
            X *= invLength;
            Y *= invLength;
        }


        /// <summary>
        ///     Dots the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <param name="result">The result</param>
        public static void Dot(ref Vector2F left, ref Vector2F right, out float result)
        {
            result = left.X * right.X + left.Y * right.Y;
        }

        /// <summary>
        ///     Mins the v 1
        /// </summary>
        /// <param name="v1">The </param>
        /// <param name="v2">The </param>
        /// <param name="result">The result</param>
        public static void Min(ref Vector2F v1, ref Vector2F v2, out Vector2F result)
        {
            result = new Vector2F(
                v1.X < v2.X ? v1.X : v2.X,
                v1.Y < v2.Y ? v1.Y : v2.Y
            );
        }

        /// <summary>
        ///     Maxes the v 1
        /// </summary>
        /// <param name="v1">The </param>
        /// <param name="v2">The </param>
        /// <param name="result">The result</param>
        public static void Max(ref Vector2F v1, ref Vector2F v2, out Vector2F result)
        {
            result = new Vector2F(v1.X > v2.X ? v1.X : v2.X, v1.Y > v2.Y ? v1.Y : v2.Y);
        }

        /// <summary>
        ///     Distances the v 1
        /// </summary>
        /// <param name="v1">The </param>
        /// <param name="v2">The </param>
        /// <param name="result">The result</param>
        public static void Distance(ref Vector2F v1, ref Vector2F v2, out float result)
        {
            float dx = v1.X - v2.X;
            float dy = v1.Y - v2.Y;
            result = (float) System.Math.Sqrt(dx * dx + dy * dy);
        }

        /// <summary>
        ///     Distances the squared using the specified v 1
        /// </summary>
        /// <param name="v1">The </param>
        /// <param name="v2">The </param>
        /// <param name="result">The result</param>
        public static void DistanceSquared(ref Vector2F v1, ref Vector2F v2, out float result)
        {
            float dx = v1.X - v2.X;
            float dy = v1.Y - v2.Y;
            result = dx * dx + dy * dy;
        }

        /// <summary>
        ///     Adds the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <param name="result">The result</param>
        public static void Add(ref Vector2F left, ref Vector2F right, out Vector2F result)
        {
            result = new Vector2F(left.X + right.X, left.Y + right.Y);
        }

        /// <summary>
        ///     Subtracts the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <param name="result">The result</param>
        public static void Subtract(ref Vector2F left, ref Vector2F right, out Vector2F result)
        {
            result = new Vector2F(left.X - right.X, left.Y - right.Y);
        }

        /// <summary>
        ///     Multiplies the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <param name="result">The result</param>
        public static void Multiply(ref Vector2F left, ref Vector2F right, out Vector2F result)
        {
            result = new Vector2F(left.X * right.X, left.Y * right.Y);
        }

        /// <summary>
        ///     Multiplies the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <param name="result">The result</param>
        public static void Multiply(ref Vector2F left, float right, out Vector2F result)
        {
            result = new Vector2F(left.X * right, left.Y * right);
        }

        /// <summary>
        ///     Divides the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <param name="result">The result</param>
        public static void Divide(ref Vector2F left, float right, out Vector2F result)
        {
            float invRight = 1 / right;
            result = new Vector2F(left.X * invRight, left.Y * invRight);
        }

        /// <summary>
        ///     Returns the string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString() => "{X: " + X + " Y: " + Y + "}";


        /// <summary>
        ///     Returns the string using the specified f 2
        /// </summary>
        /// <param name="f2">The </param>
        /// <param name="cultureInfo">The culture info</param>
        /// <returns>The string</returns>
        public string ToString(string f2, CultureInfo cultureInfo) => string.Format("{{X: {0} Y: {1}}}", X.ToString(f2, cultureInfo), Y.ToString(f2, cultureInfo));
    }
}