// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Gdi32.cs
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

#if WIN
using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Platforms.Win.Native
{
    /// <summary>
    /// 
    /// </summary>
    internal static class Gdi32
    {
        /// <summary>
        /// 
        /// </summary>
        private const string DllName = "gdi32.dll";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hdc"></param>
        /// <param name="ppfd"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "ChoosePixelFormat")]
        public static extern int ChoosePixelFormat(IntPtr hdc, ref Pixelformatdescriptor ppfd);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hdc"></param>
        /// <param name="format"></param>
        /// <param name="ppfd"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "SetPixelFormat")]
        public static extern bool SetPixelFormat(IntPtr hdc, int format, ref Pixelformatdescriptor ppfd);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hdc"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "SwapBuffers")]
        public static extern bool SwapBuffers(IntPtr hdc);
    }
}

#endif