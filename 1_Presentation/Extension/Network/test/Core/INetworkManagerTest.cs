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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Aspect.Data.Json;
using Alis.Extension.Network.Core;
using Xunit;
using Xunit.Sdk;

namespace Alis.Extension.Network.Test.Core
{
    /// <summary>
    ///     Tests for INetworkManager interface
    /// </summary>
    public class INetworkManagerTest
    {
        private class TestNetworkManager : INetworkManager
        {
            public string Id => "test-id";
            public NetworkManagerState State => NetworkManagerState.Disconnected;
            public NetworkSession CurrentSession => null;
            public NetworkPlayer LocalPlayer => null;
            public NetworkConfig Config { get; set; } = new NetworkConfig();
            
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
            
            public void Dispose() { }
        }

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
