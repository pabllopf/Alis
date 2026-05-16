// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TypePixel.cs
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

namespace Alis.Extension.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The sdl pixel type enum
    /// </summary>
    public enum TypePixel
    {
    /// <summary>
    ///     Unknown or unsupported pixel type
    /// </summary>
    TypeUnknown,

    /// <summary>
    ///     Indexed pixel type using 1-bit palette indices
    /// </summary>
    TypeIndex1,

    /// <summary>
    ///     Indexed pixel type using 4-bit palette indices
    /// </summary>
    TypeIndex4,

    /// <summary>
    ///     Indexed pixel type using 8-bit palette indices
    /// </summary>
    TypeIndex8,

    /// <summary>
    ///     Packed pixel type with 8 bits per pixel
    /// </summary>
    TypePacked8,

    /// <summary>
    ///     Packed pixel type with 16 bits per pixel
    /// </summary>
    TypePacked16,

    /// <summary>
    ///     Packed pixel type with 32 bits per pixel
    /// </summary>
    TypePacked32,

    /// <summary>
    ///     Array pixel type with 8-bit unsigned integer components
    /// </summary>
    TypeArrayU8,

    /// <summary>
    ///     Array pixel type with 16-bit unsigned integer components
    /// </summary>
    TypeArrayU16,

    /// <summary>
    ///     Array pixel type with 32-bit unsigned integer components
    /// </summary>
    TypeArrayU32,

    /// <summary>
    ///     Array pixel type with 16-bit floating-point components
    /// </summary>
    TypeArrayF16,

    /// <summary>
    ///     Array pixel type with 32-bit floating-point components
    /// </summary>
    TypeArrayF32
    }
}