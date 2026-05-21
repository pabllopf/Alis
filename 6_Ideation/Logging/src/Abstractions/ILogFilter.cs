

namespace Alis.Core.Aspect.Logging.Abstractions
{
    /// <summary>
    ///     Determines whether a log entry should be processed and written.
    ///     Filters allow fine-grained control over which logs are captured.
    ///     AOT-compatible: No reflection, pure functional filtering.
    /// </summary>
    public interface ILogFilter
    {
        /// <summary>
        ///     Gets a human-readable name for this filter.
        /// </summary>
        /// <value>The human-readable name of this filter.</value>
        string Name { get; }

        /// <summary>
        ///     Evaluates whether the given log entry should be processed.
        ///     Returning false prevents the entry from being written to outputs.
        /// </summary>
        /// <param name="entry">The log entry to filter.</param>
        /// <returns>True if the entry should be logged; false if it should be skipped.</returns>
        bool ShouldLog(ILogEntry entry);
    }
}