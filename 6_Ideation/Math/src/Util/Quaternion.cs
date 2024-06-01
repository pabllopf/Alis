// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Quaternion.cs
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
using System.Runtime.Serialization;

namespace Alis.Core.Aspect.Math.Util
{
    /// <summary>
    ///     The quaternion
    /// </summary>
    public struct Quaternion 
    {
        /// <summary>
        ///     The hash code
        /// </summary>
        private readonly int hashCode;
        
        /// <summary>The X value of the vector component of the quaternion.</summary>
        public float X { get; private set; }
        
        /// <summary>The Y value of the vector component of the quaternion.</summary>
        public float Y { get; private set; }
        
        /// <summary>The Z value of the vector component of the quaternion.</summary>
        public float Z { get; private set; }
        
        /// <summary>The rotation component of the quaternion.</summary>
        public float W { get; private set; }
        
        /// <summary>
        ///     The count
        /// </summary>
        internal const int Count = 4;
        
        /// <summary>Constructs a quaternion from the specified components.</summary>
        /// <param name="x">The value to assign to the X component of the quaternion.</param>
        /// <param name="y">The value to assign to the Y component of the quaternion.</param>
        /// <param name="z">The value to assign to the Z component of the quaternion.</param>
        /// <param name="w">The value to assign to the W component of the quaternion.</param>
        public Quaternion(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
            
            HashCode hash = new HashCode();
            hash.Add(X);
            hash.Add(Y);
            hash.Add(Z);
            hash.Add(W);
            
            hashCode = hash.ToHashCode();
        }
        
        /// <summary>Gets a quaternion that represents a zero.</summary>
        /// <value>A quaternion whose values are <c>(0, 0, 0, 0)</c>.</value>
        private static Quaternion Zero => default(Quaternion);
        
        /// <summary>Adds each element in one quaternion with its corresponding element in a second quaternion.</summary>
        /// <param name="value1">The first quaternion.</param>
        /// <param name="value2">The second quaternion.</param>
        /// <returns>The quaternion that contains the summed values of <paramref name="value1" /> and <paramref name="value2" />.</returns>
        /// <remarks>
        ///     The <see cref="Quaternion.op_Addition" /> method defines the operation of the addition operator for
        ///     <see cref="Quaternion" /> objects.
        /// </remarks>
        public static Quaternion operator +(Quaternion value1, Quaternion value2)
        {
            Quaternion ans = Zero;
            
            ans.X = value1.X + value2.X;
            ans.Y = value1.Y + value2.Y;
            ans.Z = value1.Z + value2.Z;
            ans.W = value1.W + value2.W;
            
            return ans;
        }
        
        /// <summary>Divides one quaternion by a second quaternion.</summary>
        /// <param name="value1">The dividend.</param>
        /// <param name="value2">The divisor.</param>
        /// <returns>The quaternion that results from dividing <paramref name="value1" /> by <paramref name="value2" />.</returns>
        /// <remarks>
        ///     The <see cref="Quaternion.op_Division" /> method defines the division operation for <see cref="Quaternion" />
        ///     objects.
        /// </remarks>
        public static Quaternion operator /(Quaternion value1, Quaternion value2)
        {
            Quaternion ans = Zero;
            
            float q1X = value1.X;
            float q1Y = value1.Y;
            float q1Z = value1.Z;
            float q1W = value1.W;
            
            //-------------------------------------
            // Inverse part.
            float ls = value2.X * value2.X + value2.Y * value2.Y +
                       value2.Z * value2.Z + value2.W * value2.W;
            float invNorm = 1.0f / ls;
            
            float q2X = -value2.X * invNorm;
            float q2Y = -value2.Y * invNorm;
            float q2Z = -value2.Z * invNorm;
            float q2W = value2.W * invNorm;
            
            //-------------------------------------
            // Multiply part.
            
            // cross(av, bv)
            float cx = q1Y * q2Z - q1Z * q2Y;
            float cy = q1Z * q2X - q1X * q2Z;
            float cz = q1X * q2Y - q1Y * q2X;
            
            float dot = q1X * q2X + q1Y * q2Y + q1Z * q2Z;
            
            ans.X = q1X * q2W + q2X * q1W + cx;
            ans.Y = q1Y * q2W + q2Y * q1W + cy;
            ans.Z = q1Z * q2W + q2Z * q1W + cz;
            ans.W = q1W * q2W - dot;
            
            return ans;
        }
        
        /// <summary>Returns a value that indicates whether two quaternions are equal.</summary>
        /// <param name="value1">The first quaternion to compare.</param>
        /// <param name="value2">The second quaternion to compare.</param>
        /// <returns><see langword="true" /> if the two quaternions are equal; otherwise, <see langword="false" />.</returns>
        /// <remarks>
        ///     Two quaternions are equal if each of their corresponding components is equal.
        ///     The <see cref="Quaternion.op_Equality" /> method defines the operation of the equality operator for
        ///     <see cref="Quaternion" /> objects.
        /// </remarks>
        public static bool operator ==(Quaternion value1, Quaternion value2) => (System.Math.Abs(value1.X - value2.X) < 0.1f)
                                                                                && (System.Math.Abs(value1.Y - value2.Y) < 0.1f)
                                                                                && (System.Math.Abs(value1.Z - value2.Z) < 0.1f)
                                                                                && (System.Math.Abs(value1.W - value2.W) < 0.1f);
        
