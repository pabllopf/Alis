// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastImmutableArrayCoverageTest.cs
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
using System.Collections;
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Collections;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Collections
{
    /// <summary>
    ///     Coverage-driven tests for FastImmutableArray targeting uncovered lines and branches.
    /// </summary>
    public class FastImmutableArrayCoverageTest
    {
        /// <summary>
        ///     Tests that builder indexer getter out of range should throw
        /// </summary>
        [Fact]
        public void BuilderIndexerGetterOutOfRangeShouldThrow()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(3);
            builder.Add(1);
            builder.Add(2);
            builder.Add(3);

            Assert.Throws<ArgumentOutOfRangeException>(() => _ = builder[3]);
        }

        /// <summary>
        ///     Tests that builder indexer setter out of range should throw
        /// </summary>
        [Fact]
        public void BuilderIndexerSetterOutOfRangeShouldThrow()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(3);
            builder.Add(1);
            builder.Add(2);
            builder.Add(3);

            Assert.Throws<ArgumentOutOfRangeException>(() => builder[3] = 99);
        }

        /// <summary>
        ///     Tests that non generic get enumerator should work
        /// </summary>
        [Fact]
        public void NonGenericGetEnumeratorShouldWork()
        {
            FastImmutableArray<int> array = new FastImmutableArray<int>(new[] {10, 20, 30});

            IEnumerable nonGeneric = array;
            IEnumerator enumerator = nonGeneric.GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.Equal(10, enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(20, enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(30, enumerator.Current);
            Assert.False(enumerator.MoveNext());
        }

        /// <summary>
        ///     Tests that builder item ref out of range should throw
        /// </summary>
        [Fact]
        public void BuilderItemRefOutOfRangeShouldThrow()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(3);
            builder.Add(1);
            builder.Add(2);
            builder.Add(3);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                ref readonly int ref1 = ref builder.ItemRef(3);
            });
        }

        /// <summary>
        ///     Tests that builder index of with start index and count should work
        /// </summary>
        [Fact]
        public void BuilderIndexOfWithStartIndexAndCountShouldWork()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(5);
            builder.AddRange(1, 2, 3, 4, 5);

            int result = builder.IndexOf(3, 2, 2);

            Assert.Equal(2, result);
        }

        /// <summary>
        ///     Tests that builder index of with start index and count not found should return minus one
        /// </summary>
        [Fact]
        public void BuilderIndexOfWithStartIndexAndCountNotFoundShouldReturnMinusOne()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(5);
            builder.AddRange(1, 2, 3, 4, 5);

            int result = builder.IndexOf(3, 0, 2);

            Assert.Equal(-1, result);
        }

        /// <summary>
        ///     Tests that builder index of with start index and comparer should work
        /// </summary>
        [Fact]
        public void BuilderIndexOfWithStartIndexAndComparerShouldWork()
        {
            FastImmutableArray<string>.Builder builder = FastImmutableArray<string>.CreateBuilder<string>(3);
            builder.AddRange("a", "b", "c");

            int result = builder.IndexOf("b", 0, EqualityComparer<string>.Default);

            Assert.Equal(1, result);
        }

        /// <summary>
        ///     Tests that builder index of with start index and comparer not found should return minus one
        /// </summary>
        [Fact]
        public void BuilderIndexOfWithStartIndexAndComparerNotFoundShouldReturnMinusOne()
        {
            FastImmutableArray<string>.Builder builder = FastImmutableArray<string>.CreateBuilder<string>(3);
            builder.AddRange("a", "b", "c");

            int result = builder.IndexOf("z", 0, EqualityComparer<string>.Default);

            Assert.Equal(-1, result);
        }

        /// <summary>
        ///     Tests that AddRange with ReadOnlySpan appends elements
        /// </summary>
        [Fact]
        public void AddRangeReadOnlySpanAppendsElements()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(5);
            builder.Add(1);

            ReadOnlySpan<int> span = new[] {2, 3, 4}.AsSpan();
            builder.AddRange(span);

            Assert.Equal(4, builder.Count);
            Assert.Equal(1, builder[0]);
            Assert.Equal(2, builder[1]);
            Assert.Equal(3, builder[2]);
            Assert.Equal(4, builder[3]);
        }

        /// <summary>
        ///     Tests that AddRange with empty ReadOnlySpan does nothing
        /// </summary>
        [Fact]
        public void AddRangeEmptyReadOnlySpanDoesNothing()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(3);
            builder.Add(1);

            builder.AddRange(ReadOnlySpan<int>.Empty);

            Assert.Equal(1, builder.Count);
            Assert.Equal(1, builder[0]);
        }

        /// <summary>
        ///     Tests that AddRange with FastImmutableArray and length when array is null does nothing
        /// </summary>
        [Fact]
        public void AddRangeFastImmutableArrayWithLengthNullArrayDoesNothing()
        {
            FastImmutableArray<int> defaultArray = default;
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);
            builder.Add(1);

            builder.AddRange(defaultArray, 0);

            Assert.Equal(1, builder.Count);
        }

        /// <summary>
        ///     Tests that AddRange with derived FastImmutableArray that has null array does nothing
        /// </summary>
        [Fact]
        public void AddRangeDerivedFastImmutableArrayNullArrayDoesNothing()
        {
            FastImmutableArray<string> defaultArray = default;
            FastImmutableArray<object>.Builder builder = FastImmutableArray<object>.CreateBuilder<object>(2);
            builder.Add(1);

            builder.AddRange<string>(defaultArray);

            Assert.Equal(1, builder.Count);
        }

        /// <summary>
        ///     Tests that CreateBuilder sets capacity correctly
        /// </summary>
        [Fact]
        public void CreateBuilderSetsCapacity()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(5);

            Assert.Equal(5, builder.Capacity);
            Assert.Equal(0, builder.Count);
        }

        /// <summary>
        ///     Tests that IFastImmutableArray.Array returns underlying array
        /// </summary>
        [Fact]
        public void IFastImmutableArrayArrayReturnsUnderlyingArray()
        {
            int[] data = {1, 2, 3};
            FastImmutableArray<int> array = new FastImmutableArray<int>(data);

            IFastImmutableArray iface = array;
            Array result = iface.Array;

            Assert.Same(data, result);
        }

        /// <summary>
        ///     Tests that IFastImmutableArray.Array on default instance is null
        /// </summary>
        [Fact]
        public void IFastImmutableArrayArrayOnDefaultIsNull()
        {
            FastImmutableArray<int> defaultArray = default;

            IFastImmutableArray iface = defaultArray;

            Assert.Null(iface.Array);
        }

        /// <summary>
        ///     Tests that CopyTo with Span destination copies all elements
        /// </summary>
        [Fact]
        public void CopyToSpanDestinationCopiesAll()
        {
            FastImmutableArray<int> array = new FastImmutableArray<int>(new[] {1, 2, 3});
            Span<int> dest = new int[3];

            array.CopyTo(dest);

            Assert.Equal(1, dest[0]);
            Assert.Equal(2, dest[1]);
            Assert.Equal(3, dest[2]);
        }

        /// <summary>
        ///     Tests that CopyTo with Span and destination index copies at offset
        /// </summary>
        [Fact]
        public void CopyToSpanWithDestinationIndexCopiesAtOffset()
        {
            FastImmutableArray<int> array = new FastImmutableArray<int>(new[] {10, 20, 30});
            Span<int> dest = new int[5];

            array.CopyTo(dest, 1);

            Assert.Equal(0, dest[0]);
            Assert.Equal(10, dest[1]);
            Assert.Equal(20, dest[2]);
            Assert.Equal(30, dest[3]);
            Assert.Equal(0, dest[4]);
        }

        /// <summary>
        ///     Tests that CopyTo with source index and Span destination copies range
        /// </summary>
        [Fact]
        public void CopyToSourceIndexSpanDestinationCopiesRange()
        {
            FastImmutableArray<int> array = new FastImmutableArray<int>(new[] {1, 2, 3, 4, 5});
            Span<int> dest = new int[3];

            array.CopyTo(1, dest, 0, 3);

            Assert.Equal(2, dest[0]);
            Assert.Equal(3, dest[1]);
            Assert.Equal(4, dest[2]);
        }

        /// <summary>
        ///     Tests that CopyTo with zero length on Span does nothing
        /// </summary>
        [Fact]
        public void CopyToSpanZeroLengthDoesNothing()
        {
            FastImmutableArray<int> array = new FastImmutableArray<int>(new[] {1, 2, 3});
            Span<int> dest = new int[0];

            array.CopyTo(0, dest, 0, 0);

            Assert.Empty(dest.ToArray());
        }

        /// <summary>
        ///     Tests that RemoveRange with empty enumerable and comparer does nothing
        /// </summary>
        [Fact]
        public void RemoveRangeEmptyEnumerableWithComparerDoesNothing()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);
            builder.Add(1);

            builder.RemoveRange((System.Collections.Generic.IEnumerable<int>)Array.Empty<int>(), null);

            Assert.Equal(1, builder.Count);
        }

        /// <summary>
        ///     Tests that RemoveRange with item at last position triggers break in while loop
        /// </summary>
        [Fact]
        public void RemoveRangeItemAtLastPositionTriggersBreak()
        {
            FastImmutableArray<string>.Builder builder = FastImmutableArray<string>.CreateBuilder<string>(3);
            builder.AddRange("A", "B", "C");

            builder.RemoveRange((System.Collections.Generic.IEnumerable<string>)new[] {"C"}, StringComparer.OrdinalIgnoreCase);

            Assert.Equal(2, builder.Count);
            Assert.Equal("A", builder[0]);
            Assert.Equal("B", builder[1]);
        }

        /// <summary>
        ///     Tests that RemoveRange with reference type clears elements at end
        /// </summary>
        [Fact]
        public void RemoveRangeReferenceTypeEndRemovesAll()
        {
            FastImmutableArray<string>.Builder builder = FastImmutableArray<string>.CreateBuilder<string>(4);
            builder.AddRange("A", "B", "C");

            builder.RemoveRange(1, 2);

            Assert.Equal(1, builder.Count);
            Assert.Equal("A", builder[0]);
        }
    }
}
