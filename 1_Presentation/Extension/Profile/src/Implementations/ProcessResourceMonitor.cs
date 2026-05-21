

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Alis.Extension.Profile.Interfaces;

namespace Alis.Extension.Profile.Implementations
{
    /// <summary>
    ///     Monitors system resources for the current process using the <see cref="Process" /> API.
    ///     This implementation provides cross-platform resource monitoring capabilities
    ///     for CPU, memory, garbage collection, and thread metrics.
    /// </summary>
    public class ProcessResourceMonitor : IResourceMonitor
    {
        /// <summary>
        ///     The process instance to monitor. Defaults to the current process.
        /// </summary>
        private readonly Process process;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProcessResourceMonitor" /> class
        ///     that monitors the current process.
        /// </summary>
        public ProcessResourceMonitor() : this(Process.GetCurrentProcess())
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProcessResourceMonitor" /> class
        ///     with a specific process to monitor.
        /// </summary>
        /// <param name="process">The process to monitor.</param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when process is null.
        /// </exception>
        public ProcessResourceMonitor(Process process) => this.process = process ?? throw new ArgumentNullException(nameof(process));

        /// <summary>
        ///     Measures the current CPU usage of the process.
        ///     Returns the total processor time in milliseconds consumed by the process.
        /// </summary>
        /// <returns>
        ///     A <see cref="double" /> representing the CPU time in milliseconds.
        /// </returns>
        [ExcludeFromCodeCoverage]
        public double GetCpuUsage()
        {
            try
            {
                return process.TotalProcessorTime.TotalMilliseconds;
            }
            catch (InvalidOperationException)
            {
                return 0;
            }
        }

        /// <summary>
        ///     Measures the current memory usage of the process.
        ///     Returns the working set size (physical memory used) in bytes.
        /// </summary>
        /// <returns>
        ///     A <see cref="long" /> representing the memory usage in bytes.
        /// </returns>
        [ExcludeFromCodeCoverage]
        public long GetMemoryUsage()
        {
            try
            {
                return process.WorkingSet64;
            }
            catch (InvalidOperationException)
            {
                return 0;
            }
        }

        /// <summary>
        ///     Gets the total number of garbage collections that have occurred
        ///     for all generations (0, 1, and 2) since the process started.
        /// </summary>
        /// <returns>
        ///     An <see cref="int" /> representing the total garbage collection count.
        /// </returns>
        [ExcludeFromCodeCoverage]
        public int GetGarbageCollectionCount()
        {
            int gen0 = GC.CollectionCount(0);
            int gen1 = GC.CollectionCount(1);
            int gen2 = GC.CollectionCount(2);
            return gen0 + gen1 + gen2;
        }

        /// <summary>
        ///     Gets the total number of threads currently active in the process.
        /// </summary>
        /// <returns>
        ///     An <see cref="int" /> representing the thread count.
        /// </returns>
        [ExcludeFromCodeCoverage]
        public int GetThreadCount()
        {
            try
            {
                return process.Threads.Count;
            }
            catch (InvalidOperationException)
            {
                return 0;
            }
        }
    }
}