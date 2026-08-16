// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkClientManagerExecutionTests.cs
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
    ///     Executes the real WebSocket connect and receive flows of <see cref="NetworkClientManager" />
    ///     against a loopback TCP server so that the connection path is covered without external
    ///     network access.
    /// </summary>
    public class NetworkClientManagerExecutionTests : IDisposable
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
        ///     Tests that connect async against a loopback server completes the handshake and that a
        ///     server message is dispatched to the registered handler.
        /// </summary>
        [Fact]
        public async Task ConnectAsync_WithLoopbackServer_CompletesHandshakeAndDispatchesMessage()
        {
            _listener = new TcpListener(IPAddress.Loopback, 0);
            _listener.Start();
            int port = ((IPEndPoint) _listener.LocalEndpoint).Port;

            NetworkClientManager manager = new NetworkClientManager();
            TaskCompletionSource<string> dispatchTcs = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);

            Task serverTask = Task.Run(async () => await RunLoopbackServerAsync(port, dispatchTcs, _cts.Token));

            manager.RegisterMessageHandler("test.channel", (sender, payload) =>
            {
                dispatchTcs.TrySetResult(payload);
                return Task.CompletedTask;
            });
            await manager.InitializeAsync(new NetworkConfig());
            await manager.ConnectAsync(new Uri($"ws://127.0.0.1:{port}"), "Player");

            string payload = await dispatchTcs.Task.WaitAsync(TimeSpan.FromSeconds(10));

            Assert.Equal("hello from server", payload);

            await manager.DisconnectAsync();
            await serverTask.WaitAsync(TimeSpan.FromSeconds(10));
        }

        /// <summary>
        ///     Runs the loopback websocket server
        /// </summary>
        /// <param name="port">The port</param>
        /// <param name="dispatchTcs">The dispatch tcs</param>
        /// <param name="token">The token</param>
        private async Task RunLoopbackServerAsync(int port, TaskCompletionSource<string> dispatchTcs, CancellationToken token)
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

            int headerRead = await ReadFrameHeaderAsync(ns, buffer, token);
            _ = headerRead;

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

            await EchoCloseFrameAsync(ns, buffer, token);
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
                string text = Encoding.UTF8.GetString(buffer, 0, total);
                if (text.Contains("\r\n\r\n"))
                {
                    break;
                }
            }

            return total;
        }

        /// <summary>
        ///     Reads a websocket frame header
        /// </summary>
        /// <param name="ns">The stream</param>
        /// <param name="buffer">The buffer</param>
        /// <param name="token">The token</param>
        /// <returns>The first header byte</returns>
        private static async Task<int> ReadFrameHeaderAsync(NetworkStream ns, byte[] buffer, CancellationToken token)
        {
            int read = await ns.ReadAsync(buffer, 0, 6, token);
            return read;
        }

        /// <summary>
        ///     Echoes the close frame back to the client
        /// </summary>
        /// <param name="ns">The stream</param>
        /// <param name="buffer">The buffer</param>
        /// <param name="token">The token</param>
        private static async Task EchoCloseFrameAsync(NetworkStream ns, byte[] buffer, CancellationToken token)
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
                if ((buffer[0] & 0x0F) == 0x8)
                {
                    byte[] close = {0x88, 0x02, 0x03, 0xE8};
                    await ns.WriteAsync(close, 0, close.Length, token);
                    break;
                }
            }
        }

        /// <summary>
        ///     Extracts the header value
        /// </summary>
        /// <param name="headers">The headers</param>
        /// <param name="name">The name</param>
        /// <returns>The value</returns>
        private static string ExtractHeaderValue(string headers, string name)
        {
            foreach (string line in headers.Split(new[] {"\r\n"}, StringSplitOptions.None))
            {
                int colon = line.IndexOf(':');
                if (colon > 0 && line.Substring(0, colon).Trim().Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return line.Substring(colon + 1).Trim();
                }
            }

            return null;
        }

        /// <summary>
        ///     Computes the socket accept string
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The accept string</returns>
        private static string ComputeSocketAcceptString(string key)
        {
            string combined = key + "258EAFA5-E914-47DA-95CA-C5AB0DC85B11";
            using (SHA512 sha512 = SHA512.Create())
            {
                return Convert.ToBase64String(sha512.ComputeHash(Encoding.UTF8.GetBytes(combined)));
            }
        }
    }
}
