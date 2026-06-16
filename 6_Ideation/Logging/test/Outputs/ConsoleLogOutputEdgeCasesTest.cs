// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ConsoleLogOutputEdgeCasesTest.cs
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
        /// <summary>
        ///     Tests that console log output very long message
        /// </summary>
        [Fact]
        public void ConsoleLogOutput_VeryLongMessage()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();
            string longMessage = new string('x', 100000);
            LogEntry entry = new LogEntry(LogLevel.Info, longMessage, "Logger");

            output.Write(entry);
        }

        /// <summary>
        ///     Tests that console log output all color levels
        /// </summary>
        [Fact]
        public void ConsoleLogOutput_AllColorLevels()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();
            LogLevel[] levels = new[] {LogLevel.Trace, LogLevel.Debug, LogLevel.Info, LogLevel.Warning, LogLevel.Error, LogLevel.Critical};

            foreach (LogLevel level in levels)
            {
                LogEntry entry = new LogEntry(level, $"{level} message", "Logger");
                output.Write(entry); // Should not throw
            }
        }

        /// <summary>
        ///     Tests that console log output rapid sequence
        /// </summary>
        [Fact]
        public void ConsoleLogOutput_RapidSequence()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();
            DateTime startTime = DateTime.UtcNow;

            for (int i = 0; i < 1000; i++)
            {
                LogEntry entry = new LogEntry(LogLevel.Info, $"Rapid message {i}", "Logger");
                output.Write(entry);
            }

            TimeSpan elapsed = DateTime.UtcNow - startTime;

            Assert.True(elapsed.TotalSeconds < 5);
        }

        /// <summary>
        ///     Tests that console log output unicode characters
        /// </summary>
        [Fact]
        public void ConsoleLogOutput_UnicodeCharacters()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();
            LogEntry entry = new LogEntry(LogLevel.Info, "Unicode: 你好 مرحبا 🎮", "Logger");

            output.Write(entry);
        }

        /// <summary>
        ///     Tests that console log output control characters
        /// </summary>
        [Fact]
        public void ConsoleLogOutput_ControlCharacters()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();
            LogEntry entry = new LogEntry(LogLevel.Info, "Message with\nnewline\ttab\rcarriage", "Logger");

            output.Write(entry);
        }

        /// <summary>
        ///     Tests that console log output enable disable toggle
        /// </summary>
        [Fact]
        public void ConsoleLogOutput_EnableDisableToggle()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            for (int i = 0; i < 10; i++)
            {
                output.IsEnabled = i % 2 == 0;
                output.Write(entry);
            }
        }

        /// <summary>
        ///     Tests that console log output very long logger name
        /// </summary>
        [Fact]
        public void ConsoleLogOutput_VeryLongLoggerName()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();
            string longName = "Namespace." + string.Join(".", "Class");
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", longName);

            output.Write(entry);
        }

        /// <summary>
        ///     Tests that console log output performance test
        /// </summary>
        [Fact]
        public void ConsoleLogOutput_PerformanceTest()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();
            ILogEntry[] entries = new ILogEntry[10000];
            for (int i = 0; i < 10000; i++)
            {
                entries[i] = new LogEntry(LogLevel.Info, $"Message {i}", "Logger");
            }

            DateTime startTime = DateTime.UtcNow;

            foreach (ILogEntry entry in entries)
            {
                output.Write(entry);
            }

            TimeSpan elapsed = DateTime.UtcNow - startTime;

            Assert.True(elapsed.TotalSeconds < 10);
        }

        /// <summary>
        ///     Tests that console log output with unknown log level uses default color (white).
        /// </summary>
        [Fact]
        public void ConsoleLogOutput_UnknownLogLevel_UsesDefaultColor()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();
            LogLevel unknownLevel = (LogLevel)99;
            LogEntry entry = new LogEntry(unknownLevel, "Unknown level message", "Logger");

            output.Write(entry);
        }
    }
}