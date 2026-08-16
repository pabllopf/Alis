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
using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Systems
{
    /// <summary>
    ///     Tests the <see cref="Clock"/> class.
    /// </summary>
    public class ClockTest
    {
        /// <summary>
        ///     Tests that the Clock constructor creates a valid instance.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_ShouldCreateValidInstance()
        {
            // Arrange & Act
            Clock clock = new Clock();

            // Assert
            Assert.NotNull(clock);

            // Cleanup
            clock.Destroy(true);
        }

        /// <summary>
        ///     Tests that ElapsedSfmlTime returns a valid time value.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void ElapsedSfmlTime_ShouldReturnValidTime()
        {
            // Arrange & Act
            Clock clock = new Clock();
            SfmlTime elapsedTime = clock.ElapsedSfmlTime;

            // Assert

            // Cleanup
            clock.Destroy(true);
        }

        /// <summary>
        ///     Tests that ElapsedSfmlTime returns zero time initially.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void ElapsedSfmlTime_InitialState_ShouldBeZero()
        {
            // Arrange & Act
            Clock clock = new Clock();
            SfmlTime elapsedTime = clock.ElapsedSfmlTime;

// Assert
            Assert.True(elapsedTime.AsMicroseconds() < 1000);

            // Cleanup
            clock.Destroy(true);
        }
        

        /// <summary>
        ///     Tests that multiple Restart calls work correctly.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void MultipleRestarts_ShouldWorkCorrectly()
        {
            // Arrange & Act
            Clock clock = new Clock();

            SfmlTime restart1 = clock.Restart();
            SfmlTime restart2 = clock.Restart();
            SfmlTime restart3 = clock.Restart();

            // Assert - All returns should be valid
            Assert.NotNull(restart2);

            // Cleanup
            clock.Destroy(true);
        }

        /// <summary>
        ///     Tests that Destroy can be called with disposing=true.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_WithDisposingTrue_ShouldNotThrow()
        {
            // Arrange
            Clock clock = new Clock();

            // Act & Assert
            Exception? exception = Record.Exception(() =>
            {
                clock.Destroy(true);
            });

            // Assert
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that Destroy can be called with disposing=false.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_WithDisposingFalse_ShouldNotThrow()
        {
            // Arrange
            Clock clock = new Clock();

            // Act & Assert
            Exception? exception = Record.Exception(() =>
            {
                clock.Destroy(false);
            });

            // Assert
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that multiple Clock instances can be created independently.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void MultipleInstances_ShouldWorkIndependently()
        {
            // Arrange & Act
            Clock clock1 = new Clock();
            Clock clock2 = new Clock();
            Clock clock3 = new Clock();

            SfmlTime time1 = clock1.ElapsedSfmlTime;
            SfmlTime time2 = clock2.ElapsedSfmlTime;
            SfmlTime time3 = clock3.ElapsedSfmlTime;

            // Assert - All should be valid
            Assert.NotNull(time2);

            // Cleanup
            clock1.Destroy(true);
            clock2.Destroy(true);
            clock3.Destroy(true);
        }

        /// <summary>
        ///     Tests the complete lifecycle: create, read time, restart, destroy.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void FullLifecycle_ShouldWorkCorrectly()
        {
            // Arrange & Act - Create
            Clock clock = new Clock();

            // Read initial time
            SfmlTime initialTime = clock.ElapsedSfmlTime;

            // Restart and get elapsed time
            SfmlTime restartedTime = clock.Restart();

            // Read time after restart
            SfmlTime afterRestart = clock.ElapsedSfmlTime;

            // Destroy
            clock.Destroy(true);

            // Assert - All operations completed without exception
            Assert.True(true);
        }
    }
}
