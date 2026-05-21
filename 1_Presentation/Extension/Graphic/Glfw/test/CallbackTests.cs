

using Alis.Extension.Graphic.Glfw.Enums;
using Alis.Extension.Graphic.Glfw.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Tests for callback delegates
    /// </summary>
    public class CallbackTests
    {
        /// <summary>
        ///     Tests that char callback can be instantiated
        /// </summary>
        [Fact]
        public void CharCallback_CanBeInstantiated()
        {
            CharCallback callback = (window, codePoint) => { };

            Assert.NotNull(callback);
        }

        /// <summary>
        ///     Tests that char callback can be invoked
        /// </summary>
        [Fact]
        public void CharCallback_CanBeInvoked()
        {
            uint receivedCodePoint = 0;
            CharCallback callback = (window, codePoint) => { receivedCodePoint = codePoint; };

            callback(Window.None, 65);

            Assert.Equal(65u, receivedCodePoint);
        }

        /// <summary>
        ///     Tests that key callback can be instantiated
        /// </summary>
        [Fact]
        public void KeyCallback_CanBeInstantiated()
        {
            KeyCallback callback = (window, key, scanCode, state, mods) => { };

            Assert.NotNull(callback);
        }

        /// <summary>
        ///     Tests that key callback can be invoked
        /// </summary>
        [Fact]
        public void KeyCallback_CanBeInvoked()
        {
            Keys receivedKey = Keys.Unknown;
            KeyCallback callback = (window, key, scanCode, state, mods) => { receivedKey = key; };

            callback(Window.None, Keys.A, 0, InputState.Press, ModifierKeys.None);

            Assert.Equal(Keys.A, receivedKey);
        }

        /// <summary>
        ///     Tests that mouse button callback can be instantiated
        /// </summary>
        [Fact]
        public void MouseButtonCallback_CanBeInstantiated()
        {
            MouseButtonCallback callback = (window, button, state, mods) => { };

            Assert.NotNull(callback);
        }

        /// <summary>
        ///     Tests that mouse button callback can be invoked
        /// </summary>
        [Fact]
        public void MouseButtonCallback_CanBeInvoked()
        {
            MouseButton receivedButton = MouseButton.Button1;
            MouseButtonCallback callback = (window, button, state, mods) => { receivedButton = button; };

            callback(Window.None, MouseButton.Left, InputState.Press, ModifierKeys.None);

            Assert.Equal(MouseButton.Left, receivedButton);
        }

        /// <summary>
        ///     Tests that mouse callback can be instantiated
        /// </summary>
        [Fact]
        public void MouseCallback_CanBeInstantiated()
        {
            MouseCallback callback = (window, x, y) => { };

            Assert.NotNull(callback);
        }

        /// <summary>
        ///     Tests that mouse callback can be invoked
        /// </summary>
        [Fact]
        public void MouseCallback_CanBeInvoked()
        {
            double receivedX = 0;
            double receivedY = 0;
            MouseCallback callback = (window, x, y) =>
            {
                receivedX = x;
                receivedY = y;
            };

            callback(Window.None, 100.5, 200.7);

            Assert.Equal(100.5, receivedX);
            Assert.Equal(200.7, receivedY);
        }

        /// <summary>
        ///     Tests that window callback can be instantiated
        /// </summary>
        [Fact]
        public void WindowCallback_CanBeInstantiated()
        {
            WindowCallback callback = window => { };

            Assert.NotNull(callback);
        }

        /// <summary>
        ///     Tests that window callback can be invoked
        /// </summary>
        [Fact]
        public void WindowCallback_CanBeInvoked()
        {
            bool wasCalled = false;
            WindowCallback callback = window => { wasCalled = true; };

            callback(Window.None);

            Assert.True(wasCalled);
        }

        /// <summary>
        ///     Tests that size callback can be instantiated
        /// </summary>
        [Fact]
        public void SizeCallback_CanBeInstantiated()
        {
            SizeCallback callback = (window, width, height) => { };

            Assert.NotNull(callback);
        }

        /// <summary>
        ///     Tests that size callback can be invoked
        /// </summary>
        [Fact]
        public void SizeCallback_CanBeInvoked()
        {
            int receivedWidth = 0;
            int receivedHeight = 0;
            SizeCallback callback = (window, width, height) =>
            {
                receivedWidth = width;
                receivedHeight = height;
            };

            callback(Window.None, 800, 600);

            Assert.Equal(800, receivedWidth);
            Assert.Equal(600, receivedHeight);
        }

        /// <summary>
        ///     Tests that error callback can be instantiated
        /// </summary>
        [Fact]
        public void ErrorCallback_CanBeInstantiated()
        {
            ErrorCallback callback = (errorCode, description) => { };

            Assert.NotNull(callback);
        }

        /// <summary>
        ///     Tests that file drop callback can be instantiated
        /// </summary>
        [Fact]
        public void FileDropCallback_CanBeInstantiated()
        {
            FileDropCallback callback = (window, count, paths) => { };

            Assert.NotNull(callback);
        }

        /// <summary>
        ///     Tests that monitor callback can be instantiated
        /// </summary>
        [Fact]
        public void MonitorCallback_CanBeInstantiated()
        {
            MonitorCallback callback = (monitor, state) => { };

            Assert.NotNull(callback);
        }

        /// <summary>
        ///     Tests that joystick callback can be instantiated
        /// </summary>
        [Fact]
        public void JoystickCallback_CanBeInstantiated()
        {
            JoystickCallback callback = (joystick, state) => { };

            Assert.NotNull(callback);
        }
    }
}