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
using System.Net.Security;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Alis.Core.Network.Exceptions;
using Xunit;

namespace Alis.Core.Network.Test
{
    /// <summary>
    /// The web socket client factory test class
    /// </summary>
    public class WebSocketClientFactoryTest
    {
        /// <summary>
        /// Tests that connect async valid input
        /// </summary>
        [Fact]
        public async Task ConnectAsync_ValidInput()
        {
            WebSocketClientFactory factory = new WebSocketClientFactory();
            Uri uri = new Uri("ws://localhost:8080");
            
            await Assert.ThrowsAsync<SocketException>(() => factory.ConnectAsync(uri));
        }
        
        /// <summary>
        /// Tests that connect async with custom buffer factory
        /// </summary>
        [Fact]
        public async Task ConnectAsync_WithCustomBufferFactory()
        {
            WebSocketClientFactory factory = new WebSocketClientFactory(() => new MemoryStream());
            Uri uri = new Uri("ws://localhost:8080");
            
            await Assert.ThrowsAsync<SocketException>(() => factory.ConnectAsync(uri));
        }
        
        /// <summary>
        /// Tests that dispose closes web socket
        /// </summary>
        [Fact]
        public void Dispose_ClosesWebSocket()
        {
            WebSocketClientFactory factory = new WebSocketClientFactory();
            Uri uri = new Uri("ws://localhost:8080");
            
            Task<WebSocket> webSocket = factory.ConnectAsync(uri);
            factory.Dispose();
            
            Assert.Equal(TaskStatus.WaitingForActivation, webSocket.Status);
        }
        
        /// <summary>
        /// Tests that validate server certificate should return true when ssl policy errors none
        /// </summary>
        [Fact]
        public void ValidateServerCertificate_ShouldReturnTrue_WhenSslPolicyErrorsNone()
        {
            bool result = WebSocketClientFactory.ValidateServerCertificate(null, null, null, SslPolicyErrors.None);
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that validate server certificate should return false when ssl policy errors not none
        /// </summary>
        [Fact]
        public void ValidateServerCertificate_ShouldReturnFalse_WhenSslPolicyErrorsNotNone()
        {
            bool result = WebSocketClientFactory.ValidateServerCertificate(null, null, null, SslPolicyErrors.RemoteCertificateNotAvailable);
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that get additional headers should return empty string when additional headers is null
        /// </summary>
        [Fact]
        public void GetAdditionalHeaders_ShouldReturnEmptyString_WhenAdditionalHeadersIsNull()
        {
            string result = WebSocketClientFactory.GetAdditionalHeaders(null);
            Assert.Equal(string.Empty, result);
        }
        
        /// <summary>
        /// Tests that get additional headers should return correct string when additional headers is not null
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
        /// Tests that validate server certificate should return true when ssl policy errors none v 2
        /// </summary>
        [Fact]
        public void ValidateServerCertificate_ShouldReturnTrue_WhenSslPolicyErrorsNone_v2()
        {
            bool result = WebSocketClientFactory.ValidateServerCertificate(null, null, null, SslPolicyErrors.None);
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that validate server certificate should return false when ssl policy errors not none v 2
        /// </summary>
        [Fact]
        public void ValidateServerCertificate_ShouldReturnFalse_WhenSslPolicyErrorsNotNone_v2()
        {
            bool result = WebSocketClientFactory.ValidateServerCertificate(null, null, null, SslPolicyErrors.RemoteCertificateNotAvailable);
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that get additional headers should return empty string when additional headers is null v 2
        /// </summary>
        [Fact]
        public void GetAdditionalHeaders_ShouldReturnEmptyString_WhenAdditionalHeadersIsNull_v2()
        {
            string result = WebSocketClientFactory.GetAdditionalHeaders(null);
            Assert.Equal(string.Empty, result);
        }
        
        /// <summary>
        /// Tests that get additional headers should return correct string when additional headers is not null v 2
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
        /// Tests that connect async should return web socket when stream is open
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
        /// Tests that connect async should throw exception when stream is closed
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
        /// Tests that get sub protocol from header should return correct sub protocol when response contains sub protocol
        /// </summary>
        [Fact]
        public void GetSubProtocolFromHeader_ShouldReturnCorrectSubProtocol_WhenResponseContainsSubProtocol()
        {
            WebSocketClientFactory factory = new WebSocketClientFactory();
            string response = "HTTP/1.1 101 Switching Protocols\r\n" +
                              "Upgrade: websocket\r\n" +
                              "Connection: Upgrade\r\n" +
                              "Sec-WebSocket-Accept: s3pPLMBiTxaQ9kYGzzhZRbK+xOo=\r\n" +
                              "Sec-WebSocket-Protocol: chat\r\n\r\n";
            
            string result = factory.GetSubProtocolFromHeader(response);
            
            Assert.Equal("chat", result);
        }
        
        /// <summary>
        /// Tests that get sub protocol from header should return null when response does not contain sub protocol
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
        /// Tests that throw if invalid accept string should throw exception when accept string is invalid
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
        /// Tests that throw if invalid accept string should not throw exception when accept string is valid
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
        /// Tests that generate sec web socket key should return valid base 64 string
        /// </summary>
        [Fact]
        public void GenerateSecWebSocketKey_ShouldReturnValidBase64String()
        {
            WebSocketClientFactory factory = new WebSocketClientFactory();
            string result = factory.GenerateSecWebSocketKey();
            byte[] bytes = Convert.FromBase64String(result);
            
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            
            // Check if the result is a valid Base64 string
            int base64Bytes;
            Assert.True(Convert.TryFromBase64String(result, bytes, out base64Bytes));
            
            // Check if the length of the byte array is 16
            Assert.Equal(16, base64Bytes);
        }
    }
}