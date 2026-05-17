// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TimeManagerTest.cs
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

using Alis.Core.Aspect.Time;
using Alis.Core.Ecs.Systems.Configuration.Time;
using Alis.Core.Ecs.Systems.Manager.Time;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    ///     Tests for TimeManager constructor, properties, and time-related behavior
    /// </summary>
    public class TimeManagerTest
    {
        /// <summary>
        ///     Tests that constructor creates Clock and starts it
        /// </summary>
        [Fact]
        public void TimeManager_Constructor_ShouldCreateAndStartClock()
        {
            Context context = new Context();
            TimeManager timeManager = context.TimeManager;

            Assert.NotNull(timeManager.Clock);
            Assert.True(timeManager.Clock.IsRunning);
        }

        /// <summary>
        ///     Tests that constructor sets MillisecondsInSecond to 1000
        /// </summary>
        [Fact]
        public void TimeManager_Constructor_ShouldSetMillisecondsInSecondTo1000()
        {
            Context context = new Context();
            TimeManager timeManager = context.TimeManager;

            Assert.Equal(1000, timeManager.MillisecondsInSecond);
        }

        /// <summary>
        ///     Tests that constructor sets OneSecond to 1.0
        /// </summary>
        [Fact]
        public void TimeManager_Constructor_ShouldSetOneSecondTo1_0()
        {
            Context context = new Context();
            TimeManager timeManager = context.TimeManager;

            Assert.Equal(1.0, timeManager.OneSecond);
        }

        /// <summary>
        ///     Tests that default Setting has expected FixedTimeStep
        /// </summary>
        [Fact]
        public void TimeManager_DefaultSetting_ShouldHaveExpectedFixedTimeStep()
        {
            Context context = new Context();
            TimeManager timeManager = context.TimeManager;

            Assert.Equal(0.016f, timeManager.Setting.FixedTimeStep);
        }

        /// <summary>
        ///     Tests that TimeScale defaults to 1f
        /// </summary>
        [Fact]
        public void TimeManager_TimeScale_ShouldDefaultTo1f()
        {
            Context context = new Context();
            TimeManager timeManager = context.TimeManager;

            Assert.Equal(1f, timeManager.TimeScale);
        }

        /// <summary>
        ///     Tests that DeltaTime is settable
        /// </summary>
        [Fact]
        public void TimeManager_DeltaTime_ShouldBeSettable()
        {
            Context context = new Context();
            TimeManager timeManager = context.TimeManager;

            timeManager.DeltaTime = 0.05f;

            Assert.Equal(0.05f, timeManager.DeltaTime);
        }

        /// <summary>
        ///     Tests that FixedDeltaTime is settable
        /// </summary>
        [Fact]
        public void TimeManager_FixedDeltaTime_ShouldBeSettable()
        {
            Context context = new Context();
            TimeManager timeManager = context.TimeManager;

            timeManager.FixedDeltaTime = 0.033f;

            Assert.Equal(0.033f, timeManager.FixedDeltaTime);
        }

        /// <summary>
        ///     Tests that FrameCount is settable
        /// </summary>
        [Fact]
        public void TimeManager_FrameCount_ShouldBeSettable()
        {
            Context context = new Context();
            TimeManager timeManager = context.TimeManager;

            timeManager.FrameCount = 42.0f;

            Assert.Equal(42.0f, timeManager.FrameCount);
        }

        /// <summary>
        ///     Tests that TotalFrames is settable
        /// </summary>
        [Fact]
        public void TimeManager_TotalFrames_ShouldBeSettable()
        {
            Context context = new Context();
            TimeManager timeManager = context.TimeManager;

            timeManager.TotalFrames = 1000;

            Assert.Equal(1000, timeManager.TotalFrames);
        }

        /// <summary>
        ///     Tests that AverageFrames is settable
        /// </summary>
        [Fact]
        public void TimeManager_AverageFrames_ShouldBeSettable()
        {
            Context context = new Context();
            TimeManager timeManager = context.TimeManager;

            timeManager.AverageFrames = 60;

            Assert.Equal(60, timeManager.AverageFrames);
        }

        /// <summary>
        ///     Tests that InFixedTimeStep is settable
        /// </summary>
        [Fact]
        public void TimeManager_InFixedTimeStep_ShouldBeSettable()
        {
            Context context = new Context();
            TimeManager timeManager = context.TimeManager;

            timeManager.InFixedTimeStep = true;

            Assert.True(timeManager.InFixedTimeStep);
        }

        /// <summary>
        ///     Tests that MaximumDeltaTime is settable
        /// </summary>
        [Fact]
        public void TimeManager_MaximumDeltaTime_ShouldBeSettable()
        {
            Context context = new Context();
            TimeManager timeManager = context.TimeManager;

            timeManager.MaximumDeltaTime = 0.1f;

            Assert.Equal(0.1f, timeManager.MaximumDeltaTime);
        }

        /// <summary>
        ///     Tests that SmoothDeltaTime is settable
        /// </summary>
        [Fact]
        public void TimeManager_SmoothDeltaTime_ShouldBeSettable()
        {
            Context context = new Context();
            TimeManager timeManager = context.TimeManager;

            timeManager.SmoothDeltaTime = 0.016f;

            Assert.Equal(0.016f, timeManager.SmoothDeltaTime);
        }

        /// <summary>
        ///     Tests that Time is settable
        /// </summary>
        [Fact]
        public void TimeManager_Time_ShouldBeSettable()
        {
            Context context = new Context();
            TimeManager timeManager = context.TimeManager;

            timeManager.Time = 5.5f;

            Assert.Equal(5.5f, timeManager.Time);
        }

        /// <summary>
        ///     Tests that RealtimeSinceStartup returns clock elapsed
        /// </summary>
        [Fact]
        public void TimeManager_RealtimeSinceStartup_ShouldReturnClockElapsed()
        {
            Context context = new Context();
            TimeManager timeManager = context.TimeManager;

            float realtime = timeManager.RealtimeSinceStartup;

            Assert.True(realtime >= 0);
            Assert.Equal((float) timeManager.Clock.Elapsed.TotalSeconds, realtime, 0.01f);
        }
    }
}
