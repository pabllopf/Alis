// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: TimeManagerTest.cs
// 
//  Author: Pablo Perdomo Falcón
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

using System.Threading;
using Xunit;

namespace Alis.Core.Aspect.Time.Test
{
    /// <summary>
    ///     The time manager test class
    /// </summary>
    public class TimeManagerTest
    {
        /// <summary>
        ///     Tests that constructor should initialize properties
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange & Act
            TimeManager timeManager = new TimeManager();

            // Assert
            Assert.NotNull(timeManager.Configuration);
            Assert.NotNull(timeManager.Clock);
            Assert.Equal(0f, timeManager.DeltaTime);
            Assert.Equal(0f, timeManager.FixedDeltaTime);
            Assert.Equal(0f, timeManager.FixedTime);
            Assert.Equal(0d, timeManager.FixedTimeAsDouble);
            Assert.Equal(0f, timeManager.FixedUnscaledDeltaTime);
            Assert.Equal(0f, timeManager.FixedUnscaledTime);
            Assert.Equal(0d, timeManager.FixedUnscaledTimeAsDouble);
            Assert.Equal(0f, timeManager.FrameCount);
            Assert.False(timeManager.InFixedTimeStep);
            Assert.False(timeManager.MaximumDeltaTime);
            Assert.Equal(0f, timeManager.RealtimeSinceStartup);
            Assert.Equal(0d, timeManager.RealtimeSinceStartupAsDouble);
            Assert.Equal(0f, timeManager.SmoothDeltaTime);
            Assert.Equal(0f, timeManager.Time);
            Assert.Equal(0d, timeManager.TimeAsDouble);
            Assert.Equal(1f, timeManager.TimeScale);
            Assert.Equal(0f, timeManager.UnscaledDeltaTime);
            Assert.Equal(0f, timeManager.UnscaledTime);
            Assert.Equal(0d, timeManager.UnscaledTimeAsDouble);
        }

        /// <summary>
        ///     Tests that time scale should be set correctly
        /// </summary>
        [Fact]
        public void TimeScale_ShouldBeSetCorrectly()
        {
            // Arrange
            TimeManager timeManager = new TimeManager
            {
                // Act
                TimeScale = 2f
            };

            // Assert
            Assert.Equal(2f, timeManager.TimeScale);
        }

        /// <summary>
        ///     Tests that clock should be started
        /// </summary>
        [Fact]
        public void Clock_ShouldBeStarted()
        {
            // Arrange & Act
            TimeManager timeManager = new TimeManager();

            Thread.Sleep(1000); // Sleep for 1 second

            // Assert
            Assert.True(timeManager.Clock.ElapsedMilliseconds > 0);
        }

        /// <summary>
        ///     Tests that delta time set value should update delta time
        /// </summary>
        [Fact]
        public void DeltaTime_SetValue_ShouldUpdateDeltaTime()
        {
            // Arrange
            TimeManager timeManager = new TimeManager
            {
                // Act
                DeltaTime = 0.5f
            };

            // Assert
            Assert.Equal(0.5f, timeManager.DeltaTime);
        }

        /// <summary>
        ///     Tests that fixed delta time set value should update fixed delta time
        /// </summary>
        [Fact]
        public void FixedDeltaTime_SetValue_ShouldUpdateFixedDeltaTime()
        {
            // Arrange
            TimeManager timeManager = new TimeManager
            {
                // Act
                FixedDeltaTime = 0.1f
            };

            // Assert
            Assert.Equal(0.1f, timeManager.FixedDeltaTime);
        }

        /// <summary>
        ///     Tests that clock set value should update clock
        /// </summary>
        [Fact]
        public void Clock_SetValue_ShouldUpdateClock()
        {
            // Arrange
            TimeManager timeManager = new TimeManager();
            Clock newClock = new Clock();

            // Act
            timeManager.Clock = newClock;

            // Assert
            Assert.Equal(newClock, timeManager.Clock);
        }

