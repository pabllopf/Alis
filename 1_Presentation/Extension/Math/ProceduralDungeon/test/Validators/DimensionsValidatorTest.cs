// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DimensionsValidatorTest.cs
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

using System;
using Alis.Extension.Math.ProceduralDungeon.Validators;
using Xunit;

namespace Alis.Extension.Math.ProceduralDungeon.Test.Validators
{
    /// <summary>
    ///     Test class for <see cref="DimensionsValidator"/>.
    /// </summary>
    public class DimensionsValidatorTest
    {
        #region ValidateDimensions Tests

        /// <summary>
        ///     Tests that validate dimensions with valid values does not throw.
        /// </summary>
        [Theory]
        [InlineData(1, 1)]
        [InlineData(10, 10)]
        [InlineData(100, 200)]
        [InlineData(int.MaxValue, int.MaxValue)]
        public void ValidateDimensions_WithValidValues_ShouldNotThrow(int width, int height)
        {
            // Act & Assert
            Exception exception = Record.Exception(() => 
                DimensionsValidator.ValidateDimensions(width, height));
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that validate dimensions with zero width throws argument exception.
        /// </summary>
        [Fact]
        public void ValidateDimensions_WithZeroWidth_ShouldThrowArgumentException()
        {
            // Act & Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() => 
                DimensionsValidator.ValidateDimensions(0, 10));
            Assert.Contains("Width must be greater than 0", ex.Message);
        }

        /// <summary>
        ///     Tests that validate dimensions with negative width throws argument exception.
        /// </summary>
        [Fact]
        public void ValidateDimensions_WithNegativeWidth_ShouldThrowArgumentException()
        {
            // Act & Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() => 
                DimensionsValidator.ValidateDimensions(-5, 10));
            Assert.Contains("Width must be greater than 0", ex.Message);
        }

