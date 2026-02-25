// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ProfilerScopeTest.cs
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
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ProfilerScope(null));
        }

        /// <summary>
        ///     Tests that constructor starts profiling automatically
        /// </summary>
        [Fact]
        public void Constructor_StartsProfilingAutomatically()
        {
            // Arrange
            MockTimeTracker mockTracker = new MockTimeTracker();
            MockResourceMonitor mockMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);
            IProfilerService service = new ProfilerService(mockTracker, factory);

            // Act
            using (ProfilerScope scope = new ProfilerScope(service))
            {
                // Assert
                Assert.True(service.IsActive);
            }
        }

        /// <summary>
        ///     Tests that dispose stops profiling
        /// </summary>
        [Fact]
        public void Dispose_StopsProfiling()
        {
            // Arrange
            MockTimeTracker mockTracker = new MockTimeTracker
            {
                ElapsedTime = TimeSpan.FromMilliseconds(100)
            };
            MockResourceMonitor mockMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);
            IProfilerService service = new ProfilerService(mockTracker, factory);

            ProfilerScope scope = new ProfilerScope(service);
            Assert.True(service.IsActive);

            // Act
            scope.Dispose();

            // Assert
            Assert.False(service.IsActive);
        }

        /// <summary>
        ///     Tests that dispose invokes callback with snapshot
        /// </summary>
        [Fact]
        public void Dispose_InvokesCallback_WithSnapshot()
        {
            // Arrange
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

            ProfileSnapshot capturedSnapshot = default;
            bool callbackInvoked = false;

            // Act
            using (ProfilerScope scope = new ProfilerScope(service, snapshot =>
            {
                capturedSnapshot = snapshot;
                callbackInvoked = true;
            }))
            {
                // Do nothing
            }

            // Assert
            Assert.True(callbackInvoked);
            Assert.Equal(TimeSpan.FromMilliseconds(500), capturedSnapshot.ElapsedTime);
        }

        /// <summary>
        ///     Tests that using statement syntax works correctly
        /// </summary>
        [Fact]
        public void UsingStatement_WorksCorrectly()
        {
            // Arrange
            MockTimeTracker mockTracker = new MockTimeTracker
            {
                ElapsedTime = TimeSpan.FromMilliseconds(250)
            };
            MockResourceMonitor mockMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);
            IProfilerService service = new ProfilerService(mockTracker, factory);

            bool wasActive = false;

            // Act
            using (ProfilerScope scope = new ProfilerScope(service))
            {
                wasActive = service.IsActive;
            }

            // Assert
            Assert.True(wasActive); // Was active during scope
            Assert.False(service.IsActive); // Not active after disposal
        }

        /// <summary>
        ///     Tests that dispose can be called multiple times safely
        /// </summary>
        [Fact]
        public void Dispose_CanBeCalledMultipleTimes_Safely()
        {
            // Arrange
            MockTimeTracker mockTracker = new MockTimeTracker
            {
                ElapsedTime = TimeSpan.FromMilliseconds(100)
            };
            MockResourceMonitor mockMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);
            IProfilerService service = new ProfilerService(mockTracker, factory);

            ProfilerScope scope = new ProfilerScope(service);

            // Act
            scope.Dispose();
            scope.Dispose(); // Second call

            // Assert - Should not throw
            Assert.False(service.IsActive);
        }

        /// <summary>
        ///     Tests that callback is only invoked once
        /// </summary>
        [Fact]
        public void Callback_IsOnlyInvokedOnce()
        {
            // Arrange
            MockTimeTracker mockTracker = new MockTimeTracker
            {
                ElapsedTime = TimeSpan.FromMilliseconds(100)
            };
            MockResourceMonitor mockMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);
            IProfilerService service = new ProfilerService(mockTracker, factory);

            int callbackCount = 0;
            ProfilerScope scope = new ProfilerScope(service, _ => callbackCount++);

            // Act
            scope.Dispose();
            scope.Dispose(); // Second disposal

            // Assert
            Assert.Equal(1, callbackCount);
        }

        /// <summary>
        ///     Tests that scope without callback works correctly
        /// </summary>
        [Fact]
        public void Scope_WithoutCallback_WorksCorrectly()
        {
            // Arrange
            MockTimeTracker mockTracker = new MockTimeTracker
            {
                ElapsedTime = TimeSpan.FromMilliseconds(100)
            };
            MockResourceMonitor mockMonitor = new MockResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(mockMonitor);
            IProfilerService service = new ProfilerService(mockTracker, factory);

            // Act
            using (ProfilerScope scope = new ProfilerScope(service))
            {
                // Do nothing
            }

            // Assert - Should complete without errors
            Assert.False(service.IsActive);
        }

        /// <summary>
        ///     Tests that nested scopes work correctly
        /// </summary>
        [Fact]
        public void NestedScopes_WorkCorrectly()
        {
            // Arrange
            IProfilerService service1 = ProfilerServiceBuilder.CreateDefault();
            IProfilerService service2 = ProfilerServiceBuilder.CreateDefault();

            // Act & Assert
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

