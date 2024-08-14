// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LoadTest.cs
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
using System.Diagnostics;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace Alis.Core.Network.Sample.Client.Complex
{
    // This test sends a large buffer
    // NOTE: you would never normally do this. In order to send a large amount of data use a small buffer and make multiple calls
    // to SendAsync with endOfMessage false and the last SendAsync function call with endOfMessage set to true.
    /// <summary>
    ///     The load test class
    /// </summary>
    internal class LoadTest
    {
        /// <summary>
        ///     The buffer size
        /// </summary>
        private const int BufferSize = 1 * 1024 * 1024 * 1024; // 1GB
        
        /// <summary>
        ///     Runs this instance
        /// </summary>
        public async Task Run()
        {
            WebSocketClientFactory factory = new WebSocketClientFactory();
            Uri uri = new Uri("ws://localhost:27416/chat");
            WebSocketClientOptions options = new WebSocketClientOptions
                {KeepAliveInterval = TimeSpan.FromMilliseconds(500)};
            using WebSocket webSocket = await factory.ConnectAsync(uri, options);
            // receive loop
            Task readTask = Receive(webSocket);
            
            // send a message
            await Send(webSocket);
            
            // initiate the close handshake
            await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, null, CancellationToken.None);
            
            // wait for server to respond with a close frame
            await readTask;
        }
        
        /// <summary>
        ///     Sends the web socket
        /// </summary>
        /// <param name="webSocket">The web socket</param>
        private async Task Send(WebSocket webSocket)
        {
            byte[] array = new byte[BufferSize];
            ArraySegment<byte> buffer = new ArraySegment<byte>(array);
            await webSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
        }
        
        /// <summary>
        ///     Reads the all using the specified web socket
        /// </summary>
        /// <param name="webSocket">The web socket</param>
        /// <returns>A task containing the long</returns>
        private async Task<long> ReadAll(WebSocket webSocket)
        {
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[BufferSize]);
            long len = 0;
            while (true)
            {
                WebSocketReceiveResult result = await webSocket.ReceiveAsync(buffer, CancellationToken.None);
                
                switch (result.MessageType)
                {
                    case WebSocketMessageType.Close:
                        return len;
                    case WebSocketMessageType.Text:
                    case WebSocketMessageType.Binary:
                        len += result.Count;
                        break;
                }
            }
        }
        
        /// <summary>
        ///     Receives the web socket
        /// </summary>
        /// <param name="webSocket">The web socket</param>
        private async Task Receive(WebSocket webSocket)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            long len = await ReadAll(webSocket);
            Console.WriteLine($"Read {len:#,##0} bytes in {stopwatch.Elapsed.TotalMilliseconds:#,##0} ms");
        }
    }
}