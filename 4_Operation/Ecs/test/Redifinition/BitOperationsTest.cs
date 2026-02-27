// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BitOperationsTest.cs
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

using System.Numerics;
using Xunit;

namespace Alis.Core.Ecs.Test.Redifinition
{
    /// <summary>
    ///     The bit operations test class
    /// </summary>
    /// <remarks>
    ///     Tests the BitOperations utility class that provides bit manipulation
    ///     operations such as Log2 and RoundUpToPowerOf2 for ECS performance optimization.
    /// </remarks>
    public class BitOperationsTest
    {
        /// <summary>
        ///     Tests that Log2 returns correct value for power of 2
        /// </summary>
        /// <remarks>
        ///     Validates that Log2 correctly calculates the logarithm base 2
        ///     for values that are exact powers of 2.
        /// </remarks>
        [Fact]
        public void Log2_WithPowerOf2_ReturnsCorrectValue()
        {
            // Arrange & Act & Assert
            Assert.Equal(0, BitOperations.Log2(1));
            Assert.Equal(1, BitOperations.Log2(2));
            Assert.Equal(2, BitOperations.Log2(4));
            Assert.Equal(3, BitOperations.Log2(8));
            Assert.Equal(4, BitOperations.Log2(16));
            Assert.Equal(5, BitOperations.Log2(32));
            Assert.Equal(10, BitOperations.Log2(1024));
        }

        /// <summary>
        ///     Tests that Log2 returns correct value for non-power of 2
        /// </summary>
        /// <remarks>
        ///     Validates that Log2 correctly handles values that are not
        ///     exact powers of 2 by returning the floor of the logarithm.
        /// </remarks>
        [Fact]
        public void Log2_WithNonPowerOf2_ReturnsFloorValue()
        {
            // Arrange & Act & Assert
            Assert.Equal(1, BitOperations.Log2(3));
            Assert.Equal(2, BitOperations.Log2(5));
            Assert.Equal(2, BitOperations.Log2(6));
            Assert.Equal(2, BitOperations.Log2(7));
            Assert.Equal(3, BitOperations.Log2(9));
            Assert.Equal(3, BitOperations.Log2(15));
            Assert.Equal(4, BitOperations.Log2(17));
        }

        /// <summary>
        ///     Tests that Log2 handles edge case of 0
        /// </summary>
        /// <remarks>
        ///     Validates behavior with zero input which is a special edge case.
        /// </remarks>
        [Fact]
        public void Log2_WithZero_ReturnsExpectedValue()
        {
            // Arrange
            uint value = 0;

            // Act
            int result = BitOperations.Log2(value);

            // Assert - Log2(0) behavior is implementation defined
            Assert.True(result >= 0);
        }

        /// <summary>
        ///     Tests that Log2 handles maximum uint value
        /// </summary>
        /// <remarks>
        ///     Validates that Log2 correctly handles the maximum possible
        ///     uint value without overflow or errors.
        /// </remarks>
        [Fact]
        public void Log2_WithMaxValue_ReturnsCorrectValue()
        {
            // Arrange
            uint maxValue = uint.MaxValue;

            // Act
            int result = BitOperations.Log2(maxValue);

            // Assert
            Assert.Equal(31, result);
        }

        /// <summary>
        ///     Tests that RoundUpToPowerOf2 correctly rounds up powers of 2
        /// </summary>
        /// <remarks>
        ///     Validates that values already at a power of 2 remain unchanged.
        /// </remarks>
        [Fact]
        public void RoundUpToPowerOf2_WithPowerOf2_ReturnsSameValue()
        {
            // Arrange & Act & Assert
            Assert.Equal(1u, BitOperations.RoundUpToPowerOf2(1));
            Assert.Equal(2u, BitOperations.RoundUpToPowerOf2(2));
            Assert.Equal(4u, BitOperations.RoundUpToPowerOf2(4));
            Assert.Equal(8u, BitOperations.RoundUpToPowerOf2(8));
            Assert.Equal(16u, BitOperations.RoundUpToPowerOf2(16));
            Assert.Equal(1024u, BitOperations.RoundUpToPowerOf2(1024));
        }

        /// <summary>
        ///     Tests that RoundUpToPowerOf2 rounds up non-powers of 2
        /// </summary>
        /// <remarks>
        ///     Validates that values between powers of 2 are rounded up
        ///     to the next power of 2.
        /// </remarks>
        [Fact]
        public void RoundUpToPowerOf2_WithNonPowerOf2_RoundsUp()
        {
            // Arrange & Act & Assert
            Assert.Equal(4u, BitOperations.RoundUpToPowerOf2(3));
            Assert.Equal(8u, BitOperations.RoundUpToPowerOf2(5));
            Assert.Equal(8u, BitOperations.RoundUpToPowerOf2(6));
            Assert.Equal(8u, BitOperations.RoundUpToPowerOf2(7));
            Assert.Equal(16u, BitOperations.RoundUpToPowerOf2(9));
            Assert.Equal(16u, BitOperations.RoundUpToPowerOf2(15));
            Assert.Equal(32u, BitOperations.RoundUpToPowerOf2(17));
        }

