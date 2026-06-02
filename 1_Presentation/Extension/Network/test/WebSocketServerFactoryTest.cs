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
using Alis.Extension.Network.Exceptions;
using Xunit;

namespace Alis.Extension.Network.Test
{
    /// <summary>
    ///     The web socket server factory test class
    /// </summary>
    public class WebSocketServerFactoryTest
    {
        
        [Fact]
        public void BuildHandshakeResponse_WithKey_ReturnsValidResponse()
        {
            string secWebSocketKey = "dGhlIHNhbXBsZSBub25jZQ==";
            string subProtocol = null;

            string response = WebSocketServerFactory.BuildHandshakeResponse(secWebSocketKey, subProtocol);

            Assert.Contains("HTTP/1.1 101 Switching Protocols", response);
            Assert.Contains("Connection: Upgrade", response);
            Assert.Contains("Upgrade: websocket", response);
            Assert.Contains("Sec-WebSocket-Accept:", response);
        }

        [Fact]
        public void BuildHandshakeResponse_WithSubProtocol_IncludesProtocolHeader()
        {
            string secWebSocketKey = "dGhlIHNhbXBsZSBub25jZQ==";
            string subProtocol = "chat";

            string response = WebSocketServerFactory.BuildHandshakeResponse(secWebSocketKey, subProtocol);

            Assert.Contains("Sec-WebSocket-Protocol: chat", response);
        }

        [Fact]
        public void BuildHandshakeResponse_ComputesCorrectAcceptString()
        {
            string secWebSocketKey = "dGhlIHNhbXBsZSBub25jZQ==";
            string subProtocol = null;

            string response = WebSocketServerFactory.BuildHandshakeResponse(secWebSocketKey, subProtocol);

            string expectedAccept = HttpHelper.ComputeSocketAcceptString(secWebSocketKey);
            Assert.Contains($"Sec-WebSocket-Accept: {expectedAccept}", response);
        }

        [Fact]
        public void Constructor_WithKeepAliveIntervalAndProtocol_SetsProperties()
        {
            WebSocketServerOptions options = new WebSocketServerOptions(30.0, false, "chat");

            Assert.Equal(TimeSpan.FromSeconds(30), options.KeepAliveInterval);
            Assert.False(options.IncludeExceptionInCloseResponse);
            Assert.Equal("chat", options.SubProtocol);
        }

        [Fact]
        public void Constructor_WithTimeSpanAndProtocol_SetsProperties()
        {
            WebSocketServerOptions options = new WebSocketServerOptions(TimeSpan.FromSeconds(45), "json");

            Assert.Equal(TimeSpan.FromSeconds(45), options.KeepAliveInterval);
            Assert.False(options.IncludeExceptionInCloseResponse);
            Assert.Equal("json", options.SubProtocol);
        }

        [Fact]
        public void DefaultConstructor_SetsDefaultKeepAliveInterval()
        {
            WebSocketServerOptions options = new WebSocketServerOptions();

            Assert.Equal(TimeSpan.FromSeconds(60), options.KeepAliveInterval);
        }

        [Fact]
        public void DefaultConstructor_SetsDefaultIncludeExceptionInCloseResponse()
        {
            WebSocketServerOptions options = new WebSocketServerOptions();

            Assert.False(options.IncludeExceptionInCloseResponse);
        }

        [Fact]
        public void DefaultConstructor_SetsDefaultSubProtocol()
        {
            WebSocketServerOptions options = new WebSocketServerOptions();

            Assert.Equal("", options.SubProtocol);
        }
             [Fact]
        public void ValidateWebSocketVersion_WithVersion12_ThrowsException()
        {
            WebSocketVersionNotSupportedException exception = Assert.Throws<WebSocketVersionNotSupportedException>(() => 
                WebSocketServerFactory.ValidateWebSocketVersion(12));

            Assert.Contains("not suported", exception.Message);
            Assert.Contains("13", exception.Message);
        }

        [Fact]
        public void ValidateWebSocketVersion_WithVersion10_ThrowsException()
        {
            WebSocketVersionNotSupportedException exception = Assert.Throws<WebSocketVersionNotSupportedException>(() => 
                WebSocketServerFactory.ValidateWebSocketVersion(10));

            Assert.Contains("not suported", exception.Message);
        }

        [Fact]
        public void ExtractWebSocketKey_WithValidHeader_ReturnsKey()
        {
            string httpHeader = "HTTP/1.1 101 Switching Protocols\r\n" +
                               "Sec-WebSocket-Key: dGhlIHNhbXBsZSBub25jZQ==\r\n" +
                               "\r\n";

            string key = WebSocketServerFactory.ExtractWebSocketKey(httpHeader);

            Assert.Equal("dGhlIHNhbXBsZSBub25jZQ==", key);
        }

