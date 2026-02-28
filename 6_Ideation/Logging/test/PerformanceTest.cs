// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PerformanceTest.cs
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
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Filters;
using Alis.Core.Aspect.Logging.Formatters;
using Alis.Core.Aspect.Logging.Outputs;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Performance benchmarks for the logging framework.
    ///     Validates that logging doesn't significantly impact application performance.
    /// </summary>
    public class PerformanceTest
    {
        [Fact]
        public void Performance_SimpleLogging_10KMessages_UnderXSeconds()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput(0);
                factory.AddOutput(memoryOutput);
                ILogger logger = factory.CreateLogger("PerfTest");

                Stopwatch stopwatch = Stopwatch.StartNew();

                // Act
                for (int i = 0; i < 10000; i++)
                {
                    logger.LogInfo($"Message {i}");
                }

                stopwatch.Stop();

                // Assert
                Assert.Equal(10000, memoryOutput.Count);
                Assert.True(stopwatch.Elapsed.TotalSeconds < 5,
                    $"10K messages took {stopwatch.Elapsed.TotalSeconds}s, expected < 5s");
            }
        }

        [Fact]
        public void Performance_FormattedLogging_1KMessages_UnderYSeconds()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput(0);
                factory.AddOutput(memoryOutput)
                    .SetFormatter(new SimpleLogFormatter());
                ILogger logger = factory.CreateLogger("PerfTest");

                Stopwatch stopwatch = Stopwatch.StartNew();

                // Act
                for (int i = 0; i < 1000; i++)
                {
                    logger.LogInfo($"Formatted message {i}");
                }

                stopwatch.Stop();

                // Assert
                Assert.Equal(1000, memoryOutput.Count);
                Assert.True(stopwatch.Elapsed.TotalSeconds < 3,
                    $"1K formatted messages took {stopwatch.Elapsed.TotalSeconds}s, expected < 3s");
            }
        }

        [Fact]
        public void Performance_JsonFormattedLogging_1KMessages_UnderYSeconds()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput(0);
                factory.AddOutput(memoryOutput)
                    .SetFormatter(new JsonLogFormatter());
                ILogger logger = factory.CreateLogger("PerfTest");

                Stopwatch stopwatch = Stopwatch.StartNew();

                // Act
                for (int i = 0; i < 1000; i++)
                {
                    logger.LogInfo($"JSON message {i}");
                }

                stopwatch.Stop();

                // Assert
                Assert.Equal(1000, memoryOutput.Count);
                Assert.True(stopwatch.Elapsed.TotalSeconds < 3,
                    $"1K JSON formatted messages took {stopwatch.Elapsed.TotalSeconds}s, expected < 3s");
            }
        }

        [Fact]
        public void Performance_CompactFormattedLogging_1KMessages_UnderYSeconds()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput(0);
                factory.AddOutput(memoryOutput)
                    .SetFormatter(new CompactLogFormatter());
                ILogger logger = factory.CreateLogger("PerfTest");

                Stopwatch stopwatch = Stopwatch.StartNew();

                // Act
                for (int i = 0; i < 1000; i++)
                {
                    logger.LogInfo($"Compact message {i}");
                }

                stopwatch.Stop();

                // Assert
                Assert.Equal(1000, memoryOutput.Count);
                Assert.True(stopwatch.Elapsed.TotalSeconds < 3,
                    $"1K compact formatted messages took {stopwatch.Elapsed.TotalSeconds}s, expected < 3s");
            }
        }

        [Fact]
        public void Performance_WithFiltering_10KMessages_UnderXSeconds()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput(0);
                factory.AddOutput(memoryOutput)
                    .AddFilter(new LogLevelFilter(LogLevel.Info));
                ILogger logger = factory.CreateLogger("PerfTest");

                Stopwatch stopwatch = Stopwatch.StartNew();

                // Act
                for (int i = 0; i < 10000; i++)
                {
                    logger.LogInfo($"Message {i}");
                }

                stopwatch.Stop();

                // Assert
                Assert.Equal(10000, memoryOutput.Count);
                Assert.True(stopwatch.Elapsed.TotalSeconds < 5,
                    $"10K filtered messages took {stopwatch.Elapsed.TotalSeconds}s, expected < 5s");
            }
        }

        [Fact]
        public void Performance_WithScopesLogging_1KMessages_UnderYSeconds()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput(0);
                factory.AddOutput(memoryOutput);
                ILogger logger = factory.CreateLogger("PerfTest");

                Stopwatch stopwatch = Stopwatch.StartNew();

                // Act
                for (int i = 0; i < 1000; i++)
                {
                    using (logger.BeginScope($"Request{i}"))
                    {
                        logger.LogInfo($"Message {i}");
                    }
                }

                stopwatch.Stop();

                // Assert
                Assert.Equal(1000, memoryOutput.Count);
                Assert.True(stopwatch.Elapsed.TotalSeconds < 5,
                    $"1K scoped messages took {stopwatch.Elapsed.TotalSeconds}s, expected < 5s");
            }
        }

        [Fact]
        public void Performance_ExceptionLogging_1KMessages_UnderYSeconds()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput(0);
                factory.AddOutput(memoryOutput);
                ILogger logger = factory.CreateLogger("PerfTest");

                Stopwatch stopwatch = Stopwatch.StartNew();

                // Act
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
                Assert.True(stopwatch.Elapsed.TotalSeconds < 10,
                    $"1K exception messages took {stopwatch.Elapsed.TotalSeconds}s, expected < 10s");
            }
        }

        [Fact]
        public void Performance_MemoryOutputStorage_Limits()
        {
            // Arrange
            MemoryLogOutput output = new MemoryLogOutput(100);

            // Act
            for (int i = 0; i < 1000; i++)
            {
                output.Write(new LogEntry(LogLevel.Info, $"Message {i}", "Logger"));
            }

            // Assert
            Assert.Equal(100, output.Count);
        }
    }
}