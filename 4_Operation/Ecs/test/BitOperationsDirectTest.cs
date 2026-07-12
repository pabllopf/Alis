// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BitOperationsDirectTest.cs
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

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Direct tests for the project's BitOperations class without reflection.
    /// </summary>
    public class BitOperationsDirectTest
    {
        /// <summary>
        ///     Tests Log2 returns correct values for powers of 2.
        /// </summary>
        [Fact]
        public void Log2_WhenPowerOf2_ReturnsCorrectLog()
        {
            Assert.Equal(0, BitOperations.Log2(1u));
            Assert.Equal(1, BitOperations.Log2(2u));
            Assert.Equal(2, BitOperations.Log2(4u));
            Assert.Equal(3, BitOperations.Log2(8u));
            Assert.Equal(4, BitOperations.Log2(16u));
            Assert.Equal(10, BitOperations.Log2(1024u));
            Assert.Equal(16, BitOperations.Log2(65536u));
            Assert.Equal(31, BitOperations.Log2(uint.MaxValue / 2 + 1));
        }

        /// <summary>
        ///     Tests Log2 for non-power-of-2 values (floor of log2).
        /// </summary>
        [Fact]
        public void Log2_WhenNotPowerOf2_ReturnsFloorLog()
        {
            Assert.Equal(1, BitOperations.Log2(3u));
            Assert.Equal(2, BitOperations.Log2(6u));
            Assert.Equal(3, BitOperations.Log2(10u));
            Assert.Equal(4, BitOperations.Log2(20u));
            Assert.Equal(5, BitOperations.Log2(50u));
        }

        /// <summary>
        ///     Tests Log2 with maximum uint value.
        /// </summary>
        [Fact]
        public void Log2_WhenMaxValue_Returns31()
        {
            Assert.Equal(31, BitOperations.Log2(uint.MaxValue));
        }

        /// <summary>
        ///     Tests Log2 with value 0 results in 0.
        /// </summary>
        [Fact]
        public void Log2_WhenZero_Returns0()
        {
            Assert.Equal(0, BitOperations.Log2(0u));
        }

        /// <summary>
        ///     Tests Log2 with value 1.
        /// </summary>
        [Fact]
        public void Log2_WhenOne_Returns0()
        {
            Assert.Equal(0, BitOperations.Log2(1u));
        }

        /// <summary>
        ///     Tests RoundUpToPowerOf2 with exact powers of 2.
        /// </summary>
        [Fact]
        public void RoundUpToPowerOf2_WhenExactPowerOf2_ReturnsSameValue()
        {
            Assert.Equal(1u, BitOperations.RoundUpToPowerOf2(1u));
            Assert.Equal(2u, BitOperations.RoundUpToPowerOf2(2u));
            Assert.Equal(4u, BitOperations.RoundUpToPowerOf2(4u));
            Assert.Equal(8u, BitOperations.RoundUpToPowerOf2(8u));
            Assert.Equal(16u, BitOperations.RoundUpToPowerOf2(16u));
            Assert.Equal(256u, BitOperations.RoundUpToPowerOf2(256u));
            Assert.Equal(65536u, BitOperations.RoundUpToPowerOf2(65536u));
        }

        /// <summary>
        ///     Tests RoundUpToPowerOf2 with non-power-of-2 values.
        /// </summary>
        [Fact]
        public void RoundUpToPowerOf2_WhenNotPowerOf2_ReturnsNextPower()
        {
            Assert.Equal(4u, BitOperations.RoundUpToPowerOf2(3u));
            Assert.Equal(8u, BitOperations.RoundUpToPowerOf2(5u));
            Assert.Equal(8u, BitOperations.RoundUpToPowerOf2(7u));
            Assert.Equal(128u, BitOperations.RoundUpToPowerOf2(100u));
            Assert.Equal(16384u, BitOperations.RoundUpToPowerOf2(10000u));
        }

        /// <summary>
        ///     Tests RoundUpToPowerOf2 with edge case value 0.
        /// </summary>
        [Fact]
        public void RoundUpToPowerOf2_WhenZero_Returns0()
        {
            Assert.Equal(0u, BitOperations.RoundUpToPowerOf2(0u));
        }

        /// <summary>
        ///     Tests RoundUpToPowerOf2 with maximum uint value.
        /// </summary>
        [Fact]
        public void RoundUpToPowerOf2_WhenMaxValue_Returns0()
        {
            Assert.Equal(0u, BitOperations.RoundUpToPowerOf2(uint.MaxValue));
        }

        /// <summary>
        ///     Tests RotateLeft with basic values.
        /// </summary>
        [Fact]
        public void RotateLeft_WhenBasicValues_ReturnsCorrectRotation()
        {
            Assert.Equal(2u, BitOperations.RotateLeft(1u, 1));
            Assert.Equal(4u, BitOperations.RotateLeft(1u, 2));
            Assert.Equal(8u, BitOperations.RotateLeft(1u, 3));
            Assert.Equal(0x80000000u, BitOperations.RotateLeft(1u, 31));
        }

        /// <summary>
        ///     Tests RotateLeft with offset 0 returns same value.
        /// </summary>
        [Fact]
        public void RotateLeft_WhenOffsetZero_ReturnsSameValue()
        {
            Assert.Equal(0x12345678u, BitOperations.RotateLeft(0x12345678u, 0));
        }

        /// <summary>
        ///     Tests RotateLeft with offset greater than 32 wraps correctly.
        /// </summary>
        [Fact]
        public void RotateLeft_WhenOffsetGreaterThan32_WrapsCorrectly()
        {
            Assert.Equal(BitOperations.RotateLeft(0x80000001u, 1), BitOperations.RotateLeft(0x80000001u, 33));
            Assert.Equal(BitOperations.RotateLeft(0x80000001u, 2), BitOperations.RotateLeft(0x80000001u, 34));
        }

        /// <summary>
        ///     Tests RotateLeft with various bit patterns.
        /// </summary>
        [Fact]
        public void RotateLeft_WhenVariousPatterns_ReturnsCorrectRotation()
        {
            Assert.Equal(0x00000003u, BitOperations.RotateLeft(0x80000001u, 1));
            Assert.Equal(0xC0000000u, BitOperations.RotateLeft(0x80000001u, 31));
            Assert.Equal(uint.MaxValue, BitOperations.RotateLeft(uint.MaxValue, 5));
            Assert.Equal(0xAAAAAAAAu, BitOperations.RotateLeft(0x55555555u, 1));
        }
    }
}
