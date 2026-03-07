// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ConsoleLogOutput.cs
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
using System.Diagnostics.CodeAnalysis;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Formatters;

namespace Alis.Core.Aspect.Logging.Outputs
{
    /// <summary>
    ///     Writes log entries to the standard console output.
    ///     Uses colored output when available based on log level.
    ///     Thread-safe: Console.WriteLine is thread-safe in .NET.
    ///     AOT-compatible: No reflection, simple console I/O.
    /// </summary>
    public sealed class ConsoleLogOutput : ILogOutput
    {
        /// <summary>
        /// The formatter
        /// </summary>
        private readonly ILogFormatter _formatter;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        ///     Initializes a new instance of the ConsoleLogOutput class.
        /// </summary>
        /// <param name="formatter">The formatter to use for log entries. If null, uses a simple formatter.</param>
        public ConsoleLogOutput(ILogFormatter formatter = null) => _formatter = formatter ?? new SimpleLogFormatter();

        
        /// <summary>
        /// Gets the value of the name
        /// </summary>
        public string Name => "ConsoleOutput";

        
        /// <summary>
        /// Gets or sets the value of the is enabled
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        
        /// <summary>
        /// Writes the entry
        /// </summary>
        /// <param name="entry">The entry</param>
        [ExcludeFromCodeCoverage]
        public void Write(ILogEntry entry)
        {
            if (entry == null || _disposed)
            {
                return;
            }

            string formatted = _formatter.Format(entry);
            ConsoleColor originalColor = Console.ForegroundColor;

            try
            {
                // Set color based on level
                Console.ForegroundColor = entry.Level switch
                {
                    LogLevel.Trace => ConsoleColor.Gray,
                    LogLevel.Debug => ConsoleColor.Cyan,
                    LogLevel.Info => ConsoleColor.White,
                    LogLevel.Warning => ConsoleColor.Yellow,
                    LogLevel.Error => ConsoleColor.Red,
                    LogLevel.Critical => ConsoleColor.Magenta,
                    _ => ConsoleColor.White
                };

                Console.WriteLine(formatted);
            }
            catch
            {
                // Prevent console failures from propagating
            }
            finally
            {
                try
                {
                    Console.ForegroundColor = originalColor;
                }
                catch
                {
                    // Ignore color reset failures
                }
            }
        }

        
        /// <summary>
        /// Flushes this instance
        /// </summary>
        public void Flush()
        {
            // Console output is already flushed by WriteLine
        }

        
        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _disposed = true;
        }
    }
}