// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   IWebSocketServerFactory.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.IO;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace Alis.Core.Multiplayer
{
    /// <summary>
    ///     Web socket server factory used to open web socket server connections
    /// </summary>
    public interface IWebSocketServerFactory
    {
        /// <summary>
        ///     Reads a http header information from a stream and decodes the parts relating to the WebSocket protocot upgrade
        /// </summary>
        /// <param name="stream">The network stream</param>
        /// <param name="token">The optional cancellation token</param>
        /// <returns>Http data read from the stream</returns>
        Task<WebSocketHttpContext> ReadHttpHeaderFromStreamAsync(Stream stream,
            CancellationToken token = default(CancellationToken));

        /// <summary>
        ///     Accept web socket with default options
        ///     Call ReadHttpHeaderFromStreamAsync first to get WebSocketHttpContext
        /// </summary>
        /// <param name="context">The http context used to initiate this web socket request</param>
        /// <param name="token">The optional cancellation token</param>
        /// <returns>A connected web socket</returns>
        Task<WebSocket> AcceptWebSocketAsync(WebSocketHttpContext context,
            CancellationToken token = default(CancellationToken));

        /// <summary>
        ///     Accept web socket with options specified
        ///     Call ReadHttpHeaderFromStreamAsync first to get WebSocketHttpContext
        /// </summary>
        /// <param name="context">The http context used to initiate this web socket request</param>
        /// <param name="options">The web socket options</param>
        /// <param name="token">The optional cancellation token</param>
        /// <returns>A connected web socket</returns>
        Task<WebSocket> AcceptWebSocketAsync(WebSocketHttpContext context, WebSocketServerOptions options,
            CancellationToken token = default(CancellationToken));
    }
}