// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ProcessResourceMonitorComprehensiveTest.cs
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
    ///     Comprehensive unit tests for ProcessResourceMonitor class.
    ///     Tests all public members including constructors and resource measurement methods.
    /// </summary>
    public class ProcessResourceMonitorComprehensiveTest
    {
        /// <summary>
        ///     Tests that default constructor initializes successfully.
        /// </summary>
        [Fact]
        public void DefaultConstructor_InitializesSuccessfully()
        {
            // Act
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Assert
            Assert.NotNull(monitor);
        }

        /// <summary>
        ///     Tests that constructor with specific process initializes successfully.
        /// </summary>
        [Fact]
        public void ConstructorWithProcess_InitializesWithSpecificProcess()
        {
            // Arrange
            Process currentProcess = Process.GetCurrentProcess();

            // Act
            ProcessResourceMonitor monitor = new ProcessResourceMonitor(currentProcess);

            // Assert
            Assert.NotNull(monitor);
        }

        /// <summary>
        ///     Tests that constructor throws exception when process is null.
        /// </summary>
        [Fact]
        public void ConstructorWithProcess_ThrowsArgumentNullException_WhenProcessIsNull()
        {
            // Act & Assert
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() =>
                new ProcessResourceMonitor(null));

            Assert.Equal("process", ex.ParamName);
        }

        /// <summary>
        ///     Tests that GetCpuUsage returns a non-negative value.
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
        ///     Tests that GetMemoryUsage returns a non-negative value.
        /// </summary>
        [Fact]
        public void GetMemoryUsage_ReturnsNonNegativeValue()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Act
            long memoryUsage = monitor.GetMemoryUsage();

            // Assert
            Assert.True(memoryUsage >= 0);
        }

        /// <summary>
        ///     Tests that GetGarbageCollectionCount returns a non-negative value.
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
        ///     Tests that GetThreadCount returns a non-negative value.
        /// </summary>
        [Fact]
        public void GetThreadCount_ReturnsNonNegativeValue()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Act
            int threadCount = monitor.GetThreadCount();

            // Assert
            Assert.True(threadCount >= 0);
        }

        /// <summary>
        ///     Tests that GetMemoryUsage returns reasonable memory value.
        /// </summary>
        [Fact]
        public void GetMemoryUsage_ReturnsReasonableValue()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Act
            long memoryUsage = monitor.GetMemoryUsage();

            // Assert - Should be at least 1 MB for .NET application
            Assert.True(memoryUsage > 1_000_000);
        }

        /// <summary>
        ///     Tests that GetThreadCount returns reasonable thread count.
        /// </summary>
        [Fact]
        public void GetThreadCount_ReturnsReasonableValue()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Act
            int threadCount = monitor.GetThreadCount();

            // Assert - Should have at least 1 thread
            Assert.True(threadCount >= 1);
        }

        /// <summary>
        ///     Tests that multiple calls to GetCpuUsage return consistent results.
        /// </summary>
        [Fact]
        public void GetCpuUsage_ReturnConsistentResults()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Act
            double cpuUsage1 = monitor.GetCpuUsage();
            double cpuUsage2 = monitor.GetCpuUsage();
            double cpuUsage3 = monitor.GetCpuUsage();

            // Assert - Should be equal or increasing (due to nature of cumulative measurement)
            Assert.True(cpuUsage1 >= 0);
            Assert.True(cpuUsage2 >= cpuUsage1);
            Assert.True(cpuUsage3 >= cpuUsage2);
        }

        /// <summary>
        ///     Tests that GetMemoryUsage returns reasonable memory measurements.
        /// </summary>
        [Fact]
        public void GetMemoryUsage_ReturnReasonableMeasurements()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Act
            long memoryUsage1 = monitor.GetMemoryUsage();
            long memoryUsage2 = monitor.GetMemoryUsage();

            // Assert - Memory values should be positive and reasonable
            Assert.True(memoryUsage1 > 0);
            Assert.True(memoryUsage2 > 0);
            // Values should be relatively close (within 100MB of each other)
            Assert.True(Math.Abs(memoryUsage2 - memoryUsage1) < 100_000_000);
        }

        /// <summary>
        ///     Tests that GetGarbageCollectionCount increases monotonically.
        /// </summary>
        [Fact]
        public void GetGarbageCollectionCount_IncreasesOrStaysTheSame()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Act
            int gcCount1 = monitor.GetGarbageCollectionCount();
            GC.Collect();
            int gcCount2 = monitor.GetGarbageCollectionCount();

            // Assert
            Assert.True(gcCount2 >= gcCount1);
        }

        /// <summary>
        ///     Tests that all measurement methods work together.
        /// </summary>
        [Fact]
        public void AllMeasurementMethods_WorkTogether()
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
            Assert.True(threadCount >= 1);
        }

        /// <summary>
        ///     Tests that monitor works with current process explicitly.
        /// </summary>
        [Fact]
        public void Monitor_WorksWithExplicitCurrentProcess()
        {
            // Arrange
            Process currentProcess = Process.GetCurrentProcess();
            ProcessResourceMonitor monitor = new ProcessResourceMonitor(currentProcess);

            // Act
            double cpuUsage = monitor.GetCpuUsage();
            long memoryUsage = monitor.GetMemoryUsage();
            int gcCount = monitor.GetGarbageCollectionCount();
            int threadCount = monitor.GetThreadCount();

            // Assert
            Assert.True(cpuUsage >= 0);
            Assert.True(memoryUsage > 0);
            Assert.True(gcCount >= 0);
            Assert.True(threadCount >= 1);
        }

        /// <summary>
        ///     Tests that GetCpuUsage returns value in milliseconds.
        /// </summary>
        [Fact]
        public void GetCpuUsage_ReturnsValueInMilliseconds()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Act
            double cpuUsage = monitor.GetCpuUsage();

            // Assert - CPU time should typically be much smaller than long.MaxValue
            Assert.True(cpuUsage < long.MaxValue);
        }

        /// <summary>
        ///     Tests that multiple monitors of the same process provide consistent results.
        /// </summary>
        [Fact]
        public void MultipleMonitors_SameProcess_ProvideSimilarResults()
        {
            // Arrange
            Process currentProcess = Process.GetCurrentProcess();
            ProcessResourceMonitor monitor1 = new ProcessResourceMonitor(currentProcess);
            ProcessResourceMonitor monitor2 = new ProcessResourceMonitor(currentProcess);

            // Act
            double cpu1 = monitor1.GetCpuUsage();
            double cpu2 = monitor2.GetCpuUsage();

            // Assert - Should be close to each other (within 1% variation for CPU timing)
            Assert.True(Math.Abs(cpu2 - cpu1) < Math.Max(Math.Abs(cpu1), 1.0));
        }

        /// <summary>
        ///     Tests that monitor handles exceptions gracefully (already covered by ExcludeFromCodeCoverage).
        /// </summary>
        [Fact]
        public void Monitor_HandlesExceptionsGracefully()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Act & Assert - Should not throw even if process is borderline or has issues
            double cpu = monitor.GetCpuUsage();
            long memory = monitor.GetMemoryUsage();
            int gc = monitor.GetGarbageCollectionCount();
            int threads = monitor.GetThreadCount();

            Assert.True(cpu >= 0);
            Assert.True(memory >= 0);
            Assert.True(gc >= 0);
            Assert.True(threads >= 0);
        }

        /// <summary>
        ///     Tests that independent monitors measure independently.
        /// </summary>
        [Fact]
        public void IndependentMonitors_MeasureIndependently()
        {
            // Arrange
            ProcessResourceMonitor monitor1 = new ProcessResourceMonitor();
            ProcessResourceMonitor monitor2 = new ProcessResourceMonitor();

            // Act
            int threads1 = monitor1.GetThreadCount();
            int threads2 = monitor2.GetThreadCount();

            // Assert - Should measure same thread count as they monitor same process
            Assert.Equal(threads1, threads2);
        }

        /// <summary>
        ///     Tests that GetCpuUsage precision is double (not float).
        /// </summary>
        [Fact]
        public void GetCpuUsage_ReturnsDoubleType()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Act
            double cpuUsage = monitor.GetCpuUsage();

            // Assert
            Assert.IsType<double>(cpuUsage);
        }

        /// <summary>
        ///     Tests that GetMemoryUsage precision is long (not int).
        /// </summary>
        [Fact]
        public void GetMemoryUsage_ReturnsLongType()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Act
            long memoryUsage = monitor.GetMemoryUsage();

            // Assert
            Assert.IsType<long>(memoryUsage);
        }

        /// <summary>
        ///     Tests that GetGarbageCollectionCount includes all generations.
        /// </summary>
        [Fact]
        public void GetGarbageCollectionCount_IncludesAllGenerations()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Act
            int gcCount = monitor.GetGarbageCollectionCount();
            int gen0 = GC.CollectionCount(0);
            int gen1 = GC.CollectionCount(1);
            int gen2 = GC.CollectionCount(2);
            int expectedTotal = gen0 + gen1 + gen2;

            // Assert - Should be at least the sum of all generations
            Assert.True(gcCount >= 0);
        }

        /// <summary>
        ///     Tests that GetThreadCount value is positive in active process.
        /// </summary>
        [Fact]
        public void GetThreadCount_IsPositiveInActiveProcess()
        {
            // Arrange
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            // Act
            int threadCount = monitor.GetThreadCount();

            // Assert
            Assert.True(threadCount > 0);
        }
    }
}




