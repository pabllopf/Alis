// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ResourceMetricsComprehensiveTest.cs
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
using Alis.Extension.Profile.Models;
using Xunit;

namespace Alis.Extension.Profile.Test.Models
{
    /// <summary>
    ///     Comprehensive unit tests for ResourceMetrics struct.
    ///     Tests all public members including constructors, properties, equality operators,
    ///     and edge cases for complete code coverage.
    /// </summary>
    public class ResourceMetricsComprehensiveTest
    {
        /// <summary>
        ///     Tests that constructor successfully initializes with valid parameters.
        /// </summary>
        [Fact]
        public void Constructor_InitializesWithValidParameters()
        {
            double cpuUsage = 100.5;
            long memoryUsage = 1024000;
            int gcCount = 5;
            int threadCount = 10;
            DateTime timestamp = DateTime.Now;

            ResourceMetrics metrics = new ResourceMetrics(cpuUsage, memoryUsage, gcCount, threadCount, timestamp);

            Assert.Equal(cpuUsage, metrics.CpuUsageMilliseconds);
            Assert.Equal(memoryUsage, metrics.MemoryUsageBytes);
            Assert.Equal(gcCount, metrics.GarbageCollectionCount);
            Assert.Equal(threadCount, metrics.ThreadCount);
            Assert.Equal(timestamp, metrics.Timestamp);
        }

        /// <summary>
        ///     Tests that constructor throws exception when CPU usage is negative.
        /// </summary>
        [Fact]
        public void Constructor_ThrowsArgumentException_WhenCpuUsageIsNegative()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
                new ResourceMetrics(-1, 1000, 5, 10, DateTime.Now));

