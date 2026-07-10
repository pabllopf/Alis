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
    public class WebSocketNetworkTransportRemainingCoverageTests
    {
        [Fact]
        public async Task StartAsync_CalledTwice_ThrowsInvalidOperationException()
        {
            using var transport = new WebSocketNetworkTransport(new Uri("ws://127.0.0.1:18881"));
            await transport.StartAsync();
            await Assert.ThrowsAsync<InvalidOperationException>(() => transport.StartAsync());
        }

        [Fact]
        public async Task StartAsync_ValidHost_StartsSuccessfully()
        {
            using var transport = new WebSocketNetworkTransport(new Uri("ws://127.0.0.1:18882"));
            await transport.StartAsync();
            Assert.Equal(NetworkTransportState.Connected, transport.State);
        }

        [Fact]
        public async Task StopAsync_AfterStart_Disconnects()
        {
            using var transport = new WebSocketNetworkTransport(new Uri("ws://127.0.0.1:18883"));
            await transport.StartAsync();
            await transport.StopAsync();
            Assert.Equal(NetworkTransportState.Disconnected, transport.State);
        }

        [Fact]
        public async Task ReceiveAsync_WithoutCancellation_ThrowsOperationCanceledExceptionOnCtsCancel()
        {
            using var transport = new WebSocketNetworkTransport();
            using var cts = new CancellationTokenSource();
            Task receiveTask = transport.ReceiveAsync(cts.Token);
            cts.Cancel();
            Exception ex = await Record.ExceptionAsync(() => receiveTask);
            Assert.IsAssignableFrom<OperationCanceledException>(ex);
        }

        [Fact]
        public async Task SendAsync_WithNullEnvelope_Throws()
        {
            using var transport = new WebSocketNetworkTransport();
            await Assert.ThrowsAsync<InvalidOperationException>(() => transport.SendAsync("client-id", null));
        }

        [Fact]
        public async Task BroadcastAsync_WithExceptClientId_DoesNotThrow()
        {
            using var transport = new WebSocketNetworkTransport();
            NetworkMessageEnvelope envelope = new NetworkMessageEnvelope { MessageId = "test" };
            Exception ex = await Record.ExceptionAsync(() => transport.BroadcastAsync(envelope, "some-client-id"));
            Assert.Null(ex);
        }
    }
}
