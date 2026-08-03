// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketNetworkTransportTests.cs
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
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Core;
using Xunit;

namespace Alis.Extension.Network.Test.Core
{
    /// <summary>
    /// The web socket network transport tests class
    /// </summary>
    public class WebSocketNetworkTransportTests
    {
        /// <summary>
        /// The next port
        /// </summary>
        private static int _nextPort = 25000;
        /// <summary>
        /// The port lock
        /// </summary>
        private static readonly object PortLock = new object();

        /// <summary>
        /// Gets the next port
        /// </summary>
        /// <returns>The int</returns>
        private static int GetNextPort()
        {
            lock (PortLock)
            {
                int port = _nextPort;
                _nextPort += 101;
                return port;
            }
        }

        /// <summary>
        /// Creates the web socket key
        /// </summary>
        /// <returns>The string</returns>
        private static string CreateWebSocketKey()
        {
            byte[] keyBytes = new byte[16];
            RandomNumberGenerator.Create().GetBytes(keyBytes);
            return Convert.ToBase64String(keyBytes);
        }

        /// <summary>
        /// Builds the web socket upgrade request using the specified host
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
        /// Masks the data using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="maskKey">The mask key</param>
        /// <returns>The masked</returns>
        private static byte[] MaskData(byte[] data, byte[] maskKey)
        {
            byte[] masked = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                masked[i] = (byte)(data[i] ^ maskKey[i % 4]);
            }
            return masked;
        }

        /// <summary>
        /// Builds the text frame using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="masked">The masked</param>
        /// <returns>The byte array</returns>
        private static byte[] BuildTextFrame(string text, bool masked = true)
        {
            byte[] payload = Encoding.UTF8.GetBytes(text);
            int payloadLen = payload.Length;
            using MemoryStream ms = new MemoryStream();

            // FIN=1, Opcode=0x1 (text)
            ms.WriteByte(0x81);

            byte[] maskKey = null;
            if (masked)
            {
                maskKey = new byte[4];
                RandomNumberGenerator.Create().GetBytes(maskKey);
            }

            if (payloadLen < 126)
            {
                byte lenByte = (byte)(payloadLen | (masked ? 0x80 : 0));
                ms.WriteByte(lenByte);
            }
            else if (payloadLen < 65536)
            {
                byte lenByte = (byte)(126 | (masked ? 0x80 : 0));
                ms.WriteByte(lenByte);
                ms.WriteByte((byte)(payloadLen >> 8));
                ms.WriteByte((byte)(payloadLen & 0xFF));
            }
            else
            {
                byte lenByte = (byte)(127 | (masked ? 0x80 : 0));
                ms.WriteByte(lenByte);
                long len64 = payloadLen;
                for (int i = 56; i >= 0; i -= 8)
                {
                    ms.WriteByte((byte)((len64 >> i) & 0xFF));
                }
            }

            if (masked && maskKey != null)
            {
                ms.Write(maskKey, 0, 4);
                byte[] maskedPayload = MaskData(payload, maskKey);
                ms.Write(maskedPayload, 0, maskedPayload.Length);
            }
            else
            {
                ms.Write(payload, 0, payload.Length);
            }

            return ms.ToArray();
        }

        /// <summary>
        /// Builds the close frame using the specified status
        /// </summary>
        /// <param name="status">The status</param>
        /// <param name="masked">The masked</param>
        /// <returns>The byte array</returns>
        private static byte[] BuildCloseFrame(WebSocketCloseStatus status = WebSocketCloseStatus.NormalClosure, bool masked = true)
        {
            ushort statusCode = (ushort)status;
            byte[] payload = new byte[]
            {
                (byte)((statusCode >> 8) & 0xFF),
                (byte)(statusCode & 0xFF)
            };

            using MemoryStream ms = new MemoryStream();
            ms.WriteByte(0x88);

            byte[] maskKey = null;
            if (masked)
            {
                maskKey = new byte[4];
                RandomNumberGenerator.Create().GetBytes(maskKey);
            }

            if (payload.Length < 126)
            {
                byte lenByte = (byte)(payload.Length | (masked ? 0x80 : 0));
                ms.WriteByte(lenByte);
            }

            if (masked && maskKey != null)
            {
                ms.Write(maskKey, 0, 4);
                byte[] maskedPayload = MaskData(payload, maskKey);
                ms.Write(maskedPayload, 0, maskedPayload.Length);
            }
            else
            {
                ms.Write(payload, 0, payload.Length);
            }

            return ms.ToArray();
        }

