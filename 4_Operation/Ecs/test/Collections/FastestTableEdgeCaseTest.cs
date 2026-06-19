// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastestTableEdgeCaseTest.cs
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
//  See the GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using Alis.Core.Ecs.Collections;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     Edge case tests for <see cref="FastestTable{T}" /> covering construction
    ///     boundaries, resize triggers, EnsureCapacity, Empty, AsSpan, and Length.
    /// </summary>
    public class FastestTableEdgeCaseTest
    {
        /// <summary>
        /// Tests that constructor with size zero creates empty buffer
        /// </summary>
        [Fact]
        public void Constructor_WithSizeZero_CreatesEmptyBuffer()
        {
            FastestTable<int> table = new FastestTable<int>(0);

            Assert.Equal(0, table.Length);
        }

        /// <summary>
        /// Tests that constructor with size one creates buffer of one
        /// </summary>
        [Fact]
        public void Constructor_WithSizeOne_CreatesBufferOfOne()
        {
            FastestTable<int> table = new FastestTable<int>(1);

            Assert.Equal(1, table.Length);
        }

        /// <summary>
        /// Tests that constructor with exact power of two creates exact size
        /// </summary>
        [Fact]
        public void Constructor_WithExactPowerOfTwo_CreatesExactSize()
        {
            FastestTable<int> table = new FastestTable<int>(16);

            Assert.Equal(16, table.Length);
        }

        /// <summary>
        /// Tests that constructor with non power of two rounds up
        /// </summary>
        [Fact]
        public void Constructor_WithNonPowerOfTwo_RoundsUp()
        {
            FastestTable<int> table = new FastestTable<int>(10);

            Assert.Equal(16, table.Length);
        }

        /// <summary>
        /// Tests that empty static property has zero length
        /// </summary>
        [Fact]
        public void Empty_StaticProperty_HasZeroLength()
        {
            FastestTable<int> table = FastestTable<int>.Empty;

            Assert.Equal(0, table.Length);
        }

        /// <summary>
        /// Tests that length after resize reflects new capacity
        /// </summary>
        [Fact]
        public void Length_AfterResize_ReflectsNewCapacity()
        {
            FastestTable<int> table = new FastestTable<int>(4);
            Assert.Equal(4, table.Length);

            table[10] = 42;

            Assert.True(table.Length >= 16);
        }

        /// <summary>
        /// Tests that index at capacity boundary no resize
        /// </summary>
        [Fact]
        public void Index_AtCapacityBoundary_NoResize()
        {
            FastestTable<int> table = new FastestTable<int>(8);
            table[7] = 99;

            Assert.Equal(8, table.Length);
            Assert.Equal(99, table[7]);
        }

        /// <summary>
        /// Tests that index at capacity triggers resize
        /// </summary>
        [Fact]
        public void Index_AtCapacity_TriggersResize()
        {
            FastestTable<int> table = new FastestTable<int>(4);
            table[4] = 42;

            Assert.Equal(8, table.Length);
            Assert.Equal(42, table[4]);
        }

        /// <summary>
        /// Tests that index far beyond capacity resizes large
        /// </summary>
        [Fact]
        public void Index_FarBeyondCapacity_ResizesLarge()
        {
            FastestTable<int> table = new FastestTable<int>(4);
            table[100] = 7;

            Assert.True(table.Length >= 128);
            Assert.Equal(7, table[100]);
        }

        /// <summary>
        /// Tests that index zero length resizes on first access
        /// </summary>
        [Fact]
        public void Index_ZeroLength_ResizesOnFirstAccess()
        {
            FastestTable<int> table = new FastestTable<int>(0);
            Assert.Equal(0, table.Length);

            table[0] = 1;

            Assert.True(table.Length >= 1);
            Assert.Equal(1, table[0]);
        }

        /// <summary>
        /// Tests that ensure capacity sufficient capacity does not resize
        /// </summary>
        [Fact]
        public void EnsureCapacity_SufficientCapacity_DoesNotResize()
        {
            FastestTable<int> table = new FastestTable<int>(16);
            int oldLength = table.Length;

            table.EnsureCapacity(8);

            Assert.Equal(oldLength, table.Length);
        }

        /// <summary>
        /// Tests that ensure capacity insufficient capacity resizes
        /// </summary>
        [Fact]
        public void EnsureCapacity_InsufficientCapacity_Resizes()
        {
            FastestTable<int> table = new FastestTable<int>(4);

            table.EnsureCapacity(16);

            Assert.True(table.Length >= 16);
        }

        /// <summary>
        /// Tests that unsafe index no resize valid index returns ref
        /// </summary>
        [Fact]
        public void UnsafeIndexNoResize_ValidIndex_ReturnsRef()
        {
            FastestTable<int> table = new FastestTable<int>(8);
            table[3] = 77;

            ref int val = ref table.UnsafeIndexNoResize(3);

            Assert.Equal(77, val);
        }

        /// <summary>
        /// Tests that as span returns full buffer
        /// </summary>
        [Fact]
        public void AsSpan_ReturnsFullBuffer()
        {
            FastestTable<int> table = new FastestTable<int>(8);
            table[0] = 1;
            table[1] = 2;

            Span<int> span = table.AsSpan();

            Assert.Equal(8, span.Length);
            Assert.Equal(1, span[0]);
            Assert.Equal(2, span[1]);
        }

        /// <summary>
        /// Tests that as span empty table returns empty
        /// </summary>
        [Fact]
        public void AsSpan_EmptyTable_ReturnsEmpty()
        {
            FastestTable<int> table = FastestTable<int>.Empty;

            Span<int> span = table.AsSpan();

            Assert.True(span.IsEmpty);
        }

        /// <summary>
        /// Tests that struct default has null buffer
        /// </summary>
        [Fact]
        public void Struct_Default_HasNullBuffer()
        {
            FastestTable<int> table = default;

            Assert.Throws<NullReferenceException>(() => table.Length);
        }

        /// <summary>
        /// Tests that struct copy shares buffer
        /// </summary>
        [Fact]
        public void Struct_Copy_SharesBuffer()
        {
            FastestTable<int> original = new FastestTable<int>(4);
            original[0] = 10;

            FastestTable<int> copy = original;
            copy[1] = 20;

            Assert.Equal(20, original[1]);
            Assert.Equal(20, copy[1]);
        }

        /// <summary>
        /// Tests that index reference type resize preserves values
        /// </summary>
        [Fact]
        public void Index_ReferenceType_ResizePreservesValues()
        {
            FastestTable<string> table = new FastestTable<string>(2);
            table[0] = "a";
            table[1] = "b";

            table[3] = "d";

            Assert.Equal("a", table[0]);
            Assert.Equal("b", table[1]);
            Assert.Equal("d", table[3]);
        }

        /// <summary>
        /// Tests that multiple resize data correct after several growths
        /// </summary>
        [Fact]
        public void MultipleResize_DataCorrect_AfterSeveralGrowths()
        {
            FastestTable<int> table = new FastestTable<int>(1);
            for (int i = 0; i < 64; i++)
            {
                table[i] = i;
            }

            for (int i = 0; i < 64; i++)
            {
                Assert.Equal(i, table[i]);
            }
        }
    }
}
