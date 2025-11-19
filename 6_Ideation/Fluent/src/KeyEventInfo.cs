// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:KeyEventInfo.cs
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

namespace Alis.Core.Aspect.Fluent
{
    /// <summary>
    ///     The key event info
    /// </summary>
    public struct KeyEventInfo
    {
        /// <summary>
        ///     The key
        /// </summary>
        public ConsoleKey Key;

        /// <summary>
        ///     The timestamp
        /// </summary>
        public DateTime Timestamp;

        /// <summary>
        ///     The hold duration
        /// </summary>
        public TimeSpan HoldDuration;

        /// <summary>
        ///     Initializes a new instance of the <see cref="KeyEventInfo" /> class
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="timestamp">The timestamp</param>
        /// <param name="holdDuration">The hold duration</param>
        public KeyEventInfo(ConsoleKey key, DateTime timestamp, TimeSpan holdDuration)
        {
            Key = key;
            Timestamp = timestamp;
            HoldDuration = holdDuration;
        }
    }
}