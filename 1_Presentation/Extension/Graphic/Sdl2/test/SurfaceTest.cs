// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SurfaceTest.cs
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

using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Shapes.Rectangle;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Contract tests for the <see cref="Surface" /> blittable struct.
    /// </summary>
    public class SurfaceTest
    {
        /// <summary>
        ///     Verifies that Surface is a value type.
        /// </summary>
        [Fact]
        public void Surface_ShouldBeValueType()
        {
            Assert.True(typeof(Surface).IsValueType);
        }

        /// <summary>
        ///     Verifies that Surface has sequential layout.
        /// </summary>
        [Fact]
        public void Surface_ShouldHaveSequentialLayout()
        {
            StructLayoutAttribute attribute = typeof(Surface).StructLayoutAttribute;

            Assert.NotNull(attribute);
            Assert.Equal(LayoutKind.Sequential, attribute.Value);
        }

        /// <summary>
        ///     Verifies that default Surface has zero flags.
        /// </summary>
        [Fact]
        public void DefaultInstance_Flags_ShouldBeZero()
        {
            Surface surface = default;

            Assert.Equal(0u, surface.flags);
        }

        /// <summary>
        ///     Verifies that Format property can be set and read.
        /// </summary>
        [Fact]
        public void Format_ShouldBeSettable()
        {
            Surface surface = default;
            System.IntPtr expected = new System.IntPtr(12345);

            surface.Format = expected;

            Assert.Equal(expected, surface.Format);
        }

        /// <summary>
        ///     Verifies that default Surface has zero width.
        /// </summary>
        [Fact]
        public void DefaultInstance_W_ShouldBeZero()
        {
            Surface surface = default;

            Assert.Equal(0, surface.w);
        }

        /// <summary>
        ///     Verifies that default Surface has zero height.
        /// </summary>
        [Fact]
        public void DefaultInstance_H_ShouldBeZero()
        {
            Surface surface = default;

            Assert.Equal(0, surface.h);
        }

        /// <summary>
        ///     Verifies that default Surface has zero pitch.
        /// </summary>
        [Fact]
        public void DefaultInstance_Pitch_ShouldBeZero()
        {
            Surface surface = default;

            Assert.Equal(0, surface.pitch);
        }

        /// <summary>
        ///     Verifies that Pixels property can be set and read.
        /// </summary>
        [Fact]
        public void Pixels_ShouldBeSettable()
        {
            Surface surface = default;
            System.IntPtr expected = new System.IntPtr(67890);

            surface.Pixels = expected;

            Assert.Equal(expected, surface.Pixels);
        }

        /// <summary>
        ///     Verifies that Userdata property can be set and read.
        /// </summary>
        [Fact]
        public void Userdata_ShouldBeSettable()
        {
            Surface surface = default;
            System.IntPtr expected = new System.IntPtr(11111);

            surface.Userdata = expected;

            Assert.Equal(expected, surface.Userdata);
        }

        /// <summary>
        ///     Verifies that default Surface has zero locked.
        /// </summary>
        [Fact]
        public void DefaultInstance_Locked_ShouldBeZero()
        {
            Surface surface = default;

            Assert.Equal(0, surface.locked);
        }

        /// <summary>
        ///     Verifies that ListBlitMap property can be set and read.
        /// </summary>
        [Fact]
        public void ListBlitMap_ShouldBeSettable()
        {
            Surface surface = default;
            System.IntPtr expected = new System.IntPtr(22222);

            surface.ListBlitMap = expected;

            Assert.Equal(expected, surface.ListBlitMap);
        }

        /// <summary>
        ///     Verifies that Map property can be set and read.
        /// </summary>
        [Fact]
        public void Map_ShouldBeSettable()
        {
            Surface surface = default;
            System.IntPtr expected = new System.IntPtr(33333);

            surface.Map = expected;

            Assert.Equal(expected, surface.Map);
        }

        /// <summary>
        ///     Verifies that default Surface has zero refCount.
        /// </summary>
        [Fact]
        public void DefaultInstance_RefCount_ShouldBeZero()
        {
            Surface surface = default;

            Assert.Equal(0, surface.refCount);
        }

        /// <summary>
        ///     Verifies that ClipRect property can be set and read.
        /// </summary>
        [Fact]
        public void ClipRect_ShouldBeSettable()
        {
            Surface surface = default;
            RectangleI expected = new RectangleI(10, 20, 30, 40);

            surface.ClipRect = expected;

            Assert.Equal(expected.X, surface.ClipRect.X);
            Assert.Equal(expected.Y, surface.ClipRect.Y);
            Assert.Equal(expected.W, surface.ClipRect.W);
            Assert.Equal(expected.H, surface.ClipRect.H);
        }
    }
}
