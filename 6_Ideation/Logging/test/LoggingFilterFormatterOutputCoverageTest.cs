using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Filters;
using Alis.Core.Aspect.Logging.Formatters;
using Alis.Core.Aspect.Logging.Outputs;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Coverage-driven tests for all 0%-covered Logging module files:
    ///     LogLevelFilter, LoggerNameFilter, CompositeLogFilter, ConditionalLogFilter,
    ///     SamplingLogFilter, CompactLogFormatter, JsonLogFormatter, MemoryLogOutput,
    ///     DebugLogOutput, AsyncLogOutput, FileLogOutput, LoggerScope.
    /// </summary>
    public class LoggingFilterFormatterOutputCoverageTest
    {
        /// <summary>
        /// Creates the entry using the specified level
        /// </summary>
        /// <param name="level">The level</param>
        /// <param name="message">The message</param>
        /// <param name="loggerName">The logger name</param>
        /// <param name="exception">The exception</param>
        /// <param name="correlationId">The correlation id</param>
        /// <param name="properties">The properties</param>
        /// <param name="scopes">The scopes</param>
        /// <returns>The log entry</returns>
        private static LogEntry CreateEntry(
            LogLevel level = LogLevel.Info,
            string message = "test",
            string loggerName = "Test.Logger",
            Exception exception = null,
            string correlationId = null,
            IReadOnlyDictionary<string, object> properties = null,
            IReadOnlyList<object> scopes = null)
        {
            return new LogEntry(level, message, loggerName, exception, correlationId, properties, scopes);
        }

        // ============================================================
        // LogLevelFilter
        // ============================================================

        /// <summary>
        /// Tests that log level filter should log entry above min level
        /// </summary>
        [Fact]
        public void LogLevelFilter_ShouldLog_EntryAboveMinLevel()
        {
            LogLevelFilter filter = new LogLevelFilter(LogLevel.Warning);
            LogEntry entry = CreateEntry(LogLevel.Error);

            Assert.True(filter.ShouldLog(entry));
        }

        /// <summary>
        /// Tests that log level filter should log entry at min level
        /// </summary>
        [Fact]
        public void LogLevelFilter_ShouldLog_EntryAtMinLevel()
        {
            LogLevelFilter filter = new LogLevelFilter(LogLevel.Warning);
            LogEntry entry = CreateEntry(LogLevel.Warning);

            Assert.True(filter.ShouldLog(entry));
        }

        /// <summary>
        /// Tests that log level filter should not log entry below min level
        /// </summary>
        [Fact]
        public void LogLevelFilter_ShouldNotLog_EntryBelowMinLevel()
        {
            LogLevelFilter filter = new LogLevelFilter(LogLevel.Warning);
            LogEntry entry = CreateEntry(LogLevel.Info);

            Assert.False(filter.ShouldLog(entry));
        }

        /// <summary>
        /// Tests that log level filter should not log null entry
        /// </summary>
        [Fact]
        public void LogLevelFilter_ShouldNotLog_NullEntry()
        {
            LogLevelFilter filter = new LogLevelFilter(LogLevel.Trace);

            Assert.False(filter.ShouldLog(null));
        }

        /// <summary>
        /// Tests that log level filter name contains level
        /// </summary>
        [Fact]
        public void LogLevelFilter_Name_ContainsLevel()
        {
            LogLevelFilter filter = new LogLevelFilter(LogLevel.Error);

            Assert.Contains("Error", filter.Name);
        }

        // ============================================================
        // LoggerNameFilter
        // ============================================================

        /// <summary>
        /// Tests that logger name filter inclusive should log matching name
        /// </summary>
        [Fact]
        public void LoggerNameFilter_Inclusive_ShouldLog_MatchingName()
        {
            LoggerNameFilter filter = new LoggerNameFilter(new[] { "App.Service" }, inclusive: true);
            LogEntry entry = CreateEntry(loggerName: "App.Service");

            Assert.True(filter.ShouldLog(entry));
        }

        /// <summary>
        /// Tests that logger name filter inclusive should not log non matching name
        /// </summary>
        [Fact]
        public void LoggerNameFilter_Inclusive_ShouldNotLog_NonMatchingName()
        {
            LoggerNameFilter filter = new LoggerNameFilter(new[] { "App.Service" }, inclusive: true);
            LogEntry entry = CreateEntry(loggerName: "Other.Logger");

            Assert.False(filter.ShouldLog(entry));
        }

        /// <summary>
        /// Tests that logger name filter exclusive should not log matching name
        /// </summary>
        [Fact]
        public void LoggerNameFilter_Exclusive_ShouldNotLog_MatchingName()
        {
            LoggerNameFilter filter = new LoggerNameFilter(new[] { "App.Service" }, inclusive: false);
            LogEntry entry = CreateEntry(loggerName: "App.Service");

            Assert.False(filter.ShouldLog(entry));
        }

        /// <summary>
        /// Tests that logger name filter exclusive should log non matching name
        /// </summary>
        [Fact]
        public void LoggerNameFilter_Exclusive_ShouldLog_NonMatchingName()
        {
            LoggerNameFilter filter = new LoggerNameFilter(new[] { "App.Service" }, inclusive: false);
            LogEntry entry = CreateEntry(loggerName: "Other.Logger");

            Assert.True(filter.ShouldLog(entry));
        }

        /// <summary>
        /// Tests that logger name filter null entry returns true
        /// </summary>
        [Fact]
        public void LoggerNameFilter_NullEntry_ReturnsTrue()
        {
            LoggerNameFilter filter = new LoggerNameFilter(new[] { "App.Service" });

            Assert.True(filter.ShouldLog(null));
        }

        /// <summary>
        /// Tests that logger name filter empty names returns true
        /// </summary>
        [Fact]
        public void LoggerNameFilter_EmptyNames_ReturnsTrue()
        {
            LoggerNameFilter filter = new LoggerNameFilter(new List<string>());
            LogEntry entry = CreateEntry();

            Assert.True(filter.ShouldLog(entry));
        }

        /// <summary>
        /// Tests that logger name filter null names returns true
        /// </summary>
        [Fact]
        public void LoggerNameFilter_NullNames_ReturnsTrue()
        {
            LoggerNameFilter filter = new LoggerNameFilter(null);
            LogEntry entry = CreateEntry();

            Assert.True(filter.ShouldLog(entry));
        }

        /// <summary>
        /// Tests that logger name filter name inclusive contains count
        /// </summary>
        [Fact]
        public void LoggerNameFilter_Name_Inclusive_ContainsCount()
        {
            LoggerNameFilter filter = new LoggerNameFilter(new[] { "A", "B" }, inclusive: true);

            Assert.Contains("Include", filter.Name);
            Assert.Contains("2", filter.Name);
        }

        /// <summary>
        /// Tests that logger name filter name exclusive contains exclude
        /// </summary>
        [Fact]
        public void LoggerNameFilter_Name_Exclusive_ContainsExclude()
        {
            LoggerNameFilter filter = new LoggerNameFilter(new[] { "A" }, inclusive: false);

            Assert.Contains("Exclude", filter.Name);
        }

        // ============================================================
        // CompositeLogFilter
        // ============================================================

        /// <summary>
        /// Tests that composite log filter and all pass returns true
        /// </summary>
        [Fact]
        public void CompositeLogFilter_And_AllPass_ReturnsTrue()
        {
            CompositeLogFilter filter = new CompositeLogFilter(
                new ILogFilter[]
                {
                    new LogLevelFilter(LogLevel.Trace),
                    new LoggerNameFilter(new[] { "Test" })
                },
                requireAll: true);

            LogEntry entry = CreateEntry(LogLevel.Warning, loggerName: "Test");
            Assert.True(filter.ShouldLog(entry));
        }

        /// <summary>
        /// Tests that composite log filter and one fails returns false
        /// </summary>
        [Fact]
        public void CompositeLogFilter_And_OneFails_ReturnsFalse()
        {
            CompositeLogFilter filter = new CompositeLogFilter(
                new ILogFilter[]
                {
                    new LogLevelFilter(LogLevel.Warning),
                    new LoggerNameFilter(new[] { "Test" })
                },
                requireAll: true);

            LogEntry entry = CreateEntry(LogLevel.Info, loggerName: "Test");
            Assert.False(filter.ShouldLog(entry));
        }

        /// <summary>
        /// Tests that composite log filter or one pass returns true
        /// </summary>
        [Fact]
        public void CompositeLogFilter_Or_OnePass_ReturnsTrue()
        {
            CompositeLogFilter filter = new CompositeLogFilter(
                new ILogFilter[]
                {
                    new LogLevelFilter(LogLevel.Critical),
                    new LoggerNameFilter(new[] { "Test" })
                },
                requireAll: false);

            LogEntry entry = CreateEntry(LogLevel.Info, loggerName: "Test");
            Assert.True(filter.ShouldLog(entry));
        }

        /// <summary>
        /// Tests that composite log filter or none pass returns false
        /// </summary>
        [Fact]
        public void CompositeLogFilter_Or_NonePass_ReturnsFalse()
        {
            CompositeLogFilter filter = new CompositeLogFilter(
                new ILogFilter[]
                {
                    new LogLevelFilter(LogLevel.Critical),
                    new LoggerNameFilter(new[] { "Other" })
                },
                requireAll: false);

            LogEntry entry = CreateEntry(LogLevel.Info, loggerName: "Test");
            Assert.False(filter.ShouldLog(entry));
        }

        /// <summary>
        /// Tests that composite log filter null entry returns true
        /// </summary>
        [Fact]
        public void CompositeLogFilter_NullEntry_ReturnsTrue()
        {
            CompositeLogFilter filter = new CompositeLogFilter(
                new ILogFilter[] { new LogLevelFilter(LogLevel.Warning) },
                requireAll: true);

            Assert.True(filter.ShouldLog(null));
        }

        /// <summary>
        /// Tests that composite log filter empty filters returns true
        /// </summary>
        [Fact]
        public void CompositeLogFilter_EmptyFilters_ReturnsTrue()
        {
            CompositeLogFilter filter = new CompositeLogFilter(new List<ILogFilter>());
            LogEntry entry = CreateEntry();

            Assert.True(filter.ShouldLog(entry));
        }

        /// <summary>
        /// Tests that composite log filter null filters returns true
        /// </summary>
        [Fact]
        public void CompositeLogFilter_NullFilters_ReturnsTrue()
        {
            CompositeLogFilter filter = new CompositeLogFilter(null);
            LogEntry entry = CreateEntry();

            Assert.True(filter.ShouldLog(entry));
        }

        /// <summary>
        /// Tests that composite log filter name and
        /// </summary>
        [Fact]
        public void CompositeLogFilter_Name_And()
        {
            CompositeLogFilter filter = new CompositeLogFilter(new ILogFilter[] { new LogLevelFilter(LogLevel.Trace) }, requireAll: true);
            Assert.Contains("AND", filter.Name);
        }

        /// <summary>
        /// Tests that composite log filter name or
        /// </summary>
        [Fact]
        public void CompositeLogFilter_Name_Or()
        {
            CompositeLogFilter filter = new CompositeLogFilter(new ILogFilter[] { new LogLevelFilter(LogLevel.Trace) }, requireAll: false);
            Assert.Contains("OR", filter.Name);
        }

        // ============================================================
        // ConditionalLogFilter
        // ============================================================

        /// <summary>
        /// Tests that conditional log filter predicate true returns true
        /// </summary>
        [Fact]
        public void ConditionalLogFilter_PredicateTrue_ReturnsTrue()
        {
            ConditionalLogFilter filter = new ConditionalLogFilter(e => e.Level == LogLevel.Error);
            LogEntry entry = CreateEntry(LogLevel.Error);

            Assert.True(filter.ShouldLog(entry));
        }

        /// <summary>
        /// Tests that conditional log filter predicate false returns false
        /// </summary>
        [Fact]
        public void ConditionalLogFilter_PredicateFalse_ReturnsFalse()
        {
            ConditionalLogFilter filter = new ConditionalLogFilter(e => e.Level == LogLevel.Error);
            LogEntry entry = CreateEntry(LogLevel.Info);

            Assert.False(filter.ShouldLog(entry));
        }

        /// <summary>
        /// Tests that conditional log filter exception in predicate returns true
        /// </summary>
        /// <exception cref="InvalidOperationException">boom</exception>
        [Fact]
        public void ConditionalLogFilter_ExceptionInPredicate_ReturnsTrue()
        {
            ConditionalLogFilter filter = new ConditionalLogFilter(e =>
            {
                throw new InvalidOperationException("boom");
            });
            LogEntry entry = CreateEntry();

            Assert.True(filter.ShouldLog(entry));
        }

        /// <summary>
        /// Tests that conditional log filter null predicate throws
        /// </summary>
        [Fact]
        public void ConditionalLogFilter_NullPredicate_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new ConditionalLogFilter(null));
        }

        /// <summary>
        /// Tests that conditional log filter name default
        /// </summary>
        [Fact]
        public void ConditionalLogFilter_Name_Default()
        {
            ConditionalLogFilter filter = new ConditionalLogFilter(e => true);
            Assert.Equal("ConditionalFilter", filter.Name);
        }

        /// <summary>
        /// Tests that conditional log filter name custom
        /// </summary>
        [Fact]
        public void ConditionalLogFilter_Name_Custom()
        {
            ConditionalLogFilter filter = new ConditionalLogFilter(e => true, "MyFilter");
            Assert.Equal("MyFilter", filter.Name);
        }

        // ============================================================
        // SamplingLogFilter
        // ============================================================

        /// <summary>
        /// Tests that sampling log filter rate 1 every entry passes
        /// </summary>
        [Fact]
        public void SamplingLogFilter_Rate1_EveryEntryPasses()
        {
            SamplingLogFilter filter = new SamplingLogFilter(sampleRate: 1);
            for (int i = 0; i < 10; i++)
            {
                Assert.True(filter.ShouldLog(CreateEntry()));
            }
        }

        /// <summary>
        /// Tests that sampling log filter rate 3 passes every third
        /// </summary>
        [Fact]
        public void SamplingLogFilter_Rate3_PassesEveryThird()
        {
            SamplingLogFilter filter = new SamplingLogFilter(sampleRate: 3);
            Assert.False(filter.ShouldLog(CreateEntry())); // counter=1
            Assert.False(filter.ShouldLog(CreateEntry())); // counter=2
            Assert.True(filter.ShouldLog(CreateEntry()));  // counter=3
            Assert.False(filter.ShouldLog(CreateEntry())); // counter=4
            Assert.False(filter.ShouldLog(CreateEntry())); // counter=5
            Assert.True(filter.ShouldLog(CreateEntry()));  // counter=6
        }

        /// <summary>
        /// Tests that sampling log filter null entry returns false
        /// </summary>
        [Fact]
        public void SamplingLogFilter_NullEntry_ReturnsFalse()
        {
            SamplingLogFilter filter = new SamplingLogFilter(sampleRate: 5);

            Assert.False(filter.ShouldLog(null));
        }

        /// <summary>
        /// Tests that sampling log filter rate less than 1 throws
        /// </summary>
        [Fact]
        public void SamplingLogFilter_RateLessThan1_Throws()
        {
            Assert.Throws<ArgumentException>(() => new SamplingLogFilter(sampleRate: 0));
        }

        /// <summary>
        /// Tests that sampling log filter name contains rate
        /// </summary>
        [Fact]
        public void SamplingLogFilter_Name_ContainsRate()
        {
            SamplingLogFilter filter = new SamplingLogFilter(sampleRate: 7);
            Assert.Contains("7", filter.Name);
        }

        /// <summary>
        /// Tests that sampling log filter default rate
        /// </summary>
        [Fact]
        public void SamplingLogFilter_DefaultRate()
        {
            SamplingLogFilter filter = new SamplingLogFilter();
            Assert.Contains("10", filter.Name);
        }

        // ============================================================
        // CompactLogFormatter
        // ============================================================

        /// <summary>
        /// Tests that compact log formatter format info level
        /// </summary>
        [Fact]
        public void CompactLogFormatter_Format_InfoLevel()
        {
            CompactLogFormatter formatter = new CompactLogFormatter();
            LogEntry entry = CreateEntry(LogLevel.Info, "Hello");

            string result = formatter.Format(entry);

            Assert.Equal("[I] Hello", result);
        }

        /// <summary>
        /// Tests that compact log formatter level prefix
        /// </summary>
        /// <param name="level">The level</param>
        /// <param name="expectedPrefix">The expected prefix</param>
        [Theory]
        [InlineData(LogLevel.Trace, "T")]
        [InlineData(LogLevel.Debug, "D")]
        [InlineData(LogLevel.Info, "I")]
        [InlineData(LogLevel.Warning, "W")]
        [InlineData(LogLevel.Error, "E")]
        [InlineData(LogLevel.Critical, "C")]
        public void CompactLogFormatter_LevelPrefix(LogLevel level, string expectedPrefix)
        {
            CompactLogFormatter formatter = new CompactLogFormatter();
            LogEntry entry = CreateEntry(level, "msg");

            string result = formatter.Format(entry);

            Assert.StartsWith($"[{expectedPrefix}]", result);
        }

        /// <summary>
        /// Tests that compact log formatter with exception
        /// </summary>
        [Fact]
        public void CompactLogFormatter_WithException()
        {
            CompactLogFormatter formatter = new CompactLogFormatter();
            LogEntry entry = CreateEntry(LogLevel.Error, "fail", exception: new Exception("bad"));

            string result = formatter.Format(entry);

            Assert.Contains("[EXC: bad]", result);
        }

        /// <summary>
        /// Tests that compact log formatter without exception
        /// </summary>
        [Fact]
        public void CompactLogFormatter_WithoutException()
        {
            CompactLogFormatter formatter = new CompactLogFormatter();
            LogEntry entry = CreateEntry(LogLevel.Info, "ok");

            string result = formatter.Format(entry);

            Assert.DoesNotContain("[EXC:", result);
        }

        /// <summary>
        /// Tests that compact log formatter unknown level
        /// </summary>
        [Fact]
        public void CompactLogFormatter_UnknownLevel()
        {
            CompactLogFormatter formatter = new CompactLogFormatter();
            LogEntry entry = CreateEntry((LogLevel)99, "msg");

            string result = formatter.Format(entry);

            Assert.StartsWith("[?]", result);
        }

        /// <summary>
        /// Tests that compact log formatter name
        /// </summary>
        [Fact]
        public void CompactLogFormatter_Name()
        {
            CompactLogFormatter formatter = new CompactLogFormatter();
            Assert.Equal("CompactFormatter", formatter.Name);
        }

        // ============================================================
        // JsonLogFormatter
        // ============================================================

        /// <summary>
        /// Tests that json log formatter format contains level and message
        /// </summary>
        [Fact]
        public void JsonLogFormatter_Format_ContainsLevelAndMessage()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = CreateEntry(LogLevel.Warning, "something happened");

            string result = formatter.Format(entry);

            Assert.Contains("\"level\":\"Warning\"", result);
            Assert.Contains("\"message\":\"something happened\"", result);
        }

        /// <summary>
        /// Tests that json log formatter format contains logger name
        /// </summary>
        [Fact]
        public void JsonLogFormatter_Format_ContainsLoggerName()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = CreateEntry(loggerName: "MyApp");

            string result = formatter.Format(entry);

            Assert.Contains("\"logger\":\"MyApp\"", result);
        }

        /// <summary>
        /// Tests that json log formatter format contains thread id
        /// </summary>
        [Fact]
        public void JsonLogFormatter_Format_ContainsThreadId()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = CreateEntry();

            string result = formatter.Format(entry);

            Assert.Contains($"\"threadId\":{Thread.CurrentThread.ManagedThreadId}", result);
        }

        /// <summary>
        /// Tests that json log formatter with correlation id
        /// </summary>
        [Fact]
        public void JsonLogFormatter_WithCorrelationId()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = CreateEntry(correlationId: "abc-123");

            string result = formatter.Format(entry);

            Assert.Contains("\"correlationId\":\"abc-123\"", result);
        }

        /// <summary>
        /// Tests that json log formatter without correlation id
        /// </summary>
        [Fact]
        public void JsonLogFormatter_WithoutCorrelationId()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = CreateEntry(correlationId: null);

            string result = formatter.Format(entry);

            Assert.DoesNotContain("correlationId", result);
        }

        /// <summary>
        /// Tests that json log formatter with properties
        /// </summary>
        [Fact]
        public void JsonLogFormatter_WithProperties()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            Dictionary<string, object> props = new Dictionary<string, object> { { "key1", "value1" } };
            LogEntry entry = CreateEntry(properties: props);

            string result = formatter.Format(entry);

            Assert.Contains("\"properties\":{", result);
            Assert.Contains("\"key1\":\"value1\"", result);
        }

        /// <summary>
        /// Tests that json log formatter without properties
        /// </summary>
        [Fact]
        public void JsonLogFormatter_WithoutProperties()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = CreateEntry();

            string result = formatter.Format(entry);

            Assert.DoesNotContain("properties", result);
        }

        /// <summary>
        /// Tests that json log formatter with scopes
        /// </summary>
        [Fact]
        public void JsonLogFormatter_WithScopes()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            List<object> scopes = new List<object> { "scope1", "scope2" };
            LogEntry entry = CreateEntry(scopes: scopes);

            string result = formatter.Format(entry);

            Assert.Contains("\"scopes\":[", result);
        }

        /// <summary>
        /// Tests that json log formatter with exception
        /// </summary>
        [Fact]
        public void JsonLogFormatter_WithException()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = CreateEntry(exception: new InvalidOperationException("test err"));

            string result = formatter.Format(entry);

            Assert.Contains("\"exception\":{", result);
            Assert.Contains("InvalidOperationException", result);
            Assert.Contains("test err", result);
        }

        /// <summary>
        /// Tests that json log formatter escape special chars
        /// </summary>
        [Fact]
        public void JsonLogFormatter_EscapeSpecialChars()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = CreateEntry(message: "line1\nline2\ttab\"quote\\back");

            string result = formatter.Format(entry);

            Assert.Contains("\\n", result);
            Assert.Contains("\\t", result);
            Assert.Contains("\\\"", result);
            Assert.Contains("\\\\", result);
        }

        /// <summary>
        /// Tests that json log formatter name
        /// </summary>
        [Fact]
        public void JsonLogFormatter_Name()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            Assert.Equal("JsonFormatter", formatter.Name);
        }

        // ============================================================
        // MemoryLogOutput
        // ============================================================

        /// <summary>
        /// Tests that memory log output write stores entry
        /// </summary>
        [Fact]
        public void MemoryLogOutput_Write_StoresEntry()
        {
            MemoryLogOutput output = new MemoryLogOutput();
            LogEntry entry = CreateEntry();

            output.Write(entry);

            Assert.Equal(1, output.Count);
            Assert.Single(output.GetEntries());
        }

        /// <summary>
        /// Tests that memory log output write null entry does not store
        /// </summary>
        [Fact]
        public void MemoryLogOutput_Write_NullEntry_DoesNotStore()
        {
            MemoryLogOutput output = new MemoryLogOutput();

            output.Write(null);

            Assert.Equal(0, output.Count);
        }

        /// <summary>
        /// Tests that memory log output max entries removes oldest
        /// </summary>
        [Fact]
        public void MemoryLogOutput_MaxEntries_RemovesOldest()
        {
            MemoryLogOutput output = new MemoryLogOutput(maxEntries: 3);

            output.Write(CreateEntry(message: "1"));
            output.Write(CreateEntry(message: "2"));
            output.Write(CreateEntry(message: "3"));
            output.Write(CreateEntry(message: "4"));

            Assert.Equal(3, output.Count);
            IReadOnlyList<ILogEntry> entries = output.GetEntries();
            Assert.Equal("2", entries[0].Message);
            Assert.Equal("4", entries[2].Message);
        }

        /// <summary>
        /// Tests that memory log output max entries zero or negative unlimited
        /// </summary>
        [Fact]
        public void MemoryLogOutput_MaxEntries_ZeroOrNegative_Unlimited()
        {
            MemoryLogOutput output = new MemoryLogOutput(maxEntries: 0);

            for (int i = 0; i < 100; i++)
            {
                output.Write(CreateEntry());
            }

            Assert.Equal(100, output.Count);
        }

        /// <summary>
        /// Tests that memory log output flush no op
        /// </summary>
        [Fact]
        public void MemoryLogOutput_Flush_NoOp()
        {
            MemoryLogOutput output = new MemoryLogOutput();
            output.Write(CreateEntry());

            Exception ex = Record.Exception(() => output.Flush());

            Assert.Null(ex);
            Assert.Equal(1, output.Count);
        }

        /// <summary>
        /// Tests that memory log output dispose clears entries
        /// </summary>
        [Fact]
        public void MemoryLogOutput_Dispose_ClearsEntries()
        {
            MemoryLogOutput output = new MemoryLogOutput();
            output.Write(CreateEntry());

            output.Dispose();

            Assert.Equal(0, output.Count);
        }

        /// <summary>
        /// Tests that memory log output dispose called twice no error
        /// </summary>
        [Fact]
        public void MemoryLogOutput_Dispose_CalledTwice_NoError()
        {
            MemoryLogOutput output = new MemoryLogOutput();
            output.Write(CreateEntry());

            output.Dispose();
            Exception ex = Record.Exception(() => output.Dispose());

            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that memory log output write after dispose ignored
        /// </summary>
        [Fact]
        public void MemoryLogOutput_Write_AfterDispose_Ignored()
        {
            MemoryLogOutput output = new MemoryLogOutput();
            output.Dispose();

            output.Write(CreateEntry());

            Assert.Equal(0, output.Count);
        }

        /// <summary>
        /// Tests that memory log output clear removes all
        /// </summary>
        [Fact]
        public void MemoryLogOutput_Clear_RemovesAll()
        {
            MemoryLogOutput output = new MemoryLogOutput();
            output.Write(CreateEntry());
            output.Write(CreateEntry());

            output.Clear();

            Assert.Equal(0, output.Count);
        }

        /// <summary>
        /// Tests that memory log output get entries returns snapshot
        /// </summary>
        [Fact]
        public void MemoryLogOutput_GetEntries_ReturnsSnapshot()
        {
            MemoryLogOutput output = new MemoryLogOutput();
            output.Write(CreateEntry(message: "a"));
            output.Write(CreateEntry(message: "b"));

            IReadOnlyList<ILogEntry> snapshot = output.GetEntries();
            output.Write(CreateEntry(message: "c"));

            Assert.Equal(2, snapshot.Count);
            Assert.Equal(3, output.Count);
        }

        /// <summary>
        /// Tests that memory log output name
        /// </summary>
        [Fact]
        public void MemoryLogOutput_Name()
        {
            MemoryLogOutput output = new MemoryLogOutput();
            Assert.Equal("MemoryOutput", output.Name);
        }

        /// <summary>
        /// Tests that memory log output is enabled default
        /// </summary>
        [Fact]
        public void MemoryLogOutput_IsEnabled_Default()
        {
            MemoryLogOutput output = new MemoryLogOutput();
            Assert.True(output.IsEnabled);
        }

        // ============================================================
        // DebugLogOutput
        // ============================================================

        /// <summary>
        /// Tests that debug log output write no debugger does not throw
        /// </summary>
        [Fact]
        public void DebugLogOutput_Write_NoDebugger_DoesNotThrow()
        {
            DebugLogOutput output = new DebugLogOutput();
            LogEntry entry = CreateEntry();

            Exception ex = Record.Exception(() => output.Write(entry));

            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that debug log output write null entry does not throw
        /// </summary>
        [Fact]
        public void DebugLogOutput_Write_NullEntry_DoesNotThrow()
        {
            DebugLogOutput output = new DebugLogOutput();

            Exception ex = Record.Exception(() => output.Write(null));

            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that debug log output write after dispose does not throw
        /// </summary>
        [Fact]
        public void DebugLogOutput_Write_AfterDispose_DoesNotThrow()
        {
            DebugLogOutput output = new DebugLogOutput();
            output.Dispose();

            Exception ex = Record.Exception(() => output.Write(CreateEntry()));

            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that debug log output flush no op
        /// </summary>
        [Fact]
        public void DebugLogOutput_Flush_NoOp()
        {
            DebugLogOutput output = new DebugLogOutput();

            Exception ex = Record.Exception(() => output.Flush());

            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that debug log output dispose called twice no error
        /// </summary>
        [Fact]
        public void DebugLogOutput_Dispose_CalledTwice_NoError()
        {
            DebugLogOutput output = new DebugLogOutput();
            output.Dispose();
            Exception ex = Record.Exception(() => output.Dispose());
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that debug log output name
        /// </summary>
        [Fact]
        public void DebugLogOutput_Name()
        {
            DebugLogOutput output = new DebugLogOutput();
            Assert.Equal("DebugOutput", output.Name);
        }

        /// <summary>
        /// Tests that debug log output custom formatter
        /// </summary>
        [Fact]
        public void DebugLogOutput_CustomFormatter()
        {
            DebugLogOutput output = new DebugLogOutput(new CompactLogFormatter());
            Exception ex = Record.Exception(() => output.Write(CreateEntry()));
            Assert.Null(ex);
        }

        // ============================================================
        // AsyncLogOutput
        // ============================================================

        /// <summary>
        /// Tests that async log output write flush delivers to inner
        /// </summary>
        [Fact]
        public void AsyncLogOutput_Write_FlushDeliversToInner()
        {
            MemoryLogOutput inner = new MemoryLogOutput();
            AsyncLogOutput output = new AsyncLogOutput(inner);

            output.Write(CreateEntry());
            output.Flush();

            Assert.Equal(1, inner.Count);
        }

        /// <summary>
        /// Tests that async log output write null entry does not throw
        /// </summary>
        [Fact]
        public void AsyncLogOutput_Write_NullEntry_DoesNotThrow()
        {
            MemoryLogOutput inner = new MemoryLogOutput();
            AsyncLogOutput output = new AsyncLogOutput(inner);

            Exception ex = Record.Exception(() => output.Write(null));

            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that async log output write after dispose does not throw
        /// </summary>
        [Fact]
        public void AsyncLogOutput_Write_AfterDispose_DoesNotThrow()
        {
            MemoryLogOutput inner = new MemoryLogOutput();
            AsyncLogOutput output = new AsyncLogOutput(inner);
            output.Dispose();

            Exception ex = Record.Exception(() => output.Write(CreateEntry()));

            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that async log output write when disabled does not queue
        /// </summary>
        [Fact]
        public void AsyncLogOutput_Write_WhenDisabled_DoesNotQueue()
        {
            MemoryLogOutput inner = new MemoryLogOutput();
            AsyncLogOutput output = new AsyncLogOutput(inner);
            output.IsEnabled = false;

            output.Write(CreateEntry());

            Assert.Equal(0, inner.Count);
        }

        /// <summary>
        /// Tests that async log output max queue size drops oldest
        /// </summary>
        [Fact]
        public void AsyncLogOutput_MaxQueueSize_DropsOldest()
        {
            MemoryLogOutput inner = new MemoryLogOutput();
            AsyncLogOutput output = new AsyncLogOutput(inner, maxQueueSize: 3);

            output.Write(CreateEntry(message: "1"));
            output.Write(CreateEntry(message: "2"));
            output.Write(CreateEntry(message: "3"));
            output.Write(CreateEntry(message: "4"));

            output.Flush();

            Assert.Equal(3, inner.Count);
            IReadOnlyList<ILogEntry> entries = inner.GetEntries();
            Assert.Equal("2", entries[0].Message);
            Assert.Equal("4", entries[2].Message);
        }

        /// <summary>
        /// Tests that async log output max queue size zero or negative unlimited
        /// </summary>
        [Fact]
        public void AsyncLogOutput_MaxQueueSize_ZeroOrNegative_Unlimited()
        {
            MemoryLogOutput inner = new MemoryLogOutput();
            AsyncLogOutput output = new AsyncLogOutput(inner, maxQueueSize: 0);

            for (int i = 0; i < 100; i++)
            {
                output.Write(CreateEntry());
            }

            output.Flush();
            Assert.Equal(100, inner.Count);
        }

        /// <summary>
        /// Tests that async log output flush writes to inner
        /// </summary>
        [Fact]
        public void AsyncLogOutput_Flush_WritesToInner()
        {
            MemoryLogOutput inner = new MemoryLogOutput();
            AsyncLogOutput output = new AsyncLogOutput(inner);

            output.Write(CreateEntry(message: "a"));
            output.Write(CreateEntry(message: "b"));
            output.Flush();

            Assert.Equal(2, inner.Count);
        }

        /// <summary>
        /// Tests that async log output dispose flushes and disposes inner
        /// </summary>
        [Fact]
        public void AsyncLogOutput_Dispose_FlushesAndDisposesInner()
        {
            bool innerDisposed = false;
            SpyLogOutput inner = new SpyLogOutput(() => innerDisposed = true);
            AsyncLogOutput output = new AsyncLogOutput(inner);

            output.Write(CreateEntry());
            output.Dispose();

            Assert.True(inner.WasWritten);
            Assert.True(innerDisposed);
        }

        /// <summary>
        /// Tests that async log output dispose called twice no error
        /// </summary>
        [Fact]
        public void AsyncLogOutput_Dispose_CalledTwice_NoError()
        {
            MemoryLogOutput inner = new MemoryLogOutput();
            AsyncLogOutput output = new AsyncLogOutput(inner);
            output.Dispose();
            Exception ex = Record.Exception(() => output.Dispose());
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that async log output null inner throws
        /// </summary>
        [Fact]
        public void AsyncLogOutput_NullInner_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new AsyncLogOutput(null));
        }

        /// <summary>
        /// Tests that async log output name
        /// </summary>
        [Fact]
        public void AsyncLogOutput_Name()
        {
            MemoryLogOutput inner = new MemoryLogOutput();
            AsyncLogOutput output = new AsyncLogOutput(inner);
            Assert.Contains("Async", output.Name);
            Assert.Contains("MemoryOutput", output.Name);
        }

        // ============================================================
        // FileLogOutput
        // ============================================================

        /// <summary>
        /// Tests that file log output write writes to file
        /// </summary>
        [Fact]
        public void FileLogOutput_Write_WritesToFile()
        {
            string path = Path.Combine(Path.GetTempPath(), $"test_log_{Guid.NewGuid():N}.txt");
            try
            {
                FileLogOutput output = new FileLogOutput(path);
                LogEntry entry = CreateEntry(LogLevel.Info, "hello file");

                output.Write(entry);
                output.Dispose();

                string content = File.ReadAllText(path);
                Assert.Contains("hello file", content);
            }
            finally
            {
                if (File.Exists(path)) File.Delete(path);
            }
        }

        /// <summary>
        /// Tests that file log output write null entry does not throw
        /// </summary>
        [Fact]
        public void FileLogOutput_Write_NullEntry_DoesNotThrow()
        {
            string path = Path.Combine(Path.GetTempPath(), $"test_log_{Guid.NewGuid():N}.txt");
            try
            {
                FileLogOutput output = new FileLogOutput(path);
                Exception ex = Record.Exception(() => output.Write(null));
                Assert.Null(ex);
                output.Dispose();
            }
            finally
            {
                if (File.Exists(path)) File.Delete(path);
            }
        }

        /// <summary>
        /// Tests that file log output write after dispose does not throw
        /// </summary>
        [Fact]
        public void FileLogOutput_Write_AfterDispose_DoesNotThrow()
        {
            string path = Path.Combine(Path.GetTempPath(), $"test_log_{Guid.NewGuid():N}.txt");
            try
            {
                FileLogOutput output = new FileLogOutput(path);
                output.Dispose();
                Exception ex = Record.Exception(() => output.Write(CreateEntry()));
                Assert.Null(ex);
            }
            finally
            {
                if (File.Exists(path)) File.Delete(path);
            }
        }

        /// <summary>
        /// Tests that file log output empty path throws
        /// </summary>
        [Fact]
        public void FileLogOutput_EmptyPath_Throws()
        {
            Assert.Throws<ArgumentException>(() => new FileLogOutput(""));
        }

        /// <summary>
        /// Tests that file log output null path throws
        /// </summary>
        [Fact]
        public void FileLogOutput_NullPath_Throws()
        {
            Assert.Throws<ArgumentException>(() => new FileLogOutput(null));
        }

        /// <summary>
        /// Tests that file log output whitespace path throws
        /// </summary>
        [Fact]
        public void FileLogOutput_WhitespacePath_Throws()
        {
            Assert.Throws<ArgumentException>(() => new FileLogOutput("   "));
        }

        /// <summary>
        /// Tests that file log output creates directory if missing
        /// </summary>
        [Fact]
        public void FileLogOutput_CreatesDirectoryIfMissing()
        {
            string dir = Path.Combine(Path.GetTempPath(), $"test_log_dir_{Guid.NewGuid():N}");
            string path = Path.Combine(dir, "test.log");
            try
            {
                FileLogOutput output = new FileLogOutput(path);
                output.Write(CreateEntry());
                output.Dispose();

                Assert.True(File.Exists(path));
            }
            finally
            {
                if (File.Exists(path)) File.Delete(path);
                if (Directory.Exists(dir)) Directory.Delete(dir, true);
            }
        }

        /// <summary>
        /// Tests that file log output append mode
        /// </summary>
        [Fact]
        public void FileLogOutput_AppendMode()
        {
            string path = Path.Combine(Path.GetTempPath(), $"test_log_{Guid.NewGuid():N}.txt");
            try
            {
                FileLogOutput output1 = new FileLogOutput(path);
                output1.Write(CreateEntry(message: "first"));
                output1.Dispose();

                FileLogOutput output2 = new FileLogOutput(path);
                output2.Write(CreateEntry(message: "second"));
                output2.Dispose();

                string content = File.ReadAllText(path);
                Assert.Contains("first", content);
                Assert.Contains("second", content);
            }
            finally
            {
                if (File.Exists(path)) File.Delete(path);
            }
        }

        /// <summary>
        /// Tests that file log output overwrite mode
        /// </summary>
        [Fact]
        public void FileLogOutput_OverwriteMode()
        {
            string path = Path.Combine(Path.GetTempPath(), $"test_log_{Guid.NewGuid():N}.txt");
            try
            {
                FileLogOutput output1 = new FileLogOutput(path, append: false);
                output1.Write(CreateEntry(message: "first"));
                output1.Dispose();

                FileLogOutput output2 = new FileLogOutput(path, append: false);
                output2.Write(CreateEntry(message: "second"));
                output2.Dispose();

                string content = File.ReadAllText(path);
                Assert.DoesNotContain("first", content);
                Assert.Contains("second", content);
            }
            finally
            {
                if (File.Exists(path)) File.Delete(path);
            }
        }

        /// <summary>
        /// Tests that file log output flush no op when not disposed
        /// </summary>
        [Fact]
        public void FileLogOutput_Flush_NoOpWhenNotDisposed()
        {
            string path = Path.Combine(Path.GetTempPath(), $"test_log_{Guid.NewGuid():N}.txt");
            try
            {
                FileLogOutput output = new FileLogOutput(path);
                output.Write(CreateEntry());

                Exception ex = Record.Exception(() => output.Flush());
                Assert.Null(ex);
                output.Dispose();
            }
            finally
            {
                if (File.Exists(path)) File.Delete(path);
            }
        }

        /// <summary>
        /// Tests that file log output flush after dispose no op
        /// </summary>
        [Fact]
        public void FileLogOutput_Flush_AfterDispose_NoOp()
        {
            string path = Path.Combine(Path.GetTempPath(), $"test_log_{Guid.NewGuid():N}.txt");
            try
            {
                FileLogOutput output = new FileLogOutput(path);
                output.Dispose();

                Exception ex = Record.Exception(() => output.Flush());
                Assert.Null(ex);
            }
            finally
            {
                if (File.Exists(path)) File.Delete(path);
            }
        }

        /// <summary>
        /// Tests that file log output dispose called twice no error
        /// </summary>
        [Fact]
        public void FileLogOutput_Dispose_CalledTwice_NoError()
        {
            string path = Path.Combine(Path.GetTempPath(), $"test_log_{Guid.NewGuid():N}.txt");
            try
            {
                FileLogOutput output = new FileLogOutput(path);
                output.Dispose();
                Exception ex = Record.Exception(() => output.Dispose());
                Assert.Null(ex);
            }
            finally
            {
                if (File.Exists(path)) File.Delete(path);
            }
        }

        /// <summary>
        /// Tests that file log output custom formatter
        /// </summary>
        [Fact]
        public void FileLogOutput_CustomFormatter()
        {
            string path = Path.Combine(Path.GetTempPath(), $"test_log_{Guid.NewGuid():N}.txt");
            try
            {
                FileLogOutput output = new FileLogOutput(path, new CompactLogFormatter());
                output.Write(CreateEntry(LogLevel.Warning, "warn msg"));
                output.Dispose();

                string content = File.ReadAllText(path);
                Assert.Contains("[W] warn msg", content);
            }
            finally
            {
                if (File.Exists(path)) File.Delete(path);
            }
        }

        /// <summary>
        /// Tests that file log output name
        /// </summary>
        [Fact]
        public void FileLogOutput_Name()
        {
            string path = Path.Combine(Path.GetTempPath(), "myfile.log");
            FileLogOutput output = new FileLogOutput(path);

            Assert.Contains("myfile.log", output.Name);
        }

        // ============================================================
        // LoggerScope
        // ============================================================

        /// <summary>
        /// Tests that logger scope dispose pops scope
        /// </summary>
        [Fact]
        public void LoggerScope_Dispose_PopsScope()
        {
            Stack<object> stack = new Stack<object>();
            LoggerScope scope = new LoggerScope("test", stack, null);

            Assert.Equal(1, stack.Count);

            scope.Dispose();

            Assert.Equal(0, stack.Count);
        }

        /// <summary>
        /// Tests that logger scope dispose invokes callback
        /// </summary>
        [Fact]
        public void LoggerScope_Dispose_InvokesCallback()
        {
            bool invoked = false;
            Stack<object> stack = new Stack<object>();
            LoggerScope scope = new LoggerScope("test", stack, () => invoked = true);

            scope.Dispose();

            Assert.True(invoked);
        }

        /// <summary>
        /// Tests that logger scope dispose called twice no error
        /// </summary>
        [Fact]
        public void LoggerScope_Dispose_CalledTwice_NoError()
        {
            Stack<object> stack = new Stack<object>();
            LoggerScope scope = new LoggerScope("test", stack, null);

            scope.Dispose();
            Exception ex = Record.Exception(() => scope.Dispose());

            Assert.Null(ex);
            Assert.Equal(0, stack.Count);
        }

        /// <summary>
        /// Tests that logger scope null stack throws
        /// </summary>
        [Fact]
        public void LoggerScope_NullStack_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new LoggerScope("test", null, null));
        }

        /// <summary>
        /// Tests that logger scope null callback no error
        /// </summary>
        [Fact]
        public void LoggerScope_NullCallback_NoError()
        {
            Stack<object> stack = new Stack<object>();
            LoggerScope scope = new LoggerScope("test", stack, null);

            Exception ex = Record.Exception(() => scope.Dispose());

            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that logger scope nested scopes last in first out
        /// </summary>
        [Fact]
        public void LoggerScope_NestedScopes_LastInFirstOut()
        {
            Stack<object> stack = new Stack<object>();
            LoggerScope outer = new LoggerScope("outer", stack, null);
            LoggerScope inner = new LoggerScope("inner", stack, null);

            Assert.Equal(2, stack.Count);
            Assert.Equal("inner", stack.Peek());

            inner.Dispose();
            Assert.Equal(1, stack.Count);
            Assert.Equal("outer", stack.Peek());

            outer.Dispose();
            Assert.Equal(0, stack.Count);
        }

        /// <summary>
        ///     Spy output that tracks disposal and writes for testing
        /// </summary>
        private class SpyLogOutput : ILogOutput
        {
            /// <summary>
            /// The on dispose
            /// </summary>
            private readonly Action _onDispose;
            /// <summary>
            /// Gets or sets the value of the was written
            /// </summary>
            public bool WasWritten { get; private set; }
            /// <summary>
            /// Gets the value of the name
            /// </summary>
            public string Name => "SpyOutput";
            /// <summary>
            /// Gets or sets the value of the is enabled
            /// </summary>
            public bool IsEnabled { get; set; } = true;

            /// <summary>
            /// Initializes a new instance of the <see cref="SpyLogOutput"/> class
            /// </summary>
            /// <param name="onDispose">The on dispose</param>
            public SpyLogOutput(Action onDispose = null)
            {
                _onDispose = onDispose;
            }

            /// <summary>
            /// Writes the entry
            /// </summary>
            /// <param name="entry">The entry</param>
            public void Write(ILogEntry entry)
            {
                WasWritten = true;
            }

            /// <summary>
            /// Flushes this instance
            /// </summary>
            public void Flush() { }

            /// <summary>
            /// Disposes this instance
            /// </summary>
            public void Dispose()
            {
                _onDispose?.Invoke();
            }
        }
    }
}
