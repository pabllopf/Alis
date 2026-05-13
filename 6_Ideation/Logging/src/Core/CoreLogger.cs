// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CoreLogger.cs
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
using System.Diagnostics.CodeAnalysis;
using Alis.Core.Aspect.Logging.Abstractions;

namespace Alis.Core.Aspect.Logging.Core
{
    /// <summary>
    ///     Core implementation of ILogger providing structured logging with support for
    ///     multiple outputs, filters, scopes, and correlation tracking.
    ///     Thread-safe: Uses locks for scope and correlation ID management.
    ///     AOT-compatible: No reflection, pure interface-based design.
    /// </summary>
    internal sealed class CoreLogger : ILogger
    {
        /// <summary>
        ///     The correlation lock
        /// </summary>
        private readonly object _correlationLock = new object();

        /// <summary>
        ///     The filters
        /// </summary>
        private readonly List<ILogFilter> _filters;

        /// <summary>
        ///     The formatter
        /// </summary>
        private readonly ILogFormatter _formatter;

        /// <summary>
        ///     The minimum level
        /// </summary>
        private readonly LogLevel _minimumLevel;

        /// <summary>
        ///     The outputs
        /// </summary>
        private readonly List<ILogOutput> _outputs;

        /// <summary>
        ///     The scope lock
        /// </summary>
        private readonly object _scopeLock = new object();

        /// <summary>
        ///     The scope stack
        /// </summary>
        private readonly Stack<object> _scopeStack;

        /// <summary>
        ///     Gets the logical name of this logger (typically the component/class name).
        /// </summary>
        /// <value>The logical name of this logger.</value>
        public string Name { get; }

        /// <summary>
        ///     Logs a message with Error severity.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogError(string message) => Log(LogLevel.Error, message);

        /// <summary>
        ///     Logs a message with Critical severity.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogCritical(string message) => Log(LogLevel.Critical, message);


        /// <summary>
        ///     Logs a message with an associated exception at Error level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="exception">The exception to include in the log.</param>
        public void LogError(string message, Exception exception) => Log(LogLevel.Error, message, exception);

        /// <summary>
        ///     Logs a message with an associated exception at Critical level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="exception">The exception to include in the log.</param>
        public void LogCritical(string message, Exception exception) => Log(LogLevel.Critical, message, exception);


        /// <summary>
        ///     Logs the level
        /// </summary>
        /// <param name="level">The level</param>
        /// <param name="message">The message</param>
        public void Log(LogLevel level, string message)
        {
            Log(level, message, null);
        }


        /// <summary>
        ///     Logs a message at the specified level.
        /// </summary>
        /// <param name="level">The severity level of the log.</param>
        /// <param name="message">The message to log.</param>
        public void Log(LogLevel level, string message)
        {
            Log(level, message, null);
        }

        /// <summary>
        ///     Logs a message at the specified level with an associated exception.
        /// </summary>
        /// <param name="level">The severity level of the log.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="exception">The exception to include in the log.</param>
        public void Log(LogLevel level, string message, Exception exception)
        {
            if (!IsEnabled(level))
            {
                return;
            }

            IReadOnlyList<object> scopes = GetCurrentScopes();
            string correlationId = GetCorrelationIdInternal();

            LogEntry entry = new LogEntry(
                level,
                message,
                Name,
                exception,
                correlationId,
                null,
                scopes);

            ProcessEntry(entry);
        }

        /// <summary>
        ///     Logs a structured message with additional properties.
        /// </summary>
        /// <param name="level">The severity level of the log.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="properties">Key-value pairs of contextual data.</param>
        [ExcludeFromCodeCoverage]
        public void LogStructured(LogLevel level, string message, IReadOnlyDictionary<string, object> properties)
        {
            if (!IsEnabled(level))
            {
                return;
            }

            if (properties == null)
            {
                Log(level, message);
                return;
            }

            IReadOnlyList<object> scopes = GetCurrentScopes();
            string correlationId = GetCorrelationIdInternal();

            LogEntry entry = new LogEntry(
                level,
                message,
                Name,
                null,
                correlationId,
                properties,
                scopes);

            ProcessEntry(entry);
        }


        /// <summary>
        ///     Sets the correlation ID for tracing related log entries.
        /// </summary>
        /// <param name="correlationId">The correlation ID, typically a GUID or request ID.</param>
        public void SetCorrelationId(string correlationId)
        {
            lock (_correlationLock)
            {
                _correlationId = correlationId;
            }
        }


        /// <summary>
        ///     Gets the current correlation ID.
        /// </summary>
        /// <returns>The correlation ID, or null if not set.</returns>
        public string GetCorrelationId()
        {
            lock (_correlationLock)
            {
                return _correlationId;
            }
        }


        /// <summary>
        ///     Begins a named scope for grouping related log entries.
        /// </summary>
        /// <param name="scope">The scope name or identifier.</param>
        /// <returns>A disposable that removes the scope when disposed.</returns>
        public IDisposable BeginScope(object scope)
        {
            lock (_scopeLock)
            {
                return new LoggerScope(scope, _scopeStack, () => { });
            }
        }


        /// <summary>
        ///     Determines whether logging is enabled at the given level.
        /// </summary>
        /// <param name="level">The log level to check.</param>
        /// <returns>True if the level is enabled; false otherwise.</returns>
        public bool IsEnabled(LogLevel level) => (level >= _minimumLevel) && (level != LogLevel.None);

        /// <summary>
        ///     Gets the current scope stack as a read-only list.
        /// </summary>
        private IReadOnlyList<object> GetCurrentScopes()
        {
            lock (_scopeLock)
            {
                return _scopeStack.Count > 0 ? new List<object>(_scopeStack) : new List<object>();
            }
        }

        /// <summary>
        ///     Gets the current correlation ID (internal, thread-safe version).
        /// </summary>
        private string GetCorrelationIdInternal()
        {
            lock (_correlationLock)
            {
                return _correlationId;
            }
        }

        /// <summary>
        ///     Processes a log entry through filters and outputs.
        /// </summary>
        [ExcludeFromCodeCoverage]
        private void ProcessEntry(ILogEntry entry)
        {
            try
            {
                // Apply filters
                foreach (ILogFilter filter in _filters)
                {
                    if (!filter.ShouldLog(entry))
                    {
                        return;
                    }
                }

                // Write to outputs
                foreach (ILogOutput output in _outputs)
                {
                    if (output.IsEnabled)
                    {
                        try
                        {
                            output.Write(entry);
                        }
                        catch
                        {
                            // Prevent one failing output from affecting others
                        }
                    }
                }
            }
            catch
            {
                // Prevent exceptions in logging from propagating
            }
        }
    }
}