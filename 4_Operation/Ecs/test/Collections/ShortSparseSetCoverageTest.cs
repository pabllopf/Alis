// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ShortSparseSetCoverageTest.cs
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
using Alis.Core.Ecs.Collections;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    /// The short sparse set coverage test class
    /// </summary>
    public class ShortSparseSetCoverageTest
    {
        /// <summary>
        /// Tests that constructor default sets capacity four and count zero
        /// </summary>
        [Fact]
        public void Constructor_Default_SetsCapacityFourAndCountZero()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            Assert.Equal(4, set.Capacity);
            Assert.Equal(0, set.Count);
        }

        /// <summary>
        /// Tests that constructor default does not throw
        /// </summary>
        [Fact]
        public void Constructor_Default_DoesNotThrow()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            Assert.NotNull(set);
        }

        /// <summary>
        /// Tests that indexer new id auto vivifies and stores
        /// </summary>
        [Fact]
        public void Indexer_NewId_AutoVivifiesAndStores()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set[3] = 42;

            Assert.Equal(42, set[3]);
            Assert.Equal(1, set.Count);
        }

        /// <summary>
        /// Tests that indexer multiple ids all accessible
        /// </summary>
        [Fact]
        public void Indexer_MultipleIds_AllAccessible()
        {
            ShortSparseSet<string> set = new ShortSparseSet<string>();

            set[0] = "a";
            set[1] = "b";
            set[2] = "c";

            Assert.Equal("a", set[0]);
            Assert.Equal("b", set[1]);
            Assert.Equal("c", set[2]);
            Assert.Equal(3, set.Count);
        }

        /// <summary>
        /// Tests that indexer overwrite existing count does not change
        /// </summary>
        [Fact]
        public void Indexer_OverwriteExisting_CountDoesNotChange()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set[0] = 10;
            set[0] = 20;

            Assert.Equal(20, set[0]);
            Assert.Equal(1, set.Count);
        }

        /// <summary>
        /// Tests that indexer ref return mutation persists
        /// </summary>
        [Fact]
        public void Indexer_RefReturn_MutationPersists()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set[5] = 100;
            ref int val = ref set[5];
            val = 200;

            Assert.Equal(200, set[5]);
        }

        /// <summary>
        /// Tests that indexer ref return increment persists
        /// </summary>
        [Fact]
        public void Indexer_RefReturn_IncrementPersists()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set[0] = 10;
            ref int val = ref set[0];
            val += 5;

            Assert.Equal(15, set[0]);
        }

        /// <summary>
        /// Tests that indexer large id resizes sparse
        /// </summary>
        [Fact]
        public void Indexer_LargeId_ResizesSparse()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set[1000] = 999;

            Assert.Equal(999, set[1000]);
            Assert.Equal(1, set.Count);
        }

        /// <summary>
        /// Tests that indexer sparse ids all correct
        /// </summary>
        [Fact]
        public void Indexer_SparseIds_AllCorrect()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set[1] = 10;
            set[10] = 20;
            set[100] = 30;

            Assert.Equal(10, set[1]);
            Assert.Equal(20, set[10]);
            Assert.Equal(30, set[100]);
        }

        /// <summary>
        /// Tests that indexer default value returns zero
        /// </summary>
        [Fact]
        public void Indexer_DefaultValue_ReturnsZero()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            Assert.Equal(0, set[99]);
        }

        /// <summary>
        /// Tests that indexer sequential up to capacity works
        /// </summary>
        [Fact]
        public void Indexer_SequentialUpToCapacity_Works()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            for (int i = 0; i < 4; i++)
            {
                set[(ushort)i] = i * 10;
            }
            for (int i = 0; i < 4; i++)
            {
                Assert.Equal(i * 10, set[(ushort)i]);
            }
        }

        /// <summary>
        /// Tests that indexer sequential beyond capacity works
        /// </summary>
        [Fact]
        public void Indexer_SequentialBeyondCapacity_Works()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            for (int i = 0; i < 20; i++)
            {
                set[(ushort)i] = i;
            }
            for (int i = 0; i < 20; i++)
            {
                Assert.Equal(i, set[(ushort)i]);
            }
        }

        /// <summary>
        /// Tests that indexer reading non existent id auto vivifies
        /// </summary>
        [Fact]
        public void Indexer_ReadingNonExistentId_AutoVivifies()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            int val = set[42];

            Assert.Equal(0, val);
            Assert.Equal(1, set.Count);
        }

        /// <summary>
        /// Tests that count starts at zero
        /// </summary>
        [Fact]
        public void Count_StartsAtZero()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            Assert.Equal(0, set.Count);
        }

        /// <summary>
        /// Tests that count increments with new ids
        /// </summary>
        [Fact]
        public void Count_IncrementsWithNewIds()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set[0] = 1;
            Assert.Equal(1, set.Count);

            set[1] = 2;
            Assert.Equal(2, set.Count);

            set[2] = 3;
            Assert.Equal(3, set.Count);
        }

        /// <summary>
        /// Tests that count decrements on remove
        /// </summary>
        [Fact]
        public void Count_DecrementsOnRemove()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set[0] = 1;
            set[1] = 2;
            Assert.Equal(2, set.Count);

            set.Remove(0);
            Assert.Equal(1, set.Count);
        }

        /// <summary>
        /// Tests that has existing id returns true
        /// </summary>
        [Fact]
        public void Has_ExistingId_ReturnsTrue()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set[10] = 100;

            Assert.True(set.Has(10));
        }

        /// <summary>
        /// Tests that has non existent id in range returns false
        /// </summary>
        [Fact]
        public void Has_NonExistentIdInRange_ReturnsFalse()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set[10] = 100;

            Assert.False(set.Has(5));
        }

        /// <summary>
        /// Tests that has id beyond sparse length returns false
        /// </summary>
        [Fact]
        public void Has_IdBeyondSparseLength_ReturnsFalse()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            bool result = set.Has(9999);

            Assert.False(result);
        }

        /// <summary>
        /// Tests that has negative id returns false
        /// </summary>
        [Fact]
        public void Has_NegativeId_ReturnsFalse()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            bool result = set.Has(-1);

            Assert.False(result);
        }

        /// <summary>
        /// Tests that get existing id returns ref
        /// </summary>
        [Fact]
        public void Get_ExistingId_ReturnsRef()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set[5] = 123;
            ref int value = ref set.Get(5);

            Assert.Equal(123, value);
        }

        /// <summary>
        /// Tests that get existing id allows modification through ref
        /// </summary>
        [Fact]
        public void Get_ExistingId_AllowsModificationThroughRef()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set[0] = 10;
            ref int value = ref set.Get(0);
            value = 20;

            Assert.Equal(20, set.Get(0));
        }

        /// <summary>
        /// Tests that get non existent id beyond sparse throws argument out of range
        /// </summary>
        [Fact]
        public void Get_NonExistentIdBeyondSparse_ThrowsArgumentOutOfRange()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            Assert.Throws<ArgumentOutOfRangeException>(() => set.Get(100));
        }

        /// <summary>
        /// Tests that get non existent id in sparse range throws argument out of range
        /// </summary>
        [Fact]
        public void Get_NonExistentIdInSparseRange_ThrowsArgumentOutOfRange()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            Assert.Throws<ArgumentOutOfRangeException>(() => set.Get(0));
        }

        /// <summary>
        /// Tests that try get existing id returns false but sets value
        /// </summary>
        [Fact]
        public void TryGet_ExistingId_ReturnsFalseButSetsValue()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set[10] = 42;
            bool result = set.TryGet(10, out int value);

            Assert.False(result);
            Assert.Equal(42, value);
        }

        /// <summary>
        /// Tests that try get non existent id returns false
        /// </summary>
        [Fact]
        public void TryGet_NonExistentId_ReturnsFalse()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            bool result = set.TryGet(99, out int value);

            Assert.False(result);
            Assert.Equal(0, value);
        }

        /// <summary>
        /// Tests that try get non existent id in sparse range returns false
        /// </summary>
        [Fact]
        public void TryGet_NonExistentIdInSparseRange_ReturnsFalse()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            bool result = set.TryGet(0, out int value);

            Assert.False(result);
            Assert.Equal(0, value);
        }

        /// <summary>
        /// Tests that remove existing id returns true
        /// </summary>
        [Fact]
        public void Remove_ExistingId_ReturnsTrue()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set[5] = 50;
            bool removed = set.Remove(5);

            Assert.True(removed);
        }

        /// <summary>
        /// Tests that remove existing id decrements count
        /// </summary>
        [Fact]
        public void Remove_ExistingId_DecrementsCount()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set[0] = 1;
            set[1] = 2;
            set[2] = 3;
            set.Remove(1);

            Assert.Equal(2, set.Count);
        }

        /// <summary>
        /// Tests that remove non existent id beyond sparse returns false
        /// </summary>
        [Fact]
        public void Remove_NonExistentIdBeyondSparse_ReturnsFalse()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            bool result = set.Remove(99);

            Assert.False(result);
        }

        /// <summary>
        /// Tests that remove non existent id in sparse range returns false
        /// </summary>
        [Fact]
        public void Remove_NonExistentIdInSparseRange_ReturnsFalse()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            bool result = set.Remove(0);

            Assert.False(result);
        }

        /// <summary>
        /// Tests that remove last element decrements count
        /// </summary>
        [Fact]
        public void Remove_LastElement_DecrementsCount()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set[0] = 1;
            set[1] = 2;
            bool removed = set.Remove(1);

            Assert.True(removed);
            Assert.Equal(1, set.Count);
            Assert.Equal(1, set[0]);
        }

        /// <summary>
        /// Tests that clear empty set count zero
        /// </summary>
        [Fact]
        public void Clear_EmptySet_CountZero()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set.Clear();

            Assert.Equal(0, set.Count);
        }

        /// <summary>
        /// Tests that clear after adds count zero and has false
        /// </summary>
        [Fact]
        public void Clear_AfterAdds_CountZeroAndHasFalse()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set[0] = 1;
            set[1] = 2;
            set[2] = 3;
            set.Clear();

            Assert.Equal(0, set.Count);
            Assert.False(set.Has(0));
            Assert.False(set.Has(1));
            Assert.False(set.Has(2));
        }

        /// <summary>
        /// Tests that clear allows re add
        /// </summary>
        [Fact]
        public void Clear_AllowsReAdd()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set[0] = 1;
            set.Clear();
            set[0] = 42;

            Assert.Equal(42, set[0]);
            Assert.Equal(1, set.Count);
        }

        /// <summary>
        /// Tests that clear reference type resets dense
        /// </summary>
        [Fact]
        public void Clear_ReferenceType_ResetsDense()
        {
            ShortSparseSet<string> set = new ShortSparseSet<string>();

            set[0] = "hello";
            set[1] = "world";
            set.Clear();

            Assert.Equal(0, set.Count);
            Assert.False(set.Has(0));
            Assert.False(set.Has(1));
        }

        /// <summary>
        /// Tests that as span on new set returns empty
        /// </summary>
        [Fact]
        public void AsSpan_OnNewSet_ReturnsEmpty()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            Span<int> span = set.AsSpan();

            Assert.True(span.IsEmpty);
        }

        /// <summary>
        /// Tests that as span after adds returns populated span
        /// </summary>
        [Fact]
        public void AsSpan_AfterAdds_ReturnsPopulatedSpan()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set[0] = 10;
            set[1] = 20;
            set[2] = 30;
            Span<int> span = set.AsSpan();

            Assert.Equal(3, span.Length);
            Assert.Equal(10, span[0]);
            Assert.Equal(20, span[1]);
            Assert.Equal(30, span[2]);
        }

        /// <summary>
        /// Tests that as span after remove reflects new state
        /// </summary>
        [Fact]
        public void AsSpan_AfterRemove_ReflectsNewState()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set[0] = 10;
            set[1] = 20;
            set[2] = 30;
            set.Remove(1);
            Span<int> span = set.AsSpan();

            Assert.Equal(2, span.Length);
        }

        /// <summary>
        /// Tests that capacity starts at four
        /// </summary>
        [Fact]
        public void Capacity_StartsAtFour()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            Assert.Equal(4, set.Capacity);
        }

        /// <summary>
        /// Tests that capacity grows as needed
        /// </summary>
        [Fact]
        public void Capacity_GrowsAsNeeded()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            int initial = set.Capacity;
            for (int i = 0; i < 10; i++)
            {
                set[(ushort)i] = i;
            }

            Assert.True(set.Capacity > initial);
        }

        /// <summary>
        /// Tests that ensure capacity when larger resizes
        /// </summary>
        [Fact]
        public void EnsureCapacity_WhenLarger_Resizes()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set.EnsureCapacity(100);

            Assert.True(set.Capacity >= 100);
        }

        /// <summary>
        /// Tests that ensure capacity when smaller does not shrink
        /// </summary>
        [Fact]
        public void EnsureCapacity_WhenSmaller_DoesNotShrink()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set.EnsureCapacity(2);

            Assert.Equal(4, set.Capacity);
        }

        /// <summary>
        /// Tests that ensure capacity after adds keeps values
        /// </summary>
        [Fact]
        public void EnsureCapacity_AfterAdds_KeepsValues()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set[0] = 10;
            set[1] = 20;
            set.EnsureCapacity(100);

            Assert.Equal(10, set[0]);
            Assert.Equal(20, set[1]);
        }

        /// <summary>
        /// Tests that value type int roundtrip
        /// </summary>
        [Fact]
        public void ValueType_Int_Roundtrip()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set[0] = int.MaxValue;

            Assert.Equal(int.MaxValue, set[0]);
        }

        /// <summary>
        /// Tests that reference type string roundtrip
        /// </summary>
        [Fact]
        public void ReferenceType_String_Roundtrip()
        {
            ShortSparseSet<string> set = new ShortSparseSet<string>();

            set[0] = "hello";

            Assert.Equal("hello", set[0]);
        }

        /// <summary>
        /// Tests that reference type string multiple entries
        /// </summary>
        [Fact]
        public void ReferenceType_String_MultipleEntries()
        {
            ShortSparseSet<string> set = new ShortSparseSet<string>();

            set[0] = "a";
            set[1] = "b";
            set[2] = "c";

            Assert.Equal("a", set[0]);
            Assert.Equal("b", set[1]);
            Assert.Equal("c", set[2]);
        }

        /// <summary>
        /// Tests that reference type null value stores null
        /// </summary>
        [Fact]
        public void ReferenceType_NullValue_StoresNull()
        {
            ShortSparseSet<string> set = new ShortSparseSet<string>();

            set[0] = null;

            Assert.Null(set[0]);
        }

        /// <summary>
        /// Tests that value type struct roundtrip
        /// </summary>
        [Fact]
        public void ValueType_Struct_Roundtrip()
        {
            ShortSparseSet<KeyValuePair<int, int>> set = new ShortSparseSet<KeyValuePair<int, int>>();
            KeyValuePair<int, int> kvp = new KeyValuePair<int, int>(1, 2);

            set[0] = kvp;

            Assert.Equal(1, set[0].Key);
            Assert.Equal(2, set[0].Value);
        }

        /// <summary>
        /// Tests that large sparse gap auto vivifies intermediate
        /// </summary>
        [Fact]
        public void LargeSparseGap_AutoVivifiesIntermediate()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set[0] = 1;
            set[10000] = 2;

            Assert.Equal(1, set[0]);
            Assert.Equal(2, set[10000]);
        }

        /// <summary>
        /// Tests that remove from middle shifts last element
        /// </summary>
        [Fact]
        public void Remove_FromMiddle_ShiftsLastElement()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set[0] = 10;
            set[1] = 20;
            set[2] = 30;
            set.Remove(1);

            Assert.Equal(2, set.Count);
            Assert.Equal(10, set[0]);
            Assert.Equal(30, set[2]);
        }

        /// <summary>
        /// Tests that remove only element clears dense for reference type
        /// </summary>
        [Fact]
        public void Remove_OnlyElement_ClearsDenseForReferenceType()
        {
            ShortSparseSet<string> set = new ShortSparseSet<string>();

            set[0] = "only";
            set.Remove(0);

            Assert.Equal(0, set.Count);
        }

        /// <summary>
        /// Tests that indexer dense resize preserves values
        /// </summary>
        [Fact]
        public void Indexer_DenseResize_PreservesValues()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            for (int i = 0; i < 20; i++)
            {
                set[(ushort)i] = i * 10;
            }
            for (int i = 0; i < 20; i++)
            {
                Assert.Equal(i * 10, set[(ushort)i]);
            }
        }
    }
}
