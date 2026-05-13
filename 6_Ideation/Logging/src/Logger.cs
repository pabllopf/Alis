// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Logger.cs
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
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Formatters;
using Alis.Core.Aspect.Logging.Outputs;

namespace Alis.Core.Aspect.Logging
{
    /// <summary>
    ///     Static utility methods for backward compatibility with the legacy logging API.
    ///     NOTE: For new code, use LoggerFactory and ILogger directly for better performance
    ///     and flexibility. This class is provided for backward compatibility only.
    ///     Uses a default global logger instance.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        ///     The default logger
        /// </summary>
        private static ILogger _defaultLogger;

        /// <summary>
        ///     The lock
        /// </summary>
        private static readonly object _lock = new object();

        /// <summary>
        ///     Ensures the default logger is initialized.
        /// </summary>
        private static void EnsureInitialized()
        {
            if (_defaultLogger != null)
            {
                return;
            }

            lock (_lock)
            {
                if (_defaultLogger == null)
                {
                    // Create a simple default logger with console output
                    LoggerFactory factory = new LoggerFactory();
                    factory.AddOutput(new ConsoleLogOutput(new SimpleLogFormatter()));
                    _defaultLogger = factory.CreateLogger("Alis.Core.Aspect.Logging");
                }
            }
        }

        /// <summary>
        ///     Sets a custom logger instance for static method calls.
        ///     Useful for replacing the default behavior.
        /// </summary>
        /// <param name="logger">The logger to use, or null to reset to default.</param>
        public static void SetDefaultLogger(ILogger logger)
        {
            lock (_lock)
            {
                _defaultLogger = logger;
            }
        }

        /// <summary>
        ///     Logs a message with Trace severity.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void Trace(string message)
        {
            EnsureInitialized();
            _defaultLogger?.LogTrace(message);
        }

        /// <summary>
        ///     Logs a message with Info severity.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void Info(string message)
        {
            EnsureInitialized();
            _defaultLogger?.LogInfo(message);
        }

        /// <summary>
        ///     Logs a message with Info severity using the legacy API.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void Log(string message)
        {
            EnsureInitialized();
            _defaultLogger?.LogInfo(message);
        }

        /// <summary>
        ///     Logs a message with Warning severity.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void Warning(string message)
        {
            EnsureInitialized();
            _defaultLogger?.LogWarning(message);
        }

        /// <summary>
        ///     Logs a message with Error severity.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void Error(string message)
        {
            EnsureInitialized();
            _defaultLogger?.LogError(message);
        }

        /// <summary>
        ///     Logs a message with Debug severity.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void Debug(string message)
        {
            EnsureInitialized();
            _defaultLogger?.LogDebug(message);
        }

        /// <summary>
        ///     Logs an exception message at Critical severity and throws an <see cref="Exception"/>.
        /// </summary>
        /// <param name="toString">The exception message to log and throw.</param>
        /// <exception cref="Exception">Thrown after logging to propagate the error.</exception>
        public static void Exception(string toString)
        {
            EnsureInitialized();
            _defaultLogger?.LogCritical(toString);
            throw new Exception(toString);
        }
    }
}
