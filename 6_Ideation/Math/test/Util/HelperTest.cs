// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:HelperTest.cs
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

using Alis.Core.Aspect.Math.Util;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Util
{
    /// <summary>
    ///     The helper test class
    /// </summary>
    public class HelperTest
    {
        /// <summary>
        ///     Tests that barycentric should calculate correctly
        /// </summary>
        [Fact]
        public void Barycentric_ShouldCalculateCorrectly()
        {
            // Arrange
            float value1 = 1.0f;
            float value2 = 2.0f;
            float value3 = 3.0f;
            float amount1 = 0.5f;
            float amount2 = 0.5f;
            
            // Act
            float result = Helper.Barycentric(value1, value2, value3, amount1, amount2);
            
            // Assert
            Assert.Equal(2.5f, result);
        }
        
        /// <summary>
        ///     Tests that catmull rom should calculate correctly
        /// </summary>
        [Fact]
        public void CatmullRom_ShouldCalculateCorrectly()
        {
            // Arrange
            float value1 = 0.0f;
            float value2 = 1.0f;
            float value3 = 2.0f;
            float value4 = 3.0f;
            float amount = 0.5f;
            
            // Act
            float result = Helper.CatmullRom(value1, value2, value3, value4, amount);
            
            // Assert
            Assert.Equal(1.5f, result);
        }
        
        /// <summary>
        ///     Tests that clamp should return correct value
        /// </summary>
        [Fact]
        public void Clamp_ShouldReturnCorrectValue()
        {
            // Arrange
            float value = 0.5f;
            float min = 0.0f;
            float max = 1.0f;
            
            // Act
            float result = Helper.Clamp(value, min, max);
            
            // Assert
            Assert.Equal(0.5f, result);
        }
        
        /// <summary>
        ///     Tests that distance should calculate correctly
        /// </summary>
        [Fact]
        public void Distance_ShouldCalculateCorrectly()
        {
            // Arrange
            float value1 = 1.0f;
            float value2 = 2.0f;
            
            // Act
            float result = Helper.Distance(value1, value2);
            
            // Assert
            Assert.Equal(1.0f, result);
        }
        
        /// <summary>
        ///     Tests that hermite should calculate correctly
        /// </summary>
        [Fact]
        public void Hermite_ShouldCalculateCorrectly()
        {
            // Arrange
            float value1 = 0.0f;
            float tangent1 = 0.0f;
            float value2 = 1.0f;
            float tangent2 = 0.0f;
            float amount = 0.5f;
            
            // Act
            float result = Helper.Hermite(value1, tangent1, value2, tangent2, amount);
            
            // Assert
            Assert.Equal(0.5f, result);
        }
        
        /// <summary>
        ///     Tests that lerp should calculate correctly
        /// </summary>
        [Fact]
        public void Lerp_ShouldCalculateCorrectly()
        {
            // Arrange
            float value1 = 0.0f;
            float value2 = 1.0f;
            float amount = 0.5f;
            
            // Act
            float result = Helper.Lerp(value1, value2, amount);
            
            // Assert
            Assert.Equal(0.5f, result);
        }
        
        /// <summary>
        ///     Tests that max should return correct value
        /// </summary>
        [Fact]
        public void Max_ShouldReturnCorrectValue()
        {
            // Arrange
            float value1 = 0.5f;
            float value2 = 1.0f;
            
            // Act
            float result = Helper.Max(value1, value2);
            
            // Assert
            Assert.Equal(1.0f, result);
        }
        
        /// <summary>
        ///     Tests that min should return correct value
        /// </summary>
        [Fact]
        public void Min_ShouldReturnCorrectValue()
        {
            // Arrange
            float value1 = 0.5f;
            float value2 = 1.0f;
            
            // Act
            float result = Helper.Min(value1, value2);
            
            // Assert
            Assert.Equal(0.5f, result);
        }
        
        /// <summary>
        ///     Tests that smooth step should calculate correctly
        /// </summary>
        [Fact]
        public void SmoothStep_ShouldCalculateCorrectly()
        {
            // Arrange
            float value1 = 0.0f;
            float value2 = 1.0f;
            float amount = 0.5f;
            
            // Act
            float result = Helper.SmoothStep(value1, value2, amount);
            
            // Assert
            Assert.Equal(0.5f, result);
        }
        
        /// <summary>
        ///     Tests that to degrees should calculate correctly
        /// </summary>
        [Fact]
        public void ToDegrees_ShouldCalculateCorrectly()
        {
            // Arrange
            float radians = CustomMathF.Pi;
            
            // Act
            float result = Helper.ToDegrees(radians);
            
            // Assert
            Assert.Equal(180.0f, result);
        }
        
        /// <summary>
        ///     Tests that to radians should calculate correctly
        /// </summary>
        [Fact]
        public void ToRadians_ShouldCalculateCorrectly()
        {
            // Arrange
            float degrees = 180.0f;
            
            // Act
            float result = Helper.ToRadians(degrees);
            
            // Assert
            Assert.Equal(CustomMathF.Pi, result);
        }
        
        /// <summary>
        ///     Tests that wrap angle should calculate correctly
        /// </summary>
        [Fact]
        public void WrapAngle_ShouldCalculateCorrectly()
        {
            // Arrange
            float angle = 3 * CustomMathF.Pi;
            
            // Act
            float result = Helper.WrapAngle(angle);
            
            // Assert
            Assert.Equal(CustomMathF.Pi, result, 0.1);
        }
        
        /// <summary>
        ///     Tests that is power of two should return correct value
        /// </summary>
        [Fact]
        public void IsPowerOfTwo_ShouldReturnCorrectValue()
        {
            // Arrange
            int value = 4;
            
            // Act
            bool result = Helper.IsPowerOfTwo(value);
            
            // Assert
            Assert.True(result);
        }
        
        /// <summary>
        ///     Tests that wrap angle should return same value when angle is between negative pi and pi
        /// </summary>
        [Fact]
        public void WrapAngle_ShouldReturnSameValue_WhenAngleIsBetweenNegativePiAndPi()
        {
            float angle = Constant.Pi / 2;
            float result = Helper.WrapAngle(angle);
            
            Assert.Equal(angle, result);
        }
        
        /// <summary>
        ///     Tests that wrap angle should return positive value when angle is less than negative pi
        /// </summary>
        [Fact]
        public void WrapAngle_ShouldReturnPositiveValue_WhenAngleIsLessThanNegativePi()
        {
            float angle = -Constant.Pi * 1.5f;
            float expected = Constant.Pi / 2;
            float result = Helper.WrapAngle(angle);
            
            Assert.Equal(expected, result, 0.1f);
        }
        
        /// <summary>
        ///     Tests that wrap angle should return negative value when angle is more than pi
        /// </summary>
        [Fact]
        public void WrapAngle_ShouldReturnNegativeValue_WhenAngleIsMoreThanPi()
        {
            float angle = Constant.Pi * 1.5f;
            float expected = -Constant.Pi / 2;
            float result = Helper.WrapAngle(angle);
            
            Assert.Equal(expected, result, 0.1f);
        }
        
        /// <summary>
        ///     Tests that wrap angle should return zero when angle is zero
        /// </summary>
        [Fact]
        public void WrapAngle_ShouldReturnZero_WhenAngleIsZero()
        {
            float angle = 0.0f;
            float result = Helper.WrapAngle(angle);
            
            Assert.Equal(angle, result);
        }
        
        /// <summary>
        ///     Tests that wrap angle should return negative pi when angle is negative pi
        /// </summary>
        [Fact]
        public void WrapAngle_ShouldReturnNegativePi_WhenAngleIsNegativePi()
        {
            float angle = Constant.Pi;
            float result = Helper.WrapAngle(angle);
            
            Assert.Equal(angle, result);
        }
        
        /// <summary>
        ///     Tests that wrap angle should return negative pi when angle is pi
        /// </summary>
        [Fact]
        public void WrapAngle_ShouldReturnNegativePi_WhenAngleIsPi()
        {
            float angle = Constant.Pi;
            float expected = Constant.Pi;
            float result = Helper.WrapAngle(angle);
            
            Assert.Equal(expected, result, 0.1f);
        }
        
        /// <summary>
        ///     Tests that hermite should calculate correctly when amount is zero
        /// </summary>
        [Fact]
        public void Hermite_ShouldCalculateCorrectly_WhenAmountIsZero()
        {
            float value1 = 1.0f;
            float tangent1 = 2.0f;
            float value2 = 3.0f;
            float tangent2 = 4.0f;
            float amount = 0.0f;
            float result = Helper.Hermite(value1, tangent1, value2, tangent2, amount);
            
            Assert.Equal(value1, result);
        }
        
        /// <summary>
        ///     Tests that hermite should calculate correctly when amount is one
        /// </summary>
        [Fact]
        public void Hermite_ShouldCalculateCorrectly_WhenAmountIsOne()
        {
            float value1 = 1.0f;
            float tangent1 = 2.0f;
            float value2 = 3.0f;
            float tangent2 = 4.0f;
            float amount = 1.0f;
            float result = Helper.Hermite(value1, tangent1, value2, tangent2, amount);
            
            Assert.Equal(value2, result);
        }
        
        /// <summary>
        ///     Tests that hermite should calculate correctly when amount is between zero and one
        /// </summary>
        [Fact]
        public void Hermite_ShouldCalculateCorrectly_WhenAmountIsBetweenZeroAndOne()
        {
            float value1 = 1.0f;
            float tangent1 = 2.0f;
            float value2 = 3.0f;
            float tangent2 = 4.0f;
            float amount = 0.5f;
            float expected = (2 * value1 - 2 * value2 + tangent2 + tangent1) * amount * amount * amount +
                             (3 * value2 - 3 * value1 - 2 * tangent1 - tangent2) * amount * amount +
                             tangent1 * amount + value1;
            float result = Helper.Hermite(value1, tangent1, value2, tangent2, amount);
            
            Assert.Equal(expected, result);
        }
    }
}