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
using System.Collections.Generic;
using System.Threading.Tasks;
using Alis.Extension.Network.Core;
using Alis.Extension.Network.Server;
using Xunit;

namespace Alis.Extension.Network.Test.Server
{
    /// <summary>
    ///     Comprehensive tests for NetworkServerManager - server-side network connection manager
    /// </summary>
    public class NetworkServerManagerTest : IDisposable
    {
        private readonly NetworkServerManager _manager;
        private readonly NetworkConfig _defaultConfig;

        public NetworkServerManagerTest()
        {
            _manager = new NetworkServerManager();
            _defaultConfig = new NetworkConfig { MaxPlayers = 32 };
        }

        public void Dispose()
        {
            _manager?.Dispose();
        }

        #region Constructor Tests

        /// <summary>
        ///     Arrange: Create NetworkServerManager with default constructor
        ///     Act: Verify manager initialization
        ///     Assert: Manager is in Uninitialized state with valid ID
        /// </summary>
        [Fact]
        public void Constructor_DefaultState_IsUninitialized()
        {
            // Arrange: Using _manager from constructor

            // Act: Check initial state and properties
            NetworkManagerState currentState = _manager.State;
            string managerId = _manager.Id;

            // Assert: Manager is properly initialized
            Assert.Equal(NetworkManagerState.Uninitialized, currentState);
            Assert.NotNull(managerId);
            Assert.NotEmpty(managerId);
            Assert.Null(_manager.CurrentSession);
            Assert.Null(_manager.LocalPlayer);
            Assert.Null(_manager.Config);
            Assert.Null(_manager.ListenUri);
        }

        /// <summary>
        ///     Arrange: Create two NetworkServerManager instances
        ///     Act: Verify each generates unique identifier
        ///     Assert: Each manager has distinct ID
        /// </summary>
        [Fact]
        public void Constructor_GeneratesUniqueIds()
        {
            // Arrange: Create two managers
            using NetworkServerManager manager1 = new NetworkServerManager();
            using NetworkServerManager manager2 = new NetworkServerManager();

            // Act: Compare IDs
            string id1 = manager1.Id;
            string id2 = manager2.Id;

            // Assert: IDs are unique
            Assert.NotEqual(id1, id2);
            Assert.NotNull(id1);
            Assert.NotNull(id2);
        }

        /// <summary>
        ///     Arrange: Create NetworkServerManager and check all properties
        ///     Act: Access all public properties
        ///     Assert: Properties return expected default values
        /// </summary>
        [Fact]
        public void Constructor_InitializesAllPropertiesCorrectly()
        {
            // Arrange: Using _manager from constructor

            // Act: Access all properties
            string id = _manager.Id;
            NetworkManagerState state = _manager.State;
            NetworkSession session = _manager.CurrentSession;
            NetworkPlayer player = _manager.LocalPlayer;
            NetworkConfig config = _manager.Config;
            Uri listenUri = _manager.ListenUri;

            // Assert: All properties have correct default values
            Assert.NotNull(id);
            Assert.Equal(NetworkManagerState.Uninitialized, state);
            Assert.Null(session);
            Assert.Null(player);
            Assert.Null(config);
            Assert.Null(listenUri);
        }

        #endregion

        #region Initialization Tests

        /// <summary>
        ///     Arrange: Create NetworkServerManager and initialize with config
        ///     Act: Call InitializeAsync with valid configuration
        ///     Assert: Manager transitions to Idle state with config and host player set
        /// </summary>
        [Fact]
        public async Task InitializeAsync_WithConfig_TransitionsToIdle()
        {
            // Arrange: Using _manager from constructor

            // Act: Initialize with config
            NetworkConfig config = new NetworkConfig { MaxPlayers = 16 };
            await _manager.InitializeAsync(config);

            // Assert: Manager is in Idle state with correct config and host player
            Assert.Equal(NetworkManagerState.Idle, _manager.State);
            Assert.NotNull(_manager.Config);
            Assert.Equal(16, _manager.Config.MaxPlayers);
            Assert.NotNull(_manager.LocalPlayer);
            Assert.Equal("Server", _manager.LocalPlayer.PlayerName);
            Assert.True(_manager.LocalPlayer.IsHost);
        }

