// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TextureModulate.cs
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
    ///     The sdl texture modulate enum
    /// </summary>
    [Flags]
    public enum TextureModulate
    {
        /// <summary>
        ///     The sdl texture modulate none sdl texture modulate
        /// </summary>
        None = 0x00000000,
        
        /// <summary>
        ///     The sdl texture modulate horizontal sdl texture modulate
        /// </summary>
        SdlTextureModulateHorizontal = 0x00000001,
        
        /// <summary>
        ///     The sdl texture modulate vertical sdl texture modulate
        /// </summary>
        SdlTextureModulateVertical = 0x00000002
    }
}