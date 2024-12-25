// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ControllerTouchpadEventTests.cs
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

using System.Diagnostics.CodeAnalysis;
using Alis.Core.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Core.Graphic.Test.Sdl2.Structs
{
    /// <summary>
    ///     The controller touchpad event tests class
    /// </summary>
    	  
	 public class ControllerTouchpadEventTests 
    {
        /// <summary>
        ///     Tests that controller touchpad event initializes properties correctly
        /// </summary>
        [Fact]
        public void ControllerTouchpadEvent_InitializesPropertiesCorrectly()
        {
            uint expectedType = 123;
            uint expectedTimestamp = 456789;
            int expectedWhich = 1;
            int expectedTouchpad = 2;
            int expectedFinger = 3;
            float expectedX = 0.5f;
            float expectedY = 0.75f;
            float expectedPressure = 0.25f;

            ControllerTouchpadEvent eventStruct = new ControllerTouchpadEvent
            {
                type = expectedType,
                timestamp = expectedTimestamp,
                which = expectedWhich,
                touchpad = expectedTouchpad,
                finger = expectedFinger,
                x = expectedX,
                y = expectedY,
                pressure = expectedPressure
            };

            Assert.Equal(expectedType, eventStruct.type);
            Assert.Equal(expectedTimestamp, eventStruct.timestamp);
            Assert.Equal(expectedWhich, eventStruct.which);
            Assert.Equal(expectedTouchpad, eventStruct.touchpad);
            Assert.Equal(expectedFinger, eventStruct.finger);
            Assert.Equal(expectedX, eventStruct.x);
            Assert.Equal(expectedY, eventStruct.y);
            Assert.Equal(expectedPressure, eventStruct.pressure);
        }
    }
}