

using System.Collections.Generic;
using System.Linq;
using Alis.Core.Aspect.Logging.Abstractions;

namespace Alis.Core.Aspect.Logging.Filters
{
    /// <summary>
    ///     Combines multiple filters with AND/OR logic.
    ///     Useful for complex filtering scenarios.
    ///     AOT-compatible: Uses interface composition.
    /// </summary>
    public sealed class CompositeLogFilter : ILogFilter
    {
        /// <summary>
        ///     The filters
        /// </summary>
        private readonly List<ILogFilter> _filters;

        /// <summary>
        ///     The require all
        /// </summary>
        private readonly bool _requireAll;

        /// <summary>
        ///     Initializes a new instance of the CompositeLogFilter class.
        /// </summary>
        /// <param name="filters">The filters to combine.</param>
        /// <param name="requireAll">If true, all filters must pass (AND). If false, any filter passing is sufficient (OR).</param>
        public CompositeLogFilter(IEnumerable<ILogFilter> filters, bool requireAll = true)
        {
            _filters = new List<ILogFilter>(filters ?? new List<ILogFilter>());
            _requireAll = requireAll;
        }


        /// <summary>
        ///     Gets a human-readable name for this filter.
        /// </summary>
        public string Name => $"CompositeFilter[{(_requireAll ? "AND" : "OR")}:{_filters.Count}]";


        /// <summary>
        ///     Determines whether the specified entry passes all (AND) or any (OR) combined filters.
        /// </summary>
        /// <param name="entry">The log entry to evaluate.</param>
        /// <returns>True if the entry passes the composite filter rules; false otherwise.</returns>
        public bool ShouldLog(ILogEntry entry)
        {
            if (entry == null || _filters.Count == 0)
            {
                return true;
            }

            if (_requireAll)
            {
                return _filters.All(filter => filter.ShouldLog(entry));
            }

            return _filters.Any(filter => filter.ShouldLog(entry));
        }
    }
}