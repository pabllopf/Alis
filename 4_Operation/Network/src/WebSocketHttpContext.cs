// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketHttpContext.cs
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

using System.Collections.Generic;
using System.IO;

namespace Alis.Core.Network
{
    /// <summary>
    ///     The WebSocket HTTP Context used to initiate a WebSocket handshake
    /// </summary>
    public class WebSocketHttpContext
    {
        /// <summary>
        ///     Initialises a new instance of the WebSocketHttpContext class
        /// </summary>
        /// <param name="isWebSocketRequest">True if this is a valid WebSocket request</param>
        /// <param name="webSocketRequestedProtocols"></param>
        /// <param name="httpHeader">The raw http header extracted from the stream</param>
        /// <param name="path">The Path extracted from the http header</param>
        /// <param name="stream">The stream AFTER the header has already been read</param>
        public WebSocketHttpContext(bool isWebSocketRequest, IList<string> webSocketRequestedProtocols,
            string httpHeader, string path, Stream stream)
        {
            IsWebSocketRequest = isWebSocketRequest;
            WebSocketRequestedProtocols = webSocketRequestedProtocols;
            HttpHeader = httpHeader;
            Path = path;
            Stream = stream;
        }

        /// <summary>
        ///     True if this is a valid WebSocket request
        /// </summary>
        public bool IsWebSocketRequest { get; }

        /// <summary>
        ///     Gets the value of the web socket requested protocols
        /// </summary>
        public IList<string> WebSocketRequestedProtocols { get; }

        /// <summary>
        ///     The raw http header extracted from the stream
        /// </summary>
        public string HttpHeader { get; }

        /// <summary>
        ///     The Path extracted from the http header
        /// </summary>
        public string Path { get; }

        /// <summary>
        ///     The stream AFTER the header has already been read
        /// </summary>
        public Stream Stream { get; }
    }
}