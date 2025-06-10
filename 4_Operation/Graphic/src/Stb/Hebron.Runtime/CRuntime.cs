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
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Stb.Hebron.Runtime
{
    /// <summary>
    ///     The runtime class
    /// </summary>
    internal static class CRuntime
    {
        /// <summary>
        ///     The numbers
        /// </summary>
        private static readonly string Numbers = "0123456789";

        /// <summary>
        ///     Mallocs the size
        /// </summary>
        /// <param name="size">The size</param>
        /// <returns>The void</returns>
        public static IntPtr Malloc(ulong size) => Malloc((long) size);

        /// <summary>
        ///     Mallocs the size
        /// </summary>
        /// <param name="size">The size</param>
        /// <returns>The void</returns>
        public static IntPtr Malloc(long size)
        {
            IntPtr ptr = Marshal.AllocHGlobal((int) size);

            MemoryStats.Allocated();

            return ptr;
        }

        /// <summary>
        ///     Frees the a
        /// </summary>
        /// <param name="ptr">The </param>
        public static void Free(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                return;
            }
            
            Marshal.FreeHGlobal(ptr);
            MemoryStats.Freed();
        }

        /// <summary>
        ///     Memcpies the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="size">The size</param>
        public static void Memcpy(IntPtr a, IntPtr b, long size)
        {
            byte[] buffer = new byte[size];
            Marshal.Copy(b, buffer, 0, (int)size);
            Marshal.Copy(buffer, 0, a, (int)size);
        }

       /// <summary>
       ///     Memcpies the a
       /// </summary>
       /// <param name="a">The </param>
       /// <param name="b">The </param>
       /// <param name="size">The size</param>
       public static void Memcpy(IntPtr a, IntPtr b, ulong size)
       {
           byte[] buffer = new byte[size];
           Marshal.Copy(b, buffer, 0, (int)size);
           Marshal.Copy(buffer, 0, a, (int)size);
       }

        /// <summary>
        ///     Memmoves the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="size">The size</param>
        public static void Memmove(IntPtr a, IntPtr b, long size)
        {
            byte[] buffer = new byte[size];
            Marshal.Copy(b, buffer, 0, (int)size);
            Marshal.Copy(buffer, 0, a, (int)size);
        }
        
        /// <summary>
        ///     Memcmps the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="size">The size</param>
        /// <returns>The result</returns>
        public static int Memcmp(IntPtr a, IntPtr b, long size)
        {
            byte[] bufferA = new byte[size];
            byte[] bufferB = new byte[size];
            Marshal.Copy(a, bufferA, 0, (int)size);
            Marshal.Copy(b, bufferB, 0, (int)size);
        
            int result = 0;
            for (long i = 0; i < size; ++i)
            {
                if (bufferA[i] != bufferB[i])
                {
                    result += 1;
                }
            }
        
            return result;
        }

        /// <summary>
        ///     Memsets the ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        /// <param name="value">The value</param>
        /// <param name="size">The size</param>
        public static void Memset(IntPtr ptr, int value, long size)
        {
            byte[] buffer = new byte[size];
            byte bval = (byte)value;
            for (long i = 0; i < size; ++i)
            {
                buffer[i] = bval;
            }
            Marshal.Copy(buffer, 0, ptr, (int)size);
        }

        /// <summary>
        ///     Memsets the ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        /// <param name="value">The value</param>
        /// <param name="size">The size</param>
        public static void Memset(IntPtr ptr, int value, ulong size)
        {
            byte[] buffer = new byte[size];
            byte bval = (byte)value;
            for (ulong i = 0; i < size; ++i)
            {
                buffer[i] = bval;
            }
            Marshal.Copy(buffer, 0, ptr, (int)size);
        }

        /// <summary>
        ///     Lrotls the x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The uint</returns>
        public static uint Lrotl(uint x, int y) => (x << y) | (x >> (32 - y));

        /// <summary>
        ///     Reallocs the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="newSize">The new size</param>
        /// <returns>The void</returns>
        public static IntPtr Realloc(IntPtr a, long newSize)
        {
            if (a == IntPtr.Zero)
            {
                return Malloc(newSize);
            }
        
            IntPtr result = Marshal.ReAllocHGlobal(a, new IntPtr(newSize));
            return result;
        }

        public static IntPtr Realloc(IntPtr a, ulong newSize) => Realloc(a, (long)newSize);

        /// <summary>
        ///     Abses the v
        /// </summary>
        /// <param name="v">The </param>
        /// <returns>The int</returns>
        public static int Abs(int v) => Math.Abs(v);

        /// <summary>
        ///     Pows the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The double</returns>
        public static double Pow(double a, double b) => Math.Pow(a, b);

        /// <summary>
        ///     Ldexps the number
        /// </summary>
        /// <param name="number">The number</param>
        /// <param name="exponent">The exponent</param>
        /// <returns>The double</returns>
        public static double Ldexp(double number, int exponent) => number * Math.Pow(2, exponent);

        /// <summary>
        ///     Strcmps the src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="token">The token</param>
        /// <returns>The result</returns>
       public static int Strcmp(IntPtr src, string token)
       {
           byte[] srcBuffer = new byte[token.Length];
           Marshal.Copy(src, srcBuffer, 0, token.Length);
       
           int result = 0;
       
           for (int i = 0; i < token.Length; ++i)
           {
               if (srcBuffer[i] != (byte)token[i])
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
       public static int Strncmp(IntPtr src, string token, ulong size)
       {
           byte[] srcBuffer = new byte[size];
           Marshal.Copy(src, srcBuffer, 0, (int)size);
       
           int result = 0;
       
           for (int i = 0; i < Math.Min(token.Length, (int)size); ++i)
           {
               if (srcBuffer[i] != (byte)token[i])
               {
                   ++result;
               }
           }
       
           return result;
       }

        public static long Strtol(IntPtr start, out IntPtr end, int radix)
        {
            string input = Marshal.PtrToStringAnsi(start);
            int length = 0;

            Debug.Assert(input != null, nameof(input) + " != null");
            
            while (length < input.Length && Numbers.IndexOf(input[length]) != -1)
            {
                length++;
            }
        
            long result = 0;
            for (int i = 0; i < length; i++)
            {
                long num = Numbers.IndexOf(input[i]);
                long pow = (long)Math.Pow(10, length - i - 1);
                result += num * pow;
            }
        
            end = start + length;
            return result;
        }
    }
}