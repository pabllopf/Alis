// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ThreadSafetyTest.cs
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

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Outputs;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Tests for thread safety and concurrent logging scenarios.
    /// </summary>
    public class ThreadSafetyTest
    {
        /// <summary>
        /// Tests that logger concurrent logging should not corrupt entries
        /// </summary>
        [Fact]
        public void Logger_ConcurrentLogging_ShouldNotCorruptEntries()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput(0); // unlimited
                factory.AddOutput(memoryOutput);
                ILogger logger = factory.CreateLogger("ThreadTestLogger");

                const int threadCount = 10;
                const int messagesPerThread = 100;
                List<Task> tasks = new List<Task>();

                for (int t = 0; t < threadCount; t++)
                {
                    int threadId = t;
                    Task task = Task.Run(() =>
                    {
                        for (int i = 0; i < messagesPerThread; i++)
                        {
                            logger.LogInfo($"Thread {threadId} Message {i}");
                        }
                    });
                    tasks.Add(task);
                }

                Task.WaitAll(tasks.ToArray());

                IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
                Assert.Equal(threadCount * messagesPerThread, entries.Count);

                // Verify all entries are valid
                foreach (ILogEntry entry in entries)
                {
                    Assert.NotNull(entry.Message);
                    Assert.NotEqual(0, entry.ThreadId);
                }
            }
        }


        /// <summary>
        /// Tests that logger concurrent correlation id setting should be thread safe
        /// </summary>
        [Fact]
        public void Logger_ConcurrentCorrelationIdSetting_ShouldBeThreadSafe()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput(0);
                factory.AddOutput(memoryOutput);
                ILogger logger = factory.CreateLogger("ThreadTestLogger");

                const int threadCount = 10;
                List<Task> tasks = new List<Task>();
                List<string> correlationIds = new List<string>();

                for (int t = 0; t < threadCount; t++)
                {
                    int threadId = t;
                    string correlationId = $"Correlation-{threadId}";
                    correlationIds.Add(correlationId);

                    Task task = Task.Run(() =>
                    {
                        logger.SetCorrelationId(correlationId);
                        Thread.Sleep(10); // Simulate work
                        logger.LogInfo($"Message from thread {threadId}");
                    });
                    tasks.Add(task);
                }

                Task.WaitAll(tasks.ToArray());

                IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
                Assert.Equal(threadCount, entries.Count);
            }
        }

        /// <summary>
        /// Tests that memory log output concurrent writes should preserve all entries
        /// </summary>
        [Fact]
        public void MemoryLogOutput_ConcurrentWrites_ShouldPreserveAllEntries()
        {
            MemoryLogOutput memoryOutput = new MemoryLogOutput(0);
            const int threadCount = 10;
            const int entriesPerThread = 100;
            List<Task> tasks = new List<Task>();

            for (int t = 0; t < threadCount; t++)
            {
                int threadId = t;
                Task task = Task.Run(() =>
                {
                    for (int i = 0; i < entriesPerThread; i++)
                    {
                        LogEntry entry = new LogEntry(LogLevel.Info, $"Message {i}", $"Logger{threadId}");
                        memoryOutput.Write(entry);
                    }
                });
                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            Assert.Equal(threadCount * entriesPerThread, memoryOutput.Count);
        }
    }
}