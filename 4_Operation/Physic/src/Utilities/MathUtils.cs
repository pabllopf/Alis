// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MathUtils.cs
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
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Util;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Physic.Utilities
{
    /// <summary>
    ///     The math utils class
    /// </summary>
    public static class MathUtils
    {
        /// <summary>Perform the cross product on two vectors.</summary>
        public static float Cross(ref Vector2F a, ref Vector2F b) => a.X * b.Y - a.Y * b.X;

        /// <summary>Perform the cross product on two vectors.</summary>
        public static float Cross(Vector2F a, Vector2F b) => Cross(ref a, ref b);

        /// <summary>Perform the cross product on two vectors.</summary>
        public static Vector3F Cross(Vector3F a, Vector3F b) =>
            new Vector3F(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);

        /// <summary>Perform the cross product on two vectors.</summary>
        public static Vector2F Cross(Vector2F a, float s) => new Vector2F(s * a.Y, -s * a.X);

        /// <summary>Perform the cross product on two vectors.</summary>
        public static Vector2F Cross(float s, Vector2F a) => new Vector2F(-s * a.Y, s * a.X);

        /// <summary>
        ///     Abses the v
        /// </summary>
        /// <param name="v">The </param>
        /// <returns>The vector</returns>
        public static Vector2F Abs(Vector2F v) => new Vector2F(Math.Abs(v.X), Math.Abs(v.Y));

        /// <summary>
        ///     Abses the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The float</returns>
        public static float Abs(float value) => Math.Abs(value);

        /// <summary>
        ///     Muls the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="v">The </param>
        /// <returns>The vector</returns>
        public static Vector2F Mul(ref Matrix2X2F a, Vector2F v) => Mul(ref a, ref v);

        /// <summary>
        ///     Muls the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="v">The </param>
        /// <returns>The vector</returns>
        public static Vector2F Mul(ref Matrix2X2F a, ref Vector2F v) =>
            new Vector2F(a.Ex.X * v.X + a.Ey.X * v.Y, a.Ex.Y * v.X + a.Ey.Y * v.Y);

        /// <summary>
        ///     Muls the t
        /// </summary>
        /// <param name="T">The </param>
        /// <param name="v">The </param>
        /// <returns>The vector</returns>
        public static Vector2F Mul(ref Transform T, Vector2F v) => Mul(ref T, ref v);

        /// <summary>
        ///     Muls the t
        /// </summary>
        /// <param name="T">The </param>
        /// <param name="v">The </param>
        /// <returns>The vector</returns>
        public static Vector2F Mul(ref Transform T, ref Vector2F v)
        {
            float x = T.Rotation.Cosine * v.X - T.Rotation.Sine * v.Y + T.Position.X;
            float y = T.Rotation.Sine * v.X + T.Rotation.Cosine * v.Y + T.Position.Y;

            return new Vector2F(x, y);
        }

        /// <summary>
        ///     Muls the t using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="v">The </param>
        /// <returns>The vector</returns>
        public static Vector2F MulT(ref Matrix2X2F a, Vector2F v) => MulT(ref a, ref v);

        /// <summary>
        ///     Muls the t using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="v">The </param>
        /// <returns>The vector</returns>
        public static Vector2F MulT(ref Matrix2X2F a, ref Vector2F v) =>
            new Vector2F(v.X * a.Ex.X + v.Y * a.Ex.Y, v.X * a.Ey.X + v.Y * a.Ey.Y);

        /// <summary>
        ///     Muls the t using the specified t
        /// </summary>
        /// <param name="T">The </param>
        /// <param name="v">The </param>
        /// <returns>The vector</returns>
        public static Vector2F MulT(ref Transform T, Vector2F v) => MulT(ref T, ref v);

        /// <summary>
        ///     Muls the t using the specified t
        /// </summary>
        /// <param name="T">The </param>
        /// <param name="v">The </param>
        /// <returns>The vector</returns>
        public static Vector2F MulT(ref Transform T, ref Vector2F v)
        {
            float px = v.X - T.Position.X;
            float py = v.Y - T.Position.Y;
            float x = T.Rotation.Cosine * px + T.Rotation.Sine * py;
            float y = -T.Rotation.Sine * px + T.Rotation.Cosine * py;

            return new Vector2F(x, y);
        }

        // A^T * B
        /// <summary>
        ///     Muls the t using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        public static void MulT(ref Matrix2X2F a, ref Matrix2X2F b, out Matrix2X2F c)
        {
            c = new Matrix2X2F();
            c.Ex.X = a.Ex.X * b.Ex.X + a.Ex.Y * b.Ex.Y;
            c.Ex.Y = a.Ey.X * b.Ex.X + a.Ey.Y * b.Ex.Y;
            c.Ey.X = a.Ex.X * b.Ey.X + a.Ex.Y * b.Ey.Y;
            c.Ey.Y = a.Ey.X * b.Ey.X + a.Ey.Y * b.Ey.Y;
        }

        /// <summary>Multiply a matrix times a vector.</summary>
        public static Vector3F Mul(Matrix3X3F a, Vector3F v) => v.X * a.Ex + v.Y * a.Ey + v.Z * a.Ez;

        /// <summary>
        ///     Muls the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The </returns>
        public static Transform Mul(Transform a, Transform b)
        {
            // v2 = A.q.Rot(B.q.Rot(v1) + B.p) + A.p
            //    = (A.q * B.q).Rot(v1) + A.q.Rot(B.p) + A.p

            Transform c = new Transform
            {
                Rotation = Mul(a.Rotation, b.Rotation),
                Position = Mul(a.Rotation, b.Position) + a.Position
            };
            return c;
        }

        /// <summary>
        ///     Muls the t using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        public static void MulT(ref Transform a, ref Transform b, out Transform c)
        {
            // v2 = A.q' * (B.q * v1 + B.p - A.p)
            //    = A.q' * B.q * v1 + A.q' * (B.p - A.p)

            c = new Transform
            {
                Rotation = MulT(a.Rotation, b.Rotation),
                Position = MulT(a.Rotation, b.Position - a.Position)
            };
        }

        /// <summary>
        ///     Swaps the a
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        public static void Swap<T>(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }

        /// <summary>Multiply a matrix times a vector.</summary>
        public static Vector2F Mul22(Matrix3X3F a, Vector2F v) =>
            new Vector2F(a.Ex.X * v.X + a.Ey.X * v.Y, a.Ex.Y * v.X + a.Ey.Y * v.Y);

        /// <summary>Multiply two rotations: q * r</summary>
        public static Rotation Mul(Rotation q, Rotation r)
        {
            // [qc -qs] * [rc -rs] = [qc*rc-qs*rs -qc*rs-qs*rc]
            // [qs  qc]   [rs  rc]   [qs*rc+qc*rs -qs*rs+qc*rc]
            // s = qs * rc + qc * rs
            // c = qc * rc - qs * rs
            Rotation qr;
            qr.Sine = q.Sine * r.Cosine + q.Cosine * r.Sine;
            qr.Cosine = q.Cosine * r.Cosine - q.Sine * r.Sine;
            return qr;
        }

        /// <summary>
        ///     Muls the t using the specified t
        /// </summary>
        /// <param name="T">The </param>
        /// <param name="v">The </param>
        /// <returns>The vector</returns>
        public static Vector2F MulT(Transform T, Vector2F v)
        {
            float px = v.X - T.Position.X;
            float py = v.Y - T.Position.Y;
            float x = T.Rotation.Cosine * px + T.Rotation.Sine * py;
            float y = -T.Rotation.Sine * px + T.Rotation.Cosine * py;

            return new Vector2F(x, y);
        }

        /// <summary>Transpose multiply two rotations: qT * r</summary>
        public static Rotation MulT(Rotation q, Rotation r)
        {
            // [ qc qs] * [rc -rs] = [qc*rc+qs*rs -qc*rs+qs*rc]
            // [-qs qc]   [rs  rc]   [-qs*rc+qc*rs qs*rs+qc*rc]
            // s = qc * rs - qs * rc
            // c = qc * rc + qs * rs
            Rotation qr;
            qr.Sine = q.Cosine * r.Sine - q.Sine * r.Cosine;
            qr.Cosine = q.Cosine * r.Cosine + q.Sine * r.Sine;
            return qr;
        }

        /// <summary>
        ///     Muls the t using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The </returns>
        public static Transform MulT(Transform a, Transform b)
        {
            // v2 = A.q' * (B.q * v1 + B.p - A.p)
            //    = A.q' * B.q * v1 + A.q' * (B.p - A.p)

            Transform c = new Transform
            {
                Rotation = MulT(a.Rotation, b.Rotation),
                Position = MulT(a.Rotation, b.Position - a.Position)
            };
            return c;
        }

        /// <summary>Rotate a vector</summary>
        /// <param name="q">The rotation matrix</param>
        /// <param name="v">The value</param>
        public static Vector2F Mul(Rotation q, Vector2F v) => new Vector2F(q.Cosine * v.X - q.Sine * v.Y, q.Sine * v.X + q.Cosine * v.Y);

        /// <summary>Inverse rotate a vector</summary>
        /// <param name="q">The rotation matrix</param>
        /// <param name="v">The value</param>
        public static Vector2F MulT(Rotation q, Vector2F v) => new Vector2F(q.Cosine * v.X + q.Sine * v.Y, -q.Sine * v.X + q.Cosine * v.Y);

        /// <summary>Get the skew vector such that dot(skew_vec, other) == cross(vec, other)</summary>
        public static Vector2F Skew(Vector2F input) => new Vector2F(-input.Y, input.X);

        /// <summary>This function is used to ensure that a floating point number is not a NaN or infinity.</summary>
        /// <param name="x">The x.</param>
        /// <returns><c>true</c> if the specified x is valid; otherwise, <c>false</c>.</returns>
        public static bool IsValid(float x)
        {
            if (float.IsNaN(x))
            {
                return false;
            }

            return !float.IsInfinity(x);
        }

        /// <summary>
        ///     Describes whether is valid
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool IsValid(this Vector2F x) => IsValid(x.X) && IsValid(x.Y);

        /// <summary>
        ///     Clamps the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="low">The low</param>
        /// <param name="high">The high</param>
        /// <returns>The int</returns>
        public static int Clamp(int a, int low, int high) => Math.Max(low, Math.Min(a, high));

        /// <summary>
        ///     Clamps the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="low">The low</param>
        /// <param name="high">The high</param>
        /// <returns>The float</returns>
        public static float Clamp(float a, float low, float high) => Max(low, Min(a, high));

        /// <summary>
        ///     Clamps the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="low">The low</param>
        /// <param name="high">The high</param>
        /// <returns>The vector</returns>
        public static Vector2F Clamp(Vector2F a, Vector2F low, Vector2F high) => Vector2F.Max(low, Vector2F.Min(a, high));

        /// <summary>
        ///     Crosses the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        public static void Cross(ref Vector2F a, ref Vector2F b, out float c)
        {
            c = a.X * b.Y - a.Y * b.X;
        }

        /// <summary>
        ///     Return the angle between two vectors on a plane The angle is from vector 1 to vector 2, positive anticlockwise
        ///     The result is between -pi -> pi
        /// </summary>
        public static double VectorAngle(ref Vector2F p1, ref Vector2F p2)
        {
            double theta1 = Math.Atan2(p1.Y, p1.X);
            double theta2 = Math.Atan2(p2.Y, p2.X);
            double dtheta = theta2 - theta1;

            while (dtheta > Constant.Pi)
            {
                dtheta -= Constant.TwoPi;
            }

            while (dtheta < -Constant.Pi)
            {
                dtheta += Constant.TwoPi;
            }

            return dtheta;
        }

        /// <summary>Perform the dot product on two vectors.</summary>
        public static float Dot(Vector3F a, Vector3F b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z;

        /// <summary>Perform the dot product on two vectors.</summary>
        public static float Dot(ref Vector2F a, ref Vector2F b) => a.X * b.X + a.Y * b.Y;

        /// <summary>Perform the dot product on two vectors.</summary>
        public static float Dot(Vector2F a, Vector2F b) => a.X * b.X + a.Y * b.Y;

        /// <summary>
        ///     Vectors the angle using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <returns>The double</returns>
        public static double VectorAngle(Vector2F p1, Vector2F p2) => VectorAngle(ref p1, ref p2);

        /// <summary>Returns a positive number if c is to the left of the line going from a to b.</summary>
        /// <returns>Positive number if point is left, negative if point is right, and 0 if points are collinear.</returns>
        public static float Area(Vector2F a, Vector2F b, Vector2F c) => Area(ref a, ref b, ref c);

        /// <summary>Returns a positive number if c is to the left of the line going from a to b.</summary>
        /// <returns>Positive number if point is left, negative if point is right, and 0 if points are collinear.</returns>
        public static float Area(ref Vector2F a, ref Vector2F b, ref Vector2F c) =>
            a.X * (b.Y - c.Y) + b.X * (c.Y - a.Y) + c.X * (a.Y - b.Y);

        /// <summary>Determines if three vertices are collinear (ie. on a straight line)</summary>
        public static bool IsCollinear(ref Vector2F a, ref Vector2F b, ref Vector2F c, float tolerance = 0) =>
            FloatInRange(Area(ref a, ref b, ref c), -tolerance, tolerance);

        /// <summary>
        ///     Crosses the s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        public static void Cross(float s, ref Vector2F a, out Vector2F b)
        {
            b = new Vector2F(-s * a.Y, s * a.X);
        }

        /// <summary>
        ///     Describes whether float equals
        /// </summary>
        /// <param name="value1">The value</param>
        /// <param name="value2">The value</param>
        /// <returns>The bool</returns>
        public static bool FloatEquals(float value1, float value2) =>
            Math.Abs(value1 - value2) <= Constant.Epsilon;

        /// <summary>Checks if a floating point Value is equal to another, within a certain tolerance.</summary>
        /// <returns>True if the values are "equal", false otherwise.</returns>
        public static bool FloatEquals(float value1, float value2, float delta) =>
            FloatInRange(value1, value2 - delta, value2 + delta);

        /// <summary>Checks if a floating point Value is within a specified range of values (inclusive).</summary>
        /// <param name="value">The Value to check.</param>
        /// <param name="min">The minimum Value.</param>
        /// <param name="max">The maximum Value.</param>
        /// <returns>True if the Value is within the range specified, false otherwise.</returns>
        public static bool FloatInRange(float value, float min, float max) => (value >= min) && (value <= max);

        /// <summary>
        ///     Muls the rot
        /// </summary>
        /// <param name="rotation">The rot</param>
        /// <param name="axis">The axis</param>
        /// <returns>The vector</returns>
        public static Vector2F Mul(ref Rotation rotation, Vector2F axis) => Mul(rotation, axis);

        /// <summary>
        ///     Muls the t using the specified rot
        /// </summary>
        /// <param name="rotation">The rot</param>
        /// <param name="axis">The axis</param>
        /// <returns>The vector</returns>
        public static Vector2F MulT(ref Rotation rotation, Vector2F axis) => MulT(rotation, axis);

        /// <summary>
        ///     Distances the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The float</returns>
        public static float Distance(Vector2F a, Vector2F b)
        {
            Vector2F c = a - b;
            return c.Length();
        }

        /// <summary>
        ///     Distances the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The float</returns>
        public static float Distance(ref Vector2F a, ref Vector2F b)
        {
            Vector2F c = a - b;
            return c.Length();
        }

        /// <summary>
        ///     Distances the squared using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The float</returns>
        public static float DistanceSquared(ref Vector2F a, ref Vector2F b)
        {
            Vector2F c = a - b;
            return Dot(ref c, ref c);
        }

        /// <summary>
        ///     Maxes the value a
        /// </summary>
        /// <param name="valueA">The value</param>
        /// <param name="valueB">The value</param>
        /// <returns>The float</returns>
        public static float Max(float valueA, float valueB) => Math.Max(valueA, valueB);

        /// <summary>
        ///     Maxes the value a
        /// </summary>
        /// <param name="valueA">The value</param>
        /// <param name="valueB">The value</param>
        /// <returns>The int</returns>
        public static int Max(int valueA, int valueB) => Math.Max(valueA, valueB);

        /// <summary>
        ///     Mins the value a
        /// </summary>
        /// <param name="valueA">The value</param>
        /// <param name="valueB">The value</param>
        /// <returns>The float</returns>
        public static float Min(float valueA, float valueB) => Math.Min(valueA, valueB);

        /// <summary>
        ///     Mins the value a
        /// </summary>
        /// <param name="valueA">The value</param>
        /// <param name="valueB">The value</param>
        /// <returns>The int</returns>
        public static int Min(int valueA, int valueB) => Math.Min(valueA, valueB);

        /// <summary>
        ///     Signs the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        public static int Sign(float value) => Math.Sign(value);

        /// <summary>
        ///     Convert this vector into a unit vector. Returns the length.
        /// </summary>
        public static float Normalize(ref Vector2F v)
        {
            float length = v.Length();
            if (length < Constant.Epsilon)
            {
                return 0.0f;
            }

            float invLength = 1.0f / length;
            v.X *= invLength;
            v.Y *= invLength;

            return length;
        }

        /// <summary>
        ///     Sqrts the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The float</returns>
        public static float Sqrt(float value) => (float) Math.Sqrt(value);

        /// <summary>
        ///     Cosfs the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The float</returns>
        public static float Cosf(float value) => (float) Math.Cos(value);

        /// <summary>
        ///     Sinfs the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The float</returns>
        public static float Sinf(float value) => (float) Math.Sin(value);

        /// <summary>
        ///     Ceils the log
        /// </summary>
        /// <param name="log">The log</param>
        /// <returns>The float</returns>
        public static float Ceil(float log) => (float) Math.Ceiling(log);

        /// <summary>
        ///     Logs the log
        /// </summary>
        /// <param name="log">The log</param>
        /// <returns>The float</returns>
        public static float Log(float log) => (float) Math.Log(log);
    }
}