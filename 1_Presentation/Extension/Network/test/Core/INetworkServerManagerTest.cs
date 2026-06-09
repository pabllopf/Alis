// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:INetworkServerManagerTest.cs
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
    ///     Tests for INetworkServerManager interface
    /// </summary>
    public class INetworkServerManagerTest
    {
        /// <summary>
        /// The test network server manager class
        /// </summary>
        /// <seealso cref="INetworkServerManager"/>
        private class TestNetworkServerManager : INetworkServerManager
        {
            /// <summary>
            /// Gets the value of the id
            /// </summary>
            public string Id => "server-test-id";
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
            /// Gets the value of the listen uri
            /// </summary>
            public Uri ListenUri => new Uri("ws://localhost:8080");
            
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
            /// Listens the address
            /// </summary>
            /// <param name="address">The address</param>
            /// <param name="cancellationToken">The cancellation token</param>
            public Task ListenAsync(Uri address, CancellationToken cancellationToken = default)
                => Task.CompletedTask;
            
            /// <summary>
            /// Stops the listening using the specified cancellation token
            /// </summary>
            /// <param name="cancellationToken">The cancellation token</param>
            public Task StopListeningAsync(CancellationToken cancellationToken = default)
                => Task.CompletedTask;
            
            /// <summary>
            /// Creates the session using the specified session name
            /// </summary>
            /// <param name="sessionName">The session name</param>
            /// <param name="maxPlayers">The max players</param>
            /// <param name="cancellationToken">The cancellation token</param>
            /// <returns>A task containing the network session</returns>
            public Task<NetworkSession> CreateSessionAsync(string sessionName, int maxPlayers, CancellationToken cancellationToken = default)
                => Task.FromResult(new NetworkSession { SessionId = sessionName, MaxPlayers = maxPlayers });
            
            /// <summary>
            /// Gets the session using the specified session id
            /// </summary>
            /// <param name="sessionId">The session id</param>
            /// <returns>The network session</returns>
            public NetworkSession GetSession(string sessionId) => null;
            
            /// <summary>
            /// Gets the active sessions
            /// </summary>
            /// <returns>A read only list of network session</returns>
            public IReadOnlyList<NetworkSession> GetActiveSessions() => new List<NetworkSession>();
            
            /// <summary>
            /// Closes the session using the specified session id
            /// </summary>
            /// <param name="sessionId">The session id</param>
            /// <param name="cancellationToken">The cancellation token</param>
            public Task CloseSessionAsync(string sessionId, CancellationToken cancellationToken = default)
                => Task.CompletedTask;
            
            /// <summary>
            /// Kicks the player using the specified player id
            /// </summary>
            /// <param name="playerId">The player id</param>
            /// <param name="sessionId">The session id</param>
            /// <param name="reason">The reason</param>
            /// <param name="cancellationToken">The cancellation token</param>
            public Task KickPlayerAsync(string playerId, string sessionId, string reason = null, CancellationToken cancellationToken = default)
                => Task.CompletedTask;
            
            public event EventHandler<ClientConnectionEventArgs> ClientConnected;
            public event EventHandler<ClientDisconnectionEventArgs> ClientDisconnected;
            
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
            TestNetworkServerManager manager = new TestNetworkServerManager();

            // Act
            string result = manager.Id;

            // Assert
            Assert.Equal("server-test-id", result);
        }

        /// <summary>
        /// Tests that listen uri returns correct uri
        /// </summary>
        [Fact]
        public void ListenUri_ReturnsCorrectUri()
        {
            // Arrange
            TestNetworkServerManager manager = new TestNetworkServerManager();

            // Act
            Uri result = manager.ListenUri;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("ws://localhost:8080/", result.ToString());
        }

        /// <summary>
        /// Tests that listen async completes successfully
        /// </summary>
        [Fact]
        public void ListenAsync_CompletesSuccessfully()
        {
            // Arrange
            TestNetworkServerManager manager = new TestNetworkServerManager();
            Uri address = new Uri("ws://localhost:8080");

            // Act
            Task result = manager.ListenAsync(address);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(TaskStatus.RanToCompletion, result.Status);
        }

        /// <summary>
        /// Tests that stop listening async completes successfully
        /// </summary>
        [Fact]
        public void StopListeningAsync_CompletesSuccessfully()
        {
            // Arrange
            TestNetworkServerManager manager = new TestNetworkServerManager();

            // Act
            Task result = manager.StopListeningAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(TaskStatus.RanToCompletion, result.Status);
        }

        /// <summary>
        /// Tests that create session async creates session
        /// </summary>
        [Fact]
        public void CreateSessionAsync_CreatesSession()
        {
            // Arrange
            TestNetworkServerManager manager = new TestNetworkServerManager();

            // Act
            Task<NetworkSession> result = manager.CreateSessionAsync("test-session", 16);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(TaskStatus.RanToCompletion, result.Status);
            
            NetworkSession session = result.Result;
            Assert.NotNull(session);
            Assert.Equal("test-session", session.SessionId);
        }

        /// <summary>
        /// Tests that get session returns null when session not found
        /// </summary>
        [Fact]
        public void GetSession_ReturnsNullWhenSessionNotFound()
        {
            // Arrange
            TestNetworkServerManager manager = new TestNetworkServerManager();

            // Act
            NetworkSession result = manager.GetSession("unknown-session");

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        /// Tests that get active sessions returns empty list
        /// </summary>
        [Fact]
        public void GetActiveSessions_ReturnsEmptyList()
        {
            // Arrange
            TestNetworkServerManager manager = new TestNetworkServerManager();

            // Act
            IReadOnlyList<NetworkSession> result = manager.GetActiveSessions();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that close session async completes successfully
        /// </summary>
        [Fact]
        public void CloseSessionAsync_CompletesSuccessfully()
        {
            // Arrange
            TestNetworkServerManager manager = new TestNetworkServerManager();

            // Act
            Task result = manager.CloseSessionAsync("test-session");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(TaskStatus.RanToCompletion, result.Status);
        }

        /// <summary>
        /// Tests that kick player async completes successfully
        /// </summary>
        [Fact]
        public void KickPlayerAsync_CompletesSuccessfully()
        {
            // Arrange
            TestNetworkServerManager manager = new TestNetworkServerManager();

            // Act
            Task result = manager.KickPlayerAsync("player1", "test-session", "Test reason");

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
            TestNetworkServerManager manager = new TestNetworkServerManager();

            // Act
            manager.Dispose();

            // Assert
            // No exception thrown
        }
    }
}
