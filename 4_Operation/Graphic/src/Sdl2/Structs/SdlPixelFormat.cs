// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: SdlPixelFormat.cs
// 
//  Author: Pablo Perdomo Falcón
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
    ///     The sdl pixel format
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlPixelFormat
    {
        /// <summary>
        ///     The format
        /// </summary>
        public readonly uint format;

        /// <summary>
        ///     The palette
        /// </summary>
        public IntPtr palette;

        /// <summary>
        ///     The bits per pixel
        /// </summary>
        public readonly byte BitsPerPixel;

        /// <summary>
        ///     The bytes per pixel
        /// </summary>
        public readonly byte BytesPerPixel;

        /// <summary>
        ///     The r mask
        /// </summary>
        public readonly uint RMask;

        /// <summary>
        ///     The g mask
        /// </summary>
        public readonly uint GMask;

        /// <summary>
        ///     The b mask
        /// </summary>
        public readonly uint BMask;

        /// <summary>
        ///     The a mask
        /// </summary>
        public readonly uint AMask;

        /// <summary>
        ///     The r loss
        /// </summary>
        public readonly byte RLoss;

        /// <summary>
        ///     The g loss
        /// </summary>
        public readonly byte Gloss;

        /// <summary>
        ///     The b loss
        /// </summary>
        public readonly byte BLoss;

        /// <summary>
        ///     The a loss
        /// </summary>
        public readonly byte ALoss;

        /// <summary>
        ///     The r shift
        /// </summary>
        public readonly byte RShift;

        /// <summary>
        ///     The g shift
        /// </summary>
        public readonly byte GShift;

        /// <summary>
        ///     The b shift
        /// </summary>
        public readonly byte BShift;

        /// <summary>
        ///     The a shift
        /// </summary>
        public readonly byte AShift;

        /// <summary>
        ///     The ref count
        /// </summary>
        public readonly int refCount;

        /// <summary>
        ///     The next
        /// </summary>
        public IntPtr next;
    }
}