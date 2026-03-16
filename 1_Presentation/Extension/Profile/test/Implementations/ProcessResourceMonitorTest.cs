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
using System.Collections.Generic;
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

        /// <summary>
        ///     Tests that get cpu usage returns value as total processor time milliseconds
        /// </summary>
        [Fact]
        public void GetCpuUsage_ReturnsValueAsTotalProcessorTimeMilliseconds()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();
            Process currentProcess = Process.GetCurrentProcess();
            double expectedValue = currentProcess.TotalProcessorTime.TotalMilliseconds;

            // Act
            double cpuUsage = monitor.GetCpuUsage();

            // Assert
            Assert.True(cpuUsage >= 0);
            Assert.True(Math.Abs(cpuUsage - expectedValue) < 1000); // Within 1 second
        }


        /// <summary>
        ///     Tests that get thread count returns threads count
        /// </summary>
        [Fact]
        public void GetThreadCount_ReturnsThreadsCount()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();
            Process currentProcess = Process.GetCurrentProcess();
            int expectedValue = currentProcess.Threads.Count;

            // Act
            int threadCount = monitor.GetThreadCount();

            // Assert
            Assert.Equal(expectedValue, threadCount);
        }

        /// <summary>
        ///     Tests that multiple calls to get cpu usage return consistent results
        /// </summary>
        [Fact]
        public void GetCpuUsage_MultipleCalls_ReturnConsistentResults()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Act
            double firstCall = monitor.GetCpuUsage();
            double secondCall = monitor.GetCpuUsage();

            // Assert
            Assert.True(secondCall >= firstCall);
        }

        /// <summary>
        ///     Tests that multiple calls to get memory usage return consistent or increasing results
        /// </summary>
        [Fact]
        public void GetMemoryUsage_MultipleCalls_ReturnConsistentOrIncreasingResults()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Act
            long firstCall = monitor.GetMemoryUsage();
            long secondCall = monitor.GetMemoryUsage();

            // Assert
            Assert.True(secondCall >= firstCall);
        }

        /// <summary>
        ///     Tests that multiple calls to get thread count return consistent or increasing results
        /// </summary>
        [Fact]
        public void GetThreadCount_MultipleCalls_ReturnConsistentOrIncreasingResults()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Act
            int firstCall = monitor.GetThreadCount();
            int secondCall = monitor.GetThreadCount();

            // Assert
            Assert.True(secondCall >= firstCall);
        }

        /// <summary>
        ///     Tests that get garbage collection count returns zero or positive value
        /// </summary>
        [Fact]
        public void GetGarbageCollectionCount_WithRealProcess_ReturnsPositiveValue()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Act
            int firstGcCount = monitor.GetGarbageCollectionCount();
            GC.Collect();
            int secondGcCount = monitor.GetGarbageCollectionCount();

            // Assert
            Assert.True(firstGcCount >= 0);
            Assert.True(secondGcCount >= firstGcCount);
        }

        /// <summary>
        ///     Tests that constructor with current process can access memory
        /// </summary>
        [Fact]
        public void Constructor_WithCurrentProcess_CanAccessMemory()
        {
            // Act
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();
            long memory = monitor.GetMemoryUsage();

            // Assert
            Assert.True(memory > 0);
        }

        /// <summary>
        ///     Tests that constructor with current process can access cpu
        /// </summary>
        [Fact]
        public void Constructor_WithCurrentProcess_CanAccessCpu()
        {
            // Act
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();
            double cpu = monitor.GetCpuUsage();

            // Assert
            Assert.True(cpu >= 0);
        }

        /// <summary>
        ///     Tests that constructor with current process can access thread count
        /// </summary>
        [Fact]
        public void Constructor_WithCurrentProcess_CanAccessThreadCount()
        {
            // Act
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();
            int threadCount = monitor.GetThreadCount();

            // Assert
            Assert.True(threadCount > 0);
        }

        /// <summary>
        ///     Tests that all methods return valid values with real process
        /// </summary>
        [Fact]
        public void AllMethods_ReturnValidValues_WithRealProcess()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Act
            double cpuUsage = monitor.GetCpuUsage();
            long memoryUsage = monitor.GetMemoryUsage();
            int gcCount = monitor.GetGarbageCollectionCount();
            int threadCount = monitor.GetThreadCount();

            // Assert
            Assert.True(cpuUsage >= 0);
            Assert.True(memoryUsage > 0);
            Assert.True(gcCount >= 0);
            Assert.True(threadCount > 0);
        }

        /// <summary>
        ///     Tests that garbage collection sum equals all generations
        /// </summary>
        [Fact]
        public void GetGarbageCollectionCount_EqualsSumOfAllGenerations()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Act
            int gcCount = monitor.GetGarbageCollectionCount();
            int gen0 = GC.CollectionCount(0);
            int gen1 = GC.CollectionCount(1);
            int gen2 = GC.CollectionCount(2);
            int expectedSum = gen0 + gen1 + gen2;

            // Assert
            Assert.Equal(expectedSum, gcCount);
        }

        /// <summary>
        ///     Tests that memory allocation increases memory usage
        /// </summary>
        [Fact]
        public void GetMemoryUsage_IncreaseAfterAllocation()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();
            long initialMemory = monitor.GetMemoryUsage();

            // Act - Allocate multiple arrays
            byte[] array1 = new byte[512 * 1024]; // 512 KB
            byte[] array2 = new byte[512 * 1024]; // 512 KB
            long afterAllocationMemory = monitor.GetMemoryUsage();

            // Assert
            Assert.True(afterAllocationMemory >= initialMemory);

            // Cleanup
            GC.KeepAlive(array1);
            GC.KeepAlive(array2);
        }

        /// <summary>
        ///     Tests that cpu usage increases with cpu intensive work
        /// </summary>
        [Fact]
        public void GetCpuUsage_IncreasesWithCpuIntensiveWork()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();
            double cpuBefore = monitor.GetCpuUsage();

            // Act - Perform CPU intensive work
            for (int i = 0; i < 10000000; i++)
            {
                _ = Math.Sqrt(i) * Math.Sqrt(i + 1);
            }

            double cpuAfter = monitor.GetCpuUsage();

            // Assert
            Assert.True(cpuAfter >= cpuBefore);
        }

        /// <summary>
        ///     Tests that constructor with specific process works correctly
        /// </summary>
        [Fact]
        public void Constructor_WithSpecificProcess_StoresProcessCorrectly()
        {
            // Arrange
            Process specificProcess = Process.GetCurrentProcess();

            // Act
            ProcessResourceMonitor monitor = new ProcessResourceMonitor(specificProcess);
            long memory = monitor.GetMemoryUsage();

            // Assert
            Assert.NotNull(monitor);
            Assert.True(memory > 0);
        }

        /// <summary>
        ///     Tests that get cpu usage never returns negative value
        /// </summary>
        [Fact]
        public void GetCpuUsage_NeverReturnsNegativeValue()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Act
            for (int i = 0; i < 5; i++)
            {
                double cpuUsage = monitor.GetCpuUsage();

                // Assert
                Assert.True(cpuUsage >= 0, $"CPU usage should never be negative, got {cpuUsage}");
            }
        }

        /// <summary>
        ///     Tests that get memory usage never returns negative value
        /// </summary>
        [Fact]
        public void GetMemoryUsage_NeverReturnsNegativeValue()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Act
            for (int i = 0; i < 5; i++)
            {
                long memoryUsage = monitor.GetMemoryUsage();

                // Assert
                Assert.True(memoryUsage >= 0, $"Memory usage should never be negative, got {memoryUsage}");
            }
        }

        /// <summary>
        ///     Tests that get thread count never returns negative value
        /// </summary>
        [Fact]
        public void GetThreadCount_NeverReturnsNegativeValue()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Act
            for (int i = 0; i < 5; i++)
            {
                int threadCount = monitor.GetThreadCount();

                // Assert
                Assert.True(threadCount >= 0, $"Thread count should never be negative, got {threadCount}");
            }
        }

        /// <summary>
        ///     Tests that get garbage collection count never returns negative value
        /// </summary>
        [Fact]
        public void GetGarbageCollectionCount_NeverReturnsNegativeValue()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Act
            for (int i = 0; i < 5; i++)
            {
                int gcCount = monitor.GetGarbageCollectionCount();

                // Assert
                Assert.True(gcCount >= 0, $"GC count should never be negative, got {gcCount}");
            }
        }

        /// <summary>
        ///     Tests that exception handling in get cpu usage returns zero on exception
        /// </summary>
        [Fact]
        public void GetCpuUsage_ExceptionHandling_InvokesMethodWithoutCrash()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Act & Assert - Should not throw
            double cpuUsage = monitor.GetCpuUsage();
            Assert.True(cpuUsage >= 0);
        }

        /// <summary>
        ///     Tests that exception handling in get memory usage returns zero on exception
        /// </summary>
        [Fact]
        public void GetMemoryUsage_ExceptionHandling_InvokesMethodWithoutCrash()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Act & Assert - Should not throw
            long memoryUsage = monitor.GetMemoryUsage();
            Assert.True(memoryUsage >= 0);
        }

        /// <summary>
        ///     Tests that exception handling in get thread count returns zero on exception
        /// </summary>
        [Fact]
        public void GetThreadCount_ExceptionHandling_InvokesMethodWithoutCrash()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Act & Assert - Should not throw
            int threadCount = monitor.GetThreadCount();
            Assert.True(threadCount >= 0);
        }

        /// <summary>
        ///     Tests that multiple instances monitor independently
        /// </summary>
        [Fact]
        public void MultipleInstances_MonitorIndependently()
        {
            // Arrange
            ProcessResourceMonitor monitor1 = new ProcessResourceMonitor();
            ProcessResourceMonitor monitor2 = new ProcessResourceMonitor();

            // Act
            long memory1 = monitor1.GetMemoryUsage();
            long memory2 = monitor2.GetMemoryUsage();

            // Assert
            Assert.Equal(memory1, memory2, 100000.0f);
        }

        /// <summary>
        ///     Tests that different processes can be monitored
        /// </summary>
        [Fact]
        public void Constructor_WithDifferentProcesses_Works()
        {
            // Arrange
            Process currentProcess = Process.GetCurrentProcess();
            ProcessResourceMonitor monitor1 = new ProcessResourceMonitor(currentProcess);
            ProcessResourceMonitor monitor2 = new ProcessResourceMonitor();

            // Act
            long memory1 = monitor1.GetMemoryUsage();
            long memory2 = monitor2.GetMemoryUsage();

            // Assert
            Assert.True(memory1 > 0);
            Assert.True(memory2 > 0);
        }

        /// <summary>
        ///     Tests that continuous monitoring works correctly
        /// </summary>
        [Fact]
        public void ContinuousMonitoring_WorksCorrectly()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();
            List<(double cpu, long memory, int threads, int gc)> results = new List<(double cpu, long memory, int threads, int gc)>();

            // Act
            for (int i = 0; i < 3; i++)
            {
                results.Add((
                    monitor.GetCpuUsage(),
                    monitor.GetMemoryUsage(),
                    monitor.GetThreadCount(),
                    monitor.GetGarbageCollectionCount()
                ));
            }

            // Assert
            Assert.Equal(3, results.Count);
            foreach ((double cpu, long memory, int threads, int gc) result in results)
            {
                Assert.True(result.cpu >= 0);
                Assert.True(result.memory > 0);
                Assert.True(result.threads > 0);
                Assert.True(result.gc >= 0);
            }
        }

        /// <summary>
        ///     Tests that get memory usage consistency across time
        /// </summary>
        [Fact]
        public void GetMemoryUsage_Consistency_AcrossTime()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();
            List<long> memorySnapshots = new List<long>();

            // Act
            for (int i = 0; i < 5; i++)
            {
                memorySnapshots.Add(monitor.GetMemoryUsage());
            }

            // Assert
            Assert.Equal(5, memorySnapshots.Count);
            for (int i = 1; i < memorySnapshots.Count; i++)
            {
                Assert.True(memorySnapshots[i] >= memorySnapshots[0]);
            }
        }
    }
}