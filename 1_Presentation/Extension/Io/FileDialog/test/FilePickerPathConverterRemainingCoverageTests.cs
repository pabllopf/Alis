using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Logging.Abstractions;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace Alis.Extension.Io.FileDialog.Test
{
    /// <summary>
    /// The file picker path converter remaining coverage tests class
    /// </summary>
    public class FilePickerPathConverterRemainingCoverageTests
    {
        /// <summary>
        /// Tests that get directory name when logger throws inside try should catch and return null
        /// </summary>
        [Fact]
        public void GetDirectoryName_WhenLoggerThrowsInsideTry_ShouldCatchAndReturnNull()
        {
            ThrowingLogger logger = new ThrowingLogger { ThrowTraceOnCall = 2 };
            Logger.SetDefaultLogger(logger);
            try
            {
                string result = FilePickerPathConverter.GetDirectoryName("/some/path/file.txt");
                Assert.Null(result);
            }
            finally
            {
                Logger.SetDefaultLogger(null);
            }
        }

        /// <summary>
        /// Tests that get file name when logger throws inside try should catch and return null
        /// </summary>
        [Fact]
        public void GetFileName_WhenLoggerThrowsInsideTry_ShouldCatchAndReturnNull()
        {
            ThrowingLogger logger = new ThrowingLogger { ThrowTraceOnCall = 2 };
            Logger.SetDefaultLogger(logger);
            try
            {
                string result = FilePickerPathConverter.GetFileName("/some/path/file.txt");
                Assert.Null(result);
            }
            finally
            {
                Logger.SetDefaultLogger(null);
            }
        }

        /// <summary>
        /// Tests that is valid path with must exist false and logger throws inside try should catch and return false
        /// </summary>
        [Fact]
        public void IsValidPath_WithMustExistFalseAndLoggerThrowsInsideTry_ShouldCatchAndReturnFalse()
        {
            ThrowingLogger logger = new ThrowingLogger { ThrowWarningOnCall = 1 };
            Logger.SetDefaultLogger(logger);
            try
            {
                bool result = FilePickerPathConverter.IsValidPath("/path/with\0null", false);
                Assert.False(result);
            }
            finally
            {
                Logger.SetDefaultLogger(null);
            }
        }

        /// <summary>
        /// Tests that normalize path when logger throws inside try should catch and return null
        /// </summary>
        [Fact]
        public void NormalizePath_WhenLoggerThrowsInsideTry_ShouldCatchAndReturnNull()
        {
            ThrowingLogger logger = new ThrowingLogger { ThrowTraceOnCall = 2 };
            Logger.SetDefaultLogger(logger);
            try
            {
                string result = FilePickerPathConverter.NormalizePath("/some/path.txt");
                Assert.Null(result);
            }
            finally
            {
                Logger.SetDefaultLogger(null);
            }
        }

        /// <summary>
        /// Tests that convert path separators when logger throws inside try should catch and return original
        /// </summary>
        [Fact]
        public void ConvertPathSeparators_WhenLoggerThrowsInsideTry_ShouldCatchAndReturnOriginal()
        {
            ThrowingLogger logger = new ThrowingLogger { ThrowTraceOnCall = 2 };
            Logger.SetDefaultLogger(logger);
            try
            {
                string original = @"\test\file.txt";
                string result = FilePickerPathConverter.ConvertPathSeparators(original);
                Assert.Equal(original, result);
            }
            finally
            {
                Logger.SetDefaultLogger(null);
            }
        }

        /// <summary>
        /// Tests that split multiple paths when logger throws after processing should catch and return empty
        /// </summary>
        [Fact]
        public void SplitMultiplePaths_WhenLoggerThrowsAfterProcessing_ShouldCatchAndReturnEmpty()
        {
            ThrowingLogger logger = new ThrowingLogger { ThrowTraceOnCall = 6 };
            Logger.SetDefaultLogger(logger);
            try
            {
                string paths = "/path/first.txt" + Environment.NewLine + "/path/second.txt";
                string[] result = FilePickerPathConverter.SplitMultiplePaths(paths);
                Assert.Empty(result);
            }
            finally
            {
                Logger.SetDefaultLogger(null);
            }
        }

        /// <summary>
        /// Tests that split multiple paths when normalize path logger throws should catch and return empty
        /// </summary>
        [Fact]
        public void SplitMultiplePaths_WhenNormalizePathLoggerThrows_ShouldCatchAndReturnEmpty()
        {
            ThrowingLogger logger = new ThrowingLogger { ThrowTraceOnCall = 2 };
            Logger.SetDefaultLogger(logger);
            try
            {
                string[] result = FilePickerPathConverter.SplitMultiplePaths("/single/path.txt");
                Assert.Empty(result);
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
            /// Gets or sets the value of the throw warning on call
            /// </summary>
            public int ThrowWarningOnCall { get; set; } = int.MaxValue;
            /// <summary>
            /// The trace call count
            /// </summary>
            private int _traceCallCount;
            /// <summary>
            /// The warning call count
            /// </summary>
            private int _warningCallCount;

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
            /// <exception cref="InvalidOperationException">Simulated logger warning failure</exception>
            public void LogWarning(string message)
            {
                _warningCallCount++;
                if (_warningCallCount == ThrowWarningOnCall)
                {
                    throw new InvalidOperationException("Simulated logger warning failure");
                }
            }

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
