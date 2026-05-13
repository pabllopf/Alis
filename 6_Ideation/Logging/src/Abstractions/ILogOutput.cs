// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ILogOutput.cs
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

namespace Alis.Core.Aspect.Logging.Abstractions
{
    /// <summary>
    ///     Defines a destination where log entries are written.
    ///     Implementations determine how and where log output is persisted, displayed, or transmitted.
    ///     All implementations must be thread-safe and handle errors gracefully without throwing.
    ///     AOT-compatible: No reflection, pure interface-based dispatch.
    /// </summary>
    public interface ILogOutput : IDisposable
    {
        /// <summary>
        ///     Gets a human-readable name for this output destination.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     Gets a value indicating whether this output is currently accepting log entries.
        ///     When false, <see cref="Write"/> should silently ignore entries.
        /// </summary>
        bool IsEnabled { get; internal set; }

        /// <summary>
        ///     Writes the given log entry to this output destination.
        ///     Implementations must be thread-safe and handle errors gracefully.
        /// </summary>
        /// <param name="entry">The log entry to write.</param>
        void Write(ILogEntry entry);

        /// <summary>
        ///     Flushes any buffered data to the output destination.
        ///     Called before application shutdown or on demand.
        /// </summary>
        void Flush();
    }
}