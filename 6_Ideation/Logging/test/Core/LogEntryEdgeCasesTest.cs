// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LogEntryEdgeCasesTest.cs
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
        /// <summary>
        /// Tests that log entry unicode should be preserved
        /// </summary>
        [Fact]
        public void LogEntry_Unicode_ShouldBePreserved()
        {
            // Arrange
            string unicodeMessage = "Message with 中文, العربية, 🎮, émojis!";

            // Act
            LogEntry entry = new LogEntry(LogLevel.Info, unicodeMessage, "Logger");

            // Assert
            Assert.Equal(unicodeMessage, entry.Message);
        }

        /// <summary>
        /// Tests that log entry very long message should be stored
        /// </summary>
        [Fact]
        public void LogEntry_VeryLongMessage_ShouldBeStored()
        {
            // Arrange
            string longMessage = new string('a', 1000000); // 1MB message

            // Act
            LogEntry entry = new LogEntry(LogLevel.Info, longMessage, "Logger");

            // Assert
            Assert.Equal(1000000, entry.Message.Length);
        }

        /// <summary>
        /// Tests that log entry very long logger name should be stored
        /// </summary>
        [Fact]
        public void LogEntry_VeryLongLoggerName_ShouldBeStored()
        {
            // Arrange
            string longName = "Namespace." + string.Join(".", new[] {"Class"}.Length is 1 ? new string('x', 1000) : new string('x', 1000));

            // Act
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", longName);

            // Assert
            Assert.Equal(longName, entry.LoggerName);
        }

        /// <summary>
        /// Tests that log entry many properties should be stored
        /// </summary>
        [Fact]
        public void LogEntry_ManyProperties_ShouldBeStored()
        {
            // Arrange
            Dictionary<string, object> properties = new Dictionary<string, object>();
            for (int i = 0; i < 1000; i++)
            {
                properties[$"Property{i}"] = i;
            }

            // Act
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", properties: properties);

            // Assert
            Assert.Equal(1000, entry.Properties.Count);
        }

        /// <summary>
        /// Tests that log entry deep scope nesting should be stored
        /// </summary>
        [Fact]
        public void LogEntry_DeepScopeNesting_ShouldBeStored()
        {
            // Arrange
            List<object> scopes = new List<object>();
            for (int i = 0; i < 100; i++)
            {
                scopes.Add($"Scope{i}");
            }

            // Act
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", scopes: scopes);

            // Assert
            Assert.Equal(100, entry.Scopes.Count);
        }

        /// <summary>
        /// Tests that log entry whitespace only message should be stored
        /// </summary>
        [Fact]
        public void LogEntry_WhitespaceOnlyMessage_ShouldBeStored()
        {
            // Arrange
            string whitespaceMessage = "   \t\n\r   ";

            // Act
            LogEntry entry = new LogEntry(LogLevel.Info, whitespaceMessage, "Logger");

            // Assert
            Assert.Equal(whitespaceMessage, entry.Message);
        }

        /// <summary>
        /// Tests that log entry null object in properties should be handled
        /// </summary>
        [Fact]
        public void LogEntry_NullObjectInProperties_ShouldBeHandled()
        {
            // Arrange
            Dictionary<string, object> properties = new Dictionary<string, object>
            {
                {"NullValue", null},
                {"ValidValue", "test"}
            };

            // Act
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", properties: properties);

            // Assert
            Assert.Equal(2, entry.Properties.Count);
            Assert.Null(entry.Properties["NullValue"]);
        }

        /// <summary>
        /// Tests that log entry null object in scopes should be handled
        /// </summary>
        [Fact]
        public void LogEntry_NullObjectInScopes_ShouldBeHandled()
        {
            // Arrange
            List<object> scopes = new List<object> {"ValidScope", null, "AnotherScope"};

            // Act
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", scopes: scopes);

            // Assert
            Assert.Equal(3, entry.Scopes.Count);
            Assert.Null(entry.Scopes[1]);
        }

        /// <summary>
        /// Tests that log entry exception with inner exception should preserve stack
        /// </summary>
        [Fact]
        public void LogEntry_ExceptionWithInnerException_ShouldPreserveStack()
        {
            // Arrange
            ArgumentException innerException = new ArgumentException("Inner error");
            InvalidOperationException outerException = new InvalidOperationException("Outer error", innerException);

            // Act
            LogEntry entry = new LogEntry(LogLevel.Error, "Message", "Logger", outerException);

            // Assert
            Assert.NotNull(entry.Exception);
            Assert.NotNull(entry.Exception.InnerException);
            Assert.Equal("Outer error", entry.Exception.Message);
        }

        /// <summary>
        /// Logs the entry windows paths in message should preserve
        /// </summary>
        [WindowsOnly]
        public void LogEntry_WindowsPaths_InMessage_ShouldPreserve()
        {
            // Arrange
            string windowsPath = "C:\\Users\\Test\\Documents\\file.txt";

            // Act
            LogEntry entry = new LogEntry(LogLevel.Info, windowsPath, "Logger");

            // Assert
            Assert.Contains(windowsPath, entry.Message);
        }

        /// <summary>
        /// Logs the entry linux paths in message should preserve
        /// </summary>
        [LinuxOnly]
        public void LogEntry_LinuxPaths_InMessage_ShouldPreserve()
        {
            // Arrange
            string linuxPath = "/home/user/documents/file.txt";

            // Act
            LogEntry entry = new LogEntry(LogLevel.Info, linuxPath, "Logger");

            // Assert
            Assert.Contains(linuxPath, entry.Message);
        }

        /// <summary>
        /// Tests that log entry property values of different types
        /// </summary>
        [Fact]
        public void LogEntry_PropertyValuesOfDifferentTypes()
        {
            // Arrange
            Dictionary<string, object> properties = new Dictionary<string, object>
            {
                {"String", "value"},
                {"Int", 42},
                {"Double", 3.14},
                {"Bool", true},
                {"DateTime", DateTime.Now},
                {"Object", new {nested = "value"}}
            };

            // Act
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", properties: properties);

            // Assert
            Assert.Equal(6, entry.Properties.Count);
            Assert.IsType<string>(entry.Properties["String"]);
            Assert.IsType<int>(entry.Properties["Int"]);
        }

        /// <summary>
        /// Tests that log entry repeated property names last value wins
        /// </summary>
        [Fact]
        public void LogEntry_RepeatedPropertyNames_LastValueWins()
        {
            // Arrange
            Dictionary<string, object> properties = new Dictionary<string, object>
            {
                {"Key", "FirstValue"}
            };
            properties["Key"] = "SecondValue";

            // Act
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", properties: properties);

            // Assert
            Assert.Equal("SecondValue", entry.Properties["Key"]);
        }

        /// <summary>
        /// Tests that log entry correlation id with special characters
        /// </summary>
        [Fact]
        public void LogEntry_CorrelationIdWithSpecialCharacters()
        {
            // Arrange
            string correlationId = "CORR-2024-03-02T10:30:45.123Z-uuid-1234-5678";

            // Act
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", correlationId: correlationId);

            // Assert
            Assert.Equal(correlationId, entry.CorrelationId);
        }
    }
}