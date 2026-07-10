using System;
using System.IO;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Internal;
using Xunit;

namespace Alis.Extension.Network.Test
{
    public class PingPongManagerRemainingCoverageTests
    {
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
    }
}
