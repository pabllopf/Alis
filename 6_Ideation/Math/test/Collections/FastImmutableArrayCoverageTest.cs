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

        /// <summary>
        ///     Tests that Count setter shrink by 64 or fewer uses loop clear (not Array.Clear)
        /// </summary>
        [Fact]
        public void CountSetterShrinkSmallUsesLoop()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(70);
            for (int i = 0; i < 70; i++)
            {
                builder.Add(i);
            }

            builder.Count = 60;

            Assert.Equal(60, builder.Count);
        }

        /// <summary>
        ///     Tests that Capacity setter with value > 0 and _count == 0 reallocates without copy
        /// </summary>
        [Fact]
        public void CapacitySetLargerWithZeroCountReallocates()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);

            builder.Capacity = 10;

            Assert.Equal(10, builder.Capacity);
            Assert.Equal(0, builder.Count);
        }

        /// <summary>
        ///     Tests that Insert at end (index == Count) appends without shifting
        /// </summary>
        [Fact]
        public void InsertAtEndAppends()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(3);
            builder.Add(1);
            builder.Add(2);

            builder.Insert(2, 3);

            Assert.Equal(3, builder.Count);
            Assert.Equal(1, builder[0]);
            Assert.Equal(2, builder[1]);
            Assert.Equal(3, builder[2]);
        }

        /// <summary>
        ///     Tests that InsertRange at end (index == Count) appends without shifting
        /// </summary>
        [Fact]
        public void InsertRangeAtEndAppends()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(4);
            builder.AddRange(1, 2);

            builder.InsertRange(2, new FastImmutableArray<int>(new[] { 3, 4 }));

            Assert.Equal(4, builder.Count);
            Assert.Equal(1, builder[0]);
            Assert.Equal(2, builder[1]);
            Assert.Equal(3, builder[2]);
            Assert.Equal(4, builder[3]);
        }

        /// <summary>
        ///     Tests that RemoveRange at end skips copy and just decrements count
        /// </summary>
        [Fact]
        public void RemoveRangeAtEndSkipsCopy()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(5);
            builder.AddRange(1, 2, 3, 4, 5);

            builder.RemoveRange(3, 2);

            Assert.Equal(3, builder.Count);
            Assert.Equal(1, builder[0]);
            Assert.Equal(2, builder[1]);
            Assert.Equal(3, builder[2]);
        }

        /// <summary>
        ///     Tests that EnsureCapacity does nothing when already sufficient
        /// </summary>
        [Fact]
        public void EnsureCapacityAlreadySufficientDoesNothing()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(10);
            builder.Add(1);

            int originalCapacity = builder.Capacity;

            builder.EnsureCapacity(5);

            Assert.Equal(originalCapacity, builder.Capacity);
        }

        /// <summary>
        ///     Tests that RemoveRange(IEnumerable{T}) with duplicates removes all occurrences
        /// </summary>
        [Fact]
        public void RemoveRangeEnumerableWithDuplicates()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(10);
            builder.AddRange(1, 2, 3, 2, 4, 2, 5);

            builder.RemoveRange(new[] { 2 });

            Assert.Equal(4, builder.Count);
            Assert.Equal(1, builder[0]);
            Assert.Equal(3, builder[1]);
            Assert.Equal(4, builder[2]);
            Assert.Equal(5, builder[3]);
        }

        /// <summary>
        ///     Tests that RemoveRange(IEnumerable{T}) with multiple items removes all
        /// </summary>
        [Fact]
        public void RemoveRangeEnumerableMultipleItems()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(10);
            builder.AddRange(1, 2, 3, 4, 5);

            builder.RemoveRange(new[] { 2, 4 });

            Assert.Equal(3, builder.Count);
            Assert.Equal(1, builder[0]);
            Assert.Equal(3, builder[1]);
            Assert.Equal(5, builder[2]);
        }

        /// <summary>
        ///     Tests that RemoveRange(IEnumerable{T}, IEqualityComparer) with custom comparer removes matches
        /// </summary>
        [Fact]
        public void RemoveRangeEnumerableWithCustomComparer()
        {
            FastImmutableArray<string>.Builder builder = FastImmutableArray<string>.CreateBuilder<string>(5);
            builder.AddRange("A", "B", "C", "D");

            builder.RemoveRange(new[] { "a", "c" }, StringComparer.OrdinalIgnoreCase);

            Assert.Equal(2, builder.Count);
            Assert.Equal("B", builder[0]);
            Assert.Equal("D", builder[1]);
        }

        /// <summary>
        ///     Tests that IndexOf with only startIndex delegates correctly
        /// </summary>
        [Fact]
        public void IndexOfWithStartOnlyFindsElement()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(5);
            builder.AddRange(1, 2, 3, 2, 1);

            int index = builder.IndexOf(2, 2);

            Assert.Equal(3, index);
        }

        /// <summary>
        ///     Tests that IndexOf with startIndex and count finds element in range
        /// </summary>
        [Fact]
        public void IndexOfWithStartAndCountFindsElement()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(5);
            builder.AddRange(1, 2, 3, 4, 5);

            int index = builder.IndexOf(3, 1, 3);

            Assert.Equal(2, index);
        }

        /// <summary>
        ///     Tests that LastIndexOf with startIndex and count finds element
        /// </summary>
        [Fact]
        public void LastIndexOfWithRangeFindsElement()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(5);
            builder.AddRange(1, 2, 3, 2, 1);

            int index = builder.LastIndexOf(2, 3, 3);

            Assert.Equal(3, index);
        }

        /// <summary>
        ///     Tests that Builder foreach uses struct enumerator via GetEnumerator
        /// </summary>
        [Fact]
        public void BuilderGetEnumeratorStructEnumerates()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(5);
            builder.AddRange(10, 20, 30);

            System.Collections.Generic.IEnumerator<int> enumerator = ((System.Collections.Generic.IEnumerable<int>)builder).GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.Equal(10, enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(20, enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(30, enumerator.Current);
            Assert.False(enumerator.MoveNext());
        }

        /// <summary>
        ///     Tests that Builder non-generic GetEnumerator returns values
        /// </summary>
        [Fact]
        public void BuilderNonGenericEnumeratorEnumerates()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(3);
            builder.AddRange(1, 2, 3);

            System.Collections.IEnumerator enumerator = ((System.Collections.IEnumerable)builder).GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.Equal(1, enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(2, enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(3, enumerator.Current);
            Assert.False(enumerator.MoveNext());
        }

        /// <summary>
        ///     Tests that GetEnumerator on default instance throws via IEnumerable{T}
        /// </summary>
        [Fact]
        public void DefaultIEnumerableGenericEnumeratorThrows()
        {
            FastImmutableArray<int> defaultArray = default;

            Assert.Throws<InvalidOperationException>(() => ((System.Collections.Generic.IEnumerable<int>)defaultArray).GetEnumerator());
        }

        /// <summary>
        ///     Tests that GetEnumerator on default instance throws via IEnumerable
        /// </summary>
        [Fact]
        public void DefaultIEnumerableNonGenericEnumeratorThrows()
        {
            FastImmutableArray<int> defaultArray = default;

            Assert.Throws<InvalidOperationException>(() => ((System.Collections.IEnumerable)defaultArray).GetEnumerator());
        }

        /// <summary>
        ///     Tests that EnumeratorObject MoveNext on empty returns false
        /// </summary>
        [Fact]
        public void EnumeratorObjectEmptyMoveNextFalse()
        {
            FastImmutableArray<int> array = new FastImmutableArray<int>(new int[0]);

            System.Collections.Generic.IEnumerator<int> enumerator = ((System.Collections.Generic.IEnumerable<int>)array).GetEnumerator();

            Assert.False(enumerator.MoveNext());
        }

        /// <summary>
        ///     Tests that AddRange with FastImmutableArray having null array calls AddRange(items, length)
        /// </summary>
        [Fact]
        public void AddRangeFastImmutableArrayEmptyDoesNothing()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);
            builder.Add(1);

            builder.AddRange(FastImmutableArray<int>.Empty);

            Assert.Equal(1, builder.Count);
        }

        /// <summary>
        ///     Tests that Capacity setter with same value as current does nothing
        /// </summary>
        [Fact]
        public void CapacitySetToSameValueDoesNothing()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(5);
            builder.AddRange(1, 2, 3);

            builder.Capacity = 5;

            Assert.Equal(5, builder.Capacity);
            Assert.Equal(3, builder.Count);
            Assert.Equal(1, builder[0]);
        }

        /// <summary>
        ///     Tests that RemoveRange int int with reference type in middle clears and shifts elements
        /// </summary>
        [Fact]
        public void RemoveRangeIntIntReferenceTypeMiddleClearsAndShifts()
        {
            FastImmutableArray<string>.Builder builder = FastImmutableArray<string>.CreateBuilder<string>(6);
            builder.AddRange("A", "B", "C", "D", "E", "F");

            builder.RemoveRange(2, 2);

            Assert.Equal(4, builder.Count);
            Assert.Equal("A", builder[0]);
            Assert.Equal("B", builder[1]);
            Assert.Equal("E", builder[2]);
            Assert.Equal("F", builder[3]);
        }

        /// <summary>
        ///     Tests that RemoveAll with no matching elements leaves list null and skips RemoveAtRange
        /// </summary>
        [Fact]
        public void RemoveAllNoMatchingElementsLeavesBuilderUnchanged()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(3);
            builder.AddRange(1, 2, 3);

            builder.RemoveAll(x => x > 10);

            Assert.Equal(3, builder.Count);
            Assert.Equal(1, builder[0]);
            Assert.Equal(2, builder[1]);
            Assert.Equal(3, builder[2]);
        }

        /// <summary>
        ///     Tests that Builder AsMemory returns memory over all added elements
        /// </summary>
        [Fact]
        public void BuilderAsMemoryWithNoElementsReturnsEmpty()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(4);

            Memory<int> memory = builder.AsMemory();

            Assert.Equal(0, memory.Length);
        }

        /// <summary>
        ///     Tests that struct CopyTo T array copies all elements to destination
        /// </summary>
        [Fact]
        public void StructCopyToTArrayCopiesAllElements()
        {
            FastImmutableArray<int> array = new FastImmutableArray<int>(new[] { 7, 8, 9 });
            int[] dest = new int[3];

            array.CopyTo(dest);

            Assert.Equal(7, dest[0]);
            Assert.Equal(8, dest[1]);
            Assert.Equal(9, dest[2]);
        }

        /// <summary>
        ///     Tests that struct CopyTo T array with destination index copies at offset
        /// </summary>
        [Fact]
        public void StructCopyToTArrayWithDestIndexCopiesAtOffset()
        {
            FastImmutableArray<int> array = new FastImmutableArray<int>(new[] { 7, 8, 9 });
            int[] dest = new int[5];

            array.CopyTo(dest, 2);

            Assert.Equal(0, dest[0]);
            Assert.Equal(0, dest[1]);
            Assert.Equal(7, dest[2]);
            Assert.Equal(8, dest[3]);
            Assert.Equal(9, dest[4]);
        }

        /// <summary>
        ///     Tests that struct CopyTo int T array int int copies range from source
        /// </summary>
        [Fact]
        public void StructCopyToRangeCopiesFromSourceIndex()
        {
            FastImmutableArray<int> array = new FastImmutableArray<int>(new[] { 10, 20, 30, 40, 50 });
            int[] dest = new int[2];

            array.CopyTo(2, dest, 0, 2);

            Assert.Equal(30, dest[0]);
            Assert.Equal(40, dest[1]);
        }

        /// <summary>
        ///     Tests that Builder AddRange with empty T array does nothing
        /// </summary>
        [Fact]
        public void BuilderAddRangeEmptyArrayDoesNothing()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(3);
            builder.Add(1);

            builder.AddRange(new int[0]);

            Assert.Equal(1, builder.Count);
        }

        /// <summary>
        ///     Tests that Builder AddRange with derived T array copies elements correctly
        /// </summary>
        [Fact]
        public void BuilderAddRangeDerivedArrayCopiesElements()
        {
            FastImmutableArray<object>.Builder builder = FastImmutableArray<object>.CreateBuilder<object>(4);
            builder.Add("start");

            builder.AddRange(new string[] { "a", "b", "c" });

            Assert.Equal(4, builder.Count);
            Assert.Equal("start", builder[0]);
            Assert.Equal("a", builder[1]);
            Assert.Equal("b", builder[2]);
            Assert.Equal("c", builder[3]);
        }

        /// <summary>
        ///     Tests that Builder RemoveAll with all matching elements removes all
        /// </summary>
        [Fact]
        public void BuilderRemoveAllWithAllMatchingRemovesAll()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(3);
            builder.AddRange(2, 4, 6);

            builder.RemoveAll(x => x % 2 == 0);

            Assert.Equal(0, builder.Count);
        }

        /// <summary>
        ///     Tests that Builder AddRange with derived ReadOnlySpan copies elements
        /// </summary>
        [Fact]
        public void BuilderAddRangeDerivedSpanCopiesElements()
        {
            ReadOnlySpan<string> span = new string[] { "x", "y" }.AsSpan();
            FastImmutableArray<object>.Builder builder = FastImmutableArray<object>.CreateBuilder<object>(4);
            builder.Add("start");

            builder.AddRange(span);

            Assert.Equal(3, builder.Count);
            Assert.Equal("start", builder[0]);
            Assert.Equal("x", builder[1]);
            Assert.Equal("y", builder[2]);
        }

        /// <summary>
        ///     Tests that Builder RemoveRange with IEnumerable and multiple matching items removes all occurrences
        /// </summary>
        [Fact]
        public void BuilderRemoveRangeIEnumerableWithMultipleMatchingOccurrences()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(8);
            builder.AddRange(1, 2, 2, 3, 2, 4);

            builder.RemoveRange(new[] { 2, 4 });

            Assert.Equal(2, builder.Count);
            Assert.Equal(1, builder[0]);
            Assert.Equal(3, builder[1]);
        }

        /// <summary>
        ///     Tests that Builder LastIndexOf with custom comparer and count zero returns minus one
        /// </summary>
        [Fact]
        public void BuilderLastIndexOfWithZeroCountReturnsMinusOne()
        {
            FastImmutableArray<string>.Builder builder = FastImmutableArray<string>.CreateBuilder<string>(3);
            builder.AddRange("A", "B", "C");

            int index = builder.LastIndexOf("A", 2, 0, StringComparer.OrdinalIgnoreCase);

            Assert.Equal(-1, index);
        }

        /// <summary>
        ///     Tests that Builder IndexOf with custom comparer loop path searches manually
        /// </summary>
        [Fact]
        public void BuilderIndexOfWithCustomComparerLoopPathSearches()
        {
            FastImmutableArray<string>.Builder builder = FastImmutableArray<string>.CreateBuilder<string>(4);
            builder.AddRange("Alpha", "Beta", "Gamma", "Delta");

            int index = builder.IndexOf("beta", 1, 3, StringComparer.OrdinalIgnoreCase);

            Assert.Equal(1, index);
        }
    }
}
