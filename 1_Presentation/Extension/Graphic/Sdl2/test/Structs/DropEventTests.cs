// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DropEventTests.cs
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
using Alis.Extension.Graphic.Sdl2.Enums;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test.Structs
{
    /// <summary>
    ///     The drop event tests class
    /// </summary>
    public class DropEventTests
    {
        /// <summary>
        ///     Tests that drop event initializes properties correctly
        /// </summary>
        [Fact]
        public void DropEvent_InitializesPropertiesCorrectly()
        {
            EventType expectedType = EventType.FirstEvent;
            uint expectedTimestamp = 0;
            uint expectedWindowId = 0;
            IntPtr expectedFile = new IntPtr(123456);

            DropEvent dropEvent = new DropEvent
            {
                File = expectedFile
            };

            Assert.Equal(expectedType, dropEvent.type);
            Assert.Equal(expectedTimestamp, dropEvent.timestamp);
            Assert.Equal(expectedWindowId, dropEvent.windowID);
            Assert.Equal(expectedFile, dropEvent.File);
        }
    }
}