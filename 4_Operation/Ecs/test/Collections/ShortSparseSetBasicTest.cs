// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ShortSparseSetBasicTest.cs
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


using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     The short sparse set basic test class
    /// </summary>
    /// <remarks>
    ///     Tests basic functionality of <see cref="ShortSparseSet{T}" /> which is a
    ///     sparse array implementation optimized for ushort indices (16-bit IDs).
    ///     This is useful for component storage with limited component counts.
    /// </remarks>
    public class ShortSparseSetBasicTest
    {
        /// <summary>
        ///     Tests that short sparse set can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that a ShortSparseSet can be instantiated with the default constructor.
        /// </remarks>
        [Fact]
        public void ShortSparseSet_CanBeCreated()
        {
            ShortSparseSet<int> sparseSet = new ShortSparseSet<int>();

            Assert.NotNull(sparseSet);
        }

        /// <summary>
        ///     Tests that short sparse set can store and retrieve values
        /// </summary>
        /// <remarks>
        ///     Validates that values can be stored and retrieved by short indices.
        /// </remarks>
        [Fact]
        public void ShortSparseSet_CanStoreAndRetrieveValues()
        {
            ShortSparseSet<string> sparseSet = new ShortSparseSet<string>();

            sparseSet[0] = "Zero";
            sparseSet[5] = "Five";
            sparseSet[100] = "Hundred";

            Assert.Equal("Zero", sparseSet[0]);
            Assert.Equal("Five", sparseSet[5]);
            Assert.Equal("Hundred", sparseSet[100]);
        }

        /// <summary>
        ///     Tests that short sparse set can handle maximum ushort values
        /// </summary>
        /// <remarks>
        ///     Verifies that ShortSparseSet works with the maximum ushort index value.
        /// </remarks>
        [Fact]
        public void ShortSparseSet_CanHandleMaxUshortIndices()
        {
            ShortSparseSet<int> sparseSet = new ShortSparseSet<int>();
            ushort maxIndex = ushort.MaxValue - 1;

            sparseSet[maxIndex] = 42;

            Assert.Equal(42, sparseSet[maxIndex]);
        }

        /// <summary>
        ///     Tests that short sparse set can store reference types
        /// </summary>
        /// <remarks>
        ///     Validates that ShortSparseSet works correctly with reference types.
        /// </remarks>
        [Fact]
        public void ShortSparseSet_CanStoreReferenceTypes()
        {
            ShortSparseSet<Position> sparseSet = new ShortSparseSet<Position>();
            Position pos1 = new Position {X = 10, Y = 20};
            Position pos2 = new Position {X = 30, Y = 40};

            sparseSet[0] = pos1;
            sparseSet[1] = pos2;

            Assert.Equal(pos1.X, sparseSet[0].X);
            Assert.Equal(pos2.Y, sparseSet[1].Y);
        }

        /// <summary>
        ///     Tests that short sparse set initializes with proper capacity
        /// </summary>
        /// <remarks>
        ///     Verifies that the initial capacity of ShortSparseSet is reasonable.
        /// </remarks>
        [Fact]
        public void ShortSparseSet_HasInitialCapacity()
        {
            ShortSparseSet<int> sparseSet = new ShortSparseSet<int>();

            Assert.True(sparseSet.Capacity > 0);
        }

        /// <summary>
        ///     Tests that short sparse set can grow its capacity
        /// </summary>
        /// <remarks>
        ///     Validates that ShortSparseSet can expand its internal arrays
        ///     to accommodate more elements.
        /// </remarks>
        [Fact]
        public void ShortSparseSet_CanGrowCapacity()
        {
            ShortSparseSet<int> sparseSet = new ShortSparseSet<int>();
            int initialCapacity = sparseSet.Capacity;

            for (int i = 0; i < initialCapacity * 2; i++)
            {
                sparseSet[(ushort) i] = i;
            }

            Assert.True(sparseSet.Capacity >= initialCapacity);
        }

        /// <summary>
        ///     Tests that short sparse set can handle sparse patterns
        /// </summary>
        /// <remarks>
        ///     Verifies that ShortSparseSet efficiently handles sparse data
        ///     with gaps between used indices.
        /// </remarks>
        [Fact]
        public void ShortSparseSet_HandlesSparsePatternsEfficiently()
        {
            ShortSparseSet<int> sparseSet = new ShortSparseSet<int>();

            sparseSet[0] = 1;
            sparseSet[1000] = 2;
            sparseSet[5000] = 3;
            sparseSet[10000] = 4;

            Assert.Equal(1, sparseSet[0]);
            Assert.Equal(2, sparseSet[1000]);
            Assert.Equal(3, sparseSet[5000]);
            Assert.Equal(4, sparseSet[10000]);
        }

        /// <summary>
        ///     Tests that short sparse set can store many sequential values
        /// </summary>
        /// <remarks>
        ///     Validates that ShortSparseSet performs well with sequential data.
        /// </remarks>
        [Fact]
        public void ShortSparseSet_CanStoreManySequentialValues()
        {
            ShortSparseSet<int> sparseSet = new ShortSparseSet<int>();

            for (int i = 0; i < 1000; i++)
            {
                sparseSet[(ushort) i] = i * 2;
            }

            for (int i = 0; i < 1000; i++)
            {
                Assert.Equal(i * 2, sparseSet[(ushort) i]);
            }
        }
    }
}