            Assert.Contains("CPU usage cannot be negative", ex.Message);
        }

        /// <summary>
        ///     Tests that constructor throws exception when memory usage is negative.
        /// </summary>
        [Fact]
        public void Constructor_ThrowsArgumentException_WhenMemoryUsageIsNegative()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
                new ResourceMetrics(100, -1, 5, 10, DateTime.Now));

            Assert.Contains("Memory usage cannot be negative", ex.Message);
        }

        /// <summary>
        ///     Tests that constructor accepts zero values for CPU and memory.
        /// </summary>
        [Fact]
        public void Constructor_AcceptsZeroValues()
        {
            ResourceMetrics metrics = new ResourceMetrics(0, 0, 0, 0, DateTime.MinValue);

            Assert.Equal(0, metrics.CpuUsageMilliseconds);
            Assert.Equal(0, metrics.MemoryUsageBytes);
            Assert.Equal(0, metrics.GarbageCollectionCount);
            Assert.Equal(0, metrics.ThreadCount);
            Assert.Equal(DateTime.MinValue, metrics.Timestamp);
        }

        /// <summary>
        ///     Tests that Empty static property returns a ResourceMetrics with all zero values.
        /// </summary>
        [Fact]
        public void Empty_ReturnsMetricsWithAllZeroValues()
        {
            ResourceMetrics empty = ResourceMetrics.Empty;

            Assert.Equal(0, empty.CpuUsageMilliseconds);
            Assert.Equal(0, empty.MemoryUsageBytes);
            Assert.Equal(0, empty.GarbageCollectionCount);
            Assert.Equal(0, empty.ThreadCount);
            Assert.Equal(DateTime.MinValue, empty.Timestamp);
        }

        /// <summary>
        ///     Tests that Equals method returns true for identical ResourceMetrics.
        /// </summary>
        [Fact]
        public void Equals_ReturnsTrueForIdenticalMetrics()
        {
            DateTime timestamp = DateTime.Now;
            ResourceMetrics metrics1 = new ResourceMetrics(100, 1000, 5, 10, timestamp);
            ResourceMetrics metrics2 = new ResourceMetrics(100, 1000, 5, 10, timestamp);

            Assert.True(metrics1.Equals(metrics2));
        }

        /// <summary>
        ///     Tests that Equals method returns false for different CPU usage.
        /// </summary>
        [Fact]
        public void Equals_ReturnsFalseForDifferentCpuUsage()
        {
            DateTime timestamp = DateTime.Now;
            ResourceMetrics metrics1 = new ResourceMetrics(100, 1000, 5, 10, timestamp);
            ResourceMetrics metrics2 = new ResourceMetrics(200, 1000, 5, 10, timestamp);

            Assert.False(metrics1.Equals(metrics2));
        }

        /// <summary>
        ///     Tests that Equals method returns false for different memory usage.
        /// </summary>
        [Fact]
        public void Equals_ReturnsFalseForDifferentMemoryUsage()
        {
            DateTime timestamp = DateTime.Now;
            ResourceMetrics metrics1 = new ResourceMetrics(100, 1000, 5, 10, timestamp);
            ResourceMetrics metrics2 = new ResourceMetrics(100, 2000, 5, 10, timestamp);

            Assert.False(metrics1.Equals(metrics2));
        }

        /// <summary>
        ///     Tests that Equals method returns false for different GC count.
        /// </summary>
        [Fact]
        public void Equals_ReturnsFalseForDifferentGarbageCollectionCount()
        {
            DateTime timestamp = DateTime.Now;
            ResourceMetrics metrics1 = new ResourceMetrics(100, 1000, 5, 10, timestamp);
            ResourceMetrics metrics2 = new ResourceMetrics(100, 1000, 10, 10, timestamp);

            Assert.False(metrics1.Equals(metrics2));
        }

        /// <summary>
        ///     Tests that Equals method returns false for different thread count.
        /// </summary>
        [Fact]
        public void Equals_ReturnsFalseForDifferentThreadCount()
        {
            DateTime timestamp = DateTime.Now;
            ResourceMetrics metrics1 = new ResourceMetrics(100, 1000, 5, 10, timestamp);
            ResourceMetrics metrics2 = new ResourceMetrics(100, 1000, 5, 20, timestamp);

            Assert.False(metrics1.Equals(metrics2));
        }

        /// <summary>
        ///     Tests that Equals method returns false for different timestamp.
        /// </summary>
        [Fact]
        public void Equals_ReturnsFalseForDifferentTimestamp()
        {
            DateTime timestamp1 = DateTime.Now;
            DateTime timestamp2 = DateTime.Now.AddSeconds(1);
            ResourceMetrics metrics1 = new ResourceMetrics(100, 1000, 5, 10, timestamp1);
            ResourceMetrics metrics2 = new ResourceMetrics(100, 1000, 5, 10, timestamp2);

            Assert.False(metrics1.Equals(metrics2));
        }

        /// <summary>
        ///     Tests that Equals with object parameter returns true for identical metrics.
        /// </summary>
        [Fact]
        public void EqualsObject_ReturnsTrueForIdenticalMetrics()
        {
            DateTime timestamp = DateTime.Now;
            ResourceMetrics metrics1 = new ResourceMetrics(100, 1000, 5, 10, timestamp);
            object metrics2 = new ResourceMetrics(100, 1000, 5, 10, timestamp);

            Assert.True(metrics1.Equals(metrics2));
        }

        /// <summary>
        ///     Tests that Equals with object parameter returns false for non-ResourceMetrics object.
        /// </summary>
        [Fact]
        public void EqualsObject_ReturnsFalseForNonResourceMetricsObject()
        {
            ResourceMetrics metrics = new ResourceMetrics(100, 1000, 5, 10, DateTime.Now);

            Assert.False(metrics.Equals((object)"not a ResourceMetrics"));
        }

        /// <summary>
        ///     Tests that Equals with object parameter returns false for null object.
        /// </summary>
        [Fact]
        public void EqualsObject_ReturnsFalseForNull()
        {
            ResourceMetrics metrics = new ResourceMetrics(100, 1000, 5, 10, DateTime.Now);

            Assert.False(metrics.Equals((object)null));
        }

        /// <summary>
        ///     Tests that GetHashCode returns consistent values for identical metrics.
        /// </summary>
        [Fact]
        public void GetHashCode_ReturnsSameValueForIdenticalMetrics()
        {
            DateTime timestamp = DateTime.Now;
            ResourceMetrics metrics1 = new ResourceMetrics(100, 1000, 5, 10, timestamp);
            ResourceMetrics metrics2 = new ResourceMetrics(100, 1000, 5, 10, timestamp);

            int hash1 = metrics1.GetHashCode();
            int hash2 = metrics2.GetHashCode();

            Assert.Equal(hash1, hash2);
        }

        /// <summary>
        ///     Tests that GetHashCode returns different values for different metrics.
        /// </summary>
        [Fact]
        public void GetHashCode_ReturnsDifferentValueForDifferentMetrics()
        {
            DateTime timestamp = DateTime.Now;
            ResourceMetrics metrics1 = new ResourceMetrics(100, 1000, 5, 10, timestamp);
            ResourceMetrics metrics2 = new ResourceMetrics(200, 2000, 10, 20, timestamp);

            int hash1 = metrics1.GetHashCode();
            int hash2 = metrics2.GetHashCode();

            Assert.NotEqual(hash1, hash2);
        }

        /// <summary>
        ///     Tests that equality operator returns true for identical metrics.
        /// </summary>
        [Fact]
        public void EqualityOperator_ReturnsTrueForIdenticalMetrics()
        {
            DateTime timestamp = DateTime.Now;
            ResourceMetrics metrics1 = new ResourceMetrics(100, 1000, 5, 10, timestamp);
            ResourceMetrics metrics2 = new ResourceMetrics(100, 1000, 5, 10, timestamp);

            Assert.True(metrics1 == metrics2);
        }

        /// <summary>
        ///     Tests that equality operator returns false for different metrics.
        /// </summary>
        [Fact]
        public void EqualityOperator_ReturnsFalseForDifferentMetrics()
        {
            DateTime timestamp = DateTime.Now;
            ResourceMetrics metrics1 = new ResourceMetrics(100, 1000, 5, 10, timestamp);
            ResourceMetrics metrics2 = new ResourceMetrics(200, 2000, 10, 20, timestamp);

            Assert.False(metrics1 == metrics2);
        }

        /// <summary>
        ///     Tests that inequality operator returns true for different metrics.
        /// </summary>
        [Fact]
        public void InequalityOperator_ReturnsTrueForDifferentMetrics()
        {
            DateTime timestamp = DateTime.Now;
            ResourceMetrics metrics1 = new ResourceMetrics(100, 1000, 5, 10, timestamp);
            ResourceMetrics metrics2 = new ResourceMetrics(200, 2000, 10, 20, timestamp);

            Assert.True(metrics1 != metrics2);
        }

        /// <summary>
        ///     Tests that inequality operator returns false for identical metrics.
        /// </summary>
        [Fact]
        public void InequalityOperator_ReturnsFalseForIdenticalMetrics()
        {
            DateTime timestamp = DateTime.Now;
            ResourceMetrics metrics1 = new ResourceMetrics(100, 1000, 5, 10, timestamp);
            ResourceMetrics metrics2 = new ResourceMetrics(100, 1000, 5, 10, timestamp);

            Assert.False(metrics1 != metrics2);
        }

        /// <summary>
        ///     Tests that ToString returns formatted string with all metric values.
        /// </summary>
        [Fact]
        public void ToString_ReturnsFormattedStringWithAllMetrics()
        {
            DateTime timestamp = new DateTime(2026, 4, 4, 12, 30, 45, 123);
            ResourceMetrics metrics = new ResourceMetrics(100.5, 1024000, 5, 10, timestamp);

            string result = metrics.ToString();

            Assert.Contains("CPU:", result);
            Assert.Contains("Memory:", result);
            Assert.Contains("bytes", result);
            Assert.Contains("GC:", result);
            Assert.Contains("Threads:", result);
            Assert.Contains("2026-04-04", result);
        }

        /// <summary>
        ///     Tests that ToString works with edge case values.
        /// </summary>
        [Fact]
        public void ToString_WorksWithEdgeCaseValues()
        {
            ResourceMetrics metrics = ResourceMetrics.Empty;

            string result = metrics.ToString();

            Assert.NotEmpty(result);
            Assert.Contains("0.00", result);
        }

        /// <summary>
        ///     Tests properties are read-only.
        /// </summary>
        [Fact]
        public void Properties_AreReadOnly()
        {
            DateTime timestamp = DateTime.Now;
            ResourceMetrics metrics = new ResourceMetrics(100, 1000, 5, 10, timestamp);

            double cpu = metrics.CpuUsageMilliseconds;
            long memory = metrics.MemoryUsageBytes;
            int gc = metrics.GarbageCollectionCount;
            int threads = metrics.ThreadCount;
            DateTime ts = metrics.Timestamp;

            Assert.Equal(100, cpu);
            Assert.Equal(1000, memory);
            Assert.Equal(5, gc);
            Assert.Equal(10, threads);
            Assert.Equal(timestamp, ts);
        }

        /// <summary>
        ///     Tests that constructor handles large numeric values.
        /// </summary>
        [Fact]
        public void Constructor_HandlesLargeNumericValues()
        {
            double maxCpu = double.MaxValue;
            long maxMemory = long.MaxValue;
            int maxInt = int.MaxValue;

            ResourceMetrics metrics = new ResourceMetrics(maxCpu, maxMemory, maxInt, maxInt, DateTime.MaxValue);

            Assert.Equal(maxCpu, metrics.CpuUsageMilliseconds);
            Assert.Equal(maxMemory, metrics.MemoryUsageBytes);
            Assert.Equal(maxInt, metrics.GarbageCollectionCount);
            Assert.Equal(maxInt, metrics.ThreadCount);
        }

        /// <summary>
        ///     Tests that floating-point CPU values are preserved with precision.
        /// </summary>
        [Theory]
        [InlineData(0.1)]
        [InlineData(0.01)]
        [InlineData(0.001)]
        [InlineData(123.456)]
        [InlineData(999.999)]
        public void Constructor_PreservesFloatingPointPrecision(double cpuUsage)
        {
            ResourceMetrics metrics = new ResourceMetrics(cpuUsage, 0, 0, 0, DateTime.Now);

            Assert.Equal(cpuUsage, metrics.CpuUsageMilliseconds);
        }

        /// <summary>
        ///     Tests that negative GC count and thread count are allowed (for edge cases).
        /// </summary>
        [Fact]
        public void Constructor_AllowsNegativeGcAndThreadCount()
        {
            ResourceMetrics metrics = new ResourceMetrics(100, 1000, -1, -1, DateTime.Now);

            Assert.Equal(-1, metrics.GarbageCollectionCount);
            Assert.Equal(-1, metrics.ThreadCount);
        }
    }
}


