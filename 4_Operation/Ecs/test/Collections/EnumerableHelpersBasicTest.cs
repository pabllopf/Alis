// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EnumerableHelpersTest.cs
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
    ///     Tests utility methods in <see cref="EnumerableHelpers"/> which provide
    ///     efficient conversions and operations on IEnumerable collections.
    ///     These helpers optimize performance when dealing with generic enumerables.
    /// </remarks>
    public class EnumerableHelpersTest
    {
        /// <summary>
        ///     Tests that empty enumerator can be retrieved
        /// </summary>
        /// <remarks>
        ///     Verifies that GetEmptyEnumerator returns a valid empty enumerator.
        /// </remarks>
        [Fact]
        public void EnumerableHelpers_CanGetEmptyEnumerator()
        {
            // Act
            var emptyEnumerator = EnumerableHelpers.GetEmptyEnumerator<int>();

            // Assert
            Assert.NotNull(emptyEnumerator);
            Assert.False(emptyEnumerator.MoveNext());
        }

        /// <summary>
        ///     Tests that empty enumerator of different types can be retrieved
        /// </summary>
        /// <remarks>
        ///     Validates that GetEmptyEnumerator works with various type parameters.
        /// </remarks>
        [Fact]
        public void EnumerableHelpers_EmptyEnumeratorWorksWithDifferentTypes()
        {
            // Act
            var intEnumerator = EnumerableHelpers.GetEmptyEnumerator<int>();
            var stringEnumerator = EnumerableHelpers.GetEmptyEnumerator<string>();
            var doubleEnumerator = EnumerableHelpers.GetEmptyEnumerator<double>();

            // Assert
            Assert.False(intEnumerator.MoveNext());
            Assert.False(stringEnumerator.MoveNext());
            Assert.False(doubleEnumerator.MoveNext());
        }

        /// <summary>
        ///     Tests that enumerable can be converted to array
        /// </summary>
        /// <remarks>
        ///     Verifies that ToArray method correctly converts IEnumerable to array.
        /// </remarks>
        [Fact]
        public void EnumerableHelpers_CanConvertEnumerableToArray()
        {
            // Arrange
            List<int> list = new List<int> { 1, 2, 3, 4, 5 };

            // Act
            int[] array = EnumerableHelpers.ToArray(list, out int length);

            // Assert
            Assert.NotNull(array);
            Assert.Equal(5, length);
            Assert.Equal(5, array.Length);
        }

        /// <summary>
        ///     Tests that empty enumerable converts to array with zero length
        /// </summary>
        /// <remarks>
        ///     Validates that empty enumerables are handled correctly by ToArray.
        /// </remarks>
        [Fact]
        public void EnumerableHelpers_EmptyEnumerableConvertsToEmptyArray()
        {
            // Arrange
            List<string> emptyList = new List<string>();

            // Act
            string[] array = EnumerableHelpers.ToArray(emptyList, out int length);

            // Assert
            Assert.NotNull(array);
            Assert.Equal(0, length);
        }

        /// <summary>
        ///     Tests that ToArray preserves element order
        /// </summary>
        /// <remarks>
        ///     Verifies that the order of elements is maintained when converting to array.
        /// </remarks>
        [Fact]
        public void EnumerableHelpers_ToArrayPreservesElementOrder()
        {
            // Arrange
            List<int> list = new List<int> { 10, 20, 30, 40, 50 };

            // Act
            int[] array = EnumerableHelpers.ToArray(list, out int length);

            // Assert
            Assert.Equal(10, array[0]);
            Assert.Equal(20, array[1]);
            Assert.Equal(30, array[2]);
            Assert.Equal(40, array[3]);
            Assert.Equal(50, array[4]);
        }

        /// <summary>
        ///     Tests that ToArray works with large collections
        /// </summary>
        /// <remarks>
        ///     Validates that ToArray can handle collections of significant size.
        /// </remarks>
        [Fact]
        public void EnumerableHelpers_ToArrayWorksWithLargeCollections()
        {
            // Arrange
            List<int> list = new List<int>();
            for (int i = 0; i < 10000; i++)
            {
                list.Add(i);
            }

            // Act
            int[] array = EnumerableHelpers.ToArray(list, out int length);

            // Assert
            Assert.Equal(10000, length);
            Assert.Equal(0, array[0]);
            Assert.Equal(9999, array[9999]);
        }

        /// <summary>
        ///     Tests that ToArray works with collections of reference types
        /// </summary>
        /// <remarks>
        ///     Verifies that ToArray handles reference type collections correctly.
        /// </remarks>
        [Fact]
        public void EnumerableHelpers_ToArrayWorksWithReferenceTypes()
        {
            // Arrange
            List<string> strings = new List<string> { "apple", "banana", "cherry" };

            // Act
            string[] array = EnumerableHelpers.ToArray(strings, out int length);

            // Assert
            Assert.Equal(3, length);
            Assert.Equal("apple", array[0]);
            Assert.Equal("banana", array[1]);
            Assert.Equal("cherry", array[2]);
        }

        /// <summary>
        ///     Tests that ToArray with IEnumerable (not ICollection) works
        /// </summary>
        /// <remarks>
        ///     Validates that ToArray can handle pure IEnumerable without ICollection interface.
        /// </remarks>
        [Fact]
        public void EnumerableHelpers_ToArrayWorksWithPureEnumerable()
        {
            // Arrange
            IEnumerable<int> enumerable = GetTestEnumerable();

            // Act
            int[] array = EnumerableHelpers.ToArray(enumerable, out int length);

            // Assert
            Assert.Equal(5, length);
            Assert.Equal(new[] { 1, 2, 3, 4, 5 }, array[..5]);
        }

        /// <summary>
        ///     Helper method to provide a pure IEnumerable (not ICollection)
        /// </summary>
        private static IEnumerable<int> GetTestEnumerable()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield return 5;
        }
    }
}

