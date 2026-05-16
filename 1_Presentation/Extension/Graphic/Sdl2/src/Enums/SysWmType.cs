// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SysWmType.cs
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
    ///     The sdl sys wm type enum
    /// </summary>
    public enum SysWmType
    {
    /// <summary>
    ///     Unknown or unsupported window manager type
    /// </summary>
    SdlSysWmUnknown,

    /// <summary>
    ///     Microsoft Windows window manager
    /// </summary>
    SdlSysWmWindows,

    /// <summary>
    ///     X11 window system (Linux/Unix)
    /// </summary>
    SdlSysWmX11,

    /// <summary>
    ///     DirectFB windowing system
    /// </summary>
    SdlSysWmDirectfb,

    /// <summary>
    ///     Cocoa window manager (macOS)
    /// </summary>
    SdlSysWmCocoa,

    /// <summary>
    ///     UIKit window manager (iOS/tvOS)
    /// </summary>
    SdlSysWmUikit,

    /// <summary>
    ///     Wayland compositor (Linux)
    /// </summary>
    SdlSysWmWayland,

    /// <summary>
    ///     Mir display server (Linux)
    /// </summary>
    SdlSysWmMir,

    /// <summary>
    ///     WinRT window manager (Windows Runtime)
    /// </summary>
    SdlSysWmWinrt,

    /// <summary>
    ///     Android window manager (SurfaceFlinger)
    /// </summary>
    SdlSysWmAndroid,

    /// <summary>
    ///     Vivante display driver (embedded systems)
    /// </summary>
    SdlSysWmVivante,

    /// <summary>
    ///     OS/2 Presentation Manager
    /// </summary>
    SdlSysWmOs2,

    /// <summary>
    ///     Haiku window manager
    /// </summary>
    SdlSysWmHaiku,

    /// <summary>
    ///     KMS/DRM direct graphics mode (Linux without a display server)
    /// </summary>
    SdlSysWmKmsDrm
    }
}