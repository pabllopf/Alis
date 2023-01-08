// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlPixelType.cs
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

namespace Alis.Core.Input.SDL2
{
    /// <summary>
    ///     The sdl pixeltype enum
    /// </summary>
    public enum SdlPixelType
    {
        /// <summary>
        ///     The sdl pixeltype unknown sdl pixeltype
        /// </summary>
        SdlPixeltypeUnknown,

        /// <summary>
        ///     The sdl pixeltype index1 sdl pixeltype
        /// </summary>
        SdlPixeltypeIndex1,

        /// <summary>
        ///     The sdl pixeltype index4 sdl pixeltype
        /// </summary>
        SdlPixeltypeIndex4,

        /// <summary>
        ///     The sdl pixeltype index8 sdl pixeltype
        /// </summary>
        SdlPixeltypeIndex8,

        /// <summary>
        ///     The sdl pixeltype packed8 sdl pixeltype
        /// </summary>
        SdlPixeltypePacked8,

        /// <summary>
        ///     The sdl pixeltype packed16 sdl pixeltype
        /// </summary>
        SdlPixeltypePacked16,

        /// <summary>
        ///     The sdl pixeltype packed32 sdl pixeltype
        /// </summary>
        SdlPixeltypePacked32,

        /// <summary>
        ///     The sdl pixeltype arrayu8 sdl pixeltype
        /// </summary>
        SdlPixeltypeArrayu8,

        /// <summary>
        ///     The sdl pixeltype arrayu16 sdl pixeltype
        /// </summary>
        SdlPixeltypeArrayu16,

        /// <summary>
        ///     The sdl pixeltype arrayu32 sdl pixeltype
        /// </summary>
        SdlPixeltypeArrayu32,

        /// <summary>
        ///     The sdl pixeltype arrayf16 sdl pixeltype
        /// </summary>
        SdlPixeltypeArrayf16,

        /// <summary>
        ///     The sdl pixeltype arrayf32 sdl pixeltype
        /// </summary>
        SdlPixeltypeArrayf32
    }
}