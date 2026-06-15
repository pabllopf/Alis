// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LoggerTest.cs
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
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Formatters;
using Alis.Core.Aspect.Logging.Outputs;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Comprehensive unit tests for the static Logger utility class.
    ///     Validates backward compatibility methods, default logger initialization,
    ///     custom logger injection, and exception logging behavior.
    /// </summary>
    public class LoggerTest
    {
        /// <summary>
        ///     Tests that static logger trace should not throw
        /// </summary>
        [Fact]
        public void Logger_Trace_ShouldNotThrow()
        {
            Logger.SetDefaultLogger(new MockLogger());

            Logger.Trace("Trace message");
        }

        /// <summary>
        ///     Tests that static logger info should not throw
        /// </summary>
        [Fact]
        public void Logger_Info_ShouldNotThrow()
        {
            Logger.SetDefaultLogger(new MockLogger());

            Logger.Info("Info message");
        }

        /// <summary>
        ///     Tests that static logger log should not throw
        /// </summary>
        [Fact]
        public void Logger_Log_ShouldNotThrow()
        {
            Logger.SetDefaultLogger(new MockLogger());

            Logger.Log("Log message");
        }

        /// <summary>
        ///     Tests that static logger warning should not throw
        /// </summary>
        [Fact]
        public void Logger_Warning_ShouldNotThrow()
        {
            Logger.SetDefaultLogger(new MockLogger());

            Logger.Warning("Warning message");
        }

        /// <summary>
        ///     Tests that static logger error should not throw
        /// </summary>
        [Fact]
        public void Logger_Error_ShouldNotThrow()
        {
            Logger.SetDefaultLogger(new MockLogger());

            Logger.Error("Error message");
        }

        /// <summary>
        ///     Tests that static logger debug should not throw
        /// </summary>
        [Fact]
        public void Logger_Debug_ShouldNotThrow()
        {
            Logger.SetDefaultLogger(new MockLogger());

            Logger.Debug("Debug message");
        }

        /// <summary>
        ///     Tests that static logger exception should log and throw
        /// </summary>
        [Fact]
        public void Logger_Exception_ShouldLogAndThrow()
        {
            var mockLogger = new MockLogger();
            Logger.SetDefaultLogger(mockLogger);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => Logger.Exception("Test error"));

            Assert.Equal("Test error", exception.Message);
            Assert.True(mockLogger.CriticalMessages.Count > 0);
            Assert.Equal("Test error", mockLogger.CriticalMessages[0]);
        }

        /// <summary>
        ///     Tests that static logger set default logger should use custom logger
        /// </summary>
        [Fact]
        public void Logger_SetDefaultLogger_ShouldUseCustomLogger()
        {
            var mockLogger = new MockLogger();
            Logger.SetDefaultLogger(mockLogger);

            Logger.Info("Custom logger message");

            Assert.Single(mockLogger.InfoMessages);
            Assert.Equal("Custom logger message", mockLogger.InfoMessages[0]);
        }

        /// <summary>
        ///     Tests that static logger set default logger to null should reset
        /// </summary>
        [Fact]
        public void Logger_SetDefaultLoggerToNull_ShouldReset()
        {
            var mockLogger = new MockLogger();
            Logger.SetDefaultLogger(mockLogger);
            Logger.SetDefaultLogger(null);

            Logger.Info("After reset");
        }

        /// <summary>
        ///     Tests that static logger log delegates to info
        /// </summary>
        [Fact]
        public void Logger_Log_DelegatesToInfo()
        {
            var mockLogger = new MockLogger();
            Logger.SetDefaultLogger(mockLogger);

            Logger.Log("Log message");

            Assert.Single(mockLogger.InfoMessages);
            Assert.Equal("Log message", mockLogger.InfoMessages[0]);
        }

        /// <summary>
        ///     Tests that static logger all methods should call correct logger method
        /// </summary>
        [Fact]
        public void Logger_AllMethods_ShouldCallCorrectLoggerMethod()
        {
            var mockLogger = new MockLogger();
            Logger.SetDefaultLogger(mockLogger);

            Logger.Trace("Trace");
            Logger.Debug("Debug");
            Logger.Info("Info");
            Logger.Warning("Warning");
            Logger.Error("Error");

            Assert.Single(mockLogger.TraceMessages);
            Assert.Single(mockLogger.DebugMessages);
            Assert.Single(mockLogger.InfoMessages);
            Assert.Single(mockLogger.WarningMessages);
            Assert.Single(mockLogger.ErrorMessages);
        }

        /// <summary>
        ///     Tests that static logger exception with empty message throws
        /// </summary>
        [Fact]
        public void Logger_Exception_WithEmptyMessage_Throws()
        {
            var mockLogger = new MockLogger();
            Logger.SetDefaultLogger(mockLogger);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => Logger.Exception(string.Empty));

            Assert.Equal(string.Empty, exception.Message);
        }

        /// <summary>
        ///     Tests that static logger concurrent calls should be thread safe
        /// </summary>
        [Fact]
        public void Logger_ConcurrentCalls_ShouldBeThreadSafe()
        {
            var mockLogger = new MockLogger();
            Logger.SetDefaultLogger(mockLogger);

            System.Threading.Tasks.Task[] tasks = new System.Threading.Tasks.Task[10];

            for (int i = 0; i < 10; i++)
            {
                int index = i;
                tasks[i] = System.Threading.Tasks.Task.Run(() =>
                {
                    Logger.Info($"Message {index}");
                });
            }

            System.Threading.Tasks.Task.WaitAll(tasks);
        }

        /// <summary>
        ///     Tests that static logger with null message should not throw
        /// </summary>
        [Fact]
        public void Logger_WithNullMessage_ShouldNotThrow()
        {
            var mockLogger = new MockLogger();
            Logger.SetDefaultLogger(mockLogger);

            Logger.Info(null);
        }

        /// <summary>
        ///     Tests that static logger ensures initialization on first call
        /// </summary>
        [Fact]
        public void Logger_EnsuresInitializationOnFirstCall()
        {
            Logger.SetDefaultLogger(null);

            Logger.Info("First call after reset");
        }

        /// <summary>
        ///     Helper mock logger for testing static Logger class.
        /// </summary>
        private sealed class MockLogger : ILogger
        {
            /// <summary>
            /// Gets the value of the trace messages
            /// </summary>
            public List<string> TraceMessages { get; } = new List<string>();

            /// <summary>
            /// Gets the value of the debug messages
            /// </summary>
            public List<string> DebugMessages { get; } = new List<string>();

            /// <summary>
            /// Gets the value of the info messages
            /// </summary>
            public List<string> InfoMessages { get; } = new List<string>();

            /// <summary>
            /// Gets the value of the warning messages
            /// </summary>
            public List<string> WarningMessages { get; } = new List<string>();

            /// <summary>
            /// Gets the value of the error messages
            /// </summary>
            public List<string> ErrorMessages { get; } = new List<string>();

            /// <summary>
            /// Gets the value of the critical messages
            /// </summary>
            public List<string> CriticalMessages { get; } = new List<string>();

            /// <summary>
            /// Gets the value of the name
            /// </summary>
            public string Name => "MockLogger";

            /// <summary>
            /// Logs the trace using the specified message
            /// </summary>
            /// <param name="message">The message</param>
            public void LogTrace(string message) => TraceMessages.Add(message);

            /// <summary>
            /// Logs the debug using the specified message
            /// </summary>
            /// <param name="message">The message</param>
            public void LogDebug(string message) => DebugMessages.Add(message);

            /// <summary>
            /// Logs the info using the specified message
            /// </summary>
            /// <param name="message">The message</param>
            public void LogInfo(string message) => InfoMessages.Add(message);

            /// <summary>
            /// Logs the warning using the specified message
            /// </summary>
            /// <param name="message">The message</param>
            public void LogWarning(string message) => WarningMessages.Add(message);

            /// <summary>
            /// Logs the error using the specified message
            /// </summary>
            /// <param name="message">The message</param>
            public void LogError(string message) => ErrorMessages.Add(message);

            /// <summary>
            /// Logs the error using the specified message
            /// </summary>
            /// <param name="message">The message</param>
            /// <param name="exception">The exception</param>
            public void LogError(string message, Exception exception) => ErrorMessages.Add(message);

            /// <summary>
            /// Logs the critical using the specified message
            /// </summary>
            /// <param name="message">The message</param>
            public void LogCritical(string message) => CriticalMessages.Add(message);

            /// <summary>
            /// Logs the critical using the specified message
            /// </summary>
            /// <param name="message">The message</param>
            /// <param name="exception">The exception</param>
            public void LogCritical(string message, Exception exception) => CriticalMessages.Add(message);

            /// <summary>
            /// Logs the level
            /// </summary>
            /// <param name="level">The level</param>
            /// <param name="message">The message</param>
            public void Log(LogLevel level, string message) { }

            /// <summary>
            /// Logs the level
            /// </summary>
            /// <param name="level">The level</param>
            /// <param name="message">The message</param>
            /// <param name="exception">The exception</param>
            public void Log(LogLevel level, string message, Exception exception) { }

            /// <summary>
            /// Logs the structured using the specified level
            /// </summary>
            /// <param name="level">The level</param>
            /// <param name="message">The message</param>
            /// <param name="properties">The properties</param>
            public void LogStructured(LogLevel level, string message, IReadOnlyDictionary<string, object> properties) { }

            /// <summary>
            /// Sets the correlation id using the specified correlation id
            /// </summary>
            /// <param name="correlationId">The correlation id</param>
            public void SetCorrelationId(string correlationId) { }

            /// <summary>
            /// Gets the correlation id
            /// </summary>
            /// <returns>The string</returns>
            public string GetCorrelationId() => null;

            /// <summary>
            /// Begins the scope using the specified scope
            /// </summary>
            /// <param name="scope">The scope</param>
            /// <returns>The disposable</returns>
            public IDisposable BeginScope(object scope) => null;

            /// <summary>
            /// Ises the enabled using the specified level
            /// </summary>
            /// <param name="level">The level</param>
            /// <returns>The bool</returns>
            public bool IsEnabled(LogLevel level) => true;
        }
    }
}
