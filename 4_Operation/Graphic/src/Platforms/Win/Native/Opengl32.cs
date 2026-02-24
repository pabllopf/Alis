// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Opengl32.cs
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

#if winx64 || winx86 || winarm64 || winarm || win
using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Platforms.Win.Native
{
    /// <summary>
    /// </summary>
    internal static class Opengl32
    {
        /// <summary>
        /// </summary>
        private const string DllName = "opengl32.dll";

        /// <summary>
        /// </summary>
        /// <param name="hdc"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "wglCreateContext")]
        [ExcludeFromCodeCoverage]
        public static extern IntPtr wglCreateContext(IntPtr hdc);

        /// <summary>
        /// </summary>
        /// <param name="hdc"></param>
        /// <param name="hglrc"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "wglMakeCurrent")]
        [ExcludeFromCodeCoverage]
        public static extern bool wglMakeCurrent(IntPtr hdc, IntPtr hglrc);

        /// <summary>
        /// </summary>
        /// <param name="hglrc"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "wglDeleteContext")]
        [ExcludeFromCodeCoverage]
        public static extern bool wglDeleteContext(IntPtr hglrc);

        /// <summary>
        /// </summary>
        /// <param name="lpszProc"></param>
        /// <returns></returns>
        [DllImport("opengl32.dll", SetLastError = true, EntryPoint = "wglGetProcAddress")]
        [ExcludeFromCodeCoverage]
        public static extern IntPtr wglGetProcAddress(string lpszProc);
    }
}

#endif