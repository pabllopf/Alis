

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
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);

            ProfilerService service = new ProfilerService(timeTracker, factory);

            Assert.NotNull(service);
        }

        /// <summary>
        ///     Tests that constructor throws exception when time tracker is null.
        /// </summary>
        [Fact]
        public void Constructor_ThrowsArgumentNullException_WhenTimeTrackerIsNull()
        {
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);

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
            MockTimeTracker timeTracker = new MockTimeTracker();

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
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);

            bool isActive = service.IsActive;

            Assert.False(isActive);
        }

        /// <summary>
        ///     Tests that IsActive returns true after StartProfiling.
        /// </summary>
        [Fact]
        public void IsActive_ReturnsTrue_AfterStartProfiling()
        {
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);

            service.StartProfiling();
            bool isActive = service.IsActive;

            Assert.True(isActive);
        }

        /// <summary>
        ///     Tests that IsActive returns false after StopProfiling.
        /// </summary>
        [Fact]
        public void IsActive_ReturnsFalse_AfterStopProfiling()
        {
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);
            service.StartProfiling();

            service.StopProfiling();
            bool isActive = service.IsActive;

            Assert.False(isActive);
        }

        /// <summary>
        ///     Tests that StartProfiling activates profiling.
        /// </summary>
        [Fact]
        public void StartProfiling_ActivatesProfiling()
        {
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);

            service.StartProfiling();

            Assert.True(service.IsActive);
            Assert.True(timeTracker.StartCalled);
        }

        /// <summary>
        ///     Tests that StartProfiling captures initial metrics.
        /// </summary>
        [Fact]
        public void StartProfiling_CapturesInitialMetrics()
        {
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);

            service.StartProfiling();
            ProfileSnapshot snapshot = service.GetCurrentSnapshot();

            Assert.NotEqual(ResourceMetrics.Empty, snapshot.StartMetrics);
        }

        /// <summary>
        ///     Tests that StopProfiling returns a valid ProfileSnapshot.
        /// </summary>
        [Fact]
        public void StopProfiling_ReturnsValidProfileSnapshot()
        {
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);
            service.StartProfiling();

            ProfileSnapshot snapshot = service.StopProfiling();

            Assert.NotNull(snapshot);
            Assert.NotEqual(ResourceMetrics.Empty, snapshot.StartMetrics);
        }

        /// <summary>
        ///     Tests that StopProfiling throws exception when not profiling.
        /// </summary>
        [Fact]
        public void StopProfiling_ThrowsInvalidOperationException_WhenNotProfiling()
        {
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);

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
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);
            service.StartProfiling();

            ProfileSnapshot snapshot = service.GetCurrentSnapshot();

            Assert.NotNull(snapshot);
            Assert.NotEqual(DateTime.MinValue, snapshot.StartTime);
        }

        /// <summary>
        ///     Tests that GetCurrentSnapshot works before profiling starts.
        /// </summary>
        [Fact]
        public void GetCurrentSnapshot_WorksBeforeProfilingStarts()
        {
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);

            ProfileSnapshot snapshot = service.GetCurrentSnapshot();

            Assert.NotNull(snapshot);
            Assert.Equal(DateTime.MinValue, snapshot.StartTime);
        }

        /// <summary>
        ///     Tests that Reset clears profiling state.
        /// </summary>
        [Fact]
        public void Reset_ClearsProfiilingState()
        {
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);
            service.StartProfiling();

            service.Reset();

            Assert.False(service.IsActive);
            Assert.True(timeTracker.ResetCalled);
        }

        /// <summary>
        ///     Tests that multiple profiling sessions can be run sequentially.
        /// </summary>
        [Fact]
        public void MultipleSessions_CanRunSequentially()
        {
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);

            service.StartProfiling();
            Assert.True(service.IsActive);
            ProfileSnapshot snapshot1 = service.StopProfiling();
            Assert.False(service.IsActive);
            Assert.NotNull(snapshot1);

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

            service.StartProfiling();
            Thread.Sleep(10);
            ProfileSnapshot snapshot = service.StopProfiling();

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
            MockTimeTracker timeTracker = new MockTimeTracker { ElapsedTime = TimeSpan.FromMilliseconds(100) };
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);
            service.StartProfiling();

            ProfileSnapshot snapshot = service.GetCurrentSnapshot();

            Assert.NotNull(snapshot);
            Assert.True(snapshot.ElapsedTime >= TimeSpan.Zero);
        }

        /// <summary>
        ///     Tests that Reset can be called multiple times.
        /// </summary>
        [Fact]
        public void Reset_CanBeCalledMultipleTimes()
        {
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);

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
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);

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
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);

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
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);
            service.StartProfiling();

            ProfileSnapshot snapshot = service.StopProfiling();

            Assert.NotNull(snapshot.EndMetrics);
            Assert.NotEqual(DateTime.MinValue, snapshot.EndTime);
        }

        /// <summary>
        ///     Tests that ProfileSnapshot contains start and end times.
        /// </summary>
        [Fact]
        public void ProfileSnapshot_ContainsStartAndEndTimes()
        {
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);
            DateTime beforeStart = DateTime.Now;

            service.StartProfiling();
            Thread.Sleep(10);
            ProfileSnapshot snapshot = service.StopProfiling();
            DateTime afterEnd = DateTime.Now;

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
            MockTimeTracker timeTracker = new MockTimeTracker();
            MockResourceMonitor resourceMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(resourceMonitor);
            ProfilerService service = new ProfilerService(timeTracker, factory);
            service.StartProfiling();

            ProfileSnapshot snapshot1 = service.GetCurrentSnapshot();
            Thread.Sleep(10);
            ProfileSnapshot snapshot2 = service.GetCurrentSnapshot();

            Assert.Equal(snapshot1.StartMetrics, snapshot2.StartMetrics);
        }
    }
}



