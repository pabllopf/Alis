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
using Alis.Extension.Network.Exceptions;
using Xunit;

namespace Alis.Extension.Network.Test
{
    /// <summary>
    ///     Tests for WebSocketServerFactory class
    /// </summary>
    public class WebSocketServerFactoryTest
    {
        /// <summary>
        /// Tests that constructor creates instance
        /// </summary>
        [Fact]
        public void Constructor_CreatesInstance()
        {
            WebSocketServerFactory factory = new WebSocketServerFactory();

            Assert.NotNull(factory);
        }

        /// <summary>
        /// Tests that ReadHttpHeaderFromStreamAsync reads valid header
        /// </summary>
        [Fact]
        public async Task ReadHttpHeaderFromStreamAsync_ReadsValidHeader()
        {
            WebSocketServerFactory factory = new WebSocketServerFactory();
            string header = "GET /chat HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\nSec-WebSocket-Key: dGhlIHNhbXBsZSBub25jZQ==\r\nSec-WebSocket-Version: 13\r\n\r\n";
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(header));

            WebSocketHttpContext result = await factory.ReadHttpHeaderFromStreamAsync(stream);

            Assert.NotNull(result);
            Assert.IsType<WebSocketHttpContext>(result);
            Assert.True(result.IsWebSocketRequest);
            Assert.Equal("/chat", result.Path);
        }

        /// <summary>
        /// Tests that ReadHttpHeaderFromStreamAsync returns correct protocols
        /// </summary>
        [Fact]
        public async Task ReadHttpHeaderFromStreamAsync_ReturnsCorrectProtocols()
        {
            WebSocketServerFactory factory = new WebSocketServerFactory();
            string header = "GET / HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\nSec-WebSocket-Protocol: json, binary\r\n\r\n";
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(header));

            WebSocketHttpContext result = await factory.ReadHttpHeaderFromStreamAsync(stream);

