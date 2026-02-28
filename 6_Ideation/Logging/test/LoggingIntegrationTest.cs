// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: LoggingIntegrationTest.cs
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
using System.Collections.Generic;
using System.Threading.Tasks;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Filters;
using Alis.Core.Aspect.Logging.Formatters;
using Alis.Core.Aspect.Logging.Outputs;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Integration tests for the complete logging framework.
    ///     Validates end-to-end workflows and complex scenarios.
    /// </summary>
    public class LoggingIntegrationTest
    {
        [Fact]
        public void Integration_CompleteWorkflow_ShouldSucceed()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory
                    .AddOutput(memoryOutput)
                    .AddFilter(new LogLevelFilter(LogLevel.Info))
                    .SetFormatter(new SimpleLogFormatter())
                    .SetMinimumLevel(LogLevel.Trace);

                ILogger logger = factory.CreateLogger("IntegrationTest");
                logger.SetCorrelationId("SESSION-123");

                // Act
                using (logger.BeginScope("Setup"))
                {
                    logger.LogInfo("Starting test");
                }

                using (logger.BeginScope("Execution"))
                {
                    logger.LogInfo("Executing task");
                    logger.LogWarning("Potential issue");
                }

                using (logger.BeginScope("Cleanup"))
                {
                    logger.LogInfo("Cleaning up");
                }

                // Assert
                IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
                Assert.Equal(4, entries.Count);
                Assert.All(entries, e => Assert.Equal("SESSION-123", e.CorrelationId));
            }
        }

        [Fact]
        public void Integration_MultipleLoggersMultipleOutputs_ShouldSucceed()
        {
            // Arrange
            MemoryLogOutput memory1 = new MemoryLogOutput();
            MemoryLogOutput memory2 = new MemoryLogOutput();

            using (LoggerFactory factory = new LoggerFactory())
            {
                factory.AddOutput(memory1);
                factory.AddOutput(memory2);

                ILogger logger1 = factory.CreateLogger("Logger1");
                ILogger logger2 = factory.CreateLogger("Logger2");

                // Act
                logger1.LogInfo("Message from Logger1");
                logger2.LogInfo("Message from Logger2");

                // Assert
                Assert.Equal(2, memory1.Count);
                Assert.Equal(2, memory2.Count);
            }
        }

        [Fact]
        public void Integration_ComplexFiltering_ShouldSucceed()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);

                List<ILogFilter> filters = new List<ILogFilter>
                {
                    new LogLevelFilter(LogLevel.Warning),
                    new LoggerNameFilter(new[] { "Engine", "Physics" }, inclusive: true),
                    new SamplingLogFilter(sampleRate: 2)
                };
                CompositeLogFilter composite = new CompositeLogFilter(filters, requireAll: false);
                factory.AddFilter(composite);

                ILogger engineLogger = factory.CreateLogger("Engine");
                ILogger physicsLogger = factory.CreateLogger("Physics");
                ILogger audioLogger = factory.CreateLogger("Audio");

                // Act
                for (int i = 0; i < 10; i++)
                {
                    engineLogger.LogWarning($"Engine warning {i}");
                    physicsLogger.LogWarning($"Physics warning {i}");
                    audioLogger.LogWarning($"Audio warning {i}");
                }

                // Assert - Should have some entries due to OR filter and sampling
                Assert.True(memoryOutput.Count > 0);
            }
        }

        [Fact]
        public void Integration_StructuredLoggingWithContexts_ShouldSucceed()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput)
                       .SetFormatter(new JsonLogFormatter());

                ILogger logger = factory.CreateLogger("GameEngine");
                logger.SetCorrelationId(Guid.NewGuid().ToString("N").Substring(0, 8));

                // Act
                using (logger.BeginScope("Scene:MainMenu"))
                {
                    Dictionary<string, object> playerData = new Dictionary<string, object>
                    {
                        { "PlayerId", 1001 },
                        { "PlayerName", "Hero" },
                        { "Level", 50 }
                    };
                    logger.LogStructured(LogLevel.Info, "Player loaded", playerData);
                }

                // Assert
                IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
                Assert.Single(entries);
                Assert.Equal(3, entries[0].Properties.Count);
                Assert.Single(entries[0].Scopes);
            }
        }

        [Fact]
        public void Integration_ExceptionHandling_ShouldSucceed()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);

                ILogger logger = factory.CreateLogger("ErrorTest");

                // Act
                try
                {
                    throw new InvalidOperationException("Critical operation failed");
                }
                catch (Exception ex)
                {
                    logger.LogError("Operation failed", ex);
                }

                // Assert
                IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
                Assert.Single(entries);
                Assert.NotNull(entries[0].Exception);
                Assert.IsType<InvalidOperationException>(entries[0].Exception);
            }
        }

        [Fact]
        public void Integration_ConcurrentLoggingFromMultipleThreads_ShouldSucceed()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput(maxEntries: 0);
                factory.AddOutput(memoryOutput);

                ILogger logger = factory.CreateLogger("ConcurrentTest");
                const int threadCount = 10;
                const int messagesPerThread = 100;
                List<Task> tasks = new List<Task>();

                // Act
                for (int t = 0; t < threadCount; t++)
                {
                    int threadNum = t;
                    Task task = Task.Run(() =>
                    {
                        ILogger threadLogger = factory.CreateLogger($"Thread{threadNum}");
                        for (int i = 0; i < messagesPerThread; i++)
                        {
                            threadLogger.LogInfo($"Message {i}");
                        }
                    });
                    tasks.Add(task);
                }

                Task.WaitAll(tasks.ToArray());

                // Assert
                Assert.Equal(threadCount * messagesPerThread, memoryOutput.Count);
            }
        }

        [Fact]
        public void Integration_FormatterAndOutputCombinations_ShouldSucceed()
        {
            // Arrange & Act & Assert
            ILogFormatter[] formatters = new ILogFormatter[]
            {
                new SimpleLogFormatter(),
                new CompactLogFormatter(),
                new JsonLogFormatter()
            };

            foreach (ILogFormatter formatter in formatters)
            {
                using (LoggerFactory factory = new LoggerFactory())
                {
                    MemoryLogOutput memoryOutput = new MemoryLogOutput();
                    factory.AddOutput(memoryOutput)
                           .SetFormatter(formatter);

                    ILogger logger = factory.CreateLogger("FormatterTest");
                    logger.LogInfo("Test message");

                    IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
                    Assert.Single(entries);
                }
            }
        }

        [Fact]
        public void Integration_ScopedContextsWithMultipleLevels_ShouldSucceed()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);

                ILogger logger = factory.CreateLogger("ScopeTest");

                // Act
                using (logger.BeginScope("Level1"))
                {
                    logger.LogInfo("At level 1");

                    using (logger.BeginScope("Level2"))
                    {
                        logger.LogInfo("At level 2");

                        using (logger.BeginScope("Level3"))
                        {
                            logger.LogInfo("At level 3");
                        }

                        logger.LogInfo("Back to level 2");
                    }

                    logger.LogInfo("Back to level 1");
                }

                // Assert
                IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
                Assert.Equal(5, entries.Count);
                Assert.Equal(1, entries[0].Scopes.Count);
                Assert.Equal(2, entries[1].Scopes.Count);
                Assert.Equal(3, entries[2].Scopes.Count);
                Assert.Equal(2, entries[3].Scopes.Count);
                Assert.Equal(1, entries[4].Scopes.Count);
            }
        }

        [Fact]
        public void Integration_GameLoopSimulation_ShouldSucceed()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput(maxEntries: 0);
                factory.AddOutput(memoryOutput)
                       .AddFilter(new SamplingLogFilter(sampleRate: 10)); // Log 1 in 10

                ILogger engineLogger = factory.CreateLogger("Engine");
                ILogger rendererLogger = factory.CreateLogger("Renderer");
                ILogger physicsLogger = factory.CreateLogger("Physics");

                // Act - Simulate 100 frames
                for (int frame = 0; frame < 100; frame++)
                {
                    using (engineLogger.BeginScope($"Frame:{frame}"))
                    {
                        rendererLogger.LogDebug("Rendering");
                        physicsLogger.LogDebug("Physics update");
                        engineLogger.LogDebug("Input processing");
                    }
                }

                // Assert
                // With 1 in 10 sampling, should have approximately 30 entries (3 per frame × 10 frames)
                Assert.True(memoryOutput.Count >= 25 && memoryOutput.Count <= 35);
            }
        }
    }
}

