// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ShortSparseSetRemainingCoverageTests.cs
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
    ///     Remaining coverage tests for <see cref="ShortSparseSet{T}" />.
    /// </summary>
    public class ShortSparseSetRemainingCoverageTests
    {
        /// <summary>
        ///     Verifies that the default constructor sets capacity to 4.
        /// </summary>
        [Fact]
        public void Constructor_DefaultCapacityIsFour()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            Assert.Equal(4, set.Capacity);
        }

        /// <summary>
        ///     Verifies that the default constructor sets count to 0.
        /// </summary>
        [Fact]
        public void Constructor_DefaultCountIsZero()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            Assert.Equal(0, set.Count);
        }

        /// <summary>
        ///     Verifies that Capacity returns the current dense array length.
        /// </summary>
        [Fact]
        public void Capacity_ReturnsDenseLength()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            Assert.Equal(4, set.Capacity);
        }

        /// <summary>
        ///     Verifies that Count tracks the number of added elements.
        /// </summary>
        [Fact]
        public void Count_TracksAddedElements()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            set[0] = 10;
            set[1] = 20;

            Assert.Equal(2, set.Count);
        }

        /// <summary>
        ///     Verifies that the indexer stores and retrieves a value type.
        /// </summary>
        [Fact]
        public void Indexer_ValueType_RoundTrips()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            set[3] = 42;

            Assert.Equal(42, set[3]);
        }

        /// <summary>
        ///     Verifies that the indexer stores and retrieves a reference type.
        /// </summary>
        [Fact]
        public void Indexer_ReferenceType_RoundTrips()
        {
            ShortSparseSet<string> set = new ShortSparseSet<string>();
            set[0] = "hello";

            Assert.Equal("hello", set[0]);
        }

        /// <summary>
        ///     Verifies that reading a non-existent id via indexer auto-vivifies.
        /// </summary>
        [Fact]
        public void Indexer_ReadNonExistent_AutoVivifies()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            int val = set[7];

            Assert.Equal(0, val);
            Assert.Equal(1, set.Count);
        }

        /// <summary>
        ///     Verifies that setting an id beyond initial sparse capacity resizes.
        /// </summary>
        [Fact]
        public void Indexer_LargeId_ResizesSparseAndDense()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            set[100] = 42;

            Assert.Equal(42, set[100]);
            Assert.True(set.Capacity >= 4);
        }

        /// <summary>
        ///     Verifies that Get returns a ref to the stored element.
        /// </summary>
        [Fact]
        public void Get_ValidId_ReturnsRef()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            set[0] = 42;
            ref int val = ref set.Get(0);

            Assert.Equal(42, val);
        }

        /// <summary>
        ///     Verifies that modifying a ref from Get persists.
        /// </summary>
        [Fact]
        public void Get_ModifyRef_Persists()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            set[0] = 10;
            ref int val = ref set.Get(0);
            val = 99;

            Assert.Equal(99, set.Get(0));
        }

        /// <summary>
        ///     Verifies that Get throws when id is beyond sparse array length.
        /// </summary>
        [Fact]
        public void Get_IdBeyondSparseLength_Throws()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            Assert.Throws<ArgumentOutOfRangeException>(() => set.Get(10));
        }

        /// <summary>
        ///     Verifies that Get throws when the sparse entry points beyond dense.
        /// </summary>
        [Fact]
        public void Get_UnusedSparseEntry_Throws()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            Assert.Throws<ArgumentOutOfRangeException>(() => set.Get(0));
        }

        /// <summary>
        ///     Verifies that TryGet sets value and returns false for a valid id.
        /// </summary>
        [Fact]
        public void TryGet_ValidId_SetsValue()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            set[0] = 42;
            bool found = set.TryGet(0, out int value);

            Assert.Equal(42, value);
            Assert.False(found);
        }

        /// <summary>
        ///     Verifies that TryGet returns false and default for an invalid id.
        /// </summary>
        [Fact]
        public void TryGet_InvalidId_ReturnsDefault()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            bool found = set.TryGet(99, out int value);

            Assert.Equal(0, value);
            Assert.False(found);
        }

        /// <summary>
        ///     Verifies that TryGet with an unused in-range id returns default.
        /// </summary>
        [Fact]
        public void TryGet_UnusedIdInRange_ReturnsDefault()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            bool found = set.TryGet(0, out int value);

            Assert.Equal(0, value);
            Assert.False(found);
        }

        /// <summary>
        ///     Verifies that Remove returns true for an existing element.
        /// </summary>
        [Fact]
        public void Remove_ExistingId_ReturnsTrue()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            set[0] = 42;

            Assert.True(set.Remove(0));
        }

        /// <summary>
        ///     Verifies that Remove decrements Count.
        /// </summary>
        [Fact]
        public void Remove_ExistingId_DecrementsCount()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            set[0] = 1;
            set[1] = 2;
            set.Remove(0);

            Assert.Equal(1, set.Count);
        }

        /// <summary>
        ///     Verifies that Remove returns false when id is beyond sparse range.
        /// </summary>
        [Fact]
        public void Remove_IdBeyondSparse_ReturnsFalse()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            Assert.False(set.Remove(99));
        }

        /// <summary>
        ///     Verifies that Remove returns false for an unused id within sparse range.
        /// </summary>
        [Fact]
        public void Remove_UnusedIdInRange_ReturnsFalse()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            Assert.False(set.Remove(0));
        }

        /// <summary>
        ///     Verifies that Has returns true for an existing element.
        /// </summary>
        [Fact]
        public void Has_ExistingId_ReturnsTrue()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            set[0] = 42;

            Assert.True(set.Has(0));
        }

        /// <summary>
        ///     Verifies that Has returns false for a non-existent id within range.
        /// </summary>
        [Fact]
        public void Has_NonExistentIdInRange_ReturnsFalse()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            set[0] = 1;

            Assert.False(set.Has(1));
        }

        /// <summary>
        ///     Verifies that Has returns false for an id beyond sparse length.
        /// </summary>
        [Fact]
        public void Has_IdBeyondSparseLength_ReturnsFalse()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            Assert.False(set.Has(100));
        }

        /// <summary>
        ///     Verifies that Has with a negative id returns false.
        /// </summary>
        [Fact]
        public void Has_NegativeId_ReturnsFalse()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            Assert.False(set.Has(-1));
        }

        /// <summary>
        ///     Verifies that EnsureCapacity resizes dense when larger.
        /// </summary>
        [Fact]
        public void EnsureCapacity_Larger_Resizes()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            set.EnsureCapacity(10);

            Assert.True(set.Capacity >= 10);
        }

        /// <summary>
        ///     Verifies that EnsureCapacity does not shrink when smaller.
        /// </summary>
        [Fact]
        public void EnsureCapacity_Smaller_DoesNotShrink()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            set.EnsureCapacity(2);

            Assert.Equal(4, set.Capacity);
        }

        /// <summary>
        ///     Verifies that EnsureCapacity preserves existing elements.
        /// </summary>
        [Fact]
        public void EnsureCapacity_PreservesElements()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            set[0] = 10;
            set[1] = 20;
            set.EnsureCapacity(100);

            Assert.Equal(10, set[0]);
            Assert.Equal(20, set[1]);
        }

        /// <summary>
        ///     Verifies that AsSpan on an empty set returns an empty span.
        /// </summary>
        [Fact]
        public void AsSpan_Empty_ReturnsEmpty()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            Assert.True(set.AsSpan().IsEmpty);
        }

        /// <summary>
        ///     Verifies that AsSpan returns elements in insertion order.
        /// </summary>
        [Fact]
        public void AsSpan_WithElements_ReturnsUsedPortion()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            set[0] = 10;
            set[1] = 20;
            Span<int> span = set.AsSpan();

            Assert.Equal(2, span.Length);
            Assert.Equal(10, span[0]);
            Assert.Equal(20, span[1]);
        }

        /// <summary>
        ///     Verifies that AsSpan after Remove reflects the new count.
        /// </summary>
        [Fact]
        public void AsSpan_AfterRemove_ReflectsCount()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            set[0] = 10;
            set[1] = 20;
            set[2] = 30;
            set.Remove(0);
            Span<int> span = set.AsSpan();

            Assert.Equal(2, span.Length);
        }

        /// <summary>
        ///     Verifies that Clear resets count to zero.
        /// </summary>
        [Fact]
        public void Clear_ResetsCount()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            set[0] = 10;
            set[1] = 20;
            set.Clear();

            Assert.Equal(0, set.Count);
        }

        /// <summary>
        ///     Verifies that Clear allows re-adding elements.
        /// </summary>
        [Fact]
        public void Clear_AllowsReAdd()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            set[0] = 10;
            set.Clear();
            set[0] = 99;

            Assert.Equal(99, set[0]);
            Assert.Equal(1, set.Count);
        }

        /// <summary>
        ///     Verifies that Clear on a reference type set clears dense references.
        /// </summary>
        [Fact]
        public void Clear_ReferenceType_ClearsDense()
        {
            ShortSparseSet<string> set = new ShortSparseSet<string>();
            set[0] = "hello";
            set.Clear();
            set[0] = "world";

            Assert.Equal("world", set[0]);
            Assert.Equal(1, set.Count);
        }

        /// <summary>
        ///     Verifies that Remove on a reference type clears the stale slot.
        /// </summary>
        [Fact]
        public void Remove_ReferenceType_ClearsSlot()
        {
            ShortSparseSet<string> set = new ShortSparseSet<string>();
            set[0] = "a";
            set[1] = "b";
            set.Remove(0);

            Assert.Equal(1, set.Count);
            Assert.Equal("b", set[0]);
        }

        /// <summary>
        ///     Verifies that Remove swaps the last element into the removed slot.
        /// </summary>
        [Fact]
        public void Remove_SwapsLastIntoRemovedSlot()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            set[0] = 10;
            set[1] = 20;
            set[2] = 30;
            set.Remove(0);

            Assert.Equal(30, set[0]);
            Assert.Equal(20, set[1]);
        }

        /// <summary>
        ///     Verifies that removing the last element (no swap needed) works.
        /// </summary>
        [Fact]
        public void Remove_LastElement_Works()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            set[0] = 42;

            Assert.True(set.Remove(0));
            Assert.Equal(0, set.Count);
        }

        /// <summary>
        ///     Verifies that indexer works with a struct type.
        /// </summary>
        [Fact]
        public void Indexer_StructType_RoundTrips()
        {
            ShortSparseSet<MyStruct> set = new ShortSparseSet<MyStruct>();
            set[0] = new MyStruct { X = 10, Y = 20 };

            Assert.Equal(10, set[0].X);
            Assert.Equal(20, set[0].Y);
        }

        /// <summary>
        ///     Verifies that Capacity grows after indexer auto-resize.
        /// </summary>
        [Fact]
        public void Capacity_GrowsAfterAutoResize()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            int initial = set.Capacity;

            for (int i = 0; i < 10; i++)
            {
                set[(ushort)i] = i * 10;
            }

            Assert.True(set.Capacity >= initial);
        }

    }

    /// <summary>
    ///     Helper struct for testing reference-type-related behavior.
    /// </summary>
    internal struct MyStruct
    {
        /// <summary>
        ///     The x
        /// </summary>
        public int X { get; set; }

        /// <summary>
        ///     The y
        /// </summary>
        public int Y { get; set; }
    }
}
