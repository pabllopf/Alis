// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QualityTest.cs
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
            // Arrange & Act
            Quality quality = Quality.Good;

            // Assert
            Assert.Equal(0, (int) quality);
        }

        /// <summary>
        ///     Tests that quality best should have correct value
        /// </summary>
        [Fact]
        public void Quality_Best_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            Quality quality = Quality.Best;

            // Assert
            Assert.Equal(1, (int) quality);
        }

        /// <summary>
        ///     Tests that quality real time should have correct value
        /// </summary>
        [Fact]
        public void Quality_RealTime_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            Quality quality = Quality.RealTime;

            // Assert
            Assert.Equal(2, (int) quality);
        }

        /// <summary>
        ///     Tests that quality enum should have three values
        /// </summary>
        [Fact]
        public void Quality_Enum_ShouldHaveThreeValues()
        {
            // Arrange & Act
            Quality[] values = (Quality[]) Enum.GetValues(typeof(Quality));

            // Assert
            Assert.Equal(3, values.Length);
        }

        /// <summary>
        ///     Tests that quality should be convertible to string
        /// </summary>
        [Fact]
        public void Quality_ShouldBeConvertibleToString()
        {
            // Arrange
            Quality good = Quality.Good;
            Quality best = Quality.Best;
            Quality realTime = Quality.RealTime;

            // Act
            string goodStr = good.ToString();
            string bestStr = best.ToString();
            string realTimeStr = realTime.ToString();

            // Assert
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
            // Arrange & Act
            Quality good = (Quality) Enum.Parse(typeof(Quality), "Good");
            Quality best = (Quality) Enum.Parse(typeof(Quality), "Best");

            // Assert
            Assert.Equal(Quality.Good, good);
            Assert.Equal(Quality.Best, best);
        }

        /// <summary>
        ///     Tests that quality should support equality comparison
        /// </summary>
        [Fact]
        public void Quality_ShouldSupportEqualityComparison()
        {
            // Arrange
            Quality good1 = Quality.Good;
            Quality good2 = Quality.Good;
            Quality best = Quality.Best;

            // Act & Assert
            Assert.Equal(good1, good2);
            Assert.NotEqual(good1, best);
        }

        /// <summary>
        ///     Tests that quality to lower invariant should work correctly
        /// </summary>
        [Fact]
        public void Quality_ToLowerInvariant_ShouldWorkCorrectly()
        {
            // Arrange
            Quality good = Quality.Good;
            Quality best = Quality.Best;
            Quality realTime = Quality.RealTime;

            // Act
            string goodLower = good.ToString().ToLowerInvariant();
            string bestLower = best.ToString().ToLowerInvariant();
            string realTimeLower = realTime.ToString().ToLowerInvariant();

            // Assert
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
            // Arrange
            Quality quality = Quality.Best;
            string result = string.Empty;

            // Act
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

            // Assert
            Assert.Equal("Best", result);
        }

        /// <summary>
        ///     Tests that quality all values should be defined
        /// </summary>
        [Fact]
        public void Quality_AllValues_ShouldBeDefined()
        {
            // Arrange & Act & Assert
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
            // Arrange
            int goodValue = (int) Quality.Good;
            int bestValue = (int) Quality.Best;
            int realTimeValue = (int) Quality.RealTime;

            // Act & Assert
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
            // Arrange
            Quality quality = Quality.Best;

            // Act
            int value = (int) quality;

            // Assert
            Assert.Equal(1, value);
        }

        /// <summary>
        ///     Tests that quality should be castable from int
        /// </summary>
        [Fact]
        public void Quality_ShouldBeCastableFromInt()
        {
            // Arrange
            int value = 2;

            // Act
            Quality quality = (Quality) value;

            // Assert
            Assert.Equal(Quality.RealTime, quality);
        }
    }
}