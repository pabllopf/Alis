using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Core;
using Alis.Extension.Network.Server;
using Xunit;

namespace Alis.Extension.Network.Test.Server
{
    /// <summary>
    /// The network server manager edge case tests class
    /// </summary>
    public class NetworkServerManagerEdgeCaseTests
    {
        /// <summary>
        /// Tests that constructor id is not empty
        /// </summary>
        [Fact]
        public void Constructor_Id_IsNotEmpty()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            Assert.False(string.IsNullOrEmpty(mgr.Id));
        }

        /// <summary>
        /// Tests that constructor state is uninitialized
        /// </summary>
        [Fact]
        public void Constructor_State_IsUninitialized()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            Assert.Equal(NetworkManagerState.Uninitialized, mgr.State);
        }

        /// <summary>
        /// Tests that constructor properties are null
        /// </summary>
        [Fact]
        public void Constructor_Properties_AreNull()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            Assert.Null(mgr.CurrentSession);
            Assert.Null(mgr.LocalPlayer);
            Assert.Null(mgr.Config);
            Assert.Null(mgr.ListenUri);
        }

        /// <summary>
        /// Tests that initialize async with cancellation token completes
        /// </summary>
        [Fact]
        public async Task InitializeAsync_WithCancellationToken_Completes()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            using CancellationTokenSource cts = new CancellationTokenSource();
            await mgr.InitializeAsync(new NetworkConfig(), cts.Token);
            Assert.Equal(NetworkManagerState.Idle, mgr.State);
        }

        /// <summary>
        /// Tests that start async after disconnect completes
        /// </summary>
        [Fact]
        public async Task StartAsync_AfterDisconnect_Completes()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            await mgr.InitializeAsync(new NetworkConfig());
            await mgr.StopListeningAsync();
            await mgr.StartAsync();
        }

        /// <summary>
        /// Tests that stop async delegates to stop listening
        /// </summary>
        [Fact]
        public async Task StopAsync_DelegatesToStopListeningAsync()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            await mgr.InitializeAsync(new NetworkConfig());
            await mgr.StopAsync();
            Assert.Equal(NetworkManagerState.Disconnected, mgr.State);
        }

        /// <summary>
        /// Tests that stop listening async when uninitialized does not throw
        /// </summary>
        [Fact]
        public async Task StopListeningAsync_WhenUninitialized_DoesNotThrow()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            Exception ex = await Record.ExceptionAsync(() => mgr.StopListeningAsync());
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that stop listening async when disconnected does not throw
        /// </summary>
        [Fact]
        public async Task StopListeningAsync_WhenDisconnected_DoesNotThrow()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            await mgr.InitializeAsync(new NetworkConfig());
            await mgr.StopListeningAsync();
            Exception ex = await Record.ExceptionAsync(() => mgr.StopListeningAsync());
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that stop listening async repeated calls are idempotent
        /// </summary>
        [Fact]
        public async Task StopListeningAsync_RepeatedCalls_AreIdempotent()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            await mgr.InitializeAsync(new NetworkConfig());
            await mgr.StopListeningAsync();
            await mgr.StopListeningAsync();
            await mgr.StopListeningAsync();
            Assert.Equal(NetworkManagerState.Disconnected, mgr.State);
        }

        /// <summary>
        /// Tests that close session async non existent session does not throw
        /// </summary>
        [Fact]
        public async Task CloseSessionAsync_NonExistentSession_DoesNotThrow()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            await mgr.InitializeAsync(new NetworkConfig());
            Exception ex = await Record.ExceptionAsync(() =>
                mgr.CloseSessionAsync("non-existent-id"));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that kick player async non existent session does not throw
        /// </summary>
        [Fact]
        public async Task KickPlayerAsync_NonExistentSession_DoesNotThrow()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            await mgr.InitializeAsync(new NetworkConfig());
            Exception ex = await Record.ExceptionAsync(() =>
                mgr.KickPlayerAsync("player-id", "non-existent-session"));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that kick player async non existent player does not throw
        /// </summary>
        [Fact]
        public async Task KickPlayerAsync_NonExistentPlayer_DoesNotThrow()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            await mgr.InitializeAsync(new NetworkConfig());
            NetworkSession session = await mgr.CreateSessionAsync("Game", 4);
            Exception ex = await Record.ExceptionAsync(() =>
                mgr.KickPlayerAsync("non-existent-player", session.SessionId));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that register player in session without current session does not throw
        /// </summary>
        [Fact]
        public void RegisterPlayerInSession_WithoutCurrentSession_DoesNotThrow()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            mgr.RegisterPlayerInSession("p1", "Player1");
        }

        /// <summary>
        /// Tests that register player in session existing player does not duplicate
        /// </summary>
        [Fact]
        public async Task RegisterPlayerInSession_ExistingPlayer_DoesNotDuplicate()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            await mgr.InitializeAsync(new NetworkConfig());
            await mgr.CreateSessionAsync("Game", 4);
            mgr.RegisterPlayerInSession("p1", "Player1");
            mgr.RegisterPlayerInSession("p1", "Player1");
            mgr.RegisterPlayerInSession("p1", "Player1");
            Assert.Equal(2, mgr.CurrentSession.Players.Count);
        }

        /// <summary>
        /// Tests that get player no session returns null
        /// </summary>
        [Fact]
        public void GetPlayer_NoSession_ReturnsNull()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            Assert.Null(mgr.GetPlayer("any-id"));
        }

        /// <summary>
        /// Tests that get connected players no session returns empty list
        /// </summary>
        [Fact]
        public void GetConnectedPlayers_NoSession_ReturnsEmptyList()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            IReadOnlyList<NetworkPlayer> players = mgr.GetConnectedPlayers();
            Assert.NotNull(players);
            Assert.Empty(players);
        }

        /// <summary>
        /// Tests that get session non existent returns null
        /// </summary>
        [Fact]
        public void GetSession_NonExistent_ReturnsNull()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            Assert.Null(mgr.GetSession("non-existent"));
        }

        /// <summary>
        /// Tests that register message handler null handler does not throw
        /// </summary>
        [Fact]
        public void RegisterMessageHandler_NullHandler_DoesNotThrow()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            mgr.RegisterMessageHandler("channel", null);
        }

        /// <summary>
        /// Tests that register message handler overwrite existing does not throw
        /// </summary>
        [Fact]
        public void RegisterMessageHandler_OverwriteExisting_DoesNotThrow()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            mgr.RegisterMessageHandler("channel", async (t, d) => await Task.FromResult("first"));
            mgr.RegisterMessageHandler("channel", async (t, d) => await Task.FromResult("second"));
        }

        /// <summary>
        /// Tests that unregister message handler non existent does not throw
        /// </summary>
        [Fact]
        public void UnregisterMessageHandler_NonExistent_DoesNotThrow()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            mgr.UnregisterMessageHandler("non-existent");
        }

        /// <summary>
        /// Tests that listen async with invalid address sets state to error
        /// </summary>
        [Fact]
        public async Task ListenAsync_WithInvalidAddress_SetsStateToError()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            await mgr.InitializeAsync(new NetworkConfig());
            try
            {
                await mgr.ListenAsync(new Uri("ws://999.999.999.999:1234"));
            }
            catch
            {
            }
            Assert.Equal(NetworkManagerState.Error, mgr.State);
        }

        /// <summary>
        /// Tests that dispose after listen failure does not throw
        /// </summary>
        [Fact]
        public async Task Dispose_AfterListenFailure_DoesNotThrow()
        {
            NetworkServerManager mgr = new NetworkServerManager();
            await mgr.InitializeAsync(new NetworkConfig());
            try
            {
                await mgr.ListenAsync(new Uri("ws://999.999.999.999:1234"));
            }
            catch
            {
            }
            Exception ex = Record.Exception(() => mgr.Dispose());
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that dispose after initialize does not throw
        /// </summary>
        [Fact]
        public async Task Dispose_AfterInitialize_DoesNotThrow()
        {
            NetworkServerManager mgr = new NetworkServerManager();
            await mgr.InitializeAsync(new NetworkConfig());
            Exception ex = Record.Exception(() => mgr.Dispose());
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that dispose when already disposed does not throw
        /// </summary>
        [Fact]
        public void Dispose_WhenAlreadyDisposed_DoesNotThrow()
        {
            NetworkServerManager mgr = new NetworkServerManager();
            mgr.Dispose();
            Exception ex = Record.Exception(() => mgr.Dispose());
            Assert.Null(ex);
        }
    }
}
