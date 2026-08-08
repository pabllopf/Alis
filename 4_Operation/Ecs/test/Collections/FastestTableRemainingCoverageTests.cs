// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastestTableRemainingCoverageTests.cs
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
using Alis.Core.Ecs.Collections;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     Remaining coverage tests for <see cref="FastestTable{T}" />.
    /// </summary>
    public class FastestTableRemainingCoverageTests
    {
        /// <summary>
        ///     Verifies that the constructor rounds up non-power-of-2 sizes to the next power of 2.
        /// </summary>
        [Fact]
        public void Constructor_WithSize_RoundUpToPowerOf2()
        {
            FastestTable<int> t = new FastestTable<int>(3);

            Assert.Equal(4, t.Length);
        }

        /// <summary>
        ///     Verifies that the constructor keeps the same size when given an exact power of 2.
        /// </summary>
        [Fact]
        public void Constructor_WithExactPowerOf2_KeepsSameSize()
        {
            FastestTable<int> t = new FastestTable<int>(4);

            Assert.Equal(4, t.Length);
        }

        /// <summary>
        ///     Verifies that the constructor creates a zero-length buffer when given zero.
        /// </summary>
        [Fact]
        public void Constructor_WithZero_ReturnsSizeZero()
        {
            FastestTable<int> t = new FastestTable<int>(0);

            Assert.Equal(0, t.Length);
        }

        /// <summary>
        ///     Verifies that the Empty property returns a table with zero length.
        /// </summary>
        [Fact]
        public void Empty_ReturnsEmptyTable()
        {
            FastestTable<int> e = FastestTable<int>.Empty;

            Assert.Equal(0, e.Length);
        }

        /// <summary>
        ///     Verifies that values set via the indexer are read back correctly.
        /// </summary>
        [Fact]
        public void Indexer_GetAndSet_RoundTrips()
        {
            FastestTable<int> t = new FastestTable<int>(8);
            t[3] = 42;

            Assert.Equal(42, t[3]);
        }

        /// <summary>
        ///     Verifies that accessing an out-of-range index automatically resizes the buffer.
        /// </summary>
        [Fact]
        public void Indexer_OutOfRange_ResizesAuto()
        {
            FastestTable<int> t = new FastestTable<int>(2);
            t[10] = 99;

            Assert.Equal(99, t[10]);
            Assert.True(t.Length >= 11);
        }

        /// <summary>
        ///     Verifies that existing values are preserved after a resize triggered by the indexer.
        /// </summary>
        [Fact]
        public void Indexer_SetAfterResize_KeepsExistingValues()
        {
            FastestTable<int> t = new FastestTable<int>(2);
            t[0] = 1;
            t[10] = 2;

            Assert.Equal(1, t[0]);
        }

        /// <summary>
        ///     Verifies that UnsafeIndexNoResize returns the expected element without bounds checking.
        /// </summary>
        [Fact]
        public void UnsafeIndexNoResize_ReturnsElement()
        {
            FastestTable<int> t = new FastestTable<int>(8);
            t[3] = 7;

            Assert.Equal(7, t.UnsafeIndexNoResize(3));
        }

        /// <summary>
        ///     Verifies that UnsafeIndexNoResize works for all valid indices within the buffer.
        /// </summary>
        [Fact]
        public void UnsafeIndexNoResize_InBounds_WorksForAllIndices()
        {
            FastestTable<int> t = new FastestTable<int>(16);
            for (int i = 0; i < 8; i++)
            {
                t[i] = i * 10;
            }
            for (int i = 0; i < 8; i++)
            {
                Assert.Equal(i * 10, t.UnsafeIndexNoResize(i));
            }
        }

        /// <summary>
        ///     Verifies that EnsureCapacity does nothing when the requested size is less than current capacity.
        /// </summary>
        [Fact]
        public void EnsureCapacity_WhenLessThanCurrent_DoesNothing()
        {
            FastestTable<int> t = new FastestTable<int>(8);
            t.EnsureCapacity(4);

            Assert.True(t.Length >= 8);
        }

        /// <summary>
        ///     Verifies that EnsureCapacity resizes when the requested size exceeds current capacity.
        /// </summary>
        [Fact]
        public void EnsureCapacity_WhenMoreThanCurrent_Resizes()
        {
            FastestTable<int> t = new FastestTable<int>(4);
            t.EnsureCapacity(10);

            Assert.True(t.Length >= 10);
        }

        /// <summary>
        ///     Verifies that AsSpan returns a span covering the full buffer.
        /// </summary>
        [Fact]
        public void AsSpan_ReturnsFullBufferSpan()
        {
            FastestTable<int> t = new FastestTable<int>(8);
            Span<int> span = t.AsSpan();

            Assert.True(span.Length >= 8);
        }

        /// <summary>
        ///     Verifies that Length matches the buffer length (rounded up to power of 2).
        /// </summary>
        [Fact]
        public void Length_MatchesBufferLength()
        {
            FastestTable<int> t = new FastestTable<int>(7);

            Assert.Equal(8, t.Length);
        }
    }
}
