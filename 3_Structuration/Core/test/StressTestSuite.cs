using System.Collections.Generic;
using Xunit;

namespace Alis.Core.Test
{
    /// <summary>
    /// Stress tests for performance validation.
    /// </summary>
    public class StressTestSuite
    {
        /// <summary>
        /// Tests that stress massive loop operations
        /// </summary>
        /// <param name="iterations">The iterations</param>
        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(10000)]
        [InlineData(100000)]
        public void Stress_MassiveLoopOperations(int iterations)
        {
            int count = 0;
            for (int i = 0; i < iterations; i++)
            {
                count++;
            }
            Assert.Equal(iterations, count);
        }

        /// <summary>
        /// Tests that stress memory allocation
        /// </summary>
        /// <param name="allocations">The allocations</param>
        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public void Stress_MemoryAllocation(int allocations)
        {
            var objects = new List<object>();
            for (int i = 0; i < allocations; i++)
            {
                objects.Add(new object());
            }
            Assert.Equal(allocations, objects.Count);
        }

        /// <summary>
        /// Tests that stress nested operations
        /// </summary>
        /// <param name="depth">The depth</param>
        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(100)]
        public void Stress_NestedOperations(int depth)
        {
            int result = NestedFunction(depth);
            Assert.True(result >= 0);
        }

        /// <summary>
        /// Nesteds the function using the specified depth
        /// </summary>
        /// <param name="depth">The depth</param>
        /// <returns>The int</returns>
        private int NestedFunction(int depth)
        {
            if (depth <= 0) return 0;
            return 1 + NestedFunction(depth - 1);
        }

        /// <summary>
        /// Tests that stress string operations
        /// </summary>
        /// <param name="count">The count</param>
        [Theory]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(10000)]
        public void Stress_StringOperations(int count)
        {
            var strings = new List<string>();
            for (int i = 0; i < count; i++)
            {
                strings.Add(i.ToString());
            }
            Assert.Equal(count, strings.Count);
        }

        /// <summary>
        /// Tests that stress dictionary operations
        /// </summary>
        /// <param name="count">The count</param>
        [Theory]
        [InlineData(50)]
        [InlineData(100)]
        [InlineData(500)]
        public void Stress_DictionaryOperations(int count)
        {
            var dict = new Dictionary<int, string>();
            for (int i = 0; i < count; i++)
            {
                dict[i] = $"Value{i}";
            }
            Assert.Equal(count, dict.Count);
        }
    }
}
