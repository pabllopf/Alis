// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NativeWindowTests.cs
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
using System.Drawing;
using Alis.Extension.Graphic.Glfw.Enums;
using Alis.Extension.Graphic.Glfw.Structs;
using Alis.Extension.Graphic.Glfw.Test.Skipper;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Tests for NativeWindow class
    /// </summary>
    public class NativeWindowTests : IDisposable
    {
        /// <summary>
        /// The window
        /// </summary>
        private NativeWindow window;

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            window?.Dispose();
        }

        /// <summary>
        /// Natives the window default constructor creates window
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_DefaultConstructor_CreatesWindow()
        {
            // Arrange & Act
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow();

            // Assert
            Assert.NotNull(window);
            Assert.False(window.IsInvalid);
        }

        /// <summary>
        /// Natives the window constructor with parameters creates window
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_ConstructorWithParameters_CreatesWindow()
        {
            // Arrange & Act
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");

            // Assert
            Assert.NotNull(window);
            Assert.False(window.IsInvalid);
        }

        /// <summary>
        /// Natives the window constructor with all parameters creates window
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_ConstructorWithAllParameters_CreatesWindow()
        {
            // Arrange & Act
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(1024, 768, "Full Test Window", Monitor.None, Window.None);

            // Assert
            Assert.NotNull(window);
            Assert.False(window.IsInvalid);
        }

        /// <summary>
        /// Natives the window size can get size
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Size_CanGetSize()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");

            // Act
            Size size = window.Size;

            // Assert
            Assert.Equal(800, size.Width);
            Assert.Equal(600, size.Height);
        }

        /// <summary>
        /// Natives the window size can set size
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Size_CanSetSize()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");
            Size newSize = new Size(1024, 768);

            // Act
            window.Size = newSize;

            // Assert
            Assert.Equal(1024, window.Size.Width);
            Assert.Equal(768, window.Size.Height);
        }

        /// <summary>
        /// Natives the window title can get title
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Title_CanGetTitle()
        {
            // Arrange
            string expectedTitle = "Test Title";
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, expectedTitle);

            // Act
            string title = window.Title;

            // Assert
            Assert.Equal(expectedTitle, title);
        }

        /// <summary>
        /// Natives the window title can set title
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Title_CanSetTitle()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Initial Title");
            string newTitle = "New Title";

            // Act
            window.Title = newTitle;

            // Assert
            Assert.Equal(newTitle, window.Title);
        }

        /// <summary>
        /// Natives the window position can get position
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Position_CanGetPosition()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");

            // Act
            Point position = window.Position;

            // Assert - Just verify it doesn't throw
            Assert.True(position.X != int.MinValue);
            Assert.True(position.Y != int.MinValue);
        }

        /// <summary>
        /// Natives the window position can set position
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Position_CanSetPosition()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");
            Point newPosition = new Point(100, 100);

            // Act & Assert - Should not throw
            window.Position = newPosition;
        }

        /// <summary>
        /// Natives the window bounds can get bounds
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Bounds_CanGetBounds()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");

            // Act
            Rectangle bounds = window.Bounds;

            // Assert
            Assert.True(bounds.Width > 0);
            Assert.True(bounds.Height > 0);
        }

        /// <summary>
        /// Natives the window bounds can set bounds
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Bounds_CanSetBounds()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");
            Rectangle newBounds = new Rectangle(50, 50, 1024, 768);

            // Act
            window.Bounds = newBounds;

            // Assert
            Assert.Equal(1024, window.Size.Width);
            Assert.Equal(768, window.Size.Height);
        }

        /// <summary>
        /// Natives the window close does not throw
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Close_DoesNotThrow()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");

            // Act & Assert
            window.Close();
        }

        /// <summary>
        /// Natives the window focus does not throw
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Focus_DoesNotThrow()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");

            // Act & Assert
            window.Focus();
        }
        

        /// <summary>
        /// Natives the window maximize does not throw
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Maximize_DoesNotThrow()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");

            // Act & Assert
            window.Maximize();
        }

        /// <summary>
        /// Natives the window minimize does not throw
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Minimize_DoesNotThrow()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");

            // Act & Assert
            window.Minimize();
        }

        /// <summary>
        /// Natives the window restore does not throw
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Restore_DoesNotThrow()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");

            // Act & Assert
            window.Restore();
        }

        /// <summary>
        /// Natives the window content scale returns valid scale
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_ContentScale_ReturnsValidScale()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");

            // Act
            PointF contentScale = window.ContentScale;

            // Assert
            Assert.True(contentScale.X > 0);
            Assert.True(contentScale.Y > 0);
        }
        

        /// <summary>
        /// Natives the window equals with same window returns true
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Equals_WithSameWindow_ReturnsTrue()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");

            // Act
            bool result = window.Equals(window);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Natives the window get hash code returns consistent value
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_GetHashCode_ReturnsConsistentValue()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");

            // Act
            int hash1 = window.GetHashCode();
            int hash2 = window.GetHashCode();

            // Assert
            Assert.Equal(hash1, hash2);
        }

        /// <summary>
        /// Natives the window make current does not throw
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_MakeCurrent_DoesNotThrow()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");

            // Act & Assert
            window.MakeCurrent();
        }

        /// <summary>
        /// Natives the window swap buffers does not throw
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_SwapBuffers_DoesNotThrow()
        {
            // Arrange
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");

            // Act & Assert
            window.SwapBuffers();
        }
    }
}

