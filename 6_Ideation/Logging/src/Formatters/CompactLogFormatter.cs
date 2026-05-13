// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CompactLogFormatter.cs
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

using System.Diagnostics.CodeAnalysis;
using System.Text;
using Alis.Core.Aspect.Logging.Abstractions;

namespace Alis.Core.Aspect.Logging.Formatters
{
    /// <summary>
    ///     Compact log formatter optimized for performance in game loops.
    ///     Format: [L] Message
    ///     Minimal output, just level and message for maximum performance.
    ///     AOT-compatible: Uses StringBuilder, no reflection.
    /// </summary>
    public sealed class CompactLogFormatter : ILogFormatter
    {
        /// <summary>
        ///     Gets the value of the name
        /// </summary>
        public string Name => "CompactFormatter";


        /// <summary>
        ///     Formats the entry
        /// </summary>
        /// <param name="entry">The entry</param>
        /// <returns>The string</returns>
        [ExcludeFromCodeCoverage]
        public string Format(ILogEntry entry)
        {
            StringBuilder sb = new StringBuilder(128);

            sb.Append('[');
            sb.Append(entry.Level switch
            {
                LogLevel.Trace => 'T',
                LogLevel.Debug => 'D',
                LogLevel.Info => 'I',
                LogLevel.Warning => 'W',
                LogLevel.Error => 'E',
                LogLevel.Critical => 'C',
                _ => '?'
            });
            sb.Append("] ");
            sb.Append(entry.Message);

            if (entry.Exception != null)
            {
                sb.Append(" [EXC: ");
                sb.Append(entry.Exception.Message);
                sb.Append(']');
            }

            return sb.ToString();
        }
    }
}