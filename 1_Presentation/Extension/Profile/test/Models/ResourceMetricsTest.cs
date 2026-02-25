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
    }
}

