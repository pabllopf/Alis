// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WindowSettings.cs
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
    ///     The sdl window flags enum
    /// </summary>
    [Flags]
    public enum WindowSettings : uint
    {
    /// <summary>
    ///     No window flags set (default state)
    /// </summary>
    None = 0x00000000,

    /// <summary>
    ///     Window is in fullscreen mode
    /// </summary>
    WindowFullscreen = 0x00000001,

    /// <summary>
    ///     Window is usable with an OpenGL context
    /// </summary>
    WindowOpengl = 0x00000002,

    /// <summary>
    ///     Window is visible and shown on screen
    /// </summary>
    WindowShown = 0x00000004,

    /// <summary>
    ///     Window is not visible
    /// </summary>
    WindowHidden = 0x00000008,

    /// <summary>
    ///     Window has no window decorations (no title bar, borders)
    /// </summary>
    WindowBorderless = 0x00000010,

    /// <summary>
    ///     Window can be resized by the user
    /// </summary>
    WindowResizable = 0x00000020,

    /// <summary>
    ///     Window is minimized (iconified)
    /// </summary>
    WindowMinimized = 0x00000040,

    /// <summary>
    ///     Window is maximized
    /// </summary>
    WindowMaximized = 0x00000080,

    /// <summary>
    ///     Window has mouse input grabbed (mouse confined to window)
    /// </summary>
    WindowMouseGrabbed = 0x00000100,

    /// <summary>
    ///     Window has input focus (receives keyboard events)
    /// </summary>
    WindowInputFocus = 0x00000200,

    /// <summary>
    ///     Window has mouse focus (mouse is inside the window)
    /// </summary>
    WindowMouseFocus = 0x00000400,

    /// <summary>
    ///     Window is in fullscreen desktop mode (native resolution)
    /// </summary>
    WindowFullscreenDesktop =
        WindowFullscreen | 0x00001000,

    /// <summary>
    ///     Window was created via a foreign (external) window handle
    /// </summary>
    WindowForeign = 0x00000800,

    /// <summary>
    ///     Window supports high DPI mode on Retina/HiDPI displays
    /// </summary>
    WindowAllowHighDpi = 0x00002000,

    /// <summary>
    ///     Window has mouse capture (mouse events captured outside window)
    /// </summary>
    WindowMouseCapture = 0x00004000,

    /// <summary>
    ///     Window is always on top of other windows
    /// </summary>
    WindowAlwaysOnTop = 0x00008000,

    /// <summary>
    ///     Window is excluded from the taskbar
    /// </summary>
    WindowSkipTaskbar = 0x00010000,

    /// <summary>
    ///     Window is a utility window (small, with minimal decorations)
    /// </summary>
    WindowUtility = 0x00020000,

    /// <summary>
    ///     Window is a tooltip popup window
    /// </summary>
    WindowTooltip = 0x00040000,

    /// <summary>
    ///     Window is a popup menu window
    /// </summary>
    WindowPopupMenu = 0x00080000,

    /// <summary>
    ///     Window has keyboard input grabbed
    /// </summary>
    WindowKeyboardGrabbed = 0x00100000,

    /// <summary>
    ///     Window is usable with a Vulkan graphics context
    /// </summary>
    WindowVulkan = 0x10000000,

    /// <summary>
    ///     Window is usable with a Metal graphics context (macOS/iOS)
    /// </summary>
    WindowMetal = 0x2000000,

    /// <summary>
    ///     Window has input grabbed (shorthand for mouse grab)
    /// </summary>
    WindowInputGrabbed =
        WindowMouseGrabbed
    }
}