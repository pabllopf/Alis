// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ProfilerServiceComprehensiveTest.cs
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
using System.Threading;
using Alis.Extension.Profile.Factories;
using Alis.Extension.Profile.Models;
using Alis.Extension.Profile.Test.Mocks;
using Xunit;

namespace Alis.Extension.Profile.Test
{
    /// <summary>
    ///     Comprehensive unit tests for ProfilerService class.
    ///     Tests all public members and profiling scenarios with full coverage.
    /// </summary>
    public class ProfilerServiceComprehensiveTest
    {
        /// <summary>
        ///     Tests that constructor initializes with valid dependencies.
        /// </summary>
        [Fact]
        public void Constructor_InitializesWithValidDependencies()
        {
            // Arrange
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);

            // Act
            ProfilerService service = new ProfilerService(timeTracker, factory);

            // Assert
            Assert.NotNull(service);
        }

        /// <summary>
        ///     Tests that constructor throws exception when time tracker is null.
        /// </summary>
        [Fact]
        public void Constructor_ThrowsArgumentNullException_WhenTimeTrackerIsNull()
        {
            // Arrange
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);

            // Act & Assert
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() =>
                new ProfilerService(null, factory));

            Assert.Equal("timeTracker", ex.ParamName);
        }

        /// <summary>
        ///     Tests that constructor throws exception when metrics factory is null.
        /// </summary>
        [Fact]
        public void Constructor_ThrowsArgumentNullException_WhenMetricsFactoryIsNull()
        {
            // Arrange
            MockTimeTracker timeTracker = new MockTimeTracker();

            // Act & Assert
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() =>
                new ProfilerService(timeTracker, null));

            Assert.Equal("metricsFactory", ex.ParamName);
        }

        /// <summary>
        ///     Tests that IsActive returns false initially.
        /// </summary>
        [Fact]
        public void IsActive_ReturnsFalse_Initially()
        {
            // Arrange
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);

            // Act
            bool isActive = service.IsActive;

            // Assert
            Assert.False(isActive);
        }

        /// <summary>
        ///     Tests that IsActive returns true after StartProfiling.
        /// </summary>
        [Fact]
        public void IsActive_ReturnsTrue_AfterStartProfiling()
        {
            // Arrange
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);

            // Act
            service.StartProfiling();
            bool isActive = service.IsActive;

            // Assert
            Assert.True(isActive);
        }

        /// <summary>
        ///     Tests that IsActive returns false after StopProfiling.
        /// </summary>
        [Fact]
        public void IsActive_ReturnsFalse_AfterStopProfiling()
        {
            // Arrange
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);
            service.StartProfiling();

            // Act
            service.StopProfiling();
            bool isActive = service.IsActive;

            // Assert
            Assert.False(isActive);
        }

        /// <summary>
        ///     Tests that StartProfiling activates profiling.
        /// </summary>
        [Fact]
        public void StartProfiling_ActivatesProfiling()
        {
            // Arrange
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);

            // Act
            service.StartProfiling();

            // Assert
            Assert.True(service.IsActive);
            Assert.True(timeTracker.StartCalled);
        }

        /// <summary>
        ///     Tests that StartProfiling captures initial metrics.
        /// </summary>
        [Fact]
        public void StartProfiling_CapturesInitialMetrics()
        {
            // Arrange
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);

            // Act
            service.StartProfiling();
            ProfileSnapshot snapshot = service.GetCurrentSnapshot();

            // Assert
            Assert.NotEqual(ResourceMetrics.Empty, snapshot.StartMetrics);
        }

        /// <summary>
        ///     Tests that StopProfiling returns a valid ProfileSnapshot.
        /// </summary>
        [Fact]
        public void StopProfiling_ReturnsValidProfileSnapshot()
        {
            // Arrange
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);
            service.StartProfiling();

            // Act
            ProfileSnapshot snapshot = service.StopProfiling();

            // Assert
            Assert.NotNull(snapshot);
            Assert.NotEqual(ResourceMetrics.Empty, snapshot.StartMetrics);
        }

        /// <summary>
        ///     Tests that StopProfiling throws exception when not profiling.
        /// </summary>
        [Fact]
        public void StopProfiling_ThrowsInvalidOperationException_WhenNotProfiling()
        {
            // Arrange
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);

            // Act & Assert
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
                service.StopProfiling());

            Assert.Contains("Cannot stop profiling", ex.Message);
        }

        /// <summary>
        ///     Tests that GetCurrentSnapshot returns a valid snapshot during profiling.
        /// </summary>
        [Fact]
        public void GetCurrentSnapshot_ReturnsValidSnapshot_DuringProfiling()
        {
            // Arrange
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);
            service.StartProfiling();

            // Act
            ProfileSnapshot snapshot = service.GetCurrentSnapshot();

            // Assert
            Assert.NotNull(snapshot);
            Assert.NotEqual(DateTime.MinValue, snapshot.StartTime);
        }

        /// <summary>
        ///     Tests that GetCurrentSnapshot works before profiling starts.
        /// </summary>
        [Fact]
        public void GetCurrentSnapshot_WorksBeforeProfilingStarts()
        {
            // Arrange
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);

            // Act
            ProfileSnapshot snapshot = service.GetCurrentSnapshot();

            // Assert
            Assert.NotNull(snapshot);
            Assert.Equal(DateTime.MinValue, snapshot.StartTime);
        }

        /// <summary>
        ///     Tests that Reset clears profiling state.
        /// </summary>
        [Fact]
        public void Reset_ClearsProfiilingState()
        {
            // Arrange
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);
            service.StartProfiling();

            // Act
            service.Reset();

            // Assert
            Assert.False(service.IsActive);
            Assert.True(timeTracker.ResetCalled);
        }

        /// <summary>
        ///     Tests that multiple profiling sessions can be run sequentially.
        /// </summary>
        [Fact]
        public void MultipleSessions_CanRunSequentially()
        {
            // Arrange
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);

            // Act & Assert - First session
            service.StartProfiling();
            Assert.True(service.IsActive);
            ProfileSnapshot snapshot1 = service.StopProfiling();
            Assert.False(service.IsActive);
            Assert.NotNull(snapshot1);

            // Act & Assert - Second session
            service.StartProfiling();
            Assert.True(service.IsActive);
            ProfileSnapshot snapshot2 = service.StopProfiling();
            Assert.False(service.IsActive);
            Assert.NotNull(snapshot2);
        }

        /// <summary>
        ///     Tests that profiling data is collected correctly.
        /// </summary>
        [Fact]
        public void ProfilingData_IsCollectedCorrectly()
        {
            // Arrange
            MockTimeTracker timeTracker = new MockTimeTracker { ElapsedTime = TimeSpan.FromMilliseconds(100) };
            MockResourceMonitor resourceMonitor = new MockResourceMonitor
            {
                CpuUsage = 50.0,
                MemoryUsage = 1000000,
                GarbageCollectionCount = 5,
                ThreadCount = 10
            };
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);

            // Act
            service.StartProfiling();
            Thread.Sleep(10);
            ProfileSnapshot snapshot = service.StopProfiling();

            // Assert
            Assert.NotNull(snapshot.StartMetrics);
            Assert.NotNull(snapshot.EndMetrics);
            Assert.True(snapshot.ElapsedTime.TotalMilliseconds >= 0);
        }

        /// <summary>
        ///     Tests that GetCurrentSnapshot captures elapsed time during profiling.
        /// </summary>
        [Fact]
        public void GetCurrentSnapshot_CapturesElapsedTime()
        {
            // Arrange
            MockTimeTracker timeTracker = new MockTimeTracker { ElapsedTime = TimeSpan.FromMilliseconds(100) };
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);
            service.StartProfiling();

            // Act
            ProfileSnapshot snapshot = service.GetCurrentSnapshot();

            // Assert
            Assert.NotNull(snapshot);
            Assert.True(snapshot.ElapsedTime >= TimeSpan.Zero);
        }

        /// <summary>
        ///     Tests that Reset can be called multiple times.
        /// </summary>
        [Fact]
        public void Reset_CanBeCalledMultipleTimes()
        {
            // Arrange
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);

            // Act & Assert
            service.StartProfiling();
            service.Reset();
            Assert.False(service.IsActive);

            service.Reset();
            Assert.False(service.IsActive);

            service.Reset();
            Assert.False(service.IsActive);
        }

        /// <summary>
        ///     Tests that profiling can be restarted after reset.
        /// </summary>
        [Fact]
        public void Profiling_CanBeRestartedAfterReset()
        {
            // Arrange
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);

            // Act
            service.StartProfiling();
            service.Reset();
            Assert.False(service.IsActive);

            service.StartProfiling();
            Assert.True(service.IsActive);

            ProfileSnapshot snapshot = service.StopProfiling();
            Assert.False(service.IsActive);
            Assert.NotNull(snapshot);
        }

        /// <summary>
        ///     Tests that IsActive is synchronized with time tracker state.
        /// </summary>
        [Fact]
        public void IsActive_IsSynchronizedWithTimeTracker()
        {
            // Arrange
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);

            // Act & Assert
            Assert.Equal(timeTracker.IsRunning, service.IsActive);

            service.StartProfiling();
            Assert.Equal(timeTracker.IsRunning, service.IsActive);

            service.StopProfiling();
            Assert.Equal(timeTracker.IsRunning, service.IsActive);
        }

        /// <summary>
        ///     Tests that StopProfiling captures end metrics.
        /// </summary>
        [Fact]
        public void StopProfiling_CapturesEndMetrics()
        {
            // Arrange
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);
            service.StartProfiling();

            // Act
            ProfileSnapshot snapshot = service.StopProfiling();

            // Assert
            Assert.NotNull(snapshot.EndMetrics);
            Assert.NotEqual(DateTime.MinValue, snapshot.EndTime);
        }

        /// <summary>
        ///     Tests that ProfileSnapshot contains start and end times.
        /// </summary>
        [Fact]
        public void ProfileSnapshot_ContainsStartAndEndTimes()
        {
            // Arrange
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);
            DateTime beforeStart = DateTime.Now;

            // Act
            service.StartProfiling();
            Thread.Sleep(10);
            ProfileSnapshot snapshot = service.StopProfiling();
            DateTime afterEnd = DateTime.Now;

            // Assert
            Assert.True(snapshot.StartTime >= beforeStart);
            Assert.True(snapshot.EndTime <= afterEnd);
            Assert.True(snapshot.EndTime >= snapshot.StartTime);
        }

        /// <summary>
        ///     Tests that GetCurrentSnapshot preserves start metrics.
        /// </summary>
        [Fact]
        public void GetCurrentSnapshot_PreservesStartMetrics()
        {
            // Arrange
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);
            service.StartProfiling();

            // Act
            ProfileSnapshot snapshot1 = service.GetCurrentSnapshot();
            Thread.Sleep(10);
            ProfileSnapshot snapshot2 = service.GetCurrentSnapshot();

            // Assert
            Assert.Equal(snapshot1.StartMetrics, snapshot2.StartMetrics);
        }
    }
}



