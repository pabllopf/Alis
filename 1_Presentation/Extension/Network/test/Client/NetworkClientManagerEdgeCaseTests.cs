using System;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Client;
using Alis.Extension.Network.Core;
using Xunit;

namespace Alis.Extension.Network.Test.Client
{
    public class NetworkClientManagerEdgeCaseTests
    {
        [Fact]
        public void Constructor_MultipleInstances_HaveDifferentIds()
        {
            using NetworkClientManager mgr1 = new NetworkClientManager();
            using NetworkClientManager mgr2 = new NetworkClientManager();
            Assert.NotEqual(mgr1.Id, mgr2.Id);
        }

        [Fact]
        public void Constructor_InitialState_IsUninitialized()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            Assert.Equal(NetworkManagerState.Uninitialized, mgr.State);
        }

        [Fact]
        public void Constructor_Id_IsNotEmpty()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            Assert.False(string.IsNullOrEmpty(mgr.Id));
        }

        [Fact]
        public async Task InitializeAsync_WithCancellationToken_CompletesSuccessfully()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            using CancellationTokenSource cts = new CancellationTokenSource();
            await mgr.InitializeAsync(new NetworkConfig(), cts.Token);
            Assert.Equal(NetworkManagerState.Idle, mgr.State);
        }

        [Fact]
        public async Task StartAsync_AfterDisconnect_DoesNotThrow()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            await mgr.InitializeAsync(new NetworkConfig());
            await mgr.DisconnectAsync();
            Exception ex = await Record.ExceptionAsync(() => mgr.StartAsync());
            Assert.Null(ex);
        }

        [Fact]
        public async Task DisconnectAsync_AfterInitialize_SetsStateToDisconnected()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            await mgr.InitializeAsync(new NetworkConfig());
            await mgr.DisconnectAsync();
            Assert.Equal(NetworkManagerState.Disconnected, mgr.State);
        }

        [Fact]
        public async Task DisconnectAsync_WhenAlreadyDisconnected_DoesNotThrow()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            await mgr.InitializeAsync(new NetworkConfig());
            await mgr.DisconnectAsync();
            Exception ex = await Record.ExceptionAsync(() => mgr.DisconnectAsync());
            Assert.Null(ex);
        }

        [Fact]
        public async Task DisconnectAsync_RepeatedCalls_AreIdempotent()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            await mgr.InitializeAsync(new NetworkConfig());
            await mgr.DisconnectAsync();
            await mgr.DisconnectAsync();
            await mgr.DisconnectAsync();
            Assert.Equal(NetworkManagerState.Disconnected, mgr.State);
        }

        [Fact]
        public async Task StopAsync_AfterInitialize_DelegatesToDisconnect()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            await mgr.InitializeAsync(new NetworkConfig());
            await mgr.StopAsync();
            Assert.Equal(NetworkManagerState.Disconnected, mgr.State);
        }

        [Fact]
        public async Task StopAsync_WhenUninitialized_DoesNotThrow()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            Exception ex = await Record.ExceptionAsync(() => mgr.StopAsync());
            Assert.Null(ex);
        }

        [Fact]
        public void RegisterMessageHandler_OverwriteExisting_DoesNotThrow()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            mgr.RegisterMessageHandler("channel", async (t, d) => await Task.FromResult("first"));
            mgr.RegisterMessageHandler("channel", async (t, d) => await Task.FromResult("second"));
        }

        [Fact]
        public void RegisterMessageHandler_NullHandler_DoesNotThrow()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            mgr.RegisterMessageHandler("channel", null);
        }

        [Fact]
        public void UnregisterMessageHandler_NonExistentChannel_DoesNotThrow()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            mgr.UnregisterMessageHandler("non-existent");
        }

        [Fact]
        public void GetConnectedPlayers_WithNullSession_ReturnsEmptyList()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            var players = mgr.GetConnectedPlayers();
            Assert.NotNull(players);
            Assert.Empty(players);
        }

        [Fact]
        public void GetPlayer_WithNullSession_ReturnsNull()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            Assert.Null(mgr.GetPlayer("any-id"));
        }

        [Fact]
        public void GetPlayer_WithNullId_ReturnsNull()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            Assert.Null(mgr.GetPlayer(null));
        }

        [Fact]
        public void Dispose_AfterInitialize_Idempotent()
        {
            NetworkClientManager mgr = new NetworkClientManager();
            mgr.InitializeAsync(new NetworkConfig()).GetAwaiter().GetResult();
            mgr.Dispose();
            mgr.Dispose();
        }

        [Fact]
        public async Task ConnectAsync_WithNullUri_WhenIdle_Throws()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            await mgr.InitializeAsync(new NetworkConfig());
            Exception ex = await Record.ExceptionAsync(() =>
                mgr.ConnectAsync(null, "player"));
            Assert.NotNull(ex);
        }

        [Fact]
        public async Task ConnectAsync_WhenIdle_ThrowsOnConnectionFailure()
        {
            NetworkClientManager mgr = new NetworkClientManager();
            try
            {
                await mgr.InitializeAsync(new NetworkConfig());
                Exception ex = await Record.ExceptionAsync(() =>
                    mgr.ConnectAsync(new Uri("ws://127.0.0.1:1"), "player"));
                Assert.NotNull(ex);
            }
            finally
            {
                mgr.Dispose();
            }
        }

        [Fact]
        public async Task ConnectAsync_WhenIdle_SetsStateToErrorOnFailure()
        {
            NetworkClientManager mgr = new NetworkClientManager();
            try
            {
                await mgr.InitializeAsync(new NetworkConfig());
                try
                {
                    await mgr.ConnectAsync(new Uri("ws://127.0.0.1:1"), "player");
                }
                catch
                {
                }
                Assert.Equal(NetworkManagerState.Error, mgr.State);
            }
            finally
            {
                mgr.Dispose();
            }
        }
    }
}