        /// <summary>
        ///     Tests that fixed time set value should update fixed time
        /// </summary>
        [Fact]
        public void FixedTime_SetValue_ShouldUpdateFixedTime()
        {
            // Arrange
            TimeManager timeManager = new TimeManager
            {
                // Act
                FixedTime = 5f
            };

            // Assert
            Assert.Equal(5f, timeManager.FixedTime);
        }

        // Repeat similar tests for the other properties...

        /// <summary>
        ///     Tests that maximum delta time set value should update maximum delta time
        /// </summary>
        [Fact]
        public void MaximumDeltaTime_SetValue_ShouldUpdateMaximumDeltaTime()
        {
            // Arrange
            TimeManager timeManager = new TimeManager
            {
                // Act
                MaximumDeltaTime = true
            };

            // Assert
            Assert.True(timeManager.MaximumDeltaTime);
        }

        /// <summary>
        ///     Tests that time set value should update time
        /// </summary>
        [Fact]
        public void Time_SetValue_ShouldUpdateTime()
        {
            // Arrange
            TimeManager timeManager = new TimeManager
            {
                // Act
                Time = 10f
            };

            // Assert
            Assert.Equal(10f, timeManager.Time);
        }


        /// <summary>
        ///     Tests that frame count set value should update frame count
        /// </summary>
        [Fact]
        public void FrameCount_SetValue_ShouldUpdateFrameCount()
        {
            // Arrange
            TimeManager timeManager = new TimeManager
            {
                // Act
                FrameCount = 100
            };

            // Assert
            Assert.Equal(100, timeManager.FrameCount);
        }

        /// <summary>
        ///     Tests that in fixed time step set value should update in fixed time step
        /// </summary>
        [Fact]
        public void InFixedTimeStep_SetValue_ShouldUpdateInFixedTimeStep()
        {
            // Arrange
            TimeManager timeManager = new TimeManager
            {
                // Act
                InFixedTimeStep = true
            };

            // Assert
            Assert.True(timeManager.InFixedTimeStep);
        }

        /// <summary>
        ///     Tests that smooth delta time set value should update smooth delta time
        /// </summary>
        [Fact]
        public void SmoothDeltaTime_SetValue_ShouldUpdateSmoothDeltaTime()
        {
            // Arrange
            TimeManager timeManager = new TimeManager
            {
                // Act
                SmoothDeltaTime = 0.2f
            };

            // Assert
            Assert.Equal(0.2f, timeManager.SmoothDeltaTime);
        }

        /// <summary>
        ///     Tests that time scale set value should update time scale
        /// </summary>
        [Fact]
        public void TimeScale_SetValue_ShouldUpdateTimeScale()
        {
            // Arrange
            TimeManager timeManager = new TimeManager
            {
                // Act
                TimeScale = 2.0f
            };

            // Assert
            Assert.Equal(2.0f, timeManager.TimeScale);
        }

        /// <summary>
        ///     Tests that unscaled delta time set value should update unscaled delta time
        /// </summary>
        [Fact]
        public void UnscaledDeltaTime_SetValue_ShouldUpdateUnscaledDeltaTime()
        {
            // Arrange
            TimeManager timeManager = new TimeManager
            {
                // Act
                UnscaledDeltaTime = 0.15f
            };

            // Assert
            Assert.Equal(0.15f, timeManager.UnscaledDeltaTime);
        }

        /// <summary>
        ///     Tests that realtime since startup set value should update realtime since startup
        /// </summary>
        [Fact]
        public void RealtimeSinceStartup_SetValue_ShouldUpdateRealtimeSinceStartup()
        {
            // Arrange
            TimeManager timeManager = new TimeManager
            {
                // Act
                RealtimeSinceStartup = 10.5f
            };

            // Assert
            Assert.Equal(10.5f, timeManager.RealtimeSinceStartup);
        }

