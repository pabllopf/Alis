// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: ContextualLoggingTest.cs
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
using Alis.Core.Aspect.Logging.Formatters;
using Alis.Core.Aspect.Logging.Outputs;
using Xunit;
using Alis.Core.Aspect.Logging.Formatters;
using Alis.Core.Aspect.Logging.Outputs;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Tests for contextual logging features like scopes and correlation IDs.
    ///     Validates that context is properly maintained throughout the logging chain.
    /// </summary>
    public class ContextualLoggingTest
    {
        [Fact]
        public void CorrelationId_SetAndGet_ShouldMatch()
        {
            // Arrange
            using (var factory = new LoggerFactory())
            {
                var logger = factory.CreateLogger("TestLogger");
                var correlationId = "CORR-" + Guid.NewGuid();

                // Act
                logger.SetCorrelationId(correlationId);
                var retrieved = logger.GetCorrelationId();

                // Assert
                Assert.Equal(correlationId, retrieved);
            }
        }

        [Fact]
        public void CorrelationId_InLogEntry_ShouldBePreserved()
        {
            // Arrange
            using (var factory = new LoggerFactory())
            {
                var memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);
                var logger = factory.CreateLogger("TestLogger");
                var correlationId = "CORR-123";

                logger.SetCorrelationId(correlationId);

                // Act
                logger.LogInfo("Test message");

                // Assert
                var entries = memoryOutput.GetEntries();
                Assert.Single(entries);
                Assert.Equal(correlationId, entries[0].CorrelationId);
            }
        }

        [Fact]
        public void Scope_BeginAndEnd_ShouldCaptureContext()
        {
            // Arrange
            using (var factory = new LoggerFactory())
            {
                var memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);
                var logger = factory.CreateLogger("TestLogger");

                // Act
                using (logger.BeginScope("RequestScope"))
                {
                    logger.LogInfo("Inside scope");
                }
                logger.LogInfo("Outside scope");

                // Assert
                var entries = memoryOutput.GetEntries();
                Assert.Equal(2, entries.Count);
                Assert.Single(entries[0].Scopes);
                Assert.Empty(entries[1].Scopes);
            }
        }

        [Fact]
        public void Scope_NestedScopes_ShouldMaintainStack()
        {
            // Arrange
            using (var factory = new LoggerFactory())
            {
                var memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);
                var logger = factory.CreateLogger("TestLogger");

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
                    }
                }

                // Assert
                var entries = memoryOutput.GetEntries();
                Assert.Equal(3, entries.Count);
                
                Assert.Single(entries[0].Scopes);
                Assert.Equal("Level1", entries[0].Scopes[0]);

                Assert.Equal(2, entries[1].Scopes.Count);
                Assert.Equal("Level2", entries[1].Scopes[0]);
                Assert.Equal("Level1", entries[1].Scopes[1]);

                Assert.Equal(3, entries[2].Scopes.Count);
                Assert.Equal("Level3", entries[2].Scopes[0]);
                Assert.Equal("Level2", entries[2].Scopes[1]);
                Assert.Equal("Level1", entries[2].Scopes[2]);
            }
        }

        [Fact]
        public void Scope_OutsideScope_ShouldBeEmpty()
        {
            // Arrange
            using (var factory = new LoggerFactory())
            {
                var memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);
                var logger = factory.CreateLogger("TestLogger");

                // Act
                logger.LogInfo("No scope");

                // Assert
                var entries = memoryOutput.GetEntries();
                Assert.Single(entries);
                Assert.Empty(entries[0].Scopes);
            }
        }

        [Fact]
        public void CorrelationId_SeparateLoggers_ShouldHaveSeparateIds()
        {
            // Arrange
            using (var factory = new LoggerFactory())
            {
                var logger1 = factory.CreateLogger("Logger1");
                var logger2 = factory.CreateLogger("Logger2");

                // Act
                logger1.SetCorrelationId("CORR-1");
                logger2.SetCorrelationId("CORR-2");

                var id1 = logger1.GetCorrelationId();
                var id2 = logger2.GetCorrelationId();

                // Assert
                Assert.Equal("CORR-1", id1);
                Assert.Equal("CORR-2", id2);
            }
        }

        [Fact]
        public void Scope_WithProperties_ShouldMaintainProperties()
        {
            // Arrange
            using (var factory = new LoggerFactory())
            {
                var memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);
                var logger = factory.CreateLogger("TestLogger");

                var properties = new Dictionary<string, object>
                {
                    { "UserId", 123 },
                    { "Action", "Login" }
                };

                // Act
                using (logger.BeginScope("RequestScope"))
                {
                    logger.LogStructured(LogLevel.Info, "Login attempt", properties);
                }

                // Assert
                var entries = memoryOutput.GetEntries();
                Assert.Single(entries);
                Assert.Single(entries[0].Scopes);
                Assert.Equal(2, entries[0].Properties.Count);
            }
        }

        [Fact]
        public void CorrelationId_ChangingMultipleTimes()
        {
            // Arrange
            using (var factory = new LoggerFactory())
            {
                var memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);
                var logger = factory.CreateLogger("TestLogger");

                // Act
                logger.SetCorrelationId("CORR-1");
                logger.LogInfo("Message 1");

                logger.SetCorrelationId("CORR-2");
                logger.LogInfo("Message 2");

                logger.SetCorrelationId("CORR-3");
                logger.LogInfo("Message 3");

                // Assert
                var entries = memoryOutput.GetEntries();
                Assert.Equal(3, entries.Count);
                Assert.Equal("CORR-1", entries[0].CorrelationId);
                Assert.Equal("CORR-2", entries[1].CorrelationId);
                Assert.Equal("CORR-3", entries[2].CorrelationId);
            }
        }

        [Fact]
        public void Scope_WithFormattedOutput_ShouldIncludeInOutput()
        {
            // Arrange
            using (var factory = new LoggerFactory())
            {
                var memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput)
                       .SetFormatter(new SimpleLogFormatter());
                var logger = factory.CreateLogger("TestLogger");

                // Act
                using (logger.BeginScope("RequestScope"))
                {
                    logger.LogInfo("Scoped message");
                }

                // Assert
                var entries = memoryOutput.GetEntries();
                Assert.Single(entries);
                Assert.Single(entries[0].Scopes);
            }
        }

        [Fact]
        public void Scope_Disposal_ShouldRemoveScope()
        {
            // Arrange
            using (var factory = new LoggerFactory())
            {
                var memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);
                var logger = factory.CreateLogger("TestLogger");

                // Act
                var scope1 = logger.BeginScope("Scope1");
                logger.LogInfo("With scope");
                scope1.Dispose();
                logger.LogInfo("After dispose");

                // Assert
                var entries = memoryOutput.GetEntries();
                Assert.Equal(2, entries.Count);
                Assert.Single(entries[0].Scopes);
                Assert.Empty(entries[1].Scopes);
            }
        }

        [Fact]
        public void CorrelationId_DefaultNull()
        {
            // Arrange
            using (var factory = new LoggerFactory())
            {
                var memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);
                var logger = factory.CreateLogger("TestLogger");

                // Act
                logger.LogInfo("Without correlation ID");

                // Assert
                var entries = memoryOutput.GetEntries();
                Assert.Single(entries);
                Assert.Null(entries[0].CorrelationId);
            }
        }
    }
}

