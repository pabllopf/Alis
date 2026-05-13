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
        ///     Synchronization lock for thread-safe access to the correlation ID.
        /// </summary>
        private readonly object _correlationLock = new object();

        /// <summary>
        ///     The collection of filters to evaluate before writing log entries.
        /// </summary>
        private readonly List<ILogFilter> _filters;

        /// <summary>
        ///     The formatter used to convert log entries into strings for output.
        /// </summary>
        private readonly ILogFormatter _formatter;

        /// <summary>
        ///     The minimum severity level threshold. Entries below this are silently discarded.
        /// </summary>
        private readonly LogLevel _minimumLevel;

        /// <summary>
        ///     The collection of output destinations where log entries are written.
        /// </summary>
        private readonly List<ILogOutput> _outputs;

        /// <summary>
        ///     Synchronization lock for thread-safe access to the scope stack.
        /// </summary>
        private readonly object _scopeLock = new object();

        /// <summary>
        ///     Thread-safe stack of active scope objects for grouping related log entries.
        /// </summary>
        private readonly Stack<object> _scopeStack;

        /// <summary>
        ///     The current correlation ID for tracing related log entries across components.
        /// </summary>
        private string _correlationId;

        /// <summary>
        ///     Initializes a new instance of the CoreLogger class with the specified configuration.
        /// </summary>
        /// <param name="name">The logical name for this logger, typically the fully-qualified class or component name.</param>
        /// <param name="outputs">The collection of output destinations. If null, defaults to an empty list.</param>
        /// <param name="filters">The collection of log filters. If null, defaults to an empty list.</param>
        /// <param name="formatter">The formatter for converting entries to strings. Used internally for each entry.</param>
        /// <param name="minimumLevel">The minimum severity level to process. Defaults to <see cref="LogLevel.Trace"/>.</param>
        public CoreLogger(
            string name,
            List<ILogOutput> outputs,
            List<ILogFilter> filters,
            ILogFormatter formatter,
            LogLevel minimumLevel = LogLevel.Trace)
        {
            Name = name ?? string.Empty;
            _outputs = outputs ?? new List<ILogOutput>();
            _filters = filters ?? new List<ILogFilter>();
            _formatter = formatter;
            _minimumLevel = minimumLevel;
            _scopeStack = new Stack<object>();
        }


        /// <summary>
        ///     Gets the logical name of this logger, typically the component or class name.
        /// </summary>
        public string Name { get; }


        /// <summary>
        ///     Logs a message with Trace severity, the most detailed diagnostic level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogTrace(string message) => Log(LogLevel.Trace, message);


        /// <summary>
        ///     Logs a message with Debug severity for development-time diagnostics.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogDebug(string message) => Log(LogLevel.Debug, message);


        /// <summary>
        ///     Logs a message with Info severity for general informational messages.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogInfo(string message) => Log(LogLevel.Info, message);


        /// <summary>
        ///     Logs a message with Warning severity for potentially harmful situations.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogWarning(string message) => Log(LogLevel.Warning, message);


        /// <summary>
        ///     Logs a message with Error severity for serious application problems.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogError(string message) => Log(LogLevel.Error, message);


        /// <summary>
        ///     Logs a message with Critical severity for unrecoverable errors.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogCritical(string message) => Log(LogLevel.Critical, message);


        /// <summary>
        ///     Logs a message with Error severity, including an associated exception.
        /// </summary>
        /// <param name="message">The message describing the error context.</param>
        /// <param name="exception">The exception to include in the log entry.</param>
        public void LogError(string message, Exception exception) => Log(LogLevel.Error, message, exception);


        /// <summary>
        ///     Logs a message with Critical severity, including an associated exception.
        /// </summary>
        /// <param name="message">The message describing the critical error context.</param>
        /// <param name="exception">The exception to include in the log entry.</param>
        public void LogCritical(string message, Exception exception) => Log(LogLevel.Critical, message, exception);


        /// <summary>
        ///     Logs a message at the specified severity level without an exception.
        ///     If the level is below the minimum threshold or disabled, the call is a no-op.
        /// </summary>
        /// <param name="level">The severity level for this log entry.</param>
        /// <param name="message">The message to log.</param>
        public void Log(LogLevel level, string message)
        {
            Log(level, message, null);
        }


        /// <summary>
        ///     Logs a message at the specified severity level with an associated exception.
        ///     Creates a <see cref="LogEntry"/> with current scope and correlation context,
        ///     then processes it through filters and outputs.
        /// </summary>
        /// <param name="level">The severity level for this log entry.</param>
        /// <param name="message">The message describing the log event.</param>
        /// <param name="exception">The exception to associate, or null if none.</param>
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
        ///     Logs a structured message with additional key-value properties at the specified level.
        ///     If <paramref name="properties"/> is null, falls back to <see cref="Log(LogLevel, string)"/>.
        /// </summary>
        /// <param name="level">The severity level for this log entry.</param>
        /// <param name="message">The message describing the log event.</param>
        /// <param name="properties">Key-value pairs of structured data to attach to the entry, or null.</param>
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
        ///     Sets the correlation ID for tracing related log entries across components.
        ///     Thread-safe.
        /// </summary>
        /// <param name="correlationId">The correlation ID to associate with subsequent log entries.
        ///     Typically a GUID or request identifier. Set to null to clear.</param>
        public void SetCorrelationId(string correlationId)
        {
            lock (_correlationLock)
            {
                _correlationId = correlationId;
            }
        }


        /// <summary>
        ///     Gets the current correlation ID, if one has been set.
        ///     Thread-safe.
        /// </summary>
        /// <returns>The current correlation ID, or null if not set.</returns>
        public string GetCorrelationId()
        {
            lock (_correlationLock)
            {
                return _correlationId;
            }
        }


        /// <summary>
        ///     Begins a named scope for grouping related log entries.
        ///     Returns an <see cref="IDisposable"/> that, when disposed, removes the scope.
        ///     Scopes are stored in a thread-safe stack and included in log entries.
        /// </summary>
        /// <param name="scope">The scope object or identifier. Typically a string name.</param>
        /// <returns>An <see cref="IDisposable"/> that ends the scope when disposed.</returns>
        public IDisposable BeginScope(object scope)
        {
            lock (_scopeLock)
            {
                return new LoggerScope(scope, _scopeStack, () => { });
            }
        }


        /// <summary>
        ///     Determines whether logging is enabled at the specified level.
        ///     Checks both the minimum level threshold and the None sentinel.
        /// </summary>
        /// <param name="level">The log level to check.</param>
        /// <returns>True if the level is >= minimum level and not <see cref="LogLevel.None"/>; false otherwise.</returns>
        public bool IsEnabled(LogLevel level) => (level >= _minimumLevel) && (level != LogLevel.None);

        /// <summary>
        ///     Gets a snapshot of the current active scopes as a read-only list.
        ///     Thread-safe: acquires the scope lock before reading.
        /// </summary>
        /// <returns>A list copy of all active scopes, or an empty list if none are active.</returns>
        private IReadOnlyList<object> GetCurrentScopes()
        {
            lock (_scopeLock)
            {
                return _scopeStack.Count > 0 ? new List<object>(_scopeStack) : new List<object>();
            }
        }

        /// <summary>
        ///     Gets the current correlation ID without allocating a lock object return path.
        ///     Thread-safe: acquires the correlation lock before reading.
        /// </summary>
        /// <returns>The current correlation ID, or null if not set.</returns>
        private string GetCorrelationIdInternal()
        {
            lock (_correlationLock)
            {
                return _correlationId;
            }
        }

        /// <summary>
        ///     Processes a log entry by first evaluating all filters, then writing to all enabled outputs.
        ///     Exceptions from individual filters or outputs are caught to prevent cascading failures.
        /// </summary>
        /// <param name="entry">The log entry to process through the pipeline.</param>
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