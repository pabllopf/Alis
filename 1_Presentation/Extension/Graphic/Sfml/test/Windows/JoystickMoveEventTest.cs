// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JoystickMoveEventTest.cs
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
    public class JoystickMoveEventTest
    {
        [Fact]
        public void JoystickMoveEvent_Default_HasZeroValues()
        {
            JoystickMoveEvent e = new JoystickMoveEvent();
            Assert.Equal(0u, e.JoystickId);
            Assert.Equal(0.0f, e.Position);
        }

        [Fact]
        public void JoystickMoveEventArgs_Constructor_SetsProperties()
        {
            JoystickMoveEvent e = new JoystickMoveEvent { JoystickId = 1, Axis = Joystick.Axis.X, Position = 50.0f };
            JoystickMoveEventArgs args = new JoystickMoveEventArgs(e);
            Assert.Equal(1u, args.JoystickId);
            Assert.Equal(Joystick.Axis.X, args.Axis);
            Assert.Equal(50.0f, args.Position);
        }

        [Fact]
        public void JoystickMoveEventArgs_ToString_IncludesPropertyNames()
        {
            JoystickMoveEvent e = new JoystickMoveEvent { JoystickId = 1, Position = 0.5f };
            JoystickMoveEventArgs args = new JoystickMoveEventArgs(e);
            Assert.Contains("JoystickId", args.ToString());
            Assert.Contains("Position", args.ToString());
        }
    }
}
