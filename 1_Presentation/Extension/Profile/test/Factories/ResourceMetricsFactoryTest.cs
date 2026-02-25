// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ResourceMetricsFactoryTest.cs
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
    ///     The resource metrics factory test class
    /// </summary>
    public class ResourceMetricsFactoryTest
    {
        /// <summary>
        ///     Tests that constructor throws exception when resource monitor is null
        /// </summary>
        [Fact]
        public void Constructor_ThrowsException_WhenResourceMonitorIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ResourceMetricsFactory(null));
        }

        /// <summary>
        ///     Tests that create snapshot returns metrics with data from monitor
        /// </summary>
        [Fact]
        public void CreateSnapshot_ReturnsMetrics_WithDataFromMonitor()
        {
            // Arrange
            MockResourceMonitor mockMonitor = new MockResourceMonitor
            {
                CpuUsage = 150.5,
                MemoryUsage = 2048,
                GarbageCollectionCount = 10,
                ThreadCount = 5
            };

            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);

            // Act
            ResourceMetrics metrics = factory.CreateSnapshot();

            // Assert
            Assert.Equal(150.5, metrics.CpuUsageMilliseconds);
            Assert.Equal(2048, metrics.MemoryUsageBytes);
            Assert.Equal(10, metrics.GarbageCollectionCount);
            Assert.Equal(5, metrics.ThreadCount);
            Assert.NotEqual(DateTime.MinValue, metrics.Timestamp);
        }

        /// <summary>
        ///     Tests that create snapshot captures current timestamp
        /// </summary>
        [Fact]
        public void CreateSnapshot_CapturesCurrentTimestamp()
        {
            // Arrange
            MockResourceMonitor mockMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);
            DateTime beforeSnapshot = DateTime.Now;

            // Act
            ResourceMetrics metrics = factory.CreateSnapshot();

            // Assert
            DateTime afterSnapshot = DateTime.Now;
            Assert.True(metrics.Timestamp >= beforeSnapshot);
            Assert.True(metrics.Timestamp <= afterSnapshot);
        }

        /// <summary>
        ///     Tests that create empty returns empty metrics
        /// </summary>
        [Fact]
        public void CreateEmpty_ReturnsEmptyMetrics()
        {
            // Arrange
            MockResourceMonitor mockMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);

            // Act
            ResourceMetrics empty = factory.CreateEmpty();

            // Assert
            Assert.Equal(ResourceMetrics.Empty, empty);
        }

        /// <summary>
        ///     Tests that create snapshot calls all monitor methods
        /// </summary>
        [Fact]
        public void CreateSnapshot_CallsAllMonitorMethods()
        {
            // Arrange
            MockResourceMonitor mockMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);

            // Act
            factory.CreateSnapshot();

            // Assert
            Assert.True(mockMonitor.GetCpuUsageCalled);
            Assert.True(mockMonitor.GetMemoryUsageCalled);
            Assert.True(mockMonitor.GetGarbageCollectionCountCalled);
            Assert.True(mockMonitor.GetThreadCountCalled);
        }

        /// <summary>
        ///     Tests that create snapshot creates different timestamps for multiple calls
        /// </summary>
        [Fact]
        public void CreateSnapshot_CreatesDifferentTimestamps_ForMultipleCalls()
        {
            // Arrange
            MockResourceMonitor mockMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);

            // Act
            ResourceMetrics first = factory.CreateSnapshot();
            System.Threading.Thread.Sleep(10); // Ensure time difference
            ResourceMetrics second = factory.CreateSnapshot();

            // Assert
            Assert.True(second.Timestamp >= first.Timestamp);
        }
    }
}

