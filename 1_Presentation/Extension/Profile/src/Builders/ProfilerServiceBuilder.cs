// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ProfilerServiceBuilder.cs
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

using Alis.Extension.Profile.Factories;
using Alis.Extension.Profile.Implementations;
using Alis.Extension.Profile.Interfaces;

namespace Alis.Extension.Profile.Builders
{
    /// <summary>
    ///     Implements the Builder pattern for constructing <see cref="IProfilerService" /> instances
    ///     with customizable components. Provides a fluent API for configuration and
    ///     sensible defaults for ease of use.
    /// </summary>
    public class ProfilerServiceBuilder
    {
        /// <summary>
        ///     The time tracker to use. Defaults to StopwatchTimeTracker if not specified.
        /// </summary>
        private ITimeTracker timeTracker;

        /// <summary>
        ///     The resource monitor to use. Defaults to ProcessResourceMonitor if not specified.
        /// </summary>
        private IResourceMonitor resourceMonitor;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProfilerServiceBuilder" /> class
        ///     with default implementations.
        /// </summary>
        public ProfilerServiceBuilder()
        {
            timeTracker = null;
            resourceMonitor = null;
        }

        /// <summary>
        ///     Configures the builder to use a specific time tracker implementation.
        /// </summary>
        /// <param name="tracker">The time tracker to use.</param>
        /// <returns>
        ///     The current builder instance for method chaining.
        /// </returns>
        public ProfilerServiceBuilder WithTimeTracker(ITimeTracker tracker)
        {
            timeTracker = tracker;
            return this;
        }

        /// <summary>
        ///     Configures the builder to use a specific resource monitor implementation.
        /// </summary>
        /// <param name="monitor">The resource monitor to use.</param>
        /// <returns>
        ///     The current builder instance for method chaining.
        /// </returns>
        public ProfilerServiceBuilder WithResourceMonitor(IResourceMonitor monitor)
        {
            resourceMonitor = monitor;
            return this;
        }

        /// <summary>
        ///     Builds and returns a configured <see cref="IProfilerService" /> instance.
        ///     If components were not explicitly set, default implementations are used.
        /// </summary>
        /// <returns>
        ///     A fully configured <see cref="IProfilerService" /> instance.
        /// </returns>
        public IProfilerService Build()
        {
            ITimeTracker tracker = timeTracker ?? new StopwatchTimeTracker();
            IResourceMonitor monitor = resourceMonitor ?? new ProcessResourceMonitor();
            ResourceMetricsFactory factory = new ResourceMetricsFactory(monitor);

            return new ProfilerService(tracker, factory);
        }

        /// <summary>
        ///     Creates a default profiler service with standard implementations.
        ///     This is a convenience method equivalent to calling new ProfilerServiceBuilder().Build().
        /// </summary>
        /// <returns>
        ///     A <see cref="IProfilerService" /> with default configurations.
        /// </returns>
        public static IProfilerService CreateDefault()
        {
            return new ProfilerServiceBuilder().Build();
        }
    }
}

