// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JsonLogFormatterEdgeCasesTest.cs
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
using Alis.Core.Aspect.Logging.Test.Attributes;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test.Formatters
{
    /// <summary>
    ///     Edge case tests for JsonLogFormatter.
    ///     Tests JSON escaping, Unicode, and special characters.
    /// </summary>
    public class JsonLogFormatterEdgeCasesTest
    {
        /// <summary>
        ///     Tests that json log formatter control characters should be escaped
        /// </summary>
        [Fact]
        public void JsonLogFormatter_ControlCharacters_ShouldBeEscaped()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Message with\nnewline\ttab\rcarriage", "Logger");

            string formatted = formatter.Format(entry);

            Assert.Contains("\\n", formatted);
            Assert.Contains("\\t", formatted);
            Assert.Contains("\\r", formatted);
        }

        /// <summary>
        ///     Tests that json log formatter quotes and backslashes should be escaped
        /// </summary>
        [Fact]
        public void JsonLogFormatter_QuotesAndBackslashes_ShouldBeEscaped()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Quote: \" and Backslash: \\", "Logger");

            string formatted = formatter.Format(entry);

            Assert.Contains("\\\"", formatted);
            Assert.Contains("\\\\", formatted);
        }

        /// <summary>
        ///     Tests that json log formatter unicode characters should be preserved
        /// </summary>
        [Fact]
        public void JsonLogFormatter_UnicodeCharacters_ShouldBePreserved()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Unicode: 你好 مرحبا 🎮", "Logger");

            string formatted = formatter.Format(entry);

            Assert.Contains("你好", formatted);
            Assert.Contains("مرحبا", formatted);
            Assert.Contains("🎮", formatted);
        }

        /// <summary>
        ///     Tests that json log formatter very long string in message
        /// </summary>
        [Fact]
        public void JsonLogFormatter_VeryLongStringInMessage()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            string longMessage = new string('x', 100000);
            LogEntry entry = new LogEntry(LogLevel.Info, longMessage, "Logger");

            string formatted = formatter.Format(entry);

            Assert.Contains(longMessage, formatted);
            Assert.StartsWith("{", formatted);
            Assert.EndsWith("}", formatted);
        }

        /// <summary>
        ///     Tests that json log formatter very long property value
        /// </summary>
        [Fact]
        public void JsonLogFormatter_VeryLongPropertyValue()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            string longValue = new string('y', 100000);
            Dictionary<string, object> properties = new Dictionary<string, object> {{"LongKey", longValue}};
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", properties: properties);

            string formatted = formatter.Format(entry);

            Assert.Contains(longValue, formatted);
        }

        /// <summary>
        ///     Tests that json log formatter many properties
        /// </summary>
        [Fact]
        public void JsonLogFormatter_ManyProperties()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            Dictionary<string, object> properties = new Dictionary<string, object>();
            for (int i = 0; i < 100; i++)
            {
                properties[$"Prop{i}"] = $"Value{i}";
            }

            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", properties: properties);

            string formatted = formatter.Format(entry);

            Assert.Contains("properties", formatted);
            for (int i = 0; i < 10; i++)
            {
                Assert.Contains($"Prop{i}", formatted);
            }
        }

        /// <summary>
        ///     Tests that json log formatter many scopes
        /// </summary>
        [Fact]
        public void JsonLogFormatter_ManyScopes()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            List<object> scopes = new List<object>();
            for (int i = 0; i < 50; i++)
            {
                scopes.Add($"Scope{i}");
            }

            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", scopes: scopes);

            string formatted = formatter.Format(entry);

            Assert.Contains("scopes", formatted);
            Assert.Contains("[", formatted);
            Assert.Contains("]", formatted);
        }

        /// <summary>
        ///     Jsons the log formatter windows file path in message
        /// </summary>
        [WindowsOnly]
        public void JsonLogFormatter_WindowsFilePathInMessage()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "File: C:\\Users\\Test\\file.txt", "Logger");

            string formatted = formatter.Format(entry);

            Assert.Contains("C:\\\\Users\\\\Test\\\\file.txt", formatted);
        }

        /// <summary>
        ///     Jsons the log formatter linux file path in message
        /// </summary>
        [LinuxOnly]
        public void JsonLogFormatter_LinuxFilePathInMessage()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "File: /home/user/file.txt", "Logger");

            string formatted = formatter.Format(entry);

            Assert.Contains("/home/user/file.txt", formatted);
        }

        /// <summary>
        ///     Tests that json log formatter special json characters in property names
        /// </summary>
        [Fact]
        public void JsonLogFormatter_SpecialJsonCharactersInPropertyNames()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            Dictionary<string, object> properties = new Dictionary<string, object>
            {
                {"key\"with\"quotes", "value"},
                {"key\\with\\backslash", "value"}
            };
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", properties: properties);

            string formatted = formatter.Format(entry);

            Assert.StartsWith("{", formatted);
            Assert.EndsWith("}", formatted);
        }

        /// <summary>
        ///     Tests that json log formatter null property values
        /// </summary>
        [Fact]
        public void JsonLogFormatter_NullPropertyValues()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            Dictionary<string, object> properties = new Dictionary<string, object>
            {
                {"NullValue", null},
                {"StringValue", "test"}
            };
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", properties: properties);

            string formatted = formatter.Format(entry);

            Assert.Contains("\"NullValue\":\"null\"", formatted);
        }

        /// <summary>
        ///     Tests that json log formatter valid json with complex entry
        /// </summary>
        [Fact]
        public void JsonLogFormatter_ValidJsonWithComplexEntry()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(
                LogLevel.Error,
                "Complex message",
                "ComplexLogger",
                new InvalidOperationException("Test"),
                "CORR-123",
                new Dictionary<string, object> {{"key", "value"}},
                new List<object> {"scope1", "scope2"}
            );

            string formatted = formatter.Format(entry);

            Assert.StartsWith("{", formatted);
            Assert.EndsWith("}", formatted);

            int openCount = formatted.Count(c => c == '{');
            int closeCount = formatted.Count(c => c == '}');
            Assert.Equal(openCount, closeCount);
        }
    }
}