// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArrayOrder.cs
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
    ///     The sdl array order enum
    /// </summary>
    public enum ArrayOrder
    {
    /// <summary>
    ///     No specific array color component order defined
    /// </summary>
    SdlArrayOrderNone,

    /// <summary>
    ///     Array color order is RGB (red, green, blue)
    /// </summary>
    SdlArrayOrderRgb,

    /// <summary>
    ///     Array color order is RGBA (red, green, blue, alpha)
    /// </summary>
    SdlArrayOrderRgba,

    /// <summary>
    ///     Array color order is ARGB (alpha, red, green, blue)
    /// </summary>
    SdlArrayOrderArgb,

    /// <summary>
    ///     Array color order is BGR (blue, green, red)
    /// </summary>
    SdlArrayOrderBgr,

    /// <summary>
    ///     Array color order is BGRA (blue, green, red, alpha)
    /// </summary>
    SdlArrayOrderBgrA,

    /// <summary>
    ///     Array color order is ABGR (alpha, blue, green, red)
    /// </summary>
    SdlArrayOrderAbgR
    }
}