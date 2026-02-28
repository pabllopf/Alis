// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: Outputs/ConsoleLogOutputEdgeCasesTest.cs
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
using Alis.Core.Aspect.Logging.Outputs;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test.Outputs
{
    /// <summary>
    ///     Edge case tests for ConsoleLogOutput.
    ///     Tests large volumes, color handling, and special characters.
    /// </summary>
    public class ConsoleLogOutputEdgeCasesTest
    {
        [Fact]
        public void ConsoleLogOutput_VeryLongMessage()
        {
            // Arrange
            var output = new ConsoleLogOutput();
            var longMessage = new string('x', 100000);
            var entry = new LogEntry(LogLevel.Info, longMessage, "Logger");

            // Act & Assert - Should not throw
            output.Write(entry);
        }

        [Fact]
        public void ConsoleLogOutput_AllColorLevels()
        {
            // Arrange
            var output = new ConsoleLogOutput();
            var levels = new[] { LogLevel.Trace, LogLevel.Debug, LogLevel.Info, LogLevel.Warning, LogLevel.Error, LogLevel.Critical };

            // Act & Assert
            foreach (var level in levels)
            {
                var entry = new LogEntry(level, $"{level} message", "Logger");
                output.Write(entry); // Should not throw
            }
        }

        [Fact]
        public void ConsoleLogOutput_RapidSequence()
        {
            // Arrange
            var output = new ConsoleLogOutput();
            var startTime = DateTime.UtcNow;

            // Act
            for (int i = 0; i < 1000; i++)
            {
                var entry = new LogEntry(LogLevel.Info, $"Rapid message {i}", "Logger");
                output.Write(entry);
            }

            var elapsed = DateTime.UtcNow - startTime;

            // Assert - Should complete quickly
            Assert.True(elapsed.TotalSeconds < 5);
        }

        [Fact]
        public void ConsoleLogOutput_UnicodeCharacters()
        {
            // Arrange
            var output = new ConsoleLogOutput();
            var entry = new LogEntry(LogLevel.Info, "Unicode: 你好 مرحبا 🎮", "Logger");

            // Act & Assert - Should not throw
            output.Write(entry);
        }

        [Fact]
        public void ConsoleLogOutput_ControlCharacters()
        {
            // Arrange
            var output = new ConsoleLogOutput();
            var entry = new LogEntry(LogLevel.Info, "Message with\nnewline\ttab\rcarriage", "Logger");

            // Act & Assert - Should not throw
            output.Write(entry);
        }

        [Fact]
        public void ConsoleLogOutput_EnableDisableToggle()
        {
            // Arrange
            var output = new ConsoleLogOutput();
            var entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            // Act & Assert - Multiple toggles should work
            for (int i = 0; i < 10; i++)
            {
                output.IsEnabled = (i % 2 == 0);
                output.Write(entry);
            }
        }

        [Fact]
        public void ConsoleLogOutput_VeryLongLoggerName()
        {
            // Arrange
            var output = new ConsoleLogOutput();
            var longName = "Namespace." + string.Join(".", new[] { "Class" });
            var entry = new LogEntry(LogLevel.Info, "Message", longName);

            // Act & Assert - Should not throw
            output.Write(entry);
        }

        [Fact]
        public void ConsoleLogOutput_PerformanceTest()
        {
            // Arrange
            var output = new ConsoleLogOutput();
            var entries = new ILogEntry[10000];
            for (int i = 0; i < 10000; i++)
            {
                entries[i] = new LogEntry(LogLevel.Info, $"Message {i}", "Logger");
            }

            var startTime = DateTime.UtcNow;

            // Act
            foreach (var entry in entries)
            {
                output.Write(entry);
            }

            var elapsed = DateTime.UtcNow - startTime;

            // Assert - Should handle 10k messages reasonably fast
            Assert.True(elapsed.TotalSeconds < 10);
        }
    }
}

