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

using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Util;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Aspect.Math
{
    /// <summary>
    ///     The math utils class
    /// </summary>
    public static class MathUtils
    {
        /// <summary>Perform the cross product on two vectors.</summary>
        public static float Cross(ref Vector2 a, ref Vector2 b) => a.X * b.Y - a.Y * b.X;
        
        /// <summary>Perform the cross product on two vectors.</summary>
        public static float Cross(Vector2 a, Vector2 b) => Cross(ref a, ref b);
        
        /// <summary>Perform the cross product on two vectors.</summary>
        public static Vector3 Cross(Vector3 a, Vector3 b) =>
            new Vector3(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);
        
        /// <summary>Perform the cross product on two vectors.</summary>
        public static Vector2 Cross(Vector2 a, float s) => new Vector2(s * a.Y, -s * a.X);
        
        /// <summary>Perform the cross product on two vectors.</summary>
        public static Vector2 Cross(float s, Vector2 a) => new Vector2(-s * a.Y, s * a.X);
        
        /// <summary>
        ///     Abses the v
        /// </summary>
        /// <param name="v">The </param>
        /// <returns>The vector</returns>
        public static Vector2 Abs(Vector2 v) => new Vector2(System.Math.Abs(v.X), System.Math.Abs(v.Y));
        
        /// <summary>
        ///     Abses the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The float</returns>
        public static float Abs(float value) => System.Math.Abs(value);
        
        /// <summary>
        ///     Muls the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="v">The </param>
        /// <returns>The vector</returns>
        public static Vector2 Mul(ref Matrix2X2 a, Vector2 v) => Mul(ref a, ref v);
        
        /// <summary>
        ///     Muls the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="v">The </param>
        /// <returns>The vector</returns>
        public static Vector2 Mul(ref Matrix2X2 a, ref Vector2 v) =>
            new Vector2(a.Ex.X * v.X + a.Ey.X * v.Y, a.Ex.Y * v.X + a.Ey.Y * v.Y);

        /// <summary>
        ///     Muls the t using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="v">The </param>
        /// <returns>The vector</returns>
        public static Vector2 MulT(ref Matrix2X2 a, Vector2 v) => MulT(ref a, ref v);
        
        /// <summary>
        ///     Muls the t using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="v">The </param>
        /// <returns>The vector</returns>
        public static Vector2 MulT(ref Matrix2X2 a, ref Vector2 v) =>
            new Vector2(v.X * a.Ex.X + v.Y * a.Ex.Y, v.X * a.Ey.X + v.Y * a.Ey.Y);
        
        
        // A^T * B
        /// <summary>
        ///     Muls the t using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        public static void MulT(ref Matrix2X2 a, ref Matrix2X2 b, out Matrix2X2 c)
        {
            c = new Matrix2X2(
                a.Ex.X * b.Ex.X + a.Ex.Y * b.Ex.Y,
                a.Ey.X * b.Ex.X + a.Ey.Y * b.Ex.Y,
                a.Ex.X * b.Ey.X + a.Ex.Y * b.Ey.Y,
                a.Ey.X * b.Ey.X + a.Ey.Y * b.Ey.Y
            );
        }
        
        /// <summary>Multiply a matrix times a vector.</summary>
        public static Vector3 Mul(Matrix3X3 a, Vector3 v) => v.X * a.Ex + v.Y * a.Ey + v.Z * a.Ez;
        
        /// <summary>Multiply a matrix times a vector.</summary>
        public static Vector2 Mul22(Matrix3X3 a, Vector2 v) =>
            new Vector2(a.Ex.X * v.X + a.Ey.X * v.Y, a.Ex.Y * v.X + a.Ey.Y * v.Y);
        
        /// <summary>Multiply two rotations: q * r</summary>
        public static Rotation Mul(Rotation q, Rotation r)
        {
            // [qc -qs] * [rc -rs] = [qc*rc-qs*rs -qc*rs-qs*rc]
            // [qs  qc]   [rs  rc]   [qs*rc+qc*rs -qs*rs+qc*rc]
            // s = qs * rc + qc * rs
            // c = qc * rc - qs * rs
            Rotation qr = new Rotation(0)
            {
                Sine = q.Sine * r.Cosine + q.Cosine * r.Sine,
                Cosine = q.Cosine * r.Cosine - q.Sine * r.Sine
            };
            return qr;
        }
        
        /// <summary>Transpose multiply two rotations: qT * r</summary>
        public static Rotation MulT(Rotation q, Rotation r)
        {
            // [ qc qs] * [rc -rs] = [qc*rc+qs*rs -qc*rs+qs*rc]
            // [-qs qc]   [rs  rc]   [-qs*rc+qc*rs qs*rs+qc*rc]
            // s = qc * rs - qs * rc
            // c = qc * rc + qs * rs
            Rotation qr = new Rotation(0)
            {
                Sine = q.Cosine * r.Sine - q.Sine * r.Cosine,
                Cosine = q.Cosine * r.Cosine + q.Sine * r.Sine
            };
            return qr;
        }
        
        
        /// <summary>Rotate a vector</summary>
        /// <param name="q">The rotation matrix</param>
        /// <param name="v">The value</param>
        public static Vector2 Mul(Rotation q, Vector2 v) => new Vector2(q.Cosine * v.X - q.Sine * v.Y, q.Sine * v.X + q.Cosine * v.Y);
        
        /// <summary>Inverse rotate a vector</summary>
        /// <param name="q">The rotation matrix</param>
        /// <param name="v">The value</param>
        public static Vector2 MulT(Rotation q, Vector2 v) => new Vector2(q.Cosine * v.X + q.Sine * v.Y, -q.Sine * v.X + q.Cosine * v.Y);
        
        /// <summary>Get the skew vector such that dot(skew_vec, other) == cross(vec, other)</summary>
        public static Vector2 Skew(Vector2 input) => new Vector2(-input.Y, input.X);
        
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
        public static bool IsValid(this Vector2 x) => IsValid(x.X) && IsValid(x.Y);
        
        /// <summary>
        ///     Clamps the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="low">The low</param>
        /// <param name="high">The high</param>
        /// <returns>The int</returns>
        public static int Clamp(int a, int low, int high) => System.Math.Max(low, System.Math.Min(a, high));
        
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
        public static Vector2 Clamp(Vector2 a, Vector2 low, Vector2 high) => Vector2.Max(low, Vector2.Min(a, high));
        
        /// <summary>
        ///     Crosses the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        public static void Cross(ref Vector2 a, ref Vector2 b, out float c)
        {
            c = a.X * b.Y - a.Y * b.X;
        }
        
        /// <summary>
        ///     Vectors the angle using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <returns>The vector angle</returns>
        public static double VectorAngle(ref Vector2 p1, ref Vector2 p2)
        {
            double theta1 = System.Math.Atan2(p1.Y, p1.X);
            double theta2 = System.Math.Atan2(p2.Y, p2.X);
            double vectorAngle = System.Math.IEEERemainder(theta2 - theta1, Constant.TwoPi);
            return vectorAngle;
        }
        
        /// <summary>Perform the dot product on two vectors.</summary>
        public static float Dot(Vector3 a, Vector3 b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        
        /// <summary>Perform the dot product on two vectors.</summary>
        public static float Dot(ref Vector2 a, ref Vector2 b) => a.X * b.X + a.Y * b.Y;
        
        /// <summary>Perform the dot product on two vectors.</summary>
        public static float Dot(Vector2 a, Vector2 b) => a.X * b.X + a.Y * b.Y;
        
        /// <summary>
        ///     Vectors the angle using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <returns>The double</returns>
        public static double VectorAngle(Vector2 p1, Vector2 p2) => VectorAngle(ref p1, ref p2);
        
        /// <summary>Returns a positive number if c is to the left of the line going from a to b.</summary>
        /// <returns>Positive number if point is left, negative if point is right, and 0 if points are collinear.</returns>
        public static float Area(Vector2 a, Vector2 b, Vector2 c) => Area(ref a, ref b, ref c);
        
        /// <summary>Returns a positive number if c is to the left of the line going from a to b.</summary>
        /// <returns>Positive number if point is left, negative if point is right, and 0 if points are collinear.</returns>
        public static float Area(ref Vector2 a, ref Vector2 b, ref Vector2 c) =>
            a.X * (b.Y - c.Y) + b.X * (c.Y - a.Y) + c.X * (a.Y - b.Y);
        
        /// <summary>Determines if three vertices are collinear (ie. on a straight line)</summary>
        public static bool IsCollinear(ref Vector2 a, ref Vector2 b, ref Vector2 c, float tolerance = 0) =>
            FloatInRange(Area(ref a, ref b, ref c), -tolerance, tolerance);
        
        /// <summary>
        ///     Crosses the s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        public static void Cross(float s, ref Vector2 a, out Vector2 b)
        {
            b = new Vector2(-s * a.Y, s * a.X);
        }
        
        /// <summary>
        ///     Describes whether float equals
        /// </summary>
        /// <param name="value1">The value</param>
        /// <param name="value2">The value</param>
        /// <returns>The bool</returns>
        public static bool FloatEquals(float value1, float value2) =>
            System.Math.Abs(value1 - value2) <= Constant.Epsilon;
        
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
        public static Vector2 Mul(ref Rotation rotation, Vector2 axis) => Mul(rotation, axis);
        
        /// <summary>
        ///     Muls the t using the specified rot
        /// </summary>
        /// <param name="rotation">The rot</param>
        /// <param name="axis">The axis</param>
        /// <returns>The vector</returns>
        public static Vector2 MulT(ref Rotation rotation, Vector2 axis) => MulT(rotation, axis);
        
        /// <summary>
        ///     Distances the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The float</returns>
        public static float Distance(Vector2 a, Vector2 b)
        {
            Vector2 c = a - b;
            return c.Length();
        }
        
        /// <summary>
        ///     Distances the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The float</returns>
        public static float Distance(ref Vector2 a, ref Vector2 b)
        {
            Vector2 c = a - b;
            return c.Length();
        }
        
        /// <summary>
        ///     Distances the squared using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The float</returns>
        public static float DistanceSquared(ref Vector2 a, ref Vector2 b)
        {
            Vector2 c = a - b;
            return Dot(ref c, ref c);
        }
        
        /// <summary>
        ///     Maxes the value a
        /// </summary>
        /// <param name="valueA">The value</param>
        /// <param name="valueB">The value</param>
        /// <returns>The float</returns>
        public static float Max(float valueA, float valueB) => System.Math.Max(valueA, valueB);
        
        /// <summary>
        ///     Maxes the value a
        /// </summary>
        /// <param name="valueA">The value</param>
        /// <param name="valueB">The value</param>
        /// <returns>The int</returns>
        public static int Max(int valueA, int valueB) => System.Math.Max(valueA, valueB);
        
        /// <summary>
        ///     Mins the value a
        /// </summary>
        /// <param name="valueA">The value</param>
        /// <param name="valueB">The value</param>
        /// <returns>The float</returns>
        public static float Min(float valueA, float valueB) => System.Math.Min(valueA, valueB);
        
        /// <summary>
        ///     Mins the value a
        /// </summary>
        /// <param name="valueA">The value</param>
        /// <param name="valueB">The value</param>
        /// <returns>The int</returns>
        public static int Min(int valueA, int valueB) => System.Math.Min(valueA, valueB);
        
        /// <summary>
        ///     Signs the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        public static int Sign(float value) => System.Math.Sign(value);
        
        /// <summary>
        ///     Convert this vector into a unit vector. Returns the length.
        /// </summary>
        public static float Normalize(ref Vector2 v)
        {
            float length = v.Length();
            if (length < Constant.Epsilon)
            {
                return 0.0f;
            }
            
            float invLength = 1.0f / length;
            
            v = new Vector2(v.X * invLength, v.Y * invLength);
            
            return length;
        }
        
        /// <summary>
        ///     Sqrts the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The float</returns>
        public static float Sqrt(float value) => (float) System.Math.Sqrt(value);
        
        /// <summary>
        ///     Cosfs the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The float</returns>
        public static float Cosf(float value) => (float) System.Math.Cos(value);
        
        /// <summary>
        ///     Sinfs the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The float</returns>
        public static float Sinf(float value) => (float) System.Math.Sin(value);
        
        /// <summary>
        ///     Ceils the log
        /// </summary>
        /// <param name="log">The log</param>
        /// <returns>The float</returns>
        public static float Ceil(float log) => (float) System.Math.Ceiling(log);
        
        /// <summary>
        ///     Logs the log
        /// </summary>
        /// <param name="log">The log</param>
        /// <returns>The float</returns>
        public static float Log(float log) => (float) System.Math.Log(log);
    }
}