// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ProfilerService.cs
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

namespace Alis.Extension.Profile
{
    /// <summary>
    ///     Orchestrates profiling operations by coordinating time tracking and resource monitoring.
    ///     This service follows the Facade pattern to provide a simplified interface
    ///     for complex profiling operations and dependency injection for testability.
    /// </summary>
    public class ProfilerService : IProfilerService
    {
        /// <summary>
        ///     The time tracker for measuring elapsed time during profiling.
        /// </summary>
        private readonly ITimeTracker timeTracker;

        /// <summary>
        ///     The factory for creating resource metric snapshots.
        /// </summary>
        private readonly ResourceMetricsFactory metricsFactory;

        /// <summary>
        ///     The initial resource metrics captured at the start of profiling.
        /// </summary>
        private ResourceMetrics startMetrics;

        /// <summary>
        ///     The start time of the current profiling session.
        /// </summary>
        private DateTime sessionStartTime;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProfilerService" /> class.
        /// </summary>
        /// <param name="timeTracker">The time tracker implementation to use.</param>
        /// <param name="metricsFactory">The factory for creating resource metrics.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when timeTracker or metricsFactory is null.
        /// </exception>
        public ProfilerService(ITimeTracker timeTracker, ResourceMetricsFactory metricsFactory)
        {
            this.timeTracker = timeTracker ?? throw new ArgumentNullException(nameof(timeTracker));
            this.metricsFactory = metricsFactory ?? throw new ArgumentNullException(nameof(metricsFactory));
            startMetrics = ResourceMetrics.Empty;
            sessionStartTime = DateTime.MinValue;
        }

        /// <summary>
        ///     Gets a value indicating whether profiling is currently active.
        /// </summary>
        /// <value>
        ///     <c>true</c> if profiling is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive => timeTracker.IsRunning;

        /// <summary>
        ///     Starts a new profiling session, capturing initial resource metrics
        ///     and beginning time tracking.
        /// </summary>
        public void StartProfiling()
        {
            sessionStartTime = DateTime.Now;
            startMetrics = metricsFactory.CreateSnapshot();
            timeTracker.Start();
        }

        /// <summary>
        ///     Stops the current profiling session and captures final metrics.
        /// </summary>
        /// <returns>
        ///     A <see cref="ProfileSnapshot" /> containing the collected profiling data.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///     Thrown when attempting to stop profiling without an active session.
        /// </exception>
        public ProfileSnapshot StopProfiling()
        {
            if (!IsActive)
            {
                throw new InvalidOperationException("Cannot stop profiling: no active profiling session.");
            }

            timeTracker.Stop();
            ResourceMetrics endMetrics = metricsFactory.CreateSnapshot();
            DateTime sessionEndTime = DateTime.Now;

            return new ProfileSnapshot(
                elapsedTime: timeTracker.GetElapsedTime(),
                startMetrics: startMetrics,
                endMetrics: endMetrics,
                startTime: sessionStartTime,
                endTime: sessionEndTime
            );
        }

        /// <summary>
        ///     Gets the current profiling snapshot without stopping the session.
        ///     Useful for real-time monitoring during long-running operations.
        /// </summary>
        /// <returns>
        ///     A <see cref="ProfileSnapshot" /> representing the current state.
        /// </returns>
        public ProfileSnapshot GetCurrentSnapshot()
        {
            ResourceMetrics currentMetrics = metricsFactory.CreateSnapshot();
            DateTime currentTime = DateTime.Now;

            return new ProfileSnapshot(
                elapsedTime: timeTracker.GetElapsedTime(),
                startMetrics: startMetrics,
                endMetrics: currentMetrics,
                startTime: sessionStartTime,
                endTime: currentTime
            );
        }

        /// <summary>
        ///     Resets the profiler service to its initial state, clearing all data.
        /// </summary>
        public void Reset()
        {
            timeTracker.Reset();
            startMetrics = ResourceMetrics.Empty;
            sessionStartTime = DateTime.MinValue;
        }
    }
}

