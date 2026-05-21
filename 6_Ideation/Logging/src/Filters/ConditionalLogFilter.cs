

using System;
using Alis.Core.Aspect.Logging.Abstractions;

namespace Alis.Core.Aspect.Logging.Filters
{
    /// <summary>
    ///     Filters log entries based on a custom predicate function.
    ///     Allows flexible, application-specific filtering logic.
    ///     AOT-compatible: Uses delegate-based logic.
    /// </summary>
    public sealed class ConditionalLogFilter : ILogFilter
    {
        /// <summary>
        ///     The predicate
        /// </summary>
        private readonly Func<ILogEntry, bool> _predicate;

        /// <summary>
        ///     Initializes a new instance of the ConditionalLogFilter class.
        /// </summary>
        /// <param name="predicate">The filtering predicate.</param>
        /// <param name="name">Optional name for this filter.</param>
        public ConditionalLogFilter(Func<ILogEntry, bool> predicate, string name = "ConditionalFilter")
        {
            _predicate = predicate ?? throw new ArgumentNullException(nameof(predicate));
            Name = name;
        }


        /// <summary>
        ///     Gets a human-readable name for this filter.
        /// </summary>
        public string Name { get; }


        /// <summary>
        ///     Determines whether the specified entry passes the custom predicate function.
        /// </summary>
        /// <param name="entry">The log entry to evaluate.</param>
        /// <returns>True if the entry passes the predicate; false otherwise.</returns>
        public bool ShouldLog(ILogEntry entry)
        {
            try
            {
                return _predicate(entry);
            }
            catch
            {
                return true;
            }
        }
    }
}