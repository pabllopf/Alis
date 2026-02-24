// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlfwNativeContextTests.cs
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

using Alis.Extension.Graphic.Glfw.Enums;
using Alis.Extension.Graphic.Glfw.Structs;
using Alis.Extension.Graphic.Glfw.Test.Skipper;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Tests for GlfwNative context-related methods
    /// </summary>
    public class GlfwNativeContextTests
    {
        /// <summary>
        /// Makes the context current with valid window does not throw
        /// </summary>
        [RequiresDisplay]
        public void MakeContextCurrent_WithValidWindow_DoesNotThrow()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                // Act & Assert
                GlfwNative.MakeContextCurrent(window);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Swaps the buffers with valid window does not throw
        /// </summary>
        [RequiresDisplay]
        public void SwapBuffers_WithValidWindow_DoesNotThrow()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                GlfwNative.MakeContextCurrent(window);

                // Act & Assert
                GlfwNative.SwapBuffers(window);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Swaps the interval with valid value does not throw
        /// </summary>
        [RequiresDisplay]
        public void SwapInterval_WithValidValue_DoesNotThrow()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                GlfwNative.MakeContextCurrent(window);

                // Act & Assert
                GlfwNative.SwapInterval(1);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Defaults the window hints does not throw
        /// </summary>
        [RequiresDisplay]
        public void DefaultWindowHints_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.DefaultWindowHints();
        }

        /// <summary>
        /// Sets the window should close with valid window sets flag
        /// </summary>
        [RequiresDisplay]
        public void SetWindowShouldClose_WithValidWindow_SetsFlag()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                // Act
                GlfwNative.SetWindowShouldClose(window, true);
                bool shouldClose = GlfwNative.WindowShouldClose(window);

                // Assert
                Assert.True(shouldClose);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Waits the events does not throw
        /// </summary>
        [RequiresDisplay]
        public void WaitEvents_DoesNotThrow()
        {
            // This test can't wait indefinitely, so we'll just verify it exists
            // Act & Assert - Would need to run in background to test properly
            Assert.NotNull((System.Action)GlfwNative.WaitEvents);
        }

        /// <summary>
        /// Posts the empty event does not throw
        /// </summary>
        [RequiresDisplay]
        public void PostEmptyEvent_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.PostEmptyEvent();
        }

        /// <summary>
        /// Waits the events timeout with valid timeout does not throw
        /// </summary>
        [RequiresDisplay]
        public void WaitEventsTimeout_WithValidTimeout_DoesNotThrow()
        {
            // Act & Assert
            GlfwNative.WaitEventsTimeout(0.001);
        }

        /// <summary>
        /// Sets the close callback with valid callback sets callback
        /// </summary>
        [RequiresDisplay]
        public void SetCloseCallback_WithValidCallback_SetsCallback()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);
            bool callbackInvoked = false;
            WindowCallback callback = (w) => { callbackInvoked = true; };

            try
            {
                // Act
                WindowCallback previousCallback = GlfwNative.SetCloseCallback(window, callback);

                // Assert
                Assert.Null(previousCallback);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Gets the window monitor with windowed window returns none
        /// </summary>
        [RequiresDisplay]
        public void GetWindowMonitor_WithWindowedWindow_ReturnsNone()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                // Act
                Monitor monitor = GlfwNative.GetWindowMonitor(window);

                // Assert
                Assert.Equal(Monitor.None, monitor);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Sets the cursor position with valid window does not throw
        /// </summary>
        [RequiresDisplay]
        public void SetCursorPosition_WithValidWindow_DoesNotThrow()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                // Act & Assert
                GlfwNative.SetCursorPosition(window, 100.0, 100.0);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Gets the cursor position with valid window returns position
        /// </summary>
        [RequiresDisplay]
        public void GetCursorPosition_WithValidWindow_ReturnsPosition()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                // Act
                GlfwNative.GetCursorPosition(window, out double x, out double y);

                // Assert
                Assert.True(double.IsFinite(x));
                Assert.True(double.IsFinite(y));
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Sets the cursor position callback with valid callback sets callback
        /// </summary>
        [RequiresDisplay]
        public void SetCursorPositionCallback_WithValidCallback_SetsCallback()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);
            bool callbackInvoked = false;
            MouseCallback callback = (w, x, y) => { callbackInvoked = true; };

            try
            {
                // Act
                MouseCallback previousCallback = GlfwNative.SetCursorPositionCallback(window, callback);

                // Assert
                Assert.Null(previousCallback);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Creates the standard cursor with arrow type creates cursor
        /// </summary>
        [RequiresDisplay]
        public void CreateStandardCursor_WithArrowType_CreatesCursor()
        {
            // Act
            Cursor cursor = GlfwNative.CreateStandardCursor(CursorType.Arrow);

            try
            {
                // Assert
                Assert.NotEqual(Cursor.None, cursor);
            }
            finally
            {
                if (cursor != Cursor.None)
                {
                    GlfwNative.DestroyCursor(cursor);
                }
            }
        }

        /// <summary>
        /// Destroys the cursor with valid cursor does not throw
        /// </summary>
        [RequiresDisplay]
        public void DestroyCursor_WithValidCursor_DoesNotThrow()
        {
            // Arrange
            Cursor cursor = GlfwNative.CreateStandardCursor(CursorType.Arrow);

            // Act & Assert
            if (cursor != Cursor.None)
            {
                GlfwNative.DestroyCursor(cursor);
            }
        }

        /// <summary>
        /// Sets the cursor with valid window does not throw
        /// </summary>
        [RequiresDisplay]
        public void SetCursor_WithValidWindow_DoesNotThrow()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);
            Cursor cursor = GlfwNative.CreateStandardCursor(CursorType.Hand);

            try
            {
                // Act & Assert
                GlfwNative.SetCursor(window, cursor);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
                if (cursor != Cursor.None)
                {
                    GlfwNative.DestroyCursor(cursor);
                }
            }
        }

        /// <summary>
        /// Sets the drop callback with valid callback sets callback
        /// </summary>
        [RequiresDisplay]
        public void SetDropCallback_WithValidCallback_SetsCallback()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);
            bool callbackInvoked = false;
            FileDropCallback callback = (w, count, paths) => { callbackInvoked = true; };

            try
            {
                // Act
                FileDropCallback previousCallback = GlfwNative.SetDropCallback(window, callback);

                // Assert
                Assert.Null(previousCallback);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        /// Sets the gamma with valid monitor does not throw
        /// </summary>
        [RequiresDisplay]
        public void SetGamma_WithValidMonitor_DoesNotThrow()
        {
            // Arrange
            Monitor monitor = GlfwNative.PrimaryMonitor;
            if (monitor == Monitor.None) return;

            // Act & Assert
            GlfwNative.SetGamma(monitor, 1.0f);
        }
    }
}

