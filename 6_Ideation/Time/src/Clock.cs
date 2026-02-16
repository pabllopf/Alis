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
    ///     The clock class
    /// </summary>
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
        ///     Initializes a new instance of the <see cref="Clock" /> class
        /// </summary>
        public Clock()
        {
            Reset();
        }

        /// <summary>
        ///     Gets the value of the elapsed seconds
        /// </summary>
        public long ElapsedSeconds => ElapsedMilliseconds / 1000;

        /// <summary>
        ///     Gets the value of the is running
        /// </summary>
        public bool IsRunning => _isRunning;

        /// <summary>
        ///     Gets the value of the elapsed
        /// </summary>
        public TimeSpan Elapsed => _isRunning ? _elapsed + (DateTime.UtcNow - _startTime) : _elapsed;

        /// <summary>
        ///     Gets the value of the elapsed milliseconds
        /// </summary>
        public long ElapsedMilliseconds => (long) Elapsed.TotalMilliseconds;

        /// <summary>
        ///     Gets the value of the elapsed ticks
        /// </summary>
        public long ElapsedTicks => Elapsed.Ticks;

        /// <summary>
        ///     Gets the value of the debugger display
        /// </summary>
        private string DebuggerDisplay => $"{Elapsed} (IsRunning = {_isRunning})";

        /// <summary>
        ///     Starts this instance
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
        ///     Starts the new
        /// </summary>
        /// <returns>The </returns>
        public static Clock Create()
        {
            Clock s = new Clock();
            s.Start();
            return s;
        }

        /// <summary>
        ///     Stops this instance
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
        ///     Resets this instance
        /// </summary>
        public void Reset()
        {
            _elapsed = TimeSpan.Zero;
            _isRunning = false;
            _startTime = DateTime.MinValue;
        }

        // Convenience method for replacing {sw.Reset(); sw.Start();} with a single sw.Restart()
        /// <summary>
        ///     Restarts this instance
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