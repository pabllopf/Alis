// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketClientFactoryTest.cs
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
    ///     Tests for WebSocketClientFactory class
    /// </summary>
    public class WebSocketClientFactoryTest
    {
        /// <summary>
        /// Tests that constructor creates instance
        /// </summary>
        [Fact]
        public void Constructor_CreatesInstance()
        {
            WebSocketClientFactory factory = new WebSocketClientFactory();

            Assert.NotNull(factory);
        }

        /// <summary>
        /// Tests that GenerateSecWebSocketKey returns base64-encoded key
        /// </summary>
        [Fact]
        public void GenerateSecWebSocketKey_ReturnsBase64String()
        {
            string key = WebSocketClientFactory.GenerateSecWebSocketKey();

            Assert.NotNull(key);
            Assert.NotEmpty(key);
            byte[] decoded = Convert.FromBase64String(key);
            Assert.Equal(16, decoded.Length);
        }

        /// <summary>
        /// Tests that BuildHandshakeRequest returns formatted WebSocket handshake request with the given URI
        /// </summary>
        [Fact]
        public void BuildHandshakeRequest_ReturnsFormattedRequest()
        {
            Uri uri = new Uri("ws://127.0.0.1:8080/");
            string key = "dGhlIHNhbXBsZSBub25jZQ==";
            string request = WebSocketClientFactory.BuildHandshakeRequest(uri, key, null, string.Empty);

            Assert.Contains("GET / HTTP/1.1", request);
            Assert.Contains("Host: 127.0.0.1:8080", request);
            Assert.Contains("Upgrade: websocket", request);
            Assert.Contains("Connection: Upgrade", request);
            Assert.Contains("Sec-WebSocket-Key: dGhlIHNhbXBsZSBub25jZQ==", request);
            Assert.Contains("Sec-WebSocket-Version: 13", request);
        }

        /// <summary>
        /// Tests that GetAdditionalHeaders returns empty string when headers dictionary is null
        /// </summary>
        [Fact]
        public void GetAdditionalHeaders_Null_ReturnsEmpty()
        {
            string result = WebSocketClientFactory.GetAdditionalHeaders(null);

            Assert.Equal(string.Empty, result);
        }

        /// <summary>
        /// Tests that GetAdditionalHeaders returns empty string when headers dictionary is empty
        /// </summary>
        [Fact]
        public void GetAdditionalHeaders_Empty_ReturnsEmpty()
        {
            Dictionary<string, string> headers = new System.Collections.Generic.Dictionary<string, string>();
            string result = WebSocketClientFactory.GetAdditionalHeaders(headers);

            Assert.Equal(string.Empty, result);
        }

        /// <summary>
        /// Tests that GetAdditionalHeaders returns formatted headers string
        /// </summary>
        [Fact]
        public void GetAdditionalHeaders_WithHeaders_ReturnsFormattedHeaders()
        {
            Dictionary<string, string> headers = new System.Collections.Generic.Dictionary<string, string>
            {
                { "Authorization", "Bearer token123" },
                { "X-Custom", "value" }
            };
            string result = WebSocketClientFactory.GetAdditionalHeaders(headers);

            Assert.Contains("Authorization: Bearer token123\r\n", result);
            Assert.Contains("X-Custom: value\r\n", result);
        }

        /// <summary>
        /// Tests that GetSubProtocolFromHeader returns null when no sub-protocol header present
        /// </summary>
        [Fact]
        public void GetSubProtocolFromHeader_WithoutProtocol_ReturnsNull()
        {
            string header = "HTTP/1.1 101 Switching Protocols\r\nUpgrade: websocket\r\nConnection: Upgrade\r\n\r\n";

            string result = WebSocketClientFactory.GetSubProtocolFromHeader(header);

            Assert.Null(result);
        }

        /// <summary>
        /// Tests that ThrowIfInvalidResponseCode does not throw for 101 response
        /// </summary>
        [Fact]
        public void ThrowIfInvalidResponseCode_101Response_DoesNotThrow()
        {
            string responseHeader = "HTTP/1.1 101 Switching Protocols\r\nUpgrade: websocket\r\nConnection: Upgrade\r\n\r\n";

            WebSocketClientFactory.ThrowIfInvalidResponseCode(responseHeader);
        }

        /// <summary>
        /// Tests that ThrowIfInvalidResponseCode throws for empty response (null http code)
        /// </summary>
        [Fact]
        public void ThrowIfInvalidResponseCode_EmptyResponse_ThrowsInvalidHttpResponseCodeException()
        {
            Assert.Throws<InvalidHttpResponseCodeException>(() =>
                WebSocketClientFactory.ThrowIfInvalidResponseCode(string.Empty));
        }

        /// <summary>
        /// Tests that ThrowIfInvalidResponseCode throws for non-101 response code
        /// </summary>
        [Fact]
        public void ThrowIfInvalidResponseCode_Non101Response_ThrowsInvalidHttpResponseCodeException()
        {
            string responseHeader = "HTTP/1.1 404 Not Found\r\nContent-Length: 0\r\n\r\n";

            Assert.Throws<InvalidHttpResponseCodeException>(() =>
                WebSocketClientFactory.ThrowIfInvalidResponseCode(responseHeader));
        }

        /// <summary>
        /// Tests that ThrowIfInvalidAcceptString does not throw for valid accept string
        /// </summary>
        [Fact]
        public void ThrowIfInvalidAcceptString_ValidResponse_DoesNotThrow()
        {
            string key = "dGhlIHNhbXBsZSBub25jZQ==";
            string expected = HttpHelper.ComputeSocketAcceptString(key);
            string header = $"HTTP/1.1 101 Switching Protocols\r\nSec-WebSocket-Accept: {expected}\r\nUpgrade: websocket\r\nConnection: Upgrade\r\n\r\n";

            WebSocketClientFactory.ThrowIfInvalidAcceptString(Guid.NewGuid(), header, key);
        }

        /// <summary>
        /// Tests that SendHandshakeRequest writes handshake bytes to stream
        /// </summary>
        [Fact]
        public async Task SendHandshakeRequest_WritesToStream()
        {
            using MemoryStream stream = new MemoryStream();
            string handshakeRequest = "GET / HTTP/1.1\r\nHost: test\r\nUpgrade: websocket\r\nConnection: Upgrade\r\n\r\n";
            Guid guid = Guid.NewGuid();

            await WebSocketClientFactory.SendHandshakeRequest(stream, handshakeRequest, guid);

            byte[] buffer = new byte[stream.Length];
            stream.Position = 0;
            stream.Read(buffer, 0, buffer.Length);
            string written = Encoding.UTF8.GetString(buffer);
            Assert.Contains("GET / HTTP/1.1", written);
        }

        /// <summary>
        /// Tests that ConnectAsync returns WebSocket for valid response
        /// </summary>
        [Fact]
        public async Task ConnectAsync_ValidResponse_ReturnsWebSocket()
        {
            Guid guid = Guid.NewGuid();
            string key = "dGhlIHNhbXBsZSBub25jZQ==";
            string expectedAccept = HttpHelper.ComputeSocketAcceptString(key);
            string httpResponse = $"HTTP/1.1 101 Switching Protocols\r\nUpgrade: websocket\r\nConnection: Upgrade\r\nSec-WebSocket-Accept: {expectedAccept}\r\n\r\n";
            byte[] responseBytes = Encoding.UTF8.GetBytes(httpResponse);
            using MemoryStream responseStream = new MemoryStream(responseBytes);
            responseStream.Position = 0;

            System.Net.WebSockets.WebSocket ws = await new WebSocketClientFactory().ConnectAsync(guid, responseStream, key,
                TimeSpan.FromSeconds(30), null, false, CancellationToken.None);

            Assert.NotNull(ws);
        }

        /// <summary>
        /// Tests that ConnectAsync throws InvalidHttpResponseCodeException for non-101 response
        /// </summary>
        [Fact]
        public async Task ConnectAsync_InvalidResponseCode_ThrowsInvalidHttpResponseCodeException()
        {
            Guid guid = Guid.NewGuid();
            string httpResponse = "HTTP/1.1 404 Not Found\r\nContent-Length: 0\r\n\r\n";
            byte[] responseBytes = Encoding.UTF8.GetBytes(httpResponse);
            using MemoryStream responseStream = new MemoryStream(responseBytes);
            responseStream.Position = 0;

            await Assert.ThrowsAsync<InvalidHttpResponseCodeException>(() =>
                new WebSocketClientFactory().ConnectAsync(guid, responseStream, "some-key",
                    TimeSpan.FromSeconds(30), null, false, CancellationToken.None));
        }

        /// <summary>
        /// Tests that ConnectAsync throws WebSocketHandshakeFailedException for invalid accept string
        /// </summary>
        [Fact]
        public async Task ConnectAsync_InvalidAcceptString_ThrowsWebSocketHandshakeFailedException()
        {
            Guid guid = Guid.NewGuid();
            string httpResponse = "HTTP/1.1 101 Switching Protocols\r\nSec-WebSocket-Accept: invalid\r\n\r\n";
            byte[] responseBytes = Encoding.UTF8.GetBytes(httpResponse);
            using MemoryStream responseStream = new MemoryStream(responseBytes);
            responseStream.Position = 0;

            await Assert.ThrowsAsync<WebSocketHandshakeFailedException>(() =>
                new WebSocketClientFactory().ConnectAsync(guid, responseStream, "some-key",
                    TimeSpan.FromSeconds(30), null, false, CancellationToken.None));
        }

        /// <summary>
        /// Tests that ConnectAsync throws InvalidHttpResponseCodeException for empty response
        /// </summary>
        [Fact]
        public async Task ConnectAsync_EmptyResponse_ThrowsInvalidHttpResponseCodeException()
        {
            Guid guid = Guid.NewGuid();
            using MemoryStream responseStream = new MemoryStream();
            responseStream.Position = 0;

            await Assert.ThrowsAsync<InvalidHttpResponseCodeException>(() =>
                new WebSocketClientFactory().ConnectAsync(guid, responseStream, "some-key",
                    TimeSpan.FromSeconds(30), null, false, CancellationToken.None));
        }

        /// <summary>
        /// Tests that ConnectAsync throws WebSocketHandshakeFailedException when stream read fails
        /// </summary>
        [Fact]
        public async Task ConnectAsync_StreamException_ThrowsWebSocketHandshakeFailedException()
        {
            Guid guid = Guid.NewGuid();
            using MemoryStream responseStream = new MemoryStream();
            responseStream.Dispose();

            await Assert.ThrowsAsync<WebSocketHandshakeFailedException>(() =>
                new WebSocketClientFactory().ConnectAsync(guid, responseStream, "some-key",
                    TimeSpan.FromSeconds(30), null, false, CancellationToken.None));
        }
    }
}
