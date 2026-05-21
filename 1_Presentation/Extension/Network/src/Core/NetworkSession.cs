

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