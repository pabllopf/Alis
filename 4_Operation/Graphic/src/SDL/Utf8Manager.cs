// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Utf8Manager.cs
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
using System.Text;
using Alis.Core.Aspect.Memory;
using Alis.Core.Aspect.Memory.Attributes;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    /// The utf manager class
    /// </summary>
    public static class Utf8Manager
    {
        /// <summary>
        ///     Utf the 8 to managed using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="freePtr">The free ptr</param>
        /// <returns>The result</returns>
        [return: NotNull]
        public static string Utf8ToManaged(IntPtr s, bool freePtr = false)
        {
            if (s == IntPtr.Zero)
            {
                return null;
            }

            int len = 0;
            while (Marshal.ReadByte(s, len) != 0)
            {
                len++;
            }

            if (len == 0)
            {
                return string.Empty;
            }

            byte[] bytes = new byte[len];
            Marshal.Copy(s, bytes, 0, len);
            string result = Encoding.UTF8.GetString(bytes);

            if (freePtr)
            {
                Sdl.SDL_free(s);
            }

            return result;
        }

        /// <summary>
        ///     Utf the 8 encode heap using the specified str
        /// </summary>
        /// <param name="str">The str</param>
        /// <returns>The buffer</returns>
        [return: NotNull]
        internal static byte[] Utf8EncodeHeap(string str)
        {
            if (str == null)
            {
                return null;
            }

            int bufferSize = Encoding.UTF8.GetByteCount(str) + 1;
            byte[] buffer = new byte[bufferSize];
            Encoding.UTF8.GetBytes(str, 0, str.Length, buffer, 0);
            buffer[bufferSize - 1] = 0; // Null-terminate the string

            return buffer;
        }

        /// <summary>
        ///     Utf the 8 encode using the specified str
        /// </summary>
        /// <param name="str">The str</param>
        /// <param name="buffer">The buffer</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <returns>The buffer</returns>
        [return: NotNull]
        internal static byte[] Utf8Encode([NotNull] string str, [NotNull] byte[] buffer, [NotNull] int bufferSize)
        {
            Encoding.UTF8.GetBytes(str.Validate(), 0, str.Validate().Length, buffer, 0);
            buffer[str.Length] = 0;
            return buffer;
        }

        /// <summary>
        ///     Utf the 8 size using the specified str
        /// </summary>
        /// <param name="str">The str</param>
        /// <returns>The int</returns>
        [return: NotNull]
        internal static int Utf8Size([NotNull] string str) => str.Validate().Length * 4 + 1;
    }
}