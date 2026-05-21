// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AsyncLogOutputEdgeCasesTest.cs
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
using System.Threading.Tasks;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Outputs;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test.Outputs
{
    /// <summary>
    ///     Edge case and stress tests for AsyncLogOutput.
    ///     Tests queue behavior, concurrent writes, and performance.
    /// </summary>
    public class AsyncLogOutputEdgeCasesTest
    {
        /// <summary>
        ///     Tests that async log output high volume writes
        /// </summary>
        [Fact]
        public void AsyncLogOutput_HighVolumeWrites()
        {
            MemoryLogOutput innerOutput = new MemoryLogOutput(0);
            AsyncLogOutput asyncOutput = new AsyncLogOutput(innerOutput);

            for (int i = 0; i < 10000; i++)
            {
                asyncOutput.Write(new LogEntry(LogLevel.Info, $"Message {i}", "Logger"));
            }

            asyncOutput.Flush();

            Assert.Equal(10000, innerOutput.Count);
        }

        /// <summary>
        ///     Tests that async log output concurrent writes
        /// </summary>
        [Fact]
        public void AsyncLogOutput_ConcurrentWrites()
        {
            MemoryLogOutput innerOutput = new MemoryLogOutput(0);
            AsyncLogOutput asyncOutput = new AsyncLogOutput(innerOutput);
            Task[] tasks = new Task[10];

            for (int t = 0; t < 10; t++)
            {
                int threadNum = t;
                tasks[t] = Task.Run(() =>
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        asyncOutput.Write(new LogEntry(LogLevel.Info, $"T{threadNum}-M{i}", "Logger"));
                    }
                });
            }

            Task.WaitAll(tasks);
            asyncOutput.Flush();

            Assert.Equal(10000, innerOutput.Count);
        }

        /// <summary>
        ///     Tests that async log output flush multiple times
        /// </summary>
        [Fact]
        public void AsyncLogOutput_FlushMultipleTimes()
        {
            MemoryLogOutput innerOutput = new MemoryLogOutput(0);
            AsyncLogOutput asyncOutput = new AsyncLogOutput(innerOutput);

            asyncOutput.Write(new LogEntry(LogLevel.Info, "Message 1", "Logger"));
            asyncOutput.Flush();
            Assert.Equal(1, innerOutput.Count);

            asyncOutput.Write(new LogEntry(LogLevel.Info, "Message 2", "Logger"));
            asyncOutput.Flush();
            Assert.Equal(2, innerOutput.Count);

            asyncOutput.Write(new LogEntry(LogLevel.Info, "Message 3", "Logger"));
            asyncOutput.Flush();

            Assert.Equal(3, innerOutput.Count);
        }

        /// <summary>
        ///     Tests that async log output disable then enable
        /// </summary>
        [Fact]
        public void AsyncLogOutput_DisableThenEnable()
        {
            MemoryLogOutput innerOutput = new MemoryLogOutput(0);
            AsyncLogOutput asyncOutput = new AsyncLogOutput(innerOutput);

            asyncOutput.Write(new LogEntry(LogLevel.Info, "Message 1", "Logger"));
            asyncOutput.IsEnabled = false;
            asyncOutput.Write(new LogEntry(LogLevel.Info, "Message 2", "Logger"));
            asyncOutput.IsEnabled = true;
            asyncOutput.Write(new LogEntry(LogLevel.Info, "Message 3", "Logger"));
            asyncOutput.Flush();

            Assert.Equal(2, innerOutput.Count);
        }

        /// <summary>
        ///     Tests that async log output large messages
        /// </summary>
        [Fact]
        public void AsyncLogOutput_LargeMessages()
        {
            MemoryLogOutput innerOutput = new MemoryLogOutput(0);
            AsyncLogOutput asyncOutput = new AsyncLogOutput(innerOutput);
            string largeMessage = new string('x', 100000);

            for (int i = 0; i < 10; i++)
            {
                asyncOutput.Write(new LogEntry(LogLevel.Info, largeMessage, "Logger"));
            }

            asyncOutput.Flush();

            Assert.Equal(10, innerOutput.Count);
        }

        /// <summary>
        ///     Tests that async log output queue filling
        /// </summary>
        [Fact]
        public void AsyncLogOutput_QueueFilling()
        {
            MemoryLogOutput innerOutput = new MemoryLogOutput(0);
            AsyncLogOutput asyncOutput = new AsyncLogOutput(innerOutput, 5);

            for (int i = 0; i < 20; i++)
            {
                asyncOutput.Write(new LogEntry(LogLevel.Info, $"Message {i}", "Logger"));
            }

            asyncOutput.Flush();

            Assert.True(innerOutput.Count <= 20);
            Assert.True(innerOutput.Count > 0);
        }

        /// <summary>
        ///     Tests that async log output dispose cleans up
        /// </summary>
        [Fact]
        public void AsyncLogOutput_DisposeCleansUp()
        {
            MemoryLogOutput innerOutput = new MemoryLogOutput(0);
            AsyncLogOutput asyncOutput = new AsyncLogOutput(innerOutput);

            for (int i = 0; i < 100; i++)
            {
                asyncOutput.Write(new LogEntry(LogLevel.Info, $"Message {i}", "Logger"));
            }

            asyncOutput.Dispose();

            Assert.False(innerOutput.Count > 0);
        }

        /// <summary>
        ///     Tests that async log output multiple disposes
        /// </summary>
        [Fact]
        public void AsyncLogOutput_MultipleDisposes()
        {
            MemoryLogOutput innerOutput = new MemoryLogOutput(0);
            AsyncLogOutput asyncOutput = new AsyncLogOutput(innerOutput);

            asyncOutput.Write(new LogEntry(LogLevel.Info, "Message", "Logger"));

            asyncOutput.Dispose();
            asyncOutput.Dispose();
        }

        /// <summary>
        ///     Tests that async log output flush after dispose
        /// </summary>
        [Fact]
        public void AsyncLogOutput_FlushAfterDispose()
        {
            MemoryLogOutput innerOutput = new MemoryLogOutput(0);
            AsyncLogOutput asyncOutput = new AsyncLogOutput(innerOutput);

            asyncOutput.Write(new LogEntry(LogLevel.Info, "Message", "Logger"));
            asyncOutput.Dispose();

            asyncOutput.Flush();
        }

        /// <summary>
        ///     Tests that async log output all log levels
        /// </summary>
        [Fact]
        public void AsyncLogOutput_AllLogLevels()
        {
            MemoryLogOutput innerOutput = new MemoryLogOutput(0);
            AsyncLogOutput asyncOutput = new AsyncLogOutput(innerOutput);
            LogLevel[] levels = new[] {LogLevel.Trace, LogLevel.Debug, LogLevel.Info, LogLevel.Warning, LogLevel.Error, LogLevel.Critical};

            foreach (LogLevel level in levels)
            {
                asyncOutput.Write(new LogEntry(level, "Message", "Logger"));
            }

            asyncOutput.Flush();

            Assert.Equal(6, innerOutput.Count);
        }

        /// <summary>
        ///     Tests that async log output performance test
        /// </summary>
        [Fact]
        public void AsyncLogOutput_PerformanceTest()
        {
            MemoryLogOutput innerOutput = new MemoryLogOutput(0);
            AsyncLogOutput asyncOutput = new AsyncLogOutput(innerOutput);
            DateTime startTime = DateTime.UtcNow;

            for (int i = 0; i < 50000; i++)
            {
                asyncOutput.Write(new LogEntry(LogLevel.Info, $"Message {i}", "Logger"));
            }

            asyncOutput.Flush();

            TimeSpan elapsed = DateTime.UtcNow - startTime;

            Assert.True(elapsed.TotalSeconds < 10);
        }
    }
}