// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketNetworkTransport.cs
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
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Alis.Extension.Network.Core
{
    /// <summary>
    ///     WebSocket-based network transport implementation
    /// </summary>
    public class WebSocketNetworkTransport : INetworkTransport
    {
        /// <summary>
        /// The disconnected
        /// </summary>
        private NetworkTransportState _state = NetworkTransportState.Disconnected;
        /// <summary>
        /// The serializer
        /// </summary>
        private readonly INetworkSerializer _serializer;
        /// <summary>
        /// The client sockets
        /// </summary>
        private readonly ConcurrentDictionary<string, WebSocket> _clientSockets;
        /// <summary>
        /// The message queue
        /// </summary>
        private readonly ConcurrentQueue<(string ClientId, NetworkMessageEnvelope Message)> _messageQueue;
        /// <summary>
        /// The tcp listener
        /// </summary>
        private TcpListener _tcpListener;
        /// <summary>
        /// The is disposed
        /// </summary>
        private bool _isDisposed;
        /// <summary>
        /// The lock object
        /// </summary>
        private readonly object _lockObject = new object();
        /// <summary>
        /// The listen uri
        /// </summary>
        private Uri _listenUri;
        /// <summary>
        /// The host
        /// </summary>
        private string _host;
        /// <summary>
        /// The port
        /// </summary>
        private int _port;

        /// <summary>
        ///     Initializes transport with Uri configuration
        /// </summary>
        public WebSocketNetworkTransport(Uri listenUri = null)
        {
            _serializer = new NetworkSerializer();
            _clientSockets = new ConcurrentDictionary<string, WebSocket>();
            _messageQueue = new ConcurrentQueue<(string, NetworkMessageEnvelope)>();
            _listenUri = listenUri ?? new Uri("ws://127.0.0.1:8888/");
            _host = _listenUri.Host;
            _port = _listenUri.Port > 0 ? _listenUri.Port : 8888;
        }

        /// <summary>
        ///     Gets transport state
        /// </summary>
        public NetworkTransportState State => _state;

        /// <summary>
        ///     Sends message to specific client
        /// </summary>
        public async Task SendAsync(string clientId, NetworkMessageEnvelope message, CancellationToken cancellationToken = default)
        {
            if (!_clientSockets.TryGetValue(clientId, out WebSocket socket))
                throw new InvalidOperationException($"Client {clientId} not found");

            if (socket.State != WebSocketState.Open)
                throw new InvalidOperationException($"Client {clientId} connection not open");

            string json = _serializer.SerializeEnvelope(message);
            byte[] buffer = Encoding.UTF8.GetBytes(json);

            await socket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, cancellationToken);
        }

        /// <summary>
        ///     Broadcasts message to all clients
        /// </summary>
        public async Task BroadcastAsync(NetworkMessageEnvelope message, string exceptClientId = null, CancellationToken cancellationToken = default)
        {
            string json = _serializer.SerializeEnvelope(message);
            byte[] buffer = Encoding.UTF8.GetBytes(json);

            List<Task> tasks = new List<Task>();

            foreach (KeyValuePair<string, WebSocket> kvp in _clientSockets)
            {
                if (kvp.Key == exceptClientId || kvp.Value.State != WebSocketState.Open)
                    continue;

                tasks.Add(kvp.Value.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, cancellationToken));
            }

            await Task.WhenAll(tasks);
        }

        /// <summary>
        ///     Receives next message from queue
        /// </summary>
        public async Task<(string ClientId, NetworkMessageEnvelope Message)> ReceiveAsync(CancellationToken cancellationToken = default)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                if (_messageQueue.TryDequeue(out (string ClientId, NetworkMessageEnvelope Message) message))
                    return message;

                await Task.Delay(10, cancellationToken);
            }

            throw new OperationCanceledException();
        }

        /// <summary>
        ///     Starts listening for connections
        /// </summary>
        public Task StartAsync(CancellationToken cancellationToken = default)
        {
            lock (_lockObject)
            {
                if (_state != NetworkTransportState.Disconnected)
                    throw new InvalidOperationException("Transport already started");

                _state = NetworkTransportState.Connecting;
            }

            try
            {
                IPAddress ipAddress = IPAddress.Parse(_host);
                _tcpListener = new TcpListener(ipAddress, _port);
                _tcpListener.Start();
                _state = NetworkTransportState.Connected;

                _ = AcceptConnectionsAsync(cancellationToken);
                return Task.CompletedTask;
            }
            catch (Exception)
            {
                _state = NetworkTransportState.Disconnected;
                throw;
            }
        }

        /// <summary>
        ///     Stops listening
        /// </summary>
        public async Task StopAsync(CancellationToken cancellationToken = default)
        {
            lock (_lockObject)
            {
                if (_state == NetworkTransportState.Disconnected || _state == NetworkTransportState.Disconnecting)
                    return;

                _state = NetworkTransportState.Disconnecting;
            }

            try
            {
                _tcpListener?.Stop();

                List<Task> tasks = new List<Task>();
                foreach (WebSocket socket in _clientSockets.Values)
                {
                    if (socket.State == WebSocketState.Open)
                    {
                        tasks.Add(socket.CloseAsync(WebSocketCloseStatus.NormalClosure, null, cancellationToken));
                    }
                }

                await Task.WhenAll(tasks);
                _clientSockets.Clear();
                _state = NetworkTransportState.Disconnected;
            }
            catch (Exception)
            {
                _state = NetworkTransportState.Disconnected;
                throw;
            }
        }

        /// <summary>
        ///     Accepts incoming connections
        /// </summary>
        private async Task AcceptConnectionsAsync(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested && _state == NetworkTransportState.Connected)
                {
                    TcpClient tcpClient = await _tcpListener.AcceptTcpClientAsync();
                    _ = HandleClientAsync(tcpClient, cancellationToken);
                }
            }
            catch (ObjectDisposedException)
            {
                // Listener stopped
            }
        }

        /// <summary>
        ///     Handles client connection
        /// </summary>
        private async Task HandleClientAsync(TcpClient tcpClient, CancellationToken cancellationToken)
        {
            string clientId = Guid.NewGuid().ToString();

            try
            {
                using (tcpClient)
                {
                    Stream stream = tcpClient.GetStream();
                    IWebSocketServerFactory factory = new WebSocketServerFactory();
                    WebSocketHttpContext context = await factory.ReadHttpHeaderFromStreamAsync(stream, cancellationToken);

                    if (!context.IsWebSocketRequest)
                    {
                        return;
                    }

                    WebSocket socket = await factory.AcceptWebSocketAsync(context, new WebSocketServerOptions(), cancellationToken);
                    _clientSockets.TryAdd(clientId, socket);

                    await ReceiveFromClientAsync(clientId, socket, cancellationToken);
                }
            }
            catch (Exception)
            {
                _clientSockets.TryRemove(clientId, out _);
            }
        }

        /// <summary>
        ///     Receives messages from client
        /// </summary>
        private async Task ReceiveFromClientAsync(string clientId, WebSocket socket, CancellationToken cancellationToken)
        {
            byte[] buffer = new byte[1024 * 64];

            try
            {
                while (socket.State == WebSocketState.Open && !cancellationToken.IsCancellationRequested)
                {
                    WebSocketReceiveResult result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, null, cancellationToken);
                        break;
                    }

                    string json = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    NetworkMessageEnvelope envelope = _serializer.DeserializeEnvelope(json);
                    _messageQueue.Enqueue((clientId, envelope));
                }
            }
            catch (Exception)
            {
                // Connection error
            }
            finally
            {
                _clientSockets.TryRemove(clientId, out _);
                socket?.Dispose();
            }
        }

        /// <summary>
        ///     Disposes transport
        /// </summary>
        public void Dispose()
        {
            if (_isDisposed)
                return;

            _isDisposed = true;

            try
            {
                StopAsync().Wait(TimeSpan.FromSeconds(5));
            }
            catch (Exception)
            {
                // Ignore disposal errors
            }

            _tcpListener?.Stop();

            foreach (WebSocket socket in _clientSockets.Values)
            {
                socket?.Dispose();
            }

            _clientSockets.Clear();
            GC.SuppressFinalize(this);
        }
    }
}

