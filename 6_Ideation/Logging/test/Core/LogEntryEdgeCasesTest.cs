

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
        ///     Tests that log entry unicode should be preserved
        /// </summary>
        [Fact]
        public void LogEntry_Unicode_ShouldBePreserved()
        {
            string unicodeMessage = "Message with 中文, العربية, 🎮, émojis!";

            LogEntry entry = new LogEntry(LogLevel.Info, unicodeMessage, "Logger");

            Assert.Equal(unicodeMessage, entry.Message);
        }

        /// <summary>
        ///     Tests that log entry very long message should be stored
        /// </summary>
        [Fact]
        public void LogEntry_VeryLongMessage_ShouldBeStored()
        {
            string longMessage = new string('a', 1000000); // 1MB message

            LogEntry entry = new LogEntry(LogLevel.Info, longMessage, "Logger");

            Assert.Equal(1000000, entry.Message.Length);
        }

        /// <summary>
        ///     Tests that log entry very long logger name should be stored
        /// </summary>
        [Fact]
        public void LogEntry_VeryLongLoggerName_ShouldBeStored()
        {
            string longName = "Namespace." + string.Join(".", new[] {"Class"}.Length is 1 ? new string('x', 1000) : new string('x', 1000));

            LogEntry entry = new LogEntry(LogLevel.Info, "Message", longName);

            Assert.Equal(longName, entry.LoggerName);
        }

        /// <summary>
        ///     Tests that log entry many properties should be stored
        /// </summary>
        [Fact]
        public void LogEntry_ManyProperties_ShouldBeStored()
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            for (int i = 0; i < 1000; i++)
            {
                properties[$"Property{i}"] = i;
            }

            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", properties: properties);

            Assert.Equal(1000, entry.Properties.Count);
        }

        /// <summary>
        ///     Tests that log entry deep scope nesting should be stored
        /// </summary>
        [Fact]
        public void LogEntry_DeepScopeNesting_ShouldBeStored()
        {
            List<object> scopes = new List<object>();
            for (int i = 0; i < 100; i++)
            {
                scopes.Add($"Scope{i}");
            }

            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", scopes: scopes);

            Assert.Equal(100, entry.Scopes.Count);
        }

        /// <summary>
        ///     Tests that log entry whitespace only message should be stored
        /// </summary>
        [Fact]
        public void LogEntry_WhitespaceOnlyMessage_ShouldBeStored()
        {
            string whitespaceMessage = "   \t\n\r   ";

            LogEntry entry = new LogEntry(LogLevel.Info, whitespaceMessage, "Logger");

            Assert.Equal(whitespaceMessage, entry.Message);
        }

        /// <summary>
        ///     Tests that log entry null object in properties should be handled
        /// </summary>
        [Fact]
        public void LogEntry_NullObjectInProperties_ShouldBeHandled()
        {
            Dictionary<string, object> properties = new Dictionary<string, object>
            {
                {"NullValue", null},
                {"ValidValue", "test"}
            };

            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", properties: properties);

            Assert.Equal(2, entry.Properties.Count);
            Assert.Null(entry.Properties["NullValue"]);
        }

        /// <summary>
        ///     Tests that log entry null object in scopes should be handled
        /// </summary>
        [Fact]
        public void LogEntry_NullObjectInScopes_ShouldBeHandled()
        {
            List<object> scopes = new List<object> {"ValidScope", null, "AnotherScope"};

            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", scopes: scopes);

            Assert.Equal(3, entry.Scopes.Count);
            Assert.Null(entry.Scopes[1]);
        }

        /// <summary>
        ///     Tests that log entry exception with inner exception should preserve stack
        /// </summary>
        [Fact]
        public void LogEntry_ExceptionWithInnerException_ShouldPreserveStack()
        {
            ArgumentException innerException = new ArgumentException("Inner error");
            InvalidOperationException outerException = new InvalidOperationException("Outer error", innerException);

            LogEntry entry = new LogEntry(LogLevel.Error, "Message", "Logger", outerException);

            Assert.NotNull(entry.Exception);
            Assert.NotNull(entry.Exception.InnerException);
            Assert.Equal("Outer error", entry.Exception.Message);
        }

        /// <summary>
        ///     Logs the entry windows paths in message should preserve
        /// </summary>
        [WindowsOnly]
        public void LogEntry_WindowsPaths_InMessage_ShouldPreserve()
        {
            string windowsPath = "C:\\Users\\Test\\Documents\\file.txt";

            LogEntry entry = new LogEntry(LogLevel.Info, windowsPath, "Logger");

            Assert.Contains(windowsPath, entry.Message);
        }

        /// <summary>
        ///     Logs the entry linux paths in message should preserve
        /// </summary>
        [LinuxOnly]
        public void LogEntry_LinuxPaths_InMessage_ShouldPreserve()
        {
            string linuxPath = "/home/user/documents/file.txt";

            LogEntry entry = new LogEntry(LogLevel.Info, linuxPath, "Logger");

            Assert.Contains(linuxPath, entry.Message);
        }

        /// <summary>
        ///     Tests that log entry property values of different types
        /// </summary>
        [Fact]
        public void LogEntry_PropertyValuesOfDifferentTypes()
        {
            Dictionary<string, object> properties = new Dictionary<string, object>
            {
                {"String", "value"},
                {"Int", 42},
                {"Double", 3.14},
                {"Bool", true},
                {"DateTime", DateTime.Now},
                {"Object", new {nested = "value"}}
            };

            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", properties: properties);

            Assert.Equal(6, entry.Properties.Count);
            Assert.IsType<string>(entry.Properties["String"]);
            Assert.IsType<int>(entry.Properties["Int"]);
        }

        /// <summary>
        ///     Tests that log entry repeated property names last value wins
        /// </summary>
        [Fact]
        public void LogEntry_RepeatedPropertyNames_LastValueWins()
        {
            Dictionary<string, object> properties = new Dictionary<string, object>
            {
                {"Key", "FirstValue"}
            };
            properties["Key"] = "SecondValue";

            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", properties: properties);

            Assert.Equal("SecondValue", entry.Properties["Key"]);
        }

        /// <summary>
        ///     Tests that log entry correlation id with special characters
        /// </summary>
        [Fact]
        public void LogEntry_CorrelationIdWithSpecialCharacters()
        {
            string correlationId = "CORR-2024-03-02T10:30:45.123Z-uuid-1234-5678";

            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", correlationId: correlationId);

            Assert.Equal(correlationId, entry.CorrelationId);
        }
    }
}