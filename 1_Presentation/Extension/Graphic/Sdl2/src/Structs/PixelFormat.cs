// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PixelFormat.cs
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

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     Represents an SDL pixel format, describing the pixel layout, bit masks, and shifts for a surface or texture.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PixelFormat
    {
        /// <summary>
        ///     The pixel format identifier (e.g. SDL_PIXELFORMAT_RGB888).
        /// </summary>
        public readonly uint format;

        /// <summary>
        ///     A pointer to an SDL_Palette structure, used for indexed color formats.
        /// </summary>
        public IntPtr Palette { get; set; }

        /// <summary>
        ///     The number of significant bits per pixel.
        /// </summary>
        public readonly byte BitsPerPixel;

        /// <summary>
        ///     The number of bytes per pixel (computed from BitsPerPixel).
        /// </summary>
        public readonly byte BytesPerPixel;

        /// <summary>
        ///     The bit mask for the red channel.
        /// </summary>
        public readonly uint RMask;

        /// <summary>
        ///     The bit mask for the green channel.
        /// </summary>
        public readonly uint GMask;

        /// <summary>
        ///     The bit mask for the blue channel.
        /// </summary>
        public readonly uint BMask;

        /// <summary>
        ///     The bit mask for the alpha channel.
        /// </summary>
        public readonly uint AMask;

        /// <summary>
        ///     The number of bits lost for the red channel relative to the full byte.
        /// </summary>
        public readonly byte RLoss;

        /// <summary>
        ///     The number of bits lost for the green channel relative to the full byte.
        /// </summary>
        public readonly byte Gloss;

        /// <summary>
        ///     The number of bits lost for the blue channel relative to the full byte.
        /// </summary>
        public readonly byte BLoss;

        /// <summary>
        ///     The number of bits lost for the alpha channel relative to the full byte.
        /// </summary>
        public readonly byte ALoss;

        /// <summary>
        ///     The bit shift value for the red channel.
        /// </summary>
        public readonly byte RShift;

        /// <summary>
        ///     The bit shift value for the green channel.
        /// </summary>
        public readonly byte GShift;

        /// <summary>
        ///     The bit shift value for the blue channel.
        /// </summary>
        public readonly byte BShift;

        /// <summary>
        ///     The bit shift value for the alpha channel.
        /// </summary>
        public readonly byte AShift;

        /// <summary>
        ///     The reference count for the pixel format (used internally by SDL).
        /// </summary>
        public readonly int refCount;

        /// <summary>
        ///     A pointer to the next pixel format in the linked list (used internally by SDL).
        /// </summary>
        public IntPtr Next { get; set; }
    }
}