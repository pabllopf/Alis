

namespace Alis.Extension.Profile.Interfaces
{
    /// <summary>
    ///     Defines the contract for monitoring system resources such as CPU and memory usage.
    ///     Implementations of this interface provide platform-specific or custom strategies
    ///     for measuring resource consumption during profiling operations.
    /// </summary>
    public interface IResourceMonitor
    {
        /// <summary>
        ///     Measures the current CPU usage of the process.
        /// </summary>
        /// <returns>
        ///     A <see cref="double" /> representing the CPU usage as a percentage (0-100)
        ///     or in milliseconds depending on the implementation strategy.
        /// </returns>
        double GetCpuUsage();

        /// <summary>
        ///     Measures the current memory usage of the process.
        /// </summary>
        /// <returns>
        ///     A <see cref="long" /> representing the memory usage in bytes.
        /// </returns>
        long GetMemoryUsage();

        /// <summary>
        ///     Gets the total number of garbage collections that have occurred
        ///     for all generations since the process started.
        /// </summary>
        /// <returns>
        ///     An <see cref="int" /> representing the total garbage collection count.
        /// </returns>
        int GetGarbageCollectionCount();

        /// <summary>
        ///     Gets the total number of threads currently active in the process.
        /// </summary>
        /// <returns>
        ///     An <see cref="int" /> representing the thread count.
        /// </returns>
        int GetThreadCount();
    }
}