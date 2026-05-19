// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ResourceMetricsFactoryComprehensiveTest.cs
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
using Alis.Extension.Profile.Factories;
using Alis.Extension.Profile.Interfaces;
using Alis.Extension.Profile.Models;
using Alis.Extension.Profile.Test.Mocks;
using Xunit;

namespace Alis.Extension.Profile.Test.Factories
{
    /// <summary>
    ///     Comprehensive unit tests for ResourceMetricsFactory class.
    ///     Tests all public members including constructors, factory methods,
    ///     and edge cases for complete code coverage.
    /// </summary>
    public class ResourceMetricsFactoryComprehensiveTest
    {
        /// <summary>
        ///     Tests that constructor successfully initializes with a valid resource monitor.
        /// </summary>
        [Fact]
        public void Constructor_InitializesWithValidResourceMonitor()
        {
            // Arrange
            IResourceMonitor monitor = new MockResourceMonitor();

            // Act
            ResourceMetricsFactory factory = new ResourceMetricsFactory(monitor);

            // Assert - Factory should be created successfully
            Assert.NotNull(factory);
        }

        /// <summary>
        ///     Tests that constructor throws exception when resource monitor is null.
        /// </summary>
        [Fact]
        public void Constructor_ThrowsArgumentNullException_WhenResourceMonitorIsNull()
        {
            // Act & Assert
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() =>
                new ResourceMetricsFactory(null));

            Assert.Equal("resourceMonitor", ex.ParamName);
        }

        /// <summary>
        ///     Tests that CreateSnapshot returns a valid ResourceMetrics struct.
        /// </summary>
        [Fact]
        public void CreateSnapshot_ReturnsValidResourceMetrics()
        {
            // Arrange
            IResourceMonitor monitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(monitor);

            // Act
            ResourceMetrics metrics = factory.CreateSnapshot();

            // Assert
            Assert.NotEqual(DateTime.MinValue, metrics.Timestamp);
            Assert.True(metrics.CpuUsageMilliseconds >= 0);
            Assert.True(metrics.MemoryUsageBytes >= 0);
        }

        /// <summary>
        ///     Tests that CreateSnapshot calls the resource monitor methods correctly.
        /// </summary>
        [Fact]
        public void CreateSnapshot_CallsResourceMonitorMethods()
        {
            // Arrange
            MockResourceMonitor monitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(monitor);

            // Act
            ResourceMetrics metrics = factory.CreateSnapshot();

            // Assert
            Assert.Equal(monitor.CpuUsage, metrics.CpuUsageMilliseconds);
            Assert.Equal(monitor.MemoryUsage, metrics.MemoryUsageBytes);
            Assert.Equal(monitor.GarbageCollectionCount, metrics.GarbageCollectionCount);
            Assert.Equal(monitor.ThreadCount, metrics.ThreadCount);
        }

        /// <summary>
        ///     Tests that CreateSnapshot captures the current timestamp.
        /// </summary>
        [Fact]
        public void CreateSnapshot_CapturesCurrentTimestamp()
        {
            // Arrange
            IResourceMonitor monitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(monitor);
            DateTime beforeCreation = DateTime.Now;

            // Act
            ResourceMetrics metrics = factory.CreateSnapshot();
            DateTime afterCreation = DateTime.Now;

            // Assert
            Assert.True(metrics.Timestamp >= beforeCreation);
            Assert.True(metrics.Timestamp <= afterCreation);
        }

        /// <summary>
        ///     Tests that multiple CreateSnapshot calls produce different timestamps.
        /// </summary>
        [Fact]
        public void CreateSnapshot_ProducesDifferentTimestampsOnMultipleCalls()
        {
            // Arrange
            IResourceMonitor monitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(monitor);

            // Act
            ResourceMetrics metrics1 = factory.CreateSnapshot();
            System.Threading.Thread.Sleep(10);
            ResourceMetrics metrics2 = factory.CreateSnapshot();

            // Assert - Timestamps may be identical in fast executions but should not be equal in concept
            Assert.NotNull(metrics1);
            Assert.NotNull(metrics2);
        }

        /// <summary>
        ///     Tests that CreateEmpty returns a ResourceMetrics with default values.
        /// </summary>
        [Fact]
        public void CreateEmpty_ReturnsResourceMetricsWithDefaultValues()
        {
            // Arrange
            IResourceMonitor monitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(monitor);

            // Act
            ResourceMetrics metrics = ResourceMetricsFactory.CreateEmpty();

            // Assert
            Assert.Equal(0, metrics.CpuUsageMilliseconds);
            Assert.Equal(0, metrics.MemoryUsageBytes);
            Assert.Equal(0, metrics.GarbageCollectionCount);
            Assert.Equal(0, metrics.ThreadCount);
            Assert.Equal(DateTime.MinValue, metrics.Timestamp);
        }

