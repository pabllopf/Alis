// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlPackedOrder.cs
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
    ///     The sdl packedorder enum
    /// </summary>
    public enum SdlPackedOrder
    {
        /// <summary>
        ///     The sdl packedorder none sdl packedorder
        /// </summary>
        SdlPackedorderNone,

        /// <summary>
        ///     The sdl packedorder xrgb sdl packedorder
        /// </summary>
        SdlPackedorderXrgb,

        /// <summary>
        ///     The sdl packedorder rgbx sdl packedorder
        /// </summary>
        SdlPackedorderRgbx,

        /// <summary>
        ///     The sdl packedorder argb sdl packedorder
        /// </summary>
        SdlPackedorderArgb,

        /// <summary>
        ///     The sdl packedorder rgba sdl packedorder
        /// </summary>
        SdlPackedorderRgba,

        /// <summary>
        ///     The sdl packedorder xbgr sdl packedorder
        /// </summary>
        SdlPackedorderXbgr,

        /// <summary>
        ///     The sdl packedorder bgrx sdl packedorder
        /// </summary>
        SdlPackedorderBgrx,

        /// <summary>
        ///     The sdl packedorder abgr sdl packedorder
        /// </summary>
        SdlPackedorderAbgr,

        /// <summary>
        ///     The sdl packedorder bgra sdl packedorder
        /// </summary>
        SdlPackedorderBgra
    }
}