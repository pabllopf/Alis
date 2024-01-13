// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: SdlWindowFlags.cs
// 
//  Author: Pablo Perdomo Falcón
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
    ///     The sdl window flags enum
    /// </summary>
    [Flags]
    public enum SdlWindowFlags : uint
    {
        /// <summary>
        ///     The sdl window fullscreen sdl window flags
        /// </summary>
        SdlWindowFullscreen = 0x00000001,

        /// <summary>
        ///     The sdl window opengl sdl window flags
        /// </summary>
        SdlWindowOpengl = 0x00000002,

        /// <summary>
        ///     The sdl window shown sdl window flags
        /// </summary>
        SdlWindowShown = 0x00000004,

        /// <summary>
        ///     The sdl window hidden sdl window flags
        /// </summary>
        SdlWindowHidden = 0x00000008,

        /// <summary>
        ///     The sdl window borderless sdl window flags
        /// </summary>
        SdlWindowBorderless = 0x00000010,

        /// <summary>
        ///     The sdl window resizable sdl window flags
        /// </summary>
        SdlWindowResizable = 0x00000020,

        /// <summary>
        ///     The sdl window minimized sdl window flags
        /// </summary>
        SdlWindowMinimized = 0x00000040,

        /// <summary>
        ///     The sdl window maximized sdl window flags
        /// </summary>
        SdlWindowMaximized = 0x00000080,

        /// <summary>
        ///     The sdl window mouse grabbed sdl window flags
        /// </summary>
        SdlWindowMouseGrabbed = 0x00000100,

        /// <summary>
        ///     The sdl window input focus sdl window flags
        /// </summary>
        SdlWindowInputFocus = 0x00000200,

        /// <summary>
        ///     The sdl window mouse focus sdl window flags
        /// </summary>
        SdlWindowMouseFocus = 0x00000400,

        /// <summary>
        ///     The sdl window fullscreen desktop sdl window flags
        /// </summary>
        SdlWindowFullscreenDesktop =
            SdlWindowFullscreen | 0x00001000,

        /// <summary>
        ///     The sdl window foreign sdl window flags
        /// </summary>
        SdlWindowForeign = 0x00000800,

        /// <summary>
        ///     The sdl window allow high dpi sdl window flags
        /// </summary>
        SdlWindowAllowHighDpi = 0x00002000,

        /// <summary>
        ///     The sdl window mouse capture sdl window flags
        /// </summary>
        SdlWindowMouseCapture = 0x00004000,

        /// <summary>
        ///     The sdl window always on top sdl window flags
        /// </summary>
        SdlWindowAlwaysOnTop = 0x00008000,

        /// <summary>
        ///     The sdl window skip taskbar sdl window flags
        /// </summary>
        SdlWindowSkipTaskbar = 0x00010000,

        /// <summary>
        ///     The sdl window utility sdl window flags
        /// </summary>
        SdlWindowUtility = 0x00020000,

        /// <summary>
        ///     The sdl window tooltip sdl window flags
        /// </summary>
        SdlWindowTooltip = 0x00040000,

        /// <summary>
        ///     The sdl window popup menu sdl window flags
        /// </summary>
        SdlWindowPopupMenu = 0x00080000,

        /// <summary>
        ///     The sdl window keyboard grabbed sdl window flags
        /// </summary>
        SdlWindowKeyboardGrabbed = 0x00100000,

        /// <summary>
        ///     The sdl window vulkan sdl window flags
        /// </summary>
        SdlWindowVulkan = 0x10000000,

        /// <summary>
        ///     The sdl window metal sdl window flags
        /// </summary>
        SdlWindowMetal = 0x2000000,

        /// <summary>
        ///     The sdl window input grabbed sdl window flags
        /// </summary>
        SdlWindowInputGrabbed =
            SdlWindowMouseGrabbed
    }
}