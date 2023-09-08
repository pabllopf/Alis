// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlTextureModulate.cs
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

namespace Alis.App.Engine.SDL.Enums
{
    /// <summary>
    ///     The sdl texturemodulate enum
    /// </summary>
    [Flags]
    public enum SdlTextureModulate
    {
        /// <summary>
        ///     The sdl texturemodulate none sdl texturemodulate
        /// </summary>
        None = 0x00000000,

        /// <summary>
        ///     The sdl texturemodulate horizontal sdl texturemodulate
        /// </summary>
        SdlTexturemodulateHorizontal = 0x00000001,

        /// <summary>
        ///     The sdl texturemodulate vertical sdl texturemodulate
        /// </summary>
        SdlTexturemodulateVertical = 0x00000002
    }
}