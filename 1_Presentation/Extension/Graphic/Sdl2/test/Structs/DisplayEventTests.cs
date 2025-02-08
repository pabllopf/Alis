// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DisplayEventTests.cs
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

using Alis.Extension.Graphic.Sdl2.Enums;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test.Structs
{
    /// <summary>
    ///     The display event tests class
    /// </summary>
    public class DisplayEventTests
    {
        /// <summary>
        ///     Tests that display event initializes properties correctly
        /// </summary>
        [Fact]
        public void DisplayEvent_InitializesPropertiesCorrectly()
        {
            EventType expectedType = EventType.DisplayEvent;
            uint expectedTimestamp = 123456;
            uint expectedDisplay = 1;
            DisplayEventId expectedDisplayEvent = DisplayEventId.SdlDisplayEventNone;

            DisplayEvent eventStruct = new DisplayEvent
            {
                type = expectedType,
                timestamp = expectedTimestamp,
                display = expectedDisplay,
                displayEvent = expectedDisplayEvent
            };

            Assert.Equal(expectedType, eventStruct.type);
            Assert.Equal(expectedTimestamp, eventStruct.timestamp);
            Assert.Equal(expectedDisplay, eventStruct.display);
            Assert.Equal(expectedDisplayEvent, eventStruct.displayEvent);
        }
    }
}