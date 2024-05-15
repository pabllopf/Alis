// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MathFTest.cs
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
    ///     The math test class
    /// </summary>
    public class CustomMathFTest
    {
        /// <summary>
        ///     Tests that sqrt should calculate correctly
        /// </summary>
        [Fact]
        public void Sqrt_ShouldCalculateCorrectly()
        {
            // Arrange
            float x = 4;
            
            // Act
            float result = CustomMathF.Sqrt(x);
            
            // Assert
            Assert.Equal(2, result);
        }
        
        /// <summary>
        ///     Tests that abs should return absolute value
        /// </summary>
        [Fact]
        public void Abs_ShouldReturnAbsoluteValue()
        {
            // Arrange
            float value = -5;
            
            // Act
            float result = CustomMathF.Abs(value);
            
            // Assert
            Assert.Equal(5, result);
        }
        
        /// <summary>
        ///     Tests that cos should calculate correctly
        /// </summary>
        [Fact]
        public void Cos_ShouldCalculateCorrectly()
        {
            // Arrange
            float x = CustomMathF.Pi / 2;
            
            // Act
            float result = CustomMathF.Cos(x);
            
            // Assert
            Assert.Equal(0, result, 5);
        }
        
        /// <summary>
        ///     Tests that sin should calculate correctly
        /// </summary>
        [Fact]
        public void Sin_ShouldCalculateCorrectly()
        {
            // Arrange
            float x = CustomMathF.Pi / 2;
            
            // Act
            float result = CustomMathF.Sin(x);
            
            // Assert
            Assert.Equal(1, result, 5);
        }
        
        /// <summary>
        ///     Tests that acos should calculate correctly
        /// </summary>
        [Fact]
        public void Acos_ShouldCalculateCorrectly()
        {
            // Arrange
            float x = 1;
            
            // Act
            float result = CustomMathF.Acos(x);
            
            // Assert
            Assert.Equal(1.53, result, 2);
        }
        
        /// <summary>
        ///     Tests that max should return maximum value
        /// </summary>
        [Fact]
        public void Max_ShouldReturnMaximumValue()
        {
            // Arrange
            int val1 = 5;
            int val2 = 10;
            
            // Act
            int result = CustomMathF.Max(val1, val2);
            
            // Assert
            Assert.Equal(val2, result);
        }
        
        /// <summary>
        ///     Tests that sin should calculate correctly
        /// </summary>
        [Fact]
        public void Sin_v2_ShouldCalculateCorrectly()
        {
            // Arrange
            float x = CustomMathF.Pi / 2; // Sin(Pi/2) should be 1
            
            // Act
            float result = CustomMathF.Sin(x);
            
            // Assert
            Assert.Equal(1, result, 5);
        }
        
        /// <summary>
        ///     Tests that sin should return na n for na n input
        /// </summary>
        [Fact]
        public void Sin_ShouldReturnNaNForNaNInput()
        {
            // Arrange
            float x = float.NaN;
            
            // Act
            float result = CustomMathF.Sin(x);
            
            // Assert
            Assert.True(float.IsNaN(result));
        }
        
        /// <summary>
        ///     Tests that sin should return na n for infinity input
        /// </summary>
        [Fact]
        public void Sin_ShouldReturnNaNForInfinityInput()
        {
            // Arrange
            float x = float.PositiveInfinity;
            
            // Act
            float result = CustomMathF.Sin(x);
            
            // Assert
            Assert.True(float.IsNaN(result));
        }
        
        /// <summary>
        ///     Tests that sqrt v 3 should calculate correctly
        /// </summary>
        [Fact]
        public void Sqrt_v3_ShouldCalculateCorrectly()
        {
            // Arrange
            float x = 4;
            
            // Act
            float result = CustomMathF.Sqrt(x);
            
            // Assert
            Assert.Equal(2, result);
        }
        
        /// <summary>
        ///     Tests that sqrt should return na n for negative input
        /// </summary>
        [Fact]
        public void Sqrt_ShouldReturnNaNForNegativeInput()
        {
            // Arrange
            float x = -1;
            
            // Act
            float result = CustomMathF.Sqrt(x);
            
            // Assert
            Assert.True(float.IsNaN(result));
        }
        
        /// <summary>
        ///     Tests that sqrt should return zero for zero input
        /// </summary>
        [Fact]
        public void Sqrt_ShouldReturnZeroForZeroInput()
        {
            // Arrange
            float x = 0;
            
            // Act
            float result = CustomMathF.Sqrt(x);
            
            // Assert
            Assert.Equal(0, result);
        }
        
        /// <summary>
        ///     Tests that cos v 2 should calculate correctly
        /// </summary>
        [Fact]
        public void Cos_v2_ShouldCalculateCorrectly()
        {
            // Arrange
            float x = CustomMathF.Pi / 2; // Cos(Pi/2) should be 0
            
            // Act
            float result = CustomMathF.Cos(x);
            
            // Assert
            Assert.Equal(0, result, 5);
        }
        
        /// <summary>
        ///     Tests that cos should return na n for na n input
        /// </summary>
        [Fact]
        public void Cos_ShouldReturnNaNForNaNInput()
        {
            // Arrange
            float x = float.NaN;
            
            // Act
            float result = CustomMathF.Cos(x);
            
            // Assert
            Assert.True(float.IsNaN(result));
        }
        
        /// <summary>
        ///     Tests that cos should return na n for infinity input
        /// </summary>
        [Fact]
        public void Cos_ShouldReturnNaNForInfinityInput()
        {
            // Arrange
            float x = float.PositiveInfinity;
            
            // Act
            float result = CustomMathF.Cos(x);
            
            // Assert
            Assert.True(float.IsNaN(result));
        }
        
        /// <summary>
        ///     Tests that acos v 2 should calculate correctly
        /// </summary>
        [Fact]
        public void Acos_v2_ShouldCalculateCorrectly()
        {
            // Arrange
            float x = 0; // Acos(0) should be Pi/2
            
            // Act
            float result = CustomMathF.Acos(x);
            
            // Assert
            Assert.Equal(CustomMathF.Pi / 2, result, 5);
        }
        
        /// <summary>
        ///     Tests that acos should return na n for input less than minus one
        /// </summary>
        [Fact]
        public void Acos_ShouldReturnNaNForInputLessThanMinusOne()
        {
            // Arrange
            float x = -1.1f;
            
            // Act
            float result = CustomMathF.Acos(x);
            
            // Assert
            Assert.True(float.IsNaN(result));
        }
        
        /// <summary>
        ///     Tests that acos should return na n for input greater than one
        /// </summary>
        [Fact]
        public void Acos_ShouldReturnNaNForInputGreaterThanOne()
        {
            // Arrange
            float x = 1.1f;
            
            // Act
            float result = CustomMathF.Acos(x);
            
            // Assert
            Assert.True(float.IsNaN(result));
        }
        
        /// <summary>
        ///     Tests that acos should return na n for na n input
        /// </summary>
        [Fact]
        public void Acos_ShouldReturnNaNForNaNInput()
        {
            // Arrange
            float x = float.NaN;
            
            // Act
            float result = CustomMathF.Acos(x);
            
            // Assert
            Assert.True(float.IsNaN(result));
        }
        
        /// <summary>
        ///     Tests that sin v 3 should calculate correctly
        /// </summary>
        [Fact]
        public void Sin_v3_ShouldCalculateCorrectly()
        {
            // Arrange
            float x = CustomMathF.Pi / 2; // Sin(Pi/2) should be 1
            
            // Act
            float result = CustomMathF.Sin(x);
            
            // Assert
            Assert.Equal(1, result, 5);
        }
        
        /// <summary>
        ///     Tests that sin v 3 should return na n for na n input
        /// </summary>
        [Fact]
        public void Sin_v3_ShouldReturnNaNForNaNInput()
        {
            // Arrange
            float x = float.NaN;
            
            // Act
            float result = CustomMathF.Sin(x);
            
            // Assert
            Assert.True(float.IsNaN(result));
        }
        
        /// <summary>
        ///     Tests that sin v 3 should return na n for infinity input
        /// </summary>
        [Fact]
        public void Sin_v3_ShouldReturnNaNForInfinityInput()
        {
            // Arrange
            float x = float.PositiveInfinity;
            
            // Act
            float result = CustomMathF.Sin(x);
            
            // Assert
            Assert.True(float.IsNaN(result));
        }
        
        /// <summary>
        ///     Tests that sin should calculate correctly for positive input
        /// </summary>
        [Fact]
        public void Sin_ShouldCalculateCorrectly_ForPositiveInput()
        {
            // Arrange
            float x = CustomMathF.Pi / 2; // Sin(Pi/2) should be 1
            
            // Act
            float result = CustomMathF.Sin(x);
            
            // Assert
            Assert.Equal(1, result, 5);
        }
        
        /// <summary>
        ///     Tests that sin should calculate correctly for negative input
        /// </summary>
        [Fact]
        public void Sin_ShouldCalculateCorrectly_ForNegativeInput()
        {
            // Arrange
            float x = -CustomMathF.Pi / 2; // Sin(-Pi/2) should be -1
            
            // Act
            float result = CustomMathF.Sin(x);
            
            // Assert
            Assert.Equal(-1, result, 5);
        }
        
        /// <summary>
        ///     Tests that sin v 2 should return na n for na n input
        /// </summary>
        [Fact]
        public void Sin_v2_ShouldReturnNaNForNaNInput()
        {
            // Arrange
            float x = float.NaN;
            
            // Act
            float result = CustomMathF.Sin(x);
            
            // Assert
            Assert.True(float.IsNaN(result));
        }
        
        /// <summary>
        ///     Tests that sin v 2 should return na n for infinity input
        /// </summary>
        [Fact]
        public void Sin_v2_ShouldReturnNaNForInfinityInput()
        {
            // Arrange
            float x = float.PositiveInfinity;
            
            // Act
            float result = CustomMathF.Sin(x);
            
            // Assert
            Assert.True(float.IsNaN(result));
        }
        
        /// <summary>
        ///     Tests that sin should calculate correctly for zero input
        /// </summary>
        [Fact]
        public void Sin_ShouldCalculateCorrectly_ForZeroInput()
        {
            // Arrange
            float x = 0; // Sin(0) should be 0
            
            // Act
            float result = CustomMathF.Sin(x);
            
            // Assert
            Assert.Equal(0, result, 5);
        }
        
        /// <summary>
        ///     Tests that math f sin should return correct result when input is zero
        /// </summary>
        [Fact]
        public void MathF_Sin_ShouldReturnCorrectResult_WhenInputIsZero()
        {
            float x = 0.0f;
            float result = CustomMathF.Sin(x);
            Assert.Equal(0.0f, result);
        }
        
        /// <summary>
        ///     Tests that math f sin should return correct result when input is positive
        /// </summary>
        [Fact]
        public void MathF_Sin_ShouldReturnCorrectResult_WhenInputIsPositive()
        {
            float x = CustomMathF.Pi / 2;
            float result = CustomMathF.Sin(x);
            Assert.Equal(1.0f, result, 5);
        }
        
        /// <summary>
        ///     Tests that math f sin should return correct result when input is negative
        /// </summary>
        [Fact]
        public void MathF_Sin_ShouldReturnCorrectResult_WhenInputIsNegative()
        {
            float x = -CustomMathF.Pi / 2;
            float result = CustomMathF.Sin(x);
            Assert.Equal(-1.0f, result, 5);
        }
        
        /// <summary>
        ///     Tests that math f sin should return na n when input is na n
        /// </summary>
        [Fact]
        public void MathF_Sin_ShouldReturnNaN_WhenInputIsNaN()
        {
            float x = float.NaN;
            float result = CustomMathF.Sin(x);
            Assert.True(float.IsNaN(result));
        }
        
        /// <summary>
        ///     Tests that math f sin should return na n when input is positive infinity
        /// </summary>
        [Fact]
        public void MathF_Sin_ShouldReturnNaN_WhenInputIsPositiveInfinity()
        {
            float x = float.PositiveInfinity;
            float result = CustomMathF.Sin(x);
            Assert.True(float.IsNaN(result));
        }
        
        /// <summary>
        ///     Tests that math f sin should return na n when input is negative infinity
        /// </summary>
        [Fact]
        public void MathF_Sin_ShouldReturnNaN_WhenInputIsNegativeInfinity()
        {
            float x = float.NegativeInfinity;
            float result = CustomMathF.Sin(x);
            Assert.True(float.IsNaN(result));
        }
        
        /// <summary>
        ///     Tests that math f sin should return correct result with zero
        /// </summary>
        [Fact]
        public void MathF_Sin_ShouldReturnCorrectResult_WithZero()
        {
            float x = 0.0f;
            float expected = 0.0f;
            
            float result = CustomMathF.Sin(x);
            
            Assert.Equal(expected, result);
        }
        
        /// <summary>
        ///     Tests that math f sin should return correct result with positive value
        /// </summary>
        [Fact]
        public void MathF_Sin_ShouldReturnCorrectResult_WithPositiveValue()
        {
            float x = CustomMathF.Pi / 2; // 90 degrees
            float expected = 1.0f;
            
            float result = CustomMathF.Sin(x);
            
            Assert.Equal(expected, result, 5); // 5 decimal places of precision
        }
        
        /// <summary>
        ///     Tests that math f sin should return correct result with negative value
        /// </summary>
        [Fact]
        public void MathF_Sin_ShouldReturnCorrectResult_WithNegativeValue()
        {
            float x = -CustomMathF.Pi / 2; // -90 degrees
            float expected = -1.0f;
            
            float result = CustomMathF.Sin(x);
            
            Assert.Equal(expected, result, 5); // 5 decimal places of precision
        }
        
        /// <summary>
        ///     Tests that math f sin should return na n with na n
        /// </summary>
        [Fact]
        public void MathF_Sin_ShouldReturnNaN_WithNaN()
        {
            float x = float.NaN;
            
            float result = CustomMathF.Sin(x);
            
            Assert.True(float.IsNaN(result));
        }
        
        /// <summary>
        ///     Tests that math f sin should return na n with infinity
        /// </summary>
        [Fact]
        public void MathF_Sin_ShouldReturnNaN_WithInfinity()
        {
            float x = float.PositiveInfinity;
            
            float result = CustomMathF.Sin(x);
            
            Assert.True(float.IsNaN(result));
        }
        
        /// <summary>
        ///     Tests that math f sin should return correct result with pi over two
        /// </summary>
        [Fact]
        public void MathF_Sin_ShouldReturnCorrectResult_WithPiOverTwo()
        {
            float x = CustomMathF.Pi / 2; // 90 degrees
            float expected = 1.0f;
            
            float result = CustomMathF.Sin(x);
            
            Assert.Equal(expected, result, 5); // 5 decimal places of precision
        }
        
        /// <summary>
        ///     Tests that math f sin should return correct result with negative pi over two
        /// </summary>
        [Fact]
        public void MathF_Sin_ShouldReturnCorrectResult_WithNegativePiOverTwo()
        {
            float x = -CustomMathF.Pi / 2; // -90 degrees
            float expected = -1.0f;
            
            float result = CustomMathF.Sin(x);
            
            Assert.Equal(expected, result, 5); // 5 decimal places of precision
        }
        
        /// <summary>
        ///     Tests that math f sin should return correct result with pi
        /// </summary>
        [Fact]
        public void MathF_Sin_ShouldReturnCorrectResult_WithPi()
        {
            float x = CustomMathF.Pi; // 180 degrees
            float expected = 0.0f;
            
            float result = CustomMathF.Sin(x);
            
            Assert.Equal(expected, result, 5); // 5 decimal places of precision
        }
        
        /// <summary>
        ///     Tests that math f sin should return correct result with two pi
        /// </summary>
        [Fact]
        public void MathF_Sin_ShouldReturnCorrectResult_WithTwoPi()
        {
            float x = 2 * CustomMathF.Pi; // 360 degrees
            float expected = 0.0f;
            
            float result = CustomMathF.Sin(x);
            
            Assert.Equal(expected, result, 5); // 5 decimal places of precision
        }
        
        /// <summary>
        ///     Tests that math f sin should return na n with positive infinity
        /// </summary>
        [Fact]
        public void MathF_Sin_ShouldReturnNaN_WithPositiveInfinity()
        {
            float x = float.PositiveInfinity;
            
            float result = CustomMathF.Sin(x);
            
            Assert.True(float.IsNaN(result));
        }
        
        /// <summary>
        ///     Tests that math f sin should return na n with negative infinity
        /// </summary>
        [Fact]
        public void MathF_Sin_ShouldReturnNaN_WithNegativeInfinity()
        {
            float x = float.NegativeInfinity;
            
            float result = CustomMathF.Sin(x);
            
            Assert.True(float.IsNaN(result));
        }
        
        /// <summary>
        ///     Tests that math f sin should return correct result with large positive value
        /// </summary>
        [Fact]
        public void MathF_Sin_ShouldReturnCorrectResult_WithLargePositiveValue()
        {
            float x = 10000.0f; // A large positive value
            float expected = CustomMathF.Sin(x % (2 * CustomMathF.Pi)); // Expected result based on the periodicity of sin
            
            float result = CustomMathF.Sin(x);
            
            Assert.Equal(expected, result, 5); // 5 decimal places of precision
        }
        
        /// <summary>
        ///     Tests that math f sin should return correct result with large negative value
        /// </summary>
        [Fact]
        public void MathF_Sin_ShouldReturnCorrectResult_WithLargeNegativeValue()
        {
            float x = -10000.0f; // A large negative value
            float expected = CustomMathF.Sin(x % (2 * CustomMathF.Pi)); // Expected result based on the periodicity of sin
            
            float result = CustomMathF.Sin(x);
            
            Assert.Equal(expected, result, 5); // 5 decimal places of precision
        }
        
        /// <summary>
        ///     Tests that math f sin should return na n with max value
        /// </summary>
        [Fact]
        public void MathF_Sin_ShouldReturnNaN_WithMaxValue()
        {
            float x = float.MaxValue;
            
            float result = CustomMathF.Sin(x);
            
            Assert.False(float.IsNaN(result));
        }
        
        /// <summary>
        /// Tests that min with first number less than second returns first number
        /// </summary>
        [Fact]
        public void Min_WithFirstNumberLessThanSecond_ReturnsFirstNumber()
        {
            // Arrange
            int num1 = 5;
            int num2 = 10;
            
            // Act
            int result = CustomMathF.Min(num1, num2);
            
            // Assert
            Assert.Equal(num1, result);
        }
        
        /// <summary>
        /// Tests that min with first number greater than second returns second number
        /// </summary>
        [Fact]
        public void Min_WithFirstNumberGreaterThanSecond_ReturnsSecondNumber()
        {
            // Arrange
            int num1 = 10;
            int num2 = 5;
            
            // Act
            int result = CustomMathF.Min(num1, num2);
            
            // Assert
            Assert.Equal(num2, result);
        }
        
        /// <summary>
        /// Tests that min with both numbers equal returns either number
        /// </summary>
        [Fact]
        public void Min_WithBothNumbersEqual_ReturnsEitherNumber()
        {
            // Arrange
            int num1 = 5;
            int num2 = 5;
            
            // Act
            int result = CustomMathF.Min(num1, num2);
            
            // Assert
            Assert.Equal(num1, result);
            Assert.Equal(num2, result);
        }
    }
}