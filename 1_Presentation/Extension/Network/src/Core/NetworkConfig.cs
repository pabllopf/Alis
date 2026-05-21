// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkConfig.cs
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