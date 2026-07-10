using System;
using System.Collections.Generic;
using System.IO;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Logging.Abstractions;
using Xunit;

namespace Alis.Extension.Io.FileDialog.Test
{
    public class FilePickerValidatorRemainingCoverageTests
    {
        [Fact]
        public void IsValidFilePath_WhenLoggerThrowsInsideTry_ShouldCatchAndReturnFalse()
        {
            var logger = new ThrowingLogger { ThrowWarningOnCall = 1 };
            Logger.SetDefaultLogger(logger);
            try
            {
                bool result = FilePickerValidator.IsValidFilePath("/nonexistent/path/file.txt");
                Assert.False(result);
            }
            finally
            {
                Logger.SetDefaultLogger(null);
            }
        }

        [Fact]
        public void IsValidDirectoryPath_WhenLoggerThrowsInsideTry_ShouldCatchAndReturnFalse()
        {
            var logger = new ThrowingLogger { ThrowWarningOnCall = 1 };
            Logger.SetDefaultLogger(logger);
            try
            {
                bool result = FilePickerValidator.IsValidDirectoryPath("/nonexistent/path");
                Assert.False(result);
            }
            finally
            {
                Logger.SetDefaultLogger(null);
            }
        }

        [Fact]
        public void IsFileExtensionAllowed_WhenLoggerThrowsInsideTry_ShouldCatchAndReturnFalse()
        {
            var logger = new ThrowingLogger { ThrowWarningOnCall = 1 };
            Logger.SetDefaultLogger(logger);
            try
            {
                FilePickerOptions options = new FilePickerOptions("Test")
                    .WithFilter(new FilePickerFilter("Text Files", "txt"));
                bool result = FilePickerValidator.IsFileExtensionAllowed("/path/README", options);
                Assert.False(result);
            }
            finally
            {
                Logger.SetDefaultLogger(null);
            }
        }

        [Fact]
        public void IsResultValid_WithOpenFileAndDisallowedExtension_ShouldReturnFalse()
        {
            string tempFile = Path.GetTempFileName();
            try
            {
                FilePickerOptions options = new FilePickerOptions("Open")
                    .WithFilter(new FilePickerFilter("Text Files", "txt"));
                FilePickerResult result = new FilePickerResult(tempFile);

                bool isValid = FilePickerValidator.IsResultValid(result, options);

                Assert.False(isValid);
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        [Fact]
        public void IsResultValid_WithClearedSelectedPaths_ShouldReturnFalse()
        {
            FilePickerOptions options = new FilePickerOptions("Open");
            FilePickerResult result = new FilePickerResult("/some/path.txt");
            result.SelectedPaths.Clear();

            bool isValid = FilePickerValidator.IsResultValid(result, options);

            Assert.False(isValid);
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
