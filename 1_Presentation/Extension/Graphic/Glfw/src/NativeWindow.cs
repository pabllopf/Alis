// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NativeWindow.cs
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
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using Alis.Extension.Graphic.Glfw.Enums;
using Alis.Extension.Graphic.Glfw.Structs;
using Microsoft.Win32.SafeHandles;
using Image = Alis.Core.Graphic.Image;

namespace Alis.Extension.Graphic.Glfw
{
    /// <summary>
    ///     Provides a simplified interface for creating and using a GLFW window with properties, events, etc.
    /// </summary>
    /// <seealso cref="Microsoft.Win32.SafeHandles.SafeHandleZeroOrMinusOneIsInvalid" />
    public class NativeWindow : SafeHandleZeroOrMinusOneIsInvalid, IEquatable<NativeWindow>
    {
        /// <summary>
        ///     The window instance this object wraps.
        /// </summary>
        protected readonly Window Window;

        /// <summary>
        ///     The char mods callback
        /// </summary>
        private CharModsCallback charModsCallback;

        /// <summary>
        ///     The window refresh callback
        /// </summary>
        private WindowCallback closeCallback, windowRefreshCallback;

        /// <summary>
        ///     The cursor enter callback
        /// </summary>
        private MouseEnterCallback cursorEnterCallback;

        /// <summary>
        ///     The scroll callback
        /// </summary>
        private MouseCallback cursorPositionCallback, scrollCallback;

        /// <summary>
        ///     The drop callback
        /// </summary>
        private FileDropCallback dropCallback;

        /// <summary>
        ///     The key callback
        /// </summary>
        private KeyCallback keyCallback;

        /// <summary>
        ///     The mouse button callback
        /// </summary>
        private MouseButtonCallback mouseButtonCallback;

        /// <summary>
        ///     The title
        /// </summary>
        private string title;

        /// <summary>
        ///     The window content scale callback
        /// </summary>
        private WindowContentsScaleCallback windowContentScaleCallback;

        /// <summary>
        ///     The window focus callback
        /// </summary>
        private FocusCallback windowFocusCallback;

        /// <summary>
        ///     The window maximize callback
        /// </summary>
        private WindowMaximizedCallback windowMaximizeCallback;

        /// <summary>
        ///     The window position callback
        /// </summary>
        private PositionCallback windowPositionCallback;

        /// <summary>
        ///     The framebuffer size callback
        /// </summary>
        private SizeCallback windowSizeCallback, framebufferSizeCallback;


        /// <summary>
        ///     Initializes a new instance of the <see cref="NativeWindow" /> class.
        /// </summary>
        public NativeWindow() : this(800, 600, string.Empty, Monitor.None, Window.None)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="NativeWindow" /> class.
        /// </summary>
        /// <param name="width">The desired width, in screen coordinates, of the window. This must be greater than zero.</param>
        /// <param name="height">The desired height, in screen coordinates, of the window. This must be greater than zero.</param>
        /// <param name="title">The initial window title.</param>
        public NativeWindow(int width, int height, string title) : this(width, height, title, Monitor.None,
            Window.None)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="NativeWindow" /> class.
        /// </summary>
        /// <param name="width">The desired width, in screen coordinates, of the window. This must be greater than zero.</param>
        /// <param name="height">The desired height, in screen coordinates, of the window. This must be greater than zero.</param>
        /// <param name="title">The initial window title.</param>
        /// <param name="monitor">
        ///     The monitor to use for full screen mode, or <see cref="Structs.Monitor.None" /> for windowed
        ///     mode.
        /// </param>
        /// <param name="share">
        ///     A window instance whose context to share resources with, or <see cref="Structs.Window.None" /> to not share
        ///     resources..
        /// </param>
        public NativeWindow(int width, int height, string title, Monitor monitor, Window share) : base(true)
        {
            this.title = title ?? string.Empty;
            Window = GlfwNative.CreateWindow(width, height, title ?? string.Empty, monitor, share);
            SetHandle(Window);
            if (GlfwNative.GetClientApi(this) != ClientApi.None)
            {
                MakeCurrent();
            }

            BindCallbacks();
        }


        /// <summary>
        ///     Gets or sets the size and location of the window including its non-client elements (borders, title bar, etc.), in
        ///     screen coordinates.
        /// </summary>
        /// <value>
        ///     A <see cref="Rectangle" /> in screen coordinates relative to the parent control that represents the size and
        ///     location of the control including its non-client elements.
        /// </value>
        public Rectangle Bounds
        {
            get => new Rectangle(Position, Size);
            set
            {
                Size = value.Size;
                Position = value.Location;
            }
        }

        /// <summary>
        ///     Gets the ratio between the current DPI and the platform's default DPI.
        /// </summary>
        /// <seealso cref="GlfwNative.GetWindowContentScale" />
        public PointF ContentScale
        {
            get
            {
                GlfwNative.GetWindowContentScale(handle, out float x, out float y);
                return new PointF(x, y);
            }
        }

        /// <summary>
        ///     Gets the size and location of the client area of the window, in screen coordinates.
        /// </summary>
        /// <value>
        ///     A <see cref="Rectangle" /> in screen coordinates that represents the size and location of the window's client area.
        /// </value>
        public Rectangle ClientBounds
        {
            get => new Rectangle(Position, ClientSize);
            set
            {
                GlfwNative.SetWindowPosition(Window, value.X, value.Y);
                GlfwNative.SetWindowSize(Window, value.Width, value.Height);
            }
        }

        /// <summary>
        ///     Gets or sets the width of the client area of the window, in screen coordinates.
        /// </summary>
        /// <exception cref="Exception">Thrown when specified value is less than 1.</exception>
        public int ClientWidth
        {
            get
            {
                GlfwNative.GetWindowSize(Window, out int width, out int dummy);
                return width;
            }
            set
            {
                if (value < 1)
                {
                    throw new Exception("Window width muts be greater than 0.");
                }

                GlfwNative.GetWindowSize(Window, out int dummy, out int height);
                GlfwNative.SetWindowSize(Window, value, height);
            }
        }

