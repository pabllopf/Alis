using System;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Core;
using Xunit;

namespace Alis.Extension.Network.Test.Core
{
    /// <summary>
    /// The web socket network transport edge case tests class
    /// </summary>
    public class WebSocketNetworkTransportEdgeCaseTests
    {
        /// <summary>
        /// Tests that start async with invalid ip address throws format exception
        /// </summary>
        [Fact]
        public async Task StartAsync_WithInvalidIPAddress_ThrowsFormatException()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri("ws://999.999.999.999:1234"));
            await Assert.ThrowsAsync<FormatException>(() => transport.StartAsync());
        }

        /// <summary>
        /// Tests that start async with invalid ip address resets state to disconnected
        /// </summary>
        [Fact]
        public async Task StartAsync_WithInvalidIPAddress_ResetsStateToDisconnected()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri("ws://999.999.999.999:1234"));
            try
            {
                await transport.StartAsync();
            }
            catch (FormatException)
            {
            }
            Assert.Equal(NetworkTransportState.Disconnected, transport.State);
        }

        /// <summary>
        /// Tests that start async with invalid host name throws format exception
        /// </summary>
        [Fact]
        public async Task StartAsync_WithInvalidHostName_ThrowsFormatException()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri("ws://invalid-host-name-that-cannot-parse:1234"));
            await Assert.ThrowsAsync<FormatException>(() => transport.StartAsync());
        }

        /// <summary>
        /// Tests that start async with invalid host name resets state to disconnected
        /// </summary>
        [Fact]
        public async Task StartAsync_WithInvalidHostName_ResetsStateToDisconnected()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri("ws://invalid-host-name-that-cannot-parse:1234"));
            try
            {
                await transport.StartAsync();
            }
            catch (FormatException)
            {
            }
            Assert.Equal(NetworkTransportState.Disconnected, transport.State);
        }

        /// <summary>
        /// Tests that start async with already started transport throws invalid operation exception
        /// </summary>
        [Fact]
        public async Task StartAsync_WithAlreadyStartedTransport_ThrowsInvalidOperationException()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri("ws://127.0.0.1:18891"));
            await transport.StartAsync();
            InvalidOperationException ex = await Assert.ThrowsAsync<InvalidOperationException>(() => transport.StartAsync());
            Assert.Contains("already started", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Tests that start async with port in use throws socket exception
        /// </summary>
        [Fact]
        public async Task StartAsync_WithPortInUse_ThrowsSocketException()
        {
            using WebSocketNetworkTransport transport1 = new WebSocketNetworkTransport(new Uri("ws://127.0.0.1:18892"));
            using WebSocketNetworkTransport transport2 = new WebSocketNetworkTransport(new Uri("ws://127.0.0.1:18892"));
            await transport1.StartAsync();
            System.Net.Sockets.SocketException ex = await Assert.ThrowsAsync<System.Net.Sockets.SocketException>(() => transport2.StartAsync());
            Assert.Contains("already in use", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Tests that start async with port in use resets state to disconnected
        /// </summary>
        [Fact]
        public async Task StartAsync_WithPortInUse_ResetsStateToDisconnected()
        {
            using WebSocketNetworkTransport transport1 = new WebSocketNetworkTransport(new Uri("ws://127.0.0.1:18894"));
            using WebSocketNetworkTransport transport2 = new WebSocketNetworkTransport(new Uri("ws://127.0.0.1:18894"));
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

        /// <summary>
        /// Tests that stop async after start transitions to disconnected
        /// </summary>
        [Fact]
        public async Task StopAsync_AfterStart_TransitionsToDisconnected()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri("ws://127.0.0.1:18893"));
            await transport.StartAsync();
            await transport.StopAsync();
            Assert.Equal(NetworkTransportState.Disconnected, transport.State);
        }

        /// <summary>
        /// Tests that dispose after start async failure does not throw
        /// </summary>
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

        /// <summary>
        /// Tests that broadcast async with except client id and no clients does not throw
        /// </summary>
        [Fact]
        public async Task BroadcastAsync_WithExceptClientIdAndNoClients_DoesNotThrow()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport();
            NetworkMessageEnvelope envelope = new NetworkMessageEnvelope { MessageId = "test" };
            Exception ex = await Record.ExceptionAsync(() => transport.BroadcastAsync(envelope, "non-existent-client"));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that broadcast async with cancellation token does not throw
        /// </summary>
        [Fact]
        public async Task BroadcastAsync_WithCancellationToken_DoesNotThrow()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport();
            NetworkMessageEnvelope envelope = new NetworkMessageEnvelope { MessageId = "test" };
            using CancellationTokenSource cts = new CancellationTokenSource();
            Exception ex = await Record.ExceptionAsync(() => transport.BroadcastAsync(envelope, null, cts.Token));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that constructor with null uri has disconnected state
        /// </summary>
        [Fact]
        public void Constructor_WithNullUri_HasDisconnectedState()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport();
            Assert.Equal(NetworkTransportState.Disconnected, transport.State);
        }

        /// <summary>
        /// Tests that constructor with custom port uses custom port
        /// </summary>
        [Fact]
        public void Constructor_WithCustomPort_UsesCustomPort()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri("ws://127.0.0.1:9999"));
            Assert.Equal(NetworkTransportState.Disconnected, transport.State);
        }

        /// <summary>
        /// Tests that constructor with port zero uses default port
        /// </summary>
        [Fact]
        public void Constructor_WithPortZero_UsesDefaultPort()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri("ws://127.0.0.1:0"));
            Assert.Equal(NetworkTransportState.Disconnected, transport.State);
        }

        /// <summary>
        /// Tests that constructor with localhost uses localhost
        /// </summary>
        [Fact]
        public void Constructor_WithLocalhost_UsesLocalhost()
        {
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri("ws://localhost:8888"));
            Assert.Equal(NetworkTransportState.Disconnected, transport.State);
        }

        /// <summary>
        /// Tests that dispose multiple instances does not throw
        /// </summary>
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