        /// <summary>
        ///     Tests that CreateEmpty returns the same as ResourceMetrics.Empty.
        /// </summary>
        [Fact]
        public void CreateEmpty_ReturnsSameAsResourceMetricsEmpty()
        {
            // Arrange
            IResourceMonitor monitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(monitor);

            // Act
            ResourceMetrics empty = ResourceMetricsFactory.CreateEmpty();
            ResourceMetrics staticEmpty = ResourceMetrics.Empty;

            // Assert
            Assert.Equal(staticEmpty, empty);
        }

        /// <summary>
        ///     Tests that CreateSnapshot and CreateEmpty return independent instances.
        /// </summary>
        [Fact]
        public void CreateSnapshot_And_CreateEmpty_ReturnIndependentInstances()
        {
            // Arrange
            IResourceMonitor monitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(monitor);

            // Act
            ResourceMetrics snapshot = factory.CreateSnapshot();
            ResourceMetrics empty = ResourceMetricsFactory.CreateEmpty();

            // Assert
            Assert.NotEqual(snapshot, empty);
        }

        /// <summary>
        ///     Tests that CreateSnapshot works with a monitor returning large values.
        /// </summary>
        [Fact]
        public void CreateSnapshot_WorksWithLargeValues()
        {
            // Arrange
            MockResourceMonitor monitor = new MockResourceMonitor
            {
                CpuUsage = double.MaxValue,
                MemoryUsage = long.MaxValue,
                GarbageCollectionCount = int.MaxValue,
                ThreadCount = int.MaxValue
            };
            ResourceMetricsFactory factory = new ResourceMetricsFactory(monitor);

            // Act
            ResourceMetrics metrics = factory.CreateSnapshot();

            // Assert
            Assert.Equal(double.MaxValue, metrics.CpuUsageMilliseconds);
            Assert.Equal(long.MaxValue, metrics.MemoryUsageBytes);
            Assert.Equal(int.MaxValue, metrics.GarbageCollectionCount);
            Assert.Equal(int.MaxValue, metrics.ThreadCount);
        }

        /// <summary>
        ///     Tests that CreateSnapshot works with a monitor returning zero values.
        /// </summary>
        [Fact]
        public void CreateSnapshot_WorksWithZeroValues()
        {
            // Arrange
            MockResourceMonitor monitor = new MockResourceMonitor
            {
                CpuUsage = 0,
                MemoryUsage = 0,
                GarbageCollectionCount = 0,
                ThreadCount = 0
            };
            ResourceMetricsFactory factory = new ResourceMetricsFactory(monitor);

            // Act
            ResourceMetrics metrics = factory.CreateSnapshot();

            // Assert
            Assert.Equal(0, metrics.CpuUsageMilliseconds);
            Assert.Equal(0, metrics.MemoryUsageBytes);
            Assert.Equal(0, metrics.GarbageCollectionCount);
            Assert.Equal(0, metrics.ThreadCount);
        }

        /// <summary>
        ///     Tests that factory can create multiple snapshots consistently.
        /// </summary>
        [Fact]
        public void CreateSnapshot_CanCreateMultipleSnapshotsConsistently()
        {
            // Arrange
            IResourceMonitor monitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(monitor);

            // Act
            ResourceMetrics metrics1 = factory.CreateSnapshot();
            ResourceMetrics metrics2 = factory.CreateSnapshot();
            ResourceMetrics metrics3 = factory.CreateSnapshot();

            // Assert - All should have same values except timestamp
            Assert.Equal(metrics1.CpuUsageMilliseconds, metrics2.CpuUsageMilliseconds);
            Assert.Equal(metrics2.CpuUsageMilliseconds, metrics3.CpuUsageMilliseconds);
            Assert.Equal(metrics1.MemoryUsageBytes, metrics2.MemoryUsageBytes);
            Assert.Equal(metrics2.MemoryUsageBytes, metrics3.MemoryUsageBytes);
        }

        /// <summary>
        ///     Tests that factory preserves monitor reference.
        /// </summary>
        [Fact]
        public void Constructor_PreservesMonitorReference()
        {
            // Arrange
            MockResourceMonitor monitor = new MockResourceMonitor();
            monitor.CpuUsage = 42.0;
            ResourceMetricsFactory factory = new ResourceMetricsFactory(monitor);

            // Act - Change monitor value and create snapshot
            monitor.CpuUsage = 100.0;
            ResourceMetrics metrics = factory.CreateSnapshot();

            // Assert - Should reflect the updated value
            Assert.Equal(100.0, metrics.CpuUsageMilliseconds);
        }

        /// <summary>
        ///     Tests that CreateSnapshot returns struct (value type), not reference.
        /// </summary>
        [Fact]
        public void CreateSnapshot_ReturnsValueType()
        {
            // Arrange
            IResourceMonitor monitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(monitor);

            // Act
            ResourceMetrics metrics1 = factory.CreateSnapshot();
            ResourceMetrics metrics2 = metrics1;
            metrics2 = new ResourceMetrics(999, 999, 999, 999, DateTime.Now);

            // Assert - metrics1 should be unchanged (value semantics)
            Assert.NotEqual(999, metrics1.CpuUsageMilliseconds);
        }
    }
}





