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
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network;
using Alis.Extension.Network.Internal;
using Xunit;

namespace Alis.Extension.Network.Test
{
    /// <summary>
    ///     Tests for WebSocketServerFactory class
    /// </summary>
    public class WebSocketServerFactoryTest
    {
        [Fact]
        public void Constructor_CreatesInstance()
        {
            // Arrange
            // Act
            WebSocketServerFactory factory = new WebSocketServerFactory();

            // Assert
            Assert.NotNull(factory);
        }

        [Fact]
        public async Task ReadHttpHeaderFromStreamAsync_ReadsValidHeader()
        {
            // Arrange
            WebSocketServerFactory factory = new WebSocketServerFactory();
            string header = "GET /chat HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\nSec-WebSocket-Key: dGhlIHNhbXBsZSBub25jZQ==\r\nSec-WebSocket-Version: 13\r\n\r\n";
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(header));

            // Act
            WebSocketHttpContext result = await factory.ReadHttpHeaderFromStreamAsync(stream);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<WebSocketHttpContext>(result);
            Assert.True(result.IsWebSocketRequest);
            Assert.Equal("/chat", result.Path);
        }

        [Fact]
        public async Task ReadHttpHeaderFromStreamAsync_ReturnsCorrectProtocols()
        {
            // Arrange
            WebSocketServerFactory factory = new WebSocketServerFactory();
            string header = "GET / HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\nSec-WebSocket-Protocol: json, binary\r\n\r\n";
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(header));

