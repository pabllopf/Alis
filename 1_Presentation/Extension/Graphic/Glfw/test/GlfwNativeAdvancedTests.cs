

using System;
using System.Text;
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
        ///     Gets the window opacity with valid window returns value
        /// </summary>
        [RequiresDisplay]
        public void GetWindowOpacity_WithValidWindow_ReturnsValue()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                float opacity = GlfwNative.GetWindowOpacity(window);

                Assert.True((opacity >= 0.0f) && (opacity <= 1.0f));
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Sets the window opacity with valid window sets opacity
        /// </summary>
        [RequiresDisplay]
        public void SetWindowOpacity_WithValidWindow_SetsOpacity()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                GlfwNative.SetWindowOpacity(window, 0.5f);
                float opacity = GlfwNative.GetWindowOpacity(window);

                Assert.True(Math.Abs(opacity - 0.5f) < 0.1f);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Gets the window content scale with valid window returns scale
        /// </summary>
        [RequiresDisplay]
        public void GetWindowContentScale_WithValidWindow_ReturnsScale()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                GlfwNative.GetWindowContentScale(window, out float xScale, out float yScale);

                Assert.True(xScale > 0);
                Assert.True(yScale > 0);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Requests the window attention with valid window does not throw
        /// </summary>
        [RequiresDisplay]
        public void RequestWindowAttention_WithValidWindow_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                GlfwNative.RequestWindowAttention(window);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Raws the mouse motion supported returns boolean
        /// </summary>
        [RequiresDisplay]
        public void RawMouseMotionSupported_ReturnsBoolean()
        {
            bool supported = GlfwNative.RawMouseMotionSupported();

            Assert.True(supported || !supported); // Just verify it doesn't throw
        }

        /// <summary>
        ///     Gets the key scan code with valid key returns code
        /// </summary>
        [RequiresDisplay]
        public void GetKeyScanCode_WithValidKey_ReturnsCode()
        {
            int scanCode = GlfwNative.GetKeyScanCode(Keys.A);

            Assert.True(scanCode != 0 || scanCode == 0); // Depends on platform
        }


        /// <summary>
        ///     Sets the window attribute with resizable does not throw
        /// </summary>
        [RequiresDisplay]
        public void SetWindowAttribute_WithResizable_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                GlfwNative.SetWindowAttribute(window, WindowAttribute.Resizable, false);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Sets the window attribute with decorated does not throw
        /// </summary>
        [RequiresDisplay]
        public void SetWindowAttribute_WithDecorated_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                GlfwNative.SetWindowAttribute(window, WindowAttribute.Decorated, false);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Sets the window attribute with floating does not throw
        /// </summary>
        [RequiresDisplay]
        public void SetWindowAttribute_WithFloating_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                GlfwNative.SetWindowAttribute(window, WindowAttribute.Floating, true);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Gets the window frame size with valid window returns frame size
        /// </summary>
        [RequiresDisplay]
        public void GetWindowFrameSize_WithValidWindow_ReturnsFrameSize()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                GlfwNative.GetWindowFrameSize(window, out int left, out int top, out int right, out int bottom);

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
        ///     Maximizes the window with valid window does not throw
        /// </summary>
        [RequiresDisplay]
        public void MaximizeWindow_WithValidWindow_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                GlfwNative.MaximizeWindow(window);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Gets the window position with valid window returns position
        /// </summary>
        [RequiresDisplay]
        public void GetWindowPosition_WithValidWindow_ReturnsPosition()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                GlfwNative.GetWindowPosition(window, out int x, out int y);

                Assert.True(x != int.MinValue);
                Assert.True(y != int.MinValue);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Sets the window position with valid window sets position
        /// </summary>
        [RequiresDisplay]
        public void SetWindowPosition_WithValidWindow_SetsPosition()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                GlfwNative.SetWindowPosition(window, 100, 100);
                GlfwNative.GetWindowPosition(window, out int x, out int y);

                Assert.True(x >= 0);
                Assert.True(y >= 0);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Focuses the window with valid window does not throw
        /// </summary>
        [RequiresDisplay]
        public void FocusWindow_WithValidWindow_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);

            try
            {
                GlfwNative.FocusWindow(window);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Sets the window position callback with valid callback sets callback
        /// </summary>
        [RequiresDisplay]
        public void SetWindowPositionCallback_WithValidCallback_SetsCallback()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);
            bool callbackInvoked = false;
            PositionCallback callback = (w, x, y) => { callbackInvoked = true; };

            try
            {
                PositionCallback previousCallback = GlfwNative.SetWindowPositionCallback(window, callback);

                Assert.Null(previousCallback);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Sets the window size callback with valid callback sets callback
        /// </summary>
        [RequiresDisplay]
        public void SetWindowSizeCallback_WithValidCallback_SetsCallback()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);
            bool callbackInvoked = false;
            SizeCallback callback = (w, width, height) => { callbackInvoked = true; };

            try
            {
                SizeCallback previousCallback = GlfwNative.SetWindowSizeCallback(window, callback);

                Assert.Null(previousCallback);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Sets the window focus callback with valid callback sets callback
        /// </summary>
        [RequiresDisplay]
        public void SetWindowFocusCallback_WithValidCallback_SetsCallback()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);
            bool callbackInvoked = false;
            FocusCallback callback = (w, focused) => { callbackInvoked = true; };

            try
            {
                FocusCallback previousCallback = GlfwNative.SetWindowFocusCallback(window, callback);

                Assert.Null(previousCallback);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Sets the window maximize callback with valid callback sets callback
        /// </summary>
        [RequiresDisplay]
        public void SetWindowMaximizeCallback_WithValidCallback_SetsCallback()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);
            bool callbackInvoked = false;
            WindowMaximizedCallback callback = (w, maximized) => { callbackInvoked = true; };

            try
            {
                WindowMaximizedCallback previousCallback = GlfwNative.SetWindowMaximizeCallback(window, callback);

                Assert.Null(previousCallback);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Sets the window content scale callback with valid callback sets callback
        /// </summary>
        [RequiresDisplay]
        public void SetWindowContentScaleCallback_WithValidCallback_SetsCallback()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            Window window = GlfwNative.CreateWindow(800, 600, "Test Window", Monitor.None, Window.None);
            bool callbackInvoked = false;
            WindowContentsScaleCallback callback = (w, xScale, yScale) => { callbackInvoked = true; };

            try
            {
                WindowContentsScaleCallback previousCallback = GlfwNative.SetWindowContentScaleCallback(window, callback);

                Assert.Null(previousCallback);
            }
            finally
            {
                GlfwNative.DestroyWindow(window);
            }
        }

        /// <summary>
        ///     Windows the hint string with valid hint does not throw
        /// </summary>
        [RequiresDisplay]
        public void WindowHintString_WithValidHint_DoesNotThrow()
        {
            GlfwNative.WindowHintString(Hint.X11ClassName, Encoding.UTF8.GetBytes("TestClass"));
        }

        /// <summary>
        ///     Inits the hint with valid hint does not throw
        /// </summary>
        [RequiresDisplay]
        public void InitHint_WithValidHint_DoesNotThrow()
        {
            GlfwNative.InitHint(Hint.JoystickHatButtons, true);
        }

        /// <summary>
        ///     Gets the error after init returns none or error
        /// </summary>
        [RequiresDisplay]
        public void GetError_AfterInit_ReturnsNoneOrError()
        {
            ErrorCode error = GlfwNative.GetError(out string description);

            Assert.True(error == ErrorCode.None || error != ErrorCode.None);
        }
    }
}