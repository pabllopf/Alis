// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NewProfilerServiceTest.cs
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

namespace Alis.Extension.Profile.Test
{
    /// <summary>
    ///     The profiler service test class
    /// </summary>
    public class NewProfilerServiceTest
    {
        /// <summary>
        ///     Tests that constructor throws exception when time tracker is null
        /// </summary>
        [Fact]
        public void Constructor_ThrowsException_WhenTimeTrackerIsNull()
        {
            // Arrange
            MockResourceMonitor mockMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ProfilerService(null, factory));
        }

        /// <summary>
        ///     Tests that constructor throws exception when metrics factory is null
        /// </summary>
        [Fact]
        public void Constructor_ThrowsException_WhenMetricsFactoryIsNull()
        {
            // Arrange
            MockTimeTracker mockTracker = new MockTimeTracker();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ProfilerService(mockTracker, null));
        }

        /// <summary>
        ///     Tests that is active returns false initially
        /// </summary>
        [Fact]
        public void IsActive_ReturnsFalse_Initially()
        {
            // Arrange
            MockTimeTracker mockTracker = new MockTimeTracker();
            MockResourceMonitor mockMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);
            ProfilerService service = new ProfilerService(mockTracker, factory);

            // Act & Assert
            Assert.False(service.IsActive);
        }

        /// <summary>
        ///     Tests that start profiling activates profiling
        /// </summary>
        [Fact]
        public void StartProfiling_ActivatesProfiling()
        {
            // Arrange
            MockTimeTracker mockTracker = new MockTimeTracker();
            MockResourceMonitor mockMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);
            ProfilerService service = new ProfilerService(mockTracker, factory);

            // Act
            service.StartProfiling();

            // Assert
            Assert.True(service.IsActive);
            Assert.True(mockTracker.StartCalled);
        }

        /// <summary>
        ///     Tests that start profiling captures initial metrics
        /// </summary>
        [Fact]
        public void StartProfiling_CapturesInitialMetrics()
        {
            // Arrange
            MockTimeTracker mockTracker = new MockTimeTracker();
            MockResourceMonitor mockMonitor = new MockResourceMonitor
            {
                CpuUsage = 100,
                MemoryUsage = 2048
            };
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);
            ProfilerService service = new ProfilerService(mockTracker, factory);

            // Act
            service.StartProfiling();

            // Assert
            Assert.True(mockMonitor.GetCpuUsageCalled);
            Assert.True(mockMonitor.GetMemoryUsageCalled);
        }

        /// <summary>
        ///     Tests that stop profiling returns snapshot
        /// </summary>
        [Fact]
        public void StopProfiling_ReturnsSnapshot()
        {
            // Arrange
            MockTimeTracker mockTracker = new MockTimeTracker
            {
                ElapsedTime = TimeSpan.FromMilliseconds(500)
            };
            MockResourceMonitor mockMonitor = new MockResourceMonitor
            {
                CpuUsage = 100,
                MemoryUsage = 2048
            };
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);
            ProfilerService service = new ProfilerService(mockTracker, factory);

            service.StartProfiling();

            // Act
            ProfileSnapshot snapshot = service.StopProfiling();

            // Assert
            Assert.NotNull(snapshot);
            Assert.Equal(TimeSpan.FromMilliseconds(500), snapshot.ElapsedTime);
            Assert.True(mockTracker.StopCalled);
        }

        /// <summary>
        ///     Tests that stop profiling throws exception when not active
        /// </summary>
        [Fact]
        public void StopProfiling_ThrowsException_WhenNotActive()
        {
            // Arrange
            MockTimeTracker mockTracker = new MockTimeTracker();
            MockResourceMonitor mockMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);
            ProfilerService service = new ProfilerService(mockTracker, factory);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => service.StopProfiling());
        }

        /// <summary>
        ///     Tests that get current snapshot returns data without stopping
        /// </summary>
        [Fact]
        public void GetCurrentSnapshot_ReturnsData_WithoutStopping()
        {
            // Arrange
            MockTimeTracker mockTracker = new MockTimeTracker
            {
                ElapsedTime = TimeSpan.FromMilliseconds(250)
            };
            MockResourceMonitor mockMonitor = new MockResourceMonitor
            {
                CpuUsage = 150,
                MemoryUsage = 3072
            };
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);
            ProfilerService service = new ProfilerService(mockTracker, factory);

            service.StartProfiling();

            // Act
            ProfileSnapshot snapshot = service.GetCurrentSnapshot();

            // Assert
            Assert.NotNull(snapshot);
            Assert.Equal(TimeSpan.FromMilliseconds(250), snapshot.ElapsedTime);
            Assert.True(service.IsActive); // Still active
            Assert.False(mockTracker.StopCalled); // Should not stop
        }

        /// <summary>
        ///     Tests that reset clears all data
        /// </summary>
        [Fact]
        public void Reset_ClearsAllData()
        {
            // Arrange
            MockTimeTracker mockTracker = new MockTimeTracker();
            MockResourceMonitor mockMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);
            ProfilerService service = new ProfilerService(mockTracker, factory);

            service.StartProfiling();

            // Act
            service.Reset();

            // Assert
            Assert.True(mockTracker.ResetCalled);
        }

        /// <summary>
        ///     Tests that stop profiling captures end metrics
        /// </summary>
        [Fact]
        public void StopProfiling_CapturesEndMetrics()
        {
            // Arrange
            MockTimeTracker mockTracker = new MockTimeTracker
            {
                ElapsedTime = TimeSpan.FromMilliseconds(500)
            };
            MockResourceMonitor mockMonitor = new MockResourceMonitor
            {
                CpuUsage = 100,
                MemoryUsage = 2048
            };
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);
            ProfilerService service = new ProfilerService(mockTracker, factory);

            service.StartProfiling();
            mockMonitor.ResetCallTracking();

            // Act
            ProfileSnapshot snapshot = service.StopProfiling();

            // Assert
            Assert.True(mockMonitor.GetCpuUsageCalled);
            Assert.True(mockMonitor.GetMemoryUsageCalled);
            Assert.NotEqual(DateTime.MinValue, snapshot.EndTime);
        }
        

        /// <summary>
        ///     Tests that is active reflects time tracker state
        /// </summary>
        [Fact]
        public void IsActive_ReflectsTimeTrackerState()
        {
            // Arrange
            MockTimeTracker mockTracker = new MockTimeTracker();
            MockResourceMonitor mockMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);
            ProfilerService service = new ProfilerService(mockTracker, factory);

            // Act & Assert
            Assert.False(service.IsActive);

            mockTracker.IsRunning = true;
            Assert.True(service.IsActive);

            mockTracker.IsRunning = false;
            Assert.False(service.IsActive);
        }
    }
}

