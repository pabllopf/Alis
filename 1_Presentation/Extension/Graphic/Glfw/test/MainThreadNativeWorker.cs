// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MainThreadNativeWorker.cs
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Glfw.Enums;
using Alis.Extension.Graphic.Glfw.Structs;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Executes the <see cref="NativeWindow" /> wrapper members against the real native GLFW library on the process
    ///     main thread, because GLFW on macOS creates windows on the main thread and AppKit requires window operations to
    ///     be performed there. The startup hook invokes <see cref="Run" /> before the entry point; every step records its
    ///     result so the xUnit tests can assert the observed behavior afterwards.
    /// </summary>
    public static class MainThreadNativeWorker
    {
        /// <summary>
        ///     The failures collected while executing the native steps on the main thread.
        /// </summary>
        internal static readonly List<Exception> Failures = new List<Exception>();

        /// <summary>
        ///     The read back bounds value.
        /// </summary>
        internal static Rectangle BoundsResult;

        /// <summary>
        ///     The read back client bounds value.
        /// </summary>
        internal static Rectangle ClientBoundsResult;

        /// <summary>
        ///     The read back client width after setting the client bounds.
        /// </summary>
        internal static int ClientBoundsWidthResult;

        /// <summary>
        ///     The read back client height after setting the client bounds.
        /// </summary>
        internal static int ClientBoundsHeightResult;

        /// <summary>
        ///     The read back client width after setting it directly.
        /// </summary>
        internal static int ClientWidthResult;

        /// <summary>
        ///     The read back client height after setting it directly.
        /// </summary>
        internal static int ClientHeightResult;

        /// <summary>
        ///     The read back client size value.
        /// </summary>
        internal static Size ClientSizeResult;

        /// <summary>
        ///     The read back clipboard value.
        /// </summary>
        internal static string ClipboardResult;

        /// <summary>
        ///     The read back cursor mode after applying the hidden mode.
        /// </summary>
        internal static CursorMode CursorModeHiddenResult;

        /// <summary>
        ///     The read back cursor mode after applying the disabled mode.
        /// </summary>
        internal static CursorMode CursorModeDisabledResult;

        /// <summary>
        ///     The read back cursor mode after applying the normal mode.
        /// </summary>
        internal static CursorMode CursorModeNormalResult;

        /// <summary>
        ///     The read back maximized value after setting it to true.
        /// </summary>
        internal static bool MaximizedOnResult;

        /// <summary>
        ///     The read back maximized value after setting it to false.
        /// </summary>
        internal static bool MaximizedOffResult;

        /// <summary>
        ///     The read back minimized value after setting it to true.
        /// </summary>
        internal static bool MinimizedOnResult;

        /// <summary>
        ///     The read back minimized value after setting it to false.
        /// </summary>
        internal static bool MinimizedOffResult;

        /// <summary>
        ///     The read back mouse position value.
        /// </summary>
        internal static Point MousePositionResult;

        /// <summary>
        ///     The read back window position value.
        /// </summary>
        internal static Point PositionResult;

        /// <summary>
        ///     The read back window size value.
        /// </summary>
        internal static Size SizeResult;

        /// <summary>
        ///     The read back sticky keys value after enabling it.
        /// </summary>
        internal static bool StickyKeysOnResult;

        /// <summary>
        ///     The read back sticky keys value after disabling it.
        /// </summary>
        internal static bool StickyKeysOffResult;

        /// <summary>
        ///     The read back sticky mouse button value after enabling it.
        /// </summary>
        internal static bool StickyMouseButtonsOnResult;

        /// <summary>
        ///     The read back sticky mouse button value after disabling it.
        /// </summary>
        internal static bool StickyMouseButtonsOffResult;

        /// <summary>
        ///     The read back title value.
        /// </summary>
        internal static string TitleResult;

        /// <summary>
        ///     The read back user pointer value.
        /// </summary>
        internal static IntPtr UserPointerResult;

        /// <summary>
        ///     The read back visible value after setting it to true.
        /// </summary>
        internal static bool VisibleOnResult;

        /// <summary>
        ///     The read back visible value after setting it to false.
        /// </summary>
        internal static bool VisibleOffResult;

        /// <summary>
        ///     The content scale value read from the live window.
        /// </summary>
        internal static PointF ContentScaleResult;

        /// <summary>
        ///     The handle value read from the live window.
        /// </summary>
        internal static IntPtr HandleResult;

        /// <summary>
        ///     The video mode width read from the live window.
        /// </summary>
        internal static int VideoModeWidthResult;

        /// <summary>
        ///     The video mode height read from the live window.
        /// </summary>
        internal static int VideoModeHeightResult;

        /// <summary>
        ///     The hwnd value returned on macOS.
        /// </summary>
        internal static IntPtr HwndResult;

        /// <summary>
        ///     Indicates whether setting the client width to zero threw an argument exception.
        /// </summary>
        internal static bool ClientWidthZeroThrows;

        /// <summary>
        ///     Indicates whether setting the client height to zero threw an argument exception.
        /// </summary>
        internal static bool ClientHeightZeroThrows;

        /// <summary>
        ///     Indicates whether setting the icons throws the interop exception.
        /// </summary>
        internal static bool IconsThrowsInteropException;

        /// <summary>
        ///     The cocoa monitor identifier of the primary monitor.
        /// </summary>
        internal static uint CocoaMonitorResult;

        /// <summary>
        ///     The cocoa window pointer of the shared window.
        /// </summary>
        internal static IntPtr CocoaWindowResult;

        /// <summary>
        ///     The cocoa GL context of the shared window.
        /// </summary>
        internal static NSOpenGLContext NsglContextResult;

        /// <summary>
        ///     The osmesa color buffer availability.
        /// </summary>
        internal static bool OsmesaColorBufferResult;

        /// <summary>
        ///     The osmesa depth buffer availability.
        /// </summary>
        internal static bool OsmesaDepthBufferResult;

        /// <summary>
        ///     Indicates whether the closing event could cancel the close.
        /// </summary>
        internal static bool ClosingCancelWorks;

        /// <summary>
        ///     Indicates whether the X11 selection methods threw the missing entry point exception on macOS.
        /// </summary>
        internal static bool X11SelectionThrows;

        /// <summary>
        ///     Indicates whether the Win32 query methods threw the missing entry point exception on macOS.
        /// </summary>
        internal static bool Win32QueriesThrows;

        /// <summary>
        ///     Indicates whether the default constructor produced a valid window handle.
        /// </summary>
        internal static bool DefaultCtorValidHandle;

        /// <summary>
        ///     Indicates whether the second window reported closed after the close call.
        /// </summary>
        internal static bool CloseWindowClosed;

        /// <summary>
        ///     Indicates whether the double dispose was safe.
        /// </summary>
        internal static bool DisposeTwiceSafe;

        /// <summary>
        ///     Indicates whether the last created window equals the shared one when comparing native handles.
        /// </summary>
        internal static bool ExtraWindowEqualsShared;

        /// <summary>
        ///     Runs every native step on the main thread and records the results.
        /// </summary>
        public static void Run()
        {
            if (!GlfwTestBootstrap.Ready || GlfwTestBootstrap.Window == null)
            {
                return;
            }

            NativeWindow window = GlfwTestBootstrap.Window;
            TestableNativeWindow testable = (TestableNativeWindow) window;
            Rectangle bounds = new Rectangle(11, 13, 320, 200);
            Execute("Bounds", () =>
            {
                window.Bounds = bounds;
                BoundsResult = window.Bounds;
            });
            Execute("ClientBounds", () =>
            {
                window.ClientBounds = new Rectangle(20, 20, 300, 180);
                ClientBoundsResult = window.ClientBounds;
                ClientBoundsWidthResult = window.ClientWidth;
                ClientBoundsHeightResult = window.ClientHeight;
            });
            Execute("ClientWidth", () =>
            {
                window.ClientWidth = 240;
                ClientWidthResult = window.ClientWidth;
            });
            Execute("ClientHeight", () =>
            {
                window.ClientHeight = 160;
                ClientHeightResult = window.ClientHeight;
            });
            Execute("ClientSize", () =>
            {
                window.ClientSize = new Size(280, 170);
                ClientSizeResult = window.ClientSize;
            });
            Execute("Clipboard", () =>
            {
                window.Clipboard = "alis-clip";
                ClipboardResult = window.Clipboard;
            });
            Execute("CursorMode", () =>
            {
                window.CursorMode = CursorMode.Hidden;
                CursorModeHiddenResult = window.CursorMode;
                window.CursorMode = CursorMode.Disabled;
                CursorModeDisabledResult = window.CursorMode;
                window.CursorMode = CursorMode.Normal;
                CursorModeNormalResult = window.CursorMode;
            });
            Execute("Maximized", () =>
            {
                window.Maximized = true;
                MaximizedOnResult = window.Maximized;
                window.Maximized = false;
                MaximizedOffResult = window.Maximized;
            });
            Execute("Minimized", () =>
            {
                window.Minimized = true;
                MinimizedOnResult = window.Minimized;
                window.Minimized = false;
                MinimizedOffResult = window.Minimized;
            });
            Execute("VisibleOn", () =>
            {
                window.Visible = true;
                VisibleOnResult = window.Visible;
            });
            Execute("Focus", () => window.Focus());
            Execute("MousePosition", () =>
            {
                window.MousePosition = new Point(111, 77);
                MousePositionResult = window.MousePosition;
            });
            Execute("Position", () =>
            {
                window.Position = new Point(101, 71);
                PositionResult = window.Position;
            });
            Execute("Size", () =>
            {
                window.Size = new Size(360, 240);
                SizeResult = window.Size;
            });
            Execute("StickyKeys", () =>
            {
                window.StickyKeys = true;
                StickyKeysOnResult = window.StickyKeys;
                window.StickyKeys = false;
                StickyKeysOffResult = window.StickyKeys;
            });
            Execute("StickyMouseButtons", () =>
            {
                window.StickyMouseButtons = true;
                StickyMouseButtonsOnResult = window.StickyMouseButtons;
                window.StickyMouseButtons = false;
                StickyMouseButtonsOffResult = window.StickyMouseButtons;
            });
            Execute("Title", () =>
            {
                window.Title = "exec-title";
                TitleResult = window.Title;
            });
            Execute("UserPointer", () =>
            {
                IntPtr pointer = new IntPtr(0x7B);
                window.UserPointer = pointer;
                UserPointerResult = window.UserPointer;
            });
            Execute("SizeLimits", () =>
            {
                window.SetSizeLimits(0, 0, (int) Constants.Default, (int) Constants.Default);
                window.SetSizeLimits(new Size(0, 0), new Size((int) Constants.Default, (int) Constants.Default));
            });
            Execute("AspectRatio", () => window.SetAspectRatio(1, 1));
            Execute("Icons", () =>
            {
                try
                {
                    window.SetIcons();
                }
                catch (MarshalDirectiveException)
                {
                    IconsThrowsInteropException = true;
                }
            });
            Execute("CenterOnScreen", () => window.CenterOnScreen());
            Execute("CenterOnScreenMaximized", () =>
            {
                window.Maximized = true;
                try
                {
                    window.CenterOnScreen();
                }
                finally
                {
                    window.Maximized = false;
                }
            });
            Execute("X11Selection", () =>
            {
                try
                {
                    NativeWindow.GetX11SelectionString();
                }
                catch (EntryPointNotFoundException)
                {
                    X11SelectionThrows = true;
                }

                try
                {
                    NativeWindow.SetX11SelectionString("alis");
                }
                catch (EntryPointNotFoundException)
                {
                    X11SelectionThrows = true;
                }
            });
            Execute("Win32Queries", () =>
            {
                try
                {
                    NativeWindow.GetWin32Adapter(GlfwTestBootstrap.PrimaryMonitor);
                }
                catch (EntryPointNotFoundException)
                {
                    Win32QueriesThrows = true;
                }

                try
                {
                    NativeWindow.GetWin32Monitor(GlfwTestBootstrap.PrimaryMonitor);
                }
                catch (EntryPointNotFoundException)
                {
                    Win32QueriesThrows = true;
                }
            });
            Execute("MakeCurrent", () => window.MakeCurrent());
            Execute("SwapBuffers", () => window.SwapBuffers());
            Execute("MaximizeMinimizeRestore", () =>
            {
                window.Maximize();
                window.Restore();
                window.Minimize();
                window.Restore();
            });
            Execute("RequestAttention", () => window.RequestAttention());
            Execute("SetMonitorWindowed", () => window.SetMonitor(Monitor.None, 64, 64, 320, 200, (int) Constants.Default));
            Execute("FullscreenWindowed", () => window.Fullscreen(Monitor.None));
            Execute("FullscreenPrimary", () =>
            {
                window.Fullscreen();
                window.Fullscreen(Monitor.None);
            });
            Execute("Hwnd", () => HwndResult = window.Hwnd);
            Execute("Throws", () =>
            {
                try
                {
                    window.ClientWidth = 0;
                }
                catch (ArgumentOutOfRangeException)
                {
                    ClientWidthZeroThrows = true;
                }

                try
                {
                    window.ClientHeight = 0;
                }
                catch (ArgumentOutOfRangeException)
                {
                    ClientHeightZeroThrows = true;
                }
            });
            Execute("ContentScale", () => ContentScaleResult = window.ContentScale);
            Execute("Handle", () => HandleResult = window.Handle);
            Execute("VideoMode", () =>
            {
                VideoMode mode = window.VideoMode;
                VideoModeWidthResult = mode.Width;
                VideoModeHeightResult = mode.Height;
            });
            Execute("ClosingCancel", () =>
            {
                bool raised = false;
                CancelEventHandler handler = (object sender, CancelEventArgs args) =>
                {
                    raised = true;
                    args.Cancel = true;
                };
                testable.Closing += handler;
                try
                {
                    testable.FireOnClosing();
                }
                finally
                {
                    testable.Closing -= handler;
                }

                ClosingCancelWorks = raised && !window.IsClosing;
            });
            Execute("Externs", () =>
            {
                CocoaMonitorResult = NativeWindow.GetCocoaMonitor(GlfwTestBootstrap.PrimaryMonitor);
                CocoaWindowResult = NativeWindow.GetCocoaWindow(testable.UnderlyingWindow);
                NsglContextResult = NativeWindow.GetNSGLContext(testable.UnderlyingWindow);
                NativeWindow.GetOSMesaContext(testable.UnderlyingWindow);
                NativeWindow.GetEglContext(testable.UnderlyingWindow);
                NativeWindow.GetEglDisplay();
                NativeWindow.GetEglSurface(testable.UnderlyingWindow);
                OsmesaColorBufferResult = NativeWindow.GetOSMesaColorBuffer(testable.UnderlyingWindow, out int width,
                    out int height, out int format, out IntPtr buffer);
                OsmesaDepthBufferResult = NativeWindow.GetOSMesaDepthBuffer(testable.UnderlyingWindow, out width,
                    out height, out format, out buffer);
            });
            Execute("DefaultCtor", () =>
            {
                NativeWindow nativeWindow = new NativeWindow();
                try
                {
                    DefaultCtorValidHandle = nativeWindow.Handle != IntPtr.Zero;
                }
                finally
                {
                    nativeWindow.Dispose();
                }
            });
            Execute("ExtraWindow", () =>
            {
                NativeWindow extra = new NativeWindow(64, 64, "exec-close");
                ExtraWindowEqualsShared = extra.Equals(window);
                extra.Close();
                CloseWindowClosed = extra.IsClosed;
                extra.Dispose();
                extra.Dispose();
                DisposeTwiceSafe = true;
            });
            Execute("VisibleOff", () =>
            {
                window.Visible = false;
                VisibleOffResult = window.Visible;
            });
        }

        /// <summary>
        ///     Executes the specified void action and records any exception.
        /// </summary>
        /// <param name="name">The step name.</param>
        /// <param name="action">The action to execute.</param>
        private static void Execute(string name, Action action)
        {
            try
            {
                action();
            }
            catch (Exception exception)
            {
                Failures.Add(new Exception(name, exception));
            }
        }
    }
}
