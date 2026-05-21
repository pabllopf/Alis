// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ClockTest.cs
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
using Xunit;

namespace Alis.Core.Aspect.Time.Test
{
    /// <summary>
    ///     The clock test class
    /// </summary>
    public class ClockTest
    {
        /// <summary>
        ///     Tests that start should start stopwatch
        /// </summary>
        [Fact]
        public void Start_ShouldStartStopwatch()
        {
            Clock clock = new Clock();

            clock.Start();

            Assert.True(clock.ElapsedMilliseconds >= 0);
        }

        /// <summary>
        ///     Tests that stop should stop stopwatch
        /// </summary>
        [Fact]
        public void Stop_ShouldStopStopwatch()
        {
            Clock clock = new Clock();

            clock.Start();
            clock.Stop();

            Assert.True(clock.ElapsedMilliseconds >= 0);
        }

        /// <summary>
        ///     Tests that reset should reset stopwatch
        /// </summary>
        [Fact]
        public void Reset_ShouldResetStopwatch()
        {
            Clock clock = new Clock();

            clock.Start();
            clock.Reset();

            Assert.True(clock.ElapsedMilliseconds == 0);
        }

        /// <summary>
        ///     Tests that elapsed should return elapsed time
        /// </summary>
        [Fact]
        public void Elapsed_ShouldReturnElapsedTime()
        {
            Clock clock = new Clock();

            clock.Start();
            Thread.Sleep(1000); // Sleep for 1 second
            clock.Stop();

            Assert.True(clock.Elapsed.TotalSeconds >= 1);
        }

        /// <summary>
        ///     Tests that elapsed milliseconds should return elapsed milliseconds
        /// </summary>
        [Fact]
        public void ElapsedMilliseconds_ShouldReturnElapsedMilliseconds()
        {
            Clock clock = new Clock();

            clock.Start();
            Thread.Sleep(1000); // Sleep for 1 second
            clock.Stop();

            Assert.True(clock.ElapsedMilliseconds >= 1000);
        }

        /// <summary>
        ///     Tests that elapsed ticks should return elapsed ticks
        /// </summary>
        [Fact]
        public void ElapsedTicks_ShouldReturnElapsedTicks()
        {
            Clock clock = new Clock();

            clock.Start();
            Thread.Sleep(1000); // Sleep for 1 second
            clock.Stop();

            Assert.True(clock.ElapsedTicks >= TimeSpan.TicksPerSecond);
        }

        /// <summary>
        ///     Tests that elapsed seconds should return elapsed seconds
        /// </summary>
        [Fact]
        public void ElapsedSeconds_ShouldReturnElapsedSeconds()
        {
            Clock clock = new Clock();

            clock.Start();
            Thread.Sleep(1000); // Sleep for 1 second
            clock.Stop();

            Assert.True(clock.ElapsedSeconds >= 1);
        }

        /// <summary>
        ///     Tests that constructor should initialize clock in reset state
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeClockInResetState()
        {
            Clock clock = new Clock();

            Assert.False(clock.IsRunning);
            Assert.Equal(0, clock.ElapsedMilliseconds);
            Assert.Equal(TimeSpan.Zero, clock.Elapsed);
        }

        /// <summary>
        ///     Tests that is running should return false when clock is not running
        /// </summary>
        [Fact]
        public void IsRunning_ShouldReturnFalseWhenClockIsNotRunning()
        {
            Clock clock = new Clock();

            Assert.False(clock.IsRunning);
        }

        /// <summary>
        ///     Tests that is running should return true when clock is running
        /// </summary>
        [Fact]
        public void IsRunning_ShouldReturnTrueWhenClockIsRunning()
        {
            Clock clock = new Clock();

            clock.Start();

            Assert.True(clock.IsRunning);
        }

        /// <summary>
        ///     Tests that create should return a running clock instance
        /// </summary>
        [Fact]
        public void Create_ShouldReturnRunningClockInstance()
        {
            Clock clock = Clock.Create();

            Assert.NotNull(clock);
            Assert.True(clock.IsRunning);
            Assert.True(clock.ElapsedMilliseconds >= 0);
        }

        /// <summary>
        ///     Tests that restart should reset and start the clock
        /// </summary>
        [Fact]
        public void Restart_ShouldResetAndStartClock()
        {
            Clock clock = new Clock();
            clock.Start();
            Thread.Sleep(500);
            clock.Stop();
            long elapsedBefore = clock.ElapsedMilliseconds;

            clock.Restart();

            Assert.True(clock.IsRunning);
            Assert.True(clock.ElapsedMilliseconds < elapsedBefore);
        }

