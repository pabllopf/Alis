// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ColorRemainingCoverageTests.cs
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
    ///     The color remaining coverage tests class
    /// </summary>
    public class ColorRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that constructor assigns fields
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_AssignsFields()
        {
            Color color = new Color(10, 20, 30, 40);

            Assert.Equal(10, color.R);
            Assert.Equal(20, color.G);
            Assert.Equal(30, color.B);
            Assert.Equal(40, color.A);
        }

        /// <summary>
        ///     Tests that constructor without alpha defaults alpha to 255
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_WithoutAlpha_DefaultsAlphaTo255()
        {
            Color color = new Color(10, 20, 30);

            Assert.Equal(10, color.R);
            Assert.Equal(20, color.G);
            Assert.Equal(30, color.B);
            Assert.Equal(255, color.A);
        }

        /// <summary>
        ///     Tests that constructor from uint unpacks components
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_FromUInt_UnpacksComponents()
        {
            uint value = 0xAABBCCDD;
            Color color = new Color(value);

            Assert.Equal(0xAA, color.R);
            Assert.Equal(0xBB, color.G);
            Assert.Equal(0xCC, color.B);
            Assert.Equal(0xDD, color.A);
        }

        /// <summary>
        ///     Tests that constructor from color copies components
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_FromColor_CopiesComponents()
        {
            Color source = new Color(1, 2, 3, 4);
            Color color = new Color(source);

            Assert.Equal(1, color.R);
            Assert.Equal(2, color.G);
            Assert.Equal(3, color.B);
            Assert.Equal(4, color.A);
        }

        /// <summary>
        ///     Tests that to integer packs components
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void ToInteger_PacksComponents()
        {
            Color color = new Color(0xAA, 0xBB, 0xCC, 0xDD);

            Assert.Equal(0xAABBCCDD, color.ToInteger());
        }

        /// <summary>
        ///     Tests that to string returns expected format
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void ToString_ReturnsExpectedFormat()
        {
            Color color = new Color(1, 2, 3, 4);

            string str = color.ToString();

            Assert.Contains("R(1)", str);
            Assert.Contains("G(2)", str);
            Assert.Contains("B(3)", str);
            Assert.Contains("A(4)", str);
        }

        /// <summary>
        ///     Tests that equals with same color returns true
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Equals_WithSameColor_ReturnsTrue()
        {
            Color c1 = new Color(1, 2, 3, 4);
            Color c2 = new Color(1, 2, 3, 4);

            Assert.True(c1.Equals(c2));
        }

        /// <summary>
        ///     Tests that equals with different color returns false
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Equals_WithDifferentColor_ReturnsFalse()
        {
            Color c1 = new Color(1, 2, 3, 4);
            Color c2 = new Color(5, 2, 3, 4);

            Assert.False(c1.Equals(c2));
        }

        /// <summary>
        ///     Tests that equals with boxed color returns true
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Equals_WithBoxedColor_ReturnsTrue()
        {
            Color color = new Color(1, 2, 3, 4);
            object boxed = color;

            Assert.True(color.Equals(boxed));
        }

        /// <summary>
        ///     Tests that equals with non color object returns false
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Equals_WithNonColorObject_ReturnsFalse()
        {
            Color color = new Color(1, 2, 3, 4);

            Assert.False(color.Equals("not a color"));
            Assert.False(color.Equals(null));
        }

        /// <summary>
        ///     Tests that get hash code matches packed components
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void GetHashCode_MatchesPackedComponents()
        {
            Color color = new Color(1, 2, 3, 4);

            Assert.Equal((1 << 24) | (2 << 16) | (3 << 8) | 4, color.GetHashCode());
        }

        /// <summary>
        ///     Tests that equality operator returns true for equal colors
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void EqualityOperator_WithEqualColors_ReturnsTrue()
        {
            Color c1 = new Color(1, 2, 3, 4);
            Color c2 = new Color(1, 2, 3, 4);

            Assert.True(c1 == c2);
        }

        /// <summary>
        ///     Tests that inequality operator returns true for different colors
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void InequalityOperator_WithDifferentColors_ReturnsTrue()
        {
            Color c1 = new Color(1, 2, 3, 4);
            Color c2 = new Color(5, 2, 3, 4);

            Assert.True(c1 != c2);
        }

        /// <summary>
        ///     Tests that addition clamps components at 255
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Addition_ClampsComponentsAt255()
        {
            Color c1 = new Color(200, 100, 0, 0);
            Color c2 = new Color(100, 200, 0, 0);

            Color result = c1 + c2;

            Assert.Equal(255, result.R);
            Assert.Equal(255, result.G);
            Assert.Equal(0, result.B);
            Assert.Equal(0, result.A);
        }

        /// <summary>
        ///     Tests that addition sums non overflowing components
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Addition_SumsNonOverflowingComponents()
        {
            Color c1 = new Color(10, 20, 30, 40);
            Color c2 = new Color(1, 2, 3, 4);

            Color result = c1 + c2;

            Assert.Equal(11, result.R);
            Assert.Equal(22, result.G);
            Assert.Equal(33, result.B);
            Assert.Equal(44, result.A);
        }

        /// <summary>
        ///     Tests that subtraction clamps components at 0
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Subtraction_ClampsComponentsAt0()
        {
            Color c1 = new Color(10, 20, 30, 40);
            Color c2 = new Color(100, 5, 3, 4);

            Color result = c1 - c2;

            Assert.Equal(0, result.R);
            Assert.Equal(15, result.G);
            Assert.Equal(27, result.B);
            Assert.Equal(36, result.A);
        }

        /// <summary>
        ///     Tests that multiplication scales components
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Multiplication_ScalesComponents()
        {
            Color c1 = new Color(200, 100, 50, 25);
            Color c2 = new Color(128, 128, 128, 128);

            Color result = c1 * c2;

            Assert.Equal(100, result.R);
            Assert.Equal(50, result.G);
            Assert.Equal(25, result.B);
            Assert.Equal(12, result.A);
        }

        /// <summary>
        ///     Tests that predefined black has expected components
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Predefined_Black_HasExpectedComponents()
        {
            Assert.Equal(0, Color.Black.R);
            Assert.Equal(0, Color.Black.G);
            Assert.Equal(0, Color.Black.B);
            Assert.Equal(255, Color.Black.A);
        }

        /// <summary>
        ///     Tests that predefined white has expected components
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Predefined_White_HasExpectedComponents()
        {
            Assert.Equal(255, Color.White.R);
            Assert.Equal(255, Color.White.G);
            Assert.Equal(255, Color.White.B);
            Assert.Equal(255, Color.White.A);
        }

        /// <summary>
        ///     Tests that predefined red has expected components
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Predefined_Red_HasExpectedComponents()
        {
            Assert.Equal(255, Color.Red.R);
            Assert.Equal(0, Color.Red.G);
            Assert.Equal(0, Color.Red.B);
            Assert.Equal(255, Color.Red.A);
        }

        /// <summary>
        ///     Tests that predefined green has expected components
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Predefined_Green_HasExpectedComponents()
        {
            Assert.Equal(0, Color.Green.R);
            Assert.Equal(255, Color.Green.G);
            Assert.Equal(0, Color.Green.B);
            Assert.Equal(255, Color.Green.A);
        }

        /// <summary>
        ///     Tests that predefined blue has expected components
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Predefined_Blue_HasExpectedComponents()
        {
            Assert.Equal(0, Color.Blue.R);
            Assert.Equal(0, Color.Blue.G);
            Assert.Equal(255, Color.Blue.B);
            Assert.Equal(255, Color.Blue.A);
        }

        /// <summary>
        ///     Tests that predefined yellow has expected components
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Predefined_Yellow_HasExpectedComponents()
        {
            Assert.Equal(255, Color.Yellow.R);
            Assert.Equal(255, Color.Yellow.G);
            Assert.Equal(0, Color.Yellow.B);
            Assert.Equal(255, Color.Yellow.A);
        }

        /// <summary>
        ///     Tests that predefined magenta has expected components
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Predefined_Magenta_HasExpectedComponents()
        {
            Assert.Equal(255, Color.Magenta.R);
            Assert.Equal(0, Color.Magenta.G);
            Assert.Equal(255, Color.Magenta.B);
            Assert.Equal(255, Color.Magenta.A);
        }

        /// <summary>
        ///     Tests that predefined cyan has expected components
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Predefined_Cyan_HasExpectedComponents()
        {
            Assert.Equal(0, Color.Cyan.R);
            Assert.Equal(255, Color.Cyan.G);
            Assert.Equal(255, Color.Cyan.B);
            Assert.Equal(255, Color.Cyan.A);
        }

        /// <summary>
        ///     Tests that predefined transparent has expected components
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Predefined_Transparent_HasExpectedComponents()
        {
            Assert.Equal(0, Color.Transparent.R);
            Assert.Equal(0, Color.Transparent.G);
            Assert.Equal(0, Color.Transparent.B);
            Assert.Equal(0, Color.Transparent.A);
        }
    }
}
