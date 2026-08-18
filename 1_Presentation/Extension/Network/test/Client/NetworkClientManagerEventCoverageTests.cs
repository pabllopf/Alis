// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkClientManagerEventCoverageTests.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Client;
using Alis.Extension.Network.Core;
using Xunit;

namespace Alis.Extension.Network.Test.Client
{
    /// <summary>
    ///     The network client manager event coverage tests class
    /// </summary>
    public class NetworkClientManagerEventCoverageTests : IDisposable
    {
        /// <summary>
        ///     The listener
        /// </summary>
        private TcpListener _listener;

        /// <summary>
        ///     The cancellation token source
        /// </summary>
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();

        /// <summary>
        ///     Disposes the listener
        /// </summary>
        public void Dispose()
        {
            _cts.Cancel();
            _listener?.Stop();
            _cts.Dispose();
        }

        /// <summary>
        ///     Tests that the connected event fires when the connection is established.
        /// </summary>
        [Fact]
        public async Task ConnectAsync_WithConnectedEventSubscribed_FiresEvent()
        {
            _listener = new TcpListener(IPAddress.Loopback, 0);
            _listener.Start();
            int port = ((IPEndPoint) _listener.LocalEndpoint).Port;

            NetworkClientManager manager = new NetworkClientManager();
            TaskCompletionSource<bool> connectedTcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            manager.Connected += (sender, args) => connectedTcs.TrySetResult(true);

            Task serverTask = Task.Run(async () => await RunEchoServerAsync(port, _cts.Token));
            await manager.InitializeAsync(new NetworkConfig());
            await manager.ConnectAsync(new Uri($"ws://127.0.0.1:{port}"), "Player");

            Assert.True(await connectedTcs.Task.WaitAsync(TimeSpan.FromSeconds(10)));

            await manager.DisconnectAsync();
            await serverTask.WaitAsync(TimeSpan.FromSeconds(10));
        }

        /// <summary>
        ///     Tests that the error event fires when the receive loop fails during disconnect.
        /// </summary>
        [Fact]
        public async Task DisconnectAsync_WithErrorEventSubscribed_FiresOnReceiveFailure()
        {
            _listener = new TcpListener(IPAddress.Loopback, 0);
            _listener.Start();
            int port = ((IPEndPoint) _listener.LocalEndpoint).Port;

            NetworkClientManager manager = new NetworkClientManager();
            TaskCompletionSource<bool> errorTcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            manager.Error += (sender, args) => errorTcs.TrySetResult(true);

            Task serverTask = Task.Run(async () => await RunEchoServerAsync(port, _cts.Token));
            await manager.InitializeAsync(new NetworkConfig());
            await manager.ConnectAsync(new Uri($"ws://127.0.0.1:{port}"), "Player");

            await manager.DisconnectAsync();

            Assert.True(await errorTcs.Task.WaitAsync(TimeSpan.FromSeconds(10)));

            await serverTask.WaitAsync(TimeSpan.FromSeconds(10));
        }

        /// <summary>
        ///     Tests that the receive loop exits via the cancellation check while a handler is running.
        /// </summary>
        [Fact]
        public async Task ReceiveLoop_WithSlowHandler_ExitsViaCancellationCheck()
        {
            _listener = new TcpListener(IPAddress.Loopback, 0);
            _listener.Start();
            int port = ((IPEndPoint) _listener.LocalEndpoint).Port;

            NetworkClientManager manager = new NetworkClientManager();
            TaskCompletionSource<bool> handlerEnteredTcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            TaskCompletionSource<bool> handlerGate = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            manager.RegisterMessageHandler("test.channel", async (sender, payload) =>
            {
                handlerEnteredTcs.TrySetResult(true);
                await handlerGate.Task;
            });

            Task serverTask = Task.Run(async () => await RunEchoServerAsync(port, _cts.Token, sendMessage: true));
            await manager.InitializeAsync(new NetworkConfig());
            await manager.ConnectAsync(new Uri($"ws://127.0.0.1:{port}"), "Player");

            Assert.True(await handlerEnteredTcs.Task.WaitAsync(TimeSpan.FromSeconds(10)));

            Task disconnectTask = manager.DisconnectAsync();
            handlerGate.TrySetResult(true);
            await disconnectTask;

            Assert.Equal(NetworkManagerState.Disconnected, manager.State);

            await serverTask.WaitAsync(TimeSpan.FromSeconds(10));
        }

