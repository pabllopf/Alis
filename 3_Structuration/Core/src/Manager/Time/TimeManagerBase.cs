// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TimeManagerBase.cs
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

using System.Diagnostics;
using Alis.Core.Aspect.Logging;

namespace Alis.Core.Manager.Time
{
    /// <summary>
    ///     The time manager base class
    /// </summary>
    /// <seealso cref="ManagerBase" />
    public class TimeManagerBase : ManagerBase
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TimeManagerBase" /> class
        /// </summary>
        public TimeManagerBase() => Timer.Start();

        /// <summary>
        ///     Gets the value of the timer
        /// </summary>
        private Stopwatch Timer { get; } = new Stopwatch();

        /// <summary>
        ///     Gets or sets the value of the fixed time
        /// </summary>
        internal double FixedTime { get; set; }

        /// <summary>
        ///     Gets or sets the value of the time scale
        /// </summary>
        internal double TimeScale { get; } = 1.0f;

        /// <summary>
        ///     Gets or sets the value of the frame count
        /// </summary>
        internal double FrameCount { get; set; }

        /// <summary>
        ///     Gets or sets the value of the current frame
        /// </summary>
        public double CurrentFrame { get; set; }

        /// <summary>
        ///     Gets or sets the value of the fixed delta time
        /// </summary>
        internal double FixedDeltaTime { get; set; }

        /// <summary>
        ///     Gets or sets the value of the maximum frames per second
        /// </summary>
        internal double MaximumFramesPerSecond { get; } = 60.0f;

        /// <summary>
        ///     Gets or sets the value of the time step
        /// </summary>
        public double TimeStep { get; set; }

        /// <summary>
        ///     Gets or sets the value of the max allowed time step
        /// </summary>
        public double MaxAllowedTimeStep { get; set; } = 30.0f;

        /// <summary>
        ///     Syncs the fixed delta time
        /// </summary>
        internal void SyncFixedDeltaTime() => FixedDeltaTime = 1_000.0f / MaximumFramesPerSecond;

        /// <summary>
        ///     Describes whether this instance is new frame
        /// </summary>
        /// <returns>The bool</returns>
        internal bool IsNewFrame() => FixedTime * TimeScale / FrameCount > FixedDeltaTime;

        /// <summary>
        ///     Updates the time step
        /// </summary>
        internal void UpdateTimeStep() => TimeStep = MaxAllowedTimeStep <= 0 ? 1 : 1 / MaxAllowedTimeStep;

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
        internal void UpdateFixedTime() => FixedTime = Timer.Elapsed.TotalMilliseconds;

        /// <summary>
        ///     Inits this instance
        /// </summary>
        public override void Init() => Logger.Info($"Init {GetType().Name}");

        /// <summary>
        ///     Awakes this instance
        /// </summary>
        public override void Awake() => Logger.Info($"Awake {GetType().Name}");

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start() => Logger.Info($"Start {GetType().Name}");

        /// <summary>
        ///     Before the update
        /// </summary>
        public override void BeforeUpdate() => Logger.Info($"BeforeUpdate {GetType().Name}");

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update() => Logger.Info($"Update {GetType().Name}");

        /// <summary>
        ///     Afters the update
        /// </summary>
        public override void AfterUpdate() => Logger.Info($"AfterUpdate {GetType().Name}");

        /// <summary>
        ///     Fix the update
        /// </summary>
        public override void FixedUpdate() => Logger.Info($"FixedUpdate {GetType().Name}");

        /// <summary>
        ///     Dispatches the events
        /// </summary>
        public override void DispatchEvents() => Logger.Info($"DispatchEvents {GetType().Name}");

        /// <summary>
        ///     Draws this instance
        /// </summary>
        public override void Draw() => Logger.Info($"Draw {GetType().Name}");

        /// <summary>
        ///     Resets this instance
        /// </summary>
        public override void Reset() => Logger.Info($"Reset {GetType().Name}");

        /// <summary>
        ///     Stops this instance
        /// </summary>
        public override void Stop() => Logger.Info($"Stop {GetType().Name}");

        /// <summary>
        ///     Exits this instance
        /// </summary>
        public override void Exit() => Logger.Info($"Exit {GetType().Name}");
    }
}