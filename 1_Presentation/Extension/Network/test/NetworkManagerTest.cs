

using System.Threading.Tasks;
using Alis.Extension.Network.Client;
using Alis.Extension.Network.Core;
using Alis.Extension.Network.Server;
using Xunit;

namespace Alis.Extension.Network.Test
{
    /// <summary>
    ///     Network manager tests
    /// </summary>
    public class NetworkManagerTest
    {
        /// <summary>
        ///     Tests that server manager initializes
        /// </summary>
        [Fact]
        public async Task ServerManager_Initializes()
        {
            using (NetworkServerManager manager = new NetworkServerManager())
            {
                NetworkConfig config = new NetworkConfig();
                await manager.InitializeAsync(config);

                Assert.Equal(NetworkManagerState.Idle, manager.State);
                Assert.NotNull(manager.Config);
                Assert.NotNull(manager.LocalPlayer);
            }
        }

        /// <summary>
        ///     Tests that client manager initializes
        /// </summary>
        [Fact]
        public async Task ClientManager_Initializes()
        {
            using (NetworkClientManager manager = new NetworkClientManager())
            {
                NetworkConfig config = new NetworkConfig();
                await manager.InitializeAsync(config);

                Assert.Equal(NetworkManagerState.Idle, manager.State);
                Assert.NotNull(manager.Config);
            }
        }

        /// <summary>
        ///     Tests that server manager creates session
        /// </summary>
        [Fact]
        public async Task ServerManager_CreatesSession()
        {
            using (NetworkServerManager manager = new NetworkServerManager())
            {
                NetworkConfig config = new NetworkConfig {MaxPlayers = 8};
                await manager.InitializeAsync(config);

                NetworkSession session = await manager.CreateSessionAsync("Test Session", 8);

                Assert.NotNull(session);
                Assert.Equal("Test Session", session.SessionName);
                Assert.Equal(8, session.MaxPlayers);
                Assert.Equal(SessionState.Waiting, session.State);
            }
        }

        /// <summary>
        ///     Tests that network config has correct defaults
        /// </summary>
        [Fact]
        public void NetworkConfig_HasDefaults()
        {
            NetworkConfig config = new NetworkConfig();

            Assert.Equal(32, config.MaxPlayers);
            Assert.Equal(60, config.TickRate);
            Assert.True(config.ServerAuthoritative);
        }

        /// <summary>
        ///     Tests that message envelope serializes
        /// </summary>
        [Fact]
        public void MessageEnvelope_Serializes()
        {
            NetworkMessageEnvelope envelope = new NetworkMessageEnvelope
            {
                MessageId = "test-123",
                MessageType = "chat",
                SenderId = "player-1",
                Channel = "test",
                Payload = "Hello"
            };

            NetworkSerializer serializer = new NetworkSerializer();
            string json = serializer.SerializeEnvelope(envelope);

            Assert.NotEmpty(json);
            Assert.Contains("test-123", json);
            Assert.Contains("chat", json);
        }

        /// <summary>
        ///     Tests that message envelope deserializes
        /// </summary>
        [Fact]
        public void MessageEnvelope_Deserializes()
        {
            NetworkMessageEnvelope original = new NetworkMessageEnvelope
            {
                MessageId = "test-456",
                MessageType = "game",
                SenderId = "player-2",
                Channel = "updates",
                Payload = "Test payload"
            };

            NetworkSerializer serializer = new NetworkSerializer();
            string json = serializer.SerializeEnvelope(original);
            NetworkMessageEnvelope deserialized = serializer.DeserializeEnvelope(json);

            Assert.Equal(original.MessageId, deserialized.MessageId);
            Assert.Equal(original.MessageType, deserialized.MessageType);
            Assert.Equal(original.Channel, deserialized.Channel);
        }

        /// <summary>
        ///     Tests that network player has default state
        /// </summary>
        [Fact]
        public void NetworkPlayer_HasValidState()
        {
            NetworkPlayer player = new NetworkPlayer
            {
                PlayerId = "test-player",
                PlayerName = "TestPlayer",
                ConnectionState = PlayerConnectionState.Connected
            };

            Assert.Equal("test-player", player.PlayerId);
            Assert.Equal("TestPlayer", player.PlayerName);
            Assert.Equal(PlayerConnectionState.Connected, player.ConnectionState);
        }
    }
}