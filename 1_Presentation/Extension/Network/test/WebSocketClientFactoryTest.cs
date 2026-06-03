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
using System.IO;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network;
using Alis.Extension.Network.Internal;
using Xunit;

namespace Alis.Extension.Network.Test
{
    /// <summary>
    ///     Tests for WebSocketClientFactory class
    /// </summary>
    public class WebSocketClientFactoryTest
    {
        [Fact]
        public void Constructor_CreatesInstance()
        {
            // Arrange
            // Act
            WebSocketClientFactory factory = new WebSocketClientFactory();

            // Assert
            Assert.NotNull(factory);
        }

        [Fact]
        public async Task ConnectAsync_WithUri_ReturnsConnectedWebSocket()
        {
            // Arrange
            WebSocketClientFactory factory = new WebSocketClientFactory();
            Uri uri = new Uri("ws://localhost:8080");

            // Act
            WebSocket result = await factory.ConnectAsync(uri);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<WebSocketImplementation>(result);
        }

        [Fact]
        public async Task ConnectAsync_WithValidUri_ReturnsWebSocket()
        {
            // Arrange
            WebSocketClientFactory factory = new WebSocketClientFactory();
            Uri uri = new Uri("ws://example.com/chat");

            // Act
            WebSocket result = await factory.ConnectAsync(uri);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ConnectAsync_WithWssUri_ReturnsWebSocket()
        {
            // Arrange
            WebSocketClientFactory factory = new WebSocketClientFactory();
            Uri uri = new Uri("wss://secure.example.com");

            // Act
            WebSocket result = await factory.ConnectAsync(uri);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ConnectAsync_WithOptions_ReturnsWebSocket()
        {
            // Arrange
            WebSocketClientFactory factory = new WebSocketClientFactory();
            Uri uri = new Uri("ws://localhost:8080");
            WebSocketClientOptions options = new WebSocketClientOptions();

            // Act
            WebSocket result = await factory.ConnectAsync(uri, options);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<WebSocketImplementation>(result);
        }

        [Fact]
        public async Task ConnectAsync_WithStream_ReturnsWebSocket()
        {
            // Arrange
            WebSocketClientFactory factory = new WebSocketClientFactory();
            MemoryStream stream = new MemoryStream();
            string key = "dGhlIHNhbXBsZSBub25jZQ==";
            WebSocketClientOptions options = new WebSocketClientOptions();

            // Act
            WebSocket result = await factory.ConnectAsync(stream, key, options);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void ConnectAsync_WithDefaultToken_ReturnsWebSocket()
        {
            // Arrange
            WebSocketClientFactory factory = new WebSocketClientFactory();
            Uri uri = new Uri("ws://localhost:8080");

            // Act
            Task<WebSocket> result = factory.ConnectAsync(uri);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(TaskStatus.RanToCompletion, result.Status);
        }

        [Fact]
        public async Task ConnectAsync_WithCancellationToken_ReturnsWebSocket()
        {
            // Arrange
            WebSocketClientFactory factory = new WebSocketClientFactory();
            Uri uri = new Uri("ws://localhost:8080");
            CancellationToken token = new CancellationToken();

            // Act
            WebSocket result = await factory.ConnectAsync(uri, token);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ConnectAsync_WithValidOptions_ReturnsWebSocket()
        {
            // Arrange
            WebSocketClientFactory factory = new WebSocketClientFactory();
            Uri uri = new Uri("ws://localhost:8080");
            WebSocketClientOptions options = new WebSocketClientOptions
            {
                KeepAliveInterval = TimeSpan.FromSeconds(20),
                NoDelay = true,
                IncludeExceptionInCloseResponse = false
            };

            // Act
            WebSocket result = await factory.ConnectAsync(uri, options);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<WebSocketImplementation>(result);
        }

        [Fact]
        public async Task ConnectAsync_WithAdditionalHeaders_ReturnsWebSocket()
        {
            // Arrange
            WebSocketClientFactory factory = new WebSocketClientFactory();
            Uri uri = new Uri("ws://localhost:8080");
            WebSocketClientOptions options = new WebSocketClientOptions
            {
                AdditionalHttpHeaders = { { "X-Custom-Header", "value" } }
            };

            // Act
            WebSocket result = await factory.ConnectAsync(uri, options);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ConnectAsync_WithSubProtocol_ReturnsWebSocket()
        {
            // Arrange
            WebSocketClientFactory factory = new WebSocketClientFactory();
            Uri uri = new Uri("ws://localhost:8080");
            WebSocketClientOptions options = new WebSocketClientOptions
            {
                SecWebSocketProtocol = "json"
            };

            // Act
            WebSocket result = await factory.ConnectAsync(uri, options);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void ConnectAsync_ReturnsTaskThatCompletes()
        {
            // Arrange
            WebSocketClientFactory factory = new WebSocketClientFactory();
            Uri uri = new Uri("ws://localhost:8080");

            // Act
            Task<WebSocket> task = factory.ConnectAsync(uri);

            // Assert
            Assert.NotNull(task);
            Assert.Equal(TaskStatus.RanToCompletion, task.Status);
        }

        [Fact]
        public async Task ConnectAsync_WithNullOptions_ReturnsWebSocket()
        {
            // Arrange
            WebSocketClientFactory factory = new WebSocketClientFactory();
            Uri uri = new Uri("ws://localhost:8080");

            // Act
            WebSocket result = await factory.ConnectAsync(uri, null);

            // Assert
            Assert.NotNull(result);
        }
    }
}
