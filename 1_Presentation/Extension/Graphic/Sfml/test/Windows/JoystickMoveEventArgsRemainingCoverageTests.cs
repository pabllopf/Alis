// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JoystickMoveEventArgsRemainingCoverageTests.cs
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
    ///     The joystick move event args remaining coverage tests class
    /// </summary>
    public class JoystickMoveEventArgsRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that constructor assigns values from event
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_AssignsValuesFromEvent()
        {
            JoystickMoveEvent moveEvent = new JoystickMoveEvent
            {
                JoystickId = 1u,
                Axis = Joystick.Axis.X,
                Position = 0.5f
            };

            JoystickMoveEventArgs args = new JoystickMoveEventArgs(moveEvent);

            Assert.Equal(1u, args.JoystickId);
            Assert.Equal(Joystick.Axis.X, args.Axis);
            Assert.Equal(0.5f, args.Position);
        }

        /// <summary>
        ///     Tests that properties get and set values
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Properties_GetAndSetValues()
        {
            JoystickMoveEventArgs args = new JoystickMoveEventArgs(new JoystickMoveEvent());

            args.JoystickId = 2u;
            args.Axis = Joystick.Axis.Y;
            args.Position = -0.25f;

            Assert.Equal(2u, args.JoystickId);
            Assert.Equal(Joystick.Axis.Y, args.Axis);
            Assert.Equal(-0.25f, args.Position);
        }

        /// <summary>
        ///     Tests that to string returns expected format
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void ToString_ReturnsExpectedFormat()
        {
            JoystickMoveEvent moveEvent = new JoystickMoveEvent
            {
                JoystickId = 3u,
                Axis = Joystick.Axis.X,
                Position = 1
            };
            JoystickMoveEventArgs args = new JoystickMoveEventArgs(moveEvent);

            string str = args.ToString();

            Assert.Contains("[JoystickMoveEventArgs]", str);
            Assert.Contains("JoystickId(3)", str);
            Assert.Contains("Axis(X)", str);
            Assert.Contains("Position(1)", str);
        }
    }
}
