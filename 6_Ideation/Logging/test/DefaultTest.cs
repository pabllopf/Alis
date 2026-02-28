// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: DefaultTest.cs
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
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Filters;
using Alis.Core.Aspect.Logging.Formatters;
using Alis.Core.Aspect.Logging.Outputs;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Unit tests for the logging framework core functionality.
    /// </summary>
    public class DefaultTest
    {
        [Fact]
        public void LoggerFactory_Create_ShouldReturnValidLogger()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                ILogger logger = factory.CreateLogger("TestLogger");
                Assert.NotNull(logger);
                Assert.Equal("TestLogger", logger.Name);
            }
        }

        [Fact]
        public void Logger_LogTrace_ShouldWriteToMemoryOutput()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);

                ILogger logger = factory.CreateLogger("TestLogger");
                logger.LogTrace("Test trace message");

                IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
                Assert.Single(entries);
                Assert.Equal(LogLevel.Trace, entries[0].Level);
                Assert.Equal("Test trace message", entries[0].Message);
            }
        }

        [Fact]
        public void Logger_LogDebug_ShouldWriteToMemoryOutput()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);

                ILogger logger = factory.CreateLogger("TestLogger");
                logger.LogDebug("Test debug message");

                IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
                Assert.Single(entries);
                Assert.Equal(LogLevel.Debug, entries[0].Level);
            }
        }

        [Fact]
        public void Logger_LogInfo_ShouldWriteToMemoryOutput()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);

                ILogger logger = factory.CreateLogger("TestLogger");
                logger.LogInfo("Test info message");

                IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
                Assert.Single(entries);
                Assert.Equal(LogLevel.Info, entries[0].Level);
            }
        }

        [Fact]
        public void Logger_LogWarning_ShouldWriteToMemoryOutput()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);

                ILogger logger = factory.CreateLogger("TestLogger");
                logger.LogWarning("Test warning message");

                IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
                Assert.Single(entries);
                Assert.Equal(LogLevel.Warning, entries[0].Level);
            }
        }

        [Fact]
        public void Logger_LogError_ShouldWriteToMemoryOutput()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);

                ILogger logger = factory.CreateLogger("TestLogger");
                logger.LogError("Test error message");

                IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
                Assert.Single(entries);
                Assert.Equal(LogLevel.Error, entries[0].Level);
            }
        }

        [Fact]
        public void Logger_LogCritical_ShouldWriteToMemoryOutput()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);

                ILogger logger = factory.CreateLogger("TestLogger");
                logger.LogCritical("Test critical message");

                IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
                Assert.Single(entries);
                Assert.Equal(LogLevel.Critical, entries[0].Level);
            }
        }

        [Fact]
        public void Logger_LogWithException_ShouldIncludeExceptionInEntry()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);

                ILogger logger = factory.CreateLogger("TestLogger");
                InvalidOperationException exception = new InvalidOperationException("Test exception");
                logger.LogError("Error with exception", exception);

                IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
                Assert.Single(entries);
                Assert.NotNull(entries[0].Exception);
                Assert.Equal("Test exception", entries[0].Exception.Message);
            }
        }

        [Fact]
        public void Logger_SetCorrelationId_ShouldIncludeInLogEntry()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);

                ILogger logger = factory.CreateLogger("TestLogger");
                string correlationId = Guid.NewGuid().ToString();
                logger.SetCorrelationId(correlationId);
                logger.LogInfo("Test message");

                IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
                Assert.Single(entries);
                Assert.Equal(correlationId, entries[0].CorrelationId);
            }
        }

        [Fact]
        public void Logger_GetCorrelationId_ShouldReturnSetValue()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                ILogger logger = factory.CreateLogger("TestLogger");
                string correlationId = "TEST-CORRELATION-ID";
                logger.SetCorrelationId(correlationId);

                Assert.Equal(correlationId, logger.GetCorrelationId());
            }
        }

        [Fact]
        public void Logger_BeginScope_ShouldIncludeScopeInEntry()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);

                ILogger logger = factory.CreateLogger("TestLogger");
                using (logger.BeginScope("TestScope"))
                {
                    logger.LogInfo("Message within scope");
                }

                IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
                Assert.Single(entries);
                Assert.Single(entries[0].Scopes);
                Assert.Equal("TestScope", entries[0].Scopes[0]);
            }
        }

        [Fact]
        public void Logger_NestedScopes_ShouldIncludeAllScopes()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);

                ILogger logger = factory.CreateLogger("TestLogger");
                using (logger.BeginScope("Scope1"))
                {
                    using (logger.BeginScope("Scope2"))
                    {
                        logger.LogInfo("Message in nested scopes");
                    }
                }

                IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
                Assert.Single(entries);
                Assert.Equal(2, entries[0].Scopes.Count);
            }
        }

        [Fact]
        public void LogLevelFilter_ShouldFilterByLevel()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);
                factory.AddFilter(new LogLevelFilter(LogLevel.Warning));

                ILogger logger = factory.CreateLogger("TestLogger");
                logger.LogTrace("Trace");
                logger.LogInfo("Info");
                logger.LogWarning("Warning");
                logger.LogError("Error");

                IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
                Assert.Equal(2, entries.Count); // Warning and Error only
                Assert.Equal(LogLevel.Warning, entries[0].Level);
                Assert.Equal(LogLevel.Error, entries[1].Level);
            }
        }

        [Fact]
        public void LoggerNameFilter_ShouldFilterByName()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);
                factory.AddFilter(new LoggerNameFilter(new[] { "AllowedLogger" }, inclusive: true));

                ILogger allowedLogger = factory.CreateLogger("AllowedLogger");
                ILogger deniedLogger = factory.CreateLogger("DeniedLogger");

                allowedLogger.LogInfo("Allowed message");
                deniedLogger.LogInfo("Denied message");

                IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
                Assert.Single(entries);
                Assert.Equal("AllowedLogger", entries[0].LoggerName);
            }
        }

        [Fact]
        public void LoggerNameFilter_Exclusive_ShouldExcludeNames()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);
                factory.AddFilter(new LoggerNameFilter(new[] { "ExcludedLogger" }, inclusive: false));

                ILogger allowedLogger = factory.CreateLogger("AllowedLogger");
                ILogger excludedLogger = factory.CreateLogger("ExcludedLogger");

                allowedLogger.LogInfo("Allowed message");
                excludedLogger.LogInfo("Excluded message");

                IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
                Assert.Single(entries);
                Assert.Equal("AllowedLogger", entries[0].LoggerName);
            }
        }

        [Fact]
        public void Logger_IsEnabled_ShouldReturnCorrectValue()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                factory.SetMinimumLevel(LogLevel.Warning);
                ILogger logger = factory.CreateLogger("TestLogger");

                Assert.False(logger.IsEnabled(LogLevel.Trace));
                Assert.False(logger.IsEnabled(LogLevel.Debug));
                Assert.False(logger.IsEnabled(LogLevel.Info));
                Assert.True(logger.IsEnabled(LogLevel.Warning));
                Assert.True(logger.IsEnabled(LogLevel.Error));
                Assert.True(logger.IsEnabled(LogLevel.Critical));
            }
        }

        [Fact]
        public void LogStructured_ShouldIncludeProperties()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);

                ILogger logger = factory.CreateLogger("TestLogger");
                Dictionary<string, object> properties = new Dictionary<string, object>
                {
                    { "UserId", 123 },
                    { "Action", "Login" }
                };
                logger.LogStructured(LogLevel.Info, "User action", properties);

                IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
                Assert.Single(entries);
                Assert.Equal(2, entries[0].Properties.Count);
                Assert.Equal(123, entries[0].Properties["UserId"]);
                Assert.Equal("Login", entries[0].Properties["Action"]);
            }
        }

        [Fact]
        public void SimpleLogFormatter_ShouldFormatCorrectly()
        {
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test message", "TestLogger");

            string formatted = formatter.Format(entry);
            Assert.Contains("Info", formatted);
            Assert.Contains("Test message", formatted);
            Assert.Contains("TestLogger", formatted);
        }

        [Fact]
        public void CompactLogFormatter_ShouldFormatCompactly()
        {
            CompactLogFormatter formatter = new CompactLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test message", "TestLogger");

            string formatted = formatter.Format(entry);
            Assert.Contains("[I]", formatted);
            Assert.Contains("Test message", formatted);
        }

        [Fact]
        public void JsonLogFormatter_ShouldFormatAsJson()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test message", "TestLogger");

            string formatted = formatter.Format(entry);
            Assert.StartsWith("{", formatted);
            Assert.EndsWith("}", formatted);
            Assert.Contains("\"level\":\"Info\"", formatted);
            Assert.Contains("\"message\":\"Test message\"", formatted);
        }

        [Fact]
        public void MemoryLogOutput_MaxEntries_ShouldLimitStorage()
        {
            MemoryLogOutput memoryOutput = new MemoryLogOutput(maxEntries: 3);

            for (int i = 0; i < 5; i++)
            {
                LogEntry entry = new LogEntry(LogLevel.Info, $"Message {i}", "TestLogger");
                memoryOutput.Write(entry);
            }

            Assert.Equal(3, memoryOutput.Count);
        }

        [Fact]
        public void CompositeLogFilter_AND_ShouldRequireAllFilters()
        {
            LogLevelFilter filter1 = new LogLevelFilter(LogLevel.Info);
            LoggerNameFilter filter2 = new LoggerNameFilter(new[] { "AllowedLogger" }, inclusive: true);
            CompositeLogFilter composite = new CompositeLogFilter(new ILogFilter[] { filter1, filter2 }, requireAll: true);

            LogEntry entryAllows = new LogEntry(LogLevel.Info, "Message", "AllowedLogger");
            LogEntry entryFailsLevel = new LogEntry(LogLevel.Debug, "Message", "AllowedLogger");
            LogEntry entryFailsName = new LogEntry(LogLevel.Info, "Message", "DeniedLogger");

            Assert.True(composite.ShouldLog(entryAllows));
            Assert.False(composite.ShouldLog(entryFailsLevel));
            Assert.False(composite.ShouldLog(entryFailsName));
        }

        [Fact]
        public void CompositeLogFilter_OR_ShouldRequireAnyFilter()
        {
            LogLevelFilter filter1 = new LogLevelFilter(LogLevel.Error);
            LoggerNameFilter filter2 = new LoggerNameFilter(new[] { "AllowedLogger" }, inclusive: true);
            CompositeLogFilter composite = new CompositeLogFilter(new ILogFilter[] { filter1, filter2 }, requireAll: false);

            LogEntry entryPassesLevel = new LogEntry(LogLevel.Error, "Message", "OtherLogger");
            LogEntry entryPassesName = new LogEntry(LogLevel.Debug, "Message", "AllowedLogger");
            LogEntry entryFailsBoth = new LogEntry(LogLevel.Debug, "Message", "DeniedLogger");

            Assert.True(composite.ShouldLog(entryPassesLevel));
            Assert.True(composite.ShouldLog(entryPassesName));
            Assert.False(composite.ShouldLog(entryFailsBoth));
        }

        [Fact]
        public void Logger_LogEntry_ShouldContainThreadId()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput memoryOutput = new MemoryLogOutput();
                factory.AddOutput(memoryOutput);

                ILogger logger = factory.CreateLogger("TestLogger");
                logger.LogInfo("Test message");

                IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
                Assert.Single(entries);
                Assert.NotEqual(0, entries[0].ThreadId);
            }
        }

        [Fact]
        public void LoggerFactory_FluentConfiguration_ShouldChainCorrectly()
        {
            using (LoggerFactory factory = new LoggerFactory()
                .AddOutput(new MemoryLogOutput())
                .AddFilter(new LogLevelFilter(LogLevel.Info))
                .SetMinimumLevel(LogLevel.Trace))
            {
                ILogger logger = factory.CreateLogger("TestLogger");
                Assert.NotNull(logger);
            }
        }
    }
}