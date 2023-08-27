// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PixelType.cs
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

namespace Alis.Core.Graphic.SDL.Enums
{
    /// <summary>
    ///     The sdl pixel type enum
    /// </summary>
    public enum PixelType
    {
        /// <summary>
        ///     The sdl pixel type unknown sdl pixel type
        /// </summary>
        PixelTypeUnknown,

        /// <summary>
        ///     The sdl pixel type index1 sdl pixel type
        /// </summary>
        PixelTypeIndex1,

        /// <summary>
        ///     The sdl pixel type index4 sdl pixel type
        /// </summary>
        PixelTypeIndex4,

        /// <summary>
        ///     The sdl pixel type index8 sdl pixel type
        /// </summary>
        PixelTypeIndex8,

        /// <summary>
        ///     The sdl pixel type packed8 sdl pixel type
        /// </summary>
        PixelTypePacked8,

        /// <summary>
        ///     The sdl pixel type packed16 sdl pixel type
        /// </summary>
        PixelTypePacked16,

        /// <summary>
        ///     The sdl pixel type packed32 sdl pixel type
        /// </summary>
        PixelTypePacked32,

        /// <summary>
        ///     The sdl pixel type array u8 sdl pixel type
        /// </summary>
        PixelTypeArrayU8,

        /// <summary>
        ///     The sdl pixel type arrayu16 sdl pixel type
        /// </summary>
        PixelTypeArrayU16,

        /// <summary>
        ///     The sdl pixel type arrayu32 sdl pixel type
        /// </summary>
        PixelTypeArrayU32,

        /// <summary>
        ///     The sdl pixel type arrayf16 sdl pixel type
        /// </summary>
        PixelTypeArrayF16,

        /// <summary>
        ///     The sdl pixel type arrayf32 sdl pixel type
        /// </summary>
        PixelTypeArrayF32
    }
}