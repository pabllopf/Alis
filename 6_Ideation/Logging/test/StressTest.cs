// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: StressTest.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web: https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program. If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Alis.Core.Aspect.Logging;
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
        [Fact]
        public void Stress_HighFrequencyLogging_100K_Entries()
        {
            // Arrange
            using (var factory = new LoggerFactory())
            {
                var memoryOutput = new MemoryLogOutput(maxEntries: 0);
                factory.AddOutput(memoryOutput);
                var logger = factory.CreateLogger("StressTest");

                var stopwatch = Stopwatch.StartNew();

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

        [Fact]
        public void Stress_ConcurrentLogging_10Threads_1KMessagesEach()
        {
            // Arrange
            using (var factory = new LoggerFactory())
            {
                var memoryOutput = new MemoryLogOutput(maxEntries: 0);
                factory.AddOutput(memoryOutput);

                var tasks = new Task[10];
                var stopwatch = Stopwatch.StartNew();

                // Act
                for (int t = 0; t < 10; t++)
                {
                    int threadNum = t;
                    tasks[t] = Task.Run(() =>
                    {
                        var logger = factory.CreateLogger($"Logger{threadNum}");
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

        [Fact]
        public void Stress_LargeMessageSize_1MB_Messages()
        {
            // Arrange
            using (var factory = new LoggerFactory())
            {
                var memoryOutput = new MemoryLogOutput(maxEntries: 0);
                factory.AddOutput(memoryOutput);
                var logger = factory.CreateLogger("StressTest");

                var largeMessage = new string('x', 1000000); // 1MB

                var stopwatch = Stopwatch.StartNew();

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

        [Fact]
        public void Stress_ManyLoggers_1000_Loggers()
        {
            // Arrange
            using (var factory = new LoggerFactory())
            {
                var memoryOutput = new MemoryLogOutput(maxEntries: 0);
                factory.AddOutput(memoryOutput);

                var stopwatch = Stopwatch.StartNew();

                // Act
                var loggers = new ILogger[1000];
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

        [Fact]
        public void Stress_DeepScopeNesting_100_Levels()
        {
            // Arrange
            using (var factory = new LoggerFactory())
            {
                var memoryOutput = new MemoryLogOutput(maxEntries: 0);
                factory.AddOutput(memoryOutput);
                var logger = factory.CreateLogger("StressTest");

                var stopwatch = Stopwatch.StartNew();

                // Act - Create deeply nested scopes
                Action<int> logAtDepth = null;
                logAtDepth = (depth) =>
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

        [Fact]
        public void Stress_ManyFilters_50_Filters()
        {
            // Arrange
            using (var factory = new LoggerFactory())
            {
                var memoryOutput = new MemoryLogOutput(maxEntries: 0);
                factory.AddOutput(memoryOutput);

                // Add many filters
                for (int i = 0; i < 50; i++)
                {
                    factory.AddFilter(new ConditionalLogFilter(e => true)); // Always pass
                }

                var logger = factory.CreateLogger("StressTest");

                var stopwatch = Stopwatch.StartNew();

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

        [Fact]
        public void Stress_AllFormatterTypes_Performance()
        {
            // Arrange
            var formatters = new ILogFormatter[]
            {
                new SimpleLogFormatter(),
                new CompactLogFormatter(),
                new JsonLogFormatter()
            };

            var entry = new LogEntry(LogLevel.Info, "Test message", "Logger");
            const int iterations = 10000;

            // Act
            foreach (var formatter in formatters)
            {
                var stopwatch = Stopwatch.StartNew();

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

        [Fact]
        public void Stress_HighMemoryUsage_Scenario()
        {
            // Arrange
            using (var factory = new LoggerFactory())
            {
                var memoryOutput = new MemoryLogOutput(maxEntries: 10000);
                factory.AddOutput(memoryOutput);
                var logger = factory.CreateLogger("StressTest");

                var stopwatch = Stopwatch.StartNew();

                // Act - Log with increasingly large messages
                for (int i = 0; i < 100; i++)
                {
                    var message = new string('x', i * 1000); // 0KB, 1KB, 2KB, ..., 99KB
                    logger.LogInfo(message);
                }

                stopwatch.Stop();

                // Assert
                Assert.Equal(100, memoryOutput.Count);
                Assert.True(stopwatch.Elapsed.TotalSeconds < 5);
            }
        }

        [Fact]
        public void Stress_ExceptionLogging_With_StackTrace()
        {
            // Arrange
            using (var factory = new LoggerFactory())
            {
                var memoryOutput = new MemoryLogOutput(maxEntries: 0);
                factory.AddOutput(memoryOutput);
                var logger = factory.CreateLogger("StressTest");

                var stopwatch = Stopwatch.StartNew();

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

        [Fact]
        public void Stress_Sampling_Filter_Performance()
        {
            // Arrange
            using (var factory = new LoggerFactory())
            {
                var memoryOutput = new MemoryLogOutput(maxEntries: 0);
                factory.AddOutput(memoryOutput);
                factory.AddFilter(new SamplingLogFilter(sampleRate: 10)); // Log 1 in 10

                var logger = factory.CreateLogger("StressTest");

                var stopwatch = Stopwatch.StartNew();

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

