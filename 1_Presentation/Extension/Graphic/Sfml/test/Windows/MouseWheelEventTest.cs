// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MouseWheelEventTest.cs
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
    /// The mouse wheel event test class
    /// </summary>
    public class MouseWheelEventTest
    {
        /// <summary>
        /// Tests that mouse wheel event default has zero values
        /// </summary>
        [Fact]
        public void MouseWheelEvent_Default_HasZeroValues()
        {
            MouseWheelEvent e = new MouseWheelEvent();
            Assert.Equal(0, e.Delta);
            Assert.Equal(0, e.X);
            Assert.Equal(0, e.Y);
        }

        /// <summary>
        /// Tests that mouse wheel event args constructor sets properties
        /// </summary>
        [Fact]
        public void MouseWheelEventArgs_Constructor_SetsProperties()
        {
            MouseWheelEvent e = new MouseWheelEvent { Delta = 120, X = 100, Y = 200 };
            MouseWheelEventArgs args = new MouseWheelEventArgs(e);
            Assert.Equal(120, args.Delta);
            Assert.Equal(100, args.X);
            Assert.Equal(200, args.Y);
        }

        /// <summary>
        /// Tests that mouse wheel event args to string includes property names
        /// </summary>
        [Fact]
        public void MouseWheelEventArgs_ToString_IncludesPropertyNames()
        {
            MouseWheelEvent e = new MouseWheelEvent { Delta = 1, X = 2, Y = 3 };
            MouseWheelEventArgs args = new MouseWheelEventArgs(e);
            Assert.Contains("Delta", args.ToString());
            Assert.Contains("X", args.ToString());
            Assert.Contains("Y", args.ToString());
        }
    }
}
