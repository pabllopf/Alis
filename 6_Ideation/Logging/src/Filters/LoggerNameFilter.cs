

using System.Collections.Generic;
using Alis.Core.Aspect.Logging.Abstractions;

namespace Alis.Core.Aspect.Logging.Filters
{
    /// <summary>
    ///     Filters log entries based on logger name (category).
    ///     Supports filtering by exact match or prefix.
    ///     AOT-compatible: String comparison only.
    /// </summary>
    public sealed class LoggerNameFilter : ILogFilter
    {
        /// <summary>
        ///     The included names
        /// </summary>
        private readonly HashSet<string> _includedNames;

        /// <summary>
        ///     The inclusive
        /// </summary>
        private readonly bool _inclusive;

        /// <summary>
        ///     Initializes a new instance of the LoggerNameFilter class.
        /// </summary>
        /// <param name="loggerNames">Logger names to filter by.</param>
        /// <param name="inclusive">If true, only these names are included. If false, these names are excluded.</param>
        public LoggerNameFilter(IEnumerable<string> loggerNames, bool inclusive = true)
        {
            _includedNames = new HashSet<string>(loggerNames ?? new List<string>());
            _inclusive = inclusive;
        }


        /// <summary>
        ///     Gets a human-readable name for this filter.
        /// </summary>
        public string Name => $"LoggerNameFilter[{(_inclusive ? "Include" : "Exclude")}:{_includedNames.Count}]";


        /// <summary>
        ///     Determines whether the specified entry matches the configured logger names.
        /// </summary>
        /// <param name="entry">The log entry to evaluate.</param>
        /// <returns>True if the entry matches the name filter rules; false otherwise.</returns>
        public bool ShouldLog(ILogEntry entry)
        {
            if (entry == null || _includedNames.Count == 0)
            {
                return true;
            }

            bool matches = _includedNames.Contains(entry.LoggerName);
            return _inclusive ? matches : !matches;
        }
    }
}