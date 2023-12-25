// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: Vector3.cs
// 
//  Author: Pablo Perdomo Falcón
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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Util;
using HashCode = Alis.Core.Aspect.Math.Util.HashCode;

namespace Alis.Core.Aspect.Math.Vector
{
    /// <summary>
    ///     The vector
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3 : IEquatable<Vector3>, IFormattable
    {
        /// <summary>
        ///     The hash
        /// </summary>
        private readonly HashCode hash;

        /// <summary>
        ///     The hash code
        /// </summary>
        private readonly int hashCode;

        /// <summary>The X component of the vector.</summary>
        public float X;

        /// <summary>The Y component of the vector.</summary>
        public float Y;

        /// <summary>The Z component of the vector.</summary>
        public float Z;

        /// <summary>Creates a new <see cref="Vector3" /> object whose three elements have the same value.</summary>
        /// <param name="value">The value to assign to all three elements.</param>
        public Vector3(float value) : this(value, value, value)
        {
        }


        /// <summary>
        ///     Initializes a new instance of the <see cref="Vector3" /> class
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="z">The </param>
        public Vector3(Vector2 value, float z) : this(value.X, value.Y, z)
        {
        }

        /// <summary>Creates a vector whose elements have the specified values.</summary>
        /// <param name="x">The value to assign to the <see cref="Vector3.X" /> field.</param>
        /// <param name="y">The value to assign to the <see cref="Vector3.Y" /> field.</param>
        /// <param name="z">The value to assign to the <see cref="Vector3.Z" /> field.</param>
        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;

            hash = new HashCode();
            hash.Add(x);
            hash.Add(y);
            hash.Add(z);
            hashCode = hash.ToHashCode();
        }

        /// <summary>
        ///     Store the minimum values of x, y, and z between the two vectors.
        /// </summary>
        /// <param name="tv">The Vector3 to perform the TakeMin on.</param>
        /// <param name="v">Vector to check against.</param>
        public static void TakeMin(Vector3 tv, Vector3 v)
        {
            if (v.X < tv.X)
            {
                tv.X = v.X;
            }

            if (v.Y < tv.Y)
            {
                tv.Y = v.Y;
            }

            if (v.Z < tv.Z)
            {
                tv.Z = v.Z;
            }
        }

        /// <summary>
        ///     Store the maximum values of x, y, and z between the two vectors.
        /// </summary>
        /// <param name="tv">The Vector3 to perform the TakeMax on.</param>
        /// <param name="v">Vector to check against.</param>
        public static void TakeMax(Vector3 tv, Vector3 v)
        {
            if (v.X > tv.X)
            {
                tv.X = v.X;
            }

            if (v.Y > tv.Y)
            {
                tv.Y = v.Y;
            }

            if (v.Z > tv.Z)
            {
                tv.Z = v.Z;
            }
        }

        /// <summary>
        ///     Provide an accessor for each of the elements of the Vector structure.
        /// </summary>
        /// <param name="v">The Vector3 to access.</param>
        /// <param name="index">The element to access (0 = X, 1 = Y, 2 = Z).</param>
        /// <returns>The element of the Vector3 as indexed by i.</returns>
        public static float Get(Vector3 v, int index) => index == 0 ? v.X : index == 1 ? v.Y : v.Z;

        /// <summary>Gets a vector whose 3 elements are equal to zero.</summary>
        /// <value>A vector whose three elements are equal to zero (that is, it returns the vector <c>(0,0,0)</c>.</value>
        public static Vector3 Zero => default(Vector3);

        /// <summary>Gets a vector whose 3 elements are equal to one.</summary>
        /// <value>A vector whose three elements are equal to one (that is, it returns the vector <c>(1,1,1)</c>.</value>
        public static Vector3 One => new Vector3(1.0f);

        /// <summary>Gets the vector (1,0,0).</summary>
        /// <value>The vector <c>(1,0,0)</c>.</value>
        public static Vector3 UnitX => new Vector3(1.0f, 0.0f, 0.0f);

        /// <summary>Gets the vector (0,1,0).</summary>
        /// <value>The vector <c>(0,1,0)</c>.</value>
        public static Vector3 UnitY => new Vector3(0.0f, 1.0f, 0.0f);

        /// <summary>Gets the vector (0,0,1).</summary>
        /// <value>The vector <c>(0,0,1)</c>.</value>
        public static Vector3 UnitZ => new Vector3(0.0f, 0.0f, 1.0f);

