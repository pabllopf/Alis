// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Clock.cs
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

namespace Alis.Core.Aspect.Time
{
    /// <summary>
    ///     Provides a high-resolution time measurement utility similar to a stopwatch,
    ///     allowing callers to measure elapsed time with start, stop, reset, and restart operations.
    ///     Uses <see cref="DateTime.UtcNow" /> as the underlying time source.
    /// </summary>
    /// <remarks>
    ///     This class is not thread-safe. Instances should not be shared across threads without external synchronization.
    ///     When started, elapsed time accumulates until the clock is stopped.
    /// </remarks>
    public class Clock
    {
        /// <summary>
        ///     The elapsed
        /// </summary>
        private TimeSpan _elapsed;

        /// <summary>
        ///     The is running
        /// </summary>
        private bool _isRunning;

        /// <summary>
        ///     The start time
        /// </summary>
        private DateTime _startTime;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Clock" /> class with elapsed time set to zero and the clock in a stopped state.
        /// </summary>
        public Clock()
        {
            Reset();
        }

        /// <summary>
        ///     Gets the total elapsed time measured by the clock, expressed in whole seconds.
        /// </summary>
        /// <returns>The total elapsed seconds, computed as <see cref="ElapsedMilliseconds" /> divided by 1000.</returns>
        public long ElapsedSeconds => ElapsedMilliseconds / 1000;

        /// <summary>
        ///     Gets a value indicating whether the clock is currently running (measuring time).
        /// </summary>
        /// <returns><c>true</c> if the clock is running; otherwise, <c>false</c>.</returns>
        public bool IsRunning => _isRunning;

        /// <summary>
        ///     Gets the total elapsed time measured by the clock.
        ///     If the clock is currently running, the returned value includes the time elapsed since the last start.
        ///     If the clock is stopped, the returned value is the accumulated elapsed time at the moment it was stopped.
        /// </summary>
        /// <returns>A <see cref="TimeSpan" /> representing the total elapsed time.</returns>
        public TimeSpan Elapsed => _isRunning ? _elapsed + (DateTime.UtcNow - _startTime) : _elapsed;

        /// <summary>
        ///     Gets the total elapsed time measured by the clock, expressed in milliseconds.
        /// </summary>
        /// <returns>The total elapsed milliseconds, truncated to a whole number.</returns>
        public long ElapsedMilliseconds => (long) Elapsed.TotalMilliseconds;

        /// <summary>
        ///     Gets the total elapsed time measured by the clock, expressed in tick units (100-nanosecond intervals).
        /// </summary>
        /// <returns>The total elapsed ticks, equivalent to <see cref="TimeSpan.Ticks" />.</returns>
        public long ElapsedTicks => Elapsed.Ticks;

        /// <summary>
        ///     Starts or resumes measuring elapsed time. If the clock is already running, this method is a no-op.
        /// </summary>
        public void Start()
        {
            // Calling start on a running Stopwatch is a no-op.
            if (!_isRunning)
            {
                _startTime = DateTime.UtcNow;
                _isRunning = true;
            }
        }

        /// <summary>
        ///     Creates a new <see cref="Clock" /> instance and immediately starts it.
        ///     This is a convenience factory method equivalent to <c>new Clock(); clock.Start();</c>.
        /// </summary>
        /// <returns>A new <see cref="Clock" /> instance that is already running.</returns>
        public static Clock Create()
        {
            Clock s = new Clock();
            s.Start();
            return s;
        }

        /// <summary>
        ///     Stops measuring elapsed time and freezes the accumulated elapsed value.
        ///     If the clock is already stopped, this method is a no-op.
        /// </summary>
        public void Stop()
        {
            // Calling stop on a stopped Stopwatch is a no-op.
            if (_isRunning)
            {
                _elapsed += DateTime.UtcNow - _startTime;
                _isRunning = false;
            }
        }

        /// <summary>
        ///     Stops the clock and resets the accumulated elapsed time to zero.
        /// </summary>
        public void Reset()
        {
            _elapsed = TimeSpan.Zero;
            _isRunning = false;
            _startTime = DateTime.MinValue;
        }

        // Convenience method for replacing {sw.Reset(); sw.Start();} with a single sw.Restart()
        /// <summary>
        ///     Resets the elapsed time to zero and starts the clock.
        ///     This is a convenience method equivalent to calling <see cref="Reset" /> followed by <see cref="Start" />.
        /// </summary>
        public void Restart()
        {
            _elapsed = TimeSpan.Zero;
            _startTime = DateTime.UtcNow;
            _isRunning = true;
        }

        /// <summary>
        ///     Returns the <see cref="Elapsed" /> time as a string.
        /// </summary>
        /// <returns>
        ///     Elapsed time string in the same format used by <see cref="TimeSpan.ToString()" />.
        /// </returns>
        public override string ToString() => Elapsed.ToString();
    }
}