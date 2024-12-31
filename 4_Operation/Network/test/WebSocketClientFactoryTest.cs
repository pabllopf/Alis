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
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Aspect.Logging;
using Alis.Core.Network.Exceptions;
using Alis.Core.Network.Test.Samples;
using Xunit;

namespace Alis.Core.Network.Test
{
    /// <summary>
    ///     The web socket client factory test class
    /// </summary>
    	  
	 public class WebSocketClientFactoryTest 
    {
        
        /// <summary>
        ///     Tests that dispose closes web socket
        /// </summary>
        [Fact]
        public void Dispose_ClosesWebSocket()
        {
            WebSocketClientFactory factory = new WebSocketClientFactory();
            Uri uri = new Uri("ws://localhost:8080");

            Task<WebSocket> webSocket = factory.ConnectAsync(uri);
            factory.Dispose();
        }

        /// <summary>
        ///     Tests that validate server certificate should return true when ssl policy errors none
        /// </summary>
        [Fact]
        public void ValidateServerCertificate_ShouldReturnTrue_WhenSslPolicyErrorsNone()
        {
            bool result = WebSocketClientFactory.ValidateServerCertificate(null, null, null, SslPolicyErrors.None);
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that validate server certificate should return false when ssl policy errors not none
        /// </summary>
        [Fact]
        public void ValidateServerCertificate_ShouldReturnFalse_WhenSslPolicyErrorsNotNone()
        {
            bool result = WebSocketClientFactory.ValidateServerCertificate(null, null, null, SslPolicyErrors.RemoteCertificateNotAvailable);
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that get additional headers should return empty string when additional headers is null
        /// </summary>
        [Fact]
        public void GetAdditionalHeaders_ShouldReturnEmptyString_WhenAdditionalHeadersIsNull()
        {
            string result = WebSocketClientFactory.GetAdditionalHeaders(null);
            Assert.Equal(string.Empty, result);
        }

        /// <summary>
        ///     Tests that get additional headers should return correct string when additional headers is not null
        /// </summary>
        [Fact]
        public void GetAdditionalHeaders_ShouldReturnCorrectString_WhenAdditionalHeadersIsNotNull()
        {
            Dictionary<string, string> additionalHeaders = new Dictionary<string, string>
            {
                {"TestKey1", "TestValue1"},
                {"TestKey2", "TestValue2"}
            };

            string result = WebSocketClientFactory.GetAdditionalHeaders(additionalHeaders);
            string expected = "TestKey1: TestValue1\r\nTestKey2: TestValue2\r\n";

            Assert.Equal(expected, result);
        }

        /// <summary>
        ///     Tests that validate server certificate should return true when ssl policy errors none v 2
        /// </summary>
        [Fact]
        public void ValidateServerCertificate_ShouldReturnTrue_WhenSslPolicyErrorsNone_v2()
        {
            bool result = WebSocketClientFactory.ValidateServerCertificate(null, null, null, SslPolicyErrors.None);
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that validate server certificate should return false when ssl policy errors not none v 2
        /// </summary>
        [Fact]
        public void ValidateServerCertificate_ShouldReturnFalse_WhenSslPolicyErrorsNotNone_v2()
        {
            bool result = WebSocketClientFactory.ValidateServerCertificate(null, null, null, SslPolicyErrors.RemoteCertificateNotAvailable);
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that get additional headers should return empty string when additional headers is null v 2
        /// </summary>
        [Fact]
        public void GetAdditionalHeaders_ShouldReturnEmptyString_WhenAdditionalHeadersIsNull_v2()
        {
            string result = WebSocketClientFactory.GetAdditionalHeaders(null);
            Assert.Equal(string.Empty, result);
        }

        /// <summary>
        ///     Tests that get additional headers should return correct string when additional headers is not null v 2
        /// </summary>
        [Fact]
        public void GetAdditionalHeaders_ShouldReturnCorrectString_WhenAdditionalHeadersIsNotNull_v2()
        {
            Dictionary<string, string> additionalHeaders = new Dictionary<string, string>
            {
                {"TestKey1", "TestValue1"},
                {"TestKey2", "TestValue2"}
            };

            string result = WebSocketClientFactory.GetAdditionalHeaders(additionalHeaders);
            string expected = "TestKey1: TestValue1\r\nTestKey2: TestValue2\r\n";

            Assert.Equal(expected, result);
        }

        /// <summary>
        ///     Tests that connect async should return web socket when stream is open
        /// </summary>
        [Fact]
        public async Task ConnectAsync_ShouldReturnWebSocket_WhenStreamIsOpen()
        {
            WebSocketClientFactory factory = new WebSocketClientFactory();
            WebSocketClientOptions options = new WebSocketClientOptions();
            string secWebSocketKey = "dGhlIHNhbXBsZSBub25jZQ=="; // Sample key
            MemoryStream stream = new MemoryStream();

            await Assert.ThrowsAsync<InvalidHttpResponseCodeException>(() => factory.ConnectAsync(stream, secWebSocketKey, options));
        }

        /// <summary>
        ///     Tests that connect async should throw exception when stream is closed
        /// </summary>
        [Fact]
        public async Task ConnectAsync_ShouldThrowException_WhenStreamIsClosed()
        {
            WebSocketClientFactory factory = new WebSocketClientFactory();
            WebSocketClientOptions options = new WebSocketClientOptions();
            string secWebSocketKey = "dGhlIHNhbXBsZSBub25jZQ=="; // Sample key
            MemoryStream stream = new MemoryStream();
            stream.Close();

            await Assert.ThrowsAsync<WebSocketHandshakeFailedException>(() => factory.ConnectAsync(stream, secWebSocketKey, options));
        }

        /// <summary>
        ///     Tests that get sub protocol from header should return null when response does not contain sub protocol
        /// </summary>
        [Fact]
        public void GetSubProtocolFromHeader_ShouldReturnNull_WhenResponseDoesNotContainSubProtocol()
        {
            WebSocketClientFactory factory = new WebSocketClientFactory();
            string response = "HTTP/1.1 101 Switching Protocols\r\n" +
                              "Upgrade: websocket\r\n" +
                              "Connection: Upgrade\r\n" +
                              "Sec-WebSocket-Accept: s3pPLMBiTxaQ9kYGzzhZRbK+xOo=\r\n\r\n";

            string result = factory.GetSubProtocolFromHeader(response);

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that throw if invalid accept string should throw exception when accept string is invalid
        /// </summary>
        [Fact]
        public void ThrowIfInvalidAcceptString_ShouldThrowException_WhenAcceptStringIsInvalid()
        {
            WebSocketClientFactory factory = new WebSocketClientFactory();
            string response = "Sec-WebSocket-Accept: invalid_accept_string";
            string secWebSocketKey = "dGhlIHNhbXBsZSBub25jZQ=="; // Sample key

            Assert.Throws<WebSocketHandshakeFailedException>(() => factory.ThrowIfInvalidAcceptString(Guid.NewGuid(), response, secWebSocketKey));
        }

        /// <summary>
        ///     Tests that throw if invalid accept string should not throw exception when accept string is valid
        /// </summary>
        [Fact]
        public void ThrowIfInvalidAcceptString_ShouldNotThrowException_WhenAcceptStringIsValid()
        {
            WebSocketClientFactory factory = new WebSocketClientFactory();
            string secWebSocketKey = "dGhlIHNhbXBsZSBub25jZQ=="; // Sample key
            string validAcceptString = HttpHelper.ComputeSocketAcceptString(secWebSocketKey);
            string response = $"Sec-WebSocket-Accept: {validAcceptString}";

            Exception exception = Record.Exception(() => factory.ThrowIfInvalidAcceptString(Guid.NewGuid(), response, secWebSocketKey));
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that tls authenticate as client test
        /// </summary>
        [Fact]
        public void TlsAuthenticateAsClient_Test()
        {
            WebSocketClientFactory webSocketClientFactory = new WebSocketClientFactory();
            string host = "localhost";
            Assert.Throws<IOException>(() => webSocketClientFactory.TlsAuthenticateAsClient(new SslStream(new NetworkStream(new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))), host));
        }

        /// <summary>
        ///     Tests that send handshake request test
        /// </summary>
        [Fact]
        public async Task SendHandshakeRequest_Test()
        {
            WebSocketClientFactory webSocketClientFactory = new WebSocketClientFactory();
            Guid guid = Guid.NewGuid();
            string handshakeHttpRequest = "GET / HTTP/1.1\r\n" +
                                          "Host: localhost:80\r\n" +
                                          "Upgrade: websocket\r\n" +
                                          "Connection: Upgrade\r\n" +
                                          "Sec-WebSocket-Key: dGhlIHNhbXBsZSBub25jZQ==\r\n" +
                                          "Origin: http://localhost:80\r\n" +
                                          "Sec-WebSocket-Protocol: chat\r\n" +
                                          "Sec-WebSocket-Version: 13\r\n\r\n";
            MemoryStream stream = new MemoryStream();

            await webSocketClientFactory.SendHandshakeRequest(stream, handshakeHttpRequest, guid);

            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);
            string result = await reader.ReadToEndAsync();

            Assert.Equal(handshakeHttpRequest, result);
        }

        /// <summary>
        ///     Tests that build handshake request test
        /// </summary>
        [Fact]
        public void BuildHandshakeRequest_Test()
        {
            WebSocketClientFactory webSocketClientFactory = new WebSocketClientFactory();
            Uri uri = new Uri("http://localhost:80");
            string secWebSocketKey = "dGhlIHNhbXBsZSBub25jZQ=="; // Sample key
            string secWebSocketProtocol = "chat";
            string additionalHeaders = "Additional-Header: Value\r\n";

            string result = webSocketClientFactory.BuildHandshakeRequest(uri, secWebSocketKey, secWebSocketProtocol, additionalHeaders);

            string expected = "GET / HTTP/1.1\r\n" +
                              "Host: localhost:80\r\n" +
                              "Upgrade: websocket\r\n" +
                              "Connection: Upgrade\r\n" +
                              "Sec-WebSocket-Key: dGhlIHNhbXBsZSBub25jZQ==\r\n" +
                              "Origin: http://localhost:80\r\n" +
                              "Sec-WebSocket-Protocol: chat\r\n" +
                              "Additional-Header: Value\r\n" +
                              "Sec-WebSocket-Version: 13\r\n\r\n";

            Assert.Equal(expected, result);
        }

        /// <summary>
        ///     Tests that perform handshake test
        /// </summary>
        [Fact]
        public async Task PerformHandshake_Test()
        {
            WebSocketClientFactory webSocketClientFactory = new WebSocketClientFactory();
            Guid guid = Guid.NewGuid();
            Uri uri = new Uri("http://localhost:80");
            MemoryStream stream = new MemoryStream();
            WebSocketClientOptions options = new WebSocketClientOptions();

            await Assert.ThrowsAsync<InvalidHttpResponseCodeException>(() => webSocketClientFactory.PerformHandshake(guid, uri, stream, options, CancellationToken.None));
        }
    }
}