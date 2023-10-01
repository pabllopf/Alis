// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlBlendMode.cs
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

namespace Alis.Core.Graphic.SDL.Enums
{
    /// <summary>
    ///     The sdl blend mode enum
    /// </summary>
    [Flags]
    public enum SdlBlendMode
    {
        /// <summary>
        ///     The sdl blend factor none sdl blend factor
        /// </summary>
        None = 0x00000000,

        /// <summary>
        ///     The sdl blend factor blend sdl blend factor
        /// </summary>
        SdlBlendModeBlend = 0x00000001,

        /// <summary>
        ///     The sdl blend factor add sdl blend factor
        /// </summary>
        SdlBlendModeAdd = 0x00000002,

        /// <summary>
        ///     The sdl blend factor mod sdl blend factor
        /// </summary>
        SdlBlendModeMod = 0x00000004,

        /// <summary>
        ///     The sdl blend factor mul sdl blend factor
        /// </summary>
        SdlBlendModeMul = 0x00000008,

        /// <summary>
        ///     The sdl blend factor invalid sdl blend factor
        /// </summary>
        SdlBlendModeInvalid = 0x7FFFFFFF
    }
}