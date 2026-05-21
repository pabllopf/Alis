

using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Internal;
using Xunit;
using MemoryStream = System.IO.MemoryStream;

namespace Alis.Extension.Network.Test
{
    /// <summary>
    ///     The ping pong manager test class
    /// </summary>
    public class PingPongManagerTest
    {
        /// <summary>
        ///     Tests that send ping valid input
        /// </summary>
        [Fact]
        public async Task SendPing_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Func<MemoryStream> recycledStreamFactory = () => new MemoryStream();
            Stream stream = new MemoryStream();
            TimeSpan keepAliveInterval = TimeSpan.FromSeconds(30);
            string secWebSocketExtensions = "permessage-deflate";
            bool includeExceptionInCloseResponse = true;
            bool isClient = true;
            string subProtocol = "subProtocol";

            WebSocketImplementation webSocket = new WebSocketImplementation(guid, recycledStreamFactory, stream, keepAliveInterval, secWebSocketExtensions, includeExceptionInCloseResponse, isClient, subProtocol);
            PingPongManager pingPongManager = new PingPongManager(guid, webSocket, keepAliveInterval, CancellationToken.None);
            ArraySegment<byte> payload = new ArraySegment<byte>(Encoding.UTF8.GetBytes("Test message"));
            await pingPongManager.SendPing(payload, CancellationToken.None);

        }

        /// <summary>
        ///     Tests that pong valid input
        /// </summary>
        [Fact]
        public void Pong_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Func<MemoryStream> recycledStreamFactory = () => new MemoryStream();
            Stream stream = new MemoryStream();
            TimeSpan keepAliveInterval = TimeSpan.FromSeconds(30);
            string secWebSocketExtensions = "permessage-deflate";
            bool includeExceptionInCloseResponse = true;
            bool isClient = true;
            string subProtocol = "subProtocol";

            WebSocketImplementation webSocket = new WebSocketImplementation(guid, recycledStreamFactory, stream, keepAliveInterval, secWebSocketExtensions, includeExceptionInCloseResponse, isClient, subProtocol);
            PingPongManager pingPongManager = new PingPongManager(guid, webSocket, keepAliveInterval, CancellationToken.None);
            PongEventArgs pongEventArgs = new PongEventArgs(new ArraySegment<byte>(Encoding.UTF8.GetBytes("Test message")));

            pingPongManager.Pong += (sender, e) =>
            {
            };

