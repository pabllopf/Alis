// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InternalDirectfbWmInfoTest.cs
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

using Xunit;
using System;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The internal directfb wm info test class
    /// </summary>
    public class InternalDirectfbWmInfoTest
    {
        /// <summary>
        /// Tests that should default to zero
        /// </summary>
        [Fact]
        public void ShouldDefaultToZero()
        {
            InternalDirectfbWmInfo obj = new InternalDirectfbWmInfo();
            Assert.Equal(IntPtr.Zero, obj.Dfb);
            Assert.Equal(IntPtr.Zero, obj.Window);
            Assert.Equal(IntPtr.Zero, obj.Surface);
        }

        /// <summary>
        /// Tests that should assign and retrieve properties
        /// </summary>
        [Fact]
        public void ShouldAssignAndRetrieveProperties()
        {
            InternalDirectfbWmInfo obj = new InternalDirectfbWmInfo();
            IntPtr testDfb = IntPtr.Zero + 1;
            IntPtr testWindow = IntPtr.Zero + 2;
            IntPtr testSurface = IntPtr.Zero + 3;
            obj.Dfb = testDfb;
            obj.Window = testWindow;
            obj.Surface = testSurface;
            Assert.Equal(testDfb, obj.Dfb);
            Assert.Equal(testWindow, obj.Window);
            Assert.Equal(testSurface, obj.Surface);
        }
    }
}
