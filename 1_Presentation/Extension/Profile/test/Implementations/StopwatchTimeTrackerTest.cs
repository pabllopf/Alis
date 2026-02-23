// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StopwatchTimeTrackerTest.cs
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
using System.Threading;
using Alis.Extension.Profile.Implementations;
using Xunit;

namespace Alis.Extension.Profile.Test.Implementations
{
    /// <summary>
    ///     The stopwatch time tracker test class
    /// </summary>
    public class StopwatchTimeTrackerTest
    {
        /// <summary>
        ///     Tests that constructor initializes tracker correctly
        /// </summary>
        [Fact]
        public void Constructor_InitializesTracker_Correctly()
        {
            // Act
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();

            // Assert
            Assert.False(tracker.IsRunning);
            Assert.Equal(DateTime.MinValue, tracker.GetStartTime());
            Assert.Equal(TimeSpan.Zero, tracker.GetElapsedTime());
        }

        /// <summary>
        ///     Tests that start begins tracking
        /// </summary>
        [Fact]
        public void Start_BeginsTracking()
        {
            // Arrange
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();

            // Act
            tracker.Start();

            // Assert
            Assert.True(tracker.IsRunning);
            Assert.NotEqual(DateTime.MinValue, tracker.GetStartTime());
        }

        /// <summary>
        ///     Tests that start sets start time to current time
        /// </summary>
        [Fact]
        public void Start_SetsStartTime_ToCurrentTime()
        {
            // Arrange
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();
            DateTime beforeStart = DateTime.Now;

            // Act
            tracker.Start();

            // Assert
            DateTime afterStart = DateTime.Now;
            Assert.True(tracker.GetStartTime() >= beforeStart);
            Assert.True(tracker.GetStartTime() <= afterStart);
        }

        /// <summary>
        ///     Tests that stop ends tracking
        /// </summary>
        [Fact]
        public void Stop_EndsTracking()
        {
            // Arrange
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();
            tracker.Start();

            // Act
            tracker.Stop();

            // Assert
            Assert.False(tracker.IsRunning);
        }

        /// <summary>
        ///     Tests that stop does nothing when not running
        /// </summary>
        [Fact]
        public void Stop_DoesNothing_WhenNotRunning()
        {
            // Arrange
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();

            // Act
            tracker.Stop(); // Should not throw

            // Assert
            Assert.False(tracker.IsRunning);
        }
        
        /// <summary>
        ///     Tests that reset clears all tracking data
        /// </summary>
        [Fact]
        public void Reset_ClearsAllTrackingData()
        {
            // Arrange
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();
            tracker.Start();
            Thread.Sleep(50);
            tracker.Stop();

            // Act
            tracker.Reset();

            // Assert
            Assert.False(tracker.IsRunning);
            Assert.Equal(DateTime.MinValue, tracker.GetStartTime());
            Assert.Equal(TimeSpan.Zero, tracker.GetElapsedTime());
        }

        /// <summary>
        ///     Tests that start restarts tracking when already running
        /// </summary>
        [Fact]
        public void Start_RestartsTracking_WhenAlreadyRunning()
        {
            // Arrange
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();
            tracker.Start();
            Thread.Sleep(50);
            TimeSpan firstElapsed = tracker.GetElapsedTime();

            // Act
            tracker.Start(); // Restart
            TimeSpan secondElapsed = tracker.GetElapsedTime();

            // Assert
            Assert.True(tracker.IsRunning);
            Assert.True(secondElapsed < firstElapsed); // Should be reset
        }

        /// <summary>
        ///     Tests that get elapsed time returns zero before starting
        /// </summary>
        [Fact]
        public void GetElapsedTime_ReturnsZero_BeforeStarting()
        {
            // Arrange
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();

            // Act
            TimeSpan elapsed = tracker.GetElapsedTime();

            // Assert
            Assert.Equal(TimeSpan.Zero, elapsed);
        }

        /// <summary>
        ///     Tests that get start time returns min value before starting
        /// </summary>
        [Fact]
        public void GetStartTime_ReturnsMinValue_BeforeStarting()
        {
            // Arrange
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();

            // Act
            DateTime startTime = tracker.GetStartTime();

            // Assert
            Assert.Equal(DateTime.MinValue, startTime);
        }

        /// <summary>
        ///     Tests that elapsed time continues while running
        /// </summary>
        [Fact]
        public void ElapsedTime_ContinuesWhileRunning()
        {
            // Arrange
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();
            tracker.Start();
            Thread.Sleep(50);

            // Act
            TimeSpan firstElapsed = tracker.GetElapsedTime();
            Thread.Sleep(50);
            TimeSpan secondElapsed = tracker.GetElapsedTime();

            // Assert
            Assert.True(secondElapsed > firstElapsed);
        }

        /// <summary>
        ///     Tests that elapsed time does not change after stopping
        /// </summary>
        [Fact]
        public void ElapsedTime_DoesNotChange_AfterStopping()
        {
            // Arrange
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();
            tracker.Start();
            Thread.Sleep(50);
            tracker.Stop();

            // Act
            TimeSpan firstElapsed = tracker.GetElapsedTime();
            Thread.Sleep(50);
            TimeSpan secondElapsed = tracker.GetElapsedTime();

            // Assert
            Assert.Equal(firstElapsed, secondElapsed);
        }
    }
}

