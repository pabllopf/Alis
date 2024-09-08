// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ControllerButtonEventTests.cs
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

using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Core.Graphic.Test.Sdl2.Structs
{
    /// <summary>
    ///     The controller button event tests class
    /// </summary>
    public class ControllerButtonEventTests
    {
        /// <summary>
        ///     Tests that controller button event initializes properties correctly
        /// </summary>
        [Fact]
        public void ControllerButtonEvent_InitializesPropertiesCorrectly()
        {
            EventType eventType = EventType.ControllerButtonDown;
            uint timestamp = 123456;
            int which = 1;
            byte button = 2;
            byte state = 1;

            ControllerButtonEvent eventStruct = new ControllerButtonEvent
            {
                type = eventType,
                timestamp = timestamp,
                which = which,
                button = button,
                state = state
            };

            Assert.Equal(eventType, eventStruct.type);
            Assert.Equal(timestamp, eventStruct.timestamp);
            Assert.Equal(which, eventStruct.which);
            Assert.Equal(button, eventStruct.button);
            Assert.Equal(state, eventStruct.state);
        }
    }
}