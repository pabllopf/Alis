// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketServerOptions.cs
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

namespace Alis.Core.Network
{
    /// <summary>
    ///     Server WebSocket init options
    /// </summary>
    public class WebSocketServerOptions
    {
        /// <summary>
        ///     Initialises a new instance of the WebSocketServerOptions class
        /// </summary>
        public WebSocketServerOptions()
        {
            KeepAliveInterval = TimeSpan.FromSeconds(60);
            IncludeExceptionInCloseResponse = false;
            SubProtocol = "";
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="WebSocketServerOptions" /> class
        /// </summary>
        /// <param name="keepAliveInterval">The keep alive interval</param>
        /// <param name="includeExceptionInCloseResponse">The include exception in close response</param>
        /// <param name="subProtocol">The sub protocol</param>
        public WebSocketServerOptions(double keepAliveInterval, bool includeExceptionInCloseResponse,
            string subProtocol)
        {
            KeepAliveInterval = TimeSpan.FromSeconds(keepAliveInterval);
            IncludeExceptionInCloseResponse = includeExceptionInCloseResponse;
            SubProtocol = subProtocol;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="WebSocketServerOptions" /> class
        /// </summary>
        /// <param name="keepAliveInterval">The keep alive interval</param>
        /// <param name="subProtocol">The sub protocol</param>
        public WebSocketServerOptions(TimeSpan keepAliveInterval, string subProtocol)
        {
            KeepAliveInterval = keepAliveInterval;
            IncludeExceptionInCloseResponse = false;
            SubProtocol = subProtocol;
        }

        /// <summary>
        ///     How often to send ping requests to the Client
        ///     The default is 60 seconds
        ///     This is done to prevent proxy servers from closing your connection
        ///     A timespan of zero will disable the automatic ping pong mechanism
        ///     You can manually control ping pong messages using the PingPongManager class.
        ///     If you do that it is advisable to set this KeepAliveInterval to zero in the WebSocketServerFactory
        /// </summary>
        public TimeSpan KeepAliveInterval { get; set; }

        /// <summary>
        ///     Include the full exception (with stack trace) in the close response
        ///     when an exception is encountered and the WebSocket connection is closed
        ///     The default is false
        /// </summary>
        public bool IncludeExceptionInCloseResponse { get; set; }

        /// <summary>
        ///     Specifies the sub protocol to send back to the client in the opening handshake
        ///     Can be null (the most common use case)
        ///     The client can specify multiple preferred protocols in the opening handshake header
        ///     The server should use the first supported one or set this to null if none of the requested sub protocols are
        ///     supported
        /// </summary>
        public string SubProtocol { get; set; }
    }
}