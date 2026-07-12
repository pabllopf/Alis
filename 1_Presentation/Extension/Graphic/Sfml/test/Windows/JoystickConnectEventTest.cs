// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JoystickConnectEventTest.cs
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
    /// The joystick connect event test class
    /// </summary>
    public class JoystickConnectEventTest
    {
        /// <summary>
        /// Tests that joystick connect event default has zero value
        /// </summary>
        [Fact]
        public void JoystickConnectEvent_Default_HasZeroValue()
        {
            JoystickConnectEvent e = new JoystickConnectEvent();
            Assert.Equal(0u, e.JoystickId);
        }

        /// <summary>
        /// Tests that joystick connect event args constructor sets joystick id
        /// </summary>
        [Fact]
        public void JoystickConnectEventArgs_Constructor_SetsJoystickId()
        {
            JoystickConnectEvent e = new JoystickConnectEvent { JoystickId = 3 };
            JoystickConnectEventArgs args = new JoystickConnectEventArgs(e);
            Assert.Equal(3u, args.JoystickId);
        }

        /// <summary>
        /// Tests that joystick connect event args to string includes joystick id
        /// </summary>
        [Fact]
        public void JoystickConnectEventArgs_ToString_IncludesJoystickId()
        {
            JoystickConnectEvent e = new JoystickConnectEvent { JoystickId = 1 };
            JoystickConnectEventArgs args = new JoystickConnectEventArgs(e);
            Assert.Contains("JoystickId", args.ToString());
        }
    }
}
