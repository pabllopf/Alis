// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ProfilerTest.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using Xunit;

namespace Alis.Extension.Profile.Test
{
    /// <summary>
    ///     The profiler test class
    /// </summary>
    	  
	 public class ProfilerTest 
    {
        /// <summary>
        ///     Tests that start profiling sets start time
        /// </summary>
        [Fact]
        public void StartProfiling_SetsStartTime()
        {
            Profiler profiler = new Profiler();
            profiler.StartProfiling();
            Assert.True(profiler.GetStartTime() != DateTime.MinValue);
        }

        /// <summary>
        ///     Tests that stop profiling sets elapsed time
        /// </summary>
        [Fact]
        public void StopProfiling_SetsElapsedTime()
        {
            Profiler profiler = new Profiler();
            profiler.StartProfiling();
            Thread.Sleep(1000); // Sleep for 1 second to ensure elapsed time is measurable
            profiler.StopProfiling();
            Assert.True(profiler.GetElapsedTime().TotalMilliseconds >= 1);
        }

        /// <summary>
        ///     Tests that get elapsed time returns correct duration
        /// </summary>
        [Fact]
        public void GetElapsedTime_ReturnsCorrectDuration()
        {
            Profiler profiler = new Profiler();
            profiler.StartProfiling();
            Thread.Sleep(1500); // Sleep for 1.5 seconds
            profiler.StopProfiling();
            TimeSpan elapsedTime = profiler.GetElapsedTime();
            Assert.True(elapsedTime.TotalMilliseconds >= 1);
        }

        /// <summary>
        ///     Tests that start profiling sets start time to current time
        /// </summary>
        [Fact]
        public void StartProfiling_SetsStartTimeToCurrentTime()
        {
            Profiler profiler = new Profiler();
            DateTime beforeStart = DateTime.Now;

            profiler.StartProfiling();

            DateTime afterStart = DateTime.Now;
            Assert.True((profiler.GetStartTime() >= beforeStart) && (profiler.GetStartTime() <= afterStart));
        }

        /// <summary>
        ///     Tests that stop profiling sets elapsed time correctly
        /// </summary>
        [Fact]
        public void StopProfiling_SetsElapsedTimeCorrectly()
        {
            Profiler profiler = new Profiler();
            profiler.StartProfiling();
            Thread.Sleep(100); // Sleep to ensure a measurable elapsed time

            profiler.StopProfiling();

            Assert.True(profiler.GetElapsedTime().TotalMilliseconds >= 1);
        }

        /// <summary>
        ///     Tests that get elapsed time returns zero before profiling starts
        /// </summary>
        [Fact]
        public void GetElapsedTime_ReturnsZeroBeforeProfilingStarts()
        {
            Profiler profiler = new Profiler();

            Assert.Equal(TimeSpan.Zero, profiler.GetElapsedTime());
        }

        /// <summary>
        ///     Tests that get elapsed time after stop profiling returns non zero
        /// </summary>
        [Fact]
        public void GetElapsedTime_AfterStopProfiling_ReturnsNonZero()
        {
            Profiler profiler = new Profiler();
            profiler.StartProfiling();
            Thread.Sleep(100); // Sleep to ensure a measurable elapsed time
            profiler.StopProfiling();

            Assert.True(profiler.GetElapsedTime().TotalMilliseconds > 0);
        }

        /// <summary>
        ///     Tests that get start time before start profiling returns date time min value
        /// </summary>
        [Fact]
        public void GetStartTime_BeforeStartProfiling_ReturnsDateTimeMinValue()
        {
            Profiler profiler = new Profiler();

            Assert.Equal(DateTime.MinValue, profiler.GetStartTime());
        }

        /// <summary>
        ///     Tests that get start time after start profiling returns start time
        /// </summary>
        [Fact]
        public void GetStartTime_AfterStartProfiling_ReturnsStartTime()
        {
            Profiler profiler = new Profiler();
            profiler.StartProfiling();

            Assert.NotEqual(DateTime.MinValue, profiler.GetStartTime());
        }
    }
}