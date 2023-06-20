// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlBlendOperation.cs
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

namespace Alis.Core.Graphic.SDL.Enums
{
    /// <summary>
    ///     The sdl blend operation enum
    /// </summary>
    public enum SdlBlendOperation
    {
        /// <summary>
        ///     The sdl blend operation add sdl blend operation
        /// </summary>
        SdlBlendOperationAdd = 0x1,

        /// <summary>
        ///     The sdl blend operation subtract sdl blend operation
        /// </summary>
        SdlBlendOperationSubtract = 0x2,

        /// <summary>
        ///     The sdl blend operation rev subtract sdl blend operation
        /// </summary>
        SdlBlendOperationRevSubtract = 0x3,

        /// <summary>
        ///     The sdl blend operation minimum sdl blend operation
        /// </summary>
        SdlBlendOperationMinimum = 0x4,

        /// <summary>
        ///     The sdl blend operation maximum sdl blend operation
        /// </summary>
        SdlBlendOperationMaximum = 0x5
    }
}