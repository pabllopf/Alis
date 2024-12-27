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

using System.Diagnostics.CodeAnalysis;
using System.Threading;
using Alis.Core.Aspect.Time;
using Alis.Core.Ecs.System;
using Alis.Core.Ecs.System.Manager.Time;
using Xunit;

namespace Alis.Test.Core.Ecs.System.Manager.Time
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
            VideoGame videoGame = new VideoGame();

            // Arrange & Act
            TimeManager timeManager = videoGame.Context.TimeManager;

            // Assert
            Assert.NotNull(timeManager.Configuration);
            Assert.NotNull(timeManager.Clock);
            Assert.Equal(0f, timeManager.DeltaTime);
            Assert.Equal(0f, timeManager.FixedDeltaTime);
            Assert.Equal(0f, timeManager.FixedTime);
            Assert.Equal(0f, timeManager.AverageFrames);
            Assert.Equal(0f, timeManager.TotalFrames);
            Assert.Equal(0d, timeManager.FixedTimeAsDouble);
            Assert.Equal(0f, timeManager.FixedUnscaledDeltaTime);
            Assert.Equal(0f, timeManager.FixedUnscaledTime);
            Assert.Equal(0d, timeManager.FixedUnscaledTimeAsDouble);
            Assert.Equal(0f, timeManager.FrameCount);
        }

        /// <summary>
        ///     Tests that time scale should be set correctly
        /// </summary>
        [Fact]
        public void TimeScale_ShouldBeSetCorrectly()
        {
            VideoGame videoGame = new VideoGame();
            // Arrange
            TimeManager timeManager = new TimeManager(videoGame.Context)
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
            VideoGame videoGame = new VideoGame();
            // Arrange & Act
            TimeManager timeManager = new TimeManager(videoGame.Context);

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
            VideoGame videoGame = new VideoGame();
            // Arrange
            TimeManager timeManager = new TimeManager(videoGame.Context)
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
            VideoGame videoGame = new VideoGame();
            // Arrange
            TimeManager timeManager = new TimeManager(videoGame.Context)
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
            VideoGame videoGame = new VideoGame();
            // Arrange
            TimeManager timeManager = new TimeManager(videoGame.Context);
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
            VideoGame videoGame = new VideoGame();
            // Arrange
            TimeManager timeManager = new TimeManager(videoGame.Context)
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
            VideoGame videoGame = new VideoGame();
            // Arrange
            TimeManager timeManager = new TimeManager(videoGame.Context)
            {
                // Act
                MaximumDeltaTime = 1f
            };

            // Assert
            Assert.NotEqual(0, timeManager.MaximumDeltaTime);
        }

        /// <summary>
        ///     Tests that time set value should update time
        /// </summary>
        [Fact]
        public void Time_SetValue_ShouldUpdateTime()
        {
            VideoGame videoGame = new VideoGame();
            // Arrange
            TimeManager timeManager = new TimeManager(videoGame.Context)
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
            VideoGame videoGame = new VideoGame();
            // Arrange
            TimeManager timeManager = new TimeManager(videoGame.Context)
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
            VideoGame videoGame = new VideoGame();
            // Arrange
            TimeManager timeManager = new TimeManager(videoGame.Context)
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
            VideoGame videoGame = new VideoGame();
            // Arrange
            TimeManager timeManager = new TimeManager(videoGame.Context)
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
            VideoGame videoGame = new VideoGame();
            // Arrange
            TimeManager timeManager = new TimeManager(videoGame.Context)
            {
                // Act
                TimeScale = 2.0f
            };

            // Assert
            Assert.Equal(2.0f, timeManager.TimeScale);
        }

        /// <summary>
        ///     Tests that average frames set value should update average frames
        /// </summary>
        [Fact]
        public void AverageFrames_SetValue_ShouldUpdateAverageFrames()
        {
            VideoGame videoGame = new VideoGame();
            // Arrange
            TimeManager timeManager = new TimeManager(videoGame.Context)
            {
                // Act
                AverageFrames = 2
            };

            // Assert
            Assert.Equal(2, timeManager.AverageFrames);
        }

        /// <summary>
        ///     Tests that total frames set value should update total frames
        /// </summary>
        [Fact]
        public void TotalFrames_SetValue_ShouldUpdateTotalFrames()
        {
            VideoGame videoGame = new VideoGame();
            // Arrange
            TimeManager timeManager = new TimeManager(videoGame.Context)
            {
                // Act
                TotalFrames = 2
            };

            // Assert
            Assert.Equal(2, timeManager.TotalFrames);
        }

        /// <summary>
        ///     Tests that unscaled delta time set value should update unscaled delta time
        /// </summary>
        [Fact]
        public void UnscaledDeltaTime_SetValue_ShouldUpdateUnscaledDeltaTime()
        {
            VideoGame videoGame = new VideoGame();
            // Arrange
            TimeManager timeManager = new TimeManager(videoGame.Context)
            {
                // Act
                UnscaledDeltaTime = 0.15f
            };

            // Assert
            Assert.Equal(0.15f, timeManager.UnscaledDeltaTime);
        }

        /// <summary>
        ///     Tests that fixed time as double set value should update fixed time as double
        /// </summary>
        [Fact]
        public void FixedTimeAsDouble_SetValue_ShouldUpdateFixedTimeAsDouble()
        {
            VideoGame videoGame = new VideoGame();
            // Arrange
            TimeManager timeManager = new TimeManager(videoGame.Context)
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
            VideoGame videoGame = new VideoGame();
            // Arrange
            TimeManager timeManager = new TimeManager(videoGame.Context)
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
            VideoGame videoGame = new VideoGame();
            // Arrange
            TimeManager timeManager = new TimeManager(videoGame.Context)
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
            VideoGame videoGame = new VideoGame();
            // Arrange
            TimeManager timeManager = new TimeManager(videoGame.Context)
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
            VideoGame videoGame = new VideoGame();
            // Arrange
            TimeManager timeManager = new TimeManager(videoGame.Context)
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
            VideoGame videoGame = new VideoGame();

            // Arrange
            TimeManager timeManager = new TimeManager(videoGame.Context)
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
            VideoGame videoGame = new VideoGame();

            // Arrange
            TimeManager timeManager = new TimeManager(videoGame.Context)
            {
                // Act
                TimeAsDouble = 30.75
            };

            // Assert
            Assert.Equal(30.75, timeManager.TimeAsDouble);
        }
    }
}