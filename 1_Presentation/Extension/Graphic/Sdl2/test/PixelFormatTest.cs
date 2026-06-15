// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PixelFormatTest.cs
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

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The pixel format test class
    /// </summary>
    public class PixelFormatTest
    {
        /// <summary>
        /// Tests that should default to zero
        /// </summary>
        [Fact]
        public void ShouldDefaultToZero()
        {
            PixelFormat fmt = new PixelFormat();
            Assert.Equal(0u, fmt.format);
            Assert.Equal(IntPtr.Zero, fmt.Palette);
            Assert.Equal(0, fmt.BitsPerPixel);
            Assert.Equal(0, fmt.BytesPerPixel);
            Assert.Equal(0u, fmt.RMask);
            Assert.Equal(0u, fmt.GMask);
            Assert.Equal(0u, fmt.BMask);
            Assert.Equal(0u, fmt.AMask);
            Assert.Equal(0, fmt.refCount);
            Assert.Equal(IntPtr.Zero, fmt.Next);
        }

        /// <summary>
        /// Tests that should assign palette
        /// </summary>
        [Fact]
        public void ShouldAssignPalette()
        {
            PixelFormat fmt = new PixelFormat();
            fmt.Palette = new IntPtr(0xFADE);
            Assert.Equal(new IntPtr(0xFADE), fmt.Palette);
        }

        /// <summary>
        /// Tests that should assign next
        /// </summary>
        [Fact]
        public void ShouldAssignNext()
        {
            PixelFormat fmt = new PixelFormat();
            fmt.Next = new IntPtr(0xBEEF);
            Assert.Equal(new IntPtr(0xBEEF), fmt.Next);
        }
    }
}
