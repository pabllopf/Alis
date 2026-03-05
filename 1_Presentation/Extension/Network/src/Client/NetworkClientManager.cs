// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkClientManager.cs
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
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Aspect.Data.Json;
using Alis.Extension.Network.Core;

namespace Alis.Extension.Network.Client
{
    /// <summary>
    ///     Client-side network manager implementation
    /// </summary>
    public class NetworkClientManager : Core.INetworkClientManager
    {
        /// <summary>
        /// The id
        /// </summary>
        private string _id;
        /// <summary>
        /// The uninitialized
        /// </summary>
        private NetworkManagerState _state = NetworkManagerState.Uninitialized;
        /// <summary>
        /// The config
        /// </summary>
        private NetworkConfig _config;
        /// <summary>
        /// The current session
        /// </summary>
        private NetworkSession _currentSession;
        /// <summary>
        /// The local player
        /// </summary>
        private NetworkPlayer _localPlayer;
        /// <summary>
        /// The serializer
        /// </summary>
        private INetworkSerializer _serializer;
        /// <summary>
        /// The server socket
        /// </summary>
        private WebSocket _serverSocket;
        /// <summary>
        /// The server uri
        /// </summary>
        private Uri _serverUri;
        /// <summary>
        /// The cancellation token source
        /// </summary>
        private CancellationTokenSource _cancellationTokenSource;
        /// <summary>
        /// The message handlers
        /// </summary>
        private readonly ConcurrentDictionary<string, Func<string, string, Task>> _messageHandlers;
        /// <summary>
        /// The lock object
        /// </summary>
        private readonly object _lockObject = new object();
        /// <summary>
        /// The is disposed
        /// </summary>
        private bool _isDisposed;

        /// <summary>
        ///     Initializes client manager
        /// </summary>
        public NetworkClientManager()
        {
            _id = Guid.NewGuid().ToString();
            _messageHandlers = new ConcurrentDictionary<string, Func<string, string, Task>>();
        }

        /// <summary>
        ///     Gets manager identifier
        /// </summary>
        public string Id => _id;

        /// <summary>
        ///     Gets current network state
        /// </summary>
        public NetworkManagerState State => _state;

        /// <summary>
        ///     Gets current session
        /// </summary>
        public NetworkSession CurrentSession => _currentSession;

        /// <summary>
        ///     Gets local player
        /// </summary>
        public NetworkPlayer LocalPlayer => _localPlayer;

        /// <summary>
        ///     Gets configuration
        /// </summary>
        public NetworkConfig Config => _config;

        /// <summary>
        ///     Gets server URI
        /// </summary>
        public Uri ServerUri => _serverUri;

        /// <summary>
        ///     Player joined event
        /// </summary>
        public event EventHandler<Core.PlayerEventArgs> PlayerJoined;

        /// <summary>
        ///     Player left event
        /// </summary>
        public event EventHandler<Core.PlayerEventArgs> PlayerLeft;

        /// <summary>
        ///     Connected event
        /// </summary>
        public event EventHandler<EventArgs> Connected;

        /// <summary>
        ///     Disconnected event
        /// </summary>
        public event EventHandler<EventArgs> Disconnected;

        /// <summary>
        ///     Error event
        /// </summary>
        public event EventHandler<Core.NetworkErrorEventArgs> Error;

        /// <summary>
        ///     Server message received event
        /// </summary>
        public event EventHandler<ServerMessageEventArgs> ServerMessageReceived;

        /// <summary>
        ///     Initializes manager
        /// </summary>
        public async Task InitializeAsync(Core.NetworkConfig config, CancellationToken cancellationToken = default)
        {
            lock (_lockObject)
            {
                if (_state != Core.NetworkManagerState.Uninitialized)
                    throw new InvalidOperationException("Already initialized");

                _state = Core.NetworkManagerState.Idle;
                _config = config ?? new Core.NetworkConfig();
                _serializer = new Core.NetworkSerializer();
            }

            await Task.CompletedTask;
        }