            Assert.NotNull(result);
            Assert.NotNull(result.WebSocketRequestedProtocols);
            Assert.Contains("json", result.WebSocketRequestedProtocols);
        }

        /// <summary>
        /// Tests that ReadHttpHeaderFromStreamAsync returns correct path
        /// </summary>
        [Fact]
        public async Task ReadHttpHeaderFromStreamAsync_ReturnsCorrectPath()
        {
            WebSocketServerFactory factory = new WebSocketServerFactory();
            string header = "GET /chat?room=123 HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\nSec-WebSocket-Key: dGhlIHNhbXBsZSBub25jZQ==\r\nSec-WebSocket-Version: 13\r\n\r\n";
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(header));

            WebSocketHttpContext result = await factory.ReadHttpHeaderFromStreamAsync(stream);

            Assert.NotNull(result);
            Assert.Equal("/chat?room=123", result.Path.Trim());
        }

        /// <summary>
        /// Tests that ReadHttpHeaderFromStreamAsync returns http context with valid request
        /// </summary>
        [Fact]
        public async Task ReadHttpHeaderFromStreamAsync_ReturnsHttpContextWithValidRequest()
        {
            WebSocketServerFactory factory = new WebSocketServerFactory();
            string header = "GET / HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\nSec-WebSocket-Key: dGhlIHNhbXBsZSBub25jZQ==\r\nSec-WebSocket-Version: 13\r\n\r\n";
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(header));

            WebSocketHttpContext result = await factory.ReadHttpHeaderFromStreamAsync(stream);

            Assert.NotNull(result);
            Assert.True(result.IsWebSocketRequest);
        }

        /// <summary>
        /// Tests that ReadHttpHeaderFromStreamAsync returns correct sub protocols
        /// </summary>
        [Fact]
        public async Task ReadHttpHeaderFromStreamAsync_ReturnsCorrectSubProtocols()
        {
            WebSocketServerFactory factory = new WebSocketServerFactory();
            string header = "GET / HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\nSec-WebSocket-Key: dGhlIHNhbXBsZSBub25jZQ==\r\nSec-WebSocket-Version: 13\r\nSec-WebSocket-Protocol: json\r\n\r\n";
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(header));

            WebSocketHttpContext result = await factory.ReadHttpHeaderFromStreamAsync(stream);

            Assert.NotNull(result);
            Assert.Contains("json", result.WebSocketRequestedProtocols);
        }

        /// <summary>
        /// Tests that ExtractWebSocketKey returns key from valid header
        /// </summary>
        [Fact]
        public void ExtractWebSocketKey_ValidHeader_ReturnsKey()
        {
            string header = "GET / HTTP/1.1\r\nSec-WebSocket-Key: dGhlIHNhbXBsZSBub25jZQ==\r\n\r\n";

            string result = WebSocketServerFactory.ExtractWebSocketKey(header);

            Assert.Equal("dGhlIHNhbXBsZSBub25jZQ==", result);
        }

        /// <summary>
        /// Tests that ExtractWebSocketKey throws for header without key
        /// </summary>
        [Fact]
        public void ExtractWebSocketKey_NoKey_ThrowsSecWebSocketKeyMissingException()
        {
            string header = "GET / HTTP/1.1\r\nHost: example.com\r\n\r\n";

            Assert.Throws<SecWebSocketKeyMissingException>(() =>
                WebSocketServerFactory.ExtractWebSocketKey(header));
        }

        /// <summary>
        /// Tests that CheckWebSocketVersion does not throw for valid version
        /// </summary>
        [Fact]
        public void CheckWebSocketVersion_ValidVersion_DoesNotThrow()
        {
            string header = "Sec-WebSocket-Version: 13\r\n";

            WebSocketServerFactory.CheckWebSocketVersion(header);
        }

        /// <summary>
        /// Tests that CheckWebSocketVersion throws for version below 13
        /// </summary>
        [Fact]
        public void CheckWebSocketVersion_VersionBelow13_ThrowsWebSocketVersionNotSupportedException()
        {
            string header = "Sec-WebSocket-Version: 12\r\n";

            Assert.Throws<WebSocketVersionNotSupportedException>(() =>
                WebSocketServerFactory.CheckWebSocketVersion(header));
        }

        /// <summary>
        /// Tests that CheckWebSocketVersion throws for missing version header
        /// </summary>
        [Fact]
        public void CheckWebSocketVersion_MissingVersion_ThrowsWebSocketVersionNotSupportedException()
        {
            string header = "Host: example.com\r\n";

            Assert.Throws<WebSocketVersionNotSupportedException>(() =>
                WebSocketServerFactory.CheckWebSocketVersion(header));
        }

        /// <summary>
        /// Tests that ExtractWebSocketVersion returns version from header
        /// </summary>
        [Fact]
        public void ExtractWebSocketVersion_ValidHeader_ReturnsVersion()
        {
            string header = "Sec-WebSocket-Version: 13\r\n";

            int result = WebSocketServerFactory.ExtractWebSocketVersion(header);

            Assert.Equal(13, result);
        }

        /// <summary>
        /// Tests that ExtractWebSocketVersion throws for missing version
        /// </summary>
        [Fact]
        public void ExtractWebSocketVersion_MissingVersion_ThrowsWebSocketVersionNotSupportedException()
        {
            string header = "Host: example.com\r\n";

            Assert.Throws<WebSocketVersionNotSupportedException>(() =>
                WebSocketServerFactory.ExtractWebSocketVersion(header));
        }

        /// <summary>
        /// Tests that ValidateWebSocketVersion does not throw for version 13
        /// </summary>
        [Fact]
        public void ValidateWebSocketVersion_Version13_DoesNotThrow()
        {
            WebSocketServerFactory.ValidateWebSocketVersion(13);
        }

        /// <summary>
        /// Tests that ValidateWebSocketVersion does not throw for version above 13
        /// </summary>
        [Fact]
        public void ValidateWebSocketVersion_VersionAbove13_DoesNotThrow()
        {
            WebSocketServerFactory.ValidateWebSocketVersion(14);
        }

        /// <summary>
        /// Tests that ValidateWebSocketVersion throws for version below 13
        /// </summary>
        [Fact]
        public void ValidateWebSocketVersion_VersionBelow13_ThrowsWebSocketVersionNotSupportedException()
        {
            Assert.Throws<WebSocketVersionNotSupportedException>(() =>
                WebSocketServerFactory.ValidateWebSocketVersion(12));
        }

        /// <summary>
        /// Tests that BuildHandshakeResponse returns valid response without subProtocol
        /// </summary>
        [Fact]
        public void BuildHandshakeResponse_WithoutSubProtocol_ReturnsValidResponse()
        {
            string key = "dGhlIHNhbXBsZSBub25jZQ==";

            string result = WebSocketServerFactory.BuildHandshakeResponse(key, null);

            Assert.Contains("HTTP/1.1 101 Switching Protocols", result);
            Assert.Contains("Upgrade: websocket", result);
            Assert.Contains("Sec-WebSocket-Accept:", result);
            Assert.DoesNotContain("Sec-WebSocket-Protocol:", result);
        }

        /// <summary>
        /// Tests that BuildHandshakeResponse returns valid response with subProtocol
        /// </summary>
        [Fact]
        public void BuildHandshakeResponse_WithSubProtocol_IncludesProtocol()
        {
            string key = "dGhlIHNhbXBsZSBub25jZQ==";

            string result = WebSocketServerFactory.BuildHandshakeResponse(key, "json");

            Assert.Contains("Sec-WebSocket-Protocol: json", result);
        }

        /// <summary>
        /// Tests that SendHandshakeResponse writes to stream
        /// </summary>
        [Fact]
        public async Task SendHandshakeResponse_WritesToStream()
        {
            using MemoryStream stream = new MemoryStream();
            string response = "HTTP/1.1 101 Switching Protocols\r\nUpgrade: websocket\r\n\r\n";

            await WebSocketServerFactory.SendHandshakeResponse(Guid.NewGuid(), response, stream, CancellationToken.None);

            Assert.True(stream.Length > 0);
        }

        /// <summary>
        /// Tests that HandleWebSocketVersionNotSupported writes response to stream
        /// </summary>
        [Fact]
        public async Task HandleWebSocketVersionNotSupported_WritesToStream()
        {
            using MemoryStream stream = new MemoryStream();

            await WebSocketServerFactory.HandleWebSocketVersionNotSupported(
                Guid.NewGuid(),
                new WebSocketVersionNotSupportedException("Version not supported"),
                stream,
                CancellationToken.None);

            Assert.True(stream.Length > 0);
        }

        /// <summary>
        /// Tests that HandleBadRequest writes response to stream
        /// </summary>
        [Fact]
        public async Task HandleBadRequest_WritesToStream()
        {
            using MemoryStream stream = new MemoryStream();

            await WebSocketServerFactory.HandleBadRequest(
                Guid.NewGuid(),
                new InvalidOperationException("Bad request"),
                stream,
                CancellationToken.None);

            Assert.True(stream.Length > 0);
        }

        /// <summary>
        /// Tests that PerformHandshakeWithValidations writes handshake to stream
        /// </summary>
        [Fact]
        public async Task PerformHandshake_WithValidHeader_WritesHandshake()
        {
            using MemoryStream stream = new MemoryStream();
            string httpHeader = "GET / HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\nConnection: Upgrade\r\nSec-WebSocket-Key: dGhlIHNhbXBsZSBub25jZQ==\r\nSec-WebSocket-Version: 13\r\n\r\n";

            await WebSocketServerFactory.PerformHandshakeAsync(Guid.NewGuid(), httpHeader, null, stream, CancellationToken.None);

            Assert.True(stream.Length > 0);
        }

        /// <summary>
        /// Tests that PerformHandshakeWithValidations writes handshake with subProtocol
        /// </summary>
        [Fact]
        public async Task PerformHandshake_WithSubProtocol_WritesHandshake()
        {
            using MemoryStream stream = new MemoryStream();
            string httpHeader = "GET / HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\nConnection: Upgrade\r\nSec-WebSocket-Key: dGhlIHNhbXBsZSBub25jZQ==\r\nSec-WebSocket-Version: 13\r\nSec-WebSocket-Protocol: json\r\n\r\n";

            await WebSocketServerFactory.PerformHandshakeAsync(Guid.NewGuid(), httpHeader, "json", stream, CancellationToken.None);

            Assert.True(stream.Length > 0);
        }

        /// <summary>
        /// Tests that PerformHandshake throws for unsupported version
        /// </summary>
        [Fact]
        public async Task PerformHandshake_UnsupportedVersion_ThrowsWebSocketVersionNotSupportedException()
        {
            using MemoryStream stream = new MemoryStream();
            string httpHeader = "GET / HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\nConnection: Upgrade\r\nSec-WebSocket-Key: dGhlIHNhbXBsZSBub25jZQ==\r\nSec-WebSocket-Version: 12\r\n\r\n";

            await Assert.ThrowsAsync<WebSocketVersionNotSupportedException>(() =>
                WebSocketServerFactory.PerformHandshakeAsync(Guid.NewGuid(), httpHeader, null, stream, CancellationToken.None));
        }

        /// <summary>
        /// Tests that PerformHandshake throws for missing key
        /// </summary>
        [Fact]
        public async Task PerformHandshake_MissingKey_ThrowsSecWebSocketKeyMissingException()
        {
            using MemoryStream stream = new MemoryStream();
            string httpHeader = "GET / HTTP/1.1\r\nHost: example.com\r\nSec-WebSocket-Version: 13\r\n\r\n";

            await Assert.ThrowsAsync<SecWebSocketKeyMissingException>(() =>
                WebSocketServerFactory.PerformHandshakeAsync(Guid.NewGuid(), httpHeader, null, stream, CancellationToken.None));
        }

        /// <summary>
        /// Tests that AcceptWebSocketAsync returns WebSocket for valid context
        /// </summary>
        [Fact]
        public async Task AcceptWebSocketAsync_ValidContext_ReturnsWebSocket()
        {
            WebSocketServerFactory factory = new WebSocketServerFactory();
            string header = "GET / HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\nConnection: Upgrade\r\nSec-WebSocket-Key: dGhlIHNhbXBsZSBub25jZQ==\r\nSec-WebSocket-Version: 13\r\n\r\n";
            byte[] headerBytes = Encoding.UTF8.GetBytes(header);
            MemoryStream stream = new MemoryStream();
            stream.Write(headerBytes, 0, headerBytes.Length);
            stream.Position = 0;

            WebSocketHttpContext context = await factory.ReadHttpHeaderFromStreamAsync(stream);

            stream.Position = 0;
            WebSocket socket = await factory.AcceptWebSocketAsync(context, CancellationToken.None);

            Assert.NotNull(socket);
            Assert.Equal(WebSocketState.Open, socket.State);
        }

        /// <summary>
        /// Tests that AcceptWebSocketAsync throws for invalid version
        /// </summary>
        [Fact]
        public async Task AcceptWebSocketAsync_InvalidVersion_ThrowsWebSocketVersionNotSupportedException()
        {
            WebSocketServerFactory factory = new WebSocketServerFactory();
            string header = "GET / HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\nSec-WebSocket-Key: dGhlIHNhbXBsZSBub25jZQ==\r\nSec-WebSocket-Version: 12\r\n\r\n";
            byte[] headerBytes = Encoding.UTF8.GetBytes(header);
            MemoryStream stream = new MemoryStream();
            stream.Write(headerBytes, 0, headerBytes.Length);
            stream.Position = 0;

            WebSocketHttpContext context = await factory.ReadHttpHeaderFromStreamAsync(stream);
            stream.Position = 0;

            await Assert.ThrowsAsync<WebSocketVersionNotSupportedException>(() =>
                factory.AcceptWebSocketAsync(context, CancellationToken.None));
        }
    }
}
