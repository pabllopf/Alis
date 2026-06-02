// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkClientManagerTest.cs
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
using Alis.Extension.Network.Client;
using Alis.Extension.Network.Core;
using Xunit;

namespace Alis.Extension.Network.Test.Client
{
    /// <summary>
    ///     The network client manager test class
    /// </summary>
    public class NetworkClientManagerTest
    {
        /// <summary>
        ///     Tests that constructor initializes default state
        /// </summary>
        [Fact]
        public void Constructor_DefaultState_IsUninitialized()
        {
            using NetworkClientManager manager = new NetworkClientManager();

            Assert.Equal(NetworkManagerState.Uninitialized, manager.State);
            Assert.NotNull(manager.Id);
            Assert.NotEmpty(manager.Id);
            Assert.Null(manager.CurrentSession);
            Assert.Null(manager.LocalPlayer);
            Assert.Null(manager.Config);
            Assert.Null(manager.ServerUri);
        }

        /// <summary>
        ///     Tests that constructor generates unique ids
        /// </summary>
        [Fact]
        public void Constructor_GeneratesUniqueIds()
        {
            using NetworkClientManager manager1 = new NetworkClientManager();
            using NetworkClientManager manager2 = new NetworkClientManager();

            Assert.NotEqual(manager1.Id, manager2.Id);
        }

        /// <summary>
        ///     Tests that initialize async transitions to idle state
        /// </summary>
        [Fact]
        public async Task InitializeAsync_WithConfig_TransitionsToIdle()
        {
            using NetworkClientManager manager = new NetworkClientManager();
            NetworkConfig config = new NetworkConfig {MaxPlayers = 16};

            await manager.InitializeAsync(config);

            Assert.Equal(NetworkManagerState.Idle, manager.State);
            Assert.NotNull(manager.Config);
            Assert.Equal(16, manager.Config.MaxPlayers);
        }

        /// <summary>
        ///     Tests that initialize async with null config uses default config
        /// </summary>
        [Fact]
        public async Task InitializeAsync_NullConfig_UsesDefaults()
        {
            using NetworkClientManager manager = new NetworkClientManager();

            await manager.InitializeAsync(null);

            Assert.Equal(NetworkManagerState.Idle, manager.State);
            Assert.NotNull(manager.Config);
            Assert.Equal(32, manager.Config.MaxPlayers);
        }

        /// <summary>
        ///     Tests that initialize async throws if already initialized
        /// </summary>
        [Fact]
        public async Task InitializeAsync_AlreadyInitialized_Throws()
        {
            using NetworkClientManager manager = new NetworkClientManager();
            await manager.InitializeAsync(new NetworkConfig());

            InvalidOperationException ex = await Assert.ThrowsAsync<InvalidOperationException>(() => manager.InitializeAsync(new NetworkConfig()));
            Assert.Contains("Already initialized", ex.Message);
        }

        /// <summary>
        ///     Tests that start async works in idle state
        /// </summary>
        [Fact]
        public async Task StartAsync_InIdleState_Completes()
        {
            using NetworkClientManager manager = new NetworkClientManager();
            await manager.InitializeAsync(new NetworkConfig());

            await manager.StartAsync();

            Assert.Equal(NetworkManagerState.Idle, manager.State);
        }

        /// <summary>
        ///     Tests that start async throws in uninitialized state
        /// </summary>
        [Fact]
        public async Task StartAsync_Uninitialized_Throws()
        {
            using NetworkClientManager manager = new NetworkClientManager();

            InvalidOperationException ex = await Assert.ThrowsAsync<InvalidOperationException>(() => manager.StartAsync());
            Assert.Contains("Cannot start", ex.Message);
        }

        /// <summary>
        ///     Tests that register and unregister message handler works
        /// </summary>
        [Fact]
        public void RegisterAndUnregisterMessageHandler_WorkCorrectly()
        {
            using NetworkClientManager manager = new NetworkClientManager();
            bool handlerCalled = false;
            Func<string, string, Task> handler = (sender, payload) =>
            {
                handlerCalled = true;
                return Task.CompletedTask;
            };

            manager.RegisterMessageHandler("chat", handler);
            manager.UnregisterMessageHandler("chat");
        }

        /// <summary>
        ///     Tests that get connected players returns empty list when no session
        /// </summary>
        [Fact]
        public void GetConnectedPlayers_NoSession_ReturnsEmptyList()
        {
            using NetworkClientManager manager = new NetworkClientManager();

            var players = manager.GetConnectedPlayers();

            Assert.Empty(players);
        }

        /// <summary>
        ///     Tests that get player returns null when no session
        /// </summary>
        [Fact]
        public void GetPlayer_NoSession_ReturnsNull()
        {
            using NetworkClientManager manager = new NetworkClientManager();

            NetworkPlayer player = manager.GetPlayer("any-id");

            Assert.Null(player);
        }
    }
}
