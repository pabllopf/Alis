// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WindowRemainingCoverageTests.cs
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
using Alis.Extension.Graphic.Glfw.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Structs
{
    /// <summary>
    /// The window remaining coverage tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class WindowRemainingCoverageTests : IDisposable
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
        /// Windows the opacity set within bounds
        /// </summary>
        [RequiresDisplay]
        public void Window_Opacity_Set_WithinBounds()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");
            Window w = window;

            w.Opacity = 0.5f;

            Assert.Equal(0.5f, w.Opacity);
        }

        /// <summary>
        /// Windows the opacity set clamps to zero
        /// </summary>
        [RequiresDisplay]
        public void Window_Opacity_Set_ClampsToZero()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");
            Window w = window;

            w.Opacity = -0.5f;

            Assert.Equal(0.0f, w.Opacity);
        }

        /// <summary>
        /// Windows the opacity set clamps to one
        /// </summary>
        [RequiresDisplay]
        public void Window_Opacity_Set_ClampsToOne()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");
            Window w = window;

            w.Opacity = 1.5f;

            Assert.Equal(1.0f, w.Opacity);
        }
    }
}
