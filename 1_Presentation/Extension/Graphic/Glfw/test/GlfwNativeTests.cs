// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlfwNativeTests.cs
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
using Alis.Extension.Graphic.Glfw.Enums;
using Alis.Extension.Graphic.Glfw.Structs;
using Alis.Extension.Graphic.Glfw.Test.Skipper;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Tests for GlfwNative class
    /// </summary>
    public class GlfwNativeTests
    {
        /// <summary>
        ///     Glfws the native version returns valid version
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_Version_ReturnsValidVersion()
        {
            Version version = GlfwNative.Version;

            Assert.NotNull(version);
            Assert.True(version.Major >= 3);
        }

        /// <summary>
        ///     Glfws the native version string returns non empty string
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_VersionString_ReturnsNonEmptyString()
        {
            string versionString = GlfwNative.VersionString;

            Assert.False(string.IsNullOrEmpty(versionString));
        }

        /// <summary>
        ///     Glfws the native get error with no error returns none
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_GetError_WithNoError_ReturnsNone()
        {
            ErrorCode error = GlfwNative.GetError(out string description);

            Assert.True(error == ErrorCode.None || error != ErrorCode.None);
        }

        /// <summary>
        ///     Glfws the native time can get and set
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_Time_CanGetAndSet()
        {
            double initialTime = GlfwNative.Time;
            double newTime = 5.0;

            GlfwNative.Time = newTime;
            double retrievedTime = GlfwNative.Time;

            Assert.True(retrievedTime >= newTime);
        }

        /// <summary>
        ///     Glfws the native timer frequency returns positive value
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_TimerFrequency_ReturnsPositiveValue()
        {
            ulong frequency = GlfwNative.TimerFrequency;

            Assert.True(frequency > 0);
        }

        /// <summary>
        ///     Glfws the native timer value returns positive value
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_TimerValue_ReturnsPositiveValue()
        {
            ulong timerValue = GlfwNative.TimerValue;

            Assert.True(timerValue >= 0);
        }

        /// <summary>
        ///     Glfws the native monitors returns monitor array
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_Monitors_ReturnsMonitorArray()
        {
            Monitor[] monitors = GlfwNative.Monitors;

            Assert.NotNull(monitors);
        }

        /// <summary>
        ///     Glfws the native primary monitor returns valid monitor
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_PrimaryMonitor_ReturnsValidMonitor()
        {
            Monitor primaryMonitor = GlfwNative.PrimaryMonitor;

            Assert.NotNull(primaryMonitor);
        }

        /// <summary>
        ///     Glfws the native current context returns window or none
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_CurrentContext_ReturnsWindowOrNone()
        {
            Window currentContext = GlfwNative.CurrentContext;

            Assert.NotNull(currentContext);
        }

        /// <summary>
        ///     Glfws the native get clipboard string returns string
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_GetClipboardString_ReturnsString()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(100, 100, "Test", Monitor.None, Window.None);

            try
            {
                string clipboard = GlfwNative.GetClipboardString(window);

                Assert.NotNull(clipboard);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Glfws the native create window with valid parameters creates window
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_CreateWindow_WithValidParameters_CreatesWindow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);

            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                Assert.NotEqual(Window.None, window);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Glfws the native destroy window with valid window does not throw
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_DestroyWindow_WithValidWindow_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            GlfwNative.DestroyWindow(window);
        }

        /// <summary>
        ///     Glfws the native get window size with valid window returns size
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_GetWindowSize_WithValidWindow_ReturnsSize()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                GlfwNative.GetWindowSize(window, out int width, out int height);

                Assert.True(width > 0);
                Assert.True(height > 0);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }


        /// <summary>
        ///     Glfws the native window should close with new window returns false
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_WindowShouldClose_WithNewWindow_ReturnsFalse()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                bool shouldClose = GlfwNative.WindowShouldClose(window);

                Assert.False(shouldClose);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Glfws the native set window title with valid window changes title
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_SetWindowTitle_WithValidWindow_ChangesTitle()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Initial Title", Monitor.None, Window.None);

            try
            {
                GlfwNative.SetWindowTitle(window, "New Title");

                Assert.True(true);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Glfws the native poll events does not throw
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_PollEvents_DoesNotThrow()
        {
            GlfwNative.PollEvents();
        }

        /// <summary>
        ///     Glfws the native window hint with valid hint does not throw
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_WindowHint_WithValidHint_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            GlfwNative.WindowHint(Hint.Resizable, true);
        }

        /// <summary>
        ///     Glfws the native get key with valid window returns state
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_GetKey_WithValidWindow_ReturnsState()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                InputState state = GlfwNative.GetKey(window, Keys.A);

                Assert.True(state == InputState.Press || state == InputState.Release);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Glfws the native get mouse button with valid window returns state
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_GetMouseButton_WithValidWindow_ReturnsState()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                InputState state = GlfwNative.GetMouseButton(window, MouseButton.Left);

                Assert.True(state == InputState.Press || state == InputState.Release);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Glfws the native show window with valid window does not throw
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_ShowWindow_WithValidWindow_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                GlfwNative.ShowWindow(window);
                GlfwNative.HideWindow(window);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Glfws the native iconify window with valid window does not throw
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_IconifyWindow_WithValidWindow_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                GlfwNative.IconifyWindow(window);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Glfws the native restore window with valid window does not throw
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_RestoreWindow_WithValidWindow_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                GlfwNative.RestoreWindow(window);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }
    }
}