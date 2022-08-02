// Licensed under the Apache License, Version 2.0 (the "License").
// See the LICENSE file in the project root for more information.

using System;
using System.Reactive.Disposables;
using Microsoft.Extensions.Logging;

namespace HIDDevices.Sample
{
    /// <summary>
    /// The simple console logger class
    /// </summary>
    /// <seealso cref="ILogger{T}"/>
    public class SimpleConsoleLogger<T> : ILogger<T>
    {
        /// <summary>
        /// The name
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Initializes a new instance of the class
        /// </summary>
        /// <param name="logLevel">The log level</param>
        /// <param name="name">The name</param>
        public SimpleConsoleLogger(LogLevel logLevel, string name = null)
        {
            Name = name ?? typeof(T).Name;
            LogLevel = logLevel;
        }

        /// <summary>
        /// Gets or sets the value of the log level
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
        public bool IsEnabled(LogLevel logLevel) => LogLevel <= logLevel;

        /// <inheritdoc />
        public IDisposable BeginScope<TState>(TState state) => Disposable.Empty;
    }
}
