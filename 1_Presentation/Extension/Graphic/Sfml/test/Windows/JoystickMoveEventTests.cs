// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JoystickMoveEventTests.cs
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
    ///     The joystick move event tests class
    /// </summary>
    public class JoystickMoveEventTests
    {
        /// <summary>
        ///     Tests that can set fields
        /// </summary>
        [Fact]
        public void CanSetFields()
        {
            JoystickMoveEvent evt = new JoystickMoveEvent {JoystickId = 2, Axis = Joystick.Axis.X, Position = 42.5f};
            Assert.Equal((uint) 2, evt.JoystickId);
            Assert.Equal(Joystick.Axis.X, evt.Axis);
            Assert.Equal(42.5f, evt.Position);
        }
    }

    /// <summary>
    ///     The joystick move event args tests class
    /// </summary>
    public class JoystickMoveEventArgsTests
    {
        /// <summary>
        ///     Tests that constructor sets properties correctly
        /// </summary>
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            JoystickMoveEvent evt = new JoystickMoveEvent {JoystickId = 3, Axis = Joystick.Axis.Y, Position = 99.9f};
            JoystickMoveEventArgs args = new JoystickMoveEventArgs(evt);
            Assert.Equal((uint) 3, args.JoystickId);
            Assert.Equal(Joystick.Axis.Y, args.Axis);
            Assert.Equal(99.9f, args.Position);
        }

        /// <summary>
        ///     Tests that to string returns expected format
        /// </summary>
        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            JoystickMoveEvent evt = new JoystickMoveEvent {JoystickId = 1, Axis = Joystick.Axis.Z, Position = -12.3f};
            JoystickMoveEventArgs args = new JoystickMoveEventArgs(evt);
            string str = args.ToString();
            Assert.Contains("JoystickId(1)", str);
            Assert.Contains("Axis(Z)", str);
        }
    }
}