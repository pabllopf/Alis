// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlArrayOrder.cs
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

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl arrayorder enum
    /// </summary>
    public enum SdlArrayOrder
    {
        /// <summary>
        ///     The sdl arrayorder none sdl arrayorder
        /// </summary>
        SdlArrayorderNone,

        /// <summary>
        ///     The sdl arrayorder rgb sdl arrayorder
        /// </summary>
        SdlArrayorderRgb,

        /// <summary>
        ///     The sdl arrayorder rgba sdl arrayorder
        /// </summary>
        SdlArrayorderRgba,

        /// <summary>
        ///     The sdl arrayorder argb sdl arrayorder
        /// </summary>
        SdlArrayorderArgb,

        /// <summary>
        ///     The sdl arrayorder bgr sdl arrayorder
        /// </summary>
        SdlArrayorderBgr,

        /// <summary>
        ///     The sdl arrayorder bgra sdl arrayorder
        /// </summary>
        SdlArrayorderBgra,

        /// <summary>
        ///     The sdl arrayorder abgr sdl arrayorder
        /// </summary>
        SdlArrayorderAbgr
    }
}