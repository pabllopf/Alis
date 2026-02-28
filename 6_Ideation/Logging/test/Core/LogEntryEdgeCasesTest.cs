// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: Core/LogEntryEdgeCasesTest.cs
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
using Alis.Core.Aspect.Logging.Test.Attributes;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test.Core
{
    /// <summary>
    ///     Edge case and boundary condition tests for LogEntry class.
    ///     Tests Unicode, extreme sizes, and special scenarios.
    /// </summary>
    public class LogEntryEdgeCasesTest
    {
        [Fact]
        public void LogEntry_Unicode_ShouldBePreserved()
        {
            // Arrange
            var unicodeMessage = "Message with 中文, العربية, 🎮, émojis!";

            // Act
            var entry = new LogEntry(LogLevel.Info, unicodeMessage, "Logger");

            // Assert
            Assert.Equal(unicodeMessage, entry.Message);
        }

        [Fact]
        public void LogEntry_VeryLongMessage_ShouldBeStored()
        {
            // Arrange
            var longMessage = new string('a', 1000000); // 1MB message

            // Act
            var entry = new LogEntry(LogLevel.Info, longMessage, "Logger");

            // Assert
            Assert.Equal(1000000, entry.Message.Length);
        }

        [Fact]
        public void LogEntry_VeryLongLoggerName_ShouldBeStored()
        {
            // Arrange
            var longName = "Namespace." + string.Join(".", new[] { "Class" }.Length is 1 ? new string('x', 1000) : new string('x', 1000));

            // Act
            var entry = new LogEntry(LogLevel.Info, "Message", longName);

            // Assert
            Assert.Equal(longName, entry.LoggerName);
        }

        [Fact]
        public void LogEntry_ManyProperties_ShouldBeStored()
        {
            // Arrange
            var properties = new Dictionary<string, object>();
            for (int i = 0; i < 1000; i++)
            {
                properties[$"Property{i}"] = i;
            }

            // Act
            var entry = new LogEntry(LogLevel.Info, "Message", "Logger", properties: properties);

            // Assert
            Assert.Equal(1000, entry.Properties.Count);
        }

        [Fact]
        public void LogEntry_DeepScopeNesting_ShouldBeStored()
        {
            // Arrange
            var scopes = new List<object>();
            for (int i = 0; i < 100; i++)
            {
                scopes.Add($"Scope{i}");
            }

            // Act
            var entry = new LogEntry(LogLevel.Info, "Message", "Logger", scopes: scopes);

            // Assert
            Assert.Equal(100, entry.Scopes.Count);
        }

        [Fact]
        public void LogEntry_WhitespaceOnlyMessage_ShouldBeStored()
        {
            // Arrange
            var whitespaceMessage = "   \t\n\r   ";

            // Act
            var entry = new LogEntry(LogLevel.Info, whitespaceMessage, "Logger");

            // Assert
            Assert.Equal(whitespaceMessage, entry.Message);
        }

        [Fact]
        public void LogEntry_NullObjectInProperties_ShouldBeHandled()
        {
            // Arrange
            var properties = new Dictionary<string, object>
            {
                { "NullValue", null },
                { "ValidValue", "test" }
            };

            // Act
            var entry = new LogEntry(LogLevel.Info, "Message", "Logger", properties: properties);

            // Assert
            Assert.Equal(2, entry.Properties.Count);
            Assert.Null(entry.Properties["NullValue"]);
        }

        [Fact]
        public void LogEntry_NullObjectInScopes_ShouldBeHandled()
        {
            // Arrange
            var scopes = new List<object> { "ValidScope", null, "AnotherScope" };

            // Act
            var entry = new LogEntry(LogLevel.Info, "Message", "Logger", scopes: scopes);

            // Assert
            Assert.Equal(3, entry.Scopes.Count);
            Assert.Null(entry.Scopes[1]);
        }

        [Fact]
        public void LogEntry_ExceptionWithInnerException_ShouldPreserveStack()
        {
            // Arrange
            var innerException = new ArgumentException("Inner error");
            var outerException = new InvalidOperationException("Outer error", innerException);

            // Act
            var entry = new LogEntry(LogLevel.Error, "Message", "Logger", outerException);

            // Assert
            Assert.NotNull(entry.Exception);
            Assert.NotNull(entry.Exception.InnerException);
            Assert.Equal("Outer error", entry.Exception.Message);
        }

        [WindowsOnly]
        public void LogEntry_WindowsPaths_InMessage_ShouldPreserve()
        {
            // Arrange
            var windowsPath = "C:\\Users\\Test\\Documents\\file.txt";

            // Act
            var entry = new LogEntry(LogLevel.Info, windowsPath, "Logger");

            // Assert
            Assert.Contains(windowsPath, entry.Message);
        }

        [LinuxOnly]
        public void LogEntry_LinuxPaths_InMessage_ShouldPreserve()
        {
            // Arrange
            var linuxPath = "/home/user/documents/file.txt";

            // Act
            var entry = new LogEntry(LogLevel.Info, linuxPath, "Logger");

            // Assert
            Assert.Contains(linuxPath, entry.Message);
        }

        [Fact]
        public void LogEntry_PropertyValuesOfDifferentTypes()
        {
            // Arrange
            var properties = new Dictionary<string, object>
            {
                { "String", "value" },
                { "Int", 42 },
                { "Double", 3.14 },
                { "Bool", true },
                { "DateTime", DateTime.Now },
                { "Object", new { nested = "value" } }
            };

            // Act
            var entry = new LogEntry(LogLevel.Info, "Message", "Logger", properties: properties);

            // Assert
            Assert.Equal(6, entry.Properties.Count);
            Assert.IsType<string>(entry.Properties["String"]);
            Assert.IsType<int>(entry.Properties["Int"]);
        }

        [Fact]
        public void LogEntry_RepeatedPropertyNames_LastValueWins()
        {
            // Arrange
            var properties = new Dictionary<string, object>
            {
                { "Key", "FirstValue" }
            };
            properties["Key"] = "SecondValue";

            // Act
            var entry = new LogEntry(LogLevel.Info, "Message", "Logger", properties: properties);

            // Assert
            Assert.Equal("SecondValue", entry.Properties["Key"]);
        }

        [Fact]
        public void LogEntry_CorrelationIdWithSpecialCharacters()
        {
            // Arrange
            var correlationId = "CORR-2024-03-02T10:30:45.123Z-uuid-1234-5678";

            // Act
            var entry = new LogEntry(LogLevel.Info, "Message", "Logger", correlationId: correlationId);

            // Assert
            Assert.Equal(correlationId, entry.CorrelationId);
        }
    }
}

