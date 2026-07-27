using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Aspect.Data.Json;
using Alis.Extension.Network.Client;
using Alis.Extension.Network.Core;
using Moq;
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
        /// Tests that error event fires on connection failure
        /// </summary>
        [Fact]
        public async Task ErrorEvent_FiresOnConnectionFailure()
        {
            NetworkErrorEventArgs capturedArgs = null;
            _manager.Error += (sender, args) => capturedArgs = args;
            await _manager.InitializeAsync(new NetworkConfig());
            try
            {
                await _manager.ConnectAsync(new Uri("ws://127.0.0.1:1"), "player");
            }
            catch
            {
            }
            Assert.NotNull(capturedArgs);
            Assert.Contains("connect", capturedArgs.Message, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Tests that start async when connected should throw invalid operation exception
        /// </summary>
        [Fact]
        public async Task StartAsync_WhenConnected_ShouldThrowInvalidOperationException()
        {
            await _manager.InitializeAsync(new NetworkConfig());
            SetPrivateField(_manager, "_state", NetworkManagerState.Connected);
            InvalidOperationException ex = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _manager.StartAsync());
            Assert.Equal("Cannot start in current state", ex.Message);
        }

        /// <summary>
        /// Tests that start async when error should throw invalid operation exception
        /// </summary>
        [Fact]
        public async Task StartAsync_WhenError_ShouldThrowInvalidOperationException()
        {
            await _manager.InitializeAsync(new NetworkConfig());
            SetPrivateField(_manager, "_state", NetworkManagerState.Error);
            InvalidOperationException ex = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _manager.StartAsync());
            Assert.Equal("Cannot start in current state", ex.Message);
        }

        /// <summary>
        /// Tests that connect async after initialize sets state to connecting then error on failure
        /// </summary>
        [Fact]
        public async Task ConnectAsync_AfterInitialize_TransitionsThroughConnectingToError()
        {
            await _manager.InitializeAsync(new NetworkConfig());
            try
            {
                await _manager.ConnectAsync(new Uri("ws://127.0.0.1:1"), "player");
            }
            catch
            {
            }
            Assert.Equal(NetworkManagerState.Error, _manager.State);
        }

        /// <summary>
        /// Tests that disconnect async with active connection cleans up socket
        /// </summary>
        [Fact]
        public async Task DisconnectAsync_WithActiveConnection_CleansUpSocket()
        {
            Mock<WebSocket> mockSocket = new Mock<WebSocket>();
            mockSocket.Setup(s => s.State).Returns(WebSocketState.Open);
            mockSocket.Setup(s => s.CloseAsync(It.IsAny<WebSocketCloseStatus>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            mockSocket.Setup(s => s.Dispose());

            await _manager.InitializeAsync(new NetworkConfig());
            SetPrivateField(_manager, "_serverSocket", mockSocket.Object);
            SetPrivateField(_manager, "_cancellationTokenSource", new CancellationTokenSource());
            SetPrivateField(_manager, "_localPlayer", new NetworkPlayer { PlayerId = "p1", PlayerName = "Test" });
            SetPrivateField(_manager, "_state", NetworkManagerState.Connected);

            await _manager.DisconnectAsync();

            Assert.Equal(NetworkManagerState.Disconnected, _manager.State);
            Assert.Null(GetPrivateField(_manager, "_localPlayer"));
            Assert.Null(GetPrivateField(_manager, "_currentSession"));
            Assert.Null(GetPrivateField(_manager, "_serverSocket"));
            mockSocket.Verify(s => s.CloseAsync(WebSocketCloseStatus.NormalClosure, null, It.IsAny<CancellationToken>()), Times.Once);
            mockSocket.Verify(s => s.Dispose(), Times.AtLeastOnce);
        }

        /// <summary>
        /// Tests that disconnect async with active connection fires disconnected event
        /// </summary>
        [Fact]
        public async Task DisconnectAsync_WithActiveConnection_FiresDisconnectedEvent()
        {
            Mock<WebSocket> mockSocket = new Mock<WebSocket>();
            mockSocket.Setup(s => s.State).Returns(WebSocketState.Open);
            mockSocket.Setup(s => s.CloseAsync(It.IsAny<WebSocketCloseStatus>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            mockSocket.Setup(s => s.Dispose());

            await _manager.InitializeAsync(new NetworkConfig());
            SetPrivateField(_manager, "_serverSocket", mockSocket.Object);
            SetPrivateField(_manager, "_cancellationTokenSource", new CancellationTokenSource());
            SetPrivateField(_manager, "_localPlayer", new NetworkPlayer { PlayerId = "p1", PlayerName = "Test" });
            SetPrivateField(_manager, "_state", NetworkManagerState.Connected);

            bool disconnectedFired = false;
            _manager.Disconnected += (sender, args) => disconnectedFired = true;

            await _manager.DisconnectAsync();

            Assert.True(disconnectedFired);
        }

        /// <summary>
        /// Tests that disconnect async with active connection catches exception during close
        /// </summary>
        [Fact]
        public async Task DisconnectAsync_WithActiveConnection_ExceptionDuringClose()
        {
            Mock<WebSocket> mockSocket = new Mock<WebSocket>();
            mockSocket.Setup(s => s.State).Returns(WebSocketState.Open);
            mockSocket.Setup(s => s.CloseAsync(It.IsAny<WebSocketCloseStatus>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new WebSocketException("Test error"));
            mockSocket.Setup(s => s.Dispose());

            await _manager.InitializeAsync(new NetworkConfig());
            SetPrivateField(_manager, "_serverSocket", mockSocket.Object);
            SetPrivateField(_manager, "_cancellationTokenSource", new CancellationTokenSource());
            SetPrivateField(_manager, "_localPlayer", new NetworkPlayer { PlayerId = "p1", PlayerName = "Test" });
            SetPrivateField(_manager, "_state", NetworkManagerState.Connected);

            NetworkErrorEventArgs capturedError = null;
            _manager.Error += (sender, args) => capturedError = args;

            await _manager.DisconnectAsync();

            Assert.NotNull(capturedError);
            Assert.Contains("disconnect", capturedError.Message, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Tests that send message async with active connection sends data
        /// </summary>
        [Fact]
        public async Task SendMessageAsync_WithActiveConnection_SendsData()
        {
            Mock<WebSocket> mockSocket = new Mock<WebSocket>();
            mockSocket.Setup(s => s.State).Returns(WebSocketState.Open);
            mockSocket.Setup(s => s.SendAsync(It.IsAny<ArraySegment<byte>>(), WebSocketMessageType.Text, true, It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            await _manager.InitializeAsync(new NetworkConfig());
            SetPrivateField(_manager, "_serverSocket", mockSocket.Object);
            SetPrivateField(_manager, "_localPlayer", new NetworkPlayer { PlayerId = "p1", PlayerName = "Test" });

            TestJsonMessage message = new TestJsonMessage { Data = "hello" };
            await _manager.SendMessageAsync("target-id", "test.channel", message);

            mockSocket.Verify(s => s.SendAsync(It.IsAny<ArraySegment<byte>>(), WebSocketMessageType.Text, true, It.IsAny<CancellationToken>()), Times.Once);
        }

        /// <summary>
        /// Tests that send message async with null local player sends data
        /// </summary>
        [Fact]
        public async Task SendMessageAsync_WithNullLocalPlayer_SendsData()
        {
            Mock<WebSocket> mockSocket = new Mock<WebSocket>();
            mockSocket.Setup(s => s.State).Returns(WebSocketState.Open);
            mockSocket.Setup(s => s.SendAsync(It.IsAny<ArraySegment<byte>>(), WebSocketMessageType.Text, true, It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            await _manager.InitializeAsync(new NetworkConfig());
            SetPrivateField(_manager, "_serverSocket", mockSocket.Object);

            TestJsonMessage message = new TestJsonMessage { Data = "hello" };
            await _manager.SendMessageAsync("target-id", "test.channel", message);

            mockSocket.Verify(s => s.SendAsync(It.IsAny<ArraySegment<byte>>(), WebSocketMessageType.Text, true, It.IsAny<CancellationToken>()), Times.Once);
        }

        /// <summary>
        /// Tests that broadcast message async with active connection sends data
        /// </summary>
        [Fact]
        public async Task BroadcastMessageAsync_WithActiveConnection_SendsData()
        {
            Mock<WebSocket> mockSocket = new Mock<WebSocket>();
            mockSocket.Setup(s => s.State).Returns(WebSocketState.Open);
            mockSocket.Setup(s => s.SendAsync(It.IsAny<ArraySegment<byte>>(), WebSocketMessageType.Text, true, It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            await _manager.InitializeAsync(new NetworkConfig());
            SetPrivateField(_manager, "_serverSocket", mockSocket.Object);
            SetPrivateField(_manager, "_localPlayer", new NetworkPlayer { PlayerId = "p1", PlayerName = "Test" });

            TestJsonMessage message = new TestJsonMessage { Data = "broadcast" };
            await _manager.BroadcastMessageAsync("test.channel", message);

            mockSocket.Verify(s => s.SendAsync(It.IsAny<ArraySegment<byte>>(), WebSocketMessageType.Text, true, It.IsAny<CancellationToken>()), Times.Once);
        }

        /// <summary>
        /// Tests that broadcast message async with except player id sends data
        /// </summary>
        [Fact]
        public async Task BroadcastMessageAsync_WithExceptPlayerId_SendsData()
        {
            Mock<WebSocket> mockSocket = new Mock<WebSocket>();
            mockSocket.Setup(s => s.State).Returns(WebSocketState.Open);
            mockSocket.Setup(s => s.SendAsync(It.IsAny<ArraySegment<byte>>(), WebSocketMessageType.Text, true, It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            await _manager.InitializeAsync(new NetworkConfig());
            SetPrivateField(_manager, "_serverSocket", mockSocket.Object);
            SetPrivateField(_manager, "_localPlayer", new NetworkPlayer { PlayerId = "p1", PlayerName = "Test" });

            TestJsonMessage message = new TestJsonMessage { Data = "broadcast" };
            await _manager.BroadcastMessageAsync("test.channel", message, true, "except-id");

            mockSocket.Verify(s => s.SendAsync(It.IsAny<ArraySegment<byte>>(), WebSocketMessageType.Text, true, It.IsAny<CancellationToken>()), Times.Once);
        }

        /// <summary>
        /// Tests that dispose with active connection cleans up resources
        /// </summary>
        [Fact]
        public void Dispose_WithActiveConnection_CleansUpResources()
        {
            Mock<WebSocket> mockSocket = new Mock<WebSocket>();
            mockSocket.Setup(s => s.State).Returns(WebSocketState.Open);
            mockSocket.Setup(s => s.CloseAsync(It.IsAny<WebSocketCloseStatus>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            mockSocket.Setup(s => s.Dispose());

            using NetworkClientManager mgr = new NetworkClientManager();
            mgr.InitializeAsync(new NetworkConfig()).GetAwaiter().GetResult();
            SetPrivateField(mgr, "_serverSocket", mockSocket.Object);
            SetPrivateField(mgr, "_cancellationTokenSource", new CancellationTokenSource());
            SetPrivateField(mgr, "_localPlayer", new NetworkPlayer { PlayerId = "p1", PlayerName = "Test" });
            SetPrivateField(mgr, "_state", NetworkManagerState.Connected);

            mgr.Dispose();

            mockSocket.Verify(s => s.CloseAsync(WebSocketCloseStatus.NormalClosure, null, It.IsAny<CancellationToken>()), Times.AtLeastOnce);
            mockSocket.Verify(s => s.Dispose(), Times.AtLeastOnce);
        }

        /// <summary>
        /// Tests that get connected players with session returns players
        /// </summary>
        [Fact]
        public void GetConnectedPlayers_WithSession_ReturnsPlayers()
        {
            NetworkPlayer player = new NetworkPlayer { PlayerId = "p1", PlayerName = "Test" };
            NetworkSession session = new NetworkSession
            {
                SessionId = "sess-1",
                Players = new List<NetworkPlayer> { player }
            };
            SetPrivateField(_manager, "_currentSession", session);

            IReadOnlyList<NetworkPlayer> players = _manager.GetConnectedPlayers();

            Assert.Single(players);
            Assert.Equal("p1", players[0].PlayerId);
        }

        /// <summary>
        /// Tests that get player with session returns player by id
        /// </summary>
        [Fact]
        public void GetPlayer_WithSession_ReturnsPlayerById()
        {
            NetworkPlayer player1 = new NetworkPlayer { PlayerId = "p1", PlayerName = "Alice" };
            NetworkPlayer player2 = new NetworkPlayer { PlayerId = "p2", PlayerName = "Bob" };
            NetworkSession session = new NetworkSession
            {
                SessionId = "sess-1",
                Players = new List<NetworkPlayer> { player1, player2 }
            };
            SetPrivateField(_manager, "_currentSession", session);

            NetworkPlayer result = _manager.GetPlayer("p2");

            Assert.NotNull(result);
            Assert.Equal("Bob", result.PlayerName);
        }

        /// <summary>
        /// Tests that get player with session returns null for unknown id
        /// </summary>
        [Fact]
        public void GetPlayer_WithSession_ReturnsNullForUnknownId()
        {
            NetworkPlayer player = new NetworkPlayer { PlayerId = "p1", PlayerName = "Test" };
            NetworkSession session = new NetworkSession
            {
                SessionId = "sess-1",
                Players = new List<NetworkPlayer> { player }
            };
            SetPrivateField(_manager, "_currentSession", session);

            NetworkPlayer result = _manager.GetPlayer("unknown");

            Assert.Null(result);
        }

        /// <summary>
        /// Tests that stop async delegates to disconnect and cleans up
        /// </summary>
        [Fact]
        public async Task StopAsync_AfterConnect_DelegatesToDisconnect()
        {
            Mock<WebSocket> mockSocket = new Mock<WebSocket>();
            mockSocket.Setup(s => s.State).Returns(WebSocketState.Open);
            mockSocket.Setup(s => s.CloseAsync(It.IsAny<WebSocketCloseStatus>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            mockSocket.Setup(s => s.Dispose());

            await _manager.InitializeAsync(new NetworkConfig());
            SetPrivateField(_manager, "_serverSocket", mockSocket.Object);
            SetPrivateField(_manager, "_cancellationTokenSource", new CancellationTokenSource());
            SetPrivateField(_manager, "_localPlayer", new NetworkPlayer { PlayerId = "p1", PlayerName = "Test" });
            SetPrivateField(_manager, "_state", NetworkManagerState.Connected);

            await _manager.StopAsync();

            Assert.Equal(NetworkManagerState.Disconnected, _manager.State);
            mockSocket.Verify(s => s.CloseAsync(WebSocketCloseStatus.NormalClosure, null, It.IsAny<CancellationToken>()), Times.Once);
        }

        /// <summary>
        /// Tests that register message handler stores handler in dictionary
        /// </summary>
        [Fact]
        public void RegisterMessageHandler_StoresHandlerInDictionary()
        {
            bool handlerCalled = false;
            Func<string, string, Task> handler = async (sender, payload) =>
            {
                handlerCalled = true;
                await Task.CompletedTask;
            };

            _manager.RegisterMessageHandler("my.channel", handler);

            ConcurrentDictionary<string, Func<string, string, Task>> handlers =
                (ConcurrentDictionary<string, Func<string, string, Task>>)GetPrivateField(_manager, "_messageHandlers");
            Assert.True(handlers.ContainsKey("my.channel"));
        }

        /// <summary>
        /// Tests that unregister message handler removes handler from dictionary
        /// </summary>
        [Fact]
        public void UnregisterMessageHandler_RemovesHandlerFromDictionary()
        {
            Func<string, string, Task> handler = async (sender, payload) => await Task.CompletedTask;
            _manager.RegisterMessageHandler("my.channel", handler);

            _manager.UnregisterMessageHandler("my.channel");

            ConcurrentDictionary<string, Func<string, string, Task>> handlers =
                (ConcurrentDictionary<string, Func<string, string, Task>>)GetPrivateField(_manager, "_messageHandlers");
            Assert.False(handlers.ContainsKey("my.channel"));
        }

        /// <summary>
        /// Sets private field value using reflection
        /// </summary>
        internal static void SetPrivateField(object obj, string fieldName, object value)
        {
            FieldInfo field = obj.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            if (field == null)
            {
                throw new InvalidOperationException($"Field '{fieldName}' not found on type '{obj.GetType().Name}'");
            }
            field.SetValue(obj, value);
        }

        /// <summary>
        /// Gets private field value using reflection
        /// </summary>
        internal static object GetPrivateField(object obj, string fieldName)
        {
            FieldInfo field = obj.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            if (field == null)
            {
                throw new InvalidOperationException($"Field '{fieldName}' not found on type '{obj.GetType().Name}'");
            }
            return field.GetValue(obj);
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
