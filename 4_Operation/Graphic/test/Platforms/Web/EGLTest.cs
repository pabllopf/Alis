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
            Assert.Equal(0x3038, Egl.EGL_NONE);
            Assert.Equal(0x3024, Egl.EGL_RED_SIZE);
            Assert.Equal(0x3023, Egl.EGL_GREEN_SIZE);
            Assert.Equal(0x3022, Egl.EGL_BLUE_SIZE);
            Assert.Equal(0x3025, Egl.EGL_DEPTH_SIZE);
            Assert.Equal(0x3026, Egl.EGL_STENCIL_SIZE);
            Assert.Equal(0x3033, Egl.EGL_SURFACE_TYPE);
            Assert.Equal(0x3040, Egl.EGL_RENDERABLE_TYPE);
            Assert.Equal(0x3031, Egl.EGL_SAMPLES);
            Assert.Equal(0x0004, Egl.EGL_WINDOW_BIT);
            Assert.Equal(0x0004, Egl.EGL_OPENGL_ES2_BIT);
            Assert.Equal(0x00000040, Egl.EGL_OPENGL_ES3_BIT);
            Assert.Equal(0x3098, Egl.EGL_CONTEXT_CLIENT_VERSION);
            Assert.Equal(0x0, Egl.EGL_NO_CONTEXT);
            Assert.Equal(0x302E, Egl.EGL_NATIVE_VISUAL_ID);
            Assert.Equal(0x30A0, Egl.EGL_OPENGL_ES_API);
        }

        [Fact]
        public void EglConstants_LibEgl_IsCorrectString()
        {
            Assert.Equal("libEGL", Egl.LibEgl);
        }
    }
}
