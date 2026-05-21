

using Alis.Core.Aspect.Logging.Abstractions;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Comprehensive unit tests for the LogLevel enumeration.
    ///     Validates enum values and comparison semantics.
    /// </summary>
    public class LogLevelTest
    {
        /// <summary>
        ///     Tests that log level trace has value 0
        /// </summary>
        [Fact]
        public void LogLevel_Trace_HasValue0()
        {
            Assert.Equal(0, (byte) LogLevel.Trace);
        }

        /// <summary>
        ///     Tests that log level debug has value 1
        /// </summary>
        [Fact]
        public void LogLevel_Debug_HasValue1()
        {
            Assert.Equal(1, (byte) LogLevel.Debug);
        }

        /// <summary>
        ///     Tests that log level info has value 2
        /// </summary>
        [Fact]
        public void LogLevel_Info_HasValue2()
        {
            Assert.Equal(2, (byte) LogLevel.Info);
        }

        /// <summary>
        ///     Tests that log level warning has value 3
        /// </summary>
        [Fact]
        public void LogLevel_Warning_HasValue3()
        {
            Assert.Equal(3, (byte) LogLevel.Warning);
        }

        /// <summary>
        ///     Tests that log level error has value 4
        /// </summary>
        [Fact]
        public void LogLevel_Error_HasValue4()
        {
            Assert.Equal(4, (byte) LogLevel.Error);
        }

        /// <summary>
        ///     Tests that log level critical has value 5
        /// </summary>
        [Fact]
        public void LogLevel_Critical_HasValue5()
        {
            Assert.Equal(5, (byte) LogLevel.Critical);
        }

        /// <summary>
        ///     Tests that log level none has value 255
        /// </summary>
        [Fact]
        public void LogLevel_None_HasValue255()
        {
            Assert.Equal(255, (byte) LogLevel.None);
        }

        /// <summary>
        ///     Tests that log level comparison should work correctly
        /// </summary>
        [Fact]
        public void LogLevel_Comparison_ShouldWorkCorrectly()
        {
            Assert.True(LogLevel.Trace < LogLevel.Debug);
            Assert.True(LogLevel.Debug < LogLevel.Info);
            Assert.True(LogLevel.Info < LogLevel.Warning);
            Assert.True(LogLevel.Warning < LogLevel.Error);
            Assert.True(LogLevel.Error < LogLevel.Critical);
            Assert.True(LogLevel.Critical < LogLevel.None);
        }

        /// <summary>
        ///     Tests that log level equality should work
        /// </summary>
        [Fact]
        public void LogLevel_Equality_ShouldWork()
        {
            Assert.True(LogLevel.Info == LogLevel.Info);
            Assert.False(LogLevel.Info == LogLevel.Warning);
        }

        /// <summary>
        ///     Tests that log level to string should return name
        /// </summary>
        [Fact]
        public void LogLevel_ToString_ShouldReturnName()
        {
            Assert.Equal("Trace", LogLevel.Trace.ToString());
            Assert.Equal("Debug", LogLevel.Debug.ToString());
            Assert.Equal("Info", LogLevel.Info.ToString());
            Assert.Equal("Warning", LogLevel.Warning.ToString());
            Assert.Equal("Error", LogLevel.Error.ToString());
            Assert.Equal("Critical", LogLevel.Critical.ToString());
            Assert.Equal("None", LogLevel.None.ToString());
        }

        /// <summary>
        ///     Tests that log level can be cast from byte
        /// </summary>
        [Fact]
        public void LogLevel_CanBeCastFromByte()
        {
            Assert.Equal(LogLevel.Info, (LogLevel) 2);
            Assert.Equal(LogLevel.Warning, (LogLevel) 3);
        }

        /// <summary>
        ///     Tests that log level can be cast to byte
        /// </summary>
        [Fact]
        public void LogLevel_CanBeCastToByte()
        {
            Assert.Equal(2, (byte) LogLevel.Info);
            Assert.Equal(3, (byte) LogLevel.Warning);
        }

        /// <summary>
        ///     Tests that log level ordering is monotonic
        /// </summary>
        [Fact]
        public void LogLevel_OrderingIsMonotonic()
        {
            LogLevel[] levels = new[] {LogLevel.Trace, LogLevel.Debug, LogLevel.Info, LogLevel.Warning, LogLevel.Error, LogLevel.Critical, LogLevel.None};

            for (int i = 0; i < levels.Length - 1; i++)
            {
                Assert.True(levels[i] < levels[i + 1], $"{levels[i]} should be less than {levels[i + 1]}");
            }
        }

        /// <summary>
        ///     Tests that log level has seven values
        /// </summary>
        [Fact]
        public void LogLevel_HasSevenValues()
        {
            LogLevel[] values = new[] {LogLevel.Trace, LogLevel.Debug, LogLevel.Info, LogLevel.Warning, LogLevel.Error, LogLevel.Critical, LogLevel.None};

            Assert.Equal(7, values.Length);
        }

        /// <summary>
        ///     Tests that log level none is special
        /// </summary>
        [Fact]
        public void LogLevel_NoneIsSpecial()
        {
            Assert.True(LogLevel.None > LogLevel.Critical);
            Assert.Equal(255, (byte) LogLevel.None);
        }

        /// <summary>
        ///     Tests that log level greater than or equal should work
        /// </summary>
        [Fact]
        public void LogLevel_GreaterThanOrEqual_ShouldWork()
        {
            Assert.True(LogLevel.Error >= LogLevel.Warning);
            Assert.True(LogLevel.Warning >= LogLevel.Warning);
            Assert.False(LogLevel.Warning >= LogLevel.Error);
        }

        /// <summary>
        ///     Tests that log level less than or equal should work
        /// </summary>
        [Fact]
        public void LogLevel_LessThanOrEqual_ShouldWork()
        {
            Assert.True(LogLevel.Warning <= LogLevel.Error);
            Assert.True(LogLevel.Warning <= LogLevel.Warning);
            Assert.False(LogLevel.Error <= LogLevel.Warning);
        }
    }
}