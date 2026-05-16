// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:INetworkClientManager.cs
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
    ///     Client-specific network manager interface
    /// </summary>
    public interface INetworkClientManager : INetworkManager
    {
        /// <summary>
        ///     Gets server URI
        /// </summary>
        Uri ServerUri { get; }

        /// <summary>
        ///     Connects to server
        /// </summary>
        /// <param name="serverUri">The URI of the server to connect to</param>
        /// <param name="playerName">The display name of the local player</param>
        /// <param name="cancellationToken">Token to cancel the connection operation</param>
        /// <returns>A task representing the asynchronous connection operation</returns>
        Task ConnectAsync(Uri serverUri, string playerName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Disconnects from server
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the disconnect operation</param>
        /// <returns>A task representing the asynchronous disconnect operation</returns>
        Task DisconnectAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Occurs on server message received
        /// </summary>
        event EventHandler<ServerMessageEventArgs> ServerMessageReceived;
    }
}