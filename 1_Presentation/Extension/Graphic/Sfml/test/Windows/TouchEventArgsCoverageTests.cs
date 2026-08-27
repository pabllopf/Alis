// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TouchEventArgsCoverageTests.cs
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
    ///     Tests for TouchEventArgs.
    /// </summary>
    public class TouchEventArgsCoverageTests
    {
        /// <summary>
        ///     Tests that constructor sets finger from event
        /// </summary>
        [Fact]
        public void Constructor_SetsFingerFromEvent()
        {
            TouchEvent e = new TouchEvent { Finger = 2u };

            TouchEventArgs args = new TouchEventArgs(e);

            Assert.Equal(2u, args.Finger);
        }

        /// <summary>
        ///     Tests that constructor sets x from event
        /// </summary>
        [Fact]
        public void Constructor_SetsXFromEvent()
        {
            TouchEvent e = new TouchEvent { X = 42 };

            TouchEventArgs args = new TouchEventArgs(e);

            Assert.Equal(42, args.X);
        }

        /// <summary>
        ///     Tests that constructor sets y from event
        /// </summary>
        [Fact]
        public void Constructor_SetsYFromEvent()
        {
            TouchEvent e = new TouchEvent { Y = 84 };

            TouchEventArgs args = new TouchEventArgs(e);

            Assert.Equal(84, args.Y);
        }

        /// <summary>
        ///     Tests that default event produces default arguments
        /// </summary>
        [Fact]
        public void DefaultEvent_ProducesDefaultArgs()
        {
            TouchEventArgs args = new TouchEventArgs(new TouchEvent());

            Assert.Equal(0u, args.Finger);
            Assert.Equal(0, args.X);
            Assert.Equal(0, args.Y);
        }

        /// <summary>
        ///     Tests that properties get and set values
        /// </summary>
        [Fact]
        public void Properties_GetAndSetValues()
        {
            TouchEventArgs args = new TouchEventArgs(new TouchEvent());

            args.Finger = 5u;
            args.X = 300;
            args.Y = 400;

            Assert.Equal(5u, args.Finger);
            Assert.Equal(300, args.X);
            Assert.Equal(400, args.Y);
        }

        /// <summary>
        ///     Tests that touch event args inherits from event args
        /// </summary>
        [Fact]
        public void TouchEventArgs_InheritsFromEventArgs()
        {
            TouchEventArgs args = new TouchEventArgs(new TouchEvent());

            Assert.IsAssignableFrom<EventArgs>(args);
        }

        /// <summary>
        ///     Tests that to string returns expected format
        /// </summary>
        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            TouchEvent e = new TouchEvent { Finger = 1u, X = 10, Y = 20 };
            TouchEventArgs args = new TouchEventArgs(e);

            string str = args.ToString();

            Assert.Contains("[TouchEventArgs]", str);
            Assert.Contains("Finger(1)", str);
            Assert.Contains("X(10)", str);
            Assert.Contains("Y(20)", str);
        }
    }
}
