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
    /// <summary>
    /// The network client manager remaining coverage tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class NetworkClientManagerRemainingCoverageTests : IDisposable
    {
        /// <summary>
        /// The manager
        /// </summary>
        internal readonly NetworkClientManager _manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkClientManagerRemainingCoverageTests"/> class
        /// </summary>
        public NetworkClientManagerRemainingCoverageTests()
        {
            _manager = new NetworkClientManager();
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            _manager?.Dispose();
        }

        /// <summary>
        /// Tests that initialize async should set state to idle
        /// </summary>
        [Fact]
        public async Task InitializeAsync_ShouldSetStateToIdle()
        {
            var config = new NetworkConfig();
            await _manager.InitializeAsync(config);

            Assert.Equal(NetworkManagerState.Idle, _manager.State);
        }

        /// <summary>
        /// Tests that initialize async should set config
        /// </summary>
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

        /// <summary>
        /// Tests that initialize async with null config should create default config
        /// </summary>
        [Fact]
        public async Task InitializeAsync_WithNullConfig_ShouldCreateDefaultConfig()
        {
            await _manager.InitializeAsync(null);

            Assert.NotNull(_manager.Config);
            Assert.Equal(32, _manager.Config.MaxPlayers);
            Assert.Equal(60, _manager.Config.TickRate);
            Assert.True(_manager.Config.ServerAuthoritative);
        }

        /// <summary>
        /// Tests that initialize async called twice should throw invalid operation exception
        /// </summary>
        [Fact]
        public async Task InitializeAsync_CalledTwice_ShouldThrowInvalidOperationException()
        {
            await _manager.InitializeAsync(new NetworkConfig());

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _manager.InitializeAsync(new NetworkConfig()));

            Assert.Equal("Already initialized", exception.Message);
        }

        /// <summary>
        /// Tests that start async when uninitialized should throw invalid operation exception
        /// </summary>
        [Fact]
        public void StartAsync_WhenUninitialized_ShouldThrowInvalidOperationException()
        {
            Assert.Equal(NetworkManagerState.Uninitialized, _manager.State);

            var exception = Assert.ThrowsAsync<InvalidOperationException>(() =>
                _manager.StartAsync(CancellationToken.None));

            Assert.Equal("Cannot start in current state", exception.Result.Message);
        }

        /// <summary>
        /// Tests that start async after initialize async should succeed
        /// </summary>
        [Fact]
        public async Task StartAsync_AfterInitializeAsync_ShouldSucceed()
        {
            await _manager.InitializeAsync(new NetworkConfig());

            await _manager.StartAsync(CancellationToken.None);

            Assert.Equal(NetworkManagerState.Idle, _manager.State);
        }

        /// <summary>
        /// Tests that stop async when uninitialized should not throw
        /// </summary>
        [Fact]
        public async Task StopAsync_WhenUninitialized_ShouldNotThrow()
        {
            Assert.Equal(NetworkManagerState.Uninitialized, _manager.State);

            await _manager.StopAsync(CancellationToken.None);
        }

        /// <summary>
        /// Tests that get connected players when not connected should return empty list
        /// </summary>
        [Fact]
        public void GetConnectedPlayers_WhenNotConnected_ShouldReturnEmptyList()
        {
            var players = _manager.GetConnectedPlayers();

            Assert.NotNull(players);
            Assert.Empty(players);
        }

        /// <summary>
        /// Tests that get player when not connected should return null
        /// </summary>
        [Fact]
        public void GetPlayer_WhenNotConnected_ShouldReturnNull()
        {
            var player = _manager.GetPlayer("any-id");

            Assert.Null(player);
        }

        /// <summary>
        /// Tests that send message async when not connected should throw invalid operation exception
        /// </summary>
        [Fact]
        public void SendMessageAsync_WhenNotConnected_ShouldThrowInvalidOperationException()
        {
            var message = new TestJsonMessage { Data = "test" };

            var exception = Assert.ThrowsAsync<InvalidOperationException>(() =>
                _manager.SendMessageAsync("target", "channel", message));

            Assert.Equal("Not connected to server", exception.Result.Message);
        }

        /// <summary>
        /// Tests that broadcast message async when not connected should throw invalid operation exception
        /// </summary>
        [Fact]
        public void BroadcastMessageAsync_WhenNotConnected_ShouldThrowInvalidOperationException()
        {
            var message = new TestJsonMessage { Data = "test" };

            var exception = Assert.ThrowsAsync<InvalidOperationException>(() =>
                _manager.BroadcastMessageAsync("channel", message));

            Assert.Equal("Not connected to server", exception.Result.Message);
        }

        /// <summary>
        /// Tests that dispose multiple calls should be idempotent
        /// </summary>
        [Fact]
        public void Dispose_MultipleCalls_ShouldBeIdempotent()
        {
            _manager.Dispose();
            _manager.Dispose();
            _manager.Dispose();
        }

        /// <summary>
        /// Tests that connect async when uninitialized should throw invalid operation exception
        /// </summary>
        [Fact]
        public void ConnectAsync_WhenUninitialized_ShouldThrowInvalidOperationException()
        {
            Assert.Equal(NetworkManagerState.Uninitialized, _manager.State);

            var exception = Assert.ThrowsAsync<InvalidOperationException>(() =>
                _manager.ConnectAsync(new Uri("ws://localhost"), "player"));

            Assert.Equal("Cannot connect in current state", exception.Result.Message);
        }

        /// <summary>
        /// Tests that disconnect async when uninitialized should return without throwing
        /// </summary>
        [Fact]
        public async Task DisconnectAsync_WhenUninitialized_ShouldReturnWithoutThrowing()
        {
            Assert.Equal(NetworkManagerState.Uninitialized, _manager.State);

            await _manager.DisconnectAsync(CancellationToken.None);
        }

        /// <summary>
        /// The test json message class
        /// </summary>
        /// <seealso cref="IJsonSerializable"/>
        private class TestJsonMessage : IJsonSerializable
        {
            /// <summary>
            /// Gets or sets the value of the data
            /// </summary>
            public string Data { get; set; }

            /// <summary>
            /// Gets the serializable properties
            /// </summary>
            /// <returns>An enumerable of string property name and string value</returns>
            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Data", Data);
            }
        }
    }
}
