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
using Alis.Extension.Network;
using Xunit;

namespace Alis.Extension.Network.Test
{
    /// <summary>
    ///     Tests for HttpHelper class
    /// </summary>
    public class HttpHelperTest
    {
        [Fact]
        public void CalculateWebSocketKey_ReturnsBase64String()
        {
            // Arrange
            // Act
            string result = HttpHelper.CalculateWebSocketKey();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.True(result.Length > 0);
        }

        [Fact]
        public void CalculateWebSocketKey_ReturnsDifferentValues()
        {
            // Arrange
            // Act
            string key1 = HttpHelper.CalculateWebSocketKey();
            string key2 = HttpHelper.CalculateWebSocketKey();

            // Assert
            Assert.NotEqual(key1, key2);
        }

        [Fact]
        public void ComputeSocketAcceptString_ReturnsBase64String()
        {
            // Arrange
            string key = "dGhlIHNhbXBsZSBub25jZQ==";

            // Act
            string result = HttpHelper.ComputeSocketAcceptString(key);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.True(result.Length > 0);
        }

        [Fact]
        public void ComputeSocketAcceptString_WithValidKey_ReturnsCorrectFormat()
        {
            // Arrange
            string key = "dGhlIHNhbXBsZSBub25jZQ==";

            // Act
            string result = HttpHelper.ComputeSocketAcceptString(key);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Length > 0);
        }

        [Fact]
        public async Task ReadHttpHeaderAsync_ReadsValidHeader()
        {
            // Arrange
            string header = "GET /chat HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\n\r\n";
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(header));

            // Act
            string result = await HttpHelper.ReadHttpHeaderAsync(stream, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Contains("GET", result);
            Assert.Contains("websocket", result);
        }

        [Fact]
        public async Task ReadHttpHeaderAsync_HeaderTooLarge_ThrowsException()
        {
            // Arrange
            string header = "GET /chat HTTP/1.1\r\nHost: example.com\r\n";
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(header));

            // Act
            Exception exception = await Record.ExceptionAsync(() => HttpHelper.ReadHttpHeaderAsync(stream, CancellationToken.None));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<EntityTooLargeException>(exception);
        }

        [Fact]
        public void IsWebSocketUpgradeRequest_WithValidHeader_ReturnsTrue()
        {
            // Arrange
            string header = "GET /chat HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\n\r\n";

            // Act
            bool result = HttpHelper.IsWebSocketUpgradeRequest(header);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsWebSocketUpgradeRequest_WithoutWebsocket_ReturnsFalse()
        {
            // Arrange
            string header = "GET /chat HTTP/1.1\r\nHost: example.com\r\n\r\n";

            // Act
            bool result = HttpHelper.IsWebSocketUpgradeRequest(header);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsWebSocketUpgradeRequest_WithInvalidHeader_ReturnsFalse()
        {
            // Arrange
            string header = "INVALID HEADER";

            // Act
            bool result = HttpHelper.IsWebSocketUpgradeRequest(header);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetPathFromHeader_ReturnsCorrectPath()
        {
            // Arrange
            string header = "GET /chat?room=123 HTTP/1.1\r\nHost: example.com\r\n\r\n";

            // Act
            string result = HttpHelper.GetPathFromHeader(header);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("/chat?room=123", result.Trim());
        }

        [Fact]
        public void GetPathFromHeader_WithInvalidHeader_ReturnsNull()
        {
            // Arrange
            string header = "INVALID HEADER";

            // Act
            string result = HttpHelper.GetPathFromHeader(header);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetSubProtocols_ReturnsEmptyListWhenNoProtocol()
        {
            // Arrange
            string header = "GET /chat HTTP/1.1\r\nHost: example.com\r\n\r\n";

            // Act
            IList<string> result = HttpHelper.GetSubProtocols(header);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void GetSubProtocols_ReturnsListWithSingleProtocol()
        {
            // Arrange
            string header = "GET /chat HTTP/1.1\r\nHost: example.com\r\nSec-WebSocket-Protocol: json\r\n\r\n";

            // Act
            IList<string> result = HttpHelper.GetSubProtocols(header);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("json", result[0]);
        }

        [Fact]
        public void GetSubProtocols_ReturnsListWithMultipleProtocols()
        {
            // Arrange
            string header = "GET /chat HTTP/1.1\r\nHost: example.com\r\nSec-WebSocket-Protocol: json, binary\r\n\r\n";

            // Act
            IList<string> result = HttpHelper.GetSubProtocols(header);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Contains("json", result);
            Assert.Contains("binary", result);
        }

        [Fact]
        public void ReadHttpResponseCode_ReturnsCorrectCode()
        {
            // Arrange
            string response = "HTTP/1.1 101 Switching Protocols\r\nUpgrade: websocket\r\n\r\n";

            // Act
            string result = HttpHelper.ReadHttpResponseCode(response);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("101 Switching Protocols", result.Trim());
        }

        [Fact]
        public void ReadHttpResponseCode_WithInvalidResponse_ReturnsNull()
        {
            // Arrange
            string response = "INVALID RESPONSE";

            // Act
            string result = HttpHelper.ReadHttpResponseCode(response);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task WriteHttpHeaderAsync_WritesValidHeader()
        {
            // Arrange
            string response = "HTTP/1.1 101 Switching Protocols";
            MemoryStream stream = new MemoryStream();

            // Act
            await HttpHelper.WriteHttpHeaderAsync(response, stream, CancellationToken.None);

            // Assert
            stream.Position = 0;
            string result = Encoding.UTF8.GetString(stream.ToArray());
            Assert.Contains("HTTP/1.1 101 Switching Protocols", result);
        }

        [Fact]
        public void CalculateWebSocketKey_ReturnsValidBase64()
        {
            // Arrange
            // Act
            string key = HttpHelper.CalculateWebSocketKey();

            // Assert
            Assert.NotNull(key);
            byte[] decoded = Convert.FromBase64String(key);
            Assert.Equal(16, decoded.Length);
        }

        [Fact]
        public void ComputeSocketAcceptString_WithStandardKey_ReturnsCorrectAccept()
        {
            // Arrange
            string key = "dGhlIHNhbXBsZSBub25jZQ==";

            // Act
            string accept = HttpHelper.ComputeSocketAcceptString(key);

            // Assert
            Assert.NotNull(accept);
            Assert.NotEmpty(accept);
        }
    }
}
