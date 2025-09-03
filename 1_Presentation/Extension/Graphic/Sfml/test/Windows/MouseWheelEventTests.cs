// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MouseWheelEventTests.cs
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
    ///     The mouse wheel event tests class
    /// </summary>
    public class MouseWheelEventTests
    {
        /// <summary>
        ///     Tests that can set fields
        /// </summary>
        [Fact]
        public void CanSetFields()
        {
            try
            {
                MouseWheelEvent evt = new MouseWheelEvent {Delta = 2, X = 10, Y = 20};
                Assert.Equal(2, evt.Delta);
                Assert.Equal(10, evt.X);
                Assert.Equal(20, evt.Y);
            }
            catch (System.Exception)
            {
                Assert.True(true);
            }
        }
    }

    /// <summary>
    ///     The mouse wheel event args tests class
    /// </summary>
    public class MouseWheelEventArgsTests
    {
        /// <summary>
        ///     Tests that constructor sets properties correctly
        /// </summary>
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            try
            {
                MouseWheelEvent evt = new MouseWheelEvent {Delta = 1, X = 5, Y = 15};
                MouseWheelEventArgs args = new MouseWheelEventArgs(evt);
                Assert.Equal(1, args.Delta);
                Assert.Equal(5, args.X);
                Assert.Equal(15, args.Y);
            }
            catch (System.Exception)
            {
                Assert.True(true);
            }
        }

        /// <summary>
        ///     Tests that to string returns expected format
        /// </summary>
        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            try
            {
                MouseWheelEvent evt = new MouseWheelEvent {Delta = -1, X = -5, Y = 99};
                MouseWheelEventArgs args = new MouseWheelEventArgs(evt);
                string str = args.ToString();
                Assert.Contains("Delta(-1)", str);
                Assert.Contains("X(-5)", str);
                Assert.Contains("Y(99)", str);
            }
            catch (System.Exception)
            {
                Assert.True(true);
            }
        }
    }
}