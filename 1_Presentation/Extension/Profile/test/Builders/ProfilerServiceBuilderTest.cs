// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ProfilerServiceBuilderTest.cs
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
            // Arrange
            ProfilerServiceBuilder builder = new ProfilerServiceBuilder();

            // Act
            IProfilerService service = builder.Build();

            // Assert
            Assert.NotNull(service);
            Assert.False(service.IsActive);
        }

        /// <summary>
        ///     Tests that with time tracker sets custom time tracker
        /// </summary>
        [Fact]
        public void WithTimeTracker_SetsCustomTimeTracker()
        {
            // Arrange
            ProfilerServiceBuilder builder = new ProfilerServiceBuilder();
            MockTimeTracker mockTracker = new MockTimeTracker();

            // Act
            IProfilerService service = builder
                .WithTimeTracker(mockTracker)
                .Build();

            service.StartProfiling();

            // Assert
            Assert.True(mockTracker.StartCalled);
        }

        /// <summary>
        ///     Tests that with resource monitor sets custom resource monitor
        /// </summary>
        [Fact]
        public void WithResourceMonitor_SetsCustomResourceMonitor()
        {
            // Arrange
            ProfilerServiceBuilder builder = new ProfilerServiceBuilder();
            MockResourceMonitor mockMonitor = new MockResourceMonitor
            {
                CpuUsage = 123.45,
                MemoryUsage = 2048
            };

            // Act
            IProfilerService service = builder
                .WithResourceMonitor(mockMonitor)
                .Build();

            service.StartProfiling();

            // Assert
            Assert.True(mockMonitor.GetCpuUsageCalled);
            Assert.True(mockMonitor.GetMemoryUsageCalled);
        }

        /// <summary>
        ///     Tests that builder supports method chaining
        /// </summary>
        [Fact]
        public void Builder_SupportsMethodChaining()
        {
            // Arrange
            MockTimeTracker mockTracker = new MockTimeTracker();
            MockResourceMonitor mockMonitor = new MockResourceMonitor();

            // Act
            IProfilerService service = new ProfilerServiceBuilder()
                .WithTimeTracker(mockTracker)
                .WithResourceMonitor(mockMonitor)
                .Build();

            // Assert
            Assert.NotNull(service);
        }

        /// <summary>
        ///     Tests that create default returns configured service
        /// </summary>
        [Fact]
        public void CreateDefault_ReturnsConfiguredService()
        {
            // Act
            IProfilerService service = ProfilerServiceBuilder.CreateDefault();

            // Assert
            Assert.NotNull(service);
            Assert.False(service.IsActive);
        }

        /// <summary>
        ///     Tests that built service with custom components works correctly
        /// </summary>
        [Fact]
        public void BuiltService_WithCustomComponents_WorksCorrectly()
        {
            // Arrange
            MockTimeTracker mockTracker = new MockTimeTracker
            {
                ElapsedTime = TimeSpan.FromMilliseconds(500)
            };
            MockResourceMonitor mockMonitor = new MockResourceMonitor
            {
                CpuUsage = 150,
                MemoryUsage = 3072
            };

            // Act
            IProfilerService service = new ProfilerServiceBuilder()
                .WithTimeTracker(mockTracker)
                .WithResourceMonitor(mockMonitor)
                .Build();

            service.StartProfiling();
            ProfileSnapshot snapshot = service.StopProfiling();

            // Assert
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
            // Arrange
            ProfilerServiceBuilder builder = new ProfilerServiceBuilder();

            // Act
            IProfilerService service1 = builder.Build();
            IProfilerService service2 = builder.Build();

            service1.StartProfiling();

            // Assert
            Assert.True(service1.IsActive);
            Assert.False(service2.IsActive);
        }

        /// <summary>
        ///     Tests that builder can be reused for different configurations
        /// </summary>
        [Fact]
        public void Builder_CanBeReused_ForDifferentConfigurations()
        {
            // Arrange
            ProfilerServiceBuilder builder = new ProfilerServiceBuilder();
            MockTimeTracker tracker1 = new MockTimeTracker();
            MockTimeTracker tracker2 = new MockTimeTracker();

            // Act
            IProfilerService service1 = builder.WithTimeTracker(tracker1).Build();
            IProfilerService service2 = builder.WithTimeTracker(tracker2).Build();

            service1.StartProfiling();
            service2.StartProfiling();

            // Assert
            Assert.True(tracker1.StartCalled);
            Assert.True(tracker2.StartCalled);
        }
    }
}

