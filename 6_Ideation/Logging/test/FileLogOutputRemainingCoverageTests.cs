// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FileLogOutputRemainingCoverageTests.cs
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
using Alis.Core.Aspect.Logging.Outputs;
using Alis.Core.Aspect.Logging.Core;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     The file log output remaining coverage tests class
    /// </summary>
    public class FileLogOutputRemainingCoverageTests
    {
        /// <summary>
        ///     The throwing formatter class
        /// </summary>
        /// <seealso cref="ILogFormatter"/>
        private class ThrowingFormatter : ILogFormatter
        {
            /// <summary>
            ///     Gets the value of the name
            /// </summary>
            public string Name => "ThrowingFormatter";

            /// <summary>
            ///     Formats the specified entry
            /// </summary>
            /// <param name="entry">The entry</param>
            /// <returns>The string</returns>
            public string Format(ILogEntry entry) => throw new InvalidOperationException("format failed");
        }

        /// <summary>
        ///     Tests that write with throwing formatter swallows exception
        /// </summary>
        [Fact]
        public void Write_WithThrowingFormatter_SwallowsException()
        {
            string path = Path.Combine(Path.GetTempPath(), $"flog_{Guid.NewGuid():N}.log");
            FileLogOutput output = new FileLogOutput(path, new ThrowingFormatter());
            try
            {
                output.Write(new LogEntry(LogLevel.Info, "test", "logger"));

                Assert.True(output.IsEnabled);
            }
            finally
            {
                output.Dispose();
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that write with null writer does not throw
        /// </summary>
        [Fact]
        public void Write_WithNullEntry_DoesNotThrow()
        {
            string path = Path.Combine(Path.GetTempPath(), $"flog_{Guid.NewGuid():N}.log");
            FileLogOutput output = new FileLogOutput(path);
            try
            {
                output.Write(null);
            }
            finally
            {
                output.Dispose();
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }
    }
}
