// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IWebSocketClientFactory.cs
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
using System.IO;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace Alis.Core.Network
{
    /// <summary>
    ///     Web socket client factory used to open web socket client connections
    /// </summary>
    public interface IWebSocketClientFactory
    {
        /// <summary>
        ///     Connect with default options
        /// </summary>
        /// <param name="uri">The WebSocket uri to connect to (e.g. ws://example.com or wss://example.com for SSL)</param>
        /// <param name="token">The optional cancellation token</param>
        /// <returns>A connected web socket instance</returns>
        Task<WebSocket> ConnectAsync(Uri uri, CancellationToken token = default(CancellationToken));
        
        /// <summary>
        ///     Connect with options specified
        /// </summary>
        /// <param name="uri">The WebSocket uri to connect to (e.g. ws://example.com or wss://example.com for SSL)</param>
        /// <param name="options">The WebSocket client options</param>
        /// <param name="token">The optional cancellation token</param>
        /// <returns>A connected web socket instance</returns>
        Task<WebSocket> ConnectAsync(Uri uri, WebSocketClientOptions options,
            CancellationToken token = default(CancellationToken));
        
        /// <summary>
        ///     Connect with a stream that has already been opened and HTTP websocket upgrade request sent
        ///     This function will check the handshake response from the server and proceed if successful
        ///     Use this function if you have specific requirements to open a conenction like using special http headers and
        ///     cookies
        ///     You will have to build your own HTTP websocket upgrade request
        ///     You may not even choose to use TCP/IP and this function will allow you to do that
        /// </summary>
        /// <param name="responseStream">The full duplex response stream from the server</param>
        /// <param name="secWebSocketKey">The secWebSocketKey you used in the handshake request</param>
        /// <param name="options">The WebSocket client options</param>
        /// <param name="token">The optional cancellation token</param>
        /// <returns></returns>
        Task<WebSocket> ConnectAsync(Stream responseStream, string secWebSocketKey, WebSocketClientOptions options,
            CancellationToken token = default(CancellationToken));
    }
}