// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LogEntry.cs
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
using System.Collections.Generic;
using System.Threading;
using Alis.Core.Aspect.Logging.Abstractions;

namespace Alis.Core.Aspect.Logging.Core
{
    /// <summary>
    ///     Default implementation of ILogEntry containing all log data.
    ///     Immutable after creation to ensure thread safety.
    ///     AOT-compatible: No reflection, value-based semantics.
    /// </summary>
    public sealed class LogEntry : ILogEntry
    {
        /// <summary>
        ///     Initializes a new instance of the LogEntry class with the specified log data.
        ///     The timestamp and thread ID are automatically captured at creation time.
        /// </summary>
        /// <param name="level">The severity level of this log entry.</param>
        /// <param name="message">The log message content. If null, defaults to an empty string.</param>
        /// <param name="loggerName">The name of the logger creating this entry. If null, defaults to an empty string.</param>
        /// <param name="exception">The exception to associate with this entry, or null if none.</param>
        /// <param name="correlationId">The correlation ID for tracing requests across components, or null.</param>
        /// <param name="properties">Structured key-value data for this log entry, or null for none.</param>
        /// <param name="scopes">The scope context objects, or null for none.</param>
        public LogEntry(
            LogLevel level,
            string message,
            string loggerName,
            Exception exception = null,
            string correlationId = null,
            IReadOnlyDictionary<string, object> properties = null,
            IReadOnlyList<object> scopes = null)
        {
            Level = level;
            Message = message ?? string.Empty;
            LoggerName = loggerName ?? string.Empty;
            Exception = exception;
            Timestamp = DateTime.UtcNow;
            ThreadId = Thread.CurrentThread.ManagedThreadId;
            CorrelationId = correlationId;
            Properties = properties ?? new Dictionary<string, object>();
            Scopes = scopes ?? new List<object>();
        }


        /// <summary>
        ///     Gets the severity level of this log entry.
        /// </summary>
        public LogLevel Level { get; }


        /// <summary>
        ///     Gets the primary log message text.
        /// </summary>
        public string Message { get; }


        /// <summary>
        ///     Gets the UTC timestamp when this log entry was created.
        /// </summary>
        public DateTime Timestamp { get; }


        /// <summary>
        ///     Gets the name of the logger that created this entry.
        /// </summary>
        public string LoggerName { get; }


        /// <summary>
        ///     Gets the exception associated with this entry, if any; otherwise null.
        /// </summary>
        public Exception Exception { get; }


        /// <summary>
        ///     Gets the managed thread ID of the thread that created this entry.
        /// </summary>
        public int ThreadId { get; }


        /// <summary>
        ///     Gets the correlation ID for tracing related log entries across components.
        /// </summary>
        public string CorrelationId { get; }


        /// <summary>
        ///     Gets the structured key-value properties attached to this log entry.
        /// </summary>
        public IReadOnlyDictionary<string, object> Properties { get; }


        /// <summary>
        ///     Gets the scope context stack associated with this log entry.
        /// </summary>
        public IReadOnlyList<object> Scopes { get; }
    }
}