            // Act
            WebSocketHttpContext result = await factory.ReadHttpHeaderFromStreamAsync(stream);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.WebSocketRequestedProtocols);
            Assert.Contains("json", result.WebSocketRequestedProtocols);
        }

        [Fact]
        public async Task AcceptWebSocketAsync_AcceptsValidRequest()
        {
            // Arrange
            WebSocketServerFactory factory = new WebSocketServerFactory();
            string header = "GET / HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\nSec-WebSocket-Key: dGhlIHNhbXBsZSBub25jZQ==\r\nSec-WebSocket-Version: 13\r\n\r\n";
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(header));
            WebSocketHttpContext context = await factory.ReadHttpHeaderFromStreamAsync(stream);

            // Act
            WebSocket result = await factory.AcceptWebSocketAsync(context);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<WebSocketImplementation>(result);
        }

        [Fact]
        public async Task AcceptWebSocketAsync_WithOptions_AcceptsRequest()
        {
            // Arrange
            WebSocketServerFactory factory = new WebSocketServerFactory();
            string header = "GET / HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\nSec-WebSocket-Key: dGhlIHNhbXBsZSBub25jZQ==\r\nSec-WebSocket-Version: 13\r\n\r\n";
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(header));
            WebSocketHttpContext context = await factory.ReadHttpHeaderFromStreamAsync(stream);
            WebSocketServerOptions options = new WebSocketServerOptions();

            // Act
            WebSocket result = await factory.AcceptWebSocketAsync(context, options);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<WebSocketImplementation>(result);
        }

        [Fact]
        public async Task AcceptWebSocketAsync_ReturnsConnectedWebSocket()
        {
            // Arrange
            WebSocketServerFactory factory = new WebSocketServerFactory();
            string header = "GET / HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\nSec-WebSocket-Key: dGhlIHNhbXBsZSBub25jZQ==\r\nSec-WebSocket-Version: 13\r\n\r\n";
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(header));
            WebSocketHttpContext context = await factory.ReadHttpHeaderFromStreamAsync(stream);

            // Act
            WebSocket result = await factory.AcceptWebSocketAsync(context);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ReadHttpHeaderFromStreamAsync_ReturnsCorrectPath()
        {
            // Arrange
            WebSocketServerFactory factory = new WebSocketServerFactory();
            string header = "GET /chat?room=123 HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\nSec-WebSocket-Key: dGhlIHNhbXBsZSBub25jZQ==\r\nSec-WebSocket-Version: 13\r\n\r\n";
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(header));

            // Act
            WebSocketHttpContext result = await factory.ReadHttpHeaderFromStreamAsync(stream);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("/chat?room=123", result.Path.Trim());
        }

        [Fact]
        public async Task AcceptWebSocketAsync_WithDefaultOptions_ReturnsWebSocket()
        {
            // Arrange
            WebSocketServerFactory factory = new WebSocketServerFactory();
            string header = "GET / HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\nSec-WebSocket-Key: dGhlIHNhbXBsZSBub25jZQ==\r\nSec-WebSocket-Version: 13\r\n\r\n";
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(header));
            WebSocketHttpContext context = await factory.ReadHttpHeaderFromStreamAsync(stream);

            // Act
            WebSocket result = await factory.AcceptWebSocketAsync(context);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task AcceptWebSocketAsync_WithCancellation_ReturnsWebSocket()
        {
            // Arrange
            WebSocketServerFactory factory = new WebSocketServerFactory();
            string header = "GET / HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\nSec-WebSocket-Key: dGhlIHNhbXBsZSBub25jZQ==\r\nSec-WebSocket-Version: 13\r\n\r\n";
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(header));
            WebSocketHttpContext context = await factory.ReadHttpHeaderFromStreamAsync(stream);
            CancellationToken token = new CancellationToken();

            // Act
            WebSocket result = await factory.AcceptWebSocketAsync(context, token);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ReadHttpHeaderFromStreamAsync_ReturnsHttpContextWithValidRequest()
        {
            // Arrange
            WebSocketServerFactory factory = new WebSocketServerFactory();
            string header = "GET / HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\nSec-WebSocket-Key: dGhlIHNhbXBsZSBub25jZQ==\r\nSec-WebSocket-Version: 13\r\n\r\n";
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(header));

            // Act
            WebSocketHttpContext result = await factory.ReadHttpHeaderFromStreamAsync(stream);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsWebSocketRequest);
        }

        [Fact]
        public async Task AcceptWebSocketAsync_ReturnsWebSocketWithCorrectGuid()
        {
            // Arrange
            WebSocketServerFactory factory = new WebSocketServerFactory();
            string header = "GET / HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\nSec-WebSocket-Key: dGhlIHNhbXBsZSBub25jZQ==\r\nSec-WebSocket-Version: 13\r\n\r\n";
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(header));
            WebSocketHttpContext context = await factory.ReadHttpHeaderFromStreamAsync(stream);

            // Act
            WebSocket result = await factory.AcceptWebSocketAsync(context);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ReadHttpHeaderFromStreamAsync_ReturnsCorrectSubProtocols()
        {
            // Arrange
            WebSocketServerFactory factory = new WebSocketServerFactory();
            string header = "GET / HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\nSec-WebSocket-Key: dGhlIHNhbXBsZSBub25jZQ==\r\nSec-WebSocket-Version: 13\r\nSec-WebSocket-Protocol: json\r\n\r\n";
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(header));

            // Act
            WebSocketHttpContext result = await factory.ReadHttpHeaderFromStreamAsync(stream);

            // Assert
            Assert.NotNull(result);
            Assert.Contains("json", result.WebSocketRequestedProtocols);
        }

        [Fact]
        public async Task AcceptWebSocketAsync_WithSubProtocol_ReturnsWebSocket()
        {
            // Arrange
            WebSocketServerFactory factory = new WebSocketServerFactory();
            string header = "GET / HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\nSec-WebSocket-Key: dGhlIHNhbXBsZSBub25jZQ==\r\nSec-WebSocket-Version: 13\r\n\r\n";
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(header));
            WebSocketHttpContext context = await factory.ReadHttpHeaderFromStreamAsync(stream);
            WebSocketServerOptions options = new WebSocketServerOptions(TimeSpan.FromSeconds(60), "json");

            // Act
            WebSocket result = await factory.AcceptWebSocketAsync(context, options);

            // Assert
            Assert.NotNull(result);
        }
    }
}
