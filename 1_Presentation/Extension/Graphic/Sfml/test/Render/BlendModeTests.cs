// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BlendModeTests.cs
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
    ///     Unit tests for the BlendMode struct covering all public members, constructors, nested enums and both branches.
    /// </summary>
    public class BlendModeTests
    {
        /// <summary>
        ///     Tests that the default struct value has zeroed factors and the Add equation.
        /// </summary>
        [Fact]
        public void DefaultValue_HasZeroedFactorsAndAddEquation()
        {
            BlendMode mode = default;

            Assert.Equal(BlendMode.Factor.Zero, mode.ColorSrcFactor);
            Assert.Equal(BlendMode.Factor.Zero, mode.ColorDstFactor);
            Assert.Equal(BlendMode.Equation.Add, mode.ColorEquation);
            Assert.Equal(BlendMode.Factor.Zero, mode.AlphaSrcFactor);
            Assert.Equal(BlendMode.Factor.Zero, mode.AlphaDstFactor);
            Assert.Equal(BlendMode.Equation.Add, mode.AlphaEquation);
        }

        /// <summary>
        ///     Tests that the two parameter constructor assigns both color and alpha factors and the Add equation.
        /// </summary>
        [Fact]
        public void Constructor_TwoParameters_AssignsFactorsAndAddEquation()
        {
            BlendMode mode = new BlendMode(BlendMode.Factor.SrcAlpha, BlendMode.Factor.OneMinusSrcAlpha);

            Assert.Equal(BlendMode.Factor.SrcAlpha, mode.ColorSrcFactor);
            Assert.Equal(BlendMode.Factor.OneMinusSrcAlpha, mode.ColorDstFactor);
            Assert.Equal(BlendMode.Equation.Add, mode.ColorEquation);
            Assert.Equal(BlendMode.Factor.SrcAlpha, mode.AlphaSrcFactor);
            Assert.Equal(BlendMode.Factor.OneMinusSrcAlpha, mode.AlphaDstFactor);
            Assert.Equal(BlendMode.Equation.Add, mode.AlphaEquation);
        }

        /// <summary>
        ///     Tests that the three parameter constructor assigns both color and alpha factors and the given equation.
        /// </summary>
        [Fact]
        public void Constructor_ThreeParameters_AssignsEquationToColorAndAlpha()
        {
            BlendMode mode = new BlendMode(BlendMode.Factor.DstColor, BlendMode.Factor.Zero, BlendMode.Equation.Subtract);

            Assert.Equal(BlendMode.Factor.DstColor, mode.ColorSrcFactor);
            Assert.Equal(BlendMode.Factor.Zero, mode.ColorDstFactor);
            Assert.Equal(BlendMode.Equation.Subtract, mode.ColorEquation);
            Assert.Equal(BlendMode.Factor.DstColor, mode.AlphaSrcFactor);
            Assert.Equal(BlendMode.Factor.Zero, mode.AlphaDstFactor);
            Assert.Equal(BlendMode.Equation.Subtract, mode.AlphaEquation);
        }

        /// <summary>
        ///     Tests that the six parameter constructor assigns separate color and alpha configuration.
        /// </summary>
        [Fact]
        public void Constructor_SixParameters_AssignsSeparateColorAndAlpha()
        {
            BlendMode mode = new BlendMode(
                BlendMode.Factor.SrcColor, BlendMode.Factor.OneMinusDstColor, BlendMode.Equation.Add,
                BlendMode.Factor.DstAlpha, BlendMode.Factor.OneMinusDstAlpha, BlendMode.Equation.ReverseSubtract);

            Assert.Equal(BlendMode.Factor.SrcColor, mode.ColorSrcFactor);
            Assert.Equal(BlendMode.Factor.OneMinusDstColor, mode.ColorDstFactor);
            Assert.Equal(BlendMode.Equation.Add, mode.ColorEquation);
            Assert.Equal(BlendMode.Factor.DstAlpha, mode.AlphaSrcFactor);
            Assert.Equal(BlendMode.Factor.OneMinusDstAlpha, mode.AlphaDstFactor);
            Assert.Equal(BlendMode.Equation.ReverseSubtract, mode.AlphaEquation);
        }

        /// <summary>
        ///     Tests that the factor enum has the expected underlying values.
        /// </summary>
        [Fact]
        public void Factor_Enum_HasExpectedValues()
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
        ///     Tests that the equation enum has the expected underlying values.
        /// </summary>
        [Fact]
        public void Equation_Enum_HasExpectedValues()
        {
            Assert.Equal(0, (int) BlendMode.Equation.Add);
            Assert.Equal(1, (int) BlendMode.Equation.Subtract);
            Assert.Equal(2, (int) BlendMode.Equation.ReverseSubtract);
        }

        /// <summary>
        ///     Tests that the predefined Alpha mode has the expected factors and equations.
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
        ///     Tests that the predefined Add mode has the expected factors and equations.
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
        ///     Tests that the predefined Multiply mode has the expected factors and equations.
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
        ///     Tests that the predefined None mode has the expected factors and equations.
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
        ///     Tests that Equals returns true for identical blend modes.
        /// </summary>
        [Fact]
        public void Equals_IdenticalModes_ReturnsTrue()
        {
            BlendMode m1 = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);
            BlendMode m2 = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);

            Assert.True(m1.Equals(m2));
        }

        /// <summary>
        ///     Tests that Equals returns false for blend modes that differ in a factor.
        /// </summary>
        [Fact]
        public void Equals_DifferentFactor_ReturnsFalse()
        {
            BlendMode m1 = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);
            BlendMode m2 = new BlendMode(BlendMode.Factor.SrcAlpha, BlendMode.Factor.Zero);

            Assert.False(m1.Equals(m2));
        }

        /// <summary>
        ///     Tests that Equals returns false for blend modes that differ in an equation.
        /// </summary>
        [Fact]
        public void Equals_DifferentEquation_ReturnsFalse()
        {
            BlendMode m1 = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero, BlendMode.Equation.Add);
            BlendMode m2 = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero, BlendMode.Equation.Subtract);

            Assert.False(m1.Equals(m2));
        }

        /// <summary>
        ///     Tests that Equals returns false for blend modes that differ only in the alpha configuration.
        /// </summary>
        [Fact]
        public void Equals_DifferentAlphaConfiguration_ReturnsFalse()
        {
            BlendMode m1 = new BlendMode(
                BlendMode.Factor.One, BlendMode.Factor.Zero, BlendMode.Equation.Add,
                BlendMode.Factor.One, BlendMode.Factor.Zero, BlendMode.Equation.Add);
            BlendMode m2 = new BlendMode(
                BlendMode.Factor.One, BlendMode.Factor.Zero, BlendMode.Equation.Add,
                BlendMode.Factor.DstAlpha, BlendMode.Factor.Zero, BlendMode.Equation.Add);

            Assert.False(m1.Equals(m2));
        }

        /// <summary>
        ///     Tests that the object Equals overload returns true for a boxed equal blend mode.
        /// </summary>
        [Fact]
        public void Equals_Object_BoxedEqualMode_ReturnsTrue()
        {
            BlendMode mode = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);
            object boxed = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);

            Assert.True(mode.Equals(boxed));
        }

        /// <summary>
        ///     Tests that the object Equals overload returns false for a different mode, a non mode object and null.
        /// </summary>
        [Fact]
        public void Equals_Object_NonEqualNonModeAndNull_ReturnsFalse()
        {
            BlendMode mode = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);

            Assert.False(mode.Equals(new BlendMode(BlendMode.Factor.SrcAlpha, BlendMode.Factor.OneMinusSrcAlpha)));
            Assert.False(mode.Equals("not a blend mode"));
            Assert.False(mode.Equals(null));
        }

        /// <summary>
        ///     Tests that GetHashCode is stable for equal blend modes.
        /// </summary>
        [Fact]
        public void GetHashCode_EqualModes_ReturnsSameValue()
        {
            BlendMode m1 = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);
            BlendMode m2 = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);

            Assert.Equal(m1.GetHashCode(), m2.GetHashCode());
        }

        /// <summary>
        ///     Tests that GetHashCode differs for distinct blend modes with asymmetric color and alpha configuration.
        /// </summary>
        [Fact]
        public void GetHashCode_DifferentModes_ReturnsDifferentValue()
        {
            BlendMode m1 = new BlendMode(
                BlendMode.Factor.One, BlendMode.Factor.Zero, BlendMode.Equation.Add,
                BlendMode.Factor.One, BlendMode.Factor.Zero, BlendMode.Equation.Add);
            BlendMode m2 = new BlendMode(
                BlendMode.Factor.SrcAlpha, BlendMode.Factor.OneMinusSrcAlpha, BlendMode.Equation.Subtract,
                BlendMode.Factor.DstAlpha, BlendMode.Factor.OneMinusDstAlpha, BlendMode.Equation.ReverseSubtract);

            Assert.NotEqual(m1.GetHashCode(), m2.GetHashCode());
        }

        /// <summary>
        ///     Tests that the equality operator behaves correctly.
        /// </summary>
        [Fact]
        public void Operator_Equality_WorksCorrectly()
        {
            BlendMode m1 = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);
            BlendMode m2 = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);
            BlendMode m3 = new BlendMode(BlendMode.Factor.SrcAlpha, BlendMode.Factor.OneMinusSrcAlpha);

            Assert.True(m1 == m2);
            Assert.False(m1 == m3);
        }

        /// <summary>
        ///     Tests that the inequality operator behaves correctly.
        /// </summary>
        [Fact]
        public void Operator_Inequality_WorksCorrectly()
        {
            BlendMode m1 = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);
            BlendMode m2 = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);
            BlendMode m3 = new BlendMode(BlendMode.Factor.SrcAlpha, BlendMode.Factor.OneMinusSrcAlpha);

            Assert.False(m1 != m2);
            Assert.True(m1 != m3);
        }
    }
}