        /// <summary>Adds two vectors together.</summary>
        /// <param name="left">The first vector to add.</param>
        /// <param name="right">The second vector to add.</param>
        /// <returns>The summed vector.</returns>
        /// <remarks>
        ///     The <see cref="Vector3.op_Addition" /> method defines the addition operation for <see cref="Vector3" />
        ///     objects.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator +(Vector3 left, Vector3 right) => new Vector3(
            left.X + right.X,
            left.Y + right.Y,
            left.Z + right.Z
        );

        /// <summary>Divides the first vector by the second.</summary>
        /// <param name="left">The first vector.</param>
        /// <param name="right">The second vector.</param>
        /// <returns>The vector that results from dividing <paramref name="left" /> by <paramref name="right" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator /(Vector3 left, Vector3 right) => new Vector3(
            left.X / right.X,
            left.Y / right.Y,
            left.Z / right.Z
        );

        /// <summary>Divides the specified vector by a specified scalar value.</summary>
        /// <param name="value1">The vector.</param>
        /// <param name="value2">The scalar value.</param>
        /// <returns>The result of the division.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator /(Vector3 value1, float value2) => value1 / new Vector3(value2);

        /// <summary>Returns a value that indicates whether each pair of elements in two specified vectors is equal.</summary>
        /// <param name="left">The first vector to compare.</param>
        /// <param name="right">The second vector to compare.</param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are equal; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        /// <remarks>
        ///     Two <see cref="Vector3" /> objects are equal if each element in <paramref name="right" /> is equal to the
        ///     corresponding element in <paramref name="right" />.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector3 left, Vector3 right) => (left.X == right.X)
                                                                       && (left.Y == right.Y)
                                                                       && (left.Z == right.Z);

        /// <summary>Returns a value that indicates whether two specified vectors are not equal.</summary>
        /// <param name="left">The first vector to compare.</param>
        /// <param name="right">The second vector to compare.</param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are not equal; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector3 left, Vector3 right) => !(left == right);

        /// <summary>Returns a new vector whose values are the product of each pair of elements in two specified vectors.</summary>
        /// <param name="left">The first vector.</param>
        /// <param name="right">The second vector.</param>
        /// <returns>The element-wise product vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator *(Vector3 left, Vector3 right) => new Vector3(
            left.X * right.X,
            left.Y * right.Y,
            left.Z * right.Z
        );

        /// <summary>Multiplies the specified vector by the specified scalar value.</summary>
        /// <param name="left">The vector.</param>
        /// <param name="right">The scalar value.</param>
        /// <returns>The scaled vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator *(Vector3 left, float right) => left * new Vector3(right);

        /// <summary>Multiplies the scalar value by the specified vector.</summary>
        /// <param name="left">The vector.</param>
        /// <param name="right">The scalar value.</param>
        /// <returns>The scaled vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator *(float left, Vector3 right) => right * left;

        /// <summary>Subtracts the second vector from the first.</summary>
        /// <param name="left">The first vector.</param>
        /// <param name="right">The second vector.</param>
        /// <returns>The vector that results from subtracting <paramref name="right" /> from <paramref name="left" />.</returns>
        /// <remarks>
        ///     The <see cref="Vector3.op_Subtraction" /> method defines the subtraction operation for
        ///     <see cref="Vector3" /> objects.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator -(Vector3 left, Vector3 right) => new Vector3(
            left.X - right.X,
            left.Y - right.Y,
            left.Z - right.Z
        );

        /// <summary>Negates the specified vector.</summary>
        /// <param name="value">The vector to negate.</param>
        /// <returns>The negated vector.</returns>
        /// <remarks>
        ///     The <see cref="Vector3.op_UnaryNegation" /> method defines the unary negation operation for
        ///     <see cref="Vector3" /> objects.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator -(Vector3 value) => Zero - value;

        /// <summary>Returns a vector whose elements are the absolute values of each of the specified vector's elements.</summary>
        /// <param name="value">A vector.</param>
        /// <returns>The absolute value vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Abs(Vector3 value) => new Vector3(
            MathF.Abs(value.X),
            MathF.Abs(value.Y),
            MathF.Abs(value.Z)
        );

        /// <summary>Adds two vectors together.</summary>
        /// <param name="left">The first vector to add.</param>
        /// <param name="right">The second vector to add.</param>
        /// <returns>The summed vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Add(Vector3 left, Vector3 right) => left + right;

        /// <summary>Restricts a vector between a minimum and a maximum value.</summary>
        /// <param name="value1">The vector to restrict.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The restricted vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Clamp(Vector3 value1, Vector3 min, Vector3 max) =>
            // We must follow HLSL behavior in the case user specified min value is bigger than max value.
            Min(Max(value1, min), max);

        /// <summary>Computes the cross product of two vectors.</summary>
        /// <param name="vector1">The first vector.</param>
        /// <param name="vector2">The second vector.</param>
        /// <returns>The cross product.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Cross(Vector3 vector1, Vector3 vector2) => new Vector3(
            vector1.Y * vector2.Z - vector1.Z * vector2.Y,
            vector1.Z * vector2.X - vector1.X * vector2.Z,
            vector1.X * vector2.Y - vector1.Y * vector2.X
        );

        /// <summary>Computes the Euclidean distance between the two given points.</summary>
        /// <param name="value1">The first point.</param>
        /// <param name="value2">The second point.</param>
        /// <returns>The distance.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Distance(Vector3 value1, Vector3 value2)
        {
            float distanceSquared = DistanceSquared(value1, value2);
            return MathF.Sqrt(distanceSquared);
        }

        /// <summary>Returns the Euclidean distance squared between two specified points.</summary>
        /// <param name="value1">The first point.</param>
        /// <param name="value2">The second point.</param>
        /// <returns>The distance squared.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DistanceSquared(Vector3 value1, Vector3 value2)
        {
            Vector3 difference = value1 - value2;
            return Dot(difference, difference);
        }

        /// <summary>Divides the first vector by the second.</summary>
        /// <param name="left">The first vector.</param>
        /// <param name="right">The second vector.</param>
        /// <returns>The vector resulting from the division.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Divide(Vector3 left, Vector3 right) => left / right;

        /// <summary>Divides the specified vector by a specified scalar value.</summary>
        /// <param name="left">The vector.</param>
        /// <param name="divisor">The scalar value.</param>
        /// <returns>The vector that results from the division.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Divide(Vector3 left, float divisor) => left / divisor;

        /// <summary>Returns the dot product of two vectors.</summary>
        /// <param name="vector1">The first vector.</param>
        /// <param name="vector2">The second vector.</param>
        /// <returns>The dot product.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Dot(Vector3 vector1, Vector3 vector2) => vector1.X * vector2.X
                                                                     + vector1.Y * vector2.Y
                                                                     + vector1.Z * vector2.Z;

        /// <summary>Performs a linear interpolation between two vectors based on the given weighting.</summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <param name="amount">A value between 0 and 1 that indicates the weight of <paramref name="value2" />.</param>
        /// <returns>The interpolated vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Lerp(Vector3 value1, Vector3 value2, float amount) => value1 * (1f - amount) + value2 * amount;

        /// <summary>Returns a vector whose elements are the maximum of each of the pairs of elements in two specified vectors.</summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>The maximized vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Max(Vector3 value1, Vector3 value2) => new Vector3(
            value1.X > value2.X ? value1.X : value2.X,
            value1.Y > value2.Y ? value1.Y : value2.Y,
            value1.Z > value2.Z ? value1.Z : value2.Z
        );

        /// <summary>Returns a vector whose elements are the minimum of each of the pairs of elements in two specified vectors.</summary>
        /// <param name="value1">The first vector.</param>
        /// <param name="value2">The second vector.</param>
        /// <returns>The minimized vector.</returns>
        public static Vector3 Min(Vector3 value1, Vector3 value2) => new Vector3(
            value1.X < value2.X ? value1.X : value2.X,
            value1.Y < value2.Y ? value1.Y : value2.Y,
            value1.Z < value2.Z ? value1.Z : value2.Z
        );

        /// <summary>Returns a new vector whose values are the product of each pair of elements in two specified vectors.</summary>
        /// <param name="left">The first vector.</param>
        /// <param name="right">The second vector.</param>
        /// <returns>The element-wise product vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Multiply(Vector3 left, Vector3 right) => left * right;

        /// <summary>Multiplies a vector by a specified scalar.</summary>
        /// <param name="left">The vector to multiply.</param>
        /// <param name="right">The scalar value.</param>
        /// <returns>The scaled vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Multiply(Vector3 left, float right) => left * right;

        /// <summary>Multiplies a scalar value by a specified vector.</summary>
        /// <param name="left">The scaled value.</param>
        /// <param name="right">The vector.</param>
        /// <returns>The scaled vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Multiply(float left, Vector3 right) => left * right;

        /// <summary>Negates a specified vector.</summary>
        /// <param name="value">The vector to negate.</param>
        /// <returns>The negated vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Negate(Vector3 value) => -value;

        /// <summary>Returns a vector with the same direction as the specified vector, but with a length of one.</summary>
        /// <param name="value">The vector to normalize.</param>
        /// <returns>The normalized vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Normalize(Vector3 value) => value / value.Length();

        /// <summary>Returns the reflection of a vector off a surface that has the specified normal.</summary>
        /// <param name="vector">The source vector.</param>
        /// <param name="normal">The normal of the surface being reflected off.</param>
        /// <returns>The reflected vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Reflect(Vector3 vector, Vector3 normal)
        {
            float dot = Dot(vector, normal);
            return vector - 2 * dot * normal;
        }

        /// <summary>Returns a vector whose elements are the square root of each of a specified vector's elements.</summary>
        /// <param name="value">A vector.</param>
        /// <returns>The square root vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SquareRoot(Vector3 value) => new Vector3(
            MathF.Sqrt(value.X),
            MathF.Sqrt(value.Y),
            MathF.Sqrt(value.Z)
        );

        /// <summary>Subtracts the second vector from the first.</summary>
        /// <param name="left">The first vector.</param>
        /// <param name="right">The second vector.</param>
        /// <returns>The difference vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Subtract(Vector3 left, Vector3 right) => left - right;

        /// <summary>Transforms a vector by a specified 4x4 matrix.</summary>
        /// <param name="position">The vector to transform.</param>
        /// <param name="matrix">The transformation matrix.</param>
        /// <returns>The transformed vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Transform(Vector3 position, Matrix4X4 matrix) => new Vector3(
            position.X * matrix.M11 + position.Y * matrix.M21 + position.Z * matrix.M31 + matrix.M41,
            position.X * matrix.M12 + position.Y * matrix.M22 + position.Z * matrix.M32 + matrix.M42,
            position.X * matrix.M13 + position.Y * matrix.M23 + position.Z * matrix.M33 + matrix.M43
        );

        /// <summary>Transforms a vector by the specified Quaternion rotation value.</summary>
        /// <param name="value">The vector to rotate.</param>
        /// <param name="rotation">The rotation to apply.</param>
        /// <returns>The transformed vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Transform(Vector3 value, Quaternion rotation)
        {
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

            return new Vector3(
                value.X * (1.0f - yy2 - zz2) + value.Y * (xy2 - wz2) + value.Z * (xz2 + wy2),
                value.X * (xy2 + wz2) + value.Y * (1.0f - xx2 - zz2) + value.Z * (yz2 - wx2),
                value.X * (xz2 - wy2) + value.Y * (yz2 + wx2) + value.Z * (1.0f - xx2 - yy2)
            );
        }

        /// <summary>Transforms a vector normal by the given 4x4 matrix.</summary>
        /// <param name="normal">The source vector.</param>
        /// <param name="matrix">The matrix.</param>
        /// <returns>The transformed vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 TransformNormal(Vector3 normal, Matrix4X4 matrix) => new Vector3(
            normal.X * matrix.M11 + normal.Y * matrix.M21 + normal.Z * matrix.M31,
            normal.X * matrix.M12 + normal.Y * matrix.M22 + normal.Z * matrix.M32,
            normal.X * matrix.M13 + normal.Y * matrix.M23 + normal.Z * matrix.M33
        );

        /// <summary>Copies the elements of the vector to a specified array.</summary>
        /// <param name="array">The destination array.</param>
        /// <remarks>
        ///     <paramref name="array" /> must have at least three elements. The method copies the vector's elements starting
        ///     at index 0.
        /// </remarks>
        /// <exception cref="System.ArgumentNullException"><paramref name="array" /> is <see langword="null" />.</exception>
        /// <exception cref="System.ArgumentException">The number of elements in the current instance is greater than in the array.</exception>
        /// <exception cref="System.RankException"><paramref name="array" /> is multidimensional.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly void CopyTo(float[] array)
        {
            CopyTo(array, 0);
        }

        /// <summary>Copies the elements of the vector to a specified array starting at a specified index position.</summary>
        /// <param name="array">The destination array.</param>
        /// <param name="index">The index at which to copy the first element of the vector.</param>
        /// <remarks>
        ///     <paramref name="array" /> must have a sufficient number of elements to accommodate the three vector elements.
        ///     In other words, elements <paramref name="index" />, <paramref name="index" /> + 1, and <paramref name="index" /> +
        ///     2 must already exist in <paramref name="array" />.
        /// </remarks>
        /// <exception cref="System.ArgumentNullException"><paramref name="array" /> is <see langword="null" />.</exception>
        /// <exception cref="System.ArgumentException">The number of elements in the current instance is greater than in the array.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        ///     <paramref name="index" /> is less than zero.
        ///     -or-
        ///     <paramref name="index" /> is greater than or equal to the array length.
        /// </exception>
        /// <exception cref="System.RankException"><paramref name="array" /> is multidimensional.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly void CopyTo(float[] array, int index)
        {
            if (array is null)
            {
                throw new NullReferenceException();
            }

            if (index < 0 || index >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (array.Length - index < 3)
            {
                throw new ArgumentException("Arg_ElementsInSourceIsGreaterThanDestination, index");
            }

            array[index] = X;
            array[index + 1] = Y;
            array[index + 2] = Z;
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
        ///     <see cref="Vector3" /> object and their corresponding elements are equal.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly override bool Equals(object obj) => obj is Vector3 other && Equals(other);

        /// <summary>Returns a value that indicates whether this instance and another vector are equal.</summary>
        /// <param name="other">The other vector.</param>
        /// <returns><see langword="true" /> if the two vectors are equal; otherwise, <see langword="false" />.</returns>
        /// <remarks>
        ///     Two vectors are equal if their <see cref="Vector3.X" />, <see cref="Vector3.Y" />, and
        ///     <see cref="Vector3.Z" /> elements are equal.
        /// </remarks>
        public readonly bool Equals(Vector3 other) => this == other;

        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>The hash code.</returns>
        public readonly override int GetHashCode() => hashCode;

        /// <summary>Returns the length of this vector object.</summary>
        /// <returns>The vector's length.</returns>
        /// <altmember cref="Vector3.LengthSquared" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly float Length()
        {
            float lengthSquared = LengthSquared();
            return MathF.Sqrt(lengthSquared);
        }

        /// <summary>Returns the length of the vector squared.</summary>
        /// <returns>The vector's length squared.</returns>
        /// <remarks>This operation offers better performance than a call to the <see cref="Vector3.Length" /> method.</remarks>
        /// <altmember cref="Vector3.Length" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly float LengthSquared() => Dot(this, this);

        /// <summary>Returns the string representation of the current instance using default formatting.</summary>
        /// <returns>The string representation of the current instance.</returns>
        /// <remarks>
        ///     This method returns a string in which each element of the vector is formatted using the "G" (general) format
        ///     string and the formatting conventions of the current thread culture. The "&lt;" and "&gt;" characters are used to
        ///     begin and end the string, and the current culture's
        ///     <see cref="System.Globalization.NumberFormatInfo.NumberGroupSeparator" /> property followed by a space is used to
        ///     separate each element.
        /// </remarks>
        public readonly override string ToString() => ToString("G", CultureInfo.CurrentCulture);

        /// <summary>
        ///     Returns the string representation of the current instance using the specified format string to format
        ///     individual elements.
        /// </summary>
        /// <param name="format">A standard or custom numeric format string that defines the format of individual elements.</param>
        /// <returns>The string representation of the current instance.</returns>
        /// <remarks>
        ///     This method returns a string in which each element of the vector is formatted using <paramref name="format" />
        ///     and the current culture's formatting conventions. The "&lt;" and "&gt;" characters are used to begin and end the
        ///     string, and the current culture's <see cref="System.Globalization.NumberFormatInfo.NumberGroupSeparator" />
        ///     property followed by a space is used to separate each element.
        /// </remarks>
        /// <related type="Article" href="/dotnet/standard/base-types/standard-numeric-format-strings">
        ///     Standard Numeric Format
        ///     Strings
        /// </related>
        /// <related type="Article" href="/dotnet/standard/base-types/custom-numeric-format-strings">Custom Numeric Format Strings</related>
        public readonly string ToString(string format) => ToString(format, CultureInfo.CurrentCulture);

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
        /// <related type="Article" href="/dotnet/standard/base-types/standard-numeric-format-strings">
        ///     Standard Numeric Format
        ///     Strings
        /// </related>
        /// <related type="Article" href="/dotnet/standard/base-types/custom-numeric-format-strings">Custom Numeric Format Strings</related>
        public readonly string ToString(string format, IFormatProvider formatProvider)
        {
            StringBuilder sb = new StringBuilder();
            string separator = NumberFormatInfo.GetInstance(formatProvider).NumberGroupSeparator;
            sb.Append('<');
            sb.Append(X.ToString(format, formatProvider));
            sb.Append(separator);
            sb.Append(' ');
            sb.Append(Y.ToString(format, formatProvider));
            sb.Append(separator);
            sb.Append(' ');
            sb.Append(Z.ToString(format, formatProvider));
            sb.Append('>');
            return sb.ToString();
        }
    }
}