        /// <summary>
        ///     Gets or sets the height of the client area of the window, in screen coordinates.
        /// </summary>
        /// <exception cref="Exception">Thrown when specified value is less than 1.</exception>
        public int ClientHeight
        {
            get
            {
                GlfwNative.GetWindowSize(Window, out int dummy, out int height);
                return height;
            }
            set
            {
                if (value < 1)
                {
                    throw new Exception("Window height muts be greater than 0.");
                }

                GlfwNative.GetWindowSize(Window, out int width, out int dummy);
                GlfwNative.SetWindowSize(Window, width, value);
            }
        }

        /// <summary>
        ///     Gets or sets the size of the client area of the window, in screen coordinates.
        /// </summary>
        /// <value>
        ///     A <see cref="System.Drawing.Size" /> in screen coordinates that represents the size of the window's client area.
        /// </value>
        public Size ClientSize
        {
            get
            {
                GlfwNative.GetWindowSize(Window, out int width, out int height);
                return new Size(width, height);
            }
            set => GlfwNative.SetWindowSize(Window, value.Width, value.Height);
        }

        /// <summary>
        ///     Gets or sets a string to the system clipboard.
        /// </summary>
        /// <value>
        ///     The clipboard string.
        /// </value>
        public string Clipboard
        {
            get => GlfwNative.GetClipboardString(Window);
            set => GlfwNative.SetClipboardString(Window, value);
        }

        /// <summary>
        ///     Gets or sets the behavior of the mouse cursor.
        /// </summary>
        /// <value>
        ///     The cursor mode.
        /// </value>
        public CursorMode CursorMode
        {
            get => (CursorMode) GlfwNative.GetInputMode(Window, InputMode.Cursor);
            set => GlfwNative.SetInputMode(Window, InputMode.Cursor, (int) value);
        }

        /// <summary>
        ///     Gets the underlying pointer used by GLFW for this window instance.
        /// </summary>
        /// <value>
        ///     The GLFW window handle.
        /// </value>
        public IntPtr Handle => handle;

        /// <summary>
        ///     Gets the Window's HWND for this window.
        ///     <para>WARNING: Windows only.</para>
        /// </summary>
        /// <value>
        ///     The HWND pointer.
        /// </value>
        // ReSharper disable once IdentifierTypo
        public IntPtr Hwnd
        {
            get
            {
                try
                {
                    return GetWin32Window(Window);
                }
                catch (Exception)
                {
                    return IntPtr.Zero;
                }
            }
        }
        
