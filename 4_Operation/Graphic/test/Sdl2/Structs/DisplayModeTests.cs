// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DisplayModeTests.cs
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
    ///     The display mode tests class
    /// </summary>
    	  
	 public class DisplayModeTests 
    {
        /// <summary>
        ///     Tests that display mode initializes properties correctly
        /// </summary>
        [Fact]
        public void DisplayMode_InitializesPropertiesCorrectly()
        {
            uint expectedFormat = 123;
            int expectedWidth = 1920;
            int expectedHeight = 1080;
            int expectedRefreshRate = 60;
            IntPtr expectedDriverData = new IntPtr(123456);

            DisplayMode displayMode = new DisplayMode
            {
                format = expectedFormat,
                w = expectedWidth,
                h = expectedHeight,
                refresh_rate = expectedRefreshRate,
                DriverData = expectedDriverData
            };

            Assert.Equal(expectedFormat, displayMode.format);
            Assert.Equal(expectedWidth, displayMode.w);
            Assert.Equal(expectedHeight, displayMode.h);
            Assert.Equal(expectedRefreshRate, displayMode.refresh_rate);
            Assert.Equal(expectedDriverData, displayMode.DriverData);
        }
    }
}