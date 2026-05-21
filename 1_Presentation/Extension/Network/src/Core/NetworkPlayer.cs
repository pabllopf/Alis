

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
        ///     Gets join time
        /// </summary>
        public DateTime JoinedDateTime => UnixTimeStampToDateTime(JoinedAt);

        /// <summary>
        ///     Unixes the time stamp to date time using the specified unix time stamp
        /// </summary>
        /// <param name="unixTimeStamp">The unix time stamp</param>
        /// <returns>The date time</returns>
#if NET5_0_OR_GREATER
          private static DateTime UnixTimeStampToDateTime(long unixTimeStamp) =>
            DateTime.UnixEpoch.AddSeconds(unixTimeStamp).ToLocalTime();
#else
        private static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTimeStamp).ToLocalTime();
        }
#endif
    }
}