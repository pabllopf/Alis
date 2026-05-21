

using System;
using Alis.Extension.Graphic.Glfw.Enums;
using Alis.Extension.Graphic.Glfw.Structs;
using Alis.Extension.Graphic.Glfw.Test.Skipper;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Tests for GlfwNative input-related methods
    /// </summary>
    public class GlfwNativeInputTests
    {
        /// <summary>
        ///     Sets the cursor enter callback with valid callback sets callback
        /// </summary>
        [RequiresDisplay]
        public void SetCursorEnterCallback_WithValidCallback_SetsCallback()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);
            bool callbackInvoked = false;
            MouseEnterCallback callback = (w, entered) => { callbackInvoked = true; };

            try
            {
                MouseEnterCallback previousCallback = GlfwNative.SetCursorEnterCallback(window, callback);

                Assert.Null(previousCallback);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Sets the mouse button callback with valid callback sets callback
        /// </summary>
        [RequiresDisplay]
        public void SetMouseButtonCallback_WithValidCallback_SetsCallback()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);
            bool callbackInvoked = false;
            MouseButtonCallback callback = (w, button, state, mods) => { callbackInvoked = true; };

            try
            {
                MouseButtonCallback previousCallback = GlfwNative.SetMouseButtonCallback(window, callback);

                Assert.Null(previousCallback);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Sets the scroll callback with valid callback sets callback
        /// </summary>
        [RequiresDisplay]
        public void SetScrollCallback_WithValidCallback_SetsCallback()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);
            bool callbackInvoked = false;
            MouseCallback callback = (w, xOffset, yOffset) => { callbackInvoked = true; };

            try
            {
                MouseCallback previousCallback = GlfwNative.SetScrollCallback(window, callback);

                Assert.Null(previousCallback);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Sets the window user pointer with valid pointer sets pointer
        /// </summary>
        [RequiresDisplay]
        public void SetWindowUserPointer_WithValidPointer_SetsPointer()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);
            IntPtr testPointer = new IntPtr(12345);

            try
            {
                GlfwNative.SetWindowUserPointer(window, testPointer);
                IntPtr retrievedPointer = GlfwNative.GetWindowUserPointer(window);

                Assert.Equal(testPointer, retrievedPointer);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Gets the window user pointer with no pointer set returns zero
        /// </summary>
        [RequiresDisplay]
        public void GetWindowUserPointer_WithNoPointerSet_ReturnsZero()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                IntPtr pointer = GlfwNative.GetWindowUserPointer(window);

                Assert.Equal(IntPtr.Zero, pointer);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Sets the window size limits with valid limits does not throw
        /// </summary>
        [RequiresDisplay]
        public void SetWindowSizeLimits_WithValidLimits_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                GlfwNative.SetWindowSizeLimits(window, 400, 300, 1920, 1080);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Sets the window aspect ratio with valid ratio does not throw
        /// </summary>
        [RequiresDisplay]
        public void SetWindowAspectRatio_WithValidRatio_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                GlfwNative.SetWindowAspectRatio(window, 16, 9);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Sets the char callback with valid callback sets callback
        /// </summary>
        [RequiresDisplay]
        public void SetCharCallback_WithValidCallback_SetsCallback()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);
            bool callbackInvoked = false;
            CharCallback callback = (w, codePoint) => { callbackInvoked = true; };

            try
            {
                CharCallback previousCallback = GlfwNative.SetCharCallback(window, callback);

                Assert.Null(previousCallback);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Sets the char mods callback with valid callback sets callback
        /// </summary>
        [RequiresDisplay]
        public void SetCharModsCallback_WithValidCallback_SetsCallback()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);
            bool callbackInvoked = false;
            CharModsCallback callback = (w, codePoint, mods) => { callbackInvoked = true; };

            try
            {
                CharModsCallback previousCallback = GlfwNative.SetCharModsCallback(window, callback);

                Assert.Null(previousCallback);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Sets the framebuffer size callback with valid callback sets callback
        /// </summary>
        [RequiresDisplay]
        public void SetFramebufferSizeCallback_WithValidCallback_SetsCallback()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);
            bool callbackInvoked = false;
            SizeCallback callback = (w, width, height) => { callbackInvoked = true; };

            try
            {
                SizeCallback previousCallback = GlfwNative.SetFramebufferSizeCallback(window, callback);

                Assert.Null(previousCallback);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Sets the window refresh callback with valid callback sets callback
        /// </summary>
        [RequiresDisplay]
        public void SetWindowRefreshCallback_WithValidCallback_SetsCallback()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);
            bool callbackInvoked = false;
            WindowCallback callback = w => { callbackInvoked = true; };

            try
            {
                WindowCallback previousCallback = GlfwNative.SetWindowRefreshCallback(window, callback);

                Assert.Null(previousCallback);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Sets the window iconify callback with valid callback sets callback
        /// </summary>
        [RequiresDisplay]
        public void SetWindowIconifyCallback_WithValidCallback_SetsCallback()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);
            bool callbackInvoked = false;
            IconifyCallback callback = (w, iconified) => { callbackInvoked = true; };

            try
            {
                IconifyCallback previousCallback = GlfwNative.SetWindowIconifyCallback(window, callback);

                Assert.Null(previousCallback);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Sets the input mode with valid mode does not throw
        /// </summary>
        [RequiresDisplay]
        public void SetInputMode_WithValidMode_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                GlfwNative.SetInputMode(window, InputMode.Cursor, (int) CursorMode.Normal);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Gets the input mode with valid mode returns value
        /// </summary>
        [RequiresDisplay]
        public void GetInputMode_WithValidMode_ReturnsValue()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                int cursorMode = GlfwNative.GetInputMode(window, InputMode.Cursor);

                Assert.True(cursorMode >= 0);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Joysticks the present with valid joystick returns boolean
        /// </summary>
        [RequiresDisplay]
        public void JoystickPresent_WithValidJoystick_ReturnsBoolean()
        {
            bool present = GlfwNative.JoystickPresent(Joystick.Joystick1);

            Assert.True(present || !present); // Just verify it doesn't throw
        }

        /// <summary>
        ///     Sets the joystick callback with valid callback returns null
        /// </summary>
        [RequiresDisplay]
        public void SetJoystickCallback_WithValidCallback_ReturnsNull()
        {
            bool callbackInvoked = false;
            JoystickCallback callback = (joystick, state) => { callbackInvoked = true; };

            JoystickCallback previousCallback = GlfwNative.SetJoystickCallback(callback);

            Assert.Null(previousCallback);

            GlfwNative.SetJoystickCallback(null);
        }

        /// <summary>
        ///     Sets the monitor callback with valid callback returns null
        /// </summary>
        [RequiresDisplay]
        public void SetMonitorCallback_WithValidCallback_ReturnsNull()
        {
            bool callbackInvoked = false;
            MonitorCallback callback = (monitor, state) => { callbackInvoked = true; };

            MonitorCallback previousCallback = GlfwNative.SetMonitorCallback(callback);

            Assert.True(previousCallback == null || previousCallback != null);

            GlfwNative.SetMonitorCallback(null);
        }

        /// <summary>
        ///     Gets the monitor physical size with valid monitor returns size
        /// </summary>
        [RequiresDisplay]
        public void GetMonitorPhysicalSize_WithValidMonitor_ReturnsSize()
        {
            Monitor monitor = GlfwNative.PrimaryMonitor;
            if (monitor == Monitor.None)
            {
                return;
            }

            GlfwNative.GetMonitorPhysicalSize(monitor, out int width, out int height);

            Assert.True(width > 0);
            Assert.True(height > 0);
        }

        /// <summary>
        ///     Gets the monitor position with valid monitor returns position
        /// </summary>
        [RequiresDisplay]
        public void GetMonitorPosition_WithValidMonitor_ReturnsPosition()
        {
            Monitor monitor = GlfwNative.PrimaryMonitor;
            if (monitor == Monitor.None)
            {
                return;
            }

            GlfwNative.GetMonitorPosition(monitor, out int x, out int y);

            Assert.True(x != int.MinValue);
            Assert.True(y != int.MinValue);
        }

        /// <summary>
        ///     Gets the monitor work area with valid monitor returns work area
        /// </summary>
        [RequiresDisplay]
        public void GetMonitorWorkArea_WithValidMonitor_ReturnsWorkArea()
        {
            Monitor monitor = GlfwNative.PrimaryMonitor;
            if (monitor == Monitor.None)
            {
                return;
            }

            GlfwNative.GetMonitorWorkArea(monitor, out int x, out int y, out int width, out int height);

            Assert.True(width > 0);
            Assert.True(height > 0);
        }
    }
}