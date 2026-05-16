// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:INetworkServerManager.cs
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

namespace Alis.Extension.Network.Core
{
    /// <summary>
    ///     Server-specific network manager interface
    /// </summary>
    public interface INetworkServerManager : INetworkManager
    {
        /// <summary>
        ///     Gets listening URI
        /// </summary>
        Uri ListenUri { get; }

        /// <summary>
        ///     Starts listening for connections
        /// </summary>
        /// <param name="address">The URI address to listen on</param>
        /// <param name="cancellationToken">Token to cancel the listen operation</param>
        /// <returns>A task representing the asynchronous listen operation</returns>
        Task ListenAsync(Uri address, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Stops listening
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the stop operation</param>
        /// <returns>A task representing the asynchronous stop operation</returns>
        Task StopListeningAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Creates a session
        /// </summary>
        /// <param name="sessionName">The name of the session</param>
        /// <param name="maxPlayers">Maximum number of players allowed in the session</param>
        /// <param name="cancellationToken">Token to cancel the operation</param>
        /// <returns>A task containing the newly created network session</returns>
        Task<NetworkSession> CreateSessionAsync(string sessionName, int maxPlayers, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Gets session by ID
        /// </summary>
        /// <param name="sessionId">The unique session identifier</param>
        /// <returns>The network session if found, null otherwise</returns>
        NetworkSession GetSession(string sessionId);

        /// <summary>
        ///     Gets all active sessions
        /// </summary>
        /// <returns>A read-only list of active network sessions</returns>
        IReadOnlyList<NetworkSession> GetActiveSessions();

        /// <summary>
        ///     Closes session
        /// </summary>
        /// <param name="sessionId">The unique session identifier to close</param>
        /// <param name="cancellationToken">Token to cancel the operation</param>
        /// <returns>A task representing the asynchronous close operation</returns>
        Task CloseSessionAsync(string sessionId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Kicks player from session
        /// </summary>
        /// <param name="playerId">The unique player identifier to kick</param>
        /// <param name="sessionId">The session to remove the player from</param>
        /// <param name="reason">Optional reason for the kick</param>
        /// <param name="cancellationToken">Token to cancel the operation</param>
        /// <returns>A task representing the asynchronous kick operation</returns>
        Task KickPlayerAsync(string playerId, string sessionId, string reason = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Occurs when client connects
        /// </summary>
        event EventHandler<ClientConnectionEventArgs> ClientConnected;

        /// <summary>
        ///     Occurs when client disconnects
        /// </summary>
        event EventHandler<ClientDisconnectionEventArgs> ClientDisconnected;
    }
}