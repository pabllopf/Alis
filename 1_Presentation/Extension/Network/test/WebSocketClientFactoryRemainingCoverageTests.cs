// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketClientFactoryRemainingCoverageTests.cs
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
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Exceptions;
using Xunit;

namespace Alis.Extension.Network.Test
{
    /// <summary>
    /// The web socket client factory remaining coverage tests class
    /// </summary>
    public class WebSocketClientFactoryRemainingCoverageTests
    {
        /// <summary>
        /// Tests that constructor with buffer factory sets buffer factory
        /// </summary>
        [Fact]
        public void Constructor_WithBufferFactory_SetsBufferFactory()
        {
            Func<MemoryStream> bufferFactory = () => new MemoryStream();
            using WebSocketClientFactory factory = new WebSocketClientFactory(bufferFactory);

            Assert.NotNull(factory);
        }

        /// <summary>
        /// Tests that constructor with buffer factory dispose does not throw
        /// </summary>
        [Fact]
        public void Constructor_WithBufferFactory_Dispose_DoesNotThrow()
        {
            Func<MemoryStream> bufferFactory = () => new MemoryStream();
            WebSocketClientFactory factory = new WebSocketClientFactory(bufferFactory);
            factory.Dispose();
        }

        /// <summary>
        /// Tests that dispose default constructor does not throw
        /// </summary>
        [Fact]
        public void Dispose_DefaultConstructor_DoesNotThrow()
        {
            WebSocketClientFactory factory = new WebSocketClientFactory();
            factory.Dispose();
        }

        /// <summary>
        /// Tests that dispose multiple calls does not throw
        /// </summary>
        [Fact]
        public void Dispose_MultipleCalls_DoesNotThrow()
        {
            WebSocketClientFactory factory = new WebSocketClientFactory();
            factory.Dispose();
            factory.Dispose();
        }

        /// <summary>
        /// Tests that dispose with buffer factory does not throw
        /// </summary>
        [Fact]
        public void Dispose_WithBufferFactory_DoesNotThrow()
        {
            Func<MemoryStream> bufferFactory = () => new MemoryStream();
            WebSocketClientFactory factory = new WebSocketClientFactory(bufferFactory);
            factory.Dispose();
        }

        /// <summary>
        /// Tests that get sub protocol from header with protocol returns protocol
        /// </summary>
        [Fact]
        public void GetSubProtocolFromHeader_WithProtocol_ReturnsProtocol()
        {
            string response = "HTTP/1.1 101 Switching Protocols\r\nSec-WebSocket-Protocol: myprotocol\r\nUpgrade: websocket\r\nConnection: Upgrade\r\n\r\n";

            string result = WebSocketClientFactory.GetSubProtocolFromHeader(response);

            Assert.Equal("myprotocol", result);
        }

        /// <summary>
        /// Tests that get sub protocol from header with protocol trailing spaces returns trimmed
        /// </summary>
        [Fact]
        public void GetSubProtocolFromHeader_WithProtocolTrailingSpaces_ReturnsTrimmed()
        {
            string response = "HTTP/1.1 101 Switching Protocols\r\nSec-WebSocket-Protocol:  chat  \r\nUpgrade: websocket\r\nConnection: Upgrade\r\n\r\n";

            string result = WebSocketClientFactory.GetSubProtocolFromHeader(response);

            Assert.Equal("chat", result);
        }

        /// <summary>
        /// Tests that get sub protocol from header with multiple protocols returns first
        /// </summary>
        [Fact]
        public void GetSubProtocolFromHeader_WithMultipleProtocols_ReturnsFirst()
        {
            string response = "HTTP/1.1 101 Switching Protocols\r\nSec-WebSocket-Protocol: chat, video\r\nUpgrade: websocket\r\nConnection: Upgrade\r\n\r\n";

            string result = WebSocketClientFactory.GetSubProtocolFromHeader(response);

            Assert.Equal("chat, video", result);
        }