        /// <summary>
        ///     Starts manager
        /// </summary>
        public async Task StartAsync(CancellationToken cancellationToken = default)
        {
            lock (_lockObject)
            {
                if (_state != Core.NetworkManagerState.Idle && _state != Core.NetworkManagerState.Disconnected)
                    throw new InvalidOperationException("Cannot start in current state");
            }

            await Task.CompletedTask;
        }

        /// <summary>
        ///     Stops manager
        /// </summary>
        public async Task StopAsync(CancellationToken cancellationToken = default)
        {
            await DisconnectAsync(cancellationToken);
        }

        /// <summary>
        ///     Connects to server
        /// </summary>
        public async Task ConnectAsync(Uri serverUri, string playerName, CancellationToken cancellationToken = default)
        {
            lock (_lockObject)
            {
                if (_state != NetworkManagerState.Idle && _state != NetworkManagerState.Disconnected)
                    throw new InvalidOperationException("Cannot connect in current state");

                _state = NetworkManagerState.Connecting;
            }

            try
            {
                _serverUri = serverUri;

                WebSocketClientFactory factory = new WebSocketClientFactory();
                _serverSocket = await factory.ConnectAsync(serverUri, cancellationToken);

                _localPlayer = new NetworkPlayer
                {
                    PlayerId = Guid.NewGuid().ToString(),
                    PlayerName = playerName,
                    ConnectionState = PlayerConnectionState.Connected,
                    JoinedAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
                };

                _cancellationTokenSource = new CancellationTokenSource();
                _ = ReceiveMessagesAsync(_cancellationTokenSource.Token);

                lock (_lockObject)
                {
                    _state = NetworkManagerState.Connected;
                }

                // Send handshake to register on server
                var handshakeMsg = new System.Collections.Generic.Dictionary<string, string>
                {
                    { "action", "join" },
                    { "playerId", _localPlayer.PlayerId },
                    { "playerName", _localPlayer.PlayerName }
                };
                var handshakePayload = $"{{\"action\":\"join\",\"playerId\":\"{_localPlayer.PlayerId}\",\"playerName\":\"{_localPlayer.PlayerName}\"}}";
                var handshakeEnvelope = new NetworkMessageEnvelope
                {
                    MessageId = Guid.NewGuid().ToString(),
                    MessageType = "system",
                    SenderId = _localPlayer.PlayerId,
                    Channel = "system.join",
                    Payload = handshakePayload,
                    ClientTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                    IsReliable = true,
                    SequenceNumber = 0
                };
                string handshakeJson = _serializer.SerializeEnvelope(handshakeEnvelope);
                byte[] handshakeBuffer = Encoding.UTF8.GetBytes(handshakeJson);
                await _serverSocket.SendAsync(new ArraySegment<byte>(handshakeBuffer), WebSocketMessageType.Text, true, CancellationToken.None);

                Connected?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                lock (_lockObject)
                {
                    _state = NetworkManagerState.Error;
                }

                Error?.Invoke(this, new NetworkErrorEventArgs("Failed to connect to server", ex));
                throw;
            }
        }

        /// <summary>
        ///     Disconnects from server
        /// </summary>
        public async Task DisconnectAsync(CancellationToken cancellationToken = default)
        {
            lock (_lockObject)
            {
                if (_state == Core.NetworkManagerState.Disconnected || _state == Core.NetworkManagerState.Uninitialized)
                    return;

                _state = Core.NetworkManagerState.Disconnecting;
            }

            try
            {
                _cancellationTokenSource?.Cancel();

                if (_serverSocket != null && _serverSocket.State == WebSocketState.Open)
                {
                    await _serverSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, null, cancellationToken);
                }

                _serverSocket?.Dispose();
                _serverSocket = null;
                _currentSession = null;
                _localPlayer = null;

                lock (_lockObject)
                {
                    _state = Core.NetworkManagerState.Disconnected;
                }

                Disconnected?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Error?.Invoke(this, new Core.NetworkErrorEventArgs("Error during disconnect", ex));
            }
        }

