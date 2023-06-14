// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlWindowFlags.cs
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

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl windowflags enum
    /// </summary>
    [Flags]
    public enum SdlWindowFlags : uint
    {
        /// <summary>
        ///     The sdl window fullscreen sdl windowflags
        /// </summary>
        SdlWindowFullscreen = 0x00000001,

        /// <summary>
        ///     The sdl window opengl sdl windowflags
        /// </summary>
        SdlWindowOpengl = 0x00000002,

        /// <summary>
        ///     The sdl window shown sdl windowflags
        /// </summary>
        SdlWindowShown = 0x00000004,

        /// <summary>
        ///     The sdl window hidden sdl windowflags
        /// </summary>
        SdlWindowHidden = 0x00000008,

        /// <summary>
        ///     The sdl window borderless sdl windowflags
        /// </summary>
        SdlWindowBorderless = 0x00000010,

        /// <summary>
        ///     The sdl window resizable sdl windowflags
        /// </summary>
        SdlWindowResizable = 0x00000020,

        /// <summary>
        ///     The sdl window minimized sdl windowflags
        /// </summary>
        SdlWindowMinimized = 0x00000040,

        /// <summary>
        ///     The sdl window maximized sdl windowflags
        /// </summary>
        SdlWindowMaximized = 0x00000080,

        /// <summary>
        ///     The sdl window mouse grabbed sdl windowflags
        /// </summary>
        SdlWindowMouseGrabbed = 0x00000100,

        /// <summary>
        ///     The sdl window input focus sdl windowflags
        /// </summary>
        SdlWindowInputFocus = 0x00000200,

        /// <summary>
        ///     The sdl window mouse focus sdl windowflags
        /// </summary>
        SdlWindowMouseFocus = 0x00000400,

        /// <summary>
        ///     The sdl window fullscreen desktop sdl windowflags
        /// </summary>
        SdlWindowFullscreenDesktop =
            SdlWindowFullscreen | 0x00001000,

        /// <summary>
        ///     The sdl window foreign sdl windowflags
        /// </summary>
        SdlWindowForeign = 0x00000800,

        /// <summary>
        ///     The sdl window allow highdpi sdl windowflags
        /// </summary>
        SdlWindowAllowHighdpi = 0x00002000,

        /// <summary>
        ///     The sdl window mouse capture sdl windowflags
        /// </summary>
        SdlWindowMouseCapture = 0x00004000,

        /// <summary>
        ///     The sdl window always on top sdl windowflags
        /// </summary>
        SdlWindowAlwaysOnTop = 0x00008000,

        /// <summary>
        ///     The sdl window skip taskbar sdl windowflags
        /// </summary>
        SdlWindowSkipTaskbar = 0x00010000,

        /// <summary>
        ///     The sdl window utility sdl windowflags
        /// </summary>
        SdlWindowUtility = 0x00020000,

        /// <summary>
        ///     The sdl window tooltip sdl windowflags
        /// </summary>
        SdlWindowTooltip = 0x00040000,

        /// <summary>
        ///     The sdl window popup menu sdl windowflags
        /// </summary>
        SdlWindowPopupMenu = 0x00080000,

        /// <summary>
        ///     The sdl window keyboard grabbed sdl windowflags
        /// </summary>
        SdlWindowKeyboardGrabbed = 0x00100000,

        /// <summary>
        ///     The sdl window vulkan sdl windowflags
        /// </summary>
        SdlWindowVulkan = 0x10000000,

        /// <summary>
        ///     The sdl window metal sdl windowflags
        /// </summary>
        SdlWindowMetal = 0x2000000,

        /// <summary>
        ///     The sdl window input grabbed sdl windowflags
        /// </summary>
        SdlWindowInputGrabbed =
            SdlWindowMouseGrabbed
    }
}