        /// <summary>
        /// Tests that throw if invalid accept string invalid accept throws web socket handshake failed exception
        /// </summary>
        [Fact]
        public void ThrowIfInvalidAcceptString_InvalidAccept_ThrowsWebSocketHandshakeFailedException()
        {
            string response = "HTTP/1.1 101 Switching Protocols\r\nSec-WebSocket-Accept: invalid\r\nUpgrade: websocket\r\nConnection: Upgrade\r\n\r\n";

            Assert.Throws<WebSocketHandshakeFailedException>(() =>
                WebSocketClientFactory.ThrowIfInvalidAcceptString(Guid.NewGuid(), response, "some-key"));
        }

        /// <summary>
        /// Tests that throw if invalid accept string empty accept throws web socket handshake failed exception
        /// </summary>
        [Fact]
        public void ThrowIfInvalidAcceptString_EmptyAccept_ThrowsWebSocketHandshakeFailedException()
        {
            string response = "HTTP/1.1 101 Switching Protocols\r\nSec-WebSocket-Accept: \r\nUpgrade: websocket\r\nConnection: Upgrade\r\n\r\n";

            Assert.Throws<WebSocketHandshakeFailedException>(() =>
                WebSocketClientFactory.ThrowIfInvalidAcceptString(Guid.NewGuid(), response, "some-key"));
        }

        /// <summary>
        /// Tests that throw if invalid response code non 101 with body throws invalid http response code exception with details
        /// </summary>
        [Fact]
        public void ThrowIfInvalidResponseCode_Non101WithBody_ThrowsInvalidHttpResponseCodeExceptionWithDetails()
        {
            string responseHeader = "HTTP/1.1 404 Not Found\r\nContent-Type: text/html\r\n\r\n<body>Not Found</body>\r\n";

            InvalidHttpResponseCodeException ex = Assert.Throws<InvalidHttpResponseCodeException>(() =>
                WebSocketClientFactory.ThrowIfInvalidResponseCode(responseHeader));

            Assert.Equal("404 Not Found", ex.ResponseCode);
            Assert.Contains("<body>Not Found</body>", ex.ResponseDetails);
        }

        /// <summary>
        /// Tests that throw if invalid response code non 101 with multiple body lines throws with all details
        /// </summary>
        [Fact]
        public void ThrowIfInvalidResponseCode_Non101WithMultipleBodyLines_ThrowsWithAllDetails()
        {
            string responseHeader = "HTTP/1.1 500 Internal Server Error\r\nContent-Type: text/plain\r\n\r\nLine1\r\nLine2\r\n";

            InvalidHttpResponseCodeException ex = Assert.Throws<InvalidHttpResponseCodeException>(() =>
                WebSocketClientFactory.ThrowIfInvalidResponseCode(responseHeader));

            Assert.Equal("500 Internal Server Error", ex.ResponseCode);
            Assert.Contains("Line1", ex.ResponseDetails);
            Assert.Contains("Line2", ex.ResponseDetails);
        }

        /// <summary>
        /// Tests that validate server certificate no errors returns true
        /// </summary>
        [Fact]
        public void ValidateServerCertificate_NoErrors_ReturnsTrue()
        {
            bool result = WebSocketClientFactory.ValidateServerCertificate(null, null, null, SslPolicyErrors.None);

            Assert.True(result);
        }

        /// <summary>
        /// Tests that validate server certificate remote certificate not available returns false
        /// </summary>
        [Fact]
        public void ValidateServerCertificate_RemoteCertificateNotAvailable_ReturnsFalse()
        {
            bool result = WebSocketClientFactory.ValidateServerCertificate(null, null, null, SslPolicyErrors.RemoteCertificateNotAvailable);

            Assert.False(result);
        }