        [Fact]
        public void ExtractWebSocketKey_WithTrimmedKey_ReturnsTrimmedKey()
        {
            string httpHeader = "HTTP/1.1 101 Switching Protocols\r\n" +
                               "Sec-WebSocket-Key:   dGhlIHNhbXBsZSBub25jZQ==   \r\n" +
                               "\r\n";

            string key = WebSocketServerFactory.ExtractWebSocketKey(httpHeader);

            Assert.Equal("dGhlIHNhbXBsZSBub25jZQ==", key);
        }

        [Fact]
        public void ExtractWebSocketKey_WithoutKeyHeader_ThrowsException()
        {
            string httpHeader = "HTTP/1.1 101 Switching Protocols\r\n" +
                               "\r\n";

            SecWebSocketKeyMissingException exception = Assert.Throws<SecWebSocketKeyMissingException>(() => 
                WebSocketServerFactory.ExtractWebSocketKey(httpHeader));

            Assert.Contains("Sec-WebSocket-Key", exception.Message);
        }
          [Fact]
        public void Constructor_CreatesInstanceWithDefaultBufferPool()
        {
            WebSocketServerFactory factory = new WebSocketServerFactory();

            Assert.NotNull(factory);
            Assert.NotNull(factory.BufferPool);
        }

        [Fact]
        public async Task ReadHttpHeaderFromStreamAsync_ReadsValidHeader_ReturnsContext()
        {
            WebSocketServerFactory factory = new WebSocketServerFactory();
            string header = "GET /chat HTTP/1.1\r\n" +
                           "Host: example.com:8080\r\n" +
                           "Upgrade: websocket\r\n" +
                           "Connection: Upgrade\r\n" +
                           "Sec-WebSocket-Key: dGhlIHNhbXBsZSBub25jZQ==\r\n" +
                           "Sec-WebSocket-Version: 13\r\n" +
                           "\r\n";
            byte[] headerBytes = Encoding.UTF8.GetBytes(header);
            MemoryStream stream = new MemoryStream(headerBytes);

            WebSocketHttpContext context = await factory.ReadHttpHeaderFromStreamAsync(stream);

            Assert.NotNull(context);
            Assert.True(context.IsWebSocketRequest);
            Assert.Equal("/chat", context.Path);
        }

        [Fact]
        public async Task ReadHttpHeaderFromStreamAsync_WithNonWebSocketRequest_ReturnsContextAsNotWebSocket()
        {
            WebSocketServerFactory factory = new WebSocketServerFactory();
            string header = "GET /api/data HTTP/1.1\r\n" +
                           "Host: example.com:8080\r\n" +
                           "Content-Type: application/json\r\n" +
                           "\r\n";
            byte[] headerBytes = Encoding.UTF8.GetBytes(header);
            MemoryStream stream = new MemoryStream(headerBytes);

            WebSocketHttpContext context = await factory.ReadHttpHeaderFromStreamAsync(stream);

            Assert.NotNull(context);
            Assert.False(context.IsWebSocketRequest);
        }

        [Fact]
        public void CheckWebSocketVersion_WithVersion12_ThrowsWebSocketVersionNotSupportedException()
        {
            string httpHeader = "HTTP/1.1 101 Switching Protocols\r\n" +
                               "Sec-WebSocket-Version: 12\r\n" +
                               "\r\n";

            WebSocketVersionNotSupportedException exception = Assert.Throws<WebSocketVersionNotSupportedException>(() => 
                WebSocketServerFactory.CheckWebSocketVersion(httpHeader));

            Assert.Contains("not suported", exception.Message);
        }

        [Fact]
        public void CheckWebSocketVersion_WithoutVersionHeader_ThrowsException()
        {
            string httpHeader = "HTTP/1.1 101 Switching Protocols\r\n" +
                               "\r\n";

            WebSocketVersionNotSupportedException exception = Assert.Throws<WebSocketVersionNotSupportedException>(() => 
                WebSocketServerFactory.CheckWebSocketVersion(httpHeader));

            Assert.Contains("Sec-WebSocket-Version", exception.Message);
        }

        [Fact]
        public void ExtractWebSocketVersion_WithValidHeader_Returns13()
        {
            string httpHeader = "HTTP/1.1 101 Switching Protocols\r\n" +
                               "Sec-WebSocket-Version: 13\r\n" +
                               "\r\n";

            int version = WebSocketServerFactory.ExtractWebSocketVersion(httpHeader);

            Assert.Equal(13, version);
        }