        /// <summary>
        ///     Tests that to string should return elapsed time as string
        /// </summary>
        [Fact]
        public void ToString_ShouldReturnElapsedTimeAsString()
        {
            Clock clock = new Clock();
            clock.Start();
            Thread.Sleep(100);
            clock.Stop();

            string result = clock.ToString();

            Assert.NotEmpty(result);
            Assert.NotEqual("00:00:00", result);
        }

        /// <summary>
        ///     Tests that start on running clock should be no-op
        /// </summary>
        [Fact]
        public void Start_OnRunningClock_ShouldBeNoOp()
        {
            Clock clock = new Clock();
            clock.Start();
            Thread.Sleep(100);
            long elapsedFirst = clock.ElapsedMilliseconds;

            clock.Start(); // Call start again
            Thread.Sleep(100);
            long elapsedSecond = clock.ElapsedMilliseconds;

            Assert.True(clock.IsRunning);
            Assert.True(elapsedSecond > elapsedFirst);
        }

        /// <summary>
        ///     Tests that stop on stopped clock should be no-op
        /// </summary>
        [Fact]
        public void Stop_OnStoppedClock_ShouldBeNoOp()
        {
            Clock clock = new Clock();
            clock.Start();
            Thread.Sleep(100);
            clock.Stop();
            long elapsedFirst = clock.ElapsedMilliseconds;

            clock.Stop(); // Call stop again
            long elapsedSecond = clock.ElapsedMilliseconds;

            Assert.False(clock.IsRunning);
            Assert.Equal(elapsedFirst, elapsedSecond);
        }

        /// <summary>
        ///     Tests that elapsed property should update while clock is running
        /// </summary>
        [Fact]
        public void Elapsed_ShouldUpdateWhileClockIsRunning()
        {
            Clock clock = new Clock();
            clock.Start();

            TimeSpan elapsedFirst = clock.Elapsed;
            Thread.Sleep(100);
            TimeSpan elapsedSecond = clock.Elapsed;

            Assert.True(elapsedSecond > elapsedFirst);
        }

        /// <summary>
        ///     Tests that elapsed property should not update while clock is stopped
        /// </summary>
        [Fact]
        public void Elapsed_ShouldNotUpdateWhileClockIsStopped()
        {
            Clock clock = new Clock();
            clock.Start();
            Thread.Sleep(100);
            clock.Stop();
            TimeSpan elapsedFirst = clock.Elapsed;

            Thread.Sleep(100);
            TimeSpan elapsedSecond = clock.Elapsed;

            Assert.Equal(elapsedFirst, elapsedSecond);
        }

        /// <summary>
        ///     Tests that multiple start stop cycles should accumulate elapsed time
        /// </summary>
        [Fact]
        public void MultipleCycles_ShouldAccumulateElapsedTime()
        {
            Clock clock = new Clock();

            clock.Start();
            Thread.Sleep(200);
            clock.Stop();
            long elapsedAfterFirstCycle = clock.ElapsedMilliseconds;

            clock.Start();
            Thread.Sleep(200);
            clock.Stop();
            long elapsedAfterSecondCycle = clock.ElapsedMilliseconds;

            Assert.True(elapsedAfterSecondCycle > elapsedAfterFirstCycle);
            Assert.True(elapsedAfterSecondCycle >= 400);
        }

        /// <summary>
        ///     Tests that reset should clear elapsed time
        /// </summary>
        [Fact]
        public void Reset_ShouldClearElapsedTime()
        {
            Clock clock = new Clock();
            clock.Start();
            Thread.Sleep(100);
            clock.Stop();

            clock.Reset();

            Assert.False(clock.IsRunning);
            Assert.Equal(0, clock.ElapsedMilliseconds);
            Assert.Equal(0, clock.ElapsedSeconds);
            Assert.Equal(0, clock.ElapsedTicks);
        }

        /// <summary>
        ///     Tests that elapsed milliseconds should be zero for new clock
        /// </summary>
        [Fact]
        public void ElapsedMilliseconds_ShouldBeZeroForNewClock()
        {
            Clock clock = new Clock();

            Assert.Equal(0, clock.ElapsedMilliseconds);
        }

        /// <summary>
        ///     Tests that elapsed ticks should be zero for new clock
        /// </summary>
        [Fact]
        public void ElapsedTicks_ShouldBeZeroForNewClock()
        {
            Clock clock = new Clock();

            Assert.Equal(0, clock.ElapsedTicks);
        }
    }
}