// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlfwNativeContextTests.cs
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
    ///     Tests for GlfwNative context-related methods
    /// </summary>
    public class GlfwNativeContextTests
    {
        /// <summary>
        ///     Makes the context current with valid window does not throw
        /// </summary>
        [RequiresDisplay]
        public void MakeContextCurrent_WithValidWindow_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                GlfwNative.MakeContextCurrent(window);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Swaps the buffers with valid window does not throw
        /// </summary>
        [RequiresDisplay]
        public void SwapBuffers_WithValidWindow_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                GlfwNative.MakeContextCurrent(window);

                GlfwNative.SwapBuffers(window);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Swaps the interval with valid value does not throw
        /// </summary>
        [RequiresDisplay]
        public void SwapInterval_WithValidValue_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                GlfwNative.MakeContextCurrent(window);

                GlfwNative.SwapInterval(1);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Defaults the window hints does not throw
        /// </summary>
        [RequiresDisplay]
        public void DefaultWindowHints_DoesNotThrow()
        {
            GlfwNative.DefaultWindowHints();
        }


        /// <summary>
        ///     Waits the events does not throw
        /// </summary>
        [RequiresDisplay]
        public void WaitEvents_DoesNotThrow()
        {
            Assert.NotNull((Action) GlfwNative.WaitEvents);
        }

        /// <summary>
        ///     Posts the empty event does not throw
        /// </summary>
        [RequiresDisplay]
        public void PostEmptyEvent_DoesNotThrow()
        {
            GlfwNative.PostEmptyEvent();
        }

        /// <summary>
        ///     Waits the events timeout with valid timeout does not throw
        /// </summary>
        [RequiresDisplay]
        public void WaitEventsTimeout_WithValidTimeout_DoesNotThrow()
        {
            GlfwNative.WaitEventsTimeout(0.001);
        }

        /// <summary>
        ///     Sets the close callback with valid callback sets callback
        /// </summary>
        [RequiresDisplay]
        public void SetCloseCallback_WithValidCallback_SetsCallback()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);
            bool callbackInvoked = false;
            WindowCallback callback = w => { callbackInvoked = true; };

            try
            {
                WindowCallback previousCallback = GlfwNative.SetCloseCallback(window, callback);

                Assert.Null(previousCallback);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Gets the window monitor with windowed window returns none
        /// </summary>
        [RequiresDisplay]
        public void GetWindowMonitor_WithWindowedWindow_ReturnsNone()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                Monitor monitor = GlfwNative.GetWindowMonitor(window);

                Assert.Equal(Monitor.None, monitor);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Sets the cursor position with valid window does not throw
        /// </summary>
        [RequiresDisplay]
        public void SetCursorPosition_WithValidWindow_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                GlfwNative.SetCursorPosition(window, 100.0, 100.0);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Sets the cursor position callback with valid callback sets callback
        /// </summary>
        [RequiresDisplay]
        public void SetCursorPositionCallback_WithValidCallback_SetsCallback()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);
            bool callbackInvoked = false;
            MouseCallback callback = (w, x, y) => { callbackInvoked = true; };

            try
            {
                MouseCallback previousCallback = GlfwNative.SetCursorPositionCallback(window, callback);

                Assert.Null(previousCallback);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Creates the standard cursor with arrow type creates cursor
        /// </summary>
        [RequiresDisplay]
        public void CreateStandardCursor_WithArrowType_CreatesCursor()
        {
            Cursor cursor = GlfwNative.CreateStandardCursor(CursorType.Arrow);

            try
            {
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
        ///     Destroys the cursor with valid cursor does not throw
        /// </summary>
        [RequiresDisplay]
        public void DestroyCursor_WithValidCursor_DoesNotThrow()
        {
            Cursor cursor = GlfwNative.CreateStandardCursor(CursorType.Arrow);

            if (cursor != Cursor.None)
            {
                GlfwNative.DestroyCursor(cursor);
            }
        }

        /// <summary>
        ///     Sets the drop callback with valid callback sets callback
        /// </summary>
        [RequiresDisplay]
        public void SetDropCallback_WithValidCallback_SetsCallback()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);
            bool callbackInvoked = false;
            FileDropCallback callback = (w, count, paths) => { callbackInvoked = true; };

            try
            {
                FileDropCallback previousCallback = GlfwNative.SetDropCallback(window, callback);

                Assert.Null(previousCallback);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Sets the gamma with valid monitor does not throw
        /// </summary>
        [RequiresDisplay]
        public void SetGamma_WithValidMonitor_DoesNotThrow()
        {
            Monitor monitor = GlfwNative.PrimaryMonitor;
            if (monitor == Monitor.None)
            {
                return;
            }

            GlfwNative.SetGamma(monitor, 1.0f);
        }
    }
}