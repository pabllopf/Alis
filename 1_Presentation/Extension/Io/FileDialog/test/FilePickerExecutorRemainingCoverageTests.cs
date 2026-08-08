using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Logging.Abstractions;
using Xunit;

namespace Alis.Extension.Io.FileDialog.Test
{
    /// <summary>
    /// The file picker executor remaining coverage tests class
    /// </summary>
    public class FilePickerExecutorRemainingCoverageTests
    {
        /// <summary>
        /// Tests that execute command when logger throws inside try should log error and rethrow
        /// </summary>
        [Fact]
        public void ExecuteCommand_WhenLoggerThrowsInsideTry_ShouldLogErrorAndRethrow()
        {
            ThrowingLogger logger = new ThrowingLogger { ThrowTraceOnCall = 2 };
            Logger.SetDefaultLogger(logger);
            try
            {
                Action act = () => FilePickerExecutor.ExecuteCommand("echo", "test", 5000);
                Assert.Throws<InvalidOperationException>(act);
            }
            finally
            {
                Logger.SetDefaultLogger(null);
            }
        }

        /// <summary>
        /// Tests that command exists when logger throws inside try should log warning and return false
        /// </summary>
        [Fact]
        public void CommandExists_WhenLoggerThrowsInsideTry_ShouldLogWarningAndReturnFalse()
        {
            ThrowingLogger logger = new ThrowingLogger { ThrowTraceOnCall = 4 };
            Logger.SetDefaultLogger(logger);
            try
            {
                bool result = FilePickerExecutor.CommandExists("echo");
                Assert.False(result);
            }
            finally
            {
                Logger.SetDefaultLogger(null);
            }
        }

        /// <summary>
        /// The throwing logger class
        /// </summary>
        /// <seealso cref="ILogger"/>
        internal sealed class ThrowingLogger : ILogger
        {
            /// <summary>
            /// Gets or sets the value of the throw trace on call
            /// </summary>
            public int ThrowTraceOnCall { get; set; } = int.MaxValue;
            /// <summary>
            /// The trace call count
            /// </summary>
            private int _traceCallCount;

            /// <summary>
            /// Gets the value of the name
            /// </summary>
            public string Name => "ThrowingLogger";

            /// <summary>
            /// Logs the trace using the specified message
            /// </summary>
            /// <param name="message">The message</param>
            /// <exception cref="InvalidOperationException">Simulated logger trace failure</exception>
            public void LogTrace(string message)
            {
                _traceCallCount++;
                if (_traceCallCount == ThrowTraceOnCall)
                {
                    throw new InvalidOperationException("Simulated logger trace failure");
                }
            }

            /// <summary>
            /// Logs the warning using the specified message
            /// </summary>
            /// <param name="message">The message</param>
            public void LogWarning(string message) { }
            /// <summary>
            /// Logs the debug using the specified message
            /// </summary>
            /// <param name="message">The message</param>
            public void LogDebug(string message) { }
            /// <summary>
            /// Logs the info using the specified message
            /// </summary>
            /// <param name="message">The message</param>
            public void LogInfo(string message) { }
            /// <summary>
            /// Logs the error using the specified message
            /// </summary>
            /// <param name="message">The message</param>
            public void LogError(string message) { }
            /// <summary>
            /// Logs the error using the specified message
            /// </summary>
            /// <param name="message">The message</param>
            /// <param name="exception">The exception</param>
            public void LogError(string message, Exception exception) { }
            /// <summary>
            /// Logs the critical using the specified message
            /// </summary>
            /// <param name="message">The message</param>
            public void LogCritical(string message) { }
            /// <summary>
            /// Logs the critical using the specified message
            /// </summary>
            /// <param name="message">The message</param>
            /// <param name="exception">The exception</param>
            public void LogCritical(string message, Exception exception) { }
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
            public IDisposable BeginScope(object scope) => new DisposableAction(() => { });
            /// <summary>
            /// Ises the enabled using the specified level
            /// </summary>
            /// <param name="level">The level</param>
            /// <returns>The bool</returns>
            public bool IsEnabled(LogLevel level) => true;
        }

        /// <summary>
        /// The disposable action class
        /// </summary>
        /// <seealso cref="IDisposable"/>
        internal sealed class DisposableAction : IDisposable
        {
            /// <summary>
            /// The action
            /// </summary>
            internal readonly Action _action;
            /// <summary>
            /// Initializes a new instance of the <see cref="DisposableAction"/> class
            /// </summary>
            /// <param name="action">The action</param>
            public DisposableAction(Action action) => _action = action;
            /// <summary>
            /// Disposes this instance
            /// </summary>
            public void Dispose() => _action?.Invoke();
        }
    }
}
