

using System;

namespace Alis.Extension.Network.Core
{
    /// <summary>
    ///     Configuration for multiplayer network sessions
    /// </summary>
    public class NetworkConfig
    {
        /// <summary>
        ///     Maximum players per session
        /// </summary>
        public int MaxPlayers { get; set; } = 32;

        /// <summary>
        ///     Network tick rate in Hz
        /// </summary>
        public int TickRate { get; set; } = 60;

        /// <summary>
        ///     Server tick interval
        /// </summary>
        public TimeSpan TickInterval => TimeSpan.FromSeconds(1.0 / TickRate);

        /// <summary>
        ///     Enable server authority
        /// </summary>
        public bool ServerAuthoritative { get; set; } = true;

        /// <summary>
        ///     Connection timeout
        /// </summary>
        public TimeSpan ConnectionTimeout { get; set; } = TimeSpan.FromSeconds(30);

        /// <summary>
        ///     Heartbeat interval
        /// </summary>
        public TimeSpan HeartbeatInterval { get; set; } = TimeSpan.FromSeconds(5);

        /// <summary>
        ///     Enable client-side prediction
        /// </summary>
        public bool EnableClientPrediction { get; set; } = true;

        /// <summary>
        ///     Enable lag compensation
        /// </summary>
        public bool EnableLagCompensation { get; set; } = true;

        /// <summary>
        ///     Maximum message buffer size in bytes
        /// </summary>
        public int MaxMessageSize { get; set; } = 1024 * 64; // 64KB
    }
}