        /// <summary>
        /// Connects the and handshake using the specified host
        /// </summary>
        /// <param name="host">The host</param>
        /// <param name="port">The port</param>
        /// <returns>A task containing the tcp client client network stream stream</returns>
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
        /// Tests that accept connections async client connects handles connection
        /// </summary>
        [Fact]
        public async Task AcceptConnectionsAsync_ClientConnects_HandlesConnection()
        {
            int port = GetNextPort();
            using var transport = new WebSocketNetworkTransport(new Uri($"ws://127.0.0.1:{port}"));
            await transport.StartAsync();
            Assert.Equal(NetworkTransportState.Connected, transport.State);

            using (TcpClient client = new TcpClient())
            {
                await client.ConnectAsync("127.0.0.1", port);
                NetworkStream ns = client.GetStream();

                string key = CreateWebSocketKey();
                string request = BuildWebSocketUpgradeRequest("127.0.0.1", port, key);
                byte[] reqBytes = Encoding.UTF8.GetBytes(request);
                await ns.WriteAsync(reqBytes, 0, reqBytes.Length);

                byte[] respBuf = new byte[4096];
                int read = await ns.ReadAsync(respBuf, 0, respBuf.Length);
                string response = Encoding.UTF8.GetString(respBuf, 0, read);
                Assert.Contains("101 Switching Protocols", response);
            }

            await transport.StopAsync();
            Assert.Equal(NetworkTransportState.Disconnected, transport.State);
        }

        /// <summary>
        /// Tests that accept connections async non web socket request returns gracefully
        /// </summary>
        [Fact]
        public async Task AcceptConnectionsAsync_NonWebSocketRequest_ReturnsGracefully()
        {
            int port = GetNextPort();
            using var transport = new WebSocketNetworkTransport(new Uri($"ws://127.0.0.1:{port}"));
            await transport.StartAsync();

            using (TcpClient client = new TcpClient())
            {
                await client.ConnectAsync("127.0.0.1", port);
                NetworkStream ns = client.GetStream();

                string request = "GET / HTTP/1.1\r\nHost: 127.0.0.1\r\n\r\n";
                byte[] reqBytes = Encoding.UTF8.GetBytes(request);
                await ns.WriteAsync(reqBytes, 0, reqBytes.Length);

                // Server does not send response for non-WebSocket requests
                // Just verify no exception on the transport side
                await Task.Delay(200);
            }

            await transport.StopAsync();
            Assert.Equal(NetworkTransportState.Disconnected, transport.State);
        }

        /// <summary>
        /// Tests that receive from client async text frame enqueues message
        /// </summary>
        [Fact]
        public async Task ReceiveFromClientAsync_TextFrame_EnqueuesMessage()
        {
            int port = GetNextPort();
            using var transport = new WebSocketNetworkTransport(new Uri($"ws://127.0.0.1:{port}"));
            await transport.StartAsync();

            (TcpClient client, NetworkStream stream) = await ConnectAndHandshakeAsync("127.0.0.1", port);

            NetworkMessageEnvelope envelope = new NetworkMessageEnvelope
            {
                MessageId = "test-msg-1",
                MessageType = "test",
                SenderId = "sender-1",
                TargetId = "target-1",
                Channel = "default",
                Payload = "{\"hello\":\"world\"}",
                ServerTimestamp = 12345,
                ClientTimestamp = 67890,
                SequenceNumber = 1,
                IsReliable = true,
                IsOrdered = true
            };

            NetworkSerializer serializer = new NetworkSerializer();
            string json = serializer.SerializeEnvelope(envelope);
            byte[] frame = BuildTextFrame(json);
            await stream.WriteAsync(frame, 0, frame.Length);

            (string clientId, NetworkMessageEnvelope received) = await transport.ReceiveAsync();

            Assert.NotNull(clientId);
            Assert.NotNull(received);
            Assert.Equal(envelope.MessageId, received.MessageId);
            Assert.Equal(envelope.MessageType, received.MessageType);
            Assert.Equal(envelope.SenderId, received.SenderId);
            Assert.Equal(envelope.Payload, received.Payload);

            client.Close();
            await transport.StopAsync();
        }

