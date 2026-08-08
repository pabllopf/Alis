using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Client;
using Alis.Extension.Network.Core;
using Xunit;

namespace Alis.Extension.Network.Test.Client
{
    /// <summary>
    /// The network client manager edge case tests class
    /// </summary>
    public class NetworkClientManagerEdgeCaseTests
    {
        /// <summary>
        /// Tests that constructor multiple instances have different ids
        /// </summary>
        [Fact]
        public void Constructor_MultipleInstances_HaveDifferentIds()
        {
            using NetworkClientManager mgr1 = new NetworkClientManager();
            using NetworkClientManager mgr2 = new NetworkClientManager();
            Assert.NotEqual(mgr1.Id, mgr2.Id);
        }

        /// <summary>
        /// Tests that constructor initial state is uninitialized
        /// </summary>
        [Fact]
        public void Constructor_InitialState_IsUninitialized()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            Assert.Equal(NetworkManagerState.Uninitialized, mgr.State);
        }

        /// <summary>
        /// Tests that constructor id is not empty
        /// </summary>
        [Fact]
        public void Constructor_Id_IsNotEmpty()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            Assert.False(string.IsNullOrEmpty(mgr.Id));
        }

        /// <summary>
        /// Tests that initialize async with cancellation token completes successfully
        /// </summary>
        [Fact]
        public async Task InitializeAsync_WithCancellationToken_CompletesSuccessfully()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            using CancellationTokenSource cts = new CancellationTokenSource();
            await mgr.InitializeAsync(new NetworkConfig(), cts.Token);
            Assert.Equal(NetworkManagerState.Idle, mgr.State);
        }

        /// <summary>
        /// Tests that start async after disconnect does not throw
        /// </summary>
        [Fact]
        public async Task StartAsync_AfterDisconnect_DoesNotThrow()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            await mgr.InitializeAsync(new NetworkConfig());
            await mgr.DisconnectAsync();
            Exception ex = await Record.ExceptionAsync(() => mgr.StartAsync());
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that disconnect async after initialize sets state to disconnected
        /// </summary>
        [Fact]
        public async Task DisconnectAsync_AfterInitialize_SetsStateToDisconnected()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            await mgr.InitializeAsync(new NetworkConfig());
            await mgr.DisconnectAsync();
            Assert.Equal(NetworkManagerState.Disconnected, mgr.State);
        }

        /// <summary>
        /// Tests that disconnect async when already disconnected does not throw
        /// </summary>
        [Fact]
        public async Task DisconnectAsync_WhenAlreadyDisconnected_DoesNotThrow()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            await mgr.InitializeAsync(new NetworkConfig());
            await mgr.DisconnectAsync();
            Exception ex = await Record.ExceptionAsync(() => mgr.DisconnectAsync());
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that disconnect async repeated calls are idempotent
        /// </summary>
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

        /// <summary>
        /// Tests that stop async after initialize delegates to disconnect
        /// </summary>
        [Fact]
        public async Task StopAsync_AfterInitialize_DelegatesToDisconnect()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            await mgr.InitializeAsync(new NetworkConfig());
            await mgr.StopAsync();
            Assert.Equal(NetworkManagerState.Disconnected, mgr.State);
        }

        /// <summary>
        /// Tests that stop async when uninitialized does not throw
        /// </summary>
        [Fact]
        public async Task StopAsync_WhenUninitialized_DoesNotThrow()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            Exception ex = await Record.ExceptionAsync(() => mgr.StopAsync());
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that register message handler overwrite existing does not throw
        /// </summary>
        [Fact]
        public void RegisterMessageHandler_OverwriteExisting_DoesNotThrow()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            mgr.RegisterMessageHandler("channel", async (t, d) => await Task.FromResult("first"));
            mgr.RegisterMessageHandler("channel", async (t, d) => await Task.FromResult("second"));
        }

        /// <summary>
        /// Tests that register message handler null handler does not throw
        /// </summary>
        [Fact]
        public void RegisterMessageHandler_NullHandler_DoesNotThrow()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            mgr.RegisterMessageHandler("channel", null);
        }

        /// <summary>
        /// Tests that unregister message handler non existent channel does not throw
        /// </summary>
        [Fact]
        public void UnregisterMessageHandler_NonExistentChannel_DoesNotThrow()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            mgr.UnregisterMessageHandler("non-existent");
        }

        /// <summary>
        /// Tests that get connected players with null session returns empty list
        /// </summary>
        [Fact]
        public void GetConnectedPlayers_WithNullSession_ReturnsEmptyList()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            IReadOnlyList<NetworkPlayer> players = mgr.GetConnectedPlayers();
            Assert.NotNull(players);
            Assert.Empty(players);
        }

        /// <summary>
        /// Tests that get player with null session returns null
        /// </summary>
        [Fact]
        public void GetPlayer_WithNullSession_ReturnsNull()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            Assert.Null(mgr.GetPlayer("any-id"));
        }

        /// <summary>
        /// Tests that get player with null id returns null
        /// </summary>
        [Fact]
        public void GetPlayer_WithNullId_ReturnsNull()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            Assert.Null(mgr.GetPlayer(null));
        }

        /// <summary>
        /// Tests that dispose after initialize idempotent
        /// </summary>
        [Fact]
        public void Dispose_AfterInitialize_Idempotent()
        {
            NetworkClientManager mgr = new NetworkClientManager();
            mgr.InitializeAsync(new NetworkConfig()).GetAwaiter().GetResult();
            mgr.Dispose();
            mgr.Dispose();
        }

        /// <summary>
        /// Tests that connect async with null uri when idle throws
        /// </summary>
        [Fact]
        public async Task ConnectAsync_WithNullUri_WhenIdle_Throws()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            await mgr.InitializeAsync(new NetworkConfig());
            Exception ex = await Record.ExceptionAsync(() =>
                mgr.ConnectAsync(null, "player"));
            Assert.NotNull(ex);
        }

        /// <summary>
        /// Tests that connect async when idle throws on connection failure
        /// </summary>
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

        /// <summary>
        /// Tests that connect async when idle sets state to error on failure
        /// </summary>
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
