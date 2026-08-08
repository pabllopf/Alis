// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ConsoleLogOutputRemainingCoverageTests.cs
// 
//  Author:Pablo Perdomo Falcon
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
using System.IO;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Outputs;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test.Outputs
{
    /// <summary>
    /// The console log output remaining coverage tests class
    /// </summary>
    public class ConsoleLogOutputRemainingCoverageTests
    {
        /// <summary>
        /// Tests that name property returns console output
        /// </summary>
        [Fact]
        public void Name_Property_ReturnsConsoleOutput()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();
            string name = output.Name;

            Assert.Equal("ConsoleOutput", name);
        }

        /// <summary>
        /// Tests that is enabled default value is true
        /// </summary>
        [Fact]
        public void IsEnabled_DefaultValueIsTrue()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();
            bool enabled = output.IsEnabled;

            Assert.True(enabled);
        }

        /// <summary>
        /// Tests that is enabled set false get returns false
        /// </summary>
        [Fact]
        public void IsEnabled_SetFalse_GetReturnsFalse()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();
            output.IsEnabled = false;

            Assert.False(output.IsEnabled);
        }

        /// <summary>
        /// Tests that is enabled set true get returns true
        /// </summary>
        [Fact]
        public void IsEnabled_SetTrue_GetReturnsTrue()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();
            output.IsEnabled = false;
            output.IsEnabled = true;

            Assert.True(output.IsEnabled);
        }

        /// <summary>
        /// Tests that constructor with custom formatter uses provided formatter
        /// </summary>
        [Fact]
        public void Constructor_WithCustomFormatter_UsesProvidedFormatter()
        {
            TestFormatter formatter = new TestFormatter();
            ConsoleLogOutput output = new ConsoleLogOutput(formatter);
            LogEntry entry = new LogEntry(LogLevel.Info, "Test message", "Logger");

            output.Write(entry);

            Assert.True(formatter.FormatCalled);
        }

        /// <summary>
        /// Tests that constructor with null formatter uses simple log formatter by default
        /// </summary>
        [Fact]
        public void Constructor_WithNullFormatter_UsesSimpleLogFormatterByDefault()
        {
            ConsoleLogOutput output = new ConsoleLogOutput(null);
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            output.Write(entry);
        }

        /// <summary>
        /// Tests that write with valid entry does not throw
        /// </summary>
        [Fact]
        public void Write_WithValidEntry_DoesNotThrow()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();
            LogEntry entry = new LogEntry(LogLevel.Info, "Valid message", "Logger");

            output.Write(entry);
        }

        /// <summary>
        /// Tests that write after dispose does not throw
        /// </summary>
        [Fact]
        public void Write_AfterDispose_DoesNotThrow()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();
            LogEntry entry = new LogEntry(LogLevel.Info, "After dispose", "Logger");

            output.Dispose();
            output.Write(entry);
        }

        /// <summary>
        /// Tests that dispose multiple calls does not throw
        /// </summary>
        [Fact]
        public void Dispose_MultipleCalls_DoesNotThrow()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();

            output.Dispose();
            output.Dispose();
            output.Dispose();
        }

        /// <summary>
        /// Tests that dispose after write does not throw
        /// </summary>
        [Fact]
        public void Dispose_AfterWrite_DoesNotThrow()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();
            LogEntry entry = new LogEntry(LogLevel.Info, "Before dispose", "Logger");

            output.Write(entry);
            output.Dispose();
        }

        /// <summary>
        /// Tests that flush does not throw
        /// </summary>
        [Fact]
        public void Flush_DoesNotThrow()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();

            output.Flush();
        }

        /// <summary>
        /// Tests that flush after dispose does not throw
        /// </summary>
        [Fact]
        public void Flush_AfterDispose_DoesNotThrow()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();
            output.Dispose();

            output.Flush();
        }

        /// <summary>
        /// Tests that write each log level individually does not throw
        /// </summary>
        [Fact]
        public void Write_EachLogLevelIndividually_DoesNotThrow()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();

            output.Write(new LogEntry(LogLevel.Trace, "Trace", "Logger"));
            output.Write(new LogEntry(LogLevel.Debug, "Debug", "Logger"));
            output.Write(new LogEntry(LogLevel.Info, "Info", "Logger"));
            output.Write(new LogEntry(LogLevel.Warning, "Warning", "Logger"));
            output.Write(new LogEntry(LogLevel.Error, "Error", "Logger"));
            output.Write(new LogEntry(LogLevel.Critical, "Critical", "Logger"));
        }

        /// <summary>
        /// Tests that write entry with exception does not throw
        /// </summary>
        [Fact]
        public void Write_EntryWithException_DoesNotThrow()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();
            LogEntry entry = new LogEntry(LogLevel.Error, "With exception", "Logger", new InvalidOperationException("Test exception"));

            output.Write(entry);
        }

        /// <summary>
        /// Tests that write entry with null message does not throw
        /// </summary>
        [Fact]
        public void Write_EntryWithNullMessage_DoesNotThrow()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();
            LogEntry entry = new LogEntry(LogLevel.Info, null, "Logger");

            output.Write(entry);
        }

        /// <summary>
        /// Tests that write entry with correlation id does not throw
        /// </summary>
        [Fact]
        public void Write_EntryWithCorrelationId_DoesNotThrow()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();
            LogEntry entry = new LogEntry(LogLevel.Info, "With correlation", "Logger", null, "corr-123");

            output.Write(entry);
        }

        /// <summary>
        /// Tests that write when console foreground color throws on restore does not throw
        /// </summary>
        [Fact]
        public void Write_WhenConsoleForegroundColorThrowsOnRestore_DoesNotThrow()
        {
            TextWriter originalOut = Console.Out;
            ConsoleColor originalColor = Console.ForegroundColor;
            try
            {
                Console.SetOut(new StringWriter());
                ConsoleLogOutput output = new ConsoleLogOutput();
                LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

                output.Write(entry);
            }
            finally
            {
                Console.SetOut(originalOut);
                Console.ForegroundColor = originalColor;
            }
        }

        /// <summary>
        /// The test formatter class
        /// </summary>
        /// <seealso cref="ILogFormatter"/>
        internal sealed class TestFormatter : ILogFormatter
        {
            /// <summary>
            /// Gets or sets the value of the format called
            /// </summary>
            public bool FormatCalled { get; private set; }
            /// <summary>
            /// Gets the value of the name
            /// </summary>
            public string Name => "TestFormatter";

            /// <summary>
            /// Formats the entry
            /// </summary>
            /// <param name="entry">The entry</param>
            /// <returns>The string</returns>
            public string Format(ILogEntry entry)
            {
                FormatCalled = true;
                return $"TEST: {entry.Message}";
            }
        }
    }
}
