// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MouseMoveEventTests.cs
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
    ///     The mouse move event tests class
    /// </summary>
    public class MouseMoveEventTests
    {
        /// <summary>
        ///     Tests that can set fields
        /// </summary>
        [Fact]
        public void CanSetFields()
        {
            MouseMoveEvent evt = new MouseMoveEvent {X = 123, Y = 456};
            Assert.Equal(123, evt.X);
            Assert.Equal(456, evt.Y);
        }
    }

    /// <summary>
    ///     The mouse move event args tests class
    /// </summary>
    public class MouseMoveEventArgsTests
    {
        /// <summary>
        ///     Tests that constructor sets properties correctly
        /// </summary>
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            MouseMoveEvent evt = new MouseMoveEvent {X = 10, Y = 20};
            MouseMoveEventArgs args = new MouseMoveEventArgs(evt);
            Assert.Equal(10, args.X);
            Assert.Equal(20, args.Y);
        }

        /// <summary>
        ///     Tests that to string returns expected format
        /// </summary>
        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            MouseMoveEvent evt = new MouseMoveEvent {X = -5, Y = 99};
            MouseMoveEventArgs args = new MouseMoveEventArgs(evt);
            string str = args.ToString();
            Assert.Contains("X(-5)", str);
            Assert.Contains("Y(99)", str);
        }
    }
}