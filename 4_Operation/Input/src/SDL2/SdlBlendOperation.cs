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

namespace Alis.Core.Input.SDL2
{
    /// <summary>
    ///     The sdl blendoperation enum
    /// </summary>
    public enum SdlBlendOperation
    {
        /// <summary>
        ///     The sdl blendoperation add sdl blendoperation
        /// </summary>
        SdlBlendoperationAdd = 0x1,

        /// <summary>
        ///     The sdl blendoperation subtract sdl blendoperation
        /// </summary>
        SdlBlendoperationSubtract = 0x2,

        /// <summary>
        ///     The sdl blendoperation rev subtract sdl blendoperation
        /// </summary>
        SdlBlendoperationRevSubtract = 0x3,

        /// <summary>
        ///     The sdl blendoperation minimum sdl blendoperation
        /// </summary>
        SdlBlendoperationMinimum = 0x4,

        /// <summary>
        ///     The sdl blendoperation maximum sdl blendoperation
        /// </summary>
        SdlBlendoperationMaximum = 0x5
    }
}