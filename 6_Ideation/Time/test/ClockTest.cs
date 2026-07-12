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
using Xunit;

namespace Alis.Core.Aspect.Time.Test
{
    public class ClockTest
    {
        [Fact]
        public void Start_ShouldStartStopwatch()
        {
            Clock clock = new Clock();

            clock.Start();

            Assert.True(clock.ElapsedMilliseconds >= 0);
        }

        [Fact]
        public void Stop_ShouldStopStopwatch()
        {
            Clock clock = new Clock();

            clock.Start();
            clock.Stop();

            Assert.True(clock.ElapsedMilliseconds >= 0);
        }

        [Fact]
        public void Reset_ShouldResetStopwatch()
        {
            Clock clock = new Clock();

            clock.Start();
            clock.Reset();

            Assert.True(clock.ElapsedMilliseconds == 0);
        }

        [Fact]
        public void Elapsed_ShouldReturnElapsedTime()
        {
            Clock clock = new Clock();

            clock.Start();
            clock.Stop();

            Assert.True(clock.Elapsed.TotalSeconds >= 0);
        }

        [Fact]
        public void ElapsedMilliseconds_ShouldReturnElapsedMilliseconds()
        {
            Clock clock = new Clock();

            clock.Start();
            clock.Stop();

            Assert.True(clock.ElapsedMilliseconds >= 0);
        }

        [Fact]
        public void ElapsedTicks_ShouldReturnElapsedTicks()
        {
            Clock clock = new Clock();

            clock.Start();
            clock.Stop();

            Assert.True(clock.ElapsedTicks >= 0);
        }

        [Fact]
        public void ElapsedSeconds_ShouldReturnElapsedSeconds()
        {
            Clock clock = new Clock();

            clock.Start();
            clock.Stop();

            Assert.True(clock.ElapsedSeconds >= 0);
        }

        [Fact]
        public void Constructor_ShouldInitializeClockInResetState()
        {
            Clock clock = new Clock();

            Assert.False(clock.IsRunning);
            Assert.Equal(0, clock.ElapsedMilliseconds);
            Assert.Equal(TimeSpan.Zero, clock.Elapsed);
        }

        [Fact]
        public void IsRunning_ShouldReturnFalseWhenClockIsNotRunning()
        {
            Clock clock = new Clock();

            Assert.False(clock.IsRunning);
        }

        [Fact]
        public void IsRunning_ShouldReturnTrueWhenClockIsRunning()
        {
            Clock clock = new Clock();

            clock.Start();

            Assert.True(clock.IsRunning);
        }

        [Fact]
        public void Create_ShouldReturnRunningClockInstance()
        {
            Clock clock = Clock.Create();

            Assert.NotNull(clock);
            Assert.True(clock.IsRunning);
            Assert.True(clock.ElapsedMilliseconds >= 0);
        }

        [Fact]
        public void Restart_ShouldResetAndStartClock()
        {
            Clock clock = new Clock();
            clock.Start();
            clock.Stop();
            long elapsedBefore = clock.ElapsedMilliseconds;

            clock.Restart();

            Assert.True(clock.IsRunning);
            Assert.True(clock.ElapsedMilliseconds <= elapsedBefore);
        }

        [Fact]
        public void ToString_ShouldReturnElapsedTimeAsString()
        {
            Clock clock = new Clock();
            clock.Start();
            clock.Stop();

            string result = clock.ToString();

            Assert.NotEmpty(result);
        }

        [Fact]
        public void Start_OnRunningClock_ShouldBeNoOp()
        {
            Clock clock = new Clock();
            clock.Start();
            long elapsedFirst = clock.ElapsedMilliseconds;

            clock.Start();
            long elapsedSecond = clock.ElapsedMilliseconds;

            Assert.True(clock.IsRunning);
            Assert.True(elapsedSecond >= elapsedFirst);
        }

        [Fact]
        public void Stop_OnStoppedClock_ShouldBeNoOp()
        {
            Clock clock = new Clock();
            clock.Start();
            clock.Stop();
            long elapsedFirst = clock.ElapsedMilliseconds;

            clock.Stop();
            long elapsedSecond = clock.ElapsedMilliseconds;

            Assert.False(clock.IsRunning);
            Assert.Equal(elapsedFirst, elapsedSecond);
        }

        [Fact]
        public void Elapsed_ShouldUpdateWhileClockIsRunning()
        {
            Clock clock = new Clock();
            clock.Start();

            TimeSpan elapsedFirst = clock.Elapsed;
            long startTicks = DateTime.UtcNow.Ticks;
            while (clock.Elapsed.Ticks == elapsedFirst.Ticks && DateTime.UtcNow.Ticks - startTicks < TimeSpan.TicksPerMillisecond * 10)
            {
            }

            TimeSpan elapsedSecond = clock.Elapsed;

            Assert.True(elapsedSecond >= elapsedFirst);
        }

        [Fact]
        public void Elapsed_ShouldNotUpdateWhileClockIsStopped()
        {
            Clock clock = new Clock();
            clock.Start();
            clock.Stop();
            TimeSpan elapsedFirst = clock.Elapsed;

            TimeSpan elapsedSecond = clock.Elapsed;

            Assert.Equal(elapsedFirst, elapsedSecond);
        }

        [Fact]
        public void MultipleCycles_ShouldAccumulateElapsedTime()
        {
            Clock clock = new Clock();

            clock.Start();
            clock.Stop();
            long elapsedAfterFirstCycle = clock.ElapsedMilliseconds;

            clock.Start();
            clock.Stop();
            long elapsedAfterSecondCycle = clock.ElapsedMilliseconds;

            Assert.True(elapsedAfterSecondCycle >= elapsedAfterFirstCycle);
        }

        [Fact]
        public void Reset_ShouldClearElapsedTime()
        {
            Clock clock = new Clock();
            clock.Start();
            clock.Stop();

            clock.Reset();

            Assert.False(clock.IsRunning);
            Assert.Equal(0, clock.ElapsedMilliseconds);
            Assert.Equal(0, clock.ElapsedSeconds);
            Assert.Equal(0, clock.ElapsedTicks);
        }

        [Fact]
        public void ElapsedMilliseconds_ShouldBeZeroForNewClock()
        {
            Clock clock = new Clock();

            Assert.Equal(0, clock.ElapsedMilliseconds);
        }

        [Fact]
        public void ElapsedTicks_ShouldBeZeroForNewClock()
        {
            Clock clock = new Clock();

            Assert.Equal(0, clock.ElapsedTicks);
        }
    }
}
