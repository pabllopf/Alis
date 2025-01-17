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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     The math utils class
    /// </summary>
    public static class MathUtils
    {
        /// <summary>
        ///     Gets or sets the value of the epsilon
        /// </summary>
        public static float Epsilon { get; set; } = 1e-6f;

        /// <summary>
        ///     Crosses the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The float</returns>
        public static float Cross(ref Vector2F a, ref Vector2F b) => a.X * b.Y - a.Y * b.X;

        /// <summary>
        ///     Crosses the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The float</returns>
        public static float Cross(Vector2F a, Vector2F b) => Cross(ref a, ref b);

        /// Perform the cross product on two vectors.
        public static Vector3F Cross(ref Vector3F a, ref Vector3F b) => new Vector3F(a.Y * b.Z - a.Z * b.Y,
            a.Z * b.X - a.X * b.Z,
            a.X * b.Y - a.Y * b.X);

        /// <summary>
        ///     Crosses the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="s">The </param>
        /// <returns>The vector</returns>
        public static Vector2F Cross(Vector2F a, float s) => new Vector2F(s * a.Y, -s * a.X);

        /// <summary>
        ///     Rots the 270 using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <returns>The vector</returns>
        public static Vector2F Rot270(ref Vector2F a) => new Vector2F(a.Y, -a.X);

        /// <summary>
        ///     Crosses the s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="a">The </param>
        /// <returns>The vector</returns>
        public static Vector2F Cross(float s, ref Vector2F a) => new Vector2F(-s * a.Y, s * a.X);

        /// <summary>
        ///     Rots the 90 using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <returns>The vector</returns>
        public static Vector2F Rot90(ref Vector2F a) => new Vector2F(-a.Y, a.X);

        /// <summary>
        ///     Abses the v
        /// </summary>
        /// <param name="v">The </param>
        /// <returns>The vector</returns>
        public static Vector2F Abs(Vector2F v) => new Vector2F(Math.Abs(v.X), Math.Abs(v.Y));

        /// <summary>
        ///     Muls the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="v">The </param>
        /// <returns>The vector</returns>
        public static Vector2F Mul(ref Mat22 a, Vector2F v) => Mul(ref a, ref v);

        /// <summary>
        ///     Muls the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="v">The </param>
        /// <returns>The vector</returns>
        public static Vector2F Mul(ref Mat22 a, ref Vector2F v) => new Vector2F(a.Ex.X * v.X + a.Ey.X * v.Y, a.Ex.Y * v.X + a.Ey.Y * v.Y);

        /// <summary>
        ///     Muls the t using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="v">The </param>
        /// <returns>The vector</returns>
        public static Vector2F MulT(ref Mat22 a, Vector2F v) => MulT(ref a, ref v);

        /// <summary>
        ///     Muls the t using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="v">The </param>
        /// <returns>The vector</returns>
        public static Vector2F MulT(ref Mat22 a, ref Vector2F v) => new Vector2F(v.X * a.Ex.X + v.Y * a.Ex.Y, v.X * a.Ey.X + v.Y * a.Ey.Y);


        /// Multiply a matrix times a vector.
        public static Vector3F Mul(Mat33 a, Vector3F v) => v.X * a.Ex + v.Y * a.Ey + v.Z * a.Ez;

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

        /// Multiply a matrix times a vector.
        public static Vector2F Mul22(Mat33 a, Vector2F v) => new Vector2F(a.Ex.X * v.X + a.Ey.X * v.Y, a.Ex.Y * v.X + a.Ey.Y * v.Y);

        /// Get the skew vector such that dot(skew_vec, other) == cross(vec, other)
        public static Vector2F Skew(Vector2F input) => new Vector2F(-input.Y, input.X);

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
        public static float Clamp(float a, float low, float high) => Math.Max(low, Math.Min(a, high));

        /// <summary>
        ///     Clamps the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="low">The low</param>
        /// <param name="high">The high</param>
        /// <returns>The </returns>
        public static Vector2F Clamp(Vector2F a, Vector2F low, Vector2F high)
        {
            a.X = Math.Max(low.X, Math.Min(a.X, high.X));
            a.Y = Math.Max(low.Y, Math.Min(a.Y, high.Y));
            return a;
        }

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
        ///     Return the angle between two vectors on a plane
        ///     The angle is from vector 1 to vector 2, positive anticlockwise
        ///     The result is between -pi -> pi
        /// </summary>
        public static double VectorAngle(ref Vector2F p1, ref Vector2F p2)
        {
            double theta1 = Math.Atan2(p1.Y, p1.X);
            double theta2 = Math.Atan2(p2.Y, p2.X);
            double dtheta = theta2 - theta1;
            while (dtheta > Math.PI)
            {
                dtheta -= 2 * Math.PI;
            }

            while (dtheta < -Math.PI)
            {
                dtheta += 2 * Math.PI;
            }

            return dtheta;
        }

        /// Perform the dot product on two vectors.
        public static float Dot(Vector3F a, Vector3F b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z;

        /// Perform the dot product on two vectors.
        public static float Dot(Vector2F a, ref Vector2F b) => a.X * b.X + a.Y * b.Y;

        /// <summary>
        ///     Vectors the angle using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <returns>The double</returns>
        public static double VectorAngle(Vector2F p1, Vector2F p2) => VectorAngle(ref p1, ref p2);

        /// <summary>
        ///     Returns a positive number if c is to the left of the line going from a to b.
        /// </summary>
        /// <returns>
        ///     Positive number if point is left, negative if point is right,
        ///     and 0 if points are collinear.
        /// </returns>
        public static float Area(Vector2F a, Vector2F b, Vector2F c) => Area(ref a, ref b, ref c);

        /// <summary>
        ///     Returns a positive number if c is to the left of the line going from a to b.
        /// </summary>
        /// <returns>
        ///     Positive number if point is left, negative if point is right,
        ///     and 0 if points are collinear.
        /// </returns>
        public static float Area(ref Vector2F a, ref Vector2F b, ref Vector2F c) => a.X * (b.Y - c.Y) + b.X * (c.Y - a.Y) + c.X * (a.Y - b.Y);

        /// <summary>
        ///     Determines if three vertices are collinear (ie. on a straight line)
        /// </summary>
        /// <param name="a">First vertex</param>
        /// <param name="b">Second vertex</param>
        /// <param name="c">Third vertex</param>
        /// <param name="tolerance">The tolerance</param>
        /// <returns></returns>
        public static bool IsCollinear(ref Vector2F a, ref Vector2F b, ref Vector2F c, float tolerance = 0) => FloatInRange(Area(ref a, ref b, ref c), -tolerance, tolerance);


        /// <summary>
        ///     Describes whether float equals
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
    }
}