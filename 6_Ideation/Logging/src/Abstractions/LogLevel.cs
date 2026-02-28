// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: LogLevel.cs
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

namespace Alis.Core.Aspect.Logging.Abstractions
{
    /// <summary>
    ///     Enumeration of log levels for categorizing log entries.
    ///     Follows standard logging severity levels from lowest to highest.
    /// </summary>
    public enum LogLevel : byte
    {
        /// <summary>
        ///     Trace level: Most detailed, for diagnostic information.
        /// </summary>
        Trace = 0,

        /// <summary>
        ///     Debug level: Information useful for development and debugging.
        /// </summary>
        Debug = 1,

        /// <summary>
        ///     Info level: General informational messages.
        /// </summary>
        Info = 2,

        /// <summary>
        ///     Warning level: Warning messages for potentially problematic situations.
        /// </summary>
        Warning = 3,

        /// <summary>
        ///     Error level: Error messages for serious problems.
        /// </summary>
        Error = 4,

        /// <summary>
        ///     Critical level: Critical errors requiring immediate attention.
        /// </summary>
        Critical = 5,

        /// <summary>
        ///     None: Special level to disable logging.
        /// </summary>
        None = 255
    }
}

