// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JsonLogFormatterTest.cs
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
using System.Linq;
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
        /// <summary>
        ///     Tests that json log formatter has name
        /// </summary>
        [Fact]
        public void JsonLogFormatter_HasName()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();

            Assert.NotNull(formatter.Name);
            Assert.Equal("JsonFormatter", formatter.Name);
        }

        /// <summary>
        ///     Tests that json log formatter format should be valid json
        /// </summary>
        [Fact]
        public void JsonLogFormatter_Format_ShouldBeValidJson()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            string formatted = formatter.Format(entry);

            Assert.StartsWith("{", formatted);
            Assert.EndsWith("}", formatted);
        }

        /// <summary>
        ///     Tests that json log formatter format contains timestamp
        /// </summary>
        [Fact]
        public void JsonLogFormatter_Format_ContainsTimestamp()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            string formatted = formatter.Format(entry);

            Assert.Contains("\"timestamp\":", formatted);
        }

        /// <summary>
        ///     Tests that json log formatter format contains level
        /// </summary>
        [Fact]
        public void JsonLogFormatter_Format_ContainsLevel()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Warning, "Test", "Logger");

            string formatted = formatter.Format(entry);

            Assert.Contains("\"level\":\"Warning\"", formatted);
        }

        /// <summary>
        ///     Tests that json log formatter format contains message
        /// </summary>
        [Fact]
        public void JsonLogFormatter_Format_ContainsMessage()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test message", "Logger");

            string formatted = formatter.Format(entry);

            Assert.Contains("\"message\":\"Test message\"", formatted);
        }

        /// <summary>
        ///     Tests that json log formatter format contains logger
        /// </summary>
        [Fact]
        public void JsonLogFormatter_Format_ContainsLogger()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "MyLogger");

            string formatted = formatter.Format(entry);

            Assert.Contains("\"logger\":\"MyLogger\"", formatted);
        }

        /// <summary>
        ///     Tests that json log formatter format contains thread id
        /// </summary>
        [Fact]
        public void JsonLogFormatter_Format_ContainsThreadId()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            string formatted = formatter.Format(entry);

            Assert.Contains("\"threadId\":", formatted);
        }

        /// <summary>
        ///     Tests that json log formatter format with exception
        /// </summary>
        [Fact]
        public void JsonLogFormatter_Format_WithException()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            InvalidOperationException exception = new InvalidOperationException("Operation failed");
            LogEntry entry = new LogEntry(LogLevel.Error, "Error", "Logger", exception);

            string formatted = formatter.Format(entry);

            Assert.Contains("\"exception\":", formatted);
            Assert.Contains("\"type\":\"InvalidOperationException\"", formatted);
            Assert.Contains("\"message\":\"Operation failed\"", formatted);
            Assert.Contains("\"stackTrace\":", formatted);
        }

        /// <summary>
        ///     Tests that json log formatter format without exception
        /// </summary>
        [Fact]
        public void JsonLogFormatter_Format_WithoutException()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            string formatted = formatter.Format(entry);

            Assert.DoesNotContain("\"exception\":", formatted);
        }

        /// <summary>
        ///     Tests that json log formatter format with correlation id
        /// </summary>
        [Fact]
        public void JsonLogFormatter_Format_WithCorrelationId()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger", correlationId: "CORR-123");

            string formatted = formatter.Format(entry);

            Assert.Contains("\"correlationId\":\"CORR-123\"", formatted);
        }

        /// <summary>
        ///     Tests that json log formatter format without correlation id
        /// </summary>
        [Fact]
        public void JsonLogFormatter_Format_WithoutCorrelationId()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            string formatted = formatter.Format(entry);

            Assert.DoesNotContain("\"correlationId\":", formatted);
        }

        /// <summary>
        ///     Tests that json log formatter format with properties
        /// </summary>
        [Fact]
        public void JsonLogFormatter_Format_WithProperties()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            Dictionary<string, object> properties = new Dictionary<string, object>
            {
                {"UserId", 123},
                {"Action", "Login"}
            };
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger", properties: properties);

            string formatted = formatter.Format(entry);

            Assert.Contains("\"properties\":", formatted);
            Assert.Contains("\"UserId\":", formatted);
            Assert.Contains("\"123\"", formatted);
            Assert.Contains("\"Action\":", formatted);
            Assert.Contains("\"Login\"", formatted);
        }

        /// <summary>
        ///     Tests that json log formatter format without properties
        /// </summary>
        [Fact]
        public void JsonLogFormatter_Format_WithoutProperties()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            string formatted = formatter.Format(entry);

            Assert.DoesNotContain("\"properties\":", formatted);
        }

        /// <summary>
        ///     Tests that json log formatter format with scopes
        /// </summary>
        [Fact]
        public void JsonLogFormatter_Format_WithScopes()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            List<object> scopes = new List<object> {"Scope1", "Scope2"};
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger", scopes: scopes);

            string formatted = formatter.Format(entry);

            Assert.Contains("\"scopes\":", formatted);
            Assert.Contains("\"Scope1\"", formatted);
            Assert.Contains("\"Scope2\"", formatted);
        }

        /// <summary>
        ///     Tests that json log formatter format without scopes
        /// </summary>
        [Fact]
        public void JsonLogFormatter_Format_WithoutScopes()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            string formatted = formatter.Format(entry);

            Assert.DoesNotContain("\"scopes\":", formatted);
        }

        /// <summary>
        ///     Tests that json log formatter format escapes special characters
        /// </summary>
        [Fact]
        public void JsonLogFormatter_Format_EscapesSpecialCharacters()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Message with \"quotes\" and \\backslash", "Logger");

            string formatted = formatter.Format(entry);

            Assert.Contains("\\\"", formatted);
            Assert.Contains("\\\\", formatted);
        }

        /// <summary>
        ///     Tests that json log formatter format all levels
        /// </summary>
        [Fact]
        public void JsonLogFormatter_Format_AllLevels()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogLevel[] levels = new[] {LogLevel.Trace, LogLevel.Debug, LogLevel.Info, LogLevel.Warning, LogLevel.Error, LogLevel.Critical};

            foreach (LogLevel level in levels)
            {
                LogEntry entry = new LogEntry(level, "Test", "Logger");
                string formatted = formatter.Format(entry);

                Assert.Contains($"\"level\":\"{level}\"", formatted);
            }
        }

        /// <summary>
        ///     Tests that json log formatter format complex properties
        /// </summary>
        [Fact]
        public void JsonLogFormatter_Format_ComplexProperties()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            Dictionary<string, object> properties = new Dictionary<string, object>
            {
                {"FrameNumber", 42},
                {"Timestamp", DateTime.Now.ToString("O")},
                {"Position", "1,2,3"},
                {"IsActive", true}
            };
            LogEntry entry = new LogEntry(LogLevel.Info, "Game state", "Logger", properties: properties);

            string formatted = formatter.Format(entry);

            Assert.Contains("\"properties\":", formatted);
            Assert.Contains("\"FrameNumber\":", formatted);
            Assert.Contains("42", formatted);
        }

        /// <summary>
        ///     Tests that json log formatter format empty message
        /// </summary>
        [Fact]
        public void JsonLogFormatter_Format_EmptyMessage()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, string.Empty, "Logger");

            string formatted = formatter.Format(entry);

            Assert.StartsWith("{", formatted);
            Assert.EndsWith("}", formatted);
        }

        /// <summary>
        ///     Tests that json log formatter format long message
        /// </summary>
        [Fact]
        public void JsonLogFormatter_Format_LongMessage()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            string longMessage = new string('x', 1000);
            LogEntry entry = new LogEntry(LogLevel.Info, longMessage, "Logger");

            string formatted = formatter.Format(entry);

            Assert.Contains(longMessage, formatted);
        }

        /// <summary>
        ///     Tests that json log formatter format valid json structure
        /// </summary>
        [Fact]
        public void JsonLogFormatter_Format_ValidJsonStructure()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger", correlationId: "ID",
                properties: new Dictionary<string, object> {{"key", "value"}});

            string formatted = formatter.Format(entry);

            int openBraces = formatted.Count(c => c == '{');
            int closeBraces = formatted.Count(c => c == '}');
            Assert.Equal(openBraces, closeBraces);

            int openBrackets = formatted.Count(c => c == '[');
            int closeBrackets = formatted.Count(c => c == ']');
            Assert.Equal(openBrackets, closeBrackets);
        }
    }
}