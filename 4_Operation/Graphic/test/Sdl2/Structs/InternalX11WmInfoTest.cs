// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InternalX11WmInfoTest.cs
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
using Alis.Core.Graphic.Sdl2.Structs;
using Xunit;


namespace Alis.Core.Graphic.Sdl2.Structs
{


    /// <summary>
    /// The internal 11 wm info tests class
    /// </summary>
    public class InternalX11WmInfoTests
    {
        /// <summary>
        /// Tests that internal x 11 wm info initializes properties correctly
        /// </summary>
        [Fact]
        public void InternalX11WmInfo_InitializesPropertiesCorrectly()
        {
            IntPtr expectedDisplay = new IntPtr(123);
            IntPtr expectedWindow = new IntPtr(456);

            InternalX11WmInfo info = new InternalX11WmInfo
            {
                Display = expectedDisplay,
                Window = expectedWindow
            };

            Assert.Equal(expectedDisplay, info.Display);
            Assert.Equal(expectedWindow, info.Window);
        }
    }
}