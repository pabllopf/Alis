using System;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Core;
using Alis.Extension.Network.Server;
using Xunit;

namespace Alis.Extension.Network.Test.Server
{
    public class NetworkServerManagerEdgeCaseTests
    {
        [Fact]
        public void Constructor_Id_IsNotEmpty()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            Assert.False(string.IsNullOrEmpty(mgr.Id));
        }

        [Fact]
        public void Constructor_State_IsUninitialized()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            Assert.Equal(NetworkManagerState.Uninitialized, mgr.State);
        }

        [Fact]
        public void Constructor_Properties_AreNull()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            Assert.Null(mgr.CurrentSession);
            Assert.Null(mgr.LocalPlayer);
            Assert.Null(mgr.Config);
            Assert.Null(mgr.ListenUri);
        }

        [Fact]
        public async Task InitializeAsync_WithCancellationToken_Completes()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            using CancellationTokenSource cts = new CancellationTokenSource();
            await mgr.InitializeAsync(new NetworkConfig(), cts.Token);
            Assert.Equal(NetworkManagerState.Idle, mgr.State);
        }

        [Fact]
        public async Task StartAsync_AfterDisconnect_Completes()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            await mgr.InitializeAsync(new NetworkConfig());
            await mgr.StopListeningAsync();
            await mgr.StartAsync();
        }

        [Fact]
        public async Task StopAsync_DelegatesToStopListeningAsync()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            await mgr.InitializeAsync(new NetworkConfig());
            await mgr.StopAsync();
            Assert.Equal(NetworkManagerState.Disconnected, mgr.State);
        }

        [Fact]
        public async Task StopListeningAsync_WhenUninitialized_DoesNotThrow()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            Exception ex = await Record.ExceptionAsync(() => mgr.StopListeningAsync());
            Assert.Null(ex);
        }

        [Fact]
        public async Task StopListeningAsync_WhenDisconnected_DoesNotThrow()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            await mgr.InitializeAsync(new NetworkConfig());
            await mgr.StopListeningAsync();
            Exception ex = await Record.ExceptionAsync(() => mgr.StopListeningAsync());
            Assert.Null(ex);
        }

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

        [Fact]
        public async Task CloseSessionAsync_NonExistentSession_DoesNotThrow()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            await mgr.InitializeAsync(new NetworkConfig());
            Exception ex = await Record.ExceptionAsync(() =>
                mgr.CloseSessionAsync("non-existent-id"));
            Assert.Null(ex);
        }

        [Fact]
        public async Task KickPlayerAsync_NonExistentSession_DoesNotThrow()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            await mgr.InitializeAsync(new NetworkConfig());
            Exception ex = await Record.ExceptionAsync(() =>
                mgr.KickPlayerAsync("player-id", "non-existent-session"));
            Assert.Null(ex);
        }

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

        [Fact]
        public void RegisterPlayerInSession_WithoutCurrentSession_DoesNotThrow()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            mgr.RegisterPlayerInSession("p1", "Player1");
        }

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

        [Fact]
        public void GetPlayer_NoSession_ReturnsNull()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            Assert.Null(mgr.GetPlayer("any-id"));
        }

        [Fact]
        public void GetConnectedPlayers_NoSession_ReturnsEmptyList()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            var players = mgr.GetConnectedPlayers();
            Assert.NotNull(players);
            Assert.Empty(players);
        }

        [Fact]
        public void GetSession_NonExistent_ReturnsNull()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            Assert.Null(mgr.GetSession("non-existent"));
        }

        [Fact]
        public void RegisterMessageHandler_NullHandler_DoesNotThrow()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            mgr.RegisterMessageHandler("channel", null);
        }

        [Fact]
        public void RegisterMessageHandler_OverwriteExisting_DoesNotThrow()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            mgr.RegisterMessageHandler("channel", async (t, d) => await Task.FromResult("first"));
            mgr.RegisterMessageHandler("channel", async (t, d) => await Task.FromResult("second"));
        }

        [Fact]
        public void UnregisterMessageHandler_NonExistent_DoesNotThrow()
        {
            using NetworkServerManager mgr = new NetworkServerManager();
            mgr.UnregisterMessageHandler("non-existent");
        }

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

        [Fact]
        public async Task Dispose_AfterInitialize_DoesNotThrow()
        {
            NetworkServerManager mgr = new NetworkServerManager();
            await mgr.InitializeAsync(new NetworkConfig());
            Exception ex = Record.Exception(() => mgr.Dispose());
            Assert.Null(ex);
        }

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
