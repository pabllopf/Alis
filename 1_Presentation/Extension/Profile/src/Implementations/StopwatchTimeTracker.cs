

using System;
using System.Diagnostics;
using Alis.Extension.Profile.Interfaces;

namespace Alis.Extension.Profile.Implementations
{
    /// <summary>
    ///     Provides high-precision time tracking using <see cref="Stopwatch" />.
    ///     This implementation offers better accuracy than DateTime-based tracking
    ///     and is suitable for performance-critical profiling scenarios.
    /// </summary>
    public class StopwatchTimeTracker : ITimeTracker
    {
        /// <summary>
        ///     The internal stopwatch instance used for high-precision timing.
        /// </summary>
        private readonly Stopwatch stopwatch;

        /// <summary>
        ///     The time when tracking was started.
        /// </summary>
        private DateTime startTime;

        /// <summary>
        ///     Initializes a new instance of the <see cref="StopwatchTimeTracker" /> class.
        /// </summary>
        public StopwatchTimeTracker()
        {
            stopwatch = new Stopwatch();
            startTime = DateTime.MinValue;
        }

        /// <summary>
        ///     Gets a value indicating whether the time tracker is currently running.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the tracker is running; otherwise, <c>false</c>.
        /// </value>
        public bool IsRunning => stopwatch.IsRunning;

        /// <summary>
        ///     Starts tracking time from the current moment.
        ///     If the tracker is already running, this method restarts the tracking.
        /// </summary>
        public void Start()
        {
            startTime = DateTime.Now;
            stopwatch.Restart();
        }

        /// <summary>
        ///     Stops tracking time and records the elapsed duration.
        ///     If the tracker is not running, this method has no effect.
        /// </summary>
        public void Stop()
        {
            if (stopwatch.IsRunning)
            {
                stopwatch.Stop();
            }
        }

        /// <summary>
        ///     Resets the time tracker to its initial state, clearing all recorded data.
        /// </summary>
        public void Reset()
        {
            stopwatch.Reset();
            startTime = DateTime.MinValue;
        }

        /// <summary>
        ///     Gets the total elapsed time since the tracker was started.
        /// </summary>
        /// <returns>
        ///     A <see cref="TimeSpan" /> representing the total elapsed time.
        ///     Returns <see cref="TimeSpan.Zero" /> if the tracker has not been started.
        /// </returns>
        public TimeSpan GetElapsedTime() => stopwatch.Elapsed;

        /// <summary>
        ///     Gets the start time when the tracker was initiated.
        /// </summary>
        /// <returns>
        ///     A <see cref="DateTime" /> representing when tracking started.
        ///     Returns <see cref="DateTime.MinValue" /> if the tracker has not been started.
        /// </returns>
        public DateTime GetStartTime() => startTime;
    }
}