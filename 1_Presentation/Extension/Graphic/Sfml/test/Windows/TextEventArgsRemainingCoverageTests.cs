// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TextEventArgsRemainingCoverageTests.cs
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
    ///     The text event args remaining coverage tests class
    /// </summary>
    public class TextEventArgsRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that constructor converts unicode value to string
        /// </summary>
        [Fact]
        public void Constructor_ConvertsUnicodeValueToString()
        {
            TextEvent textEvent = new TextEvent
            {
                Unicode = 65
            };

            TextEventArgs args = new TextEventArgs(textEvent);

            Assert.Equal("A", args.Unicode);
        }

        /// <summary>
        ///     Tests that property gets and sets value
        /// </summary>
        [Fact]
        public void Property_GetAndSetValue()
        {
            TextEventArgs args = new TextEventArgs(new TextEvent());

            args.Unicode = "Z";

            Assert.Equal("Z", args.Unicode);
        }

        /// <summary>
        ///     Tests that to string returns expected format
        /// </summary>
        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            TextEvent textEvent = new TextEvent
            {
                Unicode = 66
            };
            TextEventArgs args = new TextEventArgs(textEvent);

            string str = args.ToString();

            Assert.Contains("[TextEventArgs]", str);
            Assert.Contains("Unicode(B)", str);
        }
    }
}
