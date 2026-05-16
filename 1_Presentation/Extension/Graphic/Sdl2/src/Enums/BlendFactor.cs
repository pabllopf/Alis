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

namespace Alis.Extension.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The sdl blend factor enum
    /// </summary>
    public enum BlendFactor
    {
    /// <summary>
    ///     Blend factor of zero (multiply by 0)
    /// </summary>
    SdlBlendFactorZero = 0x1,

    /// <summary>
    ///     Blend factor of one (multiply by 1)
    /// </summary>
    SdlBlendFactorOne = 0x2,

    /// <summary>
    ///     Blend factor using the source color value
    /// </summary>
    SdlBlendFactorSrcColor = 0x3,

    /// <summary>
    ///     Blend factor using one minus the source color value
    /// </summary>
    SdlBlendFactorOneMinusSrcColor = 0x4,

    /// <summary>
    ///     Blend factor using the source alpha value
    /// </summary>
    SdlBlendFactorSrcAlpha = 0x5,

    /// <summary>
    ///     Blend factor using one minus the source alpha value
    /// </summary>
    SdlBlendFactorOneMinusSrcAlpha = 0x6,

    /// <summary>
    ///     Blend factor using the destination color value
    /// </summary>
    SdlBlendFactorDstColor = 0x7,

    /// <summary>
    ///     Blend factor using one minus the destination color value
    /// </summary>
    SdlBlendFactorOneMinusDstColor = 0x8,

    /// <summary>
    ///     Blend factor using the destination alpha value
    /// </summary>
    SdlBlendFactorDstAlpha = 0x9,

    /// <summary>
    ///     Blend factor using one minus the destination alpha value
    /// </summary>
    SdlBlendFactorOneMinusDstAlpha = 0xA
    }
}