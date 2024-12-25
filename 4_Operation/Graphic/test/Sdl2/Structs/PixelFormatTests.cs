// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PixelFormatTests.cs
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
using System.Diagnostics.CodeAnalysis;
using Alis.Core.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Core.Graphic.Test.Sdl2.Structs
{
    /// <summary>
    ///     The pixel format tests class
    /// </summary>
    	 [ExcludeFromCodeCoverage] 
	 public class PixelFormatTests 
    {
        /// <summary>
        ///     Tests that pixel format initializes with default values
        /// </summary>
        [Fact]
        public void PixelFormat_InitializesWithDefaultValues()
        {
            PixelFormat pixelFormat = new PixelFormat();

            Assert.Equal(default(uint), pixelFormat.format);
            Assert.Equal(IntPtr.Zero, pixelFormat.Palette);
            Assert.Equal(default(byte), pixelFormat.BitsPerPixel);
            Assert.Equal(default(byte), pixelFormat.BytesPerPixel);
            Assert.Equal(default(uint), pixelFormat.RMask);
            Assert.Equal(default(uint), pixelFormat.GMask);
            Assert.Equal(default(uint), pixelFormat.BMask);
            Assert.Equal(default(uint), pixelFormat.AMask);
            Assert.Equal(default(byte), pixelFormat.RLoss);
            Assert.Equal(default(byte), pixelFormat.Gloss);
            Assert.Equal(default(byte), pixelFormat.BLoss);
            Assert.Equal(default(byte), pixelFormat.ALoss);
            Assert.Equal(default(byte), pixelFormat.RShift);
            Assert.Equal(default(byte), pixelFormat.GShift);
            Assert.Equal(default(byte), pixelFormat.BShift);
            Assert.Equal(default(byte), pixelFormat.AShift);
            Assert.Equal(default(int), pixelFormat.refCount);
            Assert.Equal(IntPtr.Zero, pixelFormat.Next);
        }

        /// <summary>
        ///     Tests that pixel format set palette updates value correctly
        /// </summary>
        [Fact]
        public void PixelFormat_SetPalette_UpdatesValueCorrectly()
        {
            IntPtr palettePtr = new IntPtr(123);
            PixelFormat pixelFormat = new PixelFormat
            {
                Palette = palettePtr
            };

            Assert.Equal(palettePtr, pixelFormat.Palette);
        }

        /// <summary>
        ///     Tests that pixel format set next updates value correctly
        /// </summary>
        [Fact]
        public void PixelFormat_SetNext_UpdatesValueCorrectly()
        {
            IntPtr nextPtr = new IntPtr(456);
            PixelFormat pixelFormat = new PixelFormat
            {
                Next = nextPtr
            };

            Assert.Equal(nextPtr, pixelFormat.Next);
        }
    }
}