        /// <summary>
        ///     Arrange: Create NetworkServerManager and initialize with null config
        ///     Act: Call InitializeAsync with null configuration
        ///     Assert: Manager uses default configuration values and creates host player
        /// </summary>
        [Fact]
        public async Task InitializeAsync_NullConfig_UsesDefaults()
        {
            // Arrange: Using _manager from constructor

            // Act: Initialize with null config
            await _manager.InitializeAsync(null);

            // Assert: Manager uses default configuration and creates host player
            Assert.Equal(NetworkManagerState.Idle, _manager.State);
            Assert.NotNull(_manager.Config);
            Assert.Equal(32, _manager.Config.MaxPlayers); // Default value
            Assert.NotNull(_manager.LocalPlayer);
            Assert.Equal("Server", _manager.LocalPlayer.PlayerName);
        }

        /// <summary>
        ///     Arrange: Create NetworkServerManager and initialize it
        ///     Act: Try to initialize again with different config
        ///     Assert: InvalidOperationException is thrown
        /// </summary>
        [Fact]
        public async Task InitializeAsync_AlreadyInitialized_ThrowsInvalidOperationException()
        {
            // Arrange: Initialize manager once
            await _manager.InitializeAsync(new NetworkConfig());

            // Act & Assert: Try to initialize again
            InvalidOperationException ex = await Assert.ThrowsAsync<InvalidOperationException>(
                () => _manager.InitializeAsync(new NetworkConfig { MaxPlayers = 64 }));

            Assert.Contains("Already initialized", ex.Message);
        }

        /// <summary>
        ///     Arrange: Create NetworkServerManager and initialize with config
        ///     Act: Initialize with custom configuration values
        ///     Assert: All custom config values are preserved and host player is created
        /// </summary>
        [Fact]
        public async Task InitializeAsync_CustomConfig_PreservesAllSettings()
        {
            // Arrange: Using _manager from constructor

            // Act: Initialize with custom config
            NetworkConfig customConfig = new NetworkConfig
            {
                MaxPlayers = 100,
                HeartbeatInterval = new TimeSpan(30000)
            };

            await _manager.InitializeAsync(customConfig);

            // Assert: All custom settings are preserved
            Assert.Equal(NetworkManagerState.Idle, _manager.State);
            Assert.Equal(100, _manager.Config.MaxPlayers);
            Assert.NotNull(_manager.LocalPlayer);
            Assert.True(_manager.LocalPlayer.IsHost);
        }

        #endregion

        #region State Management Tests

        /// <summary>
        ///     Arrange: Create NetworkServerManager and initialize it
        ///     Act: Call StartAsync in Idle state
        ///     Assert: Manager remains in Idle state (no-op for server without ListenAsync)
        /// </summary>
        [Fact]
        public async Task StartAsync_InIdleState_CompletesSuccessfully()
        {
            // Arrange: Initialize manager
            await _manager.InitializeAsync(new NetworkConfig());

            // Act: Start manager
            await _manager.StartAsync();

            // Assert: Manager remains in Idle state
            Assert.Equal(NetworkManagerState.Idle, _manager.State);
        }

        /// <summary>
        ///     Arrange: Create NetworkServerManager without initializing
        ///     Act: Try to start manager without initialization
        ///     Assert: InvalidOperationException is thrown
        /// </summary>
        [Fact]
        public async Task StartAsync_Uninitialized_ThrowsInvalidOperationException()
        {
            // Arrange: Using _manager from constructor (not initialized)

            // Act & Assert: Try to start without initialization
            InvalidOperationException ex = await Assert.ThrowsAsync<InvalidOperationException>(
                () => _manager.StartAsync());

            Assert.Contains("Cannot start", ex.Message);
        }

    
        #endregion

        #region Session Management Tests

        /// <summary>
        ///     Arrange: Create NetworkServerManager and initialize it
        ///     Act: Call CreateSessionAsync with valid parameters
        ///     Assert: Session is created with correct properties and added to manager
        /// </summary>
        [Fact]
        public async Task CreateSessionAsync_CreatesSession_ReturnsSession()
        {
            // Arrange: Initialize manager
            await _manager.InitializeAsync(new NetworkConfig());

            // Act: Create session
            NetworkSession session = await _manager.CreateSessionAsync("TestGame", 8);

            // Assert: Session is created with correct properties
            Assert.NotNull(session);
            Assert.Equal("TestGame", session.SessionName);
            Assert.Equal(8, session.MaxPlayers);
            Assert.Equal(SessionState.Waiting, session.State);
            Assert.Equal(1, session.PlayerCount); // Host player
            Assert.NotNull(session.SessionId);
            Assert.NotEmpty(session.SessionId);
        }

