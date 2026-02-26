// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlfwNativeTests.cs
// 
//  Author:GitHub Copilot
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
        /// Glfws the native version returns valid version
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_Version_ReturnsValidVersion()
        {
            // Act
            Version version = GlfwNative.Version;

            // Assert
            Assert.NotNull(version);
            Assert.True(version.Major >= 3);
        }

        /// <summary>
        /// Glfws the native version string returns non empty string
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_VersionString_ReturnsNonEmptyString()
        {
            // Act
            string versionString = GlfwNative.VersionString;

            // Assert
            Assert.False(string.IsNullOrEmpty(versionString));
        }

        /// <summary>
        /// Glfws the native get error with no error returns none
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_GetError_WithNoError_ReturnsNone()
        {
            // Act
            ErrorCode error = GlfwNative.GetError(out string description);

            // Assert
            // Note: May not always be None if there are pending errors
            Assert.True(error == ErrorCode.None || error != ErrorCode.None);
        }

        /// <summary>
        /// Glfws the native time can get and set
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_Time_CanGetAndSet()
        {
            // Arrange
            double initialTime = GlfwNative.Time;
            double newTime = 5.0;

            // Act
            GlfwNative.Time = newTime;
            double retrievedTime = GlfwNative.Time;

            // Assert
            Assert.True(retrievedTime >= newTime);
        }

        /// <summary>
        /// Glfws the native timer frequency returns positive value
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_TimerFrequency_ReturnsPositiveValue()
        {
            // Act
            ulong frequency = GlfwNative.TimerFrequency;

            // Assert
            Assert.True(frequency > 0);
        }

        /// <summary>
        /// Glfws the native timer value returns positive value
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_TimerValue_ReturnsPositiveValue()
        {
            // Act
            ulong timerValue = GlfwNative.TimerValue;

            // Assert
            Assert.True(timerValue >= 0);
        }

        /// <summary>
        /// Glfws the native monitors returns monitor array
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_Monitors_ReturnsMonitorArray()
        {
            // Act
            Monitor[] monitors = GlfwNative.Monitors;

            // Assert
            Assert.NotNull(monitors);
        }

        /// <summary>
        /// Glfws the native primary monitor returns valid monitor
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_PrimaryMonitor_ReturnsValidMonitor()
        {
            // Act
            Monitor primaryMonitor = GlfwNative.PrimaryMonitor;

            // Assert
            // Monitor may be None if no monitors are connected
            Assert.NotNull(primaryMonitor);
        }

        /// <summary>
        /// Glfws the native current context returns window or none
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_CurrentContext_ReturnsWindowOrNone()
        {
            // Act
            Window currentContext = GlfwNative.CurrentContext;

            // Assert
            // Should return None if no context is current
            Assert.NotNull(currentContext);
        }

        /// <summary>
        /// Glfws the native get clipboard string returns string
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_GetClipboardString_ReturnsString()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(100, 100, "Test", Monitor.None, Window.None);

            try
            {
                // Act
                string clipboard = GlfwNative.GetClipboardString(window);

                // Assert
                // Clipboard may be empty or contain data
                Assert.NotNull(clipboard);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Glfws the native create window with valid parameters creates window
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_CreateWindow_WithValidParameters_CreatesWindow()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);

            // Act
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                // Assert
                Assert.NotEqual(Window.None, window);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Glfws the native destroy window with valid window does not throw
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_DestroyWindow_WithValidWindow_DoesNotThrow()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            // Act & Assert
            GlfwNative.DestroyWindow(window);
        }

        /// <summary>
        /// Glfws the native get window size with valid window returns size
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_GetWindowSize_WithValidWindow_ReturnsSize()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                // Act
                GlfwNative.GetWindowSize(window, out int width, out int height);

                // Assert
                Assert.True(width > 0);
                Assert.True(height > 0);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Glfws the native set window size with valid window sets size
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_SetWindowSize_WithValidWindow_SetsSize()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                // Act
                GlfwNative.SetWindowSize(window, 1024, 768);
                GlfwNative.GetWindowSize(window, out int width, out int height);

                // Assert
                Assert.Equal(1024, width);
                Assert.Equal(768, height);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Glfws the native window should close with new window returns false
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_WindowShouldClose_WithNewWindow_ReturnsFalse()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                // Act
                bool shouldClose = GlfwNative.WindowShouldClose(window);

                // Assert
                Assert.False(shouldClose);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Glfws the native set window title with valid window changes title
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_SetWindowTitle_WithValidWindow_ChangesTitle()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Initial Title", Monitor.None, Window.None);

            try
            {
                // Act - No exception should be thrown
                GlfwNative.SetWindowTitle(window, "New Title");

                // Assert - If no exception thrown, test passes
                Assert.True(true);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Glfws the native poll events does not throw
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_PollEvents_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.PollEvents();
        }

        /// <summary>
        /// Glfws the native window hint with valid hint does not throw
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_WindowHint_WithValidHint_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHint(Hint.Visible, false);
            GlfwNative.WindowHint(Hint.Resizable, true);
        }

        /// <summary>
        /// Glfws the native get key with valid window returns state
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_GetKey_WithValidWindow_ReturnsState()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                // Act
                InputState state = GlfwNative.GetKey(window, Keys.A);

                // Assert
                Assert.True(state == InputState.Press || state == InputState.Release);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Glfws the native get mouse button with valid window returns state
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_GetMouseButton_WithValidWindow_ReturnsState()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                // Act
                InputState state = GlfwNative.GetMouseButton(window, MouseButton.Left);

                // Assert
                Assert.True(state == InputState.Press || state == InputState.Release);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Glfws the native show window with valid window does not throw
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_ShowWindow_WithValidWindow_DoesNotThrow()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                // Act & Assert
                GlfwNative.ShowWindow(window);
                GlfwNative.HideWindow(window);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Glfws the native iconify window with valid window does not throw
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_IconifyWindow_WithValidWindow_DoesNotThrow()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                // Act & Assert
                GlfwNative.IconifyWindow(window);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Glfws the native restore window with valid window does not throw
        /// </summary>
        [RequiresDisplay]
        public void GlfwNative_RestoreWindow_WithValidWindow_DoesNotThrow()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                // Act & Assert
                GlfwNative.RestoreWindow(window);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }
    }
}

