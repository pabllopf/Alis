// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EnumerableHelpersExtendedTest.cs
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
    ///     Tests for <see cref="EnumerableHelpers" /> class
    /// </summary>
    public class EnumerableHelpersExtendedTest
    {
        /// <summary>
        ///     Tests that get empty enumerator returns empty enumerator
        /// </summary>
        [Fact]
        public void GetEmptyEnumerator_ReturnsEmptyEnumerator()
        {
            IEnumerator<int> enumerator = EnumerableHelpers.GetEmptyEnumerator<int>();

            Assert.False(enumerator.MoveNext());
        }

        /// <summary>
        ///     Tests that to array from empty enumerable returns empty array
        /// </summary>
        [Fact]
        public void ToArray_EmptyEnumerable_ReturnsEmptyArray()
        {
            IEnumerable<int> empty = Array.Empty<int>();

            int[] result = EnumerableHelpers.ToArray(empty, out int length);

            Assert.Empty(result);
            Assert.Equal(0, length);
        }

        /// <summary>
        ///     Tests that to array from list returns correct array
        /// </summary>
        [Fact]
        public void ToArray_FromList_ReturnsCorrectArray()
        {
            List<int> list = new List<int> {1, 2, 3};

            int[] result = EnumerableHelpers.ToArray(list, out int length);

            Assert.Equal(3, length);
            Assert.Equal(1, result[0]);
            Assert.Equal(2, result[1]);
            Assert.Equal(3, result[2]);
        }

        /// <summary>
        ///     Tests that to array from enumerable returns correct array
        /// </summary>
        [Fact]
        public void ToArray_FromEnumerable_ReturnsCorrectArray()
        {
            IEnumerable<int> enumerable = new List<int> {10, 20, 30, 40};

            int[] result = EnumerableHelpers.ToArray(enumerable, out int length);

            Assert.Equal(4, length);
            Assert.Equal(10, result[0]);
            Assert.Equal(40, result[3]);
        }

        /// <summary>
        ///     Tests that to array from single element enumerable returns correct array
        /// </summary>
        [Fact]
        public void ToArray_SingleElement_ReturnsCorrectArray()
        {
            IEnumerable<string> enumerable = new List<string> {"hello"};

            string[] result = EnumerableHelpers.ToArray(enumerable, out int length);

            Assert.Equal(1, length);
            Assert.Equal("hello", result[0]);
        }

        /// <summary>
        ///     Tests that to array length matches collection count
        /// </summary>
        [Fact]
        public void ToArray_LengthMatchesCollectionCount()
        {
            List<int> list = new List<int> {1, 2, 3, 4, 5};

            int[] result = EnumerableHelpers.ToArray(list, out int length);

            Assert.Equal(list.Count, length);
        }
    }
}
