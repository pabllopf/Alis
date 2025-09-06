// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MouseButtonEventArgsTests.cs
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
    ///     The mouse button event args tests class
    /// </summary>
    public class MouseButtonEventArgsTests
    {
        /// <summary>
        ///     Tests that constructor sets properties correctly
        /// </summary>
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            MouseButtonEvent evt = new MouseButtonEvent
            {
                Button = Mouse.Button.Right,
                X = 10,
                Y = 20
            };
            MouseButtonEventArgs args = new MouseButtonEventArgs(evt);
            Assert.Equal(Mouse.Button.Right, args.Button);
            Assert.Equal(10, args.X);
            Assert.Equal(20, args.Y);
        }


        /// <summary>
        ///     Tests that to string returns expected format
        /// </summary>
        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            MouseButtonEvent evt = new MouseButtonEvent
            {
                Button = Mouse.Button.Middle,
                X = -5,
                Y = 99
            };
            MouseButtonEventArgs args = new MouseButtonEventArgs(evt);
            string str = args.ToString();
            Assert.Contains("Button(Middle)", str);
            Assert.Contains("X(-5)", str);
            Assert.Contains("Y(99)", str);
        }
    }
}