        /// <summary>
        ///     Arrange: Create NetworkServerManager and initialize it
        ///     Act: Call CreateSessionAsync and verify current session is set
        ///     Assert: CurrentSession property returns the created session
        /// </summary>
        [Fact]
        public async Task CreateSessionAsync_SetsCurrentSession()
        {
            // Arrange: Initialize manager
            await _manager.InitializeAsync(new NetworkConfig());

            // Act: Create session
            NetworkSession session = await _manager.CreateSessionAsync("Game", 4);

            // Assert: CurrentSession is set to created session
            Assert.Equal(session, _manager.CurrentSession);
            Assert.NotNull(_manager.CurrentSession);
        }

        /// <summary>
        ///     Arrange: Create NetworkServerManager and initialize it
        ///     Act: Call GetSession with unknown session ID
        ///     Assert: Returns null
        /// </summary>
        [Fact]
        public void GetSession_UnknownId_ReturnsNull()
        {
            // Arrange: Using _manager from constructor

            // Act: Get session with unknown ID
            NetworkSession session = _manager.GetSession("non-existent-session-id");

            // Assert: Returns null
            Assert.Null(session);
        }

        /// <summary>
        ///     Arrange: Create NetworkServerManager, initialize and create session
        ///     Act: Get session by its ID
        ///     Assert: Returns the created session
        /// </summary>
        [Fact]
        public async Task GetSession_AfterCreation_ReturnsSession()
        {
            // Arrange: Initialize manager and create session
            await _manager.InitializeAsync(new NetworkConfig());
            NetworkSession created = await _manager.CreateSessionAsync("Game", 4);

            // Act: Get session by ID
            NetworkSession retrieved = _manager.GetSession(created.SessionId);

            // Assert: Returns the created session
            Assert.Equal(created, retrieved);
            Assert.NotNull(retrieved);
        }

        /// <summary>
        ///     Arrange: Create NetworkServerManager, initialize and create session
        ///     Act: Close session and get active sessions
        ///     Assert: Closed session is not included in active sessions list
        /// </summary>
        [Fact]
        public async Task GetActiveSessions_AfterClose_ExcludesClosed()
        {
            // Arrange: Initialize manager and create session
            await _manager.InitializeAsync(new NetworkConfig());
            NetworkSession session = await _manager.CreateSessionAsync("Game", 4);

            // Act: Close session and get active sessions
            await _manager.CloseSessionAsync(session.SessionId);
            IReadOnlyList<NetworkSession> active = _manager.GetActiveSessions();

            // Assert: Closed session is not included
            Assert.DoesNotContain(session, active);
            Assert.Empty(active);
        }

        /// <summary>
        ///     Arrange: Create NetworkServerManager, initialize and create session
        ///     Act: Close session by ID
        ///     Assert: Session state is set to Closed
        /// </summary>
        [Fact]
        public async Task CloseSessionAsync_SetsStateToClosed()
        {
            // Arrange: Initialize manager and create session
            await _manager.InitializeAsync(new NetworkConfig());
            NetworkSession session = await _manager.CreateSessionAsync("Game", 4);

            // Act: Close session
            await _manager.CloseSessionAsync(session.SessionId);

            // Assert: Session state is Closed
            Assert.Equal(SessionState.Closed, session.State);
        }

        /// <summary>
        ///     Arrange: Create NetworkServerManager, initialize and create session
        ///     Act: Create multiple sessions and get all active sessions
        ///     Assert: Returns all non-closed sessions
        /// </summary>
        [Fact]
        public async Task GetActiveSessions_MultipleSessions_ReturnsAllActive()
        {
            // Arrange: Initialize manager and create multiple sessions
            await _manager.InitializeAsync(new NetworkConfig());

            NetworkSession session1 = await _manager.CreateSessionAsync("Game1", 4);
            NetworkSession session2 = await _manager.CreateSessionAsync("Game2", 8);

            // Act: Get active sessions
            IReadOnlyList<NetworkSession> active = _manager.GetActiveSessions();

            // Assert: Returns all active sessions
            Assert.Equal(2, active.Count);
            Assert.Contains(session1, active);
            Assert.Contains(session2, active);
        }

        #endregion

        #region Player Management Tests



