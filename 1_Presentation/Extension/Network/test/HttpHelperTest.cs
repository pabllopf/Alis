// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:HttpHelperTest.cs
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
    ///     The http helper test class
    /// </summary>
    public class HttpHelperTest
    {
         [Fact]
        public void CalculateWebSocketKey_ReturnsBase64String()
        {
            string key = HttpHelper.CalculateWebSocketKey();

            Assert.NotNull(key);
            byte[] decoded = Convert.FromBase64String(key);
            Assert.Equal(16, decoded.Length);
        }

        [Fact]
        public void CalculateWebSocketKey_GeneratesDifferentKeys()
        {
            string key1 = HttpHelper.CalculateWebSocketKey();
            string key2 = HttpHelper.CalculateWebSocketKey();

            Assert.NotEqual(key1, key2);
        }

        [Fact]
        public void ComputeSocketAcceptString_WithValidKey_ReturnsAcceptString()
        {
            string key = "dGhlIHNhbXBsZSBub25jZQ==";
            string accept = HttpHelper.ComputeSocketAcceptString(key);

            Assert.NotNull(accept);
            byte[] decoded = Convert.FromBase64String(accept);
            Assert.NotEmpty(decoded);
        }

        [Fact]
        public void ComputeSocketAcceptString_WithDifferentKey_ReturnsDifferentAccept()
        {
            string key1 = "dGhlIHNhbXBsZSBub25jZQ==";
            string key2 = "anotherkey1234567890AB";

            string accept1 = HttpHelper.ComputeSocketAcceptString(key1);
            string accept2 = HttpHelper.ComputeSocketAcceptString(key2);

            Assert.NotEqual(accept1, accept2);
        }

        [Fact]
        public async Task ReadHttpHeaderAsync_WithCancellationToken_ThrowsOperationCanceledException()
        {
            MemoryStream stream = new MemoryStream();
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();

            OperationCanceledException exception = await Assert.ThrowsAnyAsync<OperationCanceledException>(() => 
                HttpHelper.ReadHttpHeaderAsync(stream, cts.Token));

            Assert.NotNull(exception);
        }

        [Fact]
        public void IsWebSocketUpgradeRequest_WithValidRequest_ReturnsTrue()
        {
            string header = "GET /chat HTTP/1.1\r\n" +
                           "Host: example.com:8080\r\n" +
                           "Upgrade: websocket\r\n" +
                           "Connection: Upgrade\r\n" +
                           "Sec-WebSocket-Key: dGhlIHNhbXBsZSBub25jZQ==\r\n" +
                           "Sec-WebSocket-Version: 13\r\n" +
                           "\r\n";

            bool result = HttpHelper.IsWebSocketUpgradeRequest(header);

            Assert.True(result);
        }

        [Fact]
        public void IsWebSocketUpgradeRequest_WithoutUpgradeHeader_ReturnsFalse()
        {
            string header = "GET /api/data HTTP/1.1\r\n" +
                           "Host: example.com:8080\r\n" +
                           "Content-Type: application/json\r\n" +
                           "\r\n";

            bool result = HttpHelper.IsWebSocketUpgradeRequest(header);

            Assert.False(result);
        }

        [Fact]
        public void IsWebSocketUpgradeRequest_CaseInsensitiveMatch_ReturnsTrue()
        {
            string header = "GET /chat HTTP/1.1\r\n" +
                           "Host: example.com:8080\r\n" +
                           "upgrade: WEBSOCKET\r\n" +
                           "connection: upgrade\r\n" +
                           "\r\n";

            bool result = HttpHelper.IsWebSocketUpgradeRequest(header);

            Assert.True(result);
        }
        [Fact]
        public void GetPathFromHeader_WithValidHeader_ReturnsPath()
        {
            string header = "GET /chat/test HTTP/1.1\r\n" +
                           "Host: example.com:8080\r\n" +
                           "\r\n";

            string path = HttpHelper.GetPathFromHeader(header);

            Assert.Equal("/chat/test", path);
        }

        [Fact]
        public void GetPathFromHeader_WithRootPath_ReturnsSlash()
        {
            string header = "GET / HTTP/1.1\r\n" +
                           "Host: example.com:8080\r\n" +
                           "\r\n";

            string path = HttpHelper.GetPathFromHeader(header);

            Assert.Equal("/", path);
        }

        [Fact]
        public void GetPathFromHeader_WithoutGetRequest_ReturnsNull()
        {
            string header = "POST /api HTTP/1.1\r\n" +
                           "Host: example.com:8080\r\n" +
                           "\r\n";

            string path = HttpHelper.GetPathFromHeader(header);

            Assert.Null(path);
        }
        
        [Fact]
        public void GetSubProtocols_WithValidHeader_ReturnsList()
        {
            string header = "GET /chat HTTP/1.1\r\n" +
                           "Host: example.com:8080\r\n" +
                           "Sec-WebSocket-Protocol: chat, json\r\n" +
                           "\r\n";

            IList<string> protocols = HttpHelper.GetSubProtocols(header);

            Assert.NotNull(protocols);
            Assert.Equal(2, protocols.Count);
            Assert.Contains("chat", protocols);
            Assert.Contains("json", protocols);
        }

        [Fact]
        public void GetSubProtocols_WithSingleProtocol_ReturnsListWithOneItem()
        {
            string header = "GET /chat HTTP/1.1\r\n" +
                           "Host: example.com:8080\r\n" +
                           "Sec-WebSocket-Protocol: myprotocol\r\n" +
                           "\r\n";

            IList<string> protocols = HttpHelper.GetSubProtocols(header);

            Assert.NotNull(protocols);
            Assert.Equal(1, protocols.Count);
            Assert.Equal("myprotocol", protocols[0]);
        }

        [Fact]
        public void GetSubProtocols_WithoutProtocolHeader_ReturnsEmptyList()
        {
            string header = "GET /chat HTTP/1.1\r\n" +
                           "Host: example.com:8080\r\n" +
                           "\r\n";

            IList<string> protocols = HttpHelper.GetSubProtocols(header);

            Assert.NotNull(protocols);
            Assert.Empty(protocols);
        }

        [Fact]
        public void GetSubProtocols_WithTrimmedProtocols_ReturnsTrimmedList()
        {
            string header = "GET /chat HTTP/1.1\r\n" +
                           "Host: example.com:8080\r\n" +
                           "Sec-WebSocket-Protocol:  chat  ,  json  \r\n" +
                           "\r\n";

            IList<string> protocols = HttpHelper.GetSubProtocols(header);

            Assert.Equal("chat", protocols[0]);
            Assert.Equal("json", protocols[1]);
        }
        
        [Fact]
        public void ReadHttpResponseCode_WithValidResponse_ReturnsCode()
        {
            string response = "HTTP/1.1 101 Switching Protocols\r\n" +
                             "Date: Tue, 02 Jun 2026\r\n" +
                             "\r\n";

            string code = HttpHelper.ReadHttpResponseCode(response);

            Assert.Equal("101 Switching Protocols", code);
        }

        [Fact]
        public void ReadHttpResponseCode_With404Response_ReturnsCode()
        {
            string response = "HTTP/1.1 404 Not Found\r\n" +
                             "Content-Type: text/plain\r\n" +
                             "\r\n";

            string code = HttpHelper.ReadHttpResponseCode(response);

            Assert.Equal("404 Not Found", code);
        }

 

        [Fact]
        public void ReadHttpResponseCode_WithInvalidResponse_ReturnsNull()
        {
            string response = "INVALID RESPONSE\r\n";

            string code = HttpHelper.ReadHttpResponseCode(response);

            Assert.Null(code);
        }

        [Fact]
        public async Task WriteHttpHeaderAsync_WritesValidHeader()
        {
            string response = "HTTP/1.1 101 Switching Protocols";
            MemoryStream stream = new MemoryStream();

            await HttpHelper.WriteHttpHeaderAsync(response, stream, CancellationToken.None);

            stream.Position = 0;
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);

            string written = Encoding.UTF8.GetString(bytes);
            Assert.Contains("HTTP/1.1 101 Switching Protocols", written);
            Assert.Contains("\r\n\r\n", written);
        }

        [Fact]
        public async Task WriteHttpHeaderAsync_WithTrimmedResponse_AddsNewlines()
        {
            string response = "  HTTP/1.1 200 OK  ";
            MemoryStream stream = new MemoryStream();

            await HttpHelper.WriteHttpHeaderAsync(response, stream, CancellationToken.None);

            stream.Position = 0;
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);

            string written = Encoding.UTF8.GetString(bytes);
            Assert.Contains("HTTP/1.1 200 OK", written);
            Assert.EndsWith("\r\n\r\n", written);
        }

        [Fact]
        public async Task WriteHttpHeaderAsync_WithCancellationToken_WritesToStream()
        {
            string response = "HTTP/1.1 200 OK";
            MemoryStream stream = new MemoryStream();
            CancellationToken cts = CancellationToken.None;

            await HttpHelper.WriteHttpHeaderAsync(response, stream, cts);

            Assert.True(stream.Length > 0);
        }
        
        /// <summary>
        ///     Tests that calculate web socket key should return valid key
        /// </summary>
        [Fact]
        public void CalculateWebSocketKey_ShouldReturnValidKey()
        {
            string key = HttpHelper.CalculateWebSocketKey();
            Assert.NotNull(key);
            Assert.Equal(24, key.Length); // Base64 string should be 24 characters long
        }

        /// <summary>
        ///     Tests that compute socket accept string should return valid accept string
        /// </summary>
        [Fact]
        public void ComputeSocketAcceptString_ShouldReturnValidAcceptString()
        {
            string key = HttpHelper.CalculateWebSocketKey();
            string acceptString = HttpHelper.ComputeSocketAcceptString(key);
            Assert.NotNull(acceptString);
        }

        /// <summary>
        ///     Tests that read http header async should return valid header
        /// </summary>
        [Fact]
        public async Task ReadHttpHeaderAsync_ShouldReturnValidHeader()
        {
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes("GET / HTTP/1.1\r\n\r\n"));
            string header = await HttpHelper.ReadHttpHeaderAsync(stream, CancellationToken.None);
            Assert.Equal("GET / HTTP/1.1", header.Trim());
        }

        /// <summary>
        ///     Tests that is web socket upgrade request should return true for valid request
        /// </summary>
        [Fact]
        public void IsWebSocketUpgradeRequest_ShouldReturnTrueForValidRequest()
        {
            string header = "GET / HTTP/1.1\r\nUpgrade: websocket\r\n\r\n";
            bool result = HttpHelper.IsWebSocketUpgradeRequest(header);
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that get path from header should return correct path
        /// </summary>
        [Fact]
        public void GetPathFromHeader_ShouldReturnCorrectPath()
        {
            string header = "GET /test HTTP/1.1\r\n\r\n";
            string path = HttpHelper.GetPathFromHeader(header);
            Assert.Equal("/test", path);
        }

        /// <summary>
        ///     Tests that get sub protocols should return correct protocols
        /// </summary>
        [Fact]
        public void GetSubProtocols_ShouldReturnCorrectProtocols()
        {
            string header = "GET / HTTP/1.1\r\nSec-WebSocket-Protocol: protocol1, protocol2\r\n\r\n";
            IList<string> protocols = HttpHelper.GetSubProtocols(header);
            Assert.Contains("protocol1", protocols);
            Assert.Contains("protocol2", protocols);
        }

        /// <summary>
        ///     Tests that read http response code should return correct response code
        /// </summary>
        [Fact]
        public void ReadHttpResponseCode_ShouldReturnCorrectResponseCode()
        {
            string response = "HTTP/1.1 200 OK\r\n\r\n";
            string responseCode = HttpHelper.ReadHttpResponseCode(response);
            Assert.Equal("200 OK", responseCode);
        }

        /// <summary>
        ///     Tests that write http header async should write correct header
        /// </summary>
        [Fact]
        public async Task WriteHttpHeaderAsync_ShouldWriteCorrectHeader()
        {
            MemoryStream stream = new MemoryStream();
            await HttpHelper.WriteHttpHeaderAsync("HTTP/1.1 200 OK", stream, CancellationToken.None);
            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);
            string header = await reader.ReadToEndAsync();
            Assert.Equal("HTTP/1.1 200 OK\r\n\r\n", header);
        }

        /// <summary>
        ///     Tests that is web socket upgrade request should return true when web socket upgrade request
        /// </summary>
        [Fact]
        public void IsWebSocketUpgradeRequest_ShouldReturnTrue_WhenWebSocketUpgradeRequest()
        {
            string header = "GET /chat HTTP/1.1\r\n" +
                            "Host: server.example.com\r\n" +
                            "Upgrade: websocket\r\n" +
                            "Connection: Upgrade\r\n" +
                            "Sec-WebSocket-Key: x3JJHMbDL1EzLkh9GBhXDw==\r\n" +
                            "Sec-WebSocket-Protocol: chat, superchat\r\n" +
                            "Sec-WebSocket-Version: 13\r\n" +
                            "Origin: http://example.com\r\n";

            bool result = HttpHelper.IsWebSocketUpgradeRequest(header);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that is web socket upgrade request should return false when not web socket upgrade request
        /// </summary>
        [Fact]
        public void IsWebSocketUpgradeRequest_ShouldReturnFalse_WhenNotWebSocketUpgradeRequest()
        {
            string header = "GET /chat HTTP/1.1\r\n" +
                            "Host: server.example.com\r\n" +
                            "Connection: Upgrade\r\n" +
                            "Sec-WebSocket-Key: x3JJHMbDL1EzLkh9GBhXDw==\r\n" +
                            "Sec-WebSocket-Protocol: chat, superchat\r\n" +
                            "Sec-WebSocket-Version: 13\r\n" +
                            "Origin: http://example.com\r\n";

            bool result = HttpHelper.IsWebSocketUpgradeRequest(header);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that get sub protocols should return correct protocols v 2
        /// </summary>
        [Fact]
        public void GetSubProtocols_ShouldReturnCorrectProtocols_v2()
        {
            string header = "GET / HTTP/1.1\r\nSec-WebSocket-Protocol: protocol1, protocol2\r\n\r\n";
            IList<string> protocols = HttpHelper.GetSubProtocols(header);
            Assert.Contains("protocol1", protocols);
            Assert.Contains("protocol2", protocols);
        }

        /// <summary>
        ///     Tests that get sub protocols should return empty list when no protocols
        /// </summary>
        [Fact]
        public void GetSubProtocols_ShouldReturnEmptyList_WhenNoProtocols()
        {
            string header = "GET / HTTP/1.1\r\n\r\n";
            IList<string> protocols = HttpHelper.GetSubProtocols(header);
            Assert.Empty(protocols);
        }

        /// <summary>
        ///     Tests that get sub protocols should throw exception when header too large
        /// </summary>
        [Fact]
        public void GetSubProtocols_ShouldThrowException_WhenHeaderTooLarge()
        {
            string header = "GET / HTTP/1.1\r\nSec-WebSocket-Protocol: " + new string('a', 2050) + "\r\n\r\n";
            Assert.Throws<EntityTooLargeException>(() => HttpHelper.GetSubProtocols(header));
        }
    }
}