        /// <summary>
        /// Tests that receive from client async close frame removes client
        /// </summary>
        [Fact]
        public async Task ReceiveFromClientAsync_CloseFrame_RemovesClient()
        {
            int port = GetNextPort();
            using var transport = new WebSocketNetworkTransport(new Uri($"ws://127.0.0.1:{port}"));
            await transport.StartAsync();

            (TcpClient client, NetworkStream stream) = await ConnectAndHandshakeAsync("127.0.0.1", port);

            byte[] closeFrame = BuildCloseFrame();
            await stream.WriteAsync(closeFrame, 0, closeFrame.Length);

            await Task.Delay(500);

            using CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();
            await Assert.ThrowsAsync<OperationCanceledException>(() => transport.ReceiveAsync(cts.Token));

            client.Close();
            await transport.StopAsync();
        }

        /// <summary>
        /// Tests that handle client async malformed data handles gracefully
        /// </summary>
        [Fact]
        public async Task HandleClientAsync_MalformedData_HandlesGracefully()
        {
            int port = GetNextPort();
            using var transport = new WebSocketNetworkTransport(new Uri($"ws://127.0.0.1:{port}"));
            await transport.StartAsync();

            using (TcpClient client = new TcpClient())
            {
                await client.ConnectAsync("127.0.0.1", port);
                NetworkStream ns = client.GetStream();

                byte[] garbage = Encoding.UTF8.GetBytes("NOT A VALID HTTP REQUEST\r\n\r\n");
                await ns.WriteAsync(garbage, 0, garbage.Length);

                await Task.Delay(300);
            }

            await transport.StopAsync();
            Assert.Equal(NetworkTransportState.Disconnected, transport.State);
        }

        /// <summary>
        /// Tests that send async to connected client sends message
        /// </summary>
        [Fact]
        public async Task SendAsync_ToConnectedClient_SendsMessage()
        {
            int port = GetNextPort();
            using var transport = new WebSocketNetworkTransport(new Uri($"ws://127.0.0.1:{port}"));
            await transport.StartAsync();

            (TcpClient client, NetworkStream stream) = await ConnectAndHandshakeAsync("127.0.0.1", port);

            NetworkMessageEnvelope inbound = new NetworkMessageEnvelope { MessageId = "get-client-id" };
            NetworkSerializer serializer = new NetworkSerializer();
            string inboundJson = serializer.SerializeEnvelope(inbound);
            byte[] inboundFrame = BuildTextFrame(inboundJson);
            await stream.WriteAsync(inboundFrame, 0, inboundFrame.Length);

            (string _, NetworkMessageEnvelope received) = await transport.ReceiveAsync();
            Assert.NotNull(received);
            Assert.Equal("get-client-id", received.MessageId);

            client.Close();
            await transport.StopAsync();
        }

        /// <summary>
        /// Tests that stop async with connected clients closes all
        /// </summary>
        [Fact]
        public async Task StopAsync_WithConnectedClients_ClosesAll()
        {
            int port = GetNextPort();
            using var transport = new WebSocketNetworkTransport(new Uri($"ws://127.0.0.1:{port}"));
            await transport.StartAsync();

            List<TcpClient> clients = new List<TcpClient>();
            for (int i = 0; i < 3; i++)
            {
                (TcpClient client, NetworkStream _) = await ConnectAndHandshakeAsync("127.0.0.1", port);
                clients.Add(client);
            }

            await transport.StopAsync();
            Assert.Equal(NetworkTransportState.Disconnected, transport.State);

            foreach (TcpClient client in clients)
            {
                client.Close();
            }
        }

        /// <summary>
        /// Tests that multiple clients can send and receive
        /// </summary>
        [Fact]
        public async Task MultipleClients_CanSendAndReceive()
        {
            int port = GetNextPort();
            using var transport = new WebSocketNetworkTransport(new Uri($"ws://127.0.0.1:{port}"));
            await transport.StartAsync();

            List<(TcpClient Client, NetworkStream Stream)> clients = new List<(TcpClient, NetworkStream)>();
            for (int i = 0; i < 2; i++)
            {
                (TcpClient c, NetworkStream s) = await ConnectAndHandshakeAsync("127.0.0.1", port);
                clients.Add((c, s));
            }

            NetworkMessageEnvelope envelope = new NetworkMessageEnvelope
            {
                MessageId = "multi-client",
                MessageType = "test",
                Payload = "multi-client-payload"
            };
            NetworkSerializer serializer = new NetworkSerializer();
            string json = serializer.SerializeEnvelope(envelope);

            foreach (var (client, stream) in clients)
            {
                byte[] frame = BuildTextFrame(json);
                await stream.WriteAsync(frame, 0, frame.Length);
            }

            for (int i = 0; i < 2; i++)
            {
                (string clientId, NetworkMessageEnvelope received) = await transport.ReceiveAsync();
                Assert.NotNull(clientId);
                Assert.Equal(envelope.MessageId, received.MessageId);
            }

            foreach (var (client, _) in clients)
            {
                client.Close();
            }

            await transport.StopAsync();
        }

