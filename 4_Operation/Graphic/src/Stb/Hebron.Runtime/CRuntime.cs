// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CRuntime.cs
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
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Stb.Hebron.Runtime
{
    /// <summary>
    ///     The runtime class
    /// </summary>
    internal static unsafe class CRuntime
    {
        /// <summary>
        ///     The numbers
        /// </summary>
        private static readonly string numbers = "0123456789";

        /// <summary>
        ///     Mallocs the size
        /// </summary>
        /// <param name="size">The size</param>
        /// <returns>The void</returns>
        public static void* malloc(ulong size) => malloc((long) size);

        /// <summary>
        ///     Mallocs the size
        /// </summary>
        /// <param name="size">The size</param>
        /// <returns>The void</returns>
        public static void* malloc(long size)
        {
            IntPtr ptr = Marshal.AllocHGlobal((int) size);

            MemoryStats.Allocated();

            return ptr.ToPointer();
        }

        /// <summary>
        ///     Frees the a
        /// </summary>
        /// <param name="a">The </param>
        public static void free(void* a)
        {
            if (a == null)
            {
                return;
            }

            IntPtr ptr = new IntPtr(a);
            Marshal.FreeHGlobal(ptr);
            MemoryStats.Freed();
        }

        /// <summary>
        ///     Memcpies the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="size">The size</param>
        public static void memcpy(void* a, void* b, long size)
        {
            Buffer.MemoryCopy(b, a, size, size);
        }

        /// <summary>
        ///     Memcpies the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="size">The size</param>
        public static void memcpy(void* a, void* b, ulong size)
        {
            memcpy(a, b, (long) size);
        }

        /// <summary>
        ///     Memmoves the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="size">The size</param>
        public static void memmove(void* a, void* b, long size)
        {
            void* temp = null;

            try
            {
                temp = malloc(size);
                memcpy(temp, b, size);
                memcpy(a, temp, size);
            }

            finally
            {
                if (temp != null)
                {
                    free(temp);
                }
            }
        }

        /// <summary>
        ///     Memcmps the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="size">The size</param>
        /// <returns>The result</returns>
        public static int memcmp(void* a, void* b, long size)
        {
            int result = 0;
            byte* ap = (byte*) a;
            byte* bp = (byte*) b;
            for (long i = 0; i < size; ++i)
            {
                if (*ap != *bp)
                {
                    result += 1;
                }

                ap++;
                bp++;
            }

            return result;
        }

        /// <summary>
        ///     Memsets the ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        /// <param name="value">The value</param>
        /// <param name="size">The size</param>
        public static void memset(void* ptr, int value, long size)
        {
            byte* bptr = (byte*) ptr;
            byte bval = (byte) value;
            for (long i = 0; i < size; ++i)
                *bptr++ = bval;
        }

        /// <summary>
        ///     Memsets the ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        /// <param name="value">The value</param>
        /// <param name="size">The size</param>
        public static void memset(void* ptr, int value, ulong size)
        {
            memset(ptr, value, (long) size);
        }

        /// <summary>
        ///     Lrotls the x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        public static uint _lrotl(uint x, int y) => (x << y) | (x >> (32 - y));

        /// <summary>
        ///     Reallocs the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="newSize">The new size</param>
        /// <returns>The void</returns>
        public static void* realloc(void* a, long newSize)
        {
            if (a == null)
            {
                return malloc(newSize);
            }

            IntPtr ptr = new IntPtr(a);
            IntPtr result = Marshal.ReAllocHGlobal(ptr, new IntPtr(newSize));

            return result.ToPointer();
        }

        /// <summary>
        ///     Reallocs the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="newSize">The new size</param>
        /// <returns>The void</returns>
        public static void* realloc(void* a, ulong newSize) => realloc(a, (long) newSize);

        /// <summary>
        ///     Abses the v
        /// </summary>
        /// <param name="v">The </param>
        /// <returns>The int</returns>
        public static int abs(int v) => Math.Abs(v);

        /// <summary>
        ///     Pows the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The double</returns>
        public static double pow(double a, double b) => Math.Pow(a, b);

        /// <summary>
        ///     Ldexps the number
        /// </summary>
        /// <param name="number">The number</param>
        /// <param name="exponent">The exponent</param>
        /// <returns>The double</returns>
        public static double ldexp(double number, int exponent) => number * Math.Pow(2, exponent);

        /// <summary>
        ///     Strcmps the src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="token">The token</param>
        /// <returns>The result</returns>
        public static int strcmp(sbyte* src, string token)
        {
            int result = 0;

            for (int i = 0; i < token.Length; ++i)
            {
                if (src[i] != token[i])
                {
                    ++result;
                }
            }

            return result;
        }

        /// <summary>
        ///     Strncmps the src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="token">The token</param>
        /// <param name="size">The size</param>
        /// <returns>The result</returns>
        public static int strncmp(sbyte* src, string token, ulong size)
        {
            int result = 0;

            for (int i = 0; i < Math.Min(token.Length, (int) size); ++i)
            {
                if (src[i] != token[i])
                {
                    ++result;
                }
            }

            return result;
        }

        /// <summary>
        ///     Strtols the start
        /// </summary>
        /// <param name="start">The start</param>
        /// <param name="end">The end</param>
        /// <param name="radix">The radix</param>
        /// <returns>The result</returns>
        public static long strtol(sbyte* start, sbyte** end, int radix)
        {
            // First step - determine length
            int length = 0;
            sbyte* ptr = start;
            while (numbers.IndexOf((char) *ptr) != -1)
            {
                ++ptr;
                ++length;
            }

            long result = 0;

            // Now build up the number
            ptr = start;
            while (length > 0)
            {
                long num = numbers.IndexOf((char) *ptr);
                long pow = (long) Math.Pow(10, length - 1);
                result += num * pow;

                ++ptr;
                --length;
            }

            if (end != null)
            {
                *end = ptr;
            }

            return result;
        }
    }
}