

using System;
using Alis.Extension.Profile.Builders;
using Alis.Extension.Profile.Factories;
using Alis.Extension.Profile.Interfaces;
using Alis.Extension.Profile.Models;
using Alis.Extension.Profile.Test.Mocks;
using Alis.Extension.Profile.Utilities;
using Xunit;

namespace Alis.Extension.Profile.Test.Utilities
{
    /// <summary>
    ///     The profiler scope test class
    /// </summary>
    public class ProfilerScopeTest
    {
        /// <summary>
        ///     Tests that constructor throws exception when profiler service is null
        /// </summary>
        [Fact]
        public void Constructor_ThrowsException_WhenProfilerServiceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new ProfilerScope(null));
        }

        /// <summary>
        ///     Tests that constructor starts profiling automatically
        /// </summary>
        [Fact]
        public void Constructor_StartsProfilingAutomatically()
        {
            MockTimeTracker mockTracker = new MockTimeTracker();
            MockResourceMonitor mockMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);
            IProfilerService service = new ProfilerService(mockTracker, factory);

            using (ProfilerScope scope = new ProfilerScope(service))
            {
                Assert.True(service.IsActive);
            }
        }

        /// <summary>
        ///     Tests that dispose stops profiling
        /// </summary>
        [Fact]
        public void Dispose_StopsProfiling()
        {
            MockTimeTracker mockTracker = new MockTimeTracker
            {
                ElapsedTime = TimeSpan.FromMilliseconds(100)
            };
            MockResourceMonitor mockMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);
            IProfilerService service = new ProfilerService(mockTracker, factory);

            ProfilerScope scope = new ProfilerScope(service);
            Assert.True(service.IsActive);

            scope.Dispose();

            Assert.False(service.IsActive);
        }

        /// <summary>
        ///     Tests that dispose invokes callback with snapshot
        /// </summary>
        [Fact]
        public void Dispose_InvokesCallback_WithSnapshot()
        {
            MockTimeTracker mockTracker = new MockTimeTracker
            {
                ElapsedTime = TimeSpan.FromMilliseconds(500)
            };
            MockResourceMonitor mockMonitor = new MockResourceMonitor
            {
                CpuUsage = 150,
                MemoryUsage = 2048
            };
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);
            IProfilerService service = new ProfilerService(mockTracker, factory);

            ProfileSnapshot capturedSnapshot = default(ProfileSnapshot);
            bool callbackInvoked = false;

            using (ProfilerScope scope = new ProfilerScope(service, snapshot =>
                   {
                       capturedSnapshot = snapshot;
                       callbackInvoked = true;
                   }))
            {
            }

            Assert.True(callbackInvoked);
            Assert.Equal(TimeSpan.FromMilliseconds(500), capturedSnapshot.ElapsedTime);
        }

        /// <summary>
        ///     Tests that using statement syntax works correctly
        /// </summary>
        [Fact]
        public void UsingStatement_WorksCorrectly()
        {
            MockTimeTracker mockTracker = new MockTimeTracker
            {
                ElapsedTime = TimeSpan.FromMilliseconds(250)
            };
            MockResourceMonitor mockMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);
            IProfilerService service = new ProfilerService(mockTracker, factory);

            bool wasActive = false;

            using (ProfilerScope scope = new ProfilerScope(service))
            {
                wasActive = service.IsActive;
            }

            Assert.True(wasActive); // Was active during scope
            Assert.False(service.IsActive); // Not active after disposal
        }

        /// <summary>
        ///     Tests that dispose can be called multiple times safely
        /// </summary>
        [Fact]
        public void Dispose_CanBeCalledMultipleTimes_Safely()
        {
            MockTimeTracker mockTracker = new MockTimeTracker
            {
                ElapsedTime = TimeSpan.FromMilliseconds(100)
            };
            MockResourceMonitor mockMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);
            IProfilerService service = new ProfilerService(mockTracker, factory);

            ProfilerScope scope = new ProfilerScope(service);

            scope.Dispose();
            scope.Dispose(); // Second call

            Assert.False(service.IsActive);
        }

        /// <summary>
        ///     Tests that callback is only invoked once
        /// </summary>
        [Fact]
        public void Callback_IsOnlyInvokedOnce()
        {
            MockTimeTracker mockTracker = new MockTimeTracker
            {
                ElapsedTime = TimeSpan.FromMilliseconds(100)
            };
            MockResourceMonitor mockMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);
            IProfilerService service = new ProfilerService(mockTracker, factory);

            int callbackCount = 0;
            ProfilerScope scope = new ProfilerScope(service, _ => callbackCount++);

            scope.Dispose();
            scope.Dispose(); // Second disposal

            Assert.Equal(1, callbackCount);
        }

        /// <summary>
        ///     Tests that scope without callback works correctly
        /// </summary>
        [Fact]
        public void Scope_WithoutCallback_WorksCorrectly()
        {
            MockTimeTracker mockTracker = new MockTimeTracker
            {
                ElapsedTime = TimeSpan.FromMilliseconds(100)
            };
            MockResourceMonitor mockMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);
            IProfilerService service = new ProfilerService(mockTracker, factory);

            using (ProfilerScope scope = new ProfilerScope(service))
            {
            }

            Assert.False(service.IsActive);
        }

        /// <summary>
        ///     Tests that nested scopes work correctly
        /// </summary>
        [Fact]
        public void NestedScopes_WorkCorrectly()
        {
            IProfilerService service1 = ProfilerServiceBuilder.CreateDefault();
            IProfilerService service2 = ProfilerServiceBuilder.CreateDefault();

            using (ProfilerScope scope1 = new ProfilerScope(service1))
            {
                Assert.True(service1.IsActive);

                using (ProfilerScope scope2 = new ProfilerScope(service2))
                {
                    Assert.True(service2.IsActive);
                }

                Assert.False(service2.IsActive);
                Assert.True(service1.IsActive);
            }

            Assert.False(service1.IsActive);
        }
    }
}