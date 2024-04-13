// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiBackendFlags.cs
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

namespace Alis.Extension.Graphic.ImGui
{
    /// <summary>
    ///     The im gui backend flags enum
    /// </summary>
    [Flags]
    public enum ImGuiBackendFlags
    {
        /// <summary>
        ///     The none im gui backend flags
        /// </summary>
        None = 0,
        
        /// <summary>
        ///     The has gamepad im gui backend flags
        /// </summary>
        HasGamepad = 1,
        
        /// <summary>
        ///     The has mouse cursors im gui backend flags
        /// </summary>
        HasMouseCursors = 2,
        
        /// <summary>
        ///     The has set mouse pos im gui backend flags
        /// </summary>
        HasSetMousePos = 4,
        
        /// <summary>
        ///     The renderer has vtx offset im gui backend flags
        /// </summary>
        RendererHasVtxOffset = 8,
        
        /// <summary>
        ///     The platform has viewports im gui backend flags
        /// </summary>
        PlatformHasViewports = 1024,
        
        /// <summary>
        ///     The has mouse hovered viewport im gui backend flags
        /// </summary>
        HasMouseHoveredViewport = 2048,
        
        /// <summary>
        ///     The renderer has viewports im gui backend flags
        /// </summary>
        RendererHasViewports = 4096
    }
}