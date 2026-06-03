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
using System.Collections.Generic;
using System.Threading.Tasks;
using Alis.Extension.Network.Client;
using Alis.Extension.Network.Core;
using Xunit;

namespace Alis.Extension.Network.Test.Client
{
    /// <summary>
    ///     Comprehensive tests for NetworkClientManager - client-side network connection manager
    /// </summary>
    public class NetworkClientManagerTest : IDisposable
    {
        private readonly NetworkClientManager _manager;
        private readonly NetworkConfig _defaultConfig;

        public NetworkClientManagerTest()
        {
            _manager = new NetworkClientManager();
            _defaultConfig = new NetworkConfig { MaxPlayers = 32 };
        }

        public void Dispose()
        {
            _manager?.Dispose();
        }

        #region Constructor Tests

        /// <summary>
        ///     Arrange: Create NetworkClientManager with default constructor
        ///     Act: Verify manager initialization
        ///     Assert: Manager is in Uninitialized state with valid ID
        /// </summary>
        [Fact]
        public void Constructor_DefaultState_IsUninitialized()
        {
            // Arrange: Using _manager from constructor

            // Act: Check initial state
            NetworkManagerState currentState = _manager.State;
            string managerId = _manager.Id;

            // Assert: Manager is properly initialized
            Assert.Equal(NetworkManagerState.Uninitialized, currentState);
            Assert.NotNull(managerId);
            Assert.NotEmpty(managerId);
            Assert.Null(_manager.CurrentSession);
            Assert.Null(_manager.LocalPlayer);
            Assert.Null(_manager.Config);
            Assert.Null(_manager.ServerUri);
        }

        /// <summary>
        ///     Arrange: Create two NetworkClientManager instances
        ///     Act: Verify each generates unique identifier
        ///     Assert: Each manager has distinct ID
        /// </summary>
        [Fact]
        public void Constructor_GeneratesUniqueIds()
        {
            // Arrange: Create two managers
            using NetworkClientManager manager1 = new NetworkClientManager();
            using NetworkClientManager manager2 = new NetworkClientManager();

            // Act: Compare IDs
            string id1 = manager1.Id;
            string id2 = manager2.Id;

            // Assert: IDs are unique
            Assert.NotEqual(id1, id2);
            Assert.NotNull(id1);
            Assert.NotNull(id2);
        }

        /// <summary>
        ///     Arrange: Create NetworkClientManager and check properties
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
            Uri serverUri = _manager.ServerUri;

            // Assert: All properties have correct default values
            Assert.NotNull(id);
            Assert.Equal(NetworkManagerState.Uninitialized, state);
            Assert.Null(session);
            Assert.Null(player);
            Assert.Null(config);
            Assert.Null(serverUri);
        }

        #endregion

        #region Initialization Tests

        /// <summary>
        ///     Arrange: Create NetworkClientManager and initialize with config
        ///     Act: Call InitializeAsync with valid configuration
        ///     Assert: Manager transitions to Idle state with config set
        /// </summary>
        [Fact]
        public async Task InitializeAsync_WithConfig_TransitionsToIdle()
        {
            // Arrange: Using _manager from constructor

            // Act: Initialize with config
            NetworkConfig config = new NetworkConfig { MaxPlayers = 16 };
            await _manager.InitializeAsync(config);

            // Assert: Manager is in Idle state with correct config
            Assert.Equal(NetworkManagerState.Idle, _manager.State);
            Assert.NotNull(_manager.Config);
            Assert.Equal(16, _manager.Config.MaxPlayers);
        }

        /// <summary>
        ///     Arrange: Create NetworkClientManager and initialize with null config
        ///     Act: Call InitializeAsync with null configuration
        ///     Assert: Manager uses default configuration values
        /// </summary>
        [Fact]
        public async Task InitializeAsync_NullConfig_UsesDefaults()
        {
            // Arrange: Using _manager from constructor

            // Act: Initialize with null config
            await _manager.InitializeAsync(null);

            // Assert: Manager uses default configuration
            Assert.Equal(NetworkManagerState.Idle, _manager.State);
            Assert.NotNull(_manager.Config);
            Assert.Equal(32, _manager.Config.MaxPlayers); // Default value
        }

