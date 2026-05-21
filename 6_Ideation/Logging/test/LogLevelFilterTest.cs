

using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Filters;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Comprehensive unit tests for the LogLevelFilter class.
    ///     Validates filtering by severity level and edge cases.
    /// </summary>
    public class LogLevelFilterTest
    {
        /// <summary>
        ///     Tests that log level filter should allow levels greater than or equal
        /// </summary>
        [Fact]
        public void LogLevelFilter_ShouldAllowLevelsGreaterThanOrEqual()
        {
            LogLevelFilter filter = new LogLevelFilter(LogLevel.Warning);

            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Trace)));
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Debug)));
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Info)));
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Warning)));
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Error)));
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Critical)));
        }

        /// <summary>
        ///     Tests that log level filter trace should allow all
        /// </summary>
        [Fact]
        public void LogLevelFilter_Trace_ShouldAllowAll()
        {
            LogLevelFilter filter = new LogLevelFilter(LogLevel.Trace);

            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Trace)));
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Debug)));
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Info)));
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Warning)));
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Error)));
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Critical)));
        }

        /// <summary>
        ///     Tests that log level filter critical should only allow critical
        /// </summary>
        [Fact]
        public void LogLevelFilter_Critical_ShouldOnlyAllowCritical()
        {
            LogLevelFilter filter = new LogLevelFilter(LogLevel.Critical);

            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Trace)));
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Debug)));
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Info)));
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Warning)));
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Error)));
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Critical)));
        }

        /// <summary>
        ///     Tests that log level filter none should reject all
        /// </summary>
        [Fact]
        public void LogLevelFilter_None_ShouldRejectAll()
        {
            LogLevelFilter filter = new LogLevelFilter(LogLevel.None);

            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Trace)));
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Critical)));
        }

        /// <summary>
        ///     Tests that log level filter null entry should return false
        /// </summary>
        [Fact]
        public void LogLevelFilter_NullEntry_ShouldReturnFalse()
        {
            LogLevelFilter filter = new LogLevelFilter(LogLevel.Info);

            Assert.False(filter.ShouldLog(null));
        }

        /// <summary>
        ///     Tests that log level filter all levels should produce expected results
        /// </summary>
        [Fact]
        public void LogLevelFilter_AllLevels_ShouldProduceExpectedResults()
        {
            LogLevel[] levels = new[]
            {
                LogLevel.Trace, LogLevel.Debug, LogLevel.Info,
                LogLevel.Warning, LogLevel.Error, LogLevel.Critical
            };

            foreach (LogLevel level in levels)
            {
                LogLevelFilter filter = new LogLevelFilter(level);

                for (int i = 0; i < levels.Length; i++)
                {
                    LogLevel testLevel = levels[i];
                    bool expected = testLevel >= level;
                    Assert.Equal(expected, filter.ShouldLog(CreateEntry(testLevel)));
                }
            }
        }

        /// <summary>
        ///     Tests that log level filter has name
        /// </summary>
        [Fact]
        public void LogLevelFilter_HasName()
        {
            LogLevelFilter filter = new LogLevelFilter(LogLevel.Warning);

            Assert.NotNull(filter.Name);
            Assert.Contains("LogLevelFilter", filter.Name);
            Assert.Contains("Warning", filter.Name);
        }

        /// <summary>
        ///     Creates the entry using the specified level
        /// </summary>
        /// <param name="level">The level</param>
        /// <returns>The log entry</returns>
        private static ILogEntry CreateEntry(LogLevel level) => new LogEntry(level, "Test", "Logger");

        /// <summary>
        /// Gets the massive level combinations
        /// </summary>
        /// <returns>A system collections generic enumerable of object array</returns>
        public static System.Collections.Generic.IEnumerable<object[]> GetMassiveLevelCombinations()
        {
            LogLevel[] levels =
            {
                LogLevel.Trace,
                LogLevel.Debug,
                LogLevel.Info,
                LogLevel.Warning,
                LogLevel.Error,
                LogLevel.Critical,
                LogLevel.None
            };

            for (int repeat = 0; repeat < 41; repeat++)
            {
                for (int i = 0; i < levels.Length; i++)
                {
                    for (int j = 0; j < levels.Length; j++)
                    {
                        yield return new object[] {repeat, levels[i], levels[j]};
                    }
                }
            }
        }

        /// <summary>
        /// Tests that log level filter massive level combinations are deterministic
        /// </summary>
        /// <param name="repeat">The repeat</param>
        /// <param name="minimum">The minimum</param>
        /// <param name="current">The current</param>
        [Theory, MemberData(nameof(GetMassiveLevelCombinations))]
        public void LogLevelFilter_MassiveLevelCombinations_AreDeterministic(int repeat, LogLevel minimum, LogLevel current)
        {
            LogLevelFilter filter = new LogLevelFilter(minimum);
            bool expected = current >= minimum;

            Assert.True(repeat >= 0);
            Assert.Equal(expected, filter.ShouldLog(CreateEntry(current)));
        }
    }
}