// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   SimpleConsoleLogger.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
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
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Reactive.Disposables;
using Microsoft.Extensions.Logging;

namespace HIDDevices.Sample
{
    /// <summary>
    ///     The simple console logger class
    /// </summary>
    /// <seealso cref="ILogger{T}" />
    public class SimpleConsoleLogger<T> : ILogger<T>
    {
        /// <summary>
        ///     The name
        /// </summary>
        public readonly string Name;

        /// <summary>
        ///     Initializes a new instance of the class
        /// </summary>
        /// <param name="logLevel">The log level</param>
        /// <param name="name">The name</param>
        public SimpleConsoleLogger(LogLevel logLevel, string name = null)
        {
            Name = name ?? typeof(T).Name;
            LogLevel = logLevel;
        }

        /// <summary>
        ///     Gets or sets the value of the log level
        /// </summary>
        public LogLevel LogLevel { get; set; }

        /// <inheritdoc />
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
            Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            var message = formatter(state, exception);

            if (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine(message);
            }
        }

        /// <inheritdoc />
        public bool IsEnabled(LogLevel logLevel)
        {
            return LogLevel <= logLevel;
        }

        /// <inheritdoc />
        public IDisposable BeginScope<TState>(TState state)
        {
            return Disposable.Empty;
        }
    }
}