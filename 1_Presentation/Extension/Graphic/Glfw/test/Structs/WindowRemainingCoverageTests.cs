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
using Alis.Extension.Graphic.Glfw.Test.Skipper;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Structs
{
    public class WindowRemainingCoverageTests : IDisposable
    {
        private NativeWindow window;

        public void Dispose()
        {
            window?.Dispose();
        }

        [RequiresDisplay]
        public void Window_Opacity_Get_ReturnsDefault()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");
            Window w = window;

            float opacity = w.Opacity;

            Assert.Equal(1.0f, opacity);
        }

        [RequiresDisplay]
        public void Window_Opacity_Set_WithinBounds()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");
            Window w = window;

            w.Opacity = 0.5f;

            Assert.Equal(0.5f, w.Opacity);
        }

        [RequiresDisplay]
        public void Window_Opacity_Set_ClampsToZero()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new NativeWindow(800, 600, "Test");
            Window w = window;

            w.Opacity = -0.5f;

            Assert.Equal(0.0f, w.Opacity);
        }

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
