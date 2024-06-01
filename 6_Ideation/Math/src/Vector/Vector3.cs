// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Vector3.cs
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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using HashCode = Alis.Core.Aspect.Math.Util.HashCode;

namespace Alis.Core.Aspect.Math.Vector
{
    /// <summary>
    ///     The vector
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    [Serializable]
    public struct Vector3 : IEquatable<Vector3>, IFormattable, ISerializable
    {
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
        private Vector3(float value) : this(value, value, value)
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
            
            HashCode hash = new HashCode();
            hash.Add(x);
            hash.Add(y);
            hash.Add(z);
            hashCode = hash.ToHashCode();
        }
        
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
        public static bool operator ==(Vector3 left, Vector3 right) => (System.Math.Abs(left.X - right.X) < 0.1f)
                                                                       && (System.Math.Abs(left.Y - right.Y) < 0.1f)
                                                                       && (System.Math.Abs(left.Z - right.Z) < 0.1f);
        
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
        
        /// <summary>Returns the dot product of two vectors.</summary>
        /// <param name="vector1">The first vector.</param>
        /// <param name="vector2">The second vector.</param>
        /// <returns>The dot product.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Dot(Vector3 vector1, Vector3 vector2) => vector1.X * vector2.X
                                                                     + vector1.Y * vector2.Y
                                                                     + vector1.Z * vector2.Z;
        
        /// <summary>Returns a vector with the same direction as the specified vector, but with a length of one.</summary>
        /// <param name="value">The vector to normalize.</param>
        /// <returns>The normalized vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Normalize(Vector3 value) => value / value.Length();
        
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
            return CustomMathF.Sqrt(lengthSquared);
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
        
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("X", X);
            info.AddValue("Y", Y);
            info.AddValue("Z", Z);
        }
        
        public Vector3(SerializationInfo info, StreamingContext context)
        {
            X = info.GetSingle("X");
            Y = info.GetSingle("Y");
            Z = info.GetSingle("Z");
            
            HashCode hash = new HashCode();
            hash.Add(X);
            hash.Add(Y);
            hash.Add(Z);
            hashCode = hash.ToHashCode();
        }
        
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