// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BlendModeRemainingCoverageTests.cs
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
    ///     The blend mode remaining coverage tests class
    /// </summary>
    public class BlendModeRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that factor enum has correct values
        /// </summary>
        [Fact]
        public void Factor_Enum_HasCorrectValues()
        {
            Assert.Equal(0, (int) BlendMode.Factor.Zero);
            Assert.Equal(1, (int) BlendMode.Factor.One);
            Assert.Equal(2, (int) BlendMode.Factor.SrcColor);
            Assert.Equal(3, (int) BlendMode.Factor.OneMinusSrcColor);
            Assert.Equal(4, (int) BlendMode.Factor.DstColor);
            Assert.Equal(5, (int) BlendMode.Factor.OneMinusDstColor);
            Assert.Equal(6, (int) BlendMode.Factor.SrcAlpha);
            Assert.Equal(7, (int) BlendMode.Factor.OneMinusSrcAlpha);
            Assert.Equal(8, (int) BlendMode.Factor.DstAlpha);
            Assert.Equal(9, (int) BlendMode.Factor.OneMinusDstAlpha);
        }

        /// <summary>
        ///     Tests that equation enum has correct values
        /// </summary>
        [Fact]
        public void Equation_Enum_HasCorrectValues()
        {
            Assert.Equal(0, (int) BlendMode.Equation.Add);
            Assert.Equal(1, (int) BlendMode.Equation.Subtract);
            Assert.Equal(2, (int) BlendMode.Equation.ReverseSubtract);
        }

        /// <summary>
        ///     Tests that two factor constructor assigns matching factors and add equation
        /// </summary>
        [Fact]
        public void TwoFactorConstructor_AssignsMatchingFactors_AndAddEquation()
        {
            BlendMode mode = new BlendMode(BlendMode.Factor.SrcColor, BlendMode.Factor.DstColor);

            Assert.Equal(BlendMode.Factor.SrcColor, mode.ColorSrcFactor);
            Assert.Equal(BlendMode.Factor.DstColor, mode.ColorDstFactor);
            Assert.Equal(BlendMode.Equation.Add, mode.ColorEquation);
            Assert.Equal(BlendMode.Factor.SrcColor, mode.AlphaSrcFactor);
            Assert.Equal(BlendMode.Factor.DstColor, mode.AlphaDstFactor);
            Assert.Equal(BlendMode.Equation.Add, mode.AlphaEquation);
        }

        /// <summary>
        ///     Tests that three factor constructor assigns matching factors and equation
        /// </summary>
        [Fact]
        public void ThreeFactorConstructor_AssignsMatchingFactors_AndEquation()
        {
            BlendMode mode = new BlendMode(BlendMode.Factor.SrcAlpha, BlendMode.Factor.OneMinusSrcAlpha, BlendMode.Equation.Subtract);

            Assert.Equal(BlendMode.Factor.SrcAlpha, mode.ColorSrcFactor);
            Assert.Equal(BlendMode.Factor.OneMinusSrcAlpha, mode.ColorDstFactor);
            Assert.Equal(BlendMode.Equation.Subtract, mode.ColorEquation);
            Assert.Equal(BlendMode.Factor.SrcAlpha, mode.AlphaSrcFactor);
            Assert.Equal(BlendMode.Factor.OneMinusSrcAlpha, mode.AlphaDstFactor);
            Assert.Equal(BlendMode.Equation.Subtract, mode.AlphaEquation);
        }

        /// <summary>
        ///     Tests that six factor constructor assigns all factors
        /// </summary>
        [Fact]
        public void SixFactorConstructor_AssignsAllFactors()
        {
            BlendMode mode = new BlendMode(BlendMode.Factor.SrcAlpha, BlendMode.Factor.One, BlendMode.Equation.Add,
                BlendMode.Factor.DstAlpha, BlendMode.Factor.OneMinusDstAlpha, BlendMode.Equation.ReverseSubtract);

            Assert.Equal(BlendMode.Factor.SrcAlpha, mode.ColorSrcFactor);
            Assert.Equal(BlendMode.Factor.One, mode.ColorDstFactor);
            Assert.Equal(BlendMode.Equation.Add, mode.ColorEquation);
            Assert.Equal(BlendMode.Factor.DstAlpha, mode.AlphaSrcFactor);
            Assert.Equal(BlendMode.Factor.OneMinusDstAlpha, mode.AlphaDstFactor);
            Assert.Equal(BlendMode.Equation.ReverseSubtract, mode.AlphaEquation);
        }

        /// <summary>
        ///     Tests that predefined alpha has expected factors
        /// </summary>
        [Fact]
        public void Predefined_Alpha_HasExpectedFactors()
        {
            Assert.Equal(BlendMode.Factor.SrcAlpha, BlendMode.Alpha.ColorSrcFactor);
            Assert.Equal(BlendMode.Factor.OneMinusSrcAlpha, BlendMode.Alpha.ColorDstFactor);
            Assert.Equal(BlendMode.Equation.Add, BlendMode.Alpha.ColorEquation);
            Assert.Equal(BlendMode.Factor.One, BlendMode.Alpha.AlphaSrcFactor);
            Assert.Equal(BlendMode.Factor.OneMinusSrcAlpha, BlendMode.Alpha.AlphaDstFactor);
            Assert.Equal(BlendMode.Equation.Add, BlendMode.Alpha.AlphaEquation);
        }

        /// <summary>
        ///     Tests that predefined add has expected factors
        /// </summary>
        [Fact]
        public void Predefined_Add_HasExpectedFactors()
        {
            Assert.Equal(BlendMode.Factor.SrcAlpha, BlendMode.Add.ColorSrcFactor);
            Assert.Equal(BlendMode.Factor.One, BlendMode.Add.ColorDstFactor);
            Assert.Equal(BlendMode.Equation.Add, BlendMode.Add.ColorEquation);
            Assert.Equal(BlendMode.Factor.One, BlendMode.Add.AlphaSrcFactor);
            Assert.Equal(BlendMode.Factor.One, BlendMode.Add.AlphaDstFactor);
            Assert.Equal(BlendMode.Equation.Add, BlendMode.Add.AlphaEquation);
        }

        /// <summary>
        ///     Tests that predefined multiply has expected factors
        /// </summary>
        [Fact]
        public void Predefined_Multiply_HasExpectedFactors()
        {
            Assert.Equal(BlendMode.Factor.DstColor, BlendMode.Multiply.ColorSrcFactor);
            Assert.Equal(BlendMode.Factor.Zero, BlendMode.Multiply.ColorDstFactor);
            Assert.Equal(BlendMode.Equation.Add, BlendMode.Multiply.ColorEquation);
            Assert.Equal(BlendMode.Factor.DstColor, BlendMode.Multiply.AlphaSrcFactor);
            Assert.Equal(BlendMode.Factor.Zero, BlendMode.Multiply.AlphaDstFactor);
            Assert.Equal(BlendMode.Equation.Add, BlendMode.Multiply.AlphaEquation);
        }

        /// <summary>
        ///     Tests that predefined none has expected factors
        /// </summary>
        [Fact]
        public void Predefined_None_HasExpectedFactors()
        {
            Assert.Equal(BlendMode.Factor.One, BlendMode.None.ColorSrcFactor);
            Assert.Equal(BlendMode.Factor.Zero, BlendMode.None.ColorDstFactor);
            Assert.Equal(BlendMode.Equation.Add, BlendMode.None.ColorEquation);
            Assert.Equal(BlendMode.Factor.One, BlendMode.None.AlphaSrcFactor);
            Assert.Equal(BlendMode.Factor.Zero, BlendMode.None.AlphaDstFactor);
            Assert.Equal(BlendMode.Equation.Add, BlendMode.None.AlphaEquation);
        }

        /// <summary>
        ///     Tests that equals with same mode returns true
        /// </summary>
        [Fact]
        public void Equals_WithSameMode_ReturnsTrue()
        {
            BlendMode m1 = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);
            BlendMode m2 = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);

            Assert.True(m1.Equals(m2));
        }

        /// <summary>
        ///     Tests that equals with different mode returns false
        /// </summary>
        [Fact]
        public void Equals_WithDifferentMode_ReturnsFalse()
        {
            BlendMode m1 = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);
            BlendMode m2 = new BlendMode(BlendMode.Factor.SrcAlpha, BlendMode.Factor.OneMinusSrcAlpha);

            Assert.False(m1.Equals(m2));
        }

        /// <summary>
        ///     Tests that equals with boxed mode returns true
        /// </summary>
        [Fact]
        public void Equals_WithBoxedMode_ReturnsTrue()
        {
            BlendMode mode = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);
            object boxed = mode;

            Assert.True(mode.Equals(boxed));
        }

        /// <summary>
        ///     Tests that equals with non mode object returns false
        /// </summary>
        [Fact]
        public void Equals_WithNonModeObject_ReturnsFalse()
        {
            BlendMode mode = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);

            Assert.False(mode.Equals("not a blend mode"));
            Assert.False(mode.Equals(null));
        }

        /// <summary>
        ///     Tests that equality operator returns true for equal modes
        /// </summary>
        [Fact]
        public void EqualityOperator_WithEqualModes_ReturnsTrue()
        {
            BlendMode m1 = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);
            BlendMode m2 = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);

            Assert.True(m1 == m2);
        }

        /// <summary>
        ///     Tests that inequality operator returns true for different modes
        /// </summary>
        [Fact]
        public void InequalityOperator_WithDifferentModes_ReturnsTrue()
        {
            BlendMode m1 = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);
            BlendMode m2 = new BlendMode(BlendMode.Factor.SrcAlpha, BlendMode.Factor.OneMinusSrcAlpha);

            Assert.True(m1 != m2);
        }

        /// <summary>
        ///     Tests that get hash code is deterministic for equal modes
        /// </summary>
        [Fact]
        public void GetHashCode_IsDeterministic()
        {
            BlendMode m1 = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);
            BlendMode m2 = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);

            Assert.Equal(m1.GetHashCode(), m2.GetHashCode());
        }
    }
}
