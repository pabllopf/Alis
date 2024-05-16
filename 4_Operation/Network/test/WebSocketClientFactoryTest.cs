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
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Alis.Core.Network.Exceptions;
using Xunit;

namespace Alis.Core.Network.Test
{
    /// <summary>
    /// The web socket client factory test class
    /// </summary>
    public class WebSocketClientFactoryTest
    {
        /// <summary>
        /// Tests that connect async valid input
        /// </summary>
        [Fact]
        public async Task ConnectAsync_ValidInput()
        {
            WebSocketClientFactory factory = new WebSocketClientFactory();
            Uri uri = new Uri("ws://localhost:8080");
            
            await Assert.ThrowsAsync<SocketException>( () =>  factory.ConnectAsync(uri));
        }
        
        /// <summary>
        /// Tests that connect async with custom buffer factory
        /// </summary>
        [Fact]
        public async Task ConnectAsync_WithCustomBufferFactory()
        {
            WebSocketClientFactory factory = new WebSocketClientFactory(() => new MemoryStream());
            Uri uri = new Uri("ws://localhost:8080");

            await Assert.ThrowsAsync<SocketException>( () =>  factory.ConnectAsync(uri));
        }
        
        /// <summary>
        /// Tests that dispose closes web socket
        /// </summary>
        [Fact]
        public void Dispose_ClosesWebSocket()
        {
            WebSocketClientFactory factory = new WebSocketClientFactory();
            Uri uri = new Uri("ws://localhost:8080");
            
            Task<WebSocket> webSocket = factory.ConnectAsync(uri);
            factory.Dispose();
            
            Assert.Equal( TaskStatus.WaitingForActivation ,webSocket.Status);
        }
    }
}