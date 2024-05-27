// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketServerFactoryTest.cs
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
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Network.Exceptions;
using Xunit;

namespace Alis.Core.Network.Test
{
    /// <summary>
    /// The web socket server factory test class
    /// </summary>
    public class WebSocketServerFactoryTest
    {
        /// <summary>
        /// Tests that web socket server factory read http header from stream
        /// </summary>
        [Fact]
        public async Task WebSocketServerFactory_ReadHttpHeaderFromStreamAsync()
        {
            WebSocketServerFactory factory = new WebSocketServerFactory();
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes("GET / HTTP/1.1\r\nUpgrade: websocket\r\n\r\n"));
            WebSocketHttpContext context = await factory.ReadHttpHeaderFromStreamAsync(stream);
            Assert.NotNull(context);
            Assert.True(context.IsWebSocketRequest);
        }
        
        /// <summary>
        /// Tests that perform handshake async valid input
        /// </summary>
        [Fact]
        public async Task PerformHandshakeAsync_ValidInput()
        {
            WebSocketServerFactory webSocketServerFactory = new WebSocketServerFactory();
            Guid guid = Guid.NewGuid();
            string httpHeader = "GET /chat HTTP/1.1\r\nHost: server.example.com\r\nUpgrade: websocket\r\nConnection: Upgrade\r\nSec-WebSocket-Key: x3JJHMbDL1EzLkh9GBhXDw==\r\nSec-WebSocket-Protocol: chat, superchat\r\nSec-WebSocket-Version: 13\r\nOrigin: http://example.com\r\n\r\n";
            string subProtocol = "chat";
            MemoryStream stream = new MemoryStream();
            CancellationToken token = new CancellationToken();
            
            await WebSocketServerFactory.PerformHandshakeAsync(guid, httpHeader, subProtocol, stream, token);
            
            Assert.Equal(219, stream.Position);
        }
        
        /// <summary>
        /// Tests that perform handshake async invalid input
        /// </summary>
        [Fact]
        public async Task PerformHandshakeAsync_InvalidInput()
        {
            WebSocketServerFactory webSocketServerFactory = new WebSocketServerFactory();
            Guid guid = Guid.NewGuid();
            string httpHeader = "GET /chat HTTP/1.1\r\nHost: server.example.com\r\nUpgrade: websocket\r\nConnection: Upgrade\r\nSec-WebSocket-Key: x3JJHMbDL1EzLkh9GBhXDw==\r\nSec-WebSocket-Protocol: chat, superchat\r\nSec-WebSocket-Version: 12\r\nOrigin: http://example.com\r\n\r\n";
            string subProtocol = "chat";
            MemoryStream stream = new MemoryStream();
            CancellationToken token = new CancellationToken();
            
            await Assert.ThrowsAsync<WebSocketVersionNotSupportedException>(() => WebSocketServerFactory.PerformHandshakeAsync(guid, httpHeader, subProtocol, stream, token));
        }
        
        /// <summary>
        /// Tests that accept web socket async default options
        /// </summary>
        [Fact]
        public async Task AcceptWebSocketAsync_DefaultOptions()
        {
            MemoryStream stream = new MemoryStream();
            WebSocketHttpContext context = new WebSocketHttpContext(true, new List<string>(), "header", "path", stream);
            WebSocketServerFactory factory = new WebSocketServerFactory();
            
            await Assert.ThrowsAsync<SecWebSocketKeyMissingException>(() => factory.AcceptWebSocketAsync(context));
        }
        
        /// <summary>
        /// Tests that accept web socket async valid input
        /// </summary>
        [Fact]
        public async Task AcceptWebSocketAsync_ValidInput()
        {
            WebSocketHttpContext context = new WebSocketHttpContext(true, new List<string>(), "header", "path", new MemoryStream());
            WebSocketServerOptions options = new WebSocketServerOptions();
            WebSocketServerFactory factory = new WebSocketServerFactory();
            
            await Assert.ThrowsAsync<SecWebSocketKeyMissingException>(() => factory.AcceptWebSocketAsync(context, options));
        }
        
