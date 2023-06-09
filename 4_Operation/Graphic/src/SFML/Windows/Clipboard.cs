// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Clipboard.cs
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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Aspect.Base.Attributes;
using Alis.Core.Aspect.Base.Settings;

namespace Alis.Core.Graphic.SFML.Windows
{
    /// <summary>
    ///     The clipboard class
    /// </summary>
    public class Clipboard
    {
        /// <summary>
        ///     The contents of the Clipboard as a UTF-32 string.
        /// </summary>
        public static string Contents
        {
            get
            {
                IntPtr source = sfClipboard_getUnicodeString();

                List<byte> sourceBytes = new List<byte>();

                byte currentByte;
                int offset = 0;

                do
                {
                    currentByte = Marshal.ReadByte(source, offset);
                    sourceBytes.Add(currentByte);
                    offset += 4;
                }
                while (currentByte != 0);

                return Encoding.UTF32.GetString(sourceBytes.ToArray());
            }
            set
            {
                byte[] utf32 = Encoding.UTF32.GetBytes(value + '\0');
                IntPtr ptr = Marshal.AllocCoTaskMem(utf32.Length);
                Marshal.Copy(utf32, 0, ptr, utf32.Length);
                sfClipboard_setUnicodeString(ptr);
                Marshal.FreeCoTaskMem(ptr);
            }
        }


        /// <summary>
        ///     Sfs the clipboard get unicode string
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfClipboard_getUnicodeString();

        /// <summary>
        ///     Sfs the clipboard set unicode string using the specified ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfClipboard_setUnicodeString(IntPtr ptr);
    }
}