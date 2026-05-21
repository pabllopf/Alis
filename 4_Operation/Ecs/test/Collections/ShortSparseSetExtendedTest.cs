// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ShortSparseSetExtendedTest.cs
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
    ///     Extended tests for ShortSparseSet to validate sparse set operations,
    ///     membership testing, and efficient storage for sparse data.
    /// </summary>
    public class ShortSparseSetExtendedTest
    {
        /// <summary>
        ///     Test that ShortSparseSet can store and retrieve elements by index.
        /// </summary>
        [Fact]
        public void Indexer_SetAndGet_StoresAndRetrieves()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set[5] = 50;
            set[10] = 100;

            Assert.Equal(50, set[5]);
            Assert.Equal(100, set[10]);
        }

        /// <summary>
        ///     Test that ShortSparseSet can store multiple elements.
        /// </summary>
        [Fact]
        public void Indexer_MultipleElements_AllStored()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            for (int i = 0; i < 20; i++)
            {
                set[(ushort) i] = i * 10;
            }

            for (int i = 0; i < 20; i++)
            {
                Assert.Equal(i * 10, set[(ushort) i]);
            }
        }

        /// <summary>
        ///     Test that ShortSparseSet.Has works correctly.
        /// </summary>
        [Fact]
        public void Has_StoredAndNonStored_CorrectResults()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            set[10] = 100;
            set[20] = 200;

            Assert.True(set.Has(10));
            Assert.True(set.Has(20));
            Assert.False(set.Has(30));
        }

        /// <summary>
        ///     Test that ShortSparseSet.Remove removes elements.
        /// </summary>
        [Fact]
        public void Remove_ExistingElement_ElementRemoved()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            set[5] = 50;
            set[10] = 100;

            bool removed = set.Remove(5);

            Assert.True(removed);
            Assert.True(set.Has(5));
            Assert.True(set.Has(10));
        }

        /// <summary>
        ///     Test that ShortSparseSet.Clear empties the set.
        /// </summary>
        [Fact]
        public void Clear_AfterAdds_SetEmpty()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            for (int i = 0; i < 10; i++)
            {
                set[(ushort) i] = i;
            }

            set.Clear();

            Assert.Equal(0, set.Count);
        }

        /// <summary>
        ///     Test that ShortSparseSet handles sparse indices efficiently.
        /// </summary>
        [Fact]
        public void Indexer_SparseIndices_AllAccessible()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set[100] = 1000;
            set[500] = 5000;
            set[1000] = 10000;

            Assert.True(set.Has(100));
            Assert.True(set.Has(500));
            Assert.True(set.Has(1000));
        }

        /// <summary>
        ///     Test that ShortSparseSet.Count is accurate.
        /// </summary>
        [Fact]
        public void Count_AfterOperations_Accurate()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            Assert.Equal(0, set.Count);

            set[1] = 10;
            Assert.Equal(1, set.Count);

            set[2] = 20;
            Assert.Equal(2, set.Count);

            set.Remove(1);
            Assert.Equal(1, set.Count);
        }

        /// <summary>
        ///     Test that ShortSparseSet can work with AsSpan.
        /// </summary>
        [Fact]
        public void AsSpan_AfterAdds_ReturnsValidSpan()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            int[] values = {10, 20, 30, 40, 50};

            foreach (int val in values)
            {
                set[(ushort) val] = val;
            }

            Span<int> span = set.AsSpan();
            Assert.Equal(5, span.Length);
        }

        /// <summary>
        ///     Test that ShortSparseSet updates existing values correctly.
        /// </summary>
        [Fact]
        public void Indexer_UpdateExisting_ValueReplaced()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            set[5] = 50;

            set[5] = 500;

            Assert.Equal(500, set[5]);
            Assert.Equal(1, set.Count); // Still only one element
        }

        /// <summary>
        ///     Test that ShortSparseSet with string values works correctly.
        /// </summary>
        [Fact]
        public void Indexer_StringValues_StoresAndRetrieves()
        {
            ShortSparseSet<string> set = new ShortSparseSet<string>();

            set[0] = "apple";
            set[1] = "banana";
            set[2] = "cherry";

            Assert.Equal("apple", set[0]);
            Assert.Equal("banana", set[1]);
            Assert.Equal("cherry", set[2]);
        }
    }
}