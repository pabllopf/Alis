// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:INetworkManagerTest.cs
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
    ///     Tests for INetworkManager interface
    /// </summary>
    public class INetworkManagerTest
    {
        /// <summary>
        /// The test network manager class
        /// </summary>
        /// <seealso cref="INetworkManager"/>
        private class TestNetworkManager : INetworkManager
        {
            /// <summary>
            /// Gets the value of the id
            /// </summary>
            public string Id => "test-id";
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
            TestNetworkManager manager = new TestNetworkManager();

            // Act
            string result = manager.Id;

            // Assert
            Assert.Equal("test-id", result);
        }

        /// <summary>
        /// Tests that state returns disconnected state
        /// </summary>
        [Fact]
        public void State_ReturnsDisconnectedState()
        {
            // Arrange
            TestNetworkManager manager = new TestNetworkManager();

            // Act
            NetworkManagerState result = manager.State;

            // Assert
            Assert.Equal(NetworkManagerState.Disconnected, result);
        }

        /// <summary>
        /// Tests that current session returns null when not connected
        /// </summary>
        [Fact]
        public void CurrentSession_ReturnsNullWhenNotConnected()
        {
            // Arrange
            TestNetworkManager manager = new TestNetworkManager();

            // Act
            NetworkSession result = manager.CurrentSession;

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        /// Tests that local player returns null when not connected
        /// </summary>
        [Fact]
        public void LocalPlayer_ReturnsNullWhenNotConnected()
        {
            // Arrange
            TestNetworkManager manager = new TestNetworkManager();

            // Act
            NetworkPlayer result = manager.LocalPlayer;

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        /// Tests that config returns default config
        /// </summary>
        [Fact]
        public void Config_ReturnsDefaultConfig()
        {
            // Arrange
            TestNetworkManager manager = new TestNetworkManager();

            // Act
            NetworkConfig result = manager.Config;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(32, result.MaxPlayers);
            Assert.Equal(60, result.TickRate);
        }

        /// <summary>
        /// Tests that initialize async completes successfully
        /// </summary>
        [Fact]
        public void InitializeAsync_CompletesSuccessfully()
        {
            // Arrange
            TestNetworkManager manager = new TestNetworkManager();
            NetworkConfig config = new NetworkConfig();

            // Act
            Task result = manager.InitializeAsync(config);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(TaskStatus.RanToCompletion, result.Status);
        }

        /// <summary>
        /// Tests that start async completes successfully
        /// </summary>
        [Fact]
        public void StartAsync_CompletesSuccessfully()
        {
            // Arrange
            TestNetworkManager manager = new TestNetworkManager();

            // Act
            Task result = manager.StartAsync();

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
            TestNetworkManager manager = new TestNetworkManager();

            // Act
            Task result = manager.StopAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(TaskStatus.RanToCompletion, result.Status);
        }
        
        /// <summary>
        /// Tests that register message handler registers handler
        /// </summary>
        [Fact]
        public void RegisterMessageHandler_RegistersHandler()
        {
            // Arrange
            TestNetworkManager manager = new TestNetworkManager();
            Func<string, string, Task> handler = (a, b) => Task.CompletedTask;

            // Act
            manager.RegisterMessageHandler("chat", handler);

            // Assert
            // Handler registered without exception
        }

        /// <summary>
        /// Tests that unregister message handler unregisters handler
        /// </summary>
        [Fact]
        public void UnregisterMessageHandler_UnregistersHandler()
        {
            // Arrange
            TestNetworkManager manager = new TestNetworkManager();

            // Act
            manager.UnregisterMessageHandler("chat");

            // Assert
            // Handler unregistered without exception
        }

        /// <summary>
        /// Tests that get connected players returns empty list
        /// </summary>
        [Fact]
        public void GetConnectedPlayers_ReturnsEmptyList()
        {
            // Arrange
            TestNetworkManager manager = new TestNetworkManager();

            // Act
            IReadOnlyList<NetworkPlayer> result = manager.GetConnectedPlayers();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that get player returns null when player not found
        /// </summary>
        [Fact]
        public void GetPlayer_ReturnsNullWhenPlayerNotFound()
        {
            // Arrange
            TestNetworkManager manager = new TestNetworkManager();

            // Act
            NetworkPlayer result = manager.GetPlayer("unknown-player");

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        /// Tests that dispose cleans up resources
        /// </summary>
        [Fact]
        public void Dispose_CleansUpResources()
        {
            // Arrange
            TestNetworkManager manager = new TestNetworkManager();

            // Act
            manager.Dispose();

            // Assert
            // No exception thrown
        }

    }
}
