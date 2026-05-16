// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Renderers.cs
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
    ///     The sdl renderer flags enum
    /// </summary>
    [Flags]
    public enum Renderers : uint
    {
    /// <summary>
    ///     No renderer flags set (software fallback)
    /// </summary>
    None = 0x00000000,

    /// <summary>
    ///     Renderer uses software-based rendering (CPU, no GPU)
    /// </summary>
    SdlRendererSoftware = 0x00000001,

    /// <summary>
    ///     Renderer uses hardware-accelerated rendering (GPU)
    /// </summary>
    SdlRendererAccelerated = 0x00000002,

    /// <summary>
    ///     Renderer will present frames synchronized with vertical refresh
    /// </summary>
    SdlRendererPresentVSync = 0x00000004,

    /// <summary>
    ///     Renderer supports rendering to a texture target
    /// </summary>
    SdlRendererTargetTexture = 0x00000008
    }
}