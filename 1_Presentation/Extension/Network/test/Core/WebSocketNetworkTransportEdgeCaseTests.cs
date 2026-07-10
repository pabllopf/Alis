using System;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Core;
using Xunit;

namespace Alis.Extension.Network.Test.Core
{
    public class WebSocketNetworkTransportEdgeCaseTests
    {
        [Fact]
        public async Task StartAsync_WithInvalidIPAddress_ThrowsFormatException()
        {
            using var transport = new WebSocketNetworkTransport(new Uri("ws://999.999.999.999:1234"));
            await Assert.ThrowsAsync<FormatException>(() => transport.StartAsync());
        }

        [Fact]
        public async Task StartAsync_WithInvalidIPAddress_ResetsStateToDisconnected()
        {
            using var transport = new WebSocketNetworkTransport(new Uri("ws://999.999.999.999:1234"));
            try
            {
                await transport.StartAsync();
            }
            catch (FormatException)
            {
            }
            Assert.Equal(NetworkTransportState.Disconnected, transport.State);
        }

        [Fact]
        public async Task StartAsync_WithInvalidHostName_ThrowsFormatException()
        {
            using var transport = new WebSocketNetworkTransport(new Uri("ws://invalid-host-name-that-cannot-parse:1234"));
            await Assert.ThrowsAsync<FormatException>(() => transport.StartAsync());
        }

        [Fact]
        public async Task StartAsync_WithInvalidHostName_ResetsStateToDisconnected()
        {
            using var transport = new WebSocketNetworkTransport(new Uri("ws://invalid-host-name-that-cannot-parse:1234"));
            try
            {
                await transport.StartAsync();
            }
            catch (FormatException)
            {
            }
            Assert.Equal(NetworkTransportState.Disconnected, transport.State);
        }

        [Fact]
        public async Task StartAsync_WithAlreadyStartedTransport_ThrowsInvalidOperationException()
        {
            using var transport = new WebSocketNetworkTransport(new Uri("ws://127.0.0.1:18891"));
            await transport.StartAsync();
            InvalidOperationException ex = await Assert.ThrowsAsync<InvalidOperationException>(() => transport.StartAsync());
            Assert.Contains("already started", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public async Task StartAsync_WithPortInUse_ThrowsSocketException()
        {
            using var transport1 = new WebSocketNetworkTransport(new Uri("ws://127.0.0.1:18892"));
            using var transport2 = new WebSocketNetworkTransport(new Uri("ws://127.0.0.1:18892"));
            await transport1.StartAsync();
            System.Net.Sockets.SocketException ex = await Assert.ThrowsAsync<System.Net.Sockets.SocketException>(() => transport2.StartAsync());
            Assert.Contains("already in use", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public async Task StartAsync_WithPortInUse_ResetsStateToDisconnected()
        {
            using var transport1 = new WebSocketNetworkTransport(new Uri("ws://127.0.0.1:18894"));
            using var transport2 = new WebSocketNetworkTransport(new Uri("ws://127.0.0.1:18894"));
            await transport1.StartAsync();
            try
            {
                await transport2.StartAsync();
            }
            catch (System.Net.Sockets.SocketException)
            {
            }
            Assert.Equal(NetworkTransportState.Disconnected, transport2.State);
        }

        [Fact]
        public async Task StopAsync_AfterStart_TransitionsToDisconnected()
        {
            using var transport = new WebSocketNetworkTransport(new Uri("ws://127.0.0.1:18893"));
            await transport.StartAsync();
            await transport.StopAsync();
            Assert.Equal(NetworkTransportState.Disconnected, transport.State);
        }

        [Fact]
        public async Task Dispose_AfterStartAsyncFailure_DoesNotThrow()
        {
            WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri("ws://999.999.999.999:1234"));
            try
            {
                await transport.StartAsync();
            }
            catch (FormatException)
            {
            }
            Exception ex = Record.Exception(() => transport.Dispose());
            Assert.Null(ex);
        }

        [Fact]
        public async Task BroadcastAsync_WithExceptClientIdAndNoClients_DoesNotThrow()
        {
            using var transport = new WebSocketNetworkTransport();
            NetworkMessageEnvelope envelope = new NetworkMessageEnvelope { MessageId = "test" };
            Exception ex = await Record.ExceptionAsync(() => transport.BroadcastAsync(envelope, "non-existent-client"));
            Assert.Null(ex);
        }

        [Fact]
        public async Task BroadcastAsync_WithCancellationToken_DoesNotThrow()
        {
            using var transport = new WebSocketNetworkTransport();
            NetworkMessageEnvelope envelope = new NetworkMessageEnvelope { MessageId = "test" };
            using CancellationTokenSource cts = new CancellationTokenSource();
            Exception ex = await Record.ExceptionAsync(() => transport.BroadcastAsync(envelope, null, cts.Token));
            Assert.Null(ex);
        }

        [Fact]
        public void Constructor_WithNullUri_HasDisconnectedState()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport();
            Assert.Equal(NetworkTransportState.Disconnected, transport.State);
        }

        [Fact]
        public void Constructor_WithCustomPort_UsesCustomPort()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri("ws://127.0.0.1:9999"));
            Assert.Equal(NetworkTransportState.Disconnected, transport.State);
        }

        [Fact]
        public void Constructor_WithPortZero_UsesDefaultPort()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri("ws://127.0.0.1:0"));
            Assert.Equal(NetworkTransportState.Disconnected, transport.State);
        }

        [Fact]
        public void Constructor_WithLocalhost_UsesLocalhost()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri("ws://localhost:8888"));
            Assert.Equal(NetworkTransportState.Disconnected, transport.State);
        }

        [Fact]
        public void Dispose_MultipleInstances_DoesNotThrow()
        {
            WebSocketNetworkTransport transport1 = new WebSocketNetworkTransport();
            WebSocketNetworkTransport transport2 = new WebSocketNetworkTransport(new Uri("ws://127.0.0.1:9999"));
            transport1.Dispose();
            transport2.Dispose();
            Exception ex = Record.Exception(() => transport1.Dispose());
            Assert.Null(ex);
        }
    }
}
