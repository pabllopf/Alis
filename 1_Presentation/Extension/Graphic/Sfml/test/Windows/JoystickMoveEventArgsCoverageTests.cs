// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JoystickMoveEventArgsCoverageTests.cs
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

using System;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    ///     Tests for JoystickMoveEventArgs.
    /// </summary>
    public class JoystickMoveEventArgsCoverageTests
    {
        /// <summary>
        ///     Tests that constructor sets joystick id from event
        /// </summary>
        [Fact]
        public void Constructor_SetsJoystickIdFromEvent()
        {
            JoystickMoveEvent e = new JoystickMoveEvent { JoystickId = 3u };

            JoystickMoveEventArgs args = new JoystickMoveEventArgs(e);

            Assert.Equal(3u, args.JoystickId);
        }

        /// <summary>
        ///     Tests that constructor sets axis from event
        /// </summary>
        [Fact]
        public void Constructor_SetsAxisFromEvent()
        {
            JoystickMoveEvent e = new JoystickMoveEvent { Axis = Joystick.Axis.X };

            JoystickMoveEventArgs args = new JoystickMoveEventArgs(e);

            Assert.Equal(Joystick.Axis.X, args.Axis);
        }

        /// <summary>
        ///     Tests that constructor sets position from event
        /// </summary>
        [Fact]
        public void Constructor_SetsPositionFromEvent()
        {
            JoystickMoveEvent e = new JoystickMoveEvent { Position = 25.5f };

            JoystickMoveEventArgs args = new JoystickMoveEventArgs(e);

            Assert.Equal(25.5f, args.Position, 5);
        }

        /// <summary>
        ///     Tests that default event produces default arguments
        /// </summary>
        [Fact]
        public void DefaultEvent_ProducesDefaultArgs()
        {
            JoystickMoveEventArgs args = new JoystickMoveEventArgs(new JoystickMoveEvent());

            Assert.Equal(0u, args.JoystickId);
            Assert.Equal(default, args.Axis);
            Assert.Equal(0.0f, args.Position);
        }

        /// <summary>
        ///     Tests that properties get and set values
        /// </summary>
        [Fact]
        public void Properties_GetAndSetValues()
        {
            JoystickMoveEventArgs args = new JoystickMoveEventArgs(new JoystickMoveEvent());

            args.JoystickId = 7u;
            args.Axis = Joystick.Axis.Y;
            args.Position = -2.0f;

            Assert.Equal(7u, args.JoystickId);
            Assert.Equal(Joystick.Axis.Y, args.Axis);
            Assert.Equal(-2.0f, args.Position, 5);
        }

        /// <summary>
        ///     Tests that joystick move event args inherits from event args
        /// </summary>
        [Fact]
        public void JoystickMoveEventArgs_InheritsFromEventArgs()
        {
            JoystickMoveEventArgs args = new JoystickMoveEventArgs(new JoystickMoveEvent());

            Assert.IsAssignableFrom<EventArgs>(args);
        }

        /// <summary>
        ///     Tests that to string returns expected format
        /// </summary>
        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            JoystickMoveEvent e = new JoystickMoveEvent { JoystickId = 3u, Axis = Joystick.Axis.X, Position = 1.0f };
            JoystickMoveEventArgs args = new JoystickMoveEventArgs(e);

            string str = args.ToString();

            Assert.Contains("[JoystickMoveEventArgs]", str);
            Assert.Contains("JoystickId(3)", str);
            Assert.Contains("Axis(X)", str);
            Assert.Contains("Position(1)", str);
        }
    }
}
