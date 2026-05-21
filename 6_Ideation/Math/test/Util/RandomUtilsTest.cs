

using System;
using Alis.Core.Aspect.Math.Util;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Util
{
    /// <summary>
    ///     The random utils test class
    /// </summary>
    public class RandomUtilsTest
    {
        /// <summary>
        ///     Tests that get int 32 with min and max values should return within range
        /// </summary>
        [Fact]
        public void GetInt32_WithMinAndMaxValues_ShouldReturnWithinRange()
        {
            int minValue = 1;
            int maxValue = 10;
            int result = RandomUtils.GetInt32(minValue, maxValue);

            Assert.InRange(result, minValue, maxValue);
        }

        /// <summary>
        ///     Tests that get int 32 with min and max values should throw argument exception when min value is greater than max
        ///     value
        /// </summary>
        [Fact]
        public void GetInt32_WithMinAndMaxValues_ShouldThrowArgumentException_WhenMinValueIsGreaterThanMaxValue()
        {
            int minValue = 10;
            int maxValue = 1;

            Assert.Throws<ArgumentException>(() => RandomUtils.GetInt32(minValue, maxValue));
        }

        /// <summary>
        ///     Tests that get int 32 with value should return within range
        /// </summary>
        [Fact]
        public void GetInt32_WithValue_ShouldReturnWithinRange()
        {
            int value = 10;
            int result = RandomUtils.GetInt32(value);

            Assert.InRange(result, 0, value);
        }

        /// <summary>
        ///     Tests that get int 32 with value should throw argument exception when value is negative
        /// </summary>
        [Fact]
        public void GetInt32_WithValue_ShouldThrowArgumentException_WhenValueIsNegative()
        {
            int value = -1;

            Assert.Throws<ArgumentException>(() => RandomUtils.GetInt32(value));
        }

        /// <summary>
        ///     Tests that get int 32 with equal min and max returns that exact value
        /// </summary>
        [Fact]
        public void GetInt32_WithEqualMinAndMax_ReturnsThatExactValue()
        {
            int result = RandomUtils.GetInt32(7, 7);

            Assert.Equal(7, result);
        }

        /// <summary>
        ///     Tests that get int 32 with zero upper bound returns zero
        /// </summary>
        [Fact]
        public void GetInt32_WithZeroUpperBound_ReturnsZero()
        {
            int result = RandomUtils.GetInt32(0);

            Assert.Equal(0, result);
        }

        /// <summary>
        ///     Tests that get int 32 with negative and positive bounds returns within range
        /// </summary>
        [Fact]
        public void GetInt32_WithNegativeAndPositiveBounds_ReturnsWithinRange()
        {
            int result = RandomUtils.GetInt32(-10, 10);

            Assert.InRange(result, -10, 10);
        }
    }
}