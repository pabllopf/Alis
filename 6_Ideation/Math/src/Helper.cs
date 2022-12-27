// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Helper.cs
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
using System.Numerics;
using System.Runtime.InteropServices;

namespace Alis.Core.Aspect.Math
{
    /// <summary>
    ///     The math class
    /// </summary>
    public class Helper
    {
        /// <summary>
        ///     The ushrt max
        /// </summary>
        public static readonly ushort UshrtMax = 0xffff;

        /// <summary>
        ///     The uchar max
        /// </summary>
        public static readonly byte UcharMax = 0xff;

        /// <summary>
        ///     The rand limit
        /// </summary>
        public static readonly int RandLimit = 32767;

        /// <summary>
        ///     The random
        /// </summary>
        private static readonly Random SRnd = new Random();

        /// <summary>
        ///     This function is used to ensure that a floating point number is
        ///     not a NaN or infinity.
        /// </summary>
        public static bool IsValid(float x) => !(float.IsNaN(x) || float.IsNegativeInfinity(x) || float.IsPositiveInfinity(x));

        /// <summary>
        ///     This is a approximate yet fast inverse square-root.
        /// </summary>
        public static float InvSqrt(float x)
        {
            Convert convert = new Convert();
            convert.x = x;
            float xhalf = 0.5f * x;
            convert.i = 0x5f3759df - (convert.i >> 1);
            x = convert.x;
            x = x * (1.5f - xhalf * x * x);
            return x;
        }

        /// <summary>
        ///     Sqrts the x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The float</returns>
        public static float Sqrt(float x) => (float) System.Math.Sqrt(x);

        /// <summary>
        ///     Random number in range [-1,1]
        /// </summary>
        public static float Random()
        {
            float r = SRnd.Next() & RandLimit;
            r /= RandLimit;
            r = 2.0f * r - 1.0f;
            return r;
        }

        /// <summary>
        ///     Random floating point number in range [lo, hi]
        /// </summary>
        public static float Random(float lo, float hi)
        {
            float r = SRnd.Next() & RandLimit;
            r /= RandLimit;
            r = (hi - lo) * r + lo;
            return r;
        }

        /// <summary>
        ///     "Next Largest Power of 2
        ///     Given a binary integer value x, the next largest power of 2 can be computed by a SWAR algorithm
        ///     that recursively "folds" the upper bits into the lower bits. This process yields a bit vector with
        ///     the same most significant 1 as x, but all 1's below it. Adding 1 to that value yields the next
        ///     largest power of 2. For a 32-bit value:"
        /// </summary>
        public static uint NextPowerOfTwo(uint x)
        {
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;
            return x + 1;
        }

        /// <summary>
        ///     Describes whether is power of two
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The result</returns>
        public static bool IsPowerOfTwo(uint x)
        {
            bool result = (x > 0) && ((x & (x - 1)) == 0);
            return result;
        }

        /// <summary>
        ///     Abses the a
        /// </summary>
        /// <param name="a">The </param>
        /// <returns>The float</returns>
        public static float Abs(float a) => a > 0.0f ? a : -a;

        /// <summary>
        ///     Abses the a
        /// </summary>
        /// <param name="a">The </param>
        /// <returns>The </returns>
        public static Vector2 Abs(Vector2 a)
        {
            Vector2 b = new Vector2(Abs(a.X), Abs(a.Y));
            return b;
        }

        /// <summary>
        ///     Abses the a
        /// </summary>
        /// <param name="a">The </param>
        /// <returns>The </returns>
        public static Matrix22 Abs(Matrix22 a)
        {
            Matrix22 b = new Matrix22();
            b.Set(Abs(a.Col1), Abs(a.Col2));
            return b;
        }

        /// <summary>
        ///     Mins the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The float</returns>
        public static float Min(float a, float b) => a < b ? a : b;

        /// <summary>
        ///     Mins the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        public static int Min(int a, int b) => a < b ? a : b;

        /// <summary>
        ///     Mins the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The </returns>
        public static Vector2 Min(Vector2 a, Vector2 b)
        {
            Vector2 c = new Vector2();
            c.X = Min(a.X, b.X);
            c.Y = Min(a.Y, b.Y);
            return c;
        }

