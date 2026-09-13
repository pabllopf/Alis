// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:SurfaceStructCoverageTests.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Shapes.Rectangle;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Coverage tests for the blittable <see cref="Surface" /> struct that
    ///     execute without any native SDL2 dependency.
    /// </summary>
    public class SurfaceStructCoverageTests
    {
        /// <summary>
        ///     Tests that Format round trips through its accessor.
        /// </summary>
        [Fact]
        public void Format_Accessor_RoundTrips()
        {
            Surface surface = default;
            IntPtr expected = new IntPtr(12345);

            surface.Format = expected;

            Assert.Equal(expected, surface.Format);
        }

        /// <summary>
        ///     Tests that Pixels round trips through its accessor.
        /// </summary>
        [Fact]
        public void Pixels_Accessor_RoundTrips()
        {
            Surface surface = default;
            IntPtr expected = new IntPtr(67890);

            surface.Pixels = expected;

            Assert.Equal(expected, surface.Pixels);
        }

        /// <summary>
        ///     Tests that Userdata round trips through its accessor.
        /// </summary>
        [Fact]
        public void Userdata_Accessor_RoundTrips()
        {
            Surface surface = default;
            IntPtr expected = new IntPtr(11111);

            surface.Userdata = expected;

            Assert.Equal(expected, surface.Userdata);
        }

        /// <summary>
        ///     Tests that ListBlitMap round trips through its accessor.
        /// </summary>
        [Fact]
        public void ListBlitMap_Accessor_RoundTrips()
        {
            Surface surface = default;
            IntPtr expected = new IntPtr(22222);

            surface.ListBlitMap = expected;

            Assert.Equal(expected, surface.ListBlitMap);
        }

        /// <summary>
        ///     Tests that ClipRect round trips through its accessor.
        /// </summary>
        [Fact]
        public void ClipRect_Accessor_RoundTrips()
        {
            Surface surface = default;
            RectangleI expected = new RectangleI(10, 20, 30, 40);

            surface.ClipRect = expected;

            Assert.Equal(expected.X, surface.ClipRect.X);
            Assert.Equal(expected.Y, surface.ClipRect.Y);
            Assert.Equal(expected.W, surface.ClipRect.W);
            Assert.Equal(expected.H, surface.ClipRect.H);
        }

        /// <summary>
        ///     Tests that Map round trips through its accessor.
        /// </summary>
        [Fact]
        public void Map_Accessor_RoundTrips()
        {
            Surface surface = default;
            IntPtr expected = new IntPtr(33333);

            surface.Map = expected;

            Assert.Equal(expected, surface.Map);
        }

        /// <summary>
        ///     Tests that Surface remains blittable for native interop.
        /// </summary>
        [Fact]
        public void Struct_IsBlittable()
        {
            Assert.True(Marshal.SizeOf<Surface>() > 0);
            Assert.False(typeof(Surface).IsAutoLayout);
        }
    }
}
