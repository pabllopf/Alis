// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Vector3F.cs
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

namespace Alis.Core.Aspect.Math.Vector
{
    /// <summary>
    ///     Represents a 3D vector with single-precision floating-point X, Y, and Z components.
    ///     Provides standard vector operations such as addition, subtraction, dot product, cross product,
    ///     normalization, and length calculation. Implements <see cref="IEquatable{T}" />, <see cref="IFormattable" />, and <see cref="ISerializable" />.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3F : IEquatable<Vector3F>, IFormattable, ISerializable
    {
        /// <summary>
        ///     The precomputed hash code for this vector instance.
        /// </summary>
        private readonly int hashCode;

        /// <summary>The X component of the vector.</summary>
        public float X { get; set; }

        /// <summary>The Y component of the vector.</summary>
        public float Y { get; set; }

        /// <summary>The Z component of the vector.</summary>
        public float Z { get; set; }

        /// <summary>Creates a new <see cref="Vector3F" /> object whose three elements have the same value.</summary>
        /// <param name="value">The value to assign to all three components.</param>
        private Vector3F(float value) : this(value, value, value)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Vector3F" /> struct from a <see cref="Vector2F" /> and a Z component.
        /// </summary>
        /// <param name="value">The <see cref="Vector2F" /> providing X and Y components.</param>
        /// <param name="z">The Z component value.</param>
        public Vector3F(Vector2F value, float z) : this(value.X, value.Y, z)
        {
        }

        /// <summary>Creates a vector whose elements have the specified values.</summary>
        /// <param name="x">The value to assign to the <see cref="X" /> component.</param>
        /// <param name="y">The value to assign to the <see cref="Y" /> component.</param>
        /// <param name="z">The value to assign to the <see cref="Z" /> component.</param>
        public Vector3F(float x, float y, float z)
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

        /// <summary>Gets a vector whose three elements are equal to zero.</summary>
        /// <value>A vector with all components set to zero: <c>(0, 0, 0)</c>.</value>
        public static Vector3F Zero => default(Vector3F);

        /// <summary>Gets a vector whose three elements are equal to one.</summary>
        /// <value>A vector with all components set to one: <c>(1, 1, 1)</c>.</value>
        public static Vector3F One => new Vector3F(1.0f);

        /// <summary>Gets the unit vector for the X axis.</summary>
        /// <value>The vector <c>(1, 0, 0)</c>.</value>
        public static Vector3F UnitX => new Vector3F(1.0f, 0.0f, 0.0f);

        /// <summary>Gets the unit vector for the Y axis.</summary>
        /// <value>The vector <c>(0, 1, 0)</c>.</value>
        public static Vector3F UnitY => new Vector3F(0.0f, 1.0f, 0.0f);

        /// <summary>Gets the unit vector for the Z axis.</summary>
        /// <value>The vector <c>(0, 0, 1)</c>.</value>
        public static Vector3F UnitZ => new Vector3F(0.0f, 0.0f, 1.0f);

        /// <summary>Adds two vectors together component-wise.</summary>
        /// <param name="left">The first vector to add.</param>
        /// <param name="right">The second vector to add.</param>
        /// <returns>The summed vector.</returns>
        public static Vector3F operator +(Vector3F left, Vector3F right) => new Vector3F(
            left.X + right.X,
            left.Y + right.Y,
            left.Z + right.Z
        );

        /// <summary>Divides the first vector by the second component-wise.</summary>
        /// <param name="left">The dividend vector.</param>
        /// <param name="right">The divisor vector.</param>
        /// <returns>The component-wise quotient vector.</returns>
        public static Vector3F operator /(Vector3F left, Vector3F right) => new Vector3F(
            left.X / right.X,
            left.Y / right.Y,
            left.Z / right.Z
        );

        /// <summary>Divides the specified vector by a scalar value.</summary>
        /// <param name="value1">The vector.</param>
        /// <param name="value2">The scalar divisor.</param>
        /// <returns>The scaled result.</returns>
        public static Vector3F operator /(Vector3F value1, float value2) => value1 / new Vector3F(value2);

        /// <summary>Returns a value that indicates whether each pair of elements in two specified vectors is equal within a tolerance of 0.1.</summary>
        /// <param name="left">The first vector to compare.</param>
        /// <param name="right">The second vector to compare.</param>
        /// <returns><c>true</c> if equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Vector3F left, Vector3F right) => (System.Math.Abs(left.X - right.X) < 0.1f)
                                                                         && (System.Math.Abs(left.Y - right.Y) < 0.1f)
                                                                         && (System.Math.Abs(left.Z - right.Z) < 0.1f);

        /// <summary>Returns a value that indicates whether two specified vectors are not equal.</summary>
        /// <param name="left">The first vector to compare.</param>
        /// <param name="right">The second vector to compare.</param>
        /// <returns><c>true</c> if not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Vector3F left, Vector3F right) => !(left == right);

        /// <summary>Returns a new vector whose values are the component-wise product of two specified vectors.</summary>
        /// <param name="left">The first vector.</param>
        /// <param name="right">The second vector.</param>
        /// <returns>The element-wise product vector.</returns>
        public static Vector3F operator *(Vector3F left, Vector3F right) => new Vector3F(
            left.X * right.X,
            left.Y * right.Y,
            left.Z * right.Z
        );

        /// <summary>Multiplies the specified vector by a scalar value.</summary>
        /// <param name="left">The vector.</param>
        /// <param name="right">The scalar multiplier.</param>
        /// <returns>The scaled vector.</returns>
        public static Vector3F operator *(Vector3F left, float right) => left * new Vector3F(right);

        /// <summary>Multiplies a scalar value by the specified vector.</summary>
        /// <param name="left">The scalar multiplier.</param>
        /// <param name="right">The vector.</param>
        /// <returns>The scaled vector.</returns>
        public static Vector3F operator *(float left, Vector3F right) => right * left;

        /// <summary>Subtracts the second vector from the first component-wise.</summary>
        /// <param name="left">The first vector.</param>
        /// <param name="right">The second vector.</param>
        /// <returns>The difference vector.</returns>
        public static Vector3F operator -(Vector3F left, Vector3F right) => new Vector3F(
            left.X - right.X,
            left.Y - right.Y,
            left.Z - right.Z
        );

        /// <summary>Negates the specified vector.</summary>
        /// <param name="value">The vector to negate.</param>
        /// <returns>The negated vector.</returns>
        public static Vector3F operator -(Vector3F value) => Zero - value;

        /// <summary>Computes the cross product of two vectors.</summary>
        /// <param name="vector1">The first vector.</param>
        /// <param name="vector2">The second vector.</param>
        /// <returns>The cross product vector orthogonal to both inputs.</returns>
        public static Vector3F Cross(Vector3F vector1, Vector3F vector2) => new Vector3F(
            vector1.Y * vector2.Z - vector1.Z * vector2.Y,
            vector1.Z * vector2.X - vector1.X * vector2.Z,
            vector1.X * vector2.Y - vector1.Y * vector2.X
        );

        /// <summary>Returns the dot product of two vectors.</summary>
        /// <param name="vector1">The first vector.</param>
        /// <param name="vector2">The second vector.</param>
        /// <returns>The dot product (scalar).</returns>
        public static float Dot(Vector3F vector1, Vector3F vector2) => vector1.X * vector2.X
                                                                       + vector1.Y * vector2.Y
                                                                       + vector1.Z * vector2.Z;

        /// <summary>Returns a vector with the same direction as the specified vector, but with a length of one.</summary>
        /// <param name="value">The vector to normalize.</param>
        /// <returns>The normalized unit vector.</returns>
        public static Vector3F Normalize(Vector3F value) => value / value.Length();

        /// <summary>Returns a value that indicates whether this instance and a specified object are equal.</summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns><c>true</c> if equal; otherwise, <c>false</c>.</returns>
        public readonly override bool Equals(object obj) => obj is Vector3F other && Equals(other);

        /// <summary>Returns a value that indicates whether this instance and another vector are equal.</summary>
        /// <param name="other">The other vector.</param>
        /// <returns><c>true</c> if equal; otherwise, <c>false</c>.</returns>
        public readonly bool Equals(Vector3F other) => this == other;

        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>The precomputed hash code.</returns>
        public readonly override int GetHashCode() => hashCode;

        /// <summary>Returns the Euclidean length (magnitude) of the vector.</summary>
        /// <returns>The vector's length.</returns>
        public readonly float Length()
        {
            float lengthSquared = LengthSquared();
            return (float) System.Math.Sqrt(lengthSquared);
        }

        /// <summary>Returns the squared length of the vector. This is faster than <see cref="Length" /> as it avoids a square root.</summary>
        /// <returns>The squared length.</returns>
        public readonly float LengthSquared() => Dot(this, this);

        /// <summary>Returns the default string representation of the current instance.</summary>
        /// <returns>A string in the format "&lt;X, Y, Z&gt;".</returns>
        public readonly override string ToString() => ToString("G", CultureInfo.CurrentCulture);

        /// <summary>
        ///     Populates a <see cref="SerializationInfo" /> with the vector's component data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo" /> to populate.</param>
        /// <param name="context">The streaming context.</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("x", X);
            info.AddValue("y", Y);
            info.AddValue("z", Z);
        }

        /// <summary>
        ///     Returns the string representation using the specified format and format provider.
        /// </summary>
        /// <param name="format">A standard or custom numeric format string.</param>
        /// <param name="formatProvider">A format provider for culture-specific formatting.</param>
        /// <returns>The formatted string.</returns>
        public readonly string ToString(string format, IFormatProvider formatProvider) => string.Format(
            formatProvider,
            "<{0}, {1}, {2}>",
            X.ToString(format, formatProvider),
            Y.ToString(format, formatProvider),
            Z.ToString(format, formatProvider)
        );
    }
}