        /// <summary>
        ///     Tests that realtime since startup as double set value should update realtime since startup as double
        /// </summary>
        [Fact]
        public void RealtimeSinceStartupAsDouble_SetValue_ShouldUpdateRealtimeSinceStartupAsDouble()
        {
            // Arrange
            TimeManager timeManager = new TimeManager
            {
                // Act
                RealtimeSinceStartupAsDouble = 20.5
            };

            // Assert
            Assert.Equal(20.5, timeManager.RealtimeSinceStartupAsDouble);
        }

        /// <summary>
        ///     Tests that fixed time as double set value should update fixed time as double
        /// </summary>
        [Fact]
        public void FixedTimeAsDouble_SetValue_ShouldUpdateFixedTimeAsDouble()
        {
            // Arrange
            TimeManager timeManager = new TimeManager
            {
                // Act
                FixedTimeAsDouble = 30.5
            };

            // Assert
            Assert.Equal(30.5, timeManager.FixedTimeAsDouble);
        }

        /// <summary>
        ///     Tests that fixed unscaled delta time set value should update fixed unscaled delta time
        /// </summary>
        [Fact]
        public void FixedUnscaledDeltaTime_SetValue_ShouldUpdateFixedUnscaledDeltaTime()
        {
            // Arrange
            TimeManager timeManager = new TimeManager
            {
                // Act
                FixedUnscaledDeltaTime = 0.02f
            };

            // Assert
            Assert.Equal(0.02f, timeManager.FixedUnscaledDeltaTime);
        }

        /// <summary>
        ///     Tests that fixed unscaled time set value should update fixed unscaled time
        /// </summary>
        [Fact]
        public void FixedUnscaledTime_SetValue_ShouldUpdateFixedUnscaledTime()
        {
            // Arrange
            TimeManager timeManager = new TimeManager
            {
                // Act
                FixedUnscaledTime = 15.0f
            };

            // Assert
            Assert.Equal(15.0f, timeManager.FixedUnscaledTime);
        }

        /// <summary>
        ///     Tests that fixed unscaled time as double set value should update fixed unscaled time as double
        /// </summary>
        [Fact]
        public void FixedUnscaledTimeAsDouble_SetValue_ShouldUpdateFixedUnscaledTimeAsDouble()
        {
            // Arrange
            TimeManager timeManager = new TimeManager
            {
                // Act
                FixedUnscaledTimeAsDouble = 25.5
            };

            // Assert
            Assert.Equal(25.5, timeManager.FixedUnscaledTimeAsDouble);
        }

        /// <summary>
        ///     Tests that unscaled time set value should update unscaled time
        /// </summary>
        [Fact]
        public void UnscaledTime_SetValue_ShouldUpdateUnscaledTime()
        {
            // Arrange
            TimeManager timeManager = new TimeManager
            {
                // Act
                UnscaledTime = 10.0f
            };

            // Assert
            Assert.Equal(10.0f, timeManager.UnscaledTime);
        }

        /// <summary>
        ///     Tests that unscaled time as double set value should update unscaled time as double
        /// </summary>
        [Fact]
        public void UnscaledTimeAsDouble_SetValue_ShouldUpdateUnscaledTimeAsDouble()
        {
            // Arrange
            TimeManager timeManager = new TimeManager
            {
                // Act
                UnscaledTimeAsDouble = 20.5
            };

            // Assert
            Assert.Equal(20.5, timeManager.UnscaledTimeAsDouble);
        }

        /// <summary>
        ///     Tests that time as double set value should update time as double
        /// </summary>
        [Fact]
        public void TimeAsDouble_SetValue_ShouldUpdateTimeAsDouble()
        {
            // Arrange
            TimeManager timeManager = new TimeManager
            {
                // Act
                TimeAsDouble = 30.75
            };

            // Assert
            Assert.Equal(30.75, timeManager.TimeAsDouble);
        }
    }
}