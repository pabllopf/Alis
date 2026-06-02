// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkServerManagerTest.cs
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
using Alis.Extension.Network.Core;
using Alis.Extension.Network.Server;
using Xunit;

namespace Alis.Extension.Network.Test.Server
{
    /// <summary>
    ///     The network server manager test class
    /// </summary>
    public class NetworkServerManagerTest
    {
        /// <summary>
        ///     Tests that constructor initializes default state
        /// </summary>
        [Fact]
        public void Constructor_DefaultState_IsUninitialized()
        {
            using NetworkServerManager manager = new NetworkServerManager();

            Assert.Equal(NetworkManagerState.Uninitialized, manager.State);
            Assert.NotNull(manager.Id);
            Assert.NotEmpty(manager.Id);
            Assert.Null(manager.CurrentSession);
            Assert.Null(manager.LocalPlayer);
            Assert.Null(manager.Config);
            Assert.Null(manager.ListenUri);
        }

        /// <summary>
        ///     Tests that constructor generates unique ids
        /// </summary>
        [Fact]
        public void Constructor_GeneratesUniqueIds()
        {
            using NetworkServerManager manager1 = new NetworkServerManager();
            using NetworkServerManager manager2 = new NetworkServerManager();

            Assert.NotEqual(manager1.Id, manager2.Id);
        }

        /// <summary>
        ///     Tests that initialize async transitions to idle state
        /// </summary>
        [Fact]
        public async Task InitializeAsync_WithConfig_TransitionsToIdle()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            NetworkConfig config = new NetworkConfig {MaxPlayers = 16};

            await manager.InitializeAsync(config);

            Assert.Equal(NetworkManagerState.Idle, manager.State);
            Assert.NotNull(manager.Config);
            Assert.Equal(16, manager.Config.MaxPlayers);
            Assert.NotNull(manager.LocalPlayer);
            Assert.Equal("Server", manager.LocalPlayer.PlayerName);
        }

        /// <summary>
        ///     Tests that initialize async with null config uses default config
        /// </summary>
        [Fact]
        public async Task InitializeAsync_NullConfig_UsesDefaults()
        {
            using NetworkServerManager manager = new NetworkServerManager();

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
            using NetworkServerManager manager = new NetworkServerManager();
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
            using NetworkServerManager manager = new NetworkServerManager();
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
            using NetworkServerManager manager = new NetworkServerManager();

            InvalidOperationException ex = await Assert.ThrowsAsync<InvalidOperationException>(() => manager.StartAsync());
            Assert.Contains("Cannot start", ex.Message);
        }

