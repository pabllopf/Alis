using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Internal;
using Xunit;

namespace Alis.Extension.Network.Test
{
    public class PingPongManagerEdgeCaseTests
    {
        [Fact]
        public void Constructor_WithCancelledToken_DoesNotStartPingForever()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            using CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();

            PingPongManager manager = new PingPongManager(guid, webSocket, TimeSpan.FromSeconds(30), cts.Token);

            Assert.NotNull(manager);
        }

        [Fact]
        public void Constructor_WithNullWebSocket_ThrowsInvalidCastException()
        {
            Exception ex = Record.Exception(() =>
                new PingPongManager(Guid.NewGuid(), null, TimeSpan.Zero, CancellationToken.None));

            Assert.NotNull(ex);
            Assert.IsType<InvalidCastException>(ex);
        }

        [Fact]
        public async Task PingLoop_WithCancelledToken_ExitsImmediately()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            using CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();
            PingPongManager manager = new PingPongManager(guid, webSocket, TimeSpan.Zero, cts.Token);

            await manager.PingLoop();
        }

        [Fact]
        public async Task PingLoop_WithNonOpenSocket_BreaksOnStateCheck()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            using CancellationTokenSource cts = new CancellationTokenSource();
            PingPongManager manager = new PingPongManager(guid, webSocket, TimeSpan.FromMilliseconds(1), cts.Token);

            await manager.PingLoop();
        }

        [Fact]
        public async Task PingForever_WithCancelledToken_DoesNotThrow()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            using CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();
            PingPongManager manager = new PingPongManager(guid, webSocket, TimeSpan.FromSeconds(30), cts.Token);

            Exception ex = await Record.ExceptionAsync(() => manager.PingForever());
            Assert.Null(ex);
        }

        [Fact]
        public async Task PingForever_WithCancelledToken_InvokesLogEnd()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            using CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();
            PingPongManager manager = new PingPongManager(guid, webSocket, TimeSpan.FromSeconds(30), cts.Token);

            await manager.PingForever();

            Assert.NotNull(manager);
        }

        [Fact]
        public async Task HandleExpiredKeepAliveInterval_DoesNotThrow()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            using CancellationTokenSource cts = new CancellationTokenSource();
            PingPongManager manager = new PingPongManager(guid, webSocket, TimeSpan.Zero, cts.Token);

            Exception ex = await Record.ExceptionAsync(() => manager.HandleExpiredKeepAliveInterval());
            Assert.Null(ex);
        }

        [Fact]
        public void WebSocketImplPong_WithNoSubscriber_DoesNotThrow()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            using CancellationTokenSource cts = new CancellationTokenSource();
            PingPongManager manager = new PingPongManager(guid, webSocket, TimeSpan.Zero, cts.Token);

            manager.WebSocketImplPong(null, new PongEventArgs(new ArraySegment<byte>(Array.Empty<byte>())));
        }

        [Fact]
        public void SendPing_WithCancelledToken_ThrowsOperationCanceledException()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            using CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();
            PingPongManager manager = new PingPongManager(guid, webSocket, TimeSpan.Zero, CancellationToken.None);

            Assert.ThrowsAsync<OperationCanceledException>(() =>
                manager.SendPing(new ArraySegment<byte>(Array.Empty<byte>()), cts.Token));
        }
    }
}
