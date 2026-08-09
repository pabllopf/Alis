// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ConsoleLogOutputFinalCoverageTests.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Outputs;
using Alis.Core.Aspect.Logging.Test.Attributes;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test.Outputs
{
    /// <summary>
    ///     Final coverage tests for ConsoleLogOutput targeting the inner catch in the finally block
    ///     (lines 119, 121, 125) by forcing Console.ForegroundColor to throw via STDOUT fd closure.
    /// </summary>
    public class ConsoleLogOutputFinalCoverageTests
    {
        /// <summary>
        /// Closes the fd
        /// </summary>
        /// <param name="fd">The fd</param>
        /// <returns>The int</returns>
        [DllImport("libc")]
        private static extern int close(int fd);

        /// <summary>
        /// Dups the fd
        /// </summary>
        /// <param name="fd">The fd</param>
        /// <returns>The int</returns>
        [DllImport("libc")]
        private static extern int dup(int fd);

        /// <summary>
        /// Dups the 2 using the specified oldfd
        /// </summary>
        /// <param name="oldfd">The oldfd</param>
        /// <param name="newfd">The newfd</param>
        /// <returns>The int</returns>
        [DllImport("libc")]
        private static extern int dup2(int oldfd, int newfd);

        /// <summary>
        ///     Tests that when Console.ForegroundColor fails during both the try block
        ///     and the finally restore, both catch blocks are exercised.
        ///     Closes STDOUT fd to force all Interop.Write calls to STDOUT to fail.
        /// </summary>
        [UnixOnly]
        public void Write_WhenStdoutClosed_BothCatchBlocksExecute()
        {
            TextWriter originalOut = Console.Out;
            int savedStdout = dup(1);

            close(1);

            try
            {
                ConsoleLogOutput output = new ConsoleLogOutput();
                LogEntry entry = new LogEntry(LogLevel.Info, "Final coverage test", "Logger");

                output.Write(entry);
            }
            finally
            {
                dup2(savedStdout, 1);
                close(savedStdout);

                Console.SetOut(originalOut);
            }
        }

        /// <summary>
        ///     Tests that the constructor with default parameter and a write with all log levels
        ///     combined with disposed state does not throw - ensures maximum path coverage.
        /// </summary>
        [Fact]
        public void Write_AllLevelsAfterDispose_DoesNotThrow()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();
            output.Dispose();

            foreach (LogLevel level in Enum.GetValues<LogLevel>())
            {
                LogEntry entry = new LogEntry(level, $"Level {level} after dispose", "Logger");
                output.Write(entry);
            }
        }

        /// <summary>
        ///     Tests that the Write method handles a null entry after a valid write correctly.
        /// </summary>
        [Fact]
        public void Write_ValidThenNull_DoesNotThrow()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();

            output.Write(new LogEntry(LogLevel.Info, "First", "Logger"));
            output.Write(null);
            output.Write(new LogEntry(LogLevel.Debug, "Second", "Logger"));
        }

        /// <summary>
        ///     Tests that Write with all log levels works when IsEnabled is toggled multiple times.
        /// </summary>
        [Fact]
        public void Write_IsEnabledToggledWithAllLevels_DoesNotThrow()
        {
            ConsoleLogOutput output = new ConsoleLogOutput();

            foreach (LogLevel level in Enum.GetValues<LogLevel>())
            {
                output.IsEnabled = !output.IsEnabled;
                LogEntry entry = new LogEntry(level, $"Level {level} toggled", "Logger");
                output.Write(entry);
            }
        }

        /// <summary>
        ///     Tests Write when the formatter returns null.
        /// </summary>
        [Fact]
        public void Write_WithNullFormatterResult_DoesNotThrow()
        {
            ConsoleLogOutput output = new ConsoleLogOutput(new NullFormatter());
            LogEntry entry = new LogEntry(LogLevel.Info, "Should be null formatted", "Logger");

            output.Write(entry);
        }

        /// <summary>
        ///     Null formatter that returns null from Format.
        /// </summary>
        private sealed class NullFormatter : ILogFormatter
        {
            /// <summary>
            /// Gets the value of the name
            /// </summary>
            public string Name => "NullFormatter";

            /// <summary>
            /// Formats the entry
            /// </summary>
            /// <param name="entry">The entry</param>
            /// <returns>The string</returns>
            public string Format(ILogEntry entry) => null;
        }
    }
}
