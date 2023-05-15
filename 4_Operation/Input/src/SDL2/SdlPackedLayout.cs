// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlPackedLayout.cs
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
    ///     The sdl packedlayout enum
    /// </summary>
    public enum SdlPackedLayout
    {
        /// <summary>
        ///     The sdl packedlayout none sdl packedlayout
        /// </summary>
        SdlPackedlayoutNone,

        /// <summary>
        ///     The sdl packedlayout 332 sdl packedlayout
        /// </summary>
        SdlPackedlayout332,

        /// <summary>
        ///     The sdl packedlayout 4444 sdl packedlayout
        /// </summary>
        SdlPackedlayout4444,

        /// <summary>
        ///     The sdl packedlayout 1555 sdl packedlayout
        /// </summary>
        SdlPackedlayout1555,

        /// <summary>
        ///     The sdl packedlayout 5551 sdl packedlayout
        /// </summary>
        SdlPackedlayout5551,

        /// <summary>
        ///     The sdl packedlayout 565 sdl packedlayout
        /// </summary>
        SdlPackedlayout565,

        /// <summary>
        ///     The sdl packedlayout 8888 sdl packedlayout
        /// </summary>
        SdlPackedlayout8888,

        /// <summary>
        ///     The sdl packedlayout 2101010 sdl packedlayout
        /// </summary>
        SdlPackedlayout2101010,

        /// <summary>
        ///     The sdl packedlayout 1010102 sdl packedlayout
        /// </summary>
        SdlPackedlayout1010102
    }
}