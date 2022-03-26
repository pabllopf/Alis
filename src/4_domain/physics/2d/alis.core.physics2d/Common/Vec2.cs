// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Vec2.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Alis.Core.Physics2D
{
    /// <summary>
    ///     A 2D column vector.
    /// </summary>
    [Obsolete(
        "Since Vec2 has been replaced with System.Numerics.Vector2, this will be implictly cast to a Vector2. It is recommended to change your code to use System.Numerics.Vector2 instead.")]
    public struct Vec2
    {
        /// <summary>
        ///     Describes whether this instance equals
        /// </summary>
        /// <param name="other">The other</param>
        /// <returns>The bool</returns>
        private bool Equals(Vec2 other) => X.Equals(other.X) && Y.Equals(other.Y);

        /// <summary>
        ///     Describes whether this instance equals
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <returns>The bool</returns>
        public override bool Equals(object obj) => obj is Vec2 other && Equals(other);

        /// <summary>
        ///     Gets the hash code
        /// </summary>
        /// <returns>The int</returns>
        public override int GetHashCode() => HashCode.Combine(X, Y);

        [Obsolete(
            "Warning: Implicit cast from Vec2 to System.Numerics.Vector2. You are advised to change your code to expect Vector2.")]
        public static implicit operator Vector2(Vec2 src) => new Vector2(src.X, src.Y);

        [Obsolete(
            "Warning: Implicit cast from System.Numerics.Vector2 to Vec2. You are advised to change your code to expect Vector2.")]
        public static implicit operator Vec2(Vector2 src) => new Vec2(src.X, src.Y);

        [Obsolete(
            "Warning: Implicit cast from System.Numerics.Vector2 to Vec2. You are advised to change your code to expect Vector2.")]
        public static implicit operator Vec2((float, float) src) => new Vec2(src.Item1, src.Item2);

        /// <summary>
        ///     The
        /// </summary>
        public float X, Y;

        /// <summary>
        ///     Construct using coordinates.
        /// </summary>
        [Obsolete(
            "Since Vec2 has been replaced with System.Numerics.Vector2, this will be implictly cast to a Vector2. It is recommended to change your code to use System.Numerics.Vector2 instead.")]
        public Vec2(float x)
        {
            X = x;
            Y = x;
        }

        /// <summary>
        ///     Construct using coordinates.
        /// </summary>
        [Obsolete(
            "Since Vec2 has been replaced with System.Numerics.Vector2, this will be implictly cast to a Vector2. It is recommended to change your code to use System.Numerics.Vector2 instead.")]
        public Vec2(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        ///     Set this vector to all zeros.
        /// </summary>
        [Obsolete(
            "Since Vec2 has been replaced with System.Numerics.Vector2, this means vectors are now considered immutable. Instead, please create a new Vector2 and assign it.",
            true)]
        public void SetZero()
        {
            X = 0.0f;
            Y = 0.0f;
        }

        /// <summary>
        ///     Set this vector to some specified coordinates.
        /// </summary>
        [Obsolete(
            "Since Vec2 has been replaced with System.Numerics.Vector2, this means vectors are now considered immutable. Instead, please create a new Vector2 and assign it.",
            true)]
        public void Set(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        ///     Sets the xy
        /// </summary>
        /// <param name="xy">The xy</param>
        [Obsolete(
            "Since Vec2 has been replaced with System.Numerics.Vector2, this means vectors are now considered immutable. Instead, please create a new Vector2 and assign it.",
            true)]
        public void Set(float xy)
        {
            X = xy;
            Y = xy;
        }

        /// <summary>
        ///     Get the length of this vector (the norm).
        /// </summary>
        [Obsolete(
            "This will still work, but may be removed in a future version. Check the field or property and see if a newer Vector2 is available.")]
        public float Length() => (float) System.Math.Sqrt(X * X + Y * Y);

        /// <summary>
        ///     Get the length squared. For performance, use this instead of
        ///     Length (if possible).
        /// </summary>
        /// [Obsolete("This will still work, but may be removed in a future version. Check the field or property and see if a newer Vector2 is available.")]
        public float LengthSquared() => X * X + Y * Y;

        /// <summary>
        ///     Convert this vector into a unit vector. Returns the length.
        /// </summary>
        [Obsolete(
            "Since Vec2 has been replaced with System.Numerics.Vector2, this won't work any more. If you need the Length, get .Length. If you need to normalize a vector, call Vector2.Normalize and re-assign the result.",
            true)]
        public float Normalize()
        {
            float length = Length();
            if (length < Settings.FLT_EPSILON)
            {
                return 0.0f;
            }

            float invLength = 1.0f / length;
            X *= invLength;
            Y *= invLength;

            return length;
        }

        /// <summary>
        ///     Does this vector contain finite coordinates?
        /// </summary>
        [Obsolete("Please switch to System.Numerics.Vector2 and use Vector2.IsValid() instead.")]
        public bool IsValid
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Math.IsValid(X) && Math.IsValid(Y);
        }

        /// <summary>
        ///     Negate this vector.
        /// </summary>
        [Obsolete("Please switch to System.Numerics.Vector2."), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2 operator -(Vec2 v1) => new Vec2(-v1.X, -v1.Y);

        [Obsolete("Please switch to System.Numerics.Vector2."), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2 operator +(Vec2 v1, Vec2 v2) => new Vec2(v1.X + v2.X, v1.Y + v2.Y);

        [Obsolete("Please switch to System.Numerics.Vector2."), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2 operator -(Vec2 v1, Vec2 v2) => new Vec2(v1.X - v2.X, v1.Y - v2.Y);

        [Obsolete("Please switch to System.Numerics.Vector2."), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2 operator *(Vec2 v1, float a) => new Vec2(v1.X * a, v1.Y * a);

        [Obsolete("Please switch to System.Numerics.Vector2."), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2 operator *(float a, Vec2 v1) => new Vec2(v1.X * a, v1.Y * a);

        [Obsolete("Please switch to System.Numerics.Vector2."), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vec2 a, Vec2 b) => a.X == b.X && a.Y == b.Y;

        [Obsolete("Please switch to System.Numerics.Vector2."), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vec2 a, Vec2 b) => a.X != b.X || a.Y != b.Y;

        /// <summary>
        ///     Gets the value of the zero
        /// </summary>
        [Obsolete("Please switch to System.Numerics.Vector2.")]
        public static Vec2 Zero
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Vec2(0, 0);
        }


        /// <summary>
        ///     Peform the dot product on two vectors.
        /// </summary>
        [Obsolete("Please switch to System.Numerics.Vector2."), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Dot(Vec2 a, Vec2 b) => a.X * b.X + a.Y * b.Y;

        /// <summary>
        ///     Perform the cross product on two vectors. In 2D this produces a scalar.
        /// </summary>
        [Obsolete("Please switch to System.Numerics.Vector2."), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Cross(Vec2 a, Vec2 b) => a.X * b.Y - a.Y * b.X;

        /// <summary>
        ///     Perform the cross product on a vector and a scalar.
        ///     In 2D this produces a vector.
        /// </summary>
        [Obsolete("Please switch to System.Numerics.Vector2 and use Vectex.Cross."),
         MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2 Cross(Vec2 a, float s) => new Vec2(s * a.Y, -s * a.X);

        /// <summary>
        ///     Perform the cross product on a scalar and a vector.
        ///     In 2D this produces a vector.
        /// </summary>
        [Obsolete("Please switch to System.Numerics.Vector2 and use Vectex.Cross."),
         MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vec2 Cross(float s, Vec2 a) => new Vec2(-s * a.Y, s * a.X);

        /// <summary>
        ///     Distances the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The float</returns>
        [Obsolete("Use Vector2.Distance instead"), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Distance(Vec2 a, Vec2 b) => (a - b).Length();

        /// <summary>
        ///     Distances the squared using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The float</returns>
        [Obsolete("Use Vector2.DistanceSquared instead"), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DistanceSquared(Vec2 a, Vec2 b)
        {
            Vec2 c = a - b;
            return Dot(c, c);
        }

        /// <summary>
        ///     Converts the array using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <returns>The result</returns>
        internal static Vec2[] ConvertArray(Vector2[] vertices)
        {
            Vec2[] result = new Vec2[vertices.Length];
            for (int i = 0; i < vertices.Length; i++)
            {
                result[i] = vertices[i];
            }

            return result;
        }
    }
}