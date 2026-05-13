// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ILogOutput.cs
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

namespace Alis.Core.Aspect.Logging.Abstractions
{
    /// <summary>
    ///     Represents a destination where log entries are written.
    ///     Implementations define how and where logs are persisted or displayed.
    ///     AOT-compatible: No reflection, no dynamic dispatch beyond virtuals.
    /// </summary>
    public interface ILogOutput : IDisposable
    {
        /// <summary>
        ///     Gets a human-readable name for this output destination.
        /// </summary>
        /// <value>The human-readable name of this output destination.</value>
        string Name { get; }

        /// <summary>
        ///     Gets a value indicating whether this output is currently enabled.
        /// </summary>
        /// <value>True if this output is accepting log entries; false otherwise.</value>
        bool IsEnabled { get; internal set; }

        /// <summary>
        ///     Writes the given log entry to this output destination.
        ///     Implementations must be thread-safe and handle errors gracefully.
        /// </summary>
        /// <param name="entry">The log entry to write.</param>
        void Write(ILogEntry entry);

        /// <summary>
        ///     Flushes any buffered data to the output destination.
        ///     Called before application shutdown or on demand.
        /// </summary>
        void Flush();
    }
}