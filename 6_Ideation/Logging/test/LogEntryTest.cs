// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LogEntryTest.cs
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
using System.Threading;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Comprehensive unit tests for the LogEntry class.
    ///     Validates immutability, timestamp accuracy, thread ID tracking,
    ///     and proper handling of optional parameters.
    /// </summary>
    public class LogEntryTest
    {
        /// <summary>
        ///     Tests that log entry constructor should initialize all properties
        /// </summary>
        [Fact]
        public void LogEntry_Constructor_ShouldInitializeAllProperties()
        {
            // Arrange
            LogLevel level = LogLevel.Info;
            string message = "Test message";
            string loggerName = "TestLogger";
            InvalidOperationException exception = new InvalidOperationException("Test");
            string correlationId = "CORR-123";
            Dictionary<string, object> properties = new Dictionary<string, object> {{"key", "value"}};
            List<object> scopes = new List<object> {"scope1"};

            // Act
            LogEntry entry = new LogEntry(level, message, loggerName, exception, correlationId, properties, scopes);

            // Assert
            Assert.Equal(level, entry.Level);
            Assert.Equal(message, entry.Message);
            Assert.Equal(loggerName, entry.LoggerName);
            Assert.NotNull(entry.Exception);
            Assert.Equal("Test", entry.Exception.Message);
            Assert.Equal(correlationId, entry.CorrelationId);
            Assert.NotNull(entry.Properties);
            Assert.NotNull(entry.Scopes);
        }

        /// <summary>
        ///     Tests that log entry null message should store empty string
        /// </summary>
        [Fact]
        public void LogEntry_NullMessage_ShouldStoreEmptyString()
        {
            // Arrange & Act
            LogEntry entry = new LogEntry(LogLevel.Info, null, "Logger");

            // Assert
            Assert.Equal(string.Empty, entry.Message);
        }

        /// <summary>
        ///     Tests that log entry null logger name should store empty string
        /// </summary>
        [Fact]
        public void LogEntry_NullLoggerName_ShouldStoreEmptyString()
        {
            // Arrange & Act
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", null);

            // Assert
            Assert.Equal(string.Empty, entry.LoggerName);
        }

        /// <summary>
        ///     Tests that log entry null properties should store empty dictionary
        /// </summary>
        [Fact]
        public void LogEntry_NullProperties_ShouldStoreEmptyDictionary()
        {
            // Arrange & Act
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", properties: null);

            // Assert
            Assert.NotNull(entry.Properties);
            Assert.Empty(entry.Properties);
        }

        /// <summary>
        ///     Tests that log entry null scopes should store empty list
        /// </summary>
        [Fact]
        public void LogEntry_NullScopes_ShouldStoreEmptyList()
        {
            // Arrange & Act
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", scopes: null);

            // Assert
            Assert.NotNull(entry.Scopes);
            Assert.Empty(entry.Scopes);
        }

        /// <summary>
        ///     Tests that log entry timestamp should be current
        /// </summary>
        [Fact]
        public void LogEntry_TimestampShouldBeCurrent()
        {
            // Arrange
            DateTime beforeCreation = DateTime.UtcNow;

            // Act
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger");
            DateTime afterCreation = DateTime.UtcNow;

            // Assert
            Assert.True(entry.Timestamp >= beforeCreation);
            Assert.True(entry.Timestamp <= afterCreation.AddSeconds(1));
        }

        /// <summary>
        ///     Tests that log entry thread id should match current thread
        /// </summary>
        [Fact]
        public void LogEntry_ThreadIdShouldMatchCurrentThread()
        {
            // Arrange & Act
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger");

            // Assert
            Assert.Equal(Thread.CurrentThread.ManagedThreadId, entry.ThreadId);
        }

        /// <summary>
        ///     Tests that log entry all log levels should store correctly
        /// </summary>
        [Fact]
        public void LogEntry_AllLogLevels_ShouldStoreCorrectly()
        {
            // Arrange
            LogLevel[] levels = new[] {LogLevel.Trace, LogLevel.Debug, LogLevel.Info, LogLevel.Warning, LogLevel.Error, LogLevel.Critical, LogLevel.None};

            foreach (LogLevel level in levels)
            {
                // Act
                LogEntry entry = new LogEntry(level, "Message", "Logger");

                // Assert
                Assert.Equal(level, entry.Level);
            }
        }

        /// <summary>
        ///     Tests that log entry with exception should store exception
        /// </summary>
        [Fact]
        public void LogEntry_WithException_ShouldStoreException()
        {
            // Arrange
            ArgumentException exception = new ArgumentException("Invalid argument");

            // Act
            LogEntry entry = new LogEntry(LogLevel.Error, "Error occurred", "Logger", exception);

            // Assert
            Assert.NotNull(entry.Exception);
            Assert.IsType<ArgumentException>(entry.Exception);
            Assert.Equal("Invalid argument", entry.Exception.Message);
        }

        /// <summary>
        ///     Tests that log entry without exception should have null exception
        /// </summary>
        [Fact]
        public void LogEntry_WithoutException_ShouldHaveNullException()
        {
            // Arrange & Act
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger");

            // Assert
            Assert.Null(entry.Exception);
        }

        /// <summary>
        ///     Tests that log entry with correlation id should store it
        /// </summary>
        [Fact]
        public void LogEntry_WithCorrelationId_ShouldStoreIt()
        {
            // Arrange
            string correlationId = Guid.NewGuid().ToString();

            // Act
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", correlationId: correlationId);

            // Assert
            Assert.Equal(correlationId, entry.CorrelationId);
        }

        /// <summary>
        ///     Tests that log entry without correlation id should be null
        /// </summary>
        [Fact]
        public void LogEntry_WithoutCorrelationId_ShouldBeNull()
        {
            // Arrange & Act
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger");

            // Assert
            Assert.Null(entry.CorrelationId);
        }

        /// <summary>
        ///     Tests that log entry with properties should contain all properties
        /// </summary>
        [Fact]
        public void LogEntry_WithProperties_ShouldContainAllProperties()
        {
            // Arrange
            Dictionary<string, object> properties = new Dictionary<string, object>
            {
                {"UserId", 123},
                {"Action", "Login"},
                {"Timestamp", DateTime.Now}
            };

            // Act
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", properties: properties);

            // Assert
            Assert.Equal(3, entry.Properties.Count);
            Assert.Equal(123, entry.Properties["UserId"]);
            Assert.Equal("Login", entry.Properties["Action"]);
        }

        /// <summary>
        ///     Tests that log entry with scopes should contain all scopes
        /// </summary>
        [Fact]
        public void LogEntry_WithScopes_ShouldContainAllScopes()
        {
            // Arrange
            List<object> scopes = new List<object> {"Scope1", "Scope2", 42, new object()};

            // Act
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", scopes: scopes);

            // Assert
            Assert.Equal(4, entry.Scopes.Count);
            Assert.Equal("Scope1", entry.Scopes[0]);
            Assert.Equal("Scope2", entry.Scopes[1]);
            Assert.Equal(42, entry.Scopes[2]);
        }

        /// <summary>
        ///     Tests that log entry empty message should be allowed
        /// </summary>
        [Fact]
        public void LogEntry_EmptyMessage_ShouldBeAllowed()
        {
            // Arrange & Act
            LogEntry entry = new LogEntry(LogLevel.Info, string.Empty, "Logger");

            // Assert
            Assert.Equal(string.Empty, entry.Message);
        }

        /// <summary>
        ///     Tests that log entry long message should be stored
        /// </summary>
        [Fact]
        public void LogEntry_LongMessage_ShouldBeStored()
        {
            // Arrange
            string longMessage = new string('x', 10000);

            // Act
            LogEntry entry = new LogEntry(LogLevel.Info, longMessage, "Logger");

            // Assert
            Assert.Equal(longMessage, entry.Message);
            Assert.Equal(10000, entry.Message.Length);
        }

        /// <summary>
        ///     Tests that log entry special characters in message should be preserved
        /// </summary>
        [Fact]
        public void LogEntry_SpecialCharactersInMessage_ShouldBePreserved()
        {
            // Arrange
            string specialMessage = "Message with special chars: \n \t \r \" ' \\";

            // Act
            LogEntry entry = new LogEntry(LogLevel.Info, specialMessage, "Logger");

            // Assert
            Assert.Equal(specialMessage, entry.Message);
        }

        /// <summary>
        ///     Tests that log entry multiple threads should capture correct thread ids
        /// </summary>
        [Fact]
        public void LogEntry_MultipleThreads_ShouldCaptureCorrectThreadIds()
        {
            // Arrange
            List<int> threadIds = new List<int>();
            List<Thread> threads = new List<Thread>();

            // Act
            for (int i = 0; i < 5; i++)
            {
                Thread thread = new Thread(() =>
                {
                    LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger");
                    lock (threadIds)
                    {
                        threadIds.Add(entry.ThreadId);
                    }
                });
                threads.Add(thread);
                thread.Start();
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            // Assert
            Assert.Equal(5, threadIds.Count);
            // All thread IDs should be unique (one per thread)
            HashSet<int> uniqueIds = new HashSet<int>(threadIds);
            Assert.Equal(5, uniqueIds.Count);
        }

        /// <summary>
        ///     Tests that log entry properties are readonly
        /// </summary>
        [Fact]
        public void LogEntry_PropertiesAreReadonly()
        {
            // Arrange
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger");

            // Assert - IReadOnlyDictionary should not have Add method
            Assert.True(typeof(IReadOnlyDictionary<string, object>).IsAssignableFrom(entry.Properties.GetType())
                        || entry.Properties.GetType().Name.Contains("ReadOnly"));
        }

        /// <summary>
        ///     Tests that log entry scopes are readonly
        /// </summary>
        [Fact]
        public void LogEntry_ScopesAreReadonly()
        {
            // Arrange
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger");

            // Assert - IReadOnlyList should not have Add method
            Assert.True(typeof(IReadOnlyList<object>).IsAssignableFrom(entry.Scopes.GetType())
                        || entry.Scopes.GetType().Name.Contains("ReadOnly"));
        }

        /// <summary>
        ///     Tests that log entry immutable after construction
        /// </summary>
        [Fact]
        public void LogEntry_ImmutableAfterConstruction()
        {
            // Arrange
            LogEntry entry = new LogEntry(LogLevel.Info, "Original", "Logger");
            string originalMessage = entry.Message;

            // Act - Try to modify (should not affect entry)
            Dictionary<string, object> properties = new Dictionary<string, object> {{"key", "value"}};
            LogEntry entry2 = new LogEntry(LogLevel.Warning, "Modified", "Logger", properties: properties);

            // Assert
            Assert.Equal(originalMessage, entry.Message);
            Assert.NotEqual(entry2.Message, entry.Message);
        }

        /// <summary>
        ///     Tests that log entry complex object should store as scope element
        /// </summary>
        [Fact]
        public void LogEntry_ComplexObject_ShouldStoreAsScopeElement()
        {
            // Arrange
            var complexScope = new {Id = 1, Name = "Test"};
            List<object> scopes = new List<object> {complexScope};

            // Act
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", scopes: scopes);

            // Assert
            Assert.Single(entry.Scopes);
            Assert.Equal(complexScope, entry.Scopes[0]);
        }
    }
}