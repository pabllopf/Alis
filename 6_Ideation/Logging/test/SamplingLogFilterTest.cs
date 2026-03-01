// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SamplingLogFilterTest.cs
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
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Filters;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Comprehensive unit tests for the SamplingLogFilter class.
    ///     Validates sampling-based filtering for high-frequency logging.
    /// </summary>
    public class SamplingLogFilterTest
    {
        /// <summary>
        /// Tests that sampling log filter sample rate 1 should allow all
        /// </summary>
        [Fact]
        public void SamplingLogFilter_SampleRate1_ShouldAllowAll()
        {
            // Arrange
            SamplingLogFilter filter = new SamplingLogFilter(1);

            // Act & Assert - With sample rate 1, every entry passes (1 % 1 = 0)
            for (int i = 0; i < 100; i++)
            {
                Assert.True(filter.ShouldLog(CreateEntry()), $"Entry {i} should pass");
            }
        }

        /// <summary>
        /// Tests that sampling log filter sample rate 2 should alternate
        /// </summary>
        [Fact]
        public void SamplingLogFilter_SampleRate2_ShouldAlternate()
        {
            // Arrange
            SamplingLogFilter filter = new SamplingLogFilter(2);

            // Act & Assert
            bool[] results = new bool[10];
            for (int i = 0; i < 10; i++)
            {
                results[i] = filter.ShouldLog(CreateEntry());
            }

            // Should have exactly 5 passes and 5 blocks (alternating)
            int passCount = 0;
            for (int i = 0; i < 10; i++)
            {
                if (results[i])
                {
                    passCount++;
                }
            }

            Assert.Equal(5, passCount);
        }

        /// <summary>
        /// Tests that sampling log filter sample rate 10 should pass every tenth
        /// </summary>
        [Fact]
        public void SamplingLogFilter_SampleRate10_ShouldPassEveryTenth()
        {
            // Arrange
            SamplingLogFilter filter = new SamplingLogFilter(10);

            // Act
            int passCount = 0;
            for (int i = 0; i < 100; i++)
            {
                if (filter.ShouldLog(CreateEntry()))
                {
                    passCount++;
                }
            }

            // Assert
            Assert.Equal(10, passCount); // 100 / 10 = 10
        }

        /// <summary>
        /// Tests that sampling log filter sample rate 3 should pass every third
        /// </summary>
        [Fact]
        public void SamplingLogFilter_SampleRate3_ShouldPassEveryThird()
        {
            // Arrange
            SamplingLogFilter filter = new SamplingLogFilter(3);

            // Act
            int passCount = 0;
            for (int i = 0; i < 99; i++)
            {
                if (filter.ShouldLog(CreateEntry()))
                {
                    passCount++;
                }
            }

            // Assert
            Assert.Equal(33, passCount); // 99 / 3 = 33
        }

        /// <summary>
        /// Tests that sampling log filter invalid sample rate should throw
        /// </summary>
        [Fact]
        public void SamplingLogFilter_InvalidSampleRate_ShouldThrow()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new SamplingLogFilter(0));
            Assert.Throws<ArgumentException>(() => new SamplingLogFilter(-1));
        }

        /// <summary>
        /// Tests that sampling log filter large sample rate should rarely pass
        /// </summary>
        [Fact]
        public void SamplingLogFilter_LargeSampleRate_ShouldRarelyPass()
        {
            // Arrange
            SamplingLogFilter filter = new SamplingLogFilter(1000);

            // Act
            int passCount = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (filter.ShouldLog(CreateEntry()))
                {
                    passCount++;
                }
            }

            // Assert
            Assert.Equal(1, passCount); // Only one should pass at position 1000
        }

        /// <summary>
        /// Tests that sampling log filter null entry should return false
        /// </summary>
        [Fact]
        public void SamplingLogFilter_NullEntry_ShouldReturnFalse()
        {
            // Arrange
            SamplingLogFilter filter = new SamplingLogFilter(1);

            // Act & Assert
            Assert.False(filter.ShouldLog(null));
        }

        /// <summary>
        /// Tests that sampling log filter has name
        /// </summary>
        [Fact]
        public void SamplingLogFilter_HasName()
        {
            // Arrange
            SamplingLogFilter filter = new SamplingLogFilter(10);

            // Act & Assert
            Assert.NotNull(filter.Name);
            Assert.Contains("SamplingFilter", filter.Name);
            Assert.Contains("10", filter.Name);
        }

        /// <summary>
        /// Tests that sampling log filter counter increments correctly
        /// </summary>
        [Fact]
        public void SamplingLogFilter_CounterIncrementsCorrectly()
        {
            // Arrange
            SamplingLogFilter filter = new SamplingLogFilter(5);

            // Act & Assert - The counter should increment each call
            bool[] results = new bool[15];
            for (int i = 0; i < 15; i++)
            {
                results[i] = filter.ShouldLog(CreateEntry());
            }

            // Should have exactly 3 passes (at positions 5, 10, 15)
            int passCount = 0;
            int[] passPositions = new int[3];
            int passIdx = 0;

            for (int i = 0; i < 15; i++)
            {
                if (results[i])
                {
                    passPositions[passIdx] = i + 1; // 1-based
                    passCount++;
                    passIdx++;
                }
            }

            Assert.Equal(3, passCount);
            Assert.Equal(5, passPositions[0]);
            Assert.Equal(10, passPositions[1]);
            Assert.Equal(15, passPositions[2]);
        }

        /// <summary>
        /// Tests that sampling log filter multiple instances should independently sample
        /// </summary>
        [Fact]
        public void SamplingLogFilter_MultipleInstances_ShouldIndependentlySample()
        {
            // Arrange
            SamplingLogFilter filter1 = new SamplingLogFilter(2);
            SamplingLogFilter filter2 = new SamplingLogFilter(2);

            // Act
            bool[] f1Results = new bool[10];
            bool[] f2Results = new bool[10];

            for (int i = 0; i < 10; i++)
            {
                f1Results[i] = filter1.ShouldLog(CreateEntry());
                f2Results[i] = filter2.ShouldLog(CreateEntry());
            }

            // Assert - Both should have same pattern (1 in N)
            for (int i = 0; i < 10; i++)
            {
                Assert.Equal(f1Results[i], f2Results[i]);
            }
        }

        /// <summary>
        /// Tests that sampling log filter high volume should maintain ratio
        /// </summary>
        [Fact]
        public void SamplingLogFilter_HighVolume_ShouldMaintainRatio()
        {
            // Arrange
            SamplingLogFilter filter = new SamplingLogFilter(100);
            const int totalEntries = 10000;

            // Act
            int passCount = 0;
            for (int i = 0; i < totalEntries; i++)
            {
                if (filter.ShouldLog(CreateEntry()))
                {
                    passCount++;
                }
            }

            // Assert - Should be approximately 100 passes (1 out of 100)
            Assert.Equal(100, passCount);
        }

        /// <summary>
        /// Tests that sampling log filter sample rate 1 name should indicate pass all
        /// </summary>
        [Fact]
        public void SamplingLogFilter_SampleRate1_Name_ShouldIndicatePassAll()
        {
            // Arrange
            SamplingLogFilter filter = new SamplingLogFilter(1);

            // Act & Assert
            Assert.Contains("1", filter.Name);
        }

        /// <summary>
        /// Tests that sampling log filter consecutive calls should progressively
        /// </summary>
        [Fact]
        public void SamplingLogFilter_ConsecutiveCalls_ShouldProgressively()
        {
            // Arrange
            SamplingLogFilter filter = new SamplingLogFilter(5);

            // Act & Assert
            Assert.False(filter.ShouldLog(CreateEntry())); // 1st
            Assert.False(filter.ShouldLog(CreateEntry())); // 2nd
            Assert.False(filter.ShouldLog(CreateEntry())); // 3rd
            Assert.False(filter.ShouldLog(CreateEntry())); // 4th
            Assert.True(filter.ShouldLog(CreateEntry())); // 5th - Pass
            Assert.False(filter.ShouldLog(CreateEntry())); // 6th
            Assert.False(filter.ShouldLog(CreateEntry())); // 7th
            Assert.False(filter.ShouldLog(CreateEntry())); // 8th
            Assert.False(filter.ShouldLog(CreateEntry())); // 9th
            Assert.True(filter.ShouldLog(CreateEntry())); // 10th - Pass
        }

        /// <summary>
        /// Creates the entry using the specified level
        /// </summary>
        /// <param name="level">The level</param>
        /// <returns>The log entry</returns>
        private static ILogEntry CreateEntry(LogLevel level = LogLevel.Info) => new LogEntry(level, "Test message", "TestLogger");
    }
}