        /// <summary>
        /// Tests that validate server certificate remote certificate name mismatch returns false
        /// </summary>
        [Fact]
        public void ValidateServerCertificate_RemoteCertificateNameMismatch_ReturnsFalse()
        {
            bool result = WebSocketClientFactory.ValidateServerCertificate(null, null, null, SslPolicyErrors.RemoteCertificateNameMismatch);

            Assert.False(result);
        }

        /// <summary>
        /// Tests that validate server certificate remote certificate chain errors returns false
        /// </summary>
        [Fact]
        public void ValidateServerCertificate_RemoteCertificateChainErrors_ReturnsFalse()
        {
            bool result = WebSocketClientFactory.ValidateServerCertificate(null, null, null, SslPolicyErrors.RemoteCertificateChainErrors);

            Assert.False(result);
        }

        /// <summary>
        /// Tests that build handshake request with protocol includes protocol
        /// </summary>
        [Fact]
        public void BuildHandshakeRequest_WithProtocol_IncludesProtocol()
        {
            Uri uri = new Uri("ws://example.com:8080/chat");
            string key = "dGhlIHNhbXBsZSBub25jZQ==";

            string request = WebSocketClientFactory.BuildHandshakeRequest(uri, key, "chat", string.Empty);

            Assert.Contains("Sec-WebSocket-Protocol: chat", request);
        }

        /// <summary>
        /// Tests that build handshake request with additional headers includes headers
        /// </summary>
        [Fact]
        public void BuildHandshakeRequest_WithAdditionalHeaders_IncludesHeaders()
        {
            Uri uri = new Uri("ws://example.com:8080/chat");
            string key = "dGhlIHNhbXBsZSBub25jZQ==";

            string request = WebSocketClientFactory.BuildHandshakeRequest(uri, key, null, "Authorization: Bearer token\r\n");

            Assert.Contains("Authorization: Bearer token", request);
        }

        /// <summary>
        /// Tests that build handshake request with protocol and headers includes both
        /// </summary>
        [Fact]
        public void BuildHandshakeRequest_WithProtocolAndHeaders_IncludesBoth()
        {
            Uri uri = new Uri("ws://example.com:8080/chat");
            string key = "dGhlIHNhbXBsZSBub25jZQ==";

            string request = WebSocketClientFactory.BuildHandshakeRequest(uri, key, "chat", "X-Custom: value\r\n");

            Assert.Contains("Sec-WebSocket-Protocol: chat", request);
            Assert.Contains("X-Custom: value", request);
            Assert.Contains("GET /chat HTTP/1.1", request);
            Assert.Contains("Host: example.com:8080", request);
        }

        /// <summary>
        /// Tests that connect async stream overload with valid response returns web socket
        /// </summary>
        [Fact]
        public async Task ConnectAsync_StreamOverload_WithValidResponse_ReturnsWebSocket()
        {
            string key = "dGhlIHNhbXBsZSBub25jZQ==";
            string expectedAccept = HttpHelper.ComputeSocketAcceptString(key);
            string httpResponse = $"HTTP/1.1 101 Switching Protocols\r\nUpgrade: websocket\r\nConnection: Upgrade\r\nSec-WebSocket-Accept: {expectedAccept}\r\n\r\n";
            byte[] responseBytes = Encoding.UTF8.GetBytes(httpResponse);
            using MemoryStream responseStream = new MemoryStream(responseBytes);
            WebSocketClientOptions options = new WebSocketClientOptions();

            System.Net.WebSockets.WebSocket ws = await new WebSocketClientFactory().ConnectAsync(responseStream, key, options, CancellationToken.None);

            Assert.NotNull(ws);
        }

