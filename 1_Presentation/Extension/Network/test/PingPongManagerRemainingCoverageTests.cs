using System;
using System.IO;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Internal;
using Xunit;

namespace Alis.Extension.Network.Test
{
    /// <summary>
    /// The ping pong manager remaining coverage tests class
    /// </summary>
    public class PingPongManagerRemainingCoverageTests
    {
        /// <summary>
        /// Tests that send ping with valid payload completes successfully
        /// </summary>
        [Fact]
        public async Task SendPing_WithValidPayload_CompletesSuccessfully()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            using CancellationTokenSource cts = new CancellationTokenSource();
            PingPongManager manager = new PingPongManager(guid, webSocket, TimeSpan.Zero, cts.Token);
            ArraySegment<byte> payload = new ArraySegment<byte>(new byte[] { 1, 2, 3 });

            await manager.SendPing(payload, CancellationToken.None);
        }

        /// <summary>
        /// Tests that send ping with empty payload completes successfully
        /// </summary>
        [Fact]
        public async Task SendPing_WithEmptyPayload_CompletesSuccessfully()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            using CancellationTokenSource cts = new CancellationTokenSource();
            PingPongManager manager = new PingPongManager(guid, webSocket, TimeSpan.Zero, cts.Token);
            ArraySegment<byte> payload = new ArraySegment<byte>(Array.Empty<byte>());

            await manager.SendPing(payload, CancellationToken.None);
        }

        /// <summary>
        /// Tests that send ping with payload exceeding max size throws invalid operation exception
        /// </summary>
        [Fact]
        public async Task SendPing_WithPayloadExceedingMaxSize_ThrowsInvalidOperationException()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            using CancellationTokenSource cts = new CancellationTokenSource();
            PingPongManager manager = new PingPongManager(guid, webSocket, TimeSpan.Zero, cts.Token);
            ArraySegment<byte> payload = new ArraySegment<byte>(new byte[126]);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                manager.SendPing(payload, CancellationToken.None));
        }

        /// <summary>
        /// Tests that ping loop when ping sent ticks exist calls handle expired keep alive
        /// </summary>
        [Fact]
        public async Task PingLoop_WhenPingSentTicksExist_CallsHandleExpiredKeepAlive()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            using CancellationTokenSource cts = new CancellationTokenSource();
            PingPongManager manager = new PingPongManager(guid, webSocket, TimeSpan.Zero, cts.Token);

            await manager.SendPing();

            await manager.PingLoop();

            Assert.Equal(WebSocketState.CloseSent, webSocket.State);
        }

        /// <summary>
        /// Tests that ping loop sends ping and detects expired keep alive
        /// </summary>
        [Fact]
        public async Task PingLoop_SendsPingAndDetectsExpiredKeepAlive()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            using CancellationTokenSource cts = new CancellationTokenSource();
            PingPongManager manager = new PingPongManager(guid, webSocket, TimeSpan.Zero, cts.Token);

            await manager.PingLoop();

            Assert.Equal(WebSocketState.CloseSent, webSocket.State);
        }

        /// <summary>
        /// Tests that ping forever completes without exception
        /// </summary>
        [Fact]
        public async Task PingForever_CompletesWithoutException()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            using CancellationTokenSource cts = new CancellationTokenSource();
            PingPongManager manager = new PingPongManager(guid, webSocket, TimeSpan.Zero, cts.Token);

            Exception ex = await Record.ExceptionAsync(() => manager.PingForever());

            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that ping forever with cancelled token swallows cancellation
        /// </summary>
        [Fact]
        public async Task PingForever_WithCancelledToken_SwallowsCancellation()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            using CancellationTokenSource cts = new CancellationTokenSource();
            PingPongManager manager = new PingPongManager(guid, webSocket, TimeSpan.FromSeconds(30), cts.Token);

            cts.Cancel();

            await manager.PingForever();
        }
    }
}
