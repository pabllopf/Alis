// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EnumerableHelpersEmptyEnumerableTest.cs
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
    ///     Tests for <see cref="EnumerableHelpers" /> focusing on empty non-ICollection enumerables.
    /// </summary>
    public class EnumerableHelpersEmptyEnumerableTest
    {
        /// <summary>
        ///     Tests that <see cref="EnumerableHelpers.ToArray{T}" /> returns an empty array
        ///     when given an empty <see cref="IEnumerable{T}" /> that is not an <see cref="ICollection{T}" />.
        /// </summary>
        [Fact]
        public void ToArray_EmptyNonCollectionEnumerable_ReturnsEmptyArray()
        {
            IEnumerable<int> source = EmptyEnumerable();

            int[] result = EnumerableHelpers.ToArray(source, out int length);

            Assert.Empty(result);
            Assert.Equal(0, length);
        }

        /// <summary>
        ///     Tests that <see cref="EnumerableHelpers.ToArray{T}" /> returns correct array
        ///     for a non-ICollection enumerable with a single element.
        /// </summary>
        [Fact]
        public void ToArray_SingleElementNonCollectionEnumerable_ReturnsArrayWithElement()
        {
            IEnumerable<int> source = SingleElementEnumerable();

            int[] result = EnumerableHelpers.ToArray(source, out int length);

            Assert.Equal(1, length);
            Assert.Equal(42, result[0]);
        }

        /// <summary>
        ///     Tests that <see cref="EnumerableHelpers.ToArray{T}" /> returns correct array
        ///     when the source is exactly the default capacity (4).
        /// </summary>
        [Fact]
        public void ToArray_ExactDefaultCapacity_ReturnsCorrectArray()
        {
            IEnumerable<int> source = Enumerable.Range(1, 4);

            int[] result = EnumerableHelpers.ToArray(source, out int length);

            Assert.Equal(4, length);
            Assert.Equal(1, result[0]);
            Assert.Equal(2, result[1]);
            Assert.Equal(3, result[2]);
            Assert.Equal(4, result[3]);
        }

        /// <summary>
        ///     Tests that <see cref="EnumerableHelpers.ToArray{T}" /> grows the array correctly
        ///     when the source size triggers one resize step (5 elements, start at 4, grow to 8).
        /// </summary>
        [Fact]
        public void ToArray_GrowsFromDefaultToDouble_ReturnsCorrectArray()
        {
            IEnumerable<int> source = Enumerable.Range(1, 5);

            int[] result = EnumerableHelpers.ToArray(source, out int length);

            Assert.Equal(5, length);
            Assert.Equal(1, result[0]);
            Assert.Equal(5, result[4]);
        }

        /// <summary>
        ///     Tests that <see cref="EnumerableHelpers.ToArray{T}" /> handles reference types
        ///     from a non-ICollection enumerable.
        /// </summary>
        [Fact]
        public void ToArray_NonCollectionEnumerableWithReferenceTypes_ReturnsCorrectArray()
        {
            IEnumerable<string> source = StringEnumerable();

            string[] result = EnumerableHelpers.ToArray(source, out int length);

            Assert.Equal(3, length);
            Assert.Equal("a", result[0]);
            Assert.Equal("b", result[1]);
            Assert.Equal("c", result[2]);
        }

        /// <summary>
        ///     Returns an empty enumerable that does not implement <see cref="ICollection{T}" />.
        /// </summary>
        private static IEnumerable<int> EmptyEnumerable()
        {
            yield break;
        }

        /// <summary>
        ///     Returns a single-element enumerable that does not implement <see cref="ICollection{T}" />.
        /// </summary>
        private static IEnumerable<int> SingleElementEnumerable()
        {
            yield return 42;
        }

        /// <summary>
        ///     Returns a string enumerable that does not implement <see cref="ICollection{T}" />.
        /// </summary>
        private static IEnumerable<string> StringEnumerable()
        {
            yield return "a";
            yield return "b";
            yield return "c";
        }
    }
}
