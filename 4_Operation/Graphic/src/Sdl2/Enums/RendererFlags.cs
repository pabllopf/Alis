// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RendererFlags.cs
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

using System;

namespace Alis.Core.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The sdl renderer flags enum
    /// </summary>
    [Flags]
    public enum RendererFlags : uint
    {
        /// <summary>
        ///     The sdl renderer software sdl renderer flags
        /// </summary>
        SdlRendererSoftware = 0x00000001,

        /// <summary>
        ///     The sdl renderer accelerated sdl renderer flags
        /// </summary>
        SdlRendererAccelerated = 0x00000002,

        /// <summary>
        ///     The sdl renderer present vsync sdl renderer flags
        /// </summary>
        SdlRendererPresentVSync = 0x00000004,

        /// <summary>
        ///     The sdl renderer target texture sdl renderer flags
        /// </summary>
        SdlRendererTargetTexture = 0x00000008
    }
}