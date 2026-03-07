// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LoggerNameFilter.cs
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
        ///     Gets the value of the name
        /// </summary>
        public string Name => $"LoggerNameFilter[{(_inclusive ? "Include" : "Exclude")}:{_includedNames.Count}]";


        /// <summary>
        ///     Shoulds the log using the specified entry
        /// </summary>
        /// <param name="entry">The entry</param>
        /// <returns>The bool</returns>
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