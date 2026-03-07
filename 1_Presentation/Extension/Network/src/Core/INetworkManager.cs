// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:INetworkManager.cs
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
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Network.Core
{
    /// <summary>
    ///     Main network manager for multiplayer games
    /// </summary>
    public interface INetworkManager : IDisposable
    {
        /// <summary>
        ///     Gets manager identifier
        /// </summary>
        string Id { get; }

        /// <summary>
        ///     Gets current network state
        /// </summary>
        NetworkManagerState State { get; }

        /// <summary>
        ///     Gets current session or null if not connected
        /// </summary>
        NetworkSession CurrentSession { get; }

        /// <summary>
        ///     Gets local player or null if not connected
        /// </summary>
        NetworkPlayer LocalPlayer { get; }

        /// <summary>
        ///     Gets configuration
        /// </summary>
        NetworkConfig Config { get; }

        /// <summary>
        ///     Initializes manager
        /// </summary>
        Task InitializeAsync(NetworkConfig config, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Starts networking
        /// </summary>
        Task StartAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Stops networking
        /// </summary>
        Task StopAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Sends message to specific player
        /// </summary>
        Task SendMessageAsync<T>(string targetPlayerId, string channel, T message, bool reliable = true) where T : IJsonSerializable;

        /// <summary>
        ///     Broadcasts message to all players
        /// </summary>
        Task BroadcastMessageAsync<T>(string channel, T message, bool reliable = true, string exceptPlayerId = null) where T : IJsonSerializable;

        /// <summary>
        ///     Registers message handler
        /// </summary>
        void RegisterMessageHandler(string channel, Func<string, string, Task> handler);

        /// <summary>
        ///     Unregisters message handler
        /// </summary>
        void UnregisterMessageHandler(string channel);

        /// <summary>
        ///     Gets all connected players
        /// </summary>
        IReadOnlyList<NetworkPlayer> GetConnectedPlayers();

        /// <summary>
        ///     Gets player by ID
        /// </summary>
        NetworkPlayer GetPlayer(string playerId);

        /// <summary>
        ///     Occurs when player joins
        /// </summary>
        event EventHandler<PlayerEventArgs> PlayerJoined;

        /// <summary>
        ///     Occurs when player leaves
        /// </summary>
        event EventHandler<PlayerEventArgs> PlayerLeft;

        /// <summary>
        ///     Occurs when connection established
        /// </summary>
        event EventHandler<EventArgs> Connected;

        /// <summary>
        ///     Occurs when disconnected
        /// </summary>
        event EventHandler<EventArgs> Disconnected;

        /// <summary>
        ///     Occurs on error
        /// </summary>
        event EventHandler<NetworkErrorEventArgs> Error;
    }
}