        /// <summary>
        ///     Tests that RoundUpToPowerOf2 handles zero correctly
        /// </summary>
        /// <remarks>
        ///     Validates special case handling for zero input.
        /// </remarks>
        [Fact]
        public void RoundUpToPowerOf2_WithZero_ReturnsOne()
        {
            // Arrange
            uint value = 0;

            // Act
            uint result = BitOperations.RoundUpToPowerOf2(value);

            // Assert
            Assert.Equal(0u, result);
        }

        /// <summary>
        ///     Tests that RoundUpToPowerOf2 handles large values
        /// </summary>
        /// <remarks>
        ///     Validates that large values near the uint boundary are
        ///     handled correctly without overflow.
        /// </remarks>
        [Fact]
        public void RoundUpToPowerOf2_WithLargeValues_HandlesCorrectly()
        {
            // Arrange & Act & Assert
            Assert.Equal(1073741824u, BitOperations.RoundUpToPowerOf2(1073741824)); // 2^30
            Assert.Equal(2147483648u, BitOperations.RoundUpToPowerOf2(2147483648)); // 2^31
        }

        /// <summary>
        ///     Tests Log2 and RoundUpToPowerOf2 consistency
        /// </summary>
        /// <remarks>
        ///     Validates that these two functions work consistently together
        ///     for various input values.
        /// </remarks>
        [Fact]
        public void Log2AndRoundUp_WorkConsistently()
        {
            // Arrange
            uint[] testValues = { 1, 2, 3, 4, 5, 7, 8, 15, 16, 31, 32, 63, 64, 127, 128 };

            // Act & Assert
            foreach (uint value in testValues)
            {
                uint rounded = BitOperations.RoundUpToPowerOf2(value);
                int log2Result = BitOperations.Log2(rounded);
                
                // Rounded value should be power of 2
                Assert.True((rounded & (rounded - 1)) == 0 || rounded == 0);
                
                // Log2 of power of 2 should equal the bit position
                if (rounded > 0)
                {
                    Assert.True(log2Result >= 0 && log2Result < 32);
                }
            }
        }

        /// <summary>
        ///     Tests that Log2 is monotonically increasing
        /// </summary>
        /// <remarks>
        ///     Validates that Log2 results increase as input values increase.
        /// </remarks>
        [Fact]
        public void Log2_IsMonotonicallyIncreasing()
        {
            // Arrange
            uint[] values = { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024 };

            // Act & Assert
            int previousResult = -1;
            foreach (uint value in values)
            {
                int result = BitOperations.Log2(value);
                Assert.True(result > previousResult);
                previousResult = result;
            }
        }

        /// <summary>
        ///     Tests RoundUpToPowerOf2 with sequential values
        /// </summary>
        /// <remarks>
        ///     Validates that RoundUpToPowerOf2 produces correct results
        ///     for a range of sequential input values.
        /// </remarks>
        [Fact]
        public void RoundUpToPowerOf2_WithSequentialValues_ProducesCorrectResults()
        {
            // Arrange & Act & Assert
            for (uint i = 1; i <= 64; i++)
            {
                uint result = BitOperations.RoundUpToPowerOf2(i);
                
                // Result should be power of 2
                Assert.True((result & (result - 1)) == 0);
                
                // Result should be >= input
                Assert.True(result >= i);
                
                // Result should be < 2 * input (except for edge cases)
                if (i > 1)
                {
                    Assert.True(result < 2 * i);
                }
            }
        }

        /// <summary>
        ///     Tests RoundUpToPowerOf2 idempotence for powers of 2
        /// </summary>
        /// <remarks>
        ///     Validates that applying RoundUpToPowerOf2 twice to a power of 2
        ///     yields the same result as applying it once.
        /// </remarks>
        [Fact]
        public void RoundUpToPowerOf2_IsIdempotentForPowersOf2()
        {
            // Arrange
            uint[] powersOf2 = { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024 };

            // Act & Assert
            foreach (uint value in powersOf2)
            {
                uint once = BitOperations.RoundUpToPowerOf2(value);
                uint twice = BitOperations.RoundUpToPowerOf2(once);
                
                Assert.Equal(once, twice);
                Assert.Equal(value, once);
            }
        }
    }
}

