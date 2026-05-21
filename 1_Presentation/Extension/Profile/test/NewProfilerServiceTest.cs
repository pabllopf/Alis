

using System;
using Alis.Extension.Profile.Factories;
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
            MockResourceMonitor mockMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);

            Assert.Throws<ArgumentNullException>(() => new ProfilerService(null, factory));
        }

        /// <summary>
        ///     Tests that constructor throws exception when metrics factory is null
        /// </summary>
        [Fact]
        public void Constructor_ThrowsException_WhenMetricsFactoryIsNull()
        {
            MockTimeTracker mockTracker = new MockTimeTracker();

            Assert.Throws<ArgumentNullException>(() => new ProfilerService(mockTracker, null));
        }

        /// <summary>
        ///     Tests that is active returns false initially
        /// </summary>
        [Fact]
        public void IsActive_ReturnsFalse_Initially()
        {
            MockTimeTracker mockTracker = new MockTimeTracker();
            MockResourceMonitor mockMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);
            ProfilerService service = new ProfilerService(mockTracker, factory);

            Assert.False(service.IsActive);
        }

        /// <summary>
        ///     Tests that start profiling activates profiling
        /// </summary>
        [Fact]
        public void StartProfiling_ActivatesProfiling()
        {
            MockTimeTracker mockTracker = new MockTimeTracker();
            MockResourceMonitor mockMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);
            ProfilerService service = new ProfilerService(mockTracker, factory);

            service.StartProfiling();

            Assert.True(service.IsActive);
            Assert.True(mockTracker.StartCalled);
        }

        /// <summary>
        ///     Tests that start profiling captures initial metrics
        /// </summary>
        [Fact]
        public void StartProfiling_CapturesInitialMetrics()
        {
            MockTimeTracker mockTracker = new MockTimeTracker();
            MockResourceMonitor mockMonitor = new MockResourceMonitor
            {
                CpuUsage = 100,
                MemoryUsage = 2048
            };
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);
            ProfilerService service = new ProfilerService(mockTracker, factory);

            service.StartProfiling();

            Assert.True(mockMonitor.GetCpuUsageCalled);
            Assert.True(mockMonitor.GetMemoryUsageCalled);
        }

        /// <summary>
        ///     Tests that stop profiling returns snapshot
        /// </summary>
        [Fact]
        public void StopProfiling_ReturnsSnapshot()
        {
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

            ProfileSnapshot snapshot = service.StopProfiling();

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
            MockTimeTracker mockTracker = new MockTimeTracker();
            MockResourceMonitor mockMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);
            ProfilerService service = new ProfilerService(mockTracker, factory);

            Assert.Throws<InvalidOperationException>(() => service.StopProfiling());
        }

        /// <summary>
        ///     Tests that get current snapshot returns data without stopping
        /// </summary>
        [Fact]
        public void GetCurrentSnapshot_ReturnsData_WithoutStopping()
        {
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

            ProfileSnapshot snapshot = service.GetCurrentSnapshot();

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
            MockTimeTracker mockTracker = new MockTimeTracker();
            MockResourceMonitor mockMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);
            ProfilerService service = new ProfilerService(mockTracker, factory);

            service.StartProfiling();

            service.Reset();

            Assert.True(mockTracker.ResetCalled);
        }

        /// <summary>
        ///     Tests that stop profiling captures end metrics
        /// </summary>
        [Fact]
        public void StopProfiling_CapturesEndMetrics()
        {
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

            ProfileSnapshot snapshot = service.StopProfiling();

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
            MockTimeTracker mockTracker = new MockTimeTracker();
            MockResourceMonitor mockMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);
            ProfilerService service = new ProfilerService(mockTracker, factory);

            Assert.False(service.IsActive);

            mockTracker.IsRunning = true;
            Assert.True(service.IsActive);

            mockTracker.IsRunning = false;
            Assert.False(service.IsActive);
        }
    }
}