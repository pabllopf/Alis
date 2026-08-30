// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PixelFormatCoverageTests.cs
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
    ///     The pixel format coverage tests class
    /// </summary>
    public class PixelFormatCoverageTests
    {
        /// <summary>
        ///     Tests that default initialization has zeroed readonly fields and null pointers
        /// </summary>
        [Fact]
        public void PixelFormat_DefaultInitialization_FieldsHaveDefaultValues()
        {
            PixelFormat pixelFormat = default(PixelFormat);

            Assert.Equal(0u, pixelFormat.format);
            Assert.Equal(IntPtr.Zero, pixelFormat.Palette);
            Assert.Equal((byte)0, pixelFormat.BitsPerPixel);
            Assert.Equal((byte)0, pixelFormat.BytesPerPixel);
            Assert.Equal(0u, pixelFormat.RMask);
            Assert.Equal(0u, pixelFormat.GMask);
            Assert.Equal(0u, pixelFormat.BMask);
            Assert.Equal(0u, pixelFormat.AMask);
            Assert.Equal((byte)0, pixelFormat.RLoss);
            Assert.Equal((byte)0, pixelFormat.Gloss);
            Assert.Equal((byte)0, pixelFormat.BLoss);
            Assert.Equal((byte)0, pixelFormat.ALoss);
            Assert.Equal((byte)0, pixelFormat.RShift);
            Assert.Equal((byte)0, pixelFormat.GShift);
            Assert.Equal((byte)0, pixelFormat.BShift);
            Assert.Equal((byte)0, pixelFormat.AShift);
            Assert.Equal(0, pixelFormat.refCount);
            Assert.Equal(IntPtr.Zero, pixelFormat.Next);
        }

        /// <summary>
        ///     Tests that set properties stores values correctly
        /// </summary>
        [Fact]
        public void PixelFormat_SetProperties_StoresValuesCorrectly()
        {
            PixelFormat pixelFormat = new PixelFormat
            {
                Palette = new IntPtr(1),
                Next = new IntPtr(2)
            };

            Assert.Equal(new IntPtr(1), pixelFormat.Palette);
            Assert.Equal(new IntPtr(2), pixelFormat.Next);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void PixelFormat_IsValueType_CopyIsIndependent()
        {
            PixelFormat original = new PixelFormat { Palette = new IntPtr(10) };
            PixelFormat copy = original;

            copy.Palette = new IntPtr(20);

            Assert.Equal(new IntPtr(10), original.Palette);
            Assert.Equal(new IntPtr(20), copy.Palette);
        }
    }
}