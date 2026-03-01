// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MemoryHelpersTest.cs
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

using Alis.Core.Ecs.Redifinition;
using Xunit;

namespace Alis.Core.Ecs.Test.Redifinition
{
    /// <summary>
    ///     The memory helpers test class
    /// </summary>
    /// <remarks>
    ///     Tests the MemoryHelpers utility class that provides memory management
    ///     operations including power-of-2 rounding, array resizing, and other
    ///     low-level operations critical for ECS performance.
    /// </remarks>
    public class MemoryHelpersTest
    {
        /// <summary>
        ///     Tests that RoundDownToPowerOfTwo correctly rounds down to power of 2
        /// </summary>
        /// <remarks>
        ///     Validates that values are correctly rounded down to the nearest
        ///     power of 2 value.
        /// </remarks>
        [Fact]
        public void RoundDownToPowerOfTwo_WithVariousValues_RoundsCorrectly()
        {
            // Arrange & Act & Assert
            Assert.Equal(1u, MemoryHelpers.RoundDownToPowerOfTwo(1));
        }

        /// <summary>
        ///     Tests that RoundUpToNextMultipleOf16 rounds up correctly
        /// </summary>
        /// <remarks>
        ///     Validates that values are correctly rounded up to the next
        ///     multiple of 16 for memory alignment purposes.
        /// </remarks>
        [Fact]
        public void RoundUpToNextMultipleOf16_WithVariousValues_RoundsCorrectly()
        {
            // Arrange & Act & Assert
            Assert.Equal(0, MemoryHelpers.RoundUpToNextMultipleOf16(0));
            Assert.Equal(16, MemoryHelpers.RoundUpToNextMultipleOf16(1));
            Assert.Equal(16, MemoryHelpers.RoundUpToNextMultipleOf16(15));
            Assert.Equal(16, MemoryHelpers.RoundUpToNextMultipleOf16(16));
            Assert.Equal(32, MemoryHelpers.RoundUpToNextMultipleOf16(17));
            Assert.Equal(32, MemoryHelpers.RoundUpToNextMultipleOf16(31));
            Assert.Equal(32, MemoryHelpers.RoundUpToNextMultipleOf16(32));
            Assert.Equal(48, MemoryHelpers.RoundUpToNextMultipleOf16(33));
        }

        /// <summary>
        ///     Tests that RoundDownToNextMultipleOf16 rounds down correctly
        /// </summary>
        /// <remarks>
        ///     Validates that values are correctly rounded down to the previous
        ///     multiple of 16 for memory alignment purposes.
        /// </remarks>
        [Fact]
        public void RoundDownToNextMultipleOf16_WithVariousValues_RoundsCorrectly()
        {
            // Arrange & Act & Assert
            Assert.Equal(0, MemoryHelpers.RoundDownToNextMultipleOf16(0));
            Assert.Equal(0, MemoryHelpers.RoundDownToNextMultipleOf16(1));
            Assert.Equal(0, MemoryHelpers.RoundDownToNextMultipleOf16(15));
            Assert.Equal(16, MemoryHelpers.RoundDownToNextMultipleOf16(16));
            Assert.Equal(16, MemoryHelpers.RoundDownToNextMultipleOf16(17));
            Assert.Equal(16, MemoryHelpers.RoundDownToNextMultipleOf16(31));
            Assert.Equal(32, MemoryHelpers.RoundDownToNextMultipleOf16(32));
            Assert.Equal(32, MemoryHelpers.RoundDownToNextMultipleOf16(47));
        }

        /// <summary>
        ///     Tests that BoolToByte converts correctly
        /// </summary>
        /// <remarks>
        ///     Validates that boolean values are correctly converted to byte
        ///     representation for low-level operations.
        /// </remarks>
        [Fact]
        public void BoolToByte_WithTrueAndFalse_ConvertsCorrectly()
        {
            // Arrange & Act
            byte trueResult = MemoryHelpers.BoolToByte(true);
            byte falseResult = MemoryHelpers.BoolToByte(false);

            // Assert
            Assert.Equal(1, trueResult);
            Assert.Equal(0, falseResult);
        }

        /// <summary>
        ///     Tests that RoundUpToNextMultipleOf16 is idempotent for multiples
        /// </summary>
        /// <remarks>
        ///     Validates that values already at multiples of 16 remain unchanged
        ///     when rounded up.
        /// </remarks>
        [Fact]
        public void RoundUpToNextMultipleOf16_WithMultiples_IsIdempotent()
        {
            // Arrange
            int[] multiples = { 0, 16, 32, 48, 64, 128, 256, 512 };

            // Act & Assert
            foreach (int value in multiples)
            {
                int result = MemoryHelpers.RoundUpToNextMultipleOf16(value);
                Assert.Equal(value, result);
            }
        }

