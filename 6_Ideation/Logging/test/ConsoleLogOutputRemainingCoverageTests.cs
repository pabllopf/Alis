// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ConsoleLogOutputRemainingCoverageTests.cs
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
using System.Text;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Outputs;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     The console log output remaining coverage tests class
    /// </summary>
    public class ConsoleLogOutputRemainingCoverageTests : IDisposable
    {
        /// <summary>
        ///     The original out
        /// </summary>
        private readonly TextWriter _originalOut = Console.Out;

        /// <summary>
        ///     Tests that write with throwing console output swallows exception
        /// </summary>
        [Fact]
        public void Write_WithThrowingConsoleOutput_SwallowsException()
        {
            Console.SetOut(new ThrowingTextWriter());
            ConsoleLogOutput output = new ConsoleLogOutput();

            output.Write(new LogEntry(LogLevel.Info, "message", "logger"));
            output.Write(new LogEntry(LogLevel.Debug, "debug message", "logger"));
                    }

        /// <summary>
        ///     The throwing text writer class
        /// </summary>
        /// <seealso cref="TextWriter"/>
        private class ThrowingTextWriter : TextWriter
        {
            /// <summary>
            ///     Gets the value of the encoding
            /// </summary>
            public override Encoding Encoding => Encoding.UTF8;

            /// <summary>
            ///     Writes the specified value
            /// </summary>
            /// <param name="value">The value</param>
            public override void Write(string value) => throw new IOException("console failure");
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose() => Console.SetOut(_originalOut);
    }
}
