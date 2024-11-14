// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ControllerAxisEventTests.cs
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
    ///     The controller axis event tests class
    /// </summary>
    public class ControllerAxisEventTests
    {
        /// <summary>
        ///     Tests that controller axis event initializes properties correctly
        /// </summary>
        [Fact]
        public void ControllerAxisEvent_InitializesPropertiesCorrectly()
        {
            EventType eventType = EventType.ControllerAxisMotion;
            uint timestamp = 1234567890;
            int which = 1;
            byte axis = 2;

            ControllerAxisEvent eventStruct = new ControllerAxisEvent
            {
                type = eventType,
                timestamp = timestamp,
                which = which,
                axis = axis
            };

            Assert.Equal(eventType, eventStruct.type);
            Assert.Equal(timestamp, eventStruct.timestamp);
            Assert.Equal(which, eventStruct.which);
            Assert.Equal(axis, eventStruct.axis);
        }
    }
}