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

extern alias ecs;
using Xunit;

namespace Alis.Core.Ecs.Test.Redifinition
{
    /// <summary>
    ///     Tests the <see cref="ecs:System.Numerics.BitOperations" /> class, covering all public static methods
    ///     including edge cases, boundary conditions, and corner values.
    /// </summary>
    public class BitOperationsTest
    {
        /// <summary>
        ///     Tests that <see cref="ecs:System.Numerics.BitOperations.Log2" /> returns the correct floor logarithm base 2
        ///     for various known values including powers of two and values between them.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <param name="expected">The expected base-2 logarithm.</param>
        [Theory]
        [InlineData(0u, 0)]
        [InlineData(1u, 0)]
        [InlineData(2u, 1)]
        [InlineData(3u, 1)]
        [InlineData(4u, 2)]
        [InlineData(7u, 2)]
        [InlineData(8u, 3)]
        [InlineData(15u, 3)]
        [InlineData(16u, 4)]
        [InlineData(31u, 4)]
        [InlineData(32u, 5)]
        [InlineData(63u, 5)]
        [InlineData(64u, 6)]
        [InlineData(127u, 6)]
        [InlineData(128u, 7)]
        [InlineData(255u, 7)]
        [InlineData(256u, 8)]
        [InlineData(511u, 8)]
        [InlineData(512u, 9)]
        [InlineData(1023u, 9)]
        [InlineData(1024u, 10)]
        [InlineData(2047u, 10)]
        [InlineData(2048u, 11)]
        [InlineData(4095u, 11)]
        [InlineData(4096u, 12)]
        [InlineData(8191u, 12)]
        [InlineData(8192u, 13)]
        [InlineData(16383u, 13)]
        [InlineData(16384u, 14)]
        [InlineData(32767u, 14)]
        [InlineData(32768u, 15)]
        [InlineData(65535u, 15)]
        [InlineData(65536u, 16)]
        [InlineData(131071u, 16)]
        [InlineData(262144u, 18)]
        [InlineData(524288u, 19)]
        [InlineData(1048576u, 20)]
        [InlineData(2097152u, 21)]
        [InlineData(4194304u, 22)]
        [InlineData(8388608u, 23)]
        [InlineData(16777216u, 24)]
        [InlineData(33554432u, 25)]
        [InlineData(67108864u, 26)]
        [InlineData(134217728u, 27)]
        [InlineData(268435456u, 28)]
        [InlineData(536870912u, 29)]
        [InlineData(1073741824u, 30)]
        [InlineData(2147483648u, 31)]
        [InlineData(uint.MaxValue, 31)]
        public void Log2_WithVariousValues_ReturnsFloorLog2(uint value, int expected)
        {
            int result = ecs::System.Numerics.BitOperations.Log2(value);

            Assert.Equal(expected, result);
        }

        /// <summary>
        ///     Tests that <see cref="ecs:System.Numerics.BitOperations.RoundUpToPowerOf2" /> returns the smallest
        ///     power of two greater than or equal to the input value.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <param name="expected">The expected power of two.</param>
        [Theory]
        [InlineData(0u, 0u)]
        [InlineData(1u, 1u)]
        [InlineData(2u, 2u)]
        [InlineData(3u, 4u)]
        [InlineData(4u, 4u)]
        [InlineData(5u, 8u)]
        [InlineData(6u, 8u)]
        [InlineData(7u, 8u)]
        [InlineData(8u, 8u)]
        [InlineData(9u, 16u)]
        [InlineData(15u, 16u)]
        [InlineData(16u, 16u)]
        [InlineData(17u, 32u)]
        [InlineData(31u, 32u)]
        [InlineData(32u, 32u)]
        [InlineData(33u, 64u)]
        [InlineData(63u, 64u)]
        [InlineData(64u, 64u)]
        [InlineData(65u, 128u)]
        [InlineData(127u, 128u)]
        [InlineData(128u, 128u)]
        [InlineData(129u, 256u)]
        [InlineData(255u, 256u)]
        [InlineData(256u, 256u)]
        [InlineData(1000u, 1024u)]
        [InlineData(1024u, 1024u)]
        [InlineData(4095u, 4096u)]
        [InlineData(4096u, 4096u)]
        [InlineData(1073741825u, 2147483648u)]
        public void RoundUpToPowerOf2_WithVariousValues_ReturnsNextPowerOfTwo(uint value, uint expected)
        {
            uint result = ecs::System.Numerics.BitOperations.RoundUpToPowerOf2(value);

            Assert.Equal(expected, result);
        }

