// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SimpleLogFormatterEdgeCasesTest.cs
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


using System;
using System.Collections.Generic;
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
        /// <summary>
        ///     Tests that simple log formatter deeply nested exception chain
        /// </summary>
        [Fact]
        public void SimpleLogFormatter_DeeplyNestedExceptionChain()
        {
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            Exception innermost = new InvalidOperationException("Innermost");
            Exception middle = new ArgumentException("Middle", innermost);
            Exception outermost = new SystemException("Outermost", middle);

            LogEntry entry = new LogEntry(LogLevel.Error, "Error", "Logger", outermost);

            string formatted = formatter.Format(entry);

            Assert.Contains("SystemException", formatted);
            Assert.Contains("Outermost", formatted);
        }

        /// <summary>
        ///     Tests that simple log formatter very long exception message
        /// </summary>
        [Fact]
        public void SimpleLogFormatter_VeryLongExceptionMessage()
        {
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            string longExceptionMessage = new string('E', 50000);
            InvalidOperationException exception = new InvalidOperationException(longExceptionMessage);
            LogEntry entry = new LogEntry(LogLevel.Error, "Error", "Logger", exception);

            string formatted = formatter.Format(entry);

            Assert.Contains("InvalidOperationException", formatted);
        }

        /// <summary>
        ///     Tests that simple log formatter thirty deep scopes
        /// </summary>
        [Fact]
        public void SimpleLogFormatter_ThirtyDeepScopes()
        {
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            List<object> scopes = new List<object>();
            for (int i = 0; i < 30; i++)
            {
                scopes.Add($"Level{i}");
            }

            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", scopes: scopes);

            string formatted = formatter.Format(entry);

            Assert.Contains("Scopes:", formatted);
            Assert.Contains("Level0", formatted);
            Assert.Contains("Level29", formatted);
        }

        /// <summary>
        ///     Tests that simple log formatter complex logger name
        /// </summary>
        [Fact]
        public void SimpleLogFormatter_ComplexLoggerName()
        {
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            string complexName = "MyCompany.MyProduct.MyModule.MyComponent.MyClass.MyMethod";
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", complexName);

            string formatted = formatter.Format(entry);

            Assert.Contains(complexName, formatted);
        }

        /// <summary>
        ///     Tests that simple log formatter correlation id length
        /// </summary>
        [Fact]
        public void SimpleLogFormatter_CorrelationIdLength()
        {
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            string longCorrId = new string('x', 100);
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", correlationId: longCorrId);

            string formatted = formatter.Format(entry);

            Assert.Contains(longCorrId, formatted);
        }

        /// <summary>
        ///     Tests that simple log formatter multiline message
        /// </summary>
        [Fact]
        public void SimpleLogFormatter_MultilineMessage()
        {
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            string multilineMessage = "Line 1\nLine 2\nLine 3";
            LogEntry entry = new LogEntry(LogLevel.Info, multilineMessage, "Logger");

            string formatted = formatter.Format(entry);

            Assert.Contains("Line 1", formatted);
            Assert.Contains("Line 2", formatted);
            Assert.Contains("Line 3", formatted);
        }

        /// <summary>
        ///     Tests that simple log formatter performance with many scopes
        /// </summary>
        [Fact]
        public void SimpleLogFormatter_PerformanceWithManyScopes()
        {
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            List<object> scopes = new List<object>();
            for (int i = 0; i < 100; i++)
            {
                scopes.Add($"Scope{i}");
            }

            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", scopes: scopes);

            DateTime startTime = DateTime.UtcNow;

            for (int i = 0; i < 1000; i++)
            {
                formatter.Format(entry);
            }

            TimeSpan elapsed = DateTime.UtcNow - startTime;

            Assert.True(elapsed.TotalSeconds < 5);
        }
    }
}