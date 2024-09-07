// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MessageType.cs
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
    ///     The message type enum
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        ///     The trace message type
        /// </summary>
        Trace = 0,

        /// <summary>
        ///     The info message type
        /// </summary>
        Info = 1,

        /// <summary>
        ///     The log message type
        /// </summary>
        Log = 2,

        /// <summary>
        ///     The event message type
        /// </summary>
        Event = 3,

        /// <summary>
        ///     The warning message type
        /// </summary>
        Warning = 4,

        /// <summary>
        ///     The error message type
        /// </summary>
        Error = 5,

        /// <summary>
        ///     The exception message type
        /// </summary>
        Exception = 6
    }
}