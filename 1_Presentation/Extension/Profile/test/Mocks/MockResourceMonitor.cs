

using Alis.Extension.Profile.Interfaces;

namespace Alis.Extension.Profile.Test.Mocks
{
    /// <summary>
    ///     Mock implementation of <see cref="IResourceMonitor" /> for testing purposes.
    ///     This class allows tests to control resource metrics values and verify method calls.
    /// </summary>
    public class MockResourceMonitor : IResourceMonitor
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MockResourceMonitor" /> class.
        /// </summary>
        public MockResourceMonitor()
        {
            CpuUsage = 0;
            MemoryUsage = 0;
            GarbageCollectionCount = 0;
            ThreadCount = 0;
        }

        /// <summary>
        ///     Gets or sets the CPU usage value to return.
        /// </summary>
        public double CpuUsage { get; set; }

        /// <summary>
        ///     Gets or sets the memory usage value to return.
        /// </summary>
        public long MemoryUsage { get; set; }

        /// <summary>
        ///     Gets or sets the garbage collection count value to return.
        /// </summary>
        public int GarbageCollectionCount { get; set; }

        /// <summary>
        ///     Gets or sets the thread count value to return.
        /// </summary>
        public int ThreadCount { get; set; }

        /// <summary>
        ///     Gets a value indicating whether GetCpuUsage was called.
        /// </summary>
        public bool GetCpuUsageCalled { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether GetMemoryUsage was called.
        /// </summary>
        public bool GetMemoryUsageCalled { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether GetGarbageCollectionCount was called.
        /// </summary>
        public bool GetGarbageCollectionCountCalled { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether GetThreadCount was called.
        /// </summary>
        public bool GetThreadCountCalled { get; private set; }

        /// <summary>
        ///     Gets the configured CPU usage value and marks the method as called.
        /// </summary>
        /// <returns>The configured CPU usage value.</returns>
        public double GetCpuUsage()
        {
            GetCpuUsageCalled = true;
            return CpuUsage;
        }

        /// <summary>
        ///     Gets the configured memory usage value and marks the method as called.
        /// </summary>
        /// <returns>The configured memory usage value.</returns>
        public long GetMemoryUsage()
        {
            GetMemoryUsageCalled = true;
            return MemoryUsage;
        }

        /// <summary>
        ///     Gets the configured garbage collection count and marks the method as called.
        /// </summary>
        /// <returns>The configured garbage collection count.</returns>
        public int GetGarbageCollectionCount()
        {
            GetGarbageCollectionCountCalled = true;
            return GarbageCollectionCount;
        }

        /// <summary>
        ///     Gets the configured thread count and marks the method as called.
        /// </summary>
        /// <returns>The configured thread count.</returns>
        public int GetThreadCount()
        {
            GetThreadCountCalled = true;
            return ThreadCount;
        }

        /// <summary>
        ///     Resets all call tracking flags.
        /// </summary>
        public void ResetCallTracking()
        {
            GetCpuUsageCalled = false;
            GetMemoryUsageCalled = false;
            GetGarbageCollectionCountCalled = false;
            GetThreadCountCalled = false;
        }
    }
}