// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketNetworkTransportSocketCoverageTests.cs
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
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Core;
using Xunit;

namespace Alis.Extension.Network.Test.Core
{
    /// <summary>
    ///     The web socket network transport socket coverage tests class
    /// </summary>
    public class WebSocketNetworkTransportSocketCoverageTests
    {
        /// <summary>
        ///     The next port
        /// </summary>
        private static int _nextPort = 28000;

        /// <summary>
        ///     The port lock
        /// </summary>
        private static readonly object PortLock = new object();

        /// <summary>
        ///     Gets the next port
        /// </summary>
        /// <returns>The int</returns>
        private static int GetNextPort()
        {
            lock (PortLock)
            {
                int port = _nextPort;
                _nextPort += 103;
                return port;
            }
        }

        /// <summary>
        ///     Tests that the accept loop exits cleanly when the cancellation token is cancelled.
        /// </summary>
        [Fact]
        public async Task AcceptLoop_WhenTokenCancelled_ExitsCleanly()
        {
            int port = GetNextPort();
            using CancellationTokenSource cts = new CancellationTokenSource();
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri($"ws://127.0.0.1:{port}"));
            await transport.StartAsync(cts.Token);
            Assert.Equal(NetworkTransportState.Connected, transport.State);

            cts.Cancel();

            using (TcpClient client = new TcpClient())
            {
                await client.ConnectAsync("127.0.0.1", port);
                await Task.Delay(300);
            }

            await transport.StopAsync();
            Assert.Equal(NetworkTransportState.Disconnected, transport.State);
        }

        /// <summary>
        ///     Tests that the client handler removes the socket when the handshake fails.
        /// </summary>
        [Fact]
        public async Task HandleClientAsync_WhenHandshakeFails_RemovesClient()
        {
            int port = GetNextPort();
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri($"ws://127.0.0.1:{port}"));
            await transport.StartAsync();

            using (TcpClient client = new TcpClient())
            {
                await client.ConnectAsync("127.0.0.1", port);
                NetworkStream stream = client.GetStream();
                byte[] oversizedHeader = new byte[20000];
                for (int i = 0; i < oversizedHeader.Length; i++)
                {
                    oversizedHeader[i] = (byte)'A';
                }

                await stream.WriteAsync(oversizedHeader, 0, oversizedHeader.Length);
                await Task.Delay(300);
            }

