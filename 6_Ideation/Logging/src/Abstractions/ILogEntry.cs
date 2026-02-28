// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: ILogEntry.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web: https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program. If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Alis.Core.Aspect.Logging.Abstractions
{
    /// <summary>
    ///     Represents a single log entry with all relevant contextual information.
    ///     This interface defines the contract for log data passed through the logging system.
    /// </summary>
    public interface ILogEntry
    {
        /// <summary>
        ///     Gets the log level indicating severity of this entry.
        /// </summary>
        LogLevel Level { get; }

        /// <summary>
        ///     Gets the primary message of the log entry.
        /// </summary>
        string Message { get; }

        /// <summary>
        ///     Gets the timestamp when the log entry was created.
        /// </summary>
        DateTime Timestamp { get; }

        /// <summary>
        ///     Gets the name/category of the logger that created this entry.
        /// </summary>
        string LoggerName { get; }

        /// <summary>
        ///     Gets the exception associated with this entry, if any.
        /// </summary>
        Exception Exception { get; }

        /// <summary>
        ///     Gets the thread ID where the log entry was created.
        /// </summary>
        int ThreadId { get; }

        /// <summary>
        ///     Gets the correlation ID for tracing related log entries.
        /// </summary>
        string CorrelationId { get; }

        /// <summary>
        ///     Gets the structured data (key-value pairs) associated with this entry.
        /// </summary>
        IReadOnlyDictionary<string, object> Properties { get; }

        /// <summary>
        ///     Gets the scope/context information for this log entry.
        /// </summary>
        IReadOnlyList<object> Scopes { get; }
    }
}