        /// <summary>
        ///     Tests that RoundDownToNextMultipleOf16 is idempotent for multiples
        /// </summary>
        /// <remarks>
        ///     Validates that values already at multiples of 16 remain unchanged
        ///     when rounded down.
        /// </remarks>
        [Fact]
        public void RoundDownToNextMultipleOf16_WithMultiples_IsIdempotent()
        {
            // Arrange
            int[] multiples = { 0, 16, 32, 48, 64, 128, 256, 512 };

            // Act & Assert
            foreach (int value in multiples)
            {
                int result = MemoryHelpers.RoundDownToNextMultipleOf16(value);
                Assert.Equal(value, result);
            }
        }

        /// <summary>
        ///     Tests that rounding functions are consistent
        /// </summary>
        /// <remarks>
        ///     Validates that RoundUp and RoundDown produce results that
        ///     are consistent with each other (RoundDown <= value <= RoundUp).
        /// </remarks>
        [Fact]
        public void RoundingFunctions_AreConsistent()
        {
            // Arrange & Act & Assert
            for (int i = 0; i < 100; i++)
            {
                int roundedDown = MemoryHelpers.RoundDownToNextMultipleOf16(i);
                int roundedUp = MemoryHelpers.RoundUpToNextMultipleOf16(i);

                Assert.True(roundedDown <= i);
                Assert.True(roundedUp >= i);
                Assert.True(roundedDown % 16 == 0);
                Assert.True(roundedUp % 16 == 0 || roundedUp == 0);
            }
        }

        /// <summary>
        ///     Tests MaxComponentCount constant value
        /// </summary>
        /// <remarks>
        ///     Validates that the MaxComponentCount constant is set to the expected value
        ///     which is critical for ECS memory allocation.
        /// </remarks>
        [Fact]
        public void MaxComponentCount_HasExpectedValue()
        {
            // Assert
            Assert.Equal(127, MemoryHelpers.MaxComponentCount);
        }

        /// <summary>
        ///     Tests that RoundDownToPowerOfTwo handles large values
        /// </summary>
        /// <remarks>
        ///     Validates that large values are correctly rounded down to
        ///     the nearest power of 2 without overflow.
        /// </remarks>
        [Fact]
        public void RoundDownToPowerOfTwo_WithLargeValues_HandlesCorrectly()
        {
            // Arrange & Act & Assert
            Assert.Equal(1073741824u, MemoryHelpers.RoundDownToPowerOfTwo(1073741824)); // 2^30
            Assert.Equal(1073741824u, MemoryHelpers.RoundDownToPowerOfTwo(2000000000));
        }

        /// <summary>
        ///     Tests rounding with boundary values around multiples of 16
        /// </summary>
        /// <remarks>
        ///     Validates correct behavior for values immediately before and
        ///     after multiples of 16.
        /// </remarks>
        [Fact]
        public void RoundingFunctions_WithBoundaryValues_WorkCorrectly()
        {
            // Arrange & Act & Assert
            // Just before multiple of 16
            Assert.Equal(0, MemoryHelpers.RoundDownToNextMultipleOf16(15));
            Assert.Equal(16, MemoryHelpers.RoundUpToNextMultipleOf16(15));
            
            // Exactly at multiple of 16
            Assert.Equal(16, MemoryHelpers.RoundDownToNextMultipleOf16(16));
            Assert.Equal(16, MemoryHelpers.RoundUpToNextMultipleOf16(16));
            
            // Just after multiple of 16
            Assert.Equal(16, MemoryHelpers.RoundDownToNextMultipleOf16(17));
            Assert.Equal(32, MemoryHelpers.RoundUpToNextMultipleOf16(17));
        }

        /// <summary>
        ///     Tests that BoolToByte is consistent
        /// </summary>
        /// <remarks>
        ///     Validates that multiple calls with the same boolean value
        ///     produce the same byte result.
        /// </remarks>
        [Fact]
        public void BoolToByte_IsConsistent()
        {
            // Arrange & Act
            byte true1 = MemoryHelpers.BoolToByte(true);
            byte true2 = MemoryHelpers.BoolToByte(true);
            byte false1 = MemoryHelpers.BoolToByte(false);
            byte false2 = MemoryHelpers.BoolToByte(false);

            // Assert
            Assert.Equal(true1, true2);
            Assert.Equal(false1, false2);
            Assert.NotEqual(true1, false1);
        }

