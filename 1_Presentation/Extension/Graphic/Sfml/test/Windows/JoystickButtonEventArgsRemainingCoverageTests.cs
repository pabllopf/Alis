// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JoystickButtonEventArgsRemainingCoverageTests.cs
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

using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    ///     The joystick button event args remaining coverage tests class
    /// </summary>
    public class JoystickButtonEventArgsRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that constructor assigns values from event
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_AssignsValuesFromEvent()
        {
            JoystickButtonEvent buttonEvent = new JoystickButtonEvent
            {
                JoystickId = 1,
                Button = 5
            };

            JoystickButtonEventArgs args = new JoystickButtonEventArgs(buttonEvent);

            Assert.Equal(1u, args.JoystickId);
            Assert.Equal(5u, args.Button);
        }

        /// <summary>
        ///     Tests that properties get and set values
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Properties_GetAndSetValues()
        {
            JoystickButtonEventArgs args = new JoystickButtonEventArgs(new JoystickButtonEvent());

            args.JoystickId = 2;
            args.Button = 7;

            Assert.Equal(2u, args.JoystickId);
            Assert.Equal(7u, args.Button);
        }

        /// <summary>
        ///     Tests that to string returns expected format
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void ToString_ReturnsExpectedFormat()
        {
            JoystickButtonEvent buttonEvent = new JoystickButtonEvent
            {
                JoystickId = 3,
                Button = 9
            };
            JoystickButtonEventArgs args = new JoystickButtonEventArgs(buttonEvent);

            string str = args.ToString();

            Assert.Contains("[JoystickButtonEventArgs]", str);
            Assert.Contains("JoystickId(3)", str);
            Assert.Contains("Button(9)", str);
        }
    }
}
