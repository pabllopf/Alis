// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LogLevel.cs
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

namespace Alis.Core.Aspect.Logging
{
    /// <summary>
    ///     The log level enum
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        ///     The trace log level
        /// </summary>
        Trace = 0,

        /// <summary>
        ///     The info log level
        /// </summary>
        Info = 1,

        /// <summary>
        ///     The event log level
        /// </summary>
        Event = 2,

        /// <summary>
        ///     The log log level
        /// </summary>
        Log = 3,

        /// <summary>
        ///     The normal log level
        /// </summary>
        Normal = 4,

        /// <summary>
        ///     The warning log level
        /// </summary>
        Warning = 5,

        /// <summary>
        ///     The critical log level
        /// </summary>
        Critical = 6
    }
}