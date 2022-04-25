// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Clipboard.cs
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
using System.Security;
using System.Text;
using Alis.Core.Graphics2D.Systems;

namespace Alis.Core.Graphics2D.Windows
{
    /// <summary>
    ///     The clipboard class
    /// </summary>
    public class Clipboard
    {
        /// <summary>
        ///     The contents of the Clipboard as a UTF-32 string
        /// </summary>
        public static string Contents
        {
            get
            {
                IntPtr source = sfClipboard_getUnicodeString();

                uint length = 0;
                unsafe
                {
                    for (uint* ptr = (uint*) source.ToPointer(); *ptr != 0; ++ptr)
                    {
                        length++;
                    }
                }

                byte[] sourceBytes = new byte[length * 4];
                Marshal.Copy(source, sourceBytes, 0, sourceBytes.Length);

                return Encoding.UTF32.GetString(sourceBytes);
            }
            set
            {
                byte[] utf32 = Encoding.UTF32.GetBytes(value + '\0');

                unsafe
                {
                    fixed (byte* ptr = utf32)
                    {
                        sfClipboard_setUnicodeString((IntPtr) ptr);
                    }
                }
            }
        }

        /// <summary>
        ///     Sfs the clipboard get unicode string
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfClipboard_getUnicodeString();

        /// <summary>
        ///     Sfs the clipboard set unicode string using the specified ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private static extern void sfClipboard_setUnicodeString(IntPtr ptr);
    }
}