        /// <summary>
        ///     Maxes the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The float</returns>
        public static float Max(float a, float b) => a > b ? a : b;

        /// <summary>
        ///     Maxes the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        public static int Max(int a, int b) => a > b ? a : b;

        /// <summary>
        ///     Maxes the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The </returns>
        public static Vector2 Max(Vector2 a, Vector2 b)
        {
            Vector2 c = new Vector2();
            c.X = Max(a.X, b.X);
            c.Y = Max(a.Y, b.Y);
            return c;
        }

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
        /// <returns>The int</returns>
        public static int Clamp(int a, int low, int high) => Max(low, Min(a, high));

        /// <summary>
        ///     Clamps the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="low">The low</param>
        /// <param name="high">The high</param>
        /// <returns>The vec</returns>
        public static Vector2 Clamp(Vector2 a, Vector2 low, Vector2 high) => Max(low, Min(a, high));

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

        /// <summary>
        ///     Multiply a matrix times a vector. If a rotation matrix is provided,
        ///     then this transforms the vector from one frame to another.
        /// </summary>
        public static Vector2 Mul(Matrix22 a, Vector2 v)
        {
            return new Vector2(a.Col1.X * v.X + a.Col2.X * v.Y, a.Col1.Y * v.X + a.Col2.Y * v.Y);
        }

        /// <summary>
        ///     Multiply a matrix transpose times a vector. If a rotation matrix is provided,
        ///     then this transforms the vector from one frame to another (inverse transform).
        /// </summary>
        public static Vector2 MulT(Matrix22 a, Vector2 v)
        {
            Vector2 u = new Vector2(Vector2.Dot(v, a.Col1), Vector2.Dot(v, a.Col2));
            return u;
        }

        /// <summary>
        ///     A * B
        /// </summary>
        public static Matrix22 Mul(Matrix22 a, Matrix22 b)
        {
            Matrix22 c = new Matrix22();
            c.Set(Mul(a, b.Col1), Mul(a, b.Col2));
            return c;
        }

        /// <summary>
        ///     A^T * B
        /// </summary>
        public static Matrix22 MulT(Matrix22 a, Matrix22 b)
        {
            Vector2 c1 = new Vector2(Vector2.Dot(a.Col1, b.Col1), Vector2.Dot(a.Col2, b.Col1));
            Vector2 c2 = new Vector2(Vector2.Dot(a.Col1, b.Col2), Vector2.Dot(a.Col2, b.Col2));
            Matrix22 c = new Matrix22();
            c.Set(c1, c2);
            return c;
        }

        /// <summary>
        ///     Muls the t
        /// </summary>
        /// <param name="T">The </param>
        /// <param name="v">The </param>
        /// <returns>The vec</returns>
        public static Vector2 Mul(XForm T, Vector2 v) => T.Position + Mul(T.R, v);

        /// <summary>
        ///     Muls the t using the specified t
        /// </summary>
        /// <param name="T">The </param>
        /// <param name="v">The </param>
        /// <returns>The vec</returns>
        public static Vector2 MulT(XForm T, Vector2 v) => MulT(T.R, v - T.Position);

        /// <summary>
        ///     Multiply a matrix times a vector.
        /// </summary>
        public static Vector3 Mul(Matrix33 a, Vector3 v)
        {
            Vector3 u = v.X * a.Col1 + v.Y * a.Col2 + v.Z * a.Col3;
            return u;
        }

        /// <summary>
        ///     Atans the 2 using the specified y
        /// </summary>
        /// <param name="y">The </param>
        /// <param name="x">The </param>
        /// <returns>The float</returns>
        public static float Atan2(float y, float x) => (float) System.Math.Atan2(y, x);

        /// <summary>
        ///     The convert
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct Convert
        {
            /// <summary>
            ///     The
            /// </summary>
            [FieldOffset(0)] public float x;

            /// <summary>
            ///     The
            /// </summary>
            [FieldOffset(0)] public int i;
        }
    }
}