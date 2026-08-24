// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketNetworkTransportFailureCoverageTests.cs
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
using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Core;
using Xunit;

namespace Alis.Extension.Network.Test.Core
{
    /// <summary>
    ///     The web socket network transport failure coverage tests class
    /// </summary>
    public class WebSocketNetworkTransportFailureCoverageTests
    {
        /// <summary>
        ///     Injects the socket map entry using the given state.
        /// </summary>
        /// <param name="transport">The transport</param>
        /// <param name="socket">The socket</param>
        private static void InjectClientSocket(WebSocketNetworkTransport transport, WebSocket socket)
        {
            FieldInfo field = typeof(WebSocketNetworkTransport).GetField("_clientSockets",
                BindingFlags.NonPublic | BindingFlags.Instance);
            ConcurrentDictionary<string, WebSocket> map = (ConcurrentDictionary<string, WebSocket>) field.GetValue(transport);
            map["injected-client"] = socket;
        }

        /// <summary>
        ///     Tests that send async with a non open socket throws invalid operation exception.
        /// </summary>
        [Fact]
        public async Task SendAsync_WithNonOpenSocket_ThrowsInvalidOperationException()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport();
            InjectClientSocket(transport, new ClosedStateSocket());
            NetworkMessageEnvelope envelope = new NetworkMessageEnvelope { MessageId = "m1" };

            InvalidOperationException ex = await Assert.ThrowsAsync<InvalidOperationException>(
                () => transport.SendAsync("injected-client", envelope));

            Assert.Contains("connection not open", ex.Message);
        }

        /// <summary>
        ///     Tests that broadcast async skips the except client and non open sockets.
        /// </summary>
        [Fact]
        public async Task BroadcastAsync_WithExceptAndNonOpenSockets_Completes()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport();
            InjectClientSocket(transport, new ClosedStateSocket());
            NetworkMessageEnvelope envelope = new NetworkMessageEnvelope { MessageId = "m1" };

            Exception ex = await Record.ExceptionAsync(() => transport.BroadcastAsync(envelope, "injected-client"));

            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests that broadcast async with only a non open socket completes.
        /// </summary>
        [Fact]
        public async Task BroadcastAsync_WithOnlyNonOpenSocket_Completes()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport();
            InjectClientSocket(transport, new ClosedStateSocket());
            NetworkMessageEnvelope envelope = new NetworkMessageEnvelope { MessageId = "m1" };

            Exception ex = await Record.ExceptionAsync(() => transport.BroadcastAsync(envelope));

            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests that stop async with a failing socket throws and resets the state.
        /// </summary>
        [Fact]
        public async Task StopAsync_WithFailingSocket_ThrowsAndResetsState()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri("ws://127.0.0.1:18901"));
            await transport.StartAsync();
            InjectClientSocket(transport, new ThrowingCloseSocket());

            await Assert.ThrowsAsync<InvalidOperationException>(() => transport.StopAsync());

            Assert.Equal(NetworkTransportState.Disconnected, transport.State);
        }

        /// <summary>
        ///     Tests that dispose swallows a failing stop and disposes the client sockets.
        /// </summary>
        [Fact]
        public void Dispose_WithFailingStop_SwallowsAndDisposesSockets()
        {
            WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri("ws://127.0.0.1:18902"));
            transport.StartAsync().Wait();
            ThrowingCloseSocket socket = new ThrowingCloseSocket();
            InjectClientSocket(transport, socket);

            Exception ex = Record.Exception(() => transport.Dispose());

            Assert.Null(ex);
            Assert.True(socket.Disposed);
        }
        
        /// <summary>
        ///     The closed state socket class
        /// </summary>
        private class ClosedStateSocket : WebSocket
        {
            /// <summary>
            ///     Gets the state
            /// </summary>
            public override WebSocketState State => WebSocketState.Closed;

            /// <summary>
            ///     Gets the close status
            /// </summary>
            public override WebSocketCloseStatus? CloseStatus => null;

            /// <summary>
            ///     Gets the close status description
            /// </summary>
            public override string CloseStatusDescription => null;

            /// <summary>
            ///     Gets the sub protocol
            /// </summary>
            public override string SubProtocol => null;

            /// <summary>
            ///     Closes the async
            /// </summary>
            public override Task CloseAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken) => Task.CompletedTask;

            /// <summary>
            ///     Closes the output async
            /// </summary>
            public override Task CloseOutputAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken) => Task.CompletedTask;

            /// <summary>
            ///     Receives the async
            /// </summary>
            public override Task<WebSocketReceiveResult> ReceiveAsync(ArraySegment<byte> buffer, CancellationToken cancellationToken) =>
                Task.FromResult(new WebSocketReceiveResult(0, WebSocketMessageType.Close, true));

            /// <summary>
            ///     Sends the async
            /// </summary>
            public override Task SendAsync(ArraySegment<byte> buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken) => Task.CompletedTask;

            /// <summary>
            ///     Aborts this instance
            /// </summary>
            public override void Abort()
            {
            }

            /// <summary>
            ///     Disposes this instance
            /// </summary>
            public override void Dispose()
            {
            }
        }

        /// <summary>
        ///     The throwing close socket class
        /// </summary>
        private class ThrowingCloseSocket : WebSocket
        {
            /// <summary>
            ///     The disposed
            /// </summary>
            public bool Disposed;

            /// <summary>
            ///     Gets the state
            /// </summary>
            public override WebSocketState State => WebSocketState.Open;

            /// <summary>
            ///     Gets the close status
            /// </summary>
            public override WebSocketCloseStatus? CloseStatus => null;

            /// <summary>
            ///     Gets the close status description
            /// </summary>
            public override string CloseStatusDescription => null;

            /// <summary>
            ///     Gets the sub protocol
            /// </summary>
            public override string SubProtocol => null;

            /// <summary>
            ///     Closes the async
            /// </summary>
            public override Task CloseAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken) =>
                throw new InvalidOperationException("close failed");

            /// <summary>
            ///     Closes the output async
            /// </summary>
            public override Task CloseOutputAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken) =>
                throw new InvalidOperationException("close failed");

            /// <summary>
            ///     Receives the async
            /// </summary>
            public override Task<WebSocketReceiveResult> ReceiveAsync(ArraySegment<byte> buffer, CancellationToken cancellationToken) =>
                Task.FromResult(new WebSocketReceiveResult(0, WebSocketMessageType.Close, true));

            /// <summary>
            ///     Sends the async
            /// </summary>
            public override Task SendAsync(ArraySegment<byte> buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken) => Task.CompletedTask;

            /// <summary>
            ///     Aborts this instance
            /// </summary>
            public override void Abort()
            {
            }

            /// <summary>
            ///     Disposes this instance
            /// </summary>
            public override void Dispose()
            {
                Disposed = true;
            }
        }
    }
}
