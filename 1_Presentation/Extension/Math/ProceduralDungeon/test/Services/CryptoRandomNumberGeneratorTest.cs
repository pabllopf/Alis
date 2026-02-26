// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CryptoRandomNumberGeneratorTest.cs
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
using Alis.Extension.Math.ProceduralDungeon.Services;
using Xunit;

namespace Alis.Extension.Math.ProceduralDungeon.Test.Services
{
    /// <summary>
    ///     Test class for <see cref="CryptoRandomNumberGenerator" />.
    /// </summary>
    public class CryptoRandomNumberGeneratorTest
    {
        /// <summary>
        ///     Tests that next with range should return value within range.
        /// </summary>
        [Fact]
        public void Next_WithRange_ShouldReturnValueWithinRange()
        {
            // Arrange
            using (CryptoRandomNumberGenerator rng = new CryptoRandomNumberGenerator())
            {
                int minValue = 1;
                int maxValue = 10;

                // Act
                int result = rng.Next(minValue, maxValue);

                // Assert
                Assert.InRange(result, minValue, maxValue - 1);
            }
        }

        /// <summary>
        ///     Tests that next with max value should return value within range.
        /// </summary>
        [Fact]
        public void Next_WithMaxValue_ShouldReturnValueWithinRange()
        {
            // Arrange
            using (CryptoRandomNumberGenerator rng = new CryptoRandomNumberGenerator())
            {
                int maxValue = 100;

                // Act
                int result = rng.Next(maxValue);

                // Assert
                Assert.InRange(result, 0, maxValue - 1);
            }
        }

        /// <summary>
        ///     Tests that next byte should return valid byte value.
        /// </summary>
        [Fact]
        public void NextByte_ShouldReturnValidByteValue()
        {
            // Arrange
            using (CryptoRandomNumberGenerator rng = new CryptoRandomNumberGenerator())
            {
                // Act
                byte result = rng.NextByte();

                // Assert
                Assert.InRange(result, 0, 255);
            }
        }

        /// <summary>
        ///     Tests that next should throw exception when min value is greater than or equal to max value.
        /// </summary>
        [Fact]
        public void Next_ShouldThrowException_WhenMinValueIsGreaterThanOrEqualToMaxValue()
        {
            // Arrange
            using (CryptoRandomNumberGenerator rng = new CryptoRandomNumberGenerator())
            {
                // Act & Assert
                Assert.Throws<ArgumentOutOfRangeException>(() => rng.Next(10, 10));
                Assert.Throws<ArgumentOutOfRangeException>(() => rng.Next(15, 10));
            }
        }

        /// <summary>
        ///     Tests that next should throw exception when max value is zero or negative.
        /// </summary>
        [Fact]
        public void Next_ShouldThrowException_WhenMaxValueIsZeroOrNegative()
        {
            // Arrange
            using (CryptoRandomNumberGenerator rng = new CryptoRandomNumberGenerator())
            {
                // Act & Assert
                Assert.Throws<ArgumentOutOfRangeException>(() => rng.Next(0));
                Assert.Throws<ArgumentOutOfRangeException>(() => rng.Next(-5));
            }
        }

        /// <summary>
        ///     Tests that multiple calls should return different values.
        /// </summary>
        [Fact]
        public void MultipleCalls_ShouldReturnDifferentValues()
        {
            // Arrange
            using (CryptoRandomNumberGenerator rng = new CryptoRandomNumberGenerator())
            {
                int[] values = new int[10];

                // Act
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = rng.Next(1, 1000);
                }

                // Assert - At least some values should be different
                bool hasDifferentValues = false;
                for (int i = 1; i < values.Length; i++)
                {
                    if (values[i] != values[0])
                    {
                        hasDifferentValues = true;
                        break;
                    }
                }
                Assert.True(hasDifferentValues);
            }
        }

        /// <summary>
        ///     Tests that dispose should not throw exception.
        /// </summary>
        [Fact]
        public void Dispose_ShouldNotThrowException()
        {
            // Arrange
            CryptoRandomNumberGenerator rng = new CryptoRandomNumberGenerator();

            // Act & Assert
            Exception exception = Record.Exception(() => rng.Dispose());
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that multiple dispose calls should not throw exception.
        /// </summary>
        [Fact]
        public void MultipleDisposeCalls_ShouldNotThrowException()
        {
            // Arrange
            CryptoRandomNumberGenerator rng = new CryptoRandomNumberGenerator();

            // Act & Assert
            rng.Dispose();
            Exception exception = Record.Exception(() => rng.Dispose());
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that next should work with large ranges.
        /// </summary>
        [Fact]
        public void Next_ShouldWorkWithLargeRanges()
        {
            // Arrange
            using (CryptoRandomNumberGenerator rng = new CryptoRandomNumberGenerator())
            {
                int minValue = 0;
                int maxValue = 1000000;

                // Act
                int result = rng.Next(minValue, maxValue);

                // Assert
                Assert.InRange(result, minValue, maxValue - 1);
            }
        }

        /// <summary>
        ///     Tests that next with range of one should return min value.
        /// </summary>
        [Fact]
        public void Next_WithRangeOfOne_ShouldReturnMinValue()
        {
            // Arrange
            using (CryptoRandomNumberGenerator rng = new CryptoRandomNumberGenerator())
            {
                int minValue = 5;
                int maxValue = 6;

                // Act
                int result = rng.Next(minValue, maxValue);

                // Assert
                Assert.Equal(minValue, result);
            }
        }
    }
}

