// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JoystickConnectEventArgsCoverageTests.cs
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
    ///     The joystick connect event args coverage tests class
    /// </summary>
    public class JoystickConnectEventArgsCoverageTests
    {
        /// <summary>
        ///     Tests that the constructor with an event sets the joystick id
        /// </summary>
        [Fact]
        public void JoystickConnectEventArgs_ConstructorWithEvent_SetsJoystickId()
        {
            JoystickConnectEventArgs args = new JoystickConnectEventArgs(new JoystickConnectEvent { JoystickId = 7u });

            Assert.Equal(7u, args.JoystickId);
        }

        /// <summary>
        ///     Tests that the set property stores values correctly
        /// </summary>
        [Fact]
        public void JoystickConnectEventArgs_SetProperty_StoresValueCorrectly()
        {
            JoystickConnectEventArgs args = new JoystickConnectEventArgs(new JoystickConnectEvent());

            args.JoystickId = 42u;

            Assert.Equal(42u, args.JoystickId);
        }

        /// <summary>
        ///     Tests that the to string returns the expected description
        /// </summary>
        [Fact]
        public void JoystickConnectEventArgs_ToString_ReturnsExpectedDescription()
        {
            JoystickConnectEventArgs args = new JoystickConnectEventArgs(new JoystickConnectEvent { JoystickId = 3u });

            Assert.Equal("[JoystickConnectEventArgs] JoystickId(3)", args.ToString());
        }

        /// <summary>
        ///     Tests that the type derives from event args
        /// </summary>
        [Fact]
        public void JoystickConnectEventArgs_DerivesFromEventArgs_IsEventArgs()
        {
            JoystickConnectEventArgs args = new JoystickConnectEventArgs(new JoystickConnectEvent());

            Assert.IsAssignableFrom<EventArgs>(args);
        }
    }
}