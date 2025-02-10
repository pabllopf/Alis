// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InternalUikitWmInfoTests.cs
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
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test.Structs
{
    /// <summary>
    ///     The internal uikit wm info tests class
    /// </summary>
    public class InternalUikitWmInfoTests
    {
        /// <summary>
        ///     Tests that internal uikit wm info initializes properties correctly
        /// </summary>
        [Fact]
        public void InternalUikitWmInfo_InitializesPropertiesCorrectly()
        {
            IntPtr expectedWindow = new IntPtr(123);
            uint expectedFramebuffer = 456u;
            uint expectedColorBuffer = 789u;
            uint expectedResolveFramebuffer = 101112u;

            InternalUikitWmInfo info = new InternalUikitWmInfo
            {
                Window = expectedWindow,
                framebuffer = expectedFramebuffer,
                colorBuffer = expectedColorBuffer,
                resolveFramebuffer = expectedResolveFramebuffer
            };

            Assert.Equal(expectedWindow, info.Window);
            Assert.Equal(expectedFramebuffer, info.framebuffer);
            Assert.Equal(expectedColorBuffer, info.colorBuffer);
            Assert.Equal(expectedResolveFramebuffer, info.resolveFramebuffer);
        }
    }
}