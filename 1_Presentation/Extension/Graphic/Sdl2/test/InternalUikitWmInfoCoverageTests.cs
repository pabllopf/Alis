// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InternalUikitWmInfoCoverageTests.cs
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
    ///     The internal uikit wm info coverage tests class
    /// </summary>
    public class InternalUikitWmInfoCoverageTests
    {
        /// <summary>
        ///     Tests that the window property round-trips an arbitrary pointer
        /// </summary>
        [Fact]
        public void InternalUikitWmInfo_WindowProperty_RoundTripsPointer()
        {
            InternalUikitWmInfo info = default;
            IntPtr expected = new IntPtr(12345);

            info.Window = expected;

            Assert.Equal(expected, info.Window);
        }

        /// <summary>
        ///     Tests that the window property can be overwritten
        /// </summary>
        [Fact]
        public void InternalUikitWmInfo_WindowProperty_OverwritesPreviousValue()
        {
            InternalUikitWmInfo info = new InternalUikitWmInfo { Window = new IntPtr(1) };

            info.Window = new IntPtr(2);

            Assert.Equal(new IntPtr(2), info.Window);
        }

        /// <summary>
        ///     Tests that the window property defaults to zero
        /// </summary>
        [Fact]
        public void InternalUikitWmInfo_Default_WindowIsZero()
        {
            InternalUikitWmInfo info = default;

            Assert.Equal(IntPtr.Zero, info.Window);
        }

        /// <summary>
        ///     Tests that the readonly framebuffer fields default to zero
        /// </summary>
        [Fact]
        public void InternalUikitWmInfo_Default_BufferFieldsAreZero()
        {
            InternalUikitWmInfo info = default;

            Assert.Equal(0u, info.framebuffer);
            Assert.Equal(0u, info.colorBuffer);
            Assert.Equal(0u, info.resolveFramebuffer);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void InternalUikitWmInfo_IsValueType_CopiesAreIndependent()
        {
            InternalUikitWmInfo original = new InternalUikitWmInfo { Window = new IntPtr(10) };
            InternalUikitWmInfo copy = original;

            copy.Window = new IntPtr(20);

            Assert.Equal(new IntPtr(10), original.Window);
            Assert.Equal(new IntPtr(20), copy.Window);
        }
    }
}
