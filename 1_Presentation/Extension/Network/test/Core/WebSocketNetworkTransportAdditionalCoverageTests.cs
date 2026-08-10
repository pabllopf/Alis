// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketNetworkTransportAdditionalCoverageTests.cs
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
using System.Threading.Tasks;
using Alis.Extension.Network.Core;
using Xunit;

namespace Alis.Extension.Network.Test.Core
{
    /// <summary>
    ///     The web socket network transport additional coverage tests class
    /// </summary>
    public class WebSocketNetworkTransportAdditionalCoverageTests
    {
        /// <summary>
        ///     Tests that send async with unknown client throws invalid operation exception
        /// </summary>
        [Fact]
        public async Task SendAsync_WithUnknownClient_ThrowsInvalidOperationException()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri("ws://127.0.0.1:1"));
            NetworkMessageEnvelope envelope = new NetworkMessageEnvelope { MessageId = "m1", MessageType = "chat", Channel = "c", Payload = "p" };

            await Assert.ThrowsAsync<InvalidOperationException>(() => transport.SendAsync("unknown-client", envelope));
        }

        /// <summary>
        ///     Tests that broadcast with no clients does not throw
        /// </summary>
        [Fact]
        public async Task Broadcast_WithNoClients_DoesNotThrow()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri("ws://127.0.0.1:1"));
            NetworkMessageEnvelope envelope = new NetworkMessageEnvelope { MessageId = "m1", MessageType = "chat", Channel = "c", Payload = "p" };

            await transport.BroadcastAsync(envelope);
        }
    }
}
