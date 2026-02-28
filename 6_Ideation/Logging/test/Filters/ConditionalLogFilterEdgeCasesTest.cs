// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: Filters/ConditionalLogFilterEdgeCasesTest.cs
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
using Alis.Core.Aspect.Logging;
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
        [Fact]
        public void ConditionalLogFilter_PredicateThrowingMultipleTimes_ShouldAlwaysReturnTrue()
        {
            // Arrange
            var callCount = 0;
            var filter = new ConditionalLogFilter(e =>
            {
                callCount++;
                throw new InvalidOperationException("Always fails");
            });

            var entry = CreateEntry(LogLevel.Info);

            // Act & Assert
            for (int i = 0; i < 5; i++)
            {
                Assert.True(filter.ShouldLog(entry));
                Assert.Equal(i + 1, callCount);
            }
        }

        [Fact]
        public void ConditionalLogFilter_StatefulPredicate_ShouldMaintainState()
        {
            // Arrange
            var callCount = 0;
            var filter = new ConditionalLogFilter(e =>
            {
                callCount++;
                return callCount % 2 == 1; // Only pass on odd calls
            });

            // Act & Assert
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Info)));  // Call 1 - odd
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Info))); // Call 2 - even
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Info)));  // Call 3 - odd
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Info))); // Call 4 - even
        }

        [Fact]
        public void ConditionalLogFilter_ComplexLogic_WithMessageLength()
        {
            // Arrange
            var filter = new ConditionalLogFilter(e => e.Message.Length > 10);

            // Act & Assert
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Info, "Short")));
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Info, "This is a longer message")));
        }

        [Fact]
        public void ConditionalLogFilter_RegexLikeMatching()
        {
            // Arrange
            var filter = new ConditionalLogFilter(e =>
                e.Message.Contains("ERROR") && e.Level >= LogLevel.Error
            );

            // Act & Assert
            Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Error, "ERROR occurred")));
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Error, "Warning occurred")));
            Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Info, "ERROR occurred")));
        }

        [Fact]
        public void ConditionalLogFilter_CustomNamePreservation()
        {
            // Arrange
            var customNames = new[] { "Filter1", "Filter2", "MyCustomFilter" };

            // Act & Assert
            foreach (var name in customNames)
            {
                var filter = new ConditionalLogFilter(e => true, name);
                Assert.Equal(name, filter.Name);
            }
        }

        [Fact]
        public void ConditionalLogFilter_AlwaysPassPredicate()
        {
            // Arrange
            var filter = new ConditionalLogFilter(e => true);

            // Act & Assert
            for (int i = 0; i < 100; i++)
            {
                Assert.True(filter.ShouldLog(CreateEntry(LogLevel.Trace)));
            }
        }

        [Fact]
        public void ConditionalLogFilter_NeverPassPredicate()
        {
            // Arrange
            var filter = new ConditionalLogFilter(e => false);

            // Act & Assert
            for (int i = 0; i < 100; i++)
            {
                Assert.False(filter.ShouldLog(CreateEntry(LogLevel.Critical)));
            }
        }

        [Fact]
        public void ConditionalLogFilter_PerformanceWithComplexLogic()
        {
            // Arrange
            var filter = new ConditionalLogFilter(e =>
                e.Level >= LogLevel.Warning &&
                e.Message.Length > 5 &&
                !e.LoggerName.StartsWith("Internal") &&
                e.Exception == null
            );

            var validEntry = CreateEntry(LogLevel.Error, "Long message");
            var startTime = DateTime.UtcNow;

            // Act
            for (int i = 0; i < 10000; i++)
            {
                filter.ShouldLog(validEntry);
            }

            var elapsed = DateTime.UtcNow - startTime;

            // Assert - Should complete in reasonable time
            Assert.True(elapsed.TotalSeconds < 1);
        }

        private static ILogEntry CreateEntry(LogLevel level, string message = "Test")
        {
            return new LogEntry(level, message, "Logger");
        }
    }
}

