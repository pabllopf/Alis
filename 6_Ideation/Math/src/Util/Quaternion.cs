// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: Quaternion.cs
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

using System.Runtime.CompilerServices;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;

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

        /// <summary>
        ///     The slerp epsilon
        /// </summary>
        private const float SlerpEpsilon = 1e-6f;

        /// <summary>The X value of the vector component of the quaternion.</summary>
        public float X;

        /// <summary>The Y value of the vector component of the quaternion.</summary>
        public float Y;

        /// <summary>The Z value of the vector component of the quaternion.</summary>
        public float Z;

        /// <summary>The rotation component of the quaternion.</summary>
        public float W;

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

        /// <summary>Creates a quaternion from the specified vector and rotation parts.</summary>
        /// <param name="vectorPart">The vector part of the quaternion.</param>
        /// <param name="scalarPart">The rotation part of the quaternion.</param>
        public Quaternion(Vector3 vectorPart, float scalarPart)
        {
            X = vectorPart.X;
            Y = vectorPart.Y;
            Z = vectorPart.Z;
            W = scalarPart;

            HashCode hash = new HashCode();
            hash.Add(X);
            hash.Add(Y);
            hash.Add(Z);
            hash.Add(W);

            hashCode = hash.ToHashCode();
        }

        /// <summary>Gets a quaternion that represents a zero.</summary>
        /// <value>A quaternion whose values are <c>(0, 0, 0, 0)</c>.</value>
        public static Quaternion Zero => default(Quaternion);

        /// <summary>Gets a quaternion that represents no rotation.</summary>
        /// <value>A quaternion whose values are <c>(0, 0, 0, 1)</c>.</value>
        public static Quaternion Identity => new Quaternion(0, 0, 0, 1);


        /// <summary>Gets a value that indicates whether the current instance is the identity quaternion.</summary>
        /// <value><see langword="true" /> if the current instance is the identity quaternion; otherwise, <see langword="false" />.</value>
        public readonly bool IsIdentity => this == Identity;

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
        public static bool operator ==(Quaternion value1, Quaternion value2) => (value1.X == value2.X)
                                                                                && (value1.Y == value2.Y)
                                                                                && (value1.Z == value2.Z)
                                                                                && (value1.W == value2.W);

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

        /// <summary>Adds each element in one quaternion with its corresponding element in a second quaternion.</summary>
        /// <param name="value1">The first quaternion.</param>
        /// <param name="value2">The second quaternion.</param>
        /// <returns>The quaternion that contains the summed values of <paramref name="value1" /> and <paramref name="value2" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion Add(Quaternion value1, Quaternion value2) => value1 + value2;

        /// <summary>Concatenates two quaternions.</summary>
        /// <param name="value1">The first quaternion rotation in the series.</param>
        /// <param name="value2">The second quaternion rotation in the series.</param>
        /// <returns>
        ///     A new quaternion representing the concatenation of the <paramref name="value1" /> rotation followed by the
        ///     <paramref name="value2" /> rotation.
        /// </returns>
        public static Quaternion Concatenate(Quaternion value1, Quaternion value2)
        {
            Quaternion ans = Zero;

            // Concatenate rotation is actually q2 * q1 instead of q1 * q2.
            // So that's why value2 goes q1 and value1 goes q2.
            float q1X = value2.X;
            float q1Y = value2.Y;
            float q1Z = value2.Z;
            float q1W = value2.W;

            float q2X = value1.X;
            float q2Y = value1.Y;
            float q2Z = value1.Z;
            float q2W = value1.W;

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

        /// <summary>Returns the conjugate of a specified quaternion.</summary>
        /// <param name="value">The quaternion.</param>
        /// <returns>A new quaternion that is the conjugate of <see langword="value" />.</returns>
        public static Quaternion Conjugate(Quaternion value)
        {
            Quaternion ans = Zero;

            ans.X = -value.X;
            ans.Y = -value.Y;
            ans.Z = -value.Z;
            ans.W = value.W;

            return ans;
        }

        /// <summary>Creates a quaternion from a unit vector and an angle to rotate around the vector.</summary>
        /// <param name="axis">The unit vector to rotate around.</param>
        /// <param name="angle">The angle, in radians, to rotate around the vector.</param>
        /// <returns>The newly created quaternion.</returns>
        /// <remarks>
        ///     <paramref name="axis" /> vector must be normalized before calling this method or the resulting
        ///     <see cref="Quaternion" /> will be incorrect.
        /// </remarks>
        public static Quaternion CreateFromAxisAngle(Vector3 axis, float angle)
        {
            Quaternion ans = Zero;

            float halfAngle = angle * 0.5f;
            float s = MathF.Sin(halfAngle);
            float c = MathF.Cos(halfAngle);

            ans.X = axis.X * s;
            ans.Y = axis.Y * s;
            ans.Z = axis.Z * s;
            ans.W = c;

            return ans;
        }

        /// <summary>Creates a quaternion from the specified rotation matrix.</summary>
        /// <param name="matrix">The rotation matrix.</param>
        /// <returns>The newly created quaternion.</returns>
        public static Quaternion CreateFromRotationMatrix(Matrix4X4 matrix)
        {
            float trace = matrix.M11 + matrix.M22 + matrix.M33;

            Quaternion q = default(Quaternion);

            if (trace > 0.0f)
            {
                float s = MathF.Sqrt(trace + 1.0f);
                q.W = s * 0.5f;
                s = 0.5f / s;
                q.X = (matrix.M23 - matrix.M32) * s;
                q.Y = (matrix.M31 - matrix.M13) * s;
                q.Z = (matrix.M12 - matrix.M21) * s;
            }
            else
            {
                if ((matrix.M11 >= matrix.M22) && (matrix.M11 >= matrix.M33))
                {
                    float s = MathF.Sqrt(1.0f + matrix.M11 - matrix.M22 - matrix.M33);
                    float invS = 0.5f / s;
                    q.X = 0.5f * s;
                    q.Y = (matrix.M12 + matrix.M21) * invS;
                    q.Z = (matrix.M13 + matrix.M31) * invS;
                    q.W = (matrix.M23 - matrix.M32) * invS;
                }
                else if (matrix.M22 > matrix.M33)
                {
                    float s = MathF.Sqrt(1.0f + matrix.M22 - matrix.M11 - matrix.M33);
                    float invS = 0.5f / s;
                    q.X = (matrix.M21 + matrix.M12) * invS;
                    q.Y = 0.5f * s;
                    q.Z = (matrix.M32 + matrix.M23) * invS;
                    q.W = (matrix.M31 - matrix.M13) * invS;
                }
                else
                {
                    float s = MathF.Sqrt(1.0f + matrix.M33 - matrix.M11 - matrix.M22);
                    float invS = 0.5f / s;
                    q.X = (matrix.M31 + matrix.M13) * invS;
                    q.Y = (matrix.M32 + matrix.M23) * invS;
                    q.Z = 0.5f * s;
                    q.W = (matrix.M12 - matrix.M21) * invS;
                }
            }

            return q;
        }

        /// <summary>Creates a new quaternion from the given yaw, pitch, and roll.</summary>
        /// <param name="yaw">The yaw angle, in radians, around the Y axis.</param>
        /// <param name="pitch">The pitch angle, in radians, around the X axis.</param>
        /// <param name="roll">The roll angle, in radians, around the Z axis.</param>
        /// <returns>The resulting quaternion.</returns>
        public static Quaternion CreateFromYawPitchRoll(float yaw, float pitch, float roll)
        {
            //  Roll first, about axis the object is facing, then
            //  pitch upward, then yaw to face into the new heading
            float sr, cr, sp, cp, sy, cy;

            float halfRoll = roll * 0.5f;
            sr = MathF.Sin(halfRoll);
            cr = MathF.Cos(halfRoll);

            float halfPitch = pitch * 0.5f;
            sp = MathF.Sin(halfPitch);
            cp = MathF.Cos(halfPitch);

            float halfYaw = yaw * 0.5f;
            sy = MathF.Sin(halfYaw);
            cy = MathF.Cos(halfYaw);

            Quaternion result = Zero;

            result.X = cy * sp * cr + sy * cp * sr;
            result.Y = sy * cp * cr - cy * sp * sr;
            result.Z = cy * cp * sr - sy * sp * cr;
            result.W = cy * cp * cr + sy * sp * sr;

            return result;
        }

        /// <summary>Divides one quaternion by a second quaternion.</summary>
        /// <param name="value1">The dividend.</param>
        /// <param name="value2">The divisor.</param>
        /// <returns>The quaternion that results from dividing <paramref name="value1" /> by <paramref name="value2" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion Divide(Quaternion value1, Quaternion value2) => value1 / value2;

        /// <summary>Calculates the dot product of two quaternions.</summary>
        /// <param name="quaternion1">The first quaternion.</param>
        /// <param name="quaternion2">The second quaternion.</param>
        /// <returns>The dot product.</returns>
        public static float Dot(Quaternion quaternion1, Quaternion quaternion2) => quaternion1.X * quaternion2.X +
                                                                                   quaternion1.Y * quaternion2.Y +
                                                                                   quaternion1.Z * quaternion2.Z +
                                                                                   quaternion1.W * quaternion2.W;

        /// <summary>Returns the inverse of a quaternion.</summary>
        /// <param name="value">The quaternion.</param>
        /// <returns>The inverted quaternion.</returns>
        public static Quaternion Inverse(Quaternion value)
        {
            //  -1   (       a              -v       )
            // q   = ( -------------   ------------- )
            //       (  a^2 + |v|^2  ,  a^2 + |v|^2  )

            Quaternion ans = Zero;

            float ls = value.X * value.X + value.Y * value.Y + value.Z * value.Z + value.W * value.W;
            float invNorm = 1.0f / ls;

            ans.X = -value.X * invNorm;
            ans.Y = -value.Y * invNorm;
            ans.Z = -value.Z * invNorm;
            ans.W = value.W * invNorm;

            return ans;
        }

        /// <summary>
        ///     Performs a linear interpolation between two quaternions based on a value that specifies the weighting of the
        ///     second quaternion.
        /// </summary>
        /// <param name="quaternion1">The first quaternion.</param>
        /// <param name="quaternion2">The second quaternion.</param>
        /// <param name="amount">The relative weight of <paramref name="quaternion2" /> in the interpolation.</param>
        /// <returns>The interpolated quaternion.</returns>
        public static Quaternion Lerp(Quaternion quaternion1, Quaternion quaternion2, float amount)
        {
            float t = amount;
            float t1 = 1.0f - t;

            Quaternion r = default(Quaternion);

            float dot = quaternion1.X * quaternion2.X + quaternion1.Y * quaternion2.Y +
                        quaternion1.Z * quaternion2.Z + quaternion1.W * quaternion2.W;

            if (dot >= 0.0f)
            {
                r.X = t1 * quaternion1.X + t * quaternion2.X;
                r.Y = t1 * quaternion1.Y + t * quaternion2.Y;
                r.Z = t1 * quaternion1.Z + t * quaternion2.Z;
                r.W = t1 * quaternion1.W + t * quaternion2.W;
            }
            else
            {
                r.X = t1 * quaternion1.X - t * quaternion2.X;
                r.Y = t1 * quaternion1.Y - t * quaternion2.Y;
                r.Z = t1 * quaternion1.Z - t * quaternion2.Z;
                r.W = t1 * quaternion1.W - t * quaternion2.W;
            }

            // Normalize it.
            float ls = r.X * r.X + r.Y * r.Y + r.Z * r.Z + r.W * r.W;
            float invNorm = 1.0f / MathF.Sqrt(ls);

            r.X *= invNorm;
            r.Y *= invNorm;
            r.Z *= invNorm;
            r.W *= invNorm;

            return r;
        }

        /// <summary>Returns the quaternion that results from multiplying two quaternions together.</summary>
        /// <param name="value1">The first quaternion.</param>
        /// <param name="value2">The second quaternion.</param>
        /// <returns>The product quaternion.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion Multiply(Quaternion value1, Quaternion value2) => value1 * value2;

        /// <summary>
        ///     Returns the quaternion that results from scaling all the components of a specified quaternion by a scalar
        ///     factor.
        /// </summary>
        /// <param name="value1">The source quaternion.</param>
        /// <param name="value2">The scalar value.</param>
        /// <returns>The scaled quaternion.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion Multiply(Quaternion value1, float value2) => value1 * value2;

        /// <summary>Reverses the sign of each component of the quaternion.</summary>
        /// <param name="value">The quaternion to negate.</param>
        /// <returns>The negated quaternion.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion Negate(Quaternion value) => -value;

        /// <summary>Divides each component of a specified <see cref="Quaternion" /> by its length.</summary>
        /// <param name="value">The quaternion to normalize.</param>
        /// <returns>The normalized quaternion.</returns>
        public static Quaternion Normalize(Quaternion value)
        {
            Quaternion ans = Zero;

            float ls = value.X * value.X + value.Y * value.Y + value.Z * value.Z + value.W * value.W;

            float invNorm = 1.0f / MathF.Sqrt(ls);

            ans.X = value.X * invNorm;
            ans.Y = value.Y * invNorm;
            ans.Z = value.Z * invNorm;
            ans.W = value.W * invNorm;

            return ans;
        }

        /// <summary>Interpolates between two quaternions, using spherical linear interpolation.</summary>
        /// <param name="quaternion1">The first quaternion.</param>
        /// <param name="quaternion2">The second quaternion.</param>
        /// <param name="amount">The relative weight of the second quaternion in the interpolation.</param>
        /// <returns>The interpolated quaternion.</returns>
        public static Quaternion Slerp(Quaternion quaternion1, Quaternion quaternion2, float amount)
        {
            float t = amount;

            float cosOmega = quaternion1.X * quaternion2.X + quaternion1.Y * quaternion2.Y +
                             quaternion1.Z * quaternion2.Z + quaternion1.W * quaternion2.W;

            bool flip = false;

            if (cosOmega < 0.0f)
            {
                flip = true;
                cosOmega = -cosOmega;
            }

            float s1, s2;

            if (cosOmega > 1.0f - SlerpEpsilon)
            {
                // Too close, do straight linear interpolation.
                s1 = 1.0f - t;
                s2 = flip ? -t : t;
            }
            else
            {
                float omega = MathF.Acos(cosOmega);
                float invSinOmega = 1 / MathF.Sin(omega);

                s1 = MathF.Sin((1.0f - t) * omega) * invSinOmega;
                s2 = flip
                    ? -MathF.Sin(t * omega) * invSinOmega
                    : MathF.Sin(t * omega) * invSinOmega;
            }

            Quaternion ans = Zero;

            ans.X = s1 * quaternion1.X + s2 * quaternion2.X;
            ans.Y = s1 * quaternion1.Y + s2 * quaternion2.Y;
            ans.Z = s1 * quaternion1.Z + s2 * quaternion2.Z;
            ans.W = s1 * quaternion1.W + s2 * quaternion2.W;

            return ans;
        }

        /// <summary>Subtracts each element in a second quaternion from its corresponding element in a first quaternion.</summary>
        /// <param name="value1">The first quaternion.</param>
        /// <param name="value2">The second quaternion.</param>
        /// <returns>
        ///     The quaternion containing the values that result from subtracting each element in <paramref name="value2" />
        ///     from its corresponding element in <paramref name="value1" />.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion Subtract(Quaternion value1, Quaternion value2) => value1 - value2;

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
        public readonly bool Equals(Quaternion other)
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

        /// <summary>Calculates the length of the quaternion.</summary>
        /// <returns>The computed length of the quaternion.</returns>
        public readonly float Length()
        {
            float lengthSquared = LengthSquared();
            return MathF.Sqrt(lengthSquared);
        }

        /// <summary>Calculates the squared length of the quaternion.</summary>
        /// <returns>The length squared of the quaternion.</returns>
        public readonly float LengthSquared() => X * X + Y * Y + Z * Z + W * W;

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