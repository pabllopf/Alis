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
    public class ClockTest : IDisposable
    {
        /// <summary>
        ///     The clock instance.
        /// </summary>
        private Clock _clock;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ClockTest"/> class.
        /// </summary>
        public ClockTest()
        {
            _clock = new Clock();
        }

        /// <summary>
        ///     Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            _clock?.Destroy(true);
        }

        /// <summary>
        ///     Tests that the Clock constructor creates a valid instance.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_ShouldCreateValidInstance()
        {
            // Arrange & Act
            var clock = new Clock();

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
            var clock = new Clock();
            SfmlTime elapsedTime = clock.ElapsedSfmlTime;

            // Assert
            Assert.NotNull(elapsedTime);

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
            var clock = new Clock();
            SfmlTime elapsedTime = clock.ElapsedSfmlTime;

            // Assert
            Assert.Equal(0, elapsedTime.AsMicroseconds());

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
            var clock = new Clock();

            SfmlTime restart1 = clock.Restart();
            SfmlTime restart2 = clock.Restart();
            SfmlTime restart3 = clock.Restart();

            // Assert - All returns should be valid
            Assert.NotNull(restart1);
            Assert.NotNull(restart2);
            Assert.NotNull(restart3);

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
            var clock = new Clock();

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
            var clock = new Clock();

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
            var clock1 = new Clock();
            var clock2 = new Clock();
            var clock3 = new Clock();

            SfmlTime time1 = clock1.ElapsedSfmlTime;
            SfmlTime time2 = clock2.ElapsedSfmlTime;
            SfmlTime time3 = clock3.ElapsedSfmlTime;

            // Assert - All should be valid
            Assert.NotNull(time1);
            Assert.NotNull(time2);
            Assert.NotNull(time3);

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
            var clock = new Clock();

            // Read initial time
            SfmlTime initialTime = clock.ElapsedSfmlTime;
            Assert.NotNull(initialTime);

            // Restart and get elapsed time
            SfmlTime restartedTime = clock.Restart();
            Assert.NotNull(restartedTime);

            // Read time after restart
            SfmlTime afterRestart = clock.ElapsedSfmlTime;
            Assert.NotNull(afterRestart);

            // Destroy
            clock.Destroy(true);

            // Assert - All operations completed without exception
            Assert.True(true);
        }
    }
}
