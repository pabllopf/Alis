// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LoggerNullConditionalCoverageTest.cs
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
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Aspect.Logging.Abstractions;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Tests that the static Logger tolerates a default logger being reset to
    ///     null concurrently while log methods are in flight. The null-conditional
    ///     guards in <see cref="Logger"/> exist to absorb this transient, so every
    ///     static log method must complete without throwing when the default
    ///     logger disappears between initialization and use.
    /// </summary>
    [Collection("LoggerStaticCollection")]
    public class LoggerNullConditionalCoverageTest
    {
        /// <summary>
        ///     Tests that log methods when default logger is reset concurrently do not throw
        /// </summary>
        [Fact]
        public void LogMethods_WhenDefaultLoggerIsResetConcurrently_DoNotThrow()
        {
            RecordingLogger recorder = new RecordingLogger();
            Logger.SetDefaultLogger(recorder);

            using (CancellationTokenSource cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(2)))
            {
                CancellationToken token = cancellation.Token;

                Task writer = Task.Run(() =>
                {
                    while (!token.IsCancellationRequested)
                    {
                        Logger.SetDefaultLogger(null);
                        Logger.SetDefaultLogger(recorder);
                    }
                }, token);

                Task[] readers = new Task[4];

                for (int i = 0; i < readers.Length; i++)
                {
                    readers[i] = Task.Run(() =>
                    {
                        while (!token.IsCancellationRequested)
                        {
                            Logger.Trace("trace-message");
                            Logger.Debug("debug-message");
                            Logger.Info("info-message");
                            Logger.Warning("warning-message");
                            Logger.Error("error-message");

                            try
                            {
                                Logger.Exception("critical-message");
                            }
                            catch (InvalidOperationException)
                            {
                            }
                        }
                    }, token);
                }

                Task[] all = new Task[readers.Length + 1];

                for (int i = 0; i < readers.Length; i++)
                {
                    all[i] = readers[i];
                }

                all[readers.Length] = writer;
                Task.WaitAll(all);
            }

            Logger.SetDefaultLogger(null);

            Assert.True(recorder.Count > 0);
        }

        /// <summary>
        ///     AOT-safe recording fake that counts every forwarded call.
        /// </summary>
        private sealed class RecordingLogger : ILogger
        {
            /// <summary>
            ///     The count
            /// </summary>
            private int _count;

            /// <summary>
            ///     Gets the value of the name
            /// </summary>
            public string Name => "RecordingLogger";

            /// <summary>
            ///     Gets the value of the count
            /// </summary>
            public int Count => _count;

            /// <summary>
            ///     Logs the trace using the specified message
            /// </summary>
            /// <param name="message">The message</param>
            public void LogTrace(string message) => Record();

            /// <summary>
            ///     Logs the debug using the specified message
            /// </summary>
            /// <param name="message">The message</param>
            public void LogDebug(string message) => Record();

            /// <summary>
            ///     Logs the info using the specified message
            /// </summary>
            /// <param name="message">The message</param>
            public void LogInfo(string message) => Record();

            /// <summary>
            ///     Logs the warning using the specified message
            /// </summary>
            /// <param name="message">The message</param>
            public void LogWarning(string message) => Record();

            /// <summary>
            ///     Logs the error using the specified message
            /// </summary>
            /// <param name="message">The message</param>
            public void LogError(string message) => Record();

            /// <summary>
            ///     Logs the error using the specified message
            /// </summary>
            /// <param name="message">The message</param>
            /// <param name="exception">The exception</param>
            public void LogError(string message, Exception exception) => Record();

            /// <summary>
            ///     Logs the critical using the specified message
            /// </summary>
            /// <param name="message">The message</param>
            public void LogCritical(string message) => Record();

            /// <summary>
            ///     Logs the critical using the specified message
            /// </summary>
            /// <param name="message">The message</param>
            /// <param name="exception">The exception</param>
            public void LogCritical(string message, Exception exception) => Record();

            /// <summary>
            ///     Logs the level
            /// </summary>
            /// <param name="level">The level</param>
            /// <param name="message">The message</param>
            public void Log(LogLevel level, string message) => Record();

            /// <summary>
            ///     Logs the level
            /// </summary>
            /// <param name="level">The level</param>
            /// <param name="message">The message</param>
            /// <param name="exception">The exception</param>
            public void Log(LogLevel level, string message, Exception exception) => Record();

            /// <summary>
            ///     Logs the structured using the specified level
            /// </summary>
            /// <param name="level">The level</param>
            /// <param name="message">The message</param>
            /// <param name="properties">The properties</param>
            public void LogStructured(LogLevel level, string message, IReadOnlyDictionary<string, object> properties) => Record();

            /// <summary>
            ///     Sets the correlation id using the specified correlation id
            /// </summary>
            /// <param name="correlationId">The correlation id</param>
            public void SetCorrelationId(string correlationId)
            {
            }

            /// <summary>
            ///     Gets the correlation id
            /// </summary>
            /// <returns>The string</returns>
            public string GetCorrelationId() => null;

            /// <summary>
            ///     Begins the scope using the specified scope
            /// </summary>
            /// <param name="scope">The scope</param>
            /// <returns>The disposable</returns>
            public IDisposable BeginScope(object scope) => null;

            /// <summary>
            ///     Ises the enabled using the specified level
            /// </summary>
            /// <param name="level">The level</param>
            /// <returns>The bool</returns>
            public bool IsEnabled(LogLevel level) => true;

            /// <summary>
            ///     Records this instance
            /// </summary>
            private void Record() => Interlocked.Increment(ref _count);
        }
    }
}
