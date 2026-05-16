// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkPlayer.cs
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
using System.Collections.Generic;

namespace Alis.Extension.Network.Core
{
    /// <summary>
    ///     Represents a network player in a session
    /// </summary>
    public class NetworkPlayer
    {
        /// <summary>
        ///     Player identifier
        /// </summary>
        public string PlayerId { get; set; }

        /// <summary>
        ///     Player name
        /// </summary>
        public string PlayerName { get; set; }

        /// <summary>
        ///     Is host/owner
        /// </summary>
        public bool IsHost { get; set; }

        /// <summary>
        ///     Player connection state
        /// </summary>
        public PlayerConnectionState ConnectionState { get; set; }

        /// <summary>
        ///     Join timestamp
        /// </summary>
        public long JoinedAt { get; set; }

        /// <summary>
        ///     Last activity timestamp
        /// </summary>
        public long LastActivityAt { get; set; }

        /// <summary>
        ///     Network latency in milliseconds
        /// </summary>
        public int Latency { get; set; }

        /// <summary>
        ///     Custom player data
        /// </summary>
        public Dictionary<string, string> CustomData { get; set; } = new Dictionary<string, string>();

        /// <summary>
        ///     Gets join time as a local DateTime
        /// </summary>
        public DateTime JoinedDateTime => UnixTimeStampToDateTime(JoinedAt);

        /// <summary>
        ///     Unixes the time stamp to date time using the specified unix time stamp
        /// </summary>
        /// <param name="unixTimeStamp">The unix time stamp</param>
        /// <returns>The date time</returns>
        private static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
    }
}