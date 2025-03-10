// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoMode.cs
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

using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.GlfwLib.Structs
{
    /// <summary>
    ///     Structure that describes a single video mode.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 24, Pack = 4)]
    public struct VideoMode
    {
        /// <summary>
        ///     The width, in screen coordinates, of the video mode.
        /// </summary>
        [FieldOffset(0)] public readonly int Width;

        /// <summary>
        ///     The height, in screen coordinates, of the video mode.
        /// </summary>
        [FieldOffset(4)] public readonly int Height;

        /// <summary>
        ///     The bit depth of the red channel of the video mode.
        /// </summary>
        [FieldOffset(8)] public readonly int RedBits;

        /// <summary>
        ///     The bit depth of the green channel of the video mode.
        /// </summary>
        [FieldOffset(12)] public readonly int GreenBits;

        /// <summary>
        ///     The bit depth of the blue channel of the video mode.
        /// </summary>
        [FieldOffset(16)] public readonly int BlueBits;

        /// <summary>
        ///     The refresh rate, in Hz, of the video mode.
        /// </summary>
        [FieldOffset(20)] public readonly int RefreshRate;
    }
}