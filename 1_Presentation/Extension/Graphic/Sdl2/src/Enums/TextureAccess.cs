// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TextureAccess.cs
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

namespace Alis.Extension.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The sdl texture access enum
    /// </summary>
    [Flags]
    public enum TextureAccess
    {
        /// <summary>
        ///     The sdl texture access static sdl texture access
        /// </summary>
        None = 0,

        /// <summary>
        ///     The sdl texture access streaming sdl texture access
        /// </summary>
        SdlTextureAccessStreaming = 1,

        /// <summary>
        ///     The sdl texture access target sdl texture access
        /// </summary>
        SdlTextureAccessTarget = 2
    }
}