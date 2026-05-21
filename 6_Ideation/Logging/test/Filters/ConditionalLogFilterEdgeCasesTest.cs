

using System;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Filters;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test.Filters
{
    /// <summary>
    ///     Edge case tests for ConditionalLogFilter.
    ///     Tests exception handling, stateful predicates, and special scenarios.
    /// </summary>
    public class ConditionalLogFilterEdgeCasesTest
    {
        /// <summary>
        ///     Tests that conditional log filter predicate throwing multiple times should always return true
        /// </summary>
        /// <exception cref="InvalidOperationException">Always fails</exception>
        [Fact]
        public void ConditionalLogFilter_PredicateThrowingMultipleTimes_ShouldAlwaysReturnTrue()
        {
            int callCount = 0;
            ConditionalLogFilter filter = new ConditionalLogFilter(e =>
            {
                callCount++;
                throw new InvalidOperationException("Always fails");
            });

            ILogEntry entry = CreateEntry(LogLevel.Info);

            for (int i = 0; i < 5; i++)
            {
                Assert.True(filter.ShouldLog(entry));
                Assert.Equal(i + 1, callCount);
            }
        }

        /// <summary>
        ///     Tests that conditional log filter stateful predicate should maintain state
        /// </summary>
        [Fact]
        public void ConditionalLogFilter_StatefulPredicate_ShouldMaintainState()
        {
            int callCount = 0;
            ConditionalLogFilter filter = new ConditionalLogFilter(e =>
            {
                callCount++;
                return callCount % 2 == 1; // Only pass on odd calls
            });

            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Info))); // Call 1 - odd
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Info))); // Call 2 - even
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Info))); // Call 3 - odd
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Info))); // Call 4 - even
        }

        /// <summary>
        ///     Tests that conditional log filter complex logic with message length
        /// </summary>
        [Fact]
        public void ConditionalLogFilter_ComplexLogic_WithMessageLength()
        {
            ConditionalLogFilter filter = new ConditionalLogFilter(e => e.Message.Length > 10);

            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Info, "Short")));
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Info, "This is a longer message")));
        }

        /// <summary>
        ///     Tests that conditional log filter regex like matching
        /// </summary>
        [Fact]
        public void ConditionalLogFilter_RegexLikeMatching()
        {
            ConditionalLogFilter filter = new ConditionalLogFilter(e =>
                e.Message.Contains("ERROR") && (e.Level >= LogLevel.Error)
            );

            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Error, "ERROR occurred")));
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Error, "Warning occurred")));
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Info, "ERROR occurred")));
        }

        /// <summary>
        ///     Tests that conditional log filter custom name preservation
        /// </summary>
        [Fact]
        public void ConditionalLogFilter_CustomNamePreservation()
        {
            string[] customNames = new[] {"Filter1", "Filter2", "MyCustomFilter"};

            foreach (string name in customNames)
            {
                ConditionalLogFilter filter = new ConditionalLogFilter(e => true, name);
                Assert.Equal(name, filter.Name);
            }
        }

        /// <summary>
        ///     Tests that conditional log filter always pass predicate
        /// </summary>
        [Fact]
        public void ConditionalLogFilter_AlwaysPassPredicate()
        {
            ConditionalLogFilter filter = new ConditionalLogFilter(e => true);

            for (int i = 0; i < 100; i++)
            {
                Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Trace)));
            }
        }

        /// <summary>
        ///     Tests that conditional log filter never pass predicate
        /// </summary>
        [Fact]
        public void ConditionalLogFilter_NeverPassPredicate()
        {
            ConditionalLogFilter filter = new ConditionalLogFilter(e => false);

            for (int i = 0; i < 100; i++)
            {
                Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Critical)));
            }
        }

        /// <summary>
        ///     Tests that conditional log filter performance with complex logic
        /// </summary>
        [Fact]
        public void ConditionalLogFilter_PerformanceWithComplexLogic()
        {
            ConditionalLogFilter filter = new ConditionalLogFilter(e =>
                (e.Level >= LogLevel.Warning) &&
                (e.Message.Length > 5) &&
                !e.LoggerName.StartsWith("Internal") &&
                (e.Exception == null)
            );

            ILogEntry validEntry = CreateEntry(LogLevel.Error, "Long message");
            DateTime startTime = DateTime.UtcNow;

            for (int i = 0; i < 10000; i++)
            {
                filter.ShouldLog(validEntry);
            }

            TimeSpan elapsed = DateTime.UtcNow - startTime;

            Assert.True(elapsed.TotalSeconds < 1);
        }

        /// <summary>
        ///     Creates the entry using the specified level
        /// </summary>
        /// <param name="level">The level</param>
        /// <param name="message">The message</param>
        /// <returns>The log entry</returns>
        private static ILogEntry CreateEntry(LogLevel level, string message = "Test") => new LogEntry(level, message, "Logger");
    }
}