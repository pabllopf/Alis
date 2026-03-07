// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ResourceMetricsTest.cs
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
    ///     The resource metrics test class
    /// </summary>
    public class ResourceMetricsTest
    {
        /// <summary>
        ///     Tests that constructor initializes all properties correctly
        /// </summary>
        [Fact]
        public void Constructor_InitializesAllProperties_Correctly()
        {
            // Arrange
            double expectedCpu = 123.45;
            long expectedMemory = 1024000;
            int expectedGc = 10;
            int expectedThreads = 5;
            DateTime expectedTimestamp = DateTime.Now;

            // Act
            ResourceMetrics metrics = new ResourceMetrics(
                expectedCpu,
                expectedMemory,
                expectedGc,
                expectedThreads,
                expectedTimestamp);

            // Assert
            Assert.Equal(expectedCpu, metrics.CpuUsageMilliseconds);
            Assert.Equal(expectedMemory, metrics.MemoryUsageBytes);
            Assert.Equal(expectedGc, metrics.GarbageCollectionCount);
            Assert.Equal(expectedThreads, metrics.ThreadCount);
            Assert.Equal(expectedTimestamp, metrics.Timestamp);
        }

        /// <summary>
        ///     Tests that constructor throws exception when cpu usage is negative
        /// </summary>
        [Fact]
        public void Constructor_ThrowsException_WhenCpuUsageIsNegative()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() =>
                new ResourceMetrics(-1, 1024, 0, 1, DateTime.Now));
        }

        /// <summary>
        ///     Tests that constructor throws exception when memory usage is negative
        /// </summary>
        [Fact]
        public void Constructor_ThrowsException_WhenMemoryUsageIsNegative()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() =>
                new ResourceMetrics(100, -1, 0, 1, DateTime.Now));
        }

        /// <summary>
        ///     Tests that empty returns metrics with zero values
        /// </summary>
        [Fact]
        public void Empty_ReturnsMetrics_WithZeroValues()
        {
            // Act
            ResourceMetrics empty = ResourceMetrics.Empty;

            // Assert
            Assert.Equal(0, empty.CpuUsageMilliseconds);
            Assert.Equal(0, empty.MemoryUsageBytes);
            Assert.Equal(0, empty.GarbageCollectionCount);
            Assert.Equal(0, empty.ThreadCount);
            Assert.Equal(DateTime.MinValue, empty.Timestamp);
        }

        /// <summary>
        ///     Tests that equals returns true for identical metrics
        /// </summary>
        [Fact]
        public void Equals_ReturnsTrue_ForIdenticalMetrics()
        {
            // Arrange
            DateTime timestamp = DateTime.Now;
            ResourceMetrics metrics1 = new ResourceMetrics(100, 2048, 5, 3, timestamp);
            ResourceMetrics metrics2 = new ResourceMetrics(100, 2048, 5, 3, timestamp);

            // Act & Assert
            Assert.True(metrics1.Equals(metrics2));
            Assert.True(metrics1 == metrics2);
            Assert.False(metrics1 != metrics2);
        }

        /// <summary>
        ///     Tests that equals returns false for different metrics
        /// </summary>
        [Fact]
        public void Equals_ReturnsFalse_ForDifferentMetrics()
        {
            // Arrange
            DateTime timestamp = DateTime.Now;
            ResourceMetrics metrics1 = new ResourceMetrics(100, 2048, 5, 3, timestamp);
            ResourceMetrics metrics2 = new ResourceMetrics(200, 2048, 5, 3, timestamp);

            // Act & Assert
            Assert.False(metrics1.Equals(metrics2));
            Assert.False(metrics1 == metrics2);
            Assert.True(metrics1 != metrics2);
        }

        /// <summary>
        ///     Tests that get hash code returns same value for identical metrics
        /// </summary>
        [Fact]
        public void GetHashCode_ReturnsSameValue_ForIdenticalMetrics()
        {
            // Arrange
            DateTime timestamp = DateTime.Now;
            ResourceMetrics metrics1 = new ResourceMetrics(100, 2048, 5, 3, timestamp);
            ResourceMetrics metrics2 = new ResourceMetrics(100, 2048, 5, 3, timestamp);

            // Act & Assert
            Assert.Equal(metrics1.GetHashCode(), metrics2.GetHashCode());
        }


        /// <summary>
        ///     Tests that equals returns false when comparing with null
        /// </summary>
        [Fact]
        public void Equals_ReturnsFalse_WhenComparingWithNull()
        {
            // Arrange
            ResourceMetrics metrics = new ResourceMetrics(100, 2048, 5, 3, DateTime.Now);

            // Act & Assert
            Assert.False(metrics.Equals(null));
        }

        /// <summary>
        ///     Tests that equals returns false when comparing with different type
        /// </summary>
        [Fact]
        public void Equals_ReturnsFalse_WhenComparingWithDifferentType()
        {
            // Arrange
            ResourceMetrics metrics = new ResourceMetrics(100, 2048, 5, 3, DateTime.Now);
            object other = "not a ResourceMetrics";

            // Act & Assert
            Assert.False(metrics.Equals(other));
        }

        /// <summary>
        ///     Tests that to string returns formatted string with all values
        /// </summary>
        [Fact]
        public void ToString_ReturnsFormattedString_WithAllValues()
        {
            // Arrange
            DateTime timestamp = new DateTime(2026, 3, 7, 14, 30, 45, 123);
            ResourceMetrics metrics = new ResourceMetrics(123.456, 2048576, 10, 5, timestamp);

            // Act
            string result = metrics.ToString();

            // Assert
            Assert.Contains("CPU:", result);
            Assert.Contains("123", result); // CPU value
            Assert.Contains("ms", result); // milliseconds unit
            Assert.Contains("Memory:", result);
            Assert.Contains("bytes", result); // bytes unit
            Assert.Contains("GC: 10", result);
            Assert.Contains("Threads: 5", result);
            Assert.Contains("2026-03-07", result); // Date part
            Assert.Contains("14:30:45", result); // Time part
            Assert.Contains("Timestamp:", result);
        }

        /// <summary>
        ///     Tests that constructor throws exception with correct parameter name for negative cpu
        /// </summary>
        [Fact]
        public void Constructor_ThrowsException_WithCorrectParameterName_ForNegativeCpu()
        {
            // Act & Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                new ResourceMetrics(-0.1, 1024, 0, 1, DateTime.Now));
            Assert.Equal("cpuUsageMilliseconds", exception.ParamName);
        }

        /// <summary>
        ///     Tests that constructor throws exception with correct parameter name for negative memory
        /// </summary>
        [Fact]
        public void Constructor_ThrowsException_WithCorrectParameterName_ForNegativeMemory()
        {
            // Act & Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
                new ResourceMetrics(100, -1, 0, 1, DateTime.Now));
            Assert.Equal("memoryUsageBytes", exception.ParamName);
        }

        /// <summary>
        ///     Tests constructor with zero cpu usage
        /// </summary>
        [Fact]
        public void Constructor_WithZeroCpuUsage_Succeeds()
        {
            // Act
            ResourceMetrics metrics = new ResourceMetrics(0, 1024, 5, 3, DateTime.Now);

            // Assert
            Assert.Equal(0, metrics.CpuUsageMilliseconds);
        }

        /// <summary>
        ///     Tests constructor with zero memory usage
        /// </summary>
        [Fact]
        public void Constructor_WithZeroMemoryUsage_Succeeds()
        {
            // Act
            ResourceMetrics metrics = new ResourceMetrics(100, 0, 5, 3, DateTime.Now);

            // Assert
            Assert.Equal(0, metrics.MemoryUsageBytes);
        }

        /// <summary>
        ///     Tests constructor with negative garbage collection count
        /// </summary>
        [Fact]
        public void Constructor_WithNegativeGarbageCollectionCount_Succeeds()
        {
            // Act
            ResourceMetrics metrics = new ResourceMetrics(100, 1024, -5, 3, DateTime.Now);

            // Assert
            Assert.Equal(-5, metrics.GarbageCollectionCount);
        }

        /// <summary>
        ///     Tests constructor with negative thread count
        /// </summary>
        [Fact]
        public void Constructor_WithNegativeThreadCount_Succeeds()
        {
            // Act
            ResourceMetrics metrics = new ResourceMetrics(100, 1024, 5, -3, DateTime.Now);

            // Assert
            Assert.Equal(-3, metrics.ThreadCount);
        }

        /// <summary>
        ///     Tests constructor with large cpu usage values
        /// </summary>
        [Fact]
        public void Constructor_WithLargeCpuUsageValues_Succeeds()
        {
            // Act
            ResourceMetrics metrics = new ResourceMetrics(double.MaxValue, 1024, 5, 3, DateTime.Now);

            // Assert
            Assert.Equal(double.MaxValue, metrics.CpuUsageMilliseconds);
        }

        /// <summary>
        ///     Tests constructor with large memory usage values
        /// </summary>
        [Fact]
        public void Constructor_WithLargeMemoryUsageValues_Succeeds()
        {
            // Act
            ResourceMetrics metrics = new ResourceMetrics(100, long.MaxValue, 5, 3, DateTime.Now);

            // Assert
            Assert.Equal(long.MaxValue, metrics.MemoryUsageBytes);
        }

        /// <summary>
        ///     Tests that equals handles cpu usage with floating point differences
        /// </summary>
        [Fact]
        public void Equals_HandlesCpuUsageWithFloatingPointDifferences()
        {
            // Arrange
            DateTime timestamp = DateTime.Now;
            ResourceMetrics metrics1 = new ResourceMetrics(100.0, 2048, 5, 3, timestamp);
            ResourceMetrics metrics2 = new ResourceMetrics(100.0, 2048, 5, 3, timestamp);

            // Act & Assert
            Assert.True(metrics1.Equals(metrics2));
        }

        /// <summary>
        ///     Tests that equals returns false when cpu differs
        /// </summary>
        [Fact]
        public void Equals_ReturnsFalse_WhenCpuDiffers()
        {
            // Arrange
            DateTime timestamp = DateTime.Now;
            ResourceMetrics metrics1 = new ResourceMetrics(100.0, 2048, 5, 3, timestamp);
            ResourceMetrics metrics2 = new ResourceMetrics(100.1, 2048, 5, 3, timestamp);

            // Act & Assert
            Assert.False(metrics1.Equals(metrics2));
        }

        /// <summary>
        ///     Tests that equals returns false when memory differs
        /// </summary>
        [Fact]
        public void Equals_ReturnsFalse_WhenMemoryDiffers()
        {
            // Arrange
            DateTime timestamp = DateTime.Now;
            ResourceMetrics metrics1 = new ResourceMetrics(100, 2048, 5, 3, timestamp);
            ResourceMetrics metrics2 = new ResourceMetrics(100, 2049, 5, 3, timestamp);

            // Act & Assert
            Assert.False(metrics1.Equals(metrics2));
        }

        /// <summary>
        ///     Tests that equals returns false when garbage collection count differs
        /// </summary>
        [Fact]
        public void Equals_ReturnsFalse_WhenGarbageCollectionCountDiffers()
        {
            // Arrange
            DateTime timestamp = DateTime.Now;
            ResourceMetrics metrics1 = new ResourceMetrics(100, 2048, 5, 3, timestamp);
            ResourceMetrics metrics2 = new ResourceMetrics(100, 2048, 6, 3, timestamp);

            // Act & Assert
            Assert.False(metrics1.Equals(metrics2));
        }

        /// <summary>
        ///     Tests that equals returns false when thread count differs
        /// </summary>
        [Fact]
        public void Equals_ReturnsFalse_WhenThreadCountDiffers()
        {
            // Arrange
            DateTime timestamp = DateTime.Now;
            ResourceMetrics metrics1 = new ResourceMetrics(100, 2048, 5, 3, timestamp);
            ResourceMetrics metrics2 = new ResourceMetrics(100, 2048, 5, 4, timestamp);

            // Act & Assert
            Assert.False(metrics1.Equals(metrics2));
        }

        /// <summary>
        ///     Tests that equals returns false when timestamp differs
        /// </summary>
        [Fact]
        public void Equals_ReturnsFalse_WhenTimestampDiffers()
        {
            // Arrange
            DateTime timestamp1 = new DateTime(2026, 3, 7, 14, 30, 45);
            DateTime timestamp2 = new DateTime(2026, 3, 7, 14, 30, 46);
            ResourceMetrics metrics1 = new ResourceMetrics(100, 2048, 5, 3, timestamp1);
            ResourceMetrics metrics2 = new ResourceMetrics(100, 2048, 5, 3, timestamp2);

            // Act & Assert
            Assert.False(metrics1.Equals(metrics2));
        }

        /// <summary>
        ///     Tests that equality operator returns true for identical metrics
        /// </summary>
        [Fact]
        public void EqualityOperator_ReturnsTrue_ForIdenticalMetrics()
        {
            // Arrange
            DateTime timestamp = DateTime.Now;
            ResourceMetrics metrics1 = new ResourceMetrics(100, 2048, 5, 3, timestamp);
            ResourceMetrics metrics2 = new ResourceMetrics(100, 2048, 5, 3, timestamp);

            // Act & Assert
            Assert.True(metrics1 == metrics2);
        }

        /// <summary>
        ///     Tests that inequality operator returns true for different metrics
        /// </summary>
        [Fact]
        public void InequalityOperator_ReturnsTrue_ForDifferentMetrics()
        {
            // Arrange
            DateTime timestamp = DateTime.Now;
            ResourceMetrics metrics1 = new ResourceMetrics(100, 2048, 5, 3, timestamp);
            ResourceMetrics metrics2 = new ResourceMetrics(200, 2048, 5, 3, timestamp);

            // Act & Assert
            Assert.True(metrics1 != metrics2);
        }

        /// <summary>
        ///     Tests that get hash code returns different values for different metrics
        /// </summary>
        [Fact]
        public void GetHashCode_ReturnsDifferentValues_ForDifferentMetrics()
        {
            // Arrange
            DateTime timestamp = DateTime.Now;
            ResourceMetrics metrics1 = new ResourceMetrics(100, 2048, 5, 3, timestamp);
            ResourceMetrics metrics2 = new ResourceMetrics(200, 2048, 5, 3, timestamp);

            // Act & Assert
            Assert.NotEqual(metrics1.GetHashCode(), metrics2.GetHashCode());
        }

        /// <summary>
        ///     Tests that object equals with resource metrics works correctly
        /// </summary>
        [Fact]
        public void ObjectEquals_WithResourceMetrics_WorksCorrectly()
        {
            // Arrange
            DateTime timestamp = DateTime.Now;
            ResourceMetrics metrics1 = new ResourceMetrics(100, 2048, 5, 3, timestamp);
            object metrics2 = new ResourceMetrics(100, 2048, 5, 3, timestamp);

            // Act & Assert
            Assert.True(metrics1.Equals(metrics2));
        }

        /// <summary>
        ///     Tests that get hash code with zero values
        /// </summary>
        [Fact]
        public void GetHashCode_WithZeroValues_ReturnsHashCode()
        {
            // Act
            ResourceMetrics metrics = new ResourceMetrics(0, 0, 0, 0, DateTime.MinValue);
            int hashCode = metrics.GetHashCode();

            // Assert
            Assert.NotEqual(0, hashCode);
        }

        /// <summary>
        ///     Tests that get hash code with maximum values
        /// </summary>
        [Fact]
        public void GetHashCode_WithMaximumValues_ReturnsHashCode()
        {
            // Act
            ResourceMetrics metrics = new ResourceMetrics(double.MaxValue, long.MaxValue, int.MaxValue, int.MaxValue, DateTime.MaxValue);
            int hashCode = metrics.GetHashCode();

            // Assert
            Assert.NotEqual(0, hashCode);
        }

        /// <summary>
        ///     Tests that empty metrics instance is readonly
        /// </summary>
        [Fact]
        public void Empty_IsReadonly_Instance()
        {
            // Arrange
            ResourceMetrics empty1 = ResourceMetrics.Empty;
            ResourceMetrics empty2 = ResourceMetrics.Empty;

            // Act & Assert
            Assert.Equal(empty1, empty2);
        }

        /// <summary>
        ///     Tests to string with zero metrics
        /// </summary>
        [Fact]
        public void ToString_WithZeroMetrics_ReturnsFormattedString()
        {
            // Arrange
            ResourceMetrics metrics = new ResourceMetrics(0, 0, 0, 0, DateTime.MinValue);

            // Act
            string result = metrics.ToString();

            // Assert
            Assert.Contains("CPU:", result);
            Assert.Contains("0", result);
            Assert.Contains("ms", result);
            Assert.Contains("Memory:", result);
            Assert.Contains("bytes", result);
            Assert.Contains("GC: 0", result);
            Assert.Contains("Threads: 0", result);
        }

        /// <summary>
        ///     Tests to string with large values
        /// </summary>
        [Fact]
        public void ToString_WithLargeValues_ReturnsFormattedString()
        {
            // Arrange
            ResourceMetrics metrics = new ResourceMetrics(999999.99, 1000000000, 9999, 9999, DateTime.Now);

            // Act
            string result = metrics.ToString();

            // Assert
            Assert.Contains("CPU:", result);
            Assert.Contains("Memory:", result);
            Assert.Contains("GC:", result);
            Assert.Contains("Threads:", result);
            Assert.Contains("Timestamp:", result);
        }

        /// <summary>
        ///     Tests that multiple equal instances have the same hash code
        /// </summary>
        [Fact]
        public void MultipleEqualInstances_HaveSameHashCode()
        {
            // Arrange
            DateTime timestamp = DateTime.Now;
            ResourceMetrics metrics1 = new ResourceMetrics(100, 2048, 5, 3, timestamp);
            ResourceMetrics metrics2 = new ResourceMetrics(100, 2048, 5, 3, timestamp);
            ResourceMetrics metrics3 = new ResourceMetrics(100, 2048, 5, 3, timestamp);

            // Act
            int hash1 = metrics1.GetHashCode();
            int hash2 = metrics2.GetHashCode();
            int hash3 = metrics3.GetHashCode();

            // Assert
            Assert.Equal(hash1, hash2);
            Assert.Equal(hash2, hash3);
        }

        /// <summary>
        ///     Tests that equality is reflexive
        /// </summary>
        [Fact]
        public void Equality_IsReflexive()
        {
            // Arrange
            ResourceMetrics metrics = new ResourceMetrics(100, 2048, 5, 3, DateTime.Now);

            // Act & Assert
            Assert.True(metrics.Equals(metrics));
            Assert.True(metrics == metrics);
        }

        /// <summary>
        ///     Tests that equality is symmetric
        /// </summary>
        [Fact]
        public void Equality_IsSymmetric()
        {
            // Arrange
            DateTime timestamp = DateTime.Now;
            ResourceMetrics metrics1 = new ResourceMetrics(100, 2048, 5, 3, timestamp);
            ResourceMetrics metrics2 = new ResourceMetrics(100, 2048, 5, 3, timestamp);

            // Act & Assert
            Assert.Equal(metrics1.Equals(metrics2), metrics2.Equals(metrics1));
        }

        /// <summary>
        ///     Tests that equality is transitive
        /// </summary>
        [Fact]
        public void Equality_IsTransitive()
        {
            // Arrange
            DateTime timestamp = DateTime.Now;
            ResourceMetrics metrics1 = new ResourceMetrics(100, 2048, 5, 3, timestamp);
            ResourceMetrics metrics2 = new ResourceMetrics(100, 2048, 5, 3, timestamp);
            ResourceMetrics metrics3 = new ResourceMetrics(100, 2048, 5, 3, timestamp);

            // Act & Assert
            Assert.True(metrics1.Equals(metrics2));
            Assert.True(metrics2.Equals(metrics3));
            Assert.True(metrics1.Equals(metrics3));
        }

        /// <summary>
        ///     Tests constructor with minimum datetime value
        /// </summary>
        [Fact]
        public void Constructor_WithMinimumDateTime_Succeeds()
        {
            // Act
            ResourceMetrics metrics = new ResourceMetrics(100, 1024, 5, 3, DateTime.MinValue);

            // Assert
            Assert.Equal(DateTime.MinValue, metrics.Timestamp);
        }

        /// <summary>
        ///     Tests constructor with maximum datetime value
        /// </summary>
        [Fact]
        public void Constructor_WithMaximumDateTime_Succeeds()
        {
            // Act
            ResourceMetrics metrics = new ResourceMetrics(100, 1024, 5, 3, DateTime.MaxValue);

            // Assert
            Assert.Equal(DateTime.MaxValue, metrics.Timestamp);
        }

        /// <summary>
        ///     Tests that equals handles same cpu and memory but different timestamps
        /// </summary>
        [Fact]
        public void Equals_DifferentiatesByTimestamp()
        {
            // Arrange
            ResourceMetrics metrics1 = new ResourceMetrics(100, 2048, 5, 3, new DateTime(2026, 1, 1));
            ResourceMetrics metrics2 = new ResourceMetrics(100, 2048, 5, 3, new DateTime(2026, 1, 2));

            // Act & Assert
            Assert.False(metrics1.Equals(metrics2));
        }

        /// <summary>
        ///     Tests that all properties are accessible
        /// </summary>
        [Fact]
        public void AllProperties_AreAccessible()
        {
            // Arrange
            DateTime timestamp = new DateTime(2026, 3, 7, 14, 30, 45, 123);
            ResourceMetrics metrics = new ResourceMetrics(123.456, 2048576, 10, 5, timestamp);

            // Act & Assert
            Assert.Equal(123.456, metrics.CpuUsageMilliseconds);
            Assert.Equal(2048576, metrics.MemoryUsageBytes);
            Assert.Equal(10, metrics.GarbageCollectionCount);
            Assert.Equal(5, metrics.ThreadCount);
            Assert.Equal(timestamp, metrics.Timestamp);
        }

        /// <summary>
        ///     Tests constructor with very small cpu value
        /// </summary>
        [Fact]
        public void Constructor_WithVerySmallCpuValue_Succeeds()
        {
            // Act
            ResourceMetrics metrics = new ResourceMetrics(0.0001, 1024, 5, 3, DateTime.Now);

            // Assert
            Assert.Equal(0.0001, metrics.CpuUsageMilliseconds);
        }

        /// <summary>
        ///     Tests that to string format uses correct decimal places for cpu
        /// </summary>
        [Fact]
        public void ToString_UsesTwoDecimalPlaces_ForCpuUsage()
        {
            // Arrange
            ResourceMetrics metrics = new ResourceMetrics(123.456789, 2048, 5, 3, DateTime.Now);

            // Act
            string result = metrics.ToString();

            // Assert
            Assert.Contains("CPU:", result);
            Assert.Contains("123", result);
            Assert.Contains("ms", result);
        }

        /// <summary>
        ///     Tests that to string format includes formatted memory value
        /// </summary>
        [Fact]
        public void ToString_FormatsMemoryValue()
        {
            // Arrange
            ResourceMetrics metrics = new ResourceMetrics(100, 1234567, 5, 3, DateTime.Now);

            // Act
            string result = metrics.ToString();

            // Assert
            Assert.Contains("Memory:", result);
            // The exact formatting depends on locale, but should contain digits and thousands separator or just digits
            Assert.Matches(@"Memory:\s+[\d.,]+\s+bytes", result);
        }
    }
}