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
        private class TestNetworkServerManager : INetworkServerManager
        {
            public string Id => "server-test-id";
            public NetworkManagerState State => NetworkManagerState.Disconnected;
            public NetworkSession CurrentSession => null;
            public NetworkPlayer LocalPlayer => null;
            public NetworkConfig Config { get; set; } = new NetworkConfig();
            public Uri ListenUri => new Uri("ws://localhost:8080");
            
            public Task InitializeAsync(NetworkConfig config, CancellationToken cancellationToken = default)
                => Task.CompletedTask;
            
            public Task StartAsync(CancellationToken cancellationToken = default)
                => Task.CompletedTask;
            
            public Task StopAsync(CancellationToken cancellationToken = default)
                => Task.CompletedTask;
            
            public Task SendMessageAsync<T>(string targetPlayerId, string channel, T message, bool reliable = true)
                where T : IJsonSerializable => Task.CompletedTask;
            
            public Task BroadcastMessageAsync<T>(string channel, T message, bool reliable = true, string exceptPlayerId = null)
                where T : IJsonSerializable => Task.CompletedTask;
            
            public void RegisterMessageHandler(string channel, Func<string, string, Task> handler) { }
            
            public void UnregisterMessageHandler(string channel) { }
            
            public IReadOnlyList<NetworkPlayer> GetConnectedPlayers() => new List<NetworkPlayer>();
            
            public NetworkPlayer GetPlayer(string playerId) => null;
            
            public event EventHandler<PlayerEventArgs> PlayerJoined;
            public event EventHandler<PlayerEventArgs> PlayerLeft;
            public event EventHandler<EventArgs> Connected;
            public event EventHandler<EventArgs> Disconnected;
            public event EventHandler<NetworkErrorEventArgs> Error;
            
            public Task ListenAsync(Uri address, CancellationToken cancellationToken = default)
                => Task.CompletedTask;
            
            public Task StopListeningAsync(CancellationToken cancellationToken = default)
                => Task.CompletedTask;
            
            public Task<NetworkSession> CreateSessionAsync(string sessionName, int maxPlayers, CancellationToken cancellationToken = default)
                => Task.FromResult(new NetworkSession { SessionId = sessionName, MaxPlayers = maxPlayers });
            
            public NetworkSession GetSession(string sessionId) => null;
            
            public IReadOnlyList<NetworkSession> GetActiveSessions() => new List<NetworkSession>();
            
            public Task CloseSessionAsync(string sessionId, CancellationToken cancellationToken = default)
                => Task.CompletedTask;
            
            public Task KickPlayerAsync(string playerId, string sessionId, string reason = null, CancellationToken cancellationToken = default)
                => Task.CompletedTask;
            
            public event EventHandler<ClientConnectionEventArgs> ClientConnected;
            public event EventHandler<ClientDisconnectionEventArgs> ClientDisconnected;
            
            public void Dispose() { }
        }

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
