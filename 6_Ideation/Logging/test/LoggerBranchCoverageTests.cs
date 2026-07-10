using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using Alis.Core.Aspect.Logging.Abstractions;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    public class LoggerBranchCoverageTests
    {
        private static readonly FieldInfo DefaultLoggerField = typeof(Logger)
            .GetField("_defaultLogger", BindingFlags.NonPublic | BindingFlags.Static);

        private sealed class SilentLogger : ILogger
        {
            public string Name => "Silent";
            public void LogTrace(string message) { }
            public void LogDebug(string message) { }
            public void LogInfo(string message) { }
            public void LogWarning(string message) { }
            public void LogError(string message) { }
            public void LogError(string message, Exception exception) { }
            public void LogCritical(string message) { }
            public void LogCritical(string message, Exception exception) { }
            public void Log(LogLevel level, string message) { }
            public void Log(LogLevel level, string message, Exception exception) { }
            public void LogStructured(LogLevel level, string message, IReadOnlyDictionary<string, object> properties) { }
            public void SetCorrelationId(string correlationId) { }
            public string GetCorrelationId() => null;
            public IDisposable BeginScope(object scope) => null;
            public bool IsEnabled(LogLevel level) => true;
        }

        [Fact]
        public void Trace_NullBranch()
        {
            AttemptNullBranch(() => Logger.Trace("trigger-null-branch"));
        }

        [Fact]
        public void Debug_NullBranch()
        {
            AttemptNullBranch(() => Logger.Debug("trigger-null-branch"));
        }

        [Fact]
        public void Info_NullBranch()
        {
            AttemptNullBranch(() => Logger.Info("trigger-null-branch"));
        }

        [Fact]
        public void Warning_NullBranch()
        {
            AttemptNullBranch(() => Logger.Warning("trigger-null-branch"));
        }

        [Fact]
        public void Error_NullBranch()
        {
            ContinuousRaceNullBranch(() => Logger.Error("trigger-null-branch"));
        }

        [Fact]
        public void Exception_NullBranch()
        {
            ContinuousRaceNullBranch(() =>
            {
                try { Logger.Exception("trigger-null-branch"); }
                catch (InvalidOperationException) { }
            });
        }

        private static void AttemptNullBranch(Action logAction)
        {
            for (int attempt = 0; attempt < 2000; attempt++)
            {
                DefaultLoggerField.SetValue(null, new SilentLogger());

                Thread thread = new Thread(() =>
                {
                    Thread.SpinWait(attempt & 0x1FF);
                    DefaultLoggerField.SetValue(null, null);
                });
                thread.Start();

                logAction();

                thread.Join();
            }
        }

        private static void ContinuousRaceNullBranch(Action logAction)
        {
            using CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            Thread racer = new Thread(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    DefaultLoggerField.SetValue(null, null);
                    Thread.SpinWait(1);
                }
            });
            racer.Start();

            for (int i = 0; i < 10000; i++)
            {
                DefaultLoggerField.SetValue(null, new SilentLogger());
                logAction();
            }

            cts.Cancel();
            racer.Join();
        }
    }
}
