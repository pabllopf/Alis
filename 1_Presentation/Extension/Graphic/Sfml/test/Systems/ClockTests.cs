// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ClockTests.cs
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
    /// The clock tests class
    /// </summary>
    public class ClockTests
    {
        /// <summary>
        /// Constructors the should not be null
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_ShouldNotBeNull()
        {
            Clock clock = new Clock();
            Assert.NotNull(clock);
            clock.Destroy(true);
        }

        /// <summary>
        /// Elapseds the sfml time after restart should be near zero
        /// </summary>
        [RequireCSfmlSystemFact]
        public void ElapsedSfmlTime_AfterRestart_ShouldBeNearZero()
        {
            Clock clock = new Clock();
            clock.Restart();
            SfmlTime elapsed = clock.ElapsedSfmlTime;
            Assert.True(elapsed.AsMicroseconds() >= 0);
            clock.Destroy(true);
        }

        /// <summary>
        /// Elapseds the sfml time after delay should increase
        /// </summary>
        [RequireCSfmlSystemFact]
        public void ElapsedSfmlTime_AfterDelay_ShouldIncrease()
        {
            Clock clock = new Clock();
            SfmlTime t1 = clock.ElapsedSfmlTime;
            Sleep(1);
            SfmlTime t2 = clock.ElapsedSfmlTime;
            Assert.True(t2.AsMicroseconds() >= t1.AsMicroseconds());
            clock.Destroy(true);
        }

        /// <summary>
        /// Restarts the should return elapsed time
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Restart_ShouldReturnElapsedTime()
        {
            Clock clock = new Clock();
            Sleep(1);
            SfmlTime elapsed = clock.Restart();
            Assert.True(elapsed.AsMicroseconds() >= 0);
            clock.Destroy(true);
        }

        /// <summary>
        /// Restarts the should reset elapsed time
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Restart_ShouldResetElapsedTime()
        {
            Clock clock = new Clock();
            Sleep(1);
            clock.Restart();
            SfmlTime after = clock.ElapsedSfmlTime;
            Assert.True(after.AsMicroseconds() >= 0);
            clock.Destroy(true);
        }

        /// <summary>
        /// Disposes the should not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Dispose_ShouldNotThrow()
        {
            Clock clock = new Clock();
            clock.Dispose();
        }

        /// <summary>
        /// Disposes the multiple calls should not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Dispose_MultipleCalls_ShouldNotThrow()
        {
            Clock clock = new Clock();
            clock.Dispose();
            clock.Dispose();
        }

        /// <summary>
        /// Usings the should not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Using_ShouldNotThrow()
        {
            using Clock clock = new Clock();
            Assert.NotNull(clock);
        }

        /// <summary>
        /// Destroys the with disposing true sets pointer to zero
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_WithDisposingTrue_SetsPointerToZero()
        {
            Clock clock = new Clock();
            IntPtr ptr = clock.CPointer;
            Assert.NotEqual(IntPtr.Zero, ptr);
            clock.Destroy(true);
            Assert.Equal(IntPtr.Zero, clock.CPointer);
        }

        /// <summary>
        /// Destroys the with disposing false sets pointer to zero
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_WithDisposingFalse_SetsPointerToZero()
        {
            Clock clock = new Clock();
            IntPtr ptr = clock.CPointer;
            Assert.NotEqual(IntPtr.Zero, ptr);
            clock.Destroy(false);
            Assert.Equal(IntPtr.Zero, clock.CPointer);
        }

        /// <summary>
        /// Elapseds the sfml time multiple reads should not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void ElapsedSfmlTime_MultipleReads_ShouldNotThrow()
        {
            Clock clock = new Clock();
            SfmlTime t1 = clock.ElapsedSfmlTime;
            SfmlTime t2 = clock.ElapsedSfmlTime;
            SfmlTime t3 = clock.ElapsedSfmlTime;
            clock.Destroy(true);
        }

        /// <summary>
        /// Sleeps the milliseconds
        /// </summary>
        /// <param name="milliseconds">The milliseconds</param>
        private static void Sleep(int milliseconds)
        {
            long ticks = milliseconds * TimeSpan.TicksPerMillisecond;
            long start = DateTime.Now.Ticks;
            while ((DateTime.Now.Ticks - start) < ticks)
            {
            }
        }
    }
}
