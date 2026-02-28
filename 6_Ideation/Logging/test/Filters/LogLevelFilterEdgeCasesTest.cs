// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: Filters/LogLevelFilterEdgeCasesTest.cs
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

using Alis.Core.Aspect.Logging;
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
        [Fact]
        public void LogLevelFilter_BoundaryTrace_ShouldBeEqual()
        {
            // Arrange
            LogLevelFilter filter = new LogLevelFilter(LogLevel.Trace);

            // Act & Assert
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Trace)));
        }

        [Fact]
        public void LogLevelFilter_BoundaryNone_ShouldRejectNone()
        {
            // Arrange
            LogLevelFilter filter = new LogLevelFilter(LogLevel.Critical);

            // Act & Assert - None is special
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.None)));
        }

        [Fact]
        public void LogLevelFilter_AllBoundaries_ShouldWork()
        {
            // Arrange & Act & Assert
            for (byte i = 0; i <= 5; i++)
            {
                LogLevel level = (LogLevel)i;
                LogLevelFilter filter = new LogLevelFilter(level);
                Assert.NotNull(filter);
                Assert.True(filter.ShouldLog(CreateEntry(level)));
            }
        }

        [Fact]
        public void LogLevelFilter_ByteComparison_ShouldBeDirect()
        {
            // Arrange
            LogLevelFilter filter = new LogLevelFilter((LogLevel)3); // Warning

            // Act & Assert
            Assert.True(filter.ShouldLog(CreateEntry((LogLevel)3)));
            Assert.True(filter.ShouldLog(CreateEntry((LogLevel)4)));
            Assert.False(filter.ShouldLog(CreateEntry((LogLevel)2)));
        }

        [Fact]
        public void LogLevelFilter_MultipleFilterInstances_ShouldBeIndependent()
        {
            // Arrange
            LogLevelFilter filter1 = new LogLevelFilter(LogLevel.Info);
            LogLevelFilter filter2 = new LogLevelFilter(LogLevel.Error);

            // Act & Assert
            ILogEntry infoEntry = CreateEntry(LogLevel.Info);
            ILogEntry errorEntry = CreateEntry(LogLevel.Error);

            Assert.False(filter2.ShouldLog(infoEntry));
            Assert.True(filter2.ShouldLog(errorEntry));
        }

        [Fact]
        public void LogLevelFilter_Reusability_ShouldWorkMultipleTimes()
        {
            // Arrange
            LogLevelFilter filter = new LogLevelFilter(LogLevel.Warning);

            // Act & Assert - Should work multiple times
            for (int i = 0; i < 100; i++)
            {
                bool result = filter.ShouldLog(CreateEntry(LogLevel.Warning));
                Assert.True(result);
            }
        }

        private static ILogEntry CreateEntry(LogLevel level)
        {
            return new LogEntry(level, "Test", "Logger");
        }
    }
}

