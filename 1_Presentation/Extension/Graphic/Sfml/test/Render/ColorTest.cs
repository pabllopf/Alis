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

        [Fact]
        public void StaticColors_HaveExpectedValues()
        {
            Assert.Equal(new Color(0, 0, 0), Color.Black);
            Assert.Equal(new Color(255, 255, 255), Color.White);
            Assert.Equal(new Color(255, 0, 0), Color.Red);
            Assert.Equal(new Color(0, 255, 0), Color.Green);
            Assert.Equal(new Color(0, 0, 255), Color.Blue);
            Assert.Equal(new Color(255, 255, 0), Color.Yellow);
            Assert.Equal(new Color(255, 0, 255), Color.Magenta);
            Assert.Equal(new Color(0, 255, 255), Color.Cyan);
            Assert.Equal(new Color(0, 0, 0, 0), Color.Transparent);
        }

        [Fact]
        public void OperatorAdd_ClampsTo255()
        {
            Color c1 = new Color(200, 200, 200, 200);
            Color c2 = new Color(100, 100, 100, 100);
            Color result = c1 + c2;
            Assert.Equal(255, result.R);
            Assert.Equal(255, result.G);
            Assert.Equal(255, result.B);
            Assert.Equal(255, result.A);
        }

        [Fact]
        public void OperatorSubtract_ClampsToZero()
        {
            Color c1 = new Color(50, 50, 50, 50);
            Color c2 = new Color(100, 100, 100, 100);
            Color result = c1 - c2;
            Assert.Equal(0, result.R);
            Assert.Equal(0, result.G);
            Assert.Equal(0, result.B);
            Assert.Equal(0, result.A);
        }

        [Fact]
        public void OperatorMultiply_ScalesCorrectly()
        {
            Color c1 = new Color(128, 128, 128, 128);
            Color c2 = new Color(255, 255, 255, 255);
            Color result = c1 * c2;
            Assert.Equal(128, result.R);
            Assert.Equal(128, result.G);
            Assert.Equal(128, result.B);
            Assert.Equal(128, result.A);
        }

        [Fact]
        public void OperatorMultiply_WithHalfReducesByFactor()
        {
            Color white = new Color(255, 255, 255, 255);
            Color half = new Color(128, 128, 128, 128);
            Color result = white * half;
            Assert.Equal(128, result.R);
            Assert.Equal(128, result.G);
            Assert.Equal(128, result.B);
            Assert.Equal(128, result.A);
        }

        [Fact]
        public void ThreeParamConstructor_SetsAlphaTo255()
        {
            Color color = new Color(10, 20, 30);
            Assert.Equal(10, color.R);
            Assert.Equal(20, color.G);
            Assert.Equal(30, color.B);
            Assert.Equal(255, color.A);
        }
    }
}