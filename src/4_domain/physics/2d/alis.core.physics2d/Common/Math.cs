// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Math.cs
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
using System.Runtime.InteropServices;

namespace Alis.Core.Physics2D
{
    /// <summary>
    ///     The math class
    /// </summary>
    internal static class Math
    {
        /// <summary>
        ///     The max value
        /// </summary>
        internal const ushort USHRT_MAX = ushort.MaxValue;

        /// <summary>
        ///     The max value
        /// </summary>
        internal const byte UCHAR_MAX = byte.MaxValue;

        /// <summary>
        ///     The rand limit
        /// </summary>
        internal const int RAND_LIMIT = 32767;

        /// <summary>
        ///     The random
        /// </summary>
        private static readonly Random s_rnd = new Random();

        /// <summary>
        ///     This function is used to ensure that a floating point number is
        ///     not a NaN or infinity.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsValid(float x) =>
            !(float.IsNaN(x) || float.IsNegativeInfinity(x) || float.IsPositiveInfinity(x));

        /// <summary>
        ///     This is a approximate yet fast inverse square-root.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float InvSqrt(float x)
        {
            Convert convert = default(Convert);
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
        [Obsolete("Use MathF.Sqrt", true)]
        internal static float Sqrt(float x) => (float) System.Math.Sqrt(x);

        /// <summary>
        ///     Random number in range [-1,1]
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float Random()
        {
            float r = s_rnd.Next() & RAND_LIMIT;
            r /= RAND_LIMIT;
            r = 2.0f * r - 1.0f;
            return r;
        }

        /// <summary>
        ///     Random floating point number in range [lo, hi]
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float Random(float lo, float hi)
        {
            float r = s_rnd.Next() & RAND_LIMIT;
            r /= RAND_LIMIT;
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint NextPowerOfTwo(uint x)
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsPowerOfTwo(uint x)
        {
            bool result = x > 0 && (x & (x - 1)) == 0;
            return result;
        }

        /// <summary>
        ///     Multiply a matrix transpose times a vector. If a rotation matrix is provided,
        ///     then this transforms the vector from one frame to another (inverse transform).
        /// </summary>
        // [MethodImpl(MethodImplOptions.AggressiveInlining)]
        // internal static Vector2 MulT(Mat22 A, Vector2 v) => new Vector2(Vector2.Dot(v, A.ex), Vector2.Dot(v, A.ey));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2 MulT(Matrix3x2 A, Vector2 v)
        {
            /*Matrix3x2*/
            Matrex.Invert(A, out Matrix3x2 AT);
            return Vector2.Transform(v, AT);
        }


        /// <summary>
        ///     A * B
        /// </summary>
        // [MethodImpl(MethodImplOptions.AggressiveInlining)]
        // internal static Mat22 Mul(Mat22 A, Mat22 B) {
        //   Mat22 C = new Mat22();
        //   C.Set(Mul(A, B.ex), Mul(A, B.ey));
        //   return C;
        // }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Matrix3x2 Mul(Matrix3x2 A, Matrix3x2 B) => A * B;

        /// <summary>
        ///     A^T * B
        /// </summary>
        // [MethodImpl(MethodImplOptions.AggressiveInlining)]
        // internal static Mat22 MulT(Mat22 A, Mat22 B) {
        //   Vector2 c1 = new Vector2(Vector2.Dot(A.ex, B.ex), Vector2.Dot(A.ey, B.ex));
        //   Vector2 c2 = new Vector2(Vector2.Dot(A.ex, B.ey), Vector2.Dot(A.ey, B.ey));
        //   Mat22   C  = new Mat22();
        //   C.Set(c1, c2);
        //   return C;
        // }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Matrix3x2 MulT(Matrix3x2 A, Matrix3x2 B)
        {
            /*Matrix3x2*/
            Matrex.Invert(A, out Matrix3x2 AT);
            return AT * B;
        }

        /// <summary>
        ///     Muls the t
        /// </summary>
        /// <param name="T">The </param>
        /// <param name="v">The </param>
        /// <returns>The vector</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2 Mul(Transform T, Vector2 v) => T.p + Vector2.Transform(v, T.q); //Mul(T.q, v);

        /// <summary>
        ///     Muls the t using the specified t
        /// </summary>
        /// <param name="T">The </param>
        /// <param name="v">The </param>
        /// <returns>The vector</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2 MulT(Transform T, Vector2 v) => MulT(T.q, v - T.p);

        /// <summary>
        ///     Multiply a matrix times a vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector3 Mul(Mat33 A, Vector3 v) => v.X * A.ex + v.Y * A.ey + v.Z * A.ez;


        /// <summary>
        ///     Muls the q
        /// </summary>
        /// <param name="q">The </param>
        /// <param name="v">The </param>
        /// <returns>The vector</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2 Mul(Rot q, Vector2 v) => new Vector2(q.c * v.X - q.s * v.Y, q.s * v.X + q.c * v.Y);

        /// <summary>
        ///     Muls the t using the specified q
        /// </summary>
        /// <param name="q">The </param>
        /// <param name="v">The </param>
        /// <returns>The vector</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2 MulT(Rot q, Vector2 v) => new Vector2(q.c * v.X + q.s * v.Y, -q.s * v.X + q.c * v.Y);


        // v2 = A.q.Rot(B.q.Rot(v1) + B.p) + A.p
        //    = (A.q * B.q).Rot(v1) + A.q.Rot(B.p) + A.p
        /// <summary>
        ///     Muls the a
        /// </summary>
        /// <param name="A">The </param>
        /// <param name="B">The </param>
        /// <returns>The </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Transform Mul(in Transform A, in Transform B)
        {
            Transform C;
            C.q = Mul(A.q, B.q);
            C.p = A.p + Vector2.Transform(B.p, A.q); //Mul(A.q, B.p);
            return C;
        }

        // v2 = A.q' * (B.q * v1 + B.p - A.p)
        //    = A.q' * B.q * v1 + A.q' * (B.p - A.p)
        /// <summary>
        ///     Muls the t using the specified a
        /// </summary>
        /// <param name="A">The </param>
        /// <param name="B">The </param>
        /// <returns>The </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Transform MulT(in Transform A, in Transform B)
        {
            Transform C;
            C.q = MulT(A.q, B.q);
            C.p = MulT(A.q, B.p - A.p);
            return C;
        }

        /// <summary>
        ///     Muls the 22 using the specified a
        /// </summary>
        /// <param name="A">The </param>
        /// <param name="v">The </param>
        /// <returns>The vector</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2 Mul22(in Mat33 A, in Vector2 v) =>
            new Vector2(A.ex.X * v.X + A.ey.X * v.X, A.ex.Y * v.X + A.ey.Y * v.Y);

        /// <summary>
        ///     The convert
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        internal struct Convert
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