// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: ConditionalLogFilterTest.cs
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
using Alis.Core.Aspect.Logging.Filters;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Comprehensive unit tests for the ConditionalLogFilter class.
    ///     Validates custom predicate-based filtering logic.
    /// </summary>
    public class ConditionalLogFilterTest
    {
        [Fact]
        public void ConditionalLogFilter_SimplePredicate_ShouldApply()
        {
            // Arrange
            ConditionalLogFilter filter = new ConditionalLogFilter(e => e.Level >= LogLevel.Warning);

            // Act & Assert
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Info)));
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Warning)));
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Error)));
        }

        [Fact]
        public void ConditionalLogFilter_MessageContainsPredicate_ShouldApply()
        {
            // Arrange
            ConditionalLogFilter filter = new ConditionalLogFilter(e => e.Message.Contains("Error"));

            // Act & Assert
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Info, "Error occurred")));
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Info, "Normal message")));
        }

        [Fact]
        public void ConditionalLogFilter_LoggerNamePredicate_ShouldApply()
        {
            // Arrange
            ConditionalLogFilter filter = new ConditionalLogFilter(e => e.LoggerName.StartsWith("Engine"));

            // Act & Assert
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Info, "Test", "Engine.Core")));
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Info, "Test", "Audio.Mixer")));
        }

        [Fact]
        public void ConditionalLogFilter_MultipleConditions_ShouldApply()
        {
            // Arrange
            ConditionalLogFilter filter = new ConditionalLogFilter(e =>
                e.Level >= LogLevel.Warning &&
                e.Message.Contains("Critical")
            );

            // Act & Assert
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Error, "Critical error")));
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Error, "Normal error")));
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Info, "Critical info")));
        }

        [Fact]
        public void ConditionalLogFilter_ExceptionCheckPredicate_ShouldApply()
        {
            // Arrange
            ConditionalLogFilter filter = new ConditionalLogFilter(e => e.Exception != null);

            // Act & Assert
            LogEntry entryWithException = new LogEntry(LogLevel.Error, "Error", "Logger", new InvalidOperationException());
            LogEntry entryWithoutException = new LogEntry(LogLevel.Error, "Error", "Logger");

            Assert.True(filter.ShouldLog(entryWithException));
            Assert.False(filter.ShouldLog(entryWithoutException));
        }

        [Fact]
        public void ConditionalLogFilter_CorrelationIdPredicate_ShouldApply()
        {
            // Arrange
            ConditionalLogFilter filter = new ConditionalLogFilter(e => !string.IsNullOrEmpty(e.CorrelationId));

            // Act & Assert
            LogEntry entryWithCorrelation = new LogEntry(LogLevel.Info, "Test", "Logger", correlationId: "CORR-123");
            LogEntry entryWithoutCorrelation = new LogEntry(LogLevel.Info, "Test", "Logger");

            Assert.True(filter.ShouldLog(entryWithCorrelation));
            Assert.False(filter.ShouldLog(entryWithoutCorrelation));
        }

        [Fact]
        public void ConditionalLogFilter_PredicateThrowsException_ShouldReturnTrue()
        {
            // Arrange
            ConditionalLogFilter filter = new ConditionalLogFilter(e => throw new InvalidOperationException("Test error"));

            // Act & Assert - Should not throw, should return true
            ILogEntry entry = CreateEntry(LogLevel.Info);
            Assert.True(filter.ShouldLog(entry));
        }

        [Fact]
        public void ConditionalLogFilter_NullEntry_ShouldBePassedToPredicate()
        {
            // Arrange
            bool predicateCalled = false;
            ConditionalLogFilter filter = new ConditionalLogFilter(e =>
            {
                predicateCalled = true;
                return e != null;
            });

            // Act
            bool result = filter.ShouldLog(null);

            // Assert
            Assert.True(predicateCalled);
            Assert.False(result);
        }

        [Fact]
        public void ConditionalLogFilter_CustomName_ShouldUseProvidedName()
        {
            // Arrange
            ConditionalLogFilter filter = new ConditionalLogFilter(e => true, "MyCustomFilter");

            // Act & Assert
            Assert.Equal("MyCustomFilter", filter.Name);
        }

        [Fact]
        public void ConditionalLogFilter_DefaultName_ShouldBeConditionalFilter()
        {
            // Arrange
            ConditionalLogFilter filter = new ConditionalLogFilter(e => true);

            // Act & Assert
            Assert.Equal("ConditionalFilter", filter.Name);
        }

        [Fact]
        public void ConditionalLogFilter_ScopeCountPredicate_ShouldApply()
        {
            // Arrange
            ConditionalLogFilter filter = new ConditionalLogFilter(e => e.Scopes.Count > 0);

            // Act & Assert
            LogEntry entryWithScopes = new LogEntry(LogLevel.Info, "Test", "Logger", scopes: new[] { "Scope" });
            LogEntry entryWithoutScopes = new LogEntry(LogLevel.Info, "Test", "Logger");

            Assert.True(filter.ShouldLog(entryWithScopes));
            Assert.False(filter.ShouldLog(entryWithoutScopes));
        }

        [Fact]
        public void ConditionalLogFilter_PropertyCountPredicate_ShouldApply()
        {
            // Arrange
            ConditionalLogFilter filter = new ConditionalLogFilter(e => e.Properties.Count >= 2);

            // Act & Assert
            LogEntry entryWithProperties = new LogEntry(LogLevel.Info, "Test", "Logger",
                properties: new Dictionary<string, object> { { "key1", "value1" }, { "key2", "value2" } });
            LogEntry entryWithOneProperty = new LogEntry(LogLevel.Info, "Test", "Logger",
                properties: new Dictionary<string, object> { { "key", "value" } });

            Assert.True(filter.ShouldLog(entryWithProperties));
            Assert.False(filter.ShouldLog(entryWithOneProperty));
        }

        [Fact]
        public void ConditionalLogFilter_ThreadIdPredicate_ShouldApply()
        {
            // Arrange
            int currentThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
            ConditionalLogFilter filter = new ConditionalLogFilter(e => e.ThreadId == currentThreadId);

            // Act & Assert
            ILogEntry entry = CreateEntry(LogLevel.Info);
            Assert.True(filter.ShouldLog(entry));
        }

        [Fact]
        public void ConditionalLogFilter_ComplexLogicWithAllProperties_ShouldApply()
        {
            // Arrange
            ConditionalLogFilter filter = new ConditionalLogFilter(e =>
                e.Level >= LogLevel.Error &&
                !string.IsNullOrEmpty(e.CorrelationId) &&
                e.Message.Length > 5
            );

            // Act & Assert
            LogEntry validEntry = new LogEntry(LogLevel.Error, "Long error message", "Logger", correlationId: "CORR-123");
            LogEntry invalidEntry1 = new LogEntry(LogLevel.Info, "Long error message", "Logger", correlationId: "CORR-123");
            LogEntry invalidEntry2 = new LogEntry(LogLevel.Error, "Long error message", "Logger");
            LogEntry invalidEntry3 = new LogEntry(LogLevel.Error, "Short", "Logger", correlationId: "CORR-123");

            Assert.True(filter.ShouldLog(validEntry));
            Assert.False(filter.ShouldLog(invalidEntry1));
            Assert.False(filter.ShouldLog(invalidEntry2));
            Assert.False(filter.ShouldLog(invalidEntry3));
        }

        private static ILogEntry CreateEntry(LogLevel level, string message = "Test", string loggerName = "Logger")
        {
            return new LogEntry(level, message, loggerName);
        }
    }
}

