// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BlendFactor.cs
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

namespace Alis.Core.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The sdl blend factor enum
    /// </summary>
    public enum BlendFactor
    {
        /// <summary>
        ///     The sdl blend factor zero sdl blend factor
        /// </summary>
        SdlBlendFactorZero = 0x1,
        
        /// <summary>
        ///     The sdl blend factor one sdl blend factor
        /// </summary>
        SdlBlendFactorOne = 0x2,
        
        /// <summary>
        ///     The sdl blend factor src color sdl blend factor
        /// </summary>
        SdlBlendFactorSrcColor = 0x3,
        
        /// <summary>
        ///     The sdl blend factor one minus src color sdl blend factor
        /// </summary>
        SdlBlendFactorOneMinusSrcColor = 0x4,
        
        /// <summary>
        ///     The sdl blend factor src alpha sdl blend factor
        /// </summary>
        SdlBlendFactorSrcAlpha = 0x5,
        
        /// <summary>
        ///     The sdl blend factor one minus src alpha sdl blend factor
        /// </summary>
        SdlBlendFactorOneMinusSrcAlpha = 0x6,
        
        /// <summary>
        ///     The sdl blend factor dst color sdl blend factor
        /// </summary>
        SdlBlendFactorDstColor = 0x7,
        
        /// <summary>
        ///     The sdl blend factor one minus dst color sdl blend factor
        /// </summary>
        SdlBlendFactorOneMinusDstColor = 0x8,
        
        /// <summary>
        ///     The sdl blend factor dst alpha sdl blend factor
        /// </summary>
        SdlBlendFactorDstAlpha = 0x9,
        
        /// <summary>
        ///     The sdl blend factor one minus dst alpha sdl blend factor
        /// </summary>
        SdlBlendFactorOneMinusDstAlpha = 0xA
    }
}