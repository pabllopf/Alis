// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BlendModes.cs
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
    ///     The sdl blend mode enum
    /// </summary>
    [Flags]
    public enum BlendModes
    {
    /// <summary>
    ///     No blending applied; pixels are written as-is
    /// </summary>
    None = 0x00000000,

    /// <summary>
    ///     Standard alpha blending: src * src_alpha + dst * (1 - src_alpha)
    /// </summary>
    BlendModeBlend = 0x00000001,

    /// <summary>
    ///     Additive blending: src + dst
    /// </summary>
    BlendModeAdd = 0x00000002,

    /// <summary>
    ///     Modulate blending: src * dst (color modulation)
    /// </summary>
    BlendModeMod = 0x00000004,

    /// <summary>
    ///     Multiply blending: src * dst (multiply mode)
    /// </summary>
    BlendModeMul = 0x00000008,

    /// <summary>
    ///     Invalid or uninitialized blend mode marker
    /// </summary>
    BlendModeInvalid = 0x7FFFFFFF,

    /// <summary>
    ///     Combination of all valid blend modes
    /// </summary>
    BlendAll = BlendModeBlend | BlendModeAdd | BlendModeMod | BlendModeMul | BlendModeInvalid
    }
}