        /// <summary>
        /// Tests that connect async stream overload with sub protocol returns web socket
        /// </summary>
        [Fact]
        public async Task ConnectAsync_StreamOverload_WithSubProtocol_ReturnsWebSocket()
        {
            string key = "dGhlIHNhbXBsZSBub25jZQ==";
            string expectedAccept = HttpHelper.ComputeSocketAcceptString(key);
            string httpResponse = $"HTTP/1.1 101 Switching Protocols\r\nUpgrade: websocket\r\nConnection: Upgrade\r\nSec-WebSocket-Accept: {expectedAccept}\r\nSec-WebSocket-Protocol: chat\r\n\r\n";
            byte[] responseBytes = Encoding.UTF8.GetBytes(httpResponse);
            using MemoryStream responseStream = new MemoryStream(responseBytes);
            WebSocketClientOptions options = new WebSocketClientOptions();

            System.Net.WebSockets.WebSocket ws = await new WebSocketClientFactory().ConnectAsync(responseStream, key, options, CancellationToken.None);

            Assert.NotNull(ws);
        }

        /// <summary>
        /// Tests that connect async with sub protocol returns web socket
        /// </summary>
        [Fact]
        public async Task ConnectAsync_WithSubProtocol_ReturnsWebSocket()
        {
            string key = "dGhlIHNhbXBsZSBub25jZQ==";
            string expectedAccept = HttpHelper.ComputeSocketAcceptString(key);
            string httpResponse = $"HTTP/1.1 101 Switching Protocols\r\nUpgrade: websocket\r\nConnection: Upgrade\r\nSec-WebSocket-Accept: {expectedAccept}\r\nSec-WebSocket-Protocol: chat\r\n\r\n";
            byte[] responseBytes = Encoding.UTF8.GetBytes(httpResponse);
            using MemoryStream responseStream = new MemoryStream(responseBytes);

            System.Net.WebSockets.WebSocket ws = await new WebSocketClientFactory().ConnectAsync(Guid.NewGuid(), responseStream, key, TimeSpan.FromSeconds(30), null, false, CancellationToken.None);

            Assert.NotNull(ws);
        }

        /// <summary>
        /// Tests that connect async with include exception and extensions returns web socket
        /// </summary>
        [Fact]
        public async Task ConnectAsync_WithIncludeExceptionAndExtensions_ReturnsWebSocket()
        {
            string key = "dGhlIHNhbXBsZSBub25jZQ==";
            string expectedAccept = HttpHelper.ComputeSocketAcceptString(key);
            string httpResponse = $"HTTP/1.1 101 Switching Protocols\r\nUpgrade: websocket\r\nConnection: Upgrade\r\nSec-WebSocket-Accept: {expectedAccept}\r\nSec-WebSocket-Protocol: chat\r\n\r\n";
            byte[] responseBytes = Encoding.UTF8.GetBytes(httpResponse);
            using MemoryStream responseStream = new MemoryStream(responseBytes);

            System.Net.WebSockets.WebSocket ws = await new WebSocketClientFactory().ConnectAsync(Guid.NewGuid(), responseStream, key, TimeSpan.FromSeconds(30), "permessage-deflate", true, CancellationToken.None);

            Assert.NotNull(ws);
        }

        /// <summary>
        /// Tests that connect async stream overload include exception in close response returns web socket
        /// </summary>
        [Fact]
        public async Task ConnectAsync_StreamOverload_IncludeExceptionInCloseResponse_ReturnsWebSocket()
        {
            string key = "dGhlIHNhbXBsZSBub25jZQ==";
            string expectedAccept = HttpHelper.ComputeSocketAcceptString(key);
            string httpResponse = $"HTTP/1.1 101 Switching Protocols\r\nUpgrade: websocket\r\nConnection: Upgrade\r\nSec-WebSocket-Accept: {expectedAccept}\r\n\r\n";
            byte[] responseBytes = Encoding.UTF8.GetBytes(httpResponse);
            using MemoryStream responseStream = new MemoryStream(responseBytes);
            WebSocketClientOptions options = new WebSocketClientOptions
            {
                IncludeExceptionInCloseResponse = true,
                SecWebSocketProtocol = "chat"
            };

            System.Net.WebSockets.WebSocket ws = await new WebSocketClientFactory().ConnectAsync(responseStream, key, options, CancellationToken.None);

            Assert.NotNull(ws);
        }
    }
}
