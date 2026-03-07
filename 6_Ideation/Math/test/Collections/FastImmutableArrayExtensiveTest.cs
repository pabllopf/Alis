// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastImmutableArrayExtensiveTest.cs
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
using System.Linq;
using Alis.Core.Aspect.Math.Collections;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Collections
{
    /// <summary>
    ///     Comprehensive unit tests for FastImmutableArray collection type.
    ///     Tests immutability, performance, and edge cases.
    /// </summary>
    public class FastImmutableArrayExtensiveTest
    {
        /// <summary>
        ///     Tests that create from enumerable succeeds
        /// </summary>
        [Fact]
        public void Create_FromEnumerable_Succeeds()
        {
            int[] source = new[] {1, 2, 3, 4, 5};
            FastImmutableArray<int> array = new FastImmutableArray<int>(source);

            Assert.Equal(5, array.Length);
            Assert.Equal(source, array);
        }

        /// <summary>
        ///     Tests that create from enumerable null values succeeds
        /// </summary>
        [Fact]
        public void Create_FromEnumerable_NullValues_Succeeds()
        {
            string[] source = new[] {"a", null, "c"};
            FastImmutableArray<string> array = new FastImmutableArray<string>(source);

            Assert.Equal(3, array.Length);
        }

        /// <summary>
        ///     Tests that create with different sizes
        /// </summary>
        /// <param name="size">The size</param>
        [Theory, InlineData(0), InlineData(1), InlineData(10), InlineData(100), InlineData(1000)]
        public void Create_WithDifferentSizes(int size)
        {
            int[] source = Enumerable.Range(0, size).ToArray();
            FastImmutableArray<int> array = new FastImmutableArray<int>(source);

            Assert.Equal(size, array.Length);
        }


        /// <summary>
        ///     Tests that enumeration iterates all elements
        /// </summary>
        [Fact]
        public void Enumeration_IteratesAllElements()
        {
            int[] source = new[] {1, 2, 3, 4, 5};
            FastImmutableArray<int> array = new FastImmutableArray<int>(source);
            List<int> result = new List<int>();

            foreach (int item in array)
            {
                result.Add(item);
            }

            Assert.Equal(source, result);
        }

        /// <summary>
        ///     Tests that enumeration multiple enumeration succeeds
        /// </summary>
        [Fact]
        public void Enumeration_MultipleEnumeration_Succeeds()
        {
            int[] source = new[] {1, 2, 3};
            FastImmutableArray<int> array = new FastImmutableArray<int>(source);

            List<int> first = array.ToList();
            List<int> second = array.ToList();

            Assert.Equal(first, second);
        }


        /// <summary>
        ///     Tests that index access valid index returns element
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="expected">The expected</param>
        [Theory, InlineData(0, 1), InlineData(1, 2), InlineData(4, 5)]
        public void IndexAccess_ValidIndex_ReturnsElement(int index, int expected)
        {
            int[] source = new[] {1, 2, 3, 4, 5};
            FastImmutableArray<int> array = new FastImmutableArray<int>(source);

            Assert.Equal(expected, array[index]);
        }

        /// <summary>
        ///     Tests that index access invalid index throws exception
        /// </summary>
        /// <param name="index">The index</param>
        [Theory, InlineData(-1), InlineData(5), InlineData(100)]
        public void IndexAccess_InvalidIndex_ThrowsException(int index)
        {
            int[] source = new[] {1, 2, 3, 4, 5};
            FastImmutableArray<int> array = new FastImmutableArray<int>(source);

            Assert.Throws<IndexOutOfRangeException>(() => array[index]);
        }


        /// <summary>
        ///     Tests that count returns correct value
        /// </summary>
        /// <param name="size">The size</param>
        [Theory, InlineData(0), InlineData(1), InlineData(5), InlineData(100)]
        public void Count_ReturnsCorrectValue(int size)
        {
            int[] source = Enumerable.Range(0, size).ToArray();
            FastImmutableArray<int> array = new FastImmutableArray<int>(source);

            Assert.Equal(size, array.Length);
        }


        /// <summary>
        ///     Tests that linq where filtered correctly
        /// </summary>
        [Fact]
        public void Linq_Where_FilteredCorrectly()
        {
            int[] source = new[] {1, 2, 3, 4, 5};
            FastImmutableArray<int> array = new FastImmutableArray<int>(source);

            List<int> result = array.Where(x => x > 2).ToList();

            Assert.Equal(3, result.Count);
            Assert.Equal(new[] {3, 4, 5}, result);
        }

        /// <summary>
        ///     Tests that linq select transformed correctly
        /// </summary>
        [Fact]
        public void Linq_Select_TransformedCorrectly()
        {
            int[] source = new[] {1, 2, 3};
            FastImmutableArray<int> array = new FastImmutableArray<int>(source);

            List<int> result = array.Select(x => x * 2).ToList();

            Assert.Equal(new[] {2, 4, 6}, result);
        }

        /// <summary>
        ///     Tests that linq first or default returns element
        /// </summary>
        [Fact]
        public void Linq_FirstOrDefault_ReturnsElement()
        {
            int[] source = new[] {1, 2, 3};
            FastImmutableArray<int> array = new FastImmutableArray<int>(source);

            int result = array.FirstOrDefault();

            Assert.Equal(1, result);
        }
    }
}