        /// <summary>
        ///     Tests that <see cref="ecs:System.Numerics.BitOperations.RotateLeft" /> correctly rotates bits
        ///     left by the specified offset for various values and offsets.
        /// </summary>
        /// <param name="value">The value to rotate.</param>
        /// <param name="offset">The number of bits to rotate by.</param>
        /// <param name="expected">The expected rotated value.</param>
        [Theory]
        [InlineData(1u, 0, 1u)]
        [InlineData(1u, 1, 2u)]
        [InlineData(1u, 2, 4u)]
        [InlineData(1u, 3, 8u)]
        [InlineData(1u, 31, 2147483648u)]
        [InlineData(2147483648u, 1, 1u)]
        [InlineData(0x12345678u, 4, 0x23456781u)]
        [InlineData(0x12345678u, 8, 0x34567812u)]
        [InlineData(0x12345678u, 16, 0x56781234u)]
        [InlineData(0x12345678u, 24, 0x78123456u)]
        [InlineData(uint.MaxValue, 1, uint.MaxValue)]
        [InlineData(uint.MaxValue, 16, uint.MaxValue)]
        [InlineData(uint.MaxValue, 31, uint.MaxValue)]
        [InlineData(0x80000000u, 31, 0x40000000u)]
        [InlineData(0x00000001u, 32, 1u)]
        [InlineData(0xAAAAAAAAu, 1, 0x55555555u)]
        [InlineData(0x55555555u, 1, 0xAAAAAAAAu)]
        public void RotateLeft_WithVariousValues_ReturnsRotatedValue(uint value, int offset, uint expected)
        {
            uint result = ecs::System.Numerics.BitOperations.RotateLeft(value, offset);

            Assert.Equal(expected, result);
        }

        /// <summary>
        ///     Tests that <see cref="ecs:System.Numerics.BitOperations.Log2" /> handles all exact powers of two
        ///     from 2^0 through 2^31.
        /// </summary>
        [Fact]
        public void Log2_WithAllPowersOfTwo_ReturnsCorrectExponent()
        {
            for (int i = 0; i < 32; i++)
            {
                uint value = 1u << i;

                int result = ecs::System.Numerics.BitOperations.Log2(value);

                Assert.Equal(i, result);
            }
        }

        /// <summary>
        ///     Tests that <see cref="ecs:System.Numerics.BitOperations.RoundUpToPowerOf2" /> returns the same value
        ///     for exact powers of two.
        /// </summary>
        [Fact]
        public void RoundUpToPowerOf2_WithExactPowersOfTwo_ReturnsSameValue()
        {
            for (int i = 0; i < 31; i++)
            {
                uint value = 1u << i;

                uint result = ecs::System.Numerics.BitOperations.RoundUpToPowerOf2(value);

                Assert.Equal(value, result);
            }
        }

        /// <summary>
        ///     Tests that <see cref="ecs:System.Numerics.BitOperations.RotateLeft" /> with a full 32-bit rotation
        ///     (offset = 32) returns the original value.
        /// </summary>
        [Fact]
        public void RotateLeft_WithFullRotation_ReturnsOriginalValue()
        {
            uint value = 0x12345678u;

            uint result = ecs::System.Numerics.BitOperations.RotateLeft(value, 32);

            Assert.Equal(value, result);
        }

        /// <summary>
        ///     Tests that <see cref="ecs:System.Numerics.BitOperations.RotateLeft" /> with offset 0 returns
        ///     the original value unchanged.
        /// </summary>
        [Fact]
        public void RotateLeft_WithZeroOffset_ReturnsOriginalValue()
        {
            uint result = ecs::System.Numerics.BitOperations.RotateLeft(0xDEADBEEFu, 0);

            Assert.Equal(0xDEADBEEFu, result);
        }

        /// <summary>
        ///     Tests that <see cref="ecs:System.Numerics.BitOperations.Log2" /> and <see cref="ecs:System.Numerics.BitOperations.RoundUpToPowerOf2" />
        ///     are consistent: RoundUpToPowerOf2(x).Log2 = Ceiling(Log2(x)).
        /// </summary>
        [Fact]
        public void Log2AndRoundUpToPowerOf2_AreConsistent()
        {
            for (uint value = 1; value < 1_000_000; value += 7)
            {
                int log2 = ecs::System.Numerics.BitOperations.Log2(value);
                uint rounded = ecs::System.Numerics.BitOperations.RoundUpToPowerOf2(value);

                int roundedLog2 = ecs::System.Numerics.BitOperations.Log2(rounded);

                Assert.True(roundedLog2 == log2 || roundedLog2 == log2 + 1,
                    $"Inconsistency for value={value}: Log2={log2}, Rounded={rounded}, RoundedLog2={roundedLog2}");
            }
        }
    }
}
