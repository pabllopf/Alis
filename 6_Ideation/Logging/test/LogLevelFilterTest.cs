// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LogLevelFilterTest.cs
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
        /// Tests that log level filter should allow levels greater than or equal
        /// </summary>
        [Fact]
        public void LogLevelFilter_ShouldAllowLevelsGreaterThanOrEqual()
        {
            // Arrange
            LogLevelFilter filter = new LogLevelFilter(LogLevel.Warning);

            // Act & Assert
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Trace)));
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Debug)));
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Info)));
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Warning)));
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Error)));
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Critical)));
        }

        /// <summary>
        /// Tests that log level filter trace should allow all
        /// </summary>
        [Fact]
        public void LogLevelFilter_Trace_ShouldAllowAll()
        {
            // Arrange
            LogLevelFilter filter = new LogLevelFilter(LogLevel.Trace);

            // Act & Assert
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Trace)));
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Debug)));
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Info)));
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Warning)));
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Error)));
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Critical)));
        }

        /// <summary>
        /// Tests that log level filter critical should only allow critical
        /// </summary>
        [Fact]
        public void LogLevelFilter_Critical_ShouldOnlyAllowCritical()
        {
            // Arrange
            LogLevelFilter filter = new LogLevelFilter(LogLevel.Critical);

            // Act & Assert
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Trace)));
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Debug)));
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Info)));
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Warning)));
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Error)));
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Critical)));
        }

        /// <summary>
        /// Tests that log level filter none should reject all
        /// </summary>
        [Fact]
        public void LogLevelFilter_None_ShouldRejectAll()
        {
            // Arrange
            LogLevelFilter filter = new LogLevelFilter(LogLevel.None);

            // Act & Assert
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Trace)));
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Critical)));
        }

        /// <summary>
        /// Tests that log level filter null entry should return false
        /// </summary>
        [Fact]
        public void LogLevelFilter_NullEntry_ShouldReturnFalse()
        {
            // Arrange
            LogLevelFilter filter = new LogLevelFilter(LogLevel.Info);

            // Act & Assert
            Assert.False(filter.ShouldLog(null));
        }

        /// <summary>
        /// Tests that log level filter all levels should produce expected results
        /// </summary>
        [Fact]
        public void LogLevelFilter_AllLevels_ShouldProduceExpectedResults()
        {
            // Arrange
            LogLevel[] levels = new[]
            {
                LogLevel.Trace, LogLevel.Debug, LogLevel.Info,
                LogLevel.Warning, LogLevel.Error, LogLevel.Critical
            };

            foreach (LogLevel level in levels)
            {
                LogLevelFilter filter = new LogLevelFilter(level);

                // Act & Assert
                for (int i = 0; i < levels.Length; i++)
                {
                    LogLevel testLevel = levels[i];
                    bool expected = testLevel >= level;
                    Assert.Equal(expected, filter.ShouldLog(CreateEntry(testLevel)));
                }
            }
        }

        /// <summary>
        /// Tests that log level filter has name
        /// </summary>
        [Fact]
        public void LogLevelFilter_HasName()
        {
            // Arrange
            LogLevelFilter filter = new LogLevelFilter(LogLevel.Warning);

            // Act & Assert
            Assert.NotNull(filter.Name);
            Assert.Contains("LogLevelFilter", filter.Name);
            Assert.Contains("Warning", filter.Name);
        }

        /// <summary>
        /// Creates the entry using the specified level
        /// </summary>
        /// <param name="level">The level</param>
        /// <returns>The log entry</returns>
        private static ILogEntry CreateEntry(LogLevel level) => new LogEntry(level, "Test", "Logger");
    }
}