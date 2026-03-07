// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CompositeLogFilter.cs
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

using System.Collections.Generic;
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
        /// The filters
        /// </summary>
        private readonly List<ILogFilter> _filters;
        /// <summary>
        /// The require all
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
        /// Gets the value of the name
        /// </summary>
        public string Name => $"CompositeFilter[{(_requireAll ? "AND" : "OR")}:{_filters.Count}]";

        
        /// <summary>
        /// Shoulds the log using the specified entry
        /// </summary>
        /// <param name="entry">The entry</param>
        /// <returns>The bool</returns>
        public bool ShouldLog(ILogEntry entry)
        {
            if (entry == null || _filters.Count == 0)
            {
                return true;
            }

            if (_requireAll)
            {
                // AND logic: all must pass
                foreach (ILogFilter filter in _filters)
                {
                    if (!filter.ShouldLog(entry))
                    {
                        return false;
                    }
                }

                return true;
            }

            // OR logic: at least one must pass
            foreach (ILogFilter filter in _filters)
            {
                if (filter.ShouldLog(entry))
                {
                    return true;
                }
            }

            return false;
        }
    }
}