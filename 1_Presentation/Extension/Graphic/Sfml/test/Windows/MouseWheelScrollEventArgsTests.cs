// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MouseWheelScrollEventArgsTests.cs
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
    ///     The mouse wheel scroll event args tests class
    /// </summary>
    public class MouseWheelScrollEventArgsTests
    {
        /// <summary>
        ///     Tests that constructor sets properties correctly
        /// </summary>
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            MouseWheelScrollEvent evt = new MouseWheelScrollEvent {Wheel = Mouse.Wheel.HorizontalWheel, Delta = -2.0f, X = 5, Y = 15};
            MouseWheelScrollEventArgs args = new MouseWheelScrollEventArgs(evt);
            Assert.Equal(Mouse.Wheel.HorizontalWheel, args.Wheel);
            Assert.Equal(-2.0f, args.Delta);
            Assert.Equal(5, args.X);
            Assert.Equal(15, args.Y);
        }

        /// <summary>
        ///     Tests that to string returns expected format
        /// </summary>
        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            MouseWheelScrollEvent evt = new MouseWheelScrollEvent {Wheel = Mouse.Wheel.VerticalWheel, Delta = 3.3f, X = -5, Y = 99};
            MouseWheelScrollEventArgs args = new MouseWheelScrollEventArgs(evt);
            string str = args.ToString();
            Assert.Contains("Wheel(VerticalWheel)", str);
            Assert.Contains("[MouseWheelScrollEventArgs]", str);
            Assert.Contains("X(-5)", str);
            Assert.Contains("Y(99)", str);
        }
    }
}