// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EGLTest.cs
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

using Alis.Core.Graphic.Platforms.Web;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    ///     Tests for EGL constants.
    /// </summary>
    public class EGLTest
    {
        [Fact]
        public void EglConstants_HaveExpectedValues()
        {
            Assert.Equal(0x3038, EGL.EGL_NONE);
            Assert.Equal(0x3024, EGL.EGL_RED_SIZE);
            Assert.Equal(0x3023, EGL.EGL_GREEN_SIZE);
            Assert.Equal(0x3022, EGL.EGL_BLUE_SIZE);
            Assert.Equal(0x3025, EGL.EGL_DEPTH_SIZE);
            Assert.Equal(0x3026, EGL.EGL_STENCIL_SIZE);
            Assert.Equal(0x3033, EGL.EGL_SURFACE_TYPE);
            Assert.Equal(0x3040, EGL.EGL_RENDERABLE_TYPE);
            Assert.Equal(0x3031, EGL.EGL_SAMPLES);
            Assert.Equal(0x0004, EGL.EGL_WINDOW_BIT);
            Assert.Equal(0x0004, EGL.EGL_OPENGL_ES2_BIT);
            Assert.Equal(0x00000040, EGL.EGL_OPENGL_ES3_BIT);
            Assert.Equal(0x3098, EGL.EGL_CONTEXT_CLIENT_VERSION);
            Assert.Equal(0x0, EGL.EGL_NO_CONTEXT);
            Assert.Equal(0x302E, EGL.EGL_NATIVE_VISUAL_ID);
            Assert.Equal(0x30A0, EGL.EGL_OPENGL_ES_API);
        }

        [Fact]
        public void EglConstants_LibEgl_IsCorrectString()
        {
            Assert.Equal("libEGL", EGL.LibEgl);
        }
    }
}
