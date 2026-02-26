// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WindowEventsTests.cs
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
using Alis.Core.Graphic.OpenGL;
using Alis.Extension.Graphic.Glfw.Enums;
using Alis.Extension.Graphic.Glfw.Test.Skipper;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Tests for window events and callbacks
    /// </summary>
    [Collection("GLFW")]
    public class WindowEventsTests
    {
        /// <summary>
        /// Disposes the window with subscribed events should succeed
        /// </summary>
        [RequiresDisplay]
        public void DisposeWindowWithSubscribedEvents_ShouldSucceed()
        {
            GlfwNative.Init();

            Gl.Initialize(GlfwNative.GetProcAddress);
            
            // Set GLFW window hints for OpenGL context
            GlfwNative.WindowHint(Hint.ContextVersionMajor, 3);
            GlfwNative.WindowHint(Hint.ContextVersionMinor, 2);
            GlfwNative.WindowHint(Hint.OpenglProfile, GlfwProfile.Core);
            GlfwNative.WindowHint(Hint.OpenglForwardCompatible, true);
            GlfwNative.WindowHint(Hint.Doublebuffer, true);
            GlfwNative.WindowHint(Hint.DepthBits, 24);
            GlfwNative.WindowHint(Hint.AlphaBits, 8);
            GlfwNative.WindowHint(Hint.StencilBits, 8);
            
            NativeWindow window = new NativeWindow(800, 600, "Test");
            window.Closed += (s, e) => { };
            window.FocusChanged += (s, e) => { };
            window.Dispose();
            Assert.NotNull(window);
        }
        
    }
}
