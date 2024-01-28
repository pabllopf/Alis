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

namespace Alis.Core.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The sdl packed order enum
    /// </summary>
    public enum PackedOrder
    {
        /// <summary>
        ///     The sdl packed order none sdl packed order
        /// </summary>
        PackedOrderNone,

        /// <summary>
        ///     The sdl packed order x rgb sdl packed order
        /// </summary>
        PackedOrderXRgb,

        /// <summary>
        ///     The sdl packed order r gbx sdl packed order
        /// </summary>
        PackedOrderRGbx,

        /// <summary>
        ///     The sdl packed order argb sdl packed order
        /// </summary>
        PackedOrderARgb,

        /// <summary>
        ///     The sdl packed order rgba sdl packed order
        /// </summary>
        PackedOrderRGba,

        /// <summary>
        ///     The sdl packed order x bgr sdl packed order
        /// </summary>
        PackedOrderXBgr,

        /// <summary>
        ///     The sdl packed order b grx sdl packed order
        /// </summary>
        PackedOrderBGrx,

        /// <summary>
        ///     The sdl packed order a bgr sdl packed order
        /// </summary>
        PackedOrderABgr,

        /// <summary>
        ///     The sdl packed order b gra sdl packed order
        /// </summary>
        PackedOrderBGra
    }
}