// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JoystickButtonEventArgsTests.cs
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
    ///     Unit tests for the JoystickButtonEventArgs class.
    /// </summary>
    public class JoystickButtonEventArgsTests
    {
        /// <summary>
        ///     Tests that the constructor copies the event fields.
        /// </summary>
        [Fact]
        public void Constructor_WithEvent_AssignsFields()
        {
            JoystickButtonEvent e = new JoystickButtonEvent { JoystickId = 3u, Button = 7u };
            JoystickButtonEventArgs args = new JoystickButtonEventArgs(e);
            Assert.Equal(3u, args.JoystickId);
            Assert.Equal(7u, args.Button);
        }

        /// <summary>
        ///     Tests that the properties can be set after construction.
        /// </summary>
        [Fact]
        public void Properties_Setters_RoundTrip()
        {
            JoystickButtonEventArgs args = new JoystickButtonEventArgs(new JoystickButtonEvent());
            args.JoystickId = 11u;
            args.Button = 22u;
            Assert.Equal(11u, args.JoystickId);
            Assert.Equal(22u, args.Button);
        }

        /// <summary>
        ///     Tests the ToString output.
        /// </summary>
        [Fact]
        public void ToString_ReturnsDescriptiveString()
        {
            JoystickButtonEventArgs args = new JoystickButtonEventArgs(new JoystickButtonEvent { JoystickId = 1u, Button = 2u });
            Assert.Equal("[JoystickButtonEventArgs] JoystickId(1) Button(2)", args.ToString());
        }

        /// <summary>
        ///     Tests that instances are EventArgs.
        /// </summary>
        [Fact]
        public void Instance_IsEventArgs()
        {
            JoystickButtonEventArgs args = new JoystickButtonEventArgs(new JoystickButtonEvent());
            Assert.IsAssignableFrom<EventArgs>(args);
        }
    }
}
