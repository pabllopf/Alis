// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:INetworkTransportTest.cs
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
    ///     Tests for INetworkTransport interface
    /// </summary>
    public class INetworkTransportTest
    {
        /// <summary>
        /// The test network transport class
        /// </summary>
        /// <seealso cref="INetworkTransport"/>
        private class TestNetworkTransport : INetworkTransport
        {
            /// <summary>
            /// Gets the value of the state
            /// </summary>
            public NetworkTransportState State => NetworkTransportState.Disconnected;
            
            /// <summary>
            /// Sends the client id
            /// </summary>
            /// <param name="clientId">The client id</param>
            /// <param name="message">The message</param>
            /// <param name="cancellationToken">The cancellation token</param>
            public Task SendAsync(string clientId, NetworkMessageEnvelope message, CancellationToken cancellationToken = default)
                => Task.CompletedTask;
            
            /// <summary>
            /// Broadcasts the message
            /// </summary>
            /// <param name="message">The message</param>
            /// <param name="exceptClientId">The except client id</param>
            /// <param name="cancellationToken">The cancellation token</param>
            public Task BroadcastAsync(NetworkMessageEnvelope message, string exceptClientId = null, CancellationToken cancellationToken = default)
                => Task.CompletedTask;
            
            /// <summary>
            /// Receives the cancellation token
            /// </summary>
            /// <param name="cancellationToken">The cancellation token</param>
            /// <returns>A task containing the string client id network message envelope message</returns>
            public Task<(string ClientId, NetworkMessageEnvelope Message)> ReceiveAsync(CancellationToken cancellationToken = default)
                => Task.FromResult(("client1", new NetworkMessageEnvelope(){ }));
            
            /// <summary>
            /// Starts the cancellation token
            /// </summary>
            /// <param name="cancellationToken">The cancellation token</param>
            public Task StartAsync(CancellationToken cancellationToken = default)
                => Task.CompletedTask;
            
            /// <summary>
            /// Stops the cancellation token
            /// </summary>
            /// <param name="cancellationToken">The cancellation token</param>
            public Task StopAsync(CancellationToken cancellationToken = default)
                => Task.CompletedTask;
            
            /// <summary>
            /// Disposes this instance
            /// </summary>
            public void Dispose() { }
        }

        /// <summary>
        /// Tests that state returns disconnected state
        /// </summary>
        [Fact]
        public void State_ReturnsDisconnectedState()
        {
            // Arrange
            TestNetworkTransport transport = new TestNetworkTransport();

            // Act
            NetworkTransportState result = transport.State;

            // Assert
            Assert.Equal(NetworkTransportState.Disconnected, result);
        }

        /// <summary>
        /// Tests that send async completes successfully
        /// </summary>
        [Fact]
        public void SendAsync_CompletesSuccessfully()
        {
            // Arrange
            TestNetworkTransport transport = new TestNetworkTransport();
            NetworkMessageEnvelope message = new NetworkMessageEnvelope();

            // Act
            Task result = transport.SendAsync("client1", message);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(TaskStatus.RanToCompletion, result.Status);
        }

        /// <summary>
        /// Tests that broadcast async completes successfully
        /// </summary>
        [Fact]
        public void BroadcastAsync_CompletesSuccessfully()
        {
            // Arrange
            TestNetworkTransport transport = new TestNetworkTransport();
            NetworkMessageEnvelope message = new NetworkMessageEnvelope();

            // Act
            Task result = transport.BroadcastAsync(message, "client1");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(TaskStatus.RanToCompletion, result.Status);
        }

        /// <summary>
        /// Tests that receive async returns message
        /// </summary>
        [Fact]
        public void ReceiveAsync_ReturnsMessage()
        {
            // Arrange
            TestNetworkTransport transport = new TestNetworkTransport();

            // Act
            Task<(string ClientId, NetworkMessageEnvelope Message)> result = transport.ReceiveAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(TaskStatus.RanToCompletion, result.Status);
            
            (string clientId, NetworkMessageEnvelope message) = result.Result;
            Assert.Equal("client1", clientId);
            Assert.NotNull(message);
        }

        /// <summary>
        /// Tests that start async completes successfully
        /// </summary>
        [Fact]
        public void StartAsync_CompletesSuccessfully()
        {
            // Arrange
            TestNetworkTransport transport = new TestNetworkTransport();

            // Act
            Task result = transport.StartAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(TaskStatus.RanToCompletion, result.Status);
        }

        /// <summary>
        /// Tests that stop async completes successfully
        /// </summary>
        [Fact]
        public void StopAsync_CompletesSuccessfully()
        {
            // Arrange
            TestNetworkTransport transport = new TestNetworkTransport();

            // Act
            Task result = transport.StopAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(TaskStatus.RanToCompletion, result.Status);
        }

        /// <summary>
        /// Tests that dispose cleans up resources
        /// </summary>
        [Fact]
        public void Dispose_CleansUpResources()
        {
            // Arrange
            TestNetworkTransport transport = new TestNetworkTransport();

            // Act
            transport.Dispose();

            // Assert
            // No exception thrown
        }
    }
}