        /// <summary>
        /// Tests that dispose with active connections cleans up
        /// </summary>
        [Fact]
        public async Task Dispose_WithActiveConnections_CleansUp()
        {
            int port = GetNextPort();
            WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri($"ws://127.0.0.1:{port}"));
            await transport.StartAsync();

            List<TcpClient> clients = new List<TcpClient>();
            for (int i = 0; i < 2; i++)
            {
                (TcpClient c, NetworkStream _) = await ConnectAndHandshakeAsync("127.0.0.1", port);
                clients.Add(c);
            }

            Exception ex = Record.Exception(() => transport.Dispose());
            Assert.Null(ex);

            foreach (TcpClient c in clients)
            {
                c.Close();
            }
        }

        /// <summary>
        /// Tests that start async stop async restart works
        /// </summary>
        [Fact]
        public async Task StartAsync_StopAsync_Restart_Works()
        {
            int port = GetNextPort();
            using var transport = new WebSocketNetworkTransport(new Uri($"ws://127.0.0.1:{port}"));
            await transport.StartAsync();
            Assert.Equal(NetworkTransportState.Connected, transport.State);
            await transport.StopAsync();
            Assert.Equal(NetworkTransportState.Disconnected, transport.State);

            await transport.StartAsync();
            Assert.Equal(NetworkTransportState.Connected, transport.State);

            (TcpClient client, NetworkStream stream) = await ConnectAndHandshakeAsync("127.0.0.1", port);

            NetworkMessageEnvelope envelope = new NetworkMessageEnvelope { MessageId = "restart-test" };
            NetworkSerializer serializer = new NetworkSerializer();
            string json = serializer.SerializeEnvelope(envelope);
            byte[] frame = BuildTextFrame(json);
            await stream.WriteAsync(frame, 0, frame.Length);

            (string clientId, NetworkMessageEnvelope received) = await transport.ReceiveAsync();
            Assert.Equal(envelope.MessageId, received.MessageId);

            client.Close();
            await transport.StopAsync();
        }

        /// <summary>
        /// Tests that accept connections async cancelled stops loop
        /// </summary>
        [Fact]
        public async Task AcceptConnectionsAsync_Cancelled_StopsLoop()
        {
            int port = GetNextPort();
            using var transport = new WebSocketNetworkTransport(new Uri($"ws://127.0.0.1:{port}"));
            using CancellationTokenSource cts = new CancellationTokenSource();
            Task startTask = transport.StartAsync(cts.Token);
            await startTask;

            await Task.Delay(200);

            await transport.StopAsync();
            Assert.Equal(NetworkTransportState.Disconnected, transport.State);
        }

        /// <summary>
        /// Tests that receive async sequential messages returns in order
        /// </summary>
        [Fact]
        public async Task ReceiveAsync_SequentialMessages_ReturnsInOrder()
        {
            int port = GetNextPort();
            using var transport = new WebSocketNetworkTransport(new Uri($"ws://127.0.0.1:{port}"));
            await transport.StartAsync();

            (TcpClient client, NetworkStream stream) = await ConnectAndHandshakeAsync("127.0.0.1", port);

            NetworkMessageEnvelope envelope1 = new NetworkMessageEnvelope { MessageId = "first", Payload = "payload1" };
            NetworkMessageEnvelope envelope2 = new NetworkMessageEnvelope { MessageId = "second", Payload = "payload2" };

            NetworkSerializer serializer = new NetworkSerializer();
            string json1 = serializer.SerializeEnvelope(envelope1);
            string json2 = serializer.SerializeEnvelope(envelope2);

            byte[] frame1 = BuildTextFrame(json1);
            byte[] frame2 = BuildTextFrame(json2);

            await stream.WriteAsync(frame1, 0, frame1.Length);
            await stream.WriteAsync(frame2, 0, frame2.Length);

            (string id1, NetworkMessageEnvelope msg1) = await transport.ReceiveAsync();
            (string id2, NetworkMessageEnvelope msg2) = await transport.ReceiveAsync();

            Assert.Equal("first", msg1.MessageId);
            Assert.Equal("second", msg2.MessageId);

            client.Close();
            await transport.StopAsync();
        }
    }
}
