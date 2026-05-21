

using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Filters;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test.Filters
{
    /// <summary>
    ///     Edge case tests for LogLevelFilter.
    ///     Tests boundary conditions and special scenarios.
    /// </summary>
    public class LogLevelFilterEdgeCasesTest
    {
        /// <summary>
        ///     Tests that log level filter boundary trace should be equal
        /// </summary>
        [Fact]
        public void LogLevelFilter_BoundaryTrace_ShouldBeEqual()
        {
            LogLevelFilter filter = new LogLevelFilter(LogLevel.Trace);

            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Trace)));
        }

        /// <summary>
        ///     Tests that log level filter boundary none should reject none
        /// </summary>
        [Fact]
        public void LogLevelFilter_BoundaryNone_ShouldRejectNone()
        {
            LogLevelFilter filter = new LogLevelFilter(LogLevel.Critical);

            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.None)));
        }

        /// <summary>
        ///     Tests that log level filter all boundaries should work
        /// </summary>
        [Fact]
        public void LogLevelFilter_AllBoundaries_ShouldWork()
        {
            for (byte i = 0; i <= 5; i++)
            {
                LogLevel level = (LogLevel) i;
                LogLevelFilter filter = new LogLevelFilter(level);
                Assert.NotNull(filter);
                Assert.True(filter.ShouldLog(CreateEntry(level)));
            }
        }

        /// <summary>
        ///     Tests that log level filter byte comparison should be direct
        /// </summary>
        [Fact]
        public void LogLevelFilter_ByteComparison_ShouldBeDirect()
        {
            LogLevelFilter filter = new LogLevelFilter((LogLevel) 3); // Warning

            Assert.True(filter.ShouldLog(CreateEntry((LogLevel) 3)));
            Assert.True(filter.ShouldLog(CreateEntry((LogLevel) 4)));
            Assert.False(filter.ShouldLog(CreateEntry((LogLevel) 2)));
        }

        /// <summary>
        ///     Tests that log level filter multiple filter instances should be independent
        /// </summary>
        [Fact]
        public void LogLevelFilter_MultipleFilterInstances_ShouldBeIndependent()
        {
            LogLevelFilter filter1 = new LogLevelFilter(LogLevel.Info);
            LogLevelFilter filter2 = new LogLevelFilter(LogLevel.Error);

            ILogEntry infoEntry = CreateEntry(LogLevel.Info);
            ILogEntry errorEntry = CreateEntry(LogLevel.Error);

            Assert.False(filter2.ShouldLog(infoEntry));
            Assert.True(filter2.ShouldLog(errorEntry));
        }

        /// <summary>
        ///     Tests that log level filter reusability should work multiple times
        /// </summary>
        [Fact]
        public void LogLevelFilter_Reusability_ShouldWorkMultipleTimes()
        {
            LogLevelFilter filter = new LogLevelFilter(LogLevel.Warning);

            for (int i = 0; i < 100; i++)
            {
                bool result = filter.ShouldLog(CreateEntry(LogLevel.Warning));
                Assert.True(result);
            }
        }

        /// <summary>
        ///     Creates the entry using the specified level
        /// </summary>
        /// <param name="level">The level</param>
        /// <returns>The log entry</returns>
        private static ILogEntry CreateEntry(LogLevel level) => new LogEntry(level, "Test", "Logger");
    }
}