// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlPixelFormat.cs
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

namespace Alis.Core.Input.SDL2
{
    /// <summary>
    ///     The sdl pixelformat
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlPixelFormat
    {
        /// <summary>
        ///     The format
        /// </summary>
        public uint format;

        /// <summary>
        ///     The palette
        /// </summary>
        public IntPtr palette; // SDL_Palette*

        /// <summary>
        ///     The bits per pixel
        /// </summary>
        public byte BitsPerPixel;

        /// <summary>
        ///     The bytes per pixel
        /// </summary>
        public byte BytesPerPixel;

        /// <summary>
        ///     The rmask
        /// </summary>
        public uint Rmask;

        /// <summary>
        ///     The gmask
        /// </summary>
        public uint Gmask;

        /// <summary>
        ///     The bmask
        /// </summary>
        public uint Bmask;

        /// <summary>
        ///     The amask
        /// </summary>
        public uint Amask;

        /// <summary>
        ///     The rloss
        /// </summary>
        public byte Rloss;

        /// <summary>
        ///     The gloss
        /// </summary>
        public byte Gloss;

        /// <summary>
        ///     The bloss
        /// </summary>
        public byte Bloss;

        /// <summary>
        ///     The aloss
        /// </summary>
        public byte Aloss;

        /// <summary>
        ///     The rshift
        /// </summary>
        public byte Rshift;

        /// <summary>
        ///     The gshift
        /// </summary>
        public byte Gshift;

        /// <summary>
        ///     The bshift
        /// </summary>
        public byte Bshift;

        /// <summary>
        ///     The ashift
        /// </summary>
        public byte Ashift;

        /// <summary>
        ///     The refcount
        /// </summary>
        public int refcount;

        /// <summary>
        ///     The next
        /// </summary>
        public IntPtr next; // SDL_PixelFormat*
    }
}