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

using System;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    ///     Tests for MouseWheelScrollEventArgs.
    /// </summary>
    public class MouseWheelScrollEventArgsTests
    {
        /// <summary>
        ///     Tests that constructor sets delta from mouse wheel scroll event
        /// </summary>
        [Fact]
        public void Constructor_SetsDeltaFromEvent()
        {
            MouseWheelScrollEvent e = new MouseWheelScrollEvent { Delta = 1.5f };

            MouseWheelScrollEventArgs args = new MouseWheelScrollEventArgs(e);

            Assert.Equal(1.5f, args.Delta);
        }

        /// <summary>
        ///     Tests that constructor sets wheel from mouse wheel scroll event
        /// </summary>
        [Fact]
        public void Constructor_SetsWheelFromEvent()
        {
            MouseWheelScrollEvent e = new MouseWheelScrollEvent { Wheel = Mouse.Wheel.HorizontalWheel };

            MouseWheelScrollEventArgs args = new MouseWheelScrollEventArgs(e);

            Assert.Equal(Mouse.Wheel.HorizontalWheel, args.Wheel);
        }

        /// <summary>
        ///     Tests that constructor sets x from mouse wheel scroll event
        /// </summary>
        [Fact]
        public void Constructor_SetsXFromEvent()
        {
            MouseWheelScrollEvent e = new MouseWheelScrollEvent { X = 42 };

            MouseWheelScrollEventArgs args = new MouseWheelScrollEventArgs(e);

            Assert.Equal(42, args.X);
        }

        /// <summary>
        ///     Tests that constructor sets y from mouse wheel scroll event
        /// </summary>
        [Fact]
        public void Constructor_SetsYFromEvent()
        {
            MouseWheelScrollEvent e = new MouseWheelScrollEvent { Y = 84 };

            MouseWheelScrollEventArgs args = new MouseWheelScrollEventArgs(e);

            Assert.Equal(84, args.Y);
        }

        /// <summary>
        ///     Tests that default mouse wheel scroll event produces default arguments
        /// </summary>
        [Fact]
        public void DefaultEvent_ProducesDefaultArgs()
        {
            MouseWheelScrollEventArgs args = new MouseWheelScrollEventArgs(new MouseWheelScrollEvent());

            Assert.Equal(0.0f, args.Delta);
            Assert.Equal(default, args.Wheel);
            Assert.Equal(0, args.X);
            Assert.Equal(0, args.Y);
        }

        /// <summary>
        ///     Tests that properties get and set values
        /// </summary>
        [Fact]
        public void Properties_GetAndSetValues()
        {
            MouseWheelScrollEventArgs args = new MouseWheelScrollEventArgs(new MouseWheelScrollEvent());

            args.Delta = -2.0f;
            args.Wheel = Mouse.Wheel.VerticalWheel;
            args.X = 300;
            args.Y = 400;

            Assert.Equal(-2.0f, args.Delta);
            Assert.Equal(Mouse.Wheel.VerticalWheel, args.Wheel);
            Assert.Equal(300, args.X);
            Assert.Equal(400, args.Y);
        }

        /// <summary>
        ///     Tests that mouse wheel scroll event args inherits from event args
        /// </summary>
        [Fact]
        public void MouseWheelScrollEventArgs_InheritsFromEventArgs()
        {
            MouseWheelScrollEventArgs args = new MouseWheelScrollEventArgs(new MouseWheelScrollEvent());

            Assert.IsAssignableFrom<EventArgs>(args);
        }

        /// <summary>
        ///     Tests that to string returns expected format
        /// </summary>
        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            MouseWheelScrollEvent e = new MouseWheelScrollEvent { Wheel = Mouse.Wheel.VerticalWheel, Delta = 1.0f, X = 10, Y = 20 };
            MouseWheelScrollEventArgs args = new MouseWheelScrollEventArgs(e);

            string str = args.ToString();

            Assert.Contains("[MouseWheelScrollEventArgs]", str);
            Assert.Contains("Wheel(VerticalWheel)", str);
            Assert.Contains("Delta(1)", str);
            Assert.Contains("X(10)", str);
            Assert.Contains("Y(20)", str);
        }
    }
}
