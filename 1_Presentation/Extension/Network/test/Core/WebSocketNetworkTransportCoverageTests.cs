// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketNetworkTransportCoverageTests.cs
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
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Core;
using Moq;
using Xunit;

namespace Alis.Extension.Network.Test.Core
{
    /// <summary>
    ///     Coverage-driven tests for WebSocketNetworkTransport internal branches
    /// </summary>
    public class WebSocketNetworkTransportCoverageTests
    {
        /// <summary>
        ///     Tests that ReceiveAsync returns queued message when message is in queue
        /// </summary>
        [Fact]
        public async Task ReceiveAsync_WithQueuedMessage_ReturnsMessage()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport();
            NetworkMessageEnvelope envelope = new NetworkMessageEnvelope { MessageId = "msg-001" };
            transport._messageQueue.Enqueue(("client-x", envelope));

            (string clientId, NetworkMessageEnvelope message) = await transport.ReceiveAsync();

            Assert.Equal("client-x", clientId);
            Assert.Equal("msg-001", message.MessageId);
        }

        /// <summary>
        ///     Tests that SendAsync throws when client socket is not open
        /// </summary>
        [Fact]
        public async Task SendAsync_WithNonOpenSocket_ThrowsInvalidOperationException()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport();
            Mock<WebSocket> mockSocket = new Mock<WebSocket>();
            mockSocket.Setup(s => s.State).Returns(WebSocketState.Closed);
            transport._clientSockets.TryAdd("client-1", mockSocket.Object);

