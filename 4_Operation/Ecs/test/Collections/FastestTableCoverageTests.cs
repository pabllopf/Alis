// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastestTableCoverageTests.cs
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
    ///     Coverage-driven tests for <see cref="FastestTable{T}" /> targeting
    ///     specific branches and edge cases not yet exercised by existing tests.
    /// </summary>
    public class FastestTableCoverageTests
    {
        /// <summary>
        ///     Tests that UnsafeIndexNoResize returns a reference to the first element.
        /// </summary>
        [Fact]
        public void UnsafeIndexNoResize_FirstElement_ReturnsRef()
        {
            FastestTable<int> table = new FastestTable<int>(8);
            table[0] = 42;

            ref int val = ref table.UnsafeIndexNoResize(0);

            Assert.Equal(42, val);
        }

        /// <summary>
        ///     Tests that UnsafeIndexNoResize returns a reference to the last element.
        /// </summary>
        [Fact]
        public void UnsafeIndexNoResize_LastElement_ReturnsRef()
        {
            FastestTable<int> table = new FastestTable<int>(8);
            table[7] = 99;

            ref int val = ref table.UnsafeIndexNoResize(7);

            Assert.Equal(99, val);
        }

        /// <summary>
        ///     Tests that EnsureCapacity does nothing when the buffer is already large enough.
        /// </summary>
        [Fact]
        public void EnsureCapacity_Sufficient_DoesNothing()
        {
            FastestTable<int> table = new FastestTable<int>(16);
            int before = table.Length;

            table.EnsureCapacity(8);

            Assert.Equal(before, table.Length);
        }

        /// <summary>
        ///     Tests that EnsureCapacity resizes when the requested size exceeds current capacity.
        /// </summary>
        [Fact]
        public void EnsureCapacity_Insufficient_Resizes()
        {
            FastestTable<int> table = new FastestTable<int>(4);

            table.EnsureCapacity(16);

            Assert.True(table.Length >= 16);
        }

        /// <summary>
        ///     Tests that the Empty property returns a table whose Length is 0.
        /// </summary>
        [Fact]
        public void Empty_ReturnsZeroLength()
        {
            FastestTable<int> empty = FastestTable<int>.Empty;

            Assert.Equal(0, empty.Length);
        }

        /// <summary>
        ///     Tests that values written before a resize are still readable after the resize.
        /// </summary>
        [Fact]
        public void Indexer_PreservesValuesAfterResize()
        {
            FastestTable<int> table = new FastestTable<int>(2);
            table[0] = 10;
            table[1] = 20;

            table[10] = 30;

            Assert.Equal(10, table[0]);
            Assert.Equal(20, table[1]);
            Assert.Equal(30, table[10]);
        }

        /// <summary>
        ///     Tests that AsSpan covers the entire allocated buffer, not just written elements.
        /// </summary>
        [Fact]
        public void AsSpan_CoversFullBuffer()
        {
            FastestTable<int> table = new FastestTable<int>(8);
            table[0] = 1;
            table[7] = 2;

            Span<int> span = table.AsSpan();

            Assert.Equal(8, span.Length);
            Assert.Equal(1, span[0]);
            Assert.Equal(2, span[7]);
        }

        /// <summary>
        ///     Tests that constructing with size 0 produces a table whose Length is 0.
        /// </summary>
        [Fact]
        public void Constructor_SizeZero_LengthZero()
        {
            FastestTable<int> table = new FastestTable<int>(0);

            Assert.Equal(0, table.Length);
        }

        /// <summary>
        ///     Tests that Empty table AsSpan returns an empty span.
        /// </summary>
        [Fact]
        public void AsSpan_EmptyTable_ReturnsEmpty()
        {
            FastestTable<int> empty = FastestTable<int>.Empty;

            Span<int> span = empty.AsSpan();

            Assert.True(span.IsEmpty);
        }

        /// <summary>
        ///     Tests that UnsafeIndexNoResize on an Empty table throws.
        /// </summary>
        [Fact]
        public void UnsafeIndexNoResize_EmptyTable_Throws()
        {
            FastestTable<int> empty = FastestTable<int>.Empty;

            Assert.Throws<IndexOutOfRangeException>(() => empty.UnsafeIndexNoResize(0));
        }

        /// <summary>
        ///     Tests that default struct (null _buffer) throws on Length access.
        /// </summary>
        [Fact]
        public void DefaultStruct_ThrowsOnLength()
        {
            FastestTable<int> table = default;

            Assert.Throws<NullReferenceException>(() => table.Length);
        }
    }
}
