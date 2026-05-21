// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NativeWindowTests.cs
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
        ///     The window
        /// </summary>
        private NativeWindow window;

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            window?.Dispose();
        }

        /// <summary>
        ///     Natives the window constructor with parameters creates window
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_ConstructorWithParameters_CreatesWindow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");

            Assert.NotNull(window);
            Assert.False(window.IsInvalid);
        }

        /// <summary>
        ///     Natives the window constructor with all parameters creates window
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_ConstructorWithAllParameters_CreatesWindow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(1024, 768, "Full Test Window", Monitor.None, Window.None);

            Assert.NotNull(window);
            Assert.False(window.IsInvalid);
        }

        /// <summary>
        ///     Natives the window size can get size
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Size_CanGetSize()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");

            Size size = window.Size;

            Assert.Equal(800, size.Width);
            Assert.Equal(600, size.Height);
        }

        /// <summary>
        ///     Natives the window title can get title
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Title_CanGetTitle()
        {
            string expectedTitle = "Test Title";
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, expectedTitle);

            string title = window.Title;

            Assert.Equal(expectedTitle, title);
        }

        /// <summary>
        ///     Natives the window title can set title
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Title_CanSetTitle()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Initial Title");
            string newTitle = "New Title";

            window.Title = newTitle;

            Assert.Equal(newTitle, window.Title);
        }

        /// <summary>
        ///     Natives the window position can get position
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Position_CanGetPosition()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");

            Point position = window.Position;

            Assert.True(position.X != int.MinValue);
            Assert.True(position.Y != int.MinValue);
        }

        /// <summary>
        ///     Natives the window position can set position
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Position_CanSetPosition()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");
            Point newPosition = new Point(100, 100);

            window.Position = newPosition;
        }

        /// <summary>
        ///     Natives the window bounds can get bounds
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Bounds_CanGetBounds()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");

            Rectangle bounds = window.Bounds;

            Assert.True(bounds.Width > 0);
            Assert.True(bounds.Height > 0);
        }

        /// <summary>
        ///     Natives the window close does not throw
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Close_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");

            window.Close();
        }

        /// <summary>
        ///     Natives the window focus does not throw
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Focus_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");

            window.Focus();
        }


        /// <summary>
        ///     Natives the window maximize does not throw
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Maximize_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");

            window.Maximize();
        }

        /// <summary>
        ///     Natives the window minimize does not throw
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Minimize_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");

            window.Minimize();
        }

        /// <summary>
        ///     Natives the window restore does not throw
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Restore_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");

            window.Restore();
        }

        /// <summary>
        ///     Natives the window content scale returns valid scale
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_ContentScale_ReturnsValidScale()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");

            PointF contentScale = window.ContentScale;

            Assert.True(contentScale.X > 0);
            Assert.True(contentScale.Y > 0);
        }


        /// <summary>
        ///     Natives the window equals with same window returns true
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_Equals_WithSameWindow_ReturnsTrue()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");

            bool result = window.Equals(window);

            Assert.True(result);
        }

        /// <summary>
        ///     Natives the window get hash code returns consistent value
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_GetHashCode_ReturnsConsistentValue()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");

            int hash1 = window.GetHashCode();
            int hash2 = window.GetHashCode();

            Assert.Equal(hash1, hash2);
        }

        /// <summary>
        ///     Natives the window make current does not throw
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_MakeCurrent_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");

            window.MakeCurrent();
        }

        /// <summary>
        ///     Natives the window swap buffers does not throw
        /// </summary>
        [RequiresDisplay]
        public void NativeWindow_SwapBuffers_DoesNotThrow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test Window");

            window.SwapBuffers();
        }
    }
}