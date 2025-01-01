// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TouchFingerEventTests.cs
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

using Alis.Core.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Core.Graphic.Test.Sdl2.Structs
{
    /// <summary>
    ///     The touch finger event tests class
    /// </summary>
    public class TouchFingerEventTests
    {
        /// <summary>
        ///     Tests that touch finger event initializes properties correctly
        /// </summary>
        [Fact]
        public void TouchFingerEvent_InitializesPropertiesCorrectly()
        {
            uint expectedType = 1;
            uint expectedTimestamp = 123456789;
            long expectedTouchId = 123456789012345678;
            long expectedFingerId = 987654321098765432;
            float expectedX = 0.5f;
            float expectedY = 0.75f;
            float expectedDx = 0.1f;
            float expectedDy = 0.2f;
            float expectedPressure = 0.8f;
            uint expectedWindowID = 2;

            TouchFingerEvent touchFingerEvent = new TouchFingerEvent
            {
                type = expectedType,
                timestamp = expectedTimestamp,
                touchId = expectedTouchId,
                fingerId = expectedFingerId,
                x = expectedX,
                y = expectedY,
                dx = expectedDx,
                dy = expectedDy,
                pressure = expectedPressure,
                windowID = expectedWindowID
            };

            Assert.Equal(expectedType, touchFingerEvent.type);
            Assert.Equal(expectedTimestamp, touchFingerEvent.timestamp);
            Assert.Equal(expectedTouchId, touchFingerEvent.touchId);
            Assert.Equal(expectedFingerId, touchFingerEvent.fingerId);
            Assert.Equal(expectedX, touchFingerEvent.x);
            Assert.Equal(expectedY, touchFingerEvent.y);
            Assert.Equal(expectedDx, touchFingerEvent.dx);
            Assert.Equal(expectedDy, touchFingerEvent.dy);
            Assert.Equal(expectedPressure, touchFingerEvent.pressure);
            Assert.Equal(expectedWindowID, touchFingerEvent.windowID);
        }
    }
}