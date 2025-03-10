// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Native.cs
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
using System.Security;
using System.Text;
using Alis.Core.Graphic.GlfwLib.Structs;

namespace Alis.Core.Graphic.GlfwLib
{
    /// <summary>
    ///     Provides access to relevant native functions of the current operating system.
    ///     <para>
    ///         By using the native access functions you assert that you know what you're doing and how to fix problems
    ///         caused by using them.
    ///     </para>
    ///     <para>If you don't, you shouldn't be using them.</para>
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    public static class Native
    {
        #region External

        /// <summary>
        ///     Returns the CGDirectDisplayID of the specified monitor.
        /// </summary>
        /// <param name="monitor">The monitor to query.</param>
        /// <returns>The CGDirectDisplayID of the specified monitor, or <see cref="nint.Zero" /> if an error occurred.</returns>
        [DllImport(Glfw.LIBRARY, EntryPoint = "glfwGetCocoaMonitor", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GetCocoaMonitor(Monitor monitor);

        /// <summary>
        ///     Retrieves a pointer to the X11 display.
        ///     <para>The pointer is to a native <c>Display</c> struct defined by X11..</para>
        /// </summary>
        /// <returns>A pointer to the X11 display struct.</returns>
        [DllImport(Glfw.LIBRARY, EntryPoint = "glfwGetX11Display", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetX11Display();

        /// <summary>
        ///     Retrieves a pointer to the Wayland display.
        ///     <para>The pointer is to a native <c>wl_display</c> struct defined in wayland-client.c.</para>
        /// </summary>
        /// <returns>A pointer to the Wayland display struct.</returns>
        /// <seealso href="https://github.com/msteinert/wayland/blob/master/src/wayland-client.c" />
        [DllImport(Glfw.LIBRARY, EntryPoint = "glfwGetWaylandDisplay", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetWaylandDisplay();

        /// <summary>
        ///     Retrieves a pointer to the Wayland output monitor.
        ///     <para>The pointer is to a native <c>wl_output</c> struct defined in wayland-client.c.</para>
        /// </summary>
        /// <returns>A pointer to the Wayland output struct.</returns>
        /// <seealso href="https://github.com/msteinert/wayland/blob/master/src/wayland-client.c" />
        [DllImport(Glfw.LIBRARY, EntryPoint = "glfwGetWaylandMonitor", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetWaylandMonitor(Monitor monitor);

        /// <summary>
        ///     Returns the pointer to the Wayland window for the specified window.
        /// </summary>
        /// <param name="window">A window instance.</param>
        /// <returns>A pointer to a Wayland window, or <see cref="IntPtr.Zero" /> if error occurred.</returns>
        [DllImport(Glfw.LIBRARY, EntryPoint = "glfwGetWaylandWindow", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetWaylandWindow(Window window);

        /// <summary>
        ///     Returns the pointer to the GLX window for the specified window.
        /// </summary>
        /// <param name="window">A window instance.</param>
        /// <returns>A pointer to a GLX window, or <see cref="IntPtr.Zero" /> if error occurred.</returns>
        [DllImport(Glfw.LIBRARY, EntryPoint = "glfwGetGLXWindow", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetGLXWindow(Window window);

        /// <summary>
        ///     Returns the pointer to the X11 window for the specified window.
        /// </summary>
        /// <param name="window">A window instance.</param>
        /// <returns>A pointer to an X11 window, or <see cref="IntPtr.Zero" /> if error occurred.</returns>
        [DllImport(Glfw.LIBRARY, EntryPoint = "glfwGetX11Window", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetX11Window(Window window);

        /// <summary>
        ///     Returns the RROutput of the specified monitor.
        /// </summary>
        /// <param name="monitor">The monitor to query.</param>
        /// <returns>The RROutput of the specified monitor, or <see cref="IntPtr.Zero" /> if an error occurred.</returns>
        [DllImport(Glfw.LIBRARY, EntryPoint = "glfwGetX11Monitor", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetX11Monitor(Monitor monitor);

        /// <summary>
        ///     Returns the RRCrtc of the specified monitor.
        /// </summary>
        /// <param name="monitor">The monitor to query.</param>
        /// <returns>The RRCrtc of the specified monitor, or <see cref="IntPtr.Zero" /> if an error occurred.</returns>
        [DllImport(Glfw.LIBRARY, EntryPoint = "glfwGetX11Adapter", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetX11Adapter(Monitor monitor);

        /// <summary>
        ///     Returns the pointer to the Cocoa window for the specified window.
        /// </summary>
        /// <param name="window">A window instance.</param>
        /// <returns>A pointer to a Cocoa window, or <see cref="IntPtr.Zero" /> if error occurred.</returns>
        [DllImport(Glfw.LIBRARY, EntryPoint = "glfwGetCocoaWindow", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetCocoaWindow(Window window);

        /// <summary>
        ///     Returns the NSOpenGLContext of the specified window.
        /// </summary>
        /// <param name="window">A window instance.</param>
        /// <returns>The NSOpenGLContext of the specified window, or <see cref="NSOpenGLContext.None" /> if an error occurred.</returns>
        [DllImport(Glfw.LIBRARY, EntryPoint = "glfwGetNSGLContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern NSOpenGLContext GetNSGLContext(Window window);

        /// <summary>
        ///     Returns the OSMesaContext of the specified window.
        /// </summary>
        /// <param name="window">A window instance.</param>
        /// <returns>The OSMesaContext of the specified window, or <see cref="OSMesaContext.None" /> if an error occurred.</returns>
        [DllImport(Glfw.LIBRARY, EntryPoint = "glfwGetOSMesaContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern OSMesaContext GetOSMesaContext(Window window);

        /// <summary>
        ///     Returns the GLXContext of the specified window.
        /// </summary>
        /// <param name="window">A window instance.</param>
        /// <returns>The GLXContext of the specified window, or <see cref="GLXContext.None" /> if an error occurred.</returns>
        [DllImport(Glfw.LIBRARY, EntryPoint = "glfwGetGLXContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern GLXContext GetGLXContext(Window window);

        /// <summary>
        ///     Returns the EGLContext of the specified window.
        /// </summary>
        /// <param name="window">A window instance.</param>
        /// <returns>The EGLContext of the specified window, or <see cref="EGLContext.None" /> if an error occurred.</returns>
        [DllImport(Glfw.LIBRARY, EntryPoint = "glfwGetEGLContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern EGLContext GetEglContext(Window window);

        /// <summary>
        ///     Returns the EGLDisplay used by GLFW.
        /// </summary>
        /// <returns>The EGLDisplay used by GLFW, or <see cref="EGLDisplay.None" /> if an error occurred.</returns>
        [DllImport(Glfw.LIBRARY, EntryPoint = "glfwGetEGLDisplay", CallingConvention = CallingConvention.Cdecl)]
        public static extern EGLDisplay GetEglDisplay();

        /// <summary>
        ///     Returns the <see cref="EGLSurface" /> of the specified window
        /// </summary>
        /// <param name="window">A window instance.</param>
        /// <returns>The EGLSurface of the specified window, or <see cref="EGLSurface.None" /> if an error occurred.</returns>
        [DllImport(Glfw.LIBRARY, EntryPoint = "glfwGetEGLSurface", CallingConvention = CallingConvention.Cdecl)]
        public static extern EGLSurface GetEglSurface(Window window);

        /// <summary>
        ///     Returns the WGL context of the specified window.
        /// </summary>
        /// <param name="window">A window instance.</param>
        /// <returns>The WGL context of the specified window, or <see cref="EGLContext.None" /> if an error occurred.</returns>
        [DllImport(Glfw.LIBRARY, EntryPoint = "glfwGetWGLContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern HGLRC GetWglContext(Window window);

        /// <summary>
        ///     Returns the HWND of the specified window.
        /// </summary>
        /// <param name="window">A window instance.</param>
        /// <returns>The HWND of the specified window, or <see cref="IntPtr.Zero" /> if an error occurred.</returns>
        [DllImport(Glfw.LIBRARY, EntryPoint = "glfwGetWin32Window", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetWin32Window(Window window);

        /// <summary>
        ///     Returns the contents of the selection as a string.
        /// </summary>
        /// <returns>The selected string, or <c>null</c> if error occurs or no string is selected.</returns>
        public static string GetX11SelectionString()
        {
            IntPtr ptr = GetX11SelectionStringInternal();
            return ptr == IntPtr.Zero ? null : Util.PtrToStringUTF8(ptr);
        }

        /// <summary>
        ///     Sets the clipboard string of an X11 window.
        /// </summary>
        /// <param name="str">The string to set.</param>
        public static void SetX11SelectionString(string str)
        {
            SetX11SelectionString(Encoding.UTF8.GetBytes(str));
        }

        /// <summary>
        ///     Retrieves the color buffer associated with the specified window.
        /// </summary>
        /// <param name="window">The window whose color buffer to retrieve.</param>
        /// <param name="width">The width of the color buffer.</param>
        /// <param name="height">The height of the color buffer.</param>
        /// <param name="format">The pixel format of the color buffer.</param>
        /// <param name="buffer">A pointer to the first element in the buffer.</param>
        /// <returns><c>true</c> if operation was successful, otherwise <c>false</c>.</returns>
        [DllImport(Glfw.LIBRARY, EntryPoint = "glfwGetOSMesaColorBuffer", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool
            GetOSMesaColorBuffer(Window window, out int width, out int height, out int format, out IntPtr buffer);

        /// <summary>
        ///     Retrieves the depth buffer associated with the specified window.
        /// </summary>
        /// <param name="window">The window whose depth buffer to retrieve.</param>
        /// <param name="width">The width of the depth buffer.</param>
        /// <param name="height">The height of the depth buffer.</param>
        /// <param name="bytesPerValue">The number of bytes per element in the buffer.</param>
        /// <param name="buffer">A pointer to the first element in the buffer.</param>
        /// <returns><c>true</c> if operation was successful, otherwise <c>false</c>.</returns>
        [DllImport(Glfw.LIBRARY, EntryPoint = "glfwGetOSMesaDepthBuffer", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool
            GetOSMesaDepthBuffer(Window window, out int width, out int height, out int bytesPerValue,
                out IntPtr buffer);


        /// <summary>
        ///     Sets the x 11 selection string using the specified str
        /// </summary>
        /// <param name="str">The str</param>
        [DllImport(Glfw.LIBRARY, EntryPoint = "glfwSetX11SelectionString", CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetX11SelectionString(byte[] str);

        /// <summary>
        ///     Gets the x 11 selection string internal
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(Glfw.LIBRARY, EntryPoint = "glfwGetX11SelectionString", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr GetX11SelectionStringInternal();

        /// <summary>
        ///     Gets the win 32 adapter internal using the specified monitor
        /// </summary>
        /// <param name="monitor">The monitor</param>
        /// <returns>The int ptr</returns>
        [DllImport(Glfw.LIBRARY, EntryPoint = "glfwGetWin32Adapter", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr GetWin32AdapterInternal(Monitor monitor);

        /// <summary>
        ///     Gets the win 32 monitor internal using the specified monitor
        /// </summary>
        /// <param name="monitor">The monitor</param>
        /// <returns>The int ptr</returns>
        [DllImport(Glfw.LIBRARY, EntryPoint = "glfwGetWin32Monitor", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr GetWin32MonitorInternal(Monitor monitor);

        #endregion

        #region Methods

        /// <summary>
        ///     Gets the win32 adapter.
        /// </summary>
        /// <param name="monitor">A monitor instance.</param>
        /// <returns>dapter device name (for example \\.\DISPLAY1) of the specified monitor, or <c>null</c> if an error occurred.</returns>
        public static string GetWin32Adapter(Monitor monitor) => Util.PtrToStringUTF8(GetWin32AdapterInternal(monitor));

        /// <summary>
        ///     Returns the display device name of the specified monitor
        /// </summary>
        /// <param name="monitor">A monitor instance.</param>
        /// <returns>
        ///     The display device name (for example \\.\DISPLAY1\Monitor0) of the specified monitor, or <c>null</c> if an
        ///     error occurred.
        /// </returns>
        public static string GetWin32Monitor(Monitor monitor) => Util.PtrToStringUTF8(GetWin32MonitorInternal(monitor));

        #endregion
    }
}