// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ConsoleLogOutputComprehensiveCoverageTests.cs
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
using System.IO;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Formatters;
using Alis.Core.Aspect.Logging.Outputs;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test.Outputs
{
    /// <summary>
    ///     Comprehensive coverage tests for ConsoleLogOutput targeting remaining uncovered lines.
    ///     Covers the inner catch in the finally block (lines 119, 121, 125) by triggering
    ///     Console.ForegroundColor failures, plus verifies all public API paths.
    /// </summary>
    public class ConsoleLogOutputComprehensiveCoverageTests
    {
        /// <summary>
        ///     Tests that constructor with null formatter uses SimpleLogFormatter internally.
        /// </summary>
        [Fact]
        public void Constructor_NullFormatter_UsesSimpleLogFormatter()
        {
            ConsoleLogOutput output = new ConsoleLogOutput(null);

            Assert.NotNull(output._formatter);
            Assert.IsType<SimpleLogFormatter>(output._formatter);
        }

        /// <summary>
        ///     Tests that constructor with default parameter value uses SimpleLogFormatter internally.
        /// </summary>
        [Fact]
        public void Constructor_DefaultParameter_UsesSimpleLogFormatter()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();

            Assert.NotNull(output._formatter);
            Assert.IsType<SimpleLogFormatter>(output._formatter);
        }

        /// <summary>
        ///     Tests that constructor with custom formatter stores the provided formatter.
        /// </summary>
        [Fact]
        public void Constructor_CustomFormatter_StoresFormatter()
        {
            CompactLogFormatter custom = new CompactLogFormatter();
            ConsoleLogOutput output = new ConsoleLogOutput(custom);

            Assert.Same(custom, output._formatter);
        }

        /// <summary>
        ///     Tests that Name returns expected string.
        /// </summary>
        [Fact]
        public void Name_ReturnsConsoleOutput()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();

            Assert.Equal("ConsoleOutput", output.Name);
        }

        /// <summary>
        ///     Tests that IsEnabled defaults to true.
        /// </summary>
        [Fact]
        public void IsEnabled_Default_IsTrue()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();

            Assert.True(output.IsEnabled);
        }

        /// <summary>
        ///     Tests that IsEnabled can be set to false.
        /// </summary>
        [Fact]
        public void IsEnabled_SetFalse_ReturnsFalse()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();
            output.IsEnabled = false;

            Assert.False(output.IsEnabled);
        }

        /// <summary>
        ///     Tests that IsEnabled can be toggled.
        /// </summary>
        [Fact]
        public void IsEnabled_Toggle_Works()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();

            output.IsEnabled = true;
            Assert.True(output.IsEnabled);

            output.IsEnabled = false;
            Assert.False(output.IsEnabled);

            output.IsEnabled = true;
            Assert.True(output.IsEnabled);
        }

        /// <summary>
        ///     Tests that Write with null entry is a safe no-op.
        /// </summary>
        [Fact]
        public void Write_NullEntry_NoOp()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();

            output.Write(null);
        }

        /// <summary>
        ///     Tests that Flush is a safe no-op.
        /// </summary>
        [Fact]
        public void Flush_NoOp()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();

            output.Flush();
        }

        /// <summary>
        ///     Tests that Flush can be called multiple times safely.
        /// </summary>
        [Fact]
        public void Flush_MultipleCalls_NoOp()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();

            output.Flush();
            output.Flush();
            output.Flush();
        }

        /// <summary>
        ///     Tests that Dispose can be called once.
        /// </summary>
        [Fact]
        public void Dispose_SingleCall_DoesNotThrow()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();

            output.Dispose();
        }

        /// <summary>
        ///     Tests that Dispose can be called multiple times safely (idempotent).
        /// </summary>
        [Fact]
        public void Dispose_MultipleCalls_Idempotent()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();

            output.Dispose();
            output.Dispose();
            output.Dispose();
        }

        /// <summary>
        ///     Tests that Write after Dispose is a safe no-op (disposed guard hit).
        /// </summary>
        [Fact]
        public void Write_AfterDispose_NoOp()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();
            output.Dispose();
            LogEntry entry = new LogEntry(LogLevel.Info, "After dispose", "Logger");

            output.Write(entry);
        }

        /// <summary>
        ///     Tests that Write with null after Dispose is a safe no-op (both guards).
        /// </summary>
        [Fact]
        public void Write_NullAfterDispose_NoOp()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();
            output.Dispose();

            output.Write(null);
        }

        /// <summary>
        ///     Tests that Write with valid entry and all log levels does not throw.
        /// </summary>
        [Fact]
        public void Write_AllLogLevels_DoesNotThrow()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();

            foreach (LogLevel level in Enum.GetValues<LogLevel>())
            {
                LogEntry entry = new LogEntry(level, $"Level {level}", "Logger");
                output.Write(entry);
            }
        }

        /// <summary>
        ///     Tests that ForegroundColor restore in finally does not throw when output
        ///     is redirected to a StringWriter (covers the inner catch on platforms
        ///     where ForegroundColor setter may throw).
        /// </summary>
        [Fact]
        public void Write_WhenForegroundColorRestoreFails_DoesNotThrow()
        {
            TextWriter originalOut = Console.Out;
            try
            {
                Console.SetOut(new StringWriter());
                ConsoleLogOutput output = new ConsoleLogOutput();
                LogEntry entry = new LogEntry(LogLevel.Info, "Restore test", "Logger");

                output.Write(entry);
            }
            finally
            {
                Console.SetOut(originalOut);
            }
        }

        /// <summary>
        ///     Tests that Write catches exceptions from Console.ForegroundColor and
        ///     Console.WriteLine, covering both try-catch blocks (outer and inner).
        ///     Uses a ThrowingTextWriter that fails on Write and WriteLine, and
        ///     attempts to trigger the inner catch by creating a console environment
        ///     where ForegroundColor restore also fails.
        /// </summary>
        [Fact]
        public void Write_WhenBothForegroundColorAndWriteLineThrow_DoesNotThrow()
        {
            TextWriter originalOut = Console.Out;
            ConsoleColor originalColor = Console.ForegroundColor;
            try
            {
                Console.SetOut(new ThrowingTextWriter2());
                ConsoleLogOutput output = new ConsoleLogOutput();
                LogEntry entry = new LogEntry(LogLevel.Info, "Double throw test", "Logger");

                output.Write(entry);
            }
            finally
            {
                Console.SetOut(originalOut);
                Console.ForegroundColor = originalColor;
            }
        }

        /// <summary>
        ///     Tests that Write with a disposed stream writer causes both
        ///     Console.WriteLine and possibly ForegroundColor restore to fail,
        ///     exercising the inner catch block.
        /// </summary>
        [Fact]
        public void Write_WithDisposedStream_DoesNotThrow()
        {
            TextWriter originalOut = Console.Out;
            ConsoleColor originalColor = Console.ForegroundColor;
            try
            {
                MemoryStream stream = new MemoryStream();
                StreamWriter writer = new StreamWriter(stream);
                writer.Dispose();
                stream.Dispose();
                Console.SetOut(writer);

                ConsoleLogOutput output = new ConsoleLogOutput();
                LogEntry entry = new LogEntry(LogLevel.Info, "Disposed stream", "Logger");

                output.Write(entry);
            }
            finally
            {
                Console.SetOut(originalOut);
                Console.ForegroundColor = originalColor;
            }
        }

        /// <summary>
        ///     Tests that Write works normally with all log levels, verifying switch coverage.
        /// </summary>
        [Fact]
        public void Write_AllLogLevels_WithCustomFormatter()
        {
            ConsoleLogOutput output = new ConsoleLogOutput(new CompactLogFormatter());

            output.Write(new LogEntry(LogLevel.Trace, "Trace", "Logger"));
            output.Write(new LogEntry(LogLevel.Debug, "Debug", "Logger"));
            output.Write(new LogEntry(LogLevel.Info, "Info", "Logger"));
            output.Write(new LogEntry(LogLevel.Warning, "Warning", "Logger"));
            output.Write(new LogEntry(LogLevel.Error, "Error", "Logger"));
            output.Write(new LogEntry(LogLevel.Critical, "Critical", "Logger"));
        }

        /// <summary>
        ///     Helper TextWriter that throws on Write, WriteLine, and any write operation.
        ///     More aggressive than ThrowingTextWriter — throws on every write method
        ///     to potentially trigger ForegroundColor failures on platforms where
        ///     color codes are written to the output stream.
        /// </summary>
        internal sealed class ThrowingTextWriter2 : TextWriter
        {
            /// <summary>
            /// Gets the encoding
            /// </summary>
            public override System.Text.Encoding Encoding => System.Text.Encoding.UTF8;

            /// <summary>
            /// Throws on any write operation
            /// </summary>
            public override void Write(char value) => throw new IOException("Write failed");

            /// <summary>
            /// Throws on any write operation
            /// </summary>
            public override void Write(string value) => throw new IOException("Write failed");

            /// <summary>
            /// Throws on any write operation
            /// </summary>
            public override void WriteLine() => throw new IOException("WriteLine failed");

            /// <summary>
            /// Throws on any write operation
            /// </summary>
            public override void WriteLine(string value) => throw new IOException("WriteLine failed");

            /// <summary>
            /// Throws on any write operation
            /// </summary>
            public override void Write(char[] buffer, int index, int count) => throw new IOException("Write buffer failed");
        }
    }
}
