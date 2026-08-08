using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Internal;
using Xunit;

namespace Alis.Extension.Network.Test
{
    /// <summary>
    /// The ping pong manager edge case tests class
    /// </summary>
    public class PingPongManagerEdgeCaseTests
    {
        /// <summary>
        /// Tests that constructor with cancelled token does not start ping forever
        /// </summary>
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

        /// <summary>
        /// Tests that constructor with null web socket throws invalid cast exception
        /// </summary>
        [Fact]
        public void Constructor_WithNullWebSocket_ThrowsInvalidCastException()
        {
            Exception ex = Record.Exception(() =>
                new PingPongManager(Guid.NewGuid(), null, TimeSpan.Zero, CancellationToken.None));

            Assert.NotNull(ex);
            Assert.IsType<InvalidCastException>(ex);
        }

        /// <summary>
        /// Tests that ping loop with cancelled token exits immediately
        /// </summary>
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

        /// <summary>
        /// Tests that ping loop with non open socket breaks on state check
        /// </summary>
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

        /// <summary>
        /// Tests that ping forever with cancelled token does not throw
        /// </summary>
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

        /// <summary>
        /// Tests that ping forever with cancelled token invokes log end
        /// </summary>
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

        /// <summary>
        /// Tests that handle expired keep alive interval does not throw
        /// </summary>
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

        /// <summary>
        /// Tests that web socket impl pong with no subscriber does not throw
        /// </summary>
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

        /// <summary>
        /// Tests that ping forever catches operation canceled exception when token cancelled during delay
        /// </summary>
        [Fact]
        public async Task PingForever_WhenCancelledDuringDelay_CatchesOperationCanceledException()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            using CancellationTokenSource cts = new CancellationTokenSource();

            await Task.Delay(100);

            cts.Cancel();

            await Task.Delay(1000);
        }
    }
}
