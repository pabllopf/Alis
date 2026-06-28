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

using System;
using System.Reflection;
using Alis.Core.Ecs;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Tests for the BitOperations utility class from Alis.Core.Ecs assembly
    ///     Note: .NET 8 has System.Numerics.BitOperations; this tests the project's replacement
    /// </summary>
    public class BitOperationsTest
    {
        // Reference to the project's BitOperations from Alis.Core.Ecs assembly
        // Note: .NET 8 has System.Numerics.BitOperations; this tests the project's replacement
        /// <summary>
        /// The assembly
        /// </summary>
        private static readonly Assembly EcsAssembly = typeof(Scene).Assembly;
        /// <summary>
        /// The get type
        /// </summary>
        private static readonly Type BitOpsType = EcsAssembly.GetType("System.Numerics.BitOperations")!;
        /// <summary>
        /// The get method
        /// </summary>
        private static readonly MethodInfo Log2Method = BitOpsType.GetMethod("Log2")!;
        /// <summary>
        /// The get method
        /// </summary>
        private static readonly MethodInfo RoundUpToPowerOf2Method = BitOpsType.GetMethod("RoundUpToPowerOf2")!;
        /// <summary>
        /// The get method
        /// </summary>
        private static readonly MethodInfo RotateLeftMethod = BitOpsType.GetMethod("RotateLeft")!;

        /// <summary>
        ///     Helper: Call Log2(uint) via reflection
        /// </summary>
        private static int CallLog2(uint value) => (int)Log2Method.Invoke(null, new object[] { value })!;

        /// <summary>
        ///     Helper: Call RoundUpToPowerOf2(uint) via reflection
        /// </summary>
        private static uint CallRoundUpToPowerOf2(uint value) => (uint)RoundUpToPowerOf2Method.Invoke(null, new object[] { value })!;

        /// <summary>
        ///     Helper: Call RotateLeft(uint, int) via reflection
        /// </summary>
        private static uint CallRotateLeft(uint value, int offset) => (uint)RotateLeftMethod.Invoke(null, new object[] { value, offset })!;

        /// <summary>
        ///     Tests Log2 returns correct values for powers of 2
        /// </summary>
        [Fact]
        public void BitOperations_Log2_WhenPowerOf2_ReturnsCorrectLog()
        {
            // Arrange & Act + Assert — test known powers of 2
            Assert.Equal(0, CallLog2(1u));       // 2^0
            Assert.Equal(1, CallLog2(2u));       // 2^1
            Assert.Equal(2, CallLog2(4u));       // 2^2
            Assert.Equal(3, CallLog2(8u));       // 2^3
            Assert.Equal(4, CallLog2(16u));      // 2^4
            Assert.Equal(5, CallLog2(32u));      // 2^5
            Assert.Equal(10, CallLog2(1024u));   // 2^10
            Assert.Equal(15, CallLog2(32768u));  // 2^15
            Assert.Equal(16, CallLog2(65536u));  // 2^16
            Assert.Equal(30, CallLog2(1U << 30)); // 2^30
            Assert.Equal(31, CallLog2(uint.MaxValue / 2 + 1)); // 2^31 (largest power of 2 in uint)
        }

        /// <summary>
        ///     Tests Log2 for non-power-of-2 values (should return floor of log2)
        /// </summary>
        [Fact]
        public void BitOperations_Log2_WhenNotPowerOf2_ReturnsFloorLog()
        {
            // Arrange & Act + Assert — non-power-of-2 values should return floor(log2)
            Assert.Equal(1, CallLog2(3u));       // floor(log2(3)) = 1
            Assert.Equal(2, CallLog2(6u));       // floor(log2(6)) = 2
            Assert.Equal(3, CallLog2(10u));      // floor(log2(10)) = 3
            Assert.Equal(4, CallLog2(20u));      // floor(log2(20)) = 4
            Assert.Equal(5, CallLog2(50u));      // floor(log2(50)) = 5
        }

        /// <summary>
        ///     Tests Log2 with maximum uint value
        /// </summary>
        [Fact]
        public void BitOperations_Log2_WhenMaxValue_Returns31()
        {
            // Act + Assert
            Assert.Equal(31, CallLog2(uint.MaxValue));
        }

        /// <summary>
        ///     Tests RoundUpToPowerOf2 with exact powers of 2
        /// </summary>
        [Fact]
        public void BitOperations_RoundUpToPowerOf2_WhenExactPowerOf2_ReturnsSameValue()
        {
            // Arrange & Act + Assert
            Assert.Equal(1u, CallRoundUpToPowerOf2(1u));
            Assert.Equal(2u, CallRoundUpToPowerOf2(2u));
            Assert.Equal(4u, CallRoundUpToPowerOf2(4u));
            Assert.Equal(8u, CallRoundUpToPowerOf2(8u));
            Assert.Equal(16u, CallRoundUpToPowerOf2(16u));
            Assert.Equal(256u, CallRoundUpToPowerOf2(256u));
            Assert.Equal(65536u, CallRoundUpToPowerOf2(65536u));
        }

        /// <summary>
        ///     Tests RoundUpToPowerOf2 with non-power-of-2 values
        /// </summary>
        [Fact]
        public void BitOperations_RoundUpToPowerOf2_WhenNotPowerOf2_ReturnsNextPower()
        {
            // Arrange & Act + Assert
            Assert.Equal(4u, CallRoundUpToPowerOf2(3u));       // 3 → 4 (standard: next power of 2)
            Assert.Equal(8u, CallRoundUpToPowerOf2(5u));       // 5 → 8
            Assert.Equal(8u, CallRoundUpToPowerOf2(7u));       // 7 → 8 (project: --7=6, spread→7, +1=8)
            Assert.Equal(128u, CallRoundUpToPowerOf2(100u));   // 100 → 128 (project: --99, spread→127, +1=128)
            Assert.Equal(16384u, CallRoundUpToPowerOf2(10000u)); // 10000 → 16384 (project: --9999, spread→16383, +1=16384)
        }

        /// <summary>
        ///     Tests RoundUpToPowerOf2 with edge case value 0
        /// </summary>
        [Fact]
        public void BitOperations_RoundUpToPowerOf2_WhenZero_Returns0()
        {
            // Act + Assert — RoundUpToPowerOf2(0) = 0 (special case: --value wraps to uint.MaxValue, bit ops propagate, +1 wraps)
            Assert.Equal(0u, CallRoundUpToPowerOf2(0u));
        }

        /// <summary>
        ///     Tests RoundUpToPowerOf2 with maximum uint value
        /// </summary>
        [Fact]
        public void BitOperations_RoundUpToPowerOf2_WhenMaxValue_Returns0()
        {
            // Act + Assert — project's implementation: --value wraps to uint.MaxValue, bit spread propagates 1s, +1 wraps → 0
            Assert.Equal(0u, CallRoundUpToPowerOf2(uint.MaxValue));
        }

        /// <summary>
        ///     Tests RotateLeft with basic rotation values
        /// </summary>
        [Fact]
        public void BitOperations_RotateLeft_WhenBasicValues_ReturnsCorrectRotation()
        {
            // Act + Assert
            Assert.Equal(2u, CallRotateLeft(1u, 1));       // 0b0001 << 1 | >> 31 = 2
            Assert.Equal(4u, CallRotateLeft(1u, 2));       // 0b0001 << 2 = 4
            Assert.Equal(8u, CallRotateLeft(1u, 3));       // 0b0001 << 3 = 8
            Assert.Equal(0x80000000u, CallRotateLeft(1u, 31)); // 1 rotated left by 31 = 2^31
        }

        /// <summary>
        ///     Tests RotateLeft with offset 0 (no rotation)
        /// </summary>
        [Fact]
        public void BitOperations_RotateLeft_WhenOffsetZero_ReturnsSameValue()
        {
            // Act + Assert — rotating by 0 should return the original value
            uint value = 0x12345678u;
            Assert.Equal(value, CallRotateLeft(value, 0));
        }

        /// <summary>
        ///     Tests RotateLeft with offset 31 (maximum rotation for uint)
        /// </summary>
        [Fact]
        public void BitOperations_RotateLeft_WhenOffset31_ReturnsCorrectRotation()
        {
            // Act + Assert
            // 0x80000001u << 31 = 0x80000000u, 0x80000001u >> 1 = 0x40000000u
            // Result: 0x80000000u | 0x40000000u = 0xC0000000u
            uint value = 0x80000001u;
            Assert.Equal(0xC0000000u, CallRotateLeft(value, 31));
        }

        /// <summary>
        ///     Tests RotateLeft with offset greater than 32 (wraps around)
        /// </summary>
        [Fact]
        public void BitOperations_RotateLeft_WhenOffsetGreaterThan32_WrapsCorrectly()
        {
            // Act + Assert — offset 33 is equivalent to offset 1 for uint
            uint value = 0x80000001u;
            Assert.Equal(CallRotateLeft(value, 1), CallRotateLeft(value, 33));
            Assert.Equal(CallRotateLeft(value, 2), CallRotateLeft(value, 34));
        }

        /// <summary>
        ///     Tests RotateLeft with various bit patterns
        /// </summary>
        [Fact]
        public void BitOperations_RotateLeft_WhenVariousPatterns_ReturnsCorrectRotation()
        {
            // Act + Assert
            // 0x80000001u << 1 = 0x00000002u, 0x80000001u >> 31 = 0x00000001u → 0x00000003u
            Assert.Equal(0x00000003u, CallRotateLeft(0x80000001u, 1));
            // 0x80000001u << 2 = 0x00000004u, 0x80000001u >> 30 = 0x00000002u → 0x00000006u
            Assert.Equal(0x00000006u, CallRotateLeft(0x80000001u, 2));
            // 0x80000001u << 31 = 0x80000000u, 0x80000001u >> 1 = 0x40000000u → 0xC0000000u
            Assert.Equal(0xC0000000u, CallRotateLeft(0x80000001u, 31));

            // Test with all bits set (rotating all-1s gives all-1s)
            Assert.Equal(uint.MaxValue, CallRotateLeft(uint.MaxValue, 5));

            // Test with alternating bits (0x55555555 = 01010101...)
            // Rotate left by 1: 01010101... << 1 = 10101010..., >> 31 = 0 → 0xAAAAAAAA
            Assert.Equal(0xAAAAAAAAu, CallRotateLeft(0x55555555u, 1));
        }

        /// <summary>
        ///     Tests that the project's BitOperations type is successfully resolved from Alis.Core.Ecs
        /// </summary>
        [Fact]
        public void BitOperations_TypeResolution_Succeeds()
        {
            // Act + Assert — verify the type exists in Alis.Core.Ecs assembly
            Assert.NotNull(BitOpsType);
            Assert.Equal("System.Numerics.BitOperations", BitOpsType.FullName);
            Assert.Equal(EcsAssembly, BitOpsType.Assembly);
        }
    }
}
