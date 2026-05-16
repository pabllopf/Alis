// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:INetworkTransport.cs
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
using System.Threading;
using System.Threading.Tasks;

namespace Alis.Extension.Network.Core
{
    /// <summary>
    ///     Abstract transport layer for network communication
    /// </summary>
    public interface INetworkTransport : IDisposable
    {
        /// <summary>
        ///     Gets transport state
        /// </summary>
        NetworkTransportState State { get; }

        /// <summary>
        ///     Sends message to specific client
        /// </summary>
        /// <param name="clientId">The client identifier to send the message to</param>
        /// <param name="message">The message envelope to send</param>
        /// <param name="cancellationToken">Token to cancel the send operation</param>
        /// <returns>A task representing the asynchronous send operation</returns>
        Task SendAsync(string clientId, NetworkMessageEnvelope message, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Broadcasts message to all clients
        /// </summary>
        /// <param name="message">The message envelope to broadcast</param>
        /// <param name="exceptClientId">Optional client ID to exclude from broadcast</param>
        /// <param name="cancellationToken">Token to cancel the broadcast</param>
        /// <returns>A task representing the asynchronous broadcast operation</returns>
        Task BroadcastAsync(NetworkMessageEnvelope message, string exceptClientId = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Receives next message from transport
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the receive operation</param>
        /// <returns>A tuple containing the client ID and the received message envelope</returns>
        Task<(string ClientId, NetworkMessageEnvelope Message)> ReceiveAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Starts transport listener
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the start operation</param>
        /// <returns>A task representing the asynchronous start operation</returns>
        Task StartAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Stops transport listener
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the stop operation</param>
        /// <returns>A task representing the asynchronous stop operation</returns>
        Task StopAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}