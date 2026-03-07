// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StressTest.cs
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
using System.Diagnostics;
using System.Threading.Tasks;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Filters;
using Alis.Core.Aspect.Logging.Formatters;
using Alis.Core.Aspect.Logging.Outputs;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Stress and performance tests for the logging framework.
    ///     Tests high-load scenarios, memory usage, and performance characteristics.
    /// </summary>
    public class StressTest
    {
        /// <summary>
        ///     Tests that stress high frequency logging 100 k entries
        /// </summary>
        [Fact]
        public void Stress_HighFrequencyLogging_100K_Entries()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput(0);
                factory.AddOutput(memoryOutput);
                ILogger logger = factory.CreateLogger("StressTest");

                Stopwatch stopwatch = Stopwatch.StartNew();

                // Act
                for (int i = 0; i < 100000; i++)
                {
                    logger.LogInfo($"Message {i}");
                }

                stopwatch.Stop();

                // Assert
                Assert.Equal(100000, memoryOutput.Count);
                Assert.True(stopwatch.Elapsed.TotalSeconds < 30);
            }
        }

        /// <summary>
        ///     Tests that stress concurrent logging 10 threads 1 k messages each
        /// </summary>
        [Fact]
        public void Stress_ConcurrentLogging_10Threads_1KMessagesEach()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput(0);
                factory.AddOutput(memoryOutput);

                Task[] tasks = new Task[10];
                Stopwatch stopwatch = Stopwatch.StartNew();

                // Act
                for (int t = 0; t < 10; t++)
                {
                    int threadNum = t;
                    tasks[t] = Task.Run(() =>
                    {
                        ILogger logger = factory.CreateLogger($"Logger{threadNum}");
                        for (int i = 0; i < 1000; i++)
                        {
                            logger.LogInfo($"Message {i}");
                        }
                    });
                }

                Task.WaitAll(tasks);
                stopwatch.Stop();

                // Assert
                Assert.Equal(10000, memoryOutput.Count);
                Assert.True(stopwatch.Elapsed.TotalSeconds < 10);
            }
        }

        /// <summary>
        ///     Tests that stress large message size 1 mb messages
        /// </summary>
        [Fact]
        public void Stress_LargeMessageSize_1MB_Messages()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput(0);
                factory.AddOutput(memoryOutput);
                ILogger logger = factory.CreateLogger("StressTest");

                string largeMessage = new string('x', 1000000); // 1MB

                Stopwatch stopwatch = Stopwatch.StartNew();

                // Act
                for (int i = 0; i < 10; i++)
                {
                    logger.LogInfo(largeMessage);
                }

                stopwatch.Stop();

                // Assert
                Assert.Equal(10, memoryOutput.Count);
                Assert.True(stopwatch.Elapsed.TotalSeconds < 5);
            }
        }

        /// <summary>
        ///     Tests that stress many loggers 1000 loggers
        /// </summary>
        [Fact]
        public void Stress_ManyLoggers_1000_Loggers()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput(0);
                factory.AddOutput(memoryOutput);

                Stopwatch stopwatch = Stopwatch.StartNew();

                // Act
                ILogger[] loggers = new ILogger[1000];
                for (int i = 0; i < 1000; i++)
                {
                    loggers[i] = factory.CreateLogger($"Logger{i}");
                }

                for (int i = 0; i < 1000; i++)
                {
                    loggers[i].LogInfo("Message");
                }

                stopwatch.Stop();

                // Assert
                Assert.Equal(1000, memoryOutput.Count);
                Assert.True(stopwatch.Elapsed.TotalSeconds < 5);
            }
        }

        /// <summary>
        ///     Tests that stress deep scope nesting 100 levels
        /// </summary>
        [Fact]
        public void Stress_DeepScopeNesting_100_Levels()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput(0);
                factory.AddOutput(memoryOutput);
                ILogger logger = factory.CreateLogger("StressTest");

                Stopwatch stopwatch = Stopwatch.StartNew();

                // Act - Create deeply nested scopes
                Action<int> logAtDepth = null;
                logAtDepth = depth =>
                {
                    if (depth == 0)
                    {
                        logger.LogInfo("Deep message");
                    }
                    else
                    {
                        using (logger.BeginScope($"Level{depth}"))
                        {
                            logAtDepth(depth - 1);
                        }
                    }
                };

                logAtDepth(100);
                stopwatch.Stop();

                // Assert
                Assert.Single(memoryOutput.GetEntries());
                Assert.Equal(100, memoryOutput.GetEntries()[0].Scopes.Count);
                Assert.True(stopwatch.Elapsed.TotalSeconds < 2);
            }
        }

        /// <summary>
        ///     Tests that stress many filters 50 filters
        /// </summary>
        [Fact]
        public void Stress_ManyFilters_50_Filters()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput(0);
                factory.AddOutput(memoryOutput);

                // Add many filters
                for (int i = 0; i < 50; i++)
                {
                    factory.AddFilter(new ConditionalLogFilter(e => true)); // Always pass
                }

                ILogger logger = factory.CreateLogger("StressTest");

                Stopwatch stopwatch = Stopwatch.StartNew();

                // Act
                for (int i = 0; i < 1000; i++)
                {
                    logger.LogInfo($"Message {i}");
                }

                stopwatch.Stop();

                // Assert
                Assert.Equal(1000, memoryOutput.Count);
                Assert.True(stopwatch.Elapsed.TotalSeconds < 10);
            }
        }

        /// <summary>
        ///     Tests that stress all formatter types performance
        /// </summary>
        [Fact]
        public void Stress_AllFormatterTypes_Performance()
        {
            // Arrange
            ILogFormatter[] formatters = new ILogFormatter[]
            {
                new SimpleLogFormatter(),
                new CompactLogFormatter(),
                new JsonLogFormatter()
            };

            LogEntry entry = new LogEntry(LogLevel.Info, "Test message", "Logger");
            const int iterations = 10000;

            // Act
            foreach (ILogFormatter formatter in formatters)
            {
                Stopwatch stopwatch = Stopwatch.StartNew();

                for (int i = 0; i < iterations; i++)
                {
                    formatter.Format(entry);
                }

                stopwatch.Stop();

                // Assert - Each formatter should handle 10K formats in reasonable time
                Assert.True(stopwatch.Elapsed.TotalSeconds < 5,
                    $"{formatter.Name} took {stopwatch.Elapsed.TotalSeconds}s for {iterations} iterations");
            }
        }

        /// <summary>
        ///     Tests that stress high memory usage scenario
        /// </summary>
        [Fact]
        public void Stress_HighMemoryUsage_Scenario()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput(10000);
                factory.AddOutput(memoryOutput);
                ILogger logger = factory.CreateLogger("StressTest");

                Stopwatch stopwatch = Stopwatch.StartNew();

                // Act - Log with increasingly large messages
                for (int i = 0; i < 100; i++)
                {
                    string message = new string('x', i * 1000); // 0KB, 1KB, 2KB, ..., 99KB
                    logger.LogInfo(message);
                }

                stopwatch.Stop();

                // Assert
                Assert.Equal(100, memoryOutput.Count);
                Assert.True(stopwatch.Elapsed.TotalSeconds < 5);
            }
        }

        /// <summary>
        ///     Tests that stress exception logging with stack trace
        /// </summary>
        /// <exception cref="InvalidOperationException">Error {i}</exception>
        [Fact]
        public void Stress_ExceptionLogging_With_StackTrace()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput(0);
                factory.AddOutput(memoryOutput);
                ILogger logger = factory.CreateLogger("StressTest");

                Stopwatch stopwatch = Stopwatch.StartNew();

                // Act - Log many exceptions with stack traces
                for (int i = 0; i < 1000; i++)
                {
                    try
                    {
                        throw new InvalidOperationException($"Error {i}");
                    }
                    catch (Exception ex)
                    {
                        logger.LogError("Exception occurred", ex);
                    }
                }

                stopwatch.Stop();

                // Assert
                Assert.Equal(1000, memoryOutput.Count);
                Assert.True(stopwatch.Elapsed.TotalSeconds < 15);
            }
        }

        /// <summary>
        ///     Tests that stress sampling filter performance
        /// </summary>
        [Fact]
        public void Stress_Sampling_Filter_Performance()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput(0);
                factory.AddOutput(memoryOutput);
                factory.AddFilter(new SamplingLogFilter()); // Log 1 in 10

                ILogger logger = factory.CreateLogger("StressTest");

                Stopwatch stopwatch = Stopwatch.StartNew();

                // Act - Log 100K messages with sampling
                for (int i = 0; i < 100000; i++)
                {
                    logger.LogInfo($"Message {i}");
                }

                stopwatch.Stop();

                // Assert
                Assert.Equal(10000, memoryOutput.Count); // 100K / 10 = 10K
                Assert.True(stopwatch.Elapsed.TotalSeconds < 10);
            }
        }
    }
}