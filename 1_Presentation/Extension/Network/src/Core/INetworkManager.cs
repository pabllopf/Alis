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
        /// <param name="config">Network configuration to apply</param>
        /// <param name="cancellationToken">Token to cancel initialization</param>
        /// <returns>A task representing the asynchronous initialization operation</returns>
        Task InitializeAsync(NetworkConfig config, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Starts networking
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the start operation</param>
        /// <returns>A task representing the asynchronous start operation</returns>
        Task StartAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Stops networking
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the stop operation</param>
        /// <returns>A task representing the asynchronous stop operation</returns>
        Task StopAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Sends message to specific player
        /// </summary>
        /// <param name="targetPlayerId">The player ID to send the message to</param>
        /// <param name="channel">The message channel name</param>
        /// <param name="message">The message payload to send</param>
        /// <param name="reliable">If true, message delivery is guaranteed</param>
        /// <typeparam name="T">The type of the message payload, must implement IJsonSerializable</typeparam>
        /// <returns>A task representing the asynchronous send operation</returns>
        Task SendMessageAsync<T>(string targetPlayerId, string channel, T message, bool reliable = true) where T : IJsonSerializable;

        /// <summary>
        ///     Broadcasts message to all players
        /// </summary>
        /// <param name="channel">The message channel name</param>
        /// <param name="message">The message payload to broadcast</param>
        /// <param name="reliable">If true, message delivery is guaranteed</param>
        /// <param name="exceptPlayerId">Optional player ID to exclude from the broadcast</param>
        /// <typeparam name="T">The type of the message payload, must implement IJsonSerializable</typeparam>
        /// <returns>A task representing the asynchronous broadcast operation</returns>
        Task BroadcastMessageAsync<T>(string channel, T message, bool reliable = true, string exceptPlayerId = null) where T : IJsonSerializable;

        /// <summary>
        ///     Registers message handler
        /// </summary>
        /// <param name="channel">The channel name to handle messages for</param>
        /// <param name="handler">The handler function receiving sender ID and payload</param>
        void RegisterMessageHandler(string channel, Func<string, string, Task> handler);

        /// <summary>
        ///     Unregisters message handler
        /// </summary>
        /// <param name="channel">The channel name to remove the handler for</param>
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