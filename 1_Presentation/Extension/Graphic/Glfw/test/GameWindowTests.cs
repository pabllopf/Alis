// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameWindowTests.cs
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
    ///     Tests for GameWindow class
    /// </summary>
    public class GameWindowTests : IDisposable
    {
        /// <summary>
        /// The window
        /// </summary>
        private GameWindow window;

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            window?.Dispose();
        }

        /// <summary>
        /// Games the window default constructor creates window
        /// </summary>
        [RequiresDisplay]
        public void GameWindow_DefaultConstructor_CreatesWindow()
        {
            // Arrange & Act
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new GameWindow();

            // Assert
            Assert.NotNull(window);
            Assert.False(window.IsInvalid);
        }

        /// <summary>
        /// Games the window constructor with parameters creates window
        /// </summary>
        [RequiresDisplay]
        public void GameWindow_ConstructorWithParameters_CreatesWindow()
        {
            // Arrange & Act
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new GameWindow(800, 600, "Test Game Window");

            // Assert
            Assert.NotNull(window);
            Assert.False(window.IsInvalid);
        }

        /// <summary>
        /// Games the window constructor with all parameters creates window
        /// </summary>
        [RequiresDisplay]
        public void GameWindow_ConstructorWithAllParameters_CreatesWindow()
        {
            // Arrange & Act
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new GameWindow(1024, 768, "Full Test Window", Monitor.None, Window.None);

            // Assert
            Assert.NotNull(window);
            Assert.False(window.IsInvalid);
        }

        /// <summary>
        /// Games the window inherits from native window
        /// </summary>
        [RequiresDisplay]
        public void GameWindow_InheritsFromNativeWindow()
        {
            // Arrange & Act
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new GameWindow();

            // Assert
            Assert.IsAssignableFrom<NativeWindow>(window);
        }

        /// <summary>
        /// Games the window can be disposed
        /// </summary>
        [RequiresDisplay]
        public void GameWindow_CanBeDisposed()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new GameWindow(800, 600, "Disposable Window");

            // Act & Assert - Should not throw
            window.Dispose();
        }

        /// <summary>
        /// Games the window with custom size has correct size
        /// </summary>
        [RequiresDisplay]
        public void GameWindow_WithCustomSize_HasCorrectSize()
        {
            // Arrange
            int expectedWidth = 1280;
            int expectedHeight = 720;
            GlfwNative.WindowHint(Hint.Visible, false);

            // Act
            window = new GameWindow(expectedWidth, expectedHeight, "Sized Window");
            var size = window.Size;

            // Assert
            Assert.Equal(expectedWidth, size.Width);
            Assert.Equal(expectedHeight, size.Height);
        }
    }
}

