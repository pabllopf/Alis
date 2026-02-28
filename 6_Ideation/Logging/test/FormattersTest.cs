// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FormattersTest.cs
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
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Formatters;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Tests for log formatter implementations.
    /// </summary>
    public class FormattersTest
    {
        [Fact]
        public void SimpleLogFormatter_Format_ShouldIncludeAllComponents()
        {
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            InvalidOperationException exception = new InvalidOperationException("Test exception");
            LogEntry entry = new LogEntry(
                LogLevel.Error,
                "Test message",
                "TestLogger",
                exception,
                "CORRELATION-ID-123"
            );

            string formatted = formatter.Format(entry);

            Assert.Contains("Error", formatted);
            Assert.Contains("Test message", formatted);
            Assert.Contains("TestLogger", formatted);
            Assert.Contains("CORRELATION-ID-123", formatted);
            Assert.Contains("InvalidOperationException", formatted);
            Assert.Contains("Test exception", formatted);
        }

        [Fact]
        public void SimpleLogFormatter_Format_WithScopes_ShouldIncludeScopes()
        {
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            List<object> scopes = new List<object> {"Scope1", "Scope2", "Scope3"};
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", scopes: scopes);

            string formatted = formatter.Format(entry);

            Assert.Contains("Scope1", formatted);
            Assert.Contains("Scope2", formatted);
            Assert.Contains("Scope3", formatted);
        }

        [Fact]
        public void CompactLogFormatter_Format_ShouldBeMinimal()
        {
            CompactLogFormatter formatter = new CompactLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Warning, "Warning message", "Logger");

            string formatted = formatter.Format(entry);

            Assert.Contains("[W]", formatted);
            Assert.Contains("Warning message", formatted);
            Assert.DoesNotContain("Logger", formatted); // Name not in compact
        }

        [Fact]
        public void CompactLogFormatter_Format_WithException_ShouldIncludeExceptionBriefly()
        {
            CompactLogFormatter formatter = new CompactLogFormatter();
            InvalidOperationException exception = new InvalidOperationException("Operation failed");
            LogEntry entry = new LogEntry(LogLevel.Error, "Error message", "Logger", exception);

            string formatted = formatter.Format(entry);

            Assert.Contains("[E]", formatted);
            Assert.Contains("Error message", formatted);
            Assert.Contains("Operation failed", formatted);
        }

        [Fact]
        public void JsonLogFormatter_Format_ShouldProduceValidJson()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test message", "TestLogger");

            string formatted = formatter.Format(entry);

            Assert.StartsWith("{", formatted);
            Assert.EndsWith("}", formatted);
            Assert.Contains("\"level\":", formatted);
            Assert.Contains("\"message\":", formatted);
            Assert.Contains("\"logger\":", formatted);
        }

        [Fact]
        public void JsonLogFormatter_Format_WithProperties_ShouldIncludePropertiesObject()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            Dictionary<string, object> properties = new Dictionary<string, object>
            {
                {"UserId", 123},
                {"Action", "Login"},
                {"Timestamp", "2023-01-01T00:00:00Z"}
            };
            LogEntry entry = new LogEntry(LogLevel.Info, "User login", "Logger", properties: properties);

            string formatted = formatter.Format(entry);

            Assert.Contains("\"properties\":", formatted);
            Assert.Contains("\"UserId\":", formatted);
            Assert.Contains("123", formatted);
            Assert.Contains("\"Action\":", formatted);
            Assert.Contains("\"Login\"", formatted);
        }

        [Fact]
        public void JsonLogFormatter_Format_WithException_ShouldIncludeExceptionObject()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            InvalidOperationException exception = new InvalidOperationException("Test exception message");
            LogEntry entry = new LogEntry(LogLevel.Error, "Error occurred", "Logger", exception);

            string formatted = formatter.Format(entry);

            Assert.Contains("\"exception\":", formatted);
            Assert.Contains("\"type\":\"InvalidOperationException\"", formatted);
            Assert.Contains("\"message\":\"Test exception message\"", formatted);
            Assert.Contains("\"stackTrace\":", formatted);
        }

        [Fact]
        public void JsonLogFormatter_Format_EscapesSpecialCharacters()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Message with \"quotes\" and \\backslash", "Logger");

            string formatted = formatter.Format(entry);

            // JSON should escape quotes and backslashes
            Assert.Contains("\\\"", formatted);
            Assert.Contains("\\\\", formatted);
            Assert.DoesNotContain("unescaped \"quotes\"", formatted);
        }

        [Fact]
        public void JsonLogFormatter_Format_WithCorrelationId_ShouldIncludeCorrelationId()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", correlationId: "CORR-123");

            string formatted = formatter.Format(entry);

            Assert.Contains("\"correlationId\":\"CORR-123\"", formatted);
        }

        [Fact]
        public void JsonLogFormatter_Format_WithThreadId_ShouldIncludeThreadId()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger");

            string formatted = formatter.Format(entry);

            Assert.Contains("\"threadId\":", formatted);
            Assert.Contains(entry.ThreadId.ToString(), formatted);
        }

        [Fact]
        public void SimpleLogFormatter_Format_AllLogLevels_ShouldProduceOutput()
        {
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            LogLevel[] levels = new[] {LogLevel.Trace, LogLevel.Debug, LogLevel.Info, LogLevel.Warning, LogLevel.Error, LogLevel.Critical};

            foreach (LogLevel level in levels)
            {
                LogEntry entry = new LogEntry(level, "Test message", "Logger");
                string formatted = formatter.Format(entry);

                Assert.NotEmpty(formatted);
                Assert.Contains(level.ToString(), formatted);
            }
        }

        [Fact]
        public void CompactLogFormatter_Format_AllLogLevels_ShouldProduceOutput()
        {
            CompactLogFormatter formatter = new CompactLogFormatter();
            (LogLevel level, string symbol)[] expectations = new (LogLevel level, string symbol)[]
            {
                (LogLevel.Trace, "[T]"),
                (LogLevel.Debug, "[D]"),
                (LogLevel.Info, "[I]"),
                (LogLevel.Warning, "[W]"),
                (LogLevel.Error, "[E]"),
                (LogLevel.Critical, "[C]")
            };

            foreach ((LogLevel level, string symbol) in expectations)
            {
                LogEntry entry = new LogEntry(level, "Test message", "Logger");
                string formatted = formatter.Format(entry);

                Assert.Contains(symbol, formatted);
            }
        }
    }
}