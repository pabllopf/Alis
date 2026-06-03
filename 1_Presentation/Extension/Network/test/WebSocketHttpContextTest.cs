// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketHttpContextTest.cs
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
using Alis.Extension.Network;
using Xunit;

namespace Alis.Extension.Network.Test
{
    /// <summary>
    ///     Tests for WebSocketHttpContext class
    /// </summary>
    public class WebSocketHttpContextTest
    {
        [Fact]
        public void Constructor_CreatesInstanceWithValidRequest()
        {
            // Arrange
            bool isWebSocketRequest = true;
            List<string> protocols = new List<string> { "json", "binary" };
            string header = "GET / HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\n\r\n";
            string path = "/chat";
            MemoryStream stream = new MemoryStream();

            // Act
            WebSocketHttpContext context = new WebSocketHttpContext(isWebSocketRequest, protocols, header, path, stream);

            // Assert
            Assert.NotNull(context);
            Assert.True(context.IsWebSocketRequest);
            Assert.Equal("/chat", context.Path);
        }

        [Fact]
        public void IsWebSocketRequest_ReturnsCorrectValue()
        {
            // Arrange
            bool isWebSocketRequest = true;
            List<string> protocols = new List<string>();
            string header = "GET / HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\n\r\n";
            string path = "/";
            MemoryStream stream = new MemoryStream();

            // Act
            WebSocketHttpContext context = new WebSocketHttpContext(isWebSocketRequest, protocols, header, path, stream);

            // Assert
            Assert.True(context.IsWebSocketRequest);
        }

        [Fact]
        public void IsWebSocketRequest_ReturnsFalseWhenNotWebsocket()
        {
            // Arrange
            bool isWebSocketRequest = false;
            List<string> protocols = new List<string>();
            string header = "GET / HTTP/1.1\r\nHost: example.com\r\n\r\n";
            string path = "/";
            MemoryStream stream = new MemoryStream();

            // Act
            WebSocketHttpContext context = new WebSocketHttpContext(isWebSocketRequest, protocols, header, path, stream);

            // Assert
            Assert.False(context.IsWebSocketRequest);
        }

        [Fact]
        public void WebSocketRequestedProtocols_ReturnsCorrectList()
        {
            // Arrange
            bool isWebSocketRequest = true;
            List<string> protocols = new List<string> { "json", "binary", "custom" };
            string header = "GET / HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\n\r\n";
            string path = "/";
            MemoryStream stream = new MemoryStream();

            // Act
            WebSocketHttpContext context = new WebSocketHttpContext(isWebSocketRequest, protocols, header, path, stream);

            // Assert
            Assert.NotNull(context.WebSocketRequestedProtocols);
            Assert.Equal(3, context.WebSocketRequestedProtocols.Count);
            Assert.Contains("json", context.WebSocketRequestedProtocols);
            Assert.Contains("binary", context.WebSocketRequestedProtocols);
            Assert.Contains("custom", context.WebSocketRequestedProtocols);
        }

        [Fact]
        public void WebSocketRequestedProtocols_ReturnsEmptyListWhenNoProtocols()
        {
            // Arrange
            bool isWebSocketRequest = true;
            List<string> protocols = new List<string>();
            string header = "GET / HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\n\r\n";
            string path = "/";
            MemoryStream stream = new MemoryStream();

            // Act
            WebSocketHttpContext context = new WebSocketHttpContext(isWebSocketRequest, protocols, header, path, stream);

            // Assert
            Assert.NotNull(context.WebSocketRequestedProtocols);
            Assert.Empty(context.WebSocketRequestedProtocols);
        }

        [Fact]
        public void HttpHeader_ReturnsCorrectHeader()
        {
            // Arrange
            bool isWebSocketRequest = true;
            List<string> protocols = new List<string>();
            string header = "GET /chat?room=123 HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\n\r\n";
            string path = "/chat?room=123";
            MemoryStream stream = new MemoryStream();

            // Act
            WebSocketHttpContext context = new WebSocketHttpContext(isWebSocketRequest, protocols, header, path, stream);

            // Assert
            Assert.NotNull(context.HttpHeader);
            Assert.Contains("GET", context.HttpHeader);
            Assert.Contains("websocket", context.HttpHeader);
        }

        [Fact]
        public void Path_ReturnsCorrectPath()
        {
            // Arrange
            bool isWebSocketRequest = true;
            List<string> protocols = new List<string>();
            string header = "GET /chat?room=123 HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\n\r\n";
            string path = "/chat?room=123";
            MemoryStream stream = new MemoryStream();

            // Act
            WebSocketHttpContext context = new WebSocketHttpContext(isWebSocketRequest, protocols, header, path, stream);

            // Assert
            Assert.Equal("/chat?room=123", context.Path);
        }

