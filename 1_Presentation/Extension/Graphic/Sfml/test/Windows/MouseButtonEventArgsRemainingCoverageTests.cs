// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MouseButtonEventArgsRemainingCoverageTests.cs
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

using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    ///     The mouse button event args remaining coverage tests class
    /// </summary>
    public class MouseButtonEventArgsRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that constructor assigns values from event
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_AssignsValuesFromEvent()
        {
            MouseButtonEvent buttonEvent = new MouseButtonEvent
            {
                Button = Mouse.Button.Left,
                X = 100,
                Y = 200
            };

            MouseButtonEventArgs args = new MouseButtonEventArgs(buttonEvent);

            Assert.Equal(Mouse.Button.Left, args.Button);
            Assert.Equal(100, args.X);
            Assert.Equal(200, args.Y);
        }

        /// <summary>
        ///     Tests that properties get and set values
        /// </summary>
        [RequireCSfmlWindowsFact]
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
        ///     Tests that to string returns expected format
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void ToString_ReturnsExpectedFormat()
        {
            MouseButtonEvent buttonEvent = new MouseButtonEvent
            {
                Button = Mouse.Button.Left,
                X = 10,
                Y = 20
            };
            MouseButtonEventArgs args = new MouseButtonEventArgs(buttonEvent);

            string str = args.ToString();

            Assert.Contains("[MouseButtonEventArgs]", str);
            Assert.Contains("Button(Left)", str);
            Assert.Contains("X(10)", str);
            Assert.Contains("Y(20)", str);
        }
    }
}
