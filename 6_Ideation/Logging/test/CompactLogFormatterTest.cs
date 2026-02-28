// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: CompactLogFormatterTest.cs
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
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Formatters;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Comprehensive unit tests for the CompactLogFormatter class.
    ///     Validates minimal, high-performance log formatting.
    /// </summary>
    public class CompactLogFormatterTest
    {
        [Fact]
        public void CompactLogFormatter_HasName()
        {
            // Arrange
            CompactLogFormatter formatter = new CompactLogFormatter();

            // Assert
            Assert.NotNull(formatter.Name);
            Assert.Equal("CompactFormatter", formatter.Name);
        }

        [Fact]
        public void CompactLogFormatter_Format_ShouldBeShort()
        {
            // Arrange
            CompactLogFormatter formatter = new CompactLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test message", "Logger");
            SimpleLogFormatter simpleFormatter = new SimpleLogFormatter();

            // Act
            string compact = formatter.Format(entry);
            string simple = simpleFormatter.Format(entry);

            // Assert
            Assert.True(compact.Length < simple.Length, "Compact should be shorter than simple format");
        }

        [Fact]
        public void CompactLogFormatter_Format_ContainsLevelCode()
        {
            // Arrange
            CompactLogFormatter formatter = new CompactLogFormatter();

            // Test each level
            (LogLevel, string)[] levelCodes = new (LogLevel, string)[]
            {
                (LogLevel.Trace, "[T]"),
                (LogLevel.Debug, "[D]"),
                (LogLevel.Info, "[I]"),
                (LogLevel.Warning, "[W]"),
                (LogLevel.Error, "[E]"),
                (LogLevel.Critical, "[C]")
            };

            foreach ((LogLevel level, string code) in levelCodes)
            {
                // Act
                LogEntry entry = new LogEntry(level, "Test", "Logger");
                string formatted = formatter.Format(entry);

                // Assert
                Assert.Contains(code, formatted, System.StringComparison.Ordinal);
            }
        }

        [Fact]
        public void CompactLogFormatter_Format_ContainsMessage()
        {
            // Arrange
            CompactLogFormatter formatter = new CompactLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Important message", "Logger");

            // Act
            string formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("Important message", formatted);
        }

        [Fact]
        public void CompactLogFormatter_Format_WithException()
        {
            // Arrange
            CompactLogFormatter formatter = new CompactLogFormatter();
            InvalidOperationException exception = new InvalidOperationException("Operation failed");
            LogEntry entry = new LogEntry(LogLevel.Error, "Error occurred", "Logger", exception);

            // Act
            string formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("Operation failed", formatted);
            Assert.Contains("[E]", formatted);
        }

        [Fact]
        public void CompactLogFormatter_Format_WithoutException()
        {
            // Arrange
            CompactLogFormatter formatter = new CompactLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            // Act
            string formatted = formatter.Format(entry);

            // Assert
            Assert.DoesNotContain("[EXC:", formatted);
        }

        [Fact]
        public void CompactLogFormatter_AllLevels()
        {
            // Arrange
            CompactLogFormatter formatter = new CompactLogFormatter();
            LogLevel[] levels = new[] { LogLevel.Trace, LogLevel.Debug, LogLevel.Info, LogLevel.Warning, LogLevel.Error, LogLevel.Critical };

            foreach (LogLevel level in levels)
            {
                // Act
                LogEntry entry = new LogEntry(level, "Test", "Logger");
                string formatted = formatter.Format(entry);

                // Assert
                Assert.NotEmpty(formatted);
                Assert.StartsWith("[", formatted);
            }
        }

        [Fact]
        public void CompactLogFormatter_EmptyMessage()
        {
            // Arrange
            CompactLogFormatter formatter = new CompactLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, string.Empty, "Logger");

            // Act
            string formatted = formatter.Format(entry);

            // Assert
            Assert.NotEmpty(formatted);
            Assert.Contains("[I]", formatted);
        }

        [Fact]
        public void CompactLogFormatter_LongMessage()
        {
            // Arrange
            CompactLogFormatter formatter = new CompactLogFormatter();
            string longMessage = new string('x', 1000);
            LogEntry entry = new LogEntry(LogLevel.Info, longMessage, "Logger");

            // Act
            string formatted = formatter.Format(entry);

            // Assert
            Assert.Contains(longMessage, formatted);
        }

        [Fact]
        public void CompactLogFormatter_DoesNotIncludeTimestamp()
        {
            // Arrange
            CompactLogFormatter formatter = new CompactLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            // Act
            string formatted = formatter.Format(entry);

            // Assert
            // Compact format doesn't include timestamp
            Assert.DoesNotMatch(@"\d{2}:\d{2}:\d{2}", formatted);
        }

        [Fact]
        public void CompactLogFormatter_DoesNotIncludeLoggerName()
        {
            // Arrange
            CompactLogFormatter formatter = new CompactLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "MySpecificLogger");

            // Act
            string formatted = formatter.Format(entry);

            // Assert
            // Compact format doesn't include logger name
            Assert.DoesNotContain("MySpecificLogger", formatted);
        }

        [Fact]
        public void CompactLogFormatter_Performance_ShouldBeVeryFast()
        {
            // Arrange
            CompactLogFormatter formatter = new CompactLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");
            const int iterations = 10000;

            // Act
            DateTime startTime = DateTime.UtcNow;
            for (int i = 0; i < iterations; i++)
            {
                formatter.Format(entry);
            }
            TimeSpan elapsed = DateTime.UtcNow - startTime;

            // Assert - Should format 10000 entries in reasonable time (< 1 second)
            Assert.True(elapsed.TotalSeconds < 1, $"Performance issue: {elapsed.TotalMilliseconds}ms for {iterations} iterations");
        }
    }
}