        [Fact]
        public void Stream_ReturnsCorrectStream()
        {
            // Arrange
            bool isWebSocketRequest = true;
            List<string> protocols = new List<string>();
            string header = "GET / HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\n\r\n";
            string path = "/";
            MemoryStream stream = new MemoryStream();

            // Act
            WebSocketHttpContext context = new WebSocketHttpContext(isWebSocketRequest, protocols, header, path, stream);

            // Assert
            Assert.NotNull(context.Stream);
            Assert.IsType<MemoryStream>(context.Stream);
        }

        [Fact]
        public void CreateNewInstance_InitializesAllProperties()
        {
            // Arrange
            // Act
            WebSocketHttpContext context = new WebSocketHttpContext(true, new List<string>(), "GET / HTTP/1.1\r\n\r\n", "/", new MemoryStream());

            // Assert
            Assert.NotNull(context);
            Assert.True(context.IsWebSocketRequest);
            Assert.NotNull(context.WebSocketRequestedProtocols);
            Assert.NotNull(context.HttpHeader);
            Assert.NotNull(context.Path);
            Assert.NotNull(context.Stream);
        }

        [Fact]
        public void WebSocketRequestedProtocols_IsReadOnly()
        {
            // Arrange
            bool isWebSocketRequest = true;
            List<string> protocols = new List<string> { "json" };
            string header = "GET / HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\n\r\n";
            string path = "/";
            MemoryStream stream = new MemoryStream();

            // Act
            WebSocketHttpContext context = new WebSocketHttpContext(isWebSocketRequest, protocols, header, path, stream);

            // Assert
            Assert.NotNull(context.WebSocketRequestedProtocols);
            Assert.IsAssignableFrom<IList<string>>(context.WebSocketRequestedProtocols);
        }

        [Fact]
        public void HttpHeader_ContainsFullHeader()
        {
            // Arrange
            bool isWebSocketRequest = true;
            List<string> protocols = new List<string>();
            string header = "GET /chat HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\nSec-WebSocket-Key: dGhlIHNhbXBsZSBub25jZQ==\r\nSec-WebSocket-Version: 13\r\n\r\n";
            string path = "/chat";
            MemoryStream stream = new MemoryStream();

            // Act
            WebSocketHttpContext context = new WebSocketHttpContext(isWebSocketRequest, protocols, header, path, stream);

            // Assert
            Assert.NotNull(context.HttpHeader);
            Assert.Contains("Sec-WebSocket-Key", context.HttpHeader);
            Assert.Contains("Sec-WebSocket-Version", context.HttpHeader);
        }

        [Fact]
        public void Path_WithSpecialCharacters()
        {
            // Arrange
            bool isWebSocketRequest = true;
            List<string> protocols = new List<string>();
            string header = "GET /chat?room=123&user=test HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\n\r\n";
            string path = "/chat?room=123&user=test";
            MemoryStream stream = new MemoryStream();

            // Act
            WebSocketHttpContext context = new WebSocketHttpContext(isWebSocketRequest, protocols, header, path, stream);

            // Assert
            Assert.Equal("/chat?room=123&user=test", context.Path);
        }

        [Fact]
        public void Stream_IsSameInstance()
        {
            // Arrange
            bool isWebSocketRequest = true;
            List<string> protocols = new List<string>();
            string header = "GET / HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\n\r\n";
            string path = "/";
            MemoryStream stream = new MemoryStream();

            // Act
            WebSocketHttpContext context = new WebSocketHttpContext(isWebSocketRequest, protocols, header, path, stream);

            // Assert
            Assert.Same(stream, context.Stream);
        }

        [Fact]
        public void WebSocketRequestedProtocols_WithSingleProtocol()
        {
            // Arrange
            bool isWebSocketRequest = true;
            List<string> protocols = new List<string> { "json" };
            string header = "GET / HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\n\r\n";
            string path = "/";
            MemoryStream stream = new MemoryStream();

            // Act
            WebSocketHttpContext context = new WebSocketHttpContext(isWebSocketRequest, protocols, header, path, stream);

            // Assert
            Assert.Single(context.WebSocketRequestedProtocols);
            Assert.Equal("json", context.WebSocketRequestedProtocols[0]);
        }

        [Fact]
        public void CreateInstance_WithNullProtocols()
        {
            // Arrange
            // Act
            WebSocketHttpContext context = new WebSocketHttpContext(true, null, "GET / HTTP/1.1\r\n\r\n", "/", new MemoryStream());

            // Assert
            Assert.NotNull(context);
        }
    }
}
