// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CompositeLogFilterTest.cs
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
    ///     Comprehensive unit tests for the CompositeLogFilter class.
    ///     Validates AND/OR logic for multiple filter composition.
    /// </summary>
    public class CompositeLogFilterTest
    {
        [Fact]
        public void CompositeLogFilter_AND_AllFiltersMustPass()
        {
            // Arrange
            List<ILogFilter> filters = new List<ILogFilter>
            {
                new LogLevelFilter(LogLevel.Info),
                new LoggerNameFilter(new[] {"AllowedLogger"}, true)
            };
            CompositeLogFilter compositeFilter = new CompositeLogFilter(filters, true);

            // Act & Assert
            Assert.True(compositeFilter.ShouldLog(CreateEntry(LogLevel.Info, "AllowedLogger")));
            Assert.False(compositeFilter.ShouldLog(CreateEntry(LogLevel.Debug, "AllowedLogger")));
            Assert.False(compositeFilter.ShouldLog(CreateEntry(LogLevel.Info, "BlockedLogger")));
            Assert.False(compositeFilter.ShouldLog(CreateEntry(LogLevel.Debug, "BlockedLogger")));
        }

        [Fact]
        public void CompositeLogFilter_OR_AnyFilterCanPass()
        {
            // Arrange
            List<ILogFilter> filters = new List<ILogFilter>
            {
                new LogLevelFilter(LogLevel.Error),
                new LoggerNameFilter(new[] {"SpecialLogger"}, true)
            };
            CompositeLogFilter compositeFilter = new CompositeLogFilter(filters, false);

            // Act & Assert
            Assert.True(compositeFilter.ShouldLog(CreateEntry(LogLevel.Error, "OtherLogger")));
            Assert.True(compositeFilter.ShouldLog(CreateEntry(LogLevel.Debug, "SpecialLogger")));
            Assert.True(compositeFilter.ShouldLog(CreateEntry(LogLevel.Error, "SpecialLogger")));
            Assert.False(compositeFilter.ShouldLog(CreateEntry(LogLevel.Debug, "OtherLogger")));
        }

        [Fact]
        public void CompositeLogFilter_EmptyFilterList_ShouldAllowAll()
        {
            // Arrange
            List<ILogFilter> filters = new List<ILogFilter>();
            CompositeLogFilter compositeFilter = new CompositeLogFilter(filters, true);

            // Act & Assert
            Assert.True(compositeFilter.ShouldLog(CreateEntry(LogLevel.Trace, "Any")));
        }

        [Fact]
        public void CompositeLogFilter_NullFilterList_ShouldAllowAll()
        {
            // Arrange
            CompositeLogFilter compositeFilter = new CompositeLogFilter(null, true);

            // Act & Assert
            Assert.True(compositeFilter.ShouldLog(CreateEntry(LogLevel.Info, "Any")));
        }

        [Fact]
        public void CompositeLogFilter_SingleFilter_AND()
        {
            // Arrange
            List<ILogFilter> filters = new List<ILogFilter>
            {
                new LogLevelFilter(LogLevel.Warning)
            };
            CompositeLogFilter compositeFilter = new CompositeLogFilter(filters, true);

            // Act & Assert
            Assert.False(compositeFilter.ShouldLog(CreateEntry(LogLevel.Info, "Logger")));
            Assert.True(compositeFilter.ShouldLog(CreateEntry(LogLevel.Warning, "Logger")));
        }

        [Fact]
        public void CompositeLogFilter_SingleFilter_OR()
        {
            // Arrange
            List<ILogFilter> filters = new List<ILogFilter>
            {
                new LogLevelFilter(LogLevel.Warning)
            };
            CompositeLogFilter compositeFilter = new CompositeLogFilter(filters, false);

            // Act & Assert
            Assert.False(compositeFilter.ShouldLog(CreateEntry(LogLevel.Info, "Logger")));
            Assert.True(compositeFilter.ShouldLog(CreateEntry(LogLevel.Warning, "Logger")));
        }

        [Fact]
        public void CompositeLogFilter_NullEntry_ShouldReturnTrue()
        {
            // Arrange
            List<ILogFilter> filters = new List<ILogFilter>
            {
                new LogLevelFilter(LogLevel.Info)
            };
            CompositeLogFilter compositeFilter = new CompositeLogFilter(filters, true);

            // Act & Assert
            Assert.True(compositeFilter.ShouldLog(null));
        }

        [Fact]
        public void CompositeLogFilter_MultipleFilters_AND_AllMustPass()
        {
            // Arrange
            List<ILogFilter> filters = new List<ILogFilter>
            {
                new LogLevelFilter(LogLevel.Warning),
                new LoggerNameFilter(new[] {"Engine"}, true),
                new ConditionalLogFilter(e => !e.Message.Contains("Ignore"), "CustomFilter")
            };
            CompositeLogFilter compositeFilter = new CompositeLogFilter(filters, true);

            // Act & Assert
            Assert.True(compositeFilter.ShouldLog(CreateEntry(LogLevel.Warning, "Engine", "Important")));
            Assert.False(compositeFilter.ShouldLog(CreateEntry(LogLevel.Warning, "Engine", "Ignore")));
            Assert.False(compositeFilter.ShouldLog(CreateEntry(LogLevel.Info, "Engine", "Important")));
            Assert.False(compositeFilter.ShouldLog(CreateEntry(LogLevel.Warning, "Other", "Important")));
        }

        [Fact]
        public void CompositeLogFilter_MultipleFilters_OR_AnyCanPass()
        {
            // Arrange
            List<ILogFilter> filters = new List<ILogFilter>
            {
                new LogLevelFilter(LogLevel.Critical),
                new LoggerNameFilter(new[] {"Security"}, true),
                new ConditionalLogFilter(e => e.Message.StartsWith("ERROR"), "ErrorPrefix")
            };
            CompositeLogFilter compositeFilter = new CompositeLogFilter(filters, false);

            // Act & Assert
            Assert.True(compositeFilter.ShouldLog(CreateEntry(LogLevel.Critical, "Other", "Normal")));
            Assert.True(compositeFilter.ShouldLog(CreateEntry(LogLevel.Debug, "Security", "Normal")));
            Assert.True(compositeFilter.ShouldLog(CreateEntry(LogLevel.Info, "Other", "ERROR message")));
            Assert.False(compositeFilter.ShouldLog(CreateEntry(LogLevel.Info, "Other", "Normal")));
        }

        [Fact]
        public void CompositeLogFilter_HasName()
        {
            // Arrange
            List<ILogFilter> filters = new List<ILogFilter>
            {
                new LogLevelFilter(LogLevel.Info)
            };
            CompositeLogFilter compositeFilter = new CompositeLogFilter(filters, true);

            // Act & Assert
            Assert.NotNull(compositeFilter.Name);
            Assert.Contains("CompositeFilter", compositeFilter.Name);
        }

        [Fact]
        public void CompositeLogFilter_AND_HasCorrectNameSuffix()
        {
            // Arrange
            List<ILogFilter> filters = new List<ILogFilter>
            {
                new LogLevelFilter(LogLevel.Info)
            };
            CompositeLogFilter compositeFilter = new CompositeLogFilter(filters, true);

            // Act & Assert
            Assert.Contains("AND", compositeFilter.Name);
        }

        [Fact]
        public void CompositeLogFilter_OR_HasCorrectNameSuffix()
        {
            // Arrange
            List<ILogFilter> filters = new List<ILogFilter>
            {
                new LogLevelFilter(LogLevel.Info)
            };
            CompositeLogFilter compositeFilter = new CompositeLogFilter(filters, false);

            // Act & Assert
            Assert.Contains("OR", compositeFilter.Name);
        }

        [Fact]
        public void CompositeLogFilter_ComplexLogic_AND()
        {
            // Arrange
            List<ILogFilter> innerFilters1 = new List<ILogFilter>
            {
                new LogLevelFilter(LogLevel.Warning),
                new LoggerNameFilter(new[] {"Critical"}, true)
            };
            List<ILogFilter> innerFilters2 = new List<ILogFilter>
            {
                new LogLevelFilter(LogLevel.Error)
            };

            CompositeLogFilter compositeInner1 = new CompositeLogFilter(innerFilters1, true);
            CompositeLogFilter compositeInner2 = new CompositeLogFilter(innerFilters2, true);

            List<ILogFilter> outerFilters = new List<ILogFilter> {compositeInner1, compositeInner2};
            CompositeLogFilter compositeOuter = new CompositeLogFilter(outerFilters, false);

            // Act & Assert - Should pass if either inner composite passes
            Assert.True(compositeOuter.ShouldLog(CreateEntry(LogLevel.Warning, "Critical")));
            Assert.True(compositeOuter.ShouldLog(CreateEntry(LogLevel.Error, "Any")));
            Assert.False(compositeOuter.ShouldLog(CreateEntry(LogLevel.Info, "Any")));
        }

        private static ILogEntry CreateEntry(LogLevel level, string loggerName, string message = "Test") => new LogEntry(level, message, loggerName);
    }
}