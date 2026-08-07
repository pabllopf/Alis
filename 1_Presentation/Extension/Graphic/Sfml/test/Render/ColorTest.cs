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
using Alis.Extension.Graphic.Sfml.Test.Attributes;
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
        [RequireCSfmlSystemFact]
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
        [RequireCSfmlSystemFact]
        public void CopyConstructor_Works()
        {
            Color color = new Color(1, 2, 3, 4);
            Color copy = new Color(color);
            Assert.Equal(color, copy);
        }

        /// <summary>
        ///     Tests equality and inequality.
        /// </summary>
        [RequireCSfmlSystemFact]
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
        [RequireCSfmlSystemFact]
        public void ToString_NotEmpty()
        {
            Color color = new Color(1, 2, 3, 4);
            Assert.False(string.IsNullOrWhiteSpace(color.ToString()));
        }

        /// <summary>
        /// Tests that static colors have expected values
        /// </summary>
        [RequireCSfmlSystemFact]
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

        /// <summary>
        /// Tests that operator add clamps to 255
        /// </summary>
        [RequireCSfmlSystemFact]
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

        /// <summary>
        /// Tests that operator subtract clamps to zero
        /// </summary>
        [RequireCSfmlSystemFact]
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

        /// <summary>
        /// Tests that operator multiply scales correctly
        /// </summary>
        [RequireCSfmlSystemFact]
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

        /// <summary>
        /// Tests that operator multiply with half reduces by factor
        /// </summary>
        [RequireCSfmlSystemFact]
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

        /// <summary>
        /// Tests that three param constructor sets alpha to 255
        /// </summary>
        [RequireCSfmlSystemFact]
        public void ThreeParamConstructor_SetsAlphaTo255()
        {
            Color color = new Color(10, 20, 30);
            Assert.Equal(10, color.R);
            Assert.Equal(20, color.G);
            Assert.Equal(30, color.B);
            Assert.Equal(255, color.A);
        }

        /// <summary>
        ///     Tests that Equals(object) returns true for matching boxed colors
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Equals_Object_ReturnsTrueForMatchingColor()
        {
            Color c1 = new Color(10, 20, 30, 40);
            Color c2 = new Color(10, 20, 30, 40);

            Assert.True(c1.Equals((object)c2));
        }

        /// <summary>
        ///     Tests that Equals(object) returns false for non-Color object
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Equals_Object_ReturnsFalseForNonColor()
        {
            Color color = new Color(1, 2, 3, 4);

            Assert.False(color.Equals("not a color"));
        }

        /// <summary>
        ///     Tests that GetHashCode returns consistent values for equal colors
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetHashCode_EqualColors_ReturnsSameValue()
        {
            Color c1 = new Color(10, 20, 30, 40);
            Color c2 = new Color(10, 20, 30, 40);

            Assert.Equal(c1.GetHashCode(), c2.GetHashCode());
        }
    }
}