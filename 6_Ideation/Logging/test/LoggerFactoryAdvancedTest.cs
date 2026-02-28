// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: LoggerFactoryAdvancedTest.cs
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
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Filters;
using Alis.Core.Aspect.Logging.Formatters;
using Alis.Core.Aspect.Logging.Outputs;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Advanced configuration and scenario tests for LoggerFactory.
    ///     Tests complex configurations, edge cases, and special scenarios.
    /// </summary>
    public class LoggerFactoryAdvancedTest
    {
        [Fact]
        public void LoggerFactory_LargeNumberOfOutputs()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                List<MemoryLogOutput> outputs = new List<MemoryLogOutput>();
                // Add 20 outputs
                for (int i = 0; i < 20; i++)
                {
                    MemoryLogOutput output = new MemoryLogOutput();
                    outputs.Add(output);
                    factory.AddOutput(output);
                }

                ILogger logger = factory.CreateLogger("TestLogger");

                // Act
                logger.LogInfo("Message");

                // Assert
                // All outputs should receive the message
                foreach (MemoryLogOutput output in outputs)
                {
                    Assert.Single(output.GetEntries());
                }
            }
        }

        [Fact]
        public void LoggerFactory_LargeNumberOfFilters()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);

                // Add multiple filters
                factory.AddFilter(new LogLevelFilter(LogLevel.Info));
                factory.AddFilter(new ConditionalLogFilter(e => e.Message.Length > 0));
                factory.AddFilter(new ConditionalLogFilter(e => !e.LoggerName.StartsWith("Ignore")));

                ILogger logger = factory.CreateLogger("TestLogger");

                // Act
                logger.LogInfo("Should pass all filters");

                // Assert
                Assert.Single(memoryOutput.GetEntries());
            }
        }

        [Fact]
        public void LoggerFactory_SwitchFormatterDynamically()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);
                factory.SetFormatter(new SimpleLogFormatter());

                ILogger logger1 = factory.CreateLogger("Logger1");
                logger1.LogInfo("Message 1");

                // Act - Switch formatter
                factory.SetFormatter(new CompactLogFormatter());
                ILogger logger2 = factory.CreateLogger("Logger2");
                logger2.LogInfo("Message 2");

                // Assert
                Assert.Equal(2, memoryOutput.Count);
            }
        }

        [Fact]
        public void LoggerFactory_MultipleFactoryInstances()
        {
            // Arrange & Act
            MemoryLogOutput memory1 = new MemoryLogOutput();
            MemoryLogOutput memory2 = new MemoryLogOutput();

            using (LoggerFactory factory1 = new LoggerFactory())
            using (LoggerFactory factory2 = new LoggerFactory())
            {
                factory1.AddOutput(memory1);
                factory2.AddOutput(memory2);

                ILogger logger1 = factory1.CreateLogger("Logger1");
                ILogger logger2 = factory2.CreateLogger("Logger2");

                logger1.LogInfo("From factory 1");
                logger2.LogInfo("From factory 2");

                // Assert
                Assert.Single(memory1.GetEntries());
                Assert.Single(memory2.GetEntries());
                Assert.Equal("From factory 1", memory1.GetEntries()[0].Message);
                Assert.Equal("From factory 2", memory2.GetEntries()[0].Message);
            }
        }

        [Fact]
        public void LoggerFactory_AllLogLevels_AsMinimum()
        {
            // Arrange
            LogLevel[] levels = new[] { LogLevel.Trace, LogLevel.Debug, LogLevel.Info, LogLevel.Warning, LogLevel.Error, LogLevel.Critical };

            foreach (LogLevel level in levels)
            {
                using (LoggerFactory factory = new LoggerFactory())
                {
                    MemoryLogOutput memoryOutput = new MemoryLogOutput();
                    factory.AddOutput(memoryOutput)
                           .SetMinimumLevel(level);

                    ILogger logger = factory.CreateLogger("TestLogger");

                    // Act
                    logger.LogTrace("Trace");
                    logger.LogDebug("Debug");
                    logger.LogInfo("Info");
                    logger.LogWarning("Warning");
                    logger.LogError("Error");
                    logger.LogCritical("Critical");

                    // Assert
                    IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
                    foreach (ILogEntry entry in entries)
                    {
                        Assert.True(entry.Level >= level);
                    }
                }
            }
        }

        [Fact]
        public void LoggerFactory_ComplexFilterChain()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);

                LogLevelFilter filter1 = new LogLevelFilter(LogLevel.Info);
                ConditionalLogFilter filter2 = new ConditionalLogFilter(e => e.Message.Contains("important"));
                CompositeLogFilter composite = new CompositeLogFilter(new ILogFilter[] { filter1, filter2 }, requireAll: true);

                factory.AddFilter(composite);

                ILogger logger = factory.CreateLogger("TestLogger");

                // Act
                logger.LogInfo("important message");
                logger.LogInfo("normal message");
                logger.LogDebug("important message");

                // Assert
                Assert.Single(memoryOutput.GetEntries());
                Assert.Equal("important message", memoryOutput.GetEntries()[0].Message);
            }
        }

        [Fact]
        public void LoggerFactory_CreatingManyLoggers()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);

                // Act - Create 1000 loggers
                List<ILogger> loggers = new List<ILogger>();
                for (int i = 0; i < 1000; i++)
                {
                    loggers.Add(factory.CreateLogger($"Logger{i}"));
                }

                // Log from each
                foreach (ILogger logger in loggers)
                {
                    logger.LogInfo("Message");
                }

                // Assert
                Assert.Equal(1000, memoryOutput.Count);
            }
        }

        [Fact]
        public void LoggerFactory_ReuseLoggerName()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);

                // Act - Create multiple loggers with same name
                ILogger logger1 = factory.CreateLogger("SameName");
                ILogger logger2 = factory.CreateLogger("SameName");
                ILogger logger3 = factory.CreateLogger("SameName");

                logger1.LogInfo("From 1");
                logger2.LogInfo("From 2");
                logger3.LogInfo("From 3");

                // Assert
                Assert.Equal(3, memoryOutput.Count);
            }
        }

        [Fact]
        public void LoggerFactory_ErrorRecovery()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);

                ILogger logger = factory.CreateLogger("TestLogger");

                // Act - Test that errors don't break factory
                try
                {
                    factory.AddOutput(null);
                }
                catch (ArgumentNullException)
                {
                    // Expected
                }

                // Factory should still work
                logger.LogInfo("Message after error");

                // Assert
                Assert.Single(memoryOutput.GetEntries());
            }
        }

        [Fact]
        public void LoggerFactory_FlushWithMultipleOutputs()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                FlushCountingOutput flushCounter = new FlushCountingOutput();
                MemoryLogOutput memoryOutput = new MemoryLogOutput();

                factory.AddOutput(flushCounter);
                factory.AddOutput(memoryOutput);

                ILogger logger = factory.CreateLogger("TestLogger");
                logger.LogInfo("Message");

                // Act
                factory.Flush();

                // Assert
                Assert.Equal(1, flushCounter.FlushCount);
            }
        }

        private sealed class FlushCountingOutput : ILogOutput
        {
            public string Name => "FlushCounter";
            public bool IsEnabled { get; set; } = true;
            public int FlushCount { get; set; }

            public void Write(ILogEntry entry) { }

            public void Flush()
            {
                FlushCount++;
            }

            public void Dispose() { }
        }
    }
}