        /// <summary>
        ///     Tests that create session async creates session correctly
        /// </summary>
        [Fact]
        public async Task CreateSessionAsync_CreatesSession_ReturnsSession()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());

            NetworkSession session = await manager.CreateSessionAsync("TestGame", 8);

            Assert.NotNull(session);
            Assert.Equal("TestGame", session.SessionName);
            Assert.Equal(8, session.MaxPlayers);
            Assert.Equal(SessionState.Waiting, session.State);
            Assert.Equal(1, session.PlayerCount);
            Assert.NotNull(session.SessionId);
        }

        /// <summary>
        ///     Tests that create session async sets current session
        /// </summary>
        [Fact]
        public async Task CreateSessionAsync_SetsCurrentSession()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());

            NetworkSession session = await manager.CreateSessionAsync("Game", 4);

            Assert.Equal(session, manager.CurrentSession);
        }

        /// <summary>
        ///     Tests that get session returns null for unknown session
        /// </summary>
        [Fact]
        public void GetSession_UnknownId_ReturnsNull()
        {
            using NetworkServerManager manager = new NetworkServerManager();

            NetworkSession session = manager.GetSession("non-existent");

            Assert.Null(session);
        }

        /// <summary>
        ///     Tests that get session returns session after creation
        /// </summary>
        [Fact]
        public async Task GetSession_AfterCreation_ReturnsSession()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());
            NetworkSession created = await manager.CreateSessionAsync("Game", 4);

            NetworkSession retrieved = manager.GetSession(created.SessionId);

            Assert.Equal(created, retrieved);
        }

        /// <summary>
        ///     Tests that get active sessions returns only non-closed sessions
        /// </summary>
        [Fact]
        public async Task GetActiveSessions_AfterClose_ExcludesClosed()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());
            NetworkSession session = await manager.CreateSessionAsync("Game", 4);
            await manager.CloseSessionAsync(session.SessionId);

            var active = manager.GetActiveSessions();

            Assert.DoesNotContain(session, active);
        }

        /// <summary>
        ///     Tests that close session async sets state to closed
        /// </summary>
        [Fact]
        public async Task CloseSessionAsync_SetsStateToClosed()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());
            NetworkSession session = await manager.CreateSessionAsync("Game", 4);

            await manager.CloseSessionAsync(session.SessionId);

            Assert.Equal(SessionState.Closed, session.State);
        }

        /// <summary>
        ///     Tests that register and unregister message handler works
        /// </summary>
        [Fact]
        public void RegisterAndUnregisterMessageHandler_WorkCorrectly()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            Func<string, string, Task> handler = (sender, payload) => Task.CompletedTask;

            manager.RegisterMessageHandler("chat", handler);
            manager.UnregisterMessageHandler("chat");
        }

        /// <summary>
        ///     Tests that get connected players returns empty list when no session
        /// </summary>
        [Fact]
        public void GetConnectedPlayers_NoSession_ReturnsEmptyList()
        {
            using NetworkServerManager manager = new NetworkServerManager();

            var players = manager.GetConnectedPlayers();

            Assert.Empty(players);
        }

        /// <summary>
        ///     Tests that get player returns null when no session
        /// </summary>
        [Fact]
        public void GetPlayer_NoSession_ReturnsNull()
        {
            using NetworkServerManager manager = new NetworkServerManager();

            NetworkPlayer player = manager.GetPlayer("any-id");

            Assert.Null(player);
        }

        /// <summary>
        ///     Tests that dispose can be called multiple times
        /// </summary>
        [Fact]
        public void Dispose_MultipleTimes_DoesNotThrow()
        {
            NetworkServerManager manager = new NetworkServerManager();
            manager.Dispose();
            manager.Dispose();
        }

        /// <summary>
        ///     Tests that register player in session adds player
        /// </summary>
        [Fact]
        public async Task RegisterPlayerInSession_AddsPlayer()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());
            await manager.CreateSessionAsync("Game", 4);

            manager.RegisterPlayerInSession("p1", "Player1");

            Assert.Equal(2, manager.CurrentSession.Players.Count);
        }

        /// <summary>
        ///     Tests that register player in session does not duplicate
        /// </summary>
        [Fact]
        public async Task RegisterPlayerInSession_DoesNotDuplicate()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());
            await manager.CreateSessionAsync("Game", 4);

            manager.RegisterPlayerInSession("p1", "Player1");
            manager.RegisterPlayerInSession("p1", "Player1");

            Assert.Equal(2, manager.CurrentSession.Players.Count);
        }

        /// <summary>
        ///     Tests that kick player async removes player from session
        /// </summary>
        [Fact]
        public async Task KickPlayerAsync_RemovesPlayer()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());
            await manager.CreateSessionAsync("Game", 4);
            manager.RegisterPlayerInSession("p1", "Player1");

            await manager.KickPlayerAsync("p1", manager.CurrentSession.SessionId);

            Assert.Null(manager.CurrentSession.Players.Find(p => p.PlayerId == "p1"));
        }

        /// <summary>
        ///     Tests that listen async throws in uninitialized state
        /// </summary>
        [Fact]
        public async Task ListenAsync_Uninitialized_Throws()
        {
            using NetworkServerManager manager = new NetworkServerManager();

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => manager.ListenAsync(new Uri("http://localhost:8888")));
        }
    }
}