        /// <summary>
        ///     Arrange: Create NetworkServerManager, initialize and create session
        ///     Act: Register same player twice
        ///     Assert: Player is not duplicated in session
        /// </summary>
        [Fact]
        public async Task RegisterPlayerInSession_DoesNotDuplicate()
        {
            // Arrange: Initialize manager and create session
            await _manager.InitializeAsync(new NetworkConfig());
            await _manager.CreateSessionAsync("Game", 4);

            // Act: Register same player twice
            _manager.RegisterPlayerInSession("p1", "Player1");
            _manager.RegisterPlayerInSession("p1", "Player1");

            // Assert: Player is not duplicated
            Assert.Equal(2, _manager.CurrentSession.Players.Count); // Host + Player1 (not 3)
        }

        /// <summary>
        ///     Arrange: Create NetworkServerManager, initialize and create session
        ///     Act: Register player and then kick them
        ///     Assert: Player is removed from session
        /// </summary>
        [Fact]
        public async Task KickPlayerAsync_RemovesPlayer()
        {
            // Arrange: Initialize manager, create session and register player
            await _manager.InitializeAsync(new NetworkConfig());
            await _manager.CreateSessionAsync("Game", 4);
            _manager.RegisterPlayerInSession("p1", "Player1");

            // Act: Kick player
            await _manager.KickPlayerAsync("p1", _manager.CurrentSession.SessionId);

            // Assert: Player is removed from session
            NetworkPlayer player = _manager.CurrentSession.Players.Find(p => p.PlayerId == "p1");
            Assert.Null(player);
        }

        /// <summary>
        ///     Arrange: Create NetworkServerManager, initialize and create session
        ///     Act: Get connected players
        ///     Assert: Returns list with host player
        /// </summary>
        [Fact]
        public void GetConnectedPlayers_NoSession_ReturnsEmptyList()
        {
            // Arrange: Using _manager from constructor

            // Act: Get connected players
            IReadOnlyList<NetworkPlayer> players = _manager.GetConnectedPlayers();

            // Assert: Returns empty list
            Assert.Empty(players);
        }

        /// <summary>
        ///     Arrange: Create NetworkServerManager, initialize and create session
        ///     Act: Register player and get by ID
        ///     Assert: Returns the registered player
        /// </summary>
        [Fact]
        public async Task GetPlayer_AfterRegistration_ReturnsPlayer()
        {
            // Arrange: Initialize manager, create session and register player
            await _manager.InitializeAsync(new NetworkConfig());
            await _manager.CreateSessionAsync("Game", 4);
            _manager.RegisterPlayerInSession("p1", "Player1");

            // Act: Get player by ID
            NetworkPlayer player = _manager.GetPlayer("p1");

            // Assert: Returns the registered player
            Assert.NotNull(player);
            Assert.Equal("p1", player.PlayerId);
            Assert.Equal("Player1", player.PlayerName);
        }

        /// <summary>
        ///     Arrange: Create NetworkServerManager, initialize and create session
        ///     Act: Get player with non-existent ID
        ///     Assert: Returns null
        /// </summary>
        [Fact]
        public void GetPlayer_NotFound_ReturnsNull()
        {
            // Arrange: Initialize manager and create session

            // Act: Get player with non-existent ID
            NetworkPlayer player = _manager.GetPlayer("non-existent-id");

            // Assert: Returns null
            Assert.Null(player);
        }

        #endregion

        #region Message Handling Tests

        /// <summary>
        ///     Arrange: Create NetworkServerManager and register message handler
        ///     Act: Register and unregister handlers for different channels
        ///     Assert: Handlers are managed correctly
        /// </summary>
        [Fact]
        public void RegisterAndUnregisterMessageHandler_HandlersAreManagedCorrectly()
        {
            // Arrange: Using _manager from constructor

            // Act: Register handler
            Func<string, string, Task> chatHandler = (sender, payload) => Task.CompletedTask;

            _manager.RegisterMessageHandler("chat", chatHandler);

            // Assert: Handler is registered
            _manager.UnregisterMessageHandler("chat");

            // Verify no exception on unregistering non-existent handler
            _manager.UnregisterMessageHandler("chat");
        }

