// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TouchFingerEventTest.cs
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

using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Unit tests for the TouchFingerEvent struct.
    /// </summary>
    public class TouchFingerEventTest
    {
        /// <summary>
        /// Tests that should default to zero
        /// </summary>
        [Fact]
        public void ShouldDefaultToZero()
        {
            // Arrange
            TouchFingerEvent evt = new TouchFingerEvent();
            // Assert
            Assert.Equal(0u, evt.type);
            Assert.Equal(0u, evt.timestamp);
            Assert.Equal(0L, evt.touchId);
            Assert.Equal(0L, evt.fingerId);
            Assert.Equal(0f, evt.x);
            Assert.Equal(0f, evt.y);
            Assert.Equal(0f, evt.dx);
            Assert.Equal(0f, evt.dy);
            Assert.Equal(0f, evt.pressure);
            Assert.Equal(0u, evt.windowID);
        }

        /// <summary>
        /// Tests that should assign and retrieve all fields
        /// </summary>
        [Fact]
        public void ShouldAssignAndRetrieveAllFields()
        {
            // Arrange
            TouchFingerEvent evt = new TouchFingerEvent
            {
                type = 1u,
                timestamp = 100u,
                touchId = 42L,
                fingerId = 99L,
                x = 0.5f,
                y = 0.25f,
                dx = -0.1f,
                dy = 0.3f,
                pressure = 1.0f,
                windowID = 7u
            };
            // Assert
            Assert.Equal(1u, evt.type);
            Assert.Equal(100u, evt.timestamp);
            Assert.Equal(42L, evt.touchId);
            Assert.Equal(99L, evt.fingerId);
            Assert.Equal(0.5f, evt.x);
            Assert.Equal(0.25f, evt.y);
            Assert.Equal(-0.1f, evt.dx);
            Assert.Equal(0.3f, evt.dy);
            Assert.Equal(1.0f, evt.pressure);
            Assert.Equal(7u, evt.windowID);
        }
    }
}
