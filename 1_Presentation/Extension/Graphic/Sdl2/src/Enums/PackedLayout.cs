// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PackedLayout.cs
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
    ///     The sdl packed layout enum
    /// </summary>
    public enum PackedLayout
    {
    /// <summary>
    ///     No specific packed pixel layout defined
    /// </summary>
    PackedLayoutNone,

    /// <summary>
    ///     Packed pixel layout with 3 bits red, 3 bits green, 2 bits blue
    /// </summary>
    PackedLayout332,

    /// <summary>
    ///     Packed pixel layout with 4 bits per channel (4x4 = 16-bit)
    /// </summary>
    PackedLayout4444,

    /// <summary>
    ///     Packed pixel layout with 1 bit alpha, 5 bits per RGB channel
    /// </summary>
    PackedLayout1555,

    /// <summary>
    ///     Packed pixel layout with 5 bits per RGB channel, 1 bit alpha
    /// </summary>
    PackedLayout5551,

    /// <summary>
    ///     Packed pixel layout with 5 bits red, 6 bits green, 5 bits blue
    /// </summary>
    PackedLayout565,

    /// <summary>
    ///     Packed pixel layout with 8 bits per channel (4x8 = 32-bit)
    /// </summary>
    PackedLayout8888,

    /// <summary>
    ///     Packed pixel layout with 2 bits red, 10 bits per GBA channel
    /// </summary>
    PackedLayout2101010,

    /// <summary>
    ///     Packed pixel layout with 10 bits per RGB channel, 2 bits alpha
    /// </summary>
    PackedLayout1010102
    }
}