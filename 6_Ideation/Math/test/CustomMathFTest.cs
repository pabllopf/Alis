// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CustomMathFTest.cs
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

using Xunit;

namespace Alis.Core.Aspect.Math.Test
{
    /// <summary>
    ///     The custom math test class
    /// </summary>
    public class CustomMathFTest
    {
        /// <summary>
        ///     Tests that sqrt with negative value returns na n
        /// </summary>
        [Fact]
        public void Sqrt_WithNegativeValue_ReturnsNaN()
        {
            float result = CustomMathF.Sqrt(-1f);

            Assert.True(float.IsNaN(result));
        }

        /// <summary>
        ///     Tests that sqrt with zero returns zero
        /// </summary>
        [Fact]
        public void Sqrt_WithZero_ReturnsZero()
        {
            float result = CustomMathF.Sqrt(0f);

            Assert.Equal(0f, result);
        }

        /// <summary>
        ///     Tests that sqrt with perfect square returns expected value
        /// </summary>
        [Fact]
        public void Sqrt_WithPerfectSquare_ReturnsExpectedValue()
        {
            float result = CustomMathF.Sqrt(9f);

            Assert.Equal(3f, result, 3);
        }

        /// <summary>
        ///     Tests that sin and cos with canonical angles return expected values
        /// </summary>
        [Fact]
        public void SinAndCos_WithCanonicalAngles_ReturnExpectedValues()
        {
            float sin = CustomMathF.Sin(CustomMathF.Pi / 2f);
            float cos = CustomMathF.Cos(0f);

            Assert.Equal(1f, sin, 2);
            Assert.Equal(1f, cos, 2);
        }

        /// <summary>
        ///     Tests that cos with NaN returns NaN
        /// </summary>
        [Fact]
        public void Cos_WithNaN_ReturnsNaN()
        {
            Assert.True(float.IsNaN(CustomMathF.Cos(float.NaN)));
        }

        /// <summary>
        ///     Tests that tan with NaN returns NaN
        /// </summary>
        [Fact]
        public void Tan_WithNaN_ReturnsNaN()
        {
            Assert.True(float.IsNaN(CustomMathF.Tan(float.NaN)));
        }

        /// <summary>
        ///     Tests that trigonometric functions with invalid values return na n
        /// </summary>
        [Fact]
        public void TrigonometricFunctions_WithInvalidValues_ReturnNaN()
        {
            Assert.True(float.IsNaN(CustomMathF.Sin(float.NaN)));
            Assert.True(float.IsNaN(CustomMathF.Cos(float.PositiveInfinity)));
            Assert.True(float.IsNaN(CustomMathF.Tan(float.NegativeInfinity)));
        }

        /// <summary>
        ///     Tests that tan with half pi returns positive infinity
        /// </summary>
        [Fact]
        public void Tan_WithHalfPi_ReturnsPositiveInfinity()
        {
            float result = CustomMathF.Tan(CustomMathF.Pi / 2f);

            Assert.True(float.IsPositiveInfinity(result));
        }

        /// <summary>
        ///     Tests that acos out of range returns na n
        /// </summary>
        [Fact]
        public void Acos_OutOfRange_ReturnsNaN()
        {
            Assert.True(float.IsNaN(CustomMathF.Acos(-1.01f)));
            Assert.True(float.IsNaN(CustomMathF.Acos(1.01f)));
        }

        /// <summary>
        ///     Tests that clamp limits value to range
        /// </summary>
        [Fact]
        public void Clamp_LimitsValueToRange()
        {
            Assert.Equal(0f, CustomMathF.Clamp(-1f, 0f, 1f));
            Assert.Equal(1f, CustomMathF.Clamp(5f, 0f, 1f));
            Assert.Equal(0.3f, CustomMathF.Clamp(0.3f, 0f, 1f));
        }

        /// <summary>
        ///     Tests that max min for int and float return expected operand
        /// </summary>
        [Fact]
        public void MaxMin_ForIntAndFloat_ReturnExpectedOperand()
        {
            Assert.Equal(7, CustomMathF.Max(7, 3));
            Assert.Equal(3, CustomMathF.Min(7, 3));
            Assert.Equal(7.5f, CustomMathF.Max(7.5f, 7.4f));
            Assert.Equal(7.4f, CustomMathF.Min(7.5f, 7.4f));
        }

        /// <summary>
        ///     Tests that max returns second operand when first is smaller
        /// </summary>
        [Fact]
        public void Max_ReturnsSecondOperand_WhenFirstIsSmaller()
        {
            Assert.Equal(5, CustomMathF.Max(3, 5));
            Assert.Equal(7.5f, CustomMathF.Max(7.4f, 7.5f));
        }

        /// <summary>
        ///     Tests that min returns second operand when first is larger
        /// </summary>
        [Fact]
        public void Min_ReturnsSecondOperand_WhenFirstIsLarger()
        {
            Assert.Equal(3, CustomMathF.Min(5, 3));
            Assert.Equal(7.4f, CustomMathF.Min(7.5f, 7.4f));
        }

        /// <summary>
        ///     Tests that max returns equal value when operands are equal
        /// </summary>
        [Fact]
        public void Max_ReturnsEqualValue_WhenOperandsAreEqual()
        {
            Assert.Equal(5, CustomMathF.Max(5, 5));
            Assert.Equal(5.0f, CustomMathF.Max(5.0f, 5.0f));
        }