        /// <summary>
        ///     Tests that validate dimensions with zero height throws argument exception.
        /// </summary>
        [Fact]
        public void ValidateDimensions_WithZeroHeight_ShouldThrowArgumentException()
        {
            // Act & Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() => 
                DimensionsValidator.ValidateDimensions(10, 0));
            Assert.Contains("Height must be greater than 0", ex.Message);
        }

        /// <summary>
        ///     Tests that validate dimensions with negative height throws argument exception.
        /// </summary>
        [Fact]
        public void ValidateDimensions_WithNegativeHeight_ShouldThrowArgumentException()
        {
            // Act & Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() => 
                DimensionsValidator.ValidateDimensions(10, -5));
            Assert.Contains("Height must be greater than 0", ex.Message);
        }

        #endregion

        #region ValidatePosition Tests

        /// <summary>
        ///     Tests that validate position with valid values does not throw.
        /// </summary>
        [Theory]
        [InlineData(0, 0)]
        [InlineData(10, 10)]
        [InlineData(100, 200)]
        [InlineData(int.MaxValue, int.MaxValue)]
        public void ValidatePosition_WithValidValues_ShouldNotThrow(int x, int y)
        {
            // Act & Assert
            Exception exception = Record.Exception(() => 
                DimensionsValidator.ValidatePosition(x, y));
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that validate position with negative x throws argument exception.
        /// </summary>
        [Fact]
        public void ValidatePosition_WithNegativeX_ShouldThrowArgumentException()
        {
            // Act & Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() => 
                DimensionsValidator.ValidatePosition(-1, 10));
            Assert.Contains("X position must be non-negative", ex.Message);
        }

        /// <summary>
        ///     Tests that validate position with negative y throws argument exception.
        /// </summary>
        [Fact]
        public void ValidatePosition_WithNegativeY_ShouldThrowArgumentException()
        {
            // Act & Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() => 
                DimensionsValidator.ValidatePosition(10, -1));
            Assert.Contains("Y position must be non-negative", ex.Message);
        }

        #endregion

        #region ValidatePositive Tests

        /// <summary>
        ///     Tests that validate positive with positive value does not throw.
        /// </summary>
        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(int.MaxValue)]
        public void ValidatePositive_WithPositiveValue_ShouldNotThrow(int value)
        {
            // Act & Assert
            Exception exception = Record.Exception(() => 
                DimensionsValidator.ValidatePositive(value, "testParam"));
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that validate positive with zero throws argument exception.
        /// </summary>
        [Fact]
        public void ValidatePositive_WithZero_ShouldThrowArgumentException()
        {
            // Act & Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() => 
                DimensionsValidator.ValidatePositive(0, "testParam"));
            Assert.Contains("testParam must be greater than 0", ex.Message);
        }

        /// <summary>
        ///     Tests that validate positive with negative value throws argument exception.
        /// </summary>
        [Fact]
        public void ValidatePositive_WithNegativeValue_ShouldThrowArgumentException()
        {
            // Act & Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() => 
                DimensionsValidator.ValidatePositive(-5, "testParam"));
            Assert.Contains("testParam must be greater than 0", ex.Message);
        }

        #endregion

        #region ValidateRange Tests

        /// <summary>
        ///     Tests that validate range with value in range does not throw.
        /// </summary>
        [Theory]
        [InlineData(5, 1, 10)]
        [InlineData(1, 1, 10)]
        [InlineData(10, 1, 10)]
        [InlineData(50, 0, 100)]
        public void ValidateRange_WithValueInRange_ShouldNotThrow(int value, int min, int max)
        {
            // Act & Assert
            Exception exception = Record.Exception(() => 
                DimensionsValidator.ValidateRange(value, min, max, "testParam"));
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that validate range with value below min throws exception.
        /// </summary>
        [Fact]
        public void ValidateRange_WithValueBelowMin_ShouldThrowArgumentOutOfRangeException()
        {
            // Act & Assert
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => 
                DimensionsValidator.ValidateRange(0, 1, 10, "testParam"));
            Assert.Contains("testParam must be between 1 and 10", ex.Message);
        }

        /// <summary>
        ///     Tests that validate range with value above max throws exception.
        /// </summary>
        [Fact]
        public void ValidateRange_WithValueAboveMax_ShouldThrowArgumentOutOfRangeException()
        {
            // Act & Assert
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => 
                DimensionsValidator.ValidateRange(11, 1, 10, "testParam"));
            Assert.Contains("testParam must be between 1 and 10", ex.Message);
        }

        #endregion

        #region ValidateWithinBounds Tests

        /// <summary>
        ///     Tests that validate within bounds with element inside board does not throw.
        /// </summary>
        [Theory]
        [InlineData(0, 0, 10, 10, 50, 50)]
        [InlineData(10, 10, 5, 5, 50, 50)]
        [InlineData(40, 40, 10, 10, 50, 50)]
        public void ValidateWithinBounds_WithElementInsideBoard_ShouldNotThrow(
            int x, int y, int width, int height, int boardWidth, int boardHeight)
        {
            // Act & Assert
            Exception exception = Record.Exception(() => 
                DimensionsValidator.ValidateWithinBounds(x, y, width, height, boardWidth, boardHeight));
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that validate within bounds with negative position throws exception.
        /// </summary>
        [Fact]
        public void ValidateWithinBounds_WithNegativePosition_ShouldThrowArgumentException()
        {
            // Act & Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() => 
                DimensionsValidator.ValidateWithinBounds(-1, 10, 5, 5, 50, 50));
            Assert.Contains("Position must be non-negative", ex.Message);
        }

        /// <summary>
        ///     Tests that validate within bounds with element exceeding width throws exception.
        /// </summary>
        [Fact]
        public void ValidateWithinBounds_WithElementExceedingWidth_ShouldThrowArgumentException()
        {
            // Act & Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() => 
                DimensionsValidator.ValidateWithinBounds(45, 10, 10, 5, 50, 50));
            Assert.Contains("Element exceeds board width", ex.Message);
        }

        /// <summary>
        ///     Tests that validate within bounds with element exceeding height throws exception.
        /// </summary>
        [Fact]
        public void ValidateWithinBounds_WithElementExceedingHeight_ShouldThrowArgumentException()
        {
            // Act & Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() => 
                DimensionsValidator.ValidateWithinBounds(10, 45, 5, 10, 50, 50));
            Assert.Contains("Element exceeds board height", ex.Message);
        }

        /// <summary>
        ///     Tests that validate within bounds with element at exact boundary does not throw.
        /// </summary>
        [Fact]
        public void ValidateWithinBounds_WithElementAtExactBoundary_ShouldNotThrow()
        {
            // Act & Assert
            Exception exception = Record.Exception(() => 
                DimensionsValidator.ValidateWithinBounds(0, 0, 50, 50, 50, 50));
            Assert.Null(exception);
        }

        #endregion
    }
}

