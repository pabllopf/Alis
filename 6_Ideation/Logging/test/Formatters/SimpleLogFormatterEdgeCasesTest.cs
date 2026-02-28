// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: Formatters/SimpleLogFormatterEdgeCasesTest.cs
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
using Alis.Core.Aspect.Logging.Formatters;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test.Formatters
{
    /// <summary>
    ///     Edge case tests for SimpleLogFormatter.
    ///     Tests exception chains, large messages, and special scenarios.
    /// </summary>
    public class SimpleLogFormatterEdgeCasesTest
    {
        [Fact]
        public void SimpleLogFormatter_DeeplyNestedExceptionChain()
        {
            // Arrange
            var formatter = new SimpleLogFormatter();
            Exception innermost = new InvalidOperationException("Innermost");
            Exception middle = new ArgumentException("Middle", innermost);
            Exception outermost = new SystemException("Outermost", middle);

            var entry = new LogEntry(LogLevel.Error, "Error", "Logger", outermost);

            // Act
            var formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("SystemException", formatted);
            Assert.Contains("Outermost", formatted);
        }

        [Fact]
        public void SimpleLogFormatter_VeryLongExceptionMessage()
        {
            // Arrange
            var formatter = new SimpleLogFormatter();
            var longExceptionMessage = new string('E', 50000);
            var exception = new InvalidOperationException(longExceptionMessage);
            var entry = new LogEntry(LogLevel.Error, "Error", "Logger", exception);

            // Act
            var formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("InvalidOperationException", formatted);
        }

        [Fact]
        public void SimpleLogFormatter_ThirtyDeepScopes()
        {
            // Arrange
            var formatter = new SimpleLogFormatter();
            var scopes = new List<object>();
            for (int i = 0; i < 30; i++)
            {
                scopes.Add($"Level{i}");
            }
            var entry = new LogEntry(LogLevel.Info, "Message", "Logger", scopes: scopes);

            // Act
            var formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("Scopes:", formatted);
            Assert.Contains("Level0", formatted);
            Assert.Contains("Level29", formatted);
        }

        [Fact]
        public void SimpleLogFormatter_ComplexLoggerName()
        {
            // Arrange
            var formatter = new SimpleLogFormatter();
            var complexName = "MyCompany.MyProduct.MyModule.MyComponent.MyClass.MyMethod";
            var entry = new LogEntry(LogLevel.Info, "Message", complexName);

            // Act
            var formatted = formatter.Format(entry);

            // Assert
            Assert.Contains(complexName, formatted);
        }

        [Fact]
        public void SimpleLogFormatter_CorrelationIdLength()
        {
            // Arrange
            var formatter = new SimpleLogFormatter();
            var longCorrId = new string('x', 100);
            var entry = new LogEntry(LogLevel.Info, "Message", "Logger", correlationId: longCorrId);

            // Act
            var formatted = formatter.Format(entry);

            // Assert
            Assert.Contains(longCorrId, formatted);
        }

        [Fact]
        public void SimpleLogFormatter_MultilineMessage()
        {
            // Arrange
            var formatter = new SimpleLogFormatter();
            var multilineMessage = "Line 1\nLine 2\nLine 3";
            var entry = new LogEntry(LogLevel.Info, multilineMessage, "Logger");

            // Act
            var formatted = formatter.Format(entry);

            // Assert
            Assert.Contains("Line 1", formatted);
            Assert.Contains("Line 2", formatted);
            Assert.Contains("Line 3", formatted);
        }

        [Fact]
        public void SimpleLogFormatter_PerformanceWithManyScopes()
        {
            // Arrange
            var formatter = new SimpleLogFormatter();
            var scopes = new List<object>();
            for (int i = 0; i < 100; i++)
            {
                scopes.Add($"Scope{i}");
            }
            var entry = new LogEntry(LogLevel.Info, "Message", "Logger", scopes: scopes);

            var startTime = DateTime.UtcNow;

            // Act
            for (int i = 0; i < 1000; i++)
            {
                formatter.Format(entry);
            }

            var elapsed = DateTime.UtcNow - startTime;

            // Assert - Should be reasonably fast
            Assert.True(elapsed.TotalSeconds < 5);
        }

        [Fact]
        public void SimpleLogFormatter_ConsistentFormatting()
        {
            // Arrange
            var formatter = new SimpleLogFormatter();
            var entry = new LogEntry(LogLevel.Info, "Message", "Logger");

            // Act
            var format1 = formatter.Format(entry);
            System.Threading.Thread.Sleep(10); // Small delay to ensure different timestamp
            var entry2 = new LogEntry(LogLevel.Info, "Message", "Logger");
            var format2 = formatter.Format(entry2);

            // Assert - Different timestamps, same structure
            Assert.Equal(format1, format2);
        }
    }
}