        /// <summary>
        ///     Tests that min returns equal value when operands are equal
        /// </summary>
        [Fact]
        public void Min_ReturnsEqualValue_WhenOperandsAreEqual()
        {
            Assert.Equal(5, CustomMathF.Min(5, 5));
            Assert.Equal(5.0f, CustomMathF.Min(5.0f, 5.0f));
        }

        /// <summary>
        ///     Tests that max with first int smaller than second returns second
        /// </summary>
        [Fact]
        public void Max_WhenFirstIsSmaller_ReturnsSecond()
        {
            Assert.Equal(7, CustomMathF.Max(3, 7));
        }

        /// <summary>
        ///     Tests that max with first float smaller than second returns second
        /// </summary>
        [Fact]
        public void Max_WhenFirstIsSmallerFloat_ReturnsSecond()
        {
            Assert.Equal(7.5f, CustomMathF.Max(7.4f, 7.5f));
        }

        /// <summary>
        ///     Tests that min with first int smaller than second returns first
        /// </summary>
        [Fact]
        public void Min_WhenFirstIsSmaller_ReturnsFirst()
        {
            Assert.Equal(3, CustomMathF.Min(3, 7));
        }

        /// <summary>
        ///     Tests that min with first float smaller than second returns first
        /// </summary>
        [Fact]
        public void Min_WhenFirstIsSmallerFloat_ReturnsFirst()
        {
            Assert.Equal(7.4f, CustomMathF.Min(7.4f, 7.5f));
        }

        /// <summary>
        ///     Tests that abs with negative and positive values returns magnitude
        /// </summary>
        [Fact]
        public void Abs_WithNegativeAndPositiveValues_ReturnsMagnitude()
        {
            Assert.Equal(10f, CustomMathF.Abs(-10f));
            Assert.Equal(10f, CustomMathF.Abs(10f));
        }

        /// <summary>
        ///     Tests that sin with angle greater than half pi reduces the angle and returns expected value
        /// </summary>
        [Fact]
        public void Sin_WhenAngleGreaterThanHalfPi_ReducesAngle()
        {
            float result = CustomMathF.Sin(CustomMathF.Pi);

            Assert.Equal(0f, result, 2);
        }

        /// <summary>
        ///     Tests that sin with angle less than negative half pi increases the angle and returns expected value
        /// </summary>
        [Fact]
        public void Sin_WhenAngleLessThanNegativeHalfPi_IncreasesAngle()
        {
            float result = CustomMathF.Sin(-CustomMathF.Pi);

            Assert.Equal(0f, result, 2);
        }

        /// <summary>
        ///     Tests that sin and cos with full turn are approximately canonical
        /// </summary>
        [Fact]
        public void SinAndCos_WithFullTurn_AreApproximatelyCanonical()
        {
            float sin = CustomMathF.Sin(CustomMathF.Tau);
            float cos = CustomMathF.Cos(CustomMathF.Tau);

            Assert.Equal(0f, sin, 2);
            Assert.Equal(1f, cos, 2);
        }

        /// <summary>
        ///     Tests that acos with valid input returns expected value
        /// </summary>
        [Fact]
        public void Acos_WithValidInput_ReturnsExpectedValue()
        {
            float result = CustomMathF.Acos(0f);

            Assert.Equal(CustomMathF.Pi / 2, result, 1);
        }

        /// <summary>
        ///     Tests that acos with midpoint returns expected value
        /// </summary>
        [Fact]
        public void Acos_WithMidpoint_ReturnsExpectedValue()
        {
            float result = CustomMathF.Acos(0.5f);

            Assert.Equal(CustomMathF.Pi / 3, result, 1);
        }

        /// <summary>
        ///     Tests that cos with non trivial angle executes loop iterations
        /// </summary>
        [Fact]
        public void Cos_WithNonTrivialAngle_ExecutesLoopIterations()
        {
            float result = CustomMathF.Cos(CustomMathF.Pi);

            Assert.Equal(-1f, result, 2);
        }

        /// <summary>
        ///     Tests that sin with non trivial angle executes loop iterations
        /// </summary>
        [Fact]
        public void Sin_WithNonTrivialAngle_ExecutesLoopIterations()
        {
            float result = CustomMathF.Sin(CustomMathF.Pi / 2);

            Assert.Equal(1f, result, 2);
        }

        /// <summary>
        ///     Tests that sqrt with non perfect square returns approximate value
        /// </summary>
        [Fact]
        public void Sqrt_WithNonPerfectSquare_ReturnsApproximateValue()
        {
            float result = CustomMathF.Sqrt(2f);

            Assert.Equal(1.414f, result, 3);
        }

        /// <summary>
        ///     Tests that tan with normal angle returns expected value
        /// </summary>
        [Fact]
        public void Tan_WithNormalAngle_ReturnsExpectedValue()
        {
            float result = CustomMathF.Tan(0f);

            Assert.Equal(0f, result, 2);
        }

        /// <summary>
        ///     Tests that abs with zero returns zero
        /// </summary>
        [Fact]
        public void Abs_WithZero_ReturnsZero()
        {
            Assert.Equal(0f, CustomMathF.Abs(0f));
        }

        /// <summary>
        ///     Tests that acos with na n returns na n
        /// </summary>
        [Fact]
        public void Acos_WithNaN_ReturnsNaN()
        {
            Assert.True(float.IsNaN(CustomMathF.Acos(float.NaN)));
        }
    }
}