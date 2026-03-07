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
        ///     Initializes a new instance of the LogEntry class.
        /// </summary>
        /// <param name="level">The log level.</param>
        /// <param name="message">The log message.</param>
        /// <param name="loggerName">The logger name.</param>
        /// <param name="exception">The exception, if any.</param>
        /// <param name="correlationId">The correlation ID for tracing.</param>
        /// <param name="properties">Structured properties of the log.</param>
        /// <param name="scopes">The scope stack.</param>
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
        ///     Gets the value of the level
        /// </summary>
        public LogLevel Level { get; }


        /// <summary>
        ///     Gets the value of the message
        /// </summary>
        public string Message { get; }


        /// <summary>
        ///     Gets the value of the timestamp
        /// </summary>
        public DateTime Timestamp { get; }


        /// <summary>
        ///     Gets the value of the logger name
        /// </summary>
        public string LoggerName { get; }


        /// <summary>
        ///     Gets the value of the exception
        /// </summary>
        public Exception Exception { get; }


        /// <summary>
        ///     Gets the value of the thread id
        /// </summary>
        public int ThreadId { get; }


        /// <summary>
        ///     Gets the value of the correlation id
        /// </summary>
        public string CorrelationId { get; }


        /// <summary>
        ///     Gets the value of the properties
        /// </summary>
        public IReadOnlyDictionary<string, object> Properties { get; }


        /// <summary>
        ///     Gets the value of the scopes
        /// </summary>
        public IReadOnlyList<object> Scopes { get; }
    }
}