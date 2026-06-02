// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketNetworkTransportTest.cs
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
using Alis.Extension.Network.Core;
using Xunit;

namespace Alis.Extension.Network.Test.Core
{
    /// <summary>
    ///     The web socket network transport test class
    /// </summary>
    public class WebSocketNetworkTransportTest
    {
        /// <summary>
        ///     Tests that constructor without uri sets default host and port
        /// </summary>
        [Fact]
        public void Constructor_WithoutUri_SetsDefaultState()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport();

            Assert.Equal(NetworkTransportState.Disconnected, transport.State);
        }

        /// <summary>
        ///     Tests that constructor with uri sets disconnected state
        /// </summary>
        [Fact]
        public void Constructor_WithUri_SetsDisconnectedState()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri("ws://127.0.0.1:9999"));

            Assert.Equal(NetworkTransportState.Disconnected, transport.State);
        }

        /// <summary>
        ///     Tests that dispose can be called multiple times
        /// </summary>
        [Fact]
        public void Dispose_MultipleTimes_DoesNotThrow()
        {
            WebSocketNetworkTransport transport = new WebSocketNetworkTransport();
            transport.Dispose();
            transport.Dispose();
        }
    }
}
