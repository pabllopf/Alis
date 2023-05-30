// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InternalWaylandWminfo.cs
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
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The internal wayland wminfo
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct InternalWaylandWminfo
    {
        /// <summary>
        ///     The display
        /// </summary>
        public IntPtr display; // Refers to a wl_display*

        /// <summary>
        ///     The surface
        /// </summary>
        public IntPtr surface; // Refers to a wl_surface*

        /// <summary>
        ///     The shell surface
        /// </summary>
        public IntPtr shell_surface; // Refers to a wl_shell_surface*

        /// <summary>
        ///     The egl window
        /// </summary>
        public IntPtr egl_window; // Refers to an egl_window*, requires >= 2.0.16

        /// <summary>
        ///     The xdg surface
        /// </summary>
        public IntPtr xdg_surface; // Refers to an xdg_surface*, requires >= 2.0.16

        /// <summary>
        ///     The xdg toplevel
        /// </summary>
        public IntPtr xdg_toplevel; // Referes to an xdg_toplevel*, requires >= 2.0.18
    }
}