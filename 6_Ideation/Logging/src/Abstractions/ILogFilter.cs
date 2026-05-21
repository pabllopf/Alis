// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ILogFilter.cs
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