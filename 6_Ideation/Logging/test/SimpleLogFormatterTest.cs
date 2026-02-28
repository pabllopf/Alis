// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: SimpleLogFormatterTest.cs
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
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Formatters;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Comprehensive unit tests for the SimpleLogFormatter class.
    ///     Validates human-readable log formatting with all entry components.
    /// </summary>
    public class SimpleLogFormatterTest
    {
        [Fact]
        public void SimpleLogFormatter_Constructor()
        {
            // Act
            SimpleLogFormatter formatter = new SimpleLogFormatter();

            // Assert
            Assert.NotNull(formatter);
        }

        [Fact]
        public void SimpleLogFormatter_HasName()
        {
            // Arrange
            SimpleLogFormatter formatter = new SimpleLogFormatter();

            // Assert
            Assert.NotNull(formatter.Name);
            Assert.Equal("SimpleFormatter", formatter.Name);
        }

        [Fact]
        public void SimpleLogFormatter_Format_ContainsLevel()
        {
            // Arrange
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Warning, "Test", "Logger");

            // Act
            string formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("Warning", formatted);
        }

        [Fact]
        public void SimpleLogFormatter_Format_ContainsMessage()
        {
            // Arrange
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Important message", "Logger");

            // Act
            string formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("Important message", formatted);
        }

        [Fact]
        public void SimpleLogFormatter_Format_ContainsLoggerName()
        {
            // Arrange
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "MyLogger");

            // Act
            string formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("MyLogger", formatted);
        }

        [Fact]
        public void SimpleLogFormatter_Format_WithException()
        {
            // Arrange
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            InvalidOperationException exception = new InvalidOperationException("Test error");
            LogEntry entry = new LogEntry(LogLevel.Error, "Error occurred", "Logger", exception);

            // Act
            string formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("InvalidOperationException", formatted);
            Assert.Contains("Test error", formatted);
        }

        [Fact]
        public void SimpleLogFormatter_Format_WithCorrelationId()
        {
            // Arrange
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger", correlationId: "CORR-123");

            // Act
            string formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("CORR-123", formatted);
            Assert.Contains("CorrelationId", formatted);
        }

        [Fact]
        public void SimpleLogFormatter_Format_WithoutCorrelationId()
        {
            // Arrange
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            // Act
            string formatted = formatter.Format(entry);

            // Assert
            Assert.DoesNotContain("CorrelationId", formatted);
        }

        [Fact]
        public void SimpleLogFormatter_Format_WithScopes()
        {
            // Arrange
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            List<object> scopes = new List<object> { "Scope1", "Scope2", "Scope3" };
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger", scopes: scopes);

            // Act
            string formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("Scope1", formatted);
            Assert.Contains("Scope2", formatted);
            Assert.Contains("Scope3", formatted);
            Assert.Contains("Scopes", formatted);
        }

        [Fact]
        public void SimpleLogFormatter_Format_WithoutScopes()
        {
            // Arrange
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            // Act
            string formatted = formatter.Format(entry);

            // Assert
            // Should not contain Scopes section if empty
            Assert.DoesNotContain("[Scopes:", formatted);
        }

        [Fact]
        public void SimpleLogFormatter_AllLevels()
        {
            // Arrange
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            LogLevel[] levels = new[] { LogLevel.Trace, LogLevel.Debug, LogLevel.Info, LogLevel.Warning, LogLevel.Error, LogLevel.Critical };

            foreach (LogLevel level in levels)
            {
                // Act
                LogEntry entry = new LogEntry(level, "Test", "Logger");
                string formatted = formatter.Format(entry);

                // Assert
                Assert.NotEmpty(formatted);
                Assert.Contains(level.ToString(), formatted);
            }
        }

        [Fact]
        public void SimpleLogFormatter_EmptyMessage()
        {
            // Arrange
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, string.Empty, "Logger");

            // Act
            string formatted = formatter.Format(entry);

            // Assert
            Assert.NotEmpty(formatted);
            Assert.Contains("Logger", formatted);
        }

        [Fact]
        public void SimpleLogFormatter_LongMessage()
        {
            // Arrange
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            string longMessage = new string('x', 1000);
            LogEntry entry = new LogEntry(LogLevel.Info, longMessage, "Logger");

            // Act
            string formatted = formatter.Format(entry);

            // Assert
            Assert.Contains(longMessage, formatted);
        }

        [Fact]
        public void SimpleLogFormatter_SpecialCharacters()
        {
            // Arrange
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            string specialMessage = "Test\nwith\nnewlines\tand\ttabs";
            LogEntry entry = new LogEntry(LogLevel.Info, specialMessage, "Logger");

            // Act
            string formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("Test", formatted);
        }

        [Fact]
        public void SimpleLogFormatter_MultipleScopes_WithArrows()
        {
            // Arrange
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            List<object> scopes = new List<object> { "Engine", "Graphics", "Renderer" };
            LogEntry entry = new LogEntry(LogLevel.Info, "Rendering", "Logger", scopes: scopes);

            // Act
            string formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("Engine", formatted);
            Assert.Contains("Graphics", formatted);
            Assert.Contains("Renderer", formatted);
            // Should contain arrows between scopes
            Assert.Contains("->", formatted);
        }
    }
}

