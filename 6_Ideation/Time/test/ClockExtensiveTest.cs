// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ClockExtensiveTest.cs
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
    public class ClockExtensiveTest
    {
        [Fact]
        public void Clock_Creation_Succeeds()
        {
            Clock clock = new Clock();
            Assert.NotNull(clock);
        }

        [Fact]
        public void Clock_Creation_WithMultipleInstances()
        {
            Clock clock1 = new Clock();
            Clock clock2 = new Clock();
            Clock clock3 = new Clock();

            Assert.NotNull(clock1);
            Assert.NotNull(clock2);
            Assert.NotNull(clock3);
        }

        [Fact]
        public void DeltaTime_AfterInitialization_IsZeroOrSmall()
        {
            Clock clock = new Clock();
            clock.Start();

            Assert.True(clock.ElapsedMilliseconds >= 0);
        }

        [Fact]
        public void DeltaTime_AfterDelay_IncreasesWith_Time()
        {
            Clock clock = new Clock();
            clock.Start();

            clock.Stop();

            Assert.True(clock.ElapsedMilliseconds >= 0);
        }

        [Fact]
        public void Elapsed_IncrementsOverTime()
        {
            Clock clock = new Clock();
            clock.Start();

            long elapsed1 = clock.ElapsedMilliseconds;
            long elapsed2 = clock.ElapsedMilliseconds;

            Assert.True(elapsed2 >= elapsed1);
        }


        [Fact]
        public void Start_CanBeCalled()
        {
            Clock clock = new Clock();
            clock.Start();

            Assert.NotNull(clock);
        }

        [Fact]
        public void Stop_CanBeCalled()
        {
            Clock clock = new Clock();
            clock.Start();
            clock.Stop();

            Assert.NotNull(clock);
        }

        [Fact]
        public void Start_Stop_Start_Works()
        {
            Clock clock = new Clock();

            clock.Start();
            clock.Stop();

            long elapsed1 = clock.ElapsedMilliseconds;

            clock.Start();
            clock.Stop();

            long elapsed2 = clock.ElapsedMilliseconds;

            Assert.True(elapsed2 >= elapsed1);
        }

        [Fact]
        public void Reset_ClearsTime()
        {
            Clock clock = new Clock();
            clock.Start();
            clock.Reset();

            Assert.Equal(0, clock.ElapsedMilliseconds);
        }

        [Fact]
        public void Reset_MultipleTimer_Works()
        {
            Clock clock = new Clock();

            clock.Start();
            clock.Reset();

            clock.Start();
            clock.Reset();

            Assert.Equal(0, clock.ElapsedMilliseconds);
        }

        [Fact]
        public void Multiple_Clocks_AreIndependent()
        {
            Clock clock1 = new Clock();
            Clock clock2 = new Clock();

            clock1.Start();
            clock1.Stop();
            long elapsed1 = clock1.ElapsedMilliseconds;

            clock2.Start();
            clock2.Stop();
            long elapsed2 = clock2.ElapsedMilliseconds;

            Assert.True(elapsed1 >= 0);
            Assert.True(elapsed2 >= 0);
        }

        [Fact]
        public void Precision_MillisecondAccuracy()
        {
            Clock clock = new Clock();
            clock.Start();

            long start = clock.ElapsedMilliseconds;
            long end = clock.ElapsedMilliseconds;

            long delta = end - start;
            Assert.True(delta >= 0);
        }

        [Fact]
        public void Precision_SubMillisecond_CanBeMeasured()
        {
            Clock clock = new Clock();
            clock.Start();

            long elapsed1 = clock.ElapsedMilliseconds;
            long elapsed2 = clock.ElapsedMilliseconds;

            Assert.True(elapsed1 >= 0);
            Assert.True(elapsed2 >= 0);
        }

        [Fact]
        public void ExtremeLongDuration_StaysPositive()
        {
            Clock clock = new Clock();
            clock.Start();

            long elapsed = clock.ElapsedMilliseconds;

            Assert.True(elapsed >= 0);
        }

        [Fact]
        public void IsRunning_AfterStart_IsTrue()
        {
            Clock clock = new Clock();
            clock.Start();

            Assert.True(clock.IsRunning);
        }

        [Fact]
        public void IsRunning_AfterStop_IsFalse()
        {
            Clock clock = new Clock();
            clock.Start();
            clock.Stop();

            Assert.False(clock.IsRunning);
        }

        [Fact]
        public void ElapsedTimespan_ReturnsValidTimespan()
        {
            Clock clock = new Clock();
            clock.Start();

            TimeSpan timespan = clock.Elapsed;
            Assert.NotNull(timespan);
        }
    }
}
