

using System;
using System.Collections.Generic;
using System.Threading;
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
        /// <summary>
        ///     Tests that conditional log filter simple predicate should apply
        /// </summary>
        [Fact]
        public void ConditionalLogFilter_SimplePredicate_ShouldApply()
        {
            ConditionalLogFilter filter = new ConditionalLogFilter(e => e.Level >= LogLevel.Warning);

            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Info)));
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Warning)));
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Error)));
        }

        /// <summary>
        ///     Tests that conditional log filter message contains predicate should apply
        /// </summary>
        [Fact]
        public void ConditionalLogFilter_MessageContainsPredicate_ShouldApply()
        {
            ConditionalLogFilter filter = new ConditionalLogFilter(e => e.Message.Contains("Error"));

            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Info, "Error occurred")));
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Info, "Normal message")));
        }

        /// <summary>
        ///     Tests that conditional log filter logger name predicate should apply
        /// </summary>
        [Fact]
        public void ConditionalLogFilter_LoggerNamePredicate_ShouldApply()
        {
            ConditionalLogFilter filter = new ConditionalLogFilter(e => e.LoggerName.StartsWith("Engine"));

            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Info, "Test", "Engine.Core")));
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Info, "Test", "Audio.Mixer")));
        }

        /// <summary>
        ///     Tests that conditional log filter multiple conditions should apply
        /// </summary>
        [Fact]
        public void ConditionalLogFilter_MultipleConditions_ShouldApply()
        {
            ConditionalLogFilter filter = new ConditionalLogFilter(e =>
                (e.Level >= LogLevel.Warning) &&
                e.Message.Contains("Critical")
            );

            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Error, "Critical error")));
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Error, "Normal error")));
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Info, "Critical info")));
        }

        /// <summary>
        ///     Tests that conditional log filter exception check predicate should apply
        /// </summary>
        [Fact]
        public void ConditionalLogFilter_ExceptionCheckPredicate_ShouldApply()
        {
            ConditionalLogFilter filter = new ConditionalLogFilter(e => e.Exception != null);

            LogEntry entryWithException = new LogEntry(LogLevel.Error, "Error", "Logger", new InvalidOperationException());
            LogEntry entryWithoutException = new LogEntry(LogLevel.Error, "Error", "Logger");

            Assert.True(filter.ShouldLog(entryWithException));
            Assert.False(filter.ShouldLog(entryWithoutException));
        }

        /// <summary>
        ///     Tests that conditional log filter correlation id predicate should apply
        /// </summary>
        [Fact]
        public void ConditionalLogFilter_CorrelationIdPredicate_ShouldApply()
        {
            ConditionalLogFilter filter = new ConditionalLogFilter(e => !string.IsNullOrEmpty(e.CorrelationId));

            LogEntry entryWithCorrelation = new LogEntry(LogLevel.Info, "Test", "Logger", correlationId: "CORR-123");
            LogEntry entryWithoutCorrelation = new LogEntry(LogLevel.Info, "Test", "Logger");

            Assert.True(filter.ShouldLog(entryWithCorrelation));
            Assert.False(filter.ShouldLog(entryWithoutCorrelation));
        }

        /// <summary>
        ///     Tests that conditional log filter predicate throws exception should return true
        /// </summary>
        /// <exception cref="InvalidOperationException">Test error</exception>
        [Fact]
        public void ConditionalLogFilter_PredicateThrowsException_ShouldReturnTrue()
        {
            ConditionalLogFilter filter = new ConditionalLogFilter(e => throw new InvalidOperationException("Test error"));

            ILogEntry entry = CreateEntry(LogLevel.Info);
            Assert.True(filter.ShouldLog(entry));
        }

        /// <summary>
        ///     Tests that conditional log filter null entry should be passed to predicate
        /// </summary>
        [Fact]
        public void ConditionalLogFilter_NullEntry_ShouldBePassedToPredicate()
        {
            bool predicateCalled = false;
            ConditionalLogFilter filter = new ConditionalLogFilter(e =>
            {
                predicateCalled = true;
                return e != null;
            });

            bool result = filter.ShouldLog(null);

            Assert.True(predicateCalled);
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that conditional log filter custom name should use provided name
        /// </summary>
        [Fact]
        public void ConditionalLogFilter_CustomName_ShouldUseProvidedName()
        {
            ConditionalLogFilter filter = new ConditionalLogFilter(e => true, "MyCustomFilter");

            Assert.Equal("MyCustomFilter", filter.Name);
        }

        /// <summary>
        ///     Tests that conditional log filter default name should be conditional filter
        /// </summary>
        [Fact]
        public void ConditionalLogFilter_DefaultName_ShouldBeConditionalFilter()
        {
            ConditionalLogFilter filter = new ConditionalLogFilter(e => true);

            Assert.Equal("ConditionalFilter", filter.Name);
        }

        /// <summary>
        ///     Tests that conditional log filter scope count predicate should apply
        /// </summary>
        [Fact]
        public void ConditionalLogFilter_ScopeCountPredicate_ShouldApply()
        {
            ConditionalLogFilter filter = new ConditionalLogFilter(e => e.Scopes.Count > 0);

            LogEntry entryWithScopes = new LogEntry(LogLevel.Info, "Test", "Logger", scopes: new[] {"Scope"});
            LogEntry entryWithoutScopes = new LogEntry(LogLevel.Info, "Test", "Logger");

            Assert.True(filter.ShouldLog(entryWithScopes));
            Assert.False(filter.ShouldLog(entryWithoutScopes));
        }

        /// <summary>
        ///     Tests that conditional log filter property count predicate should apply
        /// </summary>
        [Fact]
        public void ConditionalLogFilter_PropertyCountPredicate_ShouldApply()
        {
            ConditionalLogFilter filter = new ConditionalLogFilter(e => e.Properties.Count >= 2);

            LogEntry entryWithProperties = new LogEntry(LogLevel.Info, "Test", "Logger",
                properties: new Dictionary<string, object> {{"key1", "value1"}, {"key2", "value2"}});
            LogEntry entryWithOneProperty = new LogEntry(LogLevel.Info, "Test", "Logger",
                properties: new Dictionary<string, object> {{"key", "value"}});

            Assert.True(filter.ShouldLog(entryWithProperties));
            Assert.False(filter.ShouldLog(entryWithOneProperty));
        }

        /// <summary>
        ///     Tests that conditional log filter thread id predicate should apply
        /// </summary>
        [Fact]
        public void ConditionalLogFilter_ThreadIdPredicate_ShouldApply()
        {
            int currentThreadId = Thread.CurrentThread.ManagedThreadId;
            ConditionalLogFilter filter = new ConditionalLogFilter(e => e.ThreadId == currentThreadId);

            ILogEntry entry = CreateEntry(LogLevel.Info);
            Assert.True(filter.ShouldLog(entry));
        }

        /// <summary>
        ///     Tests that conditional log filter complex logic with all properties should apply
        /// </summary>
        [Fact]
        public void ConditionalLogFilter_ComplexLogicWithAllProperties_ShouldApply()
        {
            ConditionalLogFilter filter = new ConditionalLogFilter(e =>
                (e.Level >= LogLevel.Error) &&
                !string.IsNullOrEmpty(e.CorrelationId) &&
                (e.Message.Length > 5)
            );

            LogEntry validEntry = new LogEntry(LogLevel.Error, "Long error message", "Logger", correlationId: "CORR-123");
            LogEntry invalidEntry1 = new LogEntry(LogLevel.Info, "Long error message", "Logger", correlationId: "CORR-123");
            LogEntry invalidEntry2 = new LogEntry(LogLevel.Error, "Long error message", "Logger");
            LogEntry invalidEntry3 = new LogEntry(LogLevel.Error, "Short", "Logger", correlationId: "CORR-123");

            Assert.True(filter.ShouldLog(validEntry));
            Assert.False(filter.ShouldLog(invalidEntry1));
            Assert.False(filter.ShouldLog(invalidEntry2));
            Assert.False(filter.ShouldLog(invalidEntry3));
        }

        /// <summary>
        ///     Creates the entry using the specified level
        /// </summary>
        /// <param name="level">The level</param>
        /// <param name="message">The message</param>
        /// <param name="loggerName">The logger name</param>
        /// <returns>The log entry</returns>
        private static ILogEntry CreateEntry(LogLevel level, string message = "Test", string loggerName = "Logger") => new LogEntry(level, message, loggerName);
    }
}