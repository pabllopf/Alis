// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: DebugLogOutput.cs
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

using System.Diagnostics;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Formatters;

namespace Alis.Core.Aspect.Logging.Outputs
{
    /// <summary>
    ///     Writes log entries to the debugger output (Debug.WriteLine).
    ///     Only writes output when debugger is attached.
    ///     Useful for development-time debugging.
    ///     AOT-compatible: Uses Debug.WriteLine, no reflection.
    /// </summary>
    public sealed class DebugLogOutput : ILogOutput
    {
        private readonly ILogFormatter _formatter;
        private bool _disposed;

        /// <summary>
        ///     Initializes a new instance of the DebugLogOutput class.
        /// </summary>
        /// <param name="formatter">The formatter to use. If null, uses a simple formatter.</param>
        public DebugLogOutput(ILogFormatter formatter = null)
        {
            _formatter = formatter ?? new SimpleLogFormatter();
        }

        /// <inheritdoc />
        public string Name => "DebugOutput";

        /// <inheritdoc />
        public bool IsEnabled { get; set; } = true;

        /// <inheritdoc />
        public void Write(ILogEntry entry)
        {
            if (entry == null || _disposed || !Debugger.IsAttached)
            {
                return;
            }

            try
            {
                string formatted = _formatter.Format(entry);
                Debug.WriteLine(formatted);
            }
            catch
            {
                // Prevent debug write failures from propagating
            }
        }

        /// <inheritdoc />
        public void Flush()
        {
            // Debug output is already flushed
        }

        /// <inheritdoc />
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

