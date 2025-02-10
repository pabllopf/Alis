// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SurfaceTests.cs
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
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test.Structs
{
    /// <summary>
    ///     The surface tests class
    /// </summary>
    public class SurfaceTests
    {
        /// <summary>
        ///     Tests that surface initializes with default values
        /// </summary>
        [Fact]
        public void Surface_InitializesWithDefaultValues()
        {
            Surface surface = new Surface();

            Assert.Equal(0u, surface.flags);
            Assert.Equal(IntPtr.Zero, surface.Format);
            Assert.Equal(0, surface.w);
            Assert.Equal(0, surface.h);
            Assert.Equal(0, surface.pitch);
            Assert.Equal(IntPtr.Zero, surface.Pixels);
            Assert.Equal(IntPtr.Zero, surface.Userdata);
            Assert.Equal(0, surface.locked);
            Assert.Equal(IntPtr.Zero, surface.ListBlitMap);
            Assert.Equal(new RectangleI(), surface.ClipRect);
            Assert.Equal(IntPtr.Zero, surface.Map);
            Assert.Equal(0, surface.refCount);
        }

        /// <summary>
        ///     Tests that surface set properties updates values correctly
        /// </summary>
        [Fact]
        public void Surface_SetProperties_UpdatesValuesCorrectly()
        {
            IntPtr formatPtr = new IntPtr(123);
            IntPtr pixelsPtr = new IntPtr(456);
            IntPtr userdataPtr = new IntPtr(789);
            IntPtr listBlitMapPtr = new IntPtr(101112);
            IntPtr mapPtr = new IntPtr(131415);
            RectangleI clipRect = new RectangleI {X = 1, Y = 2, W = 3, H = 4};

            Surface surface = new Surface
            {
                Format = formatPtr,
                Pixels = pixelsPtr,
                Userdata = userdataPtr,
                ListBlitMap = listBlitMapPtr,
                ClipRect = clipRect,
                Map = mapPtr
            };

            Assert.Equal(formatPtr, surface.Format);
            Assert.Equal(pixelsPtr, surface.Pixels);
            Assert.Equal(userdataPtr, surface.Userdata);
            Assert.Equal(listBlitMapPtr, surface.ListBlitMap);
            Assert.Equal(clipRect, surface.ClipRect);
            Assert.Equal(mapPtr, surface.Map);
        }
    }
}