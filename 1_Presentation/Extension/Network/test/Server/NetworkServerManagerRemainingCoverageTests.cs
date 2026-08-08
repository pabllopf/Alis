using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Aspect.Data.Json;
using Alis.Extension.Network.Core;
using Alis.Extension.Network.Server;
using Moq;
using Xunit;

namespace Alis.Extension.Network.Test.Server
{
    /// <summary>
    /// The network server manager remaining coverage tests class
    /// </summary>
    public class NetworkServerManagerRemainingCoverageTests
    {
        /// <summary>
        /// The test message class
        /// </summary>
        /// <seealso cref="IJsonSerializable"/>
        private class TestMessage : IJsonSerializable
        {
            /// <summary>
            /// Gets or sets the value of the text
            /// </summary>
            public string Text { get; set; }
            /// <summary>
            /// Gets the serializable properties
            /// </summary>
            /// <returns>An enumerable of string property name and string value</returns>
            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Text", Text);
            }
        }

        /// <summary>
        /// Tests that send message async target not in map does not throw
        /// </summary>
        [Fact]
        public async Task SendMessageAsync_TargetNotInMap_DoesNotThrow()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());
            await manager.SendMessageAsync("non-existent-player", "chat", new TestMessage { Text = "hello" });
        }

        /// <summary>
        /// Tests that send message async with transport and map calls send
        /// </summary>
        [Fact]
        public async Task SendMessageAsync_WithTransportAndMap_CallsSendAsync()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());

            Mock<INetworkTransport> mockTransport = new Mock<INetworkTransport>();
            mockTransport.Setup(t => t.SendAsync(It.IsAny<string>(), It.IsAny<NetworkMessageEnvelope>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            ConcurrentDictionary<string, string> map = new ConcurrentDictionary<string, string>();
            map["target-player"] = "target-client";

            SetPrivateField(manager, "_clientToSessionMap", map);
            SetPrivateField(manager, "_transport", mockTransport.Object);

            await manager.SendMessageAsync("target-player", "chat", new TestMessage { Text = "hello" });

            mockTransport.Verify(t => t.SendAsync("target-client", It.IsAny<NetworkMessageEnvelope>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        /// <summary>
        /// Tests that send message async local player null does not throw
        /// </summary>
        [Fact]
        public async Task SendMessageAsync_LocalPlayerNull_DoesNotThrow()
        {
            NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());
            SetPrivateField(manager, "_localPlayer", null);

            Exception ex = await Record.ExceptionAsync(() =>
                manager.SendMessageAsync("target-player", "chat", new TestMessage { Text = "hello" }));
            Assert.Null(ex);
            manager.Dispose();
        }

        /// <summary>
        /// Tests that broadcast message async with transport calls broadcast
        /// </summary>
        [Fact]
        public async Task BroadcastMessageAsync_WithTransport_CallsBroadcastAsync()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());

            Mock<INetworkTransport> mockTransport = new Mock<INetworkTransport>();
            mockTransport.Setup(t => t.BroadcastAsync(It.IsAny<NetworkMessageEnvelope>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            SetPrivateField(manager, "_transport", mockTransport.Object);

            await manager.BroadcastMessageAsync("chat", new TestMessage { Text = "broadcast" });

            mockTransport.Verify(t => t.BroadcastAsync(It.IsAny<NetworkMessageEnvelope>(), null, It.IsAny<CancellationToken>()), Times.Once);
        }

        /// <summary>
        /// Tests that broadcast message async local player null does not throw
        /// </summary>
        [Fact]
        public async Task BroadcastMessageAsync_LocalPlayerNull_DoesNotThrow()
        {
            NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());
            SetPrivateField(manager, "_localPlayer", null);

            Mock<INetworkTransport> mockTransport = new Mock<INetworkTransport>();
            mockTransport.Setup(t => t.BroadcastAsync(It.IsAny<NetworkMessageEnvelope>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            SetPrivateField(manager, "_transport", mockTransport.Object);

            Exception ex = await Record.ExceptionAsync(() =>
                manager.BroadcastMessageAsync("chat", new TestMessage { Text = "broadcast" }));
            Assert.Null(ex);
            manager.Dispose();
        }

        /// <summary>
        /// Tests that register player in session fires player joined event
        /// </summary>
        [Fact]
        public void RegisterPlayerInSession_FiresPlayerJoinedEvent()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            manager.InitializeAsync(new NetworkConfig()).Wait();
            manager.CreateSessionAsync("Game", 4).Wait();

            NetworkPlayer joinedPlayer = null;
            manager.PlayerJoined += (sender, args) => { joinedPlayer = args.Player; };

            manager.RegisterPlayerInSession("p1", "Player1");

            Assert.NotNull(joinedPlayer);
            Assert.Equal("p1", joinedPlayer.PlayerId);
            Assert.Equal("Player1", joinedPlayer.PlayerName);
        }

        /// <summary>
        /// Tests that register player in session no current session does not fire event
        /// </summary>
        [Fact]
        public void RegisterPlayerInSession_NoCurrentSession_DoesNotFireEvent()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            bool eventFired = false;
            manager.PlayerJoined += (sender, args) => { eventFired = true; };

            manager.RegisterPlayerInSession("p1", "Player1");

            Assert.False(eventFired);
        }

        /// <summary>
        /// Tests that kick player async fires player left event
        /// </summary>
        [Fact]
        public async Task KickPlayerAsync_FiresPlayerLeftEvent()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());
            await manager.CreateSessionAsync("Game", 4);
            manager.RegisterPlayerInSession("p1", "Player1");

            NetworkPlayer leftPlayer = null;
            manager.PlayerLeft += (sender, args) => { leftPlayer = args.Player; };

            await manager.KickPlayerAsync("p1", manager.CurrentSession.SessionId);

            Assert.NotNull(leftPlayer);
            Assert.Equal("p1", leftPlayer.PlayerId);
        }

        /// <summary>
        /// Tests that kick player async non existent session does not fire event
        /// </summary>
        [Fact]
        public async Task KickPlayerAsync_NonExistentSession_DoesNotFireEvent()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());
            bool eventFired = false;
            manager.PlayerLeft += (sender, args) => { eventFired = true; };

            await manager.KickPlayerAsync("p1", "non-existent-session");

            Assert.False(eventFired);
        }

        /// <summary>
        /// Tests that kick player async non existent player does not fire event
        /// </summary>
        [Fact]
        public async Task KickPlayerAsync_NonExistentPlayer_DoesNotFireEvent()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());
            NetworkSession session = await manager.CreateSessionAsync("Game", 4);

            bool eventFired = false;
            manager.PlayerLeft += (sender, args) => { eventFired = true; };

            await manager.KickPlayerAsync("non-existent-player", session.SessionId);

            Assert.False(eventFired);
        }

        /// <summary>
        /// Tests that get connected players with session returns players
        /// </summary>
        [Fact]
        public async Task GetConnectedPlayers_WithSession_ReturnsPlayers()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());
            await manager.CreateSessionAsync("Game", 4);
            manager.RegisterPlayerInSession("p1", "Player1");
            manager.RegisterPlayerInSession("p2", "Player2");

            IReadOnlyList<NetworkPlayer> players = manager.GetConnectedPlayers();

            Assert.Equal(3, players.Count);
            Assert.Contains(players, p => p.PlayerId == "p1");
            Assert.Contains(players, p => p.PlayerId == "p2");
        }

        /// <summary>
        /// Tests that get active sessions with multiple states returns only non closed
        /// </summary>
        [Fact]
        public async Task GetActiveSessions_WithMultipleStates_ReturnsOnlyNonClosed()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());
            NetworkSession session1 = await manager.CreateSessionAsync("Game1", 4);
            NetworkSession session2 = await manager.CreateSessionAsync("Game2", 8);
            await manager.CloseSessionAsync(session1.SessionId);

            IReadOnlyList<NetworkSession> active = manager.GetActiveSessions();

            Assert.Single(active);
            Assert.Contains(session2, active);
            Assert.DoesNotContain(session1, active);
        }

        /// <summary>
        /// Tests that close session async non existent session does not throw
        /// </summary>
        [Fact]
        public async Task CloseSessionAsync_NonExistentSession_DoesNotThrow()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());
            Exception ex = await Record.ExceptionAsync(() => manager.CloseSessionAsync("non-existent"));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that get player returns null when not in session
        /// </summary>
        [Fact]
        public async Task GetPlayer_ReturnsNull_WhenNotInSession()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());
            await manager.CreateSessionAsync("Game", 4);

            Assert.Null(manager.GetPlayer("non-existent-player"));
        }

        /// <summary>
        /// Tests that register player in session updates player count
        /// </summary>
        [Fact]
        public async Task RegisterPlayerInSession_UpdatesPlayerCount()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());
            await manager.CreateSessionAsync("Game", 4);

            manager.RegisterPlayerInSession("p1", "Player1");
            Assert.Equal(2, manager.CurrentSession.PlayerCount);

            manager.RegisterPlayerInSession("p2", "Player2");
            Assert.Equal(3, manager.CurrentSession.PlayerCount);
        }

        /// <summary>
        /// Tests that create session async session contains local player
        /// </summary>
        [Fact]
        public async Task CreateSessionAsync_SessionContainsLocalPlayer()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());
            NetworkSession session = await manager.CreateSessionAsync("Game", 4);

            Assert.Contains(session.Players, p => p.PlayerId == manager.LocalPlayer.PlayerId);
            Assert.Equal(1, session.PlayerCount);
        }

        /// <summary>
        /// Tests that stop listening async fires disconnected event
        /// </summary>
        [Fact]
        public async Task StopListeningAsync_FiresDisconnectedEvent()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());

            bool eventFired = false;
            manager.Disconnected += (sender, args) => { eventFired = true; };

            Mock<INetworkTransport> mockTransport = new Mock<INetworkTransport>();
            mockTransport.Setup(t => t.StopAsync(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

            CancellationTokenSource cts = new CancellationTokenSource();
            SetPrivateField(manager, "_transport", mockTransport.Object);
            SetPrivateField(manager, "_cancellationTokenSource", cts);

            await manager.StopListeningAsync();

            Assert.True(eventFired);
            Assert.Equal(NetworkManagerState.Disconnected, manager.State);
        }

        /// <summary>
        /// Tests that listen async transport fails sets error state
        /// </summary>
        [Fact]
        public async Task ListenAsync_TransportFails_SetsErrorState()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());

            bool errorFired = false;
            manager.Error += (sender, args) => { errorFired = true; };

            await Assert.ThrowsAnyAsync<Exception>(() =>
                manager.ListenAsync(new Uri("ws://invalid-host-that-cannot-be-resolved:8888")));

            Assert.True(errorFired);
            Assert.Equal(NetworkManagerState.Error, manager.State);
            Assert.NotNull(manager.ListenUri);
        }

        /// <summary>
        /// Tests that get player no current session returns null
        /// </summary>
        [Fact]
        public void GetPlayer_NoCurrentSession_ReturnsNull()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            Assert.Null(manager.GetPlayer("any-id"));
        }

        /// <summary>
        /// Tests that stop listening async exception fires error event
        /// </summary>
        [Fact]
        public async Task StopListeningAsync_Exception_FiresErrorEvent()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());

            bool errorFired = false;
            manager.Error += (sender, args) => { errorFired = true; };

            Mock<INetworkTransport> mockTransport = new Mock<INetworkTransport>();
            mockTransport.Setup(t => t.StopAsync(It.IsAny<CancellationToken>())).ThrowsAsync(new InvalidOperationException("stop error"));

            CancellationTokenSource cts = new CancellationTokenSource();
            SetPrivateField(manager, "_transport", mockTransport.Object);
            SetPrivateField(manager, "_cancellationTokenSource", cts);

            Exception ex = await Record.ExceptionAsync(() => manager.StopListeningAsync());
            Assert.Null(ex);
            Assert.True(errorFired);
        }

        /// <summary>
        /// Tests that initialize async cancellation requested still completes
        /// </summary>
        [Fact]
        public async Task InitializeAsync_CancellationRequested_StillCompletes()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            using CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();

            await manager.InitializeAsync(new NetworkConfig(), cts.Token);

            Assert.Equal(NetworkManagerState.Idle, manager.State);
        }

        /// <summary>
        /// Sets the private field using the specified obj
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <param name="fieldName">The field name</param>
        /// <param name="value">The value</param>
        private static void SetPrivateField(object obj, string fieldName, object value)
        {
            FieldInfo field = obj.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
            field.SetValue(obj, value);
        }
    }
}