        /// <summary>
        ///     Sends message to specific player
        /// </summary>
        public async Task SendMessageAsync<T>(string targetPlayerId, string channel, T message, bool reliable = true) where T : IJsonSerializable
        {
            if (_serverSocket == null || _serverSocket.State != WebSocketState.Open)
                throw new InvalidOperationException("Not connected to server");

            string payload = _serializer.Serialize(message);
            var envelope = new Core.NetworkMessageEnvelope
            {
                MessageId = Guid.NewGuid().ToString(),
                MessageType = typeof(T).Name,
                SenderId = _localPlayer?.PlayerId,
                TargetId = targetPlayerId,
                Channel = channel,
                Payload = payload,
                ClientTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                IsReliable = reliable,
                SequenceNumber = (uint)(DateTime.UtcNow.Ticks % uint.MaxValue)
            };

            string json = _serializer.SerializeEnvelope(envelope);
            byte[] buffer = Encoding.UTF8.GetBytes(json);

            await _serverSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        /// <summary>
        ///     Broadcasts message
        /// </summary>
        public async Task BroadcastMessageAsync<T>(string channel, T message, bool reliable = true, string exceptPlayerId = null) where T : IJsonSerializable
        {
            if (_serverSocket == null || _serverSocket.State != WebSocketState.Open)
                throw new InvalidOperationException("Not connected to server");

            string payload = _serializer.Serialize(message);
            var envelope = new Core.NetworkMessageEnvelope
            {
                MessageId = Guid.NewGuid().ToString(),
                MessageType = typeof(T).Name,
                SenderId = _localPlayer?.PlayerId,
                TargetId = null,
                Channel = channel,
                Payload = payload,
                ClientTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                IsReliable = reliable,
                SequenceNumber = (uint)(DateTime.UtcNow.Ticks % uint.MaxValue)
            };

            string json = _serializer.SerializeEnvelope(envelope);
            byte[] buffer = Encoding.UTF8.GetBytes(json);

            await _serverSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        /// <summary>
        ///     Registers message handler
        /// </summary>
        public void RegisterMessageHandler(string channel, Func<string, string, Task> handler)
        {
            _messageHandlers.AddOrUpdate(channel, handler, (key, old) => handler);
        }

        /// <summary>
        ///     Unregisters message handler
        /// </summary>
        public void UnregisterMessageHandler(string channel)
        {
            _messageHandlers.TryRemove(channel, out _);
        }

        /// <summary>
        ///     Gets connected players
        /// </summary>
        public IReadOnlyList<Core.NetworkPlayer> GetConnectedPlayers()
        {
            return _currentSession?.Players ?? new List<Core.NetworkPlayer>();
        }

        /// <summary>
        ///     Gets player by ID
        /// </summary>
        public Core.NetworkPlayer GetPlayer(string playerId)
        {
            return _currentSession?.Players.Find(p => p.PlayerId == playerId);
        }

        /// <summary>
        ///     Receives messages from server
        /// </summary>
        private async Task ReceiveMessagesAsync(CancellationToken cancellationToken)
        {
            byte[] buffer = new byte[1024 * 64];

            try
            {
                while (_serverSocket.State == WebSocketState.Open && !cancellationToken.IsCancellationRequested)
                {
                    WebSocketReceiveResult result = await _serverSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await _serverSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, null, cancellationToken);
                        break;
                    }

                    string json = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    var envelope = _serializer.DeserializeEnvelope(json);

                    if (_messageHandlers.TryGetValue(envelope.Channel, out var handler))
                    {
                        await handler(envelope.SenderId, envelope.Payload);
                    }

                    ServerMessageReceived?.Invoke(this, new ServerMessageEventArgs(envelope.Channel, envelope.Payload));
                }
            }
            catch (Exception ex)
            {
                Error?.Invoke(this, new Core.NetworkErrorEventArgs("Error receiving messages", ex));
            }
            finally
            {
                await DisconnectAsync();
            }
        }

        /// <summary>
        ///     Disposes manager
        /// </summary>
        public void Dispose()
        {
            if (_isDisposed)
                return;

            _isDisposed = true;

            try
            {
                DisconnectAsync().Wait(TimeSpan.FromSeconds(5));
            }
            catch (Exception)
            {
                // Ignore disposal errors
            }

            _cancellationTokenSource?.Dispose();
            _serverSocket?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

