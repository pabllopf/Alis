// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: CoreLogger.cs
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
        private readonly List<ILogOutput> _outputs;
        private readonly List<ILogFilter> _filters;
        private readonly ILogFormatter _formatter;
        private readonly Stack<object> _scopeStack;
        private readonly object _scopeLock = new object();
        private readonly object _correlationLock = new object();
        private string _correlationId;
        private LogLevel _minimumLevel;

        /// <summary>
        ///     Initializes a new instance of the CoreLogger class.
        /// </summary>
        /// <param name="name">The logger name.</param>
        /// <param name="outputs">The collection of log outputs.</param>
        /// <param name="filters">The collection of log filters.</param>
        /// <param name="formatter">The log formatter.</param>
        /// <param name="minimumLevel">The minimum log level to process.</param>
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

        /// <inheritdoc />
        public string Name { get; }

        /// <inheritdoc />
        public void LogTrace(string message) => Log(LogLevel.Trace, message);

        /// <inheritdoc />
        public void LogDebug(string message) => Log(LogLevel.Debug, message);

        /// <inheritdoc />
        public void LogInfo(string message) => Log(LogLevel.Info, message);

        /// <inheritdoc />
        public void LogWarning(string message) => Log(LogLevel.Warning, message);

        /// <inheritdoc />
        public void LogError(string message) => Log(LogLevel.Error, message);

        /// <inheritdoc />
        public void LogCritical(string message) => Log(LogLevel.Critical, message);

        /// <inheritdoc />
        public void LogError(string message, Exception exception) => Log(LogLevel.Error, message, exception);

        /// <inheritdoc />
        public void LogCritical(string message, Exception exception) => Log(LogLevel.Critical, message, exception);

        /// <inheritdoc />
        public void Log(LogLevel level, string message)
        {
            Log(level, message, null);
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
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

        /// <inheritdoc />
        public void SetCorrelationId(string correlationId)
        {
            lock (_correlationLock)
            {
                _correlationId = correlationId;
            }
        }

        /// <inheritdoc />
        public string GetCorrelationId()
        {
            lock (_correlationLock)
            {
                return _correlationId;
            }
        }

        /// <inheritdoc />
        public IDisposable BeginScope(object scope)
        {
            lock (_scopeLock)
            {
                return new LoggerScope(scope, _scopeStack, () => { });
            }
        }

        /// <inheritdoc />
        public bool IsEnabled(LogLevel level)
        {
            return level >= _minimumLevel && level != LogLevel.None;
        }
        
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

