// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MouseMoveEventTest.cs
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
    /// The mouse move event test class
    /// </summary>
    public class MouseMoveEventTest
    {
        /// <summary>
        /// Tests that mouse move event default has zero values
        /// </summary>
        [Fact]
        public void MouseMoveEvent_Default_HasZeroValues()
        {
            MouseMoveEvent e = new MouseMoveEvent();
            Assert.Equal(0, e.X);
            Assert.Equal(0, e.Y);
        }

        /// <summary>
        /// Tests that mouse move event args constructor sets properties
        /// </summary>
        [Fact]
        public void MouseMoveEventArgs_Constructor_SetsProperties()
        {
            MouseMoveEvent e = new MouseMoveEvent { X = 320, Y = 240 };
            MouseMoveEventArgs args = new MouseMoveEventArgs(e);
            Assert.Equal(320, args.X);
            Assert.Equal(240, args.Y);
        }

        /// <summary>
        /// Tests that mouse move event args to string includes property names
        /// </summary>
        [Fact]
        public void MouseMoveEventArgs_ToString_IncludesPropertyNames()
        {
            MouseMoveEvent e = new MouseMoveEvent { X = 1, Y = 2 };
            MouseMoveEventArgs args = new MouseMoveEventArgs(e);
            Assert.Contains("X", args.ToString());
            Assert.Contains("Y", args.ToString());
        }
    }
}
