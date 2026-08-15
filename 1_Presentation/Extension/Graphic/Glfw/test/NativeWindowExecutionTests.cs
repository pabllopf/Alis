// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NativeWindowExecutionTests.cs
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
using System.Drawing;
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Glfw.Enums;
using Alis.Extension.Graphic.Glfw.Structs;
using Alis.Extension.Graphic.Glfw.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Verifies the <see cref="NativeWindow" /> wrapper members against the real native GLFW library. The native
    ///     calls execute on the process main thread inside <see cref="MainThreadNativeWorker" /> because GLFW on macOS
    ///     requires the main thread for window operations; the tests assert the recorded results and re-read the live
    ///     window with thread-safe getters. Tests are harmless no-ops when the startup hook was not installed
    ///     (<see cref="GlfwTestBootstrap.Ready" /> is false on CI).
    /// </summary>
    public class NativeWindowExecutionTests
    {
        /// <summary>
        ///     Tests that every native step executed on the main thread completed without an exception.
        /// </summary>
        [RequireGlfwFact]
        public void WorkerSteps_AllSucceeded()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.Empty(MainThreadNativeWorker.Failures);
        }

        /// <summary>
        ///     Tests that the bounds round trip preserves the set value.
        /// </summary>
        [RequireGlfwFact]
        public void Bounds_GetSet_RoundTrips()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.Equal(new Rectangle(11, 13, 320, 200), MainThreadNativeWorker.BoundsResult);
        }

        /// <summary>
        ///     Tests that the client bounds setter applied the requested content size.
        /// </summary>
        [RequireGlfwFact]
        public void ClientBounds_SetThenRead_ContentSizeMatches()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.Equal(300, MainThreadNativeWorker.ClientBoundsWidthResult);
            Assert.Equal(180, MainThreadNativeWorker.ClientBoundsHeightResult);
        }

        /// <summary>
        ///     Tests that the client bounds read back keeps the content dimensions.
        /// </summary>
        [RequireGlfwFact]
        public void ClientBounds_Get_ReturnsContentDimensions()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Rectangle bounds = MainThreadNativeWorker.ClientBoundsResult;
            Assert.Equal(300, bounds.Width);
            Assert.Equal(180, bounds.Height);
        }

        /// <summary>
        ///     Tests that the client width round trip preserves the set value.
        /// </summary>
        [RequireGlfwFact]
        public void ClientWidth_GetSet_RoundTrips()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.Equal(240, MainThreadNativeWorker.ClientWidthResult);
            Assert.True(MainThreadNativeWorker.ClientWidthZeroThrows);
        }

        /// <summary>
        ///     Tests that the client height round trip preserves the set value.
        /// </summary>
        [RequireGlfwFact]
        public void ClientHeight_GetSet_RoundTrips()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.Equal(160, MainThreadNativeWorker.ClientHeightResult);
            Assert.True(MainThreadNativeWorker.ClientHeightZeroThrows);
        }

        /// <summary>
        ///     Tests that the client size round trip preserves the set value.
        /// </summary>
        [RequireGlfwFact]
        public void ClientSize_GetSet_RoundTrips()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.Equal(new Size(280, 170), MainThreadNativeWorker.ClientSizeResult);
        }

        /// <summary>
        ///     Tests that the clipboard round trip preserves the set value.
        /// </summary>
        [RequireGlfwFact]
        public void Clipboard_GetSet_RoundTrips()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.Equal("alis-clip", MainThreadNativeWorker.ClipboardResult);
        }

        /// <summary>
        ///     Tests that every cursor mode round trips.
        /// </summary>
        [RequireGlfwFact]
        public void CursorMode_GetSet_RoundTrips()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.Equal(CursorMode.Hidden, MainThreadNativeWorker.CursorModeHiddenResult);
            Assert.Equal(CursorMode.Disabled, MainThreadNativeWorker.CursorModeDisabledResult);
            Assert.Equal(CursorMode.Normal, MainThreadNativeWorker.CursorModeNormalResult);
        }

        /// <summary>
        ///     Tests that the maximized state round trips in both directions.
        /// </summary>
        [RequireGlfwFact]
        public void Maximized_GetSet_RoundTrips()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(MainThreadNativeWorker.MaximizedOnResult);
            Assert.False(MainThreadNativeWorker.MaximizedOffResult);
        }

        /// <summary>
        ///     Tests that the minimized property reads the auto iconify attribute which the wrapper uses for the state.
        /// </summary>
        [RequireGlfwFact]
        public void Minimized_GetSet_ReadsHintAttribute()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.Equal(MainThreadNativeWorker.MinimizedOffResult, MainThreadNativeWorker.MinimizedOnResult);
        }

        /// <summary>
        ///     Tests that the mouse position can be set and read; the read value is the current cursor position relative
        ///     to the window because macOS cursor warping requires accessibility permissions unavailable to the test host.
        /// </summary>
        [RequireGlfwFact]
        public void MousePosition_GetSet_ReadsCurrentCursor()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Point position = MainThreadNativeWorker.MousePositionResult;
            Assert.True(position.X >= 0);
            Assert.True(position.Y >= 0);
        }

        /// <summary>
        ///     Tests that the window position round trip preserves the set value.
        /// </summary>
        [RequireGlfwFact]
        public void Position_GetSet_RoundTrips()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.Equal(new Point(101, 71), MainThreadNativeWorker.PositionResult);
        }

        /// <summary>
        ///     Tests that the window size round trip preserves the set value.
        /// </summary>
        [RequireGlfwFact]
        public void Size_GetSet_RoundTrips()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.Equal(new Size(360, 240), MainThreadNativeWorker.SizeResult);
        }

        /// <summary>
        ///     Tests that the sticky keys mode round trips in both directions.
        /// </summary>
        [RequireGlfwFact]
        public void StickyKeys_GetSet_RoundTrips()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(MainThreadNativeWorker.StickyKeysOnResult);
            Assert.False(MainThreadNativeWorker.StickyKeysOffResult);
        }

        /// <summary>
        ///     Tests that the sticky mouse button mode round trips in both directions.
        /// </summary>
        [RequireGlfwFact]
        public void StickyMouseButtons_GetSet_RoundTrips()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(MainThreadNativeWorker.StickyMouseButtonsOnResult);
            Assert.False(MainThreadNativeWorker.StickyMouseButtonsOffResult);
        }

        /// <summary>
        ///     Tests that the title round trip preserves the set value.
        /// </summary>
        [RequireGlfwFact]
        public void Title_GetSet_RoundTrips()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.Equal("exec-title", MainThreadNativeWorker.TitleResult);
        }

        /// <summary>
        ///     Tests that the user pointer round trip preserves the set value.
        /// </summary>
        [RequireGlfwFact]
        public void UserPointer_GetSet_RoundTrips()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.Equal(new IntPtr(0x7B), MainThreadNativeWorker.UserPointerResult);
        }

        /// <summary>
        ///     Tests that the visibility round trip preserves both directions.
        /// </summary>
        [RequireGlfwFact]
        public void Visible_GetSet_RoundTrips()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(MainThreadNativeWorker.VisibleOnResult);
            Assert.False(MainThreadNativeWorker.VisibleOffResult);
        }

        /// <summary>
        ///     Tests that the content scale of the live window is positive.
        /// </summary>
        [RequireGlfwFact]
        public void ContentScale_Get_ReturnsPositiveValues()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(MainThreadNativeWorker.ContentScaleResult.X > 0f);
            Assert.True(MainThreadNativeWorker.ContentScaleResult.Y > 0f);
            PointF live = GlfwTestBootstrap.Window.ContentScale;
            Assert.True(live.X > 0f);
            Assert.True(live.Y > 0f);
        }

        /// <summary>
        ///     Tests that the handle of the live window is a non-zero pointer.
        /// </summary>
        [RequireGlfwFact]
        public void Handle_Get_ReturnsNonZero()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.NotEqual(IntPtr.Zero, MainThreadNativeWorker.HandleResult);
            Assert.NotEqual(IntPtr.Zero, GlfwTestBootstrap.Window.Handle);
        }

        /// <summary>
        ///     Tests that the underlying GLFW window is a non-zero pointer.
        /// </summary>
        [RequireGlfwFact]
        public void UnderlyingWindow_Get_ReturnsNonZero()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            TestableNativeWindow window = (TestableNativeWindow) GlfwTestBootstrap.Window;
            Assert.NotEqual(IntPtr.Zero, (IntPtr) window.UnderlyingWindow);
        }

        /// <summary>
        ///     Tests that the video mode of the live window reports a non-empty mode.
        /// </summary>
        [RequireGlfwFact]
        public void VideoMode_Get_ReturnsPrimaryMode()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(MainThreadNativeWorker.VideoModeWidthResult > 0);
            Assert.True(MainThreadNativeWorker.VideoModeHeightResult > 0);
        }

        /// <summary>
        ///     Tests that the Win32 HWND is unavailable on macOS and the property degrades to zero.
        /// </summary>
        [RequireGlfwFact]
        public void Hwnd_Get_ReturnsZeroOnMacOS()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.Equal(IntPtr.Zero, MainThreadNativeWorker.HwndResult);
            Assert.Equal(IntPtr.Zero, GlfwTestBootstrap.Window.Hwnd);
        }

        /// <summary>
        ///     Tests that a freshly created window is not flagged as closing.
        /// </summary>
        [RequireGlfwFact]
        public void IsClosing_Get_ReturnsFalse()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.False(GlfwTestBootstrap.Window.IsClosing);
        }

        /// <summary>
        ///     Tests that the default window is decorated.
        /// </summary>
        [RequireGlfwFact]
        public void IsDecorated_Get_ReturnsTrue()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(GlfwTestBootstrap.Window.IsDecorated);
        }

        /// <summary>
        ///     Tests that the default window is not floating.
        /// </summary>
        [RequireGlfwFact]
        public void IsFloating_Get_ReturnsFalse()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.False(GlfwTestBootstrap.Window.IsFloating);
        }

        /// <summary>
        ///     Tests that the hidden bootstrap window is not focused.
        /// </summary>
        [RequireGlfwFact]
        public void IsFocused_Get_ReturnsFalse()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.False(GlfwTestBootstrap.Window.IsFocused);
        }

        /// <summary>
        ///     Tests that the default window is resizable.
        /// </summary>
        [RequireGlfwFact]
        public void IsResizable_Get_ReturnsTrue()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(GlfwTestBootstrap.Window.IsResizable);
        }

        /// <summary>
        ///     Tests that the windowed bootstrap window reports no monitor.
        /// </summary>
        [RequireGlfwFact]
        public void Monitor_Get_ReturnsNone()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.Equal(Monitor.None, GlfwTestBootstrap.Window.Monitor);
        }

        /// <summary>
        ///     Tests that the live window size is positive.
        /// </summary>
        [RequireGlfwFact]
        public void ClientSize_Get_LiveWindow()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Size size = GlfwTestBootstrap.Window.ClientSize;
            Assert.True(size.Width > 0);
            Assert.True(size.Height > 0);
        }

        /// <summary>
        ///     Tests that the live window attributes can be read.
        /// </summary>
        [RequireGlfwFact]
        public void State_Get_LiveWindow()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            NativeWindow window = GlfwTestBootstrap.Window;
            Assert.Equal(MainThreadNativeWorker.MaximizedOffResult, window.Maximized);
            Assert.Equal(MainThreadNativeWorker.VisibleOffResult, window.Visible);
            Assert.Equal(MainThreadNativeWorker.StickyKeysOffResult, window.StickyKeys);
            Assert.Equal(MainThreadNativeWorker.StickyMouseButtonsOffResult, window.StickyMouseButtons);
            Assert.Equal(MainThreadNativeWorker.TitleResult, window.Title);
        }

        /// <summary>
        ///     Tests that the sticky keys mode can be toggled from the test thread.
        /// </summary>
        [RequireGlfwFact]
        public void StickyKeys_GetSet_OnTestThread()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            NativeWindow window = GlfwTestBootstrap.Window;
            window.StickyKeys = true;
            Assert.True(window.StickyKeys);
            window.StickyKeys = false;
            Assert.False(window.StickyKeys);
        }

        /// <summary>
        ///     Tests that the sticky mouse button mode can be toggled from the test thread.
        /// </summary>
        [RequireGlfwFact]
        public void StickyMouseButtons_GetSet_OnTestThread()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            NativeWindow window = GlfwTestBootstrap.Window;
            window.StickyMouseButtons = true;
            Assert.True(window.StickyMouseButtons);
            window.StickyMouseButtons = false;
            Assert.False(window.StickyMouseButtons);
        }

        /// <summary>
        ///     Tests that the user pointer can be set and read from the test thread.
        /// </summary>
        [RequireGlfwFact]
        public void UserPointer_GetSet_OnTestThread()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            NativeWindow window = GlfwTestBootstrap.Window;
            IntPtr pointer = new IntPtr(0x2A);
            window.UserPointer = pointer;
            Assert.Equal(pointer, window.UserPointer);
        }

        /// <summary>
        ///     Tests that making the context current does not throw from the test thread.
        /// </summary>
        [RequireGlfwFact]
        public void MakeCurrent_DoesNotThrow()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            GlfwTestBootstrap.Window.MakeCurrent();
        }

        /// <summary>
        ///     Tests that the window equals itself and not null.
        /// </summary>
        [RequireGlfwFact]
        public void Equals_HandlesSelfAndNull()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            NativeWindow window = GlfwTestBootstrap.Window;
            Assert.True(window.Equals(window));
            Assert.False(window.Equals((NativeWindow) null));
            Assert.True(window.Equals((object) window));
            Assert.False(window.Equals((object) null));
        }

        /// <summary>
        ///     Tests that two distinct windows are not equal.
        /// </summary>
        [RequireGlfwFact]
        public void Equals_DifferentInstance_ReturnsFalse()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.False(MainThreadNativeWorker.ExtraWindowEqualsShared);
        }

        /// <summary>
        ///     Tests that the hash code is derived from the underlying window.
        /// </summary>
        [RequireGlfwFact]
        public void GetHashCode_ReturnsNonZero()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.NotEqual(0, GlfwTestBootstrap.Window.GetHashCode());
        }

        /// <summary>
        ///     Tests the implicit conversions to <see cref="Window" /> and <see cref="IntPtr" />.
        /// </summary>
        [RequireGlfwFact]
        public void ImplicitConversions_ReturnNonNullHandles()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            NativeWindow window = GlfwTestBootstrap.Window;
            Window native = window;
            IntPtr pointer = window;
            Assert.NotEqual(IntPtr.Zero, pointer);
            Assert.NotEqual(IntPtr.Zero, (IntPtr) native);
        }

        /// <summary>
        ///     Tests that the default constructor produced a valid window handle on the main thread.
        /// </summary>
        [RequireGlfwFact]
        public void DefaultCtor_CreatesValidHandle()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(MainThreadNativeWorker.DefaultCtorValidHandle);
        }

        /// <summary>
        ///     Tests that setting icons throws the interop exception because the image array cannot be marshaled.
        /// </summary>
        [RequireGlfwFact]
        public void SetIcons_ThrowsInteropException()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(MainThreadNativeWorker.IconsThrowsInteropException);
        }

        /// <summary>
        ///     Tests that the X11 and Win32 entry points are unavailable on macOS and throw the missing entry point error.
        /// </summary>
        [RequireGlfwFact]
        public void PlatformSpecificMethods_ThrowMissingEntryPoint()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            if (!RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return;
            }

            Assert.True(MainThreadNativeWorker.X11SelectionThrows);
            Assert.True(MainThreadNativeWorker.Win32QueriesThrows);
        }

        /// <summary>
        ///     Tests that closing a window reports the closed state and double dispose is safe.
        /// </summary>
        [RequireGlfwFact]
        public void Close_AndDoubleDispose_AreSafe()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(MainThreadNativeWorker.CloseWindowClosed);
            Assert.True(MainThreadNativeWorker.DisposeTwiceSafe);
        }

        /// <summary>
        ///     Tests that the parameterless fullscreen overload applies and restores without throwing.
        /// </summary>
        [RequireGlfwFact]
        public void Fullscreen_Parameterless_AppliesAndRestores()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.Empty(MainThreadNativeWorker.Failures);
        }

        /// <summary>
        ///     Tests that the closing event can cancel the close and the window stays open.
        /// </summary>
        [RequireGlfwFact]
        public void FireOnClosing_Cancel_KeepsWindowOpen()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(MainThreadNativeWorker.ClosingCancelWorks);
        }

        /// <summary>
        ///     Tests that the Cocoa monitor identifier is returned on macOS.
        /// </summary>
        [RequireGlfwFact]
        public void GetCocoaMonitor_OnMacOS_ReturnsNonZero()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            if (!RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return;
            }

            Assert.NotEqual(0u, MainThreadNativeWorker.CocoaMonitorResult);
        }

        /// <summary>
        ///     Tests that the Cocoa window pointer is returned on macOS.
        /// </summary>
        [RequireGlfwFact]
        public void GetCocoaWindow_OnMacOS_ReturnsNonZero()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            if (!RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return;
            }

            Assert.NotEqual(IntPtr.Zero, MainThreadNativeWorker.CocoaWindowResult);
        }

        /// <summary>
        ///     Tests that the platform context handles can be queried without throwing.
        /// </summary>
        [RequireGlfwFact]
        public void GetContextHandles_DoNotThrow()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.NotEqual(NSOpenGLContext.None, MainThreadNativeWorker.NsglContextResult);
            Assert.False(MainThreadNativeWorker.OsmesaColorBufferResult);
            Assert.False(MainThreadNativeWorker.OsmesaDepthBufferResult);
        }

        /// <summary>
        ///     Tests that the maximize change event is raised with the expected payload.
        /// </summary>
        [RequireGlfwFact]
        public void FireOnMaximizeChanged_RaisesEvent()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            TestableNativeWindow window = (TestableNativeWindow) GlfwTestBootstrap.Window;
            bool raised = false;
            EventHandler<MaximizeEventArgs> handler = (object sender, MaximizeEventArgs args) =>
            {
                raised = args.IsMaximized;
            };
            window.MaximizeChanged += handler;
            try
            {
                window.FireOnMaximizeChanged(true);
            }
            finally
            {
                window.MaximizeChanged -= handler;
            }

            Assert.True(raised);
        }

        /// <summary>
        ///     Tests that the content scale change event is raised with the expected payload.
        /// </summary>
        [RequireGlfwFact]
        public void FireOnContentScaleChanged_RaisesEvent()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            TestableNativeWindow window = (TestableNativeWindow) GlfwTestBootstrap.Window;
            bool raised = false;
            EventHandler<ContentScaleEventArgs> handler = (object sender, ContentScaleEventArgs args) =>
            {
                raised = args.XScale == 2f && args.YScale == 1.5f;
            };
            window.ContentScaleChanged += handler;
            try
            {
                window.FireOnContentScaleChanged(2f, 1.5f);
            }
            finally
            {
                window.ContentScaleChanged -= handler;
            }

            Assert.True(raised);
        }

        /// <summary>
        ///     Tests that the character input event is raised with the expected payload.
        /// </summary>
        [RequireGlfwFact]
        public void FireOnCharacterInput_RaisesEvent()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            TestableNativeWindow window = (TestableNativeWindow) GlfwTestBootstrap.Window;
            bool raised = false;
            EventHandler<CharEventArgs> handler = (object sender, CharEventArgs args) =>
            {
                raised = args.CodePoint == 65u;
            };
            window.CharacterInput += handler;
            try
            {
                window.FireOnCharacterInput(65u, ModifierKeys.None);
            }
            finally
            {
                window.CharacterInput -= handler;
            }

            Assert.True(raised);
        }

        /// <summary>
        ///     Tests that the closed event is raised.
        /// </summary>
        [RequireGlfwFact]
        public void FireOnClosed_RaisesEvent()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            TestableNativeWindow window = (TestableNativeWindow) GlfwTestBootstrap.Window;
            bool raised = false;
            EventHandler handler = (object sender, EventArgs args) => raised = true;
            window.Closed += handler;
            try
            {
                window.FireOnClosed();
            }
            finally
            {
                window.Closed -= handler;
            }

            Assert.True(raised);
        }

        /// <summary>
        ///     Tests that the file drop event is raised with the expected payload.
        /// </summary>
        [RequireGlfwFact]
        public void FireOnFileDrop_Strings_RaisesEvent()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            TestableNativeWindow window = (TestableNativeWindow) GlfwTestBootstrap.Window;
            string[] expected = new[] {"alis-a.txt", "alis-b.txt"};
            bool raised = false;
            EventHandler<FileDropEventArgs> handler = (object sender, FileDropEventArgs args) =>
            {
                raised = args.Filenames.Length == 2;
            };
            window.FileDrop += handler;
            try
            {
                window.FireOnFileDrop(expected);
            }
            finally
            {
                window.FileDrop -= handler;
            }

            Assert.True(raised);
        }

        /// <summary>
        ///     Tests that the file drop event is raised when the paths come from a native pointer array.
        /// </summary>
        [RequireGlfwFact]
        public void FireOnFileDrop_Pointers_RaisesEvent()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            TestableNativeWindow window = (TestableNativeWindow) GlfwTestBootstrap.Window;
            bool raised = false;
            EventHandler<FileDropEventArgs> handler = (object sender, FileDropEventArgs args) =>
            {
                raised = args.Filenames.Length == 2 && args.Filenames[0] == "alis-drop.txt";
            };
            window.FileDrop += handler;
            IntPtr buffer = Marshal.StringToHGlobalAnsi("alis-drop.txt");
            try
            {
                IntPtr array = Marshal.AllocHGlobal(IntPtr.Size * 2);
                try
                {
                    Marshal.WriteIntPtr(array, 0, buffer);
                    Marshal.WriteIntPtr(array, IntPtr.Size, buffer);
                    window.FireOnFileDrop(2, array);
                }
                finally
                {
                    Marshal.FreeHGlobal(array);
                }
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
                window.FileDrop -= handler;
            }

            Assert.True(raised);
        }

        /// <summary>
        ///     Tests that the focus change event is raised.
        /// </summary>
        [RequireGlfwFact]
        public void FireOnFocusChanged_RaisesEvent()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            TestableNativeWindow window = (TestableNativeWindow) GlfwTestBootstrap.Window;
            bool raised = false;
            EventHandler handler = (object sender, EventArgs args) => raised = true;
            window.FocusChanged += handler;
            try
            {
                window.FireOnFocusChanged(true);
            }
            finally
            {
                window.FocusChanged -= handler;
            }

            Assert.True(raised);
        }

        /// <summary>
        ///     Tests that the framebuffer size change event is raised with the expected payload.
        /// </summary>
        [RequireGlfwFact]
        public void FireOnFramebufferSizeChanged_RaisesEvent()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            TestableNativeWindow window = (TestableNativeWindow) GlfwTestBootstrap.Window;
            bool raised = false;
            EventHandler<SizeChangeEventArgs> handler = (object sender, SizeChangeEventArgs args) =>
            {
                raised = args.Size.Width == 320 && args.Size.Height == 200;
            };
            window.FramebufferSizeChanged += handler;
            try
            {
                window.FireOnFramebufferSizeChanged(320, 200);
            }
            finally
            {
                window.FramebufferSizeChanged -= handler;
            }

            Assert.True(raised);
        }

        /// <summary>
        ///     Tests that the key events are raised for every input state.
        /// </summary>
        [RequireGlfwFact]
        public void FireOnKey_RaisesKeyEvents()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            TestableNativeWindow window = (TestableNativeWindow) GlfwTestBootstrap.Window;
            int pressed = 0;
            int released = 0;
            int repeated = 0;
            int actions = 0;
            EventHandler<KeyEventArgs> pressHandler = (object sender, KeyEventArgs args) => pressed++;
            EventHandler<KeyEventArgs> releaseHandler = (object sender, KeyEventArgs args) => released++;
            EventHandler<KeyEventArgs> repeatHandler = (object sender, KeyEventArgs args) => repeated++;
            EventHandler<KeyEventArgs> actionHandler = (object sender, KeyEventArgs args) => actions++;
            window.KeyPress += pressHandler;
            window.KeyRelease += releaseHandler;
            window.KeyRepeat += repeatHandler;
            window.KeyAction += actionHandler;
            try
            {
                window.FireOnKey(Keys.A, 0, InputState.Press, ModifierKeys.None);
                window.FireOnKey(Keys.A, 0, InputState.Release, ModifierKeys.None);
                window.FireOnKey(Keys.A, 0, InputState.Repeat, ModifierKeys.None);
            }
            finally
            {
                window.KeyPress -= pressHandler;
                window.KeyRelease -= releaseHandler;
                window.KeyRepeat -= repeatHandler;
                window.KeyAction -= actionHandler;
            }

            Assert.Equal(1, pressed);
            Assert.Equal(2, released);
            Assert.Equal(0, repeated);
            Assert.Equal(3, actions);
        }

        /// <summary>
        ///     Tests that the mouse button event is raised with the expected payload.
        /// </summary>
        [RequireGlfwFact]
        public void FireOnMouseButton_RaisesEvent()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            TestableNativeWindow window = (TestableNativeWindow) GlfwTestBootstrap.Window;
            bool raised = false;
            EventHandler<MouseButtonEventArgs> handler = (object sender, MouseButtonEventArgs args) =>
            {
                raised = args.Button == MouseButton.Left && args.Action == InputState.Press;
            };
            window.MouseButton += handler;
            try
            {
                window.FireOnMouseButton(MouseButton.Left, InputState.Press, ModifierKeys.None);
            }
            finally
            {
                window.MouseButton -= handler;
            }

            Assert.True(raised);
        }

        /// <summary>
        ///     Tests that the mouse enter and leave events are raised.
        /// </summary>
        [RequireGlfwFact]
        public void FireOnMouseEnter_RaisesEvents()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            TestableNativeWindow window = (TestableNativeWindow) GlfwTestBootstrap.Window;
            int entered = 0;
            int left = 0;
            EventHandler enterHandler = (object sender, EventArgs args) => entered++;
            EventHandler leaveHandler = (object sender, EventArgs args) => left++;
            window.MouseEnter += enterHandler;
            window.MouseLeave += leaveHandler;
            try
            {
                window.FireOnMouseEnter(true);
                window.FireOnMouseEnter(false);
            }
            finally
            {
                window.MouseEnter -= enterHandler;
                window.MouseLeave -= leaveHandler;
            }

            Assert.Equal(1, entered);
            Assert.Equal(1, left);
        }

        /// <summary>
        ///     Tests that the mouse move event is raised with the expected payload.
        /// </summary>
        [RequireGlfwFact]
        public void FireOnMouseMove_RaisesEvent()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            TestableNativeWindow window = (TestableNativeWindow) GlfwTestBootstrap.Window;
            bool raised = false;
            EventHandler<MouseMoveEventArgs> handler = (object sender, MouseMoveEventArgs args) =>
            {
                raised = args.X == 1.5 && args.Y == 2.5;
            };
            window.MouseMoved += handler;
            try
            {
                window.FireOnMouseMove(1.5, 2.5);
            }
            finally
            {
                window.MouseMoved -= handler;
            }

            Assert.True(raised);
        }

        /// <summary>
        ///     Tests that the mouse scroll event is raised with the expected payload.
        /// </summary>
        [RequireGlfwFact]
        public void FireOnMouseScroll_RaisesEvent()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            TestableNativeWindow window = (TestableNativeWindow) GlfwTestBootstrap.Window;
            bool raised = false;
            EventHandler<MouseMoveEventArgs> handler = (object sender, MouseMoveEventArgs args) =>
            {
                raised = args.X == 0.0 && args.Y == 3.0;
            };
            window.MouseScroll += handler;
            try
            {
                window.FireOnMouseScroll(0.0, 3.0);
            }
            finally
            {
                window.MouseScroll -= handler;
            }

            Assert.True(raised);
        }

        /// <summary>
        ///     Tests that the position change event is raised.
        /// </summary>
        [RequireGlfwFact]
        public void FireOnPositionChanged_RaisesEvent()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            TestableNativeWindow window = (TestableNativeWindow) GlfwTestBootstrap.Window;
            bool raised = false;
            EventHandler handler = (object sender, EventArgs args) => raised = true;
            window.PositionChanged += handler;
            try
            {
                window.FireOnPositionChanged(10.0, 10.0);
            }
            finally
            {
                window.PositionChanged -= handler;
            }

            Assert.True(raised);
        }

        /// <summary>
        ///     Tests that the size change event is raised with the expected payload.
        /// </summary>
        [RequireGlfwFact]
        public void FireOnSizeChanged_RaisesEvent()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            TestableNativeWindow window = (TestableNativeWindow) GlfwTestBootstrap.Window;
            bool raised = false;
            EventHandler<SizeChangeEventArgs> handler = (object sender, SizeChangeEventArgs args) =>
            {
                raised = args.Size.Width == 300 && args.Size.Height == 200;
            };
            window.SizeChanged += handler;
            try
            {
                window.FireOnSizeChanged(300, 200);
            }
            finally
            {
                window.SizeChanged -= handler;
            }

            Assert.True(raised);
        }
    }
}
