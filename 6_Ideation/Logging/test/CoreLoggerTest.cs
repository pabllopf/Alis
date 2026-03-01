// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CoreLoggerTest.cs
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
    ///     Comprehensive unit tests for the CoreLogger class.
    ///     Validates all logging methods, correlation ID tracking,
    ///     scope management, and filter/output interaction.
    /// </summary>
    public class CoreLoggerTest
    {
        /// <summary>
        /// Tests that core logger constructor should set name
        /// </summary>
        [Fact]
        public void CoreLogger_Constructor_ShouldSetName()
        {
            // Arrange
            List<ILogOutput> outputs = new List<ILogOutput>();
            List<ILogFilter> filters = new List<ILogFilter>();
            SimpleLogFormatter formatter = new SimpleLogFormatter();

            // Act
            CoreLogger logger = new CoreLogger("TestLogger", outputs, filters, formatter);

            // Assert
            Assert.Equal("TestLogger", logger.Name);
        }

        /// <summary>
        /// Tests that core logger log trace should write to output
        /// </summary>
        [Fact]
        public void CoreLogger_LogTrace_ShouldWriteToOutput()
        {
            // Arrange
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            List<ILogOutput> outputs = new List<ILogOutput> {memoryOutput};
            List<ILogFilter> filters = new List<ILogFilter>();
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            CoreLogger logger = new CoreLogger("TestLogger", outputs, filters, formatter);

            // Act
            logger.LogTrace("Trace message");

            // Assert
            IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
            Assert.Single(entries);
            Assert.Equal(LogLevel.Trace, entries[0].Level);
            Assert.Equal("Trace message", entries[0].Message);
        }

        /// <summary>
        /// Tests that core logger log debug should write to output
        /// </summary>
        [Fact]
        public void CoreLogger_LogDebug_ShouldWriteToOutput()
        {
            // Arrange
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            List<ILogOutput> outputs = new List<ILogOutput> {memoryOutput};
            List<ILogFilter> filters = new List<ILogFilter>();
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            CoreLogger logger = new CoreLogger("TestLogger", outputs, filters, formatter);

            // Act
            logger.LogDebug("Debug message");

            // Assert
            IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
            Assert.Single(entries);
            Assert.Equal(LogLevel.Debug, entries[0].Level);
        }

        /// <summary>
        /// Tests that core logger log info should write to output
        /// </summary>
        [Fact]
        public void CoreLogger_LogInfo_ShouldWriteToOutput()
        {
            // Arrange
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            List<ILogOutput> outputs = new List<ILogOutput> {memoryOutput};
            List<ILogFilter> filters = new List<ILogFilter>();
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            CoreLogger logger = new CoreLogger("TestLogger", outputs, filters, formatter);

            // Act
            logger.LogInfo("Info message");

            // Assert
            IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
            Assert.Single(entries);
            Assert.Equal(LogLevel.Info, entries[0].Level);
        }

        /// <summary>
        /// Tests that core logger log warning should write to output
        /// </summary>
        [Fact]
        public void CoreLogger_LogWarning_ShouldWriteToOutput()
        {
            // Arrange
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            List<ILogOutput> outputs = new List<ILogOutput> {memoryOutput};
            List<ILogFilter> filters = new List<ILogFilter>();
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            CoreLogger logger = new CoreLogger("TestLogger", outputs, filters, formatter);

            // Act
            logger.LogWarning("Warning message");

            // Assert
            IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
            Assert.Single(entries);
            Assert.Equal(LogLevel.Warning, entries[0].Level);
        }

        /// <summary>
        /// Tests that core logger log error should write to output
        /// </summary>
        [Fact]
        public void CoreLogger_LogError_ShouldWriteToOutput()
        {
            // Arrange
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            List<ILogOutput> outputs = new List<ILogOutput> {memoryOutput};
            List<ILogFilter> filters = new List<ILogFilter>();
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            CoreLogger logger = new CoreLogger("TestLogger", outputs, filters, formatter);

            // Act
            logger.LogError("Error message");

            // Assert
            IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
            Assert.Single(entries);
            Assert.Equal(LogLevel.Error, entries[0].Level);
        }

        /// <summary>
        /// Tests that core logger log critical should write to output
        /// </summary>
        [Fact]
        public void CoreLogger_LogCritical_ShouldWriteToOutput()
        {
            // Arrange
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            List<ILogOutput> outputs = new List<ILogOutput> {memoryOutput};
            List<ILogFilter> filters = new List<ILogFilter>();
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            CoreLogger logger = new CoreLogger("TestLogger", outputs, filters, formatter);

            // Act
            logger.LogCritical("Critical message");

            // Assert
            IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
            Assert.Single(entries);
            Assert.Equal(LogLevel.Critical, entries[0].Level);
        }

        /// <summary>
        /// Tests that core logger log error with exception should include exception
        /// </summary>
        [Fact]
        public void CoreLogger_LogErrorWithException_ShouldIncludeException()
        {
            // Arrange
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            List<ILogOutput> outputs = new List<ILogOutput> {memoryOutput};
            List<ILogFilter> filters = new List<ILogFilter>();
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            CoreLogger logger = new CoreLogger("TestLogger", outputs, filters, formatter);
            InvalidOperationException exception = new InvalidOperationException("Test exception");

            // Act
            logger.LogError("Error with exception", exception);

            // Assert
            IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
            Assert.Single(entries);
            Assert.NotNull(entries[0].Exception);
            Assert.Equal("Test exception", entries[0].Exception.Message);
        }

        /// <summary>
        /// Tests that core logger log critical with exception should include exception
        /// </summary>
        [Fact]
        public void CoreLogger_LogCriticalWithException_ShouldIncludeException()
        {
            // Arrange
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            List<ILogOutput> outputs = new List<ILogOutput> {memoryOutput};
            List<ILogFilter> filters = new List<ILogFilter>();
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            CoreLogger logger = new CoreLogger("TestLogger", outputs, filters, formatter);
            ArgumentException exception = new ArgumentException("Test exception");

            // Act
            logger.LogCritical("Critical with exception", exception);

            // Assert
            IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
            Assert.Single(entries);
            Assert.NotNull(entries[0].Exception);
        }

        /// <summary>
        /// Tests that core logger log should write with specified level
        /// </summary>
        [Fact]
        public void CoreLogger_Log_ShouldWriteWithSpecifiedLevel()
        {
            // Arrange
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            List<ILogOutput> outputs = new List<ILogOutput> {memoryOutput};
            List<ILogFilter> filters = new List<ILogFilter>();
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            CoreLogger logger = new CoreLogger("TestLogger", outputs, filters, formatter);

            // Act
            logger.Log(LogLevel.Warning, "Custom level message");

            // Assert
            IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
            Assert.Single(entries);
            Assert.Equal(LogLevel.Warning, entries[0].Level);
        }

        /// <summary>
        /// Tests that core logger log with exception should write with exception level
        /// </summary>
        [Fact]
        public void CoreLogger_LogWithException_ShouldWriteWithExceptionLevel()
        {
            // Arrange
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            List<ILogOutput> outputs = new List<ILogOutput> {memoryOutput};
            List<ILogFilter> filters = new List<ILogFilter>();
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            CoreLogger logger = new CoreLogger("TestLogger", outputs, filters, formatter);
            NullReferenceException exception = new NullReferenceException();

            // Act
            logger.Log(LogLevel.Error, "Error with exception", exception);

            // Assert
            IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
            Assert.Single(entries);
            Assert.Equal(LogLevel.Error, entries[0].Level);
            Assert.NotNull(entries[0].Exception);
        }

        /// <summary>
        /// Tests that core logger log structured should include properties
        /// </summary>
        [Fact]
        public void CoreLogger_LogStructured_ShouldIncludeProperties()
        {
            // Arrange
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            List<ILogOutput> outputs = new List<ILogOutput> {memoryOutput};
            List<ILogFilter> filters = new List<ILogFilter>();
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            CoreLogger logger = new CoreLogger("TestLogger", outputs, filters, formatter);
            Dictionary<string, object> properties = new Dictionary<string, object>
            {
                {"UserId", 123},
                {"Action", "Login"}
            };

            // Act
            logger.LogStructured(LogLevel.Info, "Structured log", properties);

            // Assert
            IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
            Assert.Single(entries);
            Assert.Equal(2, entries[0].Properties.Count);
            Assert.Equal(123, entries[0].Properties["UserId"]);
        }

        /// <summary>
        /// Tests that core logger log structured with null properties should log as normal
        /// </summary>
        [Fact]
        public void CoreLogger_LogStructuredWithNullProperties_ShouldLogAsNormal()
        {
            // Arrange
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            List<ILogOutput> outputs = new List<ILogOutput> {memoryOutput};
            List<ILogFilter> filters = new List<ILogFilter>();
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            CoreLogger logger = new CoreLogger("TestLogger", outputs, filters, formatter);

            // Act
            logger.LogStructured(LogLevel.Info, "Log message", null);

            // Assert
            IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
            Assert.Single(entries);
        }

        /// <summary>
        /// Tests that core logger set correlation id should include in entries
        /// </summary>
        [Fact]
        public void CoreLogger_SetCorrelationId_ShouldIncludeInEntries()
        {
            // Arrange
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            List<ILogOutput> outputs = new List<ILogOutput> {memoryOutput};
            List<ILogFilter> filters = new List<ILogFilter>();
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            CoreLogger logger = new CoreLogger("TestLogger", outputs, filters, formatter);
            string correlationId = "CORR-123";

            // Act
            logger.SetCorrelationId(correlationId);
            logger.LogInfo("Message");

            // Assert
            IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
            Assert.Single(entries);
            Assert.Equal(correlationId, entries[0].CorrelationId);
        }

        /// <summary>
        /// Tests that core logger get correlation id should return set value
        /// </summary>
        [Fact]
        public void CoreLogger_GetCorrelationId_ShouldReturnSetValue()
        {
            // Arrange
            List<ILogOutput> outputs = new List<ILogOutput>();
            List<ILogFilter> filters = new List<ILogFilter>();
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            CoreLogger logger = new CoreLogger("TestLogger", outputs, filters, formatter);
            string correlationId = Guid.NewGuid().ToString();

            // Act
            logger.SetCorrelationId(correlationId);
            string retrieved = logger.GetCorrelationId();

            // Assert
            Assert.Equal(correlationId, retrieved);
        }

        /// <summary>
        /// Tests that core logger begin scope should include scope in entry
        /// </summary>
        [Fact]
        public void CoreLogger_BeginScope_ShouldIncludeScopeInEntry()
        {
            // Arrange
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            List<ILogOutput> outputs = new List<ILogOutput> {memoryOutput};
            List<ILogFilter> filters = new List<ILogFilter>();
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            CoreLogger logger = new CoreLogger("TestLogger", outputs, filters, formatter);

            // Act
            using (logger.BeginScope("TestScope"))
            {
                logger.LogInfo("Message in scope");
            }

            // Assert
            IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
            Assert.Single(entries);
            Assert.Single(entries[0].Scopes);
            Assert.Equal("TestScope", entries[0].Scopes[0]);
        }

        /// <summary>
        /// Tests that core logger nested scopes should include all scopes
        /// </summary>
        [Fact]
        public void CoreLogger_NestedScopes_ShouldIncludeAllScopes()
        {
            // Arrange
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            List<ILogOutput> outputs = new List<ILogOutput> {memoryOutput};
            List<ILogFilter> filters = new List<ILogFilter>();
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            CoreLogger logger = new CoreLogger("TestLogger", outputs, filters, formatter);

            // Act
            using (logger.BeginScope("Scope1"))
            {
                using (logger.BeginScope("Scope2"))
                {
                    logger.LogInfo("Message");
                }
            }

            // Assert
            IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
            Assert.Single(entries);
            Assert.Equal(2, entries[0].Scopes.Count);
        }

        /// <summary>
        /// Tests that core logger is enabled trace should return true
        /// </summary>
        [Fact]
        public void CoreLogger_IsEnabledTrace_ShouldReturnTrue()
        {
            // Arrange
            List<ILogOutput> outputs = new List<ILogOutput>();
            List<ILogFilter> filters = new List<ILogFilter>();
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            CoreLogger logger = new CoreLogger("TestLogger", outputs, filters, formatter);

            // Act & Assert
            Assert.True(logger.IsEnabled(LogLevel.Trace));
        }

        /// <summary>
        /// Tests that core logger is enabled below minimum should return false
        /// </summary>
        [Fact]
        public void CoreLogger_IsEnabledBelowMinimum_ShouldReturnFalse()
        {
            // Arrange
            List<ILogOutput> outputs = new List<ILogOutput>();
            List<ILogFilter> filters = new List<ILogFilter>();
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            CoreLogger logger = new CoreLogger("TestLogger", outputs, filters, formatter, LogLevel.Warning);

            // Act & Assert
            Assert.False(logger.IsEnabled(LogLevel.Info));
            Assert.False(logger.IsEnabled(LogLevel.Debug));
            Assert.True(logger.IsEnabled(LogLevel.Warning));
            Assert.True(logger.IsEnabled(LogLevel.Error));
        }

        /// <summary>
        /// Tests that core logger is enabled none should return false
        /// </summary>
        [Fact]
        public void CoreLogger_IsEnabledNone_ShouldReturnFalse()
        {
            // Arrange
            List<ILogOutput> outputs = new List<ILogOutput>();
            List<ILogFilter> filters = new List<ILogFilter>();
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            CoreLogger logger = new CoreLogger("TestLogger", outputs, filters, formatter);

            // Act & Assert
            Assert.False(logger.IsEnabled(LogLevel.None));
        }

        /// <summary>
        /// Tests that core logger disabled level should not log disabled messages
        /// </summary>
        [Fact]
        public void CoreLogger_DisabledLevel_ShouldNotLogDisabledMessages()
        {
            // Arrange
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            List<ILogOutput> outputs = new List<ILogOutput> {memoryOutput};
            List<ILogFilter> filters = new List<ILogFilter>();
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            CoreLogger logger = new CoreLogger("TestLogger", outputs, filters, formatter, LogLevel.Warning);

            // Act
            logger.LogInfo("Info");
            logger.LogWarning("Warning");
            logger.LogError("Error");

            // Assert
            IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
            Assert.Equal(2, entries.Count);
            Assert.All(entries, e => Assert.True(e.Level >= LogLevel.Warning));
        }

        /// <summary>
        /// Tests that core logger filter blocks should not log
        /// </summary>
        [Fact]
        public void CoreLogger_FilterBlocks_ShouldNotLog()
        {
            // Arrange
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            List<ILogOutput> outputs = new List<ILogOutput> {memoryOutput};
            List<ILogFilter> filters = new List<ILogFilter> {new LogLevelFilter(LogLevel.Error)};
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            CoreLogger logger = new CoreLogger("TestLogger", outputs, filters, formatter);

            // Act
            logger.LogInfo("Info");
            logger.LogWarning("Warning");
            logger.LogError("Error");

            // Assert
            IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
            Assert.Single(entries);
            Assert.Equal(LogLevel.Error, entries[0].Level);
        }

        /// <summary>
        /// Tests that core logger multiple filters should apply all
        /// </summary>
        [Fact]
        public void CoreLogger_MultipleFilters_ShouldApplyAll()
        {
            // Arrange
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            List<ILogOutput> outputs = new List<ILogOutput> {memoryOutput};
            List<ILogFilter> filters = new List<ILogFilter>
            {
                new LogLevelFilter(LogLevel.Info),
                new LoggerNameFilter(new[] {"TestLogger"})
            };
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            CoreLogger logger = new CoreLogger("TestLogger", outputs, filters, formatter);

            // Act
            logger.LogInfo("Message 1");
            logger.LogInfo("Message 2");

            // Assert
            IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
            Assert.Equal(2, entries.Count);
        }

        /// <summary>
        /// Tests that core logger multiple outputs should write to all
        /// </summary>
        [Fact]
        public void CoreLogger_MultipleOutputs_ShouldWriteToAll()
        {
            // Arrange
            MemoryLogOutput memory1 = new MemoryLogOutput();
            MemoryLogOutput memory2 = new MemoryLogOutput();
            List<ILogOutput> outputs = new List<ILogOutput> {memory1, memory2};
            List<ILogFilter> filters = new List<ILogFilter>();
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            CoreLogger logger = new CoreLogger("TestLogger", outputs, filters, formatter);

            // Act
            logger.LogInfo("Test message");

            // Assert
            Assert.Single(memory1.GetEntries());
            Assert.Single(memory2.GetEntries());
        }

        /// <summary>
        /// Tests that core logger concurrent logging should be thread safe
        /// </summary>
        [Fact]
        public void CoreLogger_ConcurrentLogging_ShouldBeThreadSafe()
        {
            // Arrange
            MemoryLogOutput memoryOutput = new MemoryLogOutput(0);
            List<ILogOutput> outputs = new List<ILogOutput> {memoryOutput};
            List<ILogFilter> filters = new List<ILogFilter>();
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            CoreLogger logger = new CoreLogger("TestLogger", outputs, filters, formatter);
            List<Task> tasks = new List<Task>();

            // Act
            for (int i = 0; i < 10; i++)
            {
                Task task = Task.Run(() =>
                {
                    for (int j = 0; j < 100; j++)
                    {
                        logger.LogInfo($"Message {j}");
                    }
                });
                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            // Assert
            Assert.Equal(1000, memoryOutput.Count);
        }

        /// <summary>
        /// Tests that core logger concurrent correlation id should be thread safe
        /// </summary>
        [Fact]
        public void CoreLogger_ConcurrentCorrelationId_ShouldBeThreadSafe()
        {
            // Arrange
            MemoryLogOutput memoryOutput = new MemoryLogOutput(0);
            List<ILogOutput> outputs = new List<ILogOutput> {memoryOutput};
            List<ILogFilter> filters = new List<ILogFilter>();
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            CoreLogger logger = new CoreLogger("TestLogger", outputs, filters, formatter);
            List<Task> tasks = new List<Task>();

            // Act
            for (int i = 0; i < 5; i++)
            {
                int threadNum = i;
                Task task = Task.Run(() =>
                {
                    logger.SetCorrelationId($"CORR-{threadNum}");
                    logger.LogInfo("Message");
                });
                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            // Assert
            Assert.Equal(5, memoryOutput.Count);
        }

        /// <summary>
        /// Tests that core logger output exception should not propagate
        /// </summary>
        [Fact]
        public void CoreLogger_OutputException_ShouldNotPropagate()
        {
            // Arrange
            FaultyLogOutput faultyOutput = new FaultyLogOutput();
            List<ILogOutput> outputs = new List<ILogOutput> {faultyOutput};
            List<ILogFilter> filters = new List<ILogFilter>();
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            CoreLogger logger = new CoreLogger("TestLogger", outputs, filters, formatter);

            // Act & Assert - Should not throw
            logger.LogInfo("Message");
        }

        /// <summary>
        /// Tests that core logger empty outputs list should not throw
        /// </summary>
        [Fact]
        public void CoreLogger_EmptyOutputsList_ShouldNotThrow()
        {
            // Arrange
            List<ILogOutput> outputs = new List<ILogOutput>();
            List<ILogFilter> filters = new List<ILogFilter>();
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            CoreLogger logger = new CoreLogger("TestLogger", outputs, filters, formatter);

            // Act & Assert - Should not throw
            logger.LogInfo("Message");
        }

        /// <summary>
        ///     Helper output for testing fault tolerance.
        /// </summary>
        private sealed class FaultyLogOutput : ILogOutput
        {
            /// <summary>
            /// Gets the value of the name
            /// </summary>
            public string Name => "FaultyOutput";
            /// <summary>
            /// Gets or sets the value of the is enabled
            /// </summary>
            public bool IsEnabled { get; set; } = true;

            /// <summary>
            /// Writes the entry
            /// </summary>
            /// <param name="entry">The entry</param>
            /// <exception cref="InvalidOperationException">Faulty output</exception>
            public void Write(ILogEntry entry)
            {
                throw new InvalidOperationException("Faulty output");
            }

            /// <summary>
            /// Flushes this instance
            /// </summary>
            public void Flush()
            {
            }

            /// <summary>
            /// Disposes this instance
            /// </summary>
            public void Dispose()
            {
            }
        }
    }
}