// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DisplayModeCoverageTests.cs
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
    ///     The display mode coverage tests class
    /// </summary>
    public class DisplayModeCoverageTests
    {
        /// <summary>
        ///     Tests that default initialization properties have default values
        /// </summary>
        [Fact]
        public void DisplayMode_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            DisplayMode mode = default(DisplayMode);

            Assert.Equal(0U, mode.format);
            Assert.Equal(0, mode.w);
            Assert.Equal(0, mode.h);
            Assert.Equal(0, mode.refresh_rate);
            Assert.Equal(IntPtr.Zero, mode.DriverData);
        }

        /// <summary>
        ///     Tests that set properties stores values correctly
        /// </summary>
        [Fact]
        public void DisplayMode_SetProperties_StoresValuesCorrectly()
        {
            DisplayMode mode = new DisplayMode
            {
                format = 1U,
                w = 1920,
                h = 1080,
                refresh_rate = 60,
                DriverData = new IntPtr(999)
            };

            Assert.Equal(1U, mode.format);
            Assert.Equal(1920, mode.w);
            Assert.Equal(1080, mode.h);
            Assert.Equal(60, mode.refresh_rate);
            Assert.Equal(new IntPtr(999), mode.DriverData);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void DisplayMode_IsValueType_CopyIsIndependent()
        {
            DisplayMode original = new DisplayMode { w = 100, DriverData = new IntPtr(500) };
            DisplayMode copy = original;

            copy.w = 200;
            copy.DriverData = new IntPtr(600);

            Assert.Equal(100, original.w);
            Assert.Equal(new IntPtr(500), original.DriverData);
            Assert.Equal(200, copy.w);
            Assert.Equal(new IntPtr(600), copy.DriverData);
        }
    }
}