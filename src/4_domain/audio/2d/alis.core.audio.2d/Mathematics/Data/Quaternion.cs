// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Quaternion.cs
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
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using Alis.Core.Audio.Mathematics.Matrix;
using Alis.Core.Audio.Mathematics.Vector;

namespace Alis.Core.Audio.Mathematics.Data
{
    /// <summary>
    ///     Represents a Quaternion.
    /// </summary>
    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct Quaternion : IEquatable<Quaternion>
    {
        /// <summary>
        ///     The X, Y and Z components of this instance.
        /// </summary>
        public Vector3 Xyz;

        /// <summary>
        ///     The W component of this instance.
        /// </summary>
        public float W;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Quaternion" /> struct.
        /// </summary>
        /// <param name="v">The vector part.</param>
        /// <param name="w">The w part.</param>
        public Quaternion(Vector3 v, float w)
        {
            Xyz = v;
            W = w;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Quaternion" /> struct.
        /// </summary>
        /// <param name="x">The x component.</param>
        /// <param name="y">The y component.</param>
        /// <param name="z">The z component.</param>
        /// <param name="w">The w component.</param>
        public Quaternion(float x, float y, float z, float w)
            : this(new Vector3(x, y, z), w)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Quaternion" /> struct from given Euler angles in radians.
        ///     The rotations will get applied in following order:
        ///     1. around X axis, 2. around Y axis, 3. around Z axis.
        /// </summary>
        /// <param name="rotationX">Counterclockwise rotation around X axis in radian.</param>
        /// <param name="rotationY">Counterclockwise rotation around Y axis in radian.</param>
        /// <param name="rotationZ">Counterclockwise rotation around Z axis in radian.</param>
        public Quaternion(float rotationX, float rotationY, float rotationZ)
        {
            rotationX *= 0.5f;
            rotationY *= 0.5f;
            rotationZ *= 0.5f;

            float c1 = MathF.Cos(rotationX);
            float c2 = MathF.Cos(rotationY);
            float c3 = MathF.Cos(rotationZ);
            float s1 = MathF.Sin(rotationX);
            float s2 = MathF.Sin(rotationY);
            float s3 = MathF.Sin(rotationZ);

            W = c1 * c2 * c3 - s1 * s2 * s3;
            Xyz.X = s1 * c2 * c3 + c1 * s2 * s3;
            Xyz.Y = c1 * s2 * c3 - s1 * c2 * s3;
            Xyz.Z = c1 * c2 * s3 + s1 * s2 * c3;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Quaternion" /> struct from given Euler angles in radians.
        ///     The rotations will get applied in following order:
        ///     1. Around X, 2. Around Y, 3. Around Z.
        /// </summary>
        /// <param name="eulerAngles">The counterclockwise euler angles as a Vector3.</param>
        public Quaternion(Vector3 eulerAngles)
            : this(eulerAngles.X, eulerAngles.Y, eulerAngles.Z)
        {
        }

        /// <summary>
        ///     Gets or sets the X component of this instance.
        /// </summary>
        [XmlIgnore]
        public float X
        {
            get => Xyz.X;
            set => Xyz.X = value;
        }

        /// <summary>
        ///     Gets or sets the Y component of this instance.
        /// </summary>
        [XmlIgnore]
        public float Y
        {
            get => Xyz.Y;
            set => Xyz.Y = value;
        }

        /// <summary>
        ///     Gets or sets the Z component of this instance.
        /// </summary>
        [XmlIgnore]
        public float Z
        {
            get => Xyz.Z;
            set => Xyz.Z = value;
        }

        /// <summary>
        ///     Convert the current quaternion to axis angle representation.
        /// </summary>
        /// <param name="axis">The resultant axis.</param>
        /// <param name="angle">The resultant angle.</param>
        public void ToAxisAngle(out Vector3 axis, out float angle)
        {
            Vector4 result = ToAxisAngle();
            axis = result.Xyz;
            angle = result.W;
        }

        /// <summary>
        ///     Convert this instance to an axis-angle representation.
        /// </summary>
        /// <returns>A Vector4 that is the axis-angle representation of this quaternion.</returns>
        public Vector4 ToAxisAngle()
        {
            Quaternion q = this;
            if (Math.Abs(q.W) > 1.0f)
            {
                q.Normalize();
            }

            Vector4 result = new Vector4
            {
                W = 2.0f * MathF.Acos(q.W) // angle
            };

            float den = MathF.Sqrt(1.0f - q.W * q.W);
            if (den > 0.0001f)
            {
                result.Xyz = q.Xyz / den;
            }
            else
            {
                // This occurs when the angle is zero.
                // Not a problem: just set an arbitrary normalized axis.
                result.Xyz = Vector3.UnitX;
            }

            return result;
        }

        /// <summary>
        ///     Convert the current quaternion to Euler angle representation.
        /// </summary>
        /// <param name="angles">The Euler angles in radians.</param>
        public void ToEulerAngles(out Vector3 angles)
        {
            angles = ToEulerAngles();
        }

        /// <summary>
        ///     Convert this instance to an Euler angle representation.
        /// </summary>
        /// <returns>The Euler angles in radians.</returns>
        public Vector3 ToEulerAngles()
        {
            /*
            reference
            http://en.wikipedia.org/wiki/Conversion_between_quaternions_and_Euler_angles
            http://www.euclideanspace.com/maths/geometry/rotations/conversions/quaternionToEuler/
            */

            Quaternion q = this;

            Vector3 eulerAngles;

            // Threshold for the singularities found at the north/south poles.
            const float SINGULARITY_THRESHOLD = 0.4999995f;

            float sqw = q.W * q.W;
            float sqx = q.X * q.X;
            float sqy = q.Y * q.Y;
            float sqz = q.Z * q.Z;
            float unit = sqx + sqy + sqz + sqw; // if normalised is one, otherwise is correction factor
            float singularityTest = q.X * q.Z + q.W * q.Y;

            if (singularityTest > SINGULARITY_THRESHOLD * unit)
            {
                eulerAngles.Z = (float) (2 * Math.Atan2(q.X, q.W));
                eulerAngles.Y = MathHelper.PiOver2;
                eulerAngles.X = 0;
            }
            else if (singularityTest < -SINGULARITY_THRESHOLD * unit)
            {
                eulerAngles.Z = (float) (-2 * Math.Atan2(q.X, q.W));
                eulerAngles.Y = -MathHelper.PiOver2;
                eulerAngles.X = 0;
            }
            else
            {
                eulerAngles.Z = MathF.Atan2(2 * (q.W * q.Z - q.X * q.Y), sqw + sqx - sqy - sqz);
                eulerAngles.Y = MathF.Asin(2 * singularityTest / unit);
                eulerAngles.X = MathF.Atan2(2 * (q.W * q.X - q.Y * q.Z), sqw - sqx - sqy + sqz);
            }

            return eulerAngles;
        }

        /// <summary>
        ///     Gets the length (magnitude) of the quaternion.
        /// </summary>
        /// <seealso cref="LengthSquared" />
        public float Length => MathF.Sqrt(W * W + Xyz.LengthSquared);

        /// <summary>
        ///     Gets the square of the quaternion length (magnitude).
        /// </summary>
        public float LengthSquared => W * W + Xyz.LengthSquared;

        /// <summary>
        ///     Returns a copy of the Quaternion scaled to unit length.
        /// </summary>
        /// <returns>The normalized copy.</returns>
        public Quaternion Normalized()
        {
            Quaternion q = this;
            q.Normalize();
            return q;
        }

        /// <summary>
        ///     Inverts this Quaternion.
        /// </summary>
        public void Invert()
        {
            Invert(in this, out this);
        }

        /// <summary>
        ///     Returns the inverse of this Quaternion.
        /// </summary>
        /// <returns>The inverted copy.</returns>
        public Quaternion Inverted()
        {
            Quaternion q = this;
            q.Invert();
            return q;
        }

        /// <summary>
        ///     Scales the Quaternion to unit length.
        /// </summary>
        public void Normalize()
        {
            float scale = 1.0f / Length;
            Xyz *= scale;
            W *= scale;
        }

        /// <summary>
        ///     Inverts the Vector3 component of this Quaternion.
        /// </summary>
        public void Conjugate()
        {
            Xyz = -Xyz;
        }

        /// <summary>
        ///     Defines the identity quaternion.
        /// </summary>
        public static readonly Quaternion Identity = new Quaternion(0, 0, 0, 1);

        /// <summary>
        ///     Add two quaternions.
        /// </summary>
        /// <param name="left">The first operand.</param>
        /// <param name="right">The second operand.</param>
        /// <returns>The result of the addition.</returns>
        [Pure]
        public static Quaternion Add(Quaternion left, Quaternion right) =>
            new Quaternion(
                left.Xyz + right.Xyz,
                left.W + right.W);

        /// <summary>
        ///     Add two quaternions.
        /// </summary>
        /// <param name="left">The first operand.</param>
        /// <param name="right">The second operand.</param>
        /// <param name="result">The result of the addition.</param>
        public static void Add(in Quaternion left, in Quaternion right, out Quaternion result)
        {
            result = new Quaternion(
                left.Xyz + right.Xyz,
                left.W + right.W);
        }

        /// <summary>
        ///     Subtracts two instances.
        /// </summary>
        /// <param name="left">The left instance.</param>
        /// <param name="right">The right instance.</param>
        /// <returns>The result of the operation.</returns>
        [Pure]
        public static Quaternion Sub(Quaternion left, Quaternion right) =>
            new Quaternion(
                left.Xyz - right.Xyz,
                left.W - right.W);

        /// <summary>
        ///     Subtracts two instances.
        /// </summary>
        /// <param name="left">The left instance.</param>
        /// <param name="right">The right instance.</param>
        /// <param name="result">The result of the operation.</param>
        public static void Sub(in Quaternion left, in Quaternion right, out Quaternion result)
        {
            result = new Quaternion(
                left.Xyz - right.Xyz,
                left.W - right.W);
        }

        /// <summary>
        ///     Multiplies two instances.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>A new instance containing the result of the calculation.</returns>
        [Pure]
        public static Quaternion Multiply(Quaternion left, Quaternion right)
        {
            Multiply(in left, in right, out Quaternion result);
            return result;
        }

        /// <summary>
        ///     Multiplies two instances.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <param name="result">A new instance containing the result of the calculation.</param>
        public static void Multiply(in Quaternion left, in Quaternion right, out Quaternion result)
        {
            result = new Quaternion(
                right.W * left.Xyz + left.W * right.Xyz + Vector3.Cross(left.Xyz, right.Xyz),
                left.W * right.W - Vector3.Dot(left.Xyz, right.Xyz));
        }

        /// <summary>
        ///     Multiplies an instance by a scalar.
        /// </summary>
        /// <param name="quaternion">The instance.</param>
        /// <param name="scale">The scalar.</param>
        /// <param name="result">A new instance containing the result of the calculation.</param>
        public static void Multiply(in Quaternion quaternion, float scale, out Quaternion result)
        {
            result = new Quaternion
            (
                quaternion.X * scale,
                quaternion.Y * scale,
                quaternion.Z * scale,
                quaternion.W * scale
            );
        }

        /// <summary>
        ///     Multiplies an instance by a scalar.
        /// </summary>
        /// <param name="quaternion">The instance.</param>
        /// <param name="scale">The scalar.</param>
        /// <returns>A new instance containing the result of the calculation.</returns>
        [Pure]
        public static Quaternion Multiply(Quaternion quaternion, float scale) =>
            new Quaternion
            (
                quaternion.X * scale,
                quaternion.Y * scale,
                quaternion.Z * scale,
                quaternion.W * scale
            );

        /// <summary>
        ///     Get the conjugate of the given quaternion.
        /// </summary>
        /// <param name="q">The quaternion.</param>
        /// <returns>The conjugate of the given quaternion.</returns>
        [Pure]
        public static Quaternion Conjugate(Quaternion q) => new Quaternion(-q.Xyz, q.W);

        /// <summary>
        ///     Get the conjugate of the given quaternion.
        /// </summary>
        /// <param name="q">The quaternion.</param>
        /// <param name="result">The conjugate of the given quaternion.</param>
        public static void Conjugate(in Quaternion q, out Quaternion result)
        {
            result = new Quaternion(-q.Xyz, q.W);
        }

        /// <summary>
        ///     Get the inverse of the given quaternion.
        /// </summary>
        /// <param name="q">The quaternion to invert.</param>
        /// <returns>The inverse of the given quaternion.</returns>
        [Pure]
        public static Quaternion Invert(Quaternion q)
        {
            Invert(in q, out Quaternion result);
            return result;
        }

        /// <summary>
        ///     Get the inverse of the given quaternion.
        /// </summary>
        /// <param name="q">The quaternion to invert.</param>
        /// <param name="result">The inverse of the given quaternion.</param>
        public static void Invert(in Quaternion q, out Quaternion result)
        {
            float lengthSq = q.LengthSquared;
            if (lengthSq != 0.0)
            {
                float i = 1.0f / lengthSq;
                result = new Quaternion(q.Xyz * -i, q.W * i);
            }
            else
            {
                result = q;
            }
        }

        /// <summary>
        ///     Scale the given quaternion to unit length.
        /// </summary>
        /// <param name="q">The quaternion to normalize.</param>
        /// <returns>The normalized copy.</returns>
        [Pure]
        public static Quaternion Normalize(Quaternion q)
        {
            Normalize(in q, out Quaternion result);
            return result;
        }

        /// <summary>
        ///     Scale the given quaternion to unit length.
        /// </summary>
        /// <param name="q">The quaternion to normalize.</param>
        /// <param name="result">The normalized quaternion.</param>
        public static void Normalize(in Quaternion q, out Quaternion result)
        {
            float scale = 1.0f / q.Length;
            result = new Quaternion(q.Xyz * scale, q.W * scale);
        }

        /// <summary>
        ///     Build a quaternion from the given axis and angle in radians.
        /// </summary>
        /// <param name="axis">The axis to rotate about.</param>
        /// <param name="angle">The rotation angle in radians.</param>
        /// <returns>The equivalent quaternion.</returns>
        [Pure]
        public static Quaternion FromAxisAngle(Vector3 axis, float angle)
        {
            if (axis.LengthSquared == 0.0f)
            {
                return Identity;
            }

            Quaternion result = Identity;

            angle *= 0.5f;
            axis.Normalize();
            result.Xyz = axis * MathF.Sin(angle);
            result.W = MathF.Cos(angle);

            return Normalize(result);
        }

        /// <summary>
        ///     Builds a Quaternion from the given euler angles in radians
        ///     The rotations will get applied in following order:
        ///     1. pitch (X axis), 2. yaw (Y axis), 3. roll (Z axis).
        /// </summary>
        /// <param name="pitch">The pitch (attitude), counterclockwise rotation around X axis.</param>
        /// <param name="yaw">The yaw (heading), counterclockwise rotation around Y axis.</param>
        /// <param name="roll">The roll (bank), counterclockwise rotation around Z axis.</param>
        /// <returns>The quaternion.</returns>
        [Pure]
        public static Quaternion FromEulerAngles(float pitch, float yaw, float roll) =>
            new Quaternion(pitch, yaw, roll);

        /// <summary>
        ///     Builds a Quaternion from the given euler angles in radians.
        ///     The rotations will get applied in following order:
        ///     1. X axis, 2. Y axis, 3. Z axis.
        /// </summary>
        /// <param name="eulerAngles">The counterclockwise euler angles as a vector.</param>
        /// <returns>The equivalent Quaternion.</returns>
        [Pure]
        public static Quaternion FromEulerAngles(Vector3 eulerAngles) => new Quaternion(eulerAngles);

        /// <summary>
        ///     Builds a Quaternion from the given euler angles in radians.
        ///     The rotations will get applied in following order:
        ///     1. Around X, 2. Around Y, 3. Around Z.
        /// </summary>
        /// <param name="eulerAngles">The counterclockwise euler angles a vector.</param>
        /// <param name="result">The equivalent Quaternion.</param>
        public static void FromEulerAngles(in Vector3 eulerAngles, out Quaternion result)
        {
            float c1 = MathF.Cos(eulerAngles.X * 0.5f);
            float c2 = MathF.Cos(eulerAngles.Y * 0.5f);
            float c3 = MathF.Cos(eulerAngles.Z * 0.5f);
            float s1 = MathF.Sin(eulerAngles.X * 0.5f);
            float s2 = MathF.Sin(eulerAngles.Y * 0.5f);
            float s3 = MathF.Sin(eulerAngles.Z * 0.5f);

            result.W = c1 * c2 * c3 - s1 * s2 * s3;
            result.Xyz.X = s1 * c2 * c3 + c1 * s2 * s3;
            result.Xyz.Y = c1 * s2 * c3 - s1 * c2 * s3;
            result.Xyz.Z = c1 * c2 * s3 + s1 * s2 * c3;
        }

        /// <summary>
        ///     Converts a quaternion to it's euler angle representation.
        /// </summary>
        /// <param name="q">The Quaternion.</param>
        /// <param name="result">The resulting euler angles in radians.</param>
        public static void ToEulerAngles(in Quaternion q, out Vector3 result)
        {
            q.ToEulerAngles(out result);
        }

        /// <summary>
        ///     Builds a quaternion from the given rotation matrix.
        /// </summary>
        /// <param name="matrix">A rotation matrix.</param>
        /// <returns>The equivalent quaternion.</returns>
        [Pure]
        public static Quaternion FromMatrix(Matrix3 matrix)
        {
            FromMatrix(in matrix, out Quaternion result);
            return result;
        }

        /// <summary>
        ///     Builds a quaternion from the given rotation matrix.
        /// </summary>
        /// <param name="matrix">A rotation matrix.</param>
        /// <param name="result">The equivalent quaternion.</param>
        public static void FromMatrix(in Matrix3 matrix, out Quaternion result)
        {
            float trace = matrix.Trace;

            if (trace > 0)
            {
                float s = MathF.Sqrt(trace + 1) * 2;
                float invS = 1f / s;

                result.W = s * 0.25f;
                result.Xyz.X = (matrix.Row2.Y - matrix.Row1.Z) * invS;
                result.Xyz.Y = (matrix.Row0.Z - matrix.Row2.X) * invS;
                result.Xyz.Z = (matrix.Row1.X - matrix.Row0.Y) * invS;
            }
            else
            {
                float m00 = matrix.Row0.X, m11 = matrix.Row1.Y, m22 = matrix.Row2.Z;

                if (m00 > m11 && m00 > m22)
                {
                    float s = MathF.Sqrt(1 + m00 - m11 - m22) * 2;
                    float invS = 1f / s;

                    result.W = (matrix.Row2.Y - matrix.Row1.Z) * invS;
                    result.Xyz.X = s * 0.25f;
                    result.Xyz.Y = (matrix.Row0.Y + matrix.Row1.X) * invS;
                    result.Xyz.Z = (matrix.Row0.Z + matrix.Row2.X) * invS;
                }
                else if (m11 > m22)
                {
                    float s = MathF.Sqrt(1 + m11 - m00 - m22) * 2;
                    float invS = 1f / s;

                    result.W = (matrix.Row0.Z - matrix.Row2.X) * invS;
                    result.Xyz.X = (matrix.Row0.Y + matrix.Row1.X) * invS;
                    result.Xyz.Y = s * 0.25f;
                    result.Xyz.Z = (matrix.Row1.Z + matrix.Row2.Y) * invS;
                }
                else
                {
                    float s = MathF.Sqrt(1 + m22 - m00 - m11) * 2;
                    float invS = 1f / s;

                    result.W = (matrix.Row1.X - matrix.Row0.Y) * invS;
                    result.Xyz.X = (matrix.Row0.Z + matrix.Row2.X) * invS;
                    result.Xyz.Y = (matrix.Row1.Z + matrix.Row2.Y) * invS;
                    result.Xyz.Z = s * 0.25f;
                }
            }
        }

        /// <summary>
        ///     Do Spherical linear interpolation between two quaternions.
        /// </summary>
        /// <param name="q1">The first quaternion.</param>
        /// <param name="q2">The second quaternion.</param>
        /// <param name="blend">The blend factor.</param>
        /// <returns>A smooth blend between the given quaternions.</returns>
        [Pure]
        public static Quaternion Slerp(Quaternion q1, Quaternion q2, float blend)
        {
            // if either input is zero, return the other.
            if (q1.LengthSquared == 0.0f)
            {
                if (q2.LengthSquared == 0.0f)
                {
                    return Identity;
                }

                return q2;
            }

            if (q2.LengthSquared == 0.0f)
            {
                return q1;
            }

            float cosHalfAngle = q1.W * q2.W + Vector3.Dot(q1.Xyz, q2.Xyz);

            if (cosHalfAngle >= 1.0f || cosHalfAngle <= -1.0f)
            {
                // angle = 0.0f, so just return one input.
                return q1;
            }

            if (cosHalfAngle < 0.0f)
            {
                q2.Xyz = -q2.Xyz;
                q2.W = -q2.W;
                cosHalfAngle = -cosHalfAngle;
            }

            float blendA;
            float blendB;
            if (cosHalfAngle < 0.99f)
            {
                // do proper slerp for big angles
                float halfAngle = MathF.Acos(cosHalfAngle);
                float sinHalfAngle = MathF.Sin(halfAngle);
                float oneOverSinHalfAngle = 1.0f / sinHalfAngle;
                blendA = MathF.Sin(halfAngle * (1.0f - blend)) * oneOverSinHalfAngle;
                blendB = MathF.Sin(halfAngle * blend) * oneOverSinHalfAngle;
            }
            else
            {
                // do lerp if angle is really small.
                blendA = 1.0f - blend;
                blendB = blend;
            }

            Quaternion result = new Quaternion(blendA * q1.Xyz + blendB * q2.Xyz, blendA * q1.W + blendB * q2.W);
            if (result.LengthSquared > 0.0f)
            {
                return Normalize(result);
            }

            return Identity;
        }

        /// <summary>
        ///     Adds two instances.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>The result of the calculation.</returns>
        [Pure]
        public static Quaternion operator +(Quaternion left, Quaternion right)
        {
            left.Xyz += right.Xyz;
            left.W += right.W;
            return left;
        }

        /// <summary>
        ///     Subtracts two instances.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>The result of the calculation.</returns>
        [Pure]
        public static Quaternion operator -(Quaternion left, Quaternion right)
        {
            left.Xyz -= right.Xyz;
            left.W -= right.W;
            return left;
        }

        /// <summary>
        ///     Multiplies two instances.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>The result of the calculation.</returns>
        [Pure]
        public static Quaternion operator *(Quaternion left, Quaternion right)
        {
            Multiply(in left, in right, out left);
            return left;
        }

        /// <summary>
        ///     Multiplies an instance by a scalar.
        /// </summary>
        /// <param name="quaternion">The instance.</param>
        /// <param name="scale">The scalar.</param>
        /// <returns>A new instance containing the result of the calculation.</returns>
        [Pure]
        public static Quaternion operator *(Quaternion quaternion, float scale)
        {
            Multiply(in quaternion, scale, out quaternion);
            return quaternion;
        }

        /// <summary>
        ///     Multiplies an instance by a scalar.
        /// </summary>
        /// <param name="quaternion">The instance.</param>
        /// <param name="scale">The scalar.</param>
        /// <returns>A new instance containing the result of the calculation.</returns>
        [Pure]
        public static Quaternion operator *(float scale, Quaternion quaternion) =>
            new Quaternion
            (
                quaternion.X * scale,
                quaternion.Y * scale,
                quaternion.Z * scale,
                quaternion.W * scale
            );

        /// <summary>
        ///     Compares two instances for equality.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>True, if left equals right; false otherwise.</returns>
        public static bool operator ==(Quaternion left, Quaternion right) => left.Equals(right);

        /// <summary>
        ///     Compares two instances for inequality.
        /// </summary>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <returns>True, if left does not equal right; false otherwise.</returns>
        public static bool operator !=(Quaternion left, Quaternion right) => !(left == right);

        /// <inheritdoc />
        public override bool Equals(object obj) => obj is Quaternion && Equals((Quaternion) obj);

        /// <inheritdoc />
        public bool Equals(Quaternion other) =>
            Xyz.Equals(other.Xyz) &&
            W == other.W;

        /// <inheritdoc />
        public override int GetHashCode() => HashCode.Combine(Xyz, W);

        /// <summary>
        ///     Returns a System.String that represents the current Quaternion.
        /// </summary>
        /// <returns>A human-readable representation of the quaternion.</returns>
        public override string ToString() => $"V: {Xyz}{MathHelper.ListSeparator} W: {W}";
    }
}