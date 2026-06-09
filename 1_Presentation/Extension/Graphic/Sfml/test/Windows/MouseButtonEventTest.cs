// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MouseButtonEventTest.cs
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
    /// The mouse button event test class
    /// </summary>
    public class MouseButtonEventTest
    {
        /// <summary>
        /// Tests that mouse button event default has zero values
        /// </summary>
        [Fact]
        public void MouseButtonEvent_Default_HasZeroValues()
        {
            MouseButtonEvent e = new MouseButtonEvent();
            Assert.Equal(0, e.X);
            Assert.Equal(0, e.Y);
        }

        /// <summary>
        /// Tests that mouse button event args constructor sets properties
        /// </summary>
        [Fact]
        public void MouseButtonEventArgs_Constructor_SetsProperties()
        {
            MouseButtonEvent e = new MouseButtonEvent { Button = Mouse.Button.Left, X = 100, Y = 200 };
            MouseButtonEventArgs args = new MouseButtonEventArgs(e);
            Assert.Equal(Mouse.Button.Left, args.Button);
            Assert.Equal(100, args.X);
            Assert.Equal(200, args.Y);
        }

        /// <summary>
        /// Tests that mouse button event args to string includes property names
        /// </summary>
        [Fact]
        public void MouseButtonEventArgs_ToString_IncludesPropertyNames()
        {
            MouseButtonEvent e = new MouseButtonEvent { Button = Mouse.Button.Right, X = 1, Y = 2 };
            MouseButtonEventArgs args = new MouseButtonEventArgs(e);
            string str = args.ToString();
            Assert.Contains("Button", str);
            Assert.Contains("X", str);
            Assert.Contains("Y", str);
        }
    }
}
