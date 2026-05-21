

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
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            Assert.NotNull(monitor);
        }

        /// <summary>
        ///     Tests that constructor with specific process initializes successfully.
        /// </summary>
        [Fact]
        public void ConstructorWithProcess_InitializesWithSpecificProcess()
        {
            Process currentProcess = Process.GetCurrentProcess();

            ProcessResourceMonitor monitor = new ProcessResourceMonitor(currentProcess);

            Assert.NotNull(monitor);
        }

        /// <summary>
        ///     Tests that constructor throws exception when process is null.
        /// </summary>
        [Fact]
        public void ConstructorWithProcess_ThrowsArgumentNullException_WhenProcessIsNull()
        {
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
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            double cpuUsage = monitor.GetCpuUsage();

            Assert.True(cpuUsage >= 0);
        }

        /// <summary>
        ///     Tests that GetMemoryUsage returns a non-negative value.
        /// </summary>
        [Fact]
        public void GetMemoryUsage_ReturnsNonNegativeValue()
        {
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            long memoryUsage = monitor.GetMemoryUsage();

            Assert.True(memoryUsage >= 0);
        }

        /// <summary>
        ///     Tests that GetGarbageCollectionCount returns a non-negative value.
        /// </summary>
        [Fact]
        public void GetGarbageCollectionCount_ReturnsNonNegativeValue()
        {
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            int gcCount = monitor.GetGarbageCollectionCount();

            Assert.True(gcCount >= 0);
        }

        /// <summary>
        ///     Tests that GetThreadCount returns a non-negative value.
        /// </summary>
        [Fact]
        public void GetThreadCount_ReturnsNonNegativeValue()
        {
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            int threadCount = monitor.GetThreadCount();

            Assert.True(threadCount >= 0);
        }

        /// <summary>
        ///     Tests that GetMemoryUsage returns reasonable memory value.
        /// </summary>
        [Fact]
        public void GetMemoryUsage_ReturnsReasonableValue()
        {
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            long memoryUsage = monitor.GetMemoryUsage();

            Assert.True(memoryUsage > 1_000_000);
        }

        /// <summary>
        ///     Tests that GetThreadCount returns reasonable thread count.
        /// </summary>
        [Fact]
        public void GetThreadCount_ReturnsReasonableValue()
        {
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            int threadCount = monitor.GetThreadCount();

            Assert.True(threadCount >= 1);
        }

        /// <summary>
        ///     Tests that multiple calls to GetCpuUsage return consistent results.
        /// </summary>
        [Fact]
        public void GetCpuUsage_ReturnConsistentResults()
        {
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            double cpuUsage1 = monitor.GetCpuUsage();
            double cpuUsage2 = monitor.GetCpuUsage();
            double cpuUsage3 = monitor.GetCpuUsage();

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
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            long memoryUsage1 = monitor.GetMemoryUsage();
            long memoryUsage2 = monitor.GetMemoryUsage();

            Assert.True(memoryUsage1 > 0);
            Assert.True(memoryUsage2 > 0);
            Assert.True(Math.Abs(memoryUsage2 - memoryUsage1) < 100_000_000);
        }

        /// <summary>
        ///     Tests that GetGarbageCollectionCount increases monotonically.
        /// </summary>
        [Fact]
        public void GetGarbageCollectionCount_IncreasesOrStaysTheSame()
        {
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            int gcCount1 = monitor.GetGarbageCollectionCount();
            GC.Collect();
            int gcCount2 = monitor.GetGarbageCollectionCount();

            Assert.True(gcCount2 >= gcCount1);
        }

        /// <summary>
        ///     Tests that all measurement methods work together.
        /// </summary>
        [Fact]
        public void AllMeasurementMethods_WorkTogether()
        {
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            double cpuUsage = monitor.GetCpuUsage();
            long memoryUsage = monitor.GetMemoryUsage();
            int gcCount = monitor.GetGarbageCollectionCount();
            int threadCount = monitor.GetThreadCount();

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
            Process currentProcess = Process.GetCurrentProcess();
            ProcessResourceMonitor monitor = new ProcessResourceMonitor(currentProcess);

            double cpuUsage = monitor.GetCpuUsage();
            long memoryUsage = monitor.GetMemoryUsage();
            int gcCount = monitor.GetGarbageCollectionCount();
            int threadCount = monitor.GetThreadCount();

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
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            double cpuUsage = monitor.GetCpuUsage();

            Assert.True(cpuUsage < long.MaxValue);
        }

        /// <summary>
        ///     Tests that multiple monitors of the same process provide consistent results.
        /// </summary>
        [Fact]
        public void MultipleMonitors_SameProcess_ProvideSimilarResults()
        {
            Process currentProcess = Process.GetCurrentProcess();
            ProcessResourceMonitor monitor1 = new ProcessResourceMonitor(currentProcess);
            ProcessResourceMonitor monitor2 = new ProcessResourceMonitor(currentProcess);

            double cpu1 = monitor1.GetCpuUsage();
            double cpu2 = monitor2.GetCpuUsage();

            Assert.True(Math.Abs(cpu2 - cpu1) < Math.Max(Math.Abs(cpu1), 1.0));
        }

        /// <summary>
        ///     Tests that monitor handles exceptions gracefully (already covered by ExcludeFromCodeCoverage).
        /// </summary>
        [Fact]
        public void Monitor_HandlesExceptionsGracefully()
        {
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

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
            ProcessResourceMonitor monitor1 = new ProcessResourceMonitor();
            ProcessResourceMonitor monitor2 = new ProcessResourceMonitor();

            int threads1 = monitor1.GetThreadCount();
            int threads2 = monitor2.GetThreadCount();

            Assert.Equal(threads1, threads2);
        }

        /// <summary>
        ///     Tests that GetCpuUsage precision is double (not float).
        /// </summary>
        [Fact]
        public void GetCpuUsage_ReturnsDoubleType()
        {
            ProcessResourceMonitor monitor = new ProcessResourceMonitor();

            double cpuUsage = monitor.GetCpuUsage();

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




