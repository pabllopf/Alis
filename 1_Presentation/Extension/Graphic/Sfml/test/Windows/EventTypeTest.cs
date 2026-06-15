// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EventTypeTest.cs
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

using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    /// The event type test class
    /// </summary>
    public class EventTypeTest
    {
        /// <summary>
        /// Tests that event type has expected values
        /// </summary>
        [Fact]
        public void EventType_HasExpectedValues()
        {
            Assert.Equal(0, (int)EventType.Closed);
            Assert.Equal(1, (int)EventType.Resized);
            Assert.Equal(2, (int)EventType.LostFocus);
            Assert.Equal(3, (int)EventType.GainedFocus);
            Assert.Equal(4, (int)EventType.TextEntered);
            Assert.Equal(5, (int)EventType.KeyPressed);
            Assert.Equal(6, (int)EventType.KeyReleased);
            Assert.Equal(7, (int)EventType.MouseWheelMoved);
            Assert.Equal(8, (int)EventType.MouseWheelScrolled);
            Assert.Equal(9, (int)EventType.MouseButtonPressed);
            Assert.Equal(10, (int)EventType.MouseButtonReleased);
            Assert.Equal(11, (int)EventType.MouseMoved);
            Assert.Equal(12, (int)EventType.MouseEntered);
            Assert.Equal(13, (int)EventType.MouseLeft);
            Assert.Equal(14, (int)EventType.JoystickButtonPressed);
            Assert.Equal(15, (int)EventType.JoystickButtonReleased);
            Assert.Equal(16, (int)EventType.JoystickMoved);
            Assert.Equal(17, (int)EventType.JoystickConnected);
            Assert.Equal(18, (int)EventType.JoystickDisconnected);
            Assert.Equal(19, (int)EventType.TouchBegan);
            Assert.Equal(20, (int)EventType.TouchMoved);
            Assert.Equal(21, (int)EventType.TouchEnded);
            Assert.Equal(22, (int)EventType.SensorChanged);
        }
    }
}
