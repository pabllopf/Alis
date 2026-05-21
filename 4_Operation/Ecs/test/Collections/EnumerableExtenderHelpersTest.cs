// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EnumerableExtenderHelpersTest.cs
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
using Alis.Core.Ecs.Collections;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     The enumerable helpers test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="EnumerableHelpers" /> static utility methods
    ///     for working with enumerables and enumerators.
    /// </remarks>
    public class EnumerableExtenderHelpersTest
    {
        /// <summary>
        ///     Tests that enumerable helpers get empty enumerator returns valid enumerator
        /// </summary>
        /// <remarks>
        ///     Verifies that GetEmptyEnumerator returns a valid empty enumerator.
        /// </remarks>
        [Fact]
        public void EnumerableHelpers_GetEmptyEnumeratorReturnsValidEnumerator()
        {
            IEnumerator<int> enumerator = EnumerableHelpers.GetEmptyEnumerator<int>();

            Assert.NotNull(enumerator);
            Assert.False(enumerator.MoveNext());
        }

        /// <summary>
        ///     Tests that enumerable helpers to array with empty collection
        /// </summary>
        /// <remarks>
        ///     Tests ToArray with an empty collection.
        /// </remarks>
        [Fact]
        public void EnumerableHelpers_ToArrayWithEmptyCollection()
        {
            List<int> source = new List<int>();

            int[] result = EnumerableHelpers.ToArray(source, out int length);

            Assert.Equal(0, length);
            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that enumerable helpers to array with single element enumerable
        /// </summary>
        /// <remarks>
        ///     Tests ToArray with a single element.
        /// </remarks>
        [Fact]
        public void EnumerableHelpers_ToArrayWithSingleElement()
        {
            int[] source = new[] {42};

            int[] result = EnumerableHelpers.ToArray(source, out int length);

            Assert.Equal(1, length);
            Assert.Equal(42, result[0]);
        }

        /// <summary>
        ///     Tests that enumerable helpers to array with large enumerable
        /// </summary>
        /// <remarks>
        ///     Tests ToArray with many elements to verify proper resizing.
        /// </remarks>
        [Fact]
        public void EnumerableHelpers_ToArrayWithLargeEnumerable()
        {
            IEnumerable<int> source = GetLargeEnumerable(100);

            int[] result = EnumerableHelpers.ToArray(source, out int length);

            Assert.Equal(100, length);
            for (int i = 0; i < 100; i++)
            {
                Assert.Equal(i, result[i]);
            }
        }

        /// <summary>
        ///     Tests that enumerable helpers reset enumerator
        /// </summary>
        /// <remarks>
        ///     Tests the Reset method on an enumerator.
        /// </remarks>
        [Fact]
        public void EnumerableHelpers_ResetEnumerator()
        {
            List<int> source = new List<int> {1, 2, 3};
            IEnumerator<int> enumerator = source.GetEnumerator();
            enumerator.MoveNext();
            Assert.Equal(1, enumerator.Current);

            EnumerableHelpers.Reset(ref enumerator);

            Assert.True(enumerator.MoveNext());
            Assert.Equal(1, enumerator.Current);
        }

        /// <summary>
        ///     Tests that enumerable helpers to array preserves order
        /// </summary>
        /// <remarks>
        ///     Verifies that ToArray preserves the enumeration order.
        /// </remarks>
        [Fact]
        public void EnumerableHelpers_ToArrayPreservesOrder()
        {
            List<string> source = new List<string> {"a", "b", "c", "d"};

            string[] result = EnumerableHelpers.ToArray(source, out int length);

            Assert.Equal(4, length);
            Assert.Equal("a", result[0]);
            Assert.Equal("b", result[1]);
            Assert.Equal("c", result[2]);
            Assert.Equal("d", result[3]);
        }

        /// <summary>
        ///     Gets an enumerable.
        /// </summary>
        /// <returns>An enumerable of integers.</returns>
        private static IEnumerable<int> GetEnumerable()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield return 5;
        }

        /// <summary>
        ///     Gets a large enumerable.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns>An enumerable with the specified count of integers.</returns>
        private static IEnumerable<int> GetLargeEnumerable(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return i;
            }
        }
    }
}