// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   LogType.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
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
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

namespace Alis.Tools
{
    /// <summary>
    ///     The log type enum
    /// </summary>
    public enum LogType
    {
        /// <summary>
        ///     The info log type
        /// </summary>
        Info,

        /// <summary>
        ///     The trace log type
        /// </summary>
        Trace,

        /// <summary>
        ///     The log log type
        /// </summary>
        Log,

        /// <summary>
        ///     The success log type
        /// </summary>
        Success,

        /// <summary>
        ///     The warning log type
        /// </summary>
        Warning,

        /// <summary>
        ///     The exception log type
        /// </summary>
        Exception
    }
}