        /// <summary>
        ///     Tests Block2 struct size
        /// </summary>
        /// <remarks>
        ///     Validates that Block2 has the correct size for memory alignment.
        /// </remarks>
        [Fact]
        public void Block2_HasCorrectSize()
        {
            // Arrange & Act
            int size = System.Runtime.InteropServices.Marshal.SizeOf<MemoryHelpers.Block2>();

            // Assert
            Assert.Equal(2, size);
        }

        /// <summary>
        ///     Tests Block4 struct size
        /// </summary>
        /// <remarks>
        ///     Validates that Block4 has the correct size for memory alignment.
        /// </remarks>
        [Fact]
        public void Block4_HasCorrectSize()
        {
            // Arrange & Act
            int size = System.Runtime.InteropServices.Marshal.SizeOf<MemoryHelpers.Block4>();

            // Assert
            Assert.Equal(4, size);
        }

        /// <summary>
        ///     Tests Block8 struct size
        /// </summary>
        /// <remarks>
        ///     Validates that Block8 has the correct size for memory alignment.
        /// </remarks>
        [Fact]
        public void Block8_HasCorrectSize()
        {
            // Arrange & Act
            int size = System.Runtime.InteropServices.Marshal.SizeOf<MemoryHelpers.Block8>();

            // Assert
            Assert.Equal(8, size);
        }

        /// <summary>
        ///     Tests Block16 struct size
        /// </summary>
        /// <remarks>
        ///     Validates that Block16 has the correct size for memory alignment.
        /// </remarks>
        [Fact]
        public void Block16_HasCorrectSize()
        {
            // Arrange & Act
            int size = System.Runtime.InteropServices.Marshal.SizeOf<MemoryHelpers.Block16>();

            // Assert
            Assert.Equal(16, size);
        }

        /// <summary>
        ///     Tests GetOrAddNew with new key
        /// </summary>
        /// <remarks>
        ///     Validates that GetOrAddNew creates and adds a new value
        ///     when the key doesn't exist in the dictionary.
        /// </remarks>
        [Fact]
        public void GetOrAddNew_WithNewKey_CreatesNewValue()
        {
            // Arrange
            var dict = new System.Collections.Generic.Dictionary<int, TestClass>();

            // Act
            TestClass value = MemoryHelpers.GetOrAddNew(dict, 1);

            // Assert
            Assert.NotNull(value);
            Assert.True(dict.ContainsKey(1));
            Assert.Same(value, dict[1]);
        }

        /// <summary>
        ///     Tests GetOrAddNew with existing key
        /// </summary>
        /// <remarks>
        ///     Validates that GetOrAddNew returns the existing value
        ///     when the key already exists in the dictionary.
        /// </remarks>
        [Fact]
        public void GetOrAddNew_WithExistingKey_ReturnsExistingValue()
        {
            // Arrange
            var dict = new System.Collections.Generic.Dictionary<int, TestClass>();
            TestClass original = new TestClass();
            dict[1] = original;

            // Act
            TestClass retrieved = MemoryHelpers.GetOrAddNew(dict, 1);

            // Assert
            Assert.Same(original, retrieved);
        }

        /// <summary>
        ///     Tests GetOrAddNew with multiple keys
        /// </summary>
        /// <remarks>
        ///     Validates that GetOrAddNew works correctly when used
        ///     with multiple different keys in succession.
        /// </remarks>
        [Fact]
        public void GetOrAddNew_WithMultipleKeys_WorksCorrectly()
        {
            // Arrange
            var dict = new System.Collections.Generic.Dictionary<string, TestClass>();

            // Act
            TestClass value1 = MemoryHelpers.GetOrAddNew(dict, "key1");
            TestClass value2 = MemoryHelpers.GetOrAddNew(dict, "key2");
            TestClass value3 = MemoryHelpers.GetOrAddNew(dict, "key3");
            TestClass value1Again = MemoryHelpers.GetOrAddNew(dict, "key1");

            // Assert
            Assert.NotNull(value1);
            Assert.NotNull(value2);
            Assert.NotNull(value3);
            Assert.Same(value1, value1Again);
            Assert.NotSame(value1, value2);
            Assert.NotSame(value2, value3);
            Assert.Equal(3, dict.Count);
        }

