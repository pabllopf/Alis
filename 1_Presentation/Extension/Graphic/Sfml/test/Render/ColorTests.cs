// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ColorTests.cs
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
    ///     Unit tests for the Color struct covering all public members, static colors and both branches.
    /// </summary>
    public class ColorTests
    {
        /// <summary>
        ///     Tests that the four component constructor assigns all fields.
        /// </summary>
        [Fact]
        public void Constructor_FourComponents_AssignsFields()
        {
            Color color = new Color(10, 20, 30, 40);

            Assert.Equal(10, color.R);
            Assert.Equal(20, color.G);
            Assert.Equal(30, color.B);
            Assert.Equal(40, color.A);
        }

        /// <summary>
        ///     Tests that the three component constructor assigns all fields and sets alpha to 255.
        /// </summary>
        [Fact]
        public void Constructor_ThreeComponents_SetsAlphaTo255()
        {
            Color color = new Color(10, 20, 30);

            Assert.Equal(10, color.R);
            Assert.Equal(20, color.G);
            Assert.Equal(30, color.B);
            Assert.Equal(255, color.A);
        }

        /// <summary>
        ///     Tests that the unsigned integer constructor decodes the RGBA components in order.
        /// </summary>
        [Fact]
        public void Constructor_FromUInteger_DecodesComponents()
        {
            Color color = new Color(0x10203040);

            Assert.Equal(0x10, color.R);
            Assert.Equal(0x20, color.G);
            Assert.Equal(0x30, color.B);
            Assert.Equal(0x40, color.A);
        }

        /// <summary>
        ///     Tests that the copy constructor copies all components.
        /// </summary>
        [Fact]
        public void CopyConstructor_CopiesComponents()
        {
            Color color = new Color(1, 2, 3, 4);

            Color copy = new Color(color);

            Assert.Equal(color.R, copy.R);
            Assert.Equal(color.G, copy.G);
            Assert.Equal(color.B, copy.B);
            Assert.Equal(color.A, copy.A);
        }

        /// <summary>
        ///     Tests that the default struct value has zeroed components.
        /// </summary>
        [Fact]
        public void DefaultValue_HasZeroedComponents()
        {
            Color color = default;

            Assert.Equal(0, color.R);
            Assert.Equal(0, color.G);
            Assert.Equal(0, color.B);
            Assert.Equal(0, color.A);
        }

        /// <summary>
        ///     Tests that ToInteger packs the RGBA components into a 32-bit unsigned integer.
        /// </summary>
        [Fact]
        public void ToInteger_PacksComponents()
        {
            Color color = new Color(10, 20, 30, 40);

            uint value = color.ToInteger();

            Assert.Equal((10u << 24) | (20u << 16) | (30u << 8) | 40u, value);
        }

        /// <summary>
        ///     Tests that ToInteger round trips through the unsigned integer constructor.
        /// </summary>
        [Fact]
        public void ToInteger_RoundTripsThroughUIntegerConstructor()
        {
            Color color = new Color(1, 2, 3, 4);

            Color restored = new Color(color.ToInteger());

            Assert.Equal(color, restored);
        }

        /// <summary>
        ///     Tests that ToString returns the expected format.
        /// </summary>
        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            Color color = new Color(10, 20, 30, 40);

            string str = color.ToString();

            Assert.Contains("[Color]", str);
            Assert.Contains("R(10)", str);
            Assert.Contains("G(20)", str);
            Assert.Contains("B(30)", str);
            Assert.Contains("A(40)", str);
        }

        /// <summary>
        ///     Tests that Equals returns true for colors with identical components.
        /// </summary>
        [Fact]
        public void Equals_IdenticalColors_ReturnsTrue()
        {
            Color c1 = new Color(10, 20, 30, 40);
            Color c2 = new Color(10, 20, 30, 40);

            Assert.True(c1.Equals(c2));
        }

        /// <summary>
        ///     Tests that Equals returns false for colors with different components.
        /// </summary>
        [Fact]
        public void Equals_DifferentColors_ReturnsFalse()
        {
            Color c1 = new Color(10, 20, 30, 40);
            Color c2 = new Color(11, 20, 30, 40);

            Assert.False(c1.Equals(c2));
        }

        /// <summary>
        ///     Tests that Equals object overload returns true for a boxed equal color.
        /// </summary>
        [Fact]
        public void Equals_Object_BoxedEqualColor_ReturnsTrue()
        {
            Color color = new Color(10, 20, 30, 40);

            Assert.True(color.Equals(new Color(10, 20, 30, 40)));
        }

        /// <summary>
        ///     Tests that Equals object overload returns false for a different color, a non color object and null.
        /// </summary>
        [Fact]
        public void Equals_Object_NonEqualAndNonColorAndNull_ReturnsFalse()
        {
            Color color = new Color(10, 20, 30, 40);

            Assert.False(color.Equals(new Color(0, 0, 0, 0)));
            Assert.False(color.Equals("not a color"));
            Assert.False(color.Equals(null));
        }

        /// <summary>
        ///     Tests that GetHashCode is stable for equal colors.
        /// </summary>
        [Fact]
        public void GetHashCode_EqualColors_ReturnsSameValue()
        {
            Color c1 = new Color(10, 20, 30, 40);
            Color c2 = new Color(10, 20, 30, 40);

            Assert.Equal(c1.GetHashCode(), c2.GetHashCode());
        }

        /// <summary>
        ///     Tests that GetHashCode differs for distinct colors.
        /// </summary>
        [Fact]
        public void GetHashCode_DifferentColors_ReturnsDifferentValue()
        {
            Color c1 = new Color(10, 20, 30, 40);
            Color c2 = new Color(255, 255, 255, 255);

            Assert.NotEqual(c1.GetHashCode(), c2.GetHashCode());
        }

        /// <summary>
        ///     Tests that the equality operator behaves correctly.
        /// </summary>
        [Fact]
        public void Operator_Equality_WorksCorrectly()
        {
            Color c1 = new Color(10, 20, 30, 40);
            Color c2 = new Color(10, 20, 30, 40);
            Color c3 = new Color(0, 0, 0, 0);

            Assert.True(c1 == c2);
            Assert.False(c1 == c3);
        }

        /// <summary>
        ///     Tests that the inequality operator behaves correctly.
        /// </summary>
        [Fact]
        public void Operator_Inequality_WorksCorrectly()
        {
            Color c1 = new Color(10, 20, 30, 40);
            Color c2 = new Color(10, 20, 30, 40);
            Color c3 = new Color(0, 0, 0, 0);

            Assert.False(c1 != c2);
            Assert.True(c1 != c3);
        }

        /// <summary>
        ///     Tests that the addition operator computes the component wise sum without clamping.
        /// </summary>
        [Fact]
        public void Operator_Addition_WithoutClamp_ComputesSum()
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
        ///     Tests that the addition operator clamps components to 255.
        /// </summary>
        [Fact]
        public void Operator_Addition_ClampsTo255()
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
        ///     Tests that the subtraction operator computes the component wise difference without clamping.
        /// </summary>
        [Fact]
        public void Operator_Subtraction_WithoutClamp_ComputesDifference()
        {
            Color c1 = new Color(10, 20, 30, 40);
            Color c2 = new Color(1, 2, 3, 4);

            Color result = c1 - c2;

            Assert.Equal(9, result.R);
            Assert.Equal(18, result.G);
            Assert.Equal(27, result.B);
            Assert.Equal(36, result.A);
        }

        /// <summary>
        ///     Tests that the subtraction operator clamps components to 0.
        /// </summary>
        [Fact]
        public void Operator_Subtraction_ClampsToZero()
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
        ///     Tests that the multiplication operator scales the components.
        /// </summary>
        [Fact]
        public void Operator_Multiplication_ScalesComponents()
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
        ///     Tests that the multiplication operator with a zero color produces a transparent color.
        /// </summary>
        [Fact]
        public void Operator_Multiplication_WithZeroColor_ProducesTransparent()
        {
            Color c1 = new Color(255, 255, 255, 255);
            Color c2 = new Color(0, 0, 0, 0);

            Color result = c1 * c2;

            Assert.Equal(0, result.R);
            Assert.Equal(0, result.G);
            Assert.Equal(0, result.B);
            Assert.Equal(0, result.A);
        }

        /// <summary>
        ///     Tests that the multiplication operator rounds down on division.
        /// </summary>
        [Fact]
        public void Operator_Multiplication_RoundsDownOnDivision()
        {
            Color c1 = new Color(1, 1, 1, 1);
            Color c2 = new Color(255, 255, 255, 255);

            Color result = c1 * c2;

            Assert.Equal(1, result.R);
            Assert.Equal(1, result.G);
            Assert.Equal(1, result.B);
            Assert.Equal(1, result.A);
        }

        /// <summary>
        ///     Tests that the Black static color has the expected components.
        /// </summary>
        [Fact]
        public void StaticColor_Black_IsOpaqueBlack()
        {
            Assert.Equal(0, Color.Black.R);
            Assert.Equal(0, Color.Black.G);
            Assert.Equal(0, Color.Black.B);
            Assert.Equal(255, Color.Black.A);
        }

        /// <summary>
        ///     Tests that the White static color has the expected components.
        /// </summary>
        [Fact]
        public void StaticColor_White_IsOpaqueWhite()
        {
            Assert.Equal(255, Color.White.R);
            Assert.Equal(255, Color.White.G);
            Assert.Equal(255, Color.White.B);
            Assert.Equal(255, Color.White.A);
        }

        /// <summary>
        ///     Tests that the Red static color has the expected components.
        /// </summary>
        [Fact]
        public void StaticColor_Red_IsOpaqueRed()
        {
            Assert.Equal(255, Color.Red.R);
            Assert.Equal(0, Color.Red.G);
            Assert.Equal(0, Color.Red.B);
            Assert.Equal(255, Color.Red.A);
        }

        /// <summary>
        ///     Tests that the Green static color has the expected components.
        /// </summary>
        [Fact]
        public void StaticColor_Green_IsOpaqueGreen()
        {
            Assert.Equal(0, Color.Green.R);
            Assert.Equal(255, Color.Green.G);
            Assert.Equal(0, Color.Green.B);
            Assert.Equal(255, Color.Green.A);
        }

        /// <summary>
        ///     Tests that the Blue static color has the expected components.
        /// </summary>
        [Fact]
        public void StaticColor_Blue_IsOpaqueBlue()
        {
            Assert.Equal(0, Color.Blue.R);
            Assert.Equal(0, Color.Blue.G);
            Assert.Equal(255, Color.Blue.B);
            Assert.Equal(255, Color.Blue.A);
        }

        /// <summary>
        ///     Tests that the Yellow static color has the expected components.
        /// </summary>
        [Fact]
        public void StaticColor_Yellow_IsOpaqueYellow()
        {
            Assert.Equal(255, Color.Yellow.R);
            Assert.Equal(255, Color.Yellow.G);
            Assert.Equal(0, Color.Yellow.B);
            Assert.Equal(255, Color.Yellow.A);
        }

        /// <summary>
        ///     Tests that the Magenta static color has the expected components.
        /// </summary>
        [Fact]
        public void StaticColor_Magenta_IsOpaqueMagenta()
        {
            Assert.Equal(255, Color.Magenta.R);
            Assert.Equal(0, Color.Magenta.G);
            Assert.Equal(255, Color.Magenta.B);
            Assert.Equal(255, Color.Magenta.A);
        }

        /// <summary>
        ///     Tests that the Cyan static color has the expected components.
        /// </summary>
        [Fact]
        public void StaticColor_Cyan_IsOpaqueCyan()
        {
            Assert.Equal(0, Color.Cyan.R);
            Assert.Equal(255, Color.Cyan.G);
            Assert.Equal(255, Color.Cyan.B);
            Assert.Equal(255, Color.Cyan.A);
        }

        /// <summary>
        ///     Tests that the Transparent static color has the expected components.
        /// </summary>
        [Fact]
        public void StaticColor_Transparent_IsFullyTransparent()
        {
            Assert.Equal(0, Color.Transparent.R);
            Assert.Equal(0, Color.Transparent.G);
            Assert.Equal(0, Color.Transparent.B);
            Assert.Equal(0, Color.Transparent.A);
        }
    }
}
