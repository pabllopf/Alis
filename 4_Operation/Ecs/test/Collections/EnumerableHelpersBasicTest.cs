

using System.Collections.Generic;
using Alis.Core.Ecs.Collections;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     The enumerable helpers test class
    /// </summary>
    /// <remarks>
    ///     Tests utility methods in <see cref="EnumerableHelpers" /> which provide
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
            IEnumerator<int> emptyEnumerator = EnumerableHelpers.GetEmptyEnumerator<int>();

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
            IEnumerator<int> intEnumerator = EnumerableHelpers.GetEmptyEnumerator<int>();
            IEnumerator<string> stringEnumerator = EnumerableHelpers.GetEmptyEnumerator<string>();
            IEnumerator<double> doubleEnumerator = EnumerableHelpers.GetEmptyEnumerator<double>();

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
            List<int> list = new List<int> {1, 2, 3, 4, 5};

            int[] array = EnumerableHelpers.ToArray(list, out int length);

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
            List<string> emptyList = new List<string>();

            string[] array = EnumerableHelpers.ToArray(emptyList, out int length);

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
            List<int> list = new List<int> {10, 20, 30, 40, 50};

            int[] array = EnumerableHelpers.ToArray(list, out int length);

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
            List<int> list = new List<int>();
            for (int i = 0; i < 10000; i++)
            {
                list.Add(i);
            }

            int[] array = EnumerableHelpers.ToArray(list, out int length);

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
            List<string> strings = new List<string> {"apple", "banana", "cherry"};

            string[] array = EnumerableHelpers.ToArray(strings, out int length);

            Assert.Equal(3, length);
            Assert.Equal("apple", array[0]);
            Assert.Equal("banana", array[1]);
            Assert.Equal("cherry", array[2]);
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