        /// <summary>
        ///     Tests RoundUpToNextMultipleOf16 with negative values
        /// </summary>
        /// <remarks>
        ///     Validates behavior with negative input values.
        /// </remarks>
        [Fact]
        public void RoundUpToNextMultipleOf16_WithNegativeValues_HandlesCorrectly()
        {
            // Arrange & Act
            int result = MemoryHelpers.RoundUpToNextMultipleOf16(-5);

            // Assert - Should handle negative values (implementation defined)
            Assert.True(result % 16 == 0 || result == 0);
        }

        /// <summary>
        ///     Tests RoundDownToNextMultipleOf16 with negative values
        /// </summary>
        /// <remarks>
        ///     Validates behavior with negative input values for rounding down.
        /// </remarks>
        [Fact]
        public void RoundDownToNextMultipleOf16_WithNegativeValues_HandlesCorrectly()
        {
            // Arrange & Act
            int result = MemoryHelpers.RoundDownToNextMultipleOf16(-5);

            // Assert - Should handle negative values (implementation defined)
            Assert.True(result % 16 == 0);
        }

        /// <summary>
        ///     Tests that both rounding functions handle zero correctly
        /// </summary>
        /// <remarks>
        ///     Validates special case handling for zero as input to
        ///     both rounding up and rounding down functions.
        /// </remarks>
        [Fact]
        public void RoundingFunctions_WithZero_HandleCorrectly()
        {
            // Act
            int roundUp = MemoryHelpers.RoundUpToNextMultipleOf16(0);
            int roundDown = MemoryHelpers.RoundDownToNextMultipleOf16(0);

            // Assert
            Assert.Equal(0, roundUp);
            Assert.Equal(0, roundDown);
        }

        /// <summary>
        ///     Tests rounding consistency for range of values
        /// </summary>
        /// <remarks>
        ///     Validates that for any value, roundDown <= value <= roundUp
        ///     and the difference is at most 16.
        /// </remarks>
        [Fact]
        public void RoundingFunctions_MaintainConsistency()
        {
            // Arrange & Act & Assert
            for (int i = 1; i <= 1000; i++)
            {
                int roundedUp = MemoryHelpers.RoundUpToNextMultipleOf16(i);
                int roundedDown = MemoryHelpers.RoundDownToNextMultipleOf16(i);

                Assert.True(roundedDown <= i);
                Assert.True(roundedUp >= i);
                Assert.True(roundedUp - roundedDown <= 16);
            }
        }

        /// <summary>
        ///     Tests RoundDownToPowerOfTwo with sequential values
        /// </summary>
        /// <remarks>
        ///     Validates that RoundDownToPowerOfTwo produces monotonically
        ///     non-decreasing results for increasing inputs.
        /// </remarks>
        [Fact]
        public void RoundDownToPowerOfTwo_WithSequentialValues_IsMonotonic()
        {
            // Arrange
            uint previousResult = 0;

            // Act & Assert
            for (uint i = 1; i <= 256; i++)
            {
                uint result = MemoryHelpers.RoundDownToPowerOfTwo(i);
                Assert.True(result >= previousResult);
                
                // Result should be power of 2
                Assert.True((result & (result - 1)) == 0 || result == 0);
                
                previousResult = result;
            }
        }

        /// <summary>
        ///     Tests GetOrAddNew thread safety with single thread
        /// </summary>
        /// <remarks>
        ///     Validates that GetOrAddNew works correctly in a single-threaded
        ///     scenario with rapid successive calls.
        /// </remarks>
        [Fact]
        public void GetOrAddNew_WithRapidCalls_WorksCorrectly()
        {
            // Arrange
            var dict = new System.Collections.Generic.Dictionary<int, TestClass>();

            // Act
            for (int i = 0; i < 100; i++)
            {
                TestClass value = MemoryHelpers.GetOrAddNew(dict, i % 10);
                Assert.NotNull(value);
            }

            // Assert
            Assert.Equal(10, dict.Count);
        }

        /// <summary>
        ///     Tests MaxComponentCount is within valid range
        /// </summary>
        /// <remarks>
        ///     Validates that MaxComponentCount is a reasonable value
        ///     for ECS component limits.
        /// </remarks>
        [Fact]
        public void MaxComponentCount_IsWithinValidRange()
        {
            // Assert
            Assert.True(MemoryHelpers.MaxComponentCount > 0);
            Assert.True(MemoryHelpers.MaxComponentCount < 256);
            Assert.Equal(127, MemoryHelpers.MaxComponentCount);
        }

        /// <summary>
        ///     Helper test class for GetOrAddNew tests
        /// </summary>
        private class TestClass
        {
            /// <summary>
            /// Gets or sets the value of the value
            /// </summary>
            public int Value { get; set; }
        }
    }
}