            typeof(PingPongManager).GetMethod("OnPong", BindingFlags.NonPublic | BindingFlags.Instance)?.Invoke(pingPongManager, new object[] {pongEventArgs});
        }

        /// <summary>
        ///     Tests that web socket impl pong valid input
        /// </summary>
        [Fact]
        public void WebSocketImplPong_ValidInput()
        {
            PingPongManager pingPongManager = new PingPongManager(Guid.NewGuid(), new WebSocketImplementation(
                Guid.NewGuid(),
                () => new MemoryStream(),
                new MemoryStream(),
                TimeSpan.Zero,
                "permessage-deflate",
                true,
                true,
                "subProtocol"
            ), TimeSpan.Zero, new CancellationToken());
            PongEventArgs pongEventArgs = new PongEventArgs(new ArraySegment<byte>(BitConverter.GetBytes(1)));

            pingPongManager.WebSocketImplPong(this, pongEventArgs);

        }

        /// <summary>
        ///     Tests that web socket impl pong null event args
        /// </summary>
        [Fact]
        public void WebSocketImplPong_NullEventArgs()
        {
            PingPongManager pingPongManager = new PingPongManager(Guid.NewGuid(), new WebSocketImplementation(
                Guid.NewGuid(),
                () => new MemoryStream(),
                new MemoryStream(),
                TimeSpan.Zero,
                "permessage-deflate",
                true,
                true,
                "subProtocol"
            ), TimeSpan.Zero, new CancellationToken());

            pingPongManager.WebSocketImplPong(this, null);
        }


        /// <summary>
        ///     Tests that log ping pong manager start end test
        /// </summary>
        [Fact]
        public void LogPingPongManagerStart_End_Test()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(
                Guid.NewGuid(),
                () => new MemoryStream(),
                new MemoryStream(),
                TimeSpan.Zero,
                "permessage-deflate",
                true,
                true,
                "subProtocol"
            );
            TimeSpan keepAliveInterval = TimeSpan.FromSeconds(10);
            CancellationToken cancellationToken = new CancellationToken();

            PingPongManager pingPongManager = new PingPongManager(guid, webSocket, keepAliveInterval, cancellationToken);

        }

        /// <summary>
        ///     Tests that ping sent ticks exist test
        /// </summary>
        [Fact]
        public void PingSentTicksExist_Test()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(
                Guid.NewGuid(),
                () => new MemoryStream(),
                new MemoryStream(),
                TimeSpan.Zero,
                "permessage-deflate",
                true,
                true,
                "subProtocol"
            );
            TimeSpan keepAliveInterval = TimeSpan.FromSeconds(10);
            CancellationToken cancellationToken = new CancellationToken();

            PingPongManager pingPongManager = new PingPongManager(guid, webSocket, keepAliveInterval, cancellationToken);

            bool result = pingPongManager.PingSentTicksExist();

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that handle expired keep alive interval test
        /// </summary>
        [Fact]
        public async Task HandleExpiredKeepAliveInterval_Test()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(
                Guid.NewGuid(),
                () => new MemoryStream(),
                new MemoryStream(),
                TimeSpan.Zero,
                "permessage-deflate",
                true,
                true,
                "subProtocol"
            );
            TimeSpan keepAliveInterval = TimeSpan.FromSeconds(10);
            CancellationToken cancellationToken = new CancellationToken();

            PingPongManager pingPongManager = new PingPongManager(guid, webSocket, keepAliveInterval, cancellationToken);

            await pingPongManager.HandleExpiredKeepAliveInterval();
        }

        /// <summary>
        ///     Tests that send ping test
        /// </summary>
        [Fact]
        public async Task SendPing_Test()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(
                Guid.NewGuid(),
                () => new MemoryStream(),
                new MemoryStream(),
                TimeSpan.Zero,
                "permessage-deflate",
                true,
                true,
                "subProtocol"
            );
            TimeSpan keepAliveInterval = TimeSpan.FromSeconds(10);
            CancellationToken cancellationToken = new CancellationToken();

            PingPongManager pingPongManager = new PingPongManager(guid, webSocket, keepAliveInterval, cancellationToken);

            await pingPongManager.SendPing(new ArraySegment<byte>(BitConverter.GetBytes(1)), cancellationToken);
        }

        /// <summary>
        ///     Tests that send ping test v 2
        /// </summary>
        [Fact]
        public async Task SendPing_Test_V2()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(
                Guid.NewGuid(),
                () => new MemoryStream(),
                new MemoryStream(),
                TimeSpan.Zero,
                "permessage-deflate",
                true,
                true,
                "subProtocol"
            );
            TimeSpan keepAliveInterval = TimeSpan.FromSeconds(10);
            CancellationToken cancellationToken = new CancellationToken();

            PingPongManager pingPongManager = new PingPongManager(guid, webSocket, keepAliveInterval, cancellationToken);

            await pingPongManager.SendPing();

            Assert.True(pingPongManager.PingSentTicksExist());
        }

        /// <summary>
        ///     Tests that log ping pong manager end test
        /// </summary>
        [Fact]
        public void LogPingPongManagerEnd_Test()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(
                Guid.NewGuid(),
                () => new MemoryStream(),
                new MemoryStream(),
                TimeSpan.Zero,
                "permessage-deflate",
                true,
                true,
                "subProtocol"
            );
            TimeSpan keepAliveInterval = TimeSpan.FromSeconds(10);
            CancellationToken cancellationToken = new CancellationToken();

            PingPongManager pingPongManager = new PingPongManager(guid, webSocket, keepAliveInterval, cancellationToken);

            pingPongManager.LogPingPongManagerEnd();

        }
    }
}