            Assert.Empty(transport._clientSockets);
            await transport.StopAsync();
        }

        /// <summary>
        ///     Tests that the receive loop exits and disposes the socket when the token is cancelled.
        /// </summary>
        [Fact]
        public async Task ReceiveLoop_WhenTokenCancelled_ExitsAndDisposesSocket()
        {
            int port = GetNextPort();
            using CancellationTokenSource cts = new CancellationTokenSource();
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri($"ws://127.0.0.1:{port}"));
            await transport.StartAsync(cts.Token);

            (TcpClient client, NetworkStream stream) = await ConnectAndHandshakeAsync("127.0.0.1", port);

            NetworkSerializer serializer = new NetworkSerializer();
            NetworkMessageEnvelope envelope = new NetworkMessageEnvelope { MessageId = "cancel-test" };
            byte[] frame = BuildTextFrame(serializer.SerializeEnvelope(envelope));
            await stream.WriteAsync(frame, 0, frame.Length);

            using CancellationTokenSource receiveCts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            (string clientId, NetworkMessageEnvelope received) = await transport.ReceiveAsync(receiveCts.Token);
            Assert.Equal("cancel-test", received.MessageId);

            NetworkMessageEnvelope secondEnvelope = new NetworkMessageEnvelope { MessageId = "cancel-test-2" };
            byte[] secondFrame = BuildTextFrame(serializer.SerializeEnvelope(secondEnvelope));
            await stream.WriteAsync(secondFrame, 0, secondFrame.Length);
            cts.Cancel();
            await Task.Delay(300);

            Assert.Empty(transport._clientSockets);

            client.Close();
            await transport.StopAsync();
        }

        /// <summary>
        ///     Tests that stop async with a started listener stops the listener and clears sockets.
        /// </summary>
        [Fact]
        public async Task StopAsync_AfterStartWithConnectedClient_StopsListener()
        {
            int port = GetNextPort();
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri($"ws://127.0.0.1:{port}"));
            await transport.StartAsync();

            (TcpClient client, NetworkStream _) = await ConnectAndHandshakeAsync("127.0.0.1", port);
            await Task.Delay(200);

            await transport.StopAsync();

            Assert.Equal(NetworkTransportState.Disconnected, transport.State);
            Assert.Empty(transport._clientSockets);

            client.Close();
        }

        /// <summary>
        ///     Connects the and handshake using the specified host
        /// </summary>
        /// <param name="host">The host</param>
        /// <param name="port">The port</param>
        /// <returns>A task containing the tcp client and network stream</returns>
        private static async Task<(TcpClient Client, NetworkStream Stream)> ConnectAndHandshakeAsync(string host, int port)
        {
            TcpClient tcpClient = new TcpClient();
            await tcpClient.ConnectAsync(host, port);
            NetworkStream stream = tcpClient.GetStream();

            string key = CreateWebSocketKey();
            string request = BuildWebSocketUpgradeRequest(host, port, key);
            byte[] requestBytes = Encoding.UTF8.GetBytes(request);
            await stream.WriteAsync(requestBytes, 0, requestBytes.Length);

            byte[] responseBuffer = new byte[4096];
            int bytesRead = await stream.ReadAsync(responseBuffer, 0, responseBuffer.Length);
            string response = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);

            Assert.Contains("101 Switching Protocols", response);
            Assert.Contains("Sec-WebSocket-Accept:", response);

            return (tcpClient, stream);
        }

        /// <summary>
        ///     Creates the web socket key
        /// </summary>
        /// <returns>The string</returns>
        private static string CreateWebSocketKey()
        {
            byte[] keyBytes = new byte[16];
            RandomNumberGenerator.Create().GetBytes(keyBytes);
            return Convert.ToBase64String(keyBytes);
        }

        /// <summary>
        ///     Builds the web socket upgrade request using the specified host
        /// </summary>
        /// <param name="host">The host</param>
        /// <param name="port">The port</param>
        /// <param name="key">The key</param>
        /// <returns>The string</returns>
        private static string BuildWebSocketUpgradeRequest(string host, int port, string key)
        {
            return $"GET / HTTP/1.1\r\n" +
                   $"Host: {host}:{port}\r\n" +
                   $"Upgrade: websocket\r\n" +
                   $"Connection: Upgrade\r\n" +
                   $"Sec-WebSocket-Key: {key}\r\n" +
                   $"Sec-WebSocket-Version: 13\r\n\r\n";
        }

        /// <summary>
        ///     Builds a text web socket frame from the given payload.
        /// </summary>
        /// <param name="payload">The payload</param>
        /// <returns>The frame bytes</returns>
        private static byte[] BuildTextFrame(string text)
        {
            byte[] payload = Encoding.UTF8.GetBytes(text);
            int payloadLen = payload.Length;
            using MemoryStream ms = new MemoryStream();

            ms.WriteByte(0x81);

            byte[] maskKey = new byte[4];
            RandomNumberGenerator.Create().GetBytes(maskKey);

            if (payloadLen < 126)
            {
                byte lenByte = (byte)(payloadLen | 0x80);
                ms.WriteByte(lenByte);
            }
            else if (payloadLen < 65536)
            {
                byte lenByte = (byte)(126 | 0x80);
                ms.WriteByte(lenByte);
                ms.WriteByte((byte)(payloadLen >> 8));
                ms.WriteByte((byte)(payloadLen & 0xFF));
            }
            else
            {
                byte lenByte = (byte)(127 | 0x80);
                ms.WriteByte(lenByte);
                long len64 = payloadLen;
                for (int i = 56; i >= 0; i -= 8)
                {
                    ms.WriteByte((byte)((len64 >> i) & 0xFF));
                }
            }

            ms.Write(maskKey, 0, maskKey.Length);

            byte[] maskedPayload = new byte[payload.Length];
            for (int i = 0; i < payload.Length; i++)
            {
                maskedPayload[i] = (byte)(payload[i] ^ maskKey[i % 4]);
            }

            ms.Write(maskedPayload, 0, maskedPayload.Length);
            return ms.ToArray();
        }
    }
}