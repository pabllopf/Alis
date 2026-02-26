// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CallbackTests.cs
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
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Tests for callback delegates
    /// </summary>
    public class CallbackTests
    {
        /// <summary>
        /// Tests that char callback can be instantiated
        /// </summary>
        [Fact]
        public void CharCallback_CanBeInstantiated()
        {
            // Arrange & Act
            CharCallback callback = (window, codePoint) => { };

            // Assert
            Assert.NotNull(callback);
        }

        /// <summary>
        /// Tests that char callback can be invoked
        /// </summary>
        [Fact]
        public void CharCallback_CanBeInvoked()
        {
            // Arrange
            uint receivedCodePoint = 0;
            CharCallback callback = (window, codePoint) => { receivedCodePoint = codePoint; };

            // Act
            callback(Window.None, 65);

            // Assert
            Assert.Equal(65u, receivedCodePoint);
        }

        /// <summary>
        /// Tests that key callback can be instantiated
        /// </summary>
        [Fact]
        public void KeyCallback_CanBeInstantiated()
        {
            // Arrange & Act
            KeyCallback callback = (window, key, scanCode, state, mods) => { };

            // Assert
            Assert.NotNull(callback);
        }

        /// <summary>
        /// Tests that key callback can be invoked
        /// </summary>
        [Fact]
        public void KeyCallback_CanBeInvoked()
        {
            // Arrange
            Keys receivedKey = Keys.Unknown;
            KeyCallback callback = (window, key, scanCode, state, mods) => { receivedKey = key; };

            // Act
            callback(Window.None, Keys.A, 0, InputState.Press, ModifierKeys.None);

            // Assert
            Assert.Equal(Keys.A, receivedKey);
        }

        /// <summary>
        /// Tests that mouse button callback can be instantiated
        /// </summary>
        [Fact]
        public void MouseButtonCallback_CanBeInstantiated()
        {
            // Arrange & Act
            MouseButtonCallback callback = (window, button, state, mods) => { };

            // Assert
            Assert.NotNull(callback);
        }

        /// <summary>
        /// Tests that mouse button callback can be invoked
        /// </summary>
        [Fact]
        public void MouseButtonCallback_CanBeInvoked()
        {
            // Arrange
            MouseButton receivedButton = MouseButton.Button1;
            MouseButtonCallback callback = (window, button, state, mods) => { receivedButton = button; };

            // Act
            callback(Window.None, MouseButton.Left, InputState.Press, ModifierKeys.None);

            // Assert
            Assert.Equal(MouseButton.Left, receivedButton);
        }

        /// <summary>
        /// Tests that mouse callback can be instantiated
        /// </summary>
        [Fact]
        public void MouseCallback_CanBeInstantiated()
        {
            // Arrange & Act
            MouseCallback callback = (window, x, y) => { };

            // Assert
            Assert.NotNull(callback);
        }

        /// <summary>
        /// Tests that mouse callback can be invoked
        /// </summary>
        [Fact]
        public void MouseCallback_CanBeInvoked()
        {
            // Arrange
            double receivedX = 0;
            double receivedY = 0;
            MouseCallback callback = (window, x, y) =>
            {
                receivedX = x;
                receivedY = y;
            };

            // Act
            callback(Window.None, 100.5, 200.7);

            // Assert
            Assert.Equal(100.5, receivedX);
            Assert.Equal(200.7, receivedY);
        }

        /// <summary>
        /// Tests that window callback can be instantiated
        /// </summary>
        [Fact]
        public void WindowCallback_CanBeInstantiated()
        {
            // Arrange & Act
            WindowCallback callback = (window) => { };

            // Assert
            Assert.NotNull(callback);
        }

        /// <summary>
        /// Tests that window callback can be invoked
        /// </summary>
        [Fact]
        public void WindowCallback_CanBeInvoked()
        {
            // Arrange
            bool wasCalled = false;
            WindowCallback callback = (window) => { wasCalled = true; };

            // Act
            callback(Window.None);

            // Assert
            Assert.True(wasCalled);
        }

        /// <summary>
        /// Tests that size callback can be instantiated
        /// </summary>
        [Fact]
        public void SizeCallback_CanBeInstantiated()
        {
            // Arrange & Act
            SizeCallback callback = (window, width, height) => { };

            // Assert
            Assert.NotNull(callback);
        }

        /// <summary>
        /// Tests that size callback can be invoked
        /// </summary>
        [Fact]
        public void SizeCallback_CanBeInvoked()
        {
            // Arrange
            int receivedWidth = 0;
            int receivedHeight = 0;
            SizeCallback callback = (window, width, height) =>
            {
                receivedWidth = width;
                receivedHeight = height;
            };

            // Act
            callback(Window.None, 800, 600);

            // Assert
            Assert.Equal(800, receivedWidth);
            Assert.Equal(600, receivedHeight);
        }

        /// <summary>
        /// Tests that error callback can be instantiated
        /// </summary>
        [Fact]
        public void ErrorCallback_CanBeInstantiated()
        {
            // Arrange & Act
            ErrorCallback callback = (errorCode, description) => { };

            // Assert
            Assert.NotNull(callback);
        }

        /// <summary>
        /// Tests that file drop callback can be instantiated
        /// </summary>
        [Fact]
        public void FileDropCallback_CanBeInstantiated()
        {
            // Arrange & Act
            FileDropCallback callback = (window, count, paths) => { };

            // Assert
            Assert.NotNull(callback);
        }

        /// <summary>
        /// Tests that monitor callback can be instantiated
        /// </summary>
        [Fact]
        public void MonitorCallback_CanBeInstantiated()
        {
            // Arrange & Act
            MonitorCallback callback = (monitor, state) => { };

            // Assert
            Assert.NotNull(callback);
        }

        /// <summary>
        /// Tests that joystick callback can be instantiated
        /// </summary>
        [Fact]
        public void JoystickCallback_CanBeInstantiated()
        {
            // Arrange & Act
            JoystickCallback callback = (joystick, state) => { };

            // Assert
            Assert.NotNull(callback);
        }
    }
}

