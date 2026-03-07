// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CollectionExtensiveParametrizedTest.cs
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
using Alis.Core.Aspect.Math.Collections;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Collections
{
    /// <summary>
    ///     Comprehensive parametrized tests for collection operations.
    /// </summary>
    public class CollectionExtensiveParametrizedTest
    {
        /// <summary>
        ///     Generates the array size combinations
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GenerateArraySizeCombinations()
        {
            for (int size = 0; size <= 20; size++)
            {
                yield return new object[] {size};
            }

            for (int size = 25; size <= 100; size += 10)
            {
                yield return new object[] {size};
            }
        }

        /// <summary>
        ///     Tests that fast immutable array various sizes
        /// </summary>
        /// <param name="size">The size</param>
        [Theory, MemberData(nameof(GenerateArraySizeCombinations))]
        public void FastImmutableArray_VariousSizes(int size)
        {
            int[] values = Enumerable.Range(0, size).ToArray();
            FastImmutableArray<int> array = new FastImmutableArray<int>(values);

            Assert.Equal(size, array.Length);
        }

        /// <summary>
        ///     Generates the enumeration combinations
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GenerateEnumerationCombinations()
        {
            for (int size = 1; size <= 10; size++)
            {
                for (int iterations = 1; iterations <= 3; iterations++)
                {
                    yield return new object[] {size, iterations};
                }
            }
        }

        /// <summary>
        ///     Tests that fast immutable array enumerate multiple times
        /// </summary>
        /// <param name="size">The size</param>
        /// <param name="iterations">The iterations</param>
        [Theory, MemberData(nameof(GenerateEnumerationCombinations))]
        public void FastImmutableArray_EnumerateMultipleTimes(int size, int iterations)
        {
            FastImmutableArray<int> array = new FastImmutableArray<int>(Enumerable.Range(0, size).ToArray());

            for (int i = 0; i < iterations; i++)
            {
                List<int> list = array.ToList();
                Assert.Equal(size, list.Count);
            }
        }
    }
}