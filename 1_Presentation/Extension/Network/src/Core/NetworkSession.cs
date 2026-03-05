// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkSession.cs
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
    ///     Represents a network game session with players
    /// </summary>
    public class NetworkSession
    {
        /// <summary>
        ///     Session identifier
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        ///     Session name
        /// </summary>
        public string SessionName { get; set; }

        /// <summary>
        ///     Session owner player ID
        /// </summary>
        public string OwnerId { get; set; }

        /// <summary>
        ///     Current player count
        /// </summary>
        public int PlayerCount { get; set; }

        /// <summary>
        ///     Maximum players allowed
        /// </summary>
        public int MaxPlayers { get; set; }

        /// <summary>
        ///     Session state
        /// </summary>
        public SessionState State { get; set; }

        /// <summary>
        ///     Creation timestamp
        /// </summary>
        public long CreatedAt { get; set; }

        /// <summary>
        ///     Custom session data
        /// </summary>
        public Dictionary<string, string> CustomData { get; set; } = new Dictionary<string, string>();

        /// <summary>
        ///     Connected players
        /// </summary>
        public List<NetworkPlayer> Players { get; set; } = new List<NetworkPlayer>();

        /// <summary>
        ///     Gets session creation time
        /// </summary>
        public DateTime CreatedDateTime => UnixTimeStampToDateTime(CreatedAt);

        /// <summary>
        /// Unixes the time stamp to date time using the specified unix time stamp
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

    /// <summary>
    ///     Session state enumeration
    /// </summary>
    public enum SessionState
    {
        /// <summary>
        ///     Waiting for players
        /// </summary>
        Waiting,

        /// <summary>
        ///     Game in progress
        /// </summary>
        InProgress,

        /// <summary>
        ///     Game finished
        /// </summary>
        Finished,

        /// <summary>
        ///     Session closed
        /// </summary>
        Closed
    }
}