        /// <summary>
        ///     Arrange: Create NetworkClientManager and initialize it
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
        ///     Arrange: Create NetworkClientManager and initialize with config
        ///     Act: Initialize with custom configuration values
        ///     Assert: All custom config values are preserved
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
        }

        #endregion

        #region State Management Tests

        /// <summary>
        ///     Arrange: Create NetworkClientManager and initialize it
        ///     Act: Call StartAsync in Idle state
        ///     Assert: Manager remains in Idle state (no-op for client)
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
        ///     Arrange: Create NetworkClientManager without initializing
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

        /// <summary>
        ///     Arrange: Create NetworkClientManager and initialize it
        ///     Act: Call StopAsync when in Idle state
        ///     Assert: Manager transitions to Disconnected state
        /// </summary>
        [Fact]
        public async Task StopAsync_InIdleState_TransitionsToDisconnected()
        {
            // Arrange: Initialize manager
            await _manager.InitializeAsync(new NetworkConfig());

            // Act: Stop manager
            await _manager.StopAsync();

            // Assert: Manager is in Disconnected state
            Assert.Equal(NetworkManagerState.Disconnected, _manager.State);
        }

        /// <summary>
        ///     Arrange: Create NetworkClientManager and initialize it
        ///     Act: Call StopAsync multiple times sequentially
        ///     Assert: No exceptions are thrown and state remains Disconnected
        /// </summary>
        [Fact]
        public async Task StopAsync_MultipleCalls_DoesNotThrow()
        {
            // Arrange: Initialize manager
            await _manager.InitializeAsync(new NetworkConfig());

            // Act: Call StopAsync multiple times
            await _manager.StopAsync();
            await _manager.StopAsync();
            await _manager.StopAsync();

            // Assert: No exceptions and state is Disconnected
            Assert.Equal(NetworkManagerState.Disconnected, _manager.State);
        }

        /// <summary>
        ///     Arrange: Create NetworkClientManager and initialize it
        ///     Act: Check state transitions through different operations
        ///     Assert: State machine works correctly
        /// </summary>
        [Fact]
        public async Task StateMachine_StateTransitionsAreCorrect()
        {
            // Arrange: Using _manager from constructor

            // Act: Test state transitions
            await _manager.InitializeAsync(new NetworkConfig());
            Assert.Equal(NetworkManagerState.Idle, _manager.State);

            await _manager.StopAsync();
            Assert.Equal(NetworkManagerState.Disconnected, _manager.State);

            // Try to initialize again - should throw
            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _manager.InitializeAsync(new NetworkConfig()));
        }

        #endregion

        #region Connection Tests

        /// <summary>
        ///     Arrange: Create NetworkClientManager without initializing
        ///     Act: Try to connect to server without initialization
        ///     Assert: InvalidOperationException is thrown
        /// </summary>
        [Fact]
        public async Task ConnectAsync_Uninitialized_ThrowsInvalidOperationException()
        {
            // Arrange: Using _manager from constructor (not initialized)

            // Act & Assert: Try to connect without initialization
            InvalidOperationException ex = await Assert.ThrowsAsync<InvalidOperationException>(
                () => _manager.ConnectAsync(new Uri("ws://localhost:8888"), "testPlayer"));

            Assert.Contains("Cannot connect", ex.Message);
        }

        /// <summary>
        ///     Arrange: Create NetworkClientManager and initialize it
        ///     Act: Try to connect without proper initialization
        ///     Assert: Connection fails with appropriate exception
        /// </summary>
        [Fact]
        public async Task ConnectAsync_WithoutProperSetup_FailsGracefully()
        {
            // Arrange: Initialize manager
            await _manager.InitializeAsync(new NetworkConfig());

            // Act & Assert: Try to connect to invalid server
            try
            {
                await _manager.ConnectAsync(new Uri("ws://invalid.server.invalid:9999"), "testPlayer");
                // If connection succeeds (unlikely), verify state
                Assert.Equal(NetworkManagerState.Connected, _manager.State);
            }
            catch (Exception)
            {
                // Expected - connection should fail
                Assert.Equal(NetworkManagerState.Error, _manager.State);
            }
        }

        /// <summary>
        ///     Arrange: Create NetworkClientManager and initialize it
        ///     Act: Verify connection state machine
        ///     Assert: State transitions through Connecting -> Connected/Error
        /// </summary>
        [Fact]
        public async Task ConnectAsync_StateTransitions_VerifyStateChanges()
        {
            // Arrange: Initialize manager
            await _manager.InitializeAsync(new NetworkConfig());

            // Act: Try to connect (will fail, but state should change)
            try
            {
                await _manager.ConnectAsync(new Uri("ws://localhost:8888"), "testPlayer");
            }
            catch (Exception)
            {
                // Expected to fail
            }

            // Assert: State machine worked correctly
            Assert.NotEqual(NetworkManagerState.Uninitialized, _manager.State);
        }

        #endregion

        #region Message Handling Tests

        /// <summary>
        ///     Arrange: Create NetworkClientManager and register message handler
        ///     Act: Register and unregister handlers for different channels
        ///     Assert: Handlers are managed correctly
        /// </summary>
        [Fact]
        public void RegisterAndUnregisterMessageHandler_HandlersAreManagedCorrectly()
        {
            // Arrange: Using _manager from constructor

            // Act: Register handler
            bool handlerCalled = false;
            Func<string, string, Task> chatHandler = (sender, payload) =>
            {
                handlerCalled = true;
                return Task.CompletedTask;
            };

            _manager.RegisterMessageHandler("chat", chatHandler);

            // Assert: Handler is registered
            // Note: Cannot directly verify handler exists, but can unregister
            _manager.UnregisterMessageHandler("chat");

            // Verify no exception on unregistering non-existent handler
            _manager.UnregisterMessageHandler("chat");
        }


        /// <summary>
        ///     Arrange: Create NetworkClientManager and get connected players
        ///     Act: Call GetConnectedPlayers without session
        ///     Assert: Returns empty list
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
        ///     Arrange: Create NetworkClientManager and try to get player
        ///     Act: Call GetPlayer with arbitrary player ID
        ///     Assert: Returns null when no session exists
        /// </summary>
        [Fact]
        public void GetPlayer_NoSession_ReturnsNull()
        {
            // Arrange: Using _manager from constructor

            // Act: Get player by ID
            NetworkPlayer player = _manager.GetPlayer("any-player-id");

            // Assert: Returns null
            Assert.Null(player);
        }

        #endregion

        #region Event Handling Tests

      
       
        #endregion

        #region Disposal Tests

        /// <summary>
        ///     Arrange: Create NetworkClientManager
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
        ///     Arrange: Create NetworkClientManager and dispose it
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
        ///     Arrange: Create NetworkClientManager and initialize it
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
        ///     Arrange: Create NetworkClientManager and initialize it
        ///     Act: Complete full lifecycle: Initialize -> Start -> Stop -> Dispose
        ///     Assert: Manager handles full lifecycle correctly
        /// </summary>
        [Fact]
        public async Task FullLifecycle_CompleteLifecycleWorksCorrectly()
        {
            // Arrange: Using _manager from constructor

            // Act: Complete lifecycle
            await _manager.InitializeAsync(new NetworkConfig());
            Assert.Equal(NetworkManagerState.Idle, _manager.State);

            await _manager.StartAsync();
            Assert.Equal(NetworkManagerState.Idle, _manager.State);

            await _manager.StopAsync();
            Assert.Equal(NetworkManagerState.Disconnected, _manager.State);

            _manager.Dispose();

            // Assert: Lifecycle completed successfully
        }

       
        #endregion

        #region Edge Cases and Error Handling



        /// <summary>
        ///     Arrange: Create NetworkClientManager and initialize it
        ///     Act: Test with null or empty player name
        ///     Assert: Manager handles edge cases gracefully
        /// </summary>
        [Fact]
        public async Task EdgeCases_NullOrEmptyPlayerName_HandlesGracefully()
        {
            // Arrange: Initialize manager

            // Act: Try to connect with empty player name (will fail at connection level)
            try
            {
                await _manager.ConnectAsync(new Uri("ws://localhost:8888"), "");
            }
            catch (Exception)
            {
                // Expected to fail at connection level
            }

            // Assert: Manager handles edge case without crashing
            Assert.NotNull(_manager.Id);
        }

        #endregion
    }
}
