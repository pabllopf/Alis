// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ConditionalLogFilter.cs
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
        /// The predicate
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
        /// Gets the value of the name
        /// </summary>
        public string Name { get; }

        
        /// <summary>
        /// Shoulds the log using the specified entry
        /// </summary>
        /// <param name="entry">The entry</param>
        /// <returns>The bool</returns>
        public bool ShouldLog(ILogEntry entry)
        {
            try
            {
                return _predicate(entry);
            }
            catch
            {
                // Prevent filter errors from affecting logging
                return true;
            }
        }
    }
}