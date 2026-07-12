// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CallbackTests.cs
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
        ///     Tests that error callback can be invoked
        /// </summary>
        [Fact]
        public void ErrorCallback_CanBeInvoked()
        {
            ErrorCode receivedCode = ErrorCode.Unknown;
            ErrorCallback callback = (errorCode, description) => { receivedCode = errorCode; };

            callback(ErrorCode.Unknown, IntPtr.Zero);

            Assert.Equal(ErrorCode.Unknown, receivedCode);
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
        /// <summary>
        ///     Tests that char mods callback can be instantiated
        /// </summary>
        [Fact]
        public void CharModsCallback_CanBeInstantiated()
        {
            CharModsCallback callback = (window, codePoint, mods) => { };

            Assert.NotNull(callback);
        }

        /// <summary>
        ///     Tests that char mods callback can be invoked
        /// </summary>
        [Fact]
        public void CharModsCallback_CanBeInvoked()
        {
            uint receivedCodePoint = 0;
            CharModsCallback callback = (window, codePoint, mods) => { receivedCodePoint = codePoint; };

            callback(Window.None, 65, ModifierKeys.None);

            Assert.Equal(65u, receivedCodePoint);
        }

        /// <summary>
        ///     Tests that focus callback can be instantiated
        /// </summary>
        [Fact]
        public void FocusCallback_CanBeInstantiated()
        {
            FocusCallback callback = (window, focusing) => { };

            Assert.NotNull(callback);
        }

        /// <summary>
        ///     Tests that focus callback can be invoked
        /// </summary>
        [Fact]
        public void FocusCallback_CanBeInvoked()
        {
            bool receivedFocusing = false;
            FocusCallback callback = (window, focusing) => { receivedFocusing = focusing; };

            callback(Window.None, true);

            Assert.True(receivedFocusing);
        }

        /// <summary>
        ///     Tests that iconify callback can be instantiated
        /// </summary>
        [Fact]
        public void IconifyCallback_CanBeInstantiated()
        {
            IconifyCallback callback = (window, focusing) => { };

            Assert.NotNull(callback);
        }

        /// <summary>
        ///     Tests that iconify callback can be invoked
        /// </summary>
        [Fact]
        public void IconifyCallback_CanBeInvoked()
        {
            bool receivedIconified = false;
            IconifyCallback callback = (window, iconified) => { receivedIconified = iconified; };

            callback(IntPtr.Zero, true);

            Assert.True(receivedIconified);
        }

        /// <summary>
        ///     Tests that mouse enter callback can be instantiated
        /// </summary>
        [Fact]
        public void MouseEnterCallback_CanBeInstantiated()
        {
            MouseEnterCallback callback = (window, entering) => { };

            Assert.NotNull(callback);
        }

        /// <summary>
        ///     Tests that mouse enter callback can be invoked
        /// </summary>
        [Fact]
        public void MouseEnterCallback_CanBeInvoked()
        {
            bool receivedEntering = false;
            MouseEnterCallback callback = (window, entering) => { receivedEntering = entering; };

            callback(Window.None, true);

            Assert.True(receivedEntering);
        }

        /// <summary>
        ///     Tests that position callback can be instantiated
        /// </summary>
        [Fact]
        public void PositionCallback_CanBeInstantiated()
        {
            PositionCallback callback = (window, x, y) => { };

            Assert.NotNull(callback);
        }

        /// <summary>
        ///     Tests that position callback can be invoked
        /// </summary>
        [Fact]
        public void PositionCallback_CanBeInvoked()
        {
            double receivedX = 0;
            double receivedY = 0;
            PositionCallback callback = (window, x, y) =>
            {
                receivedX = x;
                receivedY = y;
            };

            callback(Window.None, 300.5, 400.7);

            Assert.Equal(300.5, receivedX);
            Assert.Equal(400.7, receivedY);
        }

        /// <summary>
        ///     Tests that window contents scale callback can be instantiated
        /// </summary>
        [Fact]
        public void WindowContentsScaleCallback_CanBeInstantiated()
        {
            WindowContentsScaleCallback callback = (window, xScale, yScale) => { };

            Assert.NotNull(callback);
        }

        /// <summary>
        ///     Tests that window contents scale callback can be invoked
        /// </summary>
        [Fact]
        public void WindowContentsScaleCallback_CanBeInvoked()
        {
            float receivedXScale = 0;
            float receivedYScale = 0;
            WindowContentsScaleCallback callback = (window, xScale, yScale) =>
            {
                receivedXScale = xScale;
                receivedYScale = yScale;
            };

            callback(Window.None, 1.5f, 2.0f);

            Assert.Equal(1.5f, receivedXScale);
            Assert.Equal(2.0f, receivedYScale);
        }

        /// <summary>
        ///     Tests that window maximized callback can be instantiated
        /// </summary>
        [Fact]
        public void WindowMaximizedCallback_CanBeInstantiated()
        {
            WindowMaximizedCallback callback = (window, maximized) => { };

            Assert.NotNull(callback);
        }

        /// <summary>
        ///     Tests that window maximized callback can be invoked
        /// </summary>
        [Fact]
        public void WindowMaximizedCallback_CanBeInvoked()
        {
            bool receivedMaximized = false;
            WindowMaximizedCallback callback = (window, maximized) => { receivedMaximized = maximized; };

            callback(Window.None, true);

            Assert.True(receivedMaximized);
        }
    }
}