        /// <summary>
        /// Tests that accept web socket async invalid input
        /// </summary>
        [Fact]
        public async Task AcceptWebSocketAsync_InvalidInput()
        {
            WebSocketHttpContext context = new WebSocketHttpContext(false, new List<string>(), "header", "path", new MemoryStream());
            WebSocketServerOptions options = new WebSocketServerOptions();
            WebSocketServerFactory factory = new WebSocketServerFactory();
            
            await Assert.ThrowsAsync<SecWebSocketKeyMissingException>(() => factory.AcceptWebSocketAsync(context, options));
        }
        
        /// <summary>
        /// Tests that extract web socket version valid input
        /// </summary>
        [Fact]
        public void ExtractWebSocketVersion_ValidInput()
        {
            string httpHeader = "GET /chat HTTP/1.1\r\nHost: server.example.com\r\nUpgrade: websocket\r\nConnection: Upgrade\r\nSec-WebSocket-Key: x3JJHMbDL1EzLkh9GBhXDw==\r\nSec-WebSocket-Protocol: chat, superchat\r\nSec-WebSocket-Version: 13\r\nOrigin: http://example.com\r\n\r\n";
            int expectedVersion = 13;
            
            int actualVersion = WebSocketServerFactory.ExtractWebSocketVersion(httpHeader);
            
            Assert.Equal(expectedVersion, actualVersion);
        }
        
        /// <summary>
        /// Tests that extract web socket version invalid input
        /// </summary>
        [Fact]
        public void ExtractWebSocketVersion_InvalidInput()
        {
            const string httpHeader = "GET /chat HTTP/1.1\r\nHost: server.example.com\r\nUpgrade: websocket\r\nConnection: Upgrade\r\nSec-WebSocket-Key: x3JJHMbDL1EzLkh9GBhXDw==\r\nSec-WebSocket-Protocol: chat, superchat\r\nOrigin: http://example.com\r\n\r\n";
            
            Assert.Throws<WebSocketVersionNotSupportedException>(() => WebSocketServerFactory.ExtractWebSocketVersion(httpHeader));
        }
        
        /// <summary>
        /// Tests that perform handshake async valid input v 2
        /// </summary>
        [Fact]
public async Task PerformHandshakeAsync_ValidInput_v2()
{
    Guid guid = Guid.NewGuid();
    string httpHeader = "GET /chat HTTP/1.1\r\nHost: server.example.com\r\nUpgrade: websocket\r\nConnection: Upgrade\r\nSec-WebSocket-Key: x3JJHMbDL1EzLkh9GBhXDw==\r\nSec-WebSocket-Protocol: chat, superchat\r\nSec-WebSocket-Version: 13\r\nOrigin: http://example.com\r\n\r\n";
    string subProtocol = "chat";
    MemoryStream stream = new MemoryStream();
    CancellationToken token = new CancellationToken();

    await WebSocketServerFactory.PerformHandshakeAsync(guid, httpHeader, subProtocol, stream, token);

    Assert.Equal(219, stream.Position);
}

/// <summary>

/// Tests that perform handshake async invalid input 2

/// </summary>

[Fact]
public async Task PerformHandshakeAsync_InvalidInput_2()
{
    Guid guid = Guid.NewGuid();
    string httpHeader = "GET /chat HTTP/1.1\r\nHost: server.example.com\r\nUpgrade: websocket\r\nConnection: Upgrade\r\nSec-WebSocket-Key: x3JJHMbDL1EzLkh9GBhXDw==\r\nSec-WebSocket-Protocol: chat, superchat\r\nSec-WebSocket-Version: 12\r\nOrigin: http://example.com\r\n\r\n";
    string subProtocol = "chat";
    MemoryStream stream = new MemoryStream();
    CancellationToken token = new CancellationToken();

    await Assert.ThrowsAsync<WebSocketVersionNotSupportedException>(() => WebSocketServerFactory.PerformHandshakeAsync(guid, httpHeader, subProtocol, stream, token));
}
    }
}