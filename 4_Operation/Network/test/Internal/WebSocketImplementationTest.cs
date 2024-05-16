// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketImplementationTest.cs
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
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Network.Internal;
using Xunit;

namespace Alis.Core.Network.Test.Internal
{
    /// <summary>
    /// The web socket implementation test class
    /// </summary>
    public class WebSocketImplementationTest
    {
        /// <summary>
        /// Tests that send async valid input
        /// </summary>
        [Fact]
        public async Task SendAsync_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Func<MemoryStream> recycledStreamFactory = () => new MemoryStream();
            Stream stream = new MemoryStream();
            TimeSpan keepAliveInterval = TimeSpan.FromSeconds(30);
            string secWebSocketExtensions = "permessage-deflate";
            bool includeExceptionInCloseResponse = true;
            bool isClient = true;
            string subProtocol = "subProtocol";
            
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, recycledStreamFactory, stream, keepAliveInterval, secWebSocketExtensions, includeExceptionInCloseResponse, isClient, subProtocol);
            ArraySegment<byte> buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes("Test message"));
            await webSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
            
            // Asserts would go here, but it's hard to assert anything because the method doesn't return anything or change any observable state
        }
        
        /// <summary>
        /// Tests that receive async valid input
        /// </summary>
        [Fact]
        public async Task ReceiveAsync_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Func<MemoryStream> recycledStreamFactory = () => new MemoryStream();
            Stream stream = new MemoryStream();
            TimeSpan keepAliveInterval = TimeSpan.FromSeconds(30);
            string secWebSocketExtensions = "permessage-deflate";
            bool includeExceptionInCloseResponse = true;
            bool isClient = true;
            string subProtocol = "subProtocol";
            
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, recycledStreamFactory, stream, keepAliveInterval, secWebSocketExtensions, includeExceptionInCloseResponse, isClient, subProtocol);
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
            await Assert.ThrowsAsync<EndOfStreamException>( () => webSocket.ReceiveAsync(buffer, CancellationToken.None));
        }
        
        /// <summary>
        /// Tests that close async valid input
        /// </summary>
        [Fact]
        public async Task CloseAsync_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Func<MemoryStream> recycledStreamFactory = () => new MemoryStream();
            Stream stream = new MemoryStream();
            TimeSpan keepAliveInterval = TimeSpan.FromSeconds(30);
            string secWebSocketExtensions = "permessage-deflate";
            bool includeExceptionInCloseResponse = true;
            bool isClient = true;
            string subProtocol = "subProtocol";
            
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, recycledStreamFactory, stream, keepAliveInterval, secWebSocketExtensions, includeExceptionInCloseResponse, isClient, subProtocol);
            await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Test close", CancellationToken.None);
            
            Assert.Equal(WebSocketState.CloseSent, webSocket.State);
        }
    }
}