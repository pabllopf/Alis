

using System;
using Alis.Extension.Media.FFmpeg.Encoding.Builders;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Encoding.Builders
{
    /// <summary>
    ///     The quality test class
    /// </summary>
    /// <seealso cref="Quality" />
    public class QualityTest
    {
        /// <summary>
        ///     Tests that quality good should have correct value
        /// </summary>
        [Fact]
        public void Quality_Good_ShouldHaveCorrectValue()
        {
            Quality quality = Quality.Good;

            Assert.Equal(0, (int) quality);
        }

        /// <summary>
        ///     Tests that quality best should have correct value
        /// </summary>
        [Fact]
        public void Quality_Best_ShouldHaveCorrectValue()
        {
            Quality quality = Quality.Best;

            Assert.Equal(1, (int) quality);
        }

        /// <summary>
        ///     Tests that quality real time should have correct value
        /// </summary>
        [Fact]
        public void Quality_RealTime_ShouldHaveCorrectValue()
        {
            Quality quality = Quality.RealTime;

            Assert.Equal(2, (int) quality);
        }

        /// <summary>
        ///     Tests that quality enum should have three values
        /// </summary>
        [Fact]
        public void Quality_Enum_ShouldHaveThreeValues()
        {
            Quality[] values = (Quality[]) Enum.GetValues(typeof(Quality));

            Assert.Equal(3, values.Length);
        }

        /// <summary>
        ///     Tests that quality should be convertible to string
        /// </summary>
        [Fact]
        public void Quality_ShouldBeConvertibleToString()
        {
            Quality good = Quality.Good;
            Quality best = Quality.Best;
            Quality realTime = Quality.RealTime;

            string goodStr = good.ToString();
            string bestStr = best.ToString();
            string realTimeStr = realTime.ToString();

            Assert.Equal("Good", goodStr);
            Assert.Equal("Best", bestStr);
            Assert.Equal("RealTime", realTimeStr);
        }

        /// <summary>
        ///     Tests that quality should be parseable from string
        /// </summary>
        [Fact]
        public void Quality_ShouldBeParseableFromString()
        {
            Quality good = (Quality) Enum.Parse(typeof(Quality), "Good");
            Quality best = (Quality) Enum.Parse(typeof(Quality), "Best");

            Assert.Equal(Quality.Good, good);
            Assert.Equal(Quality.Best, best);
        }

        /// <summary>
        ///     Tests that quality should support equality comparison
        /// </summary>
        [Fact]
        public void Quality_ShouldSupportEqualityComparison()
        {
            Quality good1 = Quality.Good;
            Quality good2 = Quality.Good;
            Quality best = Quality.Best;

            Assert.Equal(good1, good2);
            Assert.NotEqual(good1, best);
        }

        /// <summary>
        ///     Tests that quality to lower invariant should work correctly
        /// </summary>
        [Fact]
        public void Quality_ToLowerInvariant_ShouldWorkCorrectly()
        {
            Quality good = Quality.Good;
            Quality best = Quality.Best;
            Quality realTime = Quality.RealTime;

            string goodLower = good.ToString().ToLowerInvariant();
            string bestLower = best.ToString().ToLowerInvariant();
            string realTimeLower = realTime.ToString().ToLowerInvariant();

            Assert.Equal("good", goodLower);
            Assert.Equal("best", bestLower);
            Assert.Equal("realtime", realTimeLower);
        }

        /// <summary>
        ///     Tests that quality should be usable in switch statement
        /// </summary>
        [Fact]
        public void Quality_ShouldBeUsableInSwitchStatement()
        {
            Quality quality = Quality.Best;
            string result = string.Empty;

            switch (quality)
            {
                case Quality.Good:
                    result = "Good";
                    break;
                case Quality.Best:
                    result = "Best";
                    break;
                case Quality.RealTime:
                    result = "RealTime";
                    break;
            }

            Assert.Equal("Best", result);
        }

        /// <summary>
        ///     Tests that quality all values should be defined
        /// </summary>
        [Fact]
        public void Quality_AllValues_ShouldBeDefined()
        {
            Assert.True(Enum.IsDefined(typeof(Quality), Quality.Good));
            Assert.True(Enum.IsDefined(typeof(Quality), Quality.Best));
            Assert.True(Enum.IsDefined(typeof(Quality), Quality.RealTime));
        }

        /// <summary>
        ///     Tests that quality should have unique values
        /// </summary>
        [Fact]
        public void Quality_ShouldHaveUniqueValues()
        {
            int goodValue = (int) Quality.Good;
            int bestValue = (int) Quality.Best;
            int realTimeValue = (int) Quality.RealTime;

            Assert.NotEqual(goodValue, bestValue);
            Assert.NotEqual(bestValue, realTimeValue);
            Assert.NotEqual(goodValue, realTimeValue);
        }

        /// <summary>
        ///     Tests that quality should be castable to int
        /// </summary>
        [Fact]
        public void Quality_ShouldBeCastableToInt()
        {
            Quality quality = Quality.Best;

            int value = (int) quality;

            Assert.Equal(1, value);
        }

        /// <summary>
        ///     Tests that quality should be castable from int
        /// </summary>
        [Fact]
        public void Quality_ShouldBeCastableFromInt()
        {
            int value = 2;

            Quality quality = (Quality) value;

            Assert.Equal(Quality.RealTime, quality);
        }
    }
}