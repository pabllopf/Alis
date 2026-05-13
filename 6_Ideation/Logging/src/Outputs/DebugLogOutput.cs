// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DebugLogOutput.cs
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

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
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
        /// <summary>
        ///     The formatter used to convert log entries into strings before writing to debug output.
        /// </summary>
        private readonly ILogFormatter _formatter;

        /// <summary>
        ///     Indicates whether this instance has been disposed and should no longer accept writes.
        /// </summary>
        private bool _disposed;

        /// <summary>
        ///     Initializes a new instance of the DebugLogOutput class.
        /// </summary>
        /// <param name="formatter">The formatter to use. If null, uses a simple formatter.</param>
        public DebugLogOutput(ILogFormatter formatter = null) => _formatter = formatter ?? new SimpleLogFormatter();


        /// <summary>
        ///     Gets a human-readable identifier for this debug output.
        /// </summary>
        public string Name => "DebugOutput";


        /// <summary>
        ///     Gets or sets whether this output is currently accepting log entries.
        ///     When disabled, <see cref="Write"/> silently ignores entries.
        /// </summary>
        public bool IsEnabled { get; set; } = true;


        /// <summary>
        ///     Writes the formatted log entry to <see cref="Debug.WriteLine(string)"/>.
        ///     Only writes when a debugger is attached to avoid unnecessary overhead.
        /// </summary>
        /// <param name="entry">The log entry to format and output. Null entries are silently ignored.</param>
        [ExcludeFromCodeCoverage]
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


        /// <summary>
        ///     No-op for debug output since <see cref="Debug.WriteLine(string)"/> writes immediately.
        /// </summary>
        public void Flush()
        {
            // Debug output is already flushed
        }


        /// <summary>
        ///     Marks this instance as disposed, preventing further writes.
        ///     Safe to call multiple times.
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