            InvalidOperationException ex = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                transport.SendAsync("client-1", new NetworkMessageEnvelope()));

            Assert.Contains("connection not open", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        ///     Tests that SendAsync completes when socket is open
        /// </summary>
        [Fact]
        public async Task SendAsync_WithOpenSocket_CompletesSuccessfully()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport();
            Mock<WebSocket> mockSocket = new Mock<WebSocket>();
            mockSocket.Setup(s => s.State).Returns(WebSocketState.Open);
            mockSocket.Setup(s => s.SendAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<WebSocketMessageType>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            transport._clientSockets.TryAdd("client-1", mockSocket.Object);

            Exception ex = await Record.ExceptionAsync(() =>
                transport.SendAsync("client-1", new NetworkMessageEnvelope { MessageId = "test" }));

            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests that BroadcastAsync sends to all open clients
        /// </summary>
        [Fact]
        public async Task BroadcastAsync_WithMultipleClients_SendsToAll()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport();
            Mock<WebSocket> mock1 = new Mock<WebSocket>();
            mock1.Setup(s => s.State).Returns(WebSocketState.Open);
            mock1.Setup(s => s.SendAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<WebSocketMessageType>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            Mock<WebSocket> mock2 = new Mock<WebSocket>();
            mock2.Setup(s => s.State).Returns(WebSocketState.Open);
            mock2.Setup(s => s.SendAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<WebSocketMessageType>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            transport._clientSockets.TryAdd("a", mock1.Object);
            transport._clientSockets.TryAdd("b", mock2.Object);

            Exception ex = await Record.ExceptionAsync(() =>
                transport.BroadcastAsync(new NetworkMessageEnvelope { MessageId = "bcast" }));

            Assert.Null(ex);
            mock1.Verify(s => s.SendAsync(It.IsAny<ArraySegment<byte>>(), WebSocketMessageType.Text, true, It.IsAny<CancellationToken>()), Times.Once);
            mock2.Verify(s => s.SendAsync(It.IsAny<ArraySegment<byte>>(), WebSocketMessageType.Text, true, It.IsAny<CancellationToken>()), Times.Once);
        }

        /// <summary>
        ///     Tests that BroadcastAsync skips excepted client
        /// </summary>
        [Fact]
        public async Task BroadcastAsync_WithExceptClient_SkipsExcepted()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport();
            Mock<WebSocket> mock1 = new Mock<WebSocket>();
            mock1.Setup(s => s.State).Returns(WebSocketState.Open);
            mock1.Setup(s => s.SendAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<WebSocketMessageType>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            Mock<WebSocket> mock2 = new Mock<WebSocket>();
            mock2.Setup(s => s.State).Returns(WebSocketState.Open);
            mock2.Setup(s => s.SendAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<WebSocketMessageType>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            transport._clientSockets.TryAdd("skip-me", mock1.Object);
            transport._clientSockets.TryAdd("keep-me", mock2.Object);

            Exception ex = await Record.ExceptionAsync(() =>
                transport.BroadcastAsync(new NetworkMessageEnvelope { MessageId = "bcast" }, "skip-me"));

            Assert.Null(ex);
            mock1.Verify(s => s.SendAsync(It.IsAny<ArraySegment<byte>>(), WebSocketMessageType.Text, true, It.IsAny<CancellationToken>()), Times.Never);
            mock2.Verify(s => s.SendAsync(It.IsAny<ArraySegment<byte>>(), WebSocketMessageType.Text, true, It.IsAny<CancellationToken>()), Times.Once);
        }

        /// <summary>
        ///     Tests that BroadcastAsync skips non-open clients
        /// </summary>
        [Fact]
        public async Task BroadcastAsync_WithNonOpenClients_SkipsThem()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport();
            Mock<WebSocket> openMock = new Mock<WebSocket>();
            openMock.Setup(s => s.State).Returns(WebSocketState.Open);
            openMock.Setup(s => s.SendAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<WebSocketMessageType>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            Mock<WebSocket> closedMock = new Mock<WebSocket>();
            closedMock.Setup(s => s.State).Returns(WebSocketState.Closed);
            transport._clientSockets.TryAdd("open", openMock.Object);
            transport._clientSockets.TryAdd("closed", closedMock.Object);

            Exception ex = await Record.ExceptionAsync(() =>
                transport.BroadcastAsync(new NetworkMessageEnvelope { MessageId = "bcast" }));

            Assert.Null(ex);
            openMock.Verify(s => s.SendAsync(It.IsAny<ArraySegment<byte>>(), WebSocketMessageType.Text, true, It.IsAny<CancellationToken>()), Times.Once);
            closedMock.Verify(s => s.SendAsync(It.IsAny<ArraySegment<byte>>(), WebSocketMessageType.Text, true, It.IsAny<CancellationToken>()), Times.Never);
        }

        /// <summary>
        ///     Tests that StopAsync handles concurrent calls
        /// </summary>
        [Fact]
        public async Task StopAsync_CalledConcurrently_SecondReturnsGracefully()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri("ws://127.0.0.1:18991"));
            await transport.StartAsync();

            Task task1 = Task.Run(() => transport.StopAsync());
            Task task2 = Task.Run(() => transport.StopAsync());

            Exception ex = await Record.ExceptionAsync(() => Task.WhenAll(task1, task2));
            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests that StopAsync catch block resets state on failure
        /// </summary>
        [Fact]
        public async Task StopAsync_WithFailingSocketClose_ResetsStateToDisconnected()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri("ws://127.0.0.1:18992"));
            await transport.StartAsync();
            Mock<WebSocket> badSocket = new Mock<WebSocket>();
            badSocket.Setup(s => s.State).Returns(WebSocketState.Open);
            badSocket.Setup(s => s.CloseAsync(It.IsAny<WebSocketCloseStatus>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new InvalidOperationException("close-failure"));
            transport._clientSockets.TryAdd("bad", badSocket.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(() => transport.StopAsync());
            Assert.Equal(NetworkTransportState.Disconnected, transport.State);
        }

        /// <summary>
        ///     Tests that Dispose swallows exception from StopAsync
        /// </summary>
        [Fact]
        public async Task Dispose_WithFailingStopAsync_DoesNotThrow()
        {
            WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri("ws://127.0.0.1:18993"));
            await transport.StartAsync();
            Mock<WebSocket> badSocket = new Mock<WebSocket>();
            badSocket.Setup(s => s.State).Returns(WebSocketState.Open);
            badSocket.Setup(s => s.CloseAsync(It.IsAny<WebSocketCloseStatus>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new InvalidOperationException("close-failure"));
            transport._clientSockets.TryAdd("bad", badSocket.Object);

            Exception ex = Record.Exception(() => transport.Dispose());
            Assert.Null(ex);
            Assert.Equal(NetworkTransportState.Disconnected, transport.State);
        }
    }
}
