// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   MarshalUtility.cs
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

namespace Alis.Core.Audio2D.Core.Utility
{
    /// <summary>
    ///     The marshal utility class
    /// </summary>
    internal static class MarshalUtility
    {
        /// <summary>
        ///     Strings the to co task mem utf 8 using the specified str
        /// </summary>
        /// <param name="str">The str</param>
        /// <returns>The int ptr</returns>
        public static IntPtr StringToCoTaskMemUTF8(string str)
        {
            return Marshal.StringToCoTaskMemUTF8(str);
        }

        /// <summary>
        ///     Converts a null-terminated UTF-8 string to a <see cref="string" />.
        /// </summary>
        /// <param name="ptr">The pointer to the null-terminated UTF-8 data.</param>
        /// <returns>The string.</returns>
        public static unsafe string PtrToStringUTF8(byte* ptr)
        {
            return Marshal.PtrToStringUTF8((IntPtr) ptr);
        }
    }
}