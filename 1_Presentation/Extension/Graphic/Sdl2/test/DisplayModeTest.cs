// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DisplayModeTest.cs
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
    /// The display mode test class
    /// </summary>
    public class DisplayModeTest
    {
        /// <summary>
        /// Tests that should default to zero
        /// </summary>
        [Fact]
        public void ShouldDefaultToZero()
        {
            DisplayMode mode = new DisplayMode();
            Assert.Equal(0u, mode.format);
            Assert.Equal(0, mode.w);
            Assert.Equal(0, mode.h);
            Assert.Equal(0, mode.refresh_rate);
            Assert.Equal(IntPtr.Zero, mode.DriverData);
        }

        /// <summary>
        /// Tests that should assign and retrieve fields
        /// </summary>
        [Fact]
        public void ShouldAssignAndRetrieveFields()
        {
            DisplayMode mode = new DisplayMode
            {
                format = 123u,
                w = 1920,
                h = 1080,
                refresh_rate = 60,
                DriverData = new IntPtr(0xDEAD)
            };
            Assert.Equal(123u, mode.format);
            Assert.Equal(1920, mode.w);
            Assert.Equal(1080, mode.h);
            Assert.Equal(60, mode.refresh_rate);
            Assert.Equal(new IntPtr(0xDEAD), mode.DriverData);
        }
    }
}
