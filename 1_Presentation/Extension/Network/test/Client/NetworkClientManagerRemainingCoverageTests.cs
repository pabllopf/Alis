using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Aspect.Data.Json;
using Alis.Extension.Network.Client;
using Alis.Extension.Network.Core;
using Xunit;

namespace Alis.Extension.Network.Test.Client
{
    public class NetworkClientManagerRemainingCoverageTests : IDisposable
    {
        private readonly NetworkClientManager _manager;

        public NetworkClientManagerRemainingCoverageTests()
        {
            _manager = new NetworkClientManager();
        }

        public void Dispose()
        {
            _manager?.Dispose();
        }

        [Fact]
        public async Task InitializeAsync_ShouldSetStateToIdle()
        {
            var config = new NetworkConfig();
            await _manager.InitializeAsync(config);

            Assert.Equal(NetworkManagerState.Idle, _manager.State);
        }

        [Fact]
        public async Task InitializeAsync_ShouldSetConfig()
        {
            var config = new NetworkConfig
            {
                MaxPlayers = 16,
                TickRate = 30,
                ServerAuthoritative = false
            };

            await _manager.InitializeAsync(config);

            Assert.NotNull(_manager.Config);
            Assert.Equal(16, _manager.Config.MaxPlayers);
            Assert.Equal(30, _manager.Config.TickRate);
            Assert.False(_manager.Config.ServerAuthoritative);
        }

        [Fact]
        public async Task InitializeAsync_WithNullConfig_ShouldCreateDefaultConfig()
        {
            await _manager.InitializeAsync(null);

            Assert.NotNull(_manager.Config);
            Assert.Equal(32, _manager.Config.MaxPlayers);
            Assert.Equal(60, _manager.Config.TickRate);
            Assert.True(_manager.Config.ServerAuthoritative);
        }

        [Fact]
        public async Task InitializeAsync_CalledTwice_ShouldThrowInvalidOperationException()
        {
            await _manager.InitializeAsync(new NetworkConfig());

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _manager.InitializeAsync(new NetworkConfig()));

            Assert.Equal("Already initialized", exception.Message);
        }

        [Fact]
        public void StartAsync_WhenUninitialized_ShouldThrowInvalidOperationException()
        {
            Assert.Equal(NetworkManagerState.Uninitialized, _manager.State);

            var exception = Assert.ThrowsAsync<InvalidOperationException>(() =>
                _manager.StartAsync(CancellationToken.None));

            Assert.Equal("Cannot start in current state", exception.Result.Message);
        }

        [Fact]
        public async Task StartAsync_AfterInitializeAsync_ShouldSucceed()
        {
            await _manager.InitializeAsync(new NetworkConfig());

            await _manager.StartAsync(CancellationToken.None);

            Assert.Equal(NetworkManagerState.Idle, _manager.State);
        }

        [Fact]
        public async Task StopAsync_WhenUninitialized_ShouldNotThrow()
        {
            Assert.Equal(NetworkManagerState.Uninitialized, _manager.State);

            await _manager.StopAsync(CancellationToken.None);
        }

        [Fact]
        public void GetConnectedPlayers_WhenNotConnected_ShouldReturnEmptyList()
        {
            var players = _manager.GetConnectedPlayers();

            Assert.NotNull(players);
            Assert.Empty(players);
        }

        [Fact]
        public void GetPlayer_WhenNotConnected_ShouldReturnNull()
        {
            var player = _manager.GetPlayer("any-id");

            Assert.Null(player);
        }

        [Fact]
        public void SendMessageAsync_WhenNotConnected_ShouldThrowInvalidOperationException()
        {
            var message = new TestJsonMessage { Data = "test" };

            var exception = Assert.ThrowsAsync<InvalidOperationException>(() =>
                _manager.SendMessageAsync("target", "channel", message));

            Assert.Equal("Not connected to server", exception.Result.Message);
        }

        [Fact]
        public void BroadcastMessageAsync_WhenNotConnected_ShouldThrowInvalidOperationException()
        {
            var message = new TestJsonMessage { Data = "test" };

            var exception = Assert.ThrowsAsync<InvalidOperationException>(() =>
                _manager.BroadcastMessageAsync("channel", message));

            Assert.Equal("Not connected to server", exception.Result.Message);
        }

        [Fact]
        public void Dispose_MultipleCalls_ShouldBeIdempotent()
        {
            _manager.Dispose();
            _manager.Dispose();
            _manager.Dispose();
        }

        [Fact]
        public void ConnectAsync_WhenUninitialized_ShouldThrowInvalidOperationException()
        {
            Assert.Equal(NetworkManagerState.Uninitialized, _manager.State);

            var exception = Assert.ThrowsAsync<InvalidOperationException>(() =>
                _manager.ConnectAsync(new Uri("ws://localhost"), "player"));

            Assert.Equal("Cannot connect in current state", exception.Result.Message);
        }

        [Fact]
        public async Task DisconnectAsync_WhenUninitialized_ShouldReturnWithoutThrowing()
        {
            Assert.Equal(NetworkManagerState.Uninitialized, _manager.State);

            await _manager.DisconnectAsync(CancellationToken.None);
        }

        private class TestJsonMessage : IJsonSerializable
        {
            public string Data { get; set; }

            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Data", Data);
            }
        }
    }
}
