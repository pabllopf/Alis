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
        ///     The custom System.Numerics.BitOperations type shipped by the Alis.Core.Ecs assembly
        /// </summary>
        private static readonly Type EcsBitOperationsType = typeof(GameObject).Assembly.GetType("System.Numerics.BitOperations");

        /// <summary>
        ///     Gets the custom BitOperations static method by name
        /// </summary>
        private static MethodInfo GetEcsMethod(string name, params Type[] parameters) => EcsBitOperationsType.GetMethod(name, parameters);

        /// <summary>
        ///     Tests that Log2 returns the zero-based position of the highest set bit
        /// </summary>
        [Fact]
        public void Log2_ReturnsHighestSetBitPosition()
        {
            MethodInfo log2 = GetEcsMethod("Log2", typeof(uint));

            Assert.Equal(0, (int)log2.Invoke(null, new object[] {1u}));
            Assert.Equal(1, (int)log2.Invoke(null, new object[] {2u}));
            Assert.Equal(1, (int)log2.Invoke(null, new object[] {3u}));
            Assert.Equal(2, (int)log2.Invoke(null, new object[] {4u}));
            Assert.Equal(2, (int)log2.Invoke(null, new object[] {7u}));
            Assert.Equal(3, (int)log2.Invoke(null, new object[] {8u}));
            Assert.Equal(4, (int)log2.Invoke(null, new object[] {16u}));
            Assert.Equal(7, (int)log2.Invoke(null, new object[] {255u}));
            Assert.Equal(8, (int)log2.Invoke(null, new object[] {256u}));
            Assert.Equal(10, (int)log2.Invoke(null, new object[] {1024u}));
            Assert.Equal(31, (int)log2.Invoke(null, new object[] {2147483648u}));
            Assert.Equal(31, (int)log2.Invoke(null, new object[] {uint.MaxValue}));
        }

        /// <summary>
        ///     Tests that RoundUpToPowerOf2 returns the next highest power of two
        /// </summary>
        [Fact]
        public void RoundUpToPowerOf2_ReturnsNextHighestPowerOfTwo()
        {
            MethodInfo roundUp = GetEcsMethod("RoundUpToPowerOf2", typeof(uint));

            Assert.Equal(0u, (uint)roundUp.Invoke(null, new object[] {0u}));
            Assert.Equal(1u, (uint)roundUp.Invoke(null, new object[] {1u}));
            Assert.Equal(2u, (uint)roundUp.Invoke(null, new object[] {2u}));
            Assert.Equal(4u, (uint)roundUp.Invoke(null, new object[] {3u}));
            Assert.Equal(8u, (uint)roundUp.Invoke(null, new object[] {5u}));
            Assert.Equal(8u, (uint)roundUp.Invoke(null, new object[] {7u}));
            Assert.Equal(8u, (uint)roundUp.Invoke(null, new object[] {8u}));
            Assert.Equal(16u, (uint)roundUp.Invoke(null, new object[] {9u}));
            Assert.Equal(32u, (uint)roundUp.Invoke(null, new object[] {31u}));
            Assert.Equal(128u, (uint)roundUp.Invoke(null, new object[] {100u}));
            Assert.Equal(1024u, (uint)roundUp.Invoke(null, new object[] {1024u}));
            Assert.Equal(0u, (uint)roundUp.Invoke(null, new object[] {uint.MaxValue}));
        }

        /// <summary>
        ///     Tests that RotateLeft rotates the bits left by the specified offset
        /// </summary>
        [Fact]
        public void RotateLeft_RotatesBitsLeft()
        {
            MethodInfo rotateLeft = GetEcsMethod("RotateLeft", typeof(uint), typeof(int));

            Assert.Equal(2u, (uint)rotateLeft.Invoke(null, new object[] {1u, 1}));
            Assert.Equal(1u, (uint)rotateLeft.Invoke(null, new object[] {2147483648u, 1}));
            Assert.Equal(591751041u, (uint)rotateLeft.Invoke(null, new object[] {305419896u, 4}));
            Assert.Equal(3454992811u, (uint)rotateLeft.Invoke(null, new object[] {2882400001u, 8}));
            Assert.Equal(1u, (uint)rotateLeft.Invoke(null, new object[] {1u, 32}));
            Assert.Equal(1u, (uint)rotateLeft.Invoke(null, new object[] {1u, 0}));
        }
    }
}
