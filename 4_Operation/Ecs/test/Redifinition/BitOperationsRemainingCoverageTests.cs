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
    ///     Unit tests for the custom System.Numerics.BitOperations implementation
    ///     provided by the Alis.Core.Ecs assembly. The custom type shares its
    ///     namespace and name with the framework type, so it is invoked through an
    ///     assembly-qualified lookup to disambiguate the two.
    /// </summary>
    public class BitOperationsRemainingCoverageTests
    {
        /// <summary>
        ///     The resolved custom BitOperations type.
        /// </summary>
        private static readonly Type BitOps = Type.GetType("System.Numerics.BitOperations, Alis.Core.Ecs");

        /// <summary>
        ///     Tests that Log2 returns the correct exponent for values.
        /// </summary>
        [Fact]
        public void Log2_VariousValues_ReturnsCorrectExponent()
        {
            Assert.Equal(0, InvokeInt("Log2", 1u));
            Assert.Equal(1, InvokeInt("Log2", 2u));
            Assert.Equal(4, InvokeInt("Log2", 16u));
            Assert.Equal(10, InvokeInt("Log2", 1024u));
            Assert.Equal(31, InvokeInt("Log2", uint.MaxValue));
            Assert.Equal(2, InvokeInt("Log2", 5u));
            Assert.Equal(3, InvokeInt("Log2", 9u));
            Assert.Equal(20, InvokeInt("Log2", (1u << 21) - 1));
        }

        /// <summary>
        ///     Tests that RoundUpToPowerOf2 returns values correctly for a range of inputs.
        /// </summary>
        [Fact]
        public void RoundUpToPowerOf2_VariousValues_RoundsCorrectly()
        {
            Assert.Equal(1u, InvokeUint("RoundUpToPowerOf2", 1u));
            Assert.Equal(2u, InvokeUint("RoundUpToPowerOf2", 2u));
            Assert.Equal(16u, InvokeUint("RoundUpToPowerOf2", 16u));
            Assert.Equal(1024u, InvokeUint("RoundUpToPowerOf2", 1024u));
            Assert.Equal(4u, InvokeUint("RoundUpToPowerOf2", 3u));
            Assert.Equal(8u, InvokeUint("RoundUpToPowerOf2", 5u));
            Assert.Equal(16u, InvokeUint("RoundUpToPowerOf2", 9u));
            Assert.Equal(1024u, InvokeUint("RoundUpToPowerOf2", 513u));
            Assert.Equal(0u, InvokeUint("RoundUpToPowerOf2", 0u));
        }

        /// <summary>
        ///     Tests that RotateLeft rotates bits correctly including wrap-around.
        /// </summary>
        [Fact]
        public void RotateLeft_VariousOffsets_RotatesCorrectly()
        {
            Assert.Equal(2u, InvokeUint("RotateLeft", 1u, 1));
            Assert.Equal(0x12345678u, InvokeUint("RotateLeft", 0x12345678u, 32));
            Assert.Equal(0x12345678u, InvokeUint("RotateLeft", 0x12345678u, 64));
            Assert.Equal(0xDEADBEEFu, InvokeUint("RotateLeft", 0xDEADBEEFu, 0));
            Assert.Equal(0x80000000u, InvokeUint("RotateLeft", 1u, 31));
        }

        /// <summary>
        ///     Invokes a method returning a uint on the custom BitOperations type.
        /// </summary>
        private static uint InvokeUint(string name, params object[] args)
        {
            return (uint) BitOps.GetMethod(name).Invoke(null, args);
        }

        /// <summary>
        ///     Invokes a method returning an int on the custom BitOperations type.
        /// </summary>
        private static int InvokeInt(string name, params object[] args)
        {
            return (int) BitOps.GetMethod(name).Invoke(null, args);
        }
    }
}
