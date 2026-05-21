

using System;
using System.Collections.Generic;
using Alis.Core.Ecs.Collections;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     Extended tests for EnumerableHelpers utility functions
    ///     to validate conversion, filtering, and enumerable operations.
    /// </summary>
    public class EnumerableHelpersExtendedTest
    {
        /// <summary>
        ///     Test that ToArray converts enumerable to array correctly.
        /// </summary>
        [Fact]
        public void ToArray_Enumerable_ConvertsSuccessfully()
        {
            int[] enumerable = new[] {1, 2, 3, 4, 5};

            int[] array = EnumerableHelpers.ToArray(enumerable, out int count);

            Assert.NotNull(array);
            Assert.Equal(5, count);
        }

        /// <summary>
        ///     Test that ToArray with List maintains order.
        /// </summary>
        [Fact]
        public void ToArray_ListEnumerable_OrderPreserved()
        {
            List<string> list = new List<string> {"a", "b", "c", "d"};

            string[] array = EnumerableHelpers.ToArray(list, out int count);

            Assert.Equal(4, count);
            Assert.Equal("a", array[0]);
            Assert.Equal("d", array[count - 1]);
        }

        /// <summary>
        ///     Test that ToArray handles empty enumerable.
        /// </summary>
        [Fact]
        public void ToArray_EmptyEnumerable_ReturnsEmptyArray()
        {
            List<int> emptyList = new List<int>();

            int[] array = EnumerableHelpers.ToArray(emptyList, out int count);

            Assert.Equal(0, count);
        }

        /// <summary>
        ///     Test that ToArray works with different value types.
        /// </summary>
        [Fact]
        public void ToArray_ValueTypes_ConvertsCorrectly()
        {
            List<Guid> guids = new List<Guid>
            {
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid()
            };

            Guid[] array = EnumerableHelpers.ToArray(guids, out int count);

            Assert.Equal(3, count);
            Assert.Equal(guids[0], array[0]);
        }

        /// <summary>
        ///     Test that ToArray with large enumerable works efficiently.
        /// </summary>
        [Fact]
        public void ToArray_LargeEnumerable_ConvertedSuccessfully()
        {
            List<int> largeList = new List<int>();
            for (int i = 0; i < 10000; i++)
            {
                largeList.Add(i);
            }

            int[] array = EnumerableHelpers.ToArray(largeList, out int count);

            Assert.Equal(10000, count);
            Assert.Equal(0, array[0]);
            Assert.Equal(9999, array[count - 1]);
        }

        /// <summary>
        ///     Test that ToArray properly counts elements.
        /// </summary>
        [Fact]
        public void ToArray_OutputCount_MatchesArrayLength()
        {
            List<double> list = new List<double> {1.1, 2.2, 3.3, 4.4, 5.5};

            double[] array = EnumerableHelpers.ToArray(list, out int count);

            Assert.Equal(count, list.Count);
            Assert.True(count > 0);
        }

        /// <summary>
        ///     Test that ToArray works with custom enumerables.
        /// </summary>
        [Fact]
        public void ToArray_CustomEnumerable_Works()
        {
            IEnumerable<int> enumerable = new[] {10, 20, 30, 40};

            int[] array = EnumerableHelpers.ToArray(enumerable, out int count);

            Assert.Equal(4, count);
        }

        /// <summary>
        ///     Test that ToArray with reference types maintains references.
        /// </summary>
        [Fact]
        public void ToArray_ReferenceTypes_MaintainReferences()
        {
            var obj1 = new {ID = 1};
            var obj2 = new {ID = 2};
            List<object> list = new List<object> {obj1, obj2};

            object[] array = EnumerableHelpers.ToArray(list, out int count);

            Assert.Same(obj1, array[0]);
            Assert.Same(obj2, array[1]);
        }
    }
}