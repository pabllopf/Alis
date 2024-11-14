// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InternalDirectfbWmInfoTests.cs
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
using Alis.Core.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Core.Graphic.Test.Sdl2.Structs
{
    /// <summary>
    ///     The internal directfb wm info tests class
    /// </summary>
    public class InternalDirectfbWmInfoTests
    {
        /// <summary>
        ///     Tests that internal directfb wm info initializes properties correctly
        /// </summary>
        [Fact]
        public void InternalDirectfbWmInfo_InitializesPropertiesCorrectly()
        {
            IntPtr expectedDfb = new IntPtr(123);
            IntPtr expectedWindow = new IntPtr(456);
            IntPtr expectedSurface = new IntPtr(789);

            InternalDirectfbWmInfo info = new InternalDirectfbWmInfo
            {
                Dfb = expectedDfb,
                Window = expectedWindow,
                Surface = expectedSurface
            };

            Assert.Equal(expectedDfb, info.Dfb);
            Assert.Equal(expectedWindow, info.Window);
            Assert.Equal(expectedSurface, info.Surface);
        }
    }
}