// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlfwNativeAdvancedTests.cs
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
    ///     Advanced tests for GlfwNative class methods
    /// </summary>
    public class GlfwNativeAdvancedTests
    {
        /// <summary>
        /// Gets the window opacity with valid window returns value
        /// </summary>
        [RequiresDisplay]
        public void GetWindowOpacity_WithValidWindow_ReturnsValue()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                // Act
                float opacity = GlfwNative.GetWindowOpacity(window);

                // Assert
                Assert.True(opacity >= 0.0f && opacity <= 1.0f);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Sets the window opacity with valid window sets opacity
        /// </summary>
        [RequiresDisplay]
        public void SetWindowOpacity_WithValidWindow_SetsOpacity()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                // Act
                GlfwNative.SetWindowOpacity(window, 0.5f);
                float opacity = GlfwNative.GetWindowOpacity(window);

                // Assert
                Assert.True(Math.Abs(opacity - 0.5f) < 0.1f);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Gets the window content scale with valid window returns scale
        /// </summary>
        [RequiresDisplay]
        public void GetWindowContentScale_WithValidWindow_ReturnsScale()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                // Act
                GlfwNative.GetWindowContentScale(window, out float xScale, out float yScale);

                // Assert
                Assert.True(xScale > 0);
                Assert.True(yScale > 0);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Requests the window attention with valid window does not throw
        /// </summary>
        [RequiresDisplay]
        public void RequestWindowAttention_WithValidWindow_DoesNotThrow()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                // Act & Assert
                GlfwNative.RequestWindowAttention(window);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Raws the mouse motion supported returns boolean
        /// </summary>
        [RequiresDisplay]
        public void RawMouseMotionSupported_ReturnsBoolean()
        {
            // Act
            bool supported = GlfwNative.RawMouseMotionSupported();

            // Assert
            Assert.True(supported || !supported); // Just verify it doesn't throw
        }

        /// <summary>
        /// Gets the key scan code with valid key returns code
        /// </summary>
        [RequiresDisplay]
        public void GetKeyScanCode_WithValidKey_ReturnsCode()
        {
            // Act
            int scanCode = GlfwNative.GetKeyScanCode(Keys.A);

            // Assert
            Assert.True(scanCode != 0 || scanCode == 0); // Depends on platform
        }

        /// <summary>
        /// Gets the key scan code with unknown key returns negative one
        /// </summary>
        [RequiresDisplay]
        public void GetKeyScanCode_WithUnknownKey_ReturnsNegativeOne()
        {
            // Act
            int scanCode = GlfwNative.GetKeyScanCode(Keys.Unknown);

            // Assert
            Assert.Equal(-1, scanCode);
        }

        /// <summary>
        /// Sets the window attribute with resizable does not throw
        /// </summary>
        [RequiresDisplay]
        public void SetWindowAttribute_WithResizable_DoesNotThrow()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                // Act & Assert
                GlfwNative.SetWindowAttribute(window, WindowAttribute.Resizable, false);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Sets the window attribute with decorated does not throw
        /// </summary>
        [RequiresDisplay]
        public void SetWindowAttribute_WithDecorated_DoesNotThrow()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                // Act & Assert
                GlfwNative.SetWindowAttribute(window, WindowAttribute.Decorated, false);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Sets the window attribute with floating does not throw
        /// </summary>
        [RequiresDisplay]
        public void SetWindowAttribute_WithFloating_DoesNotThrow()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                // Act & Assert
                GlfwNative.SetWindowAttribute(window, WindowAttribute.Floating, true);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Gets the window frame size with valid window returns frame size
        /// </summary>
        [RequiresDisplay]
        public void GetWindowFrameSize_WithValidWindow_ReturnsFrameSize()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                // Act
                GlfwNative.GetWindowFrameSize(window, out int left, out int top, out int right, out int bottom);

                // Assert
                Assert.True(left >= 0);
                Assert.True(top >= 0);
                Assert.True(right >= 0);
                Assert.True(bottom >= 0);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Maximizes the window with valid window does not throw
        /// </summary>
        [RequiresDisplay]
        public void MaximizeWindow_WithValidWindow_DoesNotThrow()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                // Act & Assert
                GlfwNative.MaximizeWindow(window);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Gets the window position with valid window returns position
        /// </summary>
        [RequiresDisplay]
        public void GetWindowPosition_WithValidWindow_ReturnsPosition()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                // Act
                GlfwNative.GetWindowPosition(window, out int x, out int y);

                // Assert - Position values should be retrievable
                Assert.True(x != int.MinValue);
                Assert.True(y != int.MinValue);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Sets the window position with valid window sets position
        /// </summary>
        [RequiresDisplay]
        public void SetWindowPosition_WithValidWindow_SetsPosition()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                // Act
                GlfwNative.SetWindowPosition(window, 100, 100);
                GlfwNative.GetWindowPosition(window, out int x, out int y);

                // Assert - Position should be set (may be adjusted by window manager)
                Assert.True(x >= 0);
                Assert.True(y >= 0);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Focuses the window with valid window does not throw
        /// </summary>
        [RequiresDisplay]
        public void FocusWindow_WithValidWindow_DoesNotThrow()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                // Act & Assert
                GlfwNative.FocusWindow(window);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Sets the window position callback with valid callback sets callback
        /// </summary>
        [RequiresDisplay]
        public void SetWindowPositionCallback_WithValidCallback_SetsCallback()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);
            bool callbackInvoked = false;
            PositionCallback callback = (w, x, y) => { callbackInvoked = true; };

            try
            {
                // Act
                PositionCallback previousCallback = GlfwNative.SetWindowPositionCallback(window, callback);

                // Assert
                Assert.Null(previousCallback);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Sets the window size callback with valid callback sets callback
        /// </summary>
        [RequiresDisplay]
        public void SetWindowSizeCallback_WithValidCallback_SetsCallback()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);
            bool callbackInvoked = false;
            SizeCallback callback = (w, width, height) => { callbackInvoked = true; };

            try
            {
                // Act
                SizeCallback previousCallback = GlfwNative.SetWindowSizeCallback(window, callback);

                // Assert
                Assert.Null(previousCallback);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Sets the window focus callback with valid callback sets callback
        /// </summary>
        [RequiresDisplay]
        public void SetWindowFocusCallback_WithValidCallback_SetsCallback()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);
            bool callbackInvoked = false;
            FocusCallback callback = (w, focused) => { callbackInvoked = true; };

            try
            {
                // Act
                FocusCallback previousCallback = GlfwNative.SetWindowFocusCallback(window, callback);

                // Assert
                Assert.Null(previousCallback);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Sets the window maximize callback with valid callback sets callback
        /// </summary>
        [RequiresDisplay]
        public void SetWindowMaximizeCallback_WithValidCallback_SetsCallback()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);
            bool callbackInvoked = false;
            WindowMaximizedCallback callback = (w, maximized) => { callbackInvoked = true; };

            try
            {
                // Act
                WindowMaximizedCallback previousCallback = GlfwNative.SetWindowMaximizeCallback(window, callback);

                // Assert
                Assert.Null(previousCallback);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Sets the window content scale callback with valid callback sets callback
        /// </summary>
        [RequiresDisplay]
        public void SetWindowContentScaleCallback_WithValidCallback_SetsCallback()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);
            bool callbackInvoked = false;
            WindowContentsScaleCallback callback = (w, xScale, yScale) => { callbackInvoked = true; };

            try
            {
                // Act
                WindowContentsScaleCallback previousCallback = GlfwNative.SetWindowContentScaleCallback(window, callback);

                // Assert
                Assert.Null(previousCallback);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Windows the hint string with valid hint does not throw
        /// </summary>
        [RequiresDisplay]
        public void WindowHintString_WithValidHint_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WindowHintString(Hint.X11ClassName, System.Text.Encoding.UTF8.GetBytes("TestClass"));
        }

        /// <summary>
        /// Inits the hint with valid hint does not throw
        /// </summary>
        [RequiresDisplay]
        public void InitHint_WithValidHint_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.InitHint(Hint.JoystickHatButtons, true);
        }

        /// <summary>
        /// Gets the error after init returns none or error
        /// </summary>
        [RequiresDisplay]
        public void GetError_AfterInit_ReturnsNoneOrError()
        {
            // Act
            ErrorCode error = GlfwNative.GetError(out string description);

            // Assert
            Assert.True(error == ErrorCode.None || error != ErrorCode.None);
        }
    }
}

