// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: ILogger.cs
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
    ///     Core logger interface for logging structured messages with various severity levels.
    ///     Implementations must be thread-safe and support dependency injection.
    ///     AOT-compatible: Uses interfaces and virtual dispatch only.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        ///     Gets the logical name of this logger (typically the component/class name).
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     Logs a message with Trace severity.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void LogTrace(string message);

        /// <summary>
        ///     Logs a message with Debug severity.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void LogDebug(string message);

        /// <summary>
        ///     Logs a message with Info severity.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void LogInfo(string message);

        /// <summary>
        ///     Logs a message with Warning severity.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void LogWarning(string message);

        /// <summary>
        ///     Logs a message with Error severity.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void LogError(string message);

        /// <summary>
        ///     Logs a message with Critical severity.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void LogCritical(string message);

        /// <summary>
        ///     Logs a message with an associated exception at Error level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="exception">The exception to include in the log.</param>
        void LogError(string message, Exception exception);

        /// <summary>
        ///     Logs a message with an associated exception at Critical level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="exception">The exception to include in the log.</param>
        void LogCritical(string message, Exception exception);

        /// <summary>
        ///     Logs a message at the specified level.
        /// </summary>
        /// <param name="level">The severity level of the log.</param>
        /// <param name="message">The message to log.</param>
        void Log(LogLevel level, string message);

        /// <summary>
        ///     Logs a message at the specified level with an associated exception.
        /// </summary>
        /// <param name="level">The severity level of the log.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="exception">The exception to include in the log.</param>
        void Log(LogLevel level, string message, Exception exception);

        /// <summary>
        ///     Logs a structured message with additional properties.
        /// </summary>
        /// <param name="level">The severity level of the log.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="properties">Key-value pairs of contextual data.</param>
        void LogStructured(LogLevel level, string message, IReadOnlyDictionary<string, object> properties);

        /// <summary>
        ///     Sets the correlation ID for tracing related log entries.
        /// </summary>
        /// <param name="correlationId">The correlation ID, typically a GUID or request ID.</param>
        void SetCorrelationId(string correlationId);

        /// <summary>
        ///     Gets the current correlation ID.
        /// </summary>
        /// <returns>The correlation ID, or null if not set.</returns>
        string GetCorrelationId();

        /// <summary>
        ///     Begins a named scope for log entries, useful for grouping related logs.
        ///     Returns a disposable that ends the scope when disposed.
        /// </summary>
        /// <param name="scope">The scope name or identifier.</param>
        /// <returns>A disposable that removes the scope when disposed.</returns>
        IDisposable BeginScope(object scope);

        /// <summary>
        ///     Determines whether logging is enabled at the given level.
        ///     Can be used to avoid expensive message formatting for disabled levels.
        /// </summary>
        /// <param name="level">The log level to check.</param>
        /// <returns>True if the level is enabled; false otherwise.</returns>
        bool IsEnabled(LogLevel level);
    }
}

