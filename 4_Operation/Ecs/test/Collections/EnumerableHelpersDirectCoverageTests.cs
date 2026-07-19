// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EnumerableHelpersDirectCoverageTests.cs
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

using System.Collections.Generic;
using System.Linq;
using Alis.Core.Ecs.Collections;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     Direct coverage tests for <see cref="EnumerableHelpers" /> static methods.
    /// </summary>
    public class EnumerableHelpersDirectCoverageTests
    {
        [Fact]
        public void GetEmptyEnumerator_ReturnsEmpty()
        {
            IEnumerator<int> en = EnumerableHelpers.GetEmptyEnumerator<int>();
            Assert.False(en.MoveNext());
        }

        [Fact]
        public void GetEmptyEnumerator_String_ReturnsEmpty()
        {
            IEnumerator<string> en = EnumerableHelpers.GetEmptyEnumerator<string>();
            Assert.False(en.MoveNext());
        }

        [Fact]
        public void ToArray_FromList_ReturnsArray()
        {
            List<int> list = new List<int> { 1, 2, 3 };
            int[] result = EnumerableHelpers.ToArray(list, out int length);
            Assert.Equal(3, length);
            Assert.Equal(3, result.Length);
        }

        [Fact]
        public void ToArray_FromEmptyList_ReturnsEmpty()
        {
            List<int> list = new List<int>();
            int[] result = EnumerableHelpers.ToArray(list, out int length);
            Assert.Equal(0, length);
            Assert.Empty(result);
        }

        [Fact]
        public void ToArray_FromEnumerable_ReturnsArray()
        {
            IEnumerable<int> source = Enumerable.Range(1, 4);
            int[] result = EnumerableHelpers.ToArray(source, out int length);
            Assert.Equal(4, length);
            Assert.Equal(4, result.Length);
            Assert.Equal(1, result[0]);
            Assert.Equal(4, result[3]);
        }

        [Fact]
        public void ToArray_FromEmptyEnumerable_ReturnsEmpty()
        {
            IEnumerable<int> source = Enumerable.Empty<int>();
            int[] result = EnumerableHelpers.ToArray(source, out int length);
            Assert.Equal(0, length);
            Assert.Empty(result);
        }

        [Fact]
        public void ToArray_FromSingleElement_ReturnsArray()
        {
            IEnumerable<int> source = Enumerable.Range(1, 1);
            int[] result = EnumerableHelpers.ToArray(source, out int length);
            Assert.Equal(1, length);
            Assert.Equal(1, result[0]);
        }

        [Fact]
        public void ToArray_FromArray_ReturnsCopy()
        {
            int[] source = new int[] { 10, 20, 30, 40, 50 };
            int[] result = EnumerableHelpers.ToArray(source, out int length);
            Assert.Equal(5, length);
            Assert.Equal(10, result[0]);
            Assert.Equal(50, result[4]);
        }

        [Fact]
        public void ToArray_FromEmptyArray_ReturnsEmpty()
        {
            int[] source = new int[0];
            int[] result = EnumerableHelpers.ToArray(source, out int length);
            Assert.Equal(0, length);
            Assert.Empty(result);
        }

        [Fact]
        public void ToArray_FromHashSet_ReturnsArray()
        {
            HashSet<int> source = new HashSet<int> { 1, 2, 3 };
            int[] result = EnumerableHelpers.ToArray(source, out int length);
            Assert.Equal(3, length);
            Assert.Equal(3, result.Length);
            Assert.Contains(1, result);
            Assert.Contains(2, result);
            Assert.Contains(3, result);
        }

        [Fact]
        public void ToArray_FromLargeEnumerable_GrowsCorrectly()
        {
            IEnumerable<int> source = Enumerable.Range(1, 100);
            int[] result = EnumerableHelpers.ToArray(source, out int length);
            Assert.Equal(100, length);
            Assert.Equal(100, result.Length);
            Assert.Equal(1, result[0]);
            Assert.Equal(100, result[99]);
        }
    }
}
