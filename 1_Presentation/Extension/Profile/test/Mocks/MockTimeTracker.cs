// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MockTimeTracker.cs
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
using Alis.Extension.Profile.Interfaces;

namespace Alis.Extension.Profile.Test.Mocks
{
    /// <summary>
    ///     Mock implementation of <see cref="ITimeTracker" /> for testing purposes.
    ///     This class allows tests to control time tracking behavior and verify method calls.
    /// </summary>
    public class MockTimeTracker : ITimeTracker
    {
        /// <summary>
        ///     Gets or sets a value indicating whether the tracker is running.
        /// </summary>
        public bool IsRunning { get; set; }

        /// <summary>
        ///     Gets or sets the start time to return.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        ///     Gets or sets the elapsed time to return.
        /// </summary>
        public TimeSpan ElapsedTime { get; set; }

        /// <summary>
        ///     Gets a value indicating whether Start was called.
        /// </summary>
        public bool StartCalled { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether Stop was called.
        /// </summary>
        public bool StopCalled { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether Reset was called.
        /// </summary>
        public bool ResetCalled { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether GetElapsedTime was called.
        /// </summary>
        public bool GetElapsedTimeCalled { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether GetStartTime was called.
        /// </summary>
        public bool GetStartTimeCalled { get; private set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MockTimeTracker" /> class.
        /// </summary>
        public MockTimeTracker()
        {
            IsRunning = false;
            StartTime = DateTime.MinValue;
            ElapsedTime = TimeSpan.Zero;
        }

        /// <summary>
        ///     Simulates starting the tracker.
        /// </summary>
        public void Start()
        {
            StartCalled = true;
            IsRunning = true;
            StartTime = DateTime.Now;
        }

        /// <summary>
        ///     Simulates stopping the tracker.
        /// </summary>
        public void Stop()
        {
            StopCalled = true;
            IsRunning = false;
        }

        /// <summary>
        ///     Simulates resetting the tracker.
        /// </summary>
        public void Reset()
        {
            ResetCalled = true;
            IsRunning = false;
            StartTime = DateTime.MinValue;
            ElapsedTime = TimeSpan.Zero;
        }

        /// <summary>
        ///     Gets the configured elapsed time and marks the method as called.
        /// </summary>
        /// <returns>The configured elapsed time.</returns>
        public TimeSpan GetElapsedTime()
        {
            GetElapsedTimeCalled = true;
            return ElapsedTime;
        }

        /// <summary>
        ///     Gets the configured start time and marks the method as called.
        /// </summary>
        /// <returns>The configured start time.</returns>
        public DateTime GetStartTime()
        {
            GetStartTimeCalled = true;
            return StartTime;
        }

        /// <summary>
        ///     Resets all call tracking flags.
        /// </summary>
        public void ResetCallTracking()
        {
            StartCalled = false;
            StopCalled = false;
            ResetCalled = false;
            GetElapsedTimeCalled = false;
            GetStartTimeCalled = false;
        }
    }
}