        /// <summary>
        ///     Tests that the error event fires when a disconnect subscriber throws.
        /// </summary>
        [Fact]
        public async Task DisconnectAsync_WhenDisconnectedHandlerThrows_FiresError()
        {
            _listener = new TcpListener(IPAddress.Loopback, 0);
            _listener.Start();
            int port = ((IPEndPoint) _listener.LocalEndpoint).Port;

            NetworkClientManager manager = new NetworkClientManager();
            TaskCompletionSource<bool> errorTcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            manager.Error += (sender, args) => errorTcs.TrySetResult(true);
            manager.Disconnected += (sender, args) => throw new InvalidOperationException("subscriber failure");

            Task serverTask = Task.Run(async () => await RunEchoServerAsync(port, _cts.Token));
            await manager.InitializeAsync(new NetworkConfig());
            await manager.ConnectAsync(new Uri($"ws://127.0.0.1:{port}"), "Player");

            await manager.DisconnectAsync();

            Assert.True(await errorTcs.Task.WaitAsync(TimeSpan.FromSeconds(10)));

            await serverTask.WaitAsync(TimeSpan.FromSeconds(10));
        }

        /// <summary>
        ///     Tests that the error event fires when the socket close fails during disconnect.
        /// </summary>
        [Fact]
        public async Task DisconnectAsync_WhenSocketCloseFails_FiresError()
        {
            _listener = new TcpListener(IPAddress.Loopback, 0);
            _listener.Start();
            int port = ((IPEndPoint) _listener.LocalEndpoint).Port;

            NetworkClientManager manager = new NetworkClientManager();
            TaskCompletionSource<bool> errorTcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            manager.Error += (sender, args) => errorTcs.TrySetResult(true);

            Task serverTask = Task.Run(async () => await RunAbruptCloseServerAsync(port, _cts.Token));
            await manager.InitializeAsync(new NetworkConfig());
            await manager.ConnectAsync(new Uri($"ws://127.0.0.1:{port}"), "Player");

            await Task.Delay(200);
            await manager.DisconnectAsync();

            Assert.True(await errorTcs.Task.WaitAsync(TimeSpan.FromSeconds(10)));

            await serverTask.WaitAsync(TimeSpan.FromSeconds(10));
        }

        /// <summary>
        ///     Runs a loopback websocket echo server.
        /// </summary>
        /// <param name="port">The port</param>
        /// <param name="token">The token</param>
        /// <param name="sendMessage">Whether to send a test message after the handshake</param>
        private async Task RunEchoServerAsync(int port, CancellationToken token, bool sendMessage = false)
        {
            using TcpClient server = await _listener.AcceptTcpClientAsync();
            using NetworkStream ns = server.GetStream();

            byte[] buffer = new byte[8192];
            int read = await ReadUntilDoubleCrlfAsync(ns, buffer, token);
            string request = Encoding.UTF8.GetString(buffer, 0, read);
            string key = ExtractHeaderValue(request, "Sec-WebSocket-Key");
            string accept = ComputeSocketAcceptString(key);
            string response = "HTTP/1.1 101 Switching Protocols\r\nUpgrade: websocket\r\nConnection: Upgrade\r\nSec-WebSocket-Accept: " + accept + "\r\n\r\n";
            byte[] responseBytes = Encoding.UTF8.GetBytes(response);
            await ns.WriteAsync(responseBytes, 0, responseBytes.Length, token);

            if (sendMessage)
            {
                NetworkSerializer serializer = new NetworkSerializer();
                NetworkMessageEnvelope envelope = new NetworkMessageEnvelope
                {
                    MessageId = "s1",
                    MessageType = "chat",
                    SenderId = "server",
                    Channel = "test.channel",
                    Payload = "hello from server"
                };
                string json = serializer.SerializeEnvelope(envelope);
                byte[] payload = Encoding.UTF8.GetBytes(json);
                byte[] frame;
                if (payload.Length <= 125)
                {
                    frame = new byte[2 + payload.Length];
                    frame[0] = 0x81;
                    frame[1] = (byte) payload.Length;
                    Array.Copy(payload, 0, frame, 2, payload.Length);
                }
                else
                {
                    frame = new byte[4 + payload.Length];
                    frame[0] = 0x81;
                    frame[1] = 126;
                    frame[2] = (byte) (payload.Length >> 8);
                    frame[3] = (byte) payload.Length;
                    Array.Copy(payload, 0, frame, 4, payload.Length);
                }

                await ns.WriteAsync(frame, 0, frame.Length, token);
            }

            await ReadUntilCloseFrameAsync(ns, buffer, token);
        }

