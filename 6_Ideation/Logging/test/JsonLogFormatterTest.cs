// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: JsonLogFormatterTest.cs
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
using System.Linq;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Formatters;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Comprehensive unit tests for the JsonLogFormatter class.
    ///     Validates JSON-formatted structured logging.
    /// </summary>
    public class JsonLogFormatterTest
    {
        [Fact]
        public void JsonLogFormatter_HasName()
        {
            // Arrange
            var formatter = new JsonLogFormatter();

            // Assert
            Assert.NotNull(formatter.Name);
            Assert.Equal("JsonFormatter", formatter.Name);
        }

        [Fact]
        public void JsonLogFormatter_Format_ShouldBeValidJson()
        {
            // Arrange
            var formatter = new JsonLogFormatter();
            var entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            // Act
            var formatted = formatter.Format(entry);

            // Assert
            Assert.StartsWith("{", formatted);
            Assert.EndsWith("}", formatted);
        }

        [Fact]
        public void JsonLogFormatter_Format_ContainsTimestamp()
        {
            // Arrange
            var formatter = new JsonLogFormatter();
            var entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            // Act
            var formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("\"timestamp\":", formatted);
        }

        [Fact]
        public void JsonLogFormatter_Format_ContainsLevel()
        {
            // Arrange
            var formatter = new JsonLogFormatter();
            var entry = new LogEntry(LogLevel.Warning, "Test", "Logger");

            // Act
            var formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("\"level\":\"Warning\"", formatted);
        }

        [Fact]
        public void JsonLogFormatter_Format_ContainsMessage()
        {
            // Arrange
            var formatter = new JsonLogFormatter();
            var entry = new LogEntry(LogLevel.Info, "Test message", "Logger");

            // Act
            var formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("\"message\":\"Test message\"", formatted);
        }

        [Fact]
        public void JsonLogFormatter_Format_ContainsLogger()
        {
            // Arrange
            var formatter = new JsonLogFormatter();
            var entry = new LogEntry(LogLevel.Info, "Test", "MyLogger");

            // Act
            var formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("\"logger\":\"MyLogger\"", formatted);
        }

        [Fact]
        public void JsonLogFormatter_Format_ContainsThreadId()
        {
            // Arrange
            var formatter = new JsonLogFormatter();
            var entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            // Act
            var formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("\"threadId\":", formatted);
        }

        [Fact]
        public void JsonLogFormatter_Format_WithException()
        {
            // Arrange
            var formatter = new JsonLogFormatter();
            var exception = new InvalidOperationException("Operation failed");
            var entry = new LogEntry(LogLevel.Error, "Error", "Logger", exception);

            // Act
            var formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("\"exception\":", formatted);
            Assert.Contains("\"type\":\"InvalidOperationException\"", formatted);
            Assert.Contains("\"message\":\"Operation failed\"", formatted);
            Assert.Contains("\"stackTrace\":", formatted);
        }

        [Fact]
        public void JsonLogFormatter_Format_WithoutException()
        {
            // Arrange
            var formatter = new JsonLogFormatter();
            var entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            // Act
            var formatted = formatter.Format(entry);

            // Assert
            Assert.DoesNotContain("\"exception\":", formatted);
        }

        [Fact]
        public void JsonLogFormatter_Format_WithCorrelationId()
        {
            // Arrange
            var formatter = new JsonLogFormatter();
            var entry = new LogEntry(LogLevel.Info, "Test", "Logger", correlationId: "CORR-123");

            // Act
            var formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("\"correlationId\":\"CORR-123\"", formatted);
        }

        [Fact]
        public void JsonLogFormatter_Format_WithoutCorrelationId()
        {
            // Arrange
            var formatter = new JsonLogFormatter();
            var entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            // Act
            var formatted = formatter.Format(entry);

            // Assert
            Assert.DoesNotContain("\"correlationId\":", formatted);
        }

        [Fact]
        public void JsonLogFormatter_Format_WithProperties()
        {
            // Arrange
            var formatter = new JsonLogFormatter();
            var properties = new Dictionary<string, object>
            {
                { "UserId", 123 },
                { "Action", "Login" }
            };
            var entry = new LogEntry(LogLevel.Info, "Test", "Logger", properties: properties);

            // Act
            var formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("\"properties\":", formatted);
            Assert.Contains("\"UserId\":", formatted);
            Assert.Contains("\"123\"", formatted);
            Assert.Contains("\"Action\":", formatted);
            Assert.Contains("\"Login\"", formatted);
        }

        [Fact]
        public void JsonLogFormatter_Format_WithoutProperties()
        {
            // Arrange
            var formatter = new JsonLogFormatter();
            var entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            // Act
            var formatted = formatter.Format(entry);

            // Assert
            Assert.DoesNotContain("\"properties\":", formatted);
        }

        [Fact]
        public void JsonLogFormatter_Format_WithScopes()
        {
            // Arrange
            var formatter = new JsonLogFormatter();
            var scopes = new List<object> { "Scope1", "Scope2" };
            var entry = new LogEntry(LogLevel.Info, "Test", "Logger", scopes: scopes);

            // Act
            var formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("\"scopes\":", formatted);
            Assert.Contains("\"Scope1\"", formatted);
            Assert.Contains("\"Scope2\"", formatted);
        }

        [Fact]
        public void JsonLogFormatter_Format_WithoutScopes()
        {
            // Arrange
            var formatter = new JsonLogFormatter();
            var entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            // Act
            var formatted = formatter.Format(entry);

            // Assert
            Assert.DoesNotContain("\"scopes\":", formatted);
        }

        [Fact]
        public void JsonLogFormatter_Format_EscapesSpecialCharacters()
        {
            // Arrange
            var formatter = new JsonLogFormatter();
            var entry = new LogEntry(LogLevel.Info, "Message with \"quotes\" and \\backslash", "Logger");

            // Act
            var formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("\\\"", formatted);
            Assert.Contains("\\\\", formatted);
        }

        [Fact]
        public void JsonLogFormatter_Format_AllLevels()
        {
            // Arrange
            var formatter = new JsonLogFormatter();
            var levels = new[] { LogLevel.Trace, LogLevel.Debug, LogLevel.Info, LogLevel.Warning, LogLevel.Error, LogLevel.Critical };

            foreach (var level in levels)
            {
                // Act
                var entry = new LogEntry(level, "Test", "Logger");
                var formatted = formatter.Format(entry);

                // Assert
                Assert.Contains($"\"level\":\"{level}\"", formatted);
            }
        }

        [Fact]
        public void JsonLogFormatter_Format_ComplexProperties()
        {
            // Arrange
            var formatter = new JsonLogFormatter();
            var properties = new Dictionary<string, object>
            {
                { "FrameNumber", 42 },
                { "Timestamp", DateTime.Now.ToString("O") },
                { "Position", "1,2,3" },
                { "IsActive", true }
            };
            var entry = new LogEntry(LogLevel.Info, "Game state", "Logger", properties: properties);

            // Act
            var formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("\"properties\":", formatted);
            Assert.Contains("\"FrameNumber\":", formatted);
            Assert.Contains("42", formatted);
        }

        [Fact]
        public void JsonLogFormatter_Format_EmptyMessage()
        {
            // Arrange
            var formatter = new JsonLogFormatter();
            var entry = new LogEntry(LogLevel.Info, string.Empty, "Logger");

            // Act
            var formatted = formatter.Format(entry);

            // Assert
            Assert.StartsWith("{", formatted);
            Assert.EndsWith("}", formatted);
        }

        [Fact]
        public void JsonLogFormatter_Format_LongMessage()
        {
            // Arrange
            var formatter = new JsonLogFormatter();
            var longMessage = new string('x', 1000);
            var entry = new LogEntry(LogLevel.Info, longMessage, "Logger");

            // Act
            var formatted = formatter.Format(entry);

            // Assert
            Assert.Contains(longMessage, formatted);
        }

        [Fact]
        public void JsonLogFormatter_Format_ValidJsonStructure()
        {
            // Arrange
            var formatter = new JsonLogFormatter();
            var entry = new LogEntry(LogLevel.Info, "Test", "Logger", correlationId: "ID", 
                properties: new Dictionary<string, object> { { "key", "value" } });

            // Act
            var formatted = formatter.Format(entry);

            // Assert - Check for balanced braces
            int openBraces = formatted.Count(c => c == '{');
            int closeBraces = formatted.Count(c => c == '}');
            Assert.Equal(openBraces, closeBraces);

            // Check for balanced brackets
            int openBrackets = formatted.Count(c => c == '[');
            int closeBrackets = formatted.Count(c => c == ']');
            Assert.Equal(openBrackets, closeBrackets);
        }
    }
}

