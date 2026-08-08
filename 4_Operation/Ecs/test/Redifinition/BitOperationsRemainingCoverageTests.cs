// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BitOperationsRemainingCoverageTests.cs
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
using Xunit;

namespace Alis.Core.Ecs.Test.Redifinition
{
    /// <summary>
    ///     The bit operations remaining coverage tests class
    /// </summary>
    /// <remarks>
    ///     Invokes the project's <c>System.Numerics.BitOperations</c> replacement from the
    ///     Alis.Core.Ecs assembly via reflection, since .NET 8 also ships a
    ///     <c>System.Numerics.BitOperations</c> that would otherwise collide (CS0433).
    /// </remarks>
    public class BitOperationsRemainingCoverageTests
    {
        /// <summary>
        ///     The ecs assembly
        /// </summary>
        private static readonly Assembly EcsAssembly = typeof(Scene).Assembly;

        /// <summary>
        ///     The bit ops type
        /// </summary>
        private static readonly Type BitOpsType = EcsAssembly.GetType("System.Numerics.BitOperations")!;

        /// <summary>
        ///     The log2 method
        /// </summary>
        private static readonly MethodInfo Log2Method = BitOpsType.GetMethod("Log2")!;

        /// <summary>
        ///     The round up to power of2 method
        /// </summary>
        private static readonly MethodInfo RoundUpToPowerOf2Method = BitOpsType.GetMethod("RoundUpToPowerOf2")!;

        /// <summary>
        ///     The rotate left method
        /// </summary>
        private static readonly MethodInfo RotateLeftMethod = BitOpsType.GetMethod("RotateLeft")!;

        /// <summary>
        ///     Calls the log2 using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        private static int CallLog2(uint value) => (int) Log2Method.Invoke(null, new object[] {value})!;

        /// <summary>
        ///     Calls the round up to power of2 using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        private static uint CallRoundUpToPowerOf2(uint value) => (uint) RoundUpToPowerOf2Method.Invoke(null, new object[] {value})!;

        /// <summary>
        ///     Calls the rotate left using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="offset">The offset</param>
        /// <returns>The uint</returns>
        private static uint CallRotateLeft(uint value, int offset) => (uint) RotateLeftMethod.Invoke(null, new object[] {value, offset})!;

        /// <summary>
        ///     Tests that Log2 of one returns zero
        /// </summary>
        [Fact]
        public void Log2_OfOne_ReturnsZero() => Assert.Equal(0, CallLog2(1u));

        /// <summary>
        ///     Tests that Log2 of two returns one
        /// </summary>
        [Fact]
        public void Log2_OfTwo_ReturnsOne() => Assert.Equal(1, CallLog2(2u));

        /// <summary>
        ///     Tests that Log2 of four returns two
        /// </summary>
        [Fact]
        public void Log2_OfFour_ReturnsTwo() => Assert.Equal(2, CallLog2(4u));

        /// <summary>
        ///     Tests that Log2 of eight returns three
        /// </summary>
        [Fact]
        public void Log2_OfEight_ReturnsThree() => Assert.Equal(3, CallLog2(8u));

        /// <summary>
        ///     Tests that Log2 of sixteen returns four
        /// </summary>
        [Fact]
        public void Log2_OfSixteen_ReturnsFour() => Assert.Equal(4, CallLog2(16u));

        /// <summary>
        ///     Tests that Log2 of two hundred fifty six returns eight
        /// </summary>
        [Fact]
        public void Log2_Of256_ReturnsEight() => Assert.Equal(8, CallLog2(256u));

        /// <summary>
        ///     Tests that Log2 of one thousand twenty four returns ten
        /// </summary>
        [Fact]
        public void Log2_Of1024_ReturnsTen() => Assert.Equal(10, CallLog2(1024u));

        /// <summary>
        ///     Tests that Log2 of uint max value returns thirty one
        /// </summary>
        [Fact]
        public void Log2_OfUIntMaxValue_ReturnsThirtyOne() => Assert.Equal(31, CallLog2(uint.MaxValue));

        /// <summary>
        ///     Tests that RoundUpToPowerOf2 of one returns one
        /// </summary>
        [Fact]
        public void RoundUpToPowerOf2_OfOne_ReturnsOne() => Assert.Equal(1u, CallRoundUpToPowerOf2(1u));

        /// <summary>
        ///     Tests that RoundUpToPowerOf2 of two returns two
        /// </summary>
        [Fact]
        public void RoundUpToPowerOf2_OfTwo_ReturnsTwo() => Assert.Equal(2u, CallRoundUpToPowerOf2(2u));

        /// <summary>
        ///     Tests that RoundUpToPowerOf2 of three returns four
        /// </summary>
        [Fact]
        public void RoundUpToPowerOf2_OfThree_ReturnsFour() => Assert.Equal(4u, CallRoundUpToPowerOf2(3u));

        /// <summary>
        ///     Tests that RoundUpToPowerOf2 of five returns eight
        /// </summary>
        [Fact]
        public void RoundUpToPowerOf2_OfFive_ReturnsEight() => Assert.Equal(8u, CallRoundUpToPowerOf2(5u));

        /// <summary>
        ///     Tests that RoundUpToPowerOf2 of one hundred returns one hundred twenty eight
        /// </summary>
        [Fact]
        public void RoundUpToPowerOf2_Of100_Returns128() => Assert.Equal(128u, CallRoundUpToPowerOf2(100u));

        /// <summary>
        ///     Tests that RoundUpToPowerOf2 of one thousand twenty four returns one thousand twenty four
        /// </summary>
        [Fact]
        public void RoundUpToPowerOf2_Of1024_Returns1024() => Assert.Equal(1024u, CallRoundUpToPowerOf2(1024u));

        /// <summary>
        ///     Tests that RoundUpToPowerOf2 of zero wraps to zero
        /// </summary>
        [Fact]
        public void RoundUpToPowerOf2_OfZero_WrapsToZero() => Assert.Equal(0u, CallRoundUpToPowerOf2(0u));

        /// <summary>
        ///     Tests that RotateLeft of one by one returns two
        /// </summary>
        [Fact]
        public void RotateLeft_OfOneByOne_ReturnsTwo() => Assert.Equal(0x00000002u, CallRotateLeft(0x00000001u, 1));

        /// <summary>
        ///     Tests that RotateLeft of high bit by one returns one
        /// </summary>
        [Fact]
        public void RotateLeft_OfHighBitByOne_ReturnsOne() => Assert.Equal(0x00000001u, CallRotateLeft(0x80000000u, 1));

        /// <summary>
        ///     Tests that RotateLeft of a value by four returns the rotated value
        /// </summary>
        [Fact]
        public void RotateLeft_Of12345678By4_Returns23456781() => Assert.Equal(0x23456781u, CallRotateLeft(0x12345678u, 4));

        /// <summary>
        ///     Tests that RotateLeft of zero by eight returns zero
        /// </summary>
        [Fact]
        public void RotateLeft_OfZeroBy8_ReturnsZero() => Assert.Equal(0u, CallRotateLeft(0u, 8));
    }
}