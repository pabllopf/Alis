// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   SimpleClient.cs
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

using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Alis.Core.Network.Exceptions.Example.Client.Simple
{
    /// <summary>
    ///     The simple client class
    /// </summary>
    internal class SimpleClient
    {
        /// <summary>
        ///     Runs this instance
        /// </summary>
        public async Task Run()
        {
            WebSocketClientFactory factory = new WebSocketClientFactory();
            Uri uri = new Uri("ws://localhost:27416/chat");
            using (WebSocket webSocket = await factory.ConnectAsync(uri))
            {
                // receive loop
                Task readTask = Receive(webSocket);

                // send a message
                await Send(webSocket);

                // initiate the close handshake
                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, null, CancellationToken.None);

                // wait for server to respond with a close frame
                await readTask;
            }
        }

        /// <summary>
        ///     Sends the web socket
        /// </summary>
        /// <param name="webSocket">The web socket</param>
        private async Task Send(WebSocket webSocket)
        {
            byte[] array = Encoding.UTF8.GetBytes("Hello World");
            ArraySegment<byte> buffer = new ArraySegment<byte>(array);
            await webSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
        }

        /// <summary>
        ///     Receives the web socket
        /// </summary>
        /// <param name="webSocket">The web socket</param>
        private async Task Receive(WebSocket webSocket)
        {
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
            while (true)
            {
                WebSocketReceiveResult result = await webSocket.ReceiveAsync(buffer, CancellationToken.None);

                switch (result.MessageType)
                {
                    case WebSocketMessageType.Close:
                        return;
                    case WebSocketMessageType.Text:
                    case WebSocketMessageType.Binary:
                        string value = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
                        Console.WriteLine(value);
                        break;
                }
            }
        }
    }
}