// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ITimeTracker.cs
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

namespace Alis.Extension.Profile.Interfaces
{
    /// <summary>
    ///     Defines the contract for tracking time intervals during profiling operations.
    ///     This interface provides methods to start, stop, and measure elapsed time
    ///     with high precision for performance analysis.
    /// </summary>
    public interface ITimeTracker
    {
        /// <summary>
        ///     Gets a value indicating whether the time tracker is currently running.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the tracker is running; otherwise, <c>false</c>.
        /// </value>
        bool IsRunning { get; }

        /// <summary>
        ///     Starts tracking time from the current moment.
        ///     If the tracker is already running, this method should restart the tracking.
        /// </summary>
        void Start();

        /// <summary>
        ///     Stops tracking time and records the elapsed duration.
        ///     If the tracker is not running, this method should have no effect.
        /// </summary>
        void Stop();

        /// <summary>
        ///     Resets the time tracker to its initial state, clearing all recorded data.
        /// </summary>
        void Reset();

        /// <summary>
        ///     Gets the total elapsed time since the tracker was started.
        /// </summary>
        /// <returns>
        ///     A <see cref="TimeSpan" /> representing the total elapsed time.
        ///     Returns <see cref="TimeSpan.Zero" /> if the tracker has not been started.
        /// </returns>
        TimeSpan GetElapsedTime();

        /// <summary>
        ///     Gets the start time when the tracker was initiated.
        /// </summary>
        /// <returns>
        ///     A <see cref="DateTime" /> representing when tracking started.
        ///     Returns <see cref="DateTime.MinValue" /> if the tracker has not been started.
        /// </returns>
        DateTime GetStartTime();
    }
}

