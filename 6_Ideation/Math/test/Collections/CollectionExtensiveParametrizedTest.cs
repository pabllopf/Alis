using Alis.Core.Aspect.Math.Collections;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alis.Core.Aspect.Math.Test.Collections
{
    /// <summary>
    /// Comprehensive parametrized tests for collection operations.
    /// </summary>
    public class CollectionExtensiveParametrizedTest
    {
        /// <summary>
        /// Generates the array size combinations
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GenerateArraySizeCombinations()
        {
            for (int size = 0; size <= 20; size++)
            {
                yield return new object[] { size };
            }
            for (int size = 25; size <= 100; size += 10)
            {
                yield return new object[] { size };
            }
        }

        /// <summary>
        /// Tests that fast immutable array various sizes
        /// </summary>
        /// <param name="size">The size</param>
        [Theory]
        [MemberData(nameof(GenerateArraySizeCombinations))]
        public void FastImmutableArray_VariousSizes(int size)
        {
            int[] values = Enumerable.Range(0, size).ToArray();
            FastImmutableArray<int> array = new FastImmutableArray<int>(values);
            
            Assert.Equal(size, array.Length);
        }

        /// <summary>
        /// Generates the enumeration combinations
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GenerateEnumerationCombinations()
        {
            for (int size = 1; size <= 10; size++)
            {
                for (int iterations = 1; iterations <= 3; iterations++)
                {
                    yield return new object[] { size, iterations };
                }
            }
        }

        /// <summary>
        /// Tests that fast immutable array enumerate multiple times
        /// </summary>
        /// <param name="size">The size</param>
        /// <param name="iterations">The iterations</param>
        [Theory]
        [MemberData(nameof(GenerateEnumerationCombinations))]
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
