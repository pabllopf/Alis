using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using Alis.Core.Aspect.Logging.Abstractions;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    /// The logger branch coverage tests class
    /// </summary>
    public class LoggerBranchCoverageTests
    {
        /// <summary>
        /// The static
        /// </summary>
        private static readonly FieldInfo DefaultLoggerField = typeof(Logger)
            .GetField("_defaultLogger", BindingFlags.NonPublic | BindingFlags.Static);

        /// <summary>
        /// The silent logger class
        /// </summary>
        /// <seealso cref="ILogger"/>
        internal sealed class SilentLogger : ILogger
        {
            /// <summary>
            /// Gets the value of the name
            /// </summary>
            public string Name => "Silent";
            /// <summary>
            /// Logs the trace using the specified message
            /// </summary>
            /// <param name="message">The message</param>
            public void LogTrace(string message) { }
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
            /// Logs the warning using the specified message
            /// </summary>
            /// <param name="message">The message</param>
            public void LogWarning(string message) { }
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
            public IDisposable BeginScope(object scope) => null;
            /// <summary>
            /// Ises the enabled using the specified level
            /// </summary>
            /// <param name="level">The level</param>
            /// <returns>The bool</returns>
            public bool IsEnabled(LogLevel level) => true;
        }

        /// <summary>
        /// Tests that trace null branch
        /// </summary>
        [Fact]
        public void Trace_NullBranch()
        {
            AttemptNullBranch(() => Logger.Trace("trigger-null-branch"));
        }

        /// <summary>
        /// Tests that info null branch
        /// </summary>
        [Fact]
        public void Info_NullBranch()
        {
            AttemptNullBranch(() => Logger.Info("trigger-null-branch"));
        }

        /// <summary>
        /// Tests that error null branch
        /// </summary>
        [Fact]
        public void Error_NullBranch()
        {
            ContinuousRaceNullBranch(() => Logger.Error("trigger-null-branch"));
        }

        /// <summary>
        /// Tests that exception null branch
        /// </summary>
        [Fact]
        public void Exception_NullBranch()
        {
            ContinuousRaceNullBranch(() =>
            {
                try { Logger.Exception("trigger-null-branch"); }
                catch (InvalidOperationException) { }
            });
        }

        /// <summary>
        /// Tests that debug null branch
        /// </summary>
        [Fact]
        public void Debug_NullBranch()
        {
            AttemptNullBranch(() => Logger.Debug("trigger-null-branch"));
        }

        

        /// <summary>
        /// Tests that ensure initialized concurrent initialization second thread skips
        /// </summary>
        [Fact]
        public void Logger_EnsureInitialized_ConcurrentInitialization_SecondThreadSkips()
        {
            object saved = DefaultLoggerField.GetValue(null);

            try
            {
                DefaultLoggerField.SetValue(null, null);

                System.Collections.Concurrent.ConcurrentBag<Exception> exceptions = new System.Collections.Concurrent.ConcurrentBag<Exception>();
                Thread[] threads = new Thread[20];

                for (int i = 0; i < threads.Length; i++)
                {
                    threads[i] = new Thread(() =>
                    {
                        try
                        {
                            Logger.Trace("concurrent-init");
                        }
                        catch (Exception ex)
                        {
                            exceptions.Add(ex);
                        }
                    });
                }

                for (int i = 0; i < threads.Length; i++)
                {
                    threads[i].Start();
                }

                for (int i = 0; i < threads.Length; i++)
                {
                    threads[i].Join(10000);
                }

                Assert.Empty(exceptions);
            }
            finally
            {
                DefaultLoggerField.SetValue(null, saved);
            }
        }

        /// <summary>
        /// Attempts the null branch using the specified log action
        /// </summary>
        /// <param name="logAction">The log action</param>
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

        /// <summary>
        /// Continuouses the race null branch using the specified log action
        /// </summary>
        /// <param name="logAction">The log action</param>
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
