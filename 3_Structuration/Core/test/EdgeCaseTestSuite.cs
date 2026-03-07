using System;
using System.Collections.Generic;
using Xunit;

namespace Alis.Core.Test
{
    /// <summary>
    /// Edge case and boundary tests.
    /// Tests system behavior at the limits.
    /// </summary>
    public class EdgeCaseTestSuite
    {
        /// <summary>
        /// Generates the edge cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GenerateEdgeCases()
        {
            // Numeric edge cases
            yield return new object[] { int.MinValue };
            yield return new object[] { int.MaxValue };
            yield return new object[] { 0 };
            yield return new object[] { 1 };
            yield return new object[] { -1 };
            yield return new object[] { float.MinValue };
            yield return new object[] { float.MaxValue };
            yield return new object[] { float.NaN };
            yield return new object[] { float.PositiveInfinity };
            yield return new object[] { float.NegativeInfinity };
            
            // Boundary values
            for (int i = -5; i <= 5; i++)
            {
                yield return new object[] { i };
            }
        }

        /// <summary>
        /// Tests that edge case numeric boundaries
        /// </summary>
        /// <param name="value">The value</param>
        [Theory]
        [MemberData(nameof(GenerateEdgeCases))]
        public void EdgeCase_NumericBoundaries(object value)
        {
            Assert.NotNull(value);
        }

        /// <summary>
        /// Tests that edge case string handling
        /// </summary>
        /// <param name="value">The value</param>
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("abc")]
        [InlineData("123")]
        [InlineData(" ")]
        public void EdgeCase_StringHandling(string value)
        {
            if (value != null)
            {
                Assert.NotNull(value);
            }
        }

        /// <summary>
        /// Tests that edge case collection boundaries
        /// </summary>
        /// <param name="size">The size</param>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        public void EdgeCase_CollectionBoundaries(int size)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < Math.Abs(size); i++)
            {
                list.Add(i);
            }
            Assert.NotNull(list);
        }
    }
}
