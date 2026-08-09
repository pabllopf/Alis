// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MouseWheelScrollEventArgsRemainingCoverageTests.cs
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
    ///     The mouse wheel scroll event args remaining coverage tests class
    /// </summary>
    public class MouseWheelScrollEventArgsRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that constructor assigns values from event
        /// </summary>
        [Fact]
        public void Constructor_AssignsValuesFromEvent()
        {
            MouseWheelScrollEvent wheelEvent = new MouseWheelScrollEvent
            {
                Wheel = Mouse.Wheel.VerticalWheel,
                Delta = 1.5f,
                X = 100,
                Y = 200
            };

            MouseWheelScrollEventArgs args = new MouseWheelScrollEventArgs(wheelEvent);

            Assert.Equal(Mouse.Wheel.VerticalWheel, args.Wheel);
            Assert.Equal(1.5f, args.Delta);
            Assert.Equal(100, args.X);
            Assert.Equal(200, args.Y);
        }

        /// <summary>
        ///     Tests that properties get and set values
        /// </summary>
        [Fact]
        public void Properties_GetAndSetValues()
        {
            MouseWheelScrollEventArgs args = new MouseWheelScrollEventArgs(new MouseWheelScrollEvent());

            args.Delta = -2.0f;
            args.Wheel = Mouse.Wheel.HorizontalWheel;
            args.X = 300;
            args.Y = 400;

            Assert.Equal(-2.0f, args.Delta);
            Assert.Equal(Mouse.Wheel.HorizontalWheel, args.Wheel);
            Assert.Equal(300, args.X);
            Assert.Equal(400, args.Y);
        }

        /// <summary>
        ///     Tests that to string returns expected format
        /// </summary>
        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            MouseWheelScrollEvent wheelEvent = new MouseWheelScrollEvent
            {
                Wheel = Mouse.Wheel.VerticalWheel,
                Delta = 1,
                X = 10,
                Y = 20
            };
            MouseWheelScrollEventArgs args = new MouseWheelScrollEventArgs(wheelEvent);

            string str = args.ToString();

            Assert.Contains("[MouseWheelScrollEventArgs]", str);
            Assert.Contains("Wheel(VerticalWheel)", str);
            Assert.Contains("Delta(1)", str);
            Assert.Contains("X(10)", str);
            Assert.Contains("Y(20)", str);
        }
    }
}
