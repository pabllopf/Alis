// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InternalSysWmDriverUnion.cs
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

using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     A union type overlaying all platform-specific window manager info structures at the same memory offset.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct InternalSysWmDriverUnion
    {
        /// <summary>
        ///     Windows native window manager info (HWND, HDC, HINSTANCE).
        /// </summary>
        [FieldOffset(0)] public InternalWindowsWmInfo win;


        /// <summary>
        ///     WinRT window manager info.
        /// </summary>
        [FieldOffset(0)] public InternalWinrtWmInfo winrt;


        /// <summary>
        ///     X11 window manager info (Display*, Window XID).
        /// </summary>
        [FieldOffset(0)] public InternalX11WmInfo x11;


        /// <summary>
        ///     DirectFB window manager info.
        /// </summary>
        [FieldOffset(0)] public InternalDirectfbWmInfo dfb;


        /// <summary>
        ///     Cocoa (macOS) window manager info (NSWindow*).
        /// </summary>
        [FieldOffset(0)] public InternalCocoaWmInfo cocoa;


        /// <summary>
        ///     UIKit (iOS/tvOS) window manager info (UIWindow*).
        /// </summary>
        [FieldOffset(0)] public InternalUikitWmInfo uikit;


        /// <summary>
        ///     Wayland window manager info (wl_display*, wl_surface*, etc.).
        /// </summary>
        [FieldOffset(0)] public InternalWaylandWmInfo wl;


        /// <summary>
        ///     Mir display server window manager info.
        /// </summary>
        [FieldOffset(0)] public InternalMirWmInfo mir;


        /// <summary>
        ///     Android window manager info (ANativeWindow*, EGLSurface*).
        /// </summary>
        [FieldOffset(0)] public InternalAndroidWmInfo android;


        /// <summary>
        ///     OS/2 window manager info.
        /// </summary>
        [FieldOffset(0)] public InternalOs2WmInfo os2;


        /// <summary>
        ///     Vivante (Vivante GPU) window manager info.
        /// </summary>
        [FieldOffset(0)] public InternalVivanteWmInfo VivanteWmInfo;


        /// <summary>
        ///     KMS/DRM window manager info.
        /// </summary>
        [FieldOffset(0)] public InternalKmsWmInfo ksm;
    }
}