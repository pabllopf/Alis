// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JoystickConnectEventArgsRemainingCoverageTests.cs
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
    ///     The joystick connect event args remaining coverage tests class
    /// </summary>
    public class JoystickConnectEventArgsRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that constructor assigns value from event
        /// </summary>
        [Fact]
        public void Constructor_AssignsValueFromEvent()
        {
            JoystickConnectEvent connectEvent = new JoystickConnectEvent
            {
                JoystickId = 4
            };

            JoystickConnectEventArgs args = new JoystickConnectEventArgs(connectEvent);

            Assert.Equal(4u, args.JoystickId);
        }

        /// <summary>
        ///     Tests that property gets and sets value
        /// </summary>
        [Fact]
        public void Property_GetAndSetValue()
        {
            JoystickConnectEventArgs args = new JoystickConnectEventArgs(new JoystickConnectEvent());

            args.JoystickId = 8;

            Assert.Equal(8u, args.JoystickId);
        }

        /// <summary>
        ///     Tests that to string returns expected format
        /// </summary>
        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            JoystickConnectEvent connectEvent = new JoystickConnectEvent
            {
                JoystickId = 2
            };
            JoystickConnectEventArgs args = new JoystickConnectEventArgs(connectEvent);

            string str = args.ToString();

            Assert.Contains("[JoystickConnectEventArgs]", str);
            Assert.Contains("JoystickId(2)", str);
        }
    }
}
