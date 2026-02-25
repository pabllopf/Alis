// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ProcessResourceMonitorTest.cs
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
using System.Diagnostics;
using Alis.Extension.Profile.Implementations;
using Xunit;

namespace Alis.Extension.Profile.Test.Implementations
{
    /// <summary>
    ///     The process resource monitor test class
    /// </summary>
    public class ProcessResourceMonitorTest
    {
        /// <summary>
        ///     Tests that constructor initializes with current process
        /// </summary>
        [Fact]
        public void Constructor_InitializesWithCurrentProcess()
        {
            // Act
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Assert - should not throw
            Assert.NotNull(monitor);
        }

        /// <summary>
        ///     Tests that constructor throws exception when process is null
        /// </summary>
        [Fact]
        public void Constructor_ThrowsException_WhenProcessIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ProcessResourceMonitor(null));
        }

        /// <summary>
        ///     Tests that get cpu usage returns non negative value
        /// </summary>
        [Fact]
        public void GetCpuUsage_ReturnsNonNegativeValue()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Act
            double cpuUsage = monitor.GetCpuUsage();

            // Assert
            Assert.True(cpuUsage >= 0);
        }

        /// <summary>
        ///     Tests that get memory usage returns positive value
        /// </summary>
        [Fact]
        public void GetMemoryUsage_ReturnsPositiveValue()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Act
            long memoryUsage = monitor.GetMemoryUsage();

            // Assert
            Assert.True(memoryUsage > 0);
        }

        /// <summary>
        ///     Tests that get garbage collection count returns non negative value
        /// </summary>
        [Fact]
        public void GetGarbageCollectionCount_ReturnsNonNegativeValue()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Act
            int gcCount = monitor.GetGarbageCollectionCount();

            // Assert
            Assert.True(gcCount >= 0);
        }

        /// <summary>
        ///     Tests that get thread count returns positive value
        /// </summary>
        [Fact]
        public void GetThreadCount_ReturnsPositiveValue()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Act
            int threadCount = monitor.GetThreadCount();

            // Assert
            Assert.True(threadCount > 0);
        }

        /// <summary>
        ///     Tests that constructor with process parameter works correctly
        /// </summary>
        [Fact]
        public void Constructor_WithProcessParameter_WorksCorrectly()
        {
            // Arrange
            Process currentProcess = Process.GetCurrentProcess();

            // Act
            ProcessResourceMonitor monitor = new ProcessResourceMonitor(currentProcess);

            // Assert
            Assert.NotNull(monitor);
            Assert.True(monitor.GetMemoryUsage() > 0);
        }

        /// <summary>
        ///     Tests that get cpu usage increases over time
        /// </summary>
        [Fact]
        public void GetCpuUsage_IncreasesOverTime()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();
            double firstUsage = monitor.GetCpuUsage();

            // Act - Perform some CPU-intensive work
            for (int i = 0; i < 1000000; i++)
            {
                _ = Math.Sqrt(i);
            }

            double secondUsage = monitor.GetCpuUsage();

            // Assert
            Assert.True(secondUsage >= firstUsage);
        }

        /// <summary>
        ///     Tests that get garbage collection count increases after gc
        /// </summary>
        [Fact]
        public void GetGarbageCollectionCount_IncreasesAfterGc()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();
            int firstCount = monitor.GetGarbageCollectionCount();

            // Act
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            int secondCount = monitor.GetGarbageCollectionCount();

            // Assert
            Assert.True(secondCount >= firstCount);
        }

        /// <summary>
        ///     Tests that get memory usage reflects current memory state
        /// </summary>
        [Fact]
        public void GetMemoryUsage_ReflectsCurrentMemoryState()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();
            long firstUsage = monitor.GetMemoryUsage();

            // Act - Allocate some memory
            byte[] largeArray = new byte[1024 * 1024]; // 1 MB

            long secondUsage = monitor.GetMemoryUsage();

            // Assert
            Assert.True(secondUsage >= firstUsage);

            // Cleanup
            GC.KeepAlive(largeArray);
        }
    }
}

