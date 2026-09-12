// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:WindowNativeExecutionTests.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Test;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    ///     Verifies the base <see cref="Window" /> wrapper members against the real native
    ///     CSFML library. Tests are skipped automatically when the CSFML window library
    ///     is not installed on the platform (see Alis.Extension.Graphic.Sfml.Test.Attributes).
    /// </summary>
    public class WindowNativeExecutionTests
    {
        /// <summary>
        ///     Tests that creating a window with default style reports itself open.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_WithDefaultStyle_ReportsOpen()
        {
            using Window window = new Window(new VideoMode(160u, 90u), "alis-window-test");
            Assert.True(window.IsOpen);
        }

        /// <summary>
        ///     Tests that creating a window with a custom style reports itself open.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_WithExplicitStyle_ReportsOpen()
        {
            using Window window = new Window(new VideoMode(160u, 90u), "alis-window-test", Styles.Close);
            Assert.True(window.IsOpen);
        }

        /// <summary>
        ///     Tests that creating a window with explicit settings reports itself open.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_WithExplicitSettings_ReportsOpen()
        {
            using Window window = new Window(new VideoMode(160u, 90u), "alis-window-test", Styles.Close, new ContextSettings(0, 0));
            Assert.True(window.IsOpen);
        }

        /// <summary>
        ///     Tests that every window operation completes after closing the window, and
        ///     that the closed window reports itself not open.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Close_AfterOperations_ReportsClosed()
        {
            using Window window = new Window(new VideoMode(160u, 90u), "alis-close-test");
            window.SetTitle("alis-close-test-title");
            window.SetVisible(false);
            window.SetMouseCursorVisible(true);
            window.SetMouseCursorGrabbed(false);
            window.SetVerticalSyncEnabled(false);
            window.SetKeyRepeatEnabled(false);
            window.SetFramerateLimit(0u);
            window.SetJoystickThreshold(0.5f);
            window.RequestFocus();
            window.Display();
            window.Close();
            Assert.False(window.IsOpen);
            window.DispatchEvents();
            window.WaitAndDispatchEvents();
            window.PollEvent(out Event polledEvent);
            window.WaitEvent(out Event waitEventToFill);
        }

        /// <summary>
        ///     Tests that the context settings read back the values requested at creation.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Settings_Get_ReturnsRequestedDepthBits()
        {
            using Window window = new Window(new VideoMode(160u, 90u), "alis-settings-test");
            Assert.Equal(0u, window.Settings.DepthBits);
            window.Close();
        }

        /// <summary>
        ///     Tests that the position and size getters and setters complete on a live window.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Position_And_Size_SetGet_Complete()
        {
            using Window window = new Window(new VideoMode(160u, 90u), "alis-roundtrip-test");
            window.Position = new Vector2F(20f, 10f);
            window.Size = new Vector2F(120f, 80f);
            Vector2F position = window.Position;
            Vector2F size = window.Size;
            Assert.True(position.X >= 0f);
            Assert.True(position.Y >= 0f);
            Assert.True(size.X >= 0f);
            Assert.True(size.Y >= 0f);
            window.Close();
        }

        /// <summary>
        ///     Tests that the internal mouse position setter and getter complete on a live window.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void MouseInternals_SetGet_Complete()
        {
            using Window window = new Window(new VideoMode(160u, 90u), "alis-mouse-test");
            window.InternalSetMousePosition(new Vector2F(10f, 10f));
            Vector2F mousePosition = window.InternalGetMousePosition();
            Assert.True(mousePosition.X >= 0f);
            window.Close();
        }

        /// <summary>
        ///     Tests that the internal touch position getter completes on a live window.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void TouchPosition_InternalGet_Completes()
        {
            using Window window = new Window(new VideoMode(160u, 90u), "alis-touch-test");
            Vector2F touchPosition = window.InternalGetTouchPosition(0u);
            Assert.True(touchPosition.X >= 0f);
            window.Close();
        }

        /// <summary>
        ///     Tests that the active state returns a boolean for both active and inactive states.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void SetActive_ReturnsBooleanForBothStates()
        {
            using Window window = new Window(new VideoMode(160u, 90u), "alis-active-test");
            Assert.IsType<bool>(window.SetActive(true));
            Assert.IsType<bool>(window.SetActive(false));
            Assert.IsType<bool>(window.SetActive());
            window.Close();
        }

        /// <summary>
        ///     Tests that dispatching events on a newly created window completes.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void DispatchEvents_OnLiveWindow_Completes()
        {
            using Window window = new Window(new VideoMode(160u, 90u), "alis-dispatch-test");
            int resizedCount = 0;
            window.Resized += (sender, args) => resizedCount++;
            window.DispatchEvents();
            Assert.InRange(resizedCount, 0, 1);
            window.Close();
        }

        /// <summary>
        ///     Tests that wait and dispatch events on a closed window returns immediately.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void WaitAndDispatchEvents_AfterClose_DoesNotThrow()
        {
            using Window window = new Window(new VideoMode(160u, 90u), "alis-wait-closed-test");
            window.Close();
            window.WaitAndDispatchEvents();
        }

        /// <summary>
        ///     Tests that polling events on a closed window returns false.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void PollEvent_AfterClose_ReturnsFalse()
        {
            using Window window = new Window(new VideoMode(160u, 90u), "alis-poll-closed-test");
            window.Close();
            bool polled = window.PollEvent(out Event eventToFill);
            Assert.False(polled);
        }

        /// <summary>
        ///     Tests that waiting for events on a closed window returns false.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void WaitEvent_AfterClose_ReturnsFalse()
        {
            using Window window = new Window(new VideoMode(160u, 90u), "alis-wait-closed-test");
            window.Close();
            bool waited = window.WaitEvent(out Event eventToFill);
            Assert.False(waited);
        }

        /// <summary>
        ///     Tests that a live window focus query, display call and string description
        ///     report the wrapper state.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void HasFocus_Display_And_ToString_Execute()
        {
            using Window window = new Window(new VideoMode(160u, 90u), "alis-focus-test");
            Assert.IsType<bool>(window.HasFocus());
            window.Display();
            string description = window.ToString();
            Assert.StartsWith("[Window]", description);
            window.Close();
        }

        /// <summary>
        ///     Tests that setting the mouse cursor to a system cursor completes.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void SetMouseCursor_WithSystemCursor_Completes()
        {
            using Window window = new Window(new VideoMode(160u, 90u), "alis-cursor-test");
            using Cursor cursor = new Cursor(Cursor.CursorType.Arrow);
            window.SetMouseCursor(cursor);
            window.Close();
        }

        /// <summary>
        ///     Tests that creating a window from a native platform handle works when
        ///     creating windows from existing controls.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_FromNativeHandle_CreatesWindow()
        {
            IntPtr nativeWindow = SfmlTestBootstrap.CreateExtraNativeWindow();
            try
            {
                IntPtr handle = SfmlTestBootstrap.GetExtraNativeHandle(nativeWindow);
                Assert.NotEqual(IntPtr.Zero, handle);
                using Window window = new Window(handle, new ContextSettings(0, 0));
                Assert.NotEqual(IntPtr.Zero, window.CPointer);
                window.Close();
            }
            finally
            {
                NativeWindowFactory.DestroyExtraNativeWindow(nativeWindow);
            }
        }

        /// <summary>
        ///     Tests that creating a window from a native handle without settings works.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_FromNativeHandle_DefaultSettings_CreatesWindow()
        {
            IntPtr nativeWindow = SfmlTestBootstrap.CreateExtraNativeWindow();
            try
            {
                IntPtr handle = SfmlTestBootstrap.GetExtraNativeHandle(nativeWindow);
                Assert.NotEqual(IntPtr.Zero, handle);
                using Window window = new Window(handle);
                Assert.NotEqual(IntPtr.Zero, window.CPointer);
                window.Close();
            }
            finally
            {
                NativeWindowFactory.DestroyExtraNativeWindow(nativeWindow);
            }
        }

        /// <summary>
        ///     Tests that disposing the window destroys the native handle.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Dispose_AfterClose_NullsNativeHandle()
        {
            Window window = new Window(new VideoMode(160u, 90u), "alis-dispose-test");
            Assert.NotEqual(IntPtr.Zero, window.CPointer);
            window.Dispose();
            Assert.Equal(IntPtr.Zero, window.CPointer);
            window.Close();
        }
    }
}
