// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketNetworkTransportRemainingCoverageTests.cs
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
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Core;
using Xunit;

namespace Alis.Extension.Network.Test.Core
{
    /// <summary>
    /// The web socket network transport remaining coverage tests class
    /// </summary>
    public class WebSocketNetworkTransportRemainingCoverageTests
    {
        /// <summary>
        /// Tests that start async called twice throws invalid operation exception
        /// </summary>
        [Fact]
        public async Task StartAsync_CalledTwice_ThrowsInvalidOperationException()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri("ws://127.0.0.1:18881"));
            await transport.StartAsync();
            await Assert.ThrowsAsync<InvalidOperationException>(() => transport.StartAsync());
        }

        /// <summary>
        /// Tests that start async valid host starts successfully
        /// </summary>
        [Fact]
        public async Task StartAsync_ValidHost_StartsSuccessfully()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri("ws://127.0.0.1:18882"));
            await transport.StartAsync();
            Assert.Equal(NetworkTransportState.Connected, transport.State);
        }

        /// <summary>
        /// Tests that stop async after start disconnects
        /// </summary>
        [Fact]
        public async Task StopAsync_AfterStart_Disconnects()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri("ws://127.0.0.1:18883"));
            await transport.StartAsync();
            await transport.StopAsync();
            Assert.Equal(NetworkTransportState.Disconnected, transport.State);
        }

        /// <summary>
        /// Tests that receive async without cancellation throws operation canceled exception on cts cancel
        /// </summary>
        [Fact]
        public async Task ReceiveAsync_WithoutCancellation_ThrowsOperationCanceledExceptionOnCtsCancel()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport();
            using CancellationTokenSource cts = new CancellationTokenSource();
            Task receiveTask = transport.ReceiveAsync(cts.Token);
            cts.Cancel();
            Exception ex = await Record.ExceptionAsync(() => receiveTask);
            Assert.IsAssignableFrom<OperationCanceledException>(ex);
        }

        /// <summary>
        /// Tests that send async with null envelope throws
        /// </summary>
        [Fact]
        public async Task SendAsync_WithNullEnvelope_Throws()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport();
            await Assert.ThrowsAsync<InvalidOperationException>(() => transport.SendAsync("client-id", null));
        }

        /// <summary>
        /// Tests that broadcast async with except client id does not throw
        /// </summary>
        [Fact]
        public async Task BroadcastAsync_WithExceptClientId_DoesNotThrow()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport();
            NetworkMessageEnvelope envelope = new NetworkMessageEnvelope { MessageId = "test" };
            Exception ex = await Record.ExceptionAsync(() => transport.BroadcastAsync(envelope, "some-client-id"));
            Assert.Null(ex);
        }
    }
}
