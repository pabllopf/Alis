// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ColorTest.cs
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

using Alis.Extension.Graphic.Sfml.Render;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     Unit tests for the Color struct.
    /// </summary>
    public class ColorTest
    {
        /// <summary>
        ///     Tests the constructors and ToInteger method.
        /// </summary>
        [Fact]
        public void Constructor_And_ToInteger_Works()
        {
            Color color = new Color(10, 20, 30, 40);
            Assert.Equal(10, color.R);
            Assert.Equal(20, color.G);
            Assert.Equal(30, color.B);
            Assert.Equal(40, color.A);
            uint intValue = color.ToInteger();
            Color color2 = new Color(intValue);
            Assert.Equal(color, color2);
        }

        /// <summary>
        ///     Tests the copy constructor.
        /// </summary>
        [Fact]
        public void CopyConstructor_Works()
        {
            Color color = new Color(1, 2, 3, 4);
            Color copy = new Color(color);
            Assert.Equal(color, copy);
        }

        /// <summary>
        ///     Tests equality and inequality.
        /// </summary>
        [Fact]
        public void Equality_Works()
        {
            Color c1 = new Color(1, 2, 3, 4);
            Color c2 = new Color(1, 2, 3, 4);
            Color c3 = new Color(5, 6, 7, 8);
            Assert.True(c1.Equals(c2));
            Assert.False(c1.Equals(c3));
            Assert.True(c1 == c2);
            Assert.True(c1 != c3);
        }

        /// <summary>
        ///     Tests ToString returns a non-empty string.
        /// </summary>
        [Fact]
        public void ToString_NotEmpty()
        {
            Color color = new Color(1, 2, 3, 4);
            Assert.False(string.IsNullOrWhiteSpace(color.ToString()));
        }
    }
}