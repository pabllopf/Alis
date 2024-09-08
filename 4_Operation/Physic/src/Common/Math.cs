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
using System.Diagnostics;
using Alis.Core.Aspect.Math.Vector;


namespace Alis.Core.Physic.Common
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
        public static Vector3 Mul(Mat33 A, Vector3 v) => v.X * A.ex + v.Y * A.ey + v.Z * A.ez;

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
        public static Vector2 Mul22(Mat33 A, Vector2 v) => new Vector2(A.ex.X * v.X + A.ey.X * v.Y, A.ex.Y * v.X + A.ey.Y * v.Y);

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
        public static bool FloatEquals(float value1, float value2) => Math.Abs(value1 - value2) <= Settings.Epsilon;

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

        public static float Epsilon { get; set; } = 1e-6f;
    }

    /// <summary>
    ///     A 2-by-2 matrix. Stored in column-major order.
    /// </summary>
    public struct Mat22
    {
        /// <summary>
        /// The ey
        /// </summary>
        public Vector2 ex, ey;

        /// <summary>
        ///     Construct this matrix using columns.
        /// </summary>
        /// <param name="c1">The c1.</param>
        /// <param name="c2">The c2.</param>
        public Mat22(Vector2 c1, Vector2 c2)
        {
            ex = c1;
            ey = c2;
        }

        /// <summary>
        ///     Construct this matrix using scalars.
        /// </summary>
        /// <param name="a11">The a11.</param>
        /// <param name="a12">The a12.</param>
        /// <param name="a21">The a21.</param>
        /// <param name="a22">The a22.</param>
        public Mat22(float a11, float a12, float a21, float a22)
        {
            ex = new Vector2(a11, a21);
            ey = new Vector2(a12, a22);
        }

        /// <summary>
        /// Gets the value of the inverse
        /// </summary>
        public Mat22 Inverse
        {
            get
            {
                float a = ex.X, b = ey.X, c = ex.Y, d = ey.Y;
                float det = a * d - b * c;
                if (det != 0.0f)
                {
                    det = 1.0f / det;
                }

                Mat22 result;
                result.ex = new Vector2(det * d, -det * c);
                result.ey = new Vector2(-det * b, det * a);

                return result;
            }
        }

        /// <summary>
        ///     Initialize this matrix using columns.
        /// </summary>
        /// <param name="c1">The c1.</param>
        /// <param name="c2">The c2.</param>
        public void Set(Vector2 c1, Vector2 c2)
        {
            ex = c1;
            ey = c2;
        }

        /// <summary>
        ///     Set this to the identity matrix.
        /// </summary>
        public void SetIdentity()
        {
            ex.X = 1.0f;
            ey.X = 0.0f;
            ex.Y = 0.0f;
            ey.Y = 1.0f;
        }

        /// <summary>
        ///     Set this matrix to all zeros.
        /// </summary>
        public void SetZero()
        {
            ex.X = 0.0f;
            ey.X = 0.0f;
            ex.Y = 0.0f;
            ey.Y = 0.0f;
        }

        /// <summary>
        ///     Solve A * x = b, where b is a column vector. This is more efficient
        ///     than computing the inverse in one-shot cases.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        public Vector2 Solve(Vector2 b)
        {
            float a11 = ex.X, a12 = ey.X, a21 = ex.Y, a22 = ey.Y;
            float det = a11 * a22 - a12 * a21;
            if (det != 0.0f)
            {
                det = 1.0f / det;
            }

            return new Vector2(det * (a22 * b.X - a12 * b.Y), det * (a11 * b.Y - a21 * b.X));
        }

        /// <summary>
        /// Adds the a
        /// </summary>
        /// <param name="A">The </param>
        /// <param name="B">The </param>
        /// <param name="R">The </param>
        public static void Add(ref Mat22 A, ref Mat22 B, out Mat22 R)
        {
            R.ex = A.ex + B.ex;
            R.ey = A.ey + B.ey;
        }
    }

    /// <summary>
    ///     A 3-by-3 matrix. Stored in column-major order.
    /// </summary>
    public struct Mat33
    {
        /// <summary>
        /// The ez
        /// </summary>
        public Vector3 ex, ey, ez;

        /// <summary>
        ///     Construct this matrix using columns.
        /// </summary>
        /// <param name="c1">The c1.</param>
        /// <param name="c2">The c2.</param>
        /// <param name="c3">The c3.</param>
        public Mat33(Vector3 c1, Vector3 c2, Vector3 c3)
        {
            ex = c1;
            ey = c2;
            ez = c3;
        }

        /// <summary>
        ///     Set this matrix to all zeros.
        /// </summary>
        public void SetZero()
        {
            ex = Vector3.Zero;
            ey = Vector3.Zero;
            ez = Vector3.Zero;
        }

        /// <summary>
        ///     Solve A * x = b, where b is a column vector. This is more efficient
        ///     than computing the inverse in one-shot cases.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        public Vector3 Solve33(Vector3 b)
        {
            float det = Vector3.Dot(ex, Vector3.Cross(ey, ez));
            if (det != 0.0f)
            {
                det = 1.0f / det;
            }

            return new Vector3(det * Vector3.Dot(b, Vector3.Cross(ey, ez)), det * Vector3.Dot(ex, Vector3.Cross(b, ez)), det * Vector3.Dot(ex, Vector3.Cross(ey, b)));
        }

        /// <summary>
        ///     Solve A * x = b, where b is a column vector. This is more efficient
        ///     than computing the inverse in one-shot cases. Solve only the upper
        ///     2-by-2 matrix equation.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        public Vector2 Solve22(Vector2 b)
        {
            float a11 = ex.X, a12 = ey.X, a21 = ex.Y, a22 = ey.Y;
            float det = a11 * a22 - a12 * a21;

            if (det != 0.0f)
            {
                det = 1.0f / det;
            }

            return new Vector2(det * (a22 * b.X - a12 * b.Y), det * (a11 * b.Y - a21 * b.X));
        }

        /// Get the inverse of this matrix as a 2-by-2.
        /// Returns the zero matrix if singular.
        public void GetInverse22(ref Mat33 M)
        {
            float a = ex.X, b = ey.X, c = ex.Y, d = ey.Y;
            float det = a * d - b * c;
            if (det != 0.0f)
            {
                det = 1.0f / det;
            }

            M.ex.X = det * d;
            M.ey.X = -det * b;
            M.ex.Z = 0.0f;
            M.ex.Y = -det * c;
            M.ey.Y = det * a;
            M.ey.Z = 0.0f;
            M.ez.X = 0.0f;
            M.ez.Y = 0.0f;
            M.ez.Z = 0.0f;
        }

        /// Get the symmetric inverse of this matrix as a 3-by-3.
        /// Returns the zero matrix if singular.
        public void GetSymInverse33(ref Mat33 M)
        {
            float det = MathUtils.Dot(ex, MathUtils.Cross(ref ey, ref ez));
            if (det != 0.0f)
            {
                det = 1.0f / det;
            }

            float a11 = ex.X, a12 = ey.X, a13 = ez.X;
            float a22 = ey.Y, a23 = ez.Y;
            float a33 = ez.Z;

            M.ex.X = det * (a22 * a33 - a23 * a23);
            M.ex.Y = det * (a13 * a23 - a12 * a33);
            M.ex.Z = det * (a12 * a23 - a13 * a22);

            M.ey.X = M.ex.Y;
            M.ey.Y = det * (a11 * a33 - a13 * a13);
            M.ey.Z = det * (a13 * a12 - a11 * a23);

            M.ez.X = M.ex.Z;
            M.ez.Y = M.ey.Z;
            M.ez.Z = det * (a11 * a22 - a12 * a12);
        }
    }


    /// <summary>
    ///     A transform contains translation and rotation. It is used to represent
    ///     the position and orientation of rigid frames.
    /// </summary>
    public struct Transform
    {
        /// <summary>
        /// The 
        /// </summary>
        public Complex q;
        /// <summary>
        /// The 
        /// </summary>
        public Vector2 p;

        /// <summary>
        /// Gets the value of the identity
        /// </summary>
        public static Transform Identity { get; } = new Transform(Vector2.Zero, Complex.One);

        /// <summary>
        ///     Initialize using a position vector and a Complex rotation.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The rotation</param>
        public Transform(Vector2 position, Complex rotation)
        {
            q = rotation;
            p = position;
        }

        /// <summary>
        ///     Initialize using a position vector and a rotation.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="angle">The rotation angle</param>
        public Transform(Vector2 position, float angle)
            : this(position, Complex.FromAngle(angle))
        {
        }

        /// <summary>
        /// Multiplies the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The vector</returns>
        public static Vector2 Multiply(Vector2 left, ref Transform right) => Multiply(ref left, ref right);

        /// <summary>
        /// Multiplies the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The vector</returns>
        public static Vector2 Multiply(ref Vector2 left, ref Transform right) =>
            // Opt: var result = Complex.Multiply(left, right.q) + right.p;
            new Vector2(
                left.X * right.q.R - left.Y * right.q.i + right.p.X,
                left.Y * right.q.R + left.X * right.q.i + right.p.Y);

        /// <summary>
        /// Divides the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The vector</returns>
        public static Vector2 Divide(Vector2 left, ref Transform right) => Divide(ref left, ref right);

        /// <summary>
        /// Divides the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The vector</returns>
        public static Vector2 Divide(ref Vector2 left, ref Transform right)
        {
            // Opt: var result = Complex.Divide(left - right.p, right);
            float px = left.X - right.p.X;
            float py = left.Y - right.p.Y;
            return new Vector2(
                px * right.q.R + py * right.q.i,
                py * right.q.R - px * right.q.i);
        }

        /// <summary>
        /// Divides the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <param name="result">The result</param>
        public static void Divide(Vector2 left, ref Transform right, out Vector2 result)
        {
            // Opt: var result = Complex.Divide(left - right.p, right);
            float px = left.X - right.p.X;
            float py = left.Y - right.p.Y;
            result = new Vector2(
                px * right.q.R + py * right.q.i,
                py * right.q.R - px * right.q.i);
        }

        /// <summary>
        /// Multiplies the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The transform</returns>
        public static Transform Multiply(ref Transform left, ref Transform right) => new Transform(
            Complex.Multiply(ref left.p, ref right.q) + right.p,
            Complex.Multiply(ref left.q, ref right.q));

        /// <summary>
        /// Divides the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The transform</returns>
        public static Transform Divide(ref Transform left, ref Transform right) => new Transform(
            Complex.Divide(left.p - right.p, ref right.q),
            Complex.Divide(ref left.q, ref right.q));

        /// <summary>
        /// Divides the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <param name="result">The result</param>
        public static void Divide(ref Transform left, ref Transform right, out Transform result)
        {
            Complex.Divide(left.p - right.p, ref right.q, out result.p);
            Complex.Divide(ref left.q, ref right.q, out result.q);
        }

        /// <summary>
        /// Multiplies the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <param name="result">The result</param>
        public static void Multiply(ref Transform left, Complex right, out Transform result)
        {
            result.p = Complex.Multiply(ref left.p, ref right);
            result.q = Complex.Multiply(ref left.q, ref right);
        }

        /// <summary>
        /// Divides the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <param name="result">The result</param>
        public static void Divide(ref Transform left, Complex right, out Transform result)
        {
            result.p = Complex.Divide(ref left.p, ref right);
            result.q = Complex.Divide(ref left.q, ref right);
        }
    }

    /// <summary>
    ///     This describes the motion of a body/shape for TOI computation.
    ///     Shapes are defined with respect to the body origin, which may
    ///     no coincide with the center of mass. However, to support dynamics
    ///     we must interpolate the center of mass position.
    /// </summary>
    public struct Sweep
    {
        /// <summary>
        ///     World angles
        /// </summary>
        public float A;

        /// <summary>
        /// The 
        /// </summary>
        public float A0;

        /// <summary>
        ///     Fraction of the current time step in the range [0,1]
        ///     c0 and a0 are the positions at alpha0.
        /// </summary>
        public float Alpha0;

        /// <summary>
        ///     Center world positions
        /// </summary>
        public Vector2 C;

        /// <summary>
        /// The 
        /// </summary>
        public Vector2 C0;

        /// <summary>
        ///     Local center of mass position
        /// </summary>
        public Vector2 LocalCenter;

        /// <summary>
        ///     Get the interpolated transform at a specific time.
        /// </summary>
        /// <param name="xfb">The transform.</param>
        /// <param name="beta">beta is a factor in [0,1], where 0 indicates alpha0.</param>
        public void GetTransform(out Transform xfb, float beta)
        {
            xfb.p = new Vector2((1.0f - beta) * C0.X + beta * C.X, (1.0f - beta) * C0.Y + beta * C.Y);
            float angle = (1.0f - beta) * A0 + beta * A;
            xfb.q = Complex.FromAngle(angle);

            // Shift to origin
            xfb.p -= Complex.Multiply(ref LocalCenter, ref xfb.q);
        }

        /// <summary>
        ///     Advance the sweep forward, yielding a new initial state.
        /// </summary>
        /// <param name="alpha">new initial time..</param>
        public void Advance(float alpha)
        {
            Debug.Assert(Alpha0 < 1.0f);
            float beta = (alpha - Alpha0) / (1.0f - Alpha0);
            C0 += beta * (C - C0);
            A0 += beta * (A - A0);
            Alpha0 = alpha;
        }

        /// <summary>
        ///     Normalize the angles.
        /// </summary>
        public void Normalize()
        {
            float d = Constant.Tau * (float) Math.Floor(A0 / Constant.Tau);
            A0 -= d;
            A -= d;
        }
    }
}