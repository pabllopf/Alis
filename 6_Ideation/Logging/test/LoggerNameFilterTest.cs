// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LoggerNameFilterTest.cs
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

using System.Collections.Generic;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Filters;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Comprehensive unit tests for the LoggerNameFilter class.
    ///     Validates filtering by logger name with inclusive/exclusive modes.
    /// </summary>
    public class LoggerNameFilterTest
    {
        /// <summary>
        ///     Tests that logger name filter inclusive should allow only specified names
        /// </summary>
        [Fact]
        public void LoggerNameFilter_Inclusive_ShouldAllowOnlySpecifiedNames()
        {
            // Arrange
            string[] names = new[] {"Logger1", "Logger2"};
            LoggerNameFilter filter = new LoggerNameFilter(names);

            // Act & Assert
            Assert.True(filter.ShouldLog(CreateEntry("Logger1")));
            Assert.True(filter.ShouldLog(CreateEntry("Logger2")));
            Assert.False(filter.ShouldLog(CreateEntry("Logger3")));
        }

        /// <summary>
        ///     Tests that logger name filter exclusive should block specified names
        /// </summary>
        [Fact]
        public void LoggerNameFilter_Exclusive_ShouldBlockSpecifiedNames()
        {
            // Arrange
            string[] names = new[] {"Logger1", "Logger2"};
            LoggerNameFilter filter = new LoggerNameFilter(names, false);

            // Act & Assert
            Assert.False(filter.ShouldLog(CreateEntry("Logger1")));
            Assert.False(filter.ShouldLog(CreateEntry("Logger2")));
            Assert.True(filter.ShouldLog(CreateEntry("Logger3")));
        }

        /// <summary>
        ///     Tests that logger name filter empty name list should allow all
        /// </summary>
        [Fact]
        public void LoggerNameFilter_EmptyNameList_ShouldAllowAll()
        {
            // Arrange
            LoggerNameFilter filter = new LoggerNameFilter(new List<string>());

            // Act & Assert
            Assert.True(filter.ShouldLog(CreateEntry("Any")));
        }

        /// <summary>
        ///     Tests that logger name filter single name should filter correctly
        /// </summary>
        [Fact]
        public void LoggerNameFilter_SingleName_ShouldFilterCorrectly()
        {
            // Arrange
            LoggerNameFilter filter = new LoggerNameFilter(new[] {"MyLogger"});

            // Act & Assert
            Assert.True(filter.ShouldLog(CreateEntry("MyLogger")));
            Assert.False(filter.ShouldLog(CreateEntry("OtherLogger")));
        }

        /// <summary>
        ///     Tests that logger name filter case sensitive should distinguish case
        /// </summary>
        [Fact]
        public void LoggerNameFilter_CaseSensitive_ShouldDistinguishCase()
        {
            // Arrange
            LoggerNameFilter filter = new LoggerNameFilter(new[] {"Logger"});

            // Act & Assert
            Assert.True(filter.ShouldLog(CreateEntry("Logger")));
            Assert.False(filter.ShouldLog(CreateEntry("logger")));
            Assert.False(filter.ShouldLog(CreateEntry("LOGGER")));
        }

        /// <summary>
        ///     Tests that logger name filter null entry should return true
        /// </summary>
        [Fact]
        public void LoggerNameFilter_NullEntry_ShouldReturnTrue()
        {
            // Arrange
            LoggerNameFilter filter = new LoggerNameFilter(new[] {"Logger"});

            // Act & Assert
            Assert.True(filter.ShouldLog(null));
        }

        /// <summary>
        ///     Tests that logger name filter null name list should allow all
        /// </summary>
        [Fact]
        public void LoggerNameFilter_NullNameList_ShouldAllowAll()
        {
            // Arrange
            LoggerNameFilter filter = new LoggerNameFilter(null);

            // Act & Assert
            Assert.True(filter.ShouldLog(CreateEntry("Any")));
        }

        /// <summary>
        ///     Tests that logger name filter empty logger name should filter correctly
        /// </summary>
        [Fact]
        public void LoggerNameFilter_EmptyLoggerName_ShouldFilterCorrectly()
        {
            // Arrange
            LoggerNameFilter filter = new LoggerNameFilter(new[] {""});

            // Act & Assert
            Assert.True(filter.ShouldLog(CreateEntry("")));
            Assert.False(filter.ShouldLog(CreateEntry("Logger")));
        }

        /// <summary>
        ///     Tests that logger name filter multiple names inclusive mode
        /// </summary>
        [Fact]
        public void LoggerNameFilter_MultipleNames_InclusiveMode()
        {
            // Arrange
            string[] names = new[] {"Engine", "Physics", "Graphics"};
            LoggerNameFilter filter = new LoggerNameFilter(names);

            // Act & Assert
            Assert.True(filter.ShouldLog(CreateEntry("Engine")));
            Assert.True(filter.ShouldLog(CreateEntry("Physics")));
            Assert.True(filter.ShouldLog(CreateEntry("Graphics")));
            Assert.False(filter.ShouldLog(CreateEntry("Audio")));
            Assert.False(filter.ShouldLog(CreateEntry("Network")));
        }

        /// <summary>
        ///     Tests that logger name filter multiple names exclusive mode
        /// </summary>
        [Fact]
        public void LoggerNameFilter_MultipleNames_ExclusiveMode()
        {
            // Arrange
            string[] names = new[] {"Debug", "Trace"};
            LoggerNameFilter filter = new LoggerNameFilter(names, false);

            // Act & Assert
            Assert.False(filter.ShouldLog(CreateEntry("Debug")));
            Assert.False(filter.ShouldLog(CreateEntry("Trace")));
            Assert.True(filter.ShouldLog(CreateEntry("Info")));
            Assert.True(filter.ShouldLog(CreateEntry("Error")));
        }

        /// <summary>
        ///     Tests that logger name filter has name
        /// </summary>
        [Fact]
        public void LoggerNameFilter_HasName()
        {
            // Arrange
            LoggerNameFilter filter = new LoggerNameFilter(new[] {"Logger"});

            // Act & Assert
            Assert.NotNull(filter.Name);
            Assert.Contains("LoggerNameFilter", filter.Name);
        }

        /// <summary>
        ///     Tests that logger name filter inclusive mode name should contain include
        /// </summary>
        [Fact]
        public void LoggerNameFilter_InclusiveModeName_ShouldContainInclude()
        {
            // Arrange
            LoggerNameFilter filter = new LoggerNameFilter(new[] {"Logger"});

            // Act & Assert
            Assert.Contains("Include", filter.Name);
        }

        /// <summary>
        ///     Tests that logger name filter exclusive mode name should contain exclude
        /// </summary>
        [Fact]
        public void LoggerNameFilter_ExclusiveModeName_ShouldContainExclude()
        {
            // Arrange
            LoggerNameFilter filter = new LoggerNameFilter(new[] {"Logger"}, false);

            // Act & Assert
            Assert.Contains("Exclude", filter.Name);
        }

        /// <summary>
        ///     Tests that logger name filter whitespace in name should be preserved
        /// </summary>
        [Fact]
        public void LoggerNameFilter_WhitespaceInName_ShouldBePreserved()
        {
            // Arrange
            LoggerNameFilter filter = new LoggerNameFilter(new[] {"My Logger"});

            // Act & Assert
            Assert.True(filter.ShouldLog(CreateEntry("My Logger")));
            Assert.False(filter.ShouldLog(CreateEntry("MyLogger")));
        }

        /// <summary>
        ///     Tests that logger name filter special characters in name should be matched
        /// </summary>
        [Fact]
        public void LoggerNameFilter_SpecialCharactersInName_ShouldBeMatched()
        {
            // Arrange
            LoggerNameFilter filter = new LoggerNameFilter(new[] {"Logger@123"});

            // Act & Assert
            Assert.True(filter.ShouldLog(CreateEntry("Logger@123")));
            Assert.False(filter.ShouldLog(CreateEntry("Logger123")));
        }

        /// <summary>
        ///     Tests that logger name filter duplicate names should be handled
        /// </summary>
        [Fact]
        public void LoggerNameFilter_DuplicateNames_ShouldBeHandled()
        {
            // Arrange
            LoggerNameFilter filter = new LoggerNameFilter(new[] {"Logger", "Logger", "Other"});

            // Act & Assert
            Assert.True(filter.ShouldLog(CreateEntry("Logger")));
            Assert.True(filter.ShouldLog(CreateEntry("Other")));
        }

        /// <summary>
        ///     Creates the entry using the specified logger name
        /// </summary>
        /// <param name="loggerName">The logger name</param>
        /// <returns>The log entry</returns>
        private static ILogEntry CreateEntry(string loggerName) => new LogEntry(LogLevel.Info, "Test", loggerName);
    }
}