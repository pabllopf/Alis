using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Logging.Abstractions;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace Alis.Extension.Io.FileDialog.Test
{
    public class FilePickerPathConverterRemainingCoverageTests
    {
        [Fact]
        public void GetDirectoryName_WhenLoggerThrowsInsideTry_ShouldCatchAndReturnNull()
        {
            var logger = new ThrowingLogger { ThrowTraceOnCall = 2 };
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

        [Fact]
        public void GetFileName_WhenLoggerThrowsInsideTry_ShouldCatchAndReturnNull()
        {
            var logger = new ThrowingLogger { ThrowTraceOnCall = 2 };
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

        [Fact]
        public void IsValidPath_WithMustExistFalseAndLoggerThrowsInsideTry_ShouldCatchAndReturnFalse()
        {
            var logger = new ThrowingLogger { ThrowWarningOnCall = 1 };
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

        [Fact]
        public void NormalizePath_WhenLoggerThrowsInsideTry_ShouldCatchAndReturnNull()
        {
            var logger = new ThrowingLogger { ThrowTraceOnCall = 2 };
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

        [Fact]
        public void ConvertPathSeparators_WhenLoggerThrowsInsideTry_ShouldCatchAndReturnOriginal()
        {
            var logger = new ThrowingLogger { ThrowTraceOnCall = 2 };
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

        [Fact]
        public void SplitMultiplePaths_WhenLoggerThrowsAfterProcessing_ShouldCatchAndReturnEmpty()
        {
            var logger = new ThrowingLogger { ThrowTraceOnCall = 6 };
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

        [Fact]
        public void SplitMultiplePaths_WhenNormalizePathLoggerThrows_ShouldCatchAndReturnEmpty()
        {
            var logger = new ThrowingLogger { ThrowTraceOnCall = 2 };
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

        private sealed class ThrowingLogger : ILogger
        {
            public int ThrowTraceOnCall { get; set; } = int.MaxValue;
            public int ThrowWarningOnCall { get; set; } = int.MaxValue;
            private int _traceCallCount;
            private int _warningCallCount;

            public string Name => "ThrowingLogger";

            public void LogTrace(string message)
            {
                _traceCallCount++;
                if (_traceCallCount == ThrowTraceOnCall)
                {
                    throw new InvalidOperationException("Simulated logger trace failure");
                }
            }

            public void LogWarning(string message)
            {
                _warningCallCount++;
                if (_warningCallCount == ThrowWarningOnCall)
                {
                    throw new InvalidOperationException("Simulated logger warning failure");
                }
            }

            public void LogDebug(string message) { }
            public void LogInfo(string message) { }
            public void LogError(string message) { }
            public void LogError(string message, Exception exception) { }
            public void LogCritical(string message) { }
            public void LogCritical(string message, Exception exception) { }
            public void Log(LogLevel level, string message) { }
            public void Log(LogLevel level, string message, Exception exception) { }
            public void LogStructured(LogLevel level, string message, IReadOnlyDictionary<string, object> properties) { }
            public void SetCorrelationId(string correlationId) { }
            public string GetCorrelationId() => null;
            public IDisposable BeginScope(object scope) => new DisposableAction(() => { });
            public bool IsEnabled(LogLevel level) => true;
        }

        private sealed class DisposableAction : IDisposable
        {
            private readonly Action _action;
            public DisposableAction(Action action) => _action = action;
            public void Dispose() => _action?.Invoke();
        }
    }
}
