// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlRWops.cs
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

namespace Alis.Core.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl rw ops
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RwOps
    {
        /// <summary>
        ///     The size
        /// </summary>
        public IntPtr size;

        /// <summary>
        ///     The seek
        /// </summary>
        public IntPtr seek;

        /// <summary>
        ///     The read
        /// </summary>
        public IntPtr read;

        /// <summary>
        ///     The write
        /// </summary>
        public IntPtr write;

        /// <summary>
        ///     The close
        /// </summary>
        public IntPtr close;

        /// <summary>
        ///     The type
        /// </summary>
        public readonly uint type;
    }
}