// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   MarshalTk.cs
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
using System.Runtime.InteropServices;
using System.Text;

namespace Alis.Core.Audio.Core.Native
{
    /// <summary>
    ///     Contains extra marshalling utilities that aren't available in the normal Marshal class.
    /// </summary>
    public static class MarshalTk
    {
        /// <summary>
        ///     Marshals a pointer to a null-terminated byte array to a new <c>System.String</c>.
        ///     This method supports OpenTK and is not intended to be called by user code.
        /// </summary>
        /// <param name="ptr">A pointer to a null-terminated byte array.</param>
        /// <returns>
        ///     A <c>System.String</c> with the data from <paramref name="ptr" />.
        /// </returns>
        public static string MarshalPtrToString(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                throw new ArgumentException("ptr");
            }

            unsafe
            {
                sbyte* str = (sbyte*) ptr;
                int len = 0;
                while (*str != 0)
                {
                    ++len;
                    ++str;
                }

                return new string((sbyte*) ptr, 0, len, Encoding.UTF8);
            }
        }

        /// <summary>
        ///     Marshal a <c>System.String</c> to unmanaged memory.
        ///     The resulting string is encoded in UTF8 and must be freed
        ///     with <c>FreeStringPtr</c>.
        /// </summary>
        /// <param name="str">The <c>System.String</c> to marshal.</param>
        /// <returns>
        ///     An unmanaged pointer containing the marshaled string.
        ///     This pointer must be freed with <c>FreeStringPtr</c>.
        /// </returns>
        public static IntPtr MarshalStringToPtr(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return IntPtr.Zero;
            }

            // Allocate a buffer big enough to hold the marshaled string.
            // GetMaxByteCount() appears to allocate space for the final NUL
            // character, but allocate an extra one just in case (who knows
            // what old Mono version would do here.)
            int maxCount = Encoding.UTF8.GetMaxByteCount(str.Length) + 1;
            IntPtr ptr = Marshal.AllocHGlobal(maxCount);
            if (ptr == IntPtr.Zero)
            {
                throw new OutOfMemoryException();
            }

            // Pin the managed string and convert it to UTF8 using
            // the pointer overload of System.Encoding.UTF8.GetBytes().
            unsafe
            {
                fixed (char* pstr = str)
                {
                    int actualCount = Encoding.UTF8.GetBytes(pstr, str.Length, (byte*) ptr, maxCount);
                    Marshal.WriteByte(ptr, actualCount, 0); // Append '\0' at the end of the string
                    return ptr;
                }
            }
        }

        /// <summary>
        ///     Frees a marshaled string that allocated by <c>MarshalStringToPtr</c>.
        /// </summary>
        /// <param name="ptr">An unmanaged pointer allocated with <c>MarshalStringToPtr</c>.</param>
        public static void FreeStringPtr(IntPtr ptr)
        {
            Marshal.FreeHGlobal(ptr);
        }

        /// <summary>
        ///     Marshals a <c>System.String</c> array to unmanaged memory by calling
        ///     Marshal.AllocHGlobal for each element.
        /// </summary>
        /// <returns>An unmanaged pointer to an array of null-terminated strings.</returns>
        /// <param name="strArray">The string array to marshal.</param>
        public static IntPtr MarshalStringArrayToPtr(string[] strArray)
        {
            IntPtr ptr = IntPtr.Zero;
            if (strArray != null && strArray.Length != 0)
            {
                ptr = Marshal.AllocHGlobal(strArray.Length * IntPtr.Size);
                if (ptr == IntPtr.Zero)
                {
                    throw new OutOfMemoryException();
                }

                int i = 0;
                try
                {
                    for (i = 0; i < strArray.Length; i++)
                    {
                        IntPtr str = MarshalStringToPtr(strArray[i]);
                        Marshal.WriteIntPtr(ptr, i * IntPtr.Size, str);
                    }
                }
                catch (OutOfMemoryException)
                {
                    for (i = i - 1; i >= 0; --i)
                    {
                        Marshal.FreeHGlobal(Marshal.ReadIntPtr(ptr, i * IntPtr.Size));
                    }

                    Marshal.FreeHGlobal(ptr);

                    throw;
                }
            }

            return ptr;
        }

        /// <summary>
        ///     Frees a marshaled string that allocated by <c>MarshalStringArrayToPtr</c>.
        /// </summary>
        /// <param name="ptr">An unmanaged pointer allocated with <c>MarshalStringArrayToPtr</c>.</param>
        /// <param name="length">The length of the string array.</param>
        public static void FreeStringArrayPtr(IntPtr ptr, int length)
        {
            for (int i = 0; i < length; i++)
            {
                Marshal.FreeHGlobal(Marshal.ReadIntPtr(ptr, i * IntPtr.Size));
            }

            Marshal.FreeHGlobal(ptr);
        }
    }
}