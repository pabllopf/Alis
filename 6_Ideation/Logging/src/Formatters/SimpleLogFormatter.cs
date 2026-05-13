// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SimpleLogFormatter.cs
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

using System.Text;
using Alis.Core.Aspect.Logging.Abstractions;

namespace Alis.Core.Aspect.Logging.Formatters
{
    /// <summary>
    ///     Simple, human-readable log formatter.
    ///     Format: [TIME] [LEVEL] [LoggerName] Message [Exception]
    ///     AOT-compatible: Uses StringBuilder, no reflection.
    /// </summary>
    public sealed class SimpleLogFormatter : ILogFormatter
    {
        /// <summary>
        ///     Gets a human-readable name for this formatter.
        /// </summary>
        public string Name => "SimpleFormatter";


        /// <summary>
        ///     Formats a log entry into a human-readable string with the following pattern:
        ///     <c>[Timestamp] [Level] [LoggerName] Message [CorrelationId] [Scopes] [Exception]</c>.
        /// </summary>
        /// <param name="entry">The log entry to format. Must not be null.</param>
        /// <returns>A formatted string representation of the log entry.</returns>
        public string Format(ILogEntry entry)
        {
            StringBuilder sb = new StringBuilder(256);

            sb.Append('[');
            sb.Append(entry.Timestamp);
            sb.Append("] [");
            sb.Append(entry.Level);
            sb.Append("] [");
            sb.Append(entry.LoggerName);
            sb.Append("] ");
            sb.Append(entry.Message);

            if (!string.IsNullOrEmpty(entry.CorrelationId))
            {
                sb.Append(" [CorrelationId: ");
                sb.Append(entry.CorrelationId);
                sb.Append(']');
            }

            if (entry.Scopes.Count > 0)
            {
                sb.Append(" [Scopes: ");
                for (int i = 0; i < entry.Scopes.Count; i++)
                {
                    if (i > 0)
                    {
                        sb.Append(" -> ");
                    }

                    sb.Append(entry.Scopes[i]);
                }

                sb.Append(']');
            }

            if (entry.Exception != null)
            {
                sb.AppendLine();
                sb.Append("Exception: ");
                sb.AppendLine(entry.Exception.GetType().Name);
                sb.Append("Message: ");
                sb.AppendLine(entry.Exception.Message);
                sb.Append("StackTrace: ");
                sb.AppendLine(entry.Exception.StackTrace);
            }

            return sb.ToString();
        }
    }
}