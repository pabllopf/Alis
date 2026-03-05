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
        Task SendAsync(string clientId, NetworkMessageEnvelope message, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Broadcasts message to all clients
        /// </summary>
        Task BroadcastAsync(NetworkMessageEnvelope message, string exceptClientId = null, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Receives next message from transport
        /// </summary>
        Task<(string ClientId, NetworkMessageEnvelope Message)> ReceiveAsync(CancellationToken cancellationToken = default);

        /// <summary>
        ///     Starts transport listener
        /// </summary>
        Task StartAsync(CancellationToken cancellationToken = default);

        /// <summary>
        ///     Stops transport listener
        /// </summary>
        Task StopAsync(CancellationToken cancellationToken = default);
    }
}

