

using System;
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The internal wayland wm info
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct InternalWaylandWmInfo
    {
        /// <summary>
        ///     Refers to a wl_display*
        /// </summary>
        public IntPtr Display { get; set; }

        /// <summary>
        ///     Refers to a wl_surface*
        /// </summary>
        public IntPtr Surface { get; set; }

        /// <summary>
        ///     Refers to a wl_shell_surface*
        /// </summary>
        public IntPtr ShellSurface { get; set; }

        /// <summary>
        ///     Refers to an egl_window*, requires >= 2.0.16
        /// </summary>
        public IntPtr EglWindow { get; set; }

        /// <summary>
        ///     Refers to an xdg_surface*, requires >= 2.0.16
        /// </summary>
        public IntPtr XdgSurface { get; set; }

        /// <summary>
        ///     Refers to an xdg_toplevel*, requires >= 2.0.18
        /// </summary>
        public IntPtr XdgToplevel { get; set; }
    }
}