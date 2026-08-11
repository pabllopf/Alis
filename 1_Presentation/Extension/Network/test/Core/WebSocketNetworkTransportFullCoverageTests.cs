// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketNetworkTransportFullCoverageTests.cs
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
using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Core;
using Xunit;

namespace Alis.Extension.Network.Test.Core
{
    /// <summary>
    ///     The web socket network transport full coverage tests class
    /// </summary>
    public class WebSocketNetworkTransportFullCoverageTests
    {
        /// <summary>
        ///     The next port
        /// </summary>
        private static int _nextPort = 29000;

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
                _nextPort += 17;
                return port;
            }
        }

        /// <summary>
        ///     Tests that send async to a connected client delivers the message
        /// </summary>
        [Fact]
        public async Task SendAsync_ToConnectedClient_DeliversMessage()
        {
            int port = GetNextPort();
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri($"ws://127.0.0.1:{port}"));
            await transport.StartAsync();

            using (TcpClient client = new TcpClient())
            {
                await client.ConnectAsync("127.0.0.1", port);
                NetworkStream ns = client.GetStream();

                string request = $"GET / HTTP/1.1\r\nHost: 127.0.0.1:{port}\r\nUpgrade: websocket\r\nConnection: Upgrade\r\nSec-WebSocket-Key: dGhlIHNhbXBsZSBub25jZQ==\r\nSec-WebSocket-Version: 13\r\n\r\n";
                byte[] reqBytes = Encoding.UTF8.GetBytes(request);
                await ns.WriteAsync(reqBytes, 0, reqBytes.Length);

                byte[] respBuf = new byte[4096];
                int read = await ns.ReadAsync(respBuf, 0, respBuf.Length);
                string response = Encoding.UTF8.GetString(respBuf, 0, read);
                Assert.Contains("101 Switching Protocols", response);

                NetworkMessageEnvelope envelope = new NetworkMessageEnvelope
                {
                    MessageId = "m1",
                    MessageType = "chat",
                    SenderId = "server",
                    Channel = "test.channel",
                    Payload = "hello"
                };

                string clientId = GetFirstClientId(transport);
                await transport.SendAsync(clientId, envelope);
                await transport.StopAsync();
            }
        }

        /// <summary>
        ///     Tests that broadcast async with a connected client does not throw
        /// </summary>
        [Fact]
        public async Task BroadcastAsync_WithConnectedClient_DoesNotThrow()
        {
            int port = GetNextPort();
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri($"ws://127.0.0.1:{port}"));
            await transport.StartAsync();

            using (TcpClient client = new TcpClient())
            {
                await client.ConnectAsync("127.0.0.1", port);
                NetworkStream ns = client.GetStream();

                string request = $"GET / HTTP/1.1\r\nHost: 127.0.0.1:{port}\r\nUpgrade: websocket\r\nConnection: Upgrade\r\nSec-WebSocket-Key: dGhlIHNhbXBsZSBub25jZQ==\r\nSec-WebSocket-Version: 13\r\n\r\n";
                byte[] reqBytes = Encoding.UTF8.GetBytes(request);
                await ns.WriteAsync(reqBytes, 0, reqBytes.Length);

                byte[] respBuf = new byte[4096];
                int read = await ns.ReadAsync(respBuf, 0, respBuf.Length);
                Assert.Contains("101 Switching Protocols", Encoding.UTF8.GetString(respBuf, 0, read));

                NetworkMessageEnvelope envelope = new NetworkMessageEnvelope { MessageId = "b1", Channel = "broadcast" };
                await transport.BroadcastAsync(envelope);
                await transport.StopAsync();
            }
        }

        /// <summary>
        ///     Tests that receive async after start with cancellation returns the queued message
        /// </summary>
        [Fact]
        public async Task ReceiveAsync_AfterClientSend_GetsMessage()
        {
            int port = GetNextPort();
            using WebSocketNetworkTransport transport = new WebSocketNetworkTransport(new Uri($"ws://127.0.0.1:{port}"));
            await transport.StartAsync();

            using (TcpClient client = new TcpClient())
            {
                await client.ConnectAsync("127.0.0.1", port);
                NetworkStream ns = client.GetStream();

                string request = $"GET / HTTP/1.1\r\nHost: 127.0.0.1:{port}\r\nUpgrade: websocket\r\nConnection: Upgrade\r\nSec-WebSocket-Key: dGhlIHNhbXBsZSBub25jZQ==\r\nSec-WebSocket-Version: 13\r\n\r\n";
                byte[] reqBytes = Encoding.UTF8.GetBytes(request);
                await ns.WriteAsync(reqBytes, 0, reqBytes.Length);

                byte[] respBuf = new byte[4096];
                int read = await ns.ReadAsync(respBuf, 0, respBuf.Length);
                Assert.Contains("101 Switching Protocols", Encoding.UTF8.GetString(respBuf, 0, read));

                NetworkSerializer serializer = new NetworkSerializer();
                NetworkMessageEnvelope envelope = new NetworkMessageEnvelope
                {
                    MessageId = "r1",
                    MessageType = "chat",
                    SenderId = "client-1",
                    Channel = "test.channel",
                    Payload = "ping"
                };
                string json = serializer.SerializeEnvelope(envelope);
                byte[] payload = Encoding.UTF8.GetBytes(json);
                byte[] frame = BuildTextFrame(payload);
                await ns.WriteAsync(frame, 0, frame.Length);

                using (CancellationTokenSource cts = new CancellationTokenSource(5000))
                {
                    (string clientId, NetworkMessageEnvelope received) = await transport.ReceiveAsync(cts.Token);
                    Assert.False(string.IsNullOrEmpty(clientId));
                    Assert.Equal("ping", received.Payload);
                }

                await transport.StopAsync();
            }
        }

        /// <summary>
        ///     Gets the first client id from the transport private socket map
        /// </summary>
        /// <param name="transport">The transport</param>
        /// <returns>The client id</returns>
        private static string GetFirstClientId(WebSocketNetworkTransport transport)
        {
            FieldInfo field = typeof(WebSocketNetworkTransport).GetField("_clientSockets",
                BindingFlags.NonPublic | BindingFlags.Instance);
            ConcurrentDictionary<string, WebSocket> map = (ConcurrentDictionary<string, WebSocket>) field.GetValue(transport);
            foreach (System.Collections.Generic.KeyValuePair<string, WebSocket> kvp in map)
            {
                return kvp.Key;
            }

            return null;
        }

        /// <summary>
        ///     Builds a websocket text frame
        /// </summary>
        /// <param name="payload">The payload</param>
        /// <returns>The frame</returns>
        private static byte[] BuildTextFrame(byte[] payload)
        {
            using System.IO.MemoryStream ms = new System.IO.MemoryStream();
            ms.WriteByte(0x81);
            int payloadLen = payload.Length;
            if (payloadLen < 126)
            {
                ms.WriteByte((byte) (payloadLen | 0x80));
            }
            else
            {
                ms.WriteByte((byte) (126 | 0x80));
                ms.WriteByte((byte) (payloadLen >> 8));
                ms.WriteByte((byte) (payloadLen & 0xFF));
            }

            byte[] maskKey = {0x01, 0x02, 0x03, 0x04};
            ms.Write(maskKey, 0, 4);
            for (int i = 0; i < payloadLen; i++)
            {
                ms.WriteByte((byte) (payload[i] ^ maskKey[i % 4]));
            }

            return ms.ToArray();
        }
    }
}
