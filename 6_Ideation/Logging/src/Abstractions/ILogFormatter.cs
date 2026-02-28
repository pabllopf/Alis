// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ILogFormatter.cs
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

namespace Alis.Core.Aspect.Logging.Abstractions
{
    /// <summary>
    ///     Formats log entries into a string representation suitable for output.
    ///     Different formatters can produce different output styles (JSON, plain text, etc.).
    ///     AOT-compatible: Uses StringBuilder, no reflection.
    /// </summary>
    public interface ILogFormatter
    {
        /// <summary>
        ///     Gets a human-readable name for this formatter.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     Formats the given log entry into a string.
        /// </summary>
        /// <param name="entry">The log entry to format.</param>
        /// <returns>A formatted string representation of the log entry.</returns>
        string Format(ILogEntry entry);
    }
}