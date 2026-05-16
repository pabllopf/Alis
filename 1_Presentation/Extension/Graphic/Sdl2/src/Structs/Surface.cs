// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Surface.cs
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
using Alis.Core.Aspect.Math.Shapes.Rectangle;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     Represents an SDL software surface, a buffer of pixels in memory with a defined format and dimensions.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Surface
    {
        /// <summary>
        ///     The surface flags (e.g. SDL_SWSURFACE, SDL_PREALLOC, SDL_RLEACCEL).
        /// </summary>
        public readonly uint flags;

        /// <summary>
        ///     A pointer to the SDL_PixelFormat structure describing the surface pixel layout.
        /// </summary>
        public IntPtr Format { get; set; }

        /// <summary>
        ///     The width of the surface in pixels.
        /// </summary>
        public readonly int w;

        /// <summary>
        ///     The height of the surface in pixels.
        /// </summary>
        public readonly int h;

        /// <summary>
        ///     The length of a row of pixels in bytes (width * bytes_per_pixel + padding).
        /// </summary>
        public readonly int pitch;

        /// <summary>
        ///     A pointer to the raw pixel data buffer.
        /// </summary>
        public IntPtr Pixels { get; set; }

        /// <summary>
        ///     User-defined data pointer associated with the surface.
        /// </summary>
        public IntPtr Userdata { get; set; }

        /// <summary>
        ///     Indicates whether the surface is currently locked (non-zero if locked).
        /// </summary>
        public readonly int locked;

        /// <summary>
        ///     A pointer to the internal list of blit map entries for optimized blitting.
        /// </summary>
        public IntPtr ListBlitMap { get; set; }

        /// <summary>
        ///     The clipping rectangle applied to rendering operations on this surface.
        /// </summary>
        public RectangleI ClipRect { get; set; }

        /// <summary>
        ///     A pointer to the SDL_BlitMap structure used for hardware-accelerated blitting.
        /// </summary>
        public IntPtr Map { get; set; }

        /// <summary>
        ///     The reference count for the surface (used internally by SDL).
        /// </summary>
        public readonly int refCount;
    }
}