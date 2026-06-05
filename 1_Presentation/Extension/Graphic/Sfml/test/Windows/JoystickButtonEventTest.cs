// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JoystickButtonEventTest.cs
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
    public class JoystickButtonEventTest
    {
        [Fact]
        public void JoystickButtonEvent_Default_HasZeroValues()
        {
            JoystickButtonEvent e = new JoystickButtonEvent();
            Assert.Equal(0u, e.JoystickId);
            Assert.Equal(0u, e.Button);
        }

        [Fact]
        public void JoystickButtonEventArgs_Constructor_SetsProperties()
        {
            JoystickButtonEvent e = new JoystickButtonEvent { JoystickId = 2, Button = 5 };
            JoystickButtonEventArgs args = new JoystickButtonEventArgs(e);
            Assert.Equal(2u, args.JoystickId);
            Assert.Equal(5u, args.Button);
        }

        [Fact]
        public void JoystickButtonEventArgs_ToString_IncludesPropertyNames()
        {
            JoystickButtonEvent e = new JoystickButtonEvent { JoystickId = 1, Button = 3 };
            JoystickButtonEventArgs args = new JoystickButtonEventArgs(e);
            Assert.Contains("JoystickId", args.ToString());
            Assert.Contains("Button", args.ToString());
        }
    }
}
