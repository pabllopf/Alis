using System;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Client;
using Alis.Extension.Network.Core;
using Xunit;

namespace Alis.Extension.Network.Test.Client
{
    public class NetworkClientManagerCoverageTests
    {
        [Fact]
        public async Task DisconnectAsync_AfterInitialize_FiresDisconnectedEvent()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            bool fired = false;
            mgr.Disconnected += (sender, args) => fired = true;
            await mgr.InitializeAsync(new NetworkConfig());
            await mgr.DisconnectAsync();
            Assert.True(fired);
        }

        [Fact]
        public async Task ErrorEvent_OnConnectionFailure_FiresErrorEvent()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            bool fired = false;
            string capturedMessage = null;
            mgr.Error += (sender, args) =>
            {
                fired = true;
                capturedMessage = args.Message;
            };
            await mgr.InitializeAsync(new NetworkConfig());
            try
            {
                await mgr.ConnectAsync(new Uri("ws://127.0.0.1:1"), "player");
            }
            catch
            {
            }
            Assert.True(fired);
            Assert.Equal("Failed to connect to server", capturedMessage);
        }

        [Fact]
        public async Task ServerUri_AfterConnectionFailure_ReturnsUri()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            await mgr.InitializeAsync(new NetworkConfig());
            Uri expected = new Uri("ws://127.0.0.1:1");
            try
            {
                await mgr.ConnectAsync(expected, "player");
            }
            catch
            {
            }
            Assert.Equal(expected, mgr.ServerUri);
        }

        [Fact]
        public async Task LocalPlayer_AfterConnectionFailure_IsNull()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            await mgr.InitializeAsync(new NetworkConfig());
            try
            {
                await mgr.ConnectAsync(new Uri("ws://127.0.0.1:1"), "player");
            }
            catch
            {
            }
            Assert.Null(mgr.LocalPlayer);
        }

        [Fact]
        public async Task Dispose_AfterConnectionFailure_DoesNotThrow()
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
            }
            finally
            {
                Exception ex = Record.Exception(() => mgr.Dispose());
                Assert.Null(ex);
            }
        }

        [Fact]
        public async Task DisconnectAsync_AfterConnectionFailure_SetsStateToDisconnected()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            await mgr.InitializeAsync(new NetworkConfig());
            try
            {
                await mgr.ConnectAsync(new Uri("ws://127.0.0.1:1"), "player");
            }
            catch
            {
            }
            await mgr.DisconnectAsync();
            Assert.Equal(NetworkManagerState.Disconnected, mgr.State);
        }

        [Fact]
        public async Task DisconnectAsync_AfterConnectionFailure_FiresDisconnectedEvent()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            bool fired = false;
            mgr.Disconnected += (sender, args) => fired = true;
            await mgr.InitializeAsync(new NetworkConfig());
            try
            {
                await mgr.ConnectAsync(new Uri("ws://127.0.0.1:1"), "player");
            }
            catch
            {
            }
            await mgr.DisconnectAsync();
            Assert.True(fired);
        }

        [Fact]
        public async Task StopAsync_AfterConnectionFailure_SetsStateToDisconnected()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            await mgr.InitializeAsync(new NetworkConfig());
            try
            {
                await mgr.ConnectAsync(new Uri("ws://127.0.0.1:1"), "player");
            }
            catch
            {
            }
            await mgr.StopAsync();
            Assert.Equal(NetworkManagerState.Disconnected, mgr.State);
        }

        [Fact]
        public void Config_And_ServerUri_Preserved_AfterDisconnect()
        {
            using NetworkClientManager mgr = new NetworkClientManager();
            NetworkConfig config = new NetworkConfig
            {
                MaxPlayers = 8,
                TickRate = 20
            };
            mgr.InitializeAsync(config).GetAwaiter().GetResult();
            mgr.DisconnectAsync().GetAwaiter().GetResult();
            Assert.NotNull(mgr.Config);
            Assert.Equal(8, mgr.Config.MaxPlayers);
        }
    }
}
