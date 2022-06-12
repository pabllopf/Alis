// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Time.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.Diagnostics;

namespace Alis.Core.Configurations
{
    /// <summary>
    ///     The time class
    /// </summary>
    public class Time
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Time" /> class
        /// </summary>
        public Time()
        {
            Timer = new Stopwatch();
            Timer.Start();
        }

        /// <summary>
        ///     Gets the value of the timer
        /// </summary>
        private Stopwatch Timer { get; } = new Stopwatch();

        /// <summary>
        ///     Gets or sets the value of the fixed time
        /// </summary>
        public double FixedTime { get; set; }

        /// <summary>
        ///     Gets or sets the value of the time scale
        /// </summary>
        public double TimeScale { get; set; } = 1.0f;

        /// <summary>
        ///     Gets or sets the value of the frame count
        /// </summary>
        public double FrameCount { get; set; }

        /// <summary>
        ///     Gets or sets the value of the current frame
        /// </summary>
        public double CurrentFrame { get; set; }

        /// <summary>
        ///     Gets or sets the value of the fixed delta time
        /// </summary>
        public double FixedDeltaTime { get; set; }

        /// <summary>
        ///     Gets or sets the value of the maximum frames per second
        /// </summary>
        public double MaximumFramesPerSecond { get; set; } = 60.0f;

        /// <summary>
        ///     Gets or sets the value of the time step
        /// </summary>
        public double TimeStep { get; set; }

        /// <summary>
        ///     Gets or sets the value of the maximun allowed time step
        /// </summary>
        public double MaximunAllowedTimeStep { get; set; } = 30.0f;

        /// <summary>
        ///     Syncs the fixed delta time
        /// </summary>
        internal void SyncFixedDeltaTime()
        {
            FixedDeltaTime = 1_000.0f / MaximumFramesPerSecond;
        }

        /// <summary>
        ///     Describes whether this instance is new frame
        /// </summary>
        /// <returns>The bool</returns>
        internal bool IsNewFrame()
        {
            return FixedTime * TimeScale / FrameCount > FixedDeltaTime;
        }

        /// <summary>
        ///     Updates the time step
        /// </summary>
        internal void UpdateTimeStep()
        {
            TimeStep = MaximunAllowedTimeStep <= 0 ? 1 : 1 / MaximunAllowedTimeStep;
        }

        /// <summary>
        ///     Counters the frames
        /// </summary>
        internal void CounterFrames()
        {
            CurrentFrame = (FrameCount < MaximumFramesPerSecond ? FrameCount : FrameCount % MaximumFramesPerSecond) + 1;
            FrameCount += 1.0f;
        }

        /// <summary>
        ///     Updates the fixed time
        /// </summary>
        internal void UpdateFixedTime()
        {
            FixedTime = Timer.Elapsed.TotalMilliseconds;
        }
    }
}