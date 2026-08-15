// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WindowOpacityExecutionTests.cs
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

using Alis.Extension.Graphic.Glfw.Structs;
using Alis.Extension.Graphic.Glfw.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Structs
{
    /// <summary>
    ///     Exercises the Window opacity property against the native GLFW window created by
    ///     the main-thread bootstrap.
    /// </summary>
    public class WindowOpacityExecutionTests
    {
        /// <summary>
        ///     Verifies that the opacity getter executes against the native window.
        /// </summary>
        [RequireGlfwFact]
        public void Opacity_Get_WithRealWindow_Executes()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Window window = ((TestableNativeWindow) GlfwTestBootstrap.Window).UnderlyingWindow;
            float opacity = window.Opacity;
            Assert.True(opacity >= 0.0f);
            Assert.True(opacity <= 1.0f);
        }

        /// <summary>
        ///     Verifies that the opacity setter executes against the native window.
        /// </summary>
        [RequireGlfwFact]
        public void Opacity_Set_WithRealWindow_Executes()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Window window = ((TestableNativeWindow) GlfwTestBootstrap.Window).UnderlyingWindow;
            window.Opacity = 0.5f;
            Assert.Equal(0.5f, window.Opacity);
            window.Opacity = 1.0f;
        }
    }
}
