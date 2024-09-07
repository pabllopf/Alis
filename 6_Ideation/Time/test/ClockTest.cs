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
            // Arrange
            Clock clock = new Clock();

            // Act
            clock.Start();

            // Assert
            Assert.True(clock.ElapsedMilliseconds >= 0);
        }

        /// <summary>
        ///     Tests that stop should stop stopwatch
        /// </summary>
        [Fact]
        public void Stop_ShouldStopStopwatch()
        {
            // Arrange
            Clock clock = new Clock();

            // Act
            clock.Start();
            clock.Stop();

            // Assert
            Assert.True(clock.ElapsedMilliseconds >= 0);
        }

        /// <summary>
        ///     Tests that reset should reset stopwatch
        /// </summary>
        [Fact]
        public void Reset_ShouldResetStopwatch()
        {
            // Arrange
            Clock clock = new Clock();

            // Act
            clock.Start();
            clock.Reset();

            // Assert
            Assert.True(clock.ElapsedMilliseconds == 0);
        }

        /// <summary>
        ///     Tests that elapsed should return elapsed time
        /// </summary>
        [Fact]
        public void Elapsed_ShouldReturnElapsedTime()
        {
            // Arrange
            Clock clock = new Clock();

            // Act
            clock.Start();
            Thread.Sleep(1000); // Sleep for 1 second
            clock.Stop();

            // Assert
            Assert.True(clock.Elapsed.TotalSeconds >= 1);
        }

        /// <summary>
        ///     Tests that elapsed milliseconds should return elapsed milliseconds
        /// </summary>
        [Fact]
        public void ElapsedMilliseconds_ShouldReturnElapsedMilliseconds()
        {
            // Arrange
            Clock clock = new Clock();

            // Act
            clock.Start();
            Thread.Sleep(1000); // Sleep for 1 second
            clock.Stop();

            // Assert
            Assert.True(clock.ElapsedMilliseconds >= 1000);
        }

        /// <summary>
        ///     Tests that elapsed ticks should return elapsed ticks
        /// </summary>
        [Fact]
        public void ElapsedTicks_ShouldReturnElapsedTicks()
        {
            // Arrange
            Clock clock = new Clock();

            // Act
            clock.Start();
            Thread.Sleep(1000); // Sleep for 1 second
            clock.Stop();

            // Assert
            Assert.True(clock.ElapsedTicks >= TimeSpan.TicksPerSecond);
        }

        /// <summary>
        ///     Tests that elapsed seconds should return elapsed seconds
        /// </summary>
        [Fact]
        public void ElapsedSeconds_ShouldReturnElapsedSeconds()
        {
            // Arrange
            Clock clock = new Clock();

            // Act
            clock.Start();
            Thread.Sleep(1000); // Sleep for 1 second
            clock.Stop();

            // Assert
            Assert.True(clock.ElapsedSeconds >= 1);
        }
    }
}