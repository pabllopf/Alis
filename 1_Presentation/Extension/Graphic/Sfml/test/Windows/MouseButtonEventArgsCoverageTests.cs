// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MouseButtonEventArgsCoverageTests.cs
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
    ///     Tests for MouseButtonEventArgs.
    /// </summary>
    public class MouseButtonEventArgsCoverageTests
    {
        /// <summary>
        ///     Tests that constructor sets button from event
        /// </summary>
        [Fact]
        public void Constructor_SetsButtonFromEvent()
        {
            MouseButtonEvent e = new MouseButtonEvent { Button = Mouse.Button.Left };

            MouseButtonEventArgs args = new MouseButtonEventArgs(e);

            Assert.Equal(Mouse.Button.Left, args.Button);
        }

        /// <summary>
        ///     Tests that constructor sets x from event
        /// </summary>
        [Fact]
        public void Constructor_SetsXFromEvent()
        {
            MouseButtonEvent e = new MouseButtonEvent { X = 42 };

            MouseButtonEventArgs args = new MouseButtonEventArgs(e);

            Assert.Equal(42, args.X);
        }

        /// <summary>
        ///     Tests that constructor sets y from event
        /// </summary>
        [Fact]
        public void Constructor_SetsYFromEvent()
        {
            MouseButtonEvent e = new MouseButtonEvent { Y = 84 };

            MouseButtonEventArgs args = new MouseButtonEventArgs(e);

            Assert.Equal(84, args.Y);
        }

        /// <summary>
        ///     Tests that default event produces default arguments
        /// </summary>
        [Fact]
        public void DefaultEvent_ProducesDefaultArgs()
        {
            MouseButtonEventArgs args = new MouseButtonEventArgs(new MouseButtonEvent());

            Assert.Equal(default, args.Button);
            Assert.Equal(0, args.X);
            Assert.Equal(0, args.Y);
        }

        /// <summary>
        ///     Tests that properties get and set values
        /// </summary>
        [Fact]
        public void Properties_GetAndSetValues()
        {
            MouseButtonEventArgs args = new MouseButtonEventArgs(new MouseButtonEvent());

            args.Button = Mouse.Button.Right;
            args.X = 300;
            args.Y = 400;

            Assert.Equal(Mouse.Button.Right, args.Button);
            Assert.Equal(300, args.X);
            Assert.Equal(400, args.Y);
        }

        /// <summary>
        ///     Tests that mouse button event args inherits from event args
        /// </summary>
        [Fact]
        public void MouseButtonEventArgs_InheritsFromEventArgs()
        {
            MouseButtonEventArgs args = new MouseButtonEventArgs(new MouseButtonEvent());

            Assert.IsAssignableFrom<EventArgs>(args);
        }

        /// <summary>
        ///     Tests that to string returns expected format
        /// </summary>
        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            MouseButtonEvent e = new MouseButtonEvent { Button = Mouse.Button.Left, X = 10, Y = 20 };
            MouseButtonEventArgs args = new MouseButtonEventArgs(e);

            string str = args.ToString();

            Assert.Contains("[MouseButtonEventArgs]", str);
            Assert.Contains("Button(Left)", str);
            Assert.Contains("X(10)", str);
            Assert.Contains("Y(20)", str);
        }
    }
}
