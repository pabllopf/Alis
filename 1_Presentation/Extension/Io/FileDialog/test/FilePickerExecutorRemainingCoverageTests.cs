using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Logging.Abstractions;
using Xunit;

namespace Alis.Extension.Io.FileDialog.Test
{
    public class FilePickerExecutorRemainingCoverageTests
    {
        [Fact]
        public void ExecuteCommand_WhenLoggerThrowsInsideTry_ShouldLogErrorAndRethrow()
        {
            var logger = new ThrowingLogger { ThrowTraceOnCall = 2 };
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

        [Fact]
        public void CommandExists_WhenLoggerThrowsInsideTry_ShouldLogWarningAndReturnFalse()
        {
            var logger = new ThrowingLogger { ThrowTraceOnCall = 4 };
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

        private sealed class ThrowingLogger : ILogger
        {
            public int ThrowTraceOnCall { get; set; } = int.MaxValue;
            private int _traceCallCount;

            public string Name => "ThrowingLogger";

            public void LogTrace(string message)
            {
                _traceCallCount++;
                if (_traceCallCount == ThrowTraceOnCall)
                {
                    throw new InvalidOperationException("Simulated logger trace failure");
                }
            }

            public void LogWarning(string message) { }
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
