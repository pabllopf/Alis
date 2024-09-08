// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Math.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    /// The math utils class
    /// </summary>
    public static class MathUtils
    {
        /// <summary>
        /// Crosses the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The float</returns>
        public static float Cross(ref Vector2 a, ref Vector2 b) => a.X * b.Y - a.Y * b.X;

        /// <summary>
        /// Crosses the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The float</returns>
        public static float Cross(Vector2 a, Vector2 b) => Cross(ref a, ref b);

        /// Perform the cross product on two vectors.
        public static Vector3 Cross(ref Vector3 a, ref Vector3 b) => new Vector3(a.Y * b.Z - a.Z * b.Y,
            a.Z * b.X - a.X * b.Z,
            a.X * b.Y - a.Y * b.X);

        /// <summary>
        /// Crosses the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="s">The </param>
        /// <returns>The vector</returns>
        public static Vector2 Cross(Vector2 a, float s) => new Vector2(s * a.Y, -s * a.X);

        /// <summary>
        /// Rots the 270 using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <returns>The vector</returns>
        public static Vector2 Rot270(ref Vector2 a) => new Vector2(a.Y, -a.X);

        /// <summary>
        /// Crosses the s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="a">The </param>
        /// <returns>The vector</returns>
        public static Vector2 Cross(float s, ref Vector2 a) => new Vector2(-s * a.Y, s * a.X);

        /// <summary>
        /// Rots the 90 using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <returns>The vector</returns>
        public static Vector2 Rot90(ref Vector2 a) => new Vector2(-a.Y, a.X);

        /// <summary>
        /// Abses the v
        /// </summary>
        /// <param name="v">The </param>
        /// <returns>The vector</returns>
        public static Vector2 Abs(Vector2 v) => new Vector2(Math.Abs(v.X), Math.Abs(v.Y));

        /// <summary>
        /// Muls the a
        /// </summary>
        /// <param name="A">The </param>
        /// <param name="v">The </param>
        /// <returns>The vector</returns>
        public static Vector2 Mul(ref Mat22 A, Vector2 v) => Mul(ref A, ref v);

        /// <summary>
        /// Muls the a
        /// </summary>
        /// <param name="A">The </param>
        /// <param name="v">The </param>
        /// <returns>The vector</returns>
        public static Vector2 Mul(ref Mat22 A, ref Vector2 v) => new Vector2(A.ex.X * v.X + A.ey.X * v.Y, A.ex.Y * v.X + A.ey.Y * v.Y);

        /// <summary>
        /// Muls the t using the specified a
        /// </summary>
        /// <param name="A">The </param>
        /// <param name="v">The </param>
        /// <returns>The vector</returns>
        public static Vector2 MulT(ref Mat22 A, Vector2 v) => MulT(ref A, ref v);

        /// <summary>
        /// Muls the t using the specified a
        /// </summary>
        /// <param name="A">The </param>
        /// <param name="v">The </param>
        /// <returns>The vector</returns>
        public static Vector2 MulT(ref Mat22 A, ref Vector2 v) => new Vector2(v.X * A.ex.X + v.Y * A.ex.Y, v.X * A.ey.X + v.Y * A.ey.Y);


        /// Multiply a matrix times a vector.
        public static Vector3 Mul(Mat33 A, Vector3 v) => v.X * A.Ex + v.Y * A.Ey + v.Z * A.Ez;

        /// <summary>
        /// Swaps the a
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

        /// Multiply a matrix times a vector.
        public static Vector2 Mul22(Mat33 A, Vector2 v) => new Vector2(A.Ex.X * v.X + A.Ey.X * v.Y, A.Ex.Y * v.X + A.Ey.Y * v.Y);

        /// Get the skew vector such that dot(skew_vec, other) == cross(vec, other)
        public static Vector2 Skew(Vector2 input) => new Vector2(-input.Y, input.X);

        /// <summary>
        ///     This function is used to ensure that a floating point number is
        ///     not a NaN or infinity.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        ///     <c>true</c> if the specified x is valid; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValid(float x)
        {
            if (float.IsNaN(x))
            {
                // NaN.
                return false;
            }

            return !float.IsInfinity(x);
        }

        /// <summary>
        /// Describes whether is valid
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool IsValid(this Vector2 x) => IsValid(x.X) && IsValid(x.Y);

        /// <summary>
        /// Clamps the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="low">The low</param>
        /// <param name="high">The high</param>
        /// <returns>The int</returns>
        public static int Clamp(int a, int low, int high) => Math.Max(low, Math.Min(a, high));

        /// <summary>
        /// Clamps the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="low">The low</param>
        /// <param name="high">The high</param>
        /// <returns>The float</returns>
        public static float Clamp(float a, float low, float high) => Math.Max(low, Math.Min(a, high));

        /// <summary>
        /// Clamps the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="low">The low</param>
        /// <param name="high">The high</param>
        /// <returns>The </returns>
        public static Vector2 Clamp(Vector2 a, Vector2 low, Vector2 high)
        {
            a.X = Math.Max(low.X, Math.Min(a.X, high.X));
            a.Y = Math.Max(low.Y, Math.Min(a.Y, high.Y));
            return a;
        }

        /// <summary>
        /// Crosses the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        public static void Cross(ref Vector2 a, ref Vector2 b, out float c)
        {
            c = a.X * b.Y - a.Y * b.X;
        }

        /// <summary>
        ///     Return the angle between two vectors on a plane
        ///     The angle is from vector 1 to vector 2, positive anticlockwise
        ///     The result is between -pi -> pi
        /// </summary>
        public static double VectorAngle(ref Vector2 p1, ref Vector2 p2)
        {
            double theta1 = Math.Atan2(p1.Y, p1.X);
            double theta2 = Math.Atan2(p2.Y, p2.X);
            double dtheta = theta2 - theta1;
            while (dtheta > Math.PI)
                dtheta -= 2 * Math.PI;
            while (dtheta < -Math.PI)
                dtheta += 2 * Math.PI;

            return dtheta;
        }

        /// Perform the dot product on two vectors.
        public static float Dot(Vector3 a, Vector3 b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z;

        /// Perform the dot product on two vectors.
        public static float Dot(Vector2 a, ref Vector2 b) => a.X * b.X + a.Y * b.Y;

        /// <summary>
        /// Vectors the angle using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <returns>The double</returns>
        public static double VectorAngle(Vector2 p1, Vector2 p2) => VectorAngle(ref p1, ref p2);

        /// <summary>
        ///     Returns a positive number if c is to the left of the line going from a to b.
        /// </summary>
        /// <returns>
        ///     Positive number if point is left, negative if point is right,
        ///     and 0 if points are collinear.
        /// </returns>
        public static float Area(Vector2 a, Vector2 b, Vector2 c) => Area(ref a, ref b, ref c);

        /// <summary>
        ///     Returns a positive number if c is to the left of the line going from a to b.
        /// </summary>
        /// <returns>
        ///     Positive number if point is left, negative if point is right,
        ///     and 0 if points are collinear.
        /// </returns>
        public static float Area(ref Vector2 a, ref Vector2 b, ref Vector2 c) => a.X * (b.Y - c.Y) + b.X * (c.Y - a.Y) + c.X * (a.Y - b.Y);

        /// <summary>
        ///     Determines if three vertices are collinear (ie. on a straight line)
        /// </summary>
        /// <param name="a">First vertex</param>
        /// <param name="b">Second vertex</param>
        /// <param name="c">Third vertex</param>
        /// <param name="tolerance">The tolerance</param>
        /// <returns></returns>
        public static bool IsCollinear(ref Vector2 a, ref Vector2 b, ref Vector2 c, float tolerance = 0) => FloatInRange(Area(ref a, ref b, ref c), -tolerance, tolerance);


        /// <summary>
        /// Describes whether float equals
        /// </summary>
        /// <param name="value1">The value</param>
        /// <param name="value2">The value</param>
        /// <returns>The bool</returns>
        public static bool FloatEquals(float value1, float value2) => Math.Abs(value1 - value2) <= float.Epsilon;

        /// <summary>
        ///     Checks if a floating point Value is equal to another,
        ///     within a certain tolerance.
        /// </summary>
        /// <param name="value1">The first floating point Value.</param>
        /// <param name="value2">The second floating point Value.</param>
        /// <param name="delta">The floating point tolerance.</param>
        /// <returns>True if the values are "equal", false otherwise.</returns>
        public static bool FloatEquals(float value1, float value2, float delta) => FloatInRange(value1, value2 - delta, value2 + delta);

        /// <summary>
        ///     Checks if a floating point Value is within a specified
        ///     range of values (inclusive).
        /// </summary>
        /// <param name="value">The Value to check.</param>
        /// <param name="min">The minimum Value.</param>
        /// <param name="max">The maximum Value.</param>
        /// <returns>
        ///     True if the Value is within the range specified,
        ///     false otherwise.
        /// </returns>
        public static bool FloatInRange(float value, float min, float max) => (value >= min) && (value <= max);

        /// <summary>
        /// Gets or sets the value of the epsilon
        /// </summary>
        public static float Epsilon { get; set; } = 1e-6f;
    }
}