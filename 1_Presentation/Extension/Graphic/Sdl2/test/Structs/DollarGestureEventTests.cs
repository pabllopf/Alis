// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DollarGestureEventTests.cs
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

using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test.Structs
{
    /// <summary>
    ///     The dollar gesture event tests class
    /// </summary>
    public class DollarGestureEventTests
    {
        /// <summary>
        ///     Tests that dollar gesture event initializes properties correctly
        /// </summary>
        [Fact]
        public void DollarGestureEvent_InitializesPropertiesCorrectly()
        {
            uint expectedType = 123;
            uint expectedTimestamp = 456789;
            long expectedTouchId = 1234567890123456789;
            long expectedGestureId = 6543210987654321;
            uint expectedNumFingers = 3;
            float expectedError = 0.1f;
            float expectedX = 0.5f;
            float expectedY = 0.75f;

            DollarGestureEvent eventStruct = new DollarGestureEvent
            {
                type = expectedType,
                timestamp = expectedTimestamp,
                touchId = expectedTouchId,
                gestureId = expectedGestureId,
                numFingers = expectedNumFingers,
                error = expectedError,
                x = expectedX,
                y = expectedY
            };

            Assert.Equal(expectedType, eventStruct.type);
            Assert.Equal(expectedTimestamp, eventStruct.timestamp);
            Assert.Equal(expectedTouchId, eventStruct.touchId);
            Assert.Equal(expectedGestureId, eventStruct.gestureId);
            Assert.Equal(expectedNumFingers, eventStruct.numFingers);
            Assert.Equal(expectedError, eventStruct.error);
            Assert.Equal(expectedX, eventStruct.x);
            Assert.Equal(expectedY, eventStruct.y);
        }
    }
}