// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastImmutableArrayTest.cs
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
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Collections;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Collections
{
    /// <summary>
    ///     The fast immutable array test class
    /// </summary>
    public class FastImmutableArrayTest
    {
        /// <summary>
        ///     Tests that empty has expected state
        /// </summary>
        [Fact]
        public void Empty_HasExpectedState()
        {
            FastImmutableArray<int> empty = FastImmutableArray<int>.Empty;

            Assert.False(empty.IsDefault);
            Assert.True(empty.IsEmpty);
            Assert.True(empty.IsDefaultOrEmpty);
            Assert.Equal(0, empty.Length);
        }

        /// <summary>
        ///     Tests that indexer and item ref return expected element
        /// </summary>
        [Fact]
        public void IndexerAndItemRef_ReturnExpectedElement()
        {
            FastImmutableArray<int> array = new FastImmutableArray<int>(new[] {3, 5, 8});

            ref readonly int itemRef = ref array.ItemRef(1);

            Assert.Equal(5, array[1]);
            Assert.Equal(5, itemRef);
        }

        /// <summary>
        ///     Tests that equality uses underlying array reference
        /// </summary>
        [Fact]
        public void Equality_UsesUnderlyingArrayReference()
        {
            int[] backing = {1, 2, 3};
            FastImmutableArray<int> first = new FastImmutableArray<int>(backing);
            FastImmutableArray<int> second = new FastImmutableArray<int>(backing);
            FastImmutableArray<int> third = new FastImmutableArray<int>(new[] {1, 2, 3});

            Assert.True(first == second);
            Assert.False(first != second);
            Assert.False(first == third);
            Assert.True(first != third);
            Assert.Equal(first.GetHashCode(), second.GetHashCode());
        }

        /// <summary>
        ///     Tests that copy to copies content in order
        /// </summary>
        [Fact]
        public void CopyTo_CopiesContentInOrder()
        {
            FastImmutableArray<int> array = new FastImmutableArray<int>(new[] {10, 20, 30});
            int[] destination = new int[5];

            array.CopyTo(destination, 1);

            Assert.Equal(new[] {0, 10, 20, 30, 0}, destination);
        }

        /// <summary>
        ///     Tests that builder add insert remove updates count and order
        /// </summary>
        [Fact]
        public void Builder_AddInsertRemove_UpdatesCountAndOrder()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);
            builder.Add(1);
            builder.Add(3);
            builder.Insert(1, 2);
            builder.Remove(3);

            Assert.Equal(2, builder.Count);
            Assert.Equal(1, builder[0]);
            Assert.Equal(2, builder[1]);
            Assert.True(builder.Contains(2));
            Assert.Equal(1, builder.IndexOf(2));
        }

        /// <summary>
        ///     Tests that builder move to immutable requires capacity equal count
        /// </summary>
        [Fact]
        public void Builder_MoveToImmutable_RequiresCapacityEqualCount()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(4);
            builder.Add(1);
            builder.Add(2);

            Assert.Throws<InvalidOperationException>(() => builder.MoveToImmutable());
        }

        /// <summary>
        ///     Tests that builder move to immutable with matching capacity and count succeeds and resets builder
        /// </summary>
        [Fact]
        public void Builder_MoveToImmutable_WithMatchingCapacityAndCount_SucceedsAndResetsBuilder()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);
            builder.Add(10);
            builder.Add(20);

            FastImmutableArray<int> immutable = builder.MoveToImmutable();

            Assert.Equal(2, immutable.Length);
            Assert.Equal(10, immutable[0]);
            Assert.Equal(20, immutable[1]);
            Assert.Equal(0, builder.Count);
        }

        /// <summary>
        ///     Tests that builder indexer out of range throws
        /// </summary>
        [Fact]
        public void Builder_Indexer_OutOfRange_Throws()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(1);
            builder.Add(5);

            Assert.Throws<ArgumentOutOfRangeException>(() => _ = builder[1]);
            Assert.Throws<ArgumentOutOfRangeException>(() => builder[1] = 9);
        }

        /// <summary>
        ///     Tests that builder remove range removes expected segment
        /// </summary>
        [Fact]
        public void Builder_RemoveRange_RemovesExpectedSegment()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(5);
            builder.AddRange(1, 2, 3, 4, 5);

            builder.RemoveRange(1, 2);

            Assert.Equal(3, builder.Count);
            Assert.Equal(1, builder[0]);
            Assert.Equal(4, builder[1]);
            Assert.Equal(5, builder[2]);
        }

        /// <summary>
        ///     Tests that default instance as i enumerable throws invalid operation
        /// </summary>
        [Fact]
        public void DefaultInstance_AsIEnumerable_ThrowsInvalidOperation()
        {
            FastImmutableArray<int> defaultArray = default(FastImmutableArray<int>);

            Assert.Throws<InvalidOperationException>(() => ((IEnumerable<int>) defaultArray).GetEnumerator());
        }

        /// <summary>
        ///     Tests that builder clear resets count
        /// </summary>
        [Fact]
        public void Builder_Clear_ResetsCount()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);
            builder.Add(1);
            builder.Add(2);

            builder.Clear();

            Assert.Equal(0, builder.Count);
        }

        /// <summary>
        ///     Tests that builder to array returns empty array when empty
        /// </summary>
        [Fact]
        public void Builder_ToArray_WhenEmpty_ReturnsEmptyArray()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);

            Assert.Empty(builder.ToArray());
        }

        /// <summary>
        ///     Tests that builder to array returns copy of elements
        /// </summary>
        [Fact]
        public void Builder_ToArray_WhenNotEmpty_ReturnsCopy()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);
            builder.Add(1);
            builder.Add(2);

            int[] result = builder.ToArray();

            Assert.Equal(2, result.Length);
            Assert.Equal(1, result[0]);
            Assert.Equal(2, result[1]);
        }

        /// <summary>
        ///     Tests that builder to immutable returns copy
        /// </summary>
        [Fact]
        public void Builder_ToImmutable_ReturnsCopy()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);
            builder.Add(1);
            builder.Add(2);

            FastImmutableArray<int> immutable = builder.ToImmutable();

            Assert.Equal(2, immutable.Length);
            Assert.Equal(1, immutable[0]);
            Assert.Equal(2, immutable[1]);
        }

        /// <summary>
        ///     Tests that builder drain to immutable when capacity equals count extracts internal array
        /// </summary>
        [Fact]
        public void Builder_DrainToImmutable_WhenCapacityEqualsCount_ExtractsInternalArray()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);
            builder.Add(1);
            builder.Add(2);

            FastImmutableArray<int> immutable = builder.DrainToImmutable();

            Assert.Equal(2, immutable.Length);
            Assert.Equal(1, immutable[0]);
            Assert.Equal(2, immutable[1]);
            Assert.Equal(0, builder.Count);
        }

        /// <summary>
        ///     Tests that builder drain to immutable when capacity not equals count copies contents
        /// </summary>
        [Fact]
        public void Builder_DrainToImmutable_WhenCapacityNotEqualsCount_CopiesContents()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(4);
            builder.Add(1);
            builder.Add(2);

            FastImmutableArray<int> immutable = builder.DrainToImmutable();

            Assert.Equal(2, immutable.Length);
            Assert.Equal(1, immutable[0]);
            Assert.Equal(2, immutable[1]);
            Assert.Equal(0, builder.Count);
        }

        /// <summary>
        ///     Tests that builder capacity set to less than count throws
        /// </summary>
        [Fact]
        public void Builder_Capacity_SetToLessThanCount_Throws()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);
            builder.Add(1);
            builder.Add(2);

            Assert.Throws<ArgumentException>(() => builder.Capacity = 1);
        }

        /// <summary>
        ///     Tests that builder capacity set to zero uses empty array
        /// </summary>
        [Fact]
        public void Builder_Capacity_SetToZero_UsesEmptyArray()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);
            builder.Clear();

            builder.Capacity = 0;

            Assert.Equal(0, builder.Capacity);
        }

        /// <summary>
        ///     Tests that builder capacity set to larger reallocates
        /// </summary>
        [Fact]
        public void Builder_Capacity_SetToLarger_Reallocates()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);
            builder.Add(1);
            builder.Add(2);

            builder.Capacity = 5;

            Assert.Equal(5, builder.Capacity);
            Assert.Equal(1, builder[0]);
            Assert.Equal(2, builder[1]);
        }

        /// <summary>
        ///     Tests that builder capacity with non zero count reallocates and preserves
        /// </summary>
        [Fact]
        public void Builder_Capacity_WithNonZeroCount_ReallocatesAndPreserves()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(1);
            builder.Add(42);

            builder.Capacity = 3;

            Assert.Equal(3, builder.Capacity);
            Assert.Equal(42, builder[0]);
        }

        /// <summary>
        ///     Tests that builder index of with start index finds element
        /// </summary>
        [Fact]
        public void Builder_IndexOf_WithStartIndex_FindsElement()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(4);
            builder.AddRange(1, 2, 3, 2);

            int index = builder.IndexOf(2, 2);

            Assert.Equal(3, index);
        }

        /// <summary>
        ///     Tests that builder index of not found returns minus one
        /// </summary>
        [Fact]
        public void Builder_IndexOf_NotFound_ReturnsMinusOne()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);
            builder.AddRange(1, 2);

            Assert.Equal(-1, builder.IndexOf(3));
        }

        /// <summary>
        ///     Tests that builder index of with custom comparer finds element
        /// </summary>
        [Fact]
        public void Builder_IndexOf_WithCustomComparer_FindsElement()
        {
            FastImmutableArray<string>.Builder builder = FastImmutableArray<string>.CreateBuilder<string>(2);
            builder.AddRange("A", "B");

            int index = builder.IndexOf("a", 0, 2, StringComparer.OrdinalIgnoreCase);

            Assert.Equal(0, index);
        }

        /// <summary>
        ///     Tests that builder index of with null comparer uses default
        /// </summary>
        [Fact]
        public void Builder_IndexOf_WithNullComparer_UsesDefault()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);
            builder.AddRange(1, 2);

            int index = builder.IndexOf(1, 0, 2, null);

            Assert.Equal(0, index);
        }

        /// <summary>
        ///     Tests that builder last index of finds element
        /// </summary>
        [Fact]
        public void Builder_LastIndexOf_FindsElement()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(4);
            builder.AddRange(1, 2, 3, 2);

            int index = builder.LastIndexOf(2);

            Assert.Equal(3, index);
        }

        /// <summary>
        ///     Tests that builder last index of when empty returns minus one
        /// </summary>
        [Fact]
        public void Builder_LastIndexOf_WhenEmpty_ReturnsMinusOne()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);

            Assert.Equal(-1, builder.LastIndexOf(1));
        }

        /// <summary>
        ///     Tests that builder last index of with start index finds element
        /// </summary>
        [Fact]
        public void Builder_LastIndexOf_WithStartIndex_FindsElement()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(4);
            builder.AddRange(1, 2, 3, 2);

            int index = builder.LastIndexOf(2, 2);

            Assert.Equal(1, index);
        }

        /// <summary>
        ///     Tests that builder last index of with range finds element
        /// </summary>
        [Fact]
        public void Builder_LastIndexOf_WithRange_FindsElement()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(4);
            builder.AddRange(1, 2, 3, 2);

            int index = builder.LastIndexOf(2, 3, 4);

            Assert.Equal(3, index);
        }

        /// <summary>
        ///     Tests that builder last index of with custom comparer finds element
        /// </summary>
        [Fact]
        public void Builder_LastIndexOf_WithCustomComparer_FindsElement()
        {
            FastImmutableArray<string>.Builder builder = FastImmutableArray<string>.CreateBuilder<string>(3);
            builder.AddRange("A", "B", "A");

            int index = builder.LastIndexOf("a", 2, 3, StringComparer.OrdinalIgnoreCase);

            Assert.Equal(2, index);
        }

        /// <summary>
        ///     Tests that builder remove not found returns false
        /// </summary>
        [Fact]
        public void Builder_Remove_NotFound_ReturnsFalse()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);
            builder.AddRange(1, 2);

            Assert.False(builder.Remove(3));
        }

        /// <summary>
        ///     Tests that builder remove with custom comparer removes element
        /// </summary>
        [Fact]
        public void Builder_Remove_WithCustomComparer_RemovesElement()
        {
            FastImmutableArray<string>.Builder builder = FastImmutableArray<string>.CreateBuilder<string>(2);
            builder.AddRange("A", "B");

            Assert.True(builder.Remove("a", StringComparer.OrdinalIgnoreCase));
            Assert.Equal(1, builder.Count);
            Assert.Equal("B", builder[0]);
        }

        /// <summary>
        ///     Tests that builder remove with custom comparer not found returns false
        /// </summary>
        [Fact]
        public void Builder_Remove_WithCustomComparer_NotFound_ReturnsFalse()
        {
            FastImmutableArray<string>.Builder builder = FastImmutableArray<string>.CreateBuilder<string>(2);
            builder.AddRange("A", "B");

            Assert.False(builder.Remove("C", StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        ///     Tests that builder remove at last element does not copy
        /// </summary>
        [Fact]
        public void Builder_RemoveAt_LastElement_DoesNotCopy()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);
            builder.AddRange(1, 2);

            builder.RemoveAt(1);

            Assert.Equal(1, builder.Count);
            Assert.Equal(1, builder[0]);
        }

        /// <summary>
        ///     Tests that builder remove all with predicate removes matching elements
        /// </summary>
        [Fact]
        public void Builder_RemoveAll_WithPredicate_RemovesMatchingElements()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(5);
            builder.AddRange(1, 2, 3, 4, 5);

            builder.RemoveAll(x => x % 2 == 0);

            Assert.Equal(3, builder.Count);
            Assert.Equal(1, builder[0]);
            Assert.Equal(3, builder[1]);
            Assert.Equal(5, builder[2]);
        }

        /// <summary>
        ///     Tests that builder remove all with no match does nothing
        /// </summary>
        [Fact]
        public void Builder_RemoveAll_WithNoMatch_DoesNothing()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(3);
            builder.AddRange(1, 2, 3);

            builder.RemoveAll(x => x > 10);

            Assert.Equal(3, builder.Count);
        }

        /// <summary>
        ///     Tests that builder remove range with enumerable removes all occurrences
        /// </summary>
        [Fact]
        public void Builder_RemoveRange_WithEnumerable_RemovesAllOccurrences()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(5);
            builder.AddRange(1, 2, 3, 2, 4);

            builder.RemoveRange(new[] { 2 });

            Assert.Equal(3, builder.Count);
            Assert.Equal(1, builder[0]);
            Assert.Equal(3, builder[1]);
            Assert.Equal(4, builder[2]);
        }

        /// <summary>
        ///     Tests that builder remove range with zero length does nothing
        /// </summary>
        [Fact]
        public void Builder_RemoveRange_ZeroLength_DoesNothing()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(3);
            builder.AddRange(1, 2, 3);

            builder.RemoveRange(1, 0);

            Assert.Equal(3, builder.Count);
        }

        /// <summary>
        ///     Tests that builder reverse reverses elements
        /// </summary>
        [Fact]
        public void Builder_Reverse_ReversesElements()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(3);
            builder.AddRange(1, 2, 3);

            builder.Reverse();

            Assert.Equal(3, builder[0]);
            Assert.Equal(2, builder[1]);
            Assert.Equal(1, builder[2]);
        }

        /// <summary>
        ///     Tests that builder sort default sorts ascending
        /// </summary>
        [Fact]
        public void Builder_Sort_Default_SortsAscending()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(3);
            builder.AddRange(3, 1, 2);

            builder.Sort();

            Assert.Equal(1, builder[0]);
            Assert.Equal(2, builder[1]);
            Assert.Equal(3, builder[2]);
        }

        /// <summary>
        ///     Tests that builder sort single element does nothing
        /// </summary>
        [Fact]
        public void Builder_Sort_SingleElement_DoesNothing()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(1);
            builder.Add(42);

            builder.Sort();

            Assert.Equal(42, builder[0]);
        }

        /// <summary>
        ///     Tests that builder sort with comparison sorts descending
        /// </summary>
        [Fact]
        public void Builder_Sort_WithComparison_SortsDescending()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(3);
            builder.AddRange(1, 2, 3);

            builder.Sort((a, b) => b.CompareTo(a));

            Assert.Equal(3, builder[0]);
            Assert.Equal(2, builder[1]);
            Assert.Equal(1, builder[2]);
        }

        /// <summary>
        ///     Tests that builder sort with comparer sorts ascending
        /// </summary>
        [Fact]
        public void Builder_Sort_WithComparer_SortsAscending()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(3);
            builder.AddRange(3, 1, 2);

            builder.Sort(Comparer<int>.Default);

            Assert.Equal(1, builder[0]);
            Assert.Equal(2, builder[1]);
            Assert.Equal(3, builder[2]);
        }

        /// <summary>
        ///     Tests that builder sort with range sorts range
        /// </summary>
        [Fact]
        public void Builder_Sort_WithRange_SortsRange()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(5);
            builder.AddRange(5, 3, 1, 4, 2);

            builder.Sort(1, 3, Comparer<int>.Default);

            Assert.Equal(5, builder[0]);
            Assert.Equal(1, builder[1]);
            Assert.Equal(3, builder[2]);
            Assert.Equal(4, builder[3]);
            Assert.Equal(2, builder[4]);
        }

        /// <summary>
        ///     Tests that builder replace existing element replaces value
        /// </summary>
        [Fact]
        public void Builder_Replace_ExistingElement_ReplacesValue()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(3);
            builder.AddRange(1, 2, 3);

            builder.Replace(2, 5);

            Assert.Equal(1, builder[0]);
            Assert.Equal(5, builder[1]);
            Assert.Equal(3, builder[2]);
        }

        /// <summary>
        ///     Tests that builder replace non existing does not modify
        /// </summary>
        [Fact]
        public void Builder_Replace_NonExisting_DoesNotModify()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);
            builder.AddRange(1, 2);

            builder.Replace(3, 5);

            Assert.Equal(1, builder[0]);
            Assert.Equal(2, builder[1]);
        }

        /// <summary>
        ///     Tests that builder replace with custom comparer replaces value
        /// </summary>
        [Fact]
        public void Builder_Replace_WithCustomComparer_ReplacesValue()
        {
            FastImmutableArray<string>.Builder builder = FastImmutableArray<string>.CreateBuilder<string>(2);
            builder.AddRange("A", "B");

            builder.Replace("a", "C", StringComparer.OrdinalIgnoreCase);

            Assert.Equal("C", builder[0]);
            Assert.Equal("B", builder[1]);
        }

        /// <summary>
        ///     Tests that builder insert range empty does nothing
        /// </summary>
        [Fact]
        public void Builder_InsertRange_Empty_DoesNothing()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);
            builder.AddRange(1, 2);

            builder.InsertRange(1, FastImmutableArray<int>.Empty);

            Assert.Equal(2, builder.Count);
        }

        /// <summary>
        ///     Tests that builder insert range at beginning shifts elements
        /// </summary>
        [Fact]
        public void Builder_InsertRange_AtBeginning_ShiftsElements()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(4);
            builder.AddRange(3, 4);

            builder.InsertRange(0, new FastImmutableArray<int>(new[] { 1, 2 }));

            Assert.Equal(4, builder.Count);
            Assert.Equal(1, builder[0]);
            Assert.Equal(2, builder[1]);
            Assert.Equal(3, builder[2]);
            Assert.Equal(4, builder[3]);
        }

        /// <summary>
        ///     Tests that builder insert range at end appends elements
        /// </summary>
        [Fact]
        public void Builder_InsertRange_AtEnd_AppendsElements()
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
        ///     Tests that builder add range params array appends elements
        /// </summary>
        [Fact]
        public void Builder_AddRange_ParamsArray_AppendsElements()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(3);
            builder.AddRange(1, 2, 3);

            Assert.Equal(3, builder.Count);
            Assert.Equal(1, builder[0]);
            Assert.Equal(2, builder[1]);
            Assert.Equal(3, builder[2]);
        }

        /// <summary>
        ///     Tests that builder add range fast immutable array appends elements
        /// </summary>
        [Fact]
        public void Builder_AddRange_FastImmutableArray_AppendsElements()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);
            builder.Add(1);

            builder.AddRange(new FastImmutableArray<int>(new[] { 2, 3 }));

            Assert.Equal(3, builder.Count);
            Assert.Equal(1, builder[0]);
            Assert.Equal(2, builder[1]);
            Assert.Equal(3, builder[2]);
        }

        /// <summary>
        ///     Tests that builder add range with length appends up to length
        /// </summary>
        [Fact]
        public void Builder_AddRange_WithLength_AppendsUpToLength()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(3);
            builder.Add(1);

            builder.AddRange(new FastImmutableArray<int>(new[] { 2, 3, 4 }), 2);

            Assert.Equal(3, builder.Count);
            Assert.Equal(1, builder[0]);
            Assert.Equal(2, builder[1]);
            Assert.Equal(3, builder[2]);
        }

        /// <summary>
        ///     Tests that builder add range from builder appends elements
        /// </summary>
        [Fact]
        public void Builder_AddRange_FromBuilder_AppendsElements()
        {
            FastImmutableArray<int>.Builder source = FastImmutableArray<int>.CreateBuilder<int>(2);
            source.AddRange(2, 3);
            FastImmutableArray<int>.Builder target = FastImmutableArray<int>.CreateBuilder<int>(3);
            target.Add(1);

            target.AddRange(source);

            Assert.Equal(3, target.Count);
            Assert.Equal(1, target[0]);
            Assert.Equal(2, target[1]);
            Assert.Equal(3, target[2]);
        }

        /// <summary>
        ///     Tests that builder count set to shrink more than 64 elements uses array clear
        /// </summary>
        [Fact]
        public void Builder_Count_SetToShrinkMoreThan64Elements_UsesArrayClear()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(100);
            for (int i = 0; i < 80; i++)
            {
                builder.Add(i);
            }

            builder.Count = 10;

            Assert.Equal(10, builder.Count);
        }

        /// <summary>
        ///     Tests that builder count set to grow expands capacity
        /// </summary>
        [Fact]
        public void Builder_Count_SetToGrow_ExpandsCapacity()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);
            builder.AddRange(1, 2);

            builder.Count = 5;

            Assert.Equal(5, builder.Count);
            Assert.Equal(1, builder[0]);
            Assert.Equal(2, builder[1]);
        }

        /// <summary>
        ///     Tests that builder item ref returns reference to element
        /// </summary>
        [Fact]
        public void Builder_ItemRef_ReturnsReferenceToElement()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);
            builder.AddRange(1, 2);

            ref readonly int item = ref builder.ItemRef(1);

            Assert.Equal(2, item);
        }

        /// <summary>
        ///     Tests that builder item ref invalid index throws
        /// </summary>
        [Fact]
        public void Builder_ItemRef_InvalidIndex_Throws()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(1);
            builder.Add(5);

            Assert.Throws<ArgumentOutOfRangeException>(() => builder.ItemRef(1));
        }

        /// <summary>
        ///     Tests that builder copy to overloads copy correctly
        /// </summary>
        [Fact]
        public void Builder_CopyTo_Overloads_CopyCorrectly()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(3);
            builder.AddRange(1, 2, 3);

            int[] dest1 = new int[3];
            builder.CopyTo(dest1);
            Assert.Equal(new[] { 1, 2, 3 }, dest1);

            int[] dest2 = new int[5];
            builder.CopyTo(dest2, 1);
            Assert.Equal(new[] { 0, 1, 2, 3, 0 }, dest2);

            int[] dest3 = new int[3];
            builder.CopyTo(0, dest3, 0, 3);
            Assert.Equal(new[] { 1, 2, 3 }, dest3);

            int[] dest4 = new int[3];
            builder.CopyTo(new Span<int>(dest4));
            Assert.Equal(new[] { 1, 2, 3 }, dest4);
        }

        /// <summary>
        ///     Tests that fast immutable array remove at valid index removes element
        /// </summary>
        [Fact]
        public void RemoveAt_ValidIndex_RemovesElement()
        {
            FastImmutableArray<int> array = new FastImmutableArray<int>(new[] { 1, 2, 3, 4 });

            FastImmutableArray<int> result = array.RemoveAt<int>(1);

            Assert.Equal(3, result.Length);
            Assert.Equal(1, result[0]);
            Assert.Equal(3, result[1]);
            Assert.Equal(4, result[2]);
        }

        /// <summary>
        ///     Tests that fast immutable array remove at first element shifts
        /// </summary>
        [Fact]
        public void RemoveAt_FirstElement_Shifts()
        {
            FastImmutableArray<int> array = new FastImmutableArray<int>(new[] { 1, 2, 3 });

            FastImmutableArray<int> result = array.RemoveAt<int>(0);

            Assert.Equal(2, result.Length);
            Assert.Equal(2, result[0]);
            Assert.Equal(3, result[1]);
        }

        /// <summary>
        ///     Tests that fast immutable array remove at invalid index throws
        /// </summary>
        [Fact]
        public void RemoveAt_InvalidIndex_Throws()
        {
            FastImmutableArray<int> array = new FastImmutableArray<int>(new[] { 1, 2, 3 });

            Assert.Throws<ArgumentOutOfRangeException>(() => array.RemoveAt<int>(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => array.RemoveAt<int>(3));
        }

        /// <summary>
        ///     Tests that fast immutable array copy to destination copies all
        /// </summary>
        [Fact]
        public void CopyTo_Destination_CopiesAll()
        {
            FastImmutableArray<int> array = new FastImmutableArray<int>(new[] { 1, 2, 3 });
            int[] dest = new int[3];

            array.CopyTo(dest);

            Assert.Equal(new[] { 1, 2, 3 }, dest);
        }

        /// <summary>
        ///     Tests that fast immutable array copy to range copies range
        /// </summary>
        [Fact]
        public void CopyTo_Range_CopiesRange()
        {
            FastImmutableArray<int> array = new FastImmutableArray<int>(new[] { 1, 2, 3, 4, 5 });
            int[] dest = new int[3];

            array.CopyTo(1, dest, 0, 3);

            Assert.Equal(new[] { 2, 3, 4 }, dest);
        }

        /// <summary>
        ///     Tests that equals returns true for same array reference
        /// </summary>
        [Fact]
        public void Equals_WithSameArrayReference_ReturnsTrue()
        {
            int[] backing = { 1, 2, 3 };
            FastImmutableArray<int> first = new FastImmutableArray<int>(backing);
            FastImmutableArray<int> second = new FastImmutableArray<int>(backing);

            Assert.True(first.Equals((object)second));
            Assert.False(first.Equals("not an array"));
        }

        /// <summary>
        ///     Tests that nullable operators compare correctly
        /// </summary>
        [Fact]
        public void NullableOperators_CompareCorrectly()
        {
            int[] backing = { 1, 2 };
            FastImmutableArray<int>? first = new FastImmutableArray<int>(backing);
            FastImmutableArray<int>? second = new FastImmutableArray<int>(backing);
            FastImmutableArray<int>? third = new FastImmutableArray<int>(new[] { 1, 2 });

            Assert.True(first == second);
            Assert.False(first != second);
            Assert.False(first == third);
            Assert.True(first != third);
        }

        /// <summary>
        ///     Tests that index of returns correct index
        /// </summary>
        [Fact]
        public void IndexOf_ReturnsCorrectIndex()
        {
            FastImmutableArray<int> array = new FastImmutableArray<int>(new[] { 10, 20, 30 });

            int index = array.IndexOf<int>(20);

            Assert.Equal(1, index);
        }

        /// <summary>
        ///     Tests that as span returns span
        /// </summary>
        [Fact]
        public void AsSpan_ReturnsSpan()
        {
            FastImmutableArray<int> array = new FastImmutableArray<int>(new[] { 1, 2, 3 });

            ReadOnlySpan<int> span = array.AsSpan();

            Assert.Equal(3, span.Length);
            Assert.Equal(1, span[0]);
        }

        /// <summary>
        ///     Tests that enumerator object reset does not throw
        /// </summary>
        [Fact]
        public void EnumeratorObject_Reset_DoesNotThrow()
        {
            FastImmutableArray<int> array = new FastImmutableArray<int>(new[] { 1, 2, 3 });

            System.Collections.IEnumerable enumerable = array;
            System.Collections.IEnumerator enumerator = enumerable.GetEnumerator();

            enumerator.Reset();
        }

        /// <summary>
        ///     Tests that builder is read only returns false
        /// </summary>
        [Fact]
        public void Builder_IsReadOnly_ReturnsFalse()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(1);
            builder.Add(1);

            bool result = ((System.Collections.Generic.ICollection<int>)builder).IsReadOnly;

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that builder get enumerator returns values
        /// </summary>
        [Fact]
        public void Builder_GetEnumerator_ReturnsValues()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);
            builder.AddRange(1, 2);

            using (System.Collections.Generic.IEnumerator<int> enumerator = ((System.Collections.Generic.IEnumerable<int>)builder).GetEnumerator())
            {
                Assert.True(enumerator.MoveNext());
                Assert.Equal(1, enumerator.Current);
                Assert.True(enumerator.MoveNext());
                Assert.Equal(2, enumerator.Current);
                Assert.False(enumerator.MoveNext());
            }
        }

        /// <summary>
        ///     Tests that builder copy to destination index copies at index
        /// </summary>
        [Fact]
        public void Builder_CopyTo_DestinationIndex_CopiesAtIndex()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);
            builder.AddRange(1, 2);
            int[] dest = new int[4];

            ((System.Collections.Generic.ICollection<int>)builder).CopyTo(dest, 1);

            Assert.Equal(new[] { 0, 1, 2, 0 }, dest);
        }

        /// <summary>
        ///     Tests that builder remove range with enumerable and custom comparer removes elements
        /// </summary>
        [Fact]
        public void Builder_RemoveRange_WithEnumerableAndComparer_RemovesElements()
        {
            FastImmutableArray<string>.Builder builder = FastImmutableArray<string>.CreateBuilder<string>(3);
            builder.AddRange("A", "B", "A");

            builder.RemoveRange(new[] { "a" }, StringComparer.OrdinalIgnoreCase);

            Assert.Single(builder);
            Assert.Equal("B", builder[0]);
        }

        /// <summary>
        ///     Tests that builder add range with length on array appends up to length
        /// </summary>
        [Fact]
        public void Builder_AddRange_ArrayWithLength_AppendsUpToLength()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(3);
            builder.Add(1);

            builder.AddRange(new[] { 2, 3, 4 }, 2);

            Assert.Equal(3, builder.Count);
            Assert.Equal(1, builder[0]);
            Assert.Equal(2, builder[1]);
            Assert.Equal(3, builder[2]);
        }

        /// <summary>
        ///     Tests that builder set item writes value
        /// </summary>
        [Fact]
        public void Builder_SetItem_WritesValue()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);
            builder.AddRange(1, 2);

            builder[0] = 10;

            Assert.Equal(10, builder[0]);
        }

        /// <summary>
        ///     Tests that builder add range with derived types appends
        /// </summary>
        [Fact]
        public void Builder_AddRange_DerivedTypes_Appends()
        {
            FastImmutableArray<object>.Builder builder = FastImmutableArray<object>.CreateBuilder<object>(2);
            builder.AddRange(new string[] { "a", "b" });

            Assert.Equal(2, builder.Count);
            Assert.Equal("a", builder[0]);
            Assert.Equal("b", builder[1]);
        }

        /// <summary>
        ///     Tests that builder add range with derived fast immutable array appends
        /// </summary>
        [Fact]
        public void Builder_AddRange_DerivedFastImmutableArray_Appends()
        {
            var source = new FastImmutableArray<string>(new[] { "a", "b" });
            FastImmutableArray<object>.Builder builder = FastImmutableArray<object>.CreateBuilder<object>(2);
            builder.Add(1);

            builder.AddRange<string>(new FastImmutableArray<string>(new[] { "a", "b" }));

            Assert.Equal(3, builder.Count);
        }

        /// <summary>
        ///     Tests that builder add range with derived builder appends
        /// </summary>
        [Fact]
        public void Builder_AddRange_DerivedBuilder_Appends()
        {
            FastImmutableArray<string>.Builder source = FastImmutableArray<string>.CreateBuilder<string>(2);
            source.AddRange("a", "b");
            FastImmutableArray<object>.Builder builder = FastImmutableArray<object>.CreateBuilder<object>(3);
            builder.Add(1);

            builder.AddRange<string>(source);

            Assert.Equal(3, builder.Count);
        }

        /// <summary>
        ///     Tests that builder last index of with empty range returns minus one
        /// </summary>
        [Fact]
        public void Builder_LastIndexOf_EmptyRange_ReturnsMinusOne()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);
            builder.Add(1);

            int index = builder.LastIndexOf(1, 0, 0);

            Assert.Equal(-1, index);
        }

        /// <summary>
        ///     Tests that fast immutable array cast up casts to base type
        /// </summary>
        [Fact]
        public void CastUp_CastsToBaseType()
        {
            FastImmutableArray<string> derived = new FastImmutableArray<string>(new[] { "a" });

            FastImmutableArray<object> baseType = FastImmutableArray<object>.CastUp<string>(derived);

            Assert.Equal(1, baseType.Length);
            Assert.Equal("a", baseType[0]);
        }

        /// <summary>
        ///     Tests that fast immutable array default instance has correct state
        /// </summary>
        [Fact]
        public void DefaultInstance_HasCorrectState()
        {
            FastImmutableArray<int> defaultArray = default;

            Assert.True(defaultArray.IsDefault);
            Assert.True(defaultArray.IsDefaultOrEmpty);
            Assert.Equal(0, defaultArray.GetHashCode());
        }

        /// <summary>
        ///     Tests that builder last index of with custom comparer and non matching default returns minus one
        /// </summary>
        [Fact]
        public void Builder_LastIndexOf_WithCustomComparer_NonDefaultComparer_SearchesManually()
        {
            FastImmutableArray<string>.Builder builder = FastImmutableArray<string>.CreateBuilder<string>(3);
            builder.AddRange("A", "B", "C");

            int index = builder.LastIndexOf("b", 2, 3, StringComparer.OrdinalIgnoreCase);

            Assert.Equal(1, index);
        }

        /// <summary>
        ///     Tests that fast immutable array cast array casts element type
        /// </summary>
        [Fact]
        public void CastArray_CastsElementType()
        {
            FastImmutableArray<object> array = new FastImmutableArray<object>(new string[] { "a", "b" });

            FastImmutableArray<string> cast = array.CastArray<string>();

            Assert.Equal(2, cast.Length);
            Assert.Equal("a", cast[0]);
            Assert.Equal("b", cast[1]);
        }

        /// <summary>
        ///     Tests that as returns null when cast fails
        /// </summary>
        [Fact]
        public void As_WhenCastFails_ReturnsDefaultArray()
        {
            FastImmutableArray<object> array = new FastImmutableArray<object>(new object[] { 1, 2 });

            FastImmutableArray<string> result = array.As<string>();

            Assert.True(result.IsDefault);
        }

        /// <summary>
        ///     Tests that as returns cast array when successful
        /// </summary>
        [Fact]
        public void As_WhenCastSucceeds_ReturnsCastArray()
        {
            FastImmutableArray<object> array = new FastImmutableArray<object>(new string[] { "a" });

            FastImmutableArray<string> result = array.As<string>();

            Assert.Equal(1, result.Length);
            Assert.Equal("a", result[0]);
        }

        /// <summary>
        ///     Tests that builder remove range with reference type clears array
        /// </summary>
        [Fact]
        public void Builder_RemoveRange_ReferenceType_ClearsArray()
        {
            FastImmutableArray<string>.Builder builder = FastImmutableArray<string>.CreateBuilder<string>(3);
            builder.AddRange("A", "B", "C");

            builder.RemoveRange(0, 3);

            Assert.Equal(0, builder.Count);
        }

        /// <summary>
        ///     Tests that builder as memory returns memory over filled portion
        /// </summary>
        [Fact]
        public void Builder_AsMemory_ReturnsMemory()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(5);
            builder.AddRange(1, 2, 3);

            System.Memory<int> memory = builder.AsMemory();

            Assert.Equal(3, memory.Length);
            Assert.Equal(1, memory.Span[0]);
        }

        /// <summary>
        ///     Tests that enumerating non default array through i enumerable generic interface succeeds
        /// </summary>
        [Fact]
        public void Enumerate_ThroughIEnumerableGeneric_Succeeds()
        {
            FastImmutableArray<int> array = new FastImmutableArray<int>(new[] { 1, 2, 3 });

            using (System.Collections.Generic.IEnumerator<int> enumerator = ((System.Collections.Generic.IEnumerable<int>)array).GetEnumerator())
            {
                Assert.True(enumerator.MoveNext());
                Assert.Equal(1, enumerator.Current);
                Assert.True(enumerator.MoveNext());
                Assert.Equal(2, enumerator.Current);
                Assert.True(enumerator.MoveNext());
                Assert.Equal(3, enumerator.Current);
                Assert.False(enumerator.MoveNext());
                Assert.False(enumerator.MoveNext());
                Assert.Throws<InvalidOperationException>(() => enumerator.Current);
            }
        }

        /// <summary>
        ///     Tests that enumerating non default array through i enumerable non generic interface succeeds
        /// </summary>
        [Fact]
        public void Enumerate_ThroughIEnumerableNonGeneric_Succeeds()
        {
            FastImmutableArray<int> array = new FastImmutableArray<int>(new[] { 1, 2 });

            System.Collections.IEnumerator enumerator = ((System.Collections.IEnumerable)array).GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.Equal(1, (int)enumerator.Current);
            enumerator.Reset();
            Assert.True(enumerator.MoveNext());
            Assert.Equal(1, (int)enumerator.Current);
        }

        /// <summary>
        ///     Tests that enumerating empty array through i enumerable returns empty enumerator
        /// </summary>
        [Fact]
        public void Enumerate_EmptyArray_ThroughIEnumerable_ReturnsEmpty()
        {
            FastImmutableArray<int> array = new FastImmutableArray<int>(new int[0]);

            using (System.Collections.Generic.IEnumerator<int> enumerator = ((System.Collections.Generic.IEnumerable<int>)array).GetEnumerator())
            {
                Assert.False(enumerator.MoveNext());
            }
        }

        /// <summary>
        ///     Tests that builder last index of with empty builder returns minus one
        /// </summary>
        [Fact]
        public void Builder_LastIndexOf_WithEmptyBuilder_ReturnsMinusOne()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);

            Assert.Equal(-1, builder.LastIndexOf(1, 0));
        }

        /// <summary>
        ///     Tests that builder remove range with reference type and middle index clears and shifts
        /// </summary>
        [Fact]
        public void Builder_RemoveRange_ReferenceType_MiddleIndex_ClearsAndShifts()
        {
            FastImmutableArray<string>.Builder builder = FastImmutableArray<string>.CreateBuilder<string>(3);
            builder.AddRange("A", "B", "C");

            builder.RemoveRange(1, 1);

            Assert.Equal(2, builder.Count);
            Assert.Equal("A", builder[0]);
            Assert.Equal("C", builder[1]);
        }

        /// <summary>
        ///     Tests that builder index of with null comparer and non matching entries searches manually
        /// </summary>
        [Fact]
        public void Builder_IndexOf_WithNullComparer_NonMatchingEntries_SearchesManually()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);
            builder.AddRange(5, 10);

            int index = builder.IndexOf(10, 0, 2, null);

            Assert.Equal(1, index);
        }

        /// <summary>
        ///     Tests that builder remove at range with single removal removes element
        /// </summary>
        [Fact]
        public void Builder_RemoveRange_SingleElement_RemovesElement()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(3);
            builder.AddRange(1, 2, 3);

            builder.Remove(2);

            Assert.Equal(2, builder.Count);
            Assert.Equal(1, builder[0]);
            Assert.Equal(3, builder[1]);
        }

        /// <summary>
        ///     Tests that builder index of with empty range returns minus one
        /// </summary>
        [Fact]
        public void Builder_IndexOf_EmptyRange_ReturnsMinusOne()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);

            int index = builder.IndexOf(1, 0, 0, null);

            Assert.Equal(-1, index);
        }

        /// <summary>
        ///     Tests that builder last index of with null comparer uses default
        /// </summary>
        [Fact]
        public void Builder_LastIndexOf_WithNullComparer_UsesDefault()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);
            builder.Add(1);

            int index = builder.LastIndexOf(1, 0, 1, null);

            Assert.Equal(0, index);
        }

        /// <summary>
        ///     Tests that builder last index of with custom comparer and no match returns minus one
        /// </summary>
        [Fact]
        public void Builder_LastIndexOf_WithCustomComparer_NotFound_ReturnsMinusOne()
        {
            FastImmutableArray<string>.Builder builder = FastImmutableArray<string>.CreateBuilder<string>(2);
            builder.Add("A");

            int index = builder.LastIndexOf("b", 0, 1, StringComparer.OrdinalIgnoreCase);

            Assert.Equal(-1, index);
        }

        /// <summary>
        ///     Tests that builder remove range with empty enumerable does nothing
        /// </summary>
        [Fact]
        public void Builder_RemoveRange_EmptyEnumerable_DoesNothing()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(2);
            builder.Add(1);

            builder.RemoveRange(System.Array.Empty<int>(), EqualityComparer<int>.Default);

            Assert.Equal(1, builder.Count);
        }
    }
}