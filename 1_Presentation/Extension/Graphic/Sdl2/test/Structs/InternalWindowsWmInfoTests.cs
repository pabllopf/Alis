// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InternalWindowsWmInfoTests.cs
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

namespace Alis.Extension.Graphic.Sdl2.Test.Structs
{
    /// <summary>
    ///     The internal windows wm info tests class
    /// </summary>
    public class InternalWindowsWmInfoTests
    {
        /// <summary>
        ///     Tests that internal windows wm info initializes properties correctly
        /// </summary>
        [Fact]
        public void InternalWindowsWmInfo_InitializesPropertiesCorrectly()
        {
            IntPtr expectedWindow = new IntPtr(123);
            IntPtr expectedHdc = new IntPtr(456);
            IntPtr expectedHInstance = new IntPtr(789);

            InternalWindowsWmInfo info = new InternalWindowsWmInfo
            {
                Window = expectedWindow,
                Hdc = expectedHdc,
                HInstance = expectedHInstance
            };

            Assert.Equal(expectedWindow, info.Window);
            Assert.Equal(expectedHdc, info.Hdc);
            Assert.Equal(expectedHInstance, info.HInstance);
        }
    }
}