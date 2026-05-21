

using Alis.Core.Aspect.Logging.Abstractions;

namespace Alis.Core.Aspect.Logging.Filters
{
    /// <summary>
    ///     Filters log entries based on their severity level.
    ///     Only entries with level >= minimum level pass through.
    ///     AOT-compatible: Simple value comparison.
    /// </summary>
    public sealed class LogLevelFilter : ILogFilter
    {
        /// <summary>
        ///     The minimum level
        /// </summary>
        private readonly LogLevel _minimumLevel;

        /// <summary>
        ///     Initializes a new instance of the LogLevelFilter class.
        /// </summary>
        /// <param name="minimumLevel">The minimum level to accept.</param>
        public LogLevelFilter(LogLevel minimumLevel) => _minimumLevel = minimumLevel;


        /// <summary>
        ///     Gets a human-readable name for this filter.
        /// </summary>
        public string Name => $"LogLevelFilter[{_minimumLevel}]";


        /// <summary>
        ///     Determines whether the specified entry meets the minimum level threshold.
        /// </summary>
        /// <param name="entry">The log entry to evaluate.</param>
        /// <returns>True if the entry meets the minimum level; false otherwise.</returns>
        public bool ShouldLog(ILogEntry entry) => entry?.Level >= _minimumLevel;
    }
}