            /// <summary>
        ///     Returns the CGDirectDisplayID of the specified monitor.
        /// </summary>
        /// <param name="monitor">The monitor to query.</param>
        /// <returns>The CGDirectDisplayID of the specified monitor, or if an error occurred.</returns>
        [DllImport(GlfwNative.Library, EntryPoint = "glfwGetCocoaMonitor", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GetCocoaMonitor(Monitor monitor);

        /// <summary>
        ///     Retrieves a pointer to the X11 display.
        ///     <para>The pointer is to a native <c>Display</c> struct defined by X11..</para>
        /// </summary>
        /// <returns>A pointer to the X11 display struct.</returns>
        [DllImport(GlfwNative.Library, EntryPoint = "glfwGetX11Display", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetX11Display();

        /// <summary>
        ///     Retrieves a pointer to the Wayland display.
        ///     <para>The pointer is to a native <c>wl_display</c> struct defined in wayland-client.c.</para>
        /// </summary>
        /// <returns>A pointer to the Wayland display struct.</returns>
        /// <seealso href="https://github.com/msteinert/wayland/blob/master/src/wayland-client.c" />
        [DllImport(GlfwNative.Library, EntryPoint = "glfwGetWaylandDisplay", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetWaylandDisplay();

        /// <summary>
        ///     Retrieves a pointer to the Wayland output monitor.
        ///     <para>The pointer is to a native <c>wl_output</c> struct defined in wayland-client.c.</para>
        /// </summary>
        /// <returns>A pointer to the Wayland output struct.</returns>
        /// <seealso href="https://github.com/msteinert/wayland/blob/master/src/wayland-client.c" />
        [DllImport(GlfwNative.Library, EntryPoint = "glfwGetWaylandMonitor", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetWaylandMonitor(Monitor monitor);

        /// <summary>
        ///     Returns the pointer to the Wayland window for the specified window.
        /// </summary>
        /// <param name="window">A window instance.</param>
        /// <returns>A pointer to a Wayland window, or <see cref="IntPtr.Zero" /> if error occurred.</returns>
        [DllImport(GlfwNative.Library, EntryPoint = "glfwGetWaylandWindow", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetWaylandWindow(Window window);

        /// <summary>
        ///     Returns the pointer to the GLX window for the specified window.
        /// </summary>
        /// <param name="window">A window instance.</param>
        /// <returns>A pointer to a GLX window, or <see cref="IntPtr.Zero" /> if error occurred.</returns>
        [DllImport(GlfwNative.Library, EntryPoint = "glfwGetGLXWindow", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetGLXWindow(Window window);

        /// <summary>
        ///     Returns the pointer to the X11 window for the specified window.
        /// </summary>
        /// <param name="window">A window instance.</param>
        /// <returns>A pointer to an X11 window, or <see cref="IntPtr.Zero" /> if error occurred.</returns>
        [DllImport(GlfwNative.Library, EntryPoint = "glfwGetX11Window", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetX11Window(Window window);

        /// <summary>
        ///     Returns the RROutput of the specified monitor.
        /// </summary>
        /// <param name="monitor">The monitor to query.</param>
        /// <returns>The RROutput of the specified monitor, or <see cref="IntPtr.Zero" /> if an error occurred.</returns>
        [DllImport(GlfwNative.Library, EntryPoint = "glfwGetX11Monitor", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetX11Monitor(Monitor monitor);

        /// <summary>
        ///     Returns the RRCrtc of the specified monitor.
        /// </summary>
        /// <param name="monitor">The monitor to query.</param>
        /// <returns>The RRCrtc of the specified monitor, or <see cref="IntPtr.Zero" /> if an error occurred.</returns>
        [DllImport(GlfwNative.Library, EntryPoint = "glfwGetX11Adapter", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetX11Adapter(Monitor monitor);

        /// <summary>
        ///     Returns the pointer to the Cocoa window for the specified window.
        /// </summary>
        /// <param name="window">A window instance.</param>
        /// <returns>A pointer to a Cocoa window, or <see cref="IntPtr.Zero" /> if error occurred.</returns>
        [DllImport(GlfwNative.Library, EntryPoint = "glfwGetCocoaWindow", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetCocoaWindow(Window window);

        /// <summary>
        ///     Returns the NSOpenGLContext of the specified window.
        /// </summary>
        /// <param name="window">A window instance.</param>
        /// <returns>The NSOpenGLContext of the specified window, or <see cref="NSOpenGLContext.None" /> if an error occurred.</returns>
        [DllImport(GlfwNative.Library, EntryPoint = "glfwGetNSGLContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern NSOpenGLContext GetNSGLContext(Window window);

        /// <summary>
        ///     Returns the OSMesaContext of the specified window.
        /// </summary>
        /// <param name="window">A window instance.</param>
        /// <returns>The OSMesaContext of the specified window, or <see cref="OSMesaContext.None" /> if an error occurred.</returns>
        [DllImport(GlfwNative.Library, EntryPoint = "glfwGetOSMesaContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern OSMesaContext GetOSMesaContext(Window window);

        /// <summary>
        ///     Returns the GLXContext of the specified window.
        /// </summary>
        /// <param name="window">A window instance.</param>
        /// <returns>The GLXContext of the specified window, or <see cref="GLXContext.None" /> if an error occurred.</returns>
        [DllImport(GlfwNative.Library, EntryPoint = "glfwGetGLXContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern GLXContext GetGLXContext(Window window);

        /// <summary>
        ///     Returns the EGLContext of the specified window.
        /// </summary>
        /// <param name="window">A window instance.</param>
        /// <returns>The EGLContext of the specified window, or <see cref="EGLContext.None" /> if an error occurred.</returns>
        [DllImport(GlfwNative.Library, EntryPoint = "glfwGetEGLContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern EGLContext GetEglContext(Window window);

        /// <summary>
        ///     Returns the EGLDisplay used by GLFW.
        /// </summary>
        /// <returns>The EGLDisplay used by GLFW, or <see cref="EglDisplay.None" /> if an error occurred.</returns>
        [DllImport(GlfwNative.Library, EntryPoint = "glfwGetEGLDisplay", CallingConvention = CallingConvention.Cdecl)]
        public static extern EglDisplay GetEglDisplay();

        /// <summary>
        ///     Returns the <see cref="EglSurface" /> of the specified window
        /// </summary>
        /// <param name="window">A window instance.</param>
        /// <returns>The EGLSurface of the specified window, or <see cref="EglSurface.None" /> if an error occurred.</returns>
        [DllImport(GlfwNative.Library, EntryPoint = "glfwGetEGLSurface", CallingConvention = CallingConvention.Cdecl)]
        public static extern EglSurface GetEglSurface(Window window);

        /// <summary>
        ///     Returns the WGL context of the specified window.
        /// </summary>
        /// <param name="window">A window instance.</param>
        /// <returns>The WGL context of the specified window, or <see cref="EGLContext.None" /> if an error occurred.</returns>
        [DllImport(GlfwNative.Library, EntryPoint = "glfwGetWGLContext", CallingConvention = CallingConvention.Cdecl)]
        public static extern Hglrc GetWglContext(Window window);

        /// <summary>
        ///     Returns the HWND of the specified window.
        /// </summary>
        /// <param name="window">A window instance.</param>
        /// <returns>The HWND of the specified window, or <see cref="IntPtr.Zero" /> if an error occurred.</returns>
        [DllImport(GlfwNative.Library, EntryPoint = "glfwGetWin32Window", CallingConvention = CallingConvention.Cdecl)]
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
        [DllImport(GlfwNative.Library, EntryPoint = "glfwGetOSMesaColorBuffer", CallingConvention = CallingConvention.Cdecl)]
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
        [DllImport(GlfwNative.Library, EntryPoint = "glfwGetOSMesaDepthBuffer", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool
            GetOSMesaDepthBuffer(Window window, out int width, out int height, out int bytesPerValue,
                out IntPtr buffer);


        /// <summary>
        ///     Sets the x 11 selection string using the specified str
        /// </summary>
        /// <param name="str">The str</param>
        [DllImport(GlfwNative.Library, EntryPoint = "glfwSetX11SelectionString", CallingConvention = CallingConvention.Cdecl)]
        private static extern void SetX11SelectionString(byte[] str);

        /// <summary>
        ///     Gets the x 11 selection string internal
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(GlfwNative.Library, EntryPoint = "glfwGetX11SelectionString", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr GetX11SelectionStringInternal();

        /// <summary>
        ///     Gets the win 32 adapter internal using the specified monitor
        /// </summary>
        /// <param name="monitor">The monitor</param>
        /// <returns>The int ptr</returns>
        [DllImport(GlfwNative.Library, EntryPoint = "glfwGetWin32Adapter", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr GetWin32AdapterInternal(Monitor monitor);

        /// <summary>
        ///     Gets the win 32 monitor internal using the specified monitor
        /// </summary>
        /// <param name="monitor">The monitor</param>
        /// <returns>The int ptr</returns>
        [DllImport(GlfwNative.Library, EntryPoint = "glfwGetWin32Monitor", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr GetWin32MonitorInternal(Monitor monitor);


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
        

        /// <summary>
        ///     Gets a value indicating whether this instance is closing.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is closing; otherwise, <c>false</c>.
        /// </value>
        public bool IsClosing => GlfwNative.WindowShouldClose(Window);

        /// <summary>
        ///     Gets a value indicating whether this instance is decorated.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is decorated; otherwise, <c>false</c>.
        /// </value>
        public bool IsDecorated => GlfwNative.GetWindowAttribute(Window, WindowAttribute.Decorated);

        /// <summary>
        ///     Gets a value indicating whether this instance is floating (top-most, always-on-top).
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is floating; otherwise, <c>false</c>.
        /// </value>
        public bool IsFloating => GlfwNative.GetWindowAttribute(Window, WindowAttribute.Floating);

        /// <summary>
        ///     Gets a value indicating whether this instance is focused.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is focused; otherwise, <c>false</c>.
        /// </value>
        public bool IsFocused => GlfwNative.GetWindowAttribute(Window, WindowAttribute.Focused);

        /// <summary>
        ///     Gets a value indicating whether this instance is resizable.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is resizable; otherwise, <c>false</c>.
        /// </value>
        public bool IsResizable => GlfwNative.GetWindowAttribute(Window, WindowAttribute.Resizable);

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="NativeWindow" /> is maximized.
        ///     <para>Has no effect on fullscreen windows.</para>
        /// </summary>
        /// <value>
        ///     <c>true</c> if maximized; otherwise, <c>false</c>.
        /// </value>
        public bool Maximized
        {
            get => GlfwNative.GetWindowAttribute(Window, WindowAttribute.Maximized);
            set
            {
                if (value)
                {
                    GlfwNative.MaximizeWindow(Window);
                }
                else
                {
                    GlfwNative.RestoreWindow(Window);
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="NativeWindow" /> is minimized.
        ///     <para>If window is already minimized, does nothing.</para>
        /// </summary>
        /// <value>
        ///     <c>true</c> if minimized; otherwise, <c>false</c>.
        /// </value>
        public bool Minimized
        {
            get => GlfwNative.GetWindowAttribute(Window, WindowAttribute.AutoIconify);
            set
            {
                if (value)
                {
                    GlfwNative.IconifyWindow(Window);
                }
                else
                {
                    GlfwNative.RestoreWindow(Window);
                }
            }
        }

        /// <summary>
        ///     Gets the monitor this window is fullscreen on.
        ///     <para>Returns <see cref="Structs.Monitor.None" /> if window is not fullscreen.</para>
        /// </summary>
        /// <value>
        ///     The monitor.
        /// </value>
        public Monitor Monitor => GlfwNative.GetWindowMonitor(Window);

        /// <summary>
        ///     Gets or sets the mouse position in screen-coordinates relative to the client area of the window.
        /// </summary>
        /// <value>
        ///     The mouse position.
        /// </value>
        public Point MousePosition
        {
            get
            {
                GlfwNative.GetCursorPosition(Window, out double x, out double y);
                return new Point(Convert.ToInt32(x), Convert.ToInt32(y));
            }
            set => GlfwNative.SetCursorPosition(Window, value.X, value.Y);
        }

        /// <summary>
        ///     Gets or sets the position of the window in screen coordinates, including border, titlebar, etc..
        /// </summary>
        /// <value>
        ///     The position.
        /// </value>
        public Point Position
        {
            get
            {
                GlfwNative.GetWindowPosition(Window, out int x, out int y);
                GlfwNative.GetWindowFrameSize(Window, out int l, out int t, out int dummy1, out int dummy2);
                return new Point(x - l, y - t);
            }
            set
            {
                GlfwNative.GetWindowFrameSize(Window, out int l, out int t, out int dummy1, out int dummy2);
                GlfwNative.SetWindowPosition(Window, value.X + l, value.Y + t);
            }
        }

        /// <summary>
        ///     Gets or sets the size of the window, in screen coordinates, including border, titlebar, etc.
        /// </summary>
        /// <value>
        ///     A <see cref="System.Drawing.Size" /> in screen coordinates that represents the size of the window.
        /// </value>
        public Size Size
        {
            get
            {
                GlfwNative.GetWindowSize(Window, out int width, out int height);
                GlfwNative.GetWindowFrameSize(Window, out int l, out int t, out int r, out int b);
                return new Size(width + l + r, height + t + b);
            }
            set
            {
                GlfwNative.GetWindowFrameSize(Window, out int l, out int t, out int r, out int b);
                GlfwNative.SetWindowSize(Window, value.Width - l - r, value.Height - t - b);
            }
        }

        /// <summary>
        ///     Sets the sticky keys input mode.
        ///     <para>
        ///         Set to <c>true</c> to enable sticky keys, or <c>false</c> to disable it. If sticky keys are enabled, a key
        ///         press will ensure that <see cref="GlfwNative.GetKey" /> returns <see cref="InputState.Press" /> the next time it is
        ///         called even if the key had been released before the call. This is useful when you are only interested in
        ///         whether keys have been pressed but not when or in which order.
        ///     </para>
        /// </summary>
        public bool StickyKeys
        {
            get => GlfwNative.GetInputMode(Window, InputMode.StickyKeys) == (int) Constants.True;
            set =>
                GlfwNative.SetInputMode(Window, InputMode.StickyKeys, value ? (int) Constants.True : (int) Constants.False);
        }

        /// <summary>
        ///     Gets or sets the sticky mouse button input mode.
        ///     <para>
        ///         Set to <c>true</c> to enable sticky mouse buttons, or <c>false</c> to disable it. If sticky mouse buttons are
        ///         enabled, a mouse button press will ensure that <see cref="GlfwNative.GetMouseButton" /> returns
        ///         <see cref="InputState.Press" /> the next time it is called even if the mouse button had been released before
        ///         the call. This is useful when you are only interested in whether mouse buttons have been pressed but not when
        ///         or in which order.
        ///     </para>
        /// </summary>
        public bool StickyMouseButtons
        {
            get => GlfwNative.GetInputMode(Window, InputMode.StickyMouseButton) == (int) Constants.True;
            set =>
                GlfwNative.SetInputMode(Window, InputMode.StickyMouseButton,
                    value ? (int) Constants.True : (int) Constants.False);
        }

        /// <summary>
        ///     Gets or sets the window title or caption.
        /// </summary>
        /// <value>
        ///     The title.
        /// </value>

        public string Title
        {
            get => title;
            set
            {
                title = value;
                GlfwNative.SetWindowTitle(Window, value ?? string.Empty);
            }
        }

        /// <summary>
        ///     Gets or sets a user-defined pointer for GLFW to retain for this instance.
        /// </summary>
        /// <value>
        ///     The user-defined pointer.
        /// </value>
        public IntPtr UserPointer
        {
            get => GlfwNative.GetWindowUserPointer(Window);
            set => GlfwNative.SetWindowUserPointer(Window, value);
        }

        /// <summary>
        ///     Gets the video mode for the monitor this window is fullscreen on.
        ///     <para>If window is not fullscreen, returns the <see cref="Structs.VideoMode" /> for the primary monitor.</para>
        /// </summary>
        /// <value>
        ///     The video mode.
        /// </value>
        public VideoMode VideoMode
        {
            get
            {
                Monitor monitor = Monitor;
                return GlfwNative.GetVideoMode(monitor == Monitor.None ? GlfwNative.PrimaryMonitor : monitor);
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="NativeWindow" /> is visible.
        /// </summary>
        /// <value>
        ///     <c>true</c> if visible; otherwise, <c>false</c>.
        /// </value>
        public bool Visible
        {
            get => GlfwNative.GetWindowAttribute(Window, WindowAttribute.Visible);
            set
            {
                if (value)
                {
                    GlfwNative.ShowWindow(Window);
                }
                else
                {
                    GlfwNative.HideWindow(Window);
                }
            }
        }

        /// <summary>
        ///     Determines whether the specified <paramref name="window" /> is equal to this instance.
        /// </summary>
        /// <param name="window">A <see cref="NativeWindow" /> instance to compare for equality.</param>
        /// <returns><c>true</c> if objects represent the same window, otherwise <c>false</c>.</returns>
        public bool Equals(NativeWindow window)
        {
            if (ReferenceEquals(null, window))
            {
                return false;
            }

            return ReferenceEquals(this, window) || Window.Equals(window.Window);
        }

        /// <summary>
        ///     Raises the <see cref="Maximized" /> event.
        /// </summary>
        /// <param name="maximized">Flag indicating if window is being maximized or restored.</param>
        protected virtual void OnMaximizeChanged(bool maximized)
        {
            MaximizeChanged?.Invoke(this, new MaximizeEventArgs(maximized));
        }

        /// <summary>
        ///     Occurs when the content scale has been changed.
        /// </summary>
        public event EventHandler<ContentScaleEventArgs> ContentScaleChanged;

        /// <summary>
        ///     Raises the <see cref="ContentScaleChanged" /> event.
        /// </summary>
        /// <param name="xScale">The new scale on the x-axis.</param>
        /// <param name="yScale">The new scale on the y-axis.</param>
        protected virtual void OnContentScaleChanged(float xScale, float yScale)
        {
            ContentScaleChanged?.Invoke(this, new ContentScaleEventArgs(xScale, yScale));
        }

        /// <inheritdoc cref="Object.Equals(object)" />
        public override bool Equals(object obj) => ReferenceEquals(this, obj) || (obj is NativeWindow other && Equals(other));

        /// <inheritdoc cref="Object.GetHashCode" />
        public override int GetHashCode() => Window.GetHashCode();

        /// <summary>
        ///     Determines whether the specified window is equal to this instance.
        /// </summary>
        /// <param name="left">This instance.</param>
        /// <param name="right">A <see cref="NativeWindow" /> instance to compare for equality.</param>
        /// <returns><c>true</c> if objects represent the same window, otherwise <c>false</c>.</returns>
        public static bool operator ==(NativeWindow left, NativeWindow right) => Equals(left, right);

        /// <summary>
        ///     Determines whether the specified window is not equal to this instance.
        /// </summary>
        /// <param name="left">This instance.</param>
        /// <param name="right">A <see cref="NativeWindow" /> instance to compare for equality.</param>
        /// <returns><c>true</c> if objects do not represent the same window, otherwise <c>false</c>.</returns>
        public static bool operator !=(NativeWindow left, NativeWindow right) => !Equals(left, right);

        /// <summary>
        ///     Requests user-attention to this window on platforms that support it,
        ///     <para>
        ///         Once the user has given attention, usually by focusing the window or application, the system will end the
        ///         request automatically.
        ///     </para>
        /// </summary>
        public void RequestAttention()
        {
            GlfwNative.RequestWindowAttention(handle);
        }


        /// <summary>
        ///     Performs an implicit conversion from <see cref="NativeWindow" /> to <see cref="Structs.Window" />.
        /// </summary>
        /// <param name="nativeWindow">The game window.</param>
        /// <returns>
        ///     The result of the conversion.
        /// </returns>
        public static implicit operator Window(NativeWindow nativeWindow) => nativeWindow.Window;

        /// <summary>
        ///     Performs an implicit conversion from <see cref="NativeWindow" /> to <see cref="IntPtr" />.
        /// </summary>
        /// <param name="nativeWindow">The game window.</param>
        /// <returns>
        ///     The result of the conversion.
        /// </returns>
        public static implicit operator IntPtr(NativeWindow nativeWindow) => nativeWindow.Window;


        /// <summary>
        ///     Centers the on window on the screen.
        ///     <para>Has no effect on fullscreen or maximized windows.</para>
        /// </summary>
        public void CenterOnScreen()
        {
            if (Maximized)
            {
                return;
            }

            Monitor monitor = Monitor == Monitor.None ? GlfwNative.PrimaryMonitor : Monitor;
            VideoMode videoMode = GlfwNative.GetVideoMode(monitor);
            Size size = Size;
            Position = new Point((videoMode.Width - size.Width) / 2, (videoMode.Height - size.Height) / 2);
        }

        /// <summary>
        ///     Closes this instance.
        ///     <para>This invalidates the window, but does not free its resources.</para>
        /// </summary>
        public new void Close()
        {
            GlfwNative.SetWindowShouldClose(Window, true);
            OnClosing();
            base.Close();
        }

        /// <summary>
        ///     Focuses this form to receive input and events.
        /// </summary>
        public void Focus()
        {
            GlfwNative.FocusWindow(Window);
        }

        /// <summary>
        ///     Sets the window fullscreen on the primary monitor.
        /// </summary>
        public void Fullscreen()
        {
            Fullscreen(GlfwNative.PrimaryMonitor);
        }

        /// <summary>
        ///     Sets the window fullscreen on the specified monitor.
        /// </summary>
        /// <param name="monitor">The monitor to display the window fullscreen.</param>
        public void Fullscreen(Monitor monitor)
        {
            GlfwNative.SetWindowMonitor(Window, monitor, 0, 0, 0, 0, -1);
        }

        /// <summary>
        ///     Makes window and its context the current.
        /// </summary>
        public void MakeCurrent()
        {
            GlfwNative.MakeContextCurrent(Window);
        }

        /// <summary>
        ///     Maximizes this window to fill the screen.
        ///     <para>Has no effect if window is already maximized.</para>
        /// </summary>
        public void Maximize()
        {
            GlfwNative.MaximizeWindow(Window);
        }

        /// <summary>
        ///     Minimizes this window.
        ///     <para>Has no effect if window is already minimized.</para>
        /// </summary>
        public void Minimize()
        {
            GlfwNative.IconifyWindow(Window);
        }

        /// <summary>
        ///     Restores a minimized window to its previous state.
        ///     <para>Has no effect if window was already restored.</para>
        /// </summary>
        public void Restore()
        {
            GlfwNative.RestoreWindow(Window);
        }

        /// <summary>
        ///     Sets the aspect ratio to maintain for the window.
        ///     <para>This function is ignored for fullscreen windows.</para>
        /// </summary>
        /// <param name="numerator">The numerator of the desired aspect ratio.</param>
        /// <param name="denominator">The denominator of the desired aspect ratio.</param>
        public void SetAspectRatio(int numerator, int denominator)
        {
            GlfwNative.SetWindowAspectRatio(Window, numerator, denominator);
        }

        /// <summary>
        ///     Sets the icon(s) used for the titlebar, taskbar, etc.
        ///     <para>Standard sizes are 16x16, 32x32, and 48x48.</para>
        /// </summary>
        /// <param name="images">One or more images to set as an icon.</param>
        public void SetIcons(params Image[] images)
        {
            GlfwNative.SetWindowIcon(Window, images.Length, images);
        }

        /// <summary>
        ///     Sets the window monitor.
        ///     <para>
        ///         If <paramref name="monitor" /> is not <see cref="Structs.Monitor.None" />, the window will be full-screened and
        ///         dimensions ignored.
        ///     </para>
        /// </summary>
        /// <param name="monitor">The desired monitor, or <see cref="Structs.Monitor.None" /> to set windowed mode.</param>
        /// <param name="x">The desired x-coordinate of the upper-left corner of the client area.</param>
        /// <param name="y">The desired y-coordinate of the upper-left corner of the client area.</param>
        /// <param name="width">The desired width, in screen coordinates, of the client area or video mode.</param>
        /// <param name="height">The desired height, in screen coordinates, of the client area or video mode.</param>
        /// <param name="refreshRate">The desired refresh rate, in Hz, of the video mode, or <see cref="Constants.Default" />.</param>
        public void SetMonitor(Monitor monitor, int x, int y, int width, int height,
            int refreshRate = (int) Constants.Default)
        {
            GlfwNative.SetWindowMonitor(Window, monitor, x, y, width, height, refreshRate);
        }

        /// <summary>
        ///     Sets the limits of the client size  area of the window.
        /// </summary>
        /// <param name="minSize">The minimum size of the client area.</param>
        /// <param name="maxSize">The maximum size of the client area.</param>
        public void SetSizeLimits(Size minSize, Size maxSize)
        {
            SetSizeLimits(minSize.Width, minSize.Height, maxSize.Width, maxSize.Height);
        }

        /// <summary>
        ///     Sets the limits of the client size  area of the window.
        /// </summary>
        /// <param name="minWidth">The minimum width of the client area.</param>
        /// <param name="minHeight">The minimum height of the client area.</param>
        /// <param name="maxWidth">The maximum width of the client area.</param>
        /// <param name="maxHeight">The maximum height of the client area.</param>
        public void SetSizeLimits(int minWidth, int minHeight, int maxWidth, int maxHeight)
        {
            GlfwNative.SetWindowSizeLimits(Window, minWidth, minHeight, maxWidth, maxHeight);
        }

        /// <summary>
        ///     Swaps the front and back buffers when rendering with OpenGL or OpenGL ES.
        ///     <para>
        ///         This should not be called on a window that is not using an OpenGL or OpenGL ES context (.i.e. Vulkan).
        ///     </para>
        /// </summary>
        public void SwapBuffers()
        {
            GlfwNative.SwapBuffers(Window);
        }

        /// <summary>
        ///     Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">
        ///     <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only
        ///     unmanaged resources.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            Disposed?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        ///     Releases the internal GLFW handle.
        /// </summary>
        /// <returns><c>true</c> if handle was released successfully, otherwise <c>false</c>.</returns>
        protected override bool ReleaseHandle()
        {
            try
            {
                GlfwNative.DestroyWindow(Window);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        ///     Binds the callbacks
        /// </summary>
        private void BindCallbacks()
        {
            windowPositionCallback = (_, x, y) => OnPositionChanged(x, y);
            windowSizeCallback = (_, w, h) => OnSizeChanged(w, h);
            windowFocusCallback = (_, focusing) => OnFocusChanged(focusing);
            closeCallback = _ => OnClosing();
            dropCallback = (_, count, arrayPtr) => OnFileDrop(count, arrayPtr);
            cursorPositionCallback = (_, x, y) => OnMouseMove(x, y);
            cursorEnterCallback = (_, entering) => OnMouseEnter(entering);
            mouseButtonCallback = (_, button, state, mod) => OnMouseButton(button, state, mod);
            scrollCallback = (_, x, y) => OnMouseScroll(x, y);
            charModsCallback = (_, cp, mods) => OnCharacterInput(cp, mods);
            framebufferSizeCallback = (_, w, h) => OnFramebufferSizeChanged(w, h);
            windowRefreshCallback = _ => Refreshed?.Invoke(this, EventArgs.Empty);
            keyCallback = (_, key, code, state, mods) => OnKey(key, code, state, mods);
            windowMaximizeCallback = (_, maximized) => OnMaximizeChanged(maximized);
            windowContentScaleCallback = (_, x, y) => OnContentScaleChanged(x, y);

            GlfwNative.SetWindowPositionCallback(Window, windowPositionCallback);
            GlfwNative.SetWindowSizeCallback(Window, windowSizeCallback);
            GlfwNative.SetWindowFocusCallback(Window, windowFocusCallback);
            GlfwNative.SetCloseCallback(Window, closeCallback);
            GlfwNative.SetDropCallback(Window, dropCallback);
            GlfwNative.SetCursorPositionCallback(Window, cursorPositionCallback);
            GlfwNative.SetCursorEnterCallback(Window, cursorEnterCallback);
            GlfwNative.SetMouseButtonCallback(Window, mouseButtonCallback);
            GlfwNative.SetScrollCallback(Window, scrollCallback);
            GlfwNative.SetCharModsCallback(Window, charModsCallback);
            GlfwNative.SetFramebufferSizeCallback(Window, framebufferSizeCallback);
            GlfwNative.SetWindowRefreshCallback(Window, windowRefreshCallback);
            GlfwNative.SetKeyCallback(Window, keyCallback);
            GlfwNative.SetWindowMaximizeCallback(Window, windowMaximizeCallback);
            GlfwNative.SetWindowContentScaleCallback(Window, windowContentScaleCallback);
        }

        /// <summary>
        ///     Ons the file drop using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        /// <param name="pointer">The pointer</param>
        private void OnFileDrop(int count, IntPtr pointer)
        {
            string[] paths = new string[count];
            int offset = 0;
            for (int i = 0; i < count; i++, offset += IntPtr.Size)
            {
                IntPtr ptr = Marshal.ReadIntPtr(pointer + offset);
                paths[i] = Util.PtrToStringUTF8(ptr);
            }

            OnFileDrop(paths);
        }


        /// <summary>
        ///     Occurs when the window is maximized or restored.
        /// </summary>
        public event EventHandler<MaximizeEventArgs> MaximizeChanged;

        /// <summary>
        ///     Occurs when the window receives character input.
        /// </summary>
        public event EventHandler<CharEventArgs> CharacterInput;

        /// <summary>
        ///     Occurs when the window is closed.
        /// </summary>
        public event EventHandler Closed;

        /// <summary>
        ///     Occurs when the form is closing, and provides subscribers means of canceling the action..
        /// </summary>
        public event CancelEventHandler Closing;

        /// <summary>
        ///     Occurs when the window is disposed.
        /// </summary>
        public event EventHandler Disposed;

        /// <summary>
        ///     Occurs when files are dropped onto the window client area with a drag-drop event.
        /// </summary>
        public event EventHandler<FileDropEventArgs> FileDrop;

        /// <summary>
        ///     Occurs when the window gains or loses focus.
        /// </summary>
        public event EventHandler FocusChanged;

        /// <summary>
        ///     Occurs when the size of the internal framebuffer is changed.
        /// </summary>
        public event EventHandler<SizeChangeEventArgs> FramebufferSizeChanged;

        /// <summary>
        ///     Occurs when a key is pressed, released, or repeated.
        /// </summary>
        public event EventHandler<KeyEventArgs> KeyAction;

        /// <summary>
        ///     Occurs when a key is pressed.
        /// </summary>
        public event EventHandler<KeyEventArgs> KeyPress;

        /// <summary>
        ///     Occurs when a key is released.
        /// </summary>
        public event EventHandler<KeyEventArgs> KeyRelease;

        /// <summary>
        ///     Occurs when a key is held long enough to raise a repeat event.
        /// </summary>
        public event EventHandler<KeyEventArgs> KeyRepeat;

        /// <summary>
        ///     Occurs when a mouse button is pressed or released.
        /// </summary>
        public event EventHandler<MouseButtonEventArgs> MouseButton;

        /// <summary>
        ///     Occurs when the mouse cursor enters the client area of the window.
        /// </summary>
        public event EventHandler MouseEnter;

        /// <summary>
        ///     Occurs when the mouse cursor leaves the client area of the window.
        /// </summary>
        public event EventHandler MouseLeave;

        /// <summary>
        ///     Occurs when mouse cursor is moved.
        /// </summary>
        public event EventHandler<MouseMoveEventArgs> MouseMoved;

        /// <summary>
        ///     Occurs when mouse is scrolled.
        /// </summary>
        public event EventHandler<MouseMoveEventArgs> MouseScroll;

        /// <summary>
        ///     Occurs when position of the <see cref="NativeWindow" /> is changed.
        /// </summary>
        public event EventHandler PositionChanged;

        /// <summary>
        ///     Occurs when window is refreshed.
        /// </summary>
        public event EventHandler Refreshed;

        /// <summary>
        ///     Occurs when size of the <see cref="NativeWindow" /> is changed.
        /// </summary>
        public event EventHandler<SizeChangeEventArgs> SizeChanged;

        /// <summary>
        ///     Raises the <see cref="CharacterInput" /> event.
        /// </summary>
        /// <param name="codePoint">The Unicode code point.</param>
        /// <param name="mods">The modifier keys present.</param>
        protected virtual void OnCharacterInput(uint codePoint, ModifierKeys mods)
        {
            CharacterInput?.Invoke(this, new CharEventArgs(codePoint, mods));
        }

        /// <summary>
        ///     Raises the <see cref="Closed" /> event.
        /// </summary>
        protected virtual void OnClosed()
        {
            Closed?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        ///     Raises the <see cref="Closing" /> event.
        /// </summary>
        protected virtual void OnClosing()
        {
            CancelEventArgs args = new CancelEventArgs();
            Closing?.Invoke(this, args);
            if (args.Cancel)
            {
                GlfwNative.SetWindowShouldClose(Window, false);
            }
            else
            {
                base.Close();
                OnClosed();
            }
        }

        /// <summary>
        ///     Raises the <see cref="FileDrop" /> event.
        /// </summary>
        /// <param name="paths">The filenames of the dropped files.</param>
        protected virtual void OnFileDrop(string[] paths)
        {
            FileDrop?.Invoke(this, new FileDropEventArgs(paths));
        }

        /// <summary>
        ///     Raises the <see cref="FocusChanged" /> event.
        /// </summary>
        /// <param name="focusing"><c>true</c> if window is gaining focus, otherwise <c>false</c>.</param>
        // ReSharper disable once UnusedParameter.Global
        protected virtual void OnFocusChanged(bool focusing)
        {
            FocusChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        ///     Raises the <see cref="FramebufferSizeChanged" /> event.
        /// </summary>
        /// <param name="width">The new width.</param>
        /// <param name="height">The new height.</param>
        protected virtual void OnFramebufferSizeChanged(int width, int height)
        {
            FramebufferSizeChanged?.Invoke(this, new SizeChangeEventArgs(new Size(width, height)));
        }

        /// <summary>
        ///     Raises the appropriate key events.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="scanCode">The scan code.</param>
        /// <param name="state">The state of the key.</param>
        /// <param name="mods">The modifier keys.</param>
        /// <seealso cref="KeyPress" />
        /// <seealso cref="KeyRelease" />
        /// <seealso cref="KeyRepeat" />
        /// <seealso cref="KeyAction" />
        protected virtual void OnKey(Keys key, int scanCode, InputState state, ModifierKeys mods)
        {
            KeyEventArgs args = new KeyEventArgs(key, scanCode, state, mods);
            if (state.HasFlag(InputState.Press))
            {
                KeyPress?.Invoke(this, args);
            }
            else if (state.HasFlag(InputState.Release))
            {
                KeyRelease?.Invoke(this, args);
            }
            else
            {
                KeyRepeat?.Invoke(this, args);
            }

            KeyAction?.Invoke(this, args);
        }

        /// <summary>
        ///     Raises the <see cref="MouseButton" /> event.
        /// </summary>
        /// <param name="button">The mouse button.</param>
        /// <param name="state">The state of the mouse button.</param>
        /// <param name="modifiers">The modifier keys.</param>
        protected virtual void OnMouseButton(MouseButton button, InputState state, ModifierKeys modifiers)
        {
            MouseButton?.Invoke(this, new MouseButtonEventArgs(button, state, modifiers));
        }

        /// <summary>
        ///     Raises the <see cref="MouseEnter" /> and <see cref="MouseLeave" /> events.
        /// </summary>
        /// <param name="entering"><c>true</c> if mouse is entering window, otherwise <c>false</c> if it is leaving.</param>
        protected virtual void OnMouseEnter(bool entering)
        {
            if (entering)
            {
                MouseEnter?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MouseLeave?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        ///     Raises the <see cref="MouseMoved" /> event.
        /// </summary>
        /// <param name="x">The new x-coordinate of the mouse.</param>
        /// <param name="y">The new y-coordinate of the mouse.</param>
        protected virtual void OnMouseMove(double x, double y)
        {
            MouseMoved?.Invoke(this, new MouseMoveEventArgs(x, y));
        }

        /// <summary>
        ///     Raises the <see cref="MouseScroll" /> event.
        /// </summary>
        /// <param name="x">The amount of the scroll on the x-axis.</param>
        /// <param name="y">The amount of the scroll on the y-axis.</param>
        protected virtual void OnMouseScroll(double x, double y)
        {
            MouseScroll?.Invoke(this, new MouseMoveEventArgs(x, y));
        }

        /// <summary>
        ///     Raises the <see cref="PositionChanged" /> event.
        /// </summary>
        /// <param name="x">The new position on the x-axis.</param>
        /// <param name="y">The new position on the y-axis.</param>
        [SuppressMessage("ReSharper", "UnusedParameter.Global")]
        protected virtual void OnPositionChanged(double x, double y)
        {
            PositionChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        ///     Raises the <see cref="SizeChanged" /> event.
        /// </summary>
        /// <param name="width">The new width.</param>
        /// <param name="height">The new height.</param>
        protected virtual void OnSizeChanged(int width, int height)
        {
            SizeChanged?.Invoke(this, new SizeChangeEventArgs(new Size(width, height)));
        }
    }
}