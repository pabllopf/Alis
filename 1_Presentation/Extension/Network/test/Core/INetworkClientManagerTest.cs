// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:INetworkClientManagerTest.cs
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
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Aspect.Data.Json;
using Alis.Extension.Network.Core;
using Xunit;

namespace Alis.Extension.Network.Test.Core
{
    /// <summary>
    ///     Tests for INetworkClientManager interface
    /// </summary>
    public class INetworkClientManagerTest
    {
        /// <summary>
        /// The test network client manager class
        /// </summary>
        /// <seealso cref="INetworkClientManager"/>
        private class TestNetworkClientManager : INetworkClientManager
        {
            /// <summary>
            /// Gets the value of the id
            /// </summary>
            public string Id => "client-test-id";
            /// <summary>
            /// Gets the value of the state
            /// </summary>
            public NetworkManagerState State => NetworkManagerState.Disconnected;
            /// <summary>
            /// Gets the value of the current session
            /// </summary>
            public NetworkSession CurrentSession => null;
            /// <summary>
            /// Gets the value of the local player
            /// </summary>
            public NetworkPlayer LocalPlayer => null;
            /// <summary>
            /// Gets or sets the value of the config
            /// </summary>
            public NetworkConfig Config { get; set; } = new NetworkConfig();
            /// <summary>
            /// Gets the value of the server uri
            /// </summary>
            public Uri ServerUri => new Uri("ws://localhost:8080");
            
            /// <summary>
            /// Initializes the config
            /// </summary>
            /// <param name="config">The config</param>
            /// <param name="cancellationToken">The cancellation token</param>
            public Task InitializeAsync(NetworkConfig config, CancellationToken cancellationToken = default)
                => Task.CompletedTask;
            
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
            /// Sends the message using the specified target player id
            /// </summary>
            /// <typeparam name="T">The </typeparam>
            /// <param name="targetPlayerId">The target player id</param>
            /// <param name="channel">The channel</param>
            /// <param name="message">The message</param>
            /// <param name="reliable">The reliable</param>
            public Task SendMessageAsync<T>(string targetPlayerId, string channel, T message, bool reliable = true)
                where T : IJsonSerializable => Task.CompletedTask;
            
            /// <summary>
            /// Broadcasts the message using the specified channel
            /// </summary>
            /// <typeparam name="T">The </typeparam>
            /// <param name="channel">The channel</param>
            /// <param name="message">The message</param>
            /// <param name="reliable">The reliable</param>
            /// <param name="exceptPlayerId">The except player id</param>
            public Task BroadcastMessageAsync<T>(string channel, T message, bool reliable = true, string exceptPlayerId = null)
                where T : IJsonSerializable => Task.CompletedTask;
            
            /// <summary>
            /// Registers the message handler using the specified channel
            /// </summary>
            /// <param name="channel">The channel</param>
            /// <param name="handler">The handler</param>
            public void RegisterMessageHandler(string channel, Func<string, string, Task> handler) { }
            
            /// <summary>
            /// Unregisters the message handler using the specified channel
            /// </summary>
            /// <param name="channel">The channel</param>
            public void UnregisterMessageHandler(string channel) { }
            
            /// <summary>
            /// Gets the connected players
            /// </summary>
            /// <returns>A read only list of network player</returns>
            public IReadOnlyList<NetworkPlayer> GetConnectedPlayers() => new List<NetworkPlayer>();
            
            /// <summary>
            /// Gets the player using the specified player id
            /// </summary>
            /// <param name="playerId">The player id</param>
            /// <returns>The network player</returns>
            public NetworkPlayer GetPlayer(string playerId) => null;
            
            public event EventHandler<PlayerEventArgs> PlayerJoined;
            public event EventHandler<PlayerEventArgs> PlayerLeft;
            public event EventHandler<EventArgs> Connected;
            public event EventHandler<EventArgs> Disconnected;
            public event EventHandler<NetworkErrorEventArgs> Error;
            
            /// <summary>
            /// Connects the server uri
            /// </summary>
            /// <param name="serverUri">The server uri</param>
            /// <param name="playerName">The player name</param>
            /// <param name="cancellationToken">The cancellation token</param>
            public Task ConnectAsync(Uri serverUri, string playerName, CancellationToken cancellationToken = default)
                => Task.CompletedTask;
            
            /// <summary>
            /// Disconnects the cancellation token
            /// </summary>
            /// <param name="cancellationToken">The cancellation token</param>
            public Task DisconnectAsync(CancellationToken cancellationToken = default)
                => Task.CompletedTask;
            
            public event EventHandler<ServerMessageEventArgs> ServerMessageReceived;
            
            /// <summary>
            /// Disposes this instance
            /// </summary>
            public void Dispose() { }
        }

        /// <summary>
        /// Tests that id returns correct id
        /// </summary>
        [Fact]
        public void Id_ReturnsCorrectId()
        {
            // Arrange
            TestNetworkClientManager manager = new TestNetworkClientManager();

            // Act
            string result = manager.Id;

            // Assert
            Assert.Equal("client-test-id", result);
        }

        /// <summary>
        /// Tests that server uri returns correct uri
        /// </summary>
        [Fact]
        public void ServerUri_ReturnsCorrectUri()
        {
            // Arrange
            TestNetworkClientManager manager = new TestNetworkClientManager();

            // Act
            Uri result = manager.ServerUri;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("ws://localhost:8080/", result.ToString());
        }

        /// <summary>
        /// Tests that connect async completes successfully
        /// </summary>
        [Fact]
        public void ConnectAsync_CompletesSuccessfully()
        {
            // Arrange
            TestNetworkClientManager manager = new TestNetworkClientManager();
            Uri serverUri = new Uri("ws://localhost:8080");

            // Act
            Task result = manager.ConnectAsync(serverUri, "test-player");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(TaskStatus.RanToCompletion, result.Status);
        }

        /// <summary>
        /// Tests that disconnect async completes successfully
        /// </summary>
        [Fact]
        public void DisconnectAsync_CompletesSuccessfully()
        {
            // Arrange
            TestNetworkClientManager manager = new TestNetworkClientManager();

            // Act
            Task result = manager.DisconnectAsync();

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
            TestNetworkClientManager manager = new TestNetworkClientManager();

            // Act
            manager.Dispose();

            // Assert
            // No exception thrown
        }
    }
}
