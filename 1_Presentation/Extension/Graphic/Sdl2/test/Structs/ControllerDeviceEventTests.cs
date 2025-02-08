// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ControllerDeviceEventTests.cs
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
    ///     The controller device event tests class
    /// </summary>
    public class ControllerDeviceEventTests
    {
        /// <summary>
        ///     Tests that controller device event initializes properties correctly
        /// </summary>
        [Fact]
        public void ControllerDeviceEvent_InitializesPropertiesCorrectly()
        {
            EventType eventType = EventType.ControllerButtonUp;
            uint timestamp = 123456789;
            int which = 1;

            ControllerDeviceEvent eventStruct = new ControllerDeviceEvent
            {
                type = eventType,
                timestamp = timestamp,
                which = which
            };

            Assert.Equal(eventType, eventStruct.type);
            Assert.Equal(timestamp, eventStruct.timestamp);
            Assert.Equal(which, eventStruct.which);
        }
    }
}