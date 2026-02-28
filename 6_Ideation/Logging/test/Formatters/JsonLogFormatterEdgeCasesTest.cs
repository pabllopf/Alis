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
        [Fact]
        public void JsonLogFormatter_ControlCharacters_ShouldBeEscaped()
        {
            // Arrange
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Message with\nnewline\ttab\rcarriage", "Logger");

            // Act
            string formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("\\n", formatted);
            Assert.Contains("\\t", formatted);
            Assert.Contains("\\r", formatted);
        }

        [Fact]
        public void JsonLogFormatter_QuotesAndBackslashes_ShouldBeEscaped()
        {
            // Arrange
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Quote: \" and Backslash: \\", "Logger");

            // Act
            string formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("\\\"", formatted);
            Assert.Contains("\\\\", formatted);
        }

        [Fact]
        public void JsonLogFormatter_UnicodeCharacters_ShouldBePreserved()
        {
            // Arrange
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Unicode: 你好 مرحبا 🎮", "Logger");

            // Act
            string formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("你好", formatted);
            Assert.Contains("مرحبا", formatted);
            Assert.Contains("🎮", formatted);
        }

        [Fact]
        public void JsonLogFormatter_VeryLongStringInMessage()
        {
            // Arrange
            JsonLogFormatter formatter = new JsonLogFormatter();
            string longMessage = new string('x', 100000);
            LogEntry entry = new LogEntry(LogLevel.Info, longMessage, "Logger");

            // Act
            string formatted = formatter.Format(entry);

            // Assert
            Assert.Contains(longMessage, formatted);
            Assert.StartsWith("{", formatted);
            Assert.EndsWith("}", formatted);
        }

        [Fact]
        public void JsonLogFormatter_VeryLongPropertyValue()
        {
            // Arrange
            JsonLogFormatter formatter = new JsonLogFormatter();
            string longValue = new string('y', 100000);
            Dictionary<string, object> properties = new Dictionary<string, object> {{"LongKey", longValue}};
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", properties: properties);

            // Act
            string formatted = formatter.Format(entry);

            // Assert
            Assert.Contains(longValue, formatted);
        }

        [Fact]
        public void JsonLogFormatter_ManyProperties()
        {
            // Arrange
            JsonLogFormatter formatter = new JsonLogFormatter();
            Dictionary<string, object> properties = new Dictionary<string, object>();
            for (int i = 0; i < 100; i++)
            {
                properties[$"Prop{i}"] = $"Value{i}";
            }

            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", properties: properties);

            // Act
            string formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("properties", formatted);
            for (int i = 0; i < 10; i++)
            {
                Assert.Contains($"Prop{i}", formatted);
            }
        }

        [Fact]
        public void JsonLogFormatter_ManyScopes()
        {
            // Arrange
            JsonLogFormatter formatter = new JsonLogFormatter();
            List<object> scopes = new List<object>();
            for (int i = 0; i < 50; i++)
            {
                scopes.Add($"Scope{i}");
            }

            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", scopes: scopes);

            // Act
            string formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("scopes", formatted);
            Assert.Contains("[", formatted);
            Assert.Contains("]", formatted);
        }

        [WindowsOnly]
        public void JsonLogFormatter_WindowsFilePathInMessage()
        {
            // Arrange
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "File: C:\\Users\\Test\\file.txt", "Logger");

            // Act
            string formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("C:\\\\Users\\\\Test\\\\file.txt", formatted);
        }

        [LinuxOnly]
        public void JsonLogFormatter_LinuxFilePathInMessage()
        {
            // Arrange
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "File: /home/user/file.txt", "Logger");

            // Act
            string formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("/home/user/file.txt", formatted);
        }

        [Fact]
        public void JsonLogFormatter_SpecialJsonCharactersInPropertyNames()
        {
            // Arrange
            JsonLogFormatter formatter = new JsonLogFormatter();
            Dictionary<string, object> properties = new Dictionary<string, object>
            {
                {"key\"with\"quotes", "value"},
                {"key\\with\\backslash", "value"}
            };
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", properties: properties);

            // Act
            string formatted = formatter.Format(entry);

            // Assert
            Assert.StartsWith("{", formatted);
            Assert.EndsWith("}", formatted);
        }

        [Fact]
        public void JsonLogFormatter_NullPropertyValues()
        {
            // Arrange
            JsonLogFormatter formatter = new JsonLogFormatter();
            Dictionary<string, object> properties = new Dictionary<string, object>
            {
                {"NullValue", null},
                {"StringValue", "test"}
            };
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", properties: properties);

            // Act
            string formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("\"NullValue\":\"null\"", formatted);
        }

        [Fact]
        public void JsonLogFormatter_ValidJsonWithComplexEntry()
        {
            // Arrange
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

            // Act
            string formatted = formatter.Format(entry);

            // Assert
            Assert.StartsWith("{", formatted);
            Assert.EndsWith("}", formatted);

            // Count braces
            int openCount = formatted.Count(c => c == '{');
            int closeCount = formatted.Count(c => c == '}');
            Assert.Equal(openCount, closeCount);
        }
    }
}