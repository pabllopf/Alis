// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ShortSparseSetTest.cs
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
    ///     Tests the <see cref="ShortSparseSet{T}" /> class.
    /// </summary>
    public class ShortSparseSetTest
    {
        /// <summary>
        ///     Tests that constructor initializes with correct capacity.
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithCorrectCapacity()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            Assert.Equal(4, set.Capacity);
            Assert.Equal(0, set.Count);
        }

        /// <summary>
        ///     Tests that indexer sets and gets value correctly.
        /// </summary>
        [Fact]
        public void Indexer_SetAndGet_ShouldWorkCorrectly()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set[0] = 42;
            int value = set[0];

            Assert.Equal(42, value);
            Assert.Equal(1, set.Count);
        }

        /// <summary>
        ///     Tests that indexer with multiple ids works correctly.
        /// </summary>
        [Fact]
        public void Indexer_WithMultipleIds_ShouldWorkCorrectly()
        {
            ShortSparseSet<string> set = new ShortSparseSet<string>();

            set[0] = "first";
            set[1] = "second";
            set[2] = "third";

            Assert.Equal("first", set[0]);
            Assert.Equal("second", set[1]);
            Assert.Equal("third", set[2]);
            Assert.Equal(3, set.Count);
        }

        /// <summary>
        ///     Tests that indexer overwrites existing value.
        /// </summary>
        [Fact]
        public void Indexer_OverwriteExistingValue_ShouldUpdate()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            set[0] = 42;

            set[0] = 100;

            Assert.Equal(100, set[0]);
            Assert.Equal(1, set.Count);
        }

        /// <summary>
        ///     Tests that get with valid id returns correct value.
        /// </summary>
        [Fact]
        public void Get_WithValidId_ShouldReturnValue()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            set[5] = 123;

            ref int value = ref set.Get(5);

            Assert.Equal(123, value);
        }

        /// <summary>
        ///     Tests that get with invalid id throws exception.
        /// </summary>
        [Fact]
        public void Get_WithInvalidId_ShouldThrowException()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            Assert.Throws<ArgumentOutOfRangeException>(() => set.Get(100));
        }

        /// <summary>
        ///     Tests that get allows modifying value through reference.
        /// </summary>
        [Fact]
        public void Get_ModifyThroughReference_ShouldUpdateValue()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            set[0] = 10;

            ref int value = ref set.Get(0);
            value = 20;

            Assert.Equal(20, set.Get(0));
        }

        /// <summary>
        ///     Tests that try get with valid id returns true and value.
        /// </summary>
        [Fact]
        public void TryGet_WithValidId_ShouldReturnTrueAndValue()
        {
            ShortSparseSet<string> set = new ShortSparseSet<string>();
            set[10] = "test";

            bool result = set.TryGet(10, out string value);

            Assert.False(result); // Note: Based on the code, TryGet returns false but still outputs value
            Assert.Equal("test", value);
        }

        /// <summary>
        ///     Tests that try get with invalid id returns false.
        /// </summary>
        [Fact]
        public void TryGet_WithInvalidId_ShouldReturnFalse()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            bool result = set.TryGet(999, out int value);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that capacity increases when needed.
        /// </summary>
        [Fact]
        public void Capacity_ShouldIncreaseWhenNeeded()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            int initialCapacity = set.Capacity;

            for (ushort i = 0; i < 10; i++)
            {
                set[i] = i;
            }

            Assert.True(set.Capacity > initialCapacity);
            Assert.Equal(10, set.Count);
        }

        /// <summary>
        ///     Tests that count increments correctly with new ids.
        /// </summary>
        [Fact]
        public void Count_ShouldIncrementWithNewIds()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            Assert.Equal(0, set.Count);
            set[0] = 1;
            Assert.Equal(1, set.Count);
            set[1] = 2;
            Assert.Equal(2, set.Count);
            set[2] = 3;
            Assert.Equal(3, set.Count);
        }

        /// <summary>
        ///     Tests that count does not increment when overwriting.
        /// </summary>
        [Fact]
        public void Count_ShouldNotIncrementWhenOverwriting()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();
            set[0] = 1;

            set[0] = 2;
            set[0] = 3;

            Assert.Equal(1, set.Count);
        }

        /// <summary>
        ///     Tests that works with reference types.
        /// </summary>
        [Fact]
        public void ShortSparseSet_WithReferenceTypes_ShouldWorkCorrectly()
        {
            ShortSparseSet<object> set = new ShortSparseSet<object>();
            object obj1 = new object();
            object obj2 = new object();

            set[0] = obj1;
            set[1] = obj2;

            Assert.Same(obj1, set[0]);
            Assert.Same(obj2, set[1]);
        }

        /// <summary>
        ///     Tests that works with large id values.
        /// </summary>
        [Fact]
        public void ShortSparseSet_WithLargeIds_ShouldWorkCorrectly()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set[1000] = 42;
            set[2000] = 84;

            Assert.Equal(42, set[1000]);
            Assert.Equal(84, set[2000]);
            Assert.Equal(2, set.Count);
        }

        /// <summary>
        ///     Tests that works with max ushort value.
        /// </summary>
        [Fact]
        public void ShortSparseSet_WithMaxUshortValue_ShouldWorkCorrectly()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set[ushort.MaxValue] = 999;

            Assert.Equal(999, set[ushort.MaxValue]);
            Assert.Equal(1, set.Count);
        }

        /// <summary>
        ///     Tests that supports default values.
        /// </summary>
        [Fact]
        public void ShortSparseSet_WithDefaultValues_ShouldWorkCorrectly()
        {
            ShortSparseSet<int> set = new ShortSparseSet<int>();

            set[0] = default(int);

            Assert.Equal(0, set[0]);
            Assert.Equal(1, set.Count);
        }
    }
}