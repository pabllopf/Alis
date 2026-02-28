// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: LoggerNameFilterTest.cs
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
    ///     Comprehensive unit tests for the LoggerNameFilter class.
    ///     Validates filtering by logger name with inclusive/exclusive modes.
    /// </summary>
    public class LoggerNameFilterTest
    {
        [Fact]
        public void LoggerNameFilter_Inclusive_ShouldAllowOnlySpecifiedNames()
        {
            // Arrange
            string[] names = new[] { "Logger1", "Logger2" };
            LoggerNameFilter filter = new LoggerNameFilter(names, inclusive: true);

            // Act & Assert
            Assert.True(filter.ShouldLog(CreateEntry("Logger1")));
            Assert.True(filter.ShouldLog(CreateEntry("Logger2")));
            Assert.False(filter.ShouldLog(CreateEntry("Logger3")));
        }

        [Fact]
        public void LoggerNameFilter_Exclusive_ShouldBlockSpecifiedNames()
        {
            // Arrange
            string[] names = new[] { "Logger1", "Logger2" };
            LoggerNameFilter filter = new LoggerNameFilter(names, inclusive: false);

            // Act & Assert
            Assert.False(filter.ShouldLog(CreateEntry("Logger1")));
            Assert.False(filter.ShouldLog(CreateEntry("Logger2")));
            Assert.True(filter.ShouldLog(CreateEntry("Logger3")));
        }

        [Fact]
        public void LoggerNameFilter_EmptyNameList_ShouldAllowAll()
        {
            // Arrange
            LoggerNameFilter filter = new LoggerNameFilter(new List<string>(), inclusive: true);

            // Act & Assert
            Assert.True(filter.ShouldLog(CreateEntry("Any")));
        }

        [Fact]
        public void LoggerNameFilter_SingleName_ShouldFilterCorrectly()
        {
            // Arrange
            LoggerNameFilter filter = new LoggerNameFilter(new[] { "MyLogger" }, inclusive: true);

            // Act & Assert
            Assert.True(filter.ShouldLog(CreateEntry("MyLogger")));
            Assert.False(filter.ShouldLog(CreateEntry("OtherLogger")));
        }

        [Fact]
        public void LoggerNameFilter_CaseSensitive_ShouldDistinguishCase()
        {
            // Arrange
            LoggerNameFilter filter = new LoggerNameFilter(new[] { "Logger" }, inclusive: true);

            // Act & Assert
            Assert.True(filter.ShouldLog(CreateEntry("Logger")));
            Assert.False(filter.ShouldLog(CreateEntry("logger")));
            Assert.False(filter.ShouldLog(CreateEntry("LOGGER")));
        }

        [Fact]
        public void LoggerNameFilter_NullEntry_ShouldReturnTrue()
        {
            // Arrange
            LoggerNameFilter filter = new LoggerNameFilter(new[] { "Logger" }, inclusive: true);

            // Act & Assert
            Assert.True(filter.ShouldLog(null));
        }

        [Fact]
        public void LoggerNameFilter_NullNameList_ShouldAllowAll()
        {
            // Arrange
            LoggerNameFilter filter = new LoggerNameFilter(null, inclusive: true);

            // Act & Assert
            Assert.True(filter.ShouldLog(CreateEntry("Any")));
        }

        [Fact]
        public void LoggerNameFilter_EmptyLoggerName_ShouldFilterCorrectly()
        {
            // Arrange
            LoggerNameFilter filter = new LoggerNameFilter(new[] { "" }, inclusive: true);

            // Act & Assert
            Assert.True(filter.ShouldLog(CreateEntry("")));
            Assert.False(filter.ShouldLog(CreateEntry("Logger")));
        }

        [Fact]
        public void LoggerNameFilter_MultipleNames_InclusiveMode()
        {
            // Arrange
            string[] names = new[] { "Engine", "Physics", "Graphics" };
            LoggerNameFilter filter = new LoggerNameFilter(names, inclusive: true);

            // Act & Assert
            Assert.True(filter.ShouldLog(CreateEntry("Engine")));
            Assert.True(filter.ShouldLog(CreateEntry("Physics")));
            Assert.True(filter.ShouldLog(CreateEntry("Graphics")));
            Assert.False(filter.ShouldLog(CreateEntry("Audio")));
            Assert.False(filter.ShouldLog(CreateEntry("Network")));
        }

        [Fact]
        public void LoggerNameFilter_MultipleNames_ExclusiveMode()
        {
            // Arrange
            string[] names = new[] { "Debug", "Trace" };
            LoggerNameFilter filter = new LoggerNameFilter(names, inclusive: false);

            // Act & Assert
            Assert.False(filter.ShouldLog(CreateEntry("Debug")));
            Assert.False(filter.ShouldLog(CreateEntry("Trace")));
            Assert.True(filter.ShouldLog(CreateEntry("Info")));
            Assert.True(filter.ShouldLog(CreateEntry("Error")));
        }

        [Fact]
        public void LoggerNameFilter_HasName()
        {
            // Arrange
            LoggerNameFilter filter = new LoggerNameFilter(new[] { "Logger" }, inclusive: true);

            // Act & Assert
            Assert.NotNull(filter.Name);
            Assert.Contains("LoggerNameFilter", filter.Name);
        }

        [Fact]
        public void LoggerNameFilter_InclusiveModeName_ShouldContainInclude()
        {
            // Arrange
            LoggerNameFilter filter = new LoggerNameFilter(new[] { "Logger" }, inclusive: true);

            // Act & Assert
            Assert.Contains("Include", filter.Name);
        }

        [Fact]
        public void LoggerNameFilter_ExclusiveModeName_ShouldContainExclude()
        {
            // Arrange
            LoggerNameFilter filter = new LoggerNameFilter(new[] { "Logger" }, inclusive: false);

            // Act & Assert
            Assert.Contains("Exclude", filter.Name);
        }

        [Fact]
        public void LoggerNameFilter_WhitespaceInName_ShouldBePreserved()
        {
            // Arrange
            LoggerNameFilter filter = new LoggerNameFilter(new[] { "My Logger" }, inclusive: true);

            // Act & Assert
            Assert.True(filter.ShouldLog(CreateEntry("My Logger")));
            Assert.False(filter.ShouldLog(CreateEntry("MyLogger")));
        }

        [Fact]
        public void LoggerNameFilter_SpecialCharactersInName_ShouldBeMatched()
        {
            // Arrange
            LoggerNameFilter filter = new LoggerNameFilter(new[] { "Logger@123" }, inclusive: true);

            // Act & Assert
            Assert.True(filter.ShouldLog(CreateEntry("Logger@123")));
            Assert.False(filter.ShouldLog(CreateEntry("Logger123")));
        }

        [Fact]
        public void LoggerNameFilter_DuplicateNames_ShouldBeHandled()
        {
            // Arrange
            LoggerNameFilter filter = new LoggerNameFilter(new[] { "Logger", "Logger", "Other" }, inclusive: true);

            // Act & Assert
            Assert.True(filter.ShouldLog(CreateEntry("Logger")));
            Assert.True(filter.ShouldLog(CreateEntry("Other")));
        }

        private static ILogEntry CreateEntry(string loggerName)
        {
            return new LogEntry(LogLevel.Info, "Test", loggerName);
        }
    }
}