        /// <summary>
        ///     Runs a loopback websocket server that aborts the connection after the handshake.
        /// </summary>
        /// <param name="port">The port</param>
        /// <param name="token">The token</param>
        private async Task RunAbruptCloseServerAsync(int port, CancellationToken token)
        {
            using TcpClient server = await _listener.AcceptTcpClientAsync();
            using NetworkStream ns = server.GetStream();

            byte[] buffer = new byte[8192];
            int read = await ReadUntilDoubleCrlfAsync(ns, buffer, token);
            string request = Encoding.UTF8.GetString(buffer, 0, read);
            string key = ExtractHeaderValue(request, "Sec-WebSocket-Key");
            string accept = ComputeSocketAcceptString(key);
            string response = "HTTP/1.1 101 Switching Protocols\r\nUpgrade: websocket\r\nConnection: Upgrade\r\nSec-WebSocket-Accept: " + accept + "\r\n\r\n";
            byte[] responseBytes = Encoding.UTF8.GetBytes(response);
            await ns.WriteAsync(responseBytes, 0, responseBytes.Length, token);

            await Task.Delay(100, token);
        }

        /// <summary>
        ///     Reads until the double crlf of the http headers
        /// </summary>
        /// <param name="ns">The stream</param>
        /// <param name="buffer">The buffer</param>
        /// <param name="token">The token</param>
        /// <returns>The bytes read</returns>
        private static async Task<int> ReadUntilDoubleCrlfAsync(NetworkStream ns, byte[] buffer, CancellationToken token)
        {
            int total = 0;
            while (total < buffer.Length)
            {
                int read = await ns.ReadAsync(buffer, total, buffer.Length - total, token);
                if (read == 0)
                {
                    break;
                }

                total += read;
                if (Encoding.UTF8.GetString(buffer, 0, total).Contains("\r\n\r\n"))
                {
                    break;
                }
            }

            return total;
        }

        /// <summary>
        ///     Reads until a close frame arrives from the client.
        /// </summary>
        /// <param name="ns">The stream</param>
        /// <param name="buffer">The buffer</param>
        /// <param name="token">The token</param>
        private static async Task ReadUntilCloseFrameAsync(NetworkStream ns, byte[] buffer, CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    int read = await ns.ReadAsync(buffer, 0, buffer.Length, token);
                    if (read == 0)
                    {
                        break;
                    }

                    if ((read >= 2) && (buffer[0] == 0x88))
                    {
                        break;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        ///     Extracts the header value using the specified header name
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="name">The name</param>
        /// <returns>The value</returns>
        private static string ExtractHeaderValue(string request, string name)
        {
            string[] lines = request.Split("\r\n");
            foreach (string line in lines)
            {
                if (line.StartsWith(name + ":", StringComparison.OrdinalIgnoreCase))
                {
                    return line.Substring(name.Length + 1).Trim();
                }
            }

            return string.Empty;
        }

        /// <summary>
        ///     Computes the socket accept string
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The string</returns>
        private static string ComputeSocketAcceptString(string key)
        {
            string magic = "258EAFA5-E914-47DA-95CA-C5AB0DC85B11";
            using SHA512 sha512 = SHA512.Create();
            byte[] hash = sha512.ComputeHash(Encoding.UTF8.GetBytes(key + magic));
            return Convert.ToBase64String(hash);
        }
    }
}