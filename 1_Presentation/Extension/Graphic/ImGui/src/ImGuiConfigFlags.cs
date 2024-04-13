// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiConfigFlags.cs
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
    ///     The im gui config flags enum
    /// </summary>
    [Flags]
    public enum ImGuiConfigFlags
    {
        /// <summary>
        ///     The none im gui config flags
        /// </summary>
        None = 0,
        
        /// <summary>
        ///     The nav enable keyboard im gui config flags
        /// </summary>
        NavEnableKeyboard = 1,
        
        /// <summary>
        ///     The nav enable gamepad im gui config flags
        /// </summary>
        NavEnableGamepad = 2,
        
        /// <summary>
        ///     The nav enable set mouse pos im gui config flags
        /// </summary>
        NavEnableSetMousePos = 4,
        
        /// <summary>
        ///     The nav no capture keyboard im gui config flags
        /// </summary>
        NavNoCaptureKeyboard = 8,
        
        /// <summary>
        ///     The no mouse im gui config flags
        /// </summary>
        NoMouse = 16,
        
        /// <summary>
        ///     The no mouse cursor change im gui config flags
        /// </summary>
        NoMouseCursorChange = 32,
        
        /// <summary>
        ///     The docking enable im gui config flags
        /// </summary>
        DockingEnable = 64,
        
        /// <summary>
        ///     The viewports enable im gui config flags
        /// </summary>
        ViewportsEnable = 1024,
        
        /// <summary>
        ///     The dpi enable scale viewports im gui config flags
        /// </summary>
        DpiEnableScaleViewports = 16384,
        
        /// <summary>
        ///     The dpi enable scale fonts im gui config flags
        /// </summary>
        DpiEnableScaleFonts = 32768,
        
        /// <summary>
        ///     The is srgb im gui config flags
        /// </summary>
        IsSrgb = 1048576,
        
        /// <summary>
        ///     The is touch screen im gui config flags
        /// </summary>
        IsTouchScreen = 2097152
    }
}