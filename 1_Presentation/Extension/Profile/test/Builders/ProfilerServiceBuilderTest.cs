

using System;
using Alis.Extension.Profile.Builders;
using Alis.Extension.Profile.Interfaces;
using Alis.Extension.Profile.Models;
using Alis.Extension.Profile.Test.Mocks;
using Xunit;

namespace Alis.Extension.Profile.Test.Builders
{
    /// <summary>
    ///     The profiler service builder test class
    /// </summary>
    public class ProfilerServiceBuilderTest
    {
        /// <summary>
        ///     Tests that build creates profiler service with default implementations
        /// </summary>
        [Fact]
        public void Build_CreatesProfilerService_WithDefaultImplementations()
        {
            ProfilerServiceBuilder builder = new ProfilerServiceBuilder();

            IProfilerService service = builder.Build();

            Assert.NotNull(service);
            Assert.False(service.IsActive);
        }

        /// <summary>
        ///     Tests that with time tracker sets custom time tracker
        /// </summary>
        [Fact]
        public void WithTimeTracker_SetsCustomTimeTracker()
        {
            ProfilerServiceBuilder builder = new ProfilerServiceBuilder();
            MockTimeTracker mockTracker = new MockTimeTracker();

            IProfilerService service = builder
                .WithTimeTracker(mockTracker)
                .Build();

            service.StartProfiling();

            Assert.True(mockTracker.StartCalled);
        }

        /// <summary>
        ///     Tests that with resource monitor sets custom resource monitor
        /// </summary>
        [Fact]
        public void WithResourceMonitor_SetsCustomResourceMonitor()
        {
            ProfilerServiceBuilder builder = new ProfilerServiceBuilder();
            MockResourceMonitor mockMonitor = new MockResourceMonitor
            {
                CpuUsage = 123.45,
                MemoryUsage = 2048
            };

            IProfilerService service = builder
                .WithResourceMonitor(mockMonitor)
                .Build();

            service.StartProfiling();

            Assert.True(mockMonitor.GetCpuUsageCalled);
            Assert.True(mockMonitor.GetMemoryUsageCalled);
        }

        /// <summary>
        ///     Tests that builder supports method chaining
        /// </summary>
        [Fact]
        public void Builder_SupportsMethodChaining()
        {
            MockTimeTracker mockTracker = new MockTimeTracker();
            MockResourceMonitor mockMonitor = new MockResourceMonitor();

            IProfilerService service = new ProfilerServiceBuilder()
                .WithTimeTracker(mockTracker)
                .WithResourceMonitor(mockMonitor)
                .Build();

            Assert.NotNull(service);
        }

        /// <summary>
        ///     Tests that create default returns configured service
        /// </summary>
        [Fact]
        public void CreateDefault_ReturnsConfiguredService()
        {
            IProfilerService service = ProfilerServiceBuilder.CreateDefault();

            Assert.NotNull(service);
            Assert.False(service.IsActive);
        }

        /// <summary>
        ///     Tests that built service with custom components works correctly
        /// </summary>
        [Fact]
        public void BuiltService_WithCustomComponents_WorksCorrectly()
        {
            MockTimeTracker mockTracker = new MockTimeTracker
            {
                ElapsedTime = TimeSpan.FromMilliseconds(500)
            };
            MockResourceMonitor mockMonitor = new MockResourceMonitor
            {
                CpuUsage = 150,
                MemoryUsage = 3072
            };

            IProfilerService service = new ProfilerServiceBuilder()
                .WithTimeTracker(mockTracker)
                .WithResourceMonitor(mockMonitor)
                .Build();

            service.StartProfiling();
            ProfileSnapshot snapshot = service.StopProfiling();

            Assert.Equal(TimeSpan.FromMilliseconds(500), snapshot.ElapsedTime);
            Assert.Equal(150, snapshot.StartMetrics.CpuUsageMilliseconds);
            Assert.Equal(3072, snapshot.StartMetrics.MemoryUsageBytes);
        }

        /// <summary>
        ///     Tests that multiple builds create independent services
        /// </summary>
        [Fact]
        public void MultipleBuild_CreatesIndependentServices()
        {
            ProfilerServiceBuilder builder = new ProfilerServiceBuilder();

            IProfilerService service1 = builder.Build();
            IProfilerService service2 = builder.Build();

            service1.StartProfiling();

            Assert.True(service1.IsActive);
            Assert.False(service2.IsActive);
        }

        /// <summary>
        ///     Tests that builder can be reused for different configurations
        /// </summary>
        [Fact]
        public void Builder_CanBeReused_ForDifferentConfigurations()
        {
            ProfilerServiceBuilder builder = new ProfilerServiceBuilder();
            MockTimeTracker tracker1 = new MockTimeTracker();
            MockTimeTracker tracker2 = new MockTimeTracker();

            IProfilerService service1 = builder.WithTimeTracker(tracker1).Build();
            IProfilerService service2 = builder.WithTimeTracker(tracker2).Build();

            service1.StartProfiling();
            service2.StartProfiling();

            Assert.True(tracker1.StartCalled);
            Assert.True(tracker2.StartCalled);
        }
    }
}