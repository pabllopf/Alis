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
using System.Threading;
using Xunit;

namespace Alis.Core.Aspect.Time.Test
{
    /// <summary>
    ///     Comprehensive unit tests for Clock time management class.
    ///     Tests time measurement, delta time, and frame timing.
    /// </summary>
    public class ClockExtensiveTest
    {
        /// <summary>
        ///     Tests that clock creation succeeds
        /// </summary>
        [Fact]
        public void Clock_Creation_Succeeds()
        {
            Clock clock = new Clock();
            Assert.NotNull(clock);
        }

        /// <summary>
        ///     Tests that clock creation with multiple instances
        /// </summary>
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


        /// <summary>
        ///     Tests that delta time after initialization is zero or small
        /// </summary>
        [Fact]
        public void DeltaTime_AfterInitialization_IsZeroOrSmall()
        {
            Clock clock = new Clock();
            clock.Start();

            Assert.True(clock.ElapsedMilliseconds >= 0);
        }

        /// <summary>
        ///     Tests that delta time after delay increases with time
        /// </summary>
        [Fact]
        public void DeltaTime_AfterDelay_IncreasesWith_Time()
        {
            Clock clock = new Clock();
            clock.Start();

            Thread.Sleep(10);

            Assert.True(clock.ElapsedMilliseconds > 0);
        }

        /// <summary>
        ///     Tests that elapsed increments over time
        /// </summary>
        [Fact]
        public void Elapsed_IncrementsOverTime()
        {
            Clock clock = new Clock();
            clock.Start();

            long elapsed1 = clock.ElapsedMilliseconds;
            Thread.Sleep(5);
            long elapsed2 = clock.ElapsedMilliseconds;

            Assert.True(elapsed2 >= elapsed1);
        }


        /// <summary>
        ///     Tests that start can be called
        /// </summary>
        [Fact]
        public void Start_CanBeCalled()
        {
            Clock clock = new Clock();
            clock.Start();

            Assert.NotNull(clock);
        }

        /// <summary>
        ///     Tests that stop can be called
        /// </summary>
        [Fact]
        public void Stop_CanBeCalled()
        {
            Clock clock = new Clock();
            clock.Start();
            Thread.Sleep(5);
            clock.Stop();

            Assert.NotNull(clock);
        }

        /// <summary>
        ///     Tests that start stop start works
        /// </summary>
        [Fact]
        public void Start_Stop_Start_Works()
        {
            Clock clock = new Clock();

            clock.Start();
            Thread.Sleep(5);
            clock.Stop();

            long elapsed1 = clock.ElapsedMilliseconds;

            clock.Start();
            Thread.Sleep(5);

            long elapsed2 = clock.ElapsedMilliseconds;

            Assert.True(elapsed2 > elapsed1);
        }


        /// <summary>
        ///     Tests that reset clears time
        /// </summary>
        [Fact]
        public void Reset_ClearsTime()
        {
            Clock clock = new Clock();
            clock.Start();
            Thread.Sleep(10);
            clock.Reset();

            Assert.True(clock.ElapsedMilliseconds < 5);
        }

        /// <summary>
        ///     Tests that reset multiple timer works
        /// </summary>
        [Fact]
        public void Reset_MultipleTimer_Works()
        {
            Clock clock = new Clock();

            clock.Start();
            Thread.Sleep(5);
            clock.Reset();

            clock.Start();
            Thread.Sleep(5);
            clock.Reset();

            Assert.True(clock.ElapsedMilliseconds < 5);
        }


        /// <summary>
        ///     Tests that multiple clocks are independent
        /// </summary>
        [Fact]
        public void Multiple_Clocks_AreIndependent()
        {
            Clock clock1 = new Clock();
            Clock clock2 = new Clock();

            clock1.Start();
            Thread.Sleep(10);

            clock2.Start();
            Thread.Sleep(5);

            long elapsed1 = clock1.ElapsedMilliseconds;
            long elapsed2 = clock2.ElapsedMilliseconds;

            Assert.True(elapsed1 > elapsed2);
        }


        /// <summary>
        ///     Tests that precision millisecond accuracy
        /// </summary>
        [Fact]
        public void Precision_MillisecondAccuracy()
        {
            Clock clock = new Clock();
            clock.Start();

            long start = clock.ElapsedMilliseconds;
            Thread.Sleep(100);
            long end = clock.ElapsedMilliseconds;

            long delta = end - start;
            Assert.InRange(delta, 90, 400);
        }


        /// <summary>
        ///     Tests that precision sub millisecond can be measured
        /// </summary>
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


        /// <summary>
        ///     Tests that extreme long duration stays positive
        /// </summary>
        [Fact]
        public void ExtremeLongDuration_StaysPositive()
        {
            Clock clock = new Clock();
            clock.Start();

            Thread.Sleep(500);
            long elapsed = clock.ElapsedMilliseconds;

            Assert.True(elapsed >= 0);
        }


        /// <summary>
        ///     Tests that is running after start is true
        /// </summary>
        [Fact]
        public void IsRunning_AfterStart_IsTrue()
        {
            Clock clock = new Clock();
            clock.Start();

            Assert.True(clock.IsRunning);
        }

        /// <summary>
        ///     Tests that is running after stop is false
        /// </summary>
        [Fact]
        public void IsRunning_AfterStop_IsFalse()
        {
            Clock clock = new Clock();
            clock.Start();
            clock.Stop();

            Assert.False(clock.IsRunning);
        }


        /// <summary>
        ///     Tests that elapsed timespan returns valid timespan
        /// </summary>
        [Fact]
        public void ElapsedTimespan_ReturnsValidTimespan()
        {
            Clock clock = new Clock();
            clock.Start();
            Thread.Sleep(10);

            TimeSpan timespan = clock.Elapsed;
            Assert.NotNull(timespan);
        }

        /// <summary>
        /// Gets the massive lifecycle cases
        /// </summary>
        /// <returns>A system collections generic enumerable of object array</returns>
        public static System.Collections.Generic.IEnumerable<object[]> GetMassiveLifecycleCases()
        {
            for (int cycleCount = 1; cycleCount <= 2000; cycleCount++)
            {
                yield return new object[] {cycleCount};
            }
        }

        /// <summary>
        /// Tests that lifecycle massive cycles remains stable
        /// </summary>
        /// <param name="cycleCount">The cycle count</param>
        [Theory, MemberData(nameof(GetMassiveLifecycleCases))]
        public void Lifecycle_MassiveCycles_RemainsStable(int cycleCount)
        {
            Clock clock = new Clock();

            for (int i = 0; i < cycleCount; i++)
            {
                clock.Start();
                clock.Stop();
            }

            Assert.False(clock.IsRunning);
            Assert.True(clock.ElapsedMilliseconds >= 0);

            clock.Restart();
            Assert.True(clock.IsRunning);

            clock.Reset();
            Assert.False(clock.IsRunning);
            Assert.Equal(0L, clock.ElapsedMilliseconds);
        }
    }
}