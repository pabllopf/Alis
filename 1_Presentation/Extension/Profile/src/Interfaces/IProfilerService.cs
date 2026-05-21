

using System;
using Alis.Extension.Profile.Models;

namespace Alis.Extension.Profile.Interfaces
{
    /// <summary>
    ///     Defines the contract for the profiler service that orchestrates
    ///     time tracking and resource monitoring operations. This service
    ///     provides high-level profiling capabilities for game engine components.
    /// </summary>
    public interface IProfilerService
    {
        /// <summary>
        ///     Gets a value indicating whether profiling is currently active.
        /// </summary>
        /// <value>
        ///     <c>true</c> if profiling is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; }

        /// <summary>
        ///     Starts a new profiling session, capturing initial resource metrics
        ///     and beginning time tracking.
        /// </summary>
        void StartProfiling();

        /// <summary>
        ///     Stops the current profiling session and captures final metrics.
        /// </summary>
        /// <returns>
        ///     A <see cref="ProfileSnapshot" /> containing the collected profiling data.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///     Thrown when attempting to stop profiling without an active session.
        /// </exception>
        ProfileSnapshot StopProfiling();

        /// <summary>
        ///     Gets the current profiling snapshot without stopping the session.
        ///     Useful for real-time monitoring during long-running operations.
        /// </summary>
        /// <returns>
        ///     A <see cref="ProfileSnapshot" /> representing the current state.
        /// </returns>
        ProfileSnapshot GetCurrentSnapshot();

        /// <summary>
        ///     Resets the profiler service to its initial state, clearing all data.
        /// </summary>
        void Reset();
    }
}