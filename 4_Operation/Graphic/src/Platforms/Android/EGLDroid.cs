// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EGLDroid.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Platforms.Android
{
    /// <summary>
    ///     The egl droid class
    /// </summary>
    public static class EglDroid
    {
        /// <summary>
        ///     Retrieves the address of the specified EGL or GLES function from the native library.
        /// </summary>
        /// <param name="proc">The name of the function to retrieve the address for.</param>
        /// <returns>A pointer to the function, or <see cref="IntPtr.Zero"/> if the function was not found.</returns>
        [DllImport("libEGL", EntryPoint = "eglGetProcAddress", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl), DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        public static extern IntPtr GetProcAddress(string proc);
    }
}