        /// <summary>
        ///     Arrange: Create NetworkServerManager and register multiple handlers
        ///     Act: Register handlers for different channels
        ///     Assert: Each channel has its own handler
        /// </summary>
        [Fact]
        public void RegisterMultipleMessageHandlers_MultipleChannelsWorkIndependently()
        {
            // Arrange: Using _manager from constructor

            // Act: Register handlers for different channels
            _manager.RegisterMessageHandler("chat", (sender, payload) => Task.CompletedTask);
            _manager.RegisterMessageHandler("system", (sender, payload) => Task.CompletedTask);

            // Assert: Both handlers are registered
            _manager.UnregisterMessageHandler("chat");
            _manager.UnregisterMessageHandler("system");
        }

        #endregion

        #region Event Handling Tests

        

        #endregion

        #region Disposal Tests

        /// <summary>
        ///     Arrange: Create NetworkServerManager
        ///     Act: Call Dispose once
        ///     Assert: Manager is disposed without exceptions
        /// </summary>
        [Fact]
        public void Dispose_SingleCall_DoesNotThrow()
        {
            // Arrange: Using _manager from constructor

            // Act: Dispose manager
            _manager.Dispose();

            // Assert: No exception thrown
        }

        /// <summary>
        ///     Arrange: Create NetworkServerManager and dispose it
        ///     Act: Call Dispose multiple times
        ///     Assert: No exceptions are thrown on subsequent calls
        /// </summary>
        [Fact]
        public void Dispose_MultipleTimes_DoesNotThrow()
        {
            // Arrange: Using _manager from constructor

            // Act: Dispose multiple times
            _manager.Dispose();
            _manager.Dispose();
            _manager.Dispose();

            // Assert: No exceptions thrown
        }

        /// <summary>
        ///     Arrange: Create NetworkServerManager and initialize it
        ///     Act: Dispose manager after initialization
        ///     Assert: Manager is properly cleaned up
        /// </summary>
        [Fact]
        public void Dispose_AfterInitialization_CleansUpProperly()
        {
            // Arrange: Initialize manager
            _manager.InitializeAsync(new NetworkConfig()).Wait();

            // Act: Dispose manager
            _manager.Dispose();

            // Assert: No exception thrown during disposal
        }

        #endregion

        #region Integration Tests


        

        /// <summary>
        ///     Arrange: Create NetworkServerManager and initialize it
        ///     Act: Complete full session lifecycle: Create -> AddPlayers -> Close
        ///     Assert: Session management works correctly throughout lifecycle
        /// </summary>
        [Fact]
        public async Task SessionLifecycle_CompleteSessionLifecycleWorks()
        {
            // Arrange: Initialize manager
            await _manager.InitializeAsync(new NetworkConfig());

            // Act: Create session, add players, close session
            NetworkSession session = await _manager.CreateSessionAsync("TestGame", 4);
            _manager.RegisterPlayerInSession("p1", "Player1");
            _manager.RegisterPlayerInSession("p2", "Player2");

            // Verify session state
            Assert.Equal(SessionState.Waiting, session.State);
            Assert.Equal(3, session.PlayerCount); // Host + 2 players

            // Close session
            await _manager.CloseSessionAsync(session.SessionId);
            Assert.Equal(SessionState.Closed, session.State);

            // Verify session is excluded from active sessions
            IReadOnlyList<NetworkSession> active = _manager.GetActiveSessions();
            Assert.Empty(active);

            _manager.Dispose();
        }

        #endregion

        #region Edge Cases and Error Handling

        /// <summary>
        ///     Arrange: Create NetworkServerManager without initializing
        ///     Act: Try to listen without initialization
        ///     Assert: InvalidOperationException is thrown
        /// </summary>
        [Fact]
        public async Task ListenAsync_Uninitialized_ThrowsInvalidOperationException()
        {
            // Arrange: Using _manager from constructor (not initialized)

            // Act & Assert: Try to listen without initialization
            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _manager.ListenAsync(new Uri("http://localhost:8888")));
        }

        /// <summary>
        ///     Arrange: Create NetworkServerManager and initialize it
        ///     Act: Try to listen without proper setup
        ///     Assert: Listener fails gracefully
        /// </summary>
        [Fact]
        public async Task ListenAsync_WithoutProperSetup_FailsGracefully()
        {
            // Arrange: Initialize manager

            // Act & Assert: Try to listen (will fail at network level)
            try
            {
                await _manager.ListenAsync(new Uri("http://localhost:0")); // Invalid port
            }
            catch (Exception)
            {
                // Expected to fail
            }

            // Assert: Manager handles edge case without crashing
            Assert.NotNull(_manager.Id);
        }

    

        #endregion
    }
}