        [Fact]
        public void ExtractWebSocketVersion_WithVersion14_Returns14()
        {
            string httpHeader = "HTTP/1.1 101 Switching Protocols\r\n" +
                               "Sec-WebSocket-Version: 14\r\n" +
                               "\r\n";

            int version = WebSocketServerFactory.ExtractWebSocketVersion(httpHeader);

            Assert.Equal(14, version);
        }

        [Fact]
        public void ExtractWebSocketVersion_WithoutHeader_ThrowsException()
        {
            string httpHeader = "HTTP/1.1 101 Switching Protocols\r\n" +
                               "\r\n";

            WebSocketVersionNotSupportedException exception = Assert.Throws<WebSocketVersionNotSupportedException>(() => 
                WebSocketServerFactory.ExtractWebSocketVersion(httpHeader));

            Assert.Contains("Sec-WebSocket-Version", exception.Message);
        }

        
        /// <summary>
        ///     Tests that web socket server factory read http header from stream
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
        ///     Tests that perform handshake async valid input
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
        ///     Tests that perform handshake async invalid input
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
        ///     Tests that accept web socket async default options
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
        ///     Tests that accept web socket async valid input
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
        ///     Tests that accept web socket async invalid input
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
        ///     Tests that extract web socket version valid input
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
        ///     Tests that extract web socket version invalid input
        /// </summary>
        [Fact]
        public void ExtractWebSocketVersion_InvalidInput()
        {
            const string httpHeader = "GET /chat HTTP/1.1\r\nHost: server.example.com\r\nUpgrade: websocket\r\nConnection: Upgrade\r\nSec-WebSocket-Key: x3JJHMbDL1EzLkh9GBhXDw==\r\nSec-WebSocket-Protocol: chat, superchat\r\nOrigin: http://example.com\r\n\r\n";

            Assert.Throws<WebSocketVersionNotSupportedException>(() => WebSocketServerFactory.ExtractWebSocketVersion(httpHeader));
        }

        /// <summary>
        ///     Tests that perform handshake async valid input v 2
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
        ///     Tests that perform handshake async invalid input 2
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

        /// <summary>
        ///     Tests that send handshake response writes to stream
        /// </summary>
        [Fact]
        public async Task SendHandshakeResponse_WritesToStream()
        {
            Guid guid = Guid.NewGuid();
            string response = "HTTP/1.1 101 Switching Protocols\r\nUpgrade: websocket\r\n\r\n";
            MemoryStream stream = new MemoryStream();
            CancellationToken token = new CancellationToken();

            await WebSocketServerFactory.SendHandshakeResponse(guid, response, stream, token);

            Assert.True(stream.Position > 0);
        }

        /// <summary>
        ///     Tests that send handshake response writes correct content
        /// </summary>
        [Fact]
        public async Task SendHandshakeResponse_WritesCorrectContent()
        {
            Guid guid = Guid.NewGuid();
            string expected = "HTTP/1.1 101 Switching Protocols\r\nUpgrade: websocket\r\n\r\n";
            MemoryStream stream = new MemoryStream();
            CancellationToken token = new CancellationToken();

            await WebSocketServerFactory.SendHandshakeResponse(guid, expected, stream, token);

            stream.Position = 0;
            byte[] bytes = new byte[stream.Length];
            await stream.ReadAsync(bytes, 0, bytes.Length, token);
            string written = System.Text.Encoding.UTF8.GetString(bytes);

            Assert.Equal(expected, written);
        }

        /// <summary>
        ///     Tests that handle web socket version not supported writes response to stream
        /// </summary>
        [Fact]
        public async Task HandleWebSocketVersionNotSupported_WritesResponse()
        {
            Guid guid = Guid.NewGuid();
            WebSocketVersionNotSupportedException ex = new WebSocketVersionNotSupportedException("Version 12 not supported");
            MemoryStream stream = new MemoryStream();
            CancellationToken token = new CancellationToken();

            await WebSocketServerFactory.HandleWebSocketVersionNotSupported(guid, ex, stream, token);

            Assert.True(stream.Position > 0);
        }

        /// <summary>
        ///     Tests that handle bad request writes response to stream
        /// </summary>
        [Fact]
        public async Task HandleBadRequest_WritesResponse()
        {
            Guid guid = Guid.NewGuid();
            Exception ex = new InvalidOperationException("Bad request");
            MemoryStream stream = new MemoryStream();
            CancellationToken token = new CancellationToken();

            await WebSocketServerFactory.HandleBadRequest(guid, ex, stream, token);

            Assert.True(stream.Position > 0);
        }
    }
}