        /// <summary>Returns a value that indicates whether two quaternions are not equal.</summary>
        /// <param name="value1">The first quaternion to compare.</param>
        /// <param name="value2">The second quaternion to compare.</param>
        /// <returns>
        ///     <see langword="true" /> if <paramref name="value1" /> and <paramref name="value2" /> are not equal; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        public static bool operator !=(Quaternion value1, Quaternion value2) => !(value1 == value2);
        
        /// <summary>Returns the quaternion that results from multiplying two quaternions together.</summary>
        /// <param name="value1">The first quaternion.</param>
        /// <param name="value2">The second quaternion.</param>
        /// <returns>The product quaternion.</returns>
        public static Quaternion operator *(Quaternion value1, Quaternion value2)
        {
            Quaternion ans = Zero;
            
            float q1X = value1.X;
            float q1Y = value1.Y;
            float q1Z = value1.Z;
            float q1W = value1.W;
            
            float q2X = value2.X;
            float q2Y = value2.Y;
            float q2Z = value2.Z;
            float q2W = value2.W;
            
            // cross(av, bv)
            float cx = q1Y * q2Z - q1Z * q2Y;
            float cy = q1Z * q2X - q1X * q2Z;
            float cz = q1X * q2Y - q1Y * q2X;
            
            float dot = q1X * q2X + q1Y * q2Y + q1Z * q2Z;
            
            ans.X = q1X * q2W + q2X * q1W + cx;
            ans.Y = q1Y * q2W + q2Y * q1W + cy;
            ans.Z = q1Z * q2W + q2Z * q1W + cz;
            ans.W = q1W * q2W - dot;
            
            return ans;
        }
        
        /// <summary>
        ///     Returns the quaternion that results from scaling all the components of a specified quaternion by a scalar
        ///     factor.
        /// </summary>
        /// <param name="value1">The source quaternion.</param>
        /// <param name="value2">The scalar value.</param>
        /// <returns>The scaled quaternion.</returns>
        public static Quaternion operator *(Quaternion value1, float value2)
        {
            Quaternion ans = Zero;
            
            ans.X = value1.X * value2;
            ans.Y = value1.Y * value2;
            ans.Z = value1.Z * value2;
            ans.W = value1.W * value2;
            
            return ans;
        }
        
        /// <summary>Subtracts each element in a second quaternion from its corresponding element in a first quaternion.</summary>
        /// <param name="value1">The first quaternion.</param>
        /// <param name="value2">The second quaternion.</param>
        /// <returns>
        ///     The quaternion containing the values that result from subtracting each element in <paramref name="value2" />
        ///     from its corresponding element in <paramref name="value1" />.
        /// </returns>
        /// <remarks>
        ///     The <see cref="Quaternion.op_Subtraction" /> method defines the operation of the subtraction operator for
        ///     <see cref="Quaternion" /> objects.
        /// </remarks>
        public static Quaternion operator -(Quaternion value1, Quaternion value2)
        {
            Quaternion ans = Zero;
            
            ans.X = value1.X - value2.X;
            ans.Y = value1.Y - value2.Y;
            ans.Z = value1.Z - value2.Z;
            ans.W = value1.W - value2.W;
            
            return ans;
        }
        
        /// <summary>Reverses the sign of each component of the quaternion.</summary>
        /// <param name="value">The quaternion to negate.</param>
        /// <returns>The negated quaternion.</returns>
        /// <remarks>
        ///     The <see cref="Quaternion.op_UnaryNegation" /> method defines the operation of the unary negation operator for
        ///     <see cref="Quaternion" /> objects.
        /// </remarks>
        public static Quaternion operator -(Quaternion value)
        {
            Quaternion ans = Zero;
            
            ans.X = -value.X;
            ans.Y = -value.Y;
            ans.Z = -value.Z;
            ans.W = -value.W;
            
            return ans;
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
        ///     <see cref="Quaternion" /> object and the corresponding components of each matrix are equal.
        /// </remarks>
        public readonly override bool Equals(object obj) => obj is Quaternion other && Equals(other);
        
        /// <summary>Returns a value that indicates whether this instance and another quaternion are equal.</summary>
        /// <param name="other">The other quaternion.</param>
        /// <returns><see langword="true" /> if the two quaternions are equal; otherwise, <see langword="false" />.</returns>
        /// <remarks>Two quaternions are equal if each of their corresponding components is equal.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly bool Equals(Quaternion other)
        {
            return SoftwareFallback(in this, other);
            
            static bool SoftwareFallback(in Quaternion self, Quaternion other) => self.X.Equals(other.X)
                                                                                  && self.Y.Equals(other.Y)
                                                                                  && self.Z.Equals(other.Z)
                                                                                  && self.W.Equals(other.W);
        }
        
        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>The hash code.</returns>
        public readonly override int GetHashCode() => hashCode;
        
        /// <summary>Returns a string that represents this quaternion.</summary>
        /// <returns>The string representation of this quaternion.</returns>
        /// <remarks>
        ///     The numeric values in the returned string are formatted by using the conventions of the current culture. For
        ///     example, for the en-US culture, the returned string might appear as <c>{X:1.1 Y:2.2 Z:3.3 W:4.4}</c>.
        /// </remarks>
        public readonly override string ToString() =>
            $"{{X:{X} Y:{Y} Z:{Z} W:{W}}}";
    }
}