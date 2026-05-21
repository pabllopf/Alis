

using System;
using System.Collections.Generic;
using Alis.Core.Physic.Common.Logic;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Logic
{
    /// <summary>
    ///     The ray data comparer test class
    /// </summary>
    public class RayDataComparerTest
    {
        /// <summary>
        ///     Tests that compare should return positive when a greater than b
        /// </summary>
        [Fact]
        public void Compare_ShouldReturnPositive_WhenAGreaterThanB()
        {
            RayDataComparer comparer = new RayDataComparer();
            float a = 10.0f;
            float b = 5.0f;

            int result = ((IComparer<float>) comparer).Compare(a, b);

            Assert.Equal(1, result);
        }

        /// <summary>
        ///     Tests that compare should return negative when a less than b
        /// </summary>
        [Fact]
        public void Compare_ShouldReturnNegative_WhenALessThanB()
        {
            RayDataComparer comparer = new RayDataComparer();
            float a = 5.0f;
            float b = 10.0f;

            int result = ((IComparer<float>) comparer).Compare(a, b);

            Assert.Equal(-1, result);
        }

        /// <summary>
        ///     Tests that compare should return zero when a equals b
        /// </summary>
        [Fact]
        public void Compare_ShouldReturnZero_WhenAEqualsB()
        {
            RayDataComparer comparer = new RayDataComparer();
            float a = 5.0f;
            float b = 5.0f;

            int result = ((IComparer<float>) comparer).Compare(a, b);

            Assert.Equal(0, result);
        }

        /// <summary>
        ///     Tests that compare should handle negative values
        /// </summary>
        [Fact]
        public void Compare_ShouldHandleNegativeValues()
        {
            RayDataComparer comparer = new RayDataComparer();
            float a = -10.0f;
            float b = -5.0f;

            int result = ((IComparer<float>) comparer).Compare(a, b);

            Assert.Equal(-1, result);
        }

        /// <summary>
        ///     Tests that compare should handle zero values
        /// </summary>
        [Fact]
        public void Compare_ShouldHandleZeroValues()
        {
            RayDataComparer comparer = new RayDataComparer();
            float a = 0.0f;
            float b = 0.0f;

            int result = ((IComparer<float>) comparer).Compare(a, b);

            Assert.Equal(0, result);
        }

        /// <summary>
        ///     Tests that compare should handle very small differences
        /// </summary>
        [Fact]
        public void Compare_ShouldHandleVerySmallDifferences()
        {
            RayDataComparer comparer = new RayDataComparer();
            float a = 5.00001f;
            float b = 5.0f;

            int result = ((IComparer<float>) comparer).Compare(a, b);

            Assert.Equal(1, result);
        }

        /// <summary>
        ///     Tests that ray data comparer should implement i comparer
        /// </summary>
        [Fact]
        public void RayDataComparer_ShouldImplementIComparer()
        {
            RayDataComparer comparer = new RayDataComparer();

            Assert.IsAssignableFrom<IComparer<float>>(comparer);
        }

        /// <summary>
        ///     Tests that compare should be consistent
        /// </summary>
        [Fact]
        public void Compare_ShouldBeConsistent()
        {
            RayDataComparer comparer = new RayDataComparer();
            float a = 7.5f;
            float b = 3.2f;

            int result1 = ((IComparer<float>) comparer).Compare(a, b);
            int result2 = ((IComparer<float>) comparer).Compare(a, b);

            Assert.Equal(result1, result2);
        }

        /// <summary>
        ///     Tests that compare should be antisymmetric
        /// </summary>
        [Fact]
        public void Compare_ShouldBeAntisymmetric()
        {
            RayDataComparer comparer = new RayDataComparer();
            float a = 7.5f;
            float b = 3.2f;

            int resultAB = ((IComparer<float>) comparer).Compare(a, b);
            int resultBA = ((IComparer<float>) comparer).Compare(b, a);

            Assert.Equal(-resultAB, resultBA);
        }

        /// <summary>
        ///     Tests that compare should handle large values
        /// </summary>
        [Fact]
        public void Compare_ShouldHandleLargeValues()
        {
            RayDataComparer comparer = new RayDataComparer();
            float a = 1000000.0f;
            float b = 999999.0f;

            int result = ((IComparer<float>) comparer).Compare(a, b);

            Assert.Equal(1, result);
        }

        /// <summary>
        ///     Tests that compare should handle mixed sign values
        /// </summary>
        [Fact]
        public void Compare_ShouldHandleMixedSignValues()
        {
            RayDataComparer comparer = new RayDataComparer();
            float a = -5.0f;
            float b = 5.0f;

            int result = ((IComparer<float>) comparer).Compare(a, b);

            Assert.Equal(-1, result);
        }

        /// <summary>
        ///     Tests that compare should work with sorting algorithms
        /// </summary>
        [Fact]
        public void Compare_ShouldWorkWithSortingAlgorithms()
        {
            RayDataComparer comparer = new RayDataComparer();
            float[] array = new[] {5.0f, 2.0f, 8.0f, 1.0f, 9.0f};

            Array.Sort(array, comparer);

            Assert.Equal(1.0f, array[0]);
            Assert.Equal(2.0f, array[1]);
            Assert.Equal(5.0f, array[2]);
            Assert.Equal(8.0f, array[3]);
            Assert.Equal(9.0f, array[4]);
        }
    }
}