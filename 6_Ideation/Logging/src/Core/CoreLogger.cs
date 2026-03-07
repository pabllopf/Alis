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
        /// The correlation lock
        /// </summary>
        private readonly object _correlationLock = new object();
        /// <summary>
        /// The filters
        /// </summary>
        private readonly List<ILogFilter> _filters;
        /// <summary>
        /// The formatter
        /// </summary>
        private readonly ILogFormatter _formatter;
        /// <summary>
        /// The minimum level
        /// </summary>
        private readonly LogLevel _minimumLevel;
        /// <summary>
        /// The outputs
        /// </summary>
        private readonly List<ILogOutput> _outputs;
        /// <summary>
        /// The scope lock
        /// </summary>
        private readonly object _scopeLock = new object();
        /// <summary>
        /// The scope stack
        /// </summary>
        private readonly Stack<object> _scopeStack;
        /// <summary>
        /// The correlation id
        /// </summary>
        private string _correlationId;

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

        
        /// <summary>
        /// Gets the value of the name
        /// </summary>
        public string Name { get; }

        
        /// <summary>
        /// Logs the trace using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        public void LogTrace(string message) => Log(LogLevel.Trace, message);

        
        /// <summary>
        /// Logs the debug using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        public void LogDebug(string message) => Log(LogLevel.Debug, message);

        
        /// <summary>
        /// Logs the info using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        public void LogInfo(string message) => Log(LogLevel.Info, message);

        
        /// <summary>
        /// Logs the warning using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        public void LogWarning(string message) => Log(LogLevel.Warning, message);

        
        /// <summary>
        /// Logs the error using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        public void LogError(string message) => Log(LogLevel.Error, message);

        
        /// <summary>
        /// Logs the critical using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        public void LogCritical(string message) => Log(LogLevel.Critical, message);

        
        /// <summary>
        /// Logs the error using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="exception">The exception</param>
        public void LogError(string message, Exception exception) => Log(LogLevel.Error, message, exception);

        
        /// <summary>
        /// Logs the critical using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="exception">The exception</param>
        public void LogCritical(string message, Exception exception) => Log(LogLevel.Critical, message, exception);

        
        /// <summary>
        /// Logs the level
        /// </summary>
        /// <param name="level">The level</param>
        /// <param name="message">The message</param>
        public void Log(LogLevel level, string message)
        {
            Log(level, message, null);
        }

        
        /// <summary>
        /// Logs the level
        /// </summary>
        /// <param name="level">The level</param>
        /// <param name="message">The message</param>
        /// <param name="exception">The exception</param>
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
        /// Logs the structured using the specified level
        /// </summary>
        /// <param name="level">The level</param>
        /// <param name="message">The message</param>
        /// <param name="properties">The properties</param>
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
        /// Sets the correlation id using the specified correlation id
        /// </summary>
        /// <param name="correlationId">The correlation id</param>
        public void SetCorrelationId(string correlationId)
        {
            lock (_correlationLock)
            {
                _correlationId = correlationId;
            }
        }

        
        /// <summary>
        /// Gets the correlation id
        /// </summary>
        /// <returns>The string</returns>
        public string GetCorrelationId()
        {
            lock (_correlationLock)
            {
                return _correlationId;
            }
        }

        
        /// <summary>
        /// Begins the scope using the specified scope
        /// </summary>
        /// <param name="scope">The scope</param>
        /// <returns>The disposable</returns>
        public IDisposable BeginScope(object scope)
        {
            lock (_scopeLock)
            {
                return new LoggerScope(scope, _scopeStack, () => { });
            }
        }

        
        /// <summary>
        /// Ises the enabled using the specified level
        /// </summary>
        /// <param name="level">The level</param>
        /// <returns>The bool</returns>
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