// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StopwatchTimeTrackerComprehensiveTest.cs
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
    ///     Comprehensive unit tests for StopwatchTimeTracker class.
    ///     Tests all public members including constructors, start/stop operations,
    ///     elapsed time tracking, and reset functionality.
    /// </summary>
    public class StopwatchTimeTrackerComprehensiveTest
    {
        /// <summary>
        ///     Tests that constructor initializes tracker in stopped state.
        /// </summary>
        [Fact]
        public void Constructor_InitializesTrackerInStoppedState()
        {
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();

            Assert.False(tracker.IsRunning);
            Assert.Equal(TimeSpan.Zero, tracker.GetElapsedTime());
            Assert.Equal(DateTime.MinValue, tracker.GetStartTime());
        }

        /// <summary>
        ///     Tests that Start method sets IsRunning to true.
        /// </summary>
        [Fact]
        public void Start_SetsIsRunningToTrue()
        {
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();

            tracker.Start();

            Assert.True(tracker.IsRunning);
        }

        /// <summary>
        ///     Tests that Start method records the start time.
        /// </summary>
        [Fact]
        public void Start_RecordsStartTime()
        {
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();
            DateTime beforeStart = DateTime.Now;

            tracker.Start();
            DateTime afterStart = DateTime.Now;

            DateTime startTime = tracker.GetStartTime();
            Assert.True(startTime >= beforeStart);
            Assert.True(startTime <= afterStart);
        }

        /// <summary>
        ///     Tests that Stop method sets IsRunning to false.
        /// </summary>
        [Fact]
        public void Stop_SetsIsRunningToFalse()
        {
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();
            tracker.Start();

            tracker.Stop();

            Assert.False(tracker.IsRunning);
        }

        /// <summary>
        ///     Tests that Stop method has no effect if not running.
        /// </summary>
        [Fact]
        public void Stop_HasNoEffect_IfNotRunning()
        {
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();

            tracker.Stop();
            Assert.False(tracker.IsRunning);
        }

        /// <summary>
        ///     Tests that GetElapsedTime returns approximately zero initially.
        /// </summary>
        [Fact]
        public void GetElapsedTime_ReturnsZero_Initially()
        {
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();

            TimeSpan elapsed = tracker.GetElapsedTime();

            Assert.Equal(TimeSpan.Zero, elapsed);
        }

        /// <summary>
        ///     Tests that GetElapsedTime increases after Start.
        /// </summary>
        [Fact]
        public void GetElapsedTime_IncreasesAfterStart()
        {
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();
            tracker.Start();
            TimeSpan elapsed1 = tracker.GetElapsedTime();

            Thread.Sleep(50);
            TimeSpan elapsed2 = tracker.GetElapsedTime();

            Assert.True(elapsed2 > elapsed1);
        }

        /// <summary>
        ///     Tests that GetElapsedTime stops increasing after Stop.
        /// </summary>
        [Fact]
        public void GetElapsedTime_StopsIncreasing_AfterStop()
        {
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();
            tracker.Start();
            Thread.Sleep(50);
            tracker.Stop();
            TimeSpan elapsedAfterStop = tracker.GetElapsedTime();

            Thread.Sleep(50);
            TimeSpan elapsedAfterWait = tracker.GetElapsedTime();

            Assert.Equal(elapsedAfterStop, elapsedAfterWait);
        }

        /// <summary>
        ///     Tests that Reset clears all tracking data.
        /// </summary>
        [Fact]
        public void Reset_ClearsAllTrackingData()
        {
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();
            tracker.Start();
            Thread.Sleep(50);
            tracker.Stop();

            tracker.Reset();

            Assert.False(tracker.IsRunning);
            Assert.Equal(TimeSpan.Zero, tracker.GetElapsedTime());
            Assert.Equal(DateTime.MinValue, tracker.GetStartTime());
        }

        /// <summary>
        ///     Tests that Start can be called multiple times (restarts tracking).
        /// </summary>
        [Fact]
        public void Start_CanBeCalledMultipleTimes()
        {
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();

            tracker.Start();
            Thread.Sleep(50);
            DateTime firstStartTime = tracker.GetStartTime();
            TimeSpan firstElapsed = tracker.GetElapsedTime();

            tracker.Start();
            DateTime secondStartTime = tracker.GetStartTime();
            TimeSpan secondElapsed = tracker.GetElapsedTime();

            Assert.NotEqual(firstStartTime, secondStartTime);
            Assert.True(secondElapsed < firstElapsed);
        }

        /// <summary>
        ///     Tests that GetStartTime returns DateTime.MinValue before Start.
        /// </summary>
        [Fact]
        public void GetStartTime_ReturnsMinValue_BeforeStart()
        {
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();

            DateTime startTime = tracker.GetStartTime();

            Assert.Equal(DateTime.MinValue, startTime);
        }

        /// <summary>
        ///     Tests that IsRunning property reflects accurate state.
        /// </summary>
        [Fact]
        public void IsRunning_ReflectsAccurateState()
        {
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();

            Assert.False(tracker.IsRunning);

            tracker.Start();
            Assert.True(tracker.IsRunning);

            tracker.Stop();
            Assert.False(tracker.IsRunning);

            tracker.Reset();
            Assert.False(tracker.IsRunning);
        }
        
        /// <summary>
        ///     Tests concurrent Start and Stop operations.
        /// </summary>
        [Fact]
        public void StartStop_WorkCorrectlyInSequence()
        {
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();

            tracker.Start();
            Assert.True(tracker.IsRunning);

            tracker.Stop();
            Assert.False(tracker.IsRunning);

            TimeSpan firstElapsed = tracker.GetElapsedTime();

            Thread.Sleep(10);
            tracker.Start();
            Assert.True(tracker.IsRunning);

            Thread.Sleep(10);
            tracker.Stop();
            Assert.False(tracker.IsRunning);

            TimeSpan secondElapsed = tracker.GetElapsedTime();
            Assert.True(secondElapsed >= firstElapsed);
        }

        /// <summary>
        ///     Tests that Reset works while tracker is running.
        /// </summary>
        [Fact]
        public void Reset_WorksWhileRunning()
        {
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();
            tracker.Start();
            Thread.Sleep(50);

            tracker.Reset();

            Assert.False(tracker.IsRunning);
            Assert.Equal(TimeSpan.Zero, tracker.GetElapsedTime());
        }

        /// <summary>
        ///     Tests that GetElapsedTime precision is sufficient.
        /// </summary>
        [Fact]
        public void GetElapsedTime_HasSufficientPrecision()
        {
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();

            tracker.Start();
            Thread.Sleep(100);
            tracker.Stop();
            TimeSpan elapsed = tracker.GetElapsedTime();

            Assert.True(elapsed.TotalMilliseconds >= 90); // Allow for timing variation
        }

        /// <summary>
        ///     Tests that multiple tracker instances are independent.
        /// </summary>
        [Fact]
        public void MultipleTrackers_AreIndependent()
        {
            StopwatchTimeTracker tracker1 = new StopwatchTimeTracker();
            StopwatchTimeTracker tracker2 = new StopwatchTimeTracker();

            tracker1.Start();
            Thread.Sleep(1);
            tracker1.Stop();

            tracker2.Start();
            Thread.Sleep(100);
            tracker2.Stop();

            TimeSpan elapsed1 = tracker1.GetElapsedTime();
            TimeSpan elapsed2 = tracker2.GetElapsedTime();

            Assert.True(elapsed2 > elapsed1);
        }

        /// <summary>
        ///     Tests repeated Reset cycles.
        /// </summary>
        [Fact]
        public void RepeatedResetCycles_WorkCorrectly()
        {
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();

            for (int i = 0; i < 3; i++)
            {
                tracker.Start();
                Assert.True(tracker.IsRunning);
                Thread.Sleep(10);
                tracker.Stop();
                Assert.False(tracker.IsRunning);
                tracker.Reset();
                Assert.Equal(TimeSpan.Zero, tracker.GetElapsedTime());
                Assert.Equal(DateTime.MinValue, tracker.GetStartTime());
            }
        }

        /// <summary>
        ///     Tests that GetStartTime accuracy after Start.
        /// </summary>
        [Fact]
        public void GetStartTime_IsAccurateAfterStart()
        {
            StopwatchTimeTracker tracker = new StopwatchTimeTracker();
            DateTime beforeStart = DateTime.Now;

            tracker.Start();
            DateTime recordedStartTime = tracker.GetStartTime();
            DateTime afterStart = DateTime.Now;

            Assert.True(recordedStartTime >= beforeStart);
            Assert.True(recordedStartTime <= afterStart);
        }
    }
}



