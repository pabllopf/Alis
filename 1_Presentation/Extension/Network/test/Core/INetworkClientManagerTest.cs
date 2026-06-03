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
        private class TestNetworkClientManager : INetworkClientManager
        {
            public string Id => "client-test-id";
            public NetworkManagerState State => NetworkManagerState.Disconnected;
            public NetworkSession CurrentSession => null;
            public NetworkPlayer LocalPlayer => null;
            public NetworkConfig Config { get; set; } = new NetworkConfig();
            public Uri ServerUri => new Uri("ws://localhost:8080");
            
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
            
            public Task ConnectAsync(Uri serverUri, string playerName, CancellationToken cancellationToken = default)
                => Task.CompletedTask;
            
            public Task DisconnectAsync(CancellationToken cancellationToken = default)
                => Task.CompletedTask;
            
            public event EventHandler<ServerMessageEventArgs> ServerMessageReceived;
            
            public void Dispose() { }
        }

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

        [Fact]
        public void ServerUri_ReturnsCorrectUri()
        {
            // Arrange
            TestNetworkClientManager manager = new TestNetworkClientManager();

            // Act
            Uri result = manager.ServerUri;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("ws://localhost:8080", result.ToString());
        }

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
