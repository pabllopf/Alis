// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PackedOrder.cs
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
    ///     The sdl packed order enum
    /// </summary>
    public enum PackedOrder
    {
    /// <summary>
    ///     No specific packed pixel component order defined
    /// </summary>
    PackedOrderNone,

    /// <summary>
    ///     Packed pixel order: X (unused), Red, Green, Blue
    /// </summary>
    PackedOrderXRgb,

    /// <summary>
    ///     Packed pixel order: Red, Green, Blue, X (unused)
    /// </summary>
    PackedOrderRGbx,

    /// <summary>
    ///     Packed pixel order: Alpha, Red, Green, Blue
    /// </summary>
    PackedOrderARgb,

    /// <summary>
    ///     Packed pixel order: Red, Green, Blue, Alpha
    /// </summary>
    PackedOrderRGba,

    /// <summary>
    ///     Packed pixel order: X (unused), Blue, Green, Red
    /// </summary>
    PackedOrderXBgr,

    /// <summary>
    ///     Packed pixel order: Blue, Green, Red, X (unused)
    /// </summary>
    PackedOrderBGrx,

    /// <summary>
    ///     Packed pixel order: Alpha, Blue, Green, Red
    /// </summary>
    PackedOrderABgr,

    /// <summary>
    ///     Packed pixel order: Blue, Green, Red, Alpha
    /